"use strict";
exports.__esModule = true;
var server_1 = require("./server");
server_1.init().then(function () { return server_1.start(); });
