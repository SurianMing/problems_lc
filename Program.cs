using System.Reflection;
using LeetCode.SolutionRunner.Problems;

// See https://aka.ms/new-console-template for more information

Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(type => typeof(IProblem).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
    .Select(type => (IProblem)Activator.CreateInstance(type)!)
    .ToList()
    .ForEach(problem => problem.Run());