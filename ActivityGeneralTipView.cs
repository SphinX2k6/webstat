using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001732 RID: 5938
public class ActivityGeneralTipView : UiViewBase
{
	// Token: 0x0600A59D RID: 42397 RVA: 0x002BC75C File Offset: 0x002BA95C
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600A59E RID: 42398 RVA: 0x002BC765 File Offset: 0x002BA965
	[NullableContext(1)]
	public ActivityGeneralTipView(UiViewInfo info) : base(info)
	{
	}
}
