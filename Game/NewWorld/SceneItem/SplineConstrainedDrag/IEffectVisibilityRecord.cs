using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem.SplineConstrainedDrag
{
	// Token: 0x0200481C RID: 18460
	[NullableContext(2)]
	public interface IEffectVisibilityRecord
	{
		// Token: 0x17008228 RID: 33320
		// (get) Token: 0x060300A2 RID: 196770
		// (set) Token: 0x060300A3 RID: 196771
		[Nullable(1)]
		DragPlayEffectVisibilityProvider Provider { [NullableContext(1)] get; [NullableContext(1)] set; }

		// Token: 0x17008229 RID: 33321
		// (get) Token: 0x060300A4 RID: 196772
		// (set) Token: 0x060300A5 RID: 196773
		IGuidePathVisibilityHost Attached { get; set; }

		// Token: 0x1700822A RID: 33322
		// (get) Token: 0x060300A6 RID: 196774
		// (set) Token: 0x060300A7 RID: 196775
		Action CancelPending { get; set; }
	}
}
