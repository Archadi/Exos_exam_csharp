﻿using GAF;
using GAF.Extensions;
using GAF.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoGen
{
    class Program
    {
        private static List<City> cities;
        static void Main(string[] args)
        {
            cities = new List<City>
            {
                new City("Birmingham", 52.486125, -1.890507),
                new City("Bristol", 51.460852, -2.588139),
                new City("London", 51.512161, -0.116215),
                new City("Leeds", 53.803895, -1.549931),
                new City("Manchester", 53.478239, -2.258549),
                new City("Liverpool", 53.409532, -3.000126),
                new City("Hull", 53.751959, -0.335941),
                new City("Newcastle", 54.980766, -1.615849),
                new City("Carlisle", 54.892406, -2.923222),
                new City("Edinburgh", 55.958426, -3.186893),
                new City("Glasgow", 55.862982, -4.263554),
                new City("Cardiff", 51.488224, -3.186893),
                new City("Swansea", 51.624837, -3.94495),
                new City("Exeter", 50.726024, -3.543949),
                new City("Falmouth", 50.152266, -5.065556),
                new City("Canterbury", 51.289406, 1.075802)
            };




            var population = new Population();



            //create the chromosomes
            for (var p = 0; p < 100; p++)
            {



                var chromosome = new Chromosome();
                for (var g = 0; g < 16; g++)
                {
                    chromosome.Genes.Add(new Gene(g));
                }
                chromosome.Genes.ShuffleFast();
                population.Solutions.Add(chromosome);
            }

            foreach (Chromosome c in population.Solutions)
            {
                Console.WriteLine(c.Id);
                foreach (Gene g in c.Genes)
                {
                    Console.Write(g.RealValue);
                    Console.Write("  ");
                }
                Console.WriteLine("");
            }

            //create the elite operator
            var elite = new Elite(5);


            //create the crossover operator
            var crossover = new Crossover(0.8)
            {
                CrossoverType = CrossoverType.DoublePointOrdered
            };

            //create the mutation operator
            var mutate = new SwapMutate(0.02);

            //create the GA
            var ga = new GeneticAlgorithm(population, CalculateFitness);

            //hook up to some useful events
            ga.OnGenerationComplete += ga_OnGenerationComplete;
            ga.OnRunComplete += ga_OnRunComplete;

            //add the operators
            ga.Operators.Add(elite);
            ga.Operators.Add(crossover);
            ga.Operators.Add(mutate);

            //run the GA

            ga.Run(Terminate);
            Console.ReadLine();

        }

        static void ga_OnRunComplete(object sender, GaEventArgs e)
        {

            var fittest = e.Population.GetTop(1)[0];
            foreach (var gene in fittest.Genes)
            {
                Console.WriteLine(cities[(int)gene.RealValue].Name);
            }
        }

        private static void ga_OnGenerationComplete(object sender, GaEventArgs e)
        {
            var fittest = e.Population.GetTop(1)[0];
            var distanceToTravel = CalculateDistance(fittest);
            Console.WriteLine("Generation: {0}, Fitness: {1}, Distance: {2}", e.Generation, fittest.Fitness, distanceToTravel);
        }



        public static double CalculateFitness(Chromosome chromosome)
        {
            var distanceToTravel = CalculateDistance(chromosome);
            return 1 - distanceToTravel / 10000;
        }

        private static double CalculateDistance(Chromosome chromosome)
        {
            var distanceToTravel = 0.0;
            City previousCity = null;

            //run through each city in the order specified in the chromosome
            foreach (var gene in chromosome.Genes)
            {
                var currentCity = cities[(int)gene.RealValue];

                if (previousCity != null)
                {
                    var distance = previousCity.GetDistanceFromPosition(currentCity.Latitude, currentCity.Longitude);

                    distanceToTravel += distance;
                }

                previousCity = currentCity;
            }

            return distanceToTravel;
        }

        public static bool Terminate(Population population,
            int currentGeneration, long currentEvaluation)
        {
            return currentGeneration > 400;
        }
    }
}
