using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F1E RID: 7966
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryBackpackView : UiViewBase
{
	// Token: 0x0600EE3A RID: 60986 RVA: 0x004110A2 File Offset: 0x0040F2A2
	public HonamiStoryBackpackView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EE3B RID: 60987 RVA: 0x004110C4 File Offset: 0x0040F2C4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 8;
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
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickMask));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EE3C RID: 60988 RVA: 0x00411230 File Offset: 0x0040F430
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryBackpackView.<OnBeforeStartAsync>d__16 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryBackpackView.<OnBeforeStartAsync>d__16>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE3D RID: 60989 RVA: 0x00411273 File Offset: 0x0040F473
	protected override void OnStart()
	{
		this.InitTipsItem();
	}

	// Token: 0x0600EE3E RID: 60990 RVA: 0x0041127C File Offset: 0x0040F47C
	protected void InitSequenceEvents()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.AddSequenceFinishEvent("Drag_Hide", delegate(string _)
			{
				this.CaptionItem.SetCloseBtnActive(false);
			}, false);
		}
		UiBehaviorLevelSequence uiViewSequence2 = this.UiViewSequence;
		if (uiViewSequence2 == null)
		{
			return;
		}
		uiViewSequence2.AddSequenceFinishEvent("Drag_Show", delegate(string _)
		{
			this.CaptionItem.SetCloseBtnActive(true);
		}, false);
	}

	// Token: 0x0600EE3F RID: 60991 RVA: 0x004112D0 File Offset: 0x0040F4D0
	protected override void OnBeforeDestroy()
	{
		EHonamiStoryBackpack backpackId = HonamiStoryUtil.CheckInHonamiStoryDungeon() ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		HonamiStoryBackpackData backPackData = ModelBase<HonamiStoryModel>.Instance.GetBackPackData((int)backpackId, true);
		if (backPackData != null)
		{
			backPackData.ClearNewInBackpack();
		}
		ModelBase<HonamiStoryModel>.Instance.SetGamepadLogic(null);
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogic(null);
	}

	// Token: 0x0600EE40 RID: 60992 RVA: 0x00411318 File Offset: 0x0040F518
	private UniTask InitPlayerBackpackPanel()
	{
		HonamiStoryBackpackView.<InitPlayerBackpackPanel>d__20 <InitPlayerBackpackPanel>d__;
		<InitPlayerBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPlayerBackpackPanel>d__.<>4__this = this;
		<InitPlayerBackpackPanel>d__.<>1__state = -1;
		<InitPlayerBackpackPanel>d__.<>t__builder.Start<HonamiStoryBackpackView.<InitPlayerBackpackPanel>d__20>(ref <InitPlayerBackpackPanel>d__);
		return <InitPlayerBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE41 RID: 60993 RVA: 0x0041135C File Offset: 0x0040F55C
	private UniTask InitBackpackPanel()
	{
		HonamiStoryBackpackView.<InitBackpackPanel>d__21 <InitBackpackPanel>d__;
		<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBackpackPanel>d__.<>4__this = this;
		<InitBackpackPanel>d__.<>1__state = -1;
		<InitBackpackPanel>d__.<>t__builder.Start<HonamiStoryBackpackView.<InitBackpackPanel>d__21>(ref <InitBackpackPanel>d__);
		return <InitBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE42 RID: 60994 RVA: 0x004113A0 File Offset: 0x0040F5A0
	private UniTask InitDiscardBackpackPanel()
	{
		HonamiStoryBackpackView.<InitDiscardBackpackPanel>d__22 <InitDiscardBackpackPanel>d__;
		<InitDiscardBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDiscardBackpackPanel>d__.<>4__this = this;
		<InitDiscardBackpackPanel>d__.<>1__state = -1;
		<InitDiscardBackpackPanel>d__.<>t__builder.Start<HonamiStoryBackpackView.<InitDiscardBackpackPanel>d__22>(ref <InitDiscardBackpackPanel>d__);
		return <InitDiscardBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE43 RID: 60995 RVA: 0x004113E4 File Offset: 0x0040F5E4
	private UniTask InitTipsItem()
	{
		HonamiStoryBackpackView.<InitTipsItem>d__23 <InitTipsItem>d__;
		<InitTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTipsItem>d__.<>4__this = this;
		<InitTipsItem>d__.<>1__state = -1;
		<InitTipsItem>d__.<>t__builder.Start<HonamiStoryBackpackView.<InitTipsItem>d__23>(ref <InitTipsItem>d__);
		return <InitTipsItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EE44 RID: 60996 RVA: 0x00411427 File Offset: 0x0040F627
	protected override void OnBeforeShow()
	{
		this.DragController.OnBeforeShow();
		HonamiStorySkillDescToggle descToggleItem = this.DescToggleItem;
		if (descToggleItem == null)
		{
			return;
		}
		descToggleItem.RefreshState();
	}

	// Token: 0x0600EE45 RID: 60997 RVA: 0x00411444 File Offset: 0x0040F644
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add<EInputControllerMainType, EInputControllerMainType>(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
	}

	// Token: 0x0600EE46 RID: 60998 RVA: 0x00411462 File Offset: 0x0040F662
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
	}

	// Token: 0x0600EE47 RID: 60999 RVA: 0x00411480 File Offset: 0x0040F680
	private void ShowTips([Nullable(2)] HonamiStoryItemGridItem item, Vector2D loc, Vector2D size, EHonamiStoryBackpackType type)
	{
		if (item == null || item.GetData() == null)
		{
			return;
		}
		this.DragController.OnClickedItem(true, item.GetData().GetIncId(), item);
		HonamiStoryItemDataBase data = item.GetData();
		HonamiStoryItemTipsBase tipsItem = this.TipsItem;
		if (tipsItem == null)
		{
			return;
		}
		tipsItem.Refresh(data, type, data.GetPosition(), new Action(item.OnHideCallback), loc, size);
	}

	// Token: 0x0600EE48 RID: 61000 RVA: 0x004114E0 File Offset: 0x0040F6E0
	public void ShowTipsHotKeyOnly(HonamiStoryGridItemBase item)
	{
		if (ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic() != null)
		{
			HonamiStoryItemTipsHotKey tipsItemHotkey = this.TipsItemHotkey;
			if (tipsItemHotkey != null)
			{
				tipsItemHotkey.GetRootItem().SetUIParent(base.GetItem(5), false);
			}
			HonamiStoryItemTipsHotKey tipsItemHotkey2 = this.TipsItemHotkey;
			if (tipsItemHotkey2 != null)
			{
				tipsItemHotkey2.SetAutoLocation(item.GetRootItem());
			}
			HonamiStoryItemTipsHotKey tipsItemHotkey3 = this.TipsItemHotkey;
			if (tipsItemHotkey3 == null)
			{
				return;
			}
			tipsItemHotkey3.SetUiActive(true);
		}
	}

	// Token: 0x0600EE49 RID: 61001 RVA: 0x0041153F File Offset: 0x0040F73F
	public void HideAllTips()
	{
		HonamiStoryItemTipsBase tipsItem = this.TipsItem;
		if (tipsItem != null)
		{
			tipsItem.SetTipsVisible(false);
		}
		this.TipsItemDetail.SetUiActive(false);
		this.TipsAttrChange.SetUiActive(false);
		HonamiStoryItemTipsHotKey tipsItemHotkey = this.TipsItemHotkey;
		if (tipsItemHotkey == null)
		{
			return;
		}
		tipsItemHotkey.SetUiActive(false);
	}

	// Token: 0x0600EE4A RID: 61002 RVA: 0x0041157C File Offset: 0x0040F77C
	[NullableContext(2)]
	private void ShowTipsDetail(HonamiStoryItemGridItem item, EHonamiStoryBackpackType type)
	{
		EHonamiStoryBackpackLogicState backpackLogicState = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState();
		bool flag = backpackLogicState == EHonamiStoryBackpackLogicState.Sell;
		bool flag2 = backpackLogicState == EHonamiStoryBackpackLogicState.Tips || backpackLogicState == EHonamiStoryBackpackLogicState.TipsWithPlugins;
		bool flag3 = HonamiStoryUtil.IsMobileView();
		ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().SetCurItem(item);
		if (item == null || item.GetData() == null || flag || flag2 || flag3)
		{
			return;
		}
		HonamiStoryItemDataBase data = item.GetData();
		this.TipsItemDetail.Refresh(data, type);
		if (this.TipsItemHotkey != null && Singleton<Info>.Instance.IsInGamepad())
		{
			this.TipsItemDetail.AddHotKey(this.TipsItemHotkey.GetRootItem());
		}
		this.TipsItemDetail.SetAutoLocation(item.GetRootItem());
		this.TipsItemDetail.SetUiActive(true);
	}

	// Token: 0x0600EE4B RID: 61003 RVA: 0x00411630 File Offset: 0x0040F830
	private void HideTipsDetail()
	{
		this.TipsItemDetail.SetUiActive(false);
	}

	// Token: 0x0600EE4C RID: 61004 RVA: 0x00411640 File Offset: 0x0040F840
	private void ShowTipsAttrChange([Nullable(2)] HonamiStoryEquipGridItem item, HonamiStoryInteractOperateAgent operateAgent)
	{
		this.TipsItemDetail.SetUiActive(false);
		this.TipsAttrChange.SetUiActive(false);
		if (item == null || operateAgent.OperateData == null || operateAgent.OperateData.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return;
		}
		HonamiStoryItemDataBase data = item.GetData();
		if (data == null)
		{
			return;
		}
		HonamiStoryEquipItemData honamiStoryEquipItemData = ModelBase<HonamiStoryModel>.Instance.GetItemData(data.GetIncId()) as HonamiStoryEquipItemData;
		HonamiStoryEquipItemData honamiStoryEquipItemData2 = ModelBase<HonamiStoryModel>.Instance.GetItemData(operateAgent.OperateData.GetIncId()) as HonamiStoryEquipItemData;
		if (honamiStoryEquipItemData == honamiStoryEquipItemData2)
		{
			return;
		}
		this.TipsAttrChange.SetUiActive(true);
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.TipsAttrChange.Refresh(honamiStoryEquipItemData, honamiStoryEquipItemData2, delegate
			{
				this.TipsAttrChange.GetRootItem().SetUIParent(this.DragController.GetDragTipsRoot(), false);
				if (this.TipsItemHotkey != null)
				{
					this.TipsAttrChange.AddHotKey(this.TipsItemHotkey.GetRootItem());
				}
			});
			return;
		}
		this.TipsAttrChange.Refresh(honamiStoryEquipItemData, honamiStoryEquipItemData2, delegate
		{
			this.TipsAttrChange.GetRootItem().SetUIParent(this.DragController.GetDragTipsRoot(), false);
		});
	}

	// Token: 0x0600EE4D RID: 61005 RVA: 0x0041170C File Offset: 0x0040F90C
	public void OnEnterGamepadMask()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Drag_Hide", false, null);
	}

	// Token: 0x0600EE4E RID: 61006 RVA: 0x00411738 File Offset: 0x0040F938
	public void OnExitGamepadMask()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Drag_Show", false, null);
	}

	// Token: 0x0600EE4F RID: 61007 RVA: 0x00411764 File Offset: 0x0040F964
	public void OnDragBegin()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Drag_Hide", false, null);
	}

	// Token: 0x0600EE50 RID: 61008 RVA: 0x00411790 File Offset: 0x0040F990
	public void OnDragEnd()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence != null)
		{
			uiViewSequence.PlaySequence("Drag_Show", false, null);
		}
		HonamiStoryItemTipsHotKey tipsItemHotkey = this.TipsItemHotkey;
		if (tipsItemHotkey == null)
		{
			return;
		}
		tipsItemHotkey.SetUiActive(false);
	}

	// Token: 0x0600EE51 RID: 61009 RVA: 0x004117D0 File Offset: 0x0040F9D0
	public void SetSellMode(bool active)
	{
		PopupCaptionItem captionItem = this.CaptionItem;
		if (captionItem != null)
		{
			captionItem.SetCloseBtnActive(!active);
		}
		PopupCaptionItem captionItem2 = this.CaptionItem;
		if (captionItem2 != null)
		{
			captionItem2.SetHelpBtnActive(!active);
		}
		PopupCaptionItem captionItem3 = this.CaptionItem;
		if (captionItem3 != null)
		{
			captionItem3.SetHomeBtnShowState(!active);
		}
		if (active)
		{
			this.HideTipsDetail();
		}
		ControllerBase<UiNavigationNewController>.Instance.SetLockUseDragState(active);
	}

	// Token: 0x0600EE52 RID: 61010 RVA: 0x00411830 File Offset: 0x0040FA30
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600EE53 RID: 61011 RVA: 0x00411839 File Offset: 0x0040FA39
	[NullableContext(2)]
	private void OnEnterItem(HonamiStoryItemGridItem item, EHonamiStoryBackpackType type)
	{
		this.ShowTipsDetail(item, type);
	}

	// Token: 0x0600EE54 RID: 61012 RVA: 0x00411843 File Offset: 0x0040FA43
	private void OnExitItem()
	{
		this.HideTipsDetail();
	}

	// Token: 0x0600EE55 RID: 61013 RVA: 0x0041184B File Offset: 0x0040FA4B
	private void OnCheckAttrItem([Nullable(2)] HonamiStoryEquipGridItem item, HonamiStoryInteractOperateAgent operateAgent)
	{
		this.ShowTipsAttrChange(item, operateAgent);
	}

	// Token: 0x0600EE56 RID: 61014 RVA: 0x00411855 File Offset: 0x0040FA55
	private void OnClickItem([Nullable(2)] HonamiStoryItemGridItem item, Vector2D loc, Vector2D size, EHonamiStoryBackpackType type)
	{
		this.HideTipsDetail();
		this.ShowTips(item, loc, size, type);
	}

	// Token: 0x0600EE57 RID: 61015 RVA: 0x00411868 File Offset: 0x0040FA68
	private void OnClickMask()
	{
		Action onTipsClickCb = this.OnTipsClickCb;
		if (onTipsClickCb == null)
		{
			return;
		}
		onTipsClickCb();
	}

	// Token: 0x0600EE58 RID: 61016 RVA: 0x0041187A File Offset: 0x0040FA7A
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		if (last == EInputControllerMainType.Gamepad)
		{
			ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().SwitchToKeyboardState();
			return;
		}
		if (now == EInputControllerMainType.Gamepad)
		{
			ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().SwitchToGamepadState(false);
		}
	}

	// Token: 0x0600EE59 RID: 61017 RVA: 0x004118A4 File Offset: 0x0040FAA4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length == 0)
		{
			return null;
		}
		string a = configParams[0];
		if (a == "RolePanel" || a == "Equips" || a == "AddBtn" || a == "UpdateBtn" || a == "Capybara" || a == "SuitDesc")
		{
			HonamiStoryEquipBackpackPanel equipPanel = this.EquipPanel;
			if (equipPanel == null)
			{
				return null;
			}
			return equipPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else if (a == "BtnSell" || a == "ToggleSelect" || a == "BtnReset" || a == "Item")
		{
			HonamiStoryBackpackPanel backpackPanel = this.BackpackPanel;
			if (backpackPanel == null)
			{
				return null;
			}
			return backpackPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			if (!(a == "SkillRoleText"))
			{
				if (a == "Plugin")
				{
					HonamiStoryEquipBackpackPanel equipPanel2 = this.EquipPanel;
					UUIItem[] array = (equipPanel2 != null) ? equipPanel2.GetGuideUiItemAndUiItemForShowEx(configParams) : null;
					if (array != null && array.Length != 0)
					{
						return array;
					}
					HonamiStoryBackpackPanel backpackPanel2 = this.BackpackPanel;
					UUIItem[] array2 = (backpackPanel2 != null) ? backpackPanel2.GetGuideUiItemAndUiItemForShowEx(configParams) : null;
					if (array2 != null && array2.Length != 0)
					{
						return array2;
					}
				}
				return null;
			}
			HonamiStoryItemTipsBase tipsItem = this.TipsItem;
			if (tipsItem == null)
			{
				return null;
			}
			return tipsItem.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x04007257 RID: 29271
	private HonamiStoryEquipBackpackPanel EquipPanel;

	// Token: 0x04007258 RID: 29272
	private HonamiStoryBackpackPanel BackpackPanel;

	// Token: 0x04007259 RID: 29273
	private HonamiStoryDiscardBackpackPanel DiscardPanel;

	// Token: 0x0400725A RID: 29274
	private readonly HonamiStoryInteractController DragController = new HonamiStoryInteractController();

	// Token: 0x0400725B RID: 29275
	private readonly HonamiStoryBackpackLogicController BackpackLogicController = new HonamiStoryBackpackLogicController();

	// Token: 0x0400725C RID: 29276
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x0400725D RID: 29277
	[Nullable(2)]
	private HonamiStoryItemTipsBase TipsItem;

	// Token: 0x0400725E RID: 29278
	[Nullable(2)]
	private HonamiStoryItemTipsDetail TipsItemDetail;

	// Token: 0x0400725F RID: 29279
	[Nullable(2)]
	private HonamiStoryItemTipsAttrChange TipsAttrChange;

	// Token: 0x04007260 RID: 29280
	[Nullable(2)]
	private HonamiStoryItemTipsHotKey TipsItemHotkey;

	// Token: 0x04007261 RID: 29281
	[Nullable(2)]
	private Action OnTipsClickCb;

	// Token: 0x04007262 RID: 29282
	private float BasePanelHeight;

	// Token: 0x04007263 RID: 29283
	[Nullable(2)]
	private HonamiStorySkillDescToggle DescToggleItem;

	// Token: 0x0200828C RID: 33420
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C47A RID: 181370
		EquipPanel,
		// Token: 0x0402C47B RID: 181371
		BackpackPanel,
		// Token: 0x0402C47C RID: 181372
		AttachPanel,
		// Token: 0x0402C47D RID: 181373
		DeletePanel,
		// Token: 0x0402C47E RID: 181374
		CaptionItem,
		// Token: 0x0402C47F RID: 181375
		PanelTips,
		// Token: 0x0402C480 RID: 181376
		BtnMask,
		// Token: 0x0402C481 RID: 181377
		DescToggleItem
	}
}
