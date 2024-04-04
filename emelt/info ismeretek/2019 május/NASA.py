#29 perc 54 másodperc Personal Record :P

keresek = []

class Keres:
    def __init__(self, cim, ido, get, kod, meret):
        self.cim = cim
        self.ido = ido
        self.get = get
        self.kod = kod
        self.meret = meret
        self.ByteMeret = int(self.meret) if self.meret != "-" else 0
        self.Domain = False if self.cim[len(self.cim)-1].isnumeric() else True
    
    def __str__(self):
        return f"{self.cim} {self.ido} {self.get} {self.kod} {self.meret}"

def feladat4():
    f = open("NASAlog.txt", "r").readlines()

    for line in f:
        spl = line.strip().split("*")
        keresek.append(Keres(spl[0], spl[1], spl[2], spl[3].split(" ")[0], spl[3].split(" ")[1]))

def feladat5():
    print(f"5. feladat: Kérések száma: {len(keresek)}")

def feladat6():
    osszbyte = 0
    for keres in keresek:
        osszbyte += keres.ByteMeret

    print(f"6. feladat: Válaszok összes mérete: {osszbyte} byte")

def feladat8():
    dom = 0
    for keres in keresek:
        if keres.Domain:
            dom += 1
    print(f"8. Feladat: Domain-es kérések: {round(dom/len(keresek)*100, 2)}%")

def feladat9():
    kodok = set()

    for keres in keresek:
        kodok.add(keres.kod)

    print("9. feladat: Statisztika:")

    for kod in kodok:
        szamlalo = 0
        for keres in keresek:
            if keres.kod == kod:
                szamlalo += 1
        print(f"{kod}: {szamlalo} db")

    d = dict()

#alternatív megoldás:
"""    for keres in keresek:
        if d.__contains__(keres.kod):
            d[keres.kod] += 1
        else:
            d.update({ keres.kod : 1})

    for i in d:
        print(i, d[i])
"""
def main():
    feladat4()
    feladat5()
    feladat6()
    feladat8()
    feladat9()

if __name__ == "__main__":
    main()