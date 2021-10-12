var arr = [];

arr.push("name");
arr.push("lastname");

arr.version = 12;

for (const iterator of arr) {
  console.log(iterator);
}

// Functions are First-Class Data Types
// Functions ARE objects
function multiply(x, y) {
  return x * y;
}

multiply.version = "v.1.0.0";
console.log(multiply.version);


// Function factory
function makeMultiplier(multiplier) {
  
  var myFunc = function (x) {
    return multiplier * x;
  };

  return myFunc;
}

debugger;

var multiplyBy3 = makeMultiplier(3);


var result = multiplyBy3(6);

console.log("result of multiplyBy3:" + result);


var doubleAll = makeMultiplier(2);
console.log(doubleAll(100));



// Passing functions as arguments callback
function doOperationOn(x, operation) {
  return operation(x);
}

var result = doOperationOn(5, multiplyBy3);
console.log(result);
result = doOperationOn(100, doubleAll);
console.log(result);