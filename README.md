# Projekt na WSEI: Gra w statki
W ramach projektu na laboratoria z Programowania obiektowego postanowiliśmy stworzyć grę w statki z wykorzystaniem technologii WPF.

## Autorzy
1. Filip Kotelon - lider
2. Antoni Uranowski

## Dokumentacja

### Część logiczna:

* L_Komputer:  
Komputer losujący pola i sprawdzający swoje ruchy. Po wykonanym ruchu podejmuje decyzję odnośnie kolejnego strzału. Posiada trzy poziomy trudności:  
  - łatwy - komputer strzela losowo niezależnie od tego, czy trafi, czy nie.  
  - zaawansowany - komputer strzela losowo, a po trafieniu strzela dookoła trafionego pola w poszukiwaniu reszty statku, jeśli nie zatopił go jednym ruchem
  - trudny - podobnie jak na poziomie zaawansowanym, ale ma 20% szansy na trafienie prosto w statek gracza
  
* L_Gra:  
Instancja gra przechowująca dane o planszach graczy.

* L_KontrolerGry:  
Kontroler gry, obsługujący zmianę tury, sprawdzanie stanu gry po każdym ruchu oraz tworzenie nowych gier.

* L_Sedzia:  
Sędzia, wywoływany przez kontroler gry i sprawdzający, czy gra skończyła się po danym ruchu. Jeśli gra została zakończona, sędzia wyłania zwycięzcę.

* L_BudowniczyStatków:
Budowniczy wypełniający tablice dwuwymiarowe statkami w postaci pól zajętych.

* L_Pole:  
  * L_PolePuste - pole niezajęte przez statek. Po jego kliknięciu tura zostaje zmieniona.
  * L_PoleZajete - pole zajęte przez statek.
  
* L_Statek:  
  * L_Jednomasztowiec - statek z jednym polem.
  * L_Dwumasztowiec - statek z dwoma polami.
  * L_Trojasztowiec - statek z trzema polami.
  * L_Czteromasztowiec - statek z czterema polami.
  
* L_PlanszaBitwy:  
Klasa przechowująca dane o planszach graczy. Statki generowane przez budowniczego są przechowywane w tablicach dwuwymiarowych o wymiarach 10x10. Po odebraniu pól zajętych od budowniczego, reszta tablicy jest wypełniona polami pustymi.

### Część graficzna (prezentacja gry z ustaloną logicznie strukturą):

* G_Komputer:  
Komputer rywalizujący z graczem. Strzela w przyciski odpowiadające polom wylosowanym przez logiczny komputer.

* PlanszaBitwy:  
Klasa tworząca widok planszy na podstawie danych o układzie statków.

* KontrolaGry: 
Tutaj łączy się część logiczna gry z warstwą prezentacji. Na podstawie danych wygenerowanych przez logiczną część aplikacji zostaje przygotowany widok gry, tworzą się plansze gracza i komputera, kontroler gry zostaje podpięty do tworzenia nowej gry, wybierania poziomu trudności i kontrolowania stanu gry.
