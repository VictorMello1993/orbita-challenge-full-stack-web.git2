CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

START TRANSACTION;

CREATE TABLE `Students` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` text NULL,
    `Email` text NULL,
    `AR` varchar(767) NULL,
    `CPF` varchar(767) NULL,
    `Active` tinyint(1) NOT NULL,
    `UpdatedAt` datetime NOT NULL,
    `CreatedAt` datetime NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Users` (
    `Id` int NOT NULL AUTO_INCREMENT,
    `Name` text NULL,
    `Email` text NULL,
    `Password` text NULL,
    `UpdatedAt` datetime NOT NULL,
    `Active` tinyint(1) NOT NULL,
    `CreatedAt` datetime NOT NULL,
    PRIMARY KEY (`Id`)
);

CREATE UNIQUE INDEX `IX_Students_AR` ON `Students` (`AR`);

CREATE UNIQUE INDEX `IX_Students_CPF` ON `Students` (`CPF`);

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20210720105028_FirstMigration', '5.0.8');

COMMIT;

