using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Ui;

// Token: 0x02001DAB RID: 7595
public class TrapDefenseEventBossComingTips : UiViewBase
{
	// Token: 0x0600E024 RID: 57380 RVA: 0x003C49B9 File Offset: 0x003C2BB9
	[NullableContext(1)]
	public TrapDefenseEventBossComingTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E025 RID: 57381 RVA: 0x003C49C2 File Offset: 0x003C2BC2
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as ITrapDefenseBossComingTipsData);
	}

	// Token: 0x0600E026 RID: 57382 RVA: 0x003C49D5 File Offset: 0x003C2BD5
	protected override void OnFinishShow()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E027 RID: 57383 RVA: 0x003C49E0 File Offset: 0x003C2BE0
	protected override void OnBeforeDestroy()
	{
		ITrapDefenseBossComingTipsData data = this.Data;
		Action action = (data != null) ? data.Callback : null;
		if (action != null)
		{
			action();
		}
	}

	// Token: 0x04006B98 RID: 27544
	[Nullable(2)]
	protected ITrapDefenseBossComingTipsData Data;
}
