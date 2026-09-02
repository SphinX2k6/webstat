using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002732 RID: 10034
public class RacingBetsDangoActivityOpenTips : UiViewBase
{
	// Token: 0x06013CC8 RID: 81096 RVA: 0x00582FF1 File Offset: 0x005811F1
	[NullableContext(1)]
	public RacingBetsDangoActivityOpenTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x06013CC9 RID: 81097 RVA: 0x00582FFA File Offset: 0x005811FA
	protected override void OnAfterShow()
	{
		base.CloseMe(null);
	}
}
