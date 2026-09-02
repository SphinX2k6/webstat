using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001F4E RID: 8014
public class HonamiStorySafeLeaveUpdateView : UiViewBase
{
	// Token: 0x0600EFFB RID: 61435 RVA: 0x0041957B File Offset: 0x0041777B
	[NullableContext(1)]
	public HonamiStorySafeLeaveUpdateView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EFFC RID: 61436 RVA: 0x00419584 File Offset: 0x00417784
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
