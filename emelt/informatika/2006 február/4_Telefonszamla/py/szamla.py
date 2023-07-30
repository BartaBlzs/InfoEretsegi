#63p

import math

hivasokList = []

class hivas():
    def __init__(self, sh, sm, ss, eh, em, es, tel):
        self.sh = sh
        self.sm = sm
        self.ss = ss
        self.eh = eh
        self.em = em
        self.es = es
        self.tel = tel

def beolvas():
    f = open("HIVASOK.TXT", "r").readlines()
    for i in range(0, len(f), 2):
        spl = f[i].strip().split(" ")+f[i+1].strip().split(" ")
        hivasokList.append(hivas(spl[0], spl[1], spl[2], spl[3], spl[4], spl[5], spl[6]))

def feladat1():
    inp = input("Kérek egy telefonszámot: ")
    if inp[0:2] == "39" or inp[0:2] == "41"  or inp[0:2] == "71":
        print("A megadott telefonszám mobilnak felel meg.")
    else:
        print("A megadott telefonszám nem mobilnak felel meg.")

def feladat2():
    inp = input("Kérek egy hívás kezdeti és hívás vége időpontot (óra perc másodperc): ")
    spl = inp.split(" ")

    startTime = int(spl[0])*60+int(spl[1])+math.ceil(int(spl[2])/60)
    endTime = int(spl[3])*60+int(spl[4])+math.ceil(int(spl[5])/60)

    print(f"A számlázás szempontjából {endTime-startTime} perces a beszélgetés!")

def feladat3():
    d = dict()
    for i in hivasokList:
        ido = 0
        for j in hivasokList:
            if i.tel == j.tel:
                startTime = int(i.sh)*60+int(i.sm)+math.ceil(int(i.ss)/60)
                endTime = int(i.eh)*60+int(i.em)+math.ceil(int(i.es)/60)
                ido+= endTime-startTime
        d.update({i.tel : ido})
    conc = ""
    for i in d:
        conc += str(d[i])+ " " + i + "\n"

    open("percek.txt", "w").writelines(conc)

def feladat4():
    csucs, nemcsucs = 0, 0
    print(len(hivasokList))
    for i in hivasokList:
        if int(i.sh) >= 7 and int(i.sh) <= 17:
            csucs += 1
        else:
            nemcsucs += 1
    print(f"Hívások csúcsidőben: {csucs}")
    print(f"Hívások csúcsidőn kívül: {nemcsucs}")

def feladat5():
    mobil = 0
    vez = 0
    for i in hivasokList:
        if i.tel[0:2] == "39" or i.tel[0:2] == "41"  or i.tel[0:2] == "71":
            startTime = int(i.sh)*60+int(i.sm)+math.ceil(int(i.ss)/60)
            endTime = int(i.eh)*60+int(i.em)+math.ceil(int(i.es)/60)
            mobil += endTime-startTime
        else:
            startTime = int(i.sh)*60+int(i.sm)+math.ceil(int(i.ss)/60)
            endTime = int(i.eh)*60+int(i.em)+math.ceil(int(i.es)/60)
            vez += endTime-startTime

    print(f"A hívások ideje mobilon: {mobil}")
    print(f"A hívások ideje vezetékes telefonon: {vez}")

def feladat6():
    penz = 0
    for i in hivasokList:
        if int(i.sh) >= 7 and int(i.sh) <= 17:
            startTime = int(i.sh)*60+int(i.sm)+math.ceil(int(i.ss)/60)
            endTime = int(i.eh)*60+int(i.em)+math.ceil(int(i.es)/60)
            if i.tel[0:2] == "39" or i.tel[0:2] == "41"  or i.tel[0:2] == "71":
                penz += (endTime-startTime)*69.175
            else:
                penz += (endTime-startTime)*30

    print(f"Hívások díja csúcsidőben: {penz}")

def main():
    beolvas()
    feladat1()
    feladat2()
    feladat3()
    feladat4()
    feladat5()
    feladat6()

if __name__ == "__main__":
    main()