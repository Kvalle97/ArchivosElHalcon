# Proyecto administración.
![enter image description here](http://www.elhalcon.com.ni/img/logo.png)
## Datos técnicos

 1. Plataforma .Net 4.6.1
 2. Lenguaje Visual C#
 3. Devexpress 18.2.6
 4. Desarrollado por Kevin Alexander Gaitán Argüello

## Prácticas usadas
|Práctica|Tipo afectado |
|-|--|
| Pascal Case, Naming Convention | Clases |
| camel Case, Naming Convention | variables, instancias |
| Documentacion de código | Métodos (publicos, protected), Propiedades (Publicas, Protected)|

## Otras librerías usadas.
[AutoUpdater.Net](https://github.com/ravibpatel/AutoUpdater.NET)
Librería para la auto actualización del sistema.

 1. Instalación
	 Click derecho en capa de presentación > Administrar paquetes NuGet > Buscar [AutoUpdater.Net](https://github.com/ravibpatel/AutoUpdater.NET) > Instalar 
 2. Como usar
	 Se crearon dos funciones en la Clase UIHelper
	 > CrearEventoDeActualizacion
	 Agrega el evento de buscar la actualización, está función debe ser llamada solo una vez en el Load de FrmMain.
	 
	 > BuscarActualizaciones
	 Llamar cada vez que se quiera buscar actualizaciones, poner en true
	 UIHelper.MostrarNoHayNuevasActualizaciones cuándo desee alertar al usuario que no hay actualizaciones nuevas
	  
