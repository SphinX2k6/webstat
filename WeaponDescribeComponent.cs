using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001CF7 RID: 7415
public class WeaponDescribeComponent : UiPanelBase
{
	// Token: 0x0600D9B4 RID: 55732 RVA: 0x003A6758 File Offset: 0x003A4958
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600D9B5 RID: 55733 RVA: 0x003A6845 File Offset: 0x003A4A45
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(2));
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(true);
	}

	// Token: 0x0600D9B6 RID: 55734 RVA: 0x003A6880 File Offset: 0x003A4A80
	public void Update(int gachaTextureInfoId, bool isUp = false)
	{
		this.GachaTextureInfoId = gachaTextureInfoId;
		GachaTextureInfo? gachaTextureInfo = ConfigBase<GachaConfig>.Instance.GetGachaTextureInfo(this.GachaTextureInfoId);
		if (gachaTextureInfo == null)
		{
			return;
		}
		int itemId = (gachaTextureInfo.Value.IdArrayLength <= 0) ? this.GachaTextureInfoId : gachaTextureInfo.Value.GetIdArrayArray()[0];
		WeaponConf? weaponConfigByItemId = ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId);
		if (weaponConfigByItemId == null)
		{
			return;
		}
		base.GetText(0).ShowTextNew(weaponConfigByItemId.Value.WeaponName);
		base.GetItem(1).SetUIActive(isUp);
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath("SP_GachaWeaponBg");
		this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
		this.UpdateWeaponIcon(weaponConfigByItemId.Value.WeaponType);
		this.UpdateQuality(weaponConfigByItemId.Value.QualityId);
	}

	// Token: 0x0600D9B7 RID: 55735 RVA: 0x003A6972 File Offset: 0x003A4B72
	private void UpdateQuality(int quality)
	{
		this.StarLayout.RebuildLayout(quality);
	}

	// Token: 0x0600D9B8 RID: 55736 RVA: 0x003A6980 File Offset: 0x003A4B80
	private void UpdateWeaponIcon(int weaponType)
	{
		foreach (Mapping mapping in ConfigBase<MappingConfig>.Instance.GetWeaponConfList())
		{
			if (weaponType == mapping.Value)
			{
				this.SetSpriteByPath(mapping.Icon, base.GetSprite(5), false, null, null);
				break;
			}
		}
	}

	// Token: 0x040067E3 RID: 26595
	private int GachaTextureInfoId;

	// Token: 0x040067E4 RID: 26596
	[Nullable(2)]
	private SimpleGenericLayout StarLayout;

	// Token: 0x02008067 RID: 32871
	private enum EComponent
	{
		// Token: 0x0402BAD6 RID: 178902
		NameText,
		// Token: 0x0402BAD7 RID: 178903
		UpItem,
		// Token: 0x0402BAD8 RID: 178904
		StarLayout,
		// Token: 0x0402BAD9 RID: 178905
		WeaponIconTexture,
		// Token: 0x0402BADA RID: 178906
		WeaponBgSprite,
		// Token: 0x0402BADB RID: 178907
		WeaponIconSprite
	}
}
