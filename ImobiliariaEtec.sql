-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: 20-Maio-2020 às 00:07
-- Versão do servidor: 10.1.39-MariaDB
-- versão do PHP: 7.3.5

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `imobiliariaetec`
--
CREATE DATABASE IF NOT EXISTS `imobiliariaetec` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `imobiliariaetec`;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroleclaims`
--

CREATE TABLE `aspnetroleclaims` (
  `Id` int(11) NOT NULL,
  `RoleId` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetroles`
--

CREATE TABLE `aspnetroles` (
  `Id` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedName` varchar(85) CHARACTER SET utf8mb4 DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `aspnetroles`
--

INSERT INTO `aspnetroles` (`Id`, `Name`, `NormalizedName`, `ConcurrencyStamp`) VALUES
('a18be9c0-aa65-4af8-bd17-00bd9344e575', 'Administrador', 'ADMINISTRADOR', '6f277284-cd6d-4093-9b9b-22229cf32b1a');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserclaims`
--

CREATE TABLE `aspnetuserclaims` (
  `Id` int(11) NOT NULL,
  `UserId` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `ClaimType` longtext CHARACTER SET utf8mb4,
  `ClaimValue` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserlogins`
--

CREATE TABLE `aspnetuserlogins` (
  `LoginProvider` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderKey` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET utf8mb4,
  `UserId` varchar(85) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetuserroles`
--

CREATE TABLE `aspnetuserroles` (
  `UserId` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `RoleId` varchar(85) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `aspnetuserroles`
--

INSERT INTO `aspnetuserroles` (`UserId`, `RoleId`) VALUES
('a18be9c0-aa65-4af8-bd17-00bd9344e575', 'a18be9c0-aa65-4af8-bd17-00bd9344e575');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusers`
--

CREATE TABLE `aspnetusers` (
  `Id` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `UserName` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedUserName` varchar(85) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Email` varchar(256) CHARACTER SET utf8mb4 DEFAULT NULL,
  `NormalizedEmail` varchar(85) CHARACTER SET utf8mb4 DEFAULT NULL,
  `EmailConfirmed` tinyint(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET utf8mb4,
  `SecurityStamp` longtext CHARACTER SET utf8mb4,
  `ConcurrencyStamp` longtext CHARACTER SET utf8mb4,
  `PhoneNumber` longtext CHARACTER SET utf8mb4,
  `PhoneNumberConfirmed` tinyint(1) NOT NULL,
  `TwoFactorEnabled` tinyint(1) NOT NULL,
  `LockoutEnd` datetime(6) DEFAULT NULL,
  `LockoutEnabled` tinyint(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `Nome` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `aspnetusers`
--

INSERT INTO `aspnetusers` (`Id`, `UserName`, `NormalizedUserName`, `Email`, `NormalizedEmail`, `EmailConfirmed`, `PasswordHash`, `SecurityStamp`, `ConcurrencyStamp`, `PhoneNumber`, `PhoneNumberConfirmed`, `TwoFactorEnabled`, `LockoutEnd`, `LockoutEnabled`, `AccessFailedCount`, `Nome`) VALUES
('a18be9c0-aa65-4af8-bd17-00bd9344e575', 'admin@imobiliariaetec.com.br', 'ADMIN@IMOBILIARIAETEC.COM.BR', 'admin@imobiliariaetec.com.br', 'ADMIN@IMOBILIARIAETEC.COM.BR', 1, 'AQAAAAEAACcQAAAAEJChZ45e8ltw6yzSq+NaCRPdFvZKSmPQd5WK9o7exvx4AlUCQrNTDfdZJMICuAnmcQ==', '15080136', '986bf1a2-19b3-46de-93bc-d4703efb652d', NULL, 0, 0, NULL, 0, 0, 'Admin');

-- --------------------------------------------------------

--
-- Estrutura da tabela `aspnetusertokens`
--

CREATE TABLE `aspnetusertokens` (
  `UserId` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `LoginProvider` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `Name` varchar(85) CHARACTER SET utf8mb4 NOT NULL,
  `Value` longtext CHARACTER SET utf8mb4
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Estrutura da tabela `cidade`
--

CREATE TABLE `cidade` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
  `UF` varchar(2) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `cidade`
--

INSERT INTO `cidade` (`Id`, `Nome`, `UF`) VALUES
(2, 'Barra Bonita', 'SP');

-- --------------------------------------------------------

--
-- Estrutura da tabela `estabelecimento`
--

CREATE TABLE `estabelecimento` (
  `Id` int(11) NOT NULL,
  `Descricao` varchar(1000) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Endereco` varchar(60) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Bairro` varchar(60) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Cep` varchar(8) CHARACTER SET utf8mb4 NOT NULL,
  `NumQuartos` int(11) NOT NULL,
  `NumBanheiros` int(11) NOT NULL,
  `Valor` decimal(65,30) NOT NULL,
  `TipoEstabelecimentoId` int(11) NOT NULL,
  `CidadeId` int(11) NOT NULL,
  `Foto` varchar(300) CHARACTER SET utf8mb4 DEFAULT NULL,
  `Metragem` int(11) NOT NULL DEFAULT '0',
  `Nome` varchar(100) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `estabelecimento`
--

INSERT INTO `estabelecimento` (`Id`, `Descricao`, `Endereco`, `Bairro`, `Cep`, `NumQuartos`, `NumBanheiros`, `Valor`, `TipoEstabelecimentoId`, `CidadeId`, `Foto`, `Metragem`, `Nome`) VALUES
(1, 'While there are countless Trips out there in charity shops and car boot sales, you can also buy refurbished examples, with replacement leatherette available in all colors. I love my Trip and use it regularly something so refreshing about its simplicity.', 'Rua dos Bobos, 0', 'Centro', '17340000', 2, 1, '100000.000000000000000000000000000000', 1, 2, '/images/estabelecimentos/bdf2ae3c-5227-4a1f-8ac1-723ea65189e6_69841167-ruins-wallpapers.jpg', 250, 'Bela Casa com 2 Quartos'),
(2, 'Teste', 'Rua X', 'Y', '17340000', 5, 2, '600000.000000000000000000000000000000', 1, 2, '/images/estabelecimentos/7b8445fb-52ea-4cef-bfdd-6e9244e8d35e_fantastic_ruins-wallpaper-1920x1080.jpg', 350, 'Mais uma casa');

-- --------------------------------------------------------

--
-- Estrutura da tabela `tipoestabelecimento`
--

CREATE TABLE `tipoestabelecimento` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(50) CHARACTER SET utf8mb4 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `tipoestabelecimento`
--

INSERT INTO `tipoestabelecimento` (`Id`, `Nome`) VALUES
(1, 'Casa'),
(2, 'Apartamento');

-- --------------------------------------------------------

--
-- Estrutura da tabela `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Extraindo dados da tabela `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20200504204719_ImobiliariaInicio', '3.1.2'),
('20200504204935_Imobiliaria2', '3.1.2'),
('20200511164547_fotoestabelecimento', '3.1.2'),
('20200518231502_metragem', '3.1.2'),
('20200519202822_usuarios', '3.1.4');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetRoleClaims_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetroles`
--
ALTER TABLE `aspnetroles`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `RoleNameIndex` (`NormalizedName`);

--
-- Indexes for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_AspNetUserClaims_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD PRIMARY KEY (`LoginProvider`,`ProviderKey`),
  ADD KEY `IX_AspNetUserLogins_UserId` (`UserId`);

--
-- Indexes for table `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD PRIMARY KEY (`UserId`,`RoleId`),
  ADD KEY `IX_AspNetUserRoles_RoleId` (`RoleId`);

--
-- Indexes for table `aspnetusers`
--
ALTER TABLE `aspnetusers`
  ADD PRIMARY KEY (`Id`),
  ADD UNIQUE KEY `UserNameIndex` (`NormalizedUserName`),
  ADD KEY `EmailIndex` (`NormalizedEmail`);

--
-- Indexes for table `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD PRIMARY KEY (`UserId`,`LoginProvider`,`Name`);

--
-- Indexes for table `cidade`
--
ALTER TABLE `cidade`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `estabelecimento`
--
ALTER TABLE `estabelecimento`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Estabelecimento_CidadeId` (`CidadeId`),
  ADD KEY `IX_Estabelecimento_TipoEstabelecimentoId` (`TipoEstabelecimentoId`);

--
-- Indexes for table `tipoestabelecimento`
--
ALTER TABLE `tipoestabelecimento`
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
-- AUTO_INCREMENT for table `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `cidade`
--
ALTER TABLE `cidade`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `estabelecimento`
--
ALTER TABLE `estabelecimento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tipoestabelecimento`
--
ALTER TABLE `tipoestabelecimento`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Constraints for dumped tables
--

--
-- Limitadores para a tabela `aspnetroleclaims`
--
ALTER TABLE `aspnetroleclaims`
  ADD CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserclaims`
--
ALTER TABLE `aspnetuserclaims`
  ADD CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserlogins`
--
ALTER TABLE `aspnetuserlogins`
  ADD CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetuserroles`
--
ALTER TABLE `aspnetuserroles`
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `aspnetroles` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `aspnetusertokens`
--
ALTER TABLE `aspnetusertokens`
  ADD CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `aspnetusers` (`Id`) ON DELETE CASCADE;

--
-- Limitadores para a tabela `estabelecimento`
--
ALTER TABLE `estabelecimento`
  ADD CONSTRAINT `FK_Estabelecimento_Cidade_CidadeId` FOREIGN KEY (`CidadeId`) REFERENCES `cidade` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Estabelecimento_TipoEstabelecimento_TipoEstabelecimentoId` FOREIGN KEY (`TipoEstabelecimentoId`) REFERENCES `tipoestabelecimento` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
