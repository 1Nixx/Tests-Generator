using ClassReader;
using ClassReader.IOServices;
using Core;

const string input = @"..\..\..\..\..\Tests Generator\Tests\input";
const string output = @"..\..\..\..\..\Tests Generator\Tests\output";

var pipeline = new PipeLineCreator();

pipeline.AddSourseItem(new FileReader(10));
pipeline.AddItem(new TestGeneratorService(10));
pipeline.AddTargetItem(new FileWriter(10, output));

pipeline.Run(input);

await pipeline.IsFinished();

Console.ReadLine();