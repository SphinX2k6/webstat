using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CEC RID: 7404
public class GachaPoolDropItem : UiPanelBase
{
	// Token: 0x0600D951 RID: 55633 RVA: 0x003A4538 File Offset: 0x003A2738
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D952 RID: 55634 RVA: 0x003A4580 File Offset: 0x003A2780
	protected override void OnStart()
	{
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(this.Data.ItemId));
		string textStringId = this.Data.IsUp ? "GachaDropItemUp" : "GachaPoolDropItemNormal";
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleInfo? roleInfoById = ConfigBase<GachaConfig>.Instance.GetRoleInfoById(this.Data.ItemId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(roleInfoById.Value.Name, null)));
			return;
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponItem)
		{
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(this.Data.ItemId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), textStringId, new <>z__ReadOnlySingleElementList<object>(ConfigMultiTextLang.GetLocalTextNew(weaponConfigByItemId.Value.WeaponName, null)));
		}
	}

	// Token: 0x040067BF RID: 26559
	[Nullable(2)]
	public GachaPoolDrop Data;

	// Token: 0x02008053 RID: 32851
	private enum EGachaPoolDropItemDefine
	{
		// Token: 0x0402BA79 RID: 178809
		TxtName
	}
}
