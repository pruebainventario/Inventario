# Inventario

Para ejecutar la aplicación web se necesita: Visual Studio y .NET Framework 4.7.2

La aplicación es un inventario general, se pueden crear los tipos de elementos que quiereas. 

Consta de una página de login y el inventario, solo se puede tener acceso al inventario si el login es correcto. Se ha separado el código
de Login e Inventario en dos controladores distintos, ya que son módulos con funcionalidades distintas.

El módulo de Login genera un token que se almacena en una cookie, esto permite que se pueda utilizar el módulo del Inventario. La validación 
de la contraseña está cifrada con SHA1, por lo que solo se podra tener acceso si se conoce la contraseña.

El módulo del Inventario permite listar el inventario, sacar un elemento por nombre e introducir nuevos elementos. En los elementos 
que se vayan a crear no se admiten caracteres especiales ni espacios en blanco. Tampoco te permite insertar dos elementos con el mismo 
nombre. Si algún elemento está caducado aparecerá "Caducado" junto al elemento.

También cuenta con una pequeña parte de test Unitarios, en los que se prueban algunas funcionalidades.



