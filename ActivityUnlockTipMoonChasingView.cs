using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x0200139E RID: 5022
public class ActivityUnlockTipMoonChasingView : UiViewBase
{
	// Token: 0x06008A48 RID: 35400 RVA: 0x002469FE File Offset: 0x00244BFE
	[NullableContext(1)]
	public ActivityUnlockTipMoonChasingView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06008A49 RID: 35401 RVA: 0x00246A07 File Offset: 0x00244C07
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
