# FRÜT :cherries: :lemon: :watermelon:

![](https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/banner.jpg)

## Inspiration

The inspiration comes from [this](https://www.youtube.com/watch?v=sAiTuitN5b8&t=253s) video. In the video it shows how hard the Border Service Officers work to protect the American wild life from illegal imports of produce.

While, it is easy to spot rotten fruits, if the fruits are in perfect condition, the agent may or may not know if the fruit is allowed into the country. Also, it is definitely easy to identify common fruits, such as bananas or oranges, however, it is more difficult to identify more exotic fruits, such as cherimoyas, sweetsops, etc... It gets worse when fruits look very similar, for example - strawberry guavas and cranberries, lima and (large) limes or even unripe oranges.

<img src="https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/strawberry-guavas.jpg" height="250" width="220"> <img src="https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/cranberries.jpg" height="250" width="230">
> Strawberry guavas on the left / Cranberries on the right

<img src="https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/limas.jpeg" height="250" width="250"> <img src="https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/limes.jpg" height="250" width="250">
> Limas on the left / Limes on the right

An agent may make a mistake by confiscating permitted items, in this case the people are negatively affected by having to pay a fine. On the other hand, an agent may make a mistake by not confiscating non-permitted items, in this case the entire country is negatively affected by having to pay an even bigger "fine" to treat unknown insects and plant diseases.

## About

FRÜT could assist Border Service Officers in identifing different fruits, along with their attributes - such as fruit type, history, origin, as well as whether the fruit is allowed into the country.

FRÜT could also be used by regular citizens during their shopping trips.

## Implementation
![](https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/diagram.png)

> Screenshots of the application: [1](https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/app1.png), [2](https://github.com/00111000/MS-Azure-AI-Hackathon-S19/blob/master/static/app2.png)

## Run

Create a Function App resource on Azure portal
- Select `HTTP trigger` as type
- Copy code from `function.csx`
- Set `FUNCTION_URL` in `index.js`

Go to [Custom Vision Portal](https://www.customvision.ai) and create a new project
- Set `Project Type` as `Classification`
- Set `Classification Types` as `Multiclass`
- Set `Domains` as `Food`
- Set `COGNITIVE_URL` in `index.js` for image file (available after publishing the project)
- Set `COGNITIVE_KEY` in `index.js` (available after publishing the project)

> If you get the `We only support publishing to a prediction resource in the same region as the training resource the project resides in.` error, create a Custom Vision resource. Makes sure it is in the same region as all of your other resources.
> [Tutorial](https://www.youtube.com/watch?v=Sw_Zkb7WFDA) on how to use the Custom Vision Portal.

#### Run Client
```
> cd /client
> http-server -c-1
```
> [http-server on npm](https://www.npmjs.com/package/http-server)

#### Run Server
```
> cd /server
> node index.js
```

## Challenges
Surprisingly the biggest challenge was capturing and then sending the image to the back-end. Working so closely with Base64 Encoding, Data URIs, as well as, byte arrays was new for me. I am glad I figured it out in the end!

## Technologies
- Azure Cognitive Services (Custom Vision API)
- Azure Functions
- HTML, CSS, JS
- NodeJS, ExpressJS
- [Fruits 360 Dataset](https://www.kaggle.com/moltean/fruits)
