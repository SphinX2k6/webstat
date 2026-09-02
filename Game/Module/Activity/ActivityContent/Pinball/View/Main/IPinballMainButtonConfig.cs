using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Main
{
	// Token: 0x020065F3 RID: 26099
	[NullableContext(2)]
	public interface IPinballMainButtonConfig
	{
		// Token: 0x17009F26 RID: 40742
		// (get) Token: 0x06041329 RID: 267049
		// (set) Token: 0x0604132A RID: 267050
		EPinballMainButtonFunctionType Type { get; set; }

		// Token: 0x17009F27 RID: 40743
		// (get) Token: 0x0604132B RID: 267051
		// (set) Token: 0x0604132C RID: 267052
		int UiRegisterId { get; set; }

		// Token: 0x17009F28 RID: 40744
		// (get) Token: 0x0604132D RID: 267053
		// (set) Token: 0x0604132E RID: 267054
		int? FunctionId { get; set; }

		// Token: 0x17009F29 RID: 40745
		// (get) Token: 0x0604132F RID: 267055
		// (set) Token: 0x06041330 RID: 267056
		ERedDotName? RedDotName { get; set; }

		// Token: 0x17009F2A RID: 40746
		// (get) Token: 0x06041331 RID: 267057
		// (set) Token: 0x06041332 RID: 267058
		Func<bool> ShowRedDot { get; set; }

		// Token: 0x17009F2B RID: 40747
		// (get) Token: 0x06041333 RID: 267059
		// (set) Token: 0x06041334 RID: 267060
		Action<UUIText> SetTextCallback { get; set; }

		// Token: 0x17009F2C RID: 40748
		// (get) Token: 0x06041335 RID: 267061
		// (set) Token: 0x06041336 RID: 267062
		Action OnClickCallback { get; set; }

		// Token: 0x17009F2D RID: 40749
		// (get) Token: 0x06041337 RID: 267063
		// (set) Token: 0x06041338 RID: 267064
		Func<bool> ShowCallback { get; set; }
	}
}
