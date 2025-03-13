let promise = new Promise((res, rej) => {
    res('Resolved promise - 1')
})

promise
    .then((res) => {
        console.log(res)
        return "OK"
    })
    .then((res1) => {
        console.log(res1)
    })