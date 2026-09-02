using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A15 RID: 23061
	[NullableContext(1)]
	[Nullable(0)]
	public class CloseLoadingProcess : PendingProcess<EProcessType>
	{
		// Token: 0x0603A636 RID: 239158 RVA: 0x00ECDEC0 File Offset: 0x00ECC0C0
		public CloseLoadingProcess(ELoadingReason reason, Action callback, float? duration = null, [Nullable(2)] string context = null) : base(EProcessType.CloseLoading)
		{
			this.Reason = reason;
			this.Callback = callback;
			this.Duration = duration.GetValueOrDefault(1f);
			this.Context = context;
		}

		// Token: 0x0402110B RID: 135435
		public ELoadingReason Reason;

		// Token: 0x0402110C RID: 135436
		public Action Callback;

		// Token: 0x0402110D RID: 135437
		public float Duration;

		// Token: 0x0402110E RID: 135438
		[Nullable(2)]
		public string Context;
	}
}
