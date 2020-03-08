# Inventario

Para ejecutar la aplicaci�n web se necesita: Visual Studio y .NET Framework 4.7.2

La aplicaci�n es un inventario general, se pueden crear los tipos de elementos que quiereas. 

Consta de una p�gina de login y el inventario, solo se puede tener acceso al inventario si el login es correcto. Se ha separado el c�digo
de Login e Inventario en dos controladores distintos, ya que son m�dulos con funcionalidades distintas.

El m�dulo de Login genera un token que se almacena en una cookie, esto permite que se pueda utilizar el m�dulo del Inventario. La validaci�n 
de la contrase�a est� cifrada con SHA1, por lo que solo se podra tener acceso si se conoce la contrase�a.

El m�dulo del Inventario permite listar el inventario, sacar un elemento por nombre e introducir nuevos elementos. En los elementos 
que se vayan a crear no se admiten caracteres especiales ni espacios en blanco. Si alg�n elemento est� caducado aparecer� "Caducado"
junto al elemento.

Tambi�n cuenta con una peque�a parte de test Unitarios, en los que se prueban algunas funcionalidades.



