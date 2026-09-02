using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001364 RID: 4964
public class SevenHillsUnlockTipView : UiViewBase
{
	// Token: 0x0600882C RID: 34860 RVA: 0x0023EE5D File Offset: 0x0023D05D
	[NullableContext(1)]
	public SevenHillsUnlockTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600882D RID: 34861 RVA: 0x0023EE66 File Offset: 0x0023D066
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
