#!/usr/bin/env node

import chalk from "chalk";
import boxen from "boxen";
import yargs from "yargs/yargs";
import { hideBin } from "yargs/helpers";

const argv = yargs(hideBin(process.argv))
.usage('Usage: hello [option]')
.alias('name', 'n')
.describe('set the name to hello to')
.alias('box','b')
.describe('box', 'round around with box')
.demandOption(['name'])
.argv;

const greeting = chalk.white.bold(`hello ${argv.name}`);
const boxenOpts = {
    padding: 1,
    margin: 1,
    borderStyle: 'round',
    borderColor: 'green'
};

let finalMsg;
if (argv.box) finalMsg = boxen(greeting, boxenOpts);
else finalMsg = greeting;

console.log(finalMsg);