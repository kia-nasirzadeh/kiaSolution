نام +=
کیا +=

&json
var car1 = {
    carName: "c200-2014",
    explanation: "good car"
};

given the above information, we want to send a post request in following strategies:
all strategies must have:
• a body like this, which can be confirmed using netcat:
%D9%86%D8%A7%D9%85+%2B%3D=%DA%A9%DB%8C%D8%A7+%2B%3D&%26json=%7B%22carName%22%3A%22c200-2014%22%2C%22explanation%22%3A%22good+car%22%7D
• php should get carName which can be confirmed using php to display carName on screen
• php should get نام += which can be confirmed using php to display نام += on screen
•••you don't need to handle response in this exercise, so just confirm a healthy response on server, and it's okay, sync or asyn doesn't matter, but for consistency do it using async method

::st1 up to st5::urlencoded::
st1- using by building a form in html then submit it in the same html (not using formdata)
st2- not use formdata neighter make an html form in javascript, just send a raw xhr (make string to send manually)
st3- using by building a form in html, then use javascript to send that form with formdata and xhr
st4- using by not building a form in html but just using formdata and xhr
st5- serialize html form and send with jquery, also use jquery success and fail callbacks 

::st6 up to st10::multipart/form-data::
Note: do not really upload images and update database! just see thos in $_FILES and $_POST...
6- add me.jpg & me2.jpg pic too, building a form in html then submit it to the same html using sub button (not using formdata), after selecting pics,show selected items name
7- add just me.jpg pic, make a formdata and send it using xhr
8- add me.jpg & me2.jpg pic too, copy startegy 7 project but this time for multiple images
9- add just me.jpg pic too, send a constructed formdata with jquery

#### important todo: xhr.upload.onprogress, put a train to monitor upload process, currently we are just monitoring download progress