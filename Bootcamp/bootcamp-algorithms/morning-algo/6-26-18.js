// Print keys & values (ex. fruit: clementine)
function keyVal(fruit){
    for (var key in fruit){
        console.log(key+": "+fruit[key]);
    }
}
keyVal({name: "clementines", calories: 75, color: "orange"})

// generateCoinChange(cents) => object
function generateCoinChange(cents){
    var change = {quarters:0,dimes:0,nickels:0,pennies:0}
    while (cents>0){
        if (cents>=25){
            change.quarters = change.quarters+1;
            cents -= 25;
        }
        else if (cents>=10){
            change.dimes = change.dimes+1;
            cents -= 10;
        }
        else if (cents>=5){
            change.nickels = change.nickels+1;
            cents -= 5;
        }
        else if (cents>=1){
            change.pennies = change.pennies+1;
            cents -= 1;
        }
    }
    console.log(change);
}
generateCoinChange(164)
