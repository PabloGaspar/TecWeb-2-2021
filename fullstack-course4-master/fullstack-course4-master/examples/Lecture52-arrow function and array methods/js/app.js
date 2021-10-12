

//------------------------ARROW FUNCTIONS ---------------------------------------
var plusOneHundred = function (a){
  return a + 100;
}

// Desglose de la función flecha

// 1. Elimina la palabra "function" y coloca la flecha entre el argumento y el corchete de apertura.
var arrowFnHundred = (a) => {
  a++;
  return a + 100;
}

// 2. Quita los corchetes del cuerpo y la palabra "return" — el return está implícito.
(a) => a + 100;

// 3. Suprime los paréntesis de los argumentos
a => a + 100;


var name = "Global Pepito";

var showNameInGlobal =  ()=>{
  console.log(this.name);
}

var obj = {
  name: "pepito",
  showName: showNameInGlobal
};

obj.showName();


//--------------------------ARRAY METHODS -----------------------------------------

const items = [
  {name: "Bike", price:100},
  {name: "TV", price:50},
  {name: "PC", price:500},
  {name: "Book", price:15},
  {name: "Camera", price:48},
  {name: "Pants", price:23}
];

//const filteredItems = items.filter( (e) => {return e.price < 100});
const filteredItems = items.filter( e => e.price < 100);
console.log(filteredItems);



const prices = items.map(item => {return `The price is ${item.price}`});
console.log(prices);

debugger;
const camera = items.find(i => i.name === "Cameraasss" );
console.log(camera);


items.forEach((item)=>{
  console.log(item);
});


var anyMoreThan600 = items.some( i => i.price > 600);

var everyMoreThan50 = items.every( i => i.price > 50);


const total = items.reduce((currentTotal, item) => {
  return item.price + currentTotal;
}, 0);

