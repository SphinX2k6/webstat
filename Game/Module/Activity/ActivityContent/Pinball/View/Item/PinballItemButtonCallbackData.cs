using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item
{
	// Token: 0x02006616 RID: 26134
	[NullableContext(1)]
	[Nullable(0)]
	internal class PinballItemButtonCallbackData : IPinballItemButtonCallback
	{
		// Token: 0x17009F58 RID: 40792
		// (get) Token: 0x06041502 RID: 267522 RVA: 0x010C0DDC File Offset: 0x010BEFDC
		// (set) Token: 0x06041503 RID: 267523 RVA: 0x010C0DE4 File Offset: 0x010BEFE4
		public PinballItemView View { get; set; }

		// Token: 0x17009F59 RID: 40793
		// (get) Token: 0x06041504 RID: 267524 RVA: 0x010C0DED File Offset: 0x010BEFED
		// (set) Token: 0x06041505 RID: 267525 RVA: 0x010C0DF5 File Offset: 0x010BEFF5
		[Nullable(2)]
		public object Data { [NullableContext(2)] get; [NullableContext(2)] set; }
	}
}
