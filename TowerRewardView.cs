using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002C02 RID: 11266
public class TowerRewardView : UiViewBase
{
	// Token: 0x060167AF RID: 92079 RVA: 0x0063FB14 File Offset: 0x0063DD14
	[NullableContext(1)]
	public TowerRewardView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x060167B0 RID: 92080 RVA: 0x0063FB20 File Offset: 0x0063DD20
	protected unsafe override void OnRegisterComponent()
	{
		int num = 2;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060167B1 RID: 92081 RVA: 0x0063FB89 File Offset: 0x0063DD89
	protected override void OnStart()
	{
		this.RewardScroll = new GenericScrollViewNew<TowerRewardItem, TowerReward>(base.GetScrollViewWithScrollbar(0), new Func<TowerRewardItem>(this.RefreshItem), null, false, null);
		this.RefreshView();
	}

	// Token: 0x060167B2 RID: 92082 RVA: 0x0063FBB2 File Offset: 0x0063DDB2
	protected override void OnBeforeDestroy()
	{
		this.RewardScroll = null;
	}

	// Token: 0x060167B3 RID: 92083 RVA: 0x0063FBBB File Offset: 0x0063DDBB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRewardReceived, new Action(this.OnTowerRewardReceived));
	}

	// Token: 0x060167B4 RID: 92084 RVA: 0x0063FBD9 File Offset: 0x0063DDD9
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRewardReceived, new Action(this.OnTowerRewardReceived));
	}

	// Token: 0x060167B5 RID: 92085 RVA: 0x0063FBF8 File Offset: 0x0063DDF8
	private void RefreshView()
	{
		int difficulty = (int)(this.OpenParam ?? ModelBase<TowerModel>.Instance.CurrentSelectDifficulties);
		List<TowerReward> difficultyReward = ModelBase<TowerModel>.Instance.GetDifficultyReward(difficulty);
		if (difficultyReward == null)
		{
			return;
		}
		difficultyReward.Sort(delegate(TowerReward a, TowerReward b)
		{
			int num = (a.IsReceived.GetValueOrDefault() > false) ? 1 : 0;
			int num2 = (b.IsReceived.GetValueOrDefault() > false) ? 1 : 0;
			if (num != num2)
			{
				return num - num2;
			}
			return a.Index - b.Index;
		});
		this.RewardScroll.RefreshByData(difficultyReward, null, false);
		base.GetText(1).SetText(ModelBase<TowerModel>.Instance.GetDifficultyMaxStars(difficulty, false).ToString() + "/" + ModelBase<TowerModel>.Instance.GetDifficultyAllStars(difficulty, false).ToString(), true);
	}

	// Token: 0x060167B6 RID: 92086 RVA: 0x0063FCA6 File Offset: 0x0063DEA6
	[NullableContext(1)]
	private TowerRewardItem RefreshItem()
	{
		return new TowerRewardItem();
	}

	// Token: 0x060167B7 RID: 92087 RVA: 0x0063FCAD File Offset: 0x0063DEAD
	private void OnTowerRewardReceived()
	{
		this.RefreshView();
	}

	// Token: 0x0400ADFA RID: 44538
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericScrollViewNew<TowerRewardItem, TowerReward> RewardScroll;

	// Token: 0x02008EFF RID: 36607
	private enum EChildType
	{
		// Token: 0x04030099 RID: 196761
		ScrollView,
		// Token: 0x0403009A RID: 196762
		ReceivedStarText
	}
}
