using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.TrapDefense;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02002C1C RID: 11292
[NullableContext(1)]
[Nullable(0)]
public class TrapDefenseBdSumView : UiViewBase
{
	// Token: 0x06016988 RID: 92552 RVA: 0x0064568F File Offset: 0x0064388F
	public TrapDefenseBdSumView(UiViewInfo info) : base(info)
	{
	}

	// Token: 0x06016989 RID: 92553 RVA: 0x006456A8 File Offset: 0x006438A8
	protected unsafe override void OnRegisterComponent()
	{
		int num = 13;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIScrollViewWithScrollbarComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0601698A RID: 92554 RVA: 0x00645884 File Offset: 0x00643A84
	protected override UniTask OnBeforeStartAsync()
	{
		TrapDefenseBdSumView.<OnBeforeStartAsync>d__11 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<TrapDefenseBdSumView.<OnBeforeStartAsync>d__11>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0601698B RID: 92555 RVA: 0x006458C7 File Offset: 0x00643AC7
	protected override void OnStart()
	{
		this.InitTab();
	}

	// Token: 0x0601698C RID: 92556 RVA: 0x006458CF File Offset: 0x00643ACF
	protected override void OnAddEventListener()
	{
	}

	// Token: 0x0601698D RID: 92557 RVA: 0x006458D1 File Offset: 0x00643AD1
	protected override void OnRemoveEventListener()
	{
	}

	// Token: 0x0601698E RID: 92558 RVA: 0x006458D3 File Offset: 0x00643AD3
	protected override void OnBeforeShow()
	{
	}

	// Token: 0x0601698F RID: 92559 RVA: 0x006458D5 File Offset: 0x00643AD5
	protected override void OnBeforeDestroy()
	{
		this.ViewModel.OnViewClose();
	}

	// Token: 0x06016990 RID: 92560 RVA: 0x006458E2 File Offset: 0x00643AE2
	protected override void OnBeforeHide()
	{
		this.ViewModel.Model.RougeModeData.SaveCacheUnlockBdBuffs();
	}

	// Token: 0x06016991 RID: 92561 RVA: 0x006458FC File Offset: 0x00643AFC
	private void OnBtnHelp()
	{
		int helpIdBdSum = ConfigBase<TrapDefenseConfig>.Instance.GetHelpIdBdSum();
		ControllerBase<HelpController>.Instance.OpenHelpById(helpIdBdSum);
	}

	// Token: 0x06016992 RID: 92562 RVA: 0x0064591F File Offset: 0x00643B1F
	private void OnBtnClose()
	{
		base.CloseMe(null);
	}

	// Token: 0x06016993 RID: 92563 RVA: 0x00645928 File Offset: 0x00643B28
	private ShipTowerTeamTabItem CreateTabItem([Nullable(2)] UUIItem item, int? index)
	{
		return new ShipTowerTeamTabItem();
	}

	// Token: 0x06016994 RID: 92564 RVA: 0x00645930 File Offset: 0x00643B30
	private void OnClickTabItem(int index)
	{
		ETrapDefenseBdTabType tabType = this.TabDataList[index].TabType;
		if (tabType == ETrapDefenseBdTabType.BdProgress)
		{
			this.ShowBdProgress();
			return;
		}
		if (tabType != ETrapDefenseBdTabType.BuffSum)
		{
			return;
		}
		this.ShowBdBuffSum();
	}

	// Token: 0x06016995 RID: 92565 RVA: 0x00645964 File Offset: 0x00643B64
	public void ShowBdProgress()
	{
		this.SetTabItemContentShow(4);
		this.PanelBdBuffDesc.SetActive(false);
		this.PanelBdDesc.SetActive(true);
		List<TrapDefenseBdData> bdListForProgress = this.ViewModel.GetBdListForProgress();
		int lastSelectIndex = this.GetSelectBdProgressIndex(bdListForProgress);
		this.ScrollBd.RefreshByData(bdListForProgress, delegate
		{
			this.ScrollBd.SelectGridProxy(Math.Max(lastSelectIndex, 0), false);
		}, true);
		this.SetEmptyInfoVisible(bdListForProgress.Count <= 0);
	}

	// Token: 0x06016996 RID: 92566 RVA: 0x006459E4 File Offset: 0x00643BE4
	public int GetSelectBdProgressIndex(List<TrapDefenseBdData> dataList)
	{
		int selectedIndex = this.ScrollBd.GetSelectedIndex();
		if (selectedIndex < 0)
		{
			int? jumpId = this.ViewModel.JumpBdId;
			if (jumpId != null && jumpId.GetValueOrDefault() != 0)
			{
				return dataList.FindIndex(delegate(TrapDefenseBdData data)
				{
					int id = data.Id;
					int? jumpId = jumpId;
					return id == jumpId.GetValueOrDefault() & jumpId != null;
				});
			}
		}
		return selectedIndex;
	}

	// Token: 0x06016997 RID: 92567 RVA: 0x00645A48 File Offset: 0x00643C48
	public void ShowBdBuffSum()
	{
		this.SetTabItemContentShow(7);
		int lastSelectIndex = this.ScrollBdBuff.GetSelectedIndex();
		List<TrapDefenseBdData> bdListForBuffSum = this.ViewModel.GetBdListForBuffSum();
		this.ScrollBdBuff.RefreshByData(bdListForBuffSum, delegate
		{
			this.ScrollBdBuff.SelectGridProxy(Math.Max(lastSelectIndex, 0), false);
		}, true);
		this.PanelBdDesc.SetActive(false);
		this.PanelBdBuffDesc.SetActive(bdListForBuffSum.Count > 0);
		this.SetEmptyInfoVisible(bdListForBuffSum.Count <= 0);
	}

	// Token: 0x06016998 RID: 92568 RVA: 0x00645AD1 File Offset: 0x00643CD1
	public void SetEmptyInfoVisible(bool visible)
	{
		UUIItem item = base.GetItem(12);
		if (item == null)
		{
			return;
		}
		item.SetUIActive(visible);
	}

	// Token: 0x06016999 RID: 92569 RVA: 0x00645AE8 File Offset: 0x00643CE8
	public void SetTabItemContentShow(int childType)
	{
		foreach (int num in new List<int>
		{
			4,
			7
		})
		{
			UUIItem item = base.GetItem(num);
			if (item != null)
			{
				item.SetUIActive(num == childType);
			}
		}
	}

	// Token: 0x0601699A RID: 92570 RVA: 0x00645B58 File Offset: 0x00643D58
	private TrapDefenseBdSumBdItem CreateItemBdScrollItem()
	{
		return new TrapDefenseBdSumBdItem
		{
			ClickCallBack = new Action<TrapDefenseBdData>(this.OnClickScrollBdItem)
		};
	}

	// Token: 0x0601699B RID: 92571 RVA: 0x00645B71 File Offset: 0x00643D71
	private void OnClickScrollBdItem(TrapDefenseBdData data)
	{
		this.ViewModel.SetSelectBdData(data);
		this.PanelBdDesc.UpdateData(data);
	}

	// Token: 0x0601699C RID: 92572 RVA: 0x00645B8C File Offset: 0x00643D8C
	private TrapDefenseBdSumBuffListItem CreateItemBdBuffScrollItem()
	{
		return new TrapDefenseBdSumBuffListItem
		{
			OnSelectBdBuffItemCallBack = new Action<TrapDefenseBdBuffData, TrapDefenseBdBuffItem>(this.OnSelectScrollBdBuffItem),
			OnIsShowBdBuffLockStateCallback = new Func<TrapDefenseBdBuffData, bool>(this.OnIsShowBdBuffLockState),
			OnIsNewTagStateCallback = new Func<TrapDefenseBdBuffData, bool>(this.IsBdBuffNewTagState),
			OnGetBdBuffConfig = new Func<TrapDefenseBdBuffData, TrapDefenseBdBuff>(this.OnGetBdBuffConfig)
		};
	}

	// Token: 0x0601699D RID: 92573 RVA: 0x00645BE8 File Offset: 0x00643DE8
	private void OnSelectScrollBdBuffItem(TrapDefenseBdBuffData data, TrapDefenseBdBuffItem item)
	{
		this.ViewModel.SetSelectBdBuffData(data);
		this.PanelBdBuffDesc.UpdateDataShowMode(data);
		if (this.ViewModel.IsShowBuffLockState(data))
		{
			this.PanelBdBuffDesc.UpdateBuffLockShowState();
		}
		if (this.ViewModel.Model.RougeModeData.CheckBdBuffUnlockRedDotState(data))
		{
			item.UpdateBuffInfo();
		}
	}

	// Token: 0x0601699E RID: 92574 RVA: 0x00645C44 File Offset: 0x00643E44
	public void InitTab()
	{
		foreach (KeyValuePair<int, ShipTowerTeamTabItem> keyValuePair in this.TabComponent.GetTabItemMap())
		{
			int key = keyValuePair.Key;
			ShipTowerTeamTabItem value = keyValuePair.Value;
			value.UpdateName(this.TabDataList[key].TabNameKey);
			if (this.TabDataList[key].TabType == ETrapDefenseBdTabType.BuffSum && !this.ViewModel.IsInstance)
			{
				value.BindRedDot(ERedDotName.TrapDefenseBdBuffNewUnlock, 0);
			}
			else
			{
				value.UpdateRedDotVisible(false);
			}
		}
		this.TabComponent.SelectToggleByIndex(this.GetJumpTabIndex(), true, true);
	}

	// Token: 0x0601699F RID: 92575 RVA: 0x00645D08 File Offset: 0x00643F08
	public int GetJumpTabIndex()
	{
		ETrapDefenseBdTabType? jumpTabType = this.ViewModel.JumpTabType;
		if (jumpTabType == null)
		{
			return 0;
		}
		return this.TabDataList.FindIndex(delegate(ITrapDefenseTab<ETrapDefenseBdTabType> tab)
		{
			ETrapDefenseBdTabType tabType = tab.TabType;
			ETrapDefenseBdTabType? jumpTabType = jumpTabType;
			return tabType == jumpTabType.GetValueOrDefault() & jumpTabType != null;
		});
	}

	// Token: 0x060169A0 RID: 92576 RVA: 0x00645D52 File Offset: 0x00643F52
	private void SwitchBdBuffStrengthenShow(bool show, TrapDefenseBdBuffData data)
	{
		data.SetIsShowStrengthen(show);
		this.PanelBdBuffDesc.UpdateDataShowMode(data);
		if (this.ViewModel.IsShowBuffLockState(data))
		{
			this.PanelBdBuffDesc.UpdateBuffLockShowState();
		}
	}

	// Token: 0x060169A1 RID: 92577 RVA: 0x00645D80 File Offset: 0x00643F80
	private bool OnIsShowBdBuffLockState(TrapDefenseBdBuffData data)
	{
		return !this.ViewModel.IsInstance && !data.IsUnlock;
	}

	// Token: 0x060169A2 RID: 92578 RVA: 0x00645D9A File Offset: 0x00643F9A
	private bool IsBdBuffNewTagState(TrapDefenseBdBuffData data)
	{
		return this.ViewModel.Model.RougeModeData.GetBdBuffNewTagState(data);
	}

	// Token: 0x060169A3 RID: 92579 RVA: 0x00645DB2 File Offset: 0x00643FB2
	private TrapDefenseBdBuff OnGetBdBuffConfig(TrapDefenseBdBuffData data)
	{
		if (this.ViewModel.IsInstance)
		{
			return data.BdBuffConfig;
		}
		return data.GetStrengthenBeforeConfig();
	}

	// Token: 0x0400AE74 RID: 44660
	public PopupCaptionItem PopupCaption;

	// Token: 0x0400AE75 RID: 44661
	public TabComponent<ShipTowerTeamTabItem> TabComponent;

	// Token: 0x0400AE76 RID: 44662
	public GenericScrollViewNew<TrapDefenseBdSumBdItem, TrapDefenseBdData> ScrollBd;

	// Token: 0x0400AE77 RID: 44663
	public GenericScrollViewNew<TrapDefenseBdSumBuffListItem, TrapDefenseBdData> ScrollBdBuff;

	// Token: 0x0400AE78 RID: 44664
	public TrapDefenseBdSumBdDescPanel PanelBdDesc;

	// Token: 0x0400AE79 RID: 44665
	public TrapDefenseBdSumBuffDescPanel PanelBdBuffDesc;

	// Token: 0x0400AE7A RID: 44666
	public TrapDefenseBdSumViewModel ViewModel = ModelBase<TrapDefenseModel>.Instance.ViewModelBdSum;

	// Token: 0x0400AE7B RID: 44667
	public List<ITrapDefenseTab<ETrapDefenseBdTabType>> TabDataList;

	// Token: 0x02008F3D RID: 36669
	[NullableContext(0)]
	private class EChildType
	{
		// Token: 0x040301B6 RID: 197046
		public const int ItemBgYellowLight = 0;

		// Token: 0x040301B7 RID: 197047
		public const int ItemBgRedLight = 1;

		// Token: 0x040301B8 RID: 197048
		public const int ItemCaption = 2;

		// Token: 0x040301B9 RID: 197049
		public const int ItemTabComponent = 3;

		// Token: 0x040301BA RID: 197050
		public const int ItemBdRoot = 4;

		// Token: 0x040301BB RID: 197051
		public const int ScrollBd = 5;

		// Token: 0x040301BC RID: 197052
		public const int ItemBdScrollItem = 6;

		// Token: 0x040301BD RID: 197053
		public const int ItemBdBuffRoot = 7;

		// Token: 0x040301BE RID: 197054
		public const int ScrollBdBuff = 8;

		// Token: 0x040301BF RID: 197055
		public const int ItemBdBuffScrollItem = 9;

		// Token: 0x040301C0 RID: 197056
		public const int ItemBdBuffDescRoot = 10;

		// Token: 0x040301C1 RID: 197057
		public const int ItemBdDescRoot = 11;

		// Token: 0x040301C2 RID: 197058
		public const int ItemEmptyInfo = 12;
	}
}
