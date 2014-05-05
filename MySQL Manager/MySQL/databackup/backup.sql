CREATE DATABASE  IF NOT EXISTS `nitro` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `nitro`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: nitro
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `class`
--

DROP TABLE IF EXISTS `class`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `teacherUsername` varchar(45) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class`
--

LOCK TABLES `class` WRITE;
/*!40000 ALTER TABLE `class` DISABLE KEYS */;
INSERT INTO `class` VALUES (1,'3rd Grade','teacher'),(2,'4th Grade','teacher');
/*!40000 ALTER TABLE `class` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `class_exercises`
--

DROP TABLE IF EXISTS `class_exercises`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `class_exercises` (
  `classId` int(11) NOT NULL,
  `exerciseId` int(11) NOT NULL,
  PRIMARY KEY (`exerciseId`,`classId`),
  KEY `classId.fk_idx` (`classId`),
  KEY `exerciseId.fk_idx` (`exerciseId`),
  CONSTRAINT `class_exercises_classId.fk` FOREIGN KEY (`classId`) REFERENCES `class` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `exerciseId.fk` FOREIGN KEY (`exerciseId`) REFERENCES `exercise` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `class_exercises`
--

LOCK TABLES `class_exercises` WRITE;
/*!40000 ALTER TABLE `class_exercises` DISABLE KEYS */;
INSERT INTO `class_exercises` VALUES (1,1),(1,2),(2,1),(2,2);
/*!40000 ALTER TABLE `class_exercises` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `dba`
--

DROP TABLE IF EXISTS `dba`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dba` (
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `fName` varchar(45) NOT NULL,
  `lName` varchar(45) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `dba`
--

LOCK TABLES `dba` WRITE;
/*!40000 ALTER TABLE `dba` DISABLE KEYS */;
INSERT INTO `dba` VALUES ('dba','dba','John','Doe');
/*!40000 ALTER TABLE `dba` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `exercise`
--

DROP TABLE IF EXISTS `exercise`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `exercise` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `text` varchar(45) NOT NULL,
  `owner` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `owner.fk_idx` (`owner`),
  CONSTRAINT `owner.fk` FOREIGN KEY (`owner`) REFERENCES `teacher` (`username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `exercise`
--

LOCK TABLES `exercise` WRITE;
/*!40000 ALTER TABLE `exercise` DISABLE KEYS */;
INSERT INTO `exercise` VALUES (1,'1-1','This is the text!  Good luck typing it!','teacher'),(2,'1-2','Again, another exercise. WOO!','teacher'),(5,'1-3','no','teacher');
/*!40000 ALTER TABLE `exercise` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student` (
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `fName` varchar(45) NOT NULL,
  `lName` varchar(45) NOT NULL,
  `classId` int(11) DEFAULT NULL,
  PRIMARY KEY (`username`),
  KEY `classId.fk_idx` (`classId`),
  CONSTRAINT `classId.fk` FOREIGN KEY (`classId`) REFERENCES `class` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student`
--

LOCK TABLES `student` WRITE;
/*!40000 ALTER TABLE `student` DISABLE KEYS */;
INSERT INTO `student` VALUES ('alewis','root','Alex','Lewis',2),('bcarpenter','root','Ben','Carpenter',2),('mschilling','wdf','Michael','Schilling',2),('rhowatt','lsidkfjs','Randall','Howatt',1),('stu','root','Stu','Dent',1),('tferg','root','Turd','Fergesun',1);
/*!40000 ALTER TABLE `student` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `student_performance`
--

DROP TABLE IF EXISTS `student_performance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `student_performance` (
  `studentUsername` varchar(45) NOT NULL,
  `exerciseId` int(11) NOT NULL,
  `errorCount` int(11) NOT NULL,
  `time` int(11) NOT NULL,
  PRIMARY KEY (`studentUsername`,`exerciseId`),
  KEY `perf_exerciseId_idx` (`exerciseId`),
  CONSTRAINT `perf_exerciseId` FOREIGN KEY (`exerciseId`) REFERENCES `exercise` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `perf_studentId.fk` FOREIGN KEY (`studentUsername`) REFERENCES `student` (`username`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `student_performance`
--

LOCK TABLES `student_performance` WRITE;
/*!40000 ALTER TABLE `student_performance` DISABLE KEYS */;
INSERT INTO `student_performance` VALUES ('mschilling',2,20,35),('rhowatt',1,1,63);
/*!40000 ALTER TABLE `student_performance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teacher`
--

DROP TABLE IF EXISTS `teacher`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teacher` (
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `fName` varchar(45) NOT NULL,
  `lName` varchar(45) NOT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teacher`
--

LOCK TABLES `teacher` WRITE;
/*!40000 ALTER TABLE `teacher` DISABLE KEYS */;
INSERT INTO `teacher` VALUES ('teacher','Teacher1','Teach','Cherr');
/*!40000 ALTER TABLE `teacher` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2014-04-27 16:08:06
