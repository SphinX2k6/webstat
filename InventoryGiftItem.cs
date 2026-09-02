using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002029 RID: 8233
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class InventoryGiftItem : GridProxyAbstract<GiftItemData>
{
	// Token: 0x0600FA48 RID: 64072 RVA: 0x00448FAB File Offset: 0x004471AB
	public void Initialize(UUIItem uiItem = null)
	{
		if (uiItem != null)
		{
			this.CreateThenShowByActor(uiItem.GetOwner());
		}
	}

	// Token: 0x0600FA49 RID: 64073 RVA: 0x00448FBC File Offset: 0x004471BC
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
		num2 = 1;
		List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
		CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
		Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
		num = 0;
		*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickReduce));
		this.BtnBindInfo = list2;
	}

	// Token: 0x0600FA4A RID: 64074 RVA: 0x004490E8 File Offset: 0x004472E8
	private void OnClickReduce()
	{
		this.Toggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
		this.ReduceButton.RootUIComp.Get().SetUIActive(false);
		if (this.OnReduceFunction != null)
		{
			this.OnReduceFunction(this.ItemData);
		}
	}

	// Token: 0x0600FA4B RID: 64075 RVA: 0x00449138 File Offset: 0x00447338
	private void OnToggleStateChange(EToggleState state)
	{
		bool flag = state == EToggleState.ETT_Checked;
		if (this.ReduceButton != null)
		{
			this.ReduceButton.RootUIComp.Get().SetUIActive(flag);
		}
		if (this.OnToggleStateChangeFunction != null)
		{
			this.OnToggleStateChangeFunction(this.Toggle, this.ReduceButton, flag, this.ItemData);
		}
	}

	// Token: 0x0600FA4C RID: 64076 RVA: 0x00449191 File Offset: 0x00447391
	protected override void OnStart()
	{
		this.InitView();
	}

	// Token: 0x0600FA4D RID: 64077 RVA: 0x00449199 File Offset: 0x00447399
	protected override void OnBeforeDestroy()
	{
		this.ItemNameText = null;
		this.ItemCountText = null;
		this.ReduceButton = null;
		this.ItemConfigId = null;
		this.Toggle = null;
		this.ItemData = null;
		this.ItemGrid = null;
		this.WeaponTypeIcon = null;
	}

	// Token: 0x0600FA4E RID: 64078 RVA: 0x004491D8 File Offset: 0x004473D8
	private void InitView()
	{
		this.ItemNameText = base.GetText(1);
		this.ItemCountText = base.GetText(2);
		this.Toggle = base.GetExtendToggle(4);
		this.Toggle.OnStateChange.Add(new Action<EToggleState>(this.OnToggleStateChange));
		this.ReduceButton = base.GetButton(3);
		this.ReduceButton.RootUIComp.Get().SetUIActive(false);
		this.ItemGrid = new InventoryGiftCellItem();
		this.ItemGrid.Initialize(base.GetItem(0).GetOwner());
		this.WeaponTypeIcon = base.GetSprite(5);
		this.WeaponTypeIcon.SetUIActive(false);
	}

	// Token: 0x0600FA4F RID: 64079 RVA: 0x00449289 File Offset: 0x00447489
	[NullableContext(1)]
	public override void Refresh(GiftItemData data, bool isSelect, int gridIndex)
	{
		this.ItemData = data;
		this.RefreshItem(data);
		if (this.IsSelectOn != null)
		{
			this.SetSelected(this.IsSelectOn(data), false);
		}
	}

	// Token: 0x0600FA50 RID: 64080 RVA: 0x004492B4 File Offset: 0x004474B4
	public override void OnSelected(bool fireEvent)
	{
		if (this.IsSelectOn != null && this.ItemData != null)
		{
			this.SetSelected(this.IsSelectOn(this.ItemData), false);
		}
	}

	// Token: 0x0600FA51 RID: 64081 RVA: 0x004492E0 File Offset: 0x004474E0
	[NullableContext(1)]
	public void RefreshItem(GiftItemData data)
	{
		this.ItemConfigId = new int?(data.ItemId);
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(this.ItemConfigId.Value);
		string newText = ConfigMultiTextLang.GetLocalTextNew(itemConfigData.Name, null) ?? "";
		this.ItemNameText.SetText(newText, true);
		Singleton<LguiUtil>.Instance.SetLocalText(this.ItemCountText, "Quantity", new <>z__ReadOnlySingleElementList<object>(data.ItemCount));
		this.ItemGrid.RefreshByConfigId(data);
		this.WeaponTypeIcon.SetUIActive(false);
		if (itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.Weapon)
		{
			IEnumerable<Mapping> weaponConfList = ConfigBase<MappingConfig>.Instance.GetWeaponConfList();
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.ItemConfigId.Value);
			foreach (Mapping mapping in weaponConfList)
			{
				if (weaponConfigByItemId.Value.WeaponType == mapping.Value)
				{
					this.WeaponTypeIcon.SetUIActive(true);
					this.SetSpriteByPath(mapping.Icon, this.WeaponTypeIcon, false, null, null);
					break;
				}
			}
		}
	}

	// Token: 0x0600FA52 RID: 64082 RVA: 0x0044941C File Offset: 0x0044761C
	private void SetSelected(bool bSelectOn, bool bFireEvent = false)
	{
		this.Toggle.SetToggleState(bSelectOn ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, bFireEvent, false, false);
		this.ReduceButton.RootUIComp.Get().SetUIActive(bSelectOn);
	}

	// Token: 0x0600FA53 RID: 64083 RVA: 0x00449458 File Offset: 0x00447658
	public void RefreshSelectState()
	{
		if (this.IsSelectOn != null && this.ItemData != null)
		{
			this.SetSelected(this.IsSelectOn(this.ItemData), false);
		}
	}

	// Token: 0x0600FA54 RID: 64084 RVA: 0x00449482 File Offset: 0x00447682
	[NullableContext(1)]
	public void SetOnToggleStateChangeFunction(Action<UUIExtendToggle, UUIButtonComponent, bool, GiftItemData> onToggleStateChangeFunction)
	{
		this.OnToggleStateChangeFunction = onToggleStateChangeFunction;
	}

	// Token: 0x0600FA55 RID: 64085 RVA: 0x0044948B File Offset: 0x0044768B
	[NullableContext(1)]
	public void SetOnReduceFunction(Action<GiftItemData> onReduceFunction)
	{
		this.OnReduceFunction = onReduceFunction;
	}

	// Token: 0x0600FA56 RID: 64086 RVA: 0x00449494 File Offset: 0x00447694
	[NullableContext(1)]
	public void SetIsSelectOn(Func<GiftItemData, bool> isSelectOnFunction)
	{
		this.IsSelectOn = isSelectOnFunction;
	}

	// Token: 0x0400782E RID: 30766
	private UUIText ItemNameText;

	// Token: 0x0400782F RID: 30767
	private UUIText ItemCountText;

	// Token: 0x04007830 RID: 30768
	private UUIButtonComponent ReduceButton;

	// Token: 0x04007831 RID: 30769
	private int? ItemConfigId;

	// Token: 0x04007832 RID: 30770
	private UUIExtendToggle Toggle;

	// Token: 0x04007833 RID: 30771
	private GiftItemData ItemData;

	// Token: 0x04007834 RID: 30772
	private InventoryGiftCellItem ItemGrid;

	// Token: 0x04007835 RID: 30773
	[Nullable(new byte[]
	{
		2,
		1,
		1,
		1
	})]
	private Action<UUIExtendToggle, UUIButtonComponent, bool, GiftItemData> OnToggleStateChangeFunction;

	// Token: 0x04007836 RID: 30774
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<GiftItemData> OnReduceFunction;

	// Token: 0x04007837 RID: 30775
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Func<GiftItemData, bool> IsSelectOn;

	// Token: 0x04007838 RID: 30776
	private UUISprite WeaponTypeIcon;

	// Token: 0x020083CF RID: 33743
	[NullableContext(0)]
	private enum EInventoryGiftItemType
	{
		// Token: 0x0402CB02 RID: 183042
		ItemGridItem,
		// Token: 0x0402CB03 RID: 183043
		ItemNameText,
		// Token: 0x0402CB04 RID: 183044
		ItemCountText,
		// Token: 0x0402CB05 RID: 183045
		ReduceButton,
		// Token: 0x0402CB06 RID: 183046
		Toggle,
		// Token: 0x0402CB07 RID: 183047
		WeaponTypeIcon
	}
}
