import { plus as jam, tafrigh, pi, plus } from './mathmodule.js';
import operation from './mathmodule.js';
console.log("plus", plus(2,1));
console.log("minus", tafrigh(2,1));
console.log("pi", pi);
console.log("op-plus", operation('plus', 2, 1));
console.log("op-minus", operation('minus', 2, 1));