const fs = require('fs');
// 01, 02, 03, 04, 05
function fileExists (path) {
    try {
        fs.statSync(path);
        return true;
    } catch (error) {
        return false;
    }
}
let contractPath = './contract.txt';
if (!fileExists(contractPath)) {
    fs.writeFileSync(contractPath, '');
    fs.writeFileSync(contractPath, 'this is con:');
    fs.appendFileSync(contractPath, '\n1- cond1\n2- cond2\n3- cond3');
    let contractContent = fs.readFileSync(contractPath, {encoding: 'utf-8'});
    console.log(contractContent);
    fs.unlinkSync(contractPath);
}
// 06, 07, 08
let pi1_path = './personal_information.json';
if (!fileExists(pi1_path)) {
    fs.writeFileSync(pi1_path, '{ "name": "kia", "family": "nsx" }');
    const pi1 = require(pi1_path);
    console.log(pi1.name);
}
// 09, 10, 11, 12
let pi2_path = './pi2.json';
fs.writeFile(pi2_path, '{"name":"ava", "family":"shojai"}', afterPi2Wrote);
function afterPi2Wrote (err) {
    if (err) {
        console.log(err);
        return false;
    }
    fs.readFile(pi2_path, {encoding:'utf-8'}, afterPi2Red);
}
function afterPi2Red (err, data) {
    if (err) {
        console.log(err);
        return false;
    }
    let pi2 = JSON.parse(data);
    let pi2New = JSON.parse(JSON.stringify(pi2));
    pi2New.family = 'shojaiBakhtiari';
    console.log('old-new', `${pi2.family}-${pi2New.family}`);
}
