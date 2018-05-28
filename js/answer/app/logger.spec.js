'use strict'

const Logger = require('./logger');
const TestString = 'x';  

describe('Given Logger', () => {
    it('should log a message to the console', () => {
        let logger = new Logger();
        let spy = sinon.spy(console, 'log');

        logger.log(TestString);

        expect(spy.calledOnce);
        expect(spy.calledWithMatch(TestString));

        spy.restore();
    });
});