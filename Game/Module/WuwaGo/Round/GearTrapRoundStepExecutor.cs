using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Round
{
	// Token: 0x02004AC4 RID: 19140
	[NullableContext(1)]
	[Nullable(0)]
	public class GearTrapRoundStepExecutor : IRoundStepExecutor
	{
		// Token: 0x06031E70 RID: 204400 RVA: 0x00C7CEAB File Offset: 0x00C7B0AB
		public GearTrapRoundStepExecutor([Nullable(new byte[]
		{
			1,
			2,
			1
		})] Func<ERoundStep, IReadOnlyList<IExecutableUnit>> getRegisteredUnits, Func<int> getExecutionToken, [Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<IExecutableUnit, string> setCurrentProcess)
		{
		}

		// Token: 0x06031E71 RID: 204401 RVA: 0x00C7CEC8 File Offset: 0x00C7B0C8
		public UniTask Execute(ERoundStep step, IReadOnlyList<IExecutableUnit> units, int executionToken)
		{
			GearTrapRoundStepExecutor.<Execute>d__4 <Execute>d__;
			<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Execute>d__.<>4__this = this;
			<Execute>d__.step = step;
			<Execute>d__.units = units;
			<Execute>d__.executionToken = executionToken;
			<Execute>d__.<>1__state = -1;
			<Execute>d__.<>t__builder.Start<GearTrapRoundStepExecutor.<Execute>d__4>(ref <Execute>d__);
			return <Execute>d__.<>t__builder.Task;
		}

		// Token: 0x0401D33D RID: 119613
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		[CompilerGenerated]
		private Func<ERoundStep, IReadOnlyList<IExecutableUnit>> <getRegisteredUnits>P = getRegisteredUnits;

		// Token: 0x0401D33E RID: 119614
		[CompilerGenerated]
		private Func<int> <getExecutionToken>P = getExecutionToken;

		// Token: 0x0401D33F RID: 119615
		[Nullable(new byte[]
		{
			1,
			2,
			2
		})]
		[CompilerGenerated]
		private Action<IExecutableUnit, string> <setCurrentProcess>P = setCurrentProcess;
	}
}
