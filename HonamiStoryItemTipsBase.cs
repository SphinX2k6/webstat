using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.HonamiStory;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001F10 RID: 7952
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryItemTipsBase : UiPanelBase
{
	// Token: 0x0600ED9A RID: 60826 RVA: 0x0040CD80 File Offset: 0x0040AF80
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUISprite)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIVerticalLayout)),
			new ValueTuple<int, Type>(12, typeof(UUIItem)),
			new ValueTuple<int, Type>(13, typeof(UUIText)),
			new ValueTuple<int, Type>(14, typeof(UUIItem)),
			new ValueTuple<int, Type>(15, typeof(UUIItem)),
			new ValueTuple<int, Type>(16, typeof(UUIItem)),
			new ValueTuple<int, Type>(17, typeof(UUIItem)),
			new ValueTuple<int, Type>(18, typeof(UUIItem)),
			new ValueTuple<int, Type>(19, typeof(UUIItem)),
			new ValueTuple<int, Type>(20, typeof(UUIItem)),
			new ValueTuple<int, Type>(21, typeof(UUIItem)),
			new ValueTuple<int, Type>(22, typeof(UUITexture)),
			new ValueTuple<int, Type>(23, typeof(UUIItem)),
			new ValueTuple<int, Type>(24, typeof(UUIItem)),
			new ValueTuple<int, Type>(25, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(6, new Action<EToggleState>(this.OnClickedLock))
		};
	}

	// Token: 0x0600ED9B RID: 60827 RVA: 0x0040D008 File Offset: 0x0040B208
	protected override void OnBeforeCreateImplement()
	{
		this.LevelPlaySequence = new UiBehaviorLevelSequence(this);
		base.AddUiBehavior(this.LevelPlaySequence);
		this.LevelPlaySequence.AddSequenceFinishEvent("Close", new Action<string>(this.OnCloseSequenceFinish), false);
		this.LevelPlaySequence.AddSequenceStartEvent("Start", new Action<string>(this.OnCloseSequenceStart));
	}

	// Token: 0x0600ED9C RID: 60828 RVA: 0x0040D068 File Offset: 0x0040B268
	protected override UniTask OnBeforeStartAsync()
	{
		HonamiStoryItemTipsBase.<OnBeforeStartAsync>d__28 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<HonamiStoryItemTipsBase.<OnBeforeStartAsync>d__28>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600ED9D RID: 60829 RVA: 0x0040D0AC File Offset: 0x0040B2AC
	protected override void OnStart()
	{
		UUIItem item = base.GetItem(19);
		this.SideButtonWidth = ((item != null) ? item.GetWidth() : 0f);
		Singleton<EventSystem>.Instance.Add(EEventName.OnHonamiStorySkillDescModeChange, new Action<bool>(this.OnSkillDescModeChange));
		Singleton<EventSystem>.Instance.Add(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
	}

	// Token: 0x0600ED9E RID: 60830 RVA: 0x0040D110 File Offset: 0x0040B310
	protected override void OnBeforeDestroy()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnHonamiStorySkillDescModeChange, new Action<bool>(this.OnSkillDescModeChange));
		Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerMainTypeChange, new Action<EInputControllerMainType, EInputControllerMainType>(this.OnInputControllerMainTypeChange));
		this.ButtonRightA = null;
		this.ButtonLeftA = null;
		this.ButtonLeftB = null;
		this.ButtonRightB = null;
	}

	// Token: 0x0600ED9F RID: 60831 RVA: 0x0040D174 File Offset: 0x0040B374
	protected void InitButtonState()
	{
		this.ConfirmQuick = new ButtonItem(base.GetItem(15));
		this.ConfirmQuick.SetFunction(new Action<int>(this.OnClickedQuick));
		this.ConfirmQuick.SetLocalTextNew("HonamiStory_Tips_QuickEquipped", Array.Empty<object>());
		this.ConfirmRight = new ButtonItem(base.GetItem(14));
		this.ConfirmRight.SetFunction(new Action<int>(this.OnClickedConfirm));
		string textId = (this.TipsState == EHonamiStoryTipsState.InGame) ? "HonamiStory_Tips_Drop" : "HonamiStory_Tips_Sell";
		this.ConfirmRight.SetLocalTextNew(textId, Array.Empty<object>());
	}

	// Token: 0x0600EDA0 RID: 60832 RVA: 0x0040D210 File Offset: 0x0040B410
	protected void RefreshButton(HonamiStoryItemDataBase data, EHonamiStoryBackpackType backpackType)
	{
		UUIExtendToggle extendToggle = base.GetExtendToggle(6);
		if (extendToggle != null)
		{
			extendToggle.RootUIComp.Get().SetUIActive(backpackType != EHonamiStoryBackpackType.PickUpBox);
		}
		if (backpackType != EHonamiStoryBackpackType.PickUpBox)
		{
			EToggleState state = data.IsLock() ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			UUIExtendToggle extendToggle2 = base.GetExtendToggle(6);
			if (extendToggle2 != null)
			{
				extendToggle2.SetToggleState(state, false, false, false);
			}
		}
		this.RefreshConfirmButton(data, backpackType);
		this.RefreshSideButton(data, backpackType);
	}

	// Token: 0x0600EDA1 RID: 60833 RVA: 0x0040D27C File Offset: 0x0040B47C
	protected void RefreshConfirmButton(HonamiStoryItemDataBase data, EHonamiStoryBackpackType backpackType)
	{
		if (this.TipsState == EHonamiStoryTipsState.ShopView)
		{
			ButtonItem confirmRight = this.ConfirmRight;
			if (confirmRight != null)
			{
				confirmRight.SetUiActive(false);
			}
			ButtonItem confirmQuick = this.ConfirmQuick;
			if (confirmQuick != null)
			{
				confirmQuick.SetUiActive(false);
			}
			UUIItem item = base.GetItem(23);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			EHonamiStoryItemType itemType = data.GetItemType();
			bool flag = itemType == EHonamiStoryItemType.Plugin || backpackType == EHonamiStoryBackpackType.PickUpBox;
			ButtonItem confirmQuick2 = this.ConfirmQuick;
			if (confirmQuick2 != null)
			{
				confirmQuick2.SetUiActive(flag);
			}
			if (backpackType == EHonamiStoryBackpackType.PickUpBox)
			{
				ButtonItem confirmRight2 = this.ConfirmRight;
				if (confirmRight2 != null)
				{
					confirmRight2.SetUiActive(false);
				}
				bool flag2 = false;
				ButtonItem confirmQuick3 = this.ConfirmQuick;
				if (confirmQuick3 != null)
				{
					confirmQuick3.SetLocalTextNew("HonamiStory_Tips_QuickPickUp", Array.Empty<object>());
				}
				UUIItem item2 = base.GetItem(23);
				if (item2 == null)
				{
					return;
				}
				item2.SetUIActive(flag2 || flag);
				return;
			}
			else
			{
				if ((backpackType == EHonamiStoryBackpackType.Backpack || backpackType == EHonamiStoryBackpackType.Inventory) && itemType == EHonamiStoryItemType.Plugin)
				{
					ButtonItem confirmQuick4 = this.ConfirmQuick;
					if (confirmQuick4 != null)
					{
						confirmQuick4.SetLocalTextNew("HonamiStory_Tips_QuickEquipped", Array.Empty<object>());
					}
				}
				else if (backpackType == EHonamiStoryBackpackType.Player)
				{
					ButtonItem confirmQuick5 = this.ConfirmQuick;
					if (confirmQuick5 != null)
					{
						confirmQuick5.SetLocalTextNew("HonamiStory_Tips_QuickUnload", Array.Empty<object>());
					}
				}
				bool flag2 = this.TipsState == EHonamiStoryTipsState.InGame || this.ActivityOpen;
				ButtonItem confirmRight3 = this.ConfirmRight;
				if (confirmRight3 != null)
				{
					confirmRight3.SetUiActive(flag2);
				}
				UUIItem item3 = base.GetItem(23);
				if (item3 == null)
				{
					return;
				}
				item3.SetUIActive(flag2 || flag);
				return;
			}
		}
	}

	// Token: 0x0600EDA2 RID: 60834 RVA: 0x0040D3BC File Offset: 0x0040B5BC
	protected void RefreshSideButton(HonamiStoryItemDataBase data, EHonamiStoryBackpackType backpackType)
	{
		bool flag = data.GetItemType() == EHonamiStoryItemType.Plugin && backpackType != EHonamiStoryBackpackType.Player;
		this.ButtonLeftA.SetUiActive(flag);
		this.ButtonRightA.SetUiActive(flag);
		bool flag2 = backpackType != EHonamiStoryBackpackType.Backpack && backpackType > EHonamiStoryBackpackType.Inventory;
		this.ButtonLeftB.SetUiActive(flag2);
		this.ButtonRightB.SetUiActive(flag2);
		this.SideButtonActive = (flag2 || flag);
	}

	// Token: 0x0600EDA3 RID: 60835 RVA: 0x0040D424 File Offset: 0x0040B624
	public bool Refresh(HonamiStoryItemDataBase data, EHonamiStoryBackpackType backpackType, int curPos, Action cb, Vector2D gridLoc, Vector2D gridSize)
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		if (data == this.ItemData)
		{
			this.ItemData = null;
			this.OnClickedMask();
			return false;
		}
		if (this.OnHideCb != null)
		{
			this.OnHideCb();
		}
		this.GridLoc = gridLoc;
		this.GridSize = gridSize;
		this.OnHideCb = cb;
		this.SetTipsVisible(true);
		EHonamiStoryBackpackLogicState state = (data.GetItemType() == EHonamiStoryItemType.Plugin) ? EHonamiStoryBackpackLogicState.TipsWithPlugins : EHonamiStoryBackpackLogicState.Tips;
		HonamiStoryItemDataBase insteadItem = (data.GetItemType() == EHonamiStoryItemType.Plugin) ? data : null;
		EHonamiStoryBackpack value;
		if (!Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap.TryGetValue(backpackType, out value))
		{
			return false;
		}
		backpackLogic.SetLogicState(state, insteadItem, new EHonamiStoryBackpack?(value));
		this.CurrentPos = curPos;
		this.ItemData = data;
		this.BackpackType = backpackType;
		this.RefreshButton(data, backpackType);
		this.RefreshDoubleClicked();
		string name = data.GetName();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), name, Array.Empty<object>());
		string desc = data.GetDesc();
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(13), desc, Array.Empty<object>());
		UUIItem item = base.GetItem(7);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		string resourceId = (data.GetItemType() == EHonamiStoryItemType.Plugin) ? "SP_TipsTypeIcon1" : "SP_TipsTypeIcon2";
		UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
		string text = (instance != null) ? instance.GetResourcePath(resourceId) : null;
		this.SetSpriteByPath(text ?? string.Empty, base.GetSprite(2), false, null, null);
		string text2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey(data.GetItemTypeText());
		if (!Singleton<Info>.Instance.IsBuildShipping)
		{
			string str = text2;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 1);
			defaultInterpolatedStringHandler.AppendLiteral(" ID:");
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetItemId());
			text2 = str + defaultInterpolatedStringHandler.ToStringAndClear();
			if (data.GetItemType() == EHonamiStoryItemType.Plugin)
			{
				HonamiStoryEquipItemData honamiStoryEquipItemData = data as HonamiStoryEquipItemData;
				string str2 = text2;
				defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(13, 2);
				defaultInterpolatedStringHandler.AppendLiteral(" Type:");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetSubType());
				defaultInterpolatedStringHandler.AppendLiteral(" Power:");
				defaultInterpolatedStringHandler.AppendFormatted<int?>((honamiStoryEquipItemData != null) ? new int?(honamiStoryEquipItemData.GetBaseEnhance()) : null);
				text2 = str2 + defaultInterpolatedStringHandler.ToStringAndClear();
			}
		}
		UUIText text3 = base.GetText(3);
		if (text3 != null)
		{
			text3.SetText(text2, true);
		}
		UUITexture texture = base.GetTexture(22);
		base.SetItemIcon(texture, data.GetItemId(), null, null);
		this.SetSpriteByPath(ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(data.GetQuality()).Value.Bg, base.GetSprite(1), false, null, null);
		UUIText text4 = base.GetText(5);
		if (text4 != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
			defaultInterpolatedStringHandler.AppendFormatted<int>(data.GetSellPrice());
			text4.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		int itemType = (int)data.GetItemType();
		this.UpdateHeight = 0f;
		if (itemType != 2)
		{
			HonamiStoryEquipItemData honamiStoryEquipItemData2 = data as HonamiStoryEquipItemData;
			if (honamiStoryEquipItemData2 == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module = ELogModule.HonamiStory;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SDC Data Transform Fail";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", data.GetItemId());
				instance2.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int[] mainPropList = honamiStoryEquipItemData2.GetMainPropList();
			List<IHonamiStoryTipsPropertyData> list = new List<IHonamiStoryTipsPropertyData>();
			foreach (int propId in mainPropList)
			{
				list.Add(new HonamiStoryTipsPropertyData
				{
					PropId = propId
				});
			}
			List<IHonamiStoryTipsBuffInfo> buffTempIdList = honamiStoryEquipItemData2.GetBuffTempIdList(false);
			GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData> propertyLayout = this.PropertyLayout;
			if (propertyLayout != null)
			{
				propertyLayout.RefreshByDataDirectlySync(list);
			}
			GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> skillLayout = this.SkillLayout;
			if (skillLayout != null)
			{
				skillLayout.RefreshByDataDirectlySync(buffTempIdList);
			}
		}
		else
		{
			GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData> propertyLayout2 = this.PropertyLayout;
			if (propertyLayout2 != null)
			{
				propertyLayout2.RefreshByDataDirectlySync(new List<IHonamiStoryTipsPropertyData>());
			}
			GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> skillLayout2 = this.SkillLayout;
			if (skillLayout2 != null)
			{
				skillLayout2.RefreshByDataDirectlySync(new List<IHonamiStoryTipsBuffInfo>());
			}
		}
		return true;
	}

	// Token: 0x0600EDA4 RID: 60836 RVA: 0x0040D7F0 File Offset: 0x0040B9F0
	public void SetAutoLocation(Vector2D gridLoc, Vector2D gridSize)
	{
		float width = this.RootItem.GetWidth();
		float height = this.RootItem.GetHeight();
		FVector uiworldPosition = this.RootItem.GetUIWorldPosition();
		FVector2D viewportSize = UWidgetLayoutLibrary.GetViewportSize(GlobalData.World);
		float viewportScale = UWidgetLayoutLibrary.GetViewportScale(GlobalData.World);
		float num = viewportSize.X / viewportScale;
		float num2 = viewportSize.Y / viewportScale;
		float num3 = num / 2f;
		float num4 = num2 / 2f;
		double num5 = gridLoc.X + gridSize.X / 2.0;
		double y = gridLoc.Y;
		float num6 = this.SideButtonActive ? this.SideButtonWidth : 0f;
		int num7 = Singleton<Info>.Instance.IsMobileInputModel() ? 0 : 60;
		bool flag = num5 + (double)width + (double)num6 + (double)num7 < (double)num3;
		bool flag2 = y - (double)height > (double)(-(double)num4 + 100f);
		double num8;
		if (flag)
		{
			num8 = num5 + (double)(width / 2f) + (double)num7;
		}
		else
		{
			num8 = gridLoc.X - gridSize.X / 2.0 - (double)(width / 2f);
		}
		double num9;
		if (flag2)
		{
			num9 = y + gridSize.Y / 2.0;
		}
		else
		{
			num9 = (double)(-(double)num4 + height + this.BottomOffset);
		}
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			UUIItem item = base.GetItem(19);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIItem item2 = base.GetItem(16);
			if (item2 != null)
			{
				item2.SetUIActive(false);
			}
		}
		else if (Singleton<Info>.Instance.IsMobileInputModel())
		{
			bool flag3 = false;
			if (this.SideButtonActive)
			{
				flag3 = (num5 + (double)(width / 2f) + (double)this.SideButtonWidth > 0.0);
				if (!flag3)
				{
					num8 += (double)this.SideButtonWidth;
				}
				else if (!flag)
				{
					num8 -= (double)this.SideButtonWidth;
				}
			}
			UUIItem item3 = base.GetItem(19);
			if (item3 != null)
			{
				item3.SetUIActive(!flag3 && this.SideButtonActive);
			}
			UUIItem item4 = base.GetItem(16);
			if (item4 != null)
			{
				item4.SetUIActive(flag3 && this.SideButtonActive);
			}
		}
		else
		{
			UUIItem item5 = base.GetItem(19);
			if (item5 != null)
			{
				item5.SetUIActive(false);
			}
			UUIItem item6 = base.GetItem(16);
			if (item6 != null)
			{
				item6.SetUIActive(this.SideButtonActive);
			}
			if (!flag && this.SideButtonActive)
			{
				num8 -= (double)this.SideButtonWidth;
			}
		}
		FVector fvector = new FVector((float)num8, uiworldPosition.Y, (float)num9);
		this.RootItem.SetUIWorldLocation(fvector);
	}

	// Token: 0x0600EDA5 RID: 60837 RVA: 0x0040DA83 File Offset: 0x0040BC83
	public void SetMaskAttach(UUIButtonComponent uiItem)
	{
		this.MaskButton = uiItem;
	}

	// Token: 0x0600EDA6 RID: 60838 RVA: 0x0040DA8C File Offset: 0x0040BC8C
	public void SetTipsVisible(bool isVisible)
	{
		this.MaskButton.RootUIComp.Get().SetUIActive(isVisible);
		if (isVisible)
		{
			UiBehaviorLevelSequence levelPlaySequence = this.LevelPlaySequence;
			if (levelPlaySequence != null)
			{
				levelPlaySequence.PlaySequence("Start", false, null);
			}
		}
		else
		{
			UiBehaviorLevelSequence levelPlaySequence2 = this.LevelPlaySequence;
			if (levelPlaySequence2 != null)
			{
				levelPlaySequence2.PlaySequence("Close", false, null);
			}
		}
		if (!isVisible)
		{
			this.ItemData = null;
			ModelBase<HonamiStoryModel>.Instance.GetInteractController().OnClickedItem(false, -1, null);
			if (this.OnHideCb != null)
			{
				this.OnHideCb();
			}
			this.OnHideCb = null;
		}
	}

	// Token: 0x0600EDA7 RID: 60839 RVA: 0x0040DB2D File Offset: 0x0040BD2D
	[NullableContext(2)]
	public void SetItemDataOut(HonamiStoryItemDataBase data)
	{
		this.ItemData = data;
	}

	// Token: 0x0600EDA8 RID: 60840 RVA: 0x0040DB36 File Offset: 0x0040BD36
	[NullableContext(2)]
	public HonamiStoryItemDataBase GetItemDataOut()
	{
		return this.ItemData;
	}

	// Token: 0x0600EDA9 RID: 60841 RVA: 0x0040DB3E File Offset: 0x0040BD3E
	public void SetTipsState(EHonamiStoryTipsState state)
	{
		this.TipsState = state;
	}

	// Token: 0x0600EDAA RID: 60842 RVA: 0x0040DB47 File Offset: 0x0040BD47
	public void SetBottomOffset(float value)
	{
		this.BottomOffset = value;
	}

	// Token: 0x0600EDAB RID: 60843 RVA: 0x0040DB50 File Offset: 0x0040BD50
	protected void OnDiscardItem()
	{
		if (this.ItemData.IsLock())
		{
			this.SetTipsVisible(false);
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_TryDiscardLockItem", Array.Empty<object>());
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
			return;
		}
		EHonamiStoryBackpack ehonamiStoryBackpack = (this.BackpackType == EHonamiStoryBackpackType.Backpack) ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Player;
		if (ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic().IsBackpackView())
		{
			ControllerBase<HonamiStoryController>.Instance.RequestDiscardItem(this.ItemData, ehonamiStoryBackpack);
			this.SetTipsVisible(false);
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
			return;
		}
		if (ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.ItemData, ehonamiStoryBackpack, EHonamiStoryBackpack.PickUpBox))
		{
			this.SetTipsVisible(false);
			ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
		}
	}

	// Token: 0x0600EDAC RID: 60844 RVA: 0x0040DC00 File Offset: 0x0040BE00
	private void RefreshDoubleClicked()
	{
		if (Singleton<Info>.Instance.IsInGamepad())
		{
			UUIItem item = base.GetItem(24);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(false);
			return;
		}
		else
		{
			bool flag = this.ItemData.GetItemType() == EHonamiStoryItemType.Normal;
			bool flag2 = Singleton<UiManager>.Instance.GetViewByName(EUiViewName.HonamiStoryBackpackView) == null;
			if ((this.BackpackType != EHonamiStoryBackpackType.Inventory && (this.BackpackType != EHonamiStoryBackpackType.Backpack || flag2)) || !flag)
			{
				UUIItem item2 = base.GetItem(24);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				string textStringId = string.Empty;
				if (this.BackpackType == EHonamiStoryBackpackType.Player)
				{
					textStringId = "HonamiStory_DoubleClickTip_UnloadPlugin";
				}
				else if (!flag2)
				{
					textStringId = "HonamiStory_DoubleClickTip_Equip";
				}
				else if (this.BackpackType != EHonamiStoryBackpackType.PickUpBox)
				{
					textStringId = "HonamiStory_DoubleClickTip_Discard";
				}
				else
				{
					textStringId = (flag ? "HonamiStory_DoubleClickTip_Pick" : "HonamiStory_DoubleClickTip_PickPlugin");
				}
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(25), textStringId, Array.Empty<object>());
				return;
			}
			UUIItem item3 = base.GetItem(24);
			if (item3 == null)
			{
				return;
			}
			item3.SetUIActive(false);
			return;
		}
	}

	// Token: 0x0600EDAD RID: 60845 RVA: 0x0040DCF4 File Offset: 0x0040BEF4
	private void OnClickedLock(EToggleState toggleState)
	{
		bool curLock = this.ItemData.IsLock();
		EHonamiStoryBackpack backType;
		if (!Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap.TryGetValue(this.BackpackType, out backType))
		{
			return;
		}
		ControllerBase<HonamiStoryController>.Instance.RequestHonamiStoryLockItem(this.ItemData.GetIncId(), backType, !curLock).ContinueWith(delegate(bool value)
		{
			EToggleState state = (value != curLock) ? EToggleState.ETT_UnChecked : EToggleState.ETT_Checked;
			UUIExtendToggle extendToggle = this.GetExtendToggle(6);
			if (extendToggle != null)
			{
				extendToggle.SetToggleState(state, false, false, false);
			}
			HonamiStoryItemDataBase itemData = this.ItemData;
			if (itemData != null)
			{
				itemData.SetIsLock(!curLock);
			}
			HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
			if (backpackLogic == null)
			{
				return;
			}
			backpackLogic.RefreshItemLockState(this.ItemData, this.BackpackType);
		});
	}

	// Token: 0x0600EDAE RID: 60846 RVA: 0x0040DD6A File Offset: 0x0040BF6A
	public void OnClickedMask()
	{
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
		this.SetTipsVisible(false);
	}

	// Token: 0x0600EDAF RID: 60847 RVA: 0x0040DD7E File Offset: 0x0040BF7E
	private HonamiStoryTipsPropertyItem CreateProp()
	{
		return new HonamiStoryTipsPropertyItem();
	}

	// Token: 0x0600EDB0 RID: 60848 RVA: 0x0040DD85 File Offset: 0x0040BF85
	private HonamiStoryTipsTextItem CreateSkill()
	{
		return new HonamiStoryTipsTextItem();
	}

	// Token: 0x0600EDB1 RID: 60849 RVA: 0x0040DD8C File Offset: 0x0040BF8C
	private void OnClickedQuick(int _)
	{
		if (this.BackpackType == EHonamiStoryBackpackType.Player)
		{
			EHonamiStoryBackpack toBackpack = (this.TipsState == EHonamiStoryTipsState.InGame) ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
			if (!ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.ItemData, EHonamiStoryBackpack.Player, toBackpack))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_NoEnoughSpace", Array.Empty<object>());
				return;
			}
		}
		else if ((this.BackpackType == EHonamiStoryBackpackType.Backpack || this.BackpackType == EHonamiStoryBackpackType.Inventory) && this.ItemData.GetItemType() == EHonamiStoryItemType.Plugin)
		{
			if (!ModelBase<HonamiStoryModel>.Instance.QuickEquipFromBackpack(this.ItemData, this.CurrentPos))
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("HonamiStory_ShowTips_CantQuickEquip", Array.Empty<object>());
				return;
			}
		}
		else if (this.BackpackType == EHonamiStoryBackpackType.PickUpBox)
		{
			ModelBase<HonamiStoryModel>.Instance.QuickPickUpFromPickUpBox(this.ItemData, this.CurrentPos);
		}
		this.SetTipsVisible(false);
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
	}

	// Token: 0x0600EDB2 RID: 60850 RVA: 0x0040DE58 File Offset: 0x0040C058
	private void OnClickedConfirm(int _)
	{
		if (this.TipsState == EHonamiStoryTipsState.InGame)
		{
			this.OnDiscardItem();
			return;
		}
		if (this.TipsState == EHonamiStoryTipsState.Inventory)
		{
			EHonamiStoryBackpack backpack = (this.BackpackType == EHonamiStoryBackpackType.Inventory) ? EHonamiStoryBackpack.Inventory : EHonamiStoryBackpack.Player;
			ModelBase<HonamiStoryModel>.Instance.SellSingleItem(this.ItemData, backpack).ContinueWith(delegate(bool value)
			{
				if (value)
				{
					this.SetTipsVisible(false);
					ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
				}
			});
		}
	}

	// Token: 0x0600EDB3 RID: 60851 RVA: 0x0040DEB0 File Offset: 0x0040C0B0
	private void OnClickedToBackpack()
	{
		EHonamiStoryBackpack curBackpack = (this.BackpackType == EHonamiStoryBackpackType.Player) ? EHonamiStoryBackpack.Player : EHonamiStoryBackpack.PickUpBox;
		EHonamiStoryBackpack toBackpack = (this.TipsState == EHonamiStoryTipsState.InGame) ? EHonamiStoryBackpack.Backpack : EHonamiStoryBackpack.Inventory;
		if (!ModelBase<HonamiStoryModel>.Instance.SetItemIntoBag(this.ItemData, curBackpack, toBackpack))
		{
			return;
		}
		this.SetTipsVisible(false);
		ModelBase<HonamiStoryModel>.Instance.SetBackpackLogicState(EHonamiStoryBackpackLogicState.Normal);
	}

	// Token: 0x0600EDB4 RID: 60852 RVA: 0x0040DF00 File Offset: 0x0040C100
	private void OnClickedInstead()
	{
		HonamiStoryBackpackLogicController backpackLogic = ModelBase<HonamiStoryModel>.Instance.GetBackpackLogic();
		EHonamiStoryBackpack value;
		if (!Singleton<HonamiStoryDefine>.Instance.HonamiBackpackTypeMap.TryGetValue(this.BackpackType, out value))
		{
			return;
		}
		if (backpackLogic != null)
		{
			backpackLogic.SetLogicState(EHonamiStoryBackpackLogicState.Instead, this.ItemData, new EHonamiStoryBackpack?(value));
		}
		this.SetTipsVisible(false);
	}

	// Token: 0x0600EDB5 RID: 60853 RVA: 0x0040DF4F File Offset: 0x0040C14F
	public void SetEnable(bool value)
	{
		base.SetUiActive(value);
		UUIItem originalItem = this.GetOriginalItem();
		if (originalItem == null)
		{
			return;
		}
		originalItem.SetUIActive(value);
	}

	// Token: 0x0600EDB6 RID: 60854 RVA: 0x0040DF69 File Offset: 0x0040C169
	private void OnCloseSequenceStart(string _)
	{
		this.SetEnable(true);
	}

	// Token: 0x0600EDB7 RID: 60855 RVA: 0x0040DF74 File Offset: 0x0040C174
	private void OnLayoutUpdate(float _)
	{
		float height = this.RootItem.GetHeight();
		if (height != this.UpdateHeight)
		{
			this.UpdateHeight = height;
			this.SetAutoLocation(this.GridLoc, this.GridSize);
		}
	}

	// Token: 0x0600EDB8 RID: 60856 RVA: 0x0040DFB0 File Offset: 0x0040C1B0
	private void OnSkillDescModeChange(bool isSimple)
	{
		if (this.ItemData == null || this.ItemData.GetItemType() == EHonamiStoryItemType.Normal)
		{
			return;
		}
		HonamiStoryEquipItemData honamiStoryEquipItemData = this.ItemData as HonamiStoryEquipItemData;
		if (honamiStoryEquipItemData == null)
		{
			return;
		}
		List<IHonamiStoryTipsBuffInfo> buffTempIdList = honamiStoryEquipItemData.GetBuffTempIdList(false);
		GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> skillLayout = this.SkillLayout;
		if (skillLayout == null)
		{
			return;
		}
		skillLayout.RefreshByDataDirectlySync(buffTempIdList);
	}

	// Token: 0x0600EDB9 RID: 60857 RVA: 0x0040DFFE File Offset: 0x0040C1FE
	private void OnInputControllerMainTypeChange(EInputControllerMainType last, EInputControllerMainType now)
	{
		this.RefreshDoubleClicked();
	}

	// Token: 0x0600EDBA RID: 60858 RVA: 0x0040E008 File Offset: 0x0040C208
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
		if (!(configParams[0] == "SkillRoleText"))
		{
			return null;
		}
		int index = int.Parse(configParams[1]);
		GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> skillLayout = this.SkillLayout;
		HonamiStoryTipsTextItem honamiStoryTipsTextItem = (skillLayout != null) ? skillLayout.GetLayoutItemByIndex(index) : null;
		UUIItem uuiitem = (honamiStoryTipsTextItem != null) ? honamiStoryTipsTextItem.GetGuideUiItem("0") : null;
		if (uuiitem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			uuiitem,
			uuiitem
		};
	}

	// Token: 0x0600EDBB RID: 60859 RVA: 0x0040E06D File Offset: 0x0040C26D
	private void OnCloseSequenceFinish(string _)
	{
		this.SetEnable(false);
	}

	// Token: 0x04007220 RID: 29216
	private const int RIGHT_OFFSET = 60;

	// Token: 0x04007221 RID: 29217
	private const int PROPERTY_MAX_COUNT = 3;

	// Token: 0x04007222 RID: 29218
	private const int BUFF_MAX_COUNT = 1;

	// Token: 0x04007223 RID: 29219
	protected bool ActivityOpen;

	// Token: 0x04007224 RID: 29220
	protected float SideButtonWidth;

	// Token: 0x04007225 RID: 29221
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<HonamiStoryTipsPropertyItem, IHonamiStoryTipsPropertyData> PropertyLayout;

	// Token: 0x04007226 RID: 29222
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	protected GenericLayout<HonamiStoryTipsTextItem, IHonamiStoryTipsBuffInfo> SkillLayout;

	// Token: 0x04007227 RID: 29223
	[Nullable(2)]
	protected UUIButtonComponent MaskButton;

	// Token: 0x04007228 RID: 29224
	protected EHonamiStoryTipsState TipsState;

	// Token: 0x04007229 RID: 29225
	[Nullable(2)]
	protected ButtonItem ConfirmQuick;

	// Token: 0x0400722A RID: 29226
	[Nullable(2)]
	protected ButtonItem ConfirmRight;

	// Token: 0x0400722B RID: 29227
	[Nullable(2)]
	protected HonamiStoryItemDataBase ItemData;

	// Token: 0x0400722C RID: 29228
	protected EHonamiStoryBackpackType BackpackType;

	// Token: 0x0400722D RID: 29229
	protected float BottomOffset = 200f;

	// Token: 0x0400722E RID: 29230
	protected int CurrentPos = -1;

	// Token: 0x0400722F RID: 29231
	[Nullable(2)]
	protected HonamiStoryItemTipsSideButton ButtonRightA;

	// Token: 0x04007230 RID: 29232
	[Nullable(2)]
	protected HonamiStoryItemTipsSideButton ButtonRightB;

	// Token: 0x04007231 RID: 29233
	[Nullable(2)]
	protected HonamiStoryItemTipsSideButton ButtonLeftA;

	// Token: 0x04007232 RID: 29234
	[Nullable(2)]
	protected HonamiStoryItemTipsSideButton ButtonLeftB;

	// Token: 0x04007233 RID: 29235
	protected bool SideButtonActive;

	// Token: 0x04007234 RID: 29236
	[Nullable(2)]
	protected Action OnHideCb;

	// Token: 0x04007235 RID: 29237
	protected Vector2D GridLoc;

	// Token: 0x04007236 RID: 29238
	protected Vector2D GridSize;

	// Token: 0x04007237 RID: 29239
	protected float UpdateHeight;

	// Token: 0x04007238 RID: 29240
	[Nullable(2)]
	private UiBehaviorLevelSequence LevelPlaySequence;

	// Token: 0x02008271 RID: 33393
	[NullableContext(0)]
	private enum EDefine
	{
		// Token: 0x0402C3C1 RID: 181185
		TxtName,
		// Token: 0x0402C3C2 RID: 181186
		SpriteTitleBg,
		// Token: 0x0402C3C3 RID: 181187
		SpriteTypeIcon,
		// Token: 0x0402C3C4 RID: 181188
		TxtType,
		// Token: 0x0402C3C5 RID: 181189
		TexCost,
		// Token: 0x0402C3C6 RID: 181190
		TxtLevel,
		// Token: 0x0402C3C7 RID: 181191
		TogLock,
		// Token: 0x0402C3C8 RID: 181192
		PanelTipsTime,
		// Token: 0x0402C3C9 RID: 181193
		TxtTime,
		// Token: 0x0402C3CA RID: 181194
		PanelTipsProperty,
		// Token: 0x0402C3CB RID: 181195
		PanelList,
		// Token: 0x0402C3CC RID: 181196
		PanelSkill,
		// Token: 0x0402C3CD RID: 181197
		MainDescItem,
		// Token: 0x0402C3CE RID: 181198
		TxtDesc,
		// Token: 0x0402C3CF RID: 181199
		BtnConfirmA,
		// Token: 0x0402C3D0 RID: 181200
		BtnConfirmB,
		// Token: 0x0402C3D1 RID: 181201
		PanelBtnR,
		// Token: 0x0402C3D2 RID: 181202
		BtnRA,
		// Token: 0x0402C3D3 RID: 181203
		BtnRB,
		// Token: 0x0402C3D4 RID: 181204
		PanelBtnL,
		// Token: 0x0402C3D5 RID: 181205
		BtnLA,
		// Token: 0x0402C3D6 RID: 181206
		BtnLB,
		// Token: 0x0402C3D7 RID: 181207
		TexIcon,
		// Token: 0x0402C3D8 RID: 181208
		PanelBottom,
		// Token: 0x0402C3D9 RID: 181209
		PanelDoubleClicked,
		// Token: 0x0402C3DA RID: 181210
		TxtDoubleClicked
	}
}
