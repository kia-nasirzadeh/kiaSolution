using "xhr" and "apache" and (not making form in html or javascript also not add payload manually to url):
1- send async get message with "name=hos" to the same index.php and 
1-1- log progress percents, get res in alert
1-2- log response-status and response-body
==> output should be: console.log=>1, console.log=>2, progress, res-body & res-status, console.log=>load ended
4- do above process in a sync way
==> output should be: 1, res-body & res-status, 2

for async project and in a proper readystate do 5,6,7,8:
5- log all responses headers as an array into console => then log "connection" header
6- do sth that you can't get progress percents afterwards

using "xhr" and "net cat":
7- send a get message which makes an error
8- send a get message which makes an error but don't wait for error about 5 fucking seconds