const firstletter = require('./../Partials/RegexSamples').firstletter;

function getGenero(sexo) {
    return sexo == "F" ? "Mujer" : sexo == "M" ? "Hombre" : "-";
}

function getEstadoPeriodo(estado) {
    switch (estado) {
        case 'ACT':
            return "Activo";
        case 'INA':
            return "Inactivo";
    }
}

function toCapitalCase(text) {
    return text.toLowerCase().replace(firstletter, s => s.toUpperCase());
}

exports.getGenero = getGenero;
exports.getEstadoPeriodo = getEstadoPeriodo;
exports.toCapitalCase = toCapitalCase;