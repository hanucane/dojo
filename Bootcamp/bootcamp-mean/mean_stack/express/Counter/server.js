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
    if(!req.session.visits){
        req.session.visits = 1;
    }
    else
    {
        req.session.visits += 1;
    }
    
    context = {visits: req.session.visits};
    res.render("index", context);
})

app.post('/double', function(req, res) {
    req.session.visits += 1;
    res.redirect('/')
})

//Listening on port//
app.listen(8000, function() {
    console.log("listening on port 8000");
});