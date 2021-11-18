# Simple JavaScript ES6 module example

## Native JavaScript **ES6 modules** run locally in the browser, without libraries or transpilers

ES6 browser support now means you can use the simpler JavaScript module syntax (`export` and `import`) natively in [most modern browsers](https://www.caniuse.com/#feat=es6-module). Unless you're still writing for IE9, this is the way to go.

This simplifies things and is all you need to break down your JavaScript code into re-usable modules for small-medium-sized projects.

## A little history: AMD and Common JS

> "The goal for ECMAScript 6 modules was to create a format that both users of CommonJS and of AMD are happy with" —[Exploring JS](http://exploringjs.com/es6/ch_modules.html)

When searching *JavaScript modules* on the web, you'll come across (often older pre-**ES6 module**) examples using **AMD** and **CommonJS** syntax (originating from the JavaScript front-end library Dojo and the JavaScript server environment node) both created to implement JS modules before widespread support:

- AMD: Asynchronous Module Definition, asynchronous, targeted at browser environments (from Dojo)
- CommonJS or CJS: CommonJS Modules, synchronous, targeted at server-side environments (e.g. node)

AMD and CommonJS code examples use `exports` (with an *s*), `define()` and `require()` (to mangle both into one non-ES6 thing). ES6 module syntax now does the job.

## A few notes

What no-one mentions, either because they've been using node since before the dinosaurs, or they're just *so js* they can't possibly imagine anyone not actually knowing this stuff:

1. the HTML script tag for the main JavaScript file (from which any module files are imported) needs a `type="module"` attribute e.g. `<script type="module" src="main.js"></script>`.
2. in your HTML, you only need a single `script` tag with the "module" attribute for your main JavaScript file, from which you can import module files.
3. [Same-origin policy](https://stackoverflow.com/a/46992592/123033) applies, so can't run from a file system (e.g. dragging your HTML file to the browser). Start a local server from the command-line in the folder containing the HTML file - use node `http-server` or another [static server command for a popular language](#static-server-one-liners) listed below.
4. MDN covers ES6 modules very well under [`import`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/import) and [`export`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Statements/export), but **ignore** finds on MDN for *JavaScript code modules*, these are [*Firefox-specific* "JavaScript code modules"](https://developer.mozilla.org/en-US/docs/Mozilla/JavaScript_code_modules), **not** JavaScript ES6 modules. Confusing, eh?
5. you must `import` modules before an IFFE, and they're "use strict" by default, so no need to declare it explicitly in the module

## TO DO

- [x] improve links to local servers
- [x] add link to CodeCademy JS Module tutorial
- [ ] insert results from calling modules into the HTML instead of just showing in the console
- [ ] use the example to explain (asynchronous/synchronous) AMD and CommonJS (`define()`, `require()`, `exports`) and ES6 (`export`/`import`)

---

## Key quotations

> the Require module system isn't standard based. It's is highly unlikely to become standard now that ES6 modules exist.

> ES6 modules will basically make UMD (Universal Module Definition) obsolete - essentially removes the schism between CommonJS and AMD (server vs browser).

—[Using Node.js require vs. ES6 import/export
](https://stackoverflow.com/q/31354559/123033)

> If you’re a newcomer to JavaScript, jargon like “module bundlers vs. module loaders,” “Webpack vs. Browserify” and “AMD vs. CommonJS” can quickly become overwhelming.

> Good authors divide their books into chapters and sections; good programmers divide their programs into modules.

—[JavaScript Modules: A Beginner’s Guide](https://medium.freecodecamp.org/javascript-modules-a-beginner-s-guide-783f7d7a5fcc)

## References

- the primary references:
  - [Exploring JS, Chapter 6: Modules](http://exploringjs.com/es6/ch_modules.html)
  - [CodeCademy, Learn JavaScript: Modules](https://www.codecademy.com/courses/intermediate-javascript-modules/lessons/modules/exercises/hello-modules)
  - [The Stack Overflow question with the info I really needed](https://stackoverflow.com/q/28674652/123033 "What is the difference between browserify/requirejs modules and ES6 modules (2015)")
- Other useful sources:
  - [[es6] import, export, default cheatsheet](https://hackernoon.com/import-export-default-require-commandjs-javascript-nodejs-es6-vs-cheatsheet-different-tutorial-example-5a321738b50f)
- history lessons (only if you really need them):
  - [AMD versus CJS. What’s the best format? (2011)](http://unscriptable.com/2011/09/30/amd-versus-cjs-whats-the-best-format/)
  - why modules? Addy Osmani [Writing Modular JavaScript With AMD, CommonJS & ES Harmony (2012)](https://addyosmani.com/writing-modular-js/) (the old name for ES6)
  - [AngularJS and Browserify developers discussing AMD vs CommonJS](https://stackoverflow.com/a/36224960/123033)

### Static server one-liners

- [Big list of static server one-liners](https://gist.github.com/willurd/5720255)
- Shortlist/quick reference:
  - [node](https://www.npmjs.com/package/http-server) (install globally with `npm install http-server -g` and run from your project directory with `http-server` on the command-line to view on http://localhost:8080)
  - [Python](https://sweetme.at/2013/08/21/simple-local-http-server-with-python/) `python -m SimpleHTTPServer` Python3 `python -m http.server` (default port 8000)
  - [Ruby](http://til.justincampbell.me/start-an-http-server-with-ruby-run/) `ruby -run -e httpd . -p 8000`
  - [PHP](https://secure.php.net/manual/en/features.commandline.webserver.php) `php -S localhost:8000`

