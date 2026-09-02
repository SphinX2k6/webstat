using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020025CF RID: 9679
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class GachaShareSwitchItem : GridProxyAbstract<GachaShareSwitchData>
{
	// Token: 0x06012EB4 RID: 77492 RVA: 0x0053BF88 File Offset: 0x0053A188
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06012EB5 RID: 77493 RVA: 0x0053C01B File Offset: 0x0053A21B
	private void OnClickToggle(EToggleState obj)
	{
		if (this.ToggleClickCb != null)
		{
			this.ToggleClickCb(this.SwitchData, base.GridIndex);
		}
	}

	// Token: 0x06012EB6 RID: 77494 RVA: 0x0053C03C File Offset: 0x0053A23C
	public void SetToggleClickCallback(Action<GachaShareSwitchData, int> cb)
	{
		this.ToggleClickCb = cb;
	}

	// Token: 0x06012EB7 RID: 77495 RVA: 0x0053C048 File Offset: 0x0053A248
	public override void Refresh(GachaShareSwitchData switchData, bool isSelected, int gridIndex)
	{
		this.SwitchData = switchData;
		base.GridIndex = gridIndex;
		if (switchData.TenGachaInfo != null)
		{
			base.GetItem(1).SetUIActive(true);
			base.GetTexture(3).SetUIActive(false);
			base.GetTexture(2).SetUIActive(false);
			return;
		}
		int itemId = switchData.GachaInfo.Proto_GachaReward.ItemId;
		base.GetItem(1).SetUIActive(false);
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId);
		base.GetTexture(3).SetUIActive(itemIdType == InventoryDefine.EItemDataType.RoleItem);
		base.GetTexture(2).SetUIActive(itemIdType == InventoryDefine.EItemDataType.WeaponItem);
		if (itemIdType == InventoryDefine.EItemDataType.RoleItem)
		{
			string card = ConfigBase<RoleConfig>.Instance.GetRoleConfig(itemId).Value.Card;
			base.SetTextureByPath(card, base.GetTexture(3), null, null);
		}
		else if (itemIdType == InventoryDefine.EItemDataType.WeaponItem)
		{
			string icon = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId).Value.Icon;
			base.SetTextureByPath(icon, base.GetTexture(2), null, null);
		}
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		if (extendToggle == null)
		{
			return;
		}
		extendToggle.SetToggleState(isSelected ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06012EB8 RID: 77496 RVA: 0x0053C172 File Offset: 0x0053A372
	public override void OnSelected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_Checked, false, false, false);
	}

	// Token: 0x06012EB9 RID: 77497 RVA: 0x0053C185 File Offset: 0x0053A385
	public override void OnDeselected(bool fireEvent)
	{
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040093C4 RID: 37828
	[Nullable(2)]
	private GachaShareSwitchData SwitchData;

	// Token: 0x040093C5 RID: 37829
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Action<GachaShareSwitchData, int> ToggleClickCb;

	// Token: 0x0200893A RID: 35130
	[NullableContext(0)]
	private enum EComponents
	{
		// Token: 0x0402E4DC RID: 189660
		Toggle,
		// Token: 0x0402E4DD RID: 189661
		DefaultIcon,
		// Token: 0x0402E4DE RID: 189662
		WeaponIcon,
		// Token: 0x0402E4DF RID: 189663
		RoleIcon
	}
}
