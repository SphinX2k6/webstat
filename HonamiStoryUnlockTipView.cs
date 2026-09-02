using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001F5A RID: 8026
public class HonamiStoryUnlockTipView : UiViewBase
{
	// Token: 0x0600F03F RID: 61503 RVA: 0x0041A4BB File Offset: 0x004186BB
	[NullableContext(1)]
	public HonamiStoryUnlockTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600F040 RID: 61504 RVA: 0x0041A4C4 File Offset: 0x004186C4
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
