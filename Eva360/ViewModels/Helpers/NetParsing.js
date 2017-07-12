var moment = require('moment');
var netdate = require('./../Partials/RegexSamples').netdate;

function parseDate(date) {
    var timestamp = date.replace(netdate, "$1");
    return moment(parseInt(timestamp)).format("YYYY-MM-DD");
}

function parseFormatDate(date) {
    var timestamp = date.replace(netdate, "$1");
    return moment(parseInt(timestamp)).format("DD-MM-YYYY");
}


module.exports.parseDate = parseDate;
module.exports.parseFormatDate = parseFormatDate;