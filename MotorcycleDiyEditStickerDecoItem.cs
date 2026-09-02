using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022CF RID: 8911
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyEditStickerDecoItem : GridProxyAbstract<MotorcycleDiyEditStickerDecoItemData>
{
	// Token: 0x06010DD4 RID: 69076 RVA: 0x0049DE00 File Offset: 0x0049C000
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x06010DD5 RID: 69077 RVA: 0x0049DF04 File Offset: 0x0049C104
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiyEditStickerDecoItemData data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		this.Data = data;
		UUISprite sprite = base.GetSprite(1);
		UUIItem item = base.GetItem(2);
		UUITexture texture = base.GetTexture(3);
		UUIItem item2 = base.GetItem(4);
		UUIItem item3 = base.GetItem(5);
		UUIItem item4 = base.GetItem(6);
		UUIItem item5 = base.GetItem(7);
		UUIItem item6 = base.GetItem(8);
		sprite.SetUIActive(false);
		item.SetUIActive(false);
		texture.SetUIActive(false);
		item2.SetUIActive(false);
		item5.SetUIActive(false);
		item6.SetUIActive(false);
		item3.SetUIActive(false);
		bool flag = (data.IsSticker ? ModelBase<MotorcycleDiyModel>.Instance.GetSelectedStickerId(data.Part) : ModelBase<MotorcycleDiyModel>.Instance.GetSelectedDecorationId(data.Part)) == data.ItemId;
		item4.SetUIActive(flag);
		if (data.ItemId <= 0)
		{
			string path = data.IsSticker ? ConfigCommonParamById.GetStringConfig("MotorEmptyStickerIcon") : ConfigCommonParamById.GetStringConfig("MotorEmptyDecorationIcon");
			item.SetUIActive(true);
			base.SetTextureByPath(path, texture, null, null);
			item3.SetUIActive(false);
		}
		else
		{
			string path2 = string.Empty;
			int qualityId;
			if (data.IsSticker)
			{
				MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(data.ItemId);
				if (motorStickerConfig == null)
				{
					return;
				}
				path2 = motorStickerConfig.Value.Icon;
				qualityId = motorStickerConfig.Value.QualityId;
			}
			else
			{
				MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(data.ItemId);
				if (motorDecorationConfig == null)
				{
					return;
				}
				path2 = motorDecorationConfig.Value.Icon;
				qualityId = motorDecorationConfig.Value.QualityId;
			}
			sprite.SetUIActive(true);
			texture.SetUIActive(true);
			base.SetTextureByPath(path2, texture, null, null);
			MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(qualityId);
			if (motorQualityConfig == null)
			{
				return;
			}
			this.SetSpriteByPath(motorQualityConfig.Value.Path, sprite, false, null, null);
			if ((data.IsSticker ? ModelBase<MotorcycleDiyModel>.Instance.GetStickerState(data.ItemId) : ModelBase<MotorcycleDiyModel>.Instance.GetDecorationState(data.ItemId)) == EOutLookState.IsBan)
			{
				item2.SetUIActive(true);
			}
		}
		EToggleState state = flag ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
		base.GetExtendToggle(0).SetToggleState(state, false, false, false);
	}

	// Token: 0x06010DD6 RID: 69078 RVA: 0x0049E15F File Offset: 0x0049C35F
	public override void OnSelected(bool fireEvent)
	{
		this.OnClickItem(EToggleState.ETT_Checked);
	}

	// Token: 0x06010DD7 RID: 69079 RVA: 0x0049E168 File Offset: 0x0049C368
	private void OnClickItem(EToggleState toggleState)
	{
		if (this.Data == null)
		{
			return;
		}
		Action<int, UUIExtendToggle, UUIItem> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Data.ItemId, base.GetExtendToggle(0), base.GetItem(7));
	}

	// Token: 0x040084E6 RID: 34022
	[Nullable(2)]
	private MotorcycleDiyEditStickerDecoItemData Data;

	// Token: 0x040084E7 RID: 34023
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<int, UUIExtendToggle, UUIItem> OnClickToggleBack;

	// Token: 0x020085A9 RID: 34217
	private class EEditStickerDecoItemComponent
	{
		// Token: 0x0402D385 RID: 185221
		public const int TogItem = 0;

		// Token: 0x0402D386 RID: 185222
		public const int SprQuality = 1;

		// Token: 0x0402D387 RID: 185223
		public const int PnlNone = 2;

		// Token: 0x0402D388 RID: 185224
		public const int TexIcon = 3;

		// Token: 0x0402D389 RID: 185225
		public const int PnlBan = 4;

		// Token: 0x0402D38A RID: 185226
		public const int PnlLock = 5;

		// Token: 0x0402D38B RID: 185227
		public const int PnlSelect = 6;

		// Token: 0x0402D38C RID: 185228
		public const int NewItem = 7;

		// Token: 0x0402D38D RID: 185229
		public const int PreviewItem = 8;
	}
}
