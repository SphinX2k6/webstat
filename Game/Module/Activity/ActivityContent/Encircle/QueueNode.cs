using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x0200685C RID: 26716
	[NullableContext(1)]
	[Nullable(0)]
	public class QueueNode : IQueueNode
	{
		// Token: 0x1700A19A RID: 41370
		// (get) Token: 0x0604297E RID: 272766 RVA: 0x01117DFA File Offset: 0x01115FFA
		// (set) Token: 0x0604297F RID: 272767 RVA: 0x01117E02 File Offset: 0x01116002
		public IHexPos Point { get; set; }

		// Token: 0x1700A19B RID: 41371
		// (get) Token: 0x06042980 RID: 272768 RVA: 0x01117E0B File Offset: 0x0111600B
		// (set) Token: 0x06042981 RID: 272769 RVA: 0x01117E13 File Offset: 0x01116013
		[Nullable(2)]
		public IQueueNode Next { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
