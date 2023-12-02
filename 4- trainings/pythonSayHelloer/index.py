p1 = input('person1 name:')
p1_age = input('person1 age:')
p2 = input('person2 name:')
p2_age = input('person2 age:')

def castToInt(var):
    try:
        var = int(var)
    except:
        print('var should be intiger')
        
castToInt(p1_age)
castToInt(p2_age)

if p1_age > p2_age:
    print(p1, 'is older than ', p2)
elif p1_age < p2_age:
    print(p1, ' is younger than ', p2)
else:
    print(p1, ' and ', p2, ' have same age')

# this app still needs much to be as desired as it should be
# we should continue the current video on python
# we then should add the this to exercises on flashCard app
