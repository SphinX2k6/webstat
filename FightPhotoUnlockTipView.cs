using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001331 RID: 4913
public class FightPhotoUnlockTipView : UiViewBase
{
	// Token: 0x0600861E RID: 34334 RVA: 0x0023574F File Offset: 0x0023394F
	[NullableContext(1)]
	public FightPhotoUnlockTipView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600861F RID: 34335 RVA: 0x00235758 File Offset: 0x00233958
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
