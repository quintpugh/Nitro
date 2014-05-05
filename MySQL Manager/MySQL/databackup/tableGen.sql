DROP SCHEMA IF EXISTS `nitro`;
CREATE SCHEMA `nitro`;

CREATE TABLE `nitro`.`teacher` (
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `fName` VARCHAR(45) NOT NULL,
  `lName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`username`)
);

CREATE TABLE `nitro`.`dba` (
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `fName` VARCHAR(45) NOT NULL,
  `lName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`username`)
);

CREATE TABLE `nitro`.`class` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `teacherUsername` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`)
);

CREATE TABLE `nitro`.`student` (
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `fName` VARCHAR(45) NOT NULL,
  `lName` VARCHAR(45) NOT NULL,
  `classId` INT NOT NULL,
  PRIMARY KEY (`username`),
  INDEX `classId.fk_idx` (`classId` ASC),
  CONSTRAINT `classId.fk`
    FOREIGN KEY (`classId`)
    REFERENCES `nitro`.`class` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE `nitro`.`exercise` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `text` VARCHAR(45) NOT NULL,
  `owner` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `owner.fk_idx` (`owner` ASC),
  CONSTRAINT `owner.fk`
    FOREIGN KEY (`owner`)
    REFERENCES `nitro`.`teacher` (`username`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE `nitro`.`class_exercises` (
  `classId` INT NOT NULL,
  `exerciseId` INT NOT NULL,
  PRIMARY KEY (`exerciseId`, `classId`),
  INDEX `classId.fk_idx` (`classId` ASC),
  INDEX `exerciseId.fk_idx` (`exerciseId` ASC),
  CONSTRAINT `class_exercises_classId.fk`
    FOREIGN KEY (`classId`)
    REFERENCES `nitro`.`class` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `exerciseId.fk`
    FOREIGN KEY (`exerciseId`)
    REFERENCES `nitro`.`exercise` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE `nitro`.`student_performance` (
  `studentUsername` VARCHAR(45) NOT NULL,
  `classId` INT NOT NULL,
  `exerciseId` INT NOT NULL,
  `errorCount` INT NOT NULL,
  `time` INT NOT NULL,
  PRIMARY KEY (`studentUsername`, `classId`, `exerciseId`),
  INDEX `perf_exerciseId_idx` (`exerciseId` ASC),
  CONSTRAINT `perf_studentId.fk`
    FOREIGN KEY (`studentUsername`)
    REFERENCES `nitro`.`student` (`username`)
    ON DELETE CASCADE
    ON UPDATE CASCADE,
  CONSTRAINT `perf_exerciseId`
    FOREIGN KEY (`exerciseId`)
    REFERENCES `nitro`.`exercise` (`id`)
    ON DELETE CASCADE
    ON UPDATE CASCADE
 );

