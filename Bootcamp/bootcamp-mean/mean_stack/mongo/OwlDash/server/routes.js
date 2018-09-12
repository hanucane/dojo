const {home, viewOwl, newOwl, createOwl, editOwl, updateOwl, deleteOwl} = require("./controller.js")

function router(app)
{
    app.get("/", home);
    app.get("/owls/:id", viewOwl);
    app.get("/owls/new", newOwl);
    app.post("/owls", createOwl);
    app.get("/owls/edit/:id", editOwl);
    app.post("/owls/:id", updateOwl);
    app.get("/owls/delete/:id", deleteOwl);
}

module.exports = router;