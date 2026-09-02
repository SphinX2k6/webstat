using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001BA4 RID: 7076
public class FeedbackRewardStartView : UiViewBase
{
	// Token: 0x0600CDD2 RID: 52690 RVA: 0x0036D472 File Offset: 0x0036B672
	[NullableContext(1)]
	public FeedbackRewardStartView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600CDD3 RID: 52691 RVA: 0x0036D47C File Offset: 0x0036B67C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickBtn));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600CDD4 RID: 52692 RVA: 0x0036D544 File Offset: 0x0036B744
	protected override void OnStart()
	{
		List<int> canFinishRewardId = ModelBase<FeedbackRewardModel>.Instance.GetCanFinishRewardId();
		if (canFinishRewardId.Count <= 0)
		{
			return;
		}
		int id = canFinishRewardId[canFinishRewardId.Count - 1];
		GivebackScoreReward? givebackScoreRewardById = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(id);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "FeedBackReward_StartView_Text", new <>z__ReadOnlyArray<object>(new object[]
		{
			ModelBase<FeedbackRewardModel>.Instance.CurrentPointCount,
			(givebackScoreRewardById != null) ? new int?(givebackScoreRewardById.GetValueOrDefault().Target) : null
		}));
		this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), new Func<CommonItemSmallItemGrid>(this.InitItem), null, false, true);
		List<TItem> list = new List<TItem>();
		foreach (int id2 in canFinishRewardId)
		{
			GivebackScoreReward? givebackScoreRewardById2 = ConfigBase<FeedbackRewardConfig>.Instance.GetGivebackScoreRewardById(id2);
			if (givebackScoreRewardById2 != null)
			{
				DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(givebackScoreRewardById2.Value.DropId);
				if (dropPackage != null)
				{
					using (Dictionary<int, int>.Enumerator enumerator2 = dropPackage.Value.DropPreview().GetEnumerator())
					{
						if (enumerator2.MoveNext())
						{
							KeyValuePair<int, int> keyValuePair = enumerator2.Current;
							int key = keyValuePair.Key;
							int value = keyValuePair.Value;
							TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value);
							list.Add(item);
						}
					}
				}
			}
		}
		this.RewardLayout.RefreshByData(list, delegate
		{
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in (((rewardLayout != null) ? rewardLayout.GetLayoutItemList() : null) ?? new List<CommonItemSmallItemGrid>()))
			{
				commonItemSmallItemGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
				commonItemSmallItemGrid.SetAllowClickBack(false);
			}
		}, false);
	}

	// Token: 0x0600CDD5 RID: 52693 RVA: 0x0036D71C File Offset: 0x0036B91C
	protected override void OnBeforeShow()
	{
		ControllerBase<SplashScreenController>.Instance.FinishCurTask(ESplashScreenSourceModuleType.FeedbackReward);
	}

	// Token: 0x0600CDD6 RID: 52694 RVA: 0x0036D729 File Offset: 0x0036B929
	[NullableContext(1)]
	private CommonItemSmallItemGrid InitItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x0600CDD7 RID: 52695 RVA: 0x0036D730 File Offset: 0x0036B930
	private void OnClickBtn()
	{
		base.CloseMe(null);
		Singleton<UiManager>.Instance.OpenView(EUiViewName.FeedbackRewardMainView, null, null);
	}

	// Token: 0x04006247 RID: 25159
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x02007E8F RID: 32399
	private enum ECompDefine
	{
		// Token: 0x0402B1CF RID: 176591
		Button,
		// Token: 0x0402B1D0 RID: 176592
		PointText,
		// Token: 0x0402B1D1 RID: 176593
		RewardLayout
	}
}
