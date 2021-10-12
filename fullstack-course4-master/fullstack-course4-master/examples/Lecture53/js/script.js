// DOM manipulation
// console.log(document.getElementById("title"));
// console.log(document instanceof HTMLDocument);
// var p = document.querySelector(".divClass p");
//var ps = document.querySelectorAll(".divClass p");


function sayHello (eventName, otherValue) {
  debugger;
  var name = document.getElementById("name").value;
  var message = `<h1>Hello ${name}</h1>`;

  // document
  //   .getElementById("content")
  //   .textContent = message;

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
