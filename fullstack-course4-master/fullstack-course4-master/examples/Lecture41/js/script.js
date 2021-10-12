var message = "in global";

var a = function () {
  var message = "inside a";
  b();
}

function b() {
  var messageInsideB = "im in B";
  console.log("b: message = " + message);
}

a();