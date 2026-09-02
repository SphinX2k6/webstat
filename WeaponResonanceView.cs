using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.Role.Common.Data.Enum;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02002CF9 RID: 11513
[NullableContext(2)]
[Nullable(0)]
public class WeaponResonanceView : UiTabViewBase
{
	// Token: 0x060173B3 RID: 95155 RVA: 0x00670910 File Offset: 0x0066EB10
	protected unsafe override void OnRegisterComponent()
	{
		int num = 14;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x060173B4 RID: 95156 RVA: 0x00670B0C File Offset: 0x0066ED0C
	protected override void OnStart()
	{
		this.WeaponIncId = (int)this.ExtraParams;
		if (this.GetCurrentResonanceConfig().MaterialPlaceType == 1)
		{
			this.AutoPlaceItem = true;
		}
		if (this.AutoPlaceItem)
		{
			this.ItemGridAlternativeConsume = new MediumItemGrid();
			this.ItemGridAlternativeConsume.Initialize(base.GetItem(5).GetOwner());
			this.RefreshAlternativeConsumeItem();
		}
		else
		{
			this.InitSingleItemSelect();
		}
		this.ConfirmButtonItem = new ButtonItem(base.GetItem(6));
		this.ConfirmButtonItem.SetFunction(new Action<int>(this.ResonanceClick));
		this.InitMoney();
	}

	// Token: 0x060173B5 RID: 95157 RVA: 0x00670BA9 File Offset: 0x0066EDA9
	protected override void AddEventListener()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.ResonanceSuccess));
	}

	// Token: 0x060173B6 RID: 95158 RVA: 0x00670BC7 File Offset: 0x0066EDC7
	protected override void RemoveEventListener()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.WeaponResonanceSuccess, new Action<int, int>(this.ResonanceSuccess));
	}

	// Token: 0x060173B7 RID: 95159 RVA: 0x00670BE8 File Offset: 0x0066EDE8
	private void ResonanceSuccess(int incId, int lastLevel)
	{
		if (incId != this.WeaponIncId)
		{
			return;
		}
		this.WeaponObserver = Singleton<UiSceneManager>.Instance.GetWeaponObserver();
		this.WeaponScabbardObserver = Singleton<UiSceneManager>.Instance.GetWeaponScabbardObserver();
		ControllerBase<WeaponController>.Instance.PlayWeaponRenderingMaterial("WeaponResonanceUpMaterialController", this.WeaponObserver, this.WeaponScabbardObserver);
		UiModelBase model = this.WeaponObserver.Model;
		Singleton<UiModelUtil>.Instance.PlayEffectAtRootComponent(model, "WeaponResonanceUpEffect");
		if (this.AutoPlaceItem)
		{
			this.RefreshAlternativeConsumeItem();
		}
		else
		{
			this.SingleItemSelect.ClearSelectData();
		}
		this.RefreshLevel();
		WeaponResonanceSuccessViewParam param = new WeaponResonanceSuccessViewParam
		{
			WeaponIncId = incId,
			LastLevel = lastLevel
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.WeaponResonanceSuccessView, param, null);
	}

	// Token: 0x060173B8 RID: 95160 RVA: 0x00670C9C File Offset: 0x0066EE9C
	private void InitSingleItemSelect()
	{
		this.SingleItemSelect = new SingleItemSelect();
		this.SingleItemSelect.Init(base.GetItem(5), ESingleItemSelectViewType.Right);
		this.SingleItemSelect.SetUseWayId(28);
		this.SingleItemSelect.SetInitSortToggleState(true);
		this.SingleItemSelect.SetGetItemListFunction(new Func<List<ItemDataBase>>(this.GetItemList));
		this.SingleItemSelect.SetItemSelectChangeCallBack(new Action<ISelectedData>(this.OnItemSelectChange));
	}

	// Token: 0x060173B9 RID: 95161 RVA: 0x00670D0E File Offset: 0x0066EF0E
	[NullableContext(1)]
	private List<ItemDataBase> GetItemList()
	{
		return ModelBase<WeaponModel>.Instance.GetResonanceMaterialList(this.WeaponIncId);
	}

	// Token: 0x060173BA RID: 95162 RVA: 0x00670D20 File Offset: 0x0066EF20
	[NullableContext(1)]
	private void OnItemSelectChange(ISelectedData currentSelectItem)
	{
		this.RefreshLevel();
	}

	// Token: 0x060173BB RID: 95163 RVA: 0x00670D28 File Offset: 0x0066EF28
	private void InitMoney()
	{
		base.SetItemIcon(base.GetTexture(7), 2, null, null);
	}

	// Token: 0x060173BC RID: 95164 RVA: 0x00670D50 File Offset: 0x0066EF50
	private void RefreshMoney(int startLevel, int endLevel)
	{
		int num = 0;
		if (this.AutoPlaceItem || this.SingleItemSelect.GetCurrentSelectedData() != null)
		{
			WeaponConf value = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId).GetWeaponConfig().Value;
			num = ModelBase<WeaponModel>.Instance.GetResonanceNeedMoney(value.ResonId, startLevel, endLevel);
		}
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(2, 0);
		base.GetText(8).SetText(num.ToString(), true);
		this.IsMoneyEnough = (itemCountByConfigId >= num);
		base.GetText(8).useChangeColor = !this.IsMoneyEnough;
	}

	// Token: 0x060173BD RID: 95165 RVA: 0x00670DEC File Offset: 0x0066EFEC
	private void RefreshLevel()
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		WeaponConf value = weaponDataByIncId.GetWeaponConfig().Value;
		int resonanceLevel = weaponDataByIncId.GetResonanceLevel();
		bool flag = resonanceLevel == value.ResonLevelLimit;
		base.GetItem(3).SetUIActive(!flag);
		base.GetText(1).SetUIActive(!flag);
		base.GetItem(10).SetUIActive(!flag);
		base.GetItem(4).SetUIActive(!flag);
		this.ConfirmButtonItem.GetRootItem().SetUIActive(!flag);
		base.GetItem(9).SetUIActive(flag);
		Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(0), "WeaponResonanceLevelText", new <>z__ReadOnlySingleElementList<object>(resonanceLevel));
		string[] weaponConfigDescParams = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(value, resonanceLevel);
		string[] array = null;
		if (!flag)
		{
			int arrivedLevel = this.GetArrivedLevel();
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), "WeaponResonanceLevelText", new <>z__ReadOnlySingleElementList<object>(arrivedLevel));
			this.RefreshMoney(resonanceLevel, arrivedLevel);
			string[] weaponConfigDescParams2 = ModelBase<WeaponModel>.Instance.GetWeaponConfigDescParams(value, arrivedLevel);
			array = new string[weaponConfigDescParams.Length];
			string stringConfig = ConfigCommonParamById.GetStringConfig("HighlightColor");
			for (int i = 0; i < weaponConfigDescParams.Length; i++)
			{
				string text = weaponConfigDescParams[i];
				string text2 = weaponConfigDescParams2[i];
				string text3;
				if (text == text2)
				{
					text3 = text.ToString();
				}
				else
				{
					text3 = StringUtils.Format("{0}-><color=#{1}>{2}</color>", new string[]
					{
						text,
						stringConfig,
						text2
					});
				}
				array[i] = text3;
			}
		}
		array = (array ?? weaponConfigDescParams);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), value.Desc, array);
	}

	// Token: 0x060173BE RID: 95166 RVA: 0x00670F9C File Offset: 0x0066F19C
	protected override void OnBeforeShow()
	{
		ModelBase<WeaponModel>.Instance.SetCurSelectViewName(EWeaponViewName.WeaponResonanceView);
		this.RefreshSelectedList();
		this.Refresh();
	}

	// Token: 0x060173BF RID: 95167 RVA: 0x00670FB8 File Offset: 0x0066F1B8
	private void RefreshSelectedList()
	{
		if (this.AutoPlaceItem || this.SingleItemSelect == null)
		{
			return;
		}
		ISelectedData currentSelectedData = this.SingleItemSelect.GetCurrentSelectedData();
		if (currentSelectedData == null)
		{
			return;
		}
		if (currentSelectedData.IncId > 0)
		{
			if (ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(currentSelectedData.IncId) == null)
			{
				this.SingleItemSelect.ClearSelectData();
				return;
			}
		}
		else if (ModelBase<InventoryModel>.Instance.GetCommonItemCount(currentSelectedData.ItemId, 0) <= 0)
		{
			this.SingleItemSelect.ClearSelectData();
		}
	}

	// Token: 0x060173C0 RID: 95168 RVA: 0x0067102C File Offset: 0x0066F22C
	public void Refresh()
	{
		this.RefreshName();
		this.RefreshLevel();
	}

	// Token: 0x060173C1 RID: 95169 RVA: 0x0067103C File Offset: 0x0066F23C
	public void RefreshName()
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		WeaponConf value = weaponDataByIncId.GetWeaponConfig().Value;
		string weaponName = value.WeaponName;
		FColor color = FColor.FromHex(ConfigBase<ItemConfig>.Instance.GetQualityConfig(value.QualityId).Value.DropColor);
		base.GetText(12).SetColor(color);
		base.GetText(12).ShowTextNew(weaponName);
		int resonanceLevel = weaponDataByIncId.GetResonanceLevel();
		WeaponReson? weaponResonanceConfig = ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(value.ResonId, resonanceLevel);
		if (weaponResonanceConfig != null)
		{
			base.GetText(13).SetText(ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceDesc(weaponResonanceConfig.Value.Name), true);
		}
	}

	// Token: 0x060173C2 RID: 95170 RVA: 0x00671104 File Offset: 0x0066F304
	private int GetArrivedLevel()
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		int resonanceLevel = weaponDataByIncId.GetResonanceLevel();
		ISelectedData currentSelectedConsumeData = this.GetCurrentSelectedConsumeData();
		if (this.AutoPlaceItem || currentSelectedConsumeData == null || currentSelectedConsumeData.IncId == 0)
		{
			return resonanceLevel + 1;
		}
		int num = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(currentSelectedConsumeData.IncId).GetResonanceLevel() + weaponDataByIncId.GetResonanceLevel();
		int resonLevelLimit = weaponDataByIncId.GetWeaponConfig().Value.ResonLevelLimit;
		if (num <= resonLevelLimit)
		{
			return num;
		}
		return resonLevelLimit;
	}

	// Token: 0x060173C3 RID: 95171 RVA: 0x00671188 File Offset: 0x0066F388
	private void ResonanceClick(int _)
	{
		ISelectedData materialData = this.GetCurrentSelectedConsumeData();
		if (materialData == null)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponSelectMaterialTipsText", Array.Empty<object>());
			return;
		}
		if (!this.IsMoneyEnough)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("WeaponResonanceNoEnoughMoneyText", Array.Empty<object>());
			return;
		}
		int incId2 = materialData.IncId;
		if (incId2 <= 0 && ModelBase<InventoryModel>.Instance.GetCommonItemCount(materialData.ItemId, 0) == 0)
		{
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("ResonanceItemNotEnough", Array.Empty<object>());
			return;
		}
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		EConfirmBoxConfigId configId = EConfirmBoxConfigId.WeaponResonanceTip;
		if (incId2 > 0)
		{
			WeaponInstance weaponDataByIncId2 = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(incId2);
			bool flag = ModelBase<WeaponModel>.Instance.IsWeaponHighLevel(weaponDataByIncId2);
			bool flag2 = ModelBase<WeaponModel>.Instance.HasWeaponResonance(weaponDataByIncId2);
			if (flag && flag2)
			{
				configId = EConfirmBoxConfigId.WeaponResonanceBoth;
			}
			else if (flag2)
			{
				configId = EConfirmBoxConfigId.WeaponResonanceHasResonance;
			}
			else if (flag)
			{
				configId = EConfirmBoxConfigId.WeaponResonanceHasStrength;
			}
		}
		WeaponConfig instance = ConfigBase<WeaponConfig>.Instance;
		string text;
		if (incId2 > 0)
		{
			text = instance.GetWeaponName(instance.GetWeaponConfigByItemId(materialData.ItemId).Value.WeaponName);
		}
		else
		{
			text = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<ItemConfig>.Instance.GetConfig(materialData.ItemId).Value.Name, null);
		}
		string weaponName = instance.GetWeaponName(weaponDataByIncId.GetWeaponConfig().Value.WeaponName);
		int arrivedLevel = this.GetArrivedLevel();
		int? incId = weaponDataByIncId.GetIncId();
		ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(configId);
		Action value = delegate()
		{
			List<WeaponConsumeItem> list = new List<WeaponConsumeItem>();
			WeaponConsumeItem weaponConsumeItem = WeaponConsumeItem.Create();
			weaponConsumeItem.IncId = materialData.IncId;
			weaponConsumeItem.Count = 1;
			weaponConsumeItem.ItemId = materialData.ItemId;
			list.Add(weaponConsumeItem);
			ControllerBase<WeaponController>.Instance.SendPbResonUpRequest(incId.Value, list.ToArray());
		};
		confirmBoxDataNew.SetTextArgs(new string[]
		{
			text,
			weaponName,
			arrivedLevel.ToString()
		});
		confirmBoxDataNew.FunctionMap.Add(2, value);
		ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
	}

	// Token: 0x060173C4 RID: 95172 RVA: 0x0067136C File Offset: 0x0066F56C
	private ISelectedData GetCurrentSelectedConsumeData()
	{
		if (this.AutoPlaceItem)
		{
			int num = this.GetCurrentResonanceConfig().AlternativeConsume()[0];
			SelectedData selectedData = new SelectedData();
			selectedData.ItemId = num;
			selectedData.IncId = 0;
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			selectedData.Count = ((instance != null) ? instance.GetCommonItemCount(num, 0) : 0);
			selectedData.SelectedCount = 1;
			return selectedData;
		}
		return this.SingleItemSelect.GetCurrentSelectedData();
	}

	// Token: 0x060173C5 RID: 95173 RVA: 0x006713D4 File Offset: 0x0066F5D4
	private WeaponReson GetCurrentResonanceConfig()
	{
		WeaponInstance weaponDataByIncId = ModelBase<WeaponModel>.Instance.GetWeaponDataByIncId(this.WeaponIncId);
		WeaponConf value = weaponDataByIncId.GetWeaponConfig().Value;
		return ConfigBase<WeaponConfig>.Instance.GetWeaponResonanceConfig(value.ResonId, weaponDataByIncId.GetResonanceLevel()).Value;
	}

	// Token: 0x060173C6 RID: 95174 RVA: 0x00671420 File Offset: 0x0066F620
	private void RefreshAlternativeConsumeItem()
	{
		int consumeId = this.GetCurrentSelectedConsumeData().ItemId;
		PropMediumItemGrid propMediumItemGrid = new PropMediumItemGrid
		{
			ItemConfigId = new int?(consumeId)
		};
		int commonItemCount = ModelBase<InventoryModel>.Instance.GetCommonItemCount(consumeId, 0);
		propMediumItemGrid.BottomTextId = "Text_ItemEnoughText_Text";
		if (commonItemCount < 1)
		{
			propMediumItemGrid.BottomTextId = "Text_ItemNotEnoughText_Text";
		}
		propMediumItemGrid.BottomTextParameter = new object[]
		{
			commonItemCount,
			1
		};
		this.ItemGridAlternativeConsume.Apply<PropMediumItemGrid>(propMediumItemGrid);
		this.ItemGridAlternativeConsume.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
		this.ItemGridAlternativeConsume.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
		{
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(consumeId, true, null);
		});
	}

	// Token: 0x0400B2A3 RID: 45731
	private bool IsMoneyEnough;

	// Token: 0x0400B2A4 RID: 45732
	private ButtonItem ConfirmButtonItem;

	// Token: 0x0400B2A5 RID: 45733
	private SingleItemSelect SingleItemSelect;

	// Token: 0x0400B2A6 RID: 45734
	private int WeaponIncId;

	// Token: 0x0400B2A7 RID: 45735
	private SkeletalObserverHandle WeaponObserver;

	// Token: 0x0400B2A8 RID: 45736
	private SkeletalObserverHandle WeaponScabbardObserver;

	// Token: 0x0400B2A9 RID: 45737
	private bool AutoPlaceItem;

	// Token: 0x0400B2AA RID: 45738
	private MediumItemGrid ItemGridAlternativeConsume;

	// Token: 0x02008FC5 RID: 36805
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x04030411 RID: 197649
		ResonanceLevelText,
		// Token: 0x04030412 RID: 197650
		NextLevelText,
		// Token: 0x04030413 RID: 197651
		CurrentEffectText,
		// Token: 0x04030414 RID: 197652
		ArrowItem,
		// Token: 0x04030415 RID: 197653
		ConsumeRootItem,
		// Token: 0x04030416 RID: 197654
		CostItem,
		// Token: 0x04030417 RID: 197655
		ConfirmButtonItem,
		// Token: 0x04030418 RID: 197656
		MoneyTexture,
		// Token: 0x04030419 RID: 197657
		MoneyText,
		// Token: 0x0403041A RID: 197658
		MaxItem,
		// Token: 0x0403041B RID: 197659
		TipTextItem,
		// Token: 0x0403041C RID: 197660
		ConsumeItem,
		// Token: 0x0403041D RID: 197661
		WeaponNameText,
		// Token: 0x0403041E RID: 197662
		SkillNameText
	}
}
