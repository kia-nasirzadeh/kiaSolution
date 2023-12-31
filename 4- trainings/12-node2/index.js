const express = require('express');
const https = require("https");
let catFactsAPI = "https://jsonplaceholder.typicode.com/todos/1";

const app = express();
app.listen(3000, () => { console.log('expressWebServer <==connection==> localhost:3000');});
app.get('/', (req, res) => {
    try {
        https.get(catFactsAPI, (catAPIRes) => {
            catAPIRes.on('data', data => {
                const catData = JSON.parse(data);
                res.send('here is res: <br>' + catData.title);
            })
        })
    } catch (err) {
        console.log('we have errr');
    }
})