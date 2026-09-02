using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001C48 RID: 7240
public class FloroRanchUnlockTipView : UiViewBase
{
	// Token: 0x0600D326 RID: 54054 RVA: 0x00383E6D File Offset: 0x0038206D
	[NullableContext(1)]
	public FloroRanchUnlockTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x0600D327 RID: 54055 RVA: 0x00383E76 File Offset: 0x00382076
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
