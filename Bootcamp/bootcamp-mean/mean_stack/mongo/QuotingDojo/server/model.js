const goose = require("mongoose");

goose.connect("mongodb://localhost:27017/QuotingDojo",
{useNewUrlParser: true}, (errs)=>console.log(errs?errs:"Database connected"));

const QuoteSchema = new goose.Schema({
    name: {
        type: String,
        required: true,
        minlength: [2,"Name must be at least 2 characters long"]
    },
    quote: {
        type: String,
        required: true,
        minlength: [10, "The quote must be at least 10 characters long"]
    }

},{timestamps:true});

const Quotes = goose.model('quotes', QuoteSchema);

module.exports = Quotes