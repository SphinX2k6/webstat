using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002B3A RID: 11066
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class SurvivorsWeaponTabView : SurvivorsTabViewBase<SurvivorWeaponTabItem, SurvivorsHandbookWeaponData>
{
	// Token: 0x17001CBF RID: 7359
	// (get) Token: 0x06016134 RID: 90420 RVA: 0x0062008B File Offset: 0x0061E28B
	protected override ESurvivorsRogueItemType ItemType
	{
		get
		{
			return ESurvivorsRogueItemType.Weapon;
		}
	}

	// Token: 0x06016135 RID: 90421 RVA: 0x00620090 File Offset: 0x0061E290
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>();
	}

	// Token: 0x06016136 RID: 90422 RVA: 0x00620179 File Offset: 0x0061E379
	protected override int GetLoopItemIndex()
	{
		return 3;
	}

	// Token: 0x06016137 RID: 90423 RVA: 0x0062017C File Offset: 0x0061E37C
	protected override int GetLoopScrollComponentIndex()
	{
		return 1;
	}

	// Token: 0x06016138 RID: 90424 RVA: 0x00620180 File Offset: 0x0061E380
	protected override UniTask InitSubComponents()
	{
		SurvivorsWeaponTabView.<InitSubComponents>d__6 <InitSubComponents>d__;
		<InitSubComponents>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitSubComponents>d__.<>4__this = this;
		<InitSubComponents>d__.<>1__state = -1;
		<InitSubComponents>d__.<>t__builder.Start<SurvivorsWeaponTabView.<InitSubComponents>d__6>(ref <InitSubComponents>d__);
		return <InitSubComponents>d__.<>t__builder.Task;
	}

	// Token: 0x06016139 RID: 90425 RVA: 0x006201C3 File Offset: 0x0061E3C3
	protected override void OnTriggerSequenceStartEvent()
	{
		GenericScrollViewNew<SurvivorsWeaponDetailItem, int> weaponEvolveScroll = this.WeaponEvolveScroll;
		if (weaponEvolveScroll == null)
		{
			return;
		}
		weaponEvolveScroll.GetGenericLayout().PlayGridAnim();
	}

	// Token: 0x0601613A RID: 90426 RVA: 0x006201DA File Offset: 0x0061E3DA
	private SurvivorsWeaponDetailItem CreateWeaponEvolveItem()
	{
		return new SurvivorsWeaponDetailItem();
	}

	// Token: 0x0601613B RID: 90427 RVA: 0x006201E1 File Offset: 0x0061E3E1
	protected override SurvivorWeaponTabItem CreateLoopItem()
	{
		return new SurvivorWeaponTabItem
		{
			OnClickToggleCallBack = new Action<SurvivorsHandbookWeaponData, SurvivorWeaponTabItem>(base.OnItemClick),
			OnCanToggleClicked = new Func<SurvivorsHandbookWeaponData, bool, EToggleState, bool>(base.OnCanClickItem)
		};
	}

	// Token: 0x0601613C RID: 90428 RVA: 0x0062020C File Offset: 0x0061E40C
	[PreserveBaseOverrides]
	protected new virtual List<SurvivorsHandbookWeaponData> GenerateItemUiDataList()
	{
		int actId = ModelBase<SurvivorsRogueModel>.Instance.ActivityData.ActId;
		IEnumerable<SurvivorsWeapon> allSurvivorsWeaponByActId = ConfigBase<SurvivorsRogueConfig>.Instance.GetAllSurvivorsWeaponByActId(actId);
		List<SurvivorsHandbookWeaponData> list = new List<SurvivorsHandbookWeaponData>();
		foreach (SurvivorsWeapon survivorsWeapon in allSurvivorsWeaponByActId)
		{
			bool itemIsLock = ModelBase<SurvivorsRogueModel>.Instance.GetItemIsLock(this.ItemType, survivorsWeapon.Id);
			SurvivorsHandbookWeaponData item = new SurvivorsHandbookWeaponData
			{
				Id = survivorsWeapon.Id,
				LockState = new bool?(itemIsLock),
				IsNew = new bool?(ModelBase<SurvivorsRogueModel>.Instance.GetItemIsNew(this.ItemType, survivorsWeapon.Id)),
				SortId = survivorsWeapon.SortId
			};
			list.Add(item);
		}
		this.SortUiDataList(list);
		return list;
	}

	// Token: 0x0601613D RID: 90429 RVA: 0x006202E8 File Offset: 0x0061E4E8
	private void SortUiDataList(List<SurvivorsHandbookWeaponData> uiDataList)
	{
		uiDataList.Sort(delegate(SurvivorsHandbookWeaponData a, SurvivorsHandbookWeaponData b)
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
				if (a.SortId != b.SortId)
				{
					return a.SortId - b.SortId;
				}
				return a.Id - b.Id;
			}
		});
	}

	// Token: 0x0601613E RID: 90430 RVA: 0x00620310 File Offset: 0x0061E510
	protected override void OnSelectItem(SurvivorsHandbookWeaponData data, bool isFromClick = true)
	{
		SurvivorsWeapon value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(data.Id).Value;
		UUIText text = base.GetText(8);
		if (text != null)
		{
			if (data.LockState.GetValueOrDefault())
			{
				text.ShowTextNew("Text_Unknown_Text");
			}
			else
			{
				text.ShowTextNew(value.Name);
			}
		}
		this.WeaponEvolveScroll.RefreshByData(this.GenerateWeaponEvolveUiDataList(data).ToList<int>(), delegate
		{
			foreach (SurvivorsWeaponDetailItem survivorsWeaponDetailItem in this.WeaponEvolveScroll.GetScrollItemList())
			{
				survivorsWeaponDetailItem.SetIsCurrentState(false);
				survivorsWeaponDetailItem.SetIsLocked(false);
			}
		}, isFromClick);
	}

	// Token: 0x0601613F RID: 90431 RVA: 0x00620390 File Offset: 0x0061E590
	private IReadOnlyList<int> GenerateWeaponEvolveUiDataList(SurvivorsHandbookWeaponData data)
	{
		int id = data.Id;
		SurvivorsWeapon value = ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeapon(id).Value;
		List<int> list;
		if (!data.LockState.GetValueOrDefault())
		{
			list = new List<int>();
			for (int i = 0; i < value.EvolveIdsLength; i++)
			{
				list.Add(value.EvolveIds(i).Value.Key);
			}
		}
		else
		{
			list = new List<int>
			{
				ConfigBase<SurvivorsRogueConfig>.Instance.GetSurvivorsWeaponDefaultEvolve(id).Value.Id
			};
		}
		return list;
	}

	// Token: 0x0400A9FF RID: 43519
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<SurvivorsWeaponDetailItem, int> WeaponEvolveScroll;
}
