module.exports = {
    home: home,
    quotes: viewQuote,
    newQuote: makeQuote,
}

const Quotes = require("./model.js");

function home(req,res){
    res.render("index");
}

function viewQuote(req,res){
    Quotes.find({}, function(errs, data){
        if(errs){
            console.log(errs)
        }
        res.render("quotes", {data: data})
    }) 
}

function makeQuote(req,res){
    Quotes.create(req.body, (errs, results)=>{
        if(errs){
            console.log(errs);
        }else{
            console.log(results);
        }
        res.redirect("/quotes")
    })
}
