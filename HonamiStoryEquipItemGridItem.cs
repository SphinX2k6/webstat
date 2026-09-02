using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

// Token: 0x02001F05 RID: 7941
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryEquipItemGridItem : HonamiStoryItemGridItem
{
	// Token: 0x0600ED17 RID: 60695 RVA: 0x0040A516 File Offset: 0x00408716
	public HonamiStoryEquipItemGridItem(HonamiStoryItemDataBase itemData) : base(itemData)
	{
		this.ItemData = itemData;
	}

	// Token: 0x0600ED18 RID: 60696 RVA: 0x0040A528 File Offset: 0x00408728
	protected override void RefreshLogicData()
	{
		base.SetLockItemEnable(this.ItemData.IsLock(), false);
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		this.SetReplaceEnable(backpackLogicState == EHonamiStoryBackpackLogicState.Instead);
	}

	// Token: 0x0600ED19 RID: 60697 RVA: 0x0040A55C File Offset: 0x0040875C
	protected override void ExecuteDoubleClickLogic()
	{
		EHonamiStoryBackpack toBackpack = HonamiStoryUtil.CheckInHonamiStoryDungeon() ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		if (!ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.ItemData, EHonamiStoryBackpack.Player, toBackpack))
		{
			if (Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) != null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
				return;
			}
			ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.ItemData, EHonamiStoryBackpack.Player, EHonamiStoryBackpack.PickUpBox);
		}
	}

	// Token: 0x0600ED1A RID: 60698 RVA: 0x0040A5C8 File Offset: 0x004087C8
	protected override void DoLogicStateFunc(EHonamiStoryBackpackLogicState state)
	{
		if (state == EHonamiStoryBackpackLogicState.Instead)
		{
			HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
			int position = this.ItemData.GetPosition();
			backpackLogic.DoTipsWithPluginsInstead(position, this.ItemData);
			base.CancelToggleSelect();
			return;
		}
		if (state == EHonamiStoryBackpackLogicState.Tips || state == EHonamiStoryBackpackLogicState.TipsWithPlugins)
		{
			HonamiStoryBackpackLogicController backpackLogic2 = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
			HonamiStoryItemTipsBase tipsItem = backpackLogic2.TipsItem;
			HonamiStoryItemDataBase itemDataOut = tipsItem.GetItemDataOut();
			if (backpackLogic2 != null)
			{
				backpackLogic2.CloseTips();
			}
			if (this.ItemData == itemDataOut)
			{
				tipsItem.SetItemDataOut(itemDataOut);
			}
			base.OnClickedToggle(EToggleState.ETT_UnChecked);
		}
	}

	// Token: 0x0600ED1B RID: 60699 RVA: 0x0040A648 File Offset: 0x00408848
	protected void SetReplaceEnable(bool isEnable)
	{
		UiPanelBase replaceItem = this.ReplaceItem;
		if (replaceItem != null)
		{
			replaceItem.SetUiActive(isEnable);
		}
		if (isEnable && this.ReplaceItem == null)
		{
			this.ReplaceItem = new UiPanelBase();
			this.ReplaceItem.CreateThenShowByResourceIdAsync("SprChange", this.RootItem, false).ContinueWith(delegate()
			{
				bool uiActive = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Instead;
				UiPanelBase replaceItem2 = this.ReplaceItem;
				if (replaceItem2 == null)
				{
					return;
				}
				replaceItem2.SetUiActive(uiActive);
			});
		}
	}

	// Token: 0x040071E8 RID: 29160
	private UiPanelBase ReplaceItem;
}
