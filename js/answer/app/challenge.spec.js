'use strict'

const Challenge = require('./challenge');
const Logger = require('./logger');

describe('Given Challenge class', () => {
    describe('When Constructor is called', () => {
        it('should be created with three properties: commandLineArgs, greeting, and logger', () => {
            let challenge = new Challenge();
            expect(challenge).to.have.property('commandLineArgs');            
            expect(challenge).to.have.property('logger');
            expect(challenge).to.have.property('greeting');
        });
       
    });   
});

describe('Given Challenge ', () => {
    describe('When createSlug is called', () => {
        it('should return a string', () => {
            let challenge = new Challenge();
            expect(challenge.createSlug("some string")).to.be.a('string');
        });
       
    });   
});