let promise = new Promise((res, rej) => {
    res('Resolved promise - 1')
})

promise
    .then((res) => {
        console.log("Resolved promise - 2")
        return "OK"
    })
    .then((res) => {
        console.log(res)
    })