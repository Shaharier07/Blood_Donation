-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jun 26, 2019 at 05:37 AM
-- Server version: 10.1.38-MariaDB
-- PHP Version: 7.3.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `blood`
--

-- --------------------------------------------------------

--
-- Table structure for table `blood_bank`
--

CREATE TABLE `blood_bank` (
  `Area` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `blood_bank`
--

INSERT INTO `blood_bank` (`Area`) VALUES
('Adabor'),
('Badda'),
('Bangshal'),
('Bimanbandar'),
('Cantonment'),
('Chawkbazar Model'),
('Dakshinkhan'),
('Darus Salam'),
('Demra'),
('Dhanmondi'),
('Gendaria'),
('Gulshan'),
('Hazaribagh'),
('Jatrabari'),
('Kadamtali'),
('Kafrul'),
('Kalabagan'),
('Kamrangirchar'),
('Khilgaon'),
('Khilkhet'),
('Kotwali'),
('Lalbagh'),
('Mirpur'),
('Mohammadpur'),
('Motijheel'),
('New Market'),
('Pallabi'),
('Paltan'),
('Ramna'),
('Rampura'),
('Sabujbagh'),
('Shah Ali'),
('Shahbagh'),
('Sher-e-Bangla Nagar'),
('Shyampur'),
('Sutrapur'),
('Tejgaon'),
('Turag'),
('Uttar Khan'),
('Uttara');

-- --------------------------------------------------------

--
-- Table structure for table `donation`
--

CREATE TABLE `donation` (
  `userid` varchar(10) DEFAULT NULL,
  `Area` varchar(50) DEFAULT NULL,
  `B_D_Date` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `donation`
--

INSERT INTO `donation` (`userid`, `Area`, `B_D_Date`) VALUES
('n123', 'Mirpur', '2020-03-01'),
('p123', 'Mirpur', '0000-00-00');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE `user` (
  `username` varchar(30) NOT NULL,
  `userid` varchar(10) NOT NULL,
  `pass` varchar(10) NOT NULL,
  `b_group` varchar(3) NOT NULL,
  `phone` varchar(11) NOT NULL,
  `address` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`username`, `userid`, `pass`, `b_group`, `phone`, `address`) VALUES
('nesar uddin', 'n123', '1234', 'A+', '541515', 'fgjhvhm'),
('nesaruddin', 'nu123', '1234', 'A+', '01854378284', 'mirpur-2'),
('pranto', 'p123', '1234', 'A+', '541545454', 'dlkgolpdfjklfjkjr');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `blood_bank`
--
ALTER TABLE `blood_bank`
  ADD PRIMARY KEY (`Area`);

--
-- Indexes for table `donation`
--
ALTER TABLE `donation`
  ADD KEY `userid` (`userid`),
  ADD KEY `BB_name` (`Area`);

--
-- Indexes for table `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userid`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `donation`
--
ALTER TABLE `donation`
  ADD CONSTRAINT `donation_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `user` (`userid`),
  ADD CONSTRAINT `donation_ibfk_2` FOREIGN KEY (`Area`) REFERENCES `blood_bank` (`Area`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
