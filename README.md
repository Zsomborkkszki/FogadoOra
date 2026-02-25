Fogadóóra Bejelentkező Rendszer
Ez egy egyszerű, PHP és MySQL alapú webes alkalmazás, amely lehetővé teszi fogadóórák meghirdetését és a rajtuk való részvétel (bejelentkezők) adminisztrációját. A rendszert úgy terveztük, hogy egy adott személy (pl. tanár) fogadóóráit kezelje.

  Alapvető funkciók
A rendszer két fő entitást kezel: Bejelentkezők és Fogadóórák.

Lekérdezések és listázások:

  -Az összes rögzített bejelentkező adatainak listázása.

  -Egy konkrét bejelentkező részletes adatainak megjelenítése.

  -Az összes rögzített fogadóóra listázása.

  -Egy adott napra meghirdetett fogadóórák szűrése és megjelenítése.

  -Egy konkrét fogadóóra adatainak megtekintése.

Adatkezelés (CRUD műveletek):

  -Bejelentkezők: Új bejelentkező felvitele, meglévő adatainak módosítása, törlése.

  -Fogadóórák: Új időpont felvitele, módosítása, törlése. (Fontos szabály: fogadóórát csak már létező bejelentkezőhöz lehet hozzárendelni.)

  Rendszerkövetelmények
  
  -Webszerver: Apache / Nginx (pl. XAMPP, WAMP, vagy MAMP környezetben)

  -Adatbázis: MySQL / MariaDB (pl. 10.4.32-MariaDB)

  Telepítés és Beüzemelés
  
1. Fájlok másolása:
   
Másold be a projekt mappáját a webszervered gyökérkönyvtárába (XAMPP esetén ez a htdocs mappa).

3. Adatbázis létrehozása:

Nyisd meg a phpMyAdmin felületét (általában http://localhost/phpmyadmin).

Hozz létre egy új adatbázist fogadoora néven, utf8mb4_hungarian_ci illesztéssel.

3. Táblák és tesztadatok importálása:

A phpMyAdminban válaszd ki a fogadoora adatbázist.

Kattints az Importálás fülre, és töltsd fel a projektben található fogadoora.sql fájlt.

Megjegyzés: Az eredeti SQL sémában a Lenght oszlop TIMESTAMP-ről INT-re lett módosítva a percek helyes tárolása érdekében.

4. Adatbázis kapcsolat beállítása:
Nyisd meg az adatbázis-kapcsolatért felelős PHP fájlt (pl. db.php vagy config.php), és ellenőrizd a hozzáférési adatokat:

Adatbázis

host = "localhost";

dbname = "fogadoora";

username = "root";

password = "";  

  Adatbázis szerkezet
fogadoora tábla: * Id (INT, Primary Key)

  -Place (VARCHAR, Helyszín)

  -Start (DATETIME, Fogadóóra kezdete)

  -Lenght (INT, Fogadóóra hossza percben)

bejelentkezo tábla:

  -Id (INT, Primary Key, Foreign Key a fogadoora táblához)

  -Name (VARCHAR, Név)

  -Email (VARCHAR, E-mail cím)

  -Mobile (VARCHAR, Telefonszám)
  
  [Fogadóóra.docx](https://github.com/user-attachments/files/25554977/Fogadoora.docx)
