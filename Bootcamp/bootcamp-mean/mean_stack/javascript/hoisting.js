console.log(hello);     // Logs undefined                                
var hello = 'world';    // Sets hello to 'world' string

var needle = 'haystack';    // Hoists needle value as 'haystack' string
test();                     // Test is not a function -> error
function test(){            // Test() is created
	var needle = 'magnet';  // Hoists needle value as 'magnet' string
	console.log(needle);    // Console logs 'magnet'
}

var brendan = 'super cool'; // Hoists brendan value as 'super cool' string
function print(){           // print() is created
	brendan = 'only okay';  // Hoists brendan value as 'only okay' string when function called
	console.log(brendan);   // Console logs 'only okay'
}
console.log(brendan);       // Console logs 'super cool'

var food = 'chicken';       // Hoists food value as 'chicken' string
console.log(food);          // Console logs 'chicken'
eat();                      // eat is not a function -> error
function eat(){             // eat() is created
	food = 'half-chicken';  // Hoists food value as 'half-chicken' string
	console.log(food);      // Console logs 'half-chicken'
	var food = 'gone';      // Hoists food value as 'gone' string
}

mean();                     // mean is not a function -> error
console.log(food);          // food is undefined
var mean = function() {     // mean() is created
	food = "chicken";       // Hoists food as "chicken" string
    console.log(food);      // Console logs 'chicken'
	var food = "fish";      // Hoists food as "fish" string
	console.log(food);      // Console logs 'fish'
}
console.log(food);          // food is undefined unless mean() is called

console.log(genre);         // genre is undefined
var genre = "disco";        // Hoists genre as "disco" string
rewind();                   // rewind does not exist -> error
function rewind() {         // rewind() is created
	genre = "rock";         // Hoists genre as "rock" string
    console.log(genre);     // Console logs 'rock'
	var genre = "r&b";      // Hoists genre as 'r&b' string
	console.log(genre);     // Console logs 'r&b'
}
console.log(genre);         // Console logs 'disco' unless rewind() is called

dojo = "san jose";          // dojo is not previous defined so error may occcur
console.log(dojo);          // if dojo is hoisted properly, console logs 'san jose'
learn();                    // learn does not exist -> error
function learn() {          // learn() is created
	dojo = "seattle";       // Hoists 'seattle' to dojo
	console.log(dojo);      // console logs 'seattle'
	var dojo = "burbank";   // hoists 'burbank' to dojo
	console.log(dojo);      // console logs 'burbank'
}
console.log(dojo);          // console logs 'san jose'




