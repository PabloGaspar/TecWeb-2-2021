
function prepareOrder(){
  return "other";
}
debugger;
var promiseOrder = new Promise((resolve, reject)=>{
  var order = prepareOrder();
  setTimeout(function(){
    if(order === "chicken"){
      resolve(`your order is: ${order}`); 
    } else{
      reject('something went wrong')
    }
  },3000);
});


/*
promiseOrder.then((orderMessage) =>{
  console.log(`Promise succesfully resolved ${orderMessage}`)
}).catch((errorMessage)=>{
  console.log(`Promise failed ${errorMessage}`)
});
*/


promiseOrder.then((orderMessage) =>{
  console.log(`Promise succesfully resolved ${orderMessage}`)
},(errorMessage)=>{
  console.log(`Promise failed ${errorMessage}`)
});



