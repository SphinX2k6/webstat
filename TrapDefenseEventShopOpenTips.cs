using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Ui;

// Token: 0x02001DAC RID: 7596
public class TrapDefenseEventShopOpenTips : UiViewBase
{
	// Token: 0x0600E028 RID: 57384 RVA: 0x003C4A09 File Offset: 0x003C2C09
	[NullableContext(1)]
	public TrapDefenseEventShopOpenTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E029 RID: 57385 RVA: 0x003C4A12 File Offset: 0x003C2C12
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as ITrapDefenseShopTipsData);
	}

	// Token: 0x0600E02A RID: 57386 RVA: 0x003C4A25 File Offset: 0x003C2C25
	protected override void OnFinishShow()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E02B RID: 57387 RVA: 0x003C4A30 File Offset: 0x003C2C30
	protected override void OnBeforeDestroy()
	{
		ITrapDefenseShopTipsData data = this.Data;
		Action action = (data != null) ? data.Callback : null;
		if (action != null)
		{
			action();
		}
	}

	// Token: 0x04006B99 RID: 27545
	[Nullable(2)]
	protected ITrapDefenseShopTipsData Data;
}
