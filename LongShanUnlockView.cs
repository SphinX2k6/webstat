using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001359 RID: 4953
public class LongShanUnlockView : UiViewBase
{
	// Token: 0x060087A3 RID: 34723 RVA: 0x0023C259 File Offset: 0x0023A459
	[NullableContext(1)]
	public LongShanUnlockView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060087A4 RID: 34724 RVA: 0x0023C262 File Offset: 0x0023A462
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
