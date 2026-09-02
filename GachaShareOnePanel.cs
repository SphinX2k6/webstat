using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.RoleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001D07 RID: 7431
public class GachaShareOnePanel : UiPanelBase
{
	// Token: 0x0600DA4C RID: 55884 RVA: 0x003AAA10 File Offset: 0x003A8C10
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUITexture)),
			new ValueTuple<int, Type>(6, typeof(UUIText)),
			new ValueTuple<int, Type>(7, typeof(UUISprite))
		};
	}

	// Token: 0x0600DA4D RID: 55885 RVA: 0x003AAAD8 File Offset: 0x003A8CD8
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(1));
		this.Refresh(this.OpenParam as GachaResult);
	}

	// Token: 0x0600DA4E RID: 55886 RVA: 0x003AAB00 File Offset: 0x003A8D00
	[NullableContext(1)]
	public void Refresh(GachaResult gachaResult)
	{
		if (gachaResult == null || gachaResult.Proto_GachaReward == null)
		{
			return;
		}
		int itemId = gachaResult.Proto_GachaReward.ItemId;
		GaChaShare? config = ConfigGaChaShareById.GetConfig(itemId, true);
		if (config == null)
		{
			return;
		}
		base.SetTextureByPath(config.Value.SharePic, base.GetTexture(0), null, null);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(6), config.Value.Desc, Array.Empty<object>());
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(itemId);
		if (itemConfigData == null)
		{
			return;
		}
		this.StarLayout.RebuildLayout(itemConfigData.QualityId);
		base.GetText(3).ShowTextNew(itemConfigData.Name);
		UUITexture texture = base.GetTexture(5);
		UUISprite sprite = base.GetSprite(7);
		InventoryDefine.EItemDataType itemIdType = ConfigBase<GachaConfig>.Instance.GetItemIdType(itemId);
		base.GetItem(4).SetUIActive(itemIdType == InventoryDefine.EItemDataType.WeaponItem);
		texture.SetUIActive(itemIdType == InventoryDefine.EItemDataType.RoleItem);
		sprite.SetUIActive(itemIdType != InventoryDefine.EItemDataType.RoleItem);
		if (itemIdType == InventoryDefine.EItemDataType.RoleItem)
		{
			RoleInfo? roleConfig = ConfigBase<RoleConfig>.Instance.GetRoleConfig(itemId);
			if (roleConfig == null)
			{
				return;
			}
			int elementId = roleConfig.Value.ElementId;
			ElementInfo? elementConfig = ConfigBase<CommonConfig>.Instance.GetElementConfig(elementId);
			if (elementConfig == null)
			{
				return;
			}
			base.SetTextureByPath(elementConfig.Value.Icon, texture, null, null);
			texture.SetColor(FColor.FromHex(elementConfig.Value.ElementColor));
			return;
		}
		else
		{
			WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
			if (weaponConfigByItemId == null)
			{
				return;
			}
			string weaponIconPath = ConfigBase<WeaponConfig>.Instance.GetWeaponIconPath(weaponConfigByItemId.Value.WeaponType);
			if (!string.IsNullOrEmpty(weaponIconPath))
			{
				this.SetSpriteByPath(weaponIconPath, sprite, false, null, null);
			}
			return;
		}
	}

	// Token: 0x04006841 RID: 26689
	[Nullable(2)]
	private SimpleGenericLayout StarLayout;

	// Token: 0x0200807D RID: 32893
	private enum EComponent
	{
		// Token: 0x0402BB4E RID: 179022
		TextureBg,
		// Token: 0x0402BB4F RID: 179023
		StarLayout,
		// Token: 0x0402BB50 RID: 179024
		StarItem,
		// Token: 0x0402BB51 RID: 179025
		TxtName,
		// Token: 0x0402BB52 RID: 179026
		WeaponElementBg,
		// Token: 0x0402BB53 RID: 179027
		TextureElement,
		// Token: 0x0402BB54 RID: 179028
		TxtDesc,
		// Token: 0x0402BB55 RID: 179029
		SpriteWeapon
	}
}
