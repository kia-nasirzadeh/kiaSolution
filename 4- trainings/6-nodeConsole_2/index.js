#!/usr/bin/env node
import ioClass from './io.js';

const io = new ioClass();
io.write('hello');
io.confirm('are you ready to start?', ()=>{
    io.write('bad news, bye');
    io.done();
}, ()=>{
    io.ask('what is your name?', name => {
        io.write(`fuck you ${name}`);
        io.done();
    })
})