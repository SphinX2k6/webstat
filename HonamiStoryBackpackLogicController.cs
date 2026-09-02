using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02001EF2 RID: 7922
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryBackpackLogicController
{
	// Token: 0x0600EB75 RID: 60277 RVA: 0x003FF4EE File Offset: 0x003FD6EE
	public void Destroy()
	{
		this.DestroyTimer();
	}

	// Token: 0x0600EB76 RID: 60278 RVA: 0x003FF4F8 File Offset: 0x003FD6F8
	public bool OnClickGrid(HonamiStoryItemDataBase itemData, Action cb, HonamiStoryItemGridItem uiItem)
	{
		if (this.CurClickedItemData != null && itemData != this.CurClickedItemData)
		{
			HonamiStoryItemGridItem curClickedUiItem = this.CurClickedUiItem;
			if (curClickedUiItem != null)
			{
				curClickedUiItem.CancelToggleSelect();
			}
			this.DestroyTimer();
		}
		this.CurClickedUiItem = uiItem;
		this.CurClickedItemData = itemData;
		if (this.DoubleClickedHandle != null && this.DoubleClickedHandle.Valid())
		{
			this.DestroyTimer();
			this.CurClickedUiItem = null;
			this.CurClickedItemData = null;
			return true;
		}
		int doubleClickDelay = ConfigBase<HonamiStoryConfig>.Instance.GetDoubleClickDelay();
		this.DoubleClickedHandle = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
		{
			this.DoubleClickedHandle = null;
			this.CurClickedUiItem = null;
			this.CurClickedItemData = null;
			cb();
		}, (float)doubleClickDelay, null, null, true, 1f);
		return false;
	}

	// Token: 0x0600EB77 RID: 60279 RVA: 0x003FF5AC File Offset: 0x003FD7AC
	private void DestroyTimer()
	{
		if (this.DoubleClickedHandle != null)
		{
			if (this.DoubleClickedHandle.Valid())
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DoubleClickedHandle);
			}
			this.DoubleClickedHandle = null;
		}
	}

	// Token: 0x0600EB78 RID: 60280 RVA: 0x003FF5DB File Offset: 0x003FD7DB
	public void RegisterPanel(HonamiStoryBackpackPanelBase panel)
	{
		this.PanelBaseList.Add(panel);
	}

	// Token: 0x0600EB79 RID: 60281 RVA: 0x003FF5E9 File Offset: 0x003FD7E9
	public void RegisterValuePanel(HonamiStoryBackpackValueCountItem item)
	{
		this.ValuePanel = item;
	}

	// Token: 0x0600EB7A RID: 60282 RVA: 0x003FF5F2 File Offset: 0x003FD7F2
	public void RegisterTipsItem(HonamiStoryItemTipsBase tips)
	{
		this.TipsItem = tips;
	}

	// Token: 0x0600EB7B RID: 60283 RVA: 0x003FF5FB File Offset: 0x003FD7FB
	[NullableContext(2)]
	public void RegisterBackpackView(HonamiStoryBackpackView view)
	{
		this.BackpackView = view;
	}

	// Token: 0x0600EB7C RID: 60284 RVA: 0x003FF604 File Offset: 0x003FD804
	public bool IsBackpackView()
	{
		return this.BackpackView != null;
	}

	// Token: 0x0600EB7D RID: 60285 RVA: 0x003FF610 File Offset: 0x003FD810
	[NullableContext(2)]
	public void SetLogicState(EHonamiStoryBackpackLogicState state, HonamiStoryItemDataBase insteadItem = null, EHonamiStoryBackpack? tipsBackpackId = null)
	{
		this.DestroyTimer();
		EHonamiStoryBackpackLogicState curState = this.CurState;
		this.CurState = state;
		this.TipsInsteadItem = insteadItem;
		this.TipsBackpackId = tipsBackpackId;
		if (state == EHonamiStoryBackpackLogicState.Normal)
		{
			this.SellItemSet.Clear();
			this.InitDataSelectState();
			if (curState == EHonamiStoryBackpackLogicState.Sell)
			{
				HonamiStoryBackpackView backpackView = this.BackpackView;
				if (backpackView != null)
				{
					backpackView.SetSellMode(false);
				}
			}
			this.HandleGamepadLogicToNormal();
		}
		else if (state == EHonamiStoryBackpackLogicState.Sell)
		{
			this.InitDataSelectState();
			HonamiStoryBackpackView backpackView2 = this.BackpackView;
			if (backpackView2 != null)
			{
				backpackView2.SetSellMode(true);
			}
			this.SellItemSet.Clear();
			this.CurValueSum = 0;
			this.ValuePanel.SetValue(0);
		}
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			honamiStoryBackpackPanelBase.OnBackpackLogicStateChange(state);
		}
	}

	// Token: 0x0600EB7E RID: 60286 RVA: 0x003FF6F0 File Offset: 0x003FD8F0
	public EHonamiStoryBackpackLogicState GetLogicState()
	{
		return this.CurState;
	}

	// Token: 0x0600EB7F RID: 60287 RVA: 0x003FF6F8 File Offset: 0x003FD8F8
	protected void InitDataSelectState()
	{
		EHonamiStoryBackpack backpackId = HonamiStoryUtil.CheckInHonamiStoryDungeon() ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in ModelBase<HonamiStoryModel>.Instance.GetBackPackData((int)backpackId, false).GetItemDataList())
		{
			honamiStoryItemDataBase.SetIsSelected(false);
		}
	}

	// Token: 0x0600EB80 RID: 60288 RVA: 0x003FF760 File Offset: 0x003FD960
	protected void HandleGamepadLogicToNormal()
	{
		HonamiStoryGamepadLogicController gamepadLogic = ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic();
		if (gamepadLogic == null)
		{
			return;
		}
		gamepadLogic.TriggerCurItemEnterGrid();
	}

	// Token: 0x0600EB81 RID: 60289 RVA: 0x003FF778 File Offset: 0x003FD978
	public void OnUnlockSlot(int rolePos)
	{
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == 3)
			{
				HonamiStoryEquipBackpackPanel honamiStoryEquipBackpackPanel = honamiStoryBackpackPanelBase as HonamiStoryEquipBackpackPanel;
				if (honamiStoryEquipBackpackPanel == null)
				{
					break;
				}
				honamiStoryEquipBackpackPanel.RefreshUnlockSlot();
				break;
			}
		}
	}

	// Token: 0x0600EB82 RID: 60290 RVA: 0x003FF7E0 File Offset: 0x003FD9E0
	public void RefreshItemLockState(HonamiStoryItemDataBase itemData, EHonamiStoryBackpackType backpackType)
	{
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == (int)backpackType)
			{
				honamiStoryBackpackPanelBase.RefreshSingleItem(itemData);
				break;
			}
		}
	}

	// Token: 0x0600EB83 RID: 60291 RVA: 0x003FF840 File Offset: 0x003FDA40
	public void RegisterSingleSellItem(HonamiStoryItemDataBase itemData)
	{
		bool flag = !itemData.GetIsSelected();
		itemData.SetIsSelected(flag);
		if (flag)
		{
			this.SellItemSet.Add(itemData);
			this.CurValueSum += itemData.GetSellPrice();
		}
		else
		{
			this.SellItemSet.Remove(itemData);
			this.CurValueSum -= itemData.GetSellPrice();
		}
		this.ValuePanel.SetValue(this.CurValueSum);
	}

	// Token: 0x0600EB84 RID: 60292 RVA: 0x003FF8B4 File Offset: 0x003FDAB4
	public void DoSell()
	{
		if (this.SellItemSet.Count == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_Sell_NoItem_Tip", Array.Empty<object>());
			return;
		}
		List<IHonamiStoryItemSellInfo> list = new List<IHonamiStoryItemSellInfo>();
		foreach (HonamiStoryItemDataBase itemData in this.SellItemSet)
		{
			HonamiStoryItemSellInfo item = new HonamiStoryItemSellInfo
			{
				ItemData = itemData,
				BackpackType = EHonamiStoryBackpack.Inventory
			};
			list.Add(item);
		}
		Singleton<UiManager>.Instance.OpenView(EUiViewName.HonamiStorySellConfirmBoxView, new HonamiStorySellConfirmBoxOpenParam
		{
			SellItemList = list,
			SellCallback = delegate
			{
				this.SellItemSet.Clear();
				this.CurValueSum = 0;
				this.ValuePanel.SetValue(0);
				this.SetLogicState(EHonamiStoryBackpackLogicState.Normal, null, null);
				ControllerBase<UiNavigationNewController>.Instance.SetLockUseDragStateByPanelItem(this.BackpackView.GetRootItem(), false);
			}
		}, null);
	}

	// Token: 0x0600EB85 RID: 60293 RVA: 0x003FF974 File Offset: 0x003FDB74
	public void DoSellToAll(bool isSelected, EHonamiStoryItemType itemType, int qualityId = 0)
	{
		List<HonamiStoryItemDataBase> list = new List<HonamiStoryItemDataBase>();
		if (!isSelected)
		{
			foreach (HonamiStoryItemDataBase honamiStoryItemDataBase in this.SellItemSet)
			{
				if (honamiStoryItemDataBase.GetItemType() == itemType && (qualityId == 0 || qualityId == honamiStoryItemDataBase.GetQuality()))
				{
					list.Add(honamiStoryItemDataBase);
					honamiStoryItemDataBase.SetIsSelected(false);
				}
			}
			using (List<HonamiStoryItemDataBase>.Enumerator enumerator2 = list.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					HonamiStoryItemDataBase honamiStoryItemDataBase2 = enumerator2.Current;
					this.SellItemSet.Remove(honamiStoryItemDataBase2);
					this.CurValueSum -= honamiStoryItemDataBase2.GetSellPrice();
				}
				goto IL_172;
			}
		}
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase3 in ModelBase<HonamiStoryModel>.Instance.GetBackPackData(1, false).GetItemDataList())
		{
			if (honamiStoryItemDataBase3.GetItemType() == itemType && !honamiStoryItemDataBase3.IsLock() && (qualityId == 0 || qualityId == honamiStoryItemDataBase3.GetQuality()))
			{
				honamiStoryItemDataBase3.SetIsSelected(true);
				list.Add(honamiStoryItemDataBase3);
				this.SellItemSet.Add(honamiStoryItemDataBase3);
			}
		}
		this.CurValueSum = 0;
		foreach (HonamiStoryItemDataBase honamiStoryItemDataBase4 in this.SellItemSet)
		{
			this.CurValueSum += honamiStoryItemDataBase4.GetSellPrice();
		}
		IL_172:
		this.ValuePanel.SetValue(this.CurValueSum);
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == 0)
			{
				using (List<HonamiStoryItemDataBase>.Enumerator enumerator2 = list.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						HonamiStoryItemDataBase itemData = enumerator2.Current;
						honamiStoryBackpackPanelBase.RefreshSingleItem(itemData);
					}
					break;
				}
			}
		}
	}

	// Token: 0x0600EB86 RID: 60294 RVA: 0x003FFBC0 File Offset: 0x003FDDC0
	[NullableContext(0)]
	public UniTask<bool> DoTipsWithPluginsInstead(int pos, [Nullable(2)] HonamiStoryItemDataBase exchangeItem)
	{
		HonamiStoryBackpackLogicController.<DoTipsWithPluginsInstead>d__29 <DoTipsWithPluginsInstead>d__;
		<DoTipsWithPluginsInstead>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
		<DoTipsWithPluginsInstead>d__.<>4__this = this;
		<DoTipsWithPluginsInstead>d__.pos = pos;
		<DoTipsWithPluginsInstead>d__.exchangeItem = exchangeItem;
		<DoTipsWithPluginsInstead>d__.<>1__state = -1;
		<DoTipsWithPluginsInstead>d__.<>t__builder.Start<HonamiStoryBackpackLogicController.<DoTipsWithPluginsInstead>d__29>(ref <DoTipsWithPluginsInstead>d__);
		return <DoTipsWithPluginsInstead>d__.<>t__builder.Task;
	}

	// Token: 0x0600EB87 RID: 60295 RVA: 0x003FFC13 File Offset: 0x003FDE13
	public HonamiStoryItemDataBase GetInsteadItem()
	{
		return this.TipsInsteadItem;
	}

	// Token: 0x0600EB88 RID: 60296 RVA: 0x003FFC1B File Offset: 0x003FDE1B
	public bool GetTipsOpen()
	{
		return this.GetLogicState() == EHonamiStoryBackpackLogicState.Tips || this.GetLogicState() == EHonamiStoryBackpackLogicState.TipsWithPlugins;
	}

	// Token: 0x0600EB89 RID: 60297 RVA: 0x003FFC31 File Offset: 0x003FDE31
	public void CloseTips()
	{
		this.TipsItem.OnClickedMask();
	}

	// Token: 0x0600EB8A RID: 60298 RVA: 0x003FFC3E File Offset: 0x003FDE3E
	public void SetInteractController(HonamiStoryInteractController controller)
	{
		this.InteractController = controller;
	}

	// Token: 0x0600EB8B RID: 60299 RVA: 0x003FFC47 File Offset: 0x003FDE47
	public HonamiStoryInteractController GetInteractController()
	{
		return this.InteractController;
	}

	// Token: 0x0600EB8C RID: 60300 RVA: 0x003FFC50 File Offset: 0x003FDE50
	public void RefreshNeedQuickAll()
	{
		foreach (HonamiStoryBackpackPanelBase honamiStoryBackpackPanelBase in this.PanelBaseList)
		{
			if (honamiStoryBackpackPanelBase.GetBackpackType() == 3)
			{
				if (HonamiStoryUtil.IsMobileView())
				{
					HonamiStoryMobileEquipPanel honamiStoryMobileEquipPanel = honamiStoryBackpackPanelBase as HonamiStoryMobileEquipPanel;
					if (honamiStoryMobileEquipPanel == null)
					{
						break;
					}
					honamiStoryMobileEquipPanel.RefreshNeedQuickAll();
					break;
				}
				else
				{
					HonamiStoryEquipBackpackPanel honamiStoryEquipBackpackPanel = honamiStoryBackpackPanelBase as HonamiStoryEquipBackpackPanel;
					if (honamiStoryEquipBackpackPanel == null)
					{
						break;
					}
					honamiStoryEquipBackpackPanel.RefreshNeedQuickAll();
					break;
				}
			}
		}
	}

	// Token: 0x04007151 RID: 29009
	[Nullable(2)]
	public HonamiStoryBackpackView BackpackView;

	// Token: 0x04007152 RID: 29010
	[Nullable(2)]
	private TimerHandle DoubleClickedHandle;

	// Token: 0x04007153 RID: 29011
	[Nullable(2)]
	private HonamiStoryItemDataBase CurClickedItemData;

	// Token: 0x04007154 RID: 29012
	[Nullable(2)]
	private HonamiStoryItemGridItem CurClickedUiItem;

	// Token: 0x04007155 RID: 29013
	public List<HonamiStoryBackpackPanelBase> PanelBaseList = new List<HonamiStoryBackpackPanelBase>();

	// Token: 0x04007156 RID: 29014
	private EHonamiStoryBackpackLogicState CurState;

	// Token: 0x04007157 RID: 29015
	[Nullable(2)]
	private HonamiStoryBackpackValueCountItem ValuePanel;

	// Token: 0x04007158 RID: 29016
	private readonly HashSet<HonamiStoryItemDataBase> SellItemSet = new HashSet<HonamiStoryItemDataBase>();

	// Token: 0x04007159 RID: 29017
	private int CurValueSum;

	// Token: 0x0400715A RID: 29018
	[Nullable(2)]
	private HonamiStoryItemDataBase TipsInsteadItem;

	// Token: 0x0400715B RID: 29019
	private EHonamiStoryBackpack? TipsBackpackId;

	// Token: 0x0400715C RID: 29020
	[Nullable(2)]
	public HonamiStoryItemTipsBase TipsItem;

	// Token: 0x0400715D RID: 29021
	private HonamiStoryInteractController InteractController;
}
