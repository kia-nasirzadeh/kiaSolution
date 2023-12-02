import chalk from 'chalk';
import ReadLine from 'node:readline';

class IO {
    rl;
    constructor () {
        this.rl = ReadLine.createInterface({
            input: process.stdin,
            output: process.stdout
        })
    }
    decorate (txt) {
        return chalk.cyanBright.bold(txt);
    }
    write (txt) {
        console.log(this.decorate(txt));
    }
    writeErr (txt) {
        console.log(chalk.redBright.bold(txt));
    }
    ask (question, answerCallback) {
        this.rl.question(this.decorate(question), answer => {
            answerCallback(answer);
        })
    }
    askSync (question, answerCallback) {
        question = chalk.cyanBright.bold(`${question} (Y/N)`);
        return new Promise((resolve, reject) => {
            this.rl.question(question, (answer) => {
                answerCallback(resolve, answer);
            })
        })
    }
    confirm (question, yCallback, nCallback) {
        question = chalk.cyanBright.bold(`${question} (Y/N)`);
        this.rl.question(question, (answer) => {
            if (answer == 'n') nCallback();
            else yCallback();
        });
    }
    confirmSync (question, yCallback, nCallback) {
        question = chalk.cyanBright.bold(`${question} (Y/N)`);
        return new Promise(resolve => {
            this.rl.question(question, (answer) => {
                if (answer == 'n') nCallback(resolve);
                else yCallback(resolve);
            });
        })
    }
    done () {
        this.rl.close();
    }
}
export default IO;