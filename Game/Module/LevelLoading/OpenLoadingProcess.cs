using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.LevelLoading
{
	// Token: 0x02005A14 RID: 23060
	[NullableContext(1)]
	[Nullable(0)]
	public class OpenLoadingProcess<[Nullable(2)] T> : PendingProcess<EProcessType>
	{
		// Token: 0x0603A635 RID: 239157 RVA: 0x00ECDE92 File Offset: 0x00ECC092
		public OpenLoadingProcess(ELoadingReason reason, T perform, Action callback, [Nullable(2)] string context, params object[] parameters) : base(EProcessType.OpenLoading)
		{
			this.Reason = reason;
			this.Perform = perform;
			this.Callback = callback;
			this.Context = context;
			this.Params = parameters;
		}

		// Token: 0x04021106 RID: 135430
		public ELoadingReason Reason;

		// Token: 0x04021107 RID: 135431
		public T Perform;

		// Token: 0x04021108 RID: 135432
		public Action Callback;

		// Token: 0x04021109 RID: 135433
		[Nullable(2)]
		public string Context;

		// Token: 0x0402110A RID: 135434
		public object[] Params;
	}
}
