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

// Token: 0x02001F47 RID: 8007
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryPickUpBackpackView : UiViewBase
{
	// Token: 0x0600EF9E RID: 61342 RVA: 0x00417BBF File Offset: 0x00415DBF
	public HonamiStoryPickUpBackpackView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0600EF9F RID: 61343 RVA: 0x00417BE0 File Offset: 0x00415DE0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 9;
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
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(6, new Action(this.OnClickMask));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600EFA0 RID: 61344 RVA: 0x00417D70 File Offset: 0x00415F70
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryPickUpBackpackView.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryPickUpBackpackView.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFA1 RID: 61345 RVA: 0x00417DB3 File Offset: 0x00415FB3
	protected override void OnStart()
	{
		this.InitTipsItem();
	}

	// Token: 0x0600EFA2 RID: 61346 RVA: 0x00417DBC File Offset: 0x00415FBC
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

	// Token: 0x0600EFA3 RID: 61347 RVA: 0x00417E0E File Offset: 0x0041600E
	protected override void OnBeforeDestroy()
	{
		ModelBase<HonamiStoryModel>.Instance.SetGamepadLogic(null);
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogic(null);
	}

	// Token: 0x0600EFA4 RID: 61348 RVA: 0x00417E28 File Offset: 0x00416028
	private UniTask InitPlayerBackpackPanel()
	{
		HonamiStoryPickUpBackpackView.<InitPlayerBackpackPanel>d__21 <InitPlayerBackpackPanel>d__;
		<InitPlayerBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPlayerBackpackPanel>d__.<>4__this = this;
		<InitPlayerBackpackPanel>d__.<>1__state = -1;
		<InitPlayerBackpackPanel>d__.<>t__builder.Start<HonamiStoryPickUpBackpackView.<InitPlayerBackpackPanel>d__21>(ref <InitPlayerBackpackPanel>d__);
		return <InitPlayerBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFA5 RID: 61349 RVA: 0x00417E6C File Offset: 0x0041606C
	private UniTask InitBackpackPanel()
	{
		HonamiStoryPickUpBackpackView.<InitBackpackPanel>d__22 <InitBackpackPanel>d__;
		<InitBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitBackpackPanel>d__.<>4__this = this;
		<InitBackpackPanel>d__.<>1__state = -1;
		<InitBackpackPanel>d__.<>t__builder.Start<HonamiStoryPickUpBackpackView.<InitBackpackPanel>d__22>(ref <InitBackpackPanel>d__);
		return <InitBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFA6 RID: 61350 RVA: 0x00417EB0 File Offset: 0x004160B0
	private UniTask InitDiscardBackpackPanel()
	{
		HonamiStoryPickUpBackpackView.<InitDiscardBackpackPanel>d__23 <InitDiscardBackpackPanel>d__;
		<InitDiscardBackpackPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitDiscardBackpackPanel>d__.<>4__this = this;
		<InitDiscardBackpackPanel>d__.<>1__state = -1;
		<InitDiscardBackpackPanel>d__.<>t__builder.Start<HonamiStoryPickUpBackpackView.<InitDiscardBackpackPanel>d__23>(ref <InitDiscardBackpackPanel>d__);
		return <InitDiscardBackpackPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFA7 RID: 61351 RVA: 0x00417EF4 File Offset: 0x004160F4
	private UniTask InitTipsItem()
	{
		HonamiStoryPickUpBackpackView.<InitTipsItem>d__24 <InitTipsItem>d__;
		<InitTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitTipsItem>d__.<>4__this = this;
		<InitTipsItem>d__.<>1__state = -1;
		<InitTipsItem>d__.<>t__builder.Start<HonamiStoryPickUpBackpackView.<InitTipsItem>d__24>(ref <InitTipsItem>d__);
		return <InitTipsItem>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFA8 RID: 61352 RVA: 0x00417F38 File Offset: 0x00416138
	private UniTask InitPickUpPanel()
	{
		HonamiStoryPickUpBackpackView.<InitPickUpPanel>d__25 <InitPickUpPanel>d__;
		<InitPickUpPanel>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<InitPickUpPanel>d__.<>4__this = this;
		<InitPickUpPanel>d__.<>1__state = -1;
		<InitPickUpPanel>d__.<>t__builder.Start<HonamiStoryPickUpBackpackView.<InitPickUpPanel>d__25>(ref <InitPickUpPanel>d__);
		return <InitPickUpPanel>d__.<>t__builder.Task;
	}

	// Token: 0x0600EFA9 RID: 61353 RVA: 0x00417F7C File Offset: 0x0041617C
	private void ShowTips([Nullable(2)] HonamiStoryItemGridItem item, Vector2D loc, Vector2D size, EHonamiStoryBackpackType packType)
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
		tipsItem.Refresh(data, packType, data.GetPosition(), new Action(item.OnHideCallback), loc, size);
	}

	// Token: 0x0600EFAA RID: 61354 RVA: 0x00417FDC File Offset: 0x004161DC
	public void ShowTipsHotKeyOnly(HonamiStoryGridItemBase item)
	{
		if (ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic() != null)
		{
			this.TipsItemHotkey.GetRootItem().SetUIParent(base.GetItem(5), false);
			this.TipsItemHotkey.SetAutoLocation(item.GetRootItem());
			this.TipsItemHotkey.SetUiActive(true);
		}
	}

	// Token: 0x0600EFAB RID: 61355 RVA: 0x0041802A File Offset: 0x0041622A
	public void HideAllTips()
	{
		HonamiStoryItemTipsBase tipsItem = this.TipsItem;
		if (tipsItem != null)
		{
			tipsItem.SetUiActive(false);
		}
		this.TipsItemDetail.SetUiActive(false);
		this.TipsAttrChange.SetUiActive(false);
		this.TipsItemHotkey.SetUiActive(false);
	}

	// Token: 0x0600EFAC RID: 61356 RVA: 0x00418064 File Offset: 0x00416264
	[NullableContext(2)]
	private void ShowTipsDetail(HonamiStoryItemGridItem item, EHonamiStoryBackpackType type)
	{
		bool flag = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogicState() == EHonamiStoryBackpackLogicState.Sell;
		bool active = this.TipsItem.GetActive();
		if (item == null || item.GetData() == null || flag || active)
		{
			return;
		}
		HonamiStoryItemDataBase data = item.GetData();
		ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().SetCurItem(item);
		this.TipsItemDetail.Refresh(data, type);
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.TipsItemDetail.AddHotKey(this.TipsItemHotkey.GetRootItem());
		}
		this.TipsItemDetail.SetAutoLocation(item.GetRootItem());
		this.TipsItemDetail.SetUiActive(true);
	}

	// Token: 0x0600EFAD RID: 61357 RVA: 0x00418104 File Offset: 0x00416304
	private void HideTipsDetail()
	{
		this.TipsItemDetail.SetUiActive(false);
	}

	// Token: 0x0600EFAE RID: 61358 RVA: 0x00418114 File Offset: 0x00416314
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
		HonamiStoryEquipItemData honamiStoryEquipItemData = (HonamiStoryEquipItemData)ModelBase<HonamiStoryModel>.Instance.GetItemData(data.GetIncId());
		HonamiStoryEquipItemData newData = (HonamiStoryEquipItemData)ModelBase<HonamiStoryModel>.Instance.GetItemData(operateAgent.OperateData.GetIncId());
		if (honamiStoryEquipItemData == null)
		{
			return;
		}
		this.TipsAttrChange.SetUiActive(true);
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			this.TipsAttrChange.Refresh(honamiStoryEquipItemData, newData, delegate
			{
				this.TipsAttrChange.GetRootItem().SetUIParent(this.DragController.GetDragTipsRoot(), false);
				this.TipsAttrChange.AddHotKey(this.TipsItemHotkey.GetRootItem());
			});
			return;
		}
		this.TipsAttrChange.Refresh(honamiStoryEquipItemData, newData, delegate
		{
			this.TipsAttrChange.GetRootItem().SetUIParent(this.DragController.GetDragTipsRoot(), false);
		});
	}

	// Token: 0x0600EFAF RID: 61359 RVA: 0x004181DE File Offset: 0x004163DE
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

	// Token: 0x0600EFB0 RID: 61360 RVA: 0x004181FB File Offset: 0x004163FB
	protected override void OnAddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
	}

	// Token: 0x0600EFB1 RID: 61361 RVA: 0x00418219 File Offset: 0x00416419
	protected override void OnRemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
	}

	// Token: 0x0600EFB2 RID: 61362 RVA: 0x00418238 File Offset: 0x00416438
	public void OnEnterGamepadMask()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Drag_Hide", false, null);
	}

	// Token: 0x0600EFB3 RID: 61363 RVA: 0x00418264 File Offset: 0x00416464
	public void OnExitGamepadMask()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Drag_Show", false, null);
	}

	// Token: 0x0600EFB4 RID: 61364 RVA: 0x00418290 File Offset: 0x00416490
	public void OnDragBegin()
	{
		UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
		if (uiViewSequence == null)
		{
			return;
		}
		uiViewSequence.PlaySequence("Drag_Hide", false, null);
	}

	// Token: 0x0600EFB5 RID: 61365 RVA: 0x004182BC File Offset: 0x004164BC
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

	// Token: 0x0600EFB6 RID: 61366 RVA: 0x004182FA File Offset: 0x004164FA
	private void OnClickCloseButton()
	{
		base.CloseMe(null);
	}

	// Token: 0x0600EFB7 RID: 61367 RVA: 0x00418303 File Offset: 0x00416503
	[NullableContext(2)]
	private void OnEnterItem(HonamiStoryItemGridItem item, EHonamiStoryBackpackType type)
	{
		this.ShowTipsDetail(item, type);
	}

	// Token: 0x0600EFB8 RID: 61368 RVA: 0x0041830D File Offset: 0x0041650D
	private void OnExitItem()
	{
		this.HideTipsDetail();
	}

	// Token: 0x0600EFB9 RID: 61369 RVA: 0x00418315 File Offset: 0x00416515
	private void OnCheckAttrItem([Nullable(2)] HonamiStoryEquipGridItem item, HonamiStoryInteractOperateAgent operateAgent)
	{
		this.ShowTipsAttrChange(item, operateAgent);
	}

	// Token: 0x0600EFBA RID: 61370 RVA: 0x0041831F File Offset: 0x0041651F
	private void OnClickItem([Nullable(2)] HonamiStoryItemGridItem data, Vector2D loc, Vector2D size, EHonamiStoryBackpackType packType)
	{
		this.HideTipsDetail();
		this.ShowTips(data, loc, size, packType);
	}

	// Token: 0x0600EFBB RID: 61371 RVA: 0x00418332 File Offset: 0x00416532
	private void OnClickMask()
	{
		Action onTipsClickCb = this.OnTipsClickCb;
		if (onTipsClickCb == null)
		{
			return;
		}
		onTipsClickCb();
	}

	// Token: 0x0600EFBC RID: 61372 RVA: 0x00418344 File Offset: 0x00416544
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		if (last == EInputControllerMainType.Gamepad)
		{
			ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().SwitchToKeyboardState();
			return;
		}
		if (now == EInputControllerMainType.Gamepad)
		{
			ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic().SwitchToGamepadState(true);
		}
	}

	// Token: 0x0600EFBD RID: 61373 RVA: 0x00418370 File Offset: 0x00416570
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
		if (a == "RolePanel" || a == "Equips" || a == "AddBtn" || a == "UpdateBtn")
		{
			HonamiStoryEquipBackpackPanel equipPanel = this.EquipPanel;
			if (equipPanel == null)
			{
				return null;
			}
			return equipPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
		else
		{
			if (!(a == "BtnSell") && !(a == "ToggleSelect") && !(a == "BtnReset"))
			{
				return null;
			}
			HonamiStoryBackpackPanel backpackPanel = this.BackpackPanel;
			if (backpackPanel == null)
			{
				return null;
			}
			return backpackPanel.GetGuideUiItemAndUiItemForShowEx(configParams);
		}
	}

	// Token: 0x0400733B RID: 29499
	private HonamiStoryEquipBackpackPanel EquipPanel;

	// Token: 0x0400733C RID: 29500
	private HonamiStoryBackpackPanel BackpackPanel;

	// Token: 0x0400733D RID: 29501
	private HonamiStoryBackpackPanel PickUpPanel;

	// Token: 0x0400733E RID: 29502
	private HonamiStoryDiscardBackpackPanel DiscardPanel;

	// Token: 0x0400733F RID: 29503
	private readonly HonamiStoryInteractController DragController = new HonamiStoryInteractController();

	// Token: 0x04007340 RID: 29504
	private readonly HonamiStoryBackpackLogicController BackpackLogicController = new HonamiStoryBackpackLogicController();

	// Token: 0x04007341 RID: 29505
	[Nullable(2)]
	private PopupCaptionItem CaptionItem;

	// Token: 0x04007342 RID: 29506
	[Nullable(2)]
	private HonamiStoryItemTipsBase TipsItem;

	// Token: 0x04007343 RID: 29507
	[Nullable(2)]
	private HonamiStoryItemTipsDetail TipsItemDetail;

	// Token: 0x04007344 RID: 29508
	[Nullable(2)]
	private HonamiStoryItemTipsAttrChange TipsAttrChange;

	// Token: 0x04007345 RID: 29509
	[Nullable(2)]
	private HonamiStoryItemTipsHotKey TipsItemHotkey;

	// Token: 0x04007346 RID: 29510
	[Nullable(2)]
	private HonamiStorySkillDescToggle DescToggleItem;

	// Token: 0x04007347 RID: 29511
	private float BasePanelHeight;

	// Token: 0x04007348 RID: 29512
	[Nullable(2)]
	private Action OnTipsClickCb;

	// Token: 0x020082C3 RID: 33475
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402C56B RID: 181611
		EquipPanel,
		// Token: 0x0402C56C RID: 181612
		BackpackPanel,
		// Token: 0x0402C56D RID: 181613
		PickUpPanel,
		// Token: 0x0402C56E RID: 181614
		AttachPanel,
		// Token: 0x0402C56F RID: 181615
		CaptionItem,
		// Token: 0x0402C570 RID: 181616
		PanelTips,
		// Token: 0x0402C571 RID: 181617
		BtnMask,
		// Token: 0x0402C572 RID: 181618
		DescToggleItem,
		// Token: 0x0402C573 RID: 181619
		DeletePanel
	}
}
