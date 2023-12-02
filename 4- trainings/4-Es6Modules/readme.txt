1- make two modules: index, mathmodule

2- in mathmodule build these functions and variables:
2-1- plus(a,b)
2-2- minus(a,b)
2-3- const pi
2-4- op(op, a, b)

3- in mathmodule :
• export plus and pi as named module
• export minus as tafrigh as named module
• export op as default

4- in index :
• import plus as jam
• import tafrigh
• import pi
• import op as operation

5- make an html page and add index script to it
5-1- then open all console.logs on chrome dev-console