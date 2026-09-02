using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.World.StepSequence
{
	// Token: 0x020046D3 RID: 18131
	[NullableContext(1)]
	[Nullable(0)]
	public class StepSequence
	{
		// Token: 0x0602F271 RID: 193137 RVA: 0x00B2C0F5 File Offset: 0x00B2A2F5
		public StepSequence AddStep(SequenceStep step)
		{
			this.Steps.Add(step);
			return this;
		}

		// Token: 0x0602F272 RID: 193138 RVA: 0x00B2C104 File Offset: 0x00B2A304
		public StepSequence SetOnAbort(Action handler)
		{
			this.OnAbortHandler = handler;
			return this;
		}

		// Token: 0x0602F273 RID: 193139 RVA: 0x00B2C10E File Offset: 0x00B2A30E
		public StepSequence SetFinally(Action handler)
		{
			this.FinallyHandler = handler;
			return this;
		}

		// Token: 0x0602F274 RID: 193140 RVA: 0x00B2C118 File Offset: 0x00B2A318
		[NullableContext(0)]
		private static UniTask<bool> RaceStep(UniTask stepResult, [Nullable(1)] ISequenceAbortSignal abortSignal)
		{
			StepSequence.<RaceStep>d__6 <RaceStep>d__;
			<RaceStep>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RaceStep>d__.stepResult = stepResult;
			<RaceStep>d__.abortSignal = abortSignal;
			<RaceStep>d__.<>1__state = -1;
			<RaceStep>d__.<>t__builder.Start<StepSequence.<RaceStep>d__6>(ref <RaceStep>d__);
			return <RaceStep>d__.<>t__builder.Task;
		}

		// Token: 0x0602F275 RID: 193141 RVA: 0x00B2C164 File Offset: 0x00B2A364
		public UniTask Run(ISequenceAbortSignal abortSignal)
		{
			StepSequence.<Run>d__7 <Run>d__;
			<Run>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Run>d__.<>4__this = this;
			<Run>d__.abortSignal = abortSignal;
			<Run>d__.<>1__state = -1;
			<Run>d__.<>t__builder.Start<StepSequence.<Run>d__7>(ref <Run>d__);
			return <Run>d__.<>t__builder.Task;
		}

		// Token: 0x0401ADB3 RID: 110003
		private readonly List<SequenceStep> Steps = new List<SequenceStep>();

		// Token: 0x0401ADB4 RID: 110004
		[Nullable(2)]
		private Action OnAbortHandler;

		// Token: 0x0401ADB5 RID: 110005
		[Nullable(2)]
		private Action FinallyHandler;
	}
}
