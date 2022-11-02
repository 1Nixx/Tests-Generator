using ClassReader;
using ClassReader.IOServices;
using Core;

const string input = @"C:\Универ\5 Семестр\СПП\Лаба 4\input";
const string output = @"C:\Универ\5 Семестр\СПП\Лаба 4\output";

var pipeline = new PipeLineCreator();

pipeline.AddSourseItem(new FileReader(5));
pipeline.AddItem(new TestGeneratorService(5));
pipeline.AddTargetItem(new FileWriter(5, output));

pipeline.Run(input);

await pipeline.IsFinished();

Console.ReadLine();