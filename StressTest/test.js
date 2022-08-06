const autocannon = require('autocannon')

let servers = {
    rest: `http://localhost:8093`,
    node: `http://localhost:8094`,
};

const instance = autocannon({
    url: 'http://localhost:8093/comics',
    method: 'GET',
    connections: 10,
    pipelining: 1,
    duration: 60,
    timeout: 20,
    warmup: {
        connections: 1,
        duration: 3
    }
}, finishedBench)

autocannon.track(instance, { renderProgressBar: true });

function finishedBench(err, res) {
    console.log('finished bench', err, res)
}