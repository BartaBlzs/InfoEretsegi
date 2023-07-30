#70p

import math

lovesek = []
celX = 0.00
celY = 0.00


class JatekosLovese:
    def __init__(self, sor, sorszam):
        spl = sor.strip().split(";")
        self.nev = spl[0]
        self.x:float = float(spl[1].replace(",","."))
        self.y:float = float(spl[2].replace(",","."))
        self.sorszam = sorszam
        self.tav = self.Tavolsag()
        self.pont = round(10-self.tav, 2) if (10-self.tav) > 0 else 0

    def Tavolsag(self):
        dx = celX - self.x
        dy = celY - self.y
        return math.sqrt(pow(dx, 2) + pow(dy, 2))

    def __str__(self) -> str:
        return f"{self.nev} x={self.x} y={self.y} {self.sorszam} {self.tav}"

def feladat4():
    global celX, celY
    sorszam = 1
    f = open("lovesek.txt", "r", encoding="utf8").readlines()
    celX = float(f[0].split(";")[0].replace(",", "."))
    celY = float(f[0].split(";")[1].replace(",", "."))
    for i in range(1, len(f)):
        lovesek.append(JatekosLovese(f[i],sorszam))
        sorszam += 1

def feladat5():
    print(f"5. feladat: Lövések száma: {len(lovesek)} db")

def feladat7():
    maxx = lovesek[0]
    for i in lovesek:
        if i.tav < maxx.tav:
            maxx = i
    print("7. feladat: Legpontosabb lövés:")
    print(maxx)

def feladat9():
    nul = 0
    for i in lovesek:
        if i.pont == 0:
            nul += 1
    print(f"9. feladat: Nulla pontos Lövések száma: {nul} db")

def feladat10():
    jatekosok = set()
    for i in lovesek:
        jatekosok.add(i.nev)
    print(f"10. feladat: Játékosok száma: {len(jatekosok)}")

def feladat11():
    jatekosok = dict()

    print("11. feladat: Lövések száma:")
    for loves in lovesek:
        if jatekosok.__contains__(loves.nev):
            jatekosok[loves.nev] += 1
        else:
            jatekosok.update({ loves.nev : 1 })

    for i in jatekosok:
        print(f"{i} - {jatekosok[i]}")
        
def feladat12():
    s = set()
    d = dict()
    for i in lovesek:
        s.add(i.nev)
    
    for i in s:
        pont, db = 0, 0
        for loves in lovesek:
            if loves.nev == i:
                pont += loves.pont
                db += 1
        d.update({ i : pont/db })
    print("12. feladat: Átlagpontszámok")
    for i in d:
        print(f"{i} - {d[i]}")
    
    
    for i in d:
        max = d[i]
        break
    for i in d:
        if max < d[i]:
            max = d[i]
    for i in d:
        if max == d[i]:
            print(f"12. feladat: A játék nyertese: {i}")
        
        

def main():
    feladat4()
    feladat5()
    feladat7()
    feladat9()
    feladat10()
    feladat12()

if __name__ == "__main__":
    main()