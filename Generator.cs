using System;
using System.Collections.Generic;
using System.IO;

namespace AlCaponeJr_Gewinnspiel
{
    public class Generator
    {
        private List<int> teilnehmerZahlenList= new();
        private int[] teilnehmerZahlenArray;
        private List<int> gewinnspielZahlen = new();
        public int[,] wertungsmatrix = new int[1001, 2];

        public Generator()
        {
        }

        public void readTeilnehmerZahlen(String txtname)
        {
            //mac
            //String path = "/Users/martinheyne/Projects/AlCaponeJr_Gewinnspiel/AlCaponeJr_Gewinnspiel/" + txtname + ".txt"

            //win10
            String path = @"E:\Dokumente\VisualStudio\AlCaponeJr_Gewinnspiel\AlCaponeJr_Gewinnspiel\" + txtname + ".txt";

            teilnehmerZahlenList = stringArrayToIntList(File.ReadAllText(path).Split("\n"));
            teilnehmerZahlenList.Sort();
            teilnehmerZahlenArray = teilnehmerZahlenList.ToArray();
        }

        public List<int> stringArrayToIntList(String[] stringarray)
        {
            List<int> IntList = new();
            foreach(String str in stringarray){
                IntList.Add(Int32.Parse(str));
            }
            return IntList;
        }

        public void writeGewinnZahlen()
        {
            foreach(int i in gewinnspielZahlen)
            {
                Console.WriteLine(i);
            }
        }

        public void generateGewinnspielZahlen()
        {
            int zaehler = 0;
            int wertung;

            for (int i = 1; i <= 1000; i++)
            {
                    //0 to first number
                    if(zaehler == 0)
                    {
                        wertung = teilnehmerZahlenArray[zaehler] - i;
                    }
                    //last number to 1000
                    else if (zaehler == teilnehmerZahlenArray.Length)
                    {
                        wertung = i - teilnehmerZahlenArray[zaehler - 1];
                        zaehler--;
                    }
                    //current pointer to number
                    else if(teilnehmerZahlenArray[zaehler] - i < i - teilnehmerZahlenArray[zaehler - 1])
                    {
                        wertung = Math.Abs(teilnehmerZahlenArray[zaehler] - i);
                    }
                    //number to current pointer
                    else
                    {
                        wertung = Math.Abs(i - teilnehmerZahlenArray[zaehler - 1]);
                    }
                    
                    wertungsmatrix[i, 0] = i;
                    wertungsmatrix[i, 1] = wertung;

                    if (teilnehmerZahlenArray[zaehler] <= i)
                    {
                        zaehler++;    
                    }
                    
            }

            sortArrayOnSecondRow(wertungsmatrix);

            for (int i = 1; i <= 10; i++)
            {
                gewinnspielZahlen.Add(wertungsmatrix[i, 0]);
            }

            gewinnspielZahlen.Sort();  
        }

        private void sortArrayOnSecondRow(int[,] arr)
        {
            int temp0;
            int temp1;

            for (int i = 0; i < arr.Length/2; i++)
            {
                for (int j = 1; j < arr.Length/2 - 1; j++)
                {
                    if (arr[j,1] < arr[j + 1,1])
                    {
                        temp0 = arr[j + 1, 0];
                        arr[j + 1, 0] = arr[j, 0];
                        arr[j, 0] = temp0;

                        temp1 = arr[j + 1, 1];
                        arr[j + 1, 1] = arr[j, 1];
                        arr[j, 1] = temp1;
                    }
                }
            }
        }
    }
}
