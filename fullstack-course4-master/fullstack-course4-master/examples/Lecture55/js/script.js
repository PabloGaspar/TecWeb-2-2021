
  function myFunction(thisParam, event) {
    document.getElementById("myDIV").className = "mystyle";
    debugger;
    console.log(thisParam);
    
  }


// Event handling
document.addEventListener("DOMContentLoaded", function (event) {


  function sayHello(event) {
    debugger;
    console.log(event);
    console.log(this);

    this.textContent = "Said it!";
    var name =
      document.getElementById("name").value;
    var message = "<h2>Hello " + name + "!</h2>";

    document
      .getElementById("content")
      .innerHTML = message;

    if (name === "student") {
      var title =
        document
          .querySelector("#title")
          .textContent;
      title += " & Lovin' it!";
      document
        .querySelector("h1")
        .textContent = title;
    }
  }



  // Unobtrusive event binding
  /*document.querySelector("#classButton")
    .addEventListener("click", myFunction);*/

    document.querySelector("#sayIt")
    .addEventListener("click", sayHello);

  document.querySelector("body").addEventListener("mousemove", function (event) {
    if (event.shiftKey === true) {
          console.log("x: " + event.clientX);
          console.log("y: " + event.clientY);
        }
    });
 

});








