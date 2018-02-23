# Disclaimer #

This Project isn't Up to Date. Live Demo is broken too :(

<div align="center">
 <img src="https://cdn.rawgit.com/saintplay/Eva-360/master/Eva360/Content/logo.svg" alt="eva360" width="300">
</div>

# Eva-360

**Live Demo:** <https://eva-360.herokuapp.com>

## Arquitectura ##

<div align="center">
 <img src="https://user-images.githubusercontent.com/9372893/28237718-d758b9ae-690b-11e7-9649-bb96bd86dfe0.png" alt="eva360">
</div>

## Notas Importantes

- Antes de abrir el proyecto en Visual Studio, crear una variable de entorno con el nombre **NOMBRESQLSERVER** y el valor tiene que ser el nombre de tu SQL Server.
El proyecto reemplazará el *data source* automaticamente por la variable de entorno. Pero es **Importante** de que se haga esto antes de abrir o incluso descargar el proyecto.
- Se agregó una tabla "Administrador", por lo que se recomienda bajarse la base de datos actualizada, que está en este enlace: <https://drive.google.com/drive/folders/0B_Xq0VghEDqINExIUU9WYmpITFE?usp=sharing>
- Se ha investigado sobre la metodologías de trabajar ASP.MVC con frameworks frontend como Angular o *Vue*, aislando los diferentes modulos en silos.
Este artículo lo explica a detalle: <http://www.codemag.com/article/1605081> vale la pena leerlo y sobretodo desarrollar dicha metodología. Este proyecto la implementa con **Vue.
- Este proyecto también es compatible con Visual Studio Code, gracias a *gulp* que se encarga de refrescar la página, compilar denuevo al detectar cambios e iniciar un servidor express.
- Se ha implementado seguridad con md5 y doble salt para las contraseñas.
