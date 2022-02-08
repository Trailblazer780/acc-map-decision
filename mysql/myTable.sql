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


-- MySQL dump 10.13  Distrib 8.0.22, for Win64 (x86_64)
--
-- Host: localhost    Database: nscc_acc
-- ------------------------------------------------------
-- Server version	8.0.21

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course` (
  `id` int NOT NULL AUTO_INCREMENT,
  `course_code` varchar(20) DEFAULT NULL,
  `course_name` varchar(255) DEFAULT 'None',
  `course_units` float DEFAULT '1',
  `course_description` varchar(500) DEFAULT NULL,
  `course_rationale` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `course_code_UNIQUE` (`course_code`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (1,'BIOL 1046','College Biology I',1.5,'College Biology I is presented as an introductory general course at the post-secondary level and will prepare students for further study. This course covers scientific methodology, plant and animal biology, biochemistry, cytology and genetics. The modes of instruction vary between lecture, discussion, experiments and discovery. ','The purpose of this course, in conjunction with Biology 1047, is to provide students with the academic biology skills required or recommended for entrance into college and other post-secondary programs with academic biology pre-requisites such as Dental Assisting, Medical Laboratory  Technology,  Pharmacy  Technology,  Water Resources and Nursing. '),
(2,'BIOL 1047','College Biology II',1.5,'College Biology II is a continuation of Biology I and will prepare students for further study. This course covers evolution, and human anatomy and physiology with an option to include a research project in an area of the student\'s interest. The modes of instruction vary between lecture, discussion, experiments and discovery. ','The purpose of this course is to provide students with the academic biology skills required or recommended for entrance into college and other post-secondary programs with academic biology pre-requisites such as Dental Assisting,  Medical Laboratory  Technology,  Pharmacy  Technology,  Water Resources and Nursing.'),
(3,'CHEM 1046','College Chemistry I',1.5,'Chemistry I and Chemistry II are presented as introductory general courses at the post-secondary level, and will prepare students for further study. These courses start with definitions of matter, and fundamentals of chemistry such as the atom and elements, and proceed through to qualitative and quantitative problem solving. The modes of instruction vary between lecture and discovery with plenty of time given to allowing the student to carry out calculations, online interactive research, tutoria','The purpose of this course is to provide students with the academic chemistry skills required for entrance into college or university programs with academic chemistry pre-requisites such as  Water Resources  Technology, Nursing, Dental Assisting and Pharmacy  Technology.'),
(4,'CHEM 1047','College Chemistry II',1.5,'Chemistry I and Chemistry II are presented as introductory general courses at the post-secondary level, and will prepare students for further study. These courses start with definitions of matter, and fundamentals of chemistry such as the atom and elements, and proceed through to qualitative and quantitative problem solving. The modes of instruction vary between lecture and discovery with plenty of time given to allowing the student to carry out calculations, online interactive research, tutoria','The purpose of this course is to provide students with the academic chemistry skills required for entrance into college or university programs with academic chemistry pre-requisites such as  Water Resources  Technology, Nursing, Dental Assisting and Pharmacy  Technology. '),
(5,'MATH 1048','College Health Mathematics I',1,'College Health Mathematics I and II offers theoretical and applied skills, with emphasis on applied problem-solving process and strategies. Concepts will be taught with a focus on preparing students for further study in college Health Programs. (Students considering University programs must consult with university admission requirements where applicable). ','The purpose of College Health Mathematics I and II is to provide students with the mathematical skills required for entrance into college or some university programs with academic mathematics pre-requisites, such as Medical Laboratory  Technician,  Pharmacy  Technician, Practical Nursing, and other allied health programs (the student must consult with university requirements). '),
(6,'MATH 1049','College Health Mathematics II',1,'College Health Mathematics I and II offers theoretical and applied skills, with emphasis on applied problem-solving process and strategies. Concepts will be taught with a focus on preparing students for further study in college Health Programs. (Students considering University programs must consult with university admission requirements where applicable). ','The purpose of College Health Mathematics I and II is to provide students with the mathematical skills required for entrance into college or some university programs with academic mathematics pre-requisites, such as Medical Laboratory  Technician,  Pharmacy  Technician, Practical Nursing, and other allied health programs (the student must consult with university requirements). '),
(7,'MATH 1046','College Mathematics I',1.5,'This course offers theoretical and applied mathematical skills, with reference to problem-solving process and strategies. Mathematical concepts will be taught with a focus on preparing students for further technical or scientific study.','This purpose of this course is to provide students with the academic mathematical skills required for entrance into college or university programs with academic mathematics pre-requisites.'),
(8,'MATH 1047','College Mathematics II',1.5,'This course offers theoretical and applied mathematical skills, with reference to problem-solving process and strategies. Mathematical concepts will be taught with a focus on preparing students for further technical or scientific study. ','This purpose of this course is to provide students with the academic mathematical skills required for entrance into college or university programs with academic mathematics pre-requisites. '),
(9,'PHYS 1046','College Physics I',1.5,'By utilizing an intensive problem-solving approach in the study of physics principles, students will develop the ability to analyze and interpret the relationships of the physical world around them. The student will use the basic principles of physics and mathematics to develop quantitative solutions to both practical and abstract problems. The skills and knowledge gained through this approach will serve as an excellent basis for further study in technology-related college programs. ','The purpose of this course is to provide students with the academic physics skills required for entrance into college or university programs with academic physics pre-requisites such as Computer Electronics  Technician, Construction Administration  Technology, Heating,  Ventilation, Refrigeration & Air Conditioning and Industrial Instrumentation. '),
(10,'PHYS 1047','College Physics II',1.5,'By utilizing an intensive problem-solving approach in the study of physics principles, the student will develop the ability to analyze and interpret the relationships of the physical world around them. The student will use the basic principles of physics and mathematics to develop quantitative solutions to both abstract and practical problems that may be encountered in a work environment. The skills and knowledge gained through this problem-solving approach will serve as an excellent basis for f','The purpose of this course is to provide students with the academic physics skills required for entrance into college or university programs with academic physics pre-requisites such as Architectural Engineering  Technician, Electrical Engineering  Technology,  Electronic Engineering  Technology,  Mechanical Engineering  Technology, Power Engineering Technology,  and Civil Engineering  Technology. '),
(11,'MATH 1043','Math Foundations',1,'Foundations in Math offers basic math strategies and applied skills. Concepts will be taught with a focus on preparing students for academic math courses. ','The purpose of Foundations in Math is to provide students with the mathematical skills required for academic mathematics courses. '),
(12,'MATH 1546','Pre-Calculus Math I',1,'Pre-Calculus Math is designed to provide learners with the mathematical understandings and critical-thinking skills identified for entry into post-secondary programs requiring the study of theoretical calculus; these traditionally include most undergraduate science and engineering programs.  Topics in this first level include trigonometric equations and identities, sequences and series, and algebraic functions. ','Completion of this course will provide the student with a math credit and the skills they need to pursue careers that require the use of theoretical calculus. '),
(13,'MATH 1547','Pre-Calculus Math II',1,'This Pre-Calculus course is the second of two courses designed to provide you with the mathematical understandings and critical-thinking skills identified for entry into post-secondary programs that require the study of theoretical calculus; these traditionally include most undergraduate science and engineering programs. ','Completion of this course will provide the student with a math credit and the skills they need for further studies in programs that require the use of theoretical calculus.'),
(14,'COMM 1000','Essential Communication Skills',1,'This introductory level Communication course exposes you to the subtleties of interpersonal communication including non-verbal communication, listening skills, social media management and written communication. This course provides you with an overview of the communication skills required by college programs, business and industry, including reading comprehension and development.  You will learn to apply these communication skills to be successful in your future studies and/or selected workplace','The purpose of this course is to equip students with the communications skills required for any College graduate to be successful in the workplace. Students are introduced to written, oral, and interpersonal communications skills and concepts. '),
(15,'COMM 1001','Workplace Development',1,'This course provides you with the opportunity to further develop writing skills acquired in Communications 1000 – Essential Communication Skills. The course also encourages exploration of job search techniques, and is designed to assist you in the development of the skills and confidence required to deliver individual oral presentations. ','The purpose of this course is to provide students with knowledge of the verbal communication process, opportunities for students to explore presentation strategies and practice verbal skills required for effective transfer of information . Students further develop writing skills and are introduced to other essential communications topics including job search, human relations, and customer service.');
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course_semester`
--

DROP TABLE IF EXISTS `course_semester`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `course_semester` (
  `course_id` int NOT NULL,
  `semester_id` int NOT NULL,
  PRIMARY KEY (`course_id`,`semester_id`),
  KEY `fk_semester_id_idx` (`semester_id`),
  CONSTRAINT `fk_course_id` FOREIGN KEY (`course_id`) REFERENCES `course` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_semester_id` FOREIGN KEY (`semester_id`) REFERENCES `semester` (`semester_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course_semester`
--

LOCK TABLES `course_semester` WRITE;
/*!40000 ALTER TABLE `course_semester` DISABLE KEYS */;
INSERT INTO `course_semester` VALUES (1,1),(3,1),(5,1),(7,1),(9,1),(11,1),(12,1),(14,1),(1,2),(2,2),(3,2),(4,2),(5,2),(6,2),(7,2),(8,2),(9,2),(10,2),(11,2),(13,2),(14,2),(15,2),(1,3),(2,3),(3,3),(4,3),(5,3),(6,3),(7,3),(8,3),(9,3),(10,3),(11,3),(12,3),(13,3),(14,3),(15,3),(1,4),(3,4),(5,4),(7,4),(9,4),(11,4),(12,4),(14,4),(1,5),(2,5),(3,5),(4,5),(5,5),(6,5),(7,5),(8,5),(9,5),(10,5),(11,5),(13,5),(14,5),(15,5),(1,6),(2,6),(3,6),(4,6),(5,6),(6,6),(7,6),(8,6),(9,6),(10,6),(11,6),(12,6),(13,6),(14,6),(15,6);
/*!40000 ALTER TABLE `course_semester` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `requisite`
--

DROP TABLE IF EXISTS `requisite`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `requisite` (
  `course_id` int NOT NULL,
  `required_course_id` int NOT NULL,
  `type` int DEFAULT '0' COMMENT '0 - Prerequisite\n1 - Corequisite',
  `condition` int DEFAULT '2' COMMENT '0 - AND\n1 - OR\n2 - None',
  PRIMARY KEY (`course_id`,`required_course_id`),
  KEY `fk_course_2_idx` (`required_course_id`),
  CONSTRAINT `fk_course` FOREIGN KEY (`course_id`) REFERENCES `course` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_course_2` FOREIGN KEY (`required_course_id`) REFERENCES `course` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `requisite`
--

LOCK TABLES `requisite` WRITE;
/*!40000 ALTER TABLE `requisite` DISABLE KEYS */;
INSERT INTO `requisite` VALUES (2,1,0,2),(4,3,0,2),(6,5,0,1),(6,7,0,1),(8,7,0,2),(10,9,0,2),(12,8,0,2),(13,12,0,2),(15,14,0,2);
/*!40000 ALTER TABLE `requisite` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `semester`
--

DROP TABLE IF EXISTS `semester`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `semester` (
  `semester_id` int NOT NULL AUTO_INCREMENT,
  `semester_code` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`semester_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `semester`
--

LOCK TABLES `semester` WRITE;
/*!40000 ALTER TABLE `semester` DISABLE KEYS */;
INSERT INTO `semester` VALUES (1,'Fall 2022'),(2,'Winter 2023'),(3,'Spring 2023'),(4,'Fall 2023'),(5,'Winter 2024'),(6,'Spring 2024');
/*!40000 ALTER TABLE `semester` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-02-01 14:53:14
