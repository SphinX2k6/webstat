using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002BEB RID: 11243
[NullableContext(1)]
[Nullable(0)]
public class TowerDetailView : UiViewBase
{
	// Token: 0x060166F5 RID: 91893 RVA: 0x0063B501 File Offset: 0x00639701
	public TowerDetailView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x060166F6 RID: 91894 RVA: 0x0063B50C File Offset: 0x0063970C
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIHorizontalLayout));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060166F7 RID: 91895 RVA: 0x0063B5D8 File Offset: 0x006397D8
	protected override void OnStart()
	{
		this.InformationScroller = new GenericScrollView<TowerDetailInformationItem>(base.GetScrollViewWithScrollbar(2), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TowerDetailInformationItem>(this.CreateInformationItem), null);
		this.SwitchScroller = new GenericLayoutNew<TowerDetailSwitchItem>(base.GetHorizontalLayout(4), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<TowerDetailSwitchItem>(this.CreateSwitchItem), null);
	}

	// Token: 0x060166F8 RID: 91896 RVA: 0x0063B618 File Offset: 0x00639818
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnClickSingleTimeTowerDetailSwitchBtn, new Action(this.OnClickSwitchItem));
	}

	// Token: 0x060166F9 RID: 91897 RVA: 0x0063B636 File Offset: 0x00639836
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnClickSingleTimeTowerDetailSwitchBtn, new Action(this.OnClickSwitchItem));
	}

	// Token: 0x060166FA RID: 91898 RVA: 0x0063B654 File Offset: 0x00639854
	private ILayoutItem<TowerDetailInformationItem> CreateInformationItem(object tempData, UUIItem uiItem, int index)
	{
		TowerInformationData data = (TowerInformationData)tempData;
		TowerDetailInformationItem towerDetailInformationItem = new TowerDetailInformationItem(uiItem);
		towerDetailInformationItem.Update(data);
		return new LayoutItem<TowerDetailInformationItem>
		{
			Key = index,
			Value = towerDetailInformationItem
		};
	}

	// Token: 0x060166FB RID: 91899 RVA: 0x0063B690 File Offset: 0x00639890
	private ILayoutItem<TowerDetailSwitchItem> CreateSwitchItem(object tempData, UUIItem uiItem, int index)
	{
		TowerSwitchData data = (TowerSwitchData)tempData;
		TowerDetailSwitchItem towerDetailSwitchItem = new TowerDetailSwitchItem(uiItem);
		towerDetailSwitchItem.Update(data);
		return new LayoutItem<TowerDetailSwitchItem>
		{
			Key = index,
			Value = towerDetailSwitchItem
		};
	}

	// Token: 0x060166FC RID: 91900 RVA: 0x0063B6CA File Offset: 0x006398CA
	protected override void OnAfterShow()
	{
		this.CurrentId = ModelBase<TowerDetailModel>.Instance.CurrentSelectDetailId;
		this.RefreshView();
	}

	// Token: 0x060166FD RID: 91901 RVA: 0x0063B6E2 File Offset: 0x006398E2
	private void RefreshView()
	{
		this.RefreshTitleInfo();
		this.RefreshSwitchScroller();
		this.RefreshInformationScroller();
	}

	// Token: 0x060166FE RID: 91902 RVA: 0x0063B6F8 File Offset: 0x006398F8
	private void RefreshSwitchScroller()
	{
		List<TowerSwitchData> switchData = ModelBase<TowerDetailModel>.Instance.SwitchData;
		this.SwitchScroller.RebuildLayoutByDataNew<TowerSwitchData>(switchData, null);
	}

	// Token: 0x060166FF RID: 91903 RVA: 0x0063B728 File Offset: 0x00639928
	private void RefreshInformationScroller()
	{
		List<TowerSwitchData> switchData = ModelBase<TowerDetailModel>.Instance.SwitchData;
		TowerSwitchData switchData2 = null;
		for (int i = 0; i < switchData.Count; i++)
		{
			TowerSwitchData towerSwitchData = switchData[i];
			if (towerSwitchData.Index == this.CurrentId)
			{
				switchData2 = towerSwitchData;
			}
		}
		List<TowerInformationData> list = new List<TowerInformationData>();
		List<TowerDetailBuffData> buffs = ModelBase<TowerDetailModel>.Instance.GetBuffs(switchData2);
		if (buffs != null)
		{
			for (int j = 0; j < buffs.Count; j++)
			{
				TowerDetailBuffData towerDetailBuffData = buffs[j];
				list.Add(new TowerInformationData
				{
					Type = ETowerDetailInformationType.Buff,
					TowerDetailBuffData = towerDetailBuffData,
					Title = towerDetailBuffData.Title,
					Priority = towerDetailBuffData.Priority
				});
			}
		}
		List<TowerDetailMonsterData> monsters = ModelBase<TowerDetailModel>.Instance.GetMonsters(switchData2);
		if (monsters != null)
		{
			for (int k = 0; k < monsters.Count; k++)
			{
				TowerDetailMonsterData towerDetailMonsterData = monsters[k];
				list.Add(new TowerInformationData
				{
					Type = ETowerDetailInformationType.Monster,
					MonsterData = towerDetailMonsterData,
					Title = towerDetailMonsterData.Title,
					Priority = towerDetailMonsterData.Priority
				});
			}
		}
		list.Sort(new Comparison<TowerInformationData>(this.SortFunc));
		this.InformationScroller.RefreshByData<TowerInformationData>(list, null);
	}

	// Token: 0x06016700 RID: 91904 RVA: 0x0063B879 File Offset: 0x00639A79
	public int SortFunc(TowerInformationData a, TowerInformationData b)
	{
		return a.Priority - b.Priority;
	}

	// Token: 0x06016701 RID: 91905 RVA: 0x0063B888 File Offset: 0x00639A88
	private void OnClickSwitchItem()
	{
		this.CurrentId = ModelBase<TowerDetailModel>.Instance.CurrentSelectDetailId;
		this.RefreshSwitchScroller();
		this.RefreshInformationScroller();
	}

	// Token: 0x06016702 RID: 91906 RVA: 0x0063B8A8 File Offset: 0x00639AA8
	private void RefreshTitleInfo()
	{
		string towerTitle = ModelBase<TowerDetailModel>.Instance.TowerTitle;
		base.GetText(0).SetText(towerTitle, true);
	}

	// Token: 0x06016703 RID: 91907 RVA: 0x0063B8CE File Offset: 0x00639ACE
	protected override void OnBeforeDestroy()
	{
		this.InformationScroller.ClearChildren();
		this.SwitchScroller.ClearChildren();
	}

	// Token: 0x0400ADBD RID: 44477
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollView<TowerDetailInformationItem> InformationScroller;

	// Token: 0x0400ADBE RID: 44478
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayoutNew<TowerDetailSwitchItem> SwitchScroller;

	// Token: 0x0400ADBF RID: 44479
	private int CurrentId;

	// Token: 0x02008EE0 RID: 36576
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x0402FFF2 RID: 196594
		public const int CurrentSelectTowerTitle = 0;

		// Token: 0x0402FFF3 RID: 196595
		public const int InformationItem = 1;

		// Token: 0x0402FFF4 RID: 196596
		public const int InformationScroller = 2;

		// Token: 0x0402FFF5 RID: 196597
		public const int SwitchItem = 3;

		// Token: 0x0402FFF6 RID: 196598
		public const int SwitchScroller = 4;

		// Token: 0x0402FFF7 RID: 196599
		public const int BackBtn = 5;
	}
}
