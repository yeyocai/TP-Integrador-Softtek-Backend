# TP-Integrador-Softtek-Backend C#
El proyecto está desarrollado con Net Core 6
​
## **Especificación de la Arquitectura**
​
### **Capa Controller**
Será el punto de entrada a la API. En los controladores deberíamos definir la menor cantidad de lógica posible y utilizarlos como un pasamanos con la capa de servicios.
​
### **Capa DataAccess**
Es donde definiremos el DbContext y crearemos los seeds correspondientes para probar nuestras entidades.
​
### **Capa Entities**
En este nivel de la arquitectura definiremos todas las entidades de la base de datos.
​
### **Capa Repositories**
En esta capa definiremos las clases correspondientes para realizar el repositorio genérico y la unidad de trabajo
​

​
## **Especificación de GIT**
​
* Se deberán crear las ramas a partir de develop. La nomenclatura para el nombre de las ramas será la sigueinte: feature/NombreDeLaFeature
