
var name = "global";
/*
To understand this binding, we have to understand the call-site: the location in code where a function is called 
(not where it's declared)
*/

function baz() {
  // call-stack is: `baz`
  // so, our call-site is in the global scope

  console.log( "baz" );
  bar(); // <-- call-site for `bar`
}

function bar() {
  // call-stack is: `baz` -> `bar`
  // so, our call-site is in `baz`
  var name = "foo";
  console.log( "bar" );
  foo(); // <-- call-site for `foo`
}

function foo() {
  // call-stack is: `baz` -> `bar` -> `foo`
  // so, our call-site is in `bar`

  console.log( this.name );
}

baz(); // <-- call-site for `baz`



//Nothing But Rules
//Call-site
//Default Binding--------------------------------------------------------------------------------------------------
//this -> global scope -- window
function foo() {
	console.log( this.a );
}

var a = 2;
debugger;
foo(); 


//window.foo();

var obj = {
    a: 22,
    foo2 : function(){
        console.log( this.a );  
    }
};

var fooRef = obj.foo2;
fooRef();


//Implicit Binding--------------------------------------------------------------------------------------------------------------



debugger;


function foo() {
	console.log( this.a );
}

var obj = {
	a : 17,
	foo: foo, 
	name: "pepito"
};


var a = 33;
obj.foo(); 


function foo() {
	console.log( this.a );
}
// last  level
var obj2 = {
	a: 42,
	foo: foo
};

var obj1 = {
	a: 2,
	obj2: obj2
};

obj1.obj2.foo(); 

//implicit lost
function foo() {
	console.log( this.a );
}

var obj = {
	a: 2,
	foo: foo
};

var bar = obj.foo; 
var a = "oops, global"; 
bar();

//passing a callback function:

function foo() {
	console.log( this.a );
}

function doFoo(fn) {
	// `fn` is just another reference to `foo`

	fn(); // <-- call-site!
}

var obj = {
	a: 2,
	foo: foo
};

var a = "oops, global"; // `a` also property on global object

doFoo( obj.foo ); // "oops, global"

//set interval 
function foo() {
	console.log( this.a );
}

var obj = {
	a: 2,
	foo: foo
};

var a = "oops, global"; // `a` also property on global object

setTimeout( obj.foo, 100 ); // "oops, global"



//function setTimeout(fn,delay) {
	           // wait (somehow) for `delay` milliseconds
	//fn(); // <-- call-site!
//}



//Explicit Binding-------------------------------------------------------------------------------------------------------------
function foo(prefix, sufix) {
	console.log( `${prefix} - ${this.a} - ${sufix}`);
}
var a = "in global";
var obj = {
	a: 2
};

foo.call( obj, "Sir", "good bye"); 


///////
function foo() {
	console.log( this.a );
}

var obj = {
	a: 2
};

var bar = function() {
	foo.call( obj );
};

bar(); // 2
setTimeout( bar, 100 ); // 2

// `bar` hard binds `foo`'s `this` to `obj`
// so that it cannot be overriden
bar.call( window ); // 2

//////////////

function foo(something) {
	console.log( this.a, something );
	return this.a + something;
}

var obj = {
	a: 2
};

var result = foo.call(obj);

var bar = function(arguments) {
	return foo.apply( obj, arguments );
};

var b = bar( 3 ); 
console.log( b ); 
////


function foo(something) {
	console.log( this.a, something );
	return this.a + something;
}

// simple `bind` helper
function bind(fn, obj) {
	return function() {
		return fn.apply( obj, arguments );
	};
}

var obj = {
	a: 2
};

var bar = bind( foo, obj );

var b = bar( 3 ); 
console.log( b ); 
//////


function foo(something) {
	console.log( this.a, something );
	return this.a + something;
}

var obj = {
	a: 2
};

var bar = foo.bind( obj );

var b = bar( 3 ); 
console.log( b ); 
/////


function foo() {
	console.log( `Foo returns ${this.name}` );
}

var name = "name in global";

var obj = {
	name : "obj name"
};

var obj2 = {
	name : "obj22222 name"
};

var baz = foo.bind(obj);
baz.call(obj2);


//new Binding------------------------------------------------------------------------------------------

function Person(nameArg, ageArg) {
	this.name = nameArg;
	this.age = ageArg;
}

var pepito = new Person( "pepito", 22);
console.log( `person name is ${pepito.name} and he is ${pepito.age}`);

var maria = new Person( "maria", 20);
console.log( `person name is ${maria.name} and he is ${maria.age}`);



