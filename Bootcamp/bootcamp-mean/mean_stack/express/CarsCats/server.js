// Load the express module and store it in the variable express (Where do you think this comes from?)
var express = require("express");
console.log("Let's find out what express is", express);
// invoke express and store the result in the variable app
var app = express();
console.log("Let's find out what app is", app);
// this is the line that tells our server to use the "/static" folder for static content
app.use(express.static(__dirname + "/static"));
// This sets the location where express will look for the ejs views
app.set('views', __dirname + '/views'); 
// Now lets set the view engine itself so that express knows that we are using ejs as opposed to another templating engine like jade
app.set('view engine', 'ejs');
// use app's get method and pass it the base route '/' and a callback
app.get('/cars', function(request, response) {
        response.render('cars');
    })
app.get('/cats', function(request, response) {
        response.render('cats');
    })
app.get('/cars/new', function(request, response) {
        response.render('form');
    })
app.get("/details/:catId", function (request, response){
        let catId = request.params.catId;
        var cat_array = [
            {name: "Sgt. Meowinstein", favfood: "grass", age: "1", sleep: ["under car", "in a well"]}, 
            {name: "Undead Kitty", favfood: "human flesh", age: "2000", sleep: ["under the bed", "in a sunbeam"]}
        ];
        for (let i=0; i<cat_array.length; i++)
        {
            if (i == catId){
                var obj = cat_array[i];
            }
        }
        response.render('details', {cats: obj});
    })
// tell the express app to listen on port 8000, always put this at the end of your server.js file
app.listen(8000, function() {
  console.log("listening on port 8000");
})
