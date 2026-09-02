using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.World.StepSequence
{
	// Token: 0x020046D1 RID: 18129
	[NullableContext(1)]
	[Nullable(0)]
	public class SequenceContext
	{
		// Token: 0x0602F269 RID: 193129 RVA: 0x00B2C09E File Offset: 0x00B2A29E
		public SequenceContext(ISequenceAbortSignal abortSignal)
		{
			this.AbortSignal = abortSignal;
		}

		// Token: 0x0602F26A RID: 193130 RVA: 0x00B2C0B0 File Offset: 0x00B2A2B0
		public void Stop()
		{
			Singleton<Log>.Instance.Info(ELogModule.World, ELogAuthor.ZYL, "StepSequence:请求提前结束(Stop)", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.StopRequested = true;
		}

		// Token: 0x1700811B RID: 33051
		// (get) Token: 0x0602F26B RID: 193131 RVA: 0x00B2C0E0 File Offset: 0x00B2A2E0
		public bool IsStopRequested
		{
			get
			{
				return this.StopRequested;
			}
		}

		// Token: 0x0602F26C RID: 193132 RVA: 0x00B2C0E8 File Offset: 0x00B2A2E8
		public void Abort()
		{
			this.AbortSignal.Abort();
		}

		// Token: 0x0401ADB1 RID: 110001
		private bool StopRequested;

		// Token: 0x0401ADB2 RID: 110002
		private readonly ISequenceAbortSignal AbortSignal;
	}
}
