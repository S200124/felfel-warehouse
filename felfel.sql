-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: Mar 27, 2021 at 04:17 PM
-- Server version: 8.0.22
-- PHP Version: 7.3.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `felfel`
--

-- --------------------------------------------------------

--
-- Table structure for table `batches`
--

CREATE TABLE `batches` (
  `Id` int NOT NULL,
  `ProductId` int NOT NULL,
  `Quantity` int NOT NULL,
  `ExpirationDate` datetime NOT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `batches`
--

INSERT INTO `batches` (`Id`, `ProductId`, `Quantity`, `ExpirationDate`, `CreatedAt`, `UpdatedAt`) VALUES
(4, 2, 19, '2021-03-31 14:02:40', '2021-03-26 23:33:56', '2021-03-26 23:33:56'),
(5, 6, 10, '2021-03-27 14:59:28', '2021-03-27 14:57:36', '2021-03-27 14:57:36'),
(6, 6, 20, '2021-03-29 15:00:00', '2021-03-27 15:18:17', '2021-03-27 15:18:17'),
(7, 7, 13, '2021-03-30 15:00:00', '2021-03-27 15:28:24', '2021-03-27 15:28:24');

-- --------------------------------------------------------

--
-- Table structure for table `movements`
--

CREATE TABLE `movements` (
  `Id` int NOT NULL,
  `BatchId` int NOT NULL,
  `Amount` int NOT NULL,
  `Timestamp` datetime NOT NULL,
  `Reason` text,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `movements`
--

INSERT INTO `movements` (`Id`, `BatchId`, `Amount`, `Timestamp`, `Reason`, `CreatedAt`, `UpdatedAt`) VALUES
(2, 4, 10, '2021-03-26 23:33:57', 'First Load', '2021-03-26 23:33:56', '2021-03-26 23:33:56'),
(3, 4, -2, '2021-03-27 00:02:54', 'Manual Update on Batch', '2021-03-27 00:03:19', '2021-03-27 00:03:19'),
(4, 4, -2, '2021-03-27 00:14:26', 'Manual Update on Batch', '2021-03-27 00:14:26', '2021-03-27 00:14:26'),
(5, 4, -2, '2021-03-27 13:00:25', 'Manual Update on Batch', '2021-03-27 13:00:25', '2021-03-27 13:00:25'),
(7, 4, -4, '2021-03-27 13:00:27', 'Manual Update on Batch', '2021-03-27 13:47:01', '2021-03-27 13:47:01'),
(8, 5, 10, '2021-03-27 13:50:27', 'First Load', '2021-03-27 14:57:36', '2021-03-27 14:57:36'),
(9, 6, 20, '2021-03-27 13:50:27', 'First Load', '2021-03-27 15:18:17', '2021-03-27 15:18:17'),
(10, 4, 5, '2021-03-27 13:50:27', 'Manual Update on Batch', '2021-03-27 15:25:18', '2021-03-27 15:25:18'),
(11, 7, 13, '2021-03-27 15:28:25', 'First Load', '2021-03-27 15:28:24', '2021-03-27 15:28:24'),
(12, 4, 14, '2021-03-27 15:28:40', 'Manual Update on Batch', '2021-03-27 15:28:39', '2021-03-27 15:28:39');

-- --------------------------------------------------------

--
-- Table structure for table `products`
--

CREATE TABLE `products` (
  `Id` int NOT NULL,
  `Name` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `CreatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `products`
--

INSERT INTO `products` (`Id`, `Name`, `CreatedAt`, `UpdatedAt`) VALUES
(2, 'Estathè Lemon', '2021-03-26 23:14:44', '2021-03-26 23:14:44'),
(6, 'Estathè Peach', '2021-03-27 13:16:54', '2021-03-27 13:16:54'),
(7, 'Estathè Mint', '2021-03-27 13:18:45', '2021-03-27 13:18:45');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `Id` int NOT NULL,
  `FirstName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `LastName` varchar(50) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL,
  `UserGroupId` int NOT NULL,
  `CreationDateTime` datetime NOT NULL,
  `LastUpdateDateTime` datetime NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20210326142118_DBInit', '5.0.0'),
('20210326144343_UserLastUpdateRequired', '5.0.0'),
('20210326210445_CreateProductTable', '5.0.0'),
('20210326213022_CreateBatchAndMovementTable', '5.0.0'),
('20210326213340_CorrectDefaultTimestamps', '5.0.0'),
('20210326224259_RemovedNotNull', '5.0.0');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `batches`
--
ALTER TABLE `batches`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_batches_ProductId` (`ProductId`);

--
-- Indexes for table `movements`
--
ALTER TABLE `movements`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_movements_BatchId` (`BatchId`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `batches`
--
ALTER TABLE `batches`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `movements`
--
ALTER TABLE `movements`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `Id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `batches`
--
ALTER TABLE `batches`
  ADD CONSTRAINT `FK_Batches_Products` FOREIGN KEY (`ProductId`) REFERENCES `products` (`Id`);

--
-- Constraints for table `movements`
--
ALTER TABLE `movements`
  ADD CONSTRAINT `FK_Movements_Batches` FOREIGN KEY (`BatchId`) REFERENCES `batches` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
