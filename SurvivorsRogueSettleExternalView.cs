using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02002B53 RID: 11091
public class SurvivorsRogueSettleExternalView : SurvivorsRogueSettleBaseView
{
	// Token: 0x060161F5 RID: 90613 RVA: 0x00623B28 File Offset: 0x00621D28
	[NullableContext(1)]
	public SurvivorsRogueSettleExternalView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060161F6 RID: 90614 RVA: 0x00623B31 File Offset: 0x00621D31
	protected override void OnClickBtnReturnMain()
	{
		base.CloseMe(null);
	}

	// Token: 0x060161F7 RID: 90615 RVA: 0x00623B3A File Offset: 0x00621D3A
	[NullableContext(2)]
	protected override ResultView GetViewInfo()
	{
		return this.OpenParam as ResultView;
	}
}
