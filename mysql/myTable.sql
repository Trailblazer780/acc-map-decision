-- Host: localhost:3306
-- Generation Time: Sep 25, 2016 at 10:48 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

CREATE TABLE IF NOT EXISTS `tblUsers` (
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL,
  Primary Key (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO `tblUsers` (`username`, `password`, `salt`) VALUES
('Ethan', 'J8KyEuRtSyN3eZuhwKpa9Ob/6ZGVT2ki1z4lxL3tuM0=', 'HAsTR1XIUynLxYCIwA2zdg==');