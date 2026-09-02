using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GameMainView.TrapDefense;
using CSharpScript.Game.Ui;

// Token: 0x02001DAD RID: 7597
public class TrapDefenseEventTerrainChangeTips : UiViewBase
{
	// Token: 0x0600E02C RID: 57388 RVA: 0x003C4A59 File Offset: 0x003C2C59
	[NullableContext(1)]
	public TrapDefenseEventTerrainChangeTips(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600E02D RID: 57389 RVA: 0x003C4A62 File Offset: 0x003C2C62
	protected override void OnStart()
	{
		this.Data = (this.OpenParam as ITrapDefenseTerrainChangeTipsData);
	}

	// Token: 0x0600E02E RID: 57390 RVA: 0x003C4A75 File Offset: 0x003C2C75
	protected override void OnFinishShow()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600E02F RID: 57391 RVA: 0x003C4A80 File Offset: 0x003C2C80
	protected override void OnBeforeDestroy()
	{
		ITrapDefenseTerrainChangeTipsData data = this.Data;
		Action action = (data != null) ? data.Callback : null;
		if (action != null)
		{
			action();
		}
	}

	// Token: 0x04006B9A RID: 27546
	[Nullable(2)]
	protected ITrapDefenseTerrainChangeTipsData Data;
}
