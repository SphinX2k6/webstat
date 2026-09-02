using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02001FA2 RID: 8098
public class WeeklyRogueHandle : HudUnitHandleBase
{
	// Token: 0x0600F367 RID: 62311 RVA: 0x004289AD File Offset: 0x00426BAD
	protected override void OnDestroyed()
	{
		this.DestroyWeeklyRogueUnit();
	}

	// Token: 0x0600F368 RID: 62312 RVA: 0x004289B5 File Offset: 0x00426BB5
	protected override void OnAddEvents()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.WeeklyRogueBurstEnableChange, new Action<bool>(this.OnWeeklyRogueBurstEnableChange));
	}

	// Token: 0x0600F369 RID: 62313 RVA: 0x004289D3 File Offset: 0x00426BD3
	protected override void OnRemoveEvents()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.WeeklyRogueBurstEnableChange, new Action<bool>(this.OnWeeklyRogueBurstEnableChange));
	}

	// Token: 0x0600F36A RID: 62314 RVA: 0x004289F1 File Offset: 0x00426BF1
	private void OnWeeklyRogueBurstEnableChange(bool enable)
	{
		if (enable && this.WeeklyRogueUnit == null)
		{
			this.NewWeeklyRogueUnit();
			return;
		}
		if (this.WeeklyRogueUnit == null)
		{
			return;
		}
		this.WeeklyRogueUnit.SetVisible(enable, 0);
	}

	// Token: 0x0600F36B RID: 62315 RVA: 0x00428A1C File Offset: 0x00426C1C
	private void NewWeeklyRogueUnit()
	{
		base.NewHudUnitWithReturn<WeeklyRogueUnit>(typeof(WeeklyRogueUnit), "UiView_WeeklyRogueLink", out this.WeeklyRogueUnit, true, delegate(WeeklyRogueUnit _)
		{
		}, false);
		this.WeeklyRogueUnit.SetVisible(true, 0);
	}

	// Token: 0x0600F36C RID: 62316 RVA: 0x00428A72 File Offset: 0x00426C72
	private void DestroyWeeklyRogueUnit()
	{
		if (this.WeeklyRogueUnit == null)
		{
			return;
		}
		base.DestroyHudUnit(this.WeeklyRogueUnit);
		this.WeeklyRogueUnit = null;
	}

	// Token: 0x040074EA RID: 29930
	[Nullable(2)]
	private WeeklyRogueUnit WeeklyRogueUnit;
}
