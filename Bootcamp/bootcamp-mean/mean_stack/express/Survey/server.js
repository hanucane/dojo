//dependencies//
var express = require('express');
var session = require('express-session');
var bodyParser = require('body-parser');
var path = require("path");
var app = express();

//dependency setup//
app.use(session({
    secret: 'LiveFr33',
    resave: false,
    saveUninitialized: true,
    cookie: {maxAge: 60000}
}))
app.use(bodyParser.urlencoded({extended:true}));
app.use(express.static(path.join(__dirname, "./static")));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

//Routes//
app.get('/', function(req, res) {
    res.render("index")
})

app.post('/submit', function(req, res){
    req.session.name = req.body.name;
    req.session.email = req.body.email;
    req.session.language = req.body.language;
    req.session.dojo = req.body.dojo;
    req.session.comment = req.body.comments;
    res.redirect("result")
})

app.get('/result', function(req, res){
    context = {name: req.session.name, email: req.session.email, language: req.session.language, dojo: req.session.dojo, comment: req.session.comment};
    res.render("result", context)
})

//Listening on port//
app.listen(8000, function() {
    console.log("listening on port 8000");
});