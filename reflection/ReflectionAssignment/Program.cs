using System;
using System.Reflection;

namespace ReflectionAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Assembly Path (.dll or .exe): ");
            string path = Console.ReadLine();

            try
            {
                Assembly assembly = Assembly.LoadFrom(path);

                Console.WriteLine("\n========== ASSEMBLY INFORMATION ==========");
                Console.WriteLine("Assembly Name : " + assembly.GetName().Name);

                Console.WriteLine("\n========== MODULE INFORMATION ==========");
                foreach (Module module in assembly.GetModules())
                {
                    Console.WriteLine("Module Name : " + module.Name);
                }

                Console.WriteLine("\n========== CLASS INFORMATION ==========");

                foreach (Type type in assembly.GetTypes())
                {
                    Console.WriteLine("\nClass Name : " + type.Name);

                    Console.WriteLine("\nConstructors:");

                    foreach (ConstructorInfo constructor in type.GetConstructors())
                    {
                        Console.Write("   " + constructor.Name + "(");

                        ParameterInfo[] parameters = constructor.GetParameters();

                        for (int i = 0; i < parameters.Length; i++)
                        {
                            Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);

                            if (i < parameters.Length - 1)
                                Console.Write(", ");
                        }

                        Console.WriteLine(")");
                    }

                    Console.WriteLine("\nProperties:");

                    foreach (PropertyInfo property in type.GetProperties())
                    {
                        Console.WriteLine("   " + property.PropertyType.Name + " " + property.Name);
                    }

                    Console.WriteLine("\nMethods:");

                    foreach (MethodInfo method in type.GetMethods())
                    {
                        if (method.DeclaringType == type)
                        {
                            Console.Write("   " + method.ReturnType.Name + " " + method.Name + "(");

                            ParameterInfo[] parameters = method.GetParameters();

                            for (int i = 0; i < parameters.Length; i++)
                            {
                                Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);

                                if (i < parameters.Length - 1)
                                    Console.Write(", ");
                            }

                            Console.WriteLine(")");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}