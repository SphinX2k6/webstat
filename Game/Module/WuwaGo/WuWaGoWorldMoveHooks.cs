using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA8 RID: 19112
	[NullableContext(2)]
	[Nullable(0)]
	public class WuWaGoWorldMoveHooks : IWuWaGoWorldMoveHooks
	{
		// Token: 0x170084EA RID: 34026
		// (get) Token: 0x06031D5B RID: 204123 RVA: 0x00C79A27 File Offset: 0x00C77C27
		// (set) Token: 0x06031D5C RID: 204124 RVA: 0x00C79A2F File Offset: 0x00C77C2F
		public Action OnStart { get; set; }

		// Token: 0x170084EB RID: 34027
		// (get) Token: 0x06031D5D RID: 204125 RVA: 0x00C79A38 File Offset: 0x00C77C38
		// (set) Token: 0x06031D5E RID: 204126 RVA: 0x00C79A40 File Offset: 0x00C77C40
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Action<Vector> OnRunning { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170084EC RID: 34028
		// (get) Token: 0x06031D5F RID: 204127 RVA: 0x00C79A49 File Offset: 0x00C77C49
		// (set) Token: 0x06031D60 RID: 204128 RVA: 0x00C79A51 File Offset: 0x00C77C51
		public Action OnEnterSettle { get; set; }

		// Token: 0x170084ED RID: 34029
		// (get) Token: 0x06031D61 RID: 204129 RVA: 0x00C79A5A File Offset: 0x00C77C5A
		// (set) Token: 0x06031D62 RID: 204130 RVA: 0x00C79A62 File Offset: 0x00C77C62
		public Action OnFinish { get; set; }
	}
}
