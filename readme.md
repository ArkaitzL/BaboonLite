Entendido, aquí está la documentación mejorada siguiendo tus sugerencias:

**CLASES:**

**Instancias[CLASE] (2 FUNCIONES):**
- `Instanciar<Clase>.Coger()` (Tipo: Vacío): Coge la clase del tipo del genérico.
  - `return: T (Tipo: Vacío)`
- `Instanciar<Clase>.Añadir(clase)` (Tipo: Vacío): Añade la clase de la propiedad a una función pública de fácil acceso, siempre y cuando coincida con el tipo del T.
  - `return: void (Tipo: Vacío)`
- `Instanciar<Clase>.Singletons(clase, objeto)` (Tipo: Vacío): Crea un singleton siempre y cuando coincida con el tipo del T.
  - `return: void (Tipo: Vacío)`

**Funciones[CLASE]:**
- **ARRAY:**
  - `[“true, false”].inArray<bool>()/inList<bool>()` (Tipo: Vacío): Transforma un texto con formato específico en una lista/array.
    - `return: List<T>/T[] (Tipo: Vacío)`
  - `List<bool>.inString()` (Tipo: Vacío): Transforma una lista en un texto con formato específico.
    - `return: string (Tipo: Vacío)`
  - `List<bool>.Foreach((elemento, index ) => { función() })` (Tipo: Vacío): Alternativa al foreach clásico. El index es opcional.
    - `return: void (Tipo: Vacío)`
  - `List<bool>.Every(elemento => { comparación })` (Tipo: Vacío): Te da true si todas las comparaciones dan true.
    - `return: bool (Tipo: Vacío)`
  - `List<bool>.Some(elemento => { comparación })` (Tipo: Vacío): Te da true si alguna de las comparaciones dan true.
    - `return: bool (Tipo: Vacío)`
  - `List<bool>.Filter(elemento => { comparación })` (Tipo: Vacío): Te da una lista con los elementos que cumplan la condición.
    - `return: List<T> (Tipo: Vacío)`
  - `List<bool>.Map(elemento => { función() })` (Tipo: Vacío): Te da una lista con los elementos modificados que se modifican dentro de la función.
    - `return: List<T> (Tipo: Vacío)`
  - `List<bool>.Inside(int)` (Tipo: Vacío): Te dice si el número de elementos existe.
    - `return: bool (Tipo: Vacío)`
- **BUG:**
  - `Bug.Log(color)` (Tipo: Vacío): Imprime en consola un mensaje por defecto. Puedes cambiarle el color poniéndolo como parámetro, es opcional.
    - `return: void (Tipo: Vacío)`
  - `T.Log()` (Tipo: Vacío): Imprime un Log del T en forma de string y devuelve el valor T.
    - `return: T (Tipo: Vacío)`
- **NÚMEROS:**
  - `float.EquacionLimitada(float valor, float límite)` (Tipo: Vacío): De suma o resta un valor a tu variable poniendo un límite.
- **TRANSFORMAR:**
  - `Vector3.Y/X/Z(num)` (Tipo: Vacío): Le suma o resta a la propiedad del Vector3 el número.
  - `Quaternion.Y/X/Z(num)` (Tipo: Vacío): Le suma o resta a la propiedad del Quaternion el número.

**Controlador[COMPONENTE] (3 FUNCIONES):**
- `Controlador.Rutina(tiempo, () => {})` (Tipo: Vacío): Llama a la función después de determinado tiempo.
  - `return: Coroutine (Tipo: Vacío)`
- `Controlador.Mover(transform, Movimiento)/.MoverCanva(rectTrans, Movimiento)` (Tipo: Vacío): Mueve un objeto de un punto al otro mediante una animación suave.
  - `return: Coroutine (Tipo: Vacío)`
- `Controlador.Rotar(transform, Rotacion)/.RotarCanva(rectTrans, Rotación)` (Tipo: Vacío): Rota un objeto de un punto al otro mediante una animación suave.
  - `return: Coroutine (Tipo: Vacío)`
- `Controlador.ColorSpriteRender(spriteRenderer/.ColorImage(image/.ColorCamara(camara/.ColorRender(Render/ColorText(TextMeshProGUI/ , color, duración))` (Tipo: Vacío): Cambia de un color a otro con suavidad.
  - `return: Coroutine (Tipo: Vacío)`
- `Controlador.IniciarEspera(nombre, duración)` (Tipo: Vacío): Inicia un tiempo de espera que dura una cantidad de tiempo.
  - `return: void (Tipo: Vacío)`
- `Controlador.Esperando(nombre)` (Tipo: Vacío): Te indica si la espera con ese nombre está activa.
  - `return: bool (Tipo: Vacío)`

**CLASES (4 CLASES):**
- `Movimiento(duración(float), destino(vector 3), animationCurve = defecto )`
- `Rotación:`
  - `Rotación(duración(float),ejeZ(int), animationCurve = defecto )`
  - `Rotación(duración(float), destino(quaternion), animationCurve = defecto )`

**Límites[COMPONENTE] (VARIABLES):**
- **Manual: izquierdo y derecho**: Asigna los límites manualmente.
- **Altura Automática**: Asigna automáticamente la altura de la cámara a los límites.
- **Instancia Defecto**: Instancia los bordes automáticamente. NOTA: Te obliga a tener la altura automática.

**MenuUI[COMPONENTE] (VARIABLES y FUNCIONES):**
- **VARIABLES:**
  - **Activar Tiempo**: Activa el tiempo al principio de cada escena.
  - **Botones**: Te permite asignar las teclas que quieras para realizar x funciones.
  - **reiniciar**: Reinicia la escena.
  - **pausar**: Alterna el tiempo entre pausado y play.

- **FUNCIONES:**
  - **MenuUI.CambioEscena(string escena / int escena)** (Tipo: Vacío): Cambia a la escena seleccionada.
  - **MenuUI.ReiniciarEscena()** (Tipo: Vacío): Reinicia la escena.
  - **MenuUI.AlternarEstado(GameObject objeto)** (Tipo: Vacío): Cambia entre activado y desactivado el gameobject.
  - **MenuUI.Activar(GameObject objeto)** (Tipo: Vacío): Activa el gameobject.
  - **MenuUI.Desactivar(GameObject objeto)** (Tipo: Vacío): Desactiva el gameobject.
  - **MenuUI.PausarTiempo(bool pausa)** (Tipo: Vacío): Selecciona

 si quieres pausar el tiempo.
  - **MenuUI.AlternarTiempo()** (Tipo: Vacío): Alterna entre pausa y play.
  - **MenuUI.AbrirURL(string url)** (Tipo: Vacío): Abre una URL.

**Save[VENTANA] (VARIABLES y FUNCIONES):**
- **VARIABLES:**
  - **Mensajes Confirmación**: Te manda logs de confirmación cuando ejecuta una acción.
  - **Data**: Puedes ver todas las variables que tienes.

- **VARIABLES[SCRIPT]:**
  - **Save.Data.variable** (Tipo: Vacío): Te permite acceder a las variables asignadas en el savescript para modificarlas.

- **FUNCIONES:**
  - **Save.Guardar()** (Tipo: Vacío): Guarda los datos.
  - **Save.Cargar()** (Tipo: Vacío): Carga los datos.
  - **Save.Eliminar()** (Tipo: Vacío): Elimina los datos.

**ColorMark[CLASE]:**
- Una clase para cambiar los colores de los elementos del hierarchy. Añade a los elementos en el nombre un carácter para que cambie el color. Colores defaults: ("!", rojo), ("?", azul), ("*", amarillo), ("-", negro), ("$", cyan), (“_”, blanco).
- Para cambiarlos tienes que meterte en el script ColorMark en BaboonLite/ColorMark.cs y añadir elementos en la lista.

**DictionaryBG[CLASE]:**
- **VARIABLES[DECLARAR]:**
  - `public DictionaryBG<T> nombre = new();`

- **FUNCIONES:**
  - **.Get(int indice) / .Get(int indice)** (Tipo: Vacío): Coge los datos del diccionario.
  - **.Add(string indice, T dato)** (Tipo: Vacío): Añade datos.
  - **.Inside(int indice) / .Inside(int indice)** (Tipo: Vacío): Te dice si tiene ese índice dentro del array.
