using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace accmapdecision.Models {
    public class WebLoginModel : DbContext {
        private string connectionString;
        private HttpContext context;
        // property private variables
        [Required]
        private string _username;
        [Required]
        private string _password;
		// private string _username;
		// private string _password;
		private bool _access;
        private DbSet<User> tblUsers { get; set; }

        public WebLoginModel(string myConnectionString, HttpContext myHttpContext){
            // initilization
			_username = "";
			_password = "";
			_access = false;

			connectionString = myConnectionString;
			context = myHttpContext;
			// clear out the session variable
			context.Session.Clear();
        }

        
		// ------------------------------------------------------- gets / sets
        public List<User> users {
            get {
                return tblUsers.ToList();
            }
        }
        [Required]
		public string username {
            get {
                return _username;
            }
			set { _username = (value == null ? "" : value); }
		}
        [Required]
		public string password {
            get {
                return _password;
            }
			set { _password = (value == null ? "" : value); }
		}
		public bool access {
			get { return _access; }
		}
        // ------------------------------------------------------- public methods
        public bool Login() {
            // check if the username and password are valid
            _access = false;
            User usernametest = tblUsers.Where(u => u.username == _username).FirstOrDefault<User>();
            if(usernametest == null) {
                _access = false;
                return _access;
            }
            else {
                string hashedPassword = getHashed(_password, usernametest.salt);
                if (usernametest.password == hashedPassword) {
                    _access = true;
                    context.Session.SetString("auth", "true");
                    context.Session.SetString("username", _username);
                }
                else {
                    _access = false;
                    context.Session.SetString("auth", "false");
                }
            }
            
            return _access;
        }

        // ------------------------------------------------------- private methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }

        private string getSalt() {
			// generate a 128-bit salt using a secure PRNG (pseudo-random number generator)
			byte[] salt = new byte[128 / 8];
			using (var rng = RandomNumberGenerator.Create()) {
				rng.GetBytes(salt);
			}
			//Console.WriteLine(">>> Salt: " + Convert.ToBase64String(salt));

			return Convert.ToBase64String(salt);
		}
        private string getHashed(string myPassword, string mySalt) {
			// convert string to Byte[] for hashing
			byte[] salt = Convert.FromBase64String(mySalt);
	
			// hashing done using PBKDF2 algorithm
			// derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
			string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
				password: myPassword,
				salt: salt,
				prf: KeyDerivationPrf.HMACSHA1,
				iterationCount: 10000,
				numBytesRequested: 256 / 8));
			//Console.WriteLine(">>> Hashed: " + hashed);
            // Console.WriteLine(myPassword + "salt " + mySalt);

			return hashed;
		}
        private string truncate(string value, int maxLength) {
			return value.Length <= maxLength ? value : value.Substring(0, maxLength); 
		}
    }
}