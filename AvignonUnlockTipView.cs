using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x020011CE RID: 4558
public class AvignonUnlockTipView : UiViewBase
{
	// Token: 0x06007845 RID: 30789 RVA: 0x001F77B3 File Offset: 0x001F59B3
	[NullableContext(1)]
	public AvignonUnlockTipView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06007846 RID: 30790 RVA: 0x001F77BC File Offset: 0x001F59BC
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
