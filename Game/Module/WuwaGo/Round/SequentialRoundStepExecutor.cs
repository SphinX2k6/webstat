using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Round
{
	// Token: 0x02004AC7 RID: 19143
	[NullableContext(1)]
	[Nullable(0)]
	public class SequentialRoundStepExecutor : IRoundStepExecutor
	{
		// Token: 0x06031E91 RID: 204433 RVA: 0x00C7D755 File Offset: 0x00C7B955
		public SequentialRoundStepExecutor([Nullable(new byte[]
		{
			1,
			2,
			1
		})] Func<ERoundStep, IReadOnlyList<IExecutableUnit>> getRegisteredUnits, Func<int> getExecutionToken, [Nullable(new byte[]
		{
			1,
			2,
			2
		})] Action<IExecutableUnit, string> setCurrentProcess, Func<int, bool> shouldAbortRound)
		{
		}

		// Token: 0x06031E92 RID: 204434 RVA: 0x00C7D77C File Offset: 0x00C7B97C
		public UniTask Execute(ERoundStep step, IReadOnlyList<IExecutableUnit> units, int executionToken)
		{
			SequentialRoundStepExecutor.<Execute>d__5 <Execute>d__;
			<Execute>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Execute>d__.<>4__this = this;
			<Execute>d__.step = step;
			<Execute>d__.units = units;
			<Execute>d__.executionToken = executionToken;
			<Execute>d__.<>1__state = -1;
			<Execute>d__.<>t__builder.Start<SequentialRoundStepExecutor.<Execute>d__5>(ref <Execute>d__);
			return <Execute>d__.<>t__builder.Task;
		}

		// Token: 0x0401D34F RID: 119631
		[Nullable(new byte[]
		{
			1,
			2,
			1
		})]
		[CompilerGenerated]
		private Func<ERoundStep, IReadOnlyList<IExecutableUnit>> <getRegisteredUnits>P = getRegisteredUnits;

		// Token: 0x0401D350 RID: 119632
		[CompilerGenerated]
		private Func<int> <getExecutionToken>P = getExecutionToken;

		// Token: 0x0401D351 RID: 119633
		[Nullable(new byte[]
		{
			1,
			2,
			2
		})]
		[CompilerGenerated]
		private Action<IExecutableUnit, string> <setCurrentProcess>P = setCurrentProcess;

		// Token: 0x0401D352 RID: 119634
		[CompilerGenerated]
		private Func<int, bool> <shouldAbortRound>P = shouldAbortRound;
	}
}
