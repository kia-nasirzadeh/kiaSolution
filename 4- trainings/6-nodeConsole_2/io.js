import chalk from 'chalk';
import ReadLine from 'readline';

class IO {
    rl;
    constructor () {
        this.rl = ReadLine.createInterface({
            input: process.stdin,
            output: process.stdout
        })
    }
    write (txt) {
        console.log(this.decorate(txt));
    }
    ask (question, callback) {
        this.rl.question(this.decorate(question), answer => callback(answer));
    }
    confirm (question, nCallback, yCallback) {
        question = chalk.cyanBright.bold(`${question} (Y/N)`);
        this.rl.question(question, answer => {
            if (answer == "n") nCallback()
            else yCallback()
        })
    }
    done () {
        this.rl.close();
    }
    decorate (txt) {
        txt = chalk.cyanBright.bold(txt);
        return txt;
    }
}
export default IO;