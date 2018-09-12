module.exports = {
    home: home,
    viewOwl: viewOwl,
    newOwl: newOwl,
    createOwl: createOwl,
    editOwl: editOwl,
    updateOwl: updateOwl,
    deleteOwl: deleteOwl
}

const Owls = require("./model.js");

function home(req, res){
    Owls.find({}, function(errs, data){
        if(errs){
            console.log(errs);
        }
        res.render("index", {data:data})
    })
}

function viewOwl(req, res){
    let owlId = req.params.id;
    Owls.findOne({_id: owlId}, function(errs, data){
        if(errs){
            console.log(errs);
        }
        res.render("vOwl", {owl:data})
    })
}

function newOwl(req, res){
    res.render("cOwl")
}

function createOwl(req, res){
    Owls.create(req.body, (errs, results)=>{
        if(errs){
            console.log(errs);
        }else{
            console.log(results);
        }
        res.redirect("/")
    })
}

function editOwl(req, res){
    Owls.findOne({_id: req.params.id}, function(errs, data){
        if(errs){
            console.log(errs);
        }
        res.render("uOwl", {owl:data})
    })
}

function updateOwl(req, res){
    Owls.update({_id: req.params.id}, 
    {
        name: req.body.name,
        breed: req.body.breed},
        (errs,results)=> {
            if(errs){
                console.log("You Suck");
                console.log(errs);
                
            }else{
                console.log("result");
            }
            res.redirect("/owls/"+req.params.id)
    })
}

function deleteOwl(req, res){
    Owls.deleteOne({_id: req.params.id}, (errs,results)=>{
        if(errs){
            console.log(errs);
            
        }else{
            console.log(results);
        }
        res.redirect("/");
    })
}