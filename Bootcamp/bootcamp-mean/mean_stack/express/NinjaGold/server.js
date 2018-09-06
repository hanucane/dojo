//dependencies//
var express = require('express');
var session = require('express-session');
var bodyParser = require('body-parser');
var path = require("path");
var app = express();

//dependency setup//
app.use(session({
    secret: 'IHeartPlants',
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
    if(!req.session.totalGold){
        req.session.totalGold = 0;
        req.session.goldLog = [];
    }
    
    context = {totalGold: req.session.totalGold, goldLog: req.session.goldLog};
    res.render("index", context);
})

app.post('/process_money', function(req, res){
    console.log(req.body);
    if(req.body.building == "farm"){
        building = "farm";
        addGold = (Math.floor(Math.random()*10 + 10));
        req.session.totalGold += addGold;
    }
    else if(req.body.building == "cave"){
        building = "cave";
        addGold = (Math.floor(Math.random()*5 + 5))
        req.session.totalGold += addGold;
    }
    else if(req.body.building == "house"){
        building = "house";
        addGold = (Math.floor(Math.random()*3 + 2));
        req.session.totalGold += addGold;
    }
    else if(req.body.building == "casino"){
        building = "casino";
        addGold = (Math.floor(Math.random()*100 - 50))
        req.session.totalGold += addGold;
    }
    req.session.goldLog.push("Gained "+addGold+" golds" + " from the "+ building);
    res.redirect('/');
})

//Listening on port//
app.listen(8000, function() {
    console.log("listening on port 8000");
});