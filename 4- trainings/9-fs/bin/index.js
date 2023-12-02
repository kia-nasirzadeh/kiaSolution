#!/usr/bin/env node
import IO from './../io.js';
import fs from 'fs';

const io = new IO();
io.write('hello');
fs.writeFileSync('./contract.txt', '');
await io.confirmSync('----01-we\'ve built contract.txt, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----01-');
    res();
})

fs.writeFileSync('./contract.txt', 'this is a contract');
await io.confirmSync('----02-we\'ve added this is a contract to it, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----02-');
    res();
})

fs.appendFileSync('./contract.txt', "\r\n1-cond1\r\n2-cond2\r\n3-cond3");
await io.confirmSync('----03-we\'ve add three conditions, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----03-');
    res();
})

let contractData = fs.readFileSync('./contract.txt', { encoding: 'utf-8' });
console.log(contractData);
await io.confirmSync('----04-we\'ve log it for you, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----04-');
    res();
})

fs.unlinkSync('./contract.txt')
await io.confirmSync('----04-we\'ve deleted contract.txt, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----04-');
    res();
})

fs.writeFileSync('./pi.json', '{"name":"kia", "family":"nsx"}');
await io.confirmSync('----05-we\'ve built pi.json, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----05-');
    res();
})

import pi from './../pi.json' assert { type: "json" };
console.log(pi.name);
await io.confirmSync('----05-we\'ve logged "kia" in top, did you saw it?', (res) => {
    io.write('okay, we\'re going to next step');
    res();
}, (res) => {
    io.writeErr('we have a problem in ----05-');
    res();
})

