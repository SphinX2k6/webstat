using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x020022D1 RID: 8913
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyOutlookBoxItem : GridProxyAbstract<MotorcycleDiyOutlookBoxItemData>
{
	// Token: 0x06010DE0 RID: 69088 RVA: 0x0049E5AC File Offset: 0x0049C7AC
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUITexture)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickToggle))
		};
	}

	// Token: 0x06010DE1 RID: 69089 RVA: 0x0049E66C File Offset: 0x0049C86C
	[NullableContext(1)]
	public override void Refresh(MotorcycleDiyOutlookBoxItemData data, bool isSelected, int gridIndex)
	{
		if (data == null)
		{
			return;
		}
		base.GetItem(4).SetUIActive(false);
		this.Data = data;
		switch (this.Data.OutlookType)
		{
		case EOutlookType.None:
		case EOutlookType.Frame:
			break;
		case EOutlookType.Sticker:
			this.RefreshStickerPartBoxItem();
			return;
		case EOutlookType.Decoration:
			this.RefreshDecorationPartBoxItem();
			break;
		default:
			return;
		}
	}

	// Token: 0x06010DE2 RID: 69090 RVA: 0x0049E6C4 File Offset: 0x0049C8C4
	private void RefreshStickerPartBoxItem()
	{
		MotorStickerPart? motorStickerPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerPartConfig(this.Data.JumpIndex + 1);
		if (motorStickerPartConfig == null)
		{
			return;
		}
		bool flag = this.Data.ItemId == 0;
		base.SetTextureByPath(motorStickerPartConfig.Value.Icon, base.GetTexture(3), null, null);
		base.GetSprite(5).SetUIActive(false);
		base.GetItem(2).SetUIActive(flag);
		base.GetTexture(1).SetUIActive(!flag);
		if (!flag)
		{
			int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedStickerId(this.Data.JumpIndex + 1));
			if (num != null && num.Value > 0)
			{
				MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num.Value);
				if (motorStickerConfig == null)
				{
					return;
				}
				MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(motorStickerConfig.Value.QualityId);
				if (motorQualityConfig == null)
				{
					return;
				}
				base.GetSprite(5).SetUIActive(true);
				this.SetSpriteByPath(motorQualityConfig.Value.Path, base.GetSprite(5), false, null, null);
				base.SetTextureByPath(motorStickerConfig.Value.StickerIconPath, base.GetTexture(1), null, null);
			}
		}
	}

	// Token: 0x06010DE3 RID: 69091 RVA: 0x0049E830 File Offset: 0x0049CA30
	private void RefreshDecorationPartBoxItem()
	{
		MotorDecorationsPart? motorDecorationPartConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationPartConfig(this.Data.JumpIndex + 1);
		if (motorDecorationPartConfig == null)
		{
			return;
		}
		bool flag = this.Data.ItemId == 0;
		base.SetTextureByPath(motorDecorationPartConfig.Value.Icon, base.GetTexture(3), null, null);
		base.GetSprite(5).SetUIActive(false);
		base.GetItem(2).SetUIActive(flag);
		base.GetTexture(1).SetUIActive(!flag);
		if (!flag)
		{
			int? num = new int?(ModelBase<MotorcycleDiyModel>.Instance.GetEquippedDecorationId(this.Data.JumpIndex + 1));
			if (num != null && num.Value > 0)
			{
				MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num.Value);
				if (motorDecorationConfig == null)
				{
					return;
				}
				MotorQuality? motorQualityConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorQualityConfig(motorDecorationConfig.Value.QualityId);
				if (motorQualityConfig == null)
				{
					return;
				}
				base.GetSprite(5).SetUIActive(true);
				this.SetSpriteByPath(motorQualityConfig.Value.Path, base.GetSprite(5), false, null, null);
				base.SetTextureByPath(motorDecorationConfig.Value.DecorationsIconPath, base.GetTexture(1), null, null);
			}
		}
	}

	// Token: 0x06010DE4 RID: 69092 RVA: 0x0049E99C File Offset: 0x0049CB9C
	private void OnClickToggle(EToggleState toggleState)
	{
		if (this.Data == null || this.Data.JumpIndex == -1)
		{
			return;
		}
		switch (this.Data.OutlookType)
		{
		case EOutlookType.None:
			break;
		case EOutlookType.Frame:
			this.OnClickFrameToggle();
			return;
		case EOutlookType.Sticker:
			this.OnClickStickerToggle(this.Data.JumpIndex);
			return;
		case EOutlookType.Decoration:
			this.OnClickDecorationToggle(this.Data.JumpIndex);
			break;
		default:
			return;
		}
	}

	// Token: 0x06010DE5 RID: 69093 RVA: 0x0049EA10 File Offset: 0x0049CC10
	private void OnClickFrameToggle()
	{
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			OpenTabView = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyFrameTabView),
			IsNeedResetMotor = new bool?(true)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
	}

	// Token: 0x06010DE6 RID: 69094 RVA: 0x0049EA50 File Offset: 0x0049CC50
	private void OnClickStickerToggle(int index)
	{
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			OpenTabView = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyStickerTabView),
			PartTabIndex = new int?(index + 1),
			IsNeedResetMotor = new bool?(true)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x06010DE7 RID: 69095 RVA: 0x0049EAB0 File Offset: 0x0049CCB0
	private void OnClickDecorationToggle(int index)
	{
		OpenMotorcycleDiyRootViewData param = new OpenMotorcycleDiyRootViewData
		{
			OpenTabView = new EUiTabViewName?(EUiTabViewName.MotorcycleDiyDecorationTabView),
			PartTabIndex = new int?(index + 1),
			IsNeedResetMotor = new bool?(true)
		};
		Singleton<UiManager>.Instance.OpenView(EUiViewName.MotorcycleDiyRootView, param, null);
		base.GetExtendToggle(0).SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
	}

	// Token: 0x040084EC RID: 34028
	[Nullable(2)]
	private MotorcycleDiyOutlookBoxItemData Data;

	// Token: 0x020085AC RID: 34220
	private class EOutlookBoxItemComponent
	{
		// Token: 0x0402D39B RID: 185243
		public const int TogItem = 0;

		// Token: 0x0402D39C RID: 185244
		public const int TexIcon = 1;

		// Token: 0x0402D39D RID: 185245
		public const int ItemEmpty = 2;

		// Token: 0x0402D39E RID: 185246
		public const int TexPart = 3;

		// Token: 0x0402D39F RID: 185247
		public const int ItemNone = 4;

		// Token: 0x0402D3A0 RID: 185248
		public const int SprQuality = 5;
	}
}
