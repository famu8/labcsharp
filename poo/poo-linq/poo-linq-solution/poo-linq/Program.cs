using System;
using System.Runtime.ConstrainedExecution;
using System.Linq;

namespace poolinq
{
    internal class Program
    {
        class Patient
        {
            public int id { get; set; }
            public string name { get; set; }
            public string lastname { get; set; }
            public string sex { get; set; }
            public double temperature { get; set; }
            public int heartRate { get; set; }
            public string speciality { get; set; }
            public int age { get; set; }

        }


        public static void Main (string[] args)
        {
            Patient[] patients =
            {
                new Patient { id = 1, name= "John",lastname= "Doe", sex= "Male", temperature= 36.8, heartRate = 80,speciality = "general medicine",age= 44},
                new Patient { id = 2, name= "Jane",lastname= "Doe", sex= "Female", temperature= 36.8, heartRate = 70,speciality = "general medicine",age= 43},
                new Patient { id = 3, name= "Mary",lastname= "Wien", sex= "Female", temperature= 36.8, heartRate = 120,speciality = "general medicine",age= 20},
                new Patient { id = 4, name= "Junior",lastname= "Doe", sex= "Male", temperature= 36.8, heartRate = 90,speciality = "pediatrics",age= 8},
                new Patient { id = 5, name= "Scarlett",lastname= "Saez", sex= "Female", temperature= 36.8, heartRate = 110,speciality = "general medicine",age= 30},
                new Patient { id = 6, name= "Bryan",lastname= "Kid", sex= "Male", temperature= 39.8, heartRate = 80,speciality = "pediatrics",age= 11}
            };

            //1 - Extraer la lista de pacientes que sean de la especialidad pediatrics y que tengan menos de 10 años.
            //debe devolver junior
            Console.WriteLine("EJERCICIO 1");
            var patientsOfPedraticsAndUnderTenYears = patients.Where(patient => patient.speciality == "pediatrics" && patient.age < 10);
            foreach (var patient in patientsOfPedraticsAndUnderTenYears)
            {
                Console.WriteLine($"Paciente en pediatria y menor de 10 años => {patient.name}");
            }
            Console.WriteLine("===================\n");


            Console.WriteLine("EJERCICIO 2");
            //2 - Queremos activar el protocolo de urgencia si hay algún paciente con ritmo cardíaco mayor que 100 o temperatura mayor a 39.
            //debe devolver Scarlett, Mary y Bryan
            var patientsHighHeartRateOrHighTemperature = patients.Where(patient => patient.heartRate>100 || patient.temperature > 39);
            foreach (var patient in patientsHighHeartRateOrHighTemperature)
            {
                Console.WriteLine($"Paciente en protocolo de urgencia => {patient.name}");
            }
            Console.WriteLine("===================\n");


            //3 - No podemos atender a todos los pacientes hoy por lo que vamos a crear una nueva coleccion y reasignar a los pacientes de pediatrics a general medicine
            Console.WriteLine("EJERCICIO 3");
            // despues del ? se crea el paciente y si no se completa la query se deja el paciente como está (p)
            var newPatients = patients.Select(p => p.speciality == "pediatrics"
                                                                    ? new Patient
                                                                    {
                                                                        id = p.id,
                                                                        name = p.name,
                                                                        lastname = p.lastname,
                                                                        sex = p.sex,
                                                                        temperature = p.temperature,
                                                                        heartRate = p.heartRate,
                                                                        speciality = "general medicine",
                                                                        age = p.age
                                                                    }
                                                                    : p)
                                             .ToList();
            foreach (Patient p in newPatients)
            {
                Console.WriteLine(p.id + " - " + p.name + " " + p.lastname + " - " + p.speciality);
            }
            Console.WriteLine("===================\n");


            //4 - Queremos conocer de una sola consulta el numero de pacientes que estan asignado a general medicine y a pediatrics.
            Console.WriteLine("EJERCICIO 4");
            var specialitites = patients.GroupBy(patient => patient.speciality);
            foreach (var sp in specialitites)
            {
                Console.WriteLine($"Especialidad: {sp.Key} => {sp.Count()}");
            }
            Console.WriteLine("===================\n");


            //5 - Devuelve una lista nueva que por cada paciente se indique si tiene prioridad o no. Se tendrá prioridad si el ritmo cardiaco es mayor 100
            //o la temperatura es mayor a 39.
            Console.WriteLine("EJERCICIO 5");
            var prioridades = patients.Select(p => p.name + " => " + (p.heartRate > 100 || p.temperature > 39 ? "¡¡¡Prioridad!!!  <------": "No prioridad")).ToList();
            // Imprimir la lista de prioridades
            foreach (string prioridad in prioridades)
            {
                Console.WriteLine(prioridad);
            }
            Console.WriteLine("===================\n");


            //6 - Queremos conocer de una sola consulta La edad media de pacientes asignados a pediatrics y general medicine.
            Console.WriteLine("EJERCICIO 6");
            //primero se agrupa por especialidad y luego se selecciona la especialidad y la edad media
            var ageAvgBySpeciality = patients.GroupBy(p => p.speciality).Select(g => new { Speciality = g.Key, AgeAvg = g.Average(p => p.age) });
            foreach (var item in ageAvgBySpeciality)
            {
                Console.WriteLine($"Especialidad: {item.Speciality}, Edad media: {item.AgeAvg}");
            }
            Console.WriteLine("===================\n");
        }
    }
}