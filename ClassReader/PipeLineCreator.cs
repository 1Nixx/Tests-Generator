using System.Threading.Tasks.Dataflow;
using ClassReader.Interfaces;
using ClassReader.Models;

namespace ClassReader
{
	public class PipeLineCreator : IPipeline, IPipelineCreator
	{
		private readonly Pipeline _pipeline = new();

		public void AddItem(IPipelineItem pipelineItem)
		{
			_pipeline.PropagatorBlock = pipelineItem;
		}

		public void AddSourseItem(ISourcePipelineItem pipelineItem)
		{
			_pipeline.SourceBlock = pipelineItem;
		}

		public void AddTargetItem(ITargetPipelineItem pipelineItem)
		{
			_pipeline.TargetBlock = pipelineItem;
		}

		public Task IsFinished()
		{
			return _pipeline.TargetBlock.IsFinished();
		}

		public void Run(string input)
		{
			var source = _pipeline.SourceBlock.GetItem();
			var action = _pipeline.PropagatorBlock.GetItem();
			var target = _pipeline.TargetBlock.GetItem();

			var opt = new DataflowLinkOptions { PropagateCompletion = true };

			source.LinkTo(action, opt);
			action.LinkTo(target, opt);

			_pipeline.SourceBlock.StartPipeline(input);
		}
	}
}
