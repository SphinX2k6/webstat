using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Data.Entity.Struct;
using CSharpScript.Game.Module.RoleUi;
using Google.FlatBuffers;

namespace CSharpScript.Game.Module.Inventory
{
	// Token: 0x02005B87 RID: 23431
	[NullableContext(1)]
	[Nullable(0)]
	public class ItemConfig
	{
		// Token: 0x0603B3B3 RID: 242611 RVA: 0x00EFDA34 File Offset: 0x00EFBC34
		public void Refresh(IFlatbufferObject config, InventoryDefine.EItemDataType type, int itemId)
		{
			this.Id = itemId;
			if (config is ItemInfo)
			{
				ItemInfo itemInfo = (ItemInfo)config;
				if (type == InventoryDefine.EItemDataType.InfrastructureItem)
				{
					this.Icon = itemInfo.Icon;
					this.QualityId = itemInfo.QualityId;
					this.AttributesDescription = itemInfo.AttributesDescription;
					this.RefreshInfrastructureItemConfig(itemInfo);
					return;
				}
				ItemInfo config2 = itemInfo;
				this.Icon = config2.Icon;
				this.QualityId = config2.QualityId;
				this.AttributesDescription = config2.AttributesDescription;
				this.RefreshItemConfig(config2);
				return;
			}
			else
			{
				if (config is PhantomItem)
				{
					PhantomItem config3 = (PhantomItem)config;
					this.Icon = config3.Icon;
					this.QualityId = config3.QualityId;
					this.AttributesDescription = config3.AttributesDescription;
					this.RefreshPhantomConfig(config3);
					return;
				}
				if (config is WeaponConf)
				{
					WeaponConf config4 = (WeaponConf)config;
					this.Icon = config4.Icon;
					this.QualityId = config4.QualityId;
					this.AttributesDescription = config4.AttributesDescription;
					this.RefreshWeaponConfig(config4);
					return;
				}
				if (config is RoleInfo)
				{
					RoleInfo config5 = (RoleInfo)config;
					this.Icon = config5.Icon;
					this.QualityId = config5.QualityId;
					this.AttributesDescription = config5.AttributesDescription;
					this.RefreshRoleConfig(config5);
					return;
				}
				if (config is BackgroundCard)
				{
					BackgroundCard config6 = (BackgroundCard)config;
					this.Icon = config6.Icon;
					this.QualityId = config6.QualityId;
					this.AttributesDescription = config6.AttributesDescription;
					this.RefreshCardConfig(config6);
					return;
				}
				if (config is PreviewItem)
				{
					PreviewItem config7 = (PreviewItem)config;
					this.Icon = config7.Icon;
					this.QualityId = config7.QualityId;
					this.AttributesDescription = config7.AttributesDescription;
					this.RefreshPreviewItem(config7);
					return;
				}
				if (config is RogueCurrency)
				{
					RogueCurrency config8 = (RogueCurrency)config;
					this.Icon = config8.Icon;
					this.QualityId = config8.QualityId;
					this.AttributesDescription = config8.AttributesDescription;
					this.RefreshRogueCurrency(config8);
					return;
				}
				if (config is RogueResCurrency)
				{
					RogueResCurrency config9 = (RogueResCurrency)config;
					this.Icon = config9.Icon;
					this.QualityId = config9.QualityId;
					this.AttributesDescription = config9.AttributesDescription;
					this.RefreshRogueResCurrency(config9);
					return;
				}
				if (config is RoleSkin)
				{
					RoleSkin config10 = (RoleSkin)config;
					this.Icon = config10.Icon;
					this.QualityId = config10.QualityId;
					this.AttributesDescription = config10.AttributesDescription;
					this.RefreshRoleSkinConfig(config10);
					return;
				}
				if (config is WeaponSkin)
				{
					WeaponSkin config11 = (WeaponSkin)config;
					this.Icon = config11.Icon;
					this.QualityId = config11.QualityId;
					this.AttributesDescription = config11.AttributesDescription;
					this.RefreshWeaponSkinConfig(config11);
					return;
				}
				if (config is FlySkinConfig)
				{
					FlySkinConfig config12 = (FlySkinConfig)config;
					this.Icon = config12.Icon;
					this.QualityId = config12.QualityId;
					this.AttributesDescription = config12.AttributesDescription;
					this.RefreshFlySkinConfig(config12);
					return;
				}
				if (config is PlayerHeadRe)
				{
					PlayerHeadRe config13 = (PlayerHeadRe)config;
					this.Icon = config13.Icon;
					this.QualityId = config13.QualityId;
					this.AttributesDescription = config13.AttributesDescription;
					this.RefreshPlayerHeadConfig(config13);
					return;
				}
				if (config is AbyssItem)
				{
					AbyssItem config14 = (AbyssItem)config;
					this.Icon = config14.Icon;
					this.QualityId = config14.QualityId;
					this.AttributesDescription = config14.AttributesDescription;
					this.RefreshAbyssItemConfig(config14);
					return;
				}
				if (config is PhantomBattleCard)
				{
					PhantomBattleCard config15 = (PhantomBattleCard)config;
					this.Icon = config15.Icon;
					this.QualityId = config15.QualityId;
					this.AttributesDescription = config15.AttributesDescription;
					this.RefreshPhantomArenaCardConfig(config15);
					return;
				}
				if (config is PhantomBattleBadge)
				{
					PhantomBattleBadge config16 = (PhantomBattleBadge)config;
					this.Icon = config16.Icon;
					this.QualityId = config16.QualityId;
					this.AttributesDescription = config16.AttributesDescription;
					this.RefreshPhantomArenaBadgeConfig(config16);
					return;
				}
				if (config is HonamiStoryItem)
				{
					HonamiStoryItem config17 = (HonamiStoryItem)config;
					this.Icon = config17.Icon;
					this.QualityId = config17.QualityId;
					this.AttributesDescription = config17.AttributesDescription;
					this.RefreshHonamiStoryItemConfig(config17);
					return;
				}
				if (config is HonamiStoryWeapon)
				{
					HonamiStoryWeapon config18 = (HonamiStoryWeapon)config;
					this.Icon = config18.Icon;
					this.QualityId = config18.QualityId;
					this.AttributesDescription = config18.AttributesDescription;
					this.RefreshHonamiStoryWeaponConfig(config18);
					return;
				}
				if (config is CalabashSkin)
				{
					CalabashSkin config19 = (CalabashSkin)config;
					this.Icon = config19.Icon;
					this.QualityId = config19.QualityId;
					this.AttributesDescription = config19.AttributesDescription;
					this.RefreshCalabashSkinConfig(config19);
					return;
				}
				if (config is MotorFrame)
				{
					MotorFrame config20 = (MotorFrame)config;
					this.Icon = config20.Icon;
					this.QualityId = config20.QualityId;
					this.AttributesDescription = config20.AttributesDescription;
					this.RefreshMotorFrameConfig(config20);
					return;
				}
				if (config is MotorSticker)
				{
					MotorSticker config21 = (MotorSticker)config;
					this.Icon = config21.Icon;
					this.QualityId = config21.QualityId;
					this.AttributesDescription = config21.AttributesDescription;
					this.RefreshMotorStickerConfig(config21);
					return;
				}
				if (config is MotorDecorations)
				{
					MotorDecorations config22 = (MotorDecorations)config;
					this.Icon = config22.Icon;
					this.QualityId = config22.QualityId;
					this.AttributesDescription = config22.AttributesDescription;
					this.RefreshMotorDecorationConfig(config22);
					return;
				}
				if (config is MotorSkin)
				{
					MotorSkin config23 = (MotorSkin)config;
					this.Icon = config23.Icon;
					this.QualityId = config23.QualityId;
					this.AttributesDescription = config23.AttributesDescription;
					this.RefreshMotorSkinConfig(config23);
					return;
				}
				if (config is ChatDialog)
				{
					ChatDialog config24 = (ChatDialog)config;
					this.Icon = config24.Icon;
					this.QualityId = config24.QualityId;
					this.AttributesDescription = config24.AttributesDescription;
					this.RefreshPhoneChatDialogShowConfig(config24);
					return;
				}
				if (config is ChatBg)
				{
					ChatBg config25 = (ChatBg)config;
					this.Icon = config25.Icon;
					this.QualityId = config25.QualityId;
					this.AttributesDescription = config25.AttributesDescription;
					this.RefreshPhoneChatBackGroundConfig(config25);
					return;
				}
				if (config is Furniture)
				{
					Furniture config26 = (Furniture)config;
					this.Icon = config26.Icon;
					this.QualityId = config26.QualityId;
					this.AttributesDescription = config26.AttributesDescription;
					this.RefreshFurnitureConfig(config26);
					return;
				}
				if (config is PinballRoleConfig)
				{
					PinballRoleConfig config27 = (PinballRoleConfig)config;
					this.Icon = config27.Icon;
					this.QualityId = config27.QualityId;
					this.AttributesDescription = config27.AttributesDescription;
					this.RefreshPinballRoleConfig(config27);
					return;
				}
				if (config is PinballWeaponConfig)
				{
					PinballWeaponConfig config28 = (PinballWeaponConfig)config;
					this.Icon = config28.Icon;
					this.QualityId = config28.QualityId;
					this.AttributesDescription = config28.AttributesDescription;
					this.RefreshPinballWeaponConfig(config28);
					return;
				}
				if (config is Ornament)
				{
					Ornament config29 = (Ornament)config;
					this.Icon = config29.Icon;
					this.QualityId = config29.QualityId;
					this.AttributesDescription = config29.AttributesDescription;
					this.RefreshOrnamentConfig(config29);
					return;
				}
				if (config is RoverRogueCurrency)
				{
					RoverRogueCurrency config30 = (RoverRogueCurrency)config;
					this.Icon = config30.Icon;
					this.QualityId = config30.QualityId;
					this.AttributesDescription = config30.AttributesDescription;
					this.RefreshRoverRogueCurrency(config30);
				}
				return;
			}
		}

		// Token: 0x0603B3B4 RID: 242612 RVA: 0x00EFE288 File Offset: 0x00EFC488
		private unsafe void RefreshItemConfig(ItemInfo config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.CommonItem;
			this.ItemType = new InventoryDefine.EItemType?((InventoryDefine.EItemType)config.ItemType);
			this.MainTypeId = (InventoryDefine.EItemMainTypeId)config.MainTypeId;
			this.Name = config.Name;
			this.ItemBuffType = config.ItemBuffType;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			int num = *config.GetShowTypesBytes()[0];
			if (num != 0)
			{
				ItemShowType? itemShowTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemShowTypeConfig(num);
				if (itemShowTypeConfig != null)
				{
					this.TypeDescription = itemShowTypeConfig.Value.Name;
				}
			}
			else
			{
				this.TypeDescription = null;
			}
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = config.Mesh;
			this.ItemAccess = config.GetItemAccessArray();
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.Parameters.Clear();
			int parametersLength = config.ParametersLength;
			for (int i = 0; i < parametersLength; i++)
			{
				DicIntInt? dicIntInt = config.Parameters(i);
				this.Parameters[dicIntInt.Value.Key] = dicIntInt.Value.Value;
			}
			this.SortIndex = config.SortIndex;
			this.ShowTypes = config.GetShowTypesArray();
			this.ExpiredConvertItemMap = config.ConvertItems();
		}

		// Token: 0x0603B3B5 RID: 242613 RVA: 0x00EFE408 File Offset: 0x00EFC608
		private void RefreshPhantomConfig(PhantomItem config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PhantomItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.Phantom);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Phantom;
			this.Name = config.MonsterName;
			this.TypeDescription = config.TypeDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = config.Mesh;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ItemBuffType = 0;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.IconBig = config.IconBig;
		}

		// Token: 0x0603B3B6 RID: 242614 RVA: 0x00EFE4D4 File Offset: 0x00EFC6D4
		private void RefreshRogueCurrency(RogueCurrency config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.RogueCurrency;
			this.QualityId = config.QualityId;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.RogueCurrency);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ItemBuffType = 0;
			this.Name = config.Title;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3B7 RID: 242615 RVA: 0x00EFE5A0 File Offset: 0x00EFC7A0
		private void RefreshRogueResCurrency(RogueResCurrency config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.RogueResCurrency;
			this.QualityId = config.QualityId;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.RogueCurrency);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ItemBuffType = 0;
			this.Name = config.Title;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3B8 RID: 242616 RVA: 0x00EFE66C File Offset: 0x00EFC86C
		private void RefreshWeaponConfig(WeaponConf config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.WeaponItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.Weapon);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Weapon;
			this.Name = config.WeaponName;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = config.Mesh;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ItemBuffType = 0;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.IconBig = config.IconBig;
		}

		// Token: 0x0603B3B9 RID: 242617 RVA: 0x00EFE744 File Offset: 0x00EFC944
		private void RefreshFlySkinConfig(FlySkinConfig config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.FlySkinItem;
			this.QualityId = config.QualityId;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.FlySkin);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = config.Mesh;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3BA RID: 242618 RVA: 0x00EFE814 File Offset: 0x00EFCA14
		private void RefreshWeaponSkinConfig(WeaponSkin config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.WeaponSkinItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.WeaponSkin);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = config.Mesh;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3BB RID: 242619 RVA: 0x00EFE8D8 File Offset: 0x00EFCAD8
		private void RefreshPlayerHeadConfig(PlayerHeadRe config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PlayerHeadItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PlayerHead);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3BC RID: 242620 RVA: 0x00EFE990 File Offset: 0x00EFCB90
		private void RefreshRoleSkinConfig(RoleSkin config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.RoleSkinItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.RoleSkin);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3BD RID: 242621 RVA: 0x00EFEA48 File Offset: 0x00EFCC48
		private void RefreshAbyssItemConfig(AbyssItem config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.DangoAbyssItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.AbyssItem);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = null;
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ShowInBag = true;
			this.ObtainedShowDescription = "";
			this.AttributesDescription = config.AttributesDescription;
			AbyssQuality? abyssQualityById = ConfigBase<DangoAbyssConfig>.Instance.GetAbyssQualityById(config.QualityId);
			this.Mesh = (((abyssQualityById != null) ? abyssQualityById.GetValueOrDefault().Mesh : null) ?? "");
		}

		// Token: 0x0603B3BE RID: 242622 RVA: 0x00EFEB30 File Offset: 0x00EFCD30
		private void RefreshRoleConfig(RoleInfo config)
		{
			SModelConfig modelConfig = ModelUtil.GetModelConfig(config.MeshId);
			this.ItemDataType = InventoryDefine.EItemDataType.RoleItem;
			this.ItemType = null;
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = null;
			this.BgDescription = null;
			this.IconMiddle = config.RoleHeadIconBig;
			this.IconSmall = config.RoleHeadIcon;
			this.Icon = config.RoleHeadIconLarge;
			this.Mesh = ((modelConfig != null) ? modelConfig.网格体.ToAssetPathName() : null);
			this.ItemAccess = null;
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ItemBuffType = 0;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3BF RID: 242623 RVA: 0x00EFEC04 File Offset: 0x00EFCE04
		private void RefreshCardConfig(BackgroundCard config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.CardItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.Card);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Card;
			this.Name = config.Title;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = null;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ItemBuffType = 0;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3C0 RID: 242624 RVA: 0x00EFECC4 File Offset: 0x00EFCEC4
		private void RefreshPreviewItem(PreviewItem config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PreviewItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.Phantom);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Phantom;
			this.Name = config.Name;
			int num = config.ShowTypes(0);
			if (num != 0)
			{
				ItemShowType? itemShowTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemShowTypeConfig(num);
				if (itemShowTypeConfig != null)
				{
					this.TypeDescription = itemShowTypeConfig.Value.Name;
				}
			}
			else
			{
				this.TypeDescription = null;
			}
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = null;
			this.ItemAccess = config.GetPreviewItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ItemBuffType = 0;
			this.ShowTypes = config.GetShowTypesArray();
			this.IconBig = config.IconBig;
		}

		// Token: 0x0603B3C1 RID: 242625 RVA: 0x00EFEDB0 File Offset: 0x00EFCFB0
		private void RefreshPhantomArenaCardConfig(PhantomBattleCard config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PhantomArenaCard;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PhantomArenaCard);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = null;
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = "";
			this.AttributesDescription = config.AttributesDescription;
		}

		// Token: 0x0603B3C2 RID: 242626 RVA: 0x00EFEE64 File Offset: 0x00EFD064
		private void RefreshPhantomArenaBadgeConfig(PhantomBattleBadge config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PhantomArenaBadge;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PhantomArenaBadge);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = null;
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = "";
			this.AttributesDescription = config.AttributesDescription;
		}

		// Token: 0x0603B3C3 RID: 242627 RVA: 0x00EFEF18 File Offset: 0x00EFD118
		private void RefreshHonamiStoryItemConfig(HonamiStoryItem config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.HonamiStoryItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.HonamiStoryItem);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = null;
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ShowInBag = true;
			this.ObtainedShowDescription = "";
			this.AttributesDescription = config.AttributesDescription;
			this.Mesh = config.Mesh;
		}

		// Token: 0x0603B3C4 RID: 242628 RVA: 0x00EFEFD0 File Offset: 0x00EFD1D0
		private void RefreshHonamiStoryWeaponConfig(HonamiStoryWeapon config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.HonamiStoryWeapon;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.HonamiStoryWeapon);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			int attributesDescriptionArgsLength = config.AttributesDescriptionArgsLength;
			string[] array = new string[attributesDescriptionArgsLength];
			for (int i = 0; i < attributesDescriptionArgsLength; i++)
			{
				array[i] = config.AttributesDescriptionArgs(i);
			}
			this.AttributesDescriptionArgs = array;
			this.TypeDescription = config.TypeDescription;
		}

		// Token: 0x0603B3C5 RID: 242629 RVA: 0x00EFF040 File Offset: 0x00EFD240
		private void RefreshCalabashSkinConfig(CalabashSkin config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.CalabashSkinItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.CalabashSkin);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = null;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = config.SortIndex;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0603B3C6 RID: 242630 RVA: 0x00EFF100 File Offset: 0x00EFD300
		private unsafe void RefreshInfrastructureItemConfig(ItemInfo config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.InfrastructureItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.InfrastructureItem);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			int num = *config.GetShowTypesBytes()[0];
			if (num != 0)
			{
				ItemShowType? itemShowTypeConfig = ConfigBase<InventoryConfig>.Instance.GetItemShowTypeConfig(num);
				if (itemShowTypeConfig != null)
				{
					this.TypeDescription = itemShowTypeConfig.Value.Name;
				}
			}
			else
			{
				this.TypeDescription = null;
			}
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.Mesh = null;
		}

		// Token: 0x0603B3C7 RID: 242631 RVA: 0x00EFF1B0 File Offset: 0x00EFD3B0
		private void RefreshMotorFrameConfig(MotorFrame config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.MotorFrameItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.MotorFrame);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Title;
			this.TypeDescription = config.TypeDescription;
			this.Icon = config.Icon;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.Mesh = null;
			this.IconBig = config.IconBig;
		}

		// Token: 0x0603B3C8 RID: 242632 RVA: 0x00EFF258 File Offset: 0x00EFD458
		private void RefreshMotorStickerConfig(MotorSticker config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.MotorStickerItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.MotorSticker);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Title;
			this.TypeDescription = config.TypeDescription;
			this.Icon = config.Icon;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.Mesh = null;
		}

		// Token: 0x0603B3C9 RID: 242633 RVA: 0x00EFF2F0 File Offset: 0x00EFD4F0
		private void RefreshMotorDecorationConfig(MotorDecorations config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.MotorDecorationItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.MotorDecoration);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Title;
			this.TypeDescription = config.TypeDescription;
			this.Icon = config.Icon;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.Mesh = null;
		}

		// Token: 0x0603B3CA RID: 242634 RVA: 0x00EFF388 File Offset: 0x00EFD588
		private void RefreshMotorSkinConfig(MotorSkin config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.MotorSkinItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.MotorSkin);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.Icon = config.Icon;
			this.IconBig = config.IconBig;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.Mesh = null;
		}

		// Token: 0x0603B3CB RID: 242635 RVA: 0x00EFF430 File Offset: 0x00EFD630
		private void RefreshPhoneChatDialogShowConfig(ChatDialog config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PhoneChatDialog;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PhoneChatDialog);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.PreviewType = ESkipName.SkipToPhoneMsgSetting;
			this.Name = config.Name;
			this.Icon = config.Icon;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.TypeDescription = config.TypeDescription;
			this.AttributesDescription = config.AttributesDescription;
			this.BgDescription = config.BgDescription;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ShowInBag = true;
			this.ObtainedShowDescription = "";
			this.ShowPreview = true;
		}

		// Token: 0x0603B3CC RID: 242636 RVA: 0x00EFF500 File Offset: 0x00EFD700
		private void RefreshPhoneChatBackGroundConfig(ChatBg config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PhoneChatBackGround;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PhoneChatBackGround);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.PreviewType = ESkipName.SkipToPhoneMsgSetting;
			this.Name = config.Name;
			this.Icon = config.Icon;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.TypeDescription = config.TypeDescription;
			this.AttributesDescription = config.AttributesDescription;
			this.BgDescription = config.BgDescription;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ShowInBag = true;
			this.ObtainedShowDescription = "";
			this.ShowPreview = true;
		}

		// Token: 0x0603B3CD RID: 242637 RVA: 0x00EFF5D0 File Offset: 0x00EFD7D0
		private void RefreshFurnitureConfig(Furniture config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.FurnitureItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.Furniture);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
			this.Icon = config.Icon;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.Icon;
			this.Mesh = null;
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.ItemBuffType = 0;
			this.ShowInBag = false;
		}

		// Token: 0x0603B3CE RID: 242638 RVA: 0x00EFF658 File Offset: 0x00EFD858
		private void RefreshPinballRoleConfig(PinballRoleConfig config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PinballRoleItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PinballRole);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			RoleInfo? roleInfo;
			this.Name = (((ConfigBase<RoleConfig>.Instance.GetRoleConfig(config.RoleId) != null) ? roleInfo.GetValueOrDefault().Name : null) ?? "");
		}

		// Token: 0x0603B3CF RID: 242639 RVA: 0x00EFF6BD File Offset: 0x00EFD8BD
		private void RefreshPinballWeaponConfig(PinballWeaponConfig config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.PinballWeaponItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.PinballWeapon);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.Name = config.Name;
		}

		// Token: 0x0603B3D0 RID: 242640 RVA: 0x00EFF6E8 File Offset: 0x00EFD8E8
		private void RefreshOrnamentConfig(Ornament config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.OrnamentItem;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.Ornament);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.PreviewType = ESkipName.SkipToRoleOrnamentId;
			this.Name = config.Name;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = (InventoryDefine.ERedDotDisableRule)config.RedDotDisableRule;
			this.ShowInBag = config.ShowInBag;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
			this.ShowPreview = true;
		}

		// Token: 0x0603B3D1 RID: 242641 RVA: 0x00EFF7A8 File Offset: 0x00EFD9A8
		private void RefreshRoverRogueCurrency(RoverRogueCurrency config)
		{
			this.ItemDataType = InventoryDefine.EItemDataType.RoverRogueCurrency;
			this.QualityId = config.QualityId;
			this.ItemType = new InventoryDefine.EItemType?(InventoryDefine.EItemType.RogueCurrency);
			this.MainTypeId = InventoryDefine.EItemMainTypeId.Common;
			this.TypeDescription = config.TypeDescription;
			this.BgDescription = config.BgDescription;
			this.IconMiddle = config.IconMiddle;
			this.IconSmall = config.IconSmall;
			this.ItemAccess = config.GetItemAccessArray();
			this.Parameters.Clear();
			this.SortIndex = 0;
			this.RedDotDisableRule = InventoryDefine.ERedDotDisableRule.None;
			this.ItemBuffType = 0;
			this.Name = config.Title;
			this.ShowInBag = false;
			this.ObtainedShowDescription = config.ObtainedShowDescription;
		}

		// Token: 0x0402165D RID: 136797
		public int Id;

		// Token: 0x0402165E RID: 136798
		public InventoryDefine.EItemDataType ItemDataType;

		// Token: 0x0402165F RID: 136799
		public InventoryDefine.EItemType? ItemType;

		// Token: 0x04021660 RID: 136800
		public InventoryDefine.EItemMainTypeId MainTypeId = InventoryDefine.EItemMainTypeId.Common;

		// Token: 0x04021661 RID: 136801
		public string Name = "";

		// Token: 0x04021662 RID: 136802
		[Nullable(2)]
		public string TypeDescription;

		// Token: 0x04021663 RID: 136803
		public string AttributesDescription = "";

		// Token: 0x04021664 RID: 136804
		public string[] AttributesDescriptionArgs = Array.Empty<string>();

		// Token: 0x04021665 RID: 136805
		public string ObtainedShowDescription = "";

		// Token: 0x04021666 RID: 136806
		[Nullable(2)]
		public string BgDescription;

		// Token: 0x04021667 RID: 136807
		public bool ShowInBag;

		// Token: 0x04021668 RID: 136808
		public string Icon = "";

		// Token: 0x04021669 RID: 136809
		[Nullable(2)]
		public string IconBig;

		// Token: 0x0402166A RID: 136810
		[Nullable(2)]
		public string IconMiddle;

		// Token: 0x0402166B RID: 136811
		[Nullable(2)]
		public string IconSmall;

		// Token: 0x0402166C RID: 136812
		[Nullable(2)]
		public string Mesh;

		// Token: 0x0402166D RID: 136813
		public int QualityId;

		// Token: 0x0402166E RID: 136814
		[Nullable(2)]
		public int[] ItemAccess = Array.Empty<int>();

		// Token: 0x0402166F RID: 136815
		public int SortIndex;

		// Token: 0x04021670 RID: 136816
		public InventoryDefine.ERedDotDisableRule RedDotDisableRule;

		// Token: 0x04021671 RID: 136817
		public Dictionary<int, int> Parameters = new Dictionary<int, int>();

		// Token: 0x04021672 RID: 136818
		public Dictionary<int, int> ExpiredConvertItemMap = new Dictionary<int, int>();

		// Token: 0x04021673 RID: 136819
		public int ItemBuffType;

		// Token: 0x04021674 RID: 136820
		public int[] ShowTypes = Array.Empty<int>();

		// Token: 0x04021675 RID: 136821
		public ESkipName PreviewType = ESkipName.NoSkip;

		// Token: 0x04021676 RID: 136822
		public bool ShowPreview;
	}
}
