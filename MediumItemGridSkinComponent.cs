using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x020019DF RID: 6623
public class MediumItemGridSkinComponent : MediumItemGridComponent
{
	// Token: 0x0600BDE8 RID: 48616 RVA: 0x00324F66 File Offset: 0x00323166
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemASkin";
	}

	// Token: 0x0600BDE9 RID: 48617 RVA: 0x00324F70 File Offset: 0x00323170
	protected unsafe override void OnRegisterComponent()
	{
		int num = 1;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int index = 0;
		*span[index] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600BDEA RID: 48618 RVA: 0x00324FB8 File Offset: 0x003231B8
	[NullableContext(2)]
	protected override void OnRefresh(object data)
	{
		if (data is int)
		{
			int itemConfigId = (int)data;
			this.SetActive(true);
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(this.GetTexturePath(itemConfigId));
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
			return;
		}
	}

	// Token: 0x0600BDEB RID: 48619 RVA: 0x00325008 File Offset: 0x00323208
	[NullableContext(1)]
	private string GetTexturePath(int itemConfigId)
	{
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(itemConfigId));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponSkinItem)
		{
			return "T_IconFilterSkin3";
		}
		if (itemDataTypeByConfigId != InventoryDefine.EItemDataType.RoleSkinItem)
		{
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.FlySkinItem)
			{
				FlySkinConfig? flySkinConfig = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(itemConfigId);
				if (flySkinConfig != null)
				{
					return ConfigBase<SkinConfig>.Instance.GetFlySkinBottomIconResourceId((EFlySkinType)flySkinConfig.Value.SkinType);
				}
			}
			else
			{
				if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.CalabashSkinItem)
				{
					return "T_IconFilterSkin6";
				}
				if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.OrnamentItem)
				{
					return "T_IconFilterSkin7";
				}
			}
			return "";
		}
		RoleSkinData roleSkinData = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(itemConfigId);
		if (roleSkinData != null && roleSkinData.GetSuitWeaponSkinId() > 0)
		{
			return "T_IconFilterSkin1";
		}
		return "T_IconFilterSkin2";
	}

	// Token: 0x0600BDEC RID: 48620 RVA: 0x003250A9 File Offset: 0x003232A9
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007CD2 RID: 31954
	private class EChildType
	{
		// Token: 0x0402A98E RID: 174478
		public const int WeaponTexture = 0;
	}
}
