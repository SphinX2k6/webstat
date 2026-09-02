using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RogueBattle;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200277A RID: 10106
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class RogueBattleMapFetterTabItem : GridProxyAbstract<IRogueBattleMapFetterTabInfo>
{
	// Token: 0x06013EE2 RID: 81634 RVA: 0x0058E080 File Offset: 0x0058C280
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06013EE3 RID: 81635 RVA: 0x0058E129 File Offset: 0x0058C329
	protected override void OnStart()
	{
		this.Layout = new GenericLayout<RogueBattleMapFetterTabChildItem, int>(base.GetVerticalLayout(3), new Func<RogueBattleMapFetterTabChildItem>(this.InitItem), null, false, true);
		Singleton<EventSystem>.Instance.Add(EEventName.RogueResMapSummaryBondUpdate, new Action<int>(this.OnClickSelected));
	}

	// Token: 0x06013EE4 RID: 81636 RVA: 0x0058E168 File Offset: 0x0058C368
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RogueResMapSummaryBondUpdate, new Action<int>(this.OnClickSelected));
	}

	// Token: 0x06013EE5 RID: 81637 RVA: 0x0058E188 File Offset: 0x0058C388
	public override void Refresh(IRogueBattleMapFetterTabInfo data, bool isSelected, int gridIndex)
	{
		this.BondData = data;
		List<int> list = new List<int>();
		foreach (int item in data.Config)
		{
			list.Add(item);
		}
		this.Layout.RefreshByData(list, delegate
		{
			this.Layout.BindLateUpdate(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.RogueResMapSummaryFettersSubTabUpdate);
				this.Layout.UnBindLateUpdate();
			});
		}, false);
		this.Layout.SetActive(data.IsSelected);
		this.SelectedTab(data.IsSelected);
		int id = data.Config[0];
		RogueResBond? rogueResBond = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBond(id);
		RogueResSynergyType? rogueResBondTypeById = ConfigBase<RogueBattleConfig>.Instance.GetRogueResBondTypeById(rogueResBond.Value.Rarity);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), rogueResBondTypeById.Value.SynergyTypeName, Array.Empty<object>());
	}

	// Token: 0x06013EE6 RID: 81638 RVA: 0x0058E27C File Offset: 0x0058C47C
	private void SelectedTab(bool isSelected)
	{
		EToggleState state = isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06013EE7 RID: 81639 RVA: 0x0058E2A2 File Offset: 0x0058C4A2
	private void OnClickToggle(EToggleState state)
	{
		this.BondData.IsSelected = !this.BondData.IsSelected;
		GenericLayout<RogueBattleMapFetterTabChildItem, int> layout = this.Layout;
		if (layout == null)
		{
			return;
		}
		layout.SetActive(this.BondData.IsSelected);
	}

	// Token: 0x06013EE8 RID: 81640 RVA: 0x0058E2D8 File Offset: 0x0058C4D8
	private RogueBattleMapFetterTabChildItem InitItem()
	{
		return new RogueBattleMapFetterTabChildItem
		{
			CanExecuteChangeFunction = new Func<int, EToggleState, bool>(this.CanExecuteChangeFunction)
		};
	}

	// Token: 0x06013EE9 RID: 81641 RVA: 0x0058E2F4 File Offset: 0x0058C4F4
	private void OnClickSelected(int bondId)
	{
		int? currentSelected = this.CurrentSelected;
		this.CurrentSelected = (this.BondData.Config.Contains(bondId) ? new int?(bondId) : null);
		if (currentSelected != null)
		{
			int index = this.BondData.Config.IndexOf(currentSelected.Value);
			RogueBattleMapFetterTabChildItem layoutItemByIndex = this.Layout.GetLayoutItemByIndex(index);
			if (layoutItemByIndex != null)
			{
				layoutItemByIndex.SetSelected(false);
			}
		}
		if (this.CurrentSelected == null)
		{
			return;
		}
		int gridIndex = this.BondData.Config.IndexOf(bondId);
		this.Layout.SelectGridProxy(gridIndex, false);
		RogueBattleMapFetterTabChildItem selectedProxy = this.Layout.GetSelectedProxy();
		if (selectedProxy == null)
		{
			return;
		}
		selectedProxy.SetSelected(true);
	}

	// Token: 0x06013EEA RID: 81642 RVA: 0x0058E3B0 File Offset: 0x0058C5B0
	private bool CanExecuteChangeFunction(int bondId, EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			int? currentSelected = this.CurrentSelected;
			return !(currentSelected.GetValueOrDefault() == bondId & currentSelected != null);
		}
		return true;
	}

	// Token: 0x04009B29 RID: 39721
	[Nullable(2)]
	private IRogueBattleMapFetterTabInfo BondData;

	// Token: 0x04009B2A RID: 39722
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<RogueBattleMapFetterTabChildItem, int> Layout;

	// Token: 0x04009B2B RID: 39723
	private int? CurrentSelected;
}
