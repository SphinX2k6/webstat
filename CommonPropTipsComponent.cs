using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001A70 RID: 6768
[NullableContext(1)]
[Nullable(0)]
public class CommonPropTipsComponent : UiPanelBase
{
	// Token: 0x0600C1B3 RID: 49587 RVA: 0x003300D8 File Offset: 0x0032E2D8
	public CommonPropTipsComponent(UUIItem uiItem)
	{
		base.CreateThenShowByActor(uiItem.GetOwner(), null);
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x0600C1B4 RID: 49588 RVA: 0x00330124 File Offset: 0x0032E324
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(5, typeof(UUILayoutBase)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUISprite)),
			new ValueTuple<int, Type>(12, typeof(UUIText)),
			new ValueTuple<int, Type>(13, typeof(UUISprite)),
			new ValueTuple<int, Type>(14, typeof(UUIText)),
			new ValueTuple<int, Type>(15, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(4, new Action(this.GetWayButtonClick))
		};
	}

	// Token: 0x0600C1B5 RID: 49589 RVA: 0x003302C8 File Offset: 0x0032E4C8
	private void GetWayButtonClick()
	{
		this.IsOpenGetWay = !this.IsOpenGetWay;
		base.GetLayoutBase(5).GetRootComponent().SetUIActive(this.IsOpenGetWay);
		base.GetExtendToggle(4).SetToggleState(this.IsOpenGetWay ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600C1B6 RID: 49590 RVA: 0x00330318 File Offset: 0x0032E518
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
		this.GetWayLayout = new GenericLayoutAdd<UiPanelBase>(base.GetLayoutBase(5), new TLayoutRefresh<UiPanelBase>(this.InitItem));
		base.GetItem(15).SetUIActive(true);
		this.SetGetWayState(false);
		this.SetBottomState(false, false);
		this.OneButtonItem = new ButtonItem(base.GetItem(8));
		TArray<UUIItem> attachUIChildren = base.GetItem(7).GetAttachUIChildren();
		int i = 0;
		int num = attachUIChildren.Num();
		while (i < num)
		{
			ButtonItem item = new ButtonItem(attachUIChildren.Get(i));
			this.DoubleButtonItemList.Add(item);
			i++;
		}
		this.SetOwnTextState(false);
	}

	// Token: 0x0600C1B7 RID: 49591 RVA: 0x003303C4 File Offset: 0x0032E5C4
	private ILayoutItem<UiPanelBase> InitItem(object data, UUIItem uiItem, int index, int originalItemIndex)
	{
		int getWayId = (int)data;
		ButtonItem buttonItem = new ButtonItem(uiItem);
		AccessPath? configById = ConfigBase<GetWayConfig>.Instance.GetConfigById(getWayId);
		if (configById == null)
		{
			return new LayoutItem<UiPanelBase>
			{
				Key = index,
				Value = buttonItem
			};
		}
		buttonItem.SetData(getWayId);
		buttonItem.SetEnableClick(configById.Value.Type == 2);
		buttonItem.SetFunction(delegate(int dataId)
		{
			SkipTaskManager.RunByConfigId(getWayId, this.ConfigId);
		});
		buttonItem.SetButtonAllowEventBubbleUp(true);
		string localTextNew = ConfigMultiTextLang.GetLocalTextNew(configById.Value.Description, null);
		buttonItem.SetText(localTextNew);
		return new LayoutItem<UiPanelBase>
		{
			Key = index,
			Value = buttonItem
		};
	}

	// Token: 0x0600C1B8 RID: 49592 RVA: 0x00330498 File Offset: 0x0032E698
	private void SetGetWayState(bool bActive)
	{
		base.GetExtendToggle(4).RootUIComp.Get().SetUIActive(bActive);
		base.GetLayoutBase(5).GetRootComponent().SetUIActive(false);
		this.IsOpenGetWay = false;
		base.GetExtendToggle(4).SetToggleState(this.IsOpenGetWay ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x0600C1B9 RID: 49593 RVA: 0x003304F4 File Offset: 0x0032E6F4
	private void UpdateGetWay(int[] getWayList)
	{
		this.GetWayLayout.AddItemToLayout(getWayList.Cast<object>().ToArray<object>(), 1);
	}

	// Token: 0x0600C1BA RID: 49594 RVA: 0x00330510 File Offset: 0x0032E710
	protected void LoadDebugText()
	{
		if (!GlobalData.IsPlayInEditor)
		{
			return;
		}
		if (this.DebugText == null)
		{
			Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.DebugTextLoadId);
			this.DebugTextLoadId = Singleton<LguiResourceManager>.Instance.LoadPrefabByResourceId("UiItem_DebugText_Prefab", this.RootItem, delegate([Nullable(2)] AActor actor, string _, ELguiLoadResultType _1)
			{
				this.DebugTextLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;
				this.DebugText = (actor.GetComponentByClass(UUIText.StaticClass()) as UUIText);
				Singleton<LguiUtil>.Instance.SetLocalText(this.DebugText, "CommonTipsDebugItemId", new <>z__ReadOnlySingleElementList<object>(this.ConfigId));
			}, "js_undefined");
			return;
		}
		Singleton<LguiUtil>.Instance.SetLocalText(this.DebugText, "CommonTipsDebugItemId", new <>z__ReadOnlySingleElementList<object>(this.ConfigId));
	}

	// Token: 0x0600C1BB RID: 49595 RVA: 0x00330590 File Offset: 0x0032E790
	protected override void OnBeforeDestroy()
	{
		this.LevelSequencePlayer.Clear();
		this.LevelSequencePlayer = null;
		this.GetWayLayout.ClearChildren();
		this.GetWayLayout = null;
		this.OneButtonItem.Destroy(null);
		this.OneButtonItem = null;
		foreach (ButtonItem buttonItem in this.DoubleButtonItemList)
		{
			buttonItem.Destroy(null);
		}
		this.DoubleButtonItemList.Clear();
		Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.DebugTextLoadId);
		if (this.DebugText != null)
		{
			Singleton<ActorSystem>.Instance.Put("CommonPropTipsComponent.OnBeforeDestroy", this.DebugText.GetOwner(), null);
			this.DebugText = null;
		}
	}

	// Token: 0x0600C1BC RID: 49596 RVA: 0x00330660 File Offset: 0x0032E860
	public void UpdateComponent(int configId, bool needGetWay = false)
	{
		this.ConfigId = configId;
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(configId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), itemConfigData.Name, Array.Empty<object>());
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), itemConfigData.TypeDescription, Array.Empty<object>());
		UUIText text = base.GetText(3);
		if (itemConfigData.AttributesDescription != null)
		{
			text.SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(text, itemConfigData.AttributesDescription, Array.Empty<object>());
		}
		else
		{
			text.SetUIActive(false);
		}
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(12), itemConfigData.BgDescription, Array.Empty<object>());
		base.SetItemIcon(base.GetTexture(1), this.ConfigId, null, null);
		base.SetItemQualityIcon(base.GetSprite(11), this.ConfigId, null, CommonDefine.EQualityIconType.TipsSprite, null);
		this.LoadDebugText();
		if (needGetWay)
		{
			this.GetWayLayout.ClearChildren();
			if (itemConfigData.ItemAccess != null && itemConfigData.ItemAccess.Length != 0)
			{
				this.UpdateGetWay(itemConfigData.ItemAccess);
				this.SetGetWayState(true);
				return;
			}
		}
		this.SetGetWayState(false);
	}

	// Token: 0x0600C1BD RID: 49597 RVA: 0x00330788 File Offset: 0x0032E988
	public void SetBottomState(bool bActive, bool isOneButton)
	{
		UUIItem item = base.GetItem(6);
		if (!bActive)
		{
			item.SetUIActive(false);
			return;
		}
		item.SetUIActive(true);
		UUIItem item2 = base.GetItem(8);
		UUIItem item3 = base.GetItem(7);
		item2.SetUIActive(isOneButton);
		item3.SetUIActive(!isOneButton);
	}

	// Token: 0x0600C1BE RID: 49598 RVA: 0x003307D0 File Offset: 0x0032E9D0
	public void SetOwnTextState(bool bActive)
	{
		UUIText text = base.GetText(14);
		if (bActive)
		{
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ConfigId, 0);
			Singleton<LguiUtil>.Instance.SetLocalText(text, "ItemTipsHaveNum", new <>z__ReadOnlySingleElementList<object>(itemCountByConfigId));
			text.SetUIActive(true);
			return;
		}
		text.SetUIActive(false);
	}

	// Token: 0x0600C1BF RID: 49599 RVA: 0x00330825 File Offset: 0x0032EA25
	public ButtonItem GetDoubleLeftButton()
	{
		return this.DoubleButtonItemList[0];
	}

	// Token: 0x0600C1C0 RID: 49600 RVA: 0x00330833 File Offset: 0x0032EA33
	public ButtonItem GetDoubleRightButton()
	{
		return this.DoubleButtonItemList[1];
	}

	// Token: 0x0600C1C1 RID: 49601 RVA: 0x00330841 File Offset: 0x0032EA41
	[NullableContext(2)]
	public ButtonItem GetOneButton()
	{
		return this.OneButtonItem;
	}

	// Token: 0x0600C1C2 RID: 49602 RVA: 0x00330849 File Offset: 0x0032EA49
	public void SetOneButtonEnable(bool bEnable)
	{
		this.OneButtonItem.SetEnableClick(bEnable);
	}

	// Token: 0x0600C1C3 RID: 49603 RVA: 0x00330857 File Offset: 0x0032EA57
	public int GetConfigId()
	{
		return this.ConfigId;
	}

	// Token: 0x0600C1C4 RID: 49604 RVA: 0x00330860 File Offset: 0x0032EA60
	public void PlayStartSequence()
	{
		this.LevelSequencePlayer.PlayLevelSequenceByName("Start", false, null, false);
	}

	// Token: 0x0600C1C5 RID: 49605 RVA: 0x00330888 File Offset: 0x0032EA88
	public void StopStartSequence()
	{
		this.LevelSequencePlayer.StopSequenceByKey("Start", false, false);
	}

	// Token: 0x04005AA8 RID: 23208
	[Nullable(2)]
	private UUIText DebugText;

	// Token: 0x04005AA9 RID: 23209
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected GenericLayoutAdd<UiPanelBase> GetWayLayout;

	// Token: 0x04005AAA RID: 23210
	protected int ConfigId;

	// Token: 0x04005AAB RID: 23211
	protected List<ButtonItem> DoubleButtonItemList = new List<ButtonItem>();

	// Token: 0x04005AAC RID: 23212
	[Nullable(2)]
	protected ButtonItem OneButtonItem;

	// Token: 0x04005AAD RID: 23213
	protected bool IsOpenGetWay;

	// Token: 0x04005AAE RID: 23214
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x04005AAF RID: 23215
	private int DebugTextLoadId = Singleton<LguiResourceManager>.Instance.InvalidId;

	// Token: 0x02007D26 RID: 32038
	[NullableContext(0)]
	private enum ECommonPropTipsComponentDefine
	{
		// Token: 0x0402AA9B RID: 174747
		NameText,
		// Token: 0x0402AA9C RID: 174748
		IconTexture,
		// Token: 0x0402AA9D RID: 174749
		TypeText,
		// Token: 0x0402AA9E RID: 174750
		ContentText,
		// Token: 0x0402AA9F RID: 174751
		GetWayButton,
		// Token: 0x0402AAA0 RID: 174752
		GetWayLayout,
		// Token: 0x0402AAA1 RID: 174753
		BottomItem,
		// Token: 0x0402AAA2 RID: 174754
		DoubleButtonItem,
		// Token: 0x0402AAA3 RID: 174755
		OneButtonItem,
		// Token: 0x0402AAA4 RID: 174756
		CanGetWayItem,
		// Token: 0x0402AAA5 RID: 174757
		CantGetWayItem,
		// Token: 0x0402AAA6 RID: 174758
		TitleSprite,
		// Token: 0x0402AAA7 RID: 174759
		BgDescribeText,
		// Token: 0x0402AAA8 RID: 174760
		ChipSprite,
		// Token: 0x0402AAA9 RID: 174761
		OwnText,
		// Token: 0x0402AAAA RID: 174762
		GetWayBg
	}
}
