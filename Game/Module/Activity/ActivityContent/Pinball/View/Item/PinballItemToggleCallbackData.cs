using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006615 RID: 26133
	[NullableContext(1)]
	[Nullable(0)]
	internal class PinballItemToggleCallbackData : IPinballItemToggleCallback
	{
		// Token: 0x17009F55 RID: 40789
		// (get) Token: 0x060414FB RID: 267515 RVA: 0x010C0DA1 File Offset: 0x010BEFA1
		// (set) Token: 0x060414FC RID: 267516 RVA: 0x010C0DA9 File Offset: 0x010BEFA9
		public PinballItemView View { get; set; }

		// Token: 0x17009F56 RID: 40790
		// (get) Token: 0x060414FD RID: 267517 RVA: 0x010C0DB2 File Offset: 0x010BEFB2
		// (set) Token: 0x060414FE RID: 267518 RVA: 0x010C0DBA File Offset: 0x010BEFBA
		public EToggleState State { get; set; }

		// Token: 0x17009F57 RID: 40791
		// (get) Token: 0x060414FF RID: 267519 RVA: 0x010C0DC3 File Offset: 0x010BEFC3
		// (set) Token: 0x06041500 RID: 267520 RVA: 0x010C0DCB File Offset: 0x010BEFCB
		[Nullable(2)]
		public object Data { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
