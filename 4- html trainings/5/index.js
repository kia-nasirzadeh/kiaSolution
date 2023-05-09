const fs = require('fs');
console.log('before building');

function buildATxt () {
    return new Promise ((resolve, reject) => {
        fs.writeFile('./a.txt', '', (err) => {
            if (err) {
                console.log(err);
                reject(err);
            }
            console.log("inCallBack");
            return resolve();
        });
    });
};
// async function bat () {
//     return await buildATxt().then(() => { return "ali" });
// }

// let bat = (async () => { await buildATxt() })();
// console.log(bat);

(async () => {
    try {
        let a = await buildATxt();
        // console.log(a);
    //   console.log(value); // 👉️ "bobbyhadz.com"
    } catch (err) {
      console.log(err);
    }
})();

  
// function after_aTxt_callback (err) {
//     if (err) {
//         console.log(err);
//         return false;
//     }
//     return resolve()
// }
// console.log(bat());

console.log('a.txt built');