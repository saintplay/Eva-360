const firstletter = require('./../Partials/RegexSamples').firstletter;

function getGenero(sexo) {
    return sexo == "F" ? "Mujer" : sexo == "M" ? "Hombre" : "-";
}

function toCapitalCase(text) {
    return text.toLowerCase().replace(firstletter, s => s.toUpperCase());
}

exports.getGenero = getGenero;
exports.toCapitalCase = toCapitalCase;