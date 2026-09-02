using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001192 RID: 4498
public class AdvanceNoticeNewRoleDetailItem : UiPanelBase
{
	// Token: 0x0600764E RID: 30286 RVA: 0x001EF4B4 File Offset: 0x001ED6B4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem))
		};
	}

	// Token: 0x0600764F RID: 30287 RVA: 0x001EF57C File Offset: 0x001ED77C
	protected override void OnStart()
	{
		this.StarLayout = new SimpleGenericLayout(base.GetHorizontalLayout(2));
		base.GetItem(1).SetUIActive(false);
	}

	// Token: 0x06007650 RID: 30288 RVA: 0x001EF5A0 File Offset: 0x001ED7A0
	public void Refresh(int subTabId)
	{
		AdvertisingTabCharacter advertisingTabCharacterById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabCharacterById(subTabId);
		if (advertisingTabCharacterById.Type == 1)
		{
			this.RefreshRoleItem(advertisingTabCharacterById);
			return;
		}
		this.RefreshWeaponItem(advertisingTabCharacterById);
	}

	// Token: 0x06007651 RID: 30289 RVA: 0x001EF5D4 File Offset: 0x001ED7D4
	private void RefreshRoleItem(AdvertisingTabCharacter config)
	{
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(true);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(false);
		}
		base.GetText(0).ShowTextNew(config.NameText);
		UUITexture texture2 = base.GetTexture(3);
		UUISprite sprite2 = base.GetSprite(4);
		base.SetTextureByPath(config.ElementIconPath, texture2, null, null);
		this.SetSpriteByPath(config.ElementBgIconPath, sprite2, false, null, null);
		this.UpdateQuality(config.QualityId);
	}

	// Token: 0x06007652 RID: 30290 RVA: 0x001EF668 File Offset: 0x001ED868
	private void RefreshWeaponItem(AdvertisingTabCharacter config)
	{
		UUITexture texture = base.GetTexture(3);
		if (texture != null)
		{
			texture.SetUIActive(false);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(true);
		}
		base.GetText(0).ShowTextNew(config.NameText);
		int qualityId = config.QualityId;
		string resourceId = AdvanceNoticeDefine.starToWeaponGachaBgResourceId[qualityId];
		string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
		this.SetSpriteByPath(resourcePath, base.GetSprite(4), false, null, null);
		this.SetSpriteByPath(config.WeaponTypeIconPath, base.GetSprite(5), false, null, null);
		this.UpdateQuality(qualityId);
	}

	// Token: 0x06007653 RID: 30291 RVA: 0x001EF70D File Offset: 0x001ED90D
	private void UpdateQuality(int quality)
	{
		this.StarLayout.RebuildLayout(quality);
	}

	// Token: 0x04003946 RID: 14662
	[Nullable(2)]
	private SimpleGenericLayout StarLayout;

	// Token: 0x020074EC RID: 29932
	private class EComponent
	{
		// Token: 0x040285DB RID: 165339
		public const int NameText = 0;

		// Token: 0x040285DC RID: 165340
		public const int UpItem = 1;

		// Token: 0x040285DD RID: 165341
		public const int StarLayout = 2;

		// Token: 0x040285DE RID: 165342
		public const int IconTexture = 3;

		// Token: 0x040285DF RID: 165343
		public const int IconBgSprite = 4;

		// Token: 0x040285E0 RID: 165344
		public const int IconSprite = 5;

		// Token: 0x040285E1 RID: 165345
		public const int BtnLook = 6;

		// Token: 0x040285E2 RID: 165346
		public const int JumpBtnRoot = 7;
	}
}
