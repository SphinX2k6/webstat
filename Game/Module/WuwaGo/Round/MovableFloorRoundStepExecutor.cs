using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Round
{
	// Token: 0x02004AC5 RID: 19141
	[NullableContext(1)]
	[Nullable(0)]
	public class MovableFloorRoundStepExecutor : IRoundStepExecutor
	{
		// Token: 0x06031E72 RID: 204402 RVA: 0x00C7CF23 File Offset: 0x00C7B123
		public MovableFloorRoundStepExecutor(IWuWaGoGridMutationService gridMutationService, Func<int> getExecutionToken, [Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<IExecutableUnit, string> setCurrentProcess, [Nullable(new byte[]
		{
			2,
			1
		})] Func<IWuWaGoMovableFloorBatchResult, int, UniTask> onBatchFinished = null)
		{
		}

		// Token: 0x06031E73 RID: 204403 RVA: 0x00C7CF48 File Offset: 0x00C7B148
		public UniTask Execute(ERoundStep step, IReadOnlyList<IExecutableUnit> units, int executionToken)
		{
			MovableFloorRoundStepExecutor.<Execute>d__5 <Execute>d__;
			<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Execute>d__.<>4__this = this;
			<Execute>d__.units = units;
			<Execute>d__.executionToken = executionToken;
			<Execute>d__.<>1__state = -1;
			<Execute>d__.<>t__builder.Start<MovableFloorRoundStepExecutor.<Execute>d__5>(ref <Execute>d__);
			return <Execute>d__.<>t__builder.Task;
		}

		// Token: 0x0401D340 RID: 119616
		[CompilerGenerated]
		private IWuWaGoGridMutationService <gridMutationService>P = gridMutationService;

		// Token: 0x0401D341 RID: 119617
		[CompilerGenerated]
		private Func<int> <getExecutionToken>P = getExecutionToken;

		// Token: 0x0401D342 RID: 119618
		[Nullable(new byte[]
		{
			1,
			2,
			2
		})]
		[CompilerGenerated]
		private Action<IExecutableUnit, string> <setCurrentProcess>P = setCurrentProcess;

		// Token: 0x0401D343 RID: 119619
		[Nullable(new byte[]
		{
			2,
			1
		})]
		[CompilerGenerated]
		private Func<IWuWaGoMovableFloorBatchResult, int, UniTask> <onBatchFinished>P = onBatchFinished;
	}
}
