const {home, quotes, newQuote} = require("./controller.js")

function router(app)
{
    app.get("/", home);
    app.get("/quotes", quotes);
    app.post("/quotes", newQuote);
}

module.exports = router;