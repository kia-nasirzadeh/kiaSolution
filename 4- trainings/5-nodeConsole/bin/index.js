#!/usr/bin/env node
import yargs from 'yargs/yargs';
import { hideBin } from 'yargs/helpers';
import App from '../app.js';

let yargsObj = yargs(hideBin(process.argv));
yargsObj
.usage('Usage: say hello to someone')
.version(false)
.option('version', {
    alias: 'v'
})
.option('help', {
    alias: 'h'
})
.command({
    command: '$0 <name>',
    handler: (args) => {
        App.startApp(args, yargsObj);
    }
})
.demandOption(['name'])
.positional('name', {
    type: 'string',
    alias: 'n'
})
.option('box', {
    alias: 'b',
    describe: 'round with a red box'
})
.strict()
.fail(() => {
    
})
.fail((msg) => {
    msg = msg.slice(0, 16);
    if (msg == "Unknown argument") App.addUnknownError();
})
.argv;