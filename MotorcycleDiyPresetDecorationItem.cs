using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022D2 RID: 8914
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyPresetDecorationItem : GridProxyAbstract<MotorcycleDiyEditStickerDecoItemData>
{
	// Token: 0x06010DE9 RID: 69097 RVA: 0x0049EB18 File Offset: 0x0049CD18
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

	// Token: 0x06010DEA RID: 69098 RVA: 0x0049EBF0 File Offset: 0x0049CDF0
	public void SetEnableClick(bool isEnable)
	{
		EToggleState state = isEnable ? EToggleState.ETT_UnChecked : EToggleState.ETT_UnDetermined;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010DEB RID: 69099 RVA: 0x0049EC18 File Offset: 0x0049CE18
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
		MotorDecorationsPart? motorDecorationPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationPartConfig(data.Part);
		if (motorDecorationPartConfig == null)
		{
			return;
		}
		base.SetTextureByPath(motorDecorationPartConfig.Value.Icon, texture2, null, null);
		if (data.ItemId <= 0)
		{
			item2.SetUIActive(true);
			return;
		}
		MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(data.ItemId);
		if (motorDecorationConfig == null)
		{
			return;
		}
		int qualityId = motorDecorationConfig.Value.QualityId;
		MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(qualityId);
		if (motorQualityConfig == null)
		{
			return;
		}
		texture.SetUIActive(true);
		sprite.SetUIActive(true);
		this.SetSpriteByPath(motorQualityConfig.Value.Path, sprite, false, null, null);
		base.SetTextureByPath(motorDecorationConfig.Value.Icon, texture, null, null);
	}

	// Token: 0x06010DEC RID: 69100 RVA: 0x0049ED84 File Offset: 0x0049CF84
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

	// Token: 0x040084ED RID: 34029
	[Nullable(2)]
	private MotorcycleDiyEditStickerDecoItemData Data;

	// Token: 0x040084EE RID: 34030
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<MotorcycleDiyEditStickerDecoItemData> OnClickToggleBack;

	// Token: 0x020085AD RID: 34221
	private class EDecorationItemComponent
	{
		// Token: 0x0402D3A1 RID: 185249
		public const int TogItem = 0;

		// Token: 0x0402D3A2 RID: 185250
		public const int TexIcon = 1;

		// Token: 0x0402D3A3 RID: 185251
		public const int EmptyItem = 2;

		// Token: 0x0402D3A4 RID: 185252
		public const int TexIconPart = 3;

		// Token: 0x0402D3A5 RID: 185253
		public const int NoneItem = 4;

		// Token: 0x0402D3A6 RID: 185254
		public const int SprQuality = 5;

		// Token: 0x0402D3A7 RID: 185255
		public const int ChangeTagItem = 6;
	}
}
