-- Host: localhost:3306
-- Generation Time: Sep 25, 2016 at 10:48 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";
DROP TABLE IF EXISTS `tblUsers`;
DROP TABLE IF EXISTS `tblCourses`;
DROP TABLE IF EXISTS `tblCourse_semester`;
DROP TABLE IF EXISTS `tblRequisite`;
DROP TABLE IF EXISTS `tblSemester`;

CREATE TABLE IF NOT EXISTS `tblUsers` (
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL,
  Primary Key (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `tblUsers` (`username`, `password`, `salt`) VALUES
('Ethan', 'J8KyEuRtSyN3eZuhwKpa9Ob/6ZGVT2ki1z4lxL3tuM0=', 'HAsTR1XIUynLxYCIwA2zdg==');

CREATE TABLE `tblCourse` (
  `id` int NOT NULL AUTO_INCREMENT,
  `course_code` varchar(20) DEFAULT NULL,
  `course_name` varchar(255) DEFAULT 'None',
  `course_units` float DEFAULT '1',
  `course_description` varchar(500) DEFAULT NULL,
  `course_rationale` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `course_code_UNIQUE` (`course_code`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

INSERT INTO `tblCourse` VALUES 
(1,'BIOL 1046','College Biology I',1.5,'College Biology I is presented as an introductory general course at the post-secondary level and will prepare students for further study. This course covers scientific methodology, plant and animal biology, biochemistry, cytology and genetics. The modes of instruction vary between lecture, discussion, experiments and discovery. ','The purpose of this course, in conjunction with Biology 1047, is to provide students with the academic biology skills required or recommended for entrance into college and other post-secondary programs with academic biology pre-requisites such as Dental Assisting, Medical Laboratory  Technology,  Pharmacy  Technology,  Water Resources and Nursing.'),
(2,'BIOL 1047','College Biology II',1.5,'College Biology II is a continuation of Biology I and will prepare students for further study. This course covers evolution, and human anatomy and physiology with an option to include a research project in an area of the students interest. The modes of instruction vary between lecture, discussion, experiments and discovery. ','The purpose of this course is to provide students with the academic biology skills required or recommended for entrance into college and other post-secondary programs with academic biology pre-requisites such as Dental Assisting,  Medical Laboratory  Technology,  Pharmacy  Technology,  Water Resources and Nursing.'),
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

CREATE TABLE `tblSemester` (
  `semester_id` int NOT NULL AUTO_INCREMENT,
  `semester_code` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`semester_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

INSERT INTO `tblSemester` VALUES (1,'Fall 2022'),(2,'Winter 2023'),(3,'Spring 2023'),(4,'Fall 2023'),(5,'Winter 2024'),(6,'Spring 2024');

CREATE TABLE `tblCourse_semester` (
  `course_id` int NOT NULL,
  `semester_id` int NOT NULL,
  PRIMARY KEY (`course_id`,`semester_id`),
  KEY `fk_semester_id_idx` (`semester_id`),
  CONSTRAINT `fk_course_id` FOREIGN KEY (`course_id`) REFERENCES `tblCourse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_semester_id` FOREIGN KEY (`semester_id`) REFERENCES `tblSemester` (`semester_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `tblCourse_semester` VALUES (1,1),
(3,1),
(5,1),
(7,1),
(9,1),
(11,1),
(12,1),
(14,1),
(1,2),
(2,2),
(3,2),
(4,2),
(5,2),
(6,2),
(7,2),
(8,2),
(9,2),
(10,2),
(11,2),
(13,2),
(14,2),
(15,2),
(1,3),
(2,3),
(3,3),
(4,3),
(5,3),
(6,3),
(7,3),
(8,3),
(9,3),
(10,3),
(11,3),
(12,3),
(13,3),
(14,3),
(15,3),
(1,4),
(3,4),
(5,4),
(7,4),
(9,4),
(11,4),
(12,4),
(14,4),
(1,5),
(2,5),
(3,5),
(4,5),
(5,5),
(6,5),
(7,5),
(8,5),
(9,5),
(10,5),
(11,5),
(13,5),
(14,5),
(15,5),
(1,6),
(2,6),
(3,6),
(4,6),
(5,6),
(6,6),
(7,6),
(8,6),
(9,6),
(10,6),
(11,6),
(12,6),
(13,6),
(14,6),
(15,6);

-- CREATE TABLE `tblRequisite` (
--   `requisite_id` int NOT NULL AUTO_INCREMENT,
--   `course_id` int NOT NULL,
--   `required_course_id` int NOT NULL,
--   `type` int DEFAULT '0' COMMENT '0 - Prerequisite\n1 - Corequisite',
--   `condition` int DEFAULT '2' COMMENT '0 - AND\n1 - OR\n2 - None',
--   PRIMARY KEY (`requisite_id`),
--   -- KEY `fk_course_2_idx` (`required_course_id`),
--   CONSTRAINT `fk_course` FOREIGN KEY (`course_id`) REFERENCES `tblCourse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
--   CONSTRAINT `fk_course_2` FOREIGN KEY (`required_course_id`) REFERENCES `tblCourse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
-- ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=latin1;

-- INSERT INTO `tblRequisite` VALUES (1,2,1,0,2),(2,4,3,0,2),(3,6,5,0,1),(4,6,7,0,1),(5,8,7,0,2),(6,10,9,0,2),(7,12,8,0,2),(8,13,12,0,2),(9,15,14,0,2);

CREATE TABLE `tblRequisite` (
  `course_id` int NOT NULL,
  `required_course_id` int NOT NULL,
  `type` int DEFAULT '0' COMMENT '0 - Prerequisite\n1 - Corequisite',
  `condition` int DEFAULT '2' COMMENT '0 - AND\n1 - OR\n2 - None',
  PRIMARY KEY (`course_id`,`required_course_id`),
  KEY `fk_course_2_idx` (`required_course_id`),
  CONSTRAINT `fk_course` FOREIGN KEY (`course_id`) REFERENCES `tblCourse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `fk_course_2` FOREIGN KEY (`required_course_id`) REFERENCES `tblCourse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `tblRequisite` VALUES (2,1,0,2),(4,3,0,2),(6,5,0,1),(6,7,0,1),(8,7,0,2),(10,9,0,2),(12,8,0,2),(13,12,0,2),(15,14,0,2);


CREATE TABLE `tblQuestion` (
  `questionId` int NOT NULL AUTO_INCREMENT,
  `questionText` varchar(1000) NOT NULL,
  `questionDescription` varchar(1000) DEFAULT NULL,
  PRIMARY KEY (`questionId`),
  KEY `pk_questionId_idx` (`questionId`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=latin1;

INSERT INTO `tblQuestion` VALUES (1,'Do I want ALP-AU or ACC?',NULL),(2,'Do I need to take Math?',NULL),(3,'Do I require College Health Math?',NULL),(4,'Did I take Academic Math in grade 10?',NULL),(5,'Do I need Math Foundations (Math 1043)?',NULL),(6,'Did I finish High School with \"Math at Work\"?',NULL),(7,'Do I require Full Academic Math?',NULL),(8,'Do I require Pre-Calculus Math?',NULL),(9,'Do I have Grade 12 Academic Math (or equivalent)?',NULL),(10,'Do I need to take English?',NULL),(11,'Do I need to take Biology?',NULL),(12,'Do I need to take Chemistry?',NULL),(13,'Do I need to take Physics?',NULL),(14,'Do I need Physics 1046, or do I need 1046 and 1047?',NULL),(15,'What is my highest level of Math?',NULL);


CREATE TABLE `tblOption` (
  `optionId` int NOT NULL AUTO_INCREMENT,
  `optionText` varchar(255) NOT NULL,
  `questionId` int NOT NULL,
  `nextQuestionId` int DEFAULT NULL,
  PRIMARY KEY (`optionId`),
  KEY `fk_nextQuestionId_idx` (`nextQuestionId`),
  CONSTRAINT `fk_nextQuestionId` FOREIGN KEY (`nextQuestionId`) REFERENCES `tblQuestion` (`questionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=latin1;


INSERT INTO `tblOption` VALUES (11,'ALP - Adult Learning Program', 1,NULL),(12,'ACC - Academic and Career Connections',1,2),(13,'Yes',2,3),(14,'No',2,10),(15,'Yes',3,4),(16,'No',3,7),(17,'Yes',4,6),(18,'No',4,5),(19,'Yes',5,10),(20,'No',5,10),(21,'Yes',6,5),(22,'No',6,5),(23,'Yes',7,4),(24,'No',7,8),(25,'Yes',8,9),(26,'No',8,9),(27,'Yes',9,10),(28,'No',9,10),(29,'Yes',10,11),(30,'No',10,11),(31,'Yes',11,12),(32,'No',11,12),(33,'Yes',12,13),(34,'No',12,13),(35,'Yes',13,14),(36,'No',13,NULL),(37,'Yes',14,NULL),(38,'No',14,NULL);


CREATE TABLE `tblOptionCourse` (
  `optionId` int NOT NULL,
  `courseId` int NOT NULL,
  PRIMARY KEY (`optionId`,`courseId`),
  KEY `courseId_idx` (`courseId`),
  CONSTRAINT `courseId` FOREIGN KEY (`courseId`) REFERENCES `tblCourse` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `optionId` FOREIGN KEY (`optionId`) REFERENCES `tblOption` (`optionId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;


INSERT INTO `tblOptionCourse` VALUES (31,1),(31,2),(33,3),(33,4),(15,5),(15,6),(23,7),(23,8),(35,9),(37,10),(19,11),(25,12),(25,13),(29,14),(29,15);    