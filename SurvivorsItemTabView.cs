using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B2C RID: 11052
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SurvivorsItemTabView : SurvivorsTabViewBase<SurvivorsItemTabItem, SurvivorsRogueItemCard>
{
	// Token: 0x17001CBC RID: 7356
	// (get) Token: 0x060160EA RID: 90346 RVA: 0x0061EFCF File Offset: 0x0061D1CF
	protected override ESurvivorsRogueItemType ItemType
	{
		get
		{
			return ESurvivorsRogueItemType.Normal;
		}
	}

	// Token: 0x060160EB RID: 90347 RVA: 0x0061EFD4 File Offset: 0x0061D1D4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x060160EC RID: 90348 RVA: 0x0061F07C File Offset: 0x0061D27C
	protected override UniTask InitSubComponents()
	{
		SurvivorsItemTabView.<InitSubComponents>d__4 <InitSubComponents>d__;
		<InitSubComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSubComponents>d__.<>4__this = this;
		<InitSubComponents>d__.<>1__state = -1;
		<InitSubComponents>d__.<>t__builder.Start<SurvivorsItemTabView.<InitSubComponents>d__4>(ref <InitSubComponents>d__);
		return <InitSubComponents>d__.<>t__builder.Task;
	}

	// Token: 0x060160ED RID: 90349 RVA: 0x0061F0BF File Offset: 0x0061D2BF
	protected override void OnBeforeDestroy()
	{
		SurvivorsRogueCardBase propDetailItem = this.PropDetailItem;
		if (propDetailItem != null)
		{
			propDetailItem.Destroy(null);
		}
		this.PropDetailItem = null;
	}

	// Token: 0x060160EE RID: 90350 RVA: 0x0061F0DA File Offset: 0x0061D2DA
	protected override int GetLoopItemIndex()
	{
		return 3;
	}

	// Token: 0x060160EF RID: 90351 RVA: 0x0061F0DD File Offset: 0x0061D2DD
	protected override int GetLoopScrollComponentIndex()
	{
		return 1;
	}

	// Token: 0x060160F0 RID: 90352 RVA: 0x0061F0E0 File Offset: 0x0061D2E0
	protected override SurvivorsItemTabItem CreateLoopItem()
	{
		SurvivorsItemTabItem survivorsItemTabItem = new SurvivorsItemTabItem();
		survivorsItemTabItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(base.OnCanClickItem));
		survivorsItemTabItem.OnClickCallBack = new Action<SurvivorsRogueItemCard, SurvivorsItemTabItem>(base.OnItemClick);
		return survivorsItemTabItem;
	}

	// Token: 0x060160F1 RID: 90353 RVA: 0x0061F10C File Offset: 0x0061D30C
	protected override IReadOnlyList<SurvivorsRogueItemCard> GenerateItemUiDataList()
	{
		int actId = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.ActId;
		IEnumerable<SurvivorsItem> allSurvivorsItemByActId = ConfigBase<SurvivorsRogueConfig>.Instance.GetAllSurvivorsItemByActId(actId);
		List<SurvivorsRogueItemCard> list = new List<SurvivorsRogueItemCard>();
		foreach (SurvivorsItem survivorsItem in allSurvivorsItemByActId)
		{
			SurvivorsRogueItemCard survivorsRogueItemCard = SurvivorsRogueCardDataFactory.CreateGeneralItem(survivorsItem.Id);
			if (survivorsRogueItemCard == null)
			{
				return Array.Empty<SurvivorsRogueItemCard>();
			}
			survivorsRogueItemCard.LockState = new bool?(ModelBase<SurvivorsRogueModel>.Instance.GetItemIsLock(this.ItemType, survivorsItem.Id));
			survivorsRogueItemCard.IsNew = new bool?(ModelBase<SurvivorsRogueModel>.Instance.GetItemIsNew(this.ItemType, survivorsItem.Id));
			if (survivorsRogueItemCard.LockState.GetValueOrDefault())
			{
				survivorsRogueItemCard.TitleId = "Text_Unknown_Text";
				survivorsRogueItemCard.DescId = "SurvivorsItem_Lock_Desc";
			}
			list.Add(survivorsRogueItemCard);
		}
		this.SortUiDataList(list);
		return list;
	}

	// Token: 0x060160F2 RID: 90354 RVA: 0x0061F214 File Offset: 0x0061D414
	protected override void OnSelectItem(SurvivorsRogueItemCard data, bool isFromClick = true)
	{
		SurvivorsItemTabView.<>c__DisplayClass10_0 CS$<>8__locals1 = new SurvivorsItemTabView.<>c__DisplayClass10_0();
		CS$<>8__locals1.<>4__this = this;
		CS$<>8__locals1.data = data;
		UiAsyncTask task = new UiAsyncTask("SurvivorsRogueCardBase.Apply", delegate()
		{
			SurvivorsItemTabView.<>c__DisplayClass10_0.<<OnSelectItem>b__0>d <<OnSelectItem>b__0>d;
			<<OnSelectItem>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<<OnSelectItem>b__0>d.<>4__this = CS$<>8__locals1;
			<<OnSelectItem>b__0>d.<>1__state = -1;
			<<OnSelectItem>b__0>d.<>t__builder.Start<SurvivorsItemTabView.<>c__DisplayClass10_0.<<OnSelectItem>b__0>d>(ref <<OnSelectItem>b__0>d);
			return <<OnSelectItem>b__0>d.<>t__builder.Task;
		}, null);
		base.RunAsyncTask(task);
		if (isFromClick)
		{
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence != null)
			{
				uiViewSequence.StopSequenceByKey("Switch", false, false);
			}
			UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
			if (uiViewSequence2 == null)
			{
				return;
			}
			uiViewSequence2.PlaySequence("Switch", false, null);
		}
	}

	// Token: 0x060160F3 RID: 90355 RVA: 0x0061F28F File Offset: 0x0061D48F
	private void SortUiDataList(List<SurvivorsRogueItemCard> uiDataList)
	{
		if (uiDataList == null)
		{
			return;
		}
		uiDataList.Sort(delegate(SurvivorsRogueItemCard a, SurvivorsRogueItemCard b)
		{
			bool? lockState = a.LockState;
			bool? lockState2 = b.LockState;
			if (!(lockState.GetValueOrDefault() == lockState2.GetValueOrDefault() & lockState != null == (lockState2 != null)))
			{
				if (a.LockState == null || b.LockState == null)
				{
					return 0;
				}
				if (!a.LockState.Value)
				{
					return -1;
				}
				return 1;
			}
			else
			{
				if (a.QualityId != b.QualityId)
				{
					return b.QualityId - a.QualityId;
				}
				return a.Id - b.Id;
			}
		});
	}

	// Token: 0x0400A9C9 RID: 43465
	[Nullable(2)]
	private SurvivorsRogueCardBase PropDetailItem;
}
