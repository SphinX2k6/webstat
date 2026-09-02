using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x0200168D RID: 5773
[NullableContext(1)]
[Nullable(0)]
public class WheelTowerSeasonScoreProgressItem : UiPanelBase
{
	// Token: 0x0600A117 RID: 41239 RVA: 0x002A4498 File Offset: 0x002A2698
	protected unsafe override void OnRegisterComponent()
	{
		int num = 4;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A118 RID: 41240 RVA: 0x002A4543 File Offset: 0x002A2743
	protected override void OnStart()
	{
		this.ScoreRewardLayout = new GenericLayout<WheelTowerSeasonScoreItem, IWheelTowerSeasonScoreData>(base.GetHorizontalLayout(2), new Func<WheelTowerSeasonScoreItem>(this.InitScoreItem), base.GetItem(3).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600A119 RID: 41241 RVA: 0x002A4576 File Offset: 0x002A2776
	private WheelTowerSeasonScoreItem InitScoreItem()
	{
		return new WheelTowerSeasonScoreItem
		{
			OnClickToGet = this.OnClickToGet
		};
	}

	// Token: 0x0600A11A RID: 41242 RVA: 0x002A458C File Offset: 0x002A278C
	public void Refresh(int curScore, List<IWheelTowerSeasonScoreData> rewardList)
	{
		if (rewardList.Count == 0)
		{
			return;
		}
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText(curScore.ToString(), true);
		}
		GenericLayout<WheelTowerSeasonScoreItem, IWheelTowerSeasonScoreData> scoreRewardLayout = this.ScoreRewardLayout;
		if (scoreRewardLayout != null)
		{
			scoreRewardLayout.RefreshByData(rewardList, null, false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTower_SeasonScore_TotalScore", Array.Empty<object>());
	}

	// Token: 0x04004AF5 RID: 19189
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<WheelTowerSeasonScoreItem, IWheelTowerSeasonScoreData> ScoreRewardLayout;

	// Token: 0x04004AF6 RID: 19190
	[Nullable(2)]
	public Action OnClickToGet;
}
