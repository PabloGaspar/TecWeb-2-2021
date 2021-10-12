(function (window) {
  var yaakovGreeter = {};
  yaakovGreeter.name = "Yaakov";

  var greeting = "Hello ";
  //closure
  yaakovGreeter.sayHello = function () {
    console.log(greeting + yaakovGreeter.name);
  }

  window.yaakovGreeter = yaakovGreeter;

})(window);
