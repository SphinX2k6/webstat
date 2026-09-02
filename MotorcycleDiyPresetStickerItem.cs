using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022D5 RID: 8917
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyPresetStickerItem : GridProxyAbstract<MotorcycleDiyEditStickerDecoItemData>
{
	// Token: 0x06010DFA RID: 69114 RVA: 0x0049F170 File Offset: 0x0049D370
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x06010DFB RID: 69115 RVA: 0x0049F248 File Offset: 0x0049D448
	public void SetEnableClick(bool isEnable)
	{
		EToggleState state = isEnable ? EToggleState.ETT_UnChecked : EToggleState.ETT_UnDetermined;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010DFC RID: 69116 RVA: 0x0049F270 File Offset: 0x0049D470
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiyEditStickerDecoItemData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		UUIExtendToggle extendToggle = base.GetExtendToggle(0);
		UUITexture texture = base.GetTexture(1);
		UUITexture texture2 = base.GetTexture(3);
		UUIItem item = base.GetItem(2);
		UUIItem item2 = base.GetItem(4);
		UUISprite sprite = base.GetSprite(5);
		UUIItem item3 = base.GetItem(6);
		extendToggle.SetToggleState(EToggleState.ETT_UnDetermined, false, false, false);
		texture.SetUIActive(false);
		item.SetUIActive(false);
		item2.SetUIActive(false);
		sprite.SetUIActive(false);
		item3.SetUIActive(data.HasChange);
		MotorStickerPart? motorStickerPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerPartConfig(data.Part);
		if (motorStickerPartConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorStickerPartConfig.Value.Icon, texture2, null, null);
		if (data.ItemId <= 0)
		{
			item2.SetUIActive(true);
			return;
		}
		MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(data.ItemId);
		if (motorStickerConfig == null)
		{
			return;
		}
		int qualityId = motorStickerConfig.Value.QualityId;
		MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(qualityId);
		if (motorQualityConfig == null)
		{
			return;
		}
		texture.SetUIActive(true);
		sprite.SetUIActive(true);
		this.SetSpriteByPath(motorQualityConfig.Value.Path, sprite, false, null, null);
		base.SetTextureByPath(motorStickerConfig.Value.StickerIconPath, texture, null, null);
	}

	// Token: 0x06010DFD RID: 69117 RVA: 0x0049F3DC File Offset: 0x0049D5DC
	private void OnClickItem(EToggleState state)
	{
		if (this.Data == null)
		{
			return;
		}
		Action<MotorcycleDiyEditStickerDecoItemData> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Data);
	}

	// Token: 0x040084F3 RID: 34035
	[Nullable(2)]
	private MotorcycleDiyEditStickerDecoItemData Data;

	// Token: 0x040084F4 RID: 34036
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleDiyEditStickerDecoItemData> OnClickToggleBack;

	// Token: 0x020085B1 RID: 34225
	private class EStickerItemComponent
	{
		// Token: 0x0402D3B0 RID: 185264
		public const int TogItem = 0;

		// Token: 0x0402D3B1 RID: 185265
		public const int TexIcon = 1;

		// Token: 0x0402D3B2 RID: 185266
		public const int EmptyItem = 2;

		// Token: 0x0402D3B3 RID: 185267
		public const int TexIconPart = 3;

		// Token: 0x0402D3B4 RID: 185268
		public const int NoneItem = 4;

		// Token: 0x0402D3B5 RID: 185269
		public const int SprQuality = 5;

		// Token: 0x0402D3B6 RID: 185270
		public const int ChangeTagItem = 6;
	}
}
