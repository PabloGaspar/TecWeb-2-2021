import { square, diag } from './lib.js';
//IIFE
(function(){
  console.log(square(11)); // 121
  console.log(diag(4, 3)); // 5
})()
