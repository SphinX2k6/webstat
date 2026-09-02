using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;

// Token: 0x020014BE RID: 5310
[NullableContext(1)]
public interface IPinballItemButtonCallback
{
	// Token: 0x17000C84 RID: 3204
	// (get) Token: 0x060094AE RID: 38062
	// (set) Token: 0x060094AF RID: 38063
	PinballItemView View { get; set; }

	// Token: 0x17000C85 RID: 3205
	// (get) Token: 0x060094B0 RID: 38064
	// (set) Token: 0x060094B1 RID: 38065
	[Nullable(2)]
	object Data { [NullableContext(2)] get; [NullableContext(2)] set; }
}
