-- MariaDB dump 10.19  Distrib 10.4.24-MariaDB, for Win64 (AMD64)
--
-- Host: localhost    Database: smartphone_store
-- ------------------------------------------------------
-- Server version	10.4.24-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `messages`
--

DROP TABLE IF EXISTS `messages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `messages` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `name` varchar(70) NOT NULL,
  `email` varchar(80) NOT NULL,
  `message` varchar(1000) NOT NULL,
  `date` datetime(6) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `messages`
--

LOCK TABLES `messages` WRITE;
/*!40000 ALTER TABLE `messages` DISABLE KEYS */;
/*!40000 ALTER TABLE `messages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones`
--

DROP TABLE IF EXISTS `smartphones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `model` varchar(40) NOT NULL,
  `brand` varchar(15) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones`
--

LOCK TABLES `smartphones` WRITE;
/*!40000 ALTER TABLE `smartphones` DISABLE KEYS */;
INSERT INTO `smartphones` VALUES (1,'Xiaomi 11 Lite 5G NE','Xiaomi','Предфлагман',161880,'Qualcomm Snapdragon 778G','AMOLED',8,128,4250,'Чёрный',351,'104','2022-01-03'),(2,'Apple iPhone 11 Pro','Apple','Флагман',643500,'Apple A13 Bionic','OLED',6,64,3046,'Зелёный',117,'166','2022-01-03'),(3,'Xiaomi Redmi Note 11 Pro 5G','Xiaomi','Среднебюджетный',177420,'Qualcomm Snapdragon 695','AMOLED',8,128,5000,'Белый',798,'140','2022-01-03'),(4,'Samsung Galaxy A53 5G','Samsung','Среднебюджетный',207426,'Qualcomm Snapdragon 695','Super AMOLED',8,256,5000,'Белый',644,'128','2022-01-03'),(5,'Xiaomi 11T Pro','Xiaomi','Флагман',357800,'Qualcomm Snapdragon 888','AMOLED',12,256,5000,'Синий',274,'115','2022-01-03'),(6,'Samsung Galaxy A12 Nacho','Samsung','Бюджетный',59712,'Samsung Exynos 850','PLS TFT',3,32,5000,'Синий',613,'109','2022-01-17'),(7,'Apple iPhone 12 Mini','Apple','Флагман',417679,'Apple A14 Bionic','OLED',4,128,2227,'Синий',177,'152','2022-01-17'),(8,'Samsung Galaxy A22','Samsung','Бюджетный',98776,'MediaTek Helio G80','Super AMOLED',4,64,5000,'Чёрный',395,'197','2022-01-17'),(9,'Xiaomi Poco F3','Xiaomi','Предфлагман',198800,'Qualcomm Snapdragon 870 5G','AMOLED',8,256,4520,'Чёрный',423,'171','2022-01-17'),(10,'Apple iPhone 12','Apple','Флагман',364390,'Apple A14 Bionic','OLED',4,64,2815,'Синий',106,'124','2022-01-17'),(11,'Xiaomi Redmi Note 10 Pro','Xiaomi','Среднебюджетный',147750,'Qualcomm Snapdragon 732G','AMOLED',8,128,5020,'Серый',458,'113','2022-01-31'),(12,'Samsung Galaxy S22 Ultra','Samsung','Флагман',770900,'Samsung Exynos 2200','Dynamic AMOLED',12,512,5000,'Зелёный',463,'101','2022-01-31'),(13,'Xiaomi Redmi Note 10S','Xiaomi','Среднебюджетный',116833,'Mediatek Helio G95','AMOLED',6,128,5000,'Синий',532,'184','2022-01-31'),(14,'Apple iPhone SE 2022','Apple','Предфлагман',314850,'Apple A15 Bionic','IPS LCD',4,128,2018,'Белый',364,'216','2022-01-31'),(15,'Xiaomi 12X','Xiaomi','Флагман',283340,'Qualcomm Snapdragon 870','AMOLED',8,256,4500,'Серый',137,'247','2022-02-28'),(16,'Apple iPhone SE 2020','Apple','Предфлагман',264264,'Apple A13 Bionic','IPS LCD',3,64,1821,'Белый',190,'211','2022-02-28'),(17,'Samsung Galaxy A03 Core','Samsung','Ультрабюджетный',45790,'Unisoc SC9863A','PLS TFT',2,32,5000,'Чёрный',454,'218','2022-02-28'),(18,'Xiaomi Redmi 10C','Xiaomi','Бюджетный',92299,'Qualcomm Snapdragon 680','IPS LCD',4,128,5000,'Зелёный',693,'229','2022-02-28'),(19,'Apple iPhone 13','Apple','Флагман',444400,'Apple A15 Bionic','OLED',4,128,3227,'Зелёный',842,'250','2022-02-28'),(20,'Xiaomi Redmi 9A','Xiaomi','Ультрабюджетный',46479,'MediaTek Helio G25','IPS LCD',2,32,5000,'Серый',959,'282','2022-03-14'),(21,'Samsung Galaxy A13','Samsung','Бюджетный',269900,'Samsung Exynos 850','PLS TFT',4,64,5000,'Серый',281,'236','2022-03-14'),(22,'Xiaomi Redmi Note 11S','Xiaomi','Среднебюджетный',129445,'MediaTek Helio G96','AMOLED',6,128,5000,'Серый',322,'205','2022-03-14'),(23,'Apple iPhone 13 Pro','Apple','Флагман',659900,'Apple A15 Bionic','OLED',6,256,3095,'Зелёный',418,'298','2022-03-14'),(24,'Samsung Galaxy S20 FE 5G','Samsung','Флагман',199890,'Qualcomm Snapdragon 865 5G','Super AMOLED',6,128,4500,'Синий',221,'261','2022-03-14'),(25,'Xiaomi Poco M4 Pro 5G','Xiaomi','Среднебюджетный',139285,'MediaTek Dimensity 810','IPS LCD',6,128,5000,'Чёрный',876,'213','2022-03-28'),(26,'Apple iPhone 11','Apple','Флагман',379990,'Apple A13 Bionic','IPS LCD',4,64,3110,'Белый',330,'275','2022-03-28'),(27,'Samsung Galaxy A32','Samsung','Среднебюджетный',119890,'Mediatek Helio G80','Super AMOLED',4,64,5000,'Чёрный',655,'286','2022-03-28'),(28,'Apple iPhone 12 Pro','Apple','Флагман',554630,'Apple A14 Bionic','OLED',6,128,2815,'Серый',164,'191','2022-03-28'),(29,'Xiaomi Mi 11 Ultra','Xiaomi','Флагман',568000,'Qualcomm Snapdragon 888','AMOLED',12,512,5000,'Чёрный',53,'150','2022-03-28'),(30,'Samsung Galaxy Z Fold 3','Samsung','Флагман',729000,'Qualcomm Snapdragon 888 5G','Dynamic AMOLED',12,256,4400,'Чёрный',105,'234','2022-04-11'),(31,'Xiaomi Black Shark 4 Pro','Xiaomi','Флагман',289900,'Qualcomm Snapdragon 888 5G','Super AMOLED',8,128,4500,'Чёрный',287,'263','2022-04-11'),(32,'Apple iPhone 13 Pro Max','Apple','Флагман',849990,'Apple A15 Bionic','OLED',6,1000,4352,'Серый',526,'277','2022-04-11'),(33,'Samsung Galaxy A52','Samsung','Среднебюджетный',177590,'Qualcomm Snapdragon 720G','Super AMOLED',8,256,4500,'Белый',328,'158','2022-04-11'),(35,'Apple iPhone 13','Apple','Флагман',490400,'Apple A15 Bionic','OLED',4,256,3227,'Чёрный',584,'110','2022-04-25'),(36,'Apple iPhone 13 mini','Apple','Флагман',460519,'Apple A15 Bionic','OLED',4,128,2406,'Белый',266,'252','2022-04-25'),(37,'Apple iPhone 12 Pro Max','Apple','Флагман',721650,'Apple A14 Bionic','OLED',6,512,3687,'Синий',138,'244','2022-04-25'),(38,'Apple iPhone 11 Pro Max','Apple','Флагман',769990,'Apple A13 Bionic','OLED',4,256,3969,'Серый',63,'284','2022-04-25'),(39,'Apple iPhone Xr','Apple','Флагман',326789,'Apple A12 Bionic','IPS LCD',3,64,2942,'Чёрный',24,'179','2022-04-25'),(40,'Samsung Galaxy A32','Samsung','Среднебюджетный',123760,'Mediatek Helio G80','Super AMOLED',4,64,5000,'Синий',541,'221','2022-05-09'),(41,'Samsung Galaxy Z Flip 3','Samsung','Флагман',449880,'Qualcomm Snapdragon 888 5G','Dynamic AMOLED',8,128,3300,'Чёрный',137,'162','2022-05-09'),(42,'Samsung Galaxy Note 20','Samsung','Флагман',362900,'Samsung Exynos 990','Super AMOLED',8,256,4300,'Серый',21,'240','2022-05-09'),(43,'Samsung Galaxy S22+','Samsung','Флагман',499705,'Samsung Exynos 2200','Dynamic AMOLED',8,128,4500,'Белый',689,'105','2022-05-09'),(44,'Samsung Galaxy A03s','Samsung','Бюджетный',64890,'MediaTek Helio P35','PLS TFT',3,32,5000,'Синий',866,'272','2022-05-23'),(46,'Xiaomi Redmi 9C','Xiaomi','Бюджетный',75780,'MediaTek Helio G35','IPS LCD',4,128,5000,'Серый',624,'299','2022-05-23'),(47,'Xiaomi 11T','Xiaomi','Флагман',244990,'MediaTek Dimensity 1200','AMOLED',8,256,5000,'Серый',518,'185','2022-05-23'),(57,'Xiaomi Poco M4 Pro 5G','Xiaomi','Среднебюджетный',114530,'MediaTek Dimensity 810','IPS LCD',4,64,5000,'Синий',1006,'233','2022-05-23');
/*!40000 ALTER TABLE `smartphones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_apple`
--

DROP TABLE IF EXISTS `smartphones_apple`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_apple` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_apple`
--

LOCK TABLES `smartphones_apple` WRITE;
/*!40000 ALTER TABLE `smartphones_apple` DISABLE KEYS */;
INSERT INTO `smartphones_apple` VALUES (1,'Apple iPhone 11 Pro','Флагман',643500,'Apple A13 Bionic','OLED',6,64,3046,'Зелёный',117,'166','2022-01-03'),(2,'Apple iPhone 12 Mini','Флагман',417679,'Apple A14 Bionic','OLED',4,128,2227,'Синий',177,'152','2022-01-17'),(3,'Apple iPhone SE 2020','Предфлагман',264264,'Apple A13 Bionic','IPS LCD',3,64,1821,'Белый',190,'211','2022-02-28'),(4,'Apple iPhone 11','Флагман',379990,'Apple A13 Bionic','IPS LCD',4,64,3110,'Белый',330,'275','2022-03-28'),(5,'Apple iPhone 12','Флагман',364390,'Apple A14 Bionic','OLED',4,64,2815,'Синий',106,'124','2022-01-17'),(6,'Apple iPhone 13','Флагман',444400,'Apple A15 Bionic','OLED',4,128,3227,'Зелёный',842,'250','2022-02-28'),(7,'Apple iPhone SE 2022','Предфлагман',314850,'Apple A15 Bionic','IPS LCD',4,128,2018,'Белый',364,'216','2022-01-31'),(8,'Apple iPhone 12 Pro','Флагман',554630,'Apple A14 Bionic','OLED',6,128,2815,'Серый',164,'191','2022-03-28'),(9,'Apple iPhone 13 Pro Max','Флагман',849990,'Apple A15 Bionic','OLED',6,1000,4352,'Серый',526,'277','2022-04-11'),(10,'Apple iPhone 13 Pro','Флагман',659900,'Apple A15 Bionic','OLED',6,256,3095,'Зелёный',418,'298','2022-03-14'),(11,'Apple iPhone 13','Флагман',490400,'Apple A15 Bionic','OLED',4,256,3227,'Чёрный',584,'110','2022-04-25'),(12,'Apple iPhone 13 mini','Флагман',460519,'Apple A15 Bionic','OLED',4,128,2406,'Белый',266,'252','2022-04-25'),(13,'Apple iPhone 12 Pro Max','Флагман',721650,'Apple A14 Bionic','OLED',6,512,3687,'Синий',138,'244','2022-04-25'),(14,'Apple iPhone 11 Pro Max','Флагман',769990,'Apple A13 Bionic','OLED',4,256,3969,'Серый',63,'284','2022-04-25'),(15,'Apple iPhone Xr','Флагман',326789,'Apple A12 Bionic','IPS LCD',3,64,2942,'Чёрный',24,'179','2022-04-25');
/*!40000 ALTER TABLE `smartphones_apple` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_apple_archive`
--

DROP TABLE IF EXISTS `smartphones_apple_archive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_apple_archive` (
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_apple_archive`
--

LOCK TABLES `smartphones_apple_archive` WRITE;
/*!40000 ALTER TABLE `smartphones_apple_archive` DISABLE KEYS */;
/*!40000 ALTER TABLE `smartphones_apple_archive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_apple_warehouse`
--

DROP TABLE IF EXISTS `smartphones_apple_warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_apple_warehouse` (
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_apple_warehouse`
--

LOCK TABLES `smartphones_apple_warehouse` WRITE;
/*!40000 ALTER TABLE `smartphones_apple_warehouse` DISABLE KEYS */;
INSERT INTO `smartphones_apple_warehouse` VALUES ('Apple iPhone 11 Pro','Флагман',643500,'Apple A13 Bionic','OLED',6,64,3046,'Зелёный',117),('Apple iPhone 12 Mini','Флагман',417679,'Apple A14 Bionic','OLED',4,128,2227,'Синий',177),('Apple iPhone SE 2020','Предфлагман',264264,'Apple A13 Bionic','IPS LCD',3,64,1821,'Белый',190),('Apple iPhone 11','Флагман',379990,'Apple A13 Bionic','IPS LCD',4,64,3110,'Белый',330),('Apple iPhone 12','Флагман',364390,'Apple A14 Bionic','OLED',4,64,2815,'Синий',106),('Apple iPhone 13','Флагман',444400,'Apple A15 Bionic','OLED',4,128,3227,'Зелёный',842),('Apple iPhone SE 2022','Предфлагман',314850,'Apple A15 Bionic','IPS LCD',4,128,2018,'Белый',364),('Apple iPhone 12 Pro','Флагман',554630,'Apple A14 Bionic','OLED',6,128,2815,'Серый',164),('Apple iPhone 13 Pro Max','Флагман',849990,'Apple A15 Bionic','OLED',6,1000,4352,'Серый',526),('Apple iPhone 13 Pro','Флагман',659900,'Apple A15 Bionic','OLED',6,256,3095,'Зелёный',418),('Apple iPhone 13','Флагман',490400,'Apple A15 Bionic','OLED',4,256,3227,'Чёрный',584),('Apple iPhone 13 mini','Флагман',460519,'Apple A15 Bionic','OLED',4,128,2406,'Белый',266),('Apple iPhone 12 Pro Max','Флагман',721650,'Apple A14 Bionic','OLED',6,512,3687,'Синий',138),('Apple iPhone 11 Pro Max','Флагман',769990,'Apple A13 Bionic','OLED',4,256,3969,'Серый',63),('Apple iPhone Xr','Флагман',326789,'Apple A12 Bionic','IPS LCD',3,64,2942,'Чёрный',24);
/*!40000 ALTER TABLE `smartphones_apple_warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_archive`
--

DROP TABLE IF EXISTS `smartphones_archive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_archive` (
  `model` varchar(40) NOT NULL,
  `brand` varchar(15) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_archive`
--

LOCK TABLES `smartphones_archive` WRITE;
/*!40000 ALTER TABLE `smartphones_archive` DISABLE KEYS */;
/*!40000 ALTER TABLE `smartphones_archive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_samsung`
--

DROP TABLE IF EXISTS `smartphones_samsung`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_samsung` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=20 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_samsung`
--

LOCK TABLES `smartphones_samsung` WRITE;
/*!40000 ALTER TABLE `smartphones_samsung` DISABLE KEYS */;
INSERT INTO `smartphones_samsung` VALUES (1,'Samsung Galaxy A03 Core','Ультрабюджетный',45790,'Unisoc SC9863A','PLS TFT',2,32,5000,'Чёрный',454,'218','2022-02-28'),(2,'Samsung Galaxy A12 Nacho','Бюджетный',59712,'Samsung Exynos 850','PLS TFT',3,32,5000,'Синий',613,'109','2022-01-17'),(3,'Samsung Galaxy A13','Бюджетный',269900,'Samsung Exynos 850','PLS TFT',4,64,5000,'Серый',281,'236','2022-03-14'),(4,'Samsung Galaxy A22','Бюджетный',98776,'MediaTek Helio G80','Super AMOLED',4,64,5000,'Чёрный',395,'197','2022-01-17'),(5,'Samsung Galaxy A32','Среднебюджетный',119890,'Mediatek Helio G80','Super AMOLED',4,64,5000,'Чёрный',655,'286','2022-03-28'),(6,'Samsung Galaxy A32','Среднебюджетный',123760,'Mediatek Helio G80','Super AMOLED',4,64,5000,'Синий',541,'221','2022-05-09'),(7,'Samsung Galaxy A52','Среднебюджетный',177590,'Qualcomm Snapdragon 720G','Super AMOLED',8,256,4500,'Белый',328,'158','2022-04-11'),(8,'Samsung Galaxy A53 5G','Среднебюджетный',207426,'Qualcomm Snapdragon 695','Super AMOLED',8,256,5000,'Белый',645,'695','2022-01-03'),(9,'Samsung Galaxy S20 FE 5G','Флагман',199890,'Qualcomm Snapdragon 865 5G','Super AMOLED',6,128,4500,'Синий',221,'261','2022-03-14'),(10,'Samsung Galaxy S22 Ultra','Флагман',770900,'Samsung Exynos 2200','Dynamic AMOLED',12,512,5000,'Зелёный',463,'101','2022-01-31'),(11,'Samsung Galaxy Z Fold 3','Флагман',729000,'Qualcomm Snapdragon 888 5G','Dynamic AMOLED',12,256,4400,'Чёрный',105,'234','2022-04-11'),(12,'Samsung Galaxy Z Flip 3','Флагман',449880,'Qualcomm Snapdragon 888 5G','Dynamic AMOLED',8,128,3300,'Чёрный',137,'162','2022-05-09'),(13,'Samsung Galaxy Note 20','Флагман',362900,'Samsung Exynos 990','Super AMOLED',8,256,4300,'Серый',21,'240','2022-05-09'),(14,'Samsung Galaxy S22+','Флагман',499705,'Samsung Exynos 2200','Dynamic AMOLED',8,128,4500,'Белый',689,'105','2022-05-09'),(15,'Samsung Galaxy A03s','Бюджетный',64890,'MediaTek Helio P35','PLS TFT',3,32,5000,'Синий',866,'272','2022-05-23');
/*!40000 ALTER TABLE `smartphones_samsung` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_samsung_archive`
--

DROP TABLE IF EXISTS `smartphones_samsung_archive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_samsung_archive` (
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_samsung_archive`
--

LOCK TABLES `smartphones_samsung_archive` WRITE;
/*!40000 ALTER TABLE `smartphones_samsung_archive` DISABLE KEYS */;
/*!40000 ALTER TABLE `smartphones_samsung_archive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_samsung_warehouse`
--

DROP TABLE IF EXISTS `smartphones_samsung_warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_samsung_warehouse` (
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_samsung_warehouse`
--

LOCK TABLES `smartphones_samsung_warehouse` WRITE;
/*!40000 ALTER TABLE `smartphones_samsung_warehouse` DISABLE KEYS */;
INSERT INTO `smartphones_samsung_warehouse` VALUES ('Samsung Galaxy A03 Core','Ультрабюджетный',45790,'Unisoc SC9863A','PLS TFT',2,32,5000,'Чёрный',454),('Samsung Galaxy A12 Nacho','Бюджетный',59712,'Samsung Exynos 850','PLS TFT',3,32,5000,'Синий',613),('Samsung Galaxy A13','Бюджетный',269900,'Samsung Exynos 850','PLS TFT',4,64,5000,'Серый',281),('Samsung Galaxy A22','Бюджетный',98776,'MediaTek Helio G80','Super AMOLED',4,64,5000,'Чёрный',395),('Samsung Galaxy A32','Среднебюджетный',119890,'Mediatek Helio G80','Super AMOLED',4,64,5000,'Чёрный',655),('Samsung Galaxy A32','Среднебюджетный',123760,'Mediatek Helio G80','Super AMOLED',4,64,5000,'Синий',541),('Samsung Galaxy A52','Среднебюджетный',177590,'Qualcomm Snapdragon 720G','Super AMOLED',8,256,4500,'Белый',328),('Samsung Galaxy A53 5G','Среднебюджетный',207426,'Qualcomm Snapdragon 695','Super AMOLED',8,256,5000,'Белый',645),('Samsung Galaxy S20 FE 5G','Флагман',199890,'Qualcomm Snapdragon 865 5G','Super AMOLED',6,128,4500,'Синий',221),('Samsung Galaxy S22 Ultra','Флагман',770900,'Samsung Exynos 2200','Dynamic AMOLED',12,512,5000,'Зелёный',463),('Samsung Galaxy Z Fold 3','Флагман',729000,'Qualcomm Snapdragon 888 5G','Dynamic AMOLED',12,256,4400,'Чёрный',105),('Samsung Galaxy Z Flip 3','Флагман',449880,'Qualcomm Snapdragon 888 5G','Dynamic AMOLED',8,128,3300,'Чёрный',137),('Samsung Galaxy Note 20','Флагман',362900,'Samsung Exynos 990','Super AMOLED',8,256,4300,'Серый',21),('Samsung Galaxy S22+','Флагман',499705,'Samsung Exynos 2200','Dynamic AMOLED',8,128,4500,'Белый',689),('Samsung Galaxy A03s','Бюджетный',64890,'MediaTek Helio P35','PLS TFT',3,32,5000,'Синий',866);
/*!40000 ALTER TABLE `smartphones_samsung_warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_warehouse`
--

DROP TABLE IF EXISTS `smartphones_warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_warehouse` (
  `model` varchar(40) NOT NULL,
  `brand` varchar(15) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_warehouse`
--

LOCK TABLES `smartphones_warehouse` WRITE;
/*!40000 ALTER TABLE `smartphones_warehouse` DISABLE KEYS */;
INSERT INTO `smartphones_warehouse` VALUES ('Xiaomi 11 Lite 5G NE','Xiaomi','Предфлагман',161880,'Qualcomm Snapdragon 778G','AMOLED',8,128,4250,'Чёрный',351),('Apple iPhone 11 Pro','Apple','Флагман',643500,'Apple A13 Bionic','OLED',6,64,3046,'Зелёный',117),('Xiaomi Redmi Note 11 Pro 5G','Xiaomi','Среднебюджетный',177420,'Qualcomm Snapdragon 695','AMOLED',8,128,5000,'Белый',798),('Samsung Galaxy A53 5G','Samsung','Среднебюджетный',207426,'Qualcomm Snapdragon 695','Super AMOLED',8,256,5000,'Белый',644),('Xiaomi 11T Pro','Xiaomi','Флагман',357800,'Qualcomm Snapdragon 888','AMOLED',12,256,5000,'Синий',274),('Samsung Galaxy A12 Nacho','Samsung','Бюджетный',59712,'Samsung Exynos 850','PLS TFT',3,32,5000,'Синий',613),('Apple iPhone 12 Mini','Apple','Флагман',417679,'Apple A14 Bionic','OLED',4,128,2227,'Синий',177),('Samsung Galaxy A22','Samsung','Бюджетный',98776,'MediaTek Helio G80','Super AMOLED',4,64,5000,'Чёрный',395),('Xiaomi Poco F3','Xiaomi','Предфлагман',198800,'Qualcomm Snapdragon 870 5G','AMOLED',8,256,4520,'Чёрный',423),('Apple iPhone 12','Apple','Флагман',364390,'Apple A14 Bionic','OLED',4,64,2815,'Синий',106),('Xiaomi Redmi Note 10 Pro','Xiaomi','Среднебюджетный',147750,'Qualcomm Snapdragon 732G','AMOLED',8,128,5020,'Серый',458),('Samsung Galaxy S22 Ultra','Samsung','Флагман',770900,'Samsung Exynos 2200','Dynamic AMOLED',12,512,5000,'Зелёный',463),('Xiaomi Redmi Note 10S','Xiaomi','Среднебюджетный',116833,'Mediatek Helio G95','AMOLED',6,128,5000,'Синий',532),('Apple iPhone SE 2022','Apple','Предфлагман',314850,'Apple A15 Bionic','IPS LCD',4,128,2018,'Белый',364),('Xiaomi 12X','Xiaomi','Флагман',283340,'Qualcomm Snapdragon 870','AMOLED',8,256,4500,'Серый',137),('Apple iPhone SE 2020','Apple','Предфлагман',264264,'Apple A13 Bionic','IPS LCD',3,64,1821,'Белый',190),('Samsung Galaxy A03 Core','Samsung','Ультрабюджетный',45790,'Unisoc SC9863A','PLS TFT',2,32,5000,'Чёрный',454);
/*!40000 ALTER TABLE `smartphones_warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_xiaomi`
--

DROP TABLE IF EXISTS `smartphones_xiaomi`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_xiaomi` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_xiaomi`
--

LOCK TABLES `smartphones_xiaomi` WRITE;
/*!40000 ALTER TABLE `smartphones_xiaomi` DISABLE KEYS */;
INSERT INTO `smartphones_xiaomi` VALUES (1,'Xiaomi Redmi Note 11S','Среднебюджетный',129445,'MediaTek Helio G96','AMOLED',6,128,5000,'Серый',322,'205','2022-03-14'),(2,'Xiaomi 11 Lite 5G NE','Предфлагман',161880,'Qualcomm Snapdragon 778G','AMOLED',8,128,4250,'Чёрный',351,'104','2022-01-03'),(3,'Xiaomi 11T Pro','Флагман',357800,'Qualcomm Snapdragon 888','AMOLED',12,256,5000,'Синий',274,'115','2022-01-03'),(4,'Xiaomi 12X','Флагман',283340,'Qualcomm Snapdragon 870','AMOLED',8,256,4500,'Серый',137,'247','2022-02-28'),(5,'Xiaomi Black Shark 4 Pro','Флагман',289900,'Qualcomm Snapdragon 888 5G','Super AMOLED',8,128,4500,'Чёрный',287,'263','2022-04-11'),(6,'Xiaomi Mi 11 Ultra','Флагман',568000,'Qualcomm Snapdragon 888','AMOLED',12,512,5000,'Чёрный',53,'150','2022-03-28'),(7,'Xiaomi Poco F3','Предфлагман',198800,'Qualcomm Snapdragon 870 5G','AMOLED',8,256,4520,'Чёрный',423,'171','2022-01-17'),(8,'Xiaomi Poco M4 Pro 5G','Среднебюджетный',139285,'MediaTek Dimensity 810','IPS LCD',6,128,5000,'Чёрный',876,'213','2022-03-28'),(9,'Xiaomi Redmi 10C','Бюджетный',92299,'Qualcomm Snapdragon 680','IPS LCD',4,128,5000,'Зелёный',693,'229','2022-02-28'),(10,'Xiaomi Redmi 9A','Ультрабюджетный',46479,'MediaTek Helio G25','IPS LCD',2,32,5000,'Серый',959,'282','2022-03-14'),(11,'Xiaomi Redmi Note 10 Pro','Среднебюджетный',147750,'Qualcomm Snapdragon 732G','AMOLED',8,128,5020,'Серый',458,'113','2022-01-31'),(12,'Xiaomi Redmi Note 10S','Среднебюджетный',116833,'Mediatek Helio G95','AMOLED',6,128,5000,'Синий',532,'184','2022-01-31'),(13,'Xiaomi Redmi Note 11 Pro 5G','Среднебюджетный',177420,'Qualcomm Snapdragon 695','AMOLED',8,128,5000,'Белый',798,'140','2022-01-03'),(15,'Xiaomi Redmi 9C','Бюджетный',75780,'MediaTek Helio G35','IPS LCD',4,128,5000,'Серый',624,'299','2022-05-23'),(16,'Xiaomi 11T','Флагман',244990,'MediaTek Dimensity 1200','AMOLED',8,256,5000,'Серый',518,'185','2022-05-23'),(17,'Xiaomi Poco M4 Pro 5G','Среднебюджетный',114530,'MediaTek Dimensity 810','IPS LCD',4,64,5000,'Синий',1006,'233','2022-05-23');
/*!40000 ALTER TABLE `smartphones_xiaomi` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_xiaomi_archive`
--

DROP TABLE IF EXISTS `smartphones_xiaomi_archive`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_xiaomi_archive` (
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL,
  `consignment` varchar(6) NOT NULL,
  `receipt_date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_xiaomi_archive`
--

LOCK TABLES `smartphones_xiaomi_archive` WRITE;
/*!40000 ALTER TABLE `smartphones_xiaomi_archive` DISABLE KEYS */;
/*!40000 ALTER TABLE `smartphones_xiaomi_archive` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smartphones_xiaomi_warehouse`
--

DROP TABLE IF EXISTS `smartphones_xiaomi_warehouse`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smartphones_xiaomi_warehouse` (
  `model` varchar(40) NOT NULL,
  `class` varchar(30) NOT NULL,
  `price` int(7) NOT NULL,
  `cpu` varchar(40) NOT NULL,
  `display` varchar(20) NOT NULL,
  `dram` int(2) NOT NULL,
  `memory` int(4) NOT NULL,
  `battery` int(4) NOT NULL,
  `color` varchar(25) NOT NULL,
  `quantity` int(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smartphones_xiaomi_warehouse`
--

LOCK TABLES `smartphones_xiaomi_warehouse` WRITE;
/*!40000 ALTER TABLE `smartphones_xiaomi_warehouse` DISABLE KEYS */;
INSERT INTO `smartphones_xiaomi_warehouse` VALUES ('Xiaomi Redmi Note 11S','Среднебюджетный',129445,'MediaTek Helio G96','AMOLED',6,128,5000,'Серый',322),('Xiaomi 11 Lite 5G NE','Предфлагман',161880,'Qualcomm Snapdragon 778G','AMOLED',8,128,4250,'Чёрный',351),('Xiaomi 11T Pro','Флагман',357800,'Qualcomm Snapdragon 888','AMOLED',12,256,5000,'Синий',274),('Xiaomi 12X','Флагман',283340,'Qualcomm Snapdragon 870','AMOLED',8,256,4500,'Серый',137),('Xiaomi Black Shark 4 Pro','Флагман',289900,'Qualcomm Snapdragon 888 5G','Super AMOLED',8,128,4500,'Чёрный',287),('Xiaomi Mi 11 Ultra','Флагман',568000,'Qualcomm Snapdragon 888','AMOLED',12,512,5000,'Чёрный',53),('Xiaomi Poco F3','Предфлагман',198800,'Qualcomm Snapdragon 870 5G','AMOLED',8,256,4520,'Чёрный',423),('Xiaomi Poco M4 Pro 5G','Среднебюджетный',139285,'MediaTek Dimensity 810','IPS LCD',6,128,5000,'Чёрный',876),('Xiaomi Redmi 10C','Бюджетный',92299,'Qualcomm Snapdragon 680','IPS LCD',4,128,5000,'Зелёный',693),('Xiaomi Redmi 9A','Ультрабюджетный',46479,'MediaTek Helio G25','IPS LCD',2,32,5000,'Серый',959),('Xiaomi Redmi Note 10 Pro','Среднебюджетный',147750,'Qualcomm Snapdragon 732G','AMOLED',8,128,5020,'Серый',458),('Xiaomi Redmi Note 10S','Среднебюджетный',116833,'Mediatek Helio G95','AMOLED',6,128,5000,'Синий',532),('Xiaomi Redmi Note 11 Pro 5G','Среднебюджетный',177420,'Qualcomm Snapdragon 695','AMOLED',8,128,5000,'Белый',798),('Xiaomi Redmi 9C','Бюджетный',75780,'MediaTek Helio G35','IPS LCD',4,128,5000,'Серый',624),('Xiaomi 11T','Флагман',244990,'MediaTek Dimensity 1200','AMOLED',8,256,5000,'Серый',518),('Xiaomi Poco M4 Pro 5G','Среднебюджетный',114530,'MediaTek Dimensity 810','IPS LCD',4,64,5000,'Синий',1006);
/*!40000 ALTER TABLE `smartphones_xiaomi_warehouse` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `staff` (
  `id` int(4) NOT NULL AUTO_INCREMENT,
  `fullname` varchar(70) NOT NULL,
  `job` varchar(60) NOT NULL,
  `city` varchar(30) NOT NULL,
  `salary` varchar(7) NOT NULL,
  `phone` bigint(20) NOT NULL,
  `datebirth` date NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,'Янпольская Василиса Семеновна','Директор магазина','Кокшетау','510000',79164811333,'1961-08-12'),(2,'Третьяков Максим Порфирьевич','Ведущий бухгалтер по сверке взаиморасчетов с банками','Алматы','440000',79856355799,'1985-05-02'),(3,'Тургенева Ольга Власовна','Бухгалтер по учету ТМЦ','Кокшетау','325000',79927586161,'1991-11-22'),(4,'Васнецов Николай Артемович','Менеджер по работе с B2B клиентами','Нур-Султан','342000',79092476252,'1989-12-10'),(5,'Перминов Георгий Кириллович','Старший специалист по планированию поставок','Актобе','391000',79856227640,'1980-04-15'),(6,'Миров Ефрем Евгеньевич','Офис-менеджер','Шымкент','269000',79441794715,'1960-12-14'),(7,'Тургенева Зоя Лукьяновна','Ведущий финансовый аналитик','Алматы','587000',79068492045,'1963-06-19'),(8,'Умаметев Давид Романович','Ведущий специалист по поддержке','Караганда','411000',79789337519,'1981-10-23'),(9,'Садыкова Вероника Тимофеевна','Администратор 1С','Алматы','490000',79297726248,'1984-07-05'),(10,'Шеин Наум Валентинович','Директор магазина','Нур-Султан','472000',79934717533,'1965-03-24'),(11,'Хитрово Милана Наумовна','Арт Директор','Павлодар','452000',79263779449,'1995-01-18'),(12,'Гуськов Граний Валерьевич','Главный Data Scientist','Караганда','553000',79281373551,'1989-09-08'),(13,'Щетинин Артур Васильевич','Генеральный директор','Алматы','1464000',77778227650,'1962-09-20'),(14,'Фетисов Григорий Кузьмич','Ведущий специалист поддержки систем IT','Нур-Султан','535000',79067628625,'1983-10-03'),(15,'Шульц Милослава Себастьяновна','Директор по маркетингу','Шымкент','439000',79964222519,'1990-02-21');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `id` int(4) unsigned NOT NULL AUTO_INCREMENT,
  `login` varchar(16) NOT NULL,
  `password` varchar(16) NOT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Admin','root123'),(2,'User','123456');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2022-06-19  5:49:11
