/*---------------------- OLD WAY --------------------------------*/
// Function constructors 
/*function Circle (radius) {
  this.radius = radius;
}

Circle.prototype.getArea = 
  function () {
    console.log(`radio: ${this.radius}`)
    return Math.PI * Math.pow(this.radius, 2);
  };


var myCircle = new Circle(10);
console.log(myCircle.getArea());

var myOtherCircle = new Circle(20);
console.log(myOtherCircle.getArea());*/

/*------------------------ NEW WAY --------------------------------*/


class Car {
  
  constructor(name, model, date) {
    this.name = name;
    this.model  = model;
    this.date = date;
  }

  get nameFormated(){
    return `SUPERNAME: ${this.name}`; 
  }

  calculateAge() {
    return  new Date().getFullYear() - this.date.getFullYear();
  }

  showPrettyModel(prefix){
    console.log(`${prefix}-${this.model}`);
  }

  setName(newName)  {
    this.name = newName
  }

  static startEngine(){
    console.log("BRRRRRRRR");
  }
}

debugger; 
let myCar = new Car("Ford", "4x4", new Date(1995,11,17));
console.log(myCar.calculateAge());
myCar.showPrettyModel("MODEL:");

myCar.nameFormated;

Car.startEngine();


class Truck extends Car{
  constructor(name, model, date, wheelsNumber){
      super(name, model,date);
      this.wheels = wheelsNumber;
  }

  showPrettyModel(prefix){
    super.showPrettyModel();
    console.log(`and I have ${this.model} wheels`);
  }

}
debugger;
let myTruck = new Truck("Volvo", "Excavadora", new Date(2010,11,17), 6);

myTruck.showPrettyModel();

myTruck.setName("Excavexcavator");

