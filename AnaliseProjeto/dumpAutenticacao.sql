-- Senha para admin é Admin@123
-- Senha para empresa é Empresa@123
-- Senha para candidato é Candidato@123

--
-- Table structure for table `aspnetroles`
--
/*TABLE `aspnetroles` (
  `Id` varchar(767) NOT NULL,
  `Name` varchar(256) DEFAULT NULL,
  `NormalizedName` varchar(256) DEFAULT NULL,
  `ConcurrencyStamp` text,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `RoleNameIndex` (`NormalizedName`)
)
*/
INSERT INTO `aspnetroles` VALUES 
  ('1','Admin','Admin',NULL),
  ('2','Empresa','Empresa',NULL),
  ('3','Candidato','Candidato',NULL);

--
-- Table structure for table `aspnetuserroles`
--
/*TABLE `aspnetuserroles` (
  `UserId` varchar(767) NOT NULL,
  `RoleId` varchar(767) NOT NULL,
  PRIMARY KEY (`UserId`,`RoleId`),
  KEY `IX_AspNetUserRoles_RoleId` (`RoleId`),
  CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE
)
*/
INSERT INTO `aspnetuserroles` VALUES 
  ('688e51e9-4e01-46af-b4af-befe4223f21a','1'), -- Admin
  ('e96b10f4-2295-49fe-be9b-c5e9afa8b555','2'), -- Empresa
  ('8ef9fae3-1794-42aa-9a09-ef3ffae534ab','3'); -- Candidato

--
-- Table structure for table `aspnetusers`
--
/*TABLE `aspnetusers` (
  `Id` varchar(767) NOT NULL,
  `UserName` varchar(256) DEFAULT NULL,
  `NormalizedUserName` varchar(256) DEFAULT NULL,
  `Email` varchar(256) DEFAULT NULL,
  `NormalizedEmail` varchar(256) DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` text,
  `SecurityStamp` text,
  `ConcurrencyStamp` text,
  `PhoneNumber` text,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` timestamp NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  KEY `EmailIndex` (`NormalizedEmail`)
)
*/
INSERT INTO `aspnetusers` VALUES 
('b788de87-1754-48ae-9e29-10109d5bcd3d','admin@gmail.com','ADMIN@GMAIL.COM','admin@gmail.com','ADMIN@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEPCLBxpixUQKDsQlVTHb2VBCRnGoeKzo4NCyTjYus00dOWAddHY60G7u0n9nsufWqA==','RN7AG6GXCEESSHEJG3INHCN7RHZPWOAC','8dbbe2f0-4514-4090-8a30-9dc3669b991d',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),

('688e51e9-4e01-46af-b4af-befe4223f21a','empresa@gmail.com','EMPRESA@GMAIL.COM','empresa@gmail.com','EMPRESA@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAECEgkMyfTTtOyqNcab9DK4L7GvVL7ZoCHw8L9cN3TgcZtFQZVp0l/KIv+s+RJ2IerQ==','XRMYOCLKAFJ6OI2J6VGQY5OORHBCFDUW','99f9cd3d-587f-4fbd-937e-af53682905f7',NULL,_binary '\0',_binary '\0',NULL,_binary '',0),

('8ef9fae3-1794-42aa-9a09-ef3ffae534ab','candidato@gmail.com','CANDIDATO@GMAIL.COM','candidato@gmail.com','CANDIDATO@GMAIL.COM',_binary '\0','AQAAAAEAACcQAAAAEGK88U7DKX5qYhKWQLcCq0MYmK6FwowkvC9MtZXDeziYQ8BZaGRn8C5zu0YGlgWzyg==','V6GFLK5YWXXRIFAUBU35PWU5YKEQ4JFB','21d9f595-f908-4616-b877-ba7abd8a0808',NULL,_binary '\0',_binary '\0',NULL,_binary '',0);


-- Senha para admin é Admin@123
-- Senha para empresa é Empresa@123
-- Senha para candidato é Candidato@123