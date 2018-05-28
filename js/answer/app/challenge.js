'use strict'

const Logger = require('./logger');
const regex = /[^A-Za-z0-9]/g;
const fs = require('fs');

class Challenge{

    constructor (commandLineArgs) {
        this.commandLineArgs = commandLineArgs;
        this.logger = new Logger();
        this.greeting = 'JS Challenge....';
    }

    run(){
        if (this.commandLineArgs && this.commandLineArgs.length) {
            this.logger.log(this.commandLineArgs.join(' '));
        } else {
            this.logger.log(this.greeting);
        }

        fs.readFile('titles.txt', 'utf-8', (err, data) => {
            if (err) {
                throw new Error({ error: err })
            }
            let lines = data.split('\n')
            for (let i = 0; i < lines.length; i++) {
                this.logger.log(this.createSlug(lines[i]))
            }
        })
    }

    createSlug(line){
        let formattedLine
        formattedLine = line.replace("'", '')
        formattedLine = formattedLine.replace(regex, '-')
        return formattedLine.toLowerCase().replace('-', '')
   }
}

module.exports = Challenge;