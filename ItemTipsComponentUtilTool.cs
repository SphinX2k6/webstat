using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Item;

// Token: 0x02001996 RID: 6550
[NullableContext(2)]
[Nullable(0)]
public class ItemTipsComponentUtilTool : IStaticVariableResetter
{
	// Token: 0x0600BC0A RID: 48138 RVA: 0x0031EDA1 File Offset: 0x0031CFA1
	static ItemTipsComponentUtilTool()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ItemTipsComponentUtilTool.CreateStaticDefaultValue), new Action(ItemTipsComponentUtilTool.ResetStaticDefaultValue));
	}

	// Token: 0x0600BC0B RID: 48139 RVA: 0x0031EDC0 File Offset: 0x0031CFC0
	public static void CreateStaticDefaultValue()
	{
		ItemTipsComponentUtilTool.TypeDataRelationMap = new Dictionary<EItemTipsType, Type>
		{
			{
				EItemTipsType.Normal,
				typeof(TipsMaterialData)
			},
			{
				EItemTipsType.Weapon,
				typeof(TipsWeaponData)
			},
			{
				EItemTipsType.Vision,
				typeof(TipsVisionData)
			},
			{
				EItemTipsType.Character,
				typeof(TipsCharacterData)
			},
			{
				EItemTipsType.OverPower,
				typeof(TipsOverPowerData)
			},
			{
				EItemTipsType.Card,
				typeof(TipsCardData)
			},
			{
				EItemTipsType.Head,
				typeof(TipsHeadData)
			},
			{
				EItemTipsType.AbyssDango,
				typeof(TipsAbyssDangoData)
			},
			{
				EItemTipsType.HonamiStory,
				typeof(TipsHonamiStoryData)
			},
			{
				EItemTipsType.Furniture,
				typeof(TipsFurnitureData)
			},
			{
				EItemTipsType.RoleSkin,
				typeof(TipsRoleSkinData)
			},
			{
				EItemTipsType.PinballItem,
				typeof(TipsPinballItemData)
			}
		};
		ItemTipsComponentUtilTool.TypeUiTypeRelationMap = new Dictionary<EItemTipsType, ETipsUiType>
		{
			{
				EItemTipsType.Normal,
				ETipsUiType.ItemTipsComponent
			},
			{
				EItemTipsType.Weapon,
				ETipsUiType.ItemTipsComponent
			},
			{
				EItemTipsType.Vision,
				ETipsUiType.ItemTipsComponent
			},
			{
				EItemTipsType.Character,
				ETipsUiType.ItemTipsComponent
			},
			{
				EItemTipsType.OverPower,
				ETipsUiType.PowerTipsItem
			},
			{
				EItemTipsType.Card,
				ETipsUiType.PersonalCardPreviewComponent
			},
			{
				EItemTipsType.Head,
				ETipsUiType.PersonalHeadPreviewComponent
			},
			{
				EItemTipsType.AbyssDango,
				ETipsUiType.ItemTipsComponent
			},
			{
				EItemTipsType.HonamiStory,
				ETipsUiType.HonamiStoryTipsItem
			},
			{
				EItemTipsType.Furniture,
				ETipsUiType.FurnitureTipsItem
			},
			{
				EItemTipsType.RoleSkin,
				ETipsUiType.ItemTipsComponent
			},
			{
				EItemTipsType.PinballItem,
				ETipsUiType.PinballTipsItem
			}
		};
		ItemTipsComponentUtilTool.TypeItemDataRelationMap = new Dictionary<InventoryDefine.EItemDataType, EItemTipsType>
		{
			{
				InventoryDefine.EItemDataType.PhantomItem,
				EItemTipsType.Vision
			},
			{
				InventoryDefine.EItemDataType.WeaponItem,
				EItemTipsType.Weapon
			},
			{
				InventoryDefine.EItemDataType.RoleItem,
				EItemTipsType.Character
			},
			{
				InventoryDefine.EItemDataType.CardItem,
				EItemTipsType.Card
			},
			{
				InventoryDefine.EItemDataType.DangoAbyssItem,
				EItemTipsType.AbyssDango
			},
			{
				InventoryDefine.EItemDataType.HonamiStoryItem,
				EItemTipsType.HonamiStory
			},
			{
				InventoryDefine.EItemDataType.FurnitureItem,
				EItemTipsType.Furniture
			},
			{
				InventoryDefine.EItemDataType.RoleSkinItem,
				EItemTipsType.RoleSkin
			},
			{
				InventoryDefine.EItemDataType.PinballWeaponItem,
				EItemTipsType.PinballItem
			},
			{
				InventoryDefine.EItemDataType.PinballRoleItem,
				EItemTipsType.PinballItem
			}
		};
		ItemTipsComponentUtilTool.ItemIdRelationMap = new Dictionary<int, EItemTipsType>
		{
			{
				6,
				EItemTipsType.OverPower
			}
		};
	}

	// Token: 0x0600BC0C RID: 48140 RVA: 0x0031EFB9 File Offset: 0x0031D1B9
	public static void ResetStaticDefaultValue()
	{
		ItemTipsComponentUtilTool.TypeDataRelationMap = null;
		ItemTipsComponentUtilTool.TypeUiTypeRelationMap = null;
		ItemTipsComponentUtilTool.TypeItemDataRelationMap = null;
		ItemTipsComponentUtilTool.ItemIdRelationMap = null;
	}

	// Token: 0x0600BC0D RID: 48141 RVA: 0x0031EFD4 File Offset: 0x0031D1D4
	public static EItemTipsType? GetItemItemType(int configId)
	{
		EItemTipsType value;
		if (ItemTipsComponentUtilTool.ItemIdRelationMap.TryGetValue(configId, out value))
		{
			return new EItemTipsType?(value);
		}
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(configId));
		EItemTipsType value2;
		if (!ItemTipsComponentUtilTool.TypeItemDataRelationMap.TryGetValue(itemDataTypeByConfigId, out value2))
		{
			value2 = EItemTipsType.Normal;
		}
		return new EItemTipsType?(value2);
	}

	// Token: 0x0600BC0E RID: 48142 RVA: 0x0031F020 File Offset: 0x0031D220
	public static ItemTipsData GetTipsDataById(int configId, int? incId = null, object extraParam = null)
	{
		EItemTipsType? itemItemType = ItemTipsComponentUtilTool.GetItemItemType(configId);
		if (itemItemType == null)
		{
			return null;
		}
		Type type;
		if (!ItemTipsComponentUtilTool.TypeDataRelationMap.TryGetValue(itemItemType.Value, out type))
		{
			return null;
		}
		ItemTipsParam itemTipsParam = new ItemTipsParam();
		itemTipsParam.ItemId = configId;
		itemTipsParam.ItemUid = ((incId != null) ? incId.Value : 0);
		itemTipsParam.ExtraParam = extraParam;
		return (ItemTipsData)Activator.CreateInstance(type, new object[]
		{
			itemTipsParam
		});
	}

	// Token: 0x0600BC0F RID: 48143 RVA: 0x0031F098 File Offset: 0x0031D298
	[NullableContext(1)]
	[return: Nullable(2)]
	public static ItemTipsData GetTipsDataByPram(ItemTipsParam data)
	{
		EItemTipsType? itemItemType = ItemTipsComponentUtilTool.GetItemItemType(data.ItemId);
		if (itemItemType == null)
		{
			return null;
		}
		Type type;
		if (!ItemTipsComponentUtilTool.TypeDataRelationMap.TryGetValue(itemItemType.Value, out type))
		{
			return null;
		}
		return (ItemTipsData)Activator.CreateInstance(type, new object[]
		{
			data
		});
	}

	// Token: 0x0600BC10 RID: 48144 RVA: 0x0031F0E8 File Offset: 0x0031D2E8
	public static ETipsUiType GetTipsUiType(EItemTipsType tipsType)
	{
		ETipsUiType result;
		if (ItemTipsComponentUtilTool.TypeUiTypeRelationMap.TryGetValue(tipsType, out result))
		{
			return result;
		}
		return ETipsUiType.ItemTipsComponent;
	}

	// Token: 0x0400590F RID: 22799
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static Dictionary<EItemTipsType, Type> TypeDataRelationMap;

	// Token: 0x04005910 RID: 22800
	private static Dictionary<EItemTipsType, ETipsUiType> TypeUiTypeRelationMap;

	// Token: 0x04005911 RID: 22801
	private static Dictionary<InventoryDefine.EItemDataType, EItemTipsType> TypeItemDataRelationMap;

	// Token: 0x04005912 RID: 22802
	private static Dictionary<int, EItemTipsType> ItemIdRelationMap;
}
