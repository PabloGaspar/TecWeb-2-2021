// Default values
function orderChickenWith(sideDish) {   // orderChickenWith(sideDish =  "whatever!") 
  sideDish = sideDish || "whatever!";
  console.log("Chicken with " + sideDish);
}

orderChickenWith("noodles");
orderChickenWith();



