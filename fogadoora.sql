-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Feb 25. 20:28
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `fogadoora`
--
CREATE DATABASE IF NOT EXISTS `fogadoora` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `fogadoora`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `bejelentkezo`
--

DROP TABLE IF EXISTS `bejelentkezo`;
CREATE TABLE `bejelentkezo` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `Mobile` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `bejelentkezo`
--

INSERT INTO `bejelentkezo` (`Id`, `Name`, `Email`, `Mobile`) VALUES
(1, 'Kovács Péter', 'kovacs.peter@email.hu', '+36301234567'),
(2, 'Nagy Éva', 'nagy.eva@email.hu', '+36201234567'),
(3, 'Szabó Gábor', 'szabo.gabor@email.hu', '+36701234567'),
(4, 'Tóth Mária', 'toth.maria@email.hu', '+36309876543'),
(5, 'Varga István', 'varga.istvan@email.hu', '+36209876543'),
(6, 'Kiss László', 'kiss.laszlo@email.hu', '+36709876543'),
(7, 'Molnár Zoltán', 'molnar.zoltan@email.hu', '+36301112233'),
(8, 'Németh Andrea', 'nemeth.andrea@email.hu', '+36201112233'),
(9, 'Farkas Judit', 'farkas.judit@email.hu', '+36701112233'),
(10, 'Balogh Krisztián', 'balogh.krisztian@email.hu', '+36304445566'),
(11, 'Papp Zsolt', 'papp.zsolt@email.hu', '+36204445566'),
(12, 'Takács Katalin', 'takacs.katalin@email.hu', '+36704445566'),
(13, 'Juhász Róbert', 'juhasz.robert@email.hu', '+36307778899'),
(14, 'Lakatos Viktória', 'lakatos.viktoria@email.hu', '+36207778899'),
(15, 'Mészáros Csaba', 'meszaros.csaba@email.hu', '+36707778899'),
(16, 'Simon Eszter', 'simon.eszter@email.hu', '+36309990000'),
(17, 'Halász Tamás', 'halasz.tamas@email.hu', '+36209990000'),
(18, 'Orosz Dávid', 'orosz.david@email.hu', '+36709990000'),
(19, 'Fekete Anita', 'fekete.anita@email.hu', '+36302223344'),
(20, 'Szilágyi Gergő', 'szilagyi.gergo@email.hu', '+36202223344');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `fogadoora`
--

DROP TABLE IF EXISTS `fogadoora`;
CREATE TABLE `fogadoora` (
  `Id` int(11) NOT NULL,
  `Helyszin_Id` int(11) NOT NULL,
  `Bejelentkezo_Id` int(11) NOT NULL,
  `Start` datetime NOT NULL,
  `Lenght` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `fogadoora`
--

INSERT INTO `fogadoora` (`Id`, `Helyszin_Id`, `Bejelentkezo_Id`, `Start`, `Lenght`) VALUES
(1, 1, 1, '2026-03-02 08:00:00', 15),
(2, 1, 2, '2026-03-02 08:15:00', 15),
(3, 1, 3, '2026-03-02 08:30:00', 15),
(4, 1, 4, '2026-03-02 08:45:00', 15),
(5, 2, 5, '2026-03-02 09:00:00', 20),
(6, 2, 6, '2026-03-02 09:20:00', 20),
(7, 2, 7, '2026-03-02 09:40:00', 20),
(8, 2, 8, '2026-03-02 10:00:00', 20),
(9, 3, 9, '2026-03-03 14:00:00', 30),
(10, 3, 10, '2026-03-03 14:30:00', 30),
(11, 3, 11, '2026-03-03 15:00:00', 30),
(12, 3, 12, '2026-03-03 15:30:00', 30),
(13, 4, 13, '2026-03-04 10:00:00', 45),
(14, 4, 14, '2026-03-04 10:45:00', 45),
(15, 5, 15, '2026-03-04 13:00:00', 15),
(16, 5, 16, '2026-03-04 13:15:00', 15),
(17, 5, 17, '2026-03-04 13:30:00', 15),
(18, 5, 18, '2026-03-04 13:45:00', 15),
(19, 1, 19, '2026-03-05 16:00:00', 60),
(20, 2, 20, '2026-03-05 17:00:00', 60);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `helyszin`
--

DROP TABLE IF EXISTS `helyszin`;
CREATE TABLE `helyszin` (
  `Id` int(11) NOT NULL,
  `Name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `helyszin`
--

INSERT INTO `helyszin` (`Id`, `Name`) VALUES
(1, '101-es terem'),
(2, '102-es terem'),
(3, '201-es terem'),
(4, 'Igazgatói iroda'),
(5, 'Tanári szoba');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `bejelentkezo`
--
ALTER TABLE `bejelentkezo`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `fogadoora`
--
ALTER TABLE `fogadoora`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `fk_helyszin` (`Helyszin_Id`),
  ADD KEY `fk_bejelentkezo` (`Bejelentkezo_Id`);

--
-- A tábla indexei `helyszin`
--
ALTER TABLE `helyszin`
  ADD PRIMARY KEY (`Id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `bejelentkezo`
--
ALTER TABLE `bejelentkezo`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `fogadoora`
--
ALTER TABLE `fogadoora`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=21;

--
-- AUTO_INCREMENT a táblához `helyszin`
--
ALTER TABLE `helyszin`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `fogadoora`
--
ALTER TABLE `fogadoora`
  ADD CONSTRAINT `fk_bejelentkezo` FOREIGN KEY (`Bejelentkezo_Id`) REFERENCES `bejelentkezo` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_helyszin` FOREIGN KEY (`Helyszin_Id`) REFERENCES `helyszin` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
