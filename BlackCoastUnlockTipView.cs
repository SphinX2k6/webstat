using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001271 RID: 4721
public class BlackCoastUnlockTipView : UiViewBase
{
	// Token: 0x06007E0D RID: 32269 RVA: 0x002148DD File Offset: 0x00212ADD
	[NullableContext(1)]
	public BlackCoastUnlockTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007E0E RID: 32270 RVA: 0x002148E6 File Offset: 0x00212AE6
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
