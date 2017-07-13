const mixin = {
    methods: {
        cargarDatosPorDefecto: function() {
            let datosDefecto = cargarDatosPorDefecto();
            for (let prop in datosDefecto) {
                this[prop] = datosDefecto[prop];
            }
        }
    }
};

exports.rightbarformmixin = mixin;