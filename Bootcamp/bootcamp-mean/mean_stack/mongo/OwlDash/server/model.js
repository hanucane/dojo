const goose = require("mongoose");

goose.connect("mongodb://localhost:27017/Owlie", {useNewUrlParser: true}, (errs)=>console.log(errs?errs:"Database connected"));

const OwlSchema = new goose.Schema({
    name: {
        type: String,
        required: true,
        minlength: [2, "Owl name must be at least 2 characters"]
    },
    breed: {
        type: String,
        required: true,
        minlength: [3, "The breed must be 3 characters long"]
    }
},{timestamps:true});

const Owls = goose.model('owls', OwlSchema);

module.exports = Owls
