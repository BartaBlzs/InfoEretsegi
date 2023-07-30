#55p

szoveg = ""
key = ""
s = ""

def feladat1():
    global szoveg
    print("1. feladat")
    while(True):
        inp = input("Kérek egy maximum 255 karakternyi, nem üres szöveget: ")
        if len(inp) <= 255 and len(inp) > 0:
            szoveg = inp
            break
        else:
            print("A beírt szöveg nem felel meg a feltételeknek.")

def feladat2():
    global szoveg
    szoveg = szoveg.replace("á", "a").replace("é", "e").replace("ű", "u").replace("ü", "u").replace("ő", "o").replace("ö", "o").replace("í", "i").replace("ó", "o").replace(" ", "").replace("!","").replace(",", "")
    if szoveg.isalpha():
        szoveg = szoveg.upper()

def feladat3():
    print("3. feladat")
    print("Szöveg átalakítása:",szoveg)

def feladat4():
    global key
    print("4. feladat")
    key = input("Kérek egy maximum 5 karakternyi, nem üres kulcsszót: ").upper()

def feladat5():
    print("5. feladat")
    global s
    j = 0
    for i in range(len(szoveg)):
        s += key[j]
        if j == len(key)-1:
            j = 0
        else:
            j += 1
    print("A kulcsszó:",s)

def feladat6():
    print("6. feladat")
    global s, szoveg
    lines = open("Vtabla.dat", "r").readlines()
    coded = ""

    for j in range(len(szoveg)):
        col = 0
        row = 0
        for i in range(len(lines)):
            if szoveg[j] == lines[i][0]:
                col = i
        for i in range(len(lines[0])):
            if s[j] == lines[0][i]:
                row = i
        coded += lines[row][col]
    print(coded)

def main():
    feladat1()
    feladat2()
    feladat3()
    feladat4()
    feladat5()
    feladat6()

if __name__ == "__main__":
    main()