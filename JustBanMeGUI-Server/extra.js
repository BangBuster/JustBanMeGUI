const STATUS_READY = 0;
const STATUS_UNAVAILABLE = 1;

var GameObject = {
    gameName: "",
    shortName: "",
    processName: "",
    status: 0
};
var CSGO_object = {
    gameName: "CSGO",
    shortName: "csgo",
    processName: "csgo",
    status: STATUS_READY
};
var AmongUs_object = {
    gameName: "Among Us",
    shortName: "amongus",
    processName: "Among Us",
    status: STATUS_UNAVAILABLE
};
var Notepad_object = {
    gameName: "Notepad",
    shortName: "Notepad",
    processName: "Notepad",
    status: STATUS_READY
}
var Discord_object = {
    gameName: "Discord",
    shortName: "discord",
    processName: "Discord",
    status: STATUS_UNAVAILABLE
}

function randomString(lengthOfString){
    return Math.random().toString(36).substring(lengthOfString);
};

module.exports = {
    gameObjects: [CSGO_object, AmongUs_object],
    testObjects: [Notepad_object, Discord_object],
    randomString: randomString
};

