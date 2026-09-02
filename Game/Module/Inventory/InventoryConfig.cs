using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;
using CSharpScript.Game.Module.RoleUi;
using Google.FlatBuffers;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B83 RID: 23427
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class InventoryConfig : ConfigBase<InventoryConfig>
	{
		// Token: 0x0603B387 RID: 242567 RVA: 0x00EFC64C File Offset: 0x00EFA84C
		public InventoryConfig()
		{
			this.Lru = new Lru<int, ItemConfig>(256, new Func<int, ItemConfig>(this.GetItemConfigDataRef), null);
		}

		// Token: 0x0603B388 RID: 242568 RVA: 0x00EFC6B7 File Offset: 0x00EFA8B7
		public IReadOnlyList<ItemMainType> GetAllMainTypeConfig()
		{
			return ConfigItemMainTypeAll.GetConfigList(true);
		}

		// Token: 0x0603B389 RID: 242569 RVA: 0x00EFC6BF File Offset: 0x00EFA8BF
		public ItemMainType? GetItemMainTypeConfig(int itemTypeId)
		{
			return ConfigItemMainTypeById.GetConfig(itemTypeId, true);
		}

		// Token: 0x0603B38A RID: 242570 RVA: 0x00EFC6C8 File Offset: 0x00EFA8C8
		public int? GetItemMainTypeFilterSortUseWayId(int itemTypeId)
		{
			ItemMainType? itemMainTypeConfig = this.GetItemMainTypeConfig(itemTypeId);
			if (itemMainTypeConfig == null)
			{
				return null;
			}
			return new int?(itemMainTypeConfig.Value.UseWayId);
		}

		// Token: 0x0603B38B RID: 242571 RVA: 0x00EFC704 File Offset: 0x00EFA904
		public AccessPath? GetAccessPathConfig(int accessPathId)
		{
			return ConfigAccessPathById.GetConfig(accessPathId, true);
		}

		// Token: 0x0603B38C RID: 242572 RVA: 0x00EFC70D File Offset: 0x00EFA90D
		public QualityInfo? GetItemQualityConfig(int qualityId)
		{
			return ConfigQualityInfoById.GetConfig(qualityId, true);
		}

		// Token: 0x0603B38D RID: 242573 RVA: 0x00EFC718 File Offset: 0x00EFA918
		public ItemConfig GetItemConfigData(int configId)
		{
			ItemConfig itemConfig = this.Lru.Get(configId);
			if (itemConfig != null)
			{
				this.Lru.Put(itemConfig);
				return itemConfig;
			}
			itemConfig = this.Lru.Create(configId);
			if (itemConfig == null)
			{
				return null;
			}
			this.Lru.Put(itemConfig);
			return itemConfig;
		}

		// Token: 0x0603B38E RID: 242574 RVA: 0x00EFC764 File Offset: 0x00EFA964
		public string GetItemConfigValueByParam(int configId, string param, [Nullable(1)] string tag)
		{
			ItemConfig itemConfigDataRef = this.GetItemConfigDataRef(configId);
			if (itemConfigDataRef == null || param == null)
			{
				return null;
			}
			if (param == "Icon")
			{
				return itemConfigDataRef.Icon;
			}
			if (param == "IconMiddle")
			{
				return itemConfigDataRef.IconMiddle;
			}
			if (param == "IconSmall")
			{
				return itemConfigDataRef.IconSmall;
			}
			if (!(param == "IconBig"))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.UiImageSetting;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "配置的表格字段查询到的资源路径不是字符串类型";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("配置的表格字段", tag);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return itemConfigDataRef.IconBig;
		}

		// Token: 0x0603B38F RID: 242575 RVA: 0x00EFC800 File Offset: 0x00EFAA00
		private ItemConfig GetItemConfigDataRef(int configId)
		{
			IFlatbufferObject flatbufferObject = null;
			InventoryDefine.EItemDataType itemDataTypeByConfigId = this.GetItemDataTypeByConfigId(new int?(configId));
			switch (itemDataTypeByConfigId)
			{
			case InventoryDefine.EItemDataType.CommonItem:
				flatbufferObject = this.GetItemConfig(configId);
				break;
			case InventoryDefine.EItemDataType.RoleItem:
				flatbufferObject = ConfigBase<RoleConfig>.Instance.GetRoleConfig(configId);
				break;
			case InventoryDefine.EItemDataType.WeaponItem:
				flatbufferObject = this.GetWeaponItemConfig(configId);
				break;
			case InventoryDefine.EItemDataType.PhantomItem:
				flatbufferObject = this.GetPhantomItemConfig(configId);
				break;
			case InventoryDefine.EItemDataType.PhantomCustomize:
			{
				PhantomCustomizeItem? phantomCustomizeItemConfig = this.GetPhantomCustomizeItemConfig(configId);
				if (phantomCustomizeItemConfig != null)
				{
					if (phantomCustomizeItemConfig.Value.SkinItemId > 0)
					{
						flatbufferObject = this.GetPhantomItemConfig(phantomCustomizeItemConfig.Value.SkinItemId);
					}
					else
					{
						flatbufferObject = this.GetPhantomItemConfig(phantomCustomizeItemConfig.Value.PhantomId);
					}
				}
				break;
			}
			case InventoryDefine.EItemDataType.VirtualItem:
				flatbufferObject = this.GetItemConfig(configId);
				break;
			case InventoryDefine.EItemDataType.CardItem:
				flatbufferObject = ConfigBackgroundCardById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PreviewItem:
				flatbufferObject = this.GetPreviewItemConfig(configId);
				break;
			case InventoryDefine.EItemDataType.RogueCurrency:
				flatbufferObject = ConfigRogueCurrencyById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.RogueResCurrency:
				flatbufferObject = ConfigRogueResCurrencyById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.WeaponSkinItem:
				flatbufferObject = ConfigWeaponSkinById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.RoleSkinItem:
				flatbufferObject = ConfigRoleSkinById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PlayerHeadItem:
				flatbufferObject = ConfigPlayerHeadReById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.DangoAbyssItem:
				flatbufferObject = ConfigAbyssItemById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.FlySkinItem:
				flatbufferObject = ConfigFlySkinConfigById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PhantomArenaCard:
				flatbufferObject = ConfigPhantomBattleCardById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PhantomArenaBadge:
				flatbufferObject = ConfigPhantomBattleBadgeById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.HonamiStoryItem:
				flatbufferObject = ConfigHonamiStoryItemById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.CalabashSkinItem:
				flatbufferObject = ConfigCalabashSkinById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.HonamiStoryWeapon:
				flatbufferObject = ConfigHonamiStoryWeaponById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.InfrastructureItem:
				flatbufferObject = this.GetItemConfig(configId);
				break;
			case InventoryDefine.EItemDataType.MotorStickerItem:
				flatbufferObject = ConfigMotorStickerById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PhoneChatDialog:
				flatbufferObject = ConfigChatDialogById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PhoneChatBackGround:
				flatbufferObject = ConfigChatBgById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.FurnitureItem:
				flatbufferObject = ConfigFurnitureById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.MotorFrameItem:
				flatbufferObject = ConfigMotorFrameById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.MotorDecorationItem:
				flatbufferObject = ConfigMotorDecorationsById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.MotorSkinItem:
				flatbufferObject = ConfigMotorSkinById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.OrnamentItem:
				flatbufferObject = ConfigOrnamentById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PinballRoleItem:
				flatbufferObject = ConfigPinballRoleConfigById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.PinballWeaponItem:
				flatbufferObject = ConfigPinballWeaponConfigById.GetConfig(configId, true);
				break;
			case InventoryDefine.EItemDataType.RoverRogueCurrency:
				flatbufferObject = ConfigBase<RoverlikeConfig>.Instance.GetCurrencyConfig(configId);
				break;
			}
			if (flatbufferObject == null)
			{
				return null;
			}
			ItemConfig itemConfig = new ItemConfig();
			itemConfig.Refresh(flatbufferObject, itemDataTypeByConfigId, configId);
			return itemConfig;
		}

		// Token: 0x0603B390 RID: 242576 RVA: 0x00EFCB3C File Offset: 0x00EFAD3C
		public InventoryDefine.EItemDataType GetItemDataTypeByConfigId(int? configId)
		{
			if (configId == null)
			{
				return InventoryDefine.EItemDataType.CommonItem;
			}
			if (this.ErrorPhantomSpecialIdList == null)
			{
				this.ErrorPhantomSpecialIdList = this.GetErrorPhantomSpecialIdList();
			}
			if (this.ErrorPhantomSpecialIdList != null && this.ErrorPhantomSpecialIdList.Contains(configId.Value))
			{
				return InventoryDefine.EItemDataType.PhantomCustomize;
			}
			int? num = configId;
			int num2 = InventoryDefine.weaponIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.weaponIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.WeaponItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.phantomIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.phantomIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PhantomItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.phantomSpecificIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.phantomSpecificIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PhantomCustomize;
				}
			}
			num = configId;
			num2 = InventoryDefine.roleIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.roleIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.RoleItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.virtualIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.virtualIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.VirtualItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.cardIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.cardIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.CardItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.previewItemIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.previewItemIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PreviewItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.rogueCurrencyIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.rogueCurrencyIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.RogueCurrency;
				}
			}
			num = configId;
			num2 = InventoryDefine.rogueResCurrencyIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.rogueResCurrencyIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.RogueResCurrency;
				}
			}
			num = configId;
			num2 = InventoryDefine.roverRogueCurrencyIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.roverRogueCurrencyIdRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.RoverRogueCurrency;
				}
			}
			num = configId;
			num2 = InventoryDefine.weaponSkinIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.weaponSkinIdRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.WeaponSkinItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.roleSkinIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.roleSkinIdRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.RoleSkinItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.playerHeadRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.playerHeadRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PlayerHeadItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.DangoAbyssItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.DangoAbyssItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.DangoAbyssItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.flySkinIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.flySkinIdRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.FlySkinItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.PhantomArenaCardItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.PhantomArenaCardItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PhantomArenaCard;
				}
			}
			num = configId;
			num2 = InventoryDefine.PhantomArenaBadgeItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.PhantomArenaBadgeItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PhantomArenaBadge;
				}
			}
			num = configId;
			num2 = InventoryDefine.HonamiStoryItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.HonamiStoryItemRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.HonamiStoryItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.HonamiStoryWeaponRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.HonamiStoryWeaponRange[1];
				if (num.GetValueOrDefault() <= num2 & num != null)
				{
					return InventoryDefine.EItemDataType.HonamiStoryWeapon;
				}
			}
			num = configId;
			num2 = InventoryDefine.calabashSkinIdRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.calabashSkinIdRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.CalabashSkinItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.InfrastructureItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.InfrastructureItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.InfrastructureItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.MotorFrameItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.MotorFrameItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.MotorFrameItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.MotorStickerItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.MotorStickerItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.MotorStickerItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.MotorDecorationItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.MotorDecorationItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.MotorDecorationItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.MotorSkinItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.MotorSkinItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.MotorSkinItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.PhoneChatDialogItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.PhoneChatDialogItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PhoneChatDialog;
				}
			}
			num = configId;
			num2 = InventoryDefine.PhoneChatBackGroundItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.PhoneChatBackGroundItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PhoneChatBackGround;
				}
			}
			num = configId;
			num2 = InventoryDefine.FurnitureItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.FurnitureItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.FurnitureItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.OrnamentItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.OrnamentItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.OrnamentItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.PinballRoleItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.PinballRoleItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PinballRoleItem;
				}
			}
			num = configId;
			num2 = InventoryDefine.PinballWeaponItemRange[0];
			if (num.GetValueOrDefault() >= num2 & num != null)
			{
				num = configId;
				num2 = InventoryDefine.PinballWeaponItemRange[1];
				if (num.GetValueOrDefault() < num2 & num != null)
				{
					return InventoryDefine.EItemDataType.PinballWeaponItem;
				}
			}
			return InventoryDefine.EItemDataType.CommonItem;
		}

		// Token: 0x0603B391 RID: 242577 RVA: 0x00EFD3A1 File Offset: 0x00EFB5A1
		public ItemInfo? GetItemConfig(int itemConfigId)
		{
			return ConfigItemInfoById.GetConfig(itemConfigId, true);
		}

		// Token: 0x0603B392 RID: 242578 RVA: 0x00EFD3AA File Offset: 0x00EFB5AA
		public PreviewItem? GetPreviewItemConfig(int itemConfigId)
		{
			return ConfigPreviewItemById.GetConfig(itemConfigId, true);
		}

		// Token: 0x0603B393 RID: 242579 RVA: 0x00EFD3B3 File Offset: 0x00EFB5B3
		public WeaponConf? GetWeaponItemConfig(int configId)
		{
			return ConfigWeaponConfByItemId.GetConfig(configId, true);
		}

		// Token: 0x0603B394 RID: 242580 RVA: 0x00EFD3BC File Offset: 0x00EFB5BC
		public PhantomItem? GetPhantomItemConfig(int configId)
		{
			return ConfigPhantomItemByItemId.GetConfig(configId, true);
		}

		// Token: 0x0603B395 RID: 242581 RVA: 0x00EFD3C5 File Offset: 0x00EFB5C5
		public PhantomCustomizeItem? GetPhantomCustomizeItemConfig(int configId)
		{
			return ConfigPhantomCustomizeItemByItemId.GetConfig(configId, true);
		}

		// Token: 0x0603B396 RID: 242582 RVA: 0x00EFD3D0 File Offset: 0x00EFB5D0
		public IReadOnlyList<PhantomItem> GetPhantomItemConfigListByMonsterId(int monsterId)
		{
			IReadOnlyList<PhantomItem> configList = ConfigPhantomItemByMonsterId.GetConfigList(monsterId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Config;
				ELogAuthor author = ELogAuthor.ZJC;
				string message = "表格查询不到配置ID";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MonsterId", monsterId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x0603B397 RID: 242583 RVA: 0x00EFD412 File Offset: 0x00EFB612
		public BackgroundCard? GetCardItemConfig(int configId)
		{
			return ConfigBackgroundCardById.GetConfig(configId, true);
		}

		// Token: 0x0603B398 RID: 242584 RVA: 0x00EFD41B File Offset: 0x00EFB61B
		public IReadOnlyList<int> GetErrorPhantomSpecialIdList()
		{
			return ConfigCommonParamById.GetIntArrayConfig("SpecialPhantomCustomizeItem");
		}

		// Token: 0x0603B399 RID: 242585 RVA: 0x00EFD427 File Offset: 0x00EFB627
		public IReadOnlyList<PackageCapacity> GetAllPackageConfig()
		{
			return ConfigPackageCapacityAll.GetConfigList(true);
		}

		// Token: 0x0603B39A RID: 242586 RVA: 0x00EFD42F File Offset: 0x00EFB62F
		public PackageCapacity? GetPackageConfig(int packageConfigId)
		{
			return ConfigPackageCapacityByPackageId.GetConfig(packageConfigId, true);
		}

		// Token: 0x0603B39B RID: 242587 RVA: 0x00EFD438 File Offset: 0x00EFB638
		public TypeInfo? GetItemTypeConfig(int itemType)
		{
			return ConfigTypeInfoById.GetConfig(itemType, true);
		}

		// Token: 0x0603B39C RID: 242588 RVA: 0x00EFD441 File Offset: 0x00EFB641
		public ItemShowType? GetItemShowTypeConfig(int showItemType)
		{
			return ConfigItemShowTypeById.GetConfig(showItemType, true);
		}

		// Token: 0x0603B39D RID: 242589 RVA: 0x00EFD44A File Offset: 0x00EFB64A
		public PlayerTitle? GetPlayerTitleItemConfig(int configId)
		{
			return ConfigPlayerTitleById.GetConfig(configId, true);
		}

		// Token: 0x0603B39E RID: 242590 RVA: 0x00EFD454 File Offset: 0x00EFB654
		public TItemQualityConfig GetItemQualityByItemIdAndQuality(int? configId, int qualityId)
		{
			if (configId == null)
			{
				QualityInfo? itemQualityConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(qualityId);
				if (itemQualityConfig == null)
				{
					return null;
				}
				return itemQualityConfig.GetValueOrDefault();
			}
			else
			{
				InventoryDefine.EItemDataType itemDataTypeByConfigId = this.GetItemDataTypeByConfigId(new int?(configId.Value));
				if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.HonamiStoryItem)
				{
					HonamiStoryItemQuality? honamiStoryQuality = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(qualityId);
					if (honamiStoryQuality == null)
					{
						return null;
					}
					return honamiStoryQuality.GetValueOrDefault();
				}
				else if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.DangoAbyssItem)
				{
					AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(qualityId);
					if (abyssQualityById == null)
					{
						return null;
					}
					return abyssQualityById.GetValueOrDefault();
				}
				else
				{
					QualityInfo? itemQualityConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(qualityId);
					if (itemQualityConfig == null)
					{
						return null;
					}
					return itemQualityConfig.GetValueOrDefault();
				}
			}
		}

		// Token: 0x0603B39F RID: 242591 RVA: 0x00EFD518 File Offset: 0x00EFB718
		[NullableContext(1)]
		[return: Nullable(2)]
		public TItemQualityConfig GetItemQualityByConfig(ItemConfig config)
		{
			int qualityId = config.QualityId;
			InventoryDefine.EItemType? itemType = config.ItemType;
			if (itemType.GetValueOrDefault() == InventoryDefine.EItemType.HonamiStoryItem)
			{
				HonamiStoryItemQuality? honamiStoryQuality = ConfigBase<HonamiStoryConfig>.Instance.GetHonamiStoryQuality(qualityId);
				if (honamiStoryQuality == null)
				{
					return null;
				}
				return honamiStoryQuality.GetValueOrDefault();
			}
			else if (itemType.GetValueOrDefault() == InventoryDefine.EItemType.AbyssItem)
			{
				AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(qualityId);
				if (abyssQualityById == null)
				{
					return null;
				}
				return abyssQualityById.GetValueOrDefault();
			}
			else
			{
				QualityInfo? itemQualityConfig = ConfigBase<InventoryConfig>.Instance.GetItemQualityConfig(qualityId);
				if (itemQualityConfig == null)
				{
					return null;
				}
				return itemQualityConfig.GetValueOrDefault();
			}
		}

		// Token: 0x0603B3A0 RID: 242592 RVA: 0x00EFD5B8 File Offset: 0x00EFB7B8
		public int GetPhantomFusionThreshold()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomFusionThreshold").GetValueOrDefault(1000);
		}

		// Token: 0x0603B3A1 RID: 242593 RVA: 0x00EFD5DC File Offset: 0x00EFB7DC
		public int GetPhantomDiscardThreshold()
		{
			return ConfigCommonParamById.GetIntConfig("PhantomDiscardThreshold").GetValueOrDefault(2500);
		}

		// Token: 0x0603B3A2 RID: 242594 RVA: 0x00EFD600 File Offset: 0x00EFB800
		protected override bool OnClear()
		{
			this.CommonItemConfigMap.Clear();
			this.WeaponItemConfigMap.Clear();
			this.PhantomItemConfigMap.Clear();
			this.Lru.Clear();
			return true;
		}

		// Token: 0x04021623 RID: 136739
		private IReadOnlyList<int> ErrorPhantomSpecialIdList;

		// Token: 0x04021624 RID: 136740
		[Nullable(1)]
		private readonly Dictionary<int, ItemInfo> CommonItemConfigMap = new Dictionary<int, ItemInfo>();

		// Token: 0x04021625 RID: 136741
		[Nullable(1)]
		private readonly Dictionary<int, WeaponConf> WeaponItemConfigMap = new Dictionary<int, WeaponConf>();

		// Token: 0x04021626 RID: 136742
		[Nullable(1)]
		private readonly Dictionary<int, PhantomItem> PhantomItemConfigMap = new Dictionary<int, PhantomItem>();

		// Token: 0x04021627 RID: 136743
		[Nullable(1)]
		private readonly Stat StatGetItemConfigData = Stat.Create("GetItemConfigData", "", "");

		// Token: 0x04021628 RID: 136744
		[Nullable(1)]
		private readonly Lru<int, ItemConfig> Lru;

		// Token: 0x04021629 RID: 136745
		private const int ITEM_LRU_SIZE = 256;
	}
}
