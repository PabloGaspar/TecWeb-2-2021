// Closures
function makeMultiplier (multiplier) {
  // var multiplier = 2;
  function b() {
    console.log("Multiplier is: " + multiplier);
  }
  b();
  

  var multiply = function (x) {
    return multiplier * x;
  }

  return multiply;
}

var doubleAll = makeMultiplier(2);
console.log(doubleAll(10)); // its own exec env