using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.Skin;
using UnrealEngine;

// Token: 0x02001A3E RID: 6718
[NullableContext(1)]
[Nullable(0)]
public class SmallItemGridSkinComponent : SmallItemGridComponent
{
	// Token: 0x0600C05B RID: 49243 RVA: 0x0032CD3F File Offset: 0x0032AF3F
	[NullableContext(2)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemBSkin";
	}

	// Token: 0x0600C05C RID: 49244 RVA: 0x0032CD48 File Offset: 0x0032AF48
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600C05D RID: 49245 RVA: 0x0032CE38 File Offset: 0x0032B038
	[NullableContext(2)]
	protected override void OnRefresh(object tempData)
	{
		ISmallItemGridSkinComponentParams param = (ISmallItemGridSkinComponentParams)tempData;
		this.SetActive(true);
		this.RefreshTexture(param);
		this.RefreshQualitySprite(param);
		this.RefreshWeaponIcon(param);
		this.RefreshNum(param);
	}

	// Token: 0x0600C05E RID: 49246 RVA: 0x0032CE70 File Offset: 0x0032B070
	private void RefreshTexture(ISmallItemGridSkinComponentParams param)
	{
		string texturePath = this.GetTexturePath(param);
		if (StringUtils.IsEmpty(texturePath))
		{
			base.GetTexture(1).SetUIActive(false);
			return;
		}
		base.GetTexture(1).SetUIActive(true);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(texturePath);
		base.SetTextureByPath(resourcePath, base.GetTexture(1), null, null);
	}

	// Token: 0x0600C05F RID: 49247 RVA: 0x0032CECC File Offset: 0x0032B0CC
	private void RefreshQualitySprite(ISmallItemGridSkinComponentParams param)
	{
		string qualitySpritePath = this.GetQualitySpritePath(param);
		this.SetSpriteByPath(qualitySpritePath, base.GetSprite(0), false, null, null);
	}

	// Token: 0x0600C060 RID: 49248 RVA: 0x0032CEFC File Offset: 0x0032B0FC
	private string GetQualitySpritePath(ISmallItemGridSkinComponentParams param)
	{
		int? qualityId = param.QualityId;
		if (qualityId == null)
		{
			int? skinId = param.SkinId;
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(skinId.Value);
			if (itemConfigData == null)
			{
				return "";
			}
			qualityId = new int?(itemConfigData.QualityId);
		}
		return ConfigBase<CommonConfig>.Instance.GetItemQualityById(qualityId.Value).Value.SkinItemBg;
	}

	// Token: 0x0600C061 RID: 49249 RVA: 0x0032CF6C File Offset: 0x0032B16C
	private string GetTexturePath(ISmallItemGridSkinComponentParams param)
	{
		int? skinId = param.SkinId;
		if (skinId == null)
		{
			return "";
		}
		InventoryDefine.EItemDataType itemDataTypeByConfigId = ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(skinId.Value));
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.WeaponSkinItem)
		{
			return "T_IconFilterSkin3";
		}
		if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.RoleSkinItem)
		{
			if (ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(skinId.Value).GetSuitWeaponSkinId() > 0)
			{
				return "T_IconFilterSkin1";
			}
			return "T_IconFilterSkin2";
		}
		else
		{
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.FlySkinItem)
			{
				FlySkinConfig? flySkinConfig = ConfigBase<SkinConfig>.Instance.GetFlySkinConfig(skinId.Value);
				return ConfigBase<SkinConfig>.Instance.GetFlySkinBottomIconResourceId((EFlySkinType)flySkinConfig.Value.SkinType);
			}
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.CalabashSkinItem)
			{
				return "T_IconFilterSkin6";
			}
			if (itemDataTypeByConfigId == InventoryDefine.EItemDataType.OrnamentItem)
			{
				return "T_IconFilterSkin7";
			}
			return "";
		}
	}

	// Token: 0x0600C062 RID: 49250 RVA: 0x0032D028 File Offset: 0x0032B228
	private void RefreshWeaponIcon(ISmallItemGridSkinComponentParams param)
	{
		int? skinId = param.SkinId;
		if (skinId == null)
		{
			base.GetItem(2).SetUIActive(false);
			return;
		}
		int itemDataTypeByConfigId = (int)ConfigBase<InventoryConfig>.Instance.GetItemDataTypeByConfigId(new int?(skinId.Value));
		bool flag = false;
		if (itemDataTypeByConfigId == 11 && ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(skinId.Value).GetSuitWeaponSkinId() > 0)
		{
			flag = true;
		}
		base.GetItem(2).SetUIActive(flag);
		if (flag)
		{
			string payShopPreviewBuyRoleSuitWeaponTexturePath = ModelBase<RoleSkinModel>.Instance.GetRoleSkinData(skinId.Value).GetPayShopPreviewBuyRoleSuitWeaponTexturePath();
			base.SetTextureByPath(payShopPreviewBuyRoleSuitWeaponTexturePath, base.GetTexture(3), null, null);
		}
	}

	// Token: 0x0600C063 RID: 49251 RVA: 0x0032D0CC File Offset: 0x0032B2CC
	private void RefreshNum(ISmallItemGridSkinComponentParams param)
	{
		string bottomText = param.BottomText;
		bool flag = !StringUtils.IsEmpty(bottomText);
		base.GetItem(4).SetUIActive(flag);
		if (flag)
		{
			base.GetText(5).SetText(bottomText, true);
		}
	}

	// Token: 0x0600C064 RID: 49252 RVA: 0x0032D108 File Offset: 0x0032B308
	public override EItemGridComponentLayoutLevel GetLayoutLevel()
	{
		return EItemGridComponentLayoutLevel.Bottom;
	}

	// Token: 0x02007D05 RID: 32005
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402AA25 RID: 174629
		QualitySprite,
		// Token: 0x0402AA26 RID: 174630
		Texture,
		// Token: 0x0402AA27 RID: 174631
		WeaponItem,
		// Token: 0x0402AA28 RID: 174632
		WeaponTexture,
		// Token: 0x0402AA29 RID: 174633
		NumItem,
		// Token: 0x0402AA2A RID: 174634
		NumText
	}
}
