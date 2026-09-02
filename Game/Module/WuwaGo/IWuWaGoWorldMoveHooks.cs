using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo
{
	// Token: 0x02004AA7 RID: 19111
	[NullableContext(2)]
	public interface IWuWaGoWorldMoveHooks
	{
		// Token: 0x170084E6 RID: 34022
		// (get) Token: 0x06031D53 RID: 204115
		// (set) Token: 0x06031D54 RID: 204116
		Action OnStart { get; set; }

		// Token: 0x170084E7 RID: 34023
		// (get) Token: 0x06031D55 RID: 204117
		// (set) Token: 0x06031D56 RID: 204118
		[Nullable(new byte[]
		{
			2,
			1
		})]
		Action<Vector> OnRunning { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }

		// Token: 0x170084E8 RID: 34024
		// (get) Token: 0x06031D57 RID: 204119
		// (set) Token: 0x06031D58 RID: 204120
		Action OnEnterSettle { get; set; }

		// Token: 0x170084E9 RID: 34025
		// (get) Token: 0x06031D59 RID: 204121
		// (set) Token: 0x06031D5A RID: 204122
		Action OnFinish { get; set; }
	}
}
