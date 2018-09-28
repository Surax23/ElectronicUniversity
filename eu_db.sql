CREATE DATABASE  IF NOT EXISTS `eu_db` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `eu_db`;
-- MySQL dump 10.13  Distrib 5.7.9, for Win64 (x86_64)
--
-- Host: localhost    Database: eu_db
-- ------------------------------------------------------
-- Server version	5.7.12-log

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
-- Table structure for table `ads`
--

DROP TABLE IF EXISTS `ads`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ads` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `prof_id` int(11) NOT NULL,
  `groups_name` varchar(45) NOT NULL,
  `subject` varchar(80) DEFAULT NULL,
  `text` mediumtext,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_ads_groups1_idx` (`groups_name`),
  KEY `fk_ads_professor1_idx` (`prof_id`),
  CONSTRAINT `fk_ads_groups1` FOREIGN KEY (`groups_name`) REFERENCES `groups` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ads_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ads`
--

LOCK TABLES `ads` WRITE;
/*!40000 ALTER TABLE `ads` DISABLE KEYS */;
/*!40000 ALTER TABLE `ads` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `attendance`
--

DROP TABLE IF EXISTS `attendance`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `attendance` (
  `st_zk_no` varchar(10) NOT NULL,
  `course_id` int(11) NOT NULL,
  `classes_id` int(11) NOT NULL,
  `prof_id` int(11) NOT NULL,
  `attend` tinyint(1) DEFAULT NULL,
  `lateness` tinyint(1) DEFAULT NULL,
  `answer` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`st_zk_no`,`course_id`,`classes_id`),
  KEY `fk_attendance_professor1_idx` (`prof_id`),
  KEY `fk_attendance_classes1_idx` (`course_id`,`classes_id`),
  KEY `fk_attendance_students1_idx` (`st_zk_no`),
  CONSTRAINT `fk_attendance_classes1` FOREIGN KEY (`course_id`, `classes_id`) REFERENCES `classes` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_attendance_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_attendance_students1` FOREIGN KEY (`st_zk_no`) REFERENCES `students` (`zk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `attendance`
--

LOCK TABLES `attendance` WRITE;
/*!40000 ALTER TABLE `attendance` DISABLE KEYS */;
INSERT INTO `attendance` VALUES ('12А001',1,1,1,1,NULL,NULL),('12А001',1,2,1,1,NULL,NULL),('12А001',1,3,1,1,NULL,NULL),('12А001',1,4,1,1,NULL,NULL),('12А001',1,5,1,0,NULL,NULL),('12А001',1,6,1,1,NULL,NULL),('12А001',1,13,1,1,NULL,NULL),('12А001',1,14,1,1,NULL,NULL),('12А002',1,1,1,0,NULL,NULL),('12А002',1,2,1,1,NULL,NULL),('12А002',1,3,1,1,NULL,NULL),('12А002',1,4,1,0,NULL,NULL),('12А002',1,5,1,1,NULL,NULL),('12А002',1,6,1,1,NULL,NULL),('12А002',1,13,1,1,NULL,NULL),('12А002',1,14,1,1,NULL,NULL),('12А003',1,1,1,1,NULL,NULL),('12А003',1,2,1,1,NULL,NULL),('12А003',1,3,1,1,NULL,NULL),('12А003',1,4,1,0,NULL,NULL),('12А003',1,5,1,1,NULL,NULL),('12А003',1,6,1,1,NULL,NULL),('12А003',1,13,1,1,NULL,NULL),('12А003',1,14,1,1,NULL,NULL),('12А004',1,1,1,0,NULL,NULL),('12А004',1,2,1,1,NULL,NULL),('12А004',1,3,1,1,NULL,NULL),('12А004',1,4,1,1,NULL,NULL),('12А004',1,5,1,1,NULL,NULL),('12А004',1,6,1,1,NULL,NULL),('12А004',1,13,1,0,NULL,NULL),('12А004',1,14,1,0,NULL,NULL),('12А005',1,1,1,1,NULL,NULL),('12А005',1,2,1,1,NULL,NULL),('12А005',1,3,1,1,NULL,NULL),('12А005',1,4,1,1,NULL,NULL),('12А005',1,5,1,0,NULL,NULL),('12А005',1,6,1,0,NULL,NULL),('12А005',1,13,1,1,NULL,NULL),('12А005',1,14,1,1,NULL,NULL),('12Е001',1,1,1,1,NULL,NULL),('12Е001',1,2,1,1,NULL,NULL),('12Е001',1,3,1,1,NULL,NULL),('12Е001',1,4,1,1,NULL,NULL),('12Е001',1,5,1,1,NULL,NULL),('12Е001',1,6,1,0,NULL,NULL),('12Е001',1,13,1,0,NULL,NULL),('12Е001',1,14,1,0,NULL,NULL),('12Е002',1,1,1,1,NULL,NULL),('12Е002',1,2,1,1,NULL,NULL),('12Е002',1,3,1,1,NULL,NULL),('12Е002',1,4,1,1,NULL,NULL),('12Е002',1,5,1,0,NULL,NULL),('12Е002',1,6,1,1,NULL,NULL),('12Е002',1,13,1,0,NULL,NULL),('12Е002',1,14,1,1,NULL,NULL),('12Е003',1,1,1,0,NULL,NULL),('12Е003',1,2,1,1,NULL,NULL),('12Е003',1,3,1,1,NULL,NULL),('12Е003',1,4,1,1,NULL,NULL),('12Е003',1,5,1,1,NULL,NULL),('12Е003',1,6,1,0,NULL,NULL),('12Е003',1,13,1,0,NULL,NULL),('12Е003',1,14,1,1,NULL,NULL),('12Е004',1,1,1,1,NULL,NULL),('12Е004',1,2,1,1,NULL,NULL),('12Е004',1,3,1,1,NULL,NULL),('12Е004',1,4,1,1,NULL,NULL),('12Е004',1,5,1,1,NULL,NULL),('12Е004',1,6,1,1,NULL,NULL),('12Е004',1,13,1,0,NULL,NULL),('12Е004',1,14,1,0,NULL,NULL),('12Е005',1,1,1,0,NULL,NULL),('12Е005',1,2,1,0,NULL,NULL),('12Е005',1,3,1,1,NULL,NULL),('12Е005',1,4,1,0,NULL,NULL),('12Е005',1,5,1,1,NULL,NULL),('12Е005',1,6,1,0,NULL,NULL),('12Е005',1,13,1,1,NULL,NULL),('12Е005',1,14,1,0,NULL,NULL),('12Р001',1,1,1,1,NULL,NULL),('12Р001',1,2,1,1,NULL,NULL),('12Р001',1,3,1,1,NULL,NULL),('12Р001',1,4,1,1,NULL,NULL),('12Р001',1,5,1,1,NULL,NULL),('12Р001',1,6,1,1,NULL,NULL),('12Р001',1,13,1,1,NULL,NULL),('12Р001',1,14,1,1,NULL,NULL),('12Р002',1,1,1,1,NULL,NULL),('12Р002',1,2,1,1,NULL,NULL),('12Р002',1,3,1,1,NULL,NULL),('12Р002',1,4,1,1,NULL,NULL),('12Р002',1,5,1,1,NULL,NULL),('12Р002',1,6,1,1,NULL,NULL),('12Р002',1,13,1,1,NULL,NULL),('12Р002',1,14,1,1,NULL,NULL),('12Р003',1,1,1,1,NULL,NULL),('12Р003',1,2,1,1,NULL,NULL),('12Р003',1,3,1,1,NULL,NULL),('12Р003',1,4,1,1,NULL,NULL),('12Р003',1,5,1,1,NULL,NULL),('12Р003',1,6,1,1,NULL,NULL),('12Р003',1,13,1,1,NULL,NULL),('12Р003',1,14,1,1,NULL,NULL),('12Р004',1,1,1,1,NULL,NULL),('12Р004',1,2,1,1,NULL,NULL),('12Р004',1,3,1,1,NULL,NULL),('12Р004',1,4,1,1,NULL,NULL),('12Р004',1,5,1,1,NULL,NULL),('12Р004',1,6,1,1,NULL,NULL),('12Р004',1,13,1,1,NULL,NULL),('12Р004',1,14,1,1,NULL,NULL),('12Р005',1,1,1,1,NULL,NULL),('12Р005',1,2,1,1,NULL,NULL),('12Р005',1,3,1,1,NULL,NULL),('12Р005',1,4,1,1,NULL,NULL),('12Р005',1,5,1,1,NULL,NULL),('12Р005',1,6,1,1,NULL,NULL),('12Р005',1,13,1,1,NULL,NULL),('12Р005',1,14,1,1,NULL,NULL);
/*!40000 ALTER TABLE `attendance` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `auditories`
--

DROP TABLE IF EXISTS `auditories`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `auditories` (
  `no` int(11) NOT NULL,
  `seats` int(3) DEFAULT NULL,
  `computers` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `auditories`
--

LOCK TABLES `auditories` WRITE;
/*!40000 ALTER TABLE `auditories` DISABLE KEYS */;
INSERT INTO `auditories` VALUES (222,45,NULL),(416,70,NULL),(422,25,NULL),(423,25,NULL),(426,45,NULL),(514,25,NULL);
/*!40000 ALTER TABLE `auditories` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `capacity`
--

DROP TABLE IF EXISTS `capacity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `capacity` (
  `prof_id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `classes_id` int(11) NOT NULL,
  `groups_name` varchar(45) NOT NULL,
  PRIMARY KEY (`prof_id`,`course_id`,`classes_id`,`groups_name`),
  KEY `fk_capacity_professor1_idx` (`prof_id`),
  KEY `fk_capacity_groups1_idx` (`groups_name`),
  KEY `fk_capacity_classes1_idx` (`course_id`,`classes_id`),
  CONSTRAINT `fk_capacity_classes1` FOREIGN KEY (`course_id`, `classes_id`) REFERENCES `classes` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_capacity_groups1` FOREIGN KEY (`groups_name`) REFERENCES `groups` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_capacity_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `capacity`
--

LOCK TABLES `capacity` WRITE;
/*!40000 ALTER TABLE `capacity` DISABLE KEYS */;
INSERT INTO `capacity` VALUES (1,1,1,'РК9-81'),(1,1,2,'РК9-81'),(1,1,3,'РК9-81'),(1,1,4,'РК9-81'),(1,1,5,'РК9-81'),(1,1,6,'РК9-81'),(1,1,13,'РК9-81'),(1,1,14,'РК9-81');
/*!40000 ALTER TABLE `capacity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes`
--

DROP TABLE IF EXISTS `classes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `course_id` int(11) NOT NULL,
  `classes_type_name` varchar(45) NOT NULL,
  `date` date DEFAULT NULL,
  `number` int(11) DEFAULT NULL,
  `min_mark` int(3) DEFAULT NULL,
  `max_mark` int(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`course_id`),
  KEY `fk_classes_course1_idx` (`course_id`),
  KEY `fk_classes_classes_type1_idx` (`classes_type_name`),
  CONSTRAINT `fk_classes_classes_type1` FOREIGN KEY (`classes_type_name`) REFERENCES `classes_type` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_classes_course1` FOREIGN KEY (`course_id`) REFERENCES `course` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=74 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes`
--

LOCK TABLES `classes` WRITE;
/*!40000 ALTER TABLE `classes` DISABLE KEYS */;
INSERT INTO `classes` VALUES (1,1,'Домашнее задание','2016-06-02',1,15,30),(1,2,'Рубежный контроль',NULL,1,20,30),(1,3,'Лабораторная работа',NULL,1,15,40),(1,4,'Рубежный контроль',NULL,1,10,25),(1,5,'Рубежный контроль',NULL,1,15,50),(1,6,'Рубежный контроль',NULL,1,15,40),(1,7,'Лабораторная работа',NULL,1,10,35),(2,1,'Лабораторная работа','2016-06-14',1,5,15),(2,2,'Рубежный контроль',NULL,2,15,30),(2,3,'Домашнее задание',NULL,1,15,30),(2,4,'Рубежный контроль',NULL,2,10,25),(2,5,'Домашнее задание',NULL,1,25,50),(2,6,'Рубежный контроль',NULL,2,15,40),(2,7,'Лабораторная работа',NULL,2,10,15),(3,1,'Лабораторная работа','2016-06-15',2,5,15),(3,2,'Домашнее задание',NULL,1,15,40),(3,3,'Рубежный контроль',NULL,1,20,30),(3,4,'Лабораторная работа',NULL,1,10,25),(3,5,'Семинар','2016-06-01',NULL,NULL,NULL),(3,6,'Лабораторная работа',NULL,1,10,20),(3,7,'Лекция','2016-06-04',NULL,NULL,NULL),(4,1,'Рубежный контроль','2016-06-17',1,20,40),(4,2,'Лекция','2016-05-30',NULL,NULL,NULL),(4,3,'Лекция','2016-05-31',NULL,NULL,NULL),(4,4,'Домашнее задание',NULL,1,10,25),(4,5,'Семинар','2016-06-08',NULL,NULL,NULL),(4,6,'Семинар','2016-06-01',NULL,NULL,NULL),(4,7,'Лекция','2016-06-11',NULL,NULL,NULL),(5,1,'Лекция','2016-05-30',NULL,NULL,NULL),(5,2,'Лекция','2016-06-06',NULL,NULL,NULL),(5,3,'Лекция','2016-06-07',NULL,NULL,NULL),(5,4,'Лекция','2016-05-31',NULL,NULL,NULL),(5,5,'Семинар','2016-06-15',NULL,NULL,NULL),(5,6,'Семинар','2016-06-08',NULL,NULL,NULL),(5,7,'Лекция','2016-06-18',NULL,NULL,NULL),(6,1,'Лекция','2016-06-13',NULL,NULL,NULL),(6,2,'Лекция','2016-06-13',NULL,NULL,NULL),(6,3,'Лекция','2016-06-14',NULL,NULL,NULL),(6,4,'Лекция','2016-06-07',NULL,NULL,NULL),(6,5,'Лекция','2016-06-01',NULL,NULL,NULL),(6,6,'Семинар','2016-06-15',NULL,NULL,NULL),(6,7,'Лекция','2016-06-04',NULL,NULL,NULL),(7,2,'Лекция','2016-05-30',NULL,NULL,NULL),(7,3,'Лекция','2016-05-31',NULL,NULL,NULL),(7,4,'Лекция','2016-06-14',NULL,NULL,NULL),(7,5,'Лекция','2016-06-08',NULL,NULL,NULL),(7,6,'Лекция','2016-06-01',NULL,NULL,NULL),(7,7,'Лекция','2016-06-11',NULL,NULL,NULL),(8,2,'Лекция','2016-06-06',NULL,NULL,NULL),(8,3,'Лекция','2016-06-14',NULL,NULL,NULL),(8,4,'Лекция','2016-05-31',NULL,NULL,NULL),(8,5,'Лекция','2016-06-15',NULL,NULL,NULL),(8,6,'Лекция','2016-06-08',NULL,NULL,NULL),(8,7,'Лекция','2016-06-18',NULL,NULL,NULL),(9,2,'Лекция','2016-06-13',NULL,NULL,NULL),(9,3,'Семинар','2016-05-31',NULL,NULL,NULL),(9,4,'Лекция','2016-06-07',NULL,NULL,NULL),(9,5,'Лекция','2016-06-01',NULL,NULL,NULL),(9,6,'Лекция','2016-06-15',NULL,NULL,NULL),(9,7,'Семинар','2016-06-04',NULL,NULL,NULL),(10,2,'Семинар','2016-05-30',NULL,NULL,NULL),(10,3,'Семинар','2016-06-14',NULL,NULL,NULL),(10,4,'Лекция','2016-06-14',NULL,NULL,NULL),(10,5,'Лекция','2016-06-08',NULL,NULL,NULL),(10,6,'Лекция','2016-06-01',NULL,NULL,NULL),(10,7,'Семинар','2016-06-18',NULL,NULL,NULL),(11,2,'Семинар','2016-06-13',NULL,NULL,NULL),(11,3,'Лекция','2016-05-31',NULL,NULL,NULL),(11,4,'Семинар','2016-05-31',NULL,NULL,NULL),(11,5,'Лекция','2016-06-15',NULL,NULL,NULL),(11,6,'Лекция','2016-06-08',NULL,NULL,NULL),(11,7,'Семинар','2016-06-04',NULL,NULL,NULL),(12,2,'Семинар','2016-05-30',NULL,NULL,NULL),(12,3,'Лекция','2016-06-07',NULL,NULL,NULL),(12,4,'Семинар','2016-06-07',NULL,NULL,NULL),(12,5,'Семинар','2016-06-01',NULL,NULL,NULL),(12,6,'Лекция','2016-06-15',NULL,NULL,NULL),(12,7,'Семинар','2016-06-18',NULL,NULL,NULL),(13,1,'Семинар','2016-05-30',NULL,NULL,NULL),(13,2,'Семинар','2016-06-13',NULL,NULL,NULL),(13,3,'Лекция','2016-06-14',NULL,NULL,NULL),(13,4,'Семинар','2016-06-14',NULL,NULL,NULL),(13,5,'Семинар','2016-06-08',NULL,NULL,NULL),(13,6,'Семинар','2016-06-01',NULL,NULL,NULL),(13,7,'Лекция','2016-06-04',NULL,NULL,NULL),(14,1,'Семинар','2016-06-13',NULL,NULL,NULL),(14,2,'Лекция','2016-05-30',NULL,NULL,NULL),(14,3,'Лекция','2016-05-31',NULL,NULL,NULL),(14,4,'Семинар','2016-05-31',NULL,NULL,NULL),(14,5,'Семинар','2016-06-15',NULL,NULL,NULL),(14,6,'Семинар','2016-06-08',NULL,NULL,NULL),(14,7,'Лекция','2016-06-11',NULL,NULL,NULL),(15,2,'Лекция','2016-06-06',NULL,NULL,NULL),(15,3,'Лекция','2016-06-14',NULL,NULL,NULL),(15,4,'Семинар','2016-06-14',NULL,NULL,NULL),(15,5,'Семинар','2016-06-01',NULL,NULL,NULL),(15,6,'Семинар','2016-06-15',NULL,NULL,NULL),(15,7,'Лекция','2016-06-18',NULL,NULL,NULL),(16,2,'Лекция','2016-06-13',NULL,NULL,NULL),(16,4,'Семинар','2016-05-31',NULL,NULL,NULL),(16,5,'Семинар','2016-06-08',NULL,NULL,NULL),(16,6,'Семинар','2016-06-01',NULL,NULL,NULL),(16,7,'Лекция','2016-06-04',NULL,NULL,NULL),(17,2,'Лекция','2016-05-30',NULL,NULL,NULL),(17,4,'Семинар','2016-06-14',NULL,NULL,NULL),(17,5,'Семинар','2016-06-15',NULL,NULL,NULL),(17,6,'Семинар','2016-06-08',NULL,NULL,NULL),(17,7,'Лекция','2016-06-11',NULL,NULL,NULL),(18,2,'Лекция','2016-06-06',NULL,NULL,NULL),(18,4,'Лекция','2016-05-31',NULL,NULL,NULL),(18,5,'Лекция','2016-06-01',NULL,NULL,NULL),(18,6,'Семинар','2016-06-15',NULL,NULL,NULL),(18,7,'Лекция','2016-06-18',NULL,NULL,NULL),(19,2,'Лекция','2016-06-13',NULL,NULL,NULL),(19,4,'Лекция','2016-06-07',NULL,NULL,NULL),(19,5,'Лекция','2016-06-08',NULL,NULL,NULL),(19,6,'Лекция','2016-06-01',NULL,NULL,NULL),(19,7,'Семинар','2016-06-04',NULL,NULL,NULL),(20,2,'Семинар','2016-05-30',NULL,NULL,NULL),(20,4,'Лекция','2016-06-14',NULL,NULL,NULL),(20,5,'Лекция','2016-06-15',NULL,NULL,NULL),(20,6,'Лекция','2016-06-08',NULL,NULL,NULL),(20,7,'Семинар','2016-06-18',NULL,NULL,NULL),(21,2,'Семинар','2016-06-13',NULL,NULL,NULL),(21,4,'Лекция','2016-05-31',NULL,NULL,NULL),(21,5,'Лекция','2016-06-01',NULL,NULL,NULL),(21,6,'Лекция','2016-06-15',NULL,NULL,NULL),(21,7,'Семинар','2016-06-04',NULL,NULL,NULL),(22,2,'Семинар','2016-05-30',NULL,NULL,NULL),(22,4,'Лекция','2016-06-07',NULL,NULL,NULL),(22,5,'Лекция','2016-06-08',NULL,NULL,NULL),(22,6,'Лекция','2016-06-01',NULL,NULL,NULL),(22,7,'Семинар','2016-06-18',NULL,NULL,NULL),(23,2,'Семинар','2016-06-13',NULL,NULL,NULL),(23,4,'Лекция','2016-06-14',NULL,NULL,NULL),(23,5,'Лекция','2016-06-15',NULL,NULL,NULL),(23,6,'Лекция','2016-06-08',NULL,NULL,NULL),(24,4,'Семинар','2016-05-31',NULL,NULL,NULL),(24,5,'Семинар','2016-06-01',NULL,NULL,NULL),(24,6,'Лекция','2016-06-15',NULL,NULL,NULL),(25,4,'Семинар','2016-06-07',NULL,NULL,NULL),(25,5,'Семинар','2016-06-08',NULL,NULL,NULL),(25,6,'Семинар','2016-06-01',NULL,NULL,NULL),(26,4,'Семинар','2016-06-14',NULL,NULL,NULL),(26,5,'Семинар','2016-06-15',NULL,NULL,NULL),(26,6,'Семинар','2016-06-08',NULL,NULL,NULL),(27,4,'Семинар','2016-05-31',NULL,NULL,NULL),(27,6,'Семинар','2016-06-15',NULL,NULL,NULL),(28,4,'Семинар','2016-06-14',NULL,NULL,NULL),(29,4,'Семинар','2016-05-31',NULL,NULL,NULL),(30,4,'Семинар','2016-06-14',NULL,NULL,NULL);
/*!40000 ALTER TABLE `classes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes_progress`
--

DROP TABLE IF EXISTS `classes_progress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classes_progress` (
  `st_zk_no` varchar(10) NOT NULL,
  `course_id` int(11) NOT NULL,
  `classes_id` int(11) NOT NULL,
  `prof_id` int(11) NOT NULL,
  `mark` int(3) DEFAULT NULL,
  PRIMARY KEY (`st_zk_no`,`course_id`,`classes_id`),
  KEY `fk_classes_progress_students1_idx` (`st_zk_no`),
  KEY `fk_classes_progress_professor1_idx` (`prof_id`),
  KEY `fk_classes_progress_classes1_idx` (`course_id`,`classes_id`),
  CONSTRAINT `fk_classes_progress_classes1` FOREIGN KEY (`course_id`, `classes_id`) REFERENCES `classes` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_classes_progress_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_classes_progress_students1` FOREIGN KEY (`st_zk_no`) REFERENCES `students` (`zk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes_progress`
--

LOCK TABLES `classes_progress` WRITE;
/*!40000 ALTER TABLE `classes_progress` DISABLE KEYS */;
INSERT INTO `classes_progress` VALUES ('12А001',1,1,1,6550),('12А001',1,2,1,10),('12А001',1,3,1,15),('12А001',1,4,1,15),('12А002',1,1,1,10),('12А002',1,2,1,10),('12А002',1,3,1,10),('12А002',1,4,1,15),('12А003',1,1,1,15),('12А003',1,2,1,10),('12А003',1,3,1,15),('12А003',1,4,1,10),('12А004',1,1,1,10),('12А004',1,2,1,15),('12А004',1,3,1,15),('12А004',1,4,1,10),('12А005',1,1,1,15),('12А005',1,2,1,10),('12А005',1,3,1,10),('12А005',1,4,1,10),('12Е001',1,1,1,15),('12Е001',1,2,1,15),('12Е001',1,3,1,10),('12Е001',1,4,1,15),('12Е002',1,1,1,10),('12Е002',1,2,1,15),('12Е002',1,3,1,10),('12Е002',1,4,1,15),('12Е003',1,1,1,15),('12Е003',1,2,1,10),('12Е003',1,3,1,10),('12Е003',1,4,1,10),('12Е004',1,1,1,15),('12Е004',1,2,1,15),('12Е004',1,3,1,10),('12Е004',1,4,1,10),('12Е005',1,1,1,15),('12Е005',1,2,1,15),('12Е005',1,3,1,15),('12Е005',1,4,1,15),('12Р001',1,1,1,4),('12Р001',1,2,1,1),('12Р001',1,3,1,2),('12Р001',1,4,1,3),('12Р002',1,1,1,8),('12Р002',1,2,1,5),('12Р002',1,3,1,6),('12Р002',1,4,1,7),('12Р003',1,1,1,12),('12Р003',1,2,1,9),('12Р003',1,3,1,10),('12Р003',1,4,1,11),('12Р004',1,1,1,16),('12Р004',1,2,1,13),('12Р004',1,3,1,14),('12Р004',1,4,1,15),('12Р005',1,1,1,20),('12Р005',1,2,1,17),('12Р005',1,3,1,18),('12Р005',1,4,1,19);
/*!40000 ALTER TABLE `classes_progress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `classes_type`
--

DROP TABLE IF EXISTS `classes_type`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `classes_type` (
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `classes_type`
--

LOCK TABLES `classes_type` WRITE;
/*!40000 ALTER TABLE `classes_type` DISABLE KEYS */;
INSERT INTO `classes_type` VALUES ('Домашнее задание'),('Лабораторная работа'),('Лекция'),('Рубежный контроль'),('Семинар'),('Экзамен');
/*!40000 ALTER TABLE `classes_type` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course`
--

DROP TABLE IF EXISTS `course`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course` (
  `id` int(11) NOT NULL,
  `name` varchar(80) DEFAULT NULL,
  `date_start` date DEFAULT NULL,
  `date_finish` date DEFAULT NULL,
  `limit_mark` int(11) DEFAULT NULL,
  `max_mark` int(11) DEFAULT NULL,
  `hours` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course`
--

LOCK TABLES `course` WRITE;
/*!40000 ALTER TABLE `course` DISABLE KEYS */;
INSERT INTO `course` VALUES (1,'САПРвКИП','2016-05-30','2016-06-18',50,100,NULL),(2,'Социология','2016-05-30','2016-06-18',45,100,NULL),(3,'СУТО','2016-05-30','2016-06-18',50,100,NULL),(4,'АУЖЦ','2016-05-30','2016-06-18',40,100,NULL),(5,'Логика предикатов','2016-05-30','2016-06-18',45,100,NULL),(6,'Математические модели и методы','2016-05-30','2016-06-18',50,100,NULL),(7,'Моделирование технологических процессов и производств','2016-05-30','2016-06-18',50,100,NULL),(8,'УТС','2016-05-30','2016-06-18',40,100,NULL),(9,'МУУ','2016-05-30','2016-06-18',45,100,NULL),(10,'Искусственный интеллект','2016-05-30','2016-06-18',40,100,NULL),(11,'Моделирование РТС','2016-05-30','2016-06-18',50,100,NULL),(12,'Дискретная математика','2016-05-30','2016-06-18',50,100,NULL),(13,'Управление роботами','2016-05-30','2016-06-18',40,100,NULL);
/*!40000 ALTER TABLE `course` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `course_progress`
--

DROP TABLE IF EXISTS `course_progress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `course_progress` (
  `st_zk_no` varchar(10) NOT NULL,
  `course_id` int(11) NOT NULL,
  `prof_id` int(11) NOT NULL,
  `summ_mark` int(11) DEFAULT NULL,
  `course_mark` int(11) DEFAULT NULL,
  PRIMARY KEY (`st_zk_no`,`course_id`),
  KEY `fk_course_progress_students1_idx` (`st_zk_no`),
  KEY `fk_course_progress_course1_idx` (`course_id`),
  KEY `fk_course_progress_professor1_idx` (`prof_id`),
  CONSTRAINT `fk_course_progress_course1` FOREIGN KEY (`course_id`) REFERENCES `course` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_course_progress_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_course_progress_students1` FOREIGN KEY (`st_zk_no`) REFERENCES `students` (`zk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `course_progress`
--

LOCK TABLES `course_progress` WRITE;
/*!40000 ALTER TABLE `course_progress` DISABLE KEYS */;
/*!40000 ALTER TABLE `course_progress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `day_of_week`
--

DROP TABLE IF EXISTS `day_of_week`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `day_of_week` (
  `no` int(1) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`no`),
  UNIQUE KEY `no_UNIQUE` (`no`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `day_of_week`
--

LOCK TABLES `day_of_week` WRITE;
/*!40000 ALTER TABLE `day_of_week` DISABLE KEYS */;
INSERT INTO `day_of_week` VALUES (1,'Monday'),(2,'Tuesday'),(3,'Wednesday'),(4,'Thursday'),(5,'Friday'),(6,'Saturday');
/*!40000 ALTER TABLE `day_of_week` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `groups`
--

DROP TABLE IF EXISTS `groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `groups` (
  `name` varchar(45) NOT NULL,
  PRIMARY KEY (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `groups`
--

LOCK TABLES `groups` WRITE;
/*!40000 ALTER TABLE `groups` DISABLE KEYS */;
INSERT INTO `groups` VALUES ('РК9-81'),('РК9-82'),('СМ7-81');
/*!40000 ALTER TABLE `groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `module_consist`
--

DROP TABLE IF EXISTS `module_consist`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `module_consist` (
  `course_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  `classes_id` int(11) NOT NULL,
  PRIMARY KEY (`course_id`,`module_id`,`classes_id`),
  KEY `fk_module_consist_modules1_idx` (`course_id`,`module_id`),
  KEY `fk_module_consist_classes1_idx` (`classes_id`),
  CONSTRAINT `fk_module_consist_classes1` FOREIGN KEY (`classes_id`) REFERENCES `classes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_module_consist_modules1` FOREIGN KEY (`course_id`, `module_id`) REFERENCES `modules` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `module_consist`
--

LOCK TABLES `module_consist` WRITE;
/*!40000 ALTER TABLE `module_consist` DISABLE KEYS */;
/*!40000 ALTER TABLE `module_consist` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `module_progress`
--

DROP TABLE IF EXISTS `module_progress`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `module_progress` (
  `st_zk_no` varchar(10) NOT NULL,
  `course_id` int(11) NOT NULL,
  `module_id` int(11) NOT NULL,
  `prof_id` int(11) NOT NULL,
  `summ_mark` int(11) DEFAULT NULL,
  PRIMARY KEY (`st_zk_no`,`course_id`,`module_id`),
  KEY `fk_module_progress_students1_idx` (`st_zk_no`),
  KEY `fk_module_progress_professor1_idx` (`prof_id`),
  KEY `fk_module_progress_modules1_idx` (`course_id`,`module_id`),
  CONSTRAINT `fk_module_progress_modules1` FOREIGN KEY (`course_id`, `module_id`) REFERENCES `modules` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_module_progress_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_module_progress_students1` FOREIGN KEY (`st_zk_no`) REFERENCES `students` (`zk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `module_progress`
--

LOCK TABLES `module_progress` WRITE;
/*!40000 ALTER TABLE `module_progress` DISABLE KEYS */;
/*!40000 ALTER TABLE `module_progress` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `modules`
--

DROP TABLE IF EXISTS `modules`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `modules` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `course_id` int(11) NOT NULL,
  `start_date` date DEFAULT NULL,
  `finish_date` date DEFAULT NULL,
  `limit_mark` int(3) DEFAULT NULL,
  `max_mark` int(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`course_id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_modules_course1_idx` (`course_id`),
  CONSTRAINT `fk_modules_course1` FOREIGN KEY (`course_id`) REFERENCES `course` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `modules`
--

LOCK TABLES `modules` WRITE;
/*!40000 ALTER TABLE `modules` DISABLE KEYS */;
INSERT INTO `modules` VALUES (1,1,'2016-05-30','2016-06-04',NULL,NULL),(2,1,'2016-06-06','2016-06-11',NULL,NULL),(3,1,'2016-06-13','2016-06-20',NULL,NULL);
/*!40000 ALTER TABLE `modules` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mu`
--

DROP TABLE IF EXISTS `mu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mu` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `classes_id` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `prof_id` int(11) NOT NULL,
  `comment` mediumtext,
  `link` text,
  `date` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id_UNIQUE` (`id`),
  KEY `fk_mu_classes1_idx` (`course_id`,`classes_id`),
  KEY `fk_mu_professor1_idx` (`prof_id`),
  CONSTRAINT `fk_mu_classes1` FOREIGN KEY (`course_id`, `classes_id`) REFERENCES `classes` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_mu_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `mu`
--

LOCK TABLES `mu` WRITE;
/*!40000 ALTER TABLE `mu` DISABLE KEYS */;
INSERT INTO `mu` VALUES (1,1,1,1,'Здесь некоторые комментарии к методическим указаниям. Возможно, много текста, возможно, что и нет. Сложно предугадать.','http://ya.ru/','2016-06-13'),(2,1,1,1,'Второе МУ, добавленное через форму.','http://google.com/','2016-06-15');
/*!40000 ALTER TABLE `mu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pairs`
--

DROP TABLE IF EXISTS `pairs`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pairs` (
  `pair_no` int(2) NOT NULL,
  `time_start` time DEFAULT NULL,
  `time_finish` time DEFAULT NULL,
  PRIMARY KEY (`pair_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pairs`
--

LOCK TABLES `pairs` WRITE;
/*!40000 ALTER TABLE `pairs` DISABLE KEYS */;
INSERT INTO `pairs` VALUES (1,'08:30:00','10:05:00'),(2,'10:15:00','11:50:00'),(3,'12:00:00','13:35:00'),(4,'13:50:00','15:25:00'),(5,'15:40:00','17:15:00'),(6,'17:25:00','19:00:00'),(7,'19:10:00','20:45:00');
/*!40000 ALTER TABLE `pairs` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `professor`
--

DROP TABLE IF EXISTS `professor`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `professor` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `login` varchar(45) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_professor_users1_idx` (`login`),
  CONSTRAINT `fk_professor_users1` FOREIGN KEY (`login`) REFERENCES `users` (`login`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `professor`
--

LOCK TABLES `professor` WRITE;
/*!40000 ALTER TABLE `professor` DISABLE KEYS */;
INSERT INTO `professor` VALUES (1,'Евгенев',NULL,'1'),(2,'Кузьмин',NULL,'2'),(3,'Семисалов',NULL,'3'),(4,'Федотова',NULL,'4'),(5,'Хоботов',NULL,'5'),(6,'Виньков','1962-02-17','6'),(7,'Урусов',NULL,'7'),(8,'Иванова',NULL,'8'),(9,'Михайлов',NULL,'9'),(10,'Солнцев',NULL,'10'),(11,'Зенкевич',NULL,'11'),(12,'Назарова',NULL,'12'),(13,'Крутиков',NULL,'13'),(14,'Воротников',NULL,'14');
/*!40000 ALTER TABLE `professor` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `schedule_on_week`
--

DROP TABLE IF EXISTS `schedule_on_week`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `schedule_on_week` (
  `parity` tinyint(1) NOT NULL,
  `day_of_week` int(1) NOT NULL,
  `pair_no` int(2) NOT NULL,
  `groups_name` varchar(45) NOT NULL,
  `auditory_no` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `classes_type_name` varchar(45) NOT NULL,
  `prof_id` int(11) NOT NULL,
  PRIMARY KEY (`parity`,`day_of_week`,`pair_no`,`groups_name`),
  KEY `fk_schedule_on_week_groups_idx` (`groups_name`),
  KEY `fk_schedule_on_week_course1_idx` (`course_id`),
  KEY `fk_schedule_on_week_classes_type1_idx` (`classes_type_name`),
  KEY `fk_schedule_on_week_professor1_idx` (`prof_id`),
  KEY `fk_schedule_on_week_pairs1_idx` (`pair_no`),
  KEY `fk_schedule_on_week_auditories1_idx` (`auditory_no`),
  KEY `fk_schedule_on_week_day_of_week1_idx` (`day_of_week`),
  CONSTRAINT `fk_schedule_on_week_auditories1` FOREIGN KEY (`auditory_no`) REFERENCES `auditories` (`no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_on_week_classes_type1` FOREIGN KEY (`classes_type_name`) REFERENCES `classes_type` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_on_week_course1` FOREIGN KEY (`course_id`) REFERENCES `course` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_on_week_day_of_week1` FOREIGN KEY (`day_of_week`) REFERENCES `day_of_week` (`no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_on_week_groups` FOREIGN KEY (`groups_name`) REFERENCES `groups` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_on_week_pairs1` FOREIGN KEY (`pair_no`) REFERENCES `pairs` (`pair_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_schedule_on_week_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `schedule_on_week`
--

LOCK TABLES `schedule_on_week` WRITE;
/*!40000 ALTER TABLE `schedule_on_week` DISABLE KEYS */;
INSERT INTO `schedule_on_week` VALUES (0,1,6,'РК9-81',422,2,'Лекция',8),(0,1,6,'РК9-82',422,2,'Лекция',8),(0,2,5,'РК9-82',416,4,'Лекция',3),(0,2,6,'РК9-81',416,4,'Лекция',4),(0,2,6,'РК9-82',416,3,'Лекция',4),(0,2,7,'РК9-81',416,4,'Семинар',4),(0,3,4,'РК9-81',423,5,'Семинар',6),(0,3,4,'РК9-82',416,6,'Семинар',5),(0,3,5,'РК9-81',416,6,'Лекция',5),(0,3,5,'РК9-82',416,6,'Лекция',5),(0,3,6,'РК9-81',416,5,'Лекция',6),(0,3,6,'РК9-82',416,5,'Лекция',6),(0,3,7,'РК9-81',416,6,'Семинар',5),(0,3,7,'РК9-82',426,5,'Семинар',6),(0,6,2,'РК9-81',416,7,'Лекция',7),(0,6,2,'РК9-82',416,7,'Лекция',7),(1,1,4,'РК9-81',416,1,'Лекция',1),(1,1,4,'РК9-82',416,1,'Лекция',1),(1,1,5,'РК9-81',416,1,'Лекция',1),(1,1,5,'РК9-82',416,1,'Лекция',1),(1,2,4,'РК9-82',416,4,'Семинар',3),(1,2,5,'РК9-81',416,3,'Лекция',3),(1,6,1,'РК9-81',416,7,'Семинар',7),(2,1,4,'РК9-81',416,1,'Семинар',2),(2,1,4,'РК9-82',514,2,'Семинар',8),(2,1,5,'РК9-81',422,2,'Семинар',8),(2,1,5,'РК9-82',416,1,'Семинар',2),(2,2,4,'РК9-81',416,3,'Семинар',3),(2,2,7,'РК9-82',416,4,'Семинар',4),(2,6,1,'РК9-82',416,7,'Семинар',7);
/*!40000 ALTER TABLE `schedule_on_week` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `shedule_on_date`
--

DROP TABLE IF EXISTS `shedule_on_date`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `shedule_on_date` (
  `pair_no` int(2) NOT NULL,
  `groups_name` varchar(45) NOT NULL,
  `week_no` int(11) NOT NULL,
  `day_of_week` int(1) NOT NULL,
  `prof_id` int(11) NOT NULL,
  `auditory_no` int(11) NOT NULL,
  `course_id` int(11) NOT NULL,
  `classes_id` int(11) NOT NULL,
  PRIMARY KEY (`pair_no`,`groups_name`,`week_no`,`day_of_week`),
  KEY `fk_shedule_on_date_professor1_idx` (`prof_id`),
  KEY `fk_shedule_on_date_groups1_idx` (`groups_name`),
  KEY `fk_shedule_on_date_pairs1_idx` (`pair_no`),
  KEY `fk_shedule_on_date_auditories1_idx` (`auditory_no`),
  KEY `fk_shedule_on_date_week1_idx` (`week_no`),
  KEY `fk_shedule_on_date_day_of_week1_idx` (`day_of_week`),
  KEY `fk_shedule_on_date_classes1_idx` (`course_id`,`classes_id`),
  CONSTRAINT `fk_shedule_on_date_auditories1` FOREIGN KEY (`auditory_no`) REFERENCES `auditories` (`no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_shedule_on_date_classes1` FOREIGN KEY (`course_id`, `classes_id`) REFERENCES `classes` (`course_id`, `id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_shedule_on_date_day_of_week1` FOREIGN KEY (`day_of_week`) REFERENCES `day_of_week` (`no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_shedule_on_date_groups1` FOREIGN KEY (`groups_name`) REFERENCES `groups` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_shedule_on_date_pairs1` FOREIGN KEY (`pair_no`) REFERENCES `pairs` (`pair_no`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_shedule_on_date_professor1` FOREIGN KEY (`prof_id`) REFERENCES `professor` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_shedule_on_date_week1` FOREIGN KEY (`week_no`) REFERENCES `week` (`week_no`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `shedule_on_date`
--

LOCK TABLES `shedule_on_date` WRITE;
/*!40000 ALTER TABLE `shedule_on_date` DISABLE KEYS */;
/*!40000 ALTER TABLE `shedule_on_date` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `students`
--

DROP TABLE IF EXISTS `students`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `students` (
  `zk` varchar(10) NOT NULL,
  `groups_name` varchar(45) NOT NULL,
  `name` varchar(80) DEFAULT NULL,
  `date` date DEFAULT NULL,
  `login` varchar(45) NOT NULL,
  PRIMARY KEY (`zk`),
  UNIQUE KEY `zk_UNIQUE` (`zk`),
  KEY `fk_students_users1_idx` (`login`),
  KEY `fk_students_groups1_idx` (`groups_name`),
  CONSTRAINT `fk_students_groups1` FOREIGN KEY (`groups_name`) REFERENCES `groups` (`name`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_students_users1` FOREIGN KEY (`login`) REFERENCES `users` (`login`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `students`
--

LOCK TABLES `students` WRITE;
/*!40000 ALTER TABLE `students` DISABLE KEYS */;
INSERT INTO `students` VALUES ('12А001','СМ7-81','Акимов','1994-08-19','12a001'),('12А002','СМ7-81','Ефремов','1995-11-11','12a002'),('12А003','СМ7-81','Иванченко','1993-06-23','12a003'),('12А004','СМ7-81','Петров','1994-05-26','12a004'),('12А005','СМ7-81','Самойлов','1994-07-04','12a005'),('12Е001','РК9-82','Анченко','1994-02-17','12e001'),('12Е002','РК9-82','Брызгалов','1994-10-10','12e002'),('12Е003','РК9-82','Измайлов','1994-11-07','12e003'),('12Е004','РК9-82','Сидоров','1994-08-15','12e004'),('12Е005','РК9-82','Тименко','1994-12-09','12e005'),('12Р001','РК9-81','Агаларов','1994-03-10','12r001'),('12Р002','РК9-81','Евсеев','1995-02-06','12r002'),('12Р003','РК9-81','Зинченко','1994-12-03','12r003'),('12Р004','РК9-81','Иванов','1995-01-20','12r004'),('12Р005','РК9-81','Федотов','1994-12-05','12r005');
/*!40000 ALTER TABLE `students` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `login` varchar(45) NOT NULL,
  `password` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`login`),
  UNIQUE KEY `login_UNIQUE` (`login`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('1','1'),('10','1'),('11','1'),('12','1'),('12a001','1'),('13','1'),('14','1'),('2','1'),('3','1'),('4','1'),('5','1'),('6','1'),('7','1'),('8','1'),('9','1');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `week`
--

DROP TABLE IF EXISTS `week`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `week` (
  `week_no` int(11) NOT NULL,
  `date_start` date DEFAULT NULL,
  `date_finish` date DEFAULT NULL,
  PRIMARY KEY (`week_no`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `week`
--

LOCK TABLES `week` WRITE;
/*!40000 ALTER TABLE `week` DISABLE KEYS */;
INSERT INTO `week` VALUES (1,'2016-05-30','2016-06-04'),(2,'2016-06-06','2016-06-11'),(3,'2016-06-13','2016-06-18');
/*!40000 ALTER TABLE `week` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2016-06-15  6:48:55
