using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002D3B RID: 11579
public class WeeklyRogueSettleInfoPanelItem : GridProxyAbstract<WeeklyRogueSettleInfoItemData>
{
	// Token: 0x060175CA RID: 95690 RVA: 0x0067A298 File Offset: 0x00678498
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUISprite)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText))
		};
	}

	// Token: 0x060175CB RID: 95691 RVA: 0x0067A320 File Offset: 0x00678520
	public override void Refresh(WeeklyRogueSettleInfoItemData data, bool isSelected, int gridIndex)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.Title, Array.Empty<object>());
		base.GetText(2).SetText(data.Content, true);
		if (data.IsScoreUp)
		{
			WeeklyRogueData activityDataNew = ModelBase<WeeklyRogueModel>.Instance.ActivityDataNew;
			if (activityDataNew == null)
			{
				return;
			}
			if (activityDataNew.GetCycleConfig() == null)
			{
				return;
			}
			int scoreRate = activityDataNew.GetScoreRate();
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), "WeRougeFormationIntegralMultiplier", new <>z__ReadOnlySingleElementList<object>(scoreRate));
		}
		UUIItem item = base.GetItem(3);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(data.IsScoreUp);
	}

	// Token: 0x02008FFE RID: 36862
	private enum EWeeklyRogueSettleInfoPanelItemDefine
	{
		// Token: 0x040304F8 RID: 197880
		SpriteBg,
		// Token: 0x040304F9 RID: 197881
		TxtTitle,
		// Token: 0x040304FA RID: 197882
		TxtContent,
		// Token: 0x040304FB RID: 197883
		ScoreUpItem,
		// Token: 0x040304FC RID: 197884
		TxtScoreUp
	}
}
