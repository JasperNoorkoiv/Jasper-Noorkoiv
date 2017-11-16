#Harjutus 1

#a = int(input("Sisestage arv: "))
#b = int(input("Sisestage arv: "))

#for i in range(a,b+1):
#    if i % 2 == 0:
#        print(i)

#Harjutus 2

#count = 0
#x = 5

#filename = open("kttekst.txt", "r")
#f = open("uusfail.txt", "w+")
#for lines in file:
#    word = lines.split()
#    if len(word) > 5:
#        f.write(str(word))     
#    count += len(word)
#    lahuta = word.count("—") # MS Wordis on 1289 sõna, python loeb "—" kui sõna.
#    count = count - lahuta

#print("Sõnu on: " + str(count))

#file.close()
#file.close()

#Harjutus 3

a = [11, 15, 6, 13, 13, 25, 32, 11, 20, 5, 31, 16, 32, 29, 11, 13, 3, 29, 28, 24]
b = [5, 19, 16, 4, 12, 7, 2, 28, 34, 29, 29, 36, 6, 8, 24, 18, 31, 7, 1, 7]

for i in a:
     if b.__contains__(i):
         print("Ühised elemendid on:")
         print(i)
print("Max value element : ", max(a))
print("Max value element : ", max(b))
print("Min value element : ", min(a))
print("Min value element : ", min(b))
print("Mõlema listi keskmimsed on")
i = 0
total = 0.0
while(i < len(a)):
    total = total + a[i]
    i = i+1
print(total/len(a))
i = 0
total = 0.0
while(i < len(b)):
    total = total + b[i]
    i = i+1
print(total/len(b))