const low = require('lowdb');
const FileSync = require('lowdb/adapters/FileSync');
const crypto = require('crypto');
const { exit } = require('process');
const adapter = new FileSync('login_keys.json');
const db = low(adapter);

db.defaults({ keys:[] })
  .write()

  var myArgs = process.argv.slice(2);
if (myArgs.length < 1){
  console.log("Please enter assosiated name as a parameter!");
  exit(1);
}

const generatedKey = crypto.randomBytes(8).toString("hex");
const md5sum = crypto.createHash('md5').update(generatedKey).digest('hex');
const epochDate = Date.now();

db.get('keys')
  .push({ key: generatedKey, keyHash: md5sum ,name: myArgs[0], CreationDate: epochDate})
  .write();
console.log("Newly generated key is:\n" + generatedKey);
console.log("Done!");