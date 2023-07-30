#56 p

def bubbleSort(arr):
    for i in range(len(arr)):
        for j in range(0, len(arr)-i-1):
            if arr[j] > arr[j+1]:
                arr[j], arr[j+1] = arr[j+1], arr[j]

fiftytwo = []

def feladat1():
    inp = input("Kérem az 52. hét lottószámait: ")

    for i in inp.split(" "):
        fiftytwo.append(i)
    bubbleSort(fiftytwo)
    print("1. feladat\nAz 52.hét lottószámai: ", end="")
    for i in fiftytwo:
        print(i, end=" ")
    print()

szam = 0
def feladat3():
    print("3. feladat")
    global szam
    szam = int(input("Kérek egy számot 1-51 között: "))
    
f = open("lottosz.dat", "r").readlines()
def feladat4():
    print("4. feladat")
    print(f[szam-1])

szamokLista = []
def feladat5():
    print("5. feladat")

    for i in range(1, 91):
        szamokLista.append(str(i))
        
    for line in f:
        for num in line.strip().split(" "):
            if szamokLista.__contains__(num):
                szamokLista.remove(num)

    print(f"Volt-e olyan szám, amit egyszer sem húztak ki az 51 hét alatt? ", end="")
    if(len(szamokLista) > 0):
        print("Van")
    else:
        print("Nincs")

def feladat6():
    print("6. feladat")

    odd = 0
    for line in f:
        for num in line.strip().split(" "):
            if int(num)%2 == 1:
                odd += 1
    print(f"A páratlan számú húzások száma: {odd}")

def feladat7():
    print("7. feladat")

    f.append("\n"+" ".join(fiftytwo))
    open("lotto52.ki", "w").writelines(f)

def feladat8():
    print("8. feladat")

    ki = open("lotto52.ki", "r").readlines()
    for i in range(1, 91):
        db = 0
        for line in ki:
            for s in line.strip().split(" "):
                if int(s) == i:
                    db += 1
        if (i-1)%15==0:
            print()
        print(db, end=" ")
    print()

def feladat9():
    print("9. feladat")

    primek = [2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89]
    print("A következő prímszámokat nem húzták ki az elmúlt évben: ", end="")
    for i in szamokLista:
        if primek.__contains__(int(i)):
            print(i, end=" ")


def main():
    feladat1()
    feladat3()
    feladat4()
    feladat5()
    feladat6()
    feladat7()
    feladat8()
    feladat9()

if __name__ == "__main__":
    main()