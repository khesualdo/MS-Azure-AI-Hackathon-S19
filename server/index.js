const express = require('express')
const request = require('request')
const cors = require('cors')
const bodyParser = require('body-parser')
const app = express()
const port = 8888

app.use(bodyParser.raw({
    type: 'application/octet-stream',
    limit: '*'
}));

// Default is *
app.use(cors())

const COGNITIVE_URL = ''
const COGNITIVE_KEY = ''

const FUNCTION_URL = ''

// Calls the Custom Vision Cognitive Service
// Returns the tagName with the highest probability from all predictions
app.post('/fruitPredictions', function (req, res) {

    var image = JSON.parse(req.body)
    image = image.data
    image = Buffer.from(image, 'base64')

    request({
        url: COGNITIVE_URL,
        headers: {
          'Prediction-Key': COGNITIVE_KEY,
          'Content-Type': 'application/octet-stream'
        },
        method: "POST",
        body: image
    }, function (error, response, body){

        body = JSON.parse(body)

        let predictions = body.predictions

        // Iterate over predictions
        // Choose prediction with highest probability
        let probability = 0
        let tagName = ''

        for(let i = 0; i < predictions.length; i++) {
            let obj = predictions[i]

            if (obj.probability > probability) {
                probability = obj.probability
                tagName = obj.tagName
            }
        }

        res.send({fruit:tagName});
    });
})

// Calls the Azure Function
// Returns 'Allowed' if fruit is allowed
// Returns 'Not Allowed' otherwise
// Also returns info about the fruit
// Usage: /fruitAllowed?fruit=avocado
app.get('/fruitAllowed', function (req, res) {
    let fruit = req.query.fruit

    let urlFRUIT = `${FUNCTION_URL}&name=${fruit}`

    request({
        url: urlFRUIT,
        method: "GET",
    }, function (error, response, body){
        res.send({info:body})
    })
})

app.listen(port, () => console.log(`Example app listening on port ${port}!`))
