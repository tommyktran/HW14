using System;
using System.Collections.Generic;

namespace _14a
{
    class Program
    {
        static void Main(string[] args)
        {
            var doctorHours = new List<int> { 7, 2, 4, 2 };
            var patientHours = new List<int> { 1, 2, 5, 3, 1, 2, 1 };

            Scheduler(doctorHours, patientHours);
        }

        static void Scheduler(List<int> doctors, List<int> patients)
        {
            var result = new List<string>();
            Scheduler(doctors, patients, result);
        }
        static bool Scheduler(List<int> doctors, List<int> patients, List<string> result)
        {
            if (patients.Count == 0)
            {
                foreach (string thing in result)
                {
                    Console.WriteLine(thing);
                }
                return true;
            }

            var newPatients = new List<int>(patients);
            var newDoctors = new List<int>(doctors);

            
            for (int j = 0; j < patients.Count; j++)
            {
                if (newDoctors[0] >= newPatients[j])
                {
                    result.Add("Doctor with " + newDoctors[0] + " hours takes patient with " + newPatients[j] + " hours");
                    newDoctors[0] -= newPatients[j];
                    newPatients.RemoveAt(j);
                    if (newDoctors[0] == 0)
                    {
                        newDoctors.RemoveAt(0);
                    }
                    if (Scheduler(newDoctors, newPatients, result))
                    {
                        return true;
                    }
                    newPatients = new List<int>(patients);
                    newDoctors = new List<int>(doctors);
                    result.RemoveAt(result.Count - 1);
                }
            }
            return false;
        }
    }
}
