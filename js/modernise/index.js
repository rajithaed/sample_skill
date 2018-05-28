var fs = require('fs');

var regex = /[^A-Za-z0-9]/g;

function createSlug(line) {
    line = line.replace("'", '');
    line = line.replace(regex, '-');
    return line.toLowerCase().strip('-');
}

fs.readFile('titles.txt', 'utf-8', function(err, data) {
    var lines = data.split('\n');
    for (var i = 0; i < lines.length; i ++) {
        console.log(createSlug(lines[i]));
    }
})
