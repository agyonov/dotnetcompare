import { StopWatch } from 'stopwatch-node';

const getRandomNumberBetween = (min:number, max:number) => {
    return Math.floor(Math.random() * (max - min + 1) + min)
}

const arr_1: number[] = [];

const sw = new StopWatch();

for(let loop=0; loop<67108864; loop++){
    arr_1.push(getRandomNumberBetween(0,255));
}

console.log("Start");

for (let loop = 0; loop < 21; loop++) {
    let d = 0.0;
    let a = 0;
    sw.start("Loop ["+loop+"]");
    for (let intr = 0; intr < arr_1.length; intr++) {
        a =  arr_1[intr] * 2;
        d = d + a / 313.0;
        a =  arr_1[intr] * 2;
        d = d + a / 313.0;
        a =  arr_1[intr] * 2;
        d = d + a / 313.0;
        a =  arr_1[intr] * 2;
        d = d + a / 313.0;
    }
    sw.stop();
}

sw.prettyPrint();

console.log("AvgTime: " + sw.getTotalTime() / 21 + " ms.");