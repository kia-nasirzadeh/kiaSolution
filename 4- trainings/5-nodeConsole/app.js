import chalk from 'chalk';
import boxen from 'boxen';

class App {
    static errors = []
    static startApp (args, yargsObj) {
        if (this.errors.length != 0) {
            this.handleErrors();
            return;
        }
        if (args.name == undefined) this.showErrorOnNameLack(yargsObj);
        else this.startApp_nameIsReady(args, yargsObj);
    }
    static addUnknownError () {
        this.errors.push("there is an unknown argument, we cant run app");
    }
    static handleErrors () {
        this.errors.forEach(err => {
            err = chalk.redBright.bold(err);
            console.log(err);
        })
    }
    static showErrorOnNameLack (yargsObj) {
        let errorLine_1 = chalk.redBright.bold('you didn\'t provide a name, it is required' );
        let errorLine_2 = chalk.cyanBright.bold('you can read help');
        console.log(errorLine_1);
        console.log(errorLine_2);
        yargsObj.showHelp()
    }
    static startApp_nameIsReady(args, yargsObj) {
        let message = chalk.cyanBright.bold(`hello ${args.name}`);
        if (args.b) {
            message = boxen(message, {
                padding: 2,
                margin: 2,
                borderColor: 'red',
                borderStyle: 'round'
            })
        }
        console.log(message);
    }
}
export default App;