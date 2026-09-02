using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Item;
using UnrealEngine;

// Token: 0x020014BD RID: 5309
[NullableContext(1)]
public interface IPinballItemToggleCallback
{
	// Token: 0x17000C81 RID: 3201
	// (get) Token: 0x060094A8 RID: 38056
	// (set) Token: 0x060094A9 RID: 38057
	PinballItemView View { get; set; }

	// Token: 0x17000C82 RID: 3202
	// (get) Token: 0x060094AA RID: 38058
	// (set) Token: 0x060094AB RID: 38059
	EToggleState State { get; set; }

	// Token: 0x17000C83 RID: 3203
	// (get) Token: 0x060094AC RID: 38060
	// (set) Token: 0x060094AD RID: 38061
	[Nullable(2)]
	object Data { [NullableContext(2)] get; [NullableContext(2)] set; }
}
