'use strict'

const Challenge = require('./app/challenge');

let challenge = new Challenge(process.argv.slice(2));
challenge.run();