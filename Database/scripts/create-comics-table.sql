CREATE TABLE `Comics` (
  `Id` char(36) NOT NULL,
  `Price` decimal(9,2) NOT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Image` varchar(4000) DEFAULT NULL,
  `Description` varchar(4000) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
