const express = require('express');
const session = require("express-session");
const bodyParser = require('body-parser');
const low = require('lowdb');
const FileAsync = require('lowdb/adapters/FileAsync')
const fs = require('fs');
const compression = require('compression');
const https = require('https');
const extra = require("./dev_extra");
const md5File = require('md5-file')

const app = express();
const port = 444;

var key = fs.readFileSync('../certificates/privkey.pem');
var cert = fs.readFileSync('../certificates/cert.pem');
var options = {
  key: key,
  cert: cert
};

var server = https.createServer(options, app);

app.disable('x-powered-by');
app.use(bodyParser.urlencoded({ extended: true }));
app.use(bodyParser.json());
app.use(express.static(__dirname, { dotfiles: 'allow' } ));
app.use(compression());
app.get('/favicon.ico', (req, res) => res.status(204));

app.use(session({
  secret: "someThIng",
  authenticated: 0,
  downloadUID: "",
  cookie: {},
  resave: true,
  saveUninitialized: true
}));
const adapter = new FileAsync('login_keys.json')
low(adapter).then(db => {
    app.post('/sign', (req, res) =>{
      let info = req.body.passHash;
      if (info.length > 32){
          return;
      }
      info = info.toLowerCase();
      let fetched = db.get('keys').find({keyHash: info}).value();

      if (typeof fetched === 'undefined'){
        console.log("fetched data is undefned, returning failure");
        req.session.authenticated = 0;
        return res.end('0');
      }
      req.session.authenticated = 1;
      console.log("Request was valid");
      var returnObject = {
            session: req.sessionID,
            games: []
      };
      
      if (fetched["name"] == "testings"){ // If registered code is for "testings"
        returnObject.games = extra.testObjects;
      }
      else{ // if not, prepare real game objects
        returnObject.games = extra.gameObjects;
      }

      return res.end(JSON.stringify(returnObject));
  });
  
  app.get('/sign', (req, res) => {
      // let it timeout
  });

  app.post("/update", (req, res) => {
    let info = req.body.thisHash;
    let ipAddr = req.connection.remoteAddress;
    console.log(ipAddr + " looks if any update available! (" + info + ")");
    if (typeof info === 'undefined'){
      console.log("Hash is undefined (faulty request), ignoring...");
      return res.end();
    }

    const md5Hash = md5File.sync('binary_dev/release.exe');
    console.log(md5Hash);

    if (info === md5Hash){ // Versions match, respond normally
      console.log("Versions match, not updating!");
      return res.end(JSON.stringify({forceUpdate: false}));
    }
    console.log("Version mismatch!");
    let randomUID = extra.randomString(7);
    console.log("RANDOM UID: " + randomUID);
    req.session.downloadUID = randomUID;
    return res.end(JSON.stringify({forceUpdate: true, endPoint: randomUID}));
  });

  app.get("/bin/:game", (req, res)=>{
    let game = req.params.game;
    console.log("Requested download for game " + game);
    extra.gameObjects.forEach(gameObject => {
      if (game == gameObject.gameName){
        console.log("Got a hit with " + gameObject.processName);
      }
    });
    extra.testObjects.forEach(testObject => {
      if (game == testObject.gameName){
        console.log("Got a hit with " + testObject.processName);
      }
    })

    let file = fs.readFileSync('binary_dev/injector.exe');
    res.write(file, "binary");
    res.end(null, 'binary');
  });

  app.get("/update/:id", (req, res)=>{
    let id = req.params.id;
    if (id != req.session.downloadUID){
      return res.end();
    }
    let file = fs.readFileSync('binary_dev/release.exe');
    res.write(file, "binary");
    res.end(null, 'binary');
    console.log("New file sent successfully!");
  });

  app.get('/', (req, res) => {
      // let it timeout
  })
  return db.defaults({ keys: []}).write()
})
.then(() => {
    server.listen(port, () => console.log(`Starting server ${port}...`));
});