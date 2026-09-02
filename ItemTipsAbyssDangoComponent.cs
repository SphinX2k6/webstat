using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001B13 RID: 6931
[NullableContext(1)]
[Nullable(0)]
public class ItemTipsAbyssDangoComponent : TipsBaseSubComponent
{
	// Token: 0x0600C7AF RID: 51119 RVA: 0x0034D194 File Offset: 0x0034B394
	public ItemTipsAbyssDangoComponent(UUIItem rootUiItem) : base(rootUiItem)
	{
		base.CreateThenShowByResourceIdAsync("UiItem_TipsChipInfo", rootUiItem, false);
	}

	// Token: 0x0600C7B0 RID: 51120 RVA: 0x0034D200 File Offset: 0x0034B400
	protected unsafe override void OnRegisterComponent()
	{
		int num = 15;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIVerticalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUINiagara));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C7B1 RID: 51121 RVA: 0x0034D41D File Offset: 0x0034B61D
	protected override void OnBeforeShow()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshFuncState));
	}

	// Token: 0x0600C7B2 RID: 51122 RVA: 0x0034D43B File Offset: 0x0034B63B
	protected override void OnBeforeHide()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnItemFuncValueChange, new Action<int>(this.RefreshFuncState));
	}

	// Token: 0x0600C7B3 RID: 51123 RVA: 0x0034D459 File Offset: 0x0034B659
	private void RefreshFuncState(int _)
	{
		this.RefreshView(this.CurrentData);
	}

	// Token: 0x0600C7B4 RID: 51124 RVA: 0x0034D468 File Offset: 0x0034B668
	protected override UniTask OnBeforeStartAsync()
	{
		ItemTipsAbyssDangoComponent.<OnBeforeStartAsync>d__14 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ItemTipsAbyssDangoComponent.<OnBeforeStartAsync>d__14>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x0600C7B5 RID: 51125 RVA: 0x0034D4AC File Offset: 0x0034B6AC
	protected override void OnStart()
	{
		this.AttributeScroller = new GenericLayout<DangoAbyssTipsAttributeItem, AttrListScrollData>(base.GetVerticalLayout(1), this.CreateItem, base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		this.TagScroller = new GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData>(base.GetVerticalLayout(3), this.CreateTagItem, base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x0600C7B6 RID: 51126 RVA: 0x0034D510 File Offset: 0x0034B710
	public override void Refresh(ItemTipsData sourceData)
	{
		TipsAbyssDangoData data = (TipsAbyssDangoData)sourceData;
		Action action = delegate()
		{
			this.RefreshView(data);
		};
		if (base.InAsyncLoading())
		{
			this.OperationMap["Refresh"] = action;
			return;
		}
		action();
	}

	// Token: 0x0600C7B7 RID: 51127 RVA: 0x0034D564 File Offset: 0x0034B764
	private void RefreshView(TipsAbyssDangoData data)
	{
		this.CurrentData = data;
		AttrListScrollData[] pluginShowAttributeList = ModelBase<DangoAbyssModel>.Instance.GetPluginShowAttributeList(data.ConfigId);
		this.RefreshAttribute(pluginShowAttributeList.ToList<AttrListScrollData>());
		DangoAbyssDefine.DangoAbyssTagData[] pluginShowTagDataList = ModelBase<DangoAbyssModel>.Instance.GetPluginShowTagDataList(data.ConfigId);
		this.RefreshTag(pluginShowTagDataList.ToList<DangoAbyssDefine.DangoAbyssTagData>());
		string itemBgDesc = ConfigBase<DangoAbyssConfig>.Instance.GetItemBgDesc(data.ConfigId);
		base.GetText(6).SetText(itemBgDesc, true);
		this.RefreshState(data);
		this.RefreshInActiveRedItem(data);
		this.RefreshConfirmBtn(data);
		this.RefreshLockToggle(data);
		this.RefreshIcon(data);
		this.RefreshName(data);
		this.RefreshQuality(data);
		this.RefreshType(data);
	}

	// Token: 0x0600C7B8 RID: 51128 RVA: 0x0034D60C File Offset: 0x0034B80C
	private void RefreshState(TipsAbyssDangoData data)
	{
		this.StateConfirm = DangoAbyssDefine.EAbyssItemTipsState.None;
		if (data.DangoId > 0 && data.SlotIndex >= 0)
		{
			DangoAbyssDefine.IAbyssItemTipsData data2 = new DangoAbyssDefine.IAbyssItemTipsData
			{
				DangoId = data.DangoId,
				SlotIndex = data.SlotIndex,
				IncId = data.IncId
			};
			this.StateConfirm = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssItemTipsConfirmState(data2);
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Activity;
		ELogAuthor author = ELogAuthor.WDX;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
		defaultInterpolatedStringHandler.AppendLiteral("当前按钮状态：");
		defaultInterpolatedStringHandler.AppendFormatted<DangoAbyssDefine.EAbyssItemTipsState>(this.StateConfirm);
		instance.Info(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
	}

	// Token: 0x0600C7B9 RID: 51129 RVA: 0x0034D6B0 File Offset: 0x0034B8B0
	private void RefreshIcon(TipsAbyssDangoData data)
	{
		DangoPluginIconInfo dangoPluginIconInfo = new DangoPluginIconInfo
		{
			PluginItemId = data.ConfigId
		};
		MediumItemGridDangoPluginIconComponent pluginIconItem = this.PluginIconItem;
		if (pluginIconItem == null)
		{
			return;
		}
		pluginIconItem.RefreshByInfo(dangoPluginIconInfo);
	}

	// Token: 0x0600C7BA RID: 51130 RVA: 0x0034D6E0 File Offset: 0x0034B8E0
	private void RefreshLockToggle(TipsAbyssDangoData data)
	{
		ItemConfig dangoItemConfig = ModelBase<DangoAbyssModel>.Instance.GetDangoItemConfig(data.ConfigId);
		TypeInfo? itemTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemTypeConfig((int)dangoItemConfig.ItemType.Value);
		int incId = data.IncId;
		if (data.IncId > 0)
		{
			this.TipsLockButton.Refresh(data.IncId, data.CanClickLockButton);
			this.TipsLockButton.SetDeprecateToggleVisible(itemTypeConfig.Value.Deprecate);
			TipsLockButton tipsLockButton = this.TipsLockButton;
			if (tipsLockButton == null)
			{
				return;
			}
			tipsLockButton.SetUiActive(true);
			return;
		}
		else
		{
			TipsLockButton tipsLockButton2 = this.TipsLockButton;
			if (tipsLockButton2 == null)
			{
				return;
			}
			tipsLockButton2.SetUiActive(false);
			return;
		}
	}

	// Token: 0x0600C7BB RID: 51131 RVA: 0x0034D778 File Offset: 0x0034B978
	private void RefreshConfirmBtn(TipsAbyssDangoData data)
	{
		this.ConfirmBtnItem.SetUiActive(true);
		switch (this.StateConfirm)
		{
		case DangoAbyssDefine.EAbyssItemTipsState.DiffDango:
			this.ConfirmBtnItem.TrySetLocalTextNew("Text_PhantomReplace_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.TakeOff:
			this.ConfirmBtnItem.TrySetLocalTextNew("Text_PhantomTakeOff_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.Switch:
			this.ConfirmBtnItem.TrySetLocalTextNew("Text_PhantomReplace_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.Move:
			this.ConfirmBtnItem.TrySetLocalTextNew("Text_PhantomPutOn_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.Replace:
			this.ConfirmBtnItem.TrySetLocalTextNew("Text_PhantomReplace_Text", Array.Empty<object>());
			return;
		case DangoAbyssDefine.EAbyssItemTipsState.PutOn:
			this.ConfirmBtnItem.TrySetLocalTextNew("Text_PhantomPutOn_Text", Array.Empty<object>());
			return;
		default:
			this.ConfirmBtnItem.SetUiActive(false);
			return;
		}
	}

	// Token: 0x0600C7BC RID: 51132 RVA: 0x0034D850 File Offset: 0x0034BA50
	private void RefreshInActiveRedItem(TipsAbyssDangoData data)
	{
		this.InActiveRedItem.SetUiActive(true);
		this.InActiveRedItem.SetDetailButtonVisible(false);
		DangoAbyssDefine.EAbyssItemTipsState stateConfirm = this.StateConfirm;
		if (stateConfirm == DangoAbyssDefine.EAbyssItemTipsState.ErrorDango)
		{
			int dangoItemBelongId = ModelBase<DangoAbyssModel>.Instance.GetDangoItemBelongId(data.IncId);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<DangoAbyssConfig>.Instance.GetDangoRoleById(dangoItemBelongId).Value.Name, null);
			this.InActiveRedItem.SetText("Text_DangoEquipErrorDango_Text", new object[]
			{
				localTextNew
			});
			return;
		}
		if (stateConfirm == DangoAbyssDefine.EAbyssItemTipsState.Same)
		{
			this.InActiveRedItem.SetText("Text_DangoEquipSame_Text", Array.Empty<object>());
			return;
		}
		if (stateConfirm != DangoAbyssDefine.EAbyssItemTipsState.Repeat)
		{
			this.InActiveRedItem.SetUiActive(false);
			return;
		}
		this.InActiveRedItem.SetText("Text_DangoEquipRepeat_Text", Array.Empty<object>());
	}

	// Token: 0x0600C7BD RID: 51133 RVA: 0x0034D912 File Offset: 0x0034BB12
	private void RefreshAttribute(List<AttrListScrollData> data)
	{
		this.AttributeScroller.RefreshByData(data, null, false);
	}

	// Token: 0x0600C7BE RID: 51134 RVA: 0x0034D922 File Offset: 0x0034BB22
	private void RefreshTag(List<DangoAbyssDefine.DangoAbyssTagData> data)
	{
		this.TagScroller.RefreshByData(data, null, false);
	}

	// Token: 0x0600C7BF RID: 51135 RVA: 0x0034D934 File Offset: 0x0034BB34
	private void RefreshName(TipsAbyssDangoData data)
	{
		UUIText text = base.GetText(10);
		FColor color = FColor.FromHex(ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(data.ConfigId).Value.DropColor);
		text.SetColor(color);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(text, data.Title, Array.Empty<object>());
	}

	// Token: 0x0600C7C0 RID: 51136 RVA: 0x0034D990 File Offset: 0x0034BB90
	private void RefreshQuality(TipsAbyssDangoData data)
	{
		UUINiagara uiNiagara = base.GetUiNiagara(13);
		uiNiagara.DeactivateSystem();
		UUITexture texture = base.GetTexture(11);
		AbyssQuality value = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityByPluginItemId(data.ConfigId).Value;
		string tipsQualityTexturePath = value.TipsQualityTexturePath;
		FColor color = FColor.FromHex(value.QualityColor);
		uiNiagara.SetColor(color);
		uiNiagara.ActivateSystem(true);
		base.SetTextureByPath(tipsQualityTexturePath, texture, null, null);
	}

	// Token: 0x0600C7C1 RID: 51137 RVA: 0x0034DA04 File Offset: 0x0034BC04
	private void RefreshType(TipsAbyssDangoData data)
	{
		int slotType = ConfigBase<DangoAbyssConfig>.Instance.GetDangoItemById(data.ConfigId).Value.SlotType;
		string textStringId;
		if (DangoAbyssDefine.textPluginType.TryGetValue((DangoAbyssDefine.ESlotType)slotType, out textStringId))
		{
			Singleton<LguiUtil>.Instance.TrySetLocalTextNew(base.GetText(14), textStringId, Array.Empty<object>());
		}
	}

	// Token: 0x0600C7C2 RID: 51138 RVA: 0x0034DA5C File Offset: 0x0034BC5C
	private void OnConfirmBtnClick(int _)
	{
		if (this.StateConfirm == DangoAbyssDefine.EAbyssItemTipsState.DiffDango)
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.DangoAbyssEquipPluginDiffDango);
			confirmBoxDataNew.FunctionMap.Add(2, new Action(this.OnPluginItemEquipConfirm));
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
			return;
		}
		this.OnPluginItemEquipConfirm();
	}

	// Token: 0x0600C7C3 RID: 51139 RVA: 0x0034DAA8 File Offset: 0x0034BCA8
	private void OnPluginItemEquipConfirm()
	{
		if (this.CurrentData == null)
		{
			return;
		}
		DangoAbyssDefine.IAbyssItemTipsData data = new DangoAbyssDefine.IAbyssItemTipsData
		{
			DangoId = this.CurrentData.DangoId,
			SlotIndex = this.CurrentData.SlotIndex,
			IncId = this.CurrentData.IncId
		};
		int[] dangoAbyssItemNewEquip = ModelBase<DangoAbyssModel>.Instance.GetDangoAbyssItemNewEquip(data, this.StateConfirm);
		ControllerBase<DangoAbyssActivityController>.Instance.RequestPutPluginOnDango(this.CurrentData.DangoId, dangoAbyssItemNewEquip, this.StateConfirm);
	}

	// Token: 0x0600C7C4 RID: 51140 RVA: 0x0034DB28 File Offset: 0x0034BD28
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
	{
		if (configParams.Length < 2)
		{
			return null;
		}
		string name = configParams[1];
		UUIItem guideUiItem = base.GetGuideUiItem(name);
		if (guideUiItem == null)
		{
			return null;
		}
		return new UUIItem[]
		{
			guideUiItem,
			guideUiItem
		};
	}

	// Token: 0x04005F97 RID: 24471
	[Nullable(2)]
	private TipsAbyssDangoData CurrentData;

	// Token: 0x04005F98 RID: 24472
	[Nullable(2)]
	private InActiveRedItem InActiveRedItem;

	// Token: 0x04005F99 RID: 24473
	[Nullable(2)]
	private ButtonItem ConfirmBtnItem;

	// Token: 0x04005F9A RID: 24474
	[Nullable(2)]
	private MediumItemGridDangoPluginIconComponent PluginIconItem;

	// Token: 0x04005F9B RID: 24475
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoAbyssTipsAttributeItem, AttrListScrollData> AttributeScroller;

	// Token: 0x04005F9C RID: 24476
	[Nullable(2)]
	private TipsLockButton TipsLockButton;

	// Token: 0x04005F9D RID: 24477
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<DangoAbyssTagItem, DangoAbyssDefine.DangoAbyssTagData> TagScroller;

	// Token: 0x04005F9E RID: 24478
	private DangoAbyssDefine.EAbyssItemTipsState StateConfirm;

	// Token: 0x04005F9F RID: 24479
	private readonly Func<DangoAbyssTagItem> CreateTagItem = () => new DangoAbyssTagItem
	{
		GetValueByTips = true
	};

	// Token: 0x04005FA0 RID: 24480
	private readonly Func<DangoAbyssTipsAttributeItem> CreateItem = () => new DangoAbyssTipsAttributeItem();

	// Token: 0x02007DEB RID: 32235
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AE39 RID: 175673
		LockItem,
		// Token: 0x0402AE3A RID: 175674
		BaseAttributeLayout,
		// Token: 0x0402AE3B RID: 175675
		BaseAttributeItem,
		// Token: 0x0402AE3C RID: 175676
		TagPropVertical,
		// Token: 0x0402AE3D RID: 175677
		TagPropItem,
		// Token: 0x0402AE3E RID: 175678
		DescItem,
		// Token: 0x0402AE3F RID: 175679
		DescText,
		// Token: 0x0402AE40 RID: 175680
		ConfirmBtnItem,
		// Token: 0x0402AE41 RID: 175681
		InActiveRedItem,
		// Token: 0x0402AE42 RID: 175682
		PluginIconItem,
		// Token: 0x0402AE43 RID: 175683
		TextName,
		// Token: 0x0402AE44 RID: 175684
		IconQuality,
		// Token: 0x0402AE45 RID: 175685
		IconMain,
		// Token: 0x0402AE46 RID: 175686
		NiagaraQuality,
		// Token: 0x0402AE47 RID: 175687
		TextPluginType
	}
}
