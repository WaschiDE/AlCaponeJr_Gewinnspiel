using System;
using AlCaponeJr_Gewinnspiel;

namespace AlCaponeJr_Gewinnspiel
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator generator = new Generator();
            generator.readTeilnehmerZahlen("beispiel1");
            generator.generateGewinnspielZahlen();
            generator.writeGewinnZahlen();

        }
    }
}
