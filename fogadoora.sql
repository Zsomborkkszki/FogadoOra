-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Feb 26. 09:38
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
  `Start` datetime NOT NULL,
  `Lenght` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `fogadoora`
--

INSERT INTO `fogadoora` (`Id`, `Helyszin_Id`, `Start`, `Lenght`) VALUES
(1, 1, '2026-03-02 08:00:00', 45),
(2, 1, '2026-03-02 09:00:00', 45),
(3, 2, '2026-03-02 10:00:00', 60),
(4, 2, '2026-03-03 14:00:00', 60),
(5, 3, '2026-03-03 15:00:00', 30),
(6, 3, '2026-03-04 10:00:00', 30),
(7, 4, '2026-03-04 11:00:00', 45),
(8, 4, '2026-03-04 13:00:00', 45),
(9, 5, '2026-03-05 16:00:00', 60),
(10, 5, '2026-03-05 17:00:00', 60);

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

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jelentkezes`
--

DROP TABLE IF EXISTS `jelentkezes`;
CREATE TABLE `jelentkezes` (
  `Fogadoora_Id` int(11) NOT NULL,
  `Bejelentkezo_Id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `jelentkezes`
--

INSERT INTO `jelentkezes` (`Fogadoora_Id`, `Bejelentkezo_Id`) VALUES
(1, 1),
(1, 2),
(1, 3),
(2, 4),
(2, 5),
(3, 6),
(3, 7),
(4, 8),
(4, 9),
(4, 10),
(5, 11),
(6, 12),
(6, 13),
(7, 14),
(7, 15),
(8, 16),
(9, 17),
(9, 18),
(10, 19),
(10, 20);

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
  ADD KEY `fk_helyszin` (`Helyszin_Id`);

--
-- A tábla indexei `helyszin`
--
ALTER TABLE `helyszin`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `jelentkezes`
--
ALTER TABLE `jelentkezes`
  ADD PRIMARY KEY (`Fogadoora_Id`,`Bejelentkezo_Id`),
  ADD KEY `fk_jelentkezes_bejelentkezo` (`Bejelentkezo_Id`);

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
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

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
  ADD CONSTRAINT `fk_helyszin` FOREIGN KEY (`Helyszin_Id`) REFERENCES `helyszin` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `jelentkezes`
--
ALTER TABLE `jelentkezes`
  ADD CONSTRAINT `fk_jelentkezes_bejelentkezo` FOREIGN KEY (`Bejelentkezo_Id`) REFERENCES `bejelentkezo` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_jelentkezes_fogadoora` FOREIGN KEY (`Fogadoora_Id`) REFERENCES `fogadoora` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
