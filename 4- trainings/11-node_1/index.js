const express = require("express");
const bodyParser = require("body-parser");
const app = express();
app.use(bodyParser.urlencoded({extended: true}));
app.use("/public_node_modules/jquery", express.static(__dirname + "/node_modules/jquery", { index: '' }));
app.listen(3000, () => { 
    console.log('sever in 3000');
});
app.get("/", (req, res) => {
    res.sendFile(__dirname + "/index.html");
});
app.post('/', (req, res) => {
    let num1 = req.body.num1;
    let num2 = req.body.num2;
    let response = Number(num1) + Number(num2);
    res.send(response.toString());
})