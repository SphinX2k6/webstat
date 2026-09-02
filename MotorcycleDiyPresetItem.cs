using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020022D3 RID: 8915
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class MotorcycleDiyPresetItem : GridProxyAbstract<MotorcycleDiyPresetData>
{
	// Token: 0x06010DEE RID: 69102 RVA: 0x0049EDB0 File Offset: 0x0049CFB0
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUITexture)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUIArtText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(0, new Action<EToggleState>(this.OnClickItem))
		};
	}

	// Token: 0x06010DEF RID: 69103 RVA: 0x0049EE6F File Offset: 0x0049D06F
	protected override void OnStart()
	{
		this.PresetLayout = new GenericLayout<MotorcycleDiyPresetIconItem, string>(base.GetHorizontalLayout(3), new Func<MotorcycleDiyPresetIconItem>(this.InitPresetIconItem), base.GetItem(4).GetOwner() as AUIBaseActor, false, true);
	}

	// Token: 0x06010DF0 RID: 69104 RVA: 0x0049EEA2 File Offset: 0x0049D0A2
	private MotorcycleDiyPresetIconItem InitPresetIconItem()
	{
		return new MotorcycleDiyPresetIconItem();
	}

	// Token: 0x06010DF1 RID: 69105 RVA: 0x0049EEA9 File Offset: 0x0049D0A9
	public override void Refresh(MotorcycleDiyPresetData data, bool isSelected, int gridIndex)
	{
		this.ListIndex = gridIndex;
		this.RefreshPresetInfo(data);
	}

	// Token: 0x06010DF2 RID: 69106 RVA: 0x0049EEBC File Offset: 0x0049D0BC
	public void RefreshPresetInfo(MotorcycleDiyPresetData data)
	{
		this.Data = data;
		UUIText text = base.GetText(2);
		UUIArtText artText = base.GetArtText(5);
		text.SetText(data.Name, true);
		bool flag = !data.IsCurEquipped;
		int value = this.ListIndex + 1;
		UUIArtText uuiartText = artText;
		string text2;
		if (!flag)
		{
			text2 = "";
		}
		else
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendLiteral("0");
			defaultInterpolatedStringHandler.AppendFormatted<int>(value);
			text2 = defaultInterpolatedStringHandler.ToStringAndClear();
		}
		uuiartText.SetText(text2);
		if (data.OfficialId > 0)
		{
			MotorLoadProject? motorPresetConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorPresetConfig(data.OfficialId);
			if (motorPresetConfig != null)
			{
				base.SetTextureByPath(motorPresetConfig.Value.Icon, base.GetTexture(1), null, null);
			}
			GenericLayout<MotorcycleDiyPresetIconItem, string> presetLayout = this.PresetLayout;
			if (presetLayout == null)
			{
				return;
			}
			presetLayout.RefreshByData(new List<string>(), null, false);
			return;
		}
		else
		{
			MotorFrame? motorFrameConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorFrameConfig(data.FrameId);
			if (motorFrameConfig != null)
			{
				base.SetTextureByPath(motorFrameConfig.Value.PresetIcon, base.GetTexture(1), null, null);
			}
			List<string> list = new List<string>();
			foreach (int num in data.StickerIds)
			{
				if (num > 0)
				{
					MotorSticker? motorStickerConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorStickerConfig(num);
					if (motorStickerConfig != null)
					{
						list.Add(motorStickerConfig.Value.StickerIconPath);
					}
				}
			}
			foreach (int num2 in data.DecorateIds)
			{
				if (num2 > 0)
				{
					MotorDecorations? motorDecorationConfig = ConfigBase<MotorDiyConfig>.Instance.GetMotorDecorationConfig(num2);
					if (motorDecorationConfig != null)
					{
						list.Add(motorDecorationConfig.Value.DecorationsIconPath);
					}
				}
			}
			GenericLayout<MotorcycleDiyPresetIconItem, string> presetLayout2 = this.PresetLayout;
			if (presetLayout2 == null)
			{
				return;
			}
			presetLayout2.RefreshByData(list, null, false);
			return;
		}
	}

	// Token: 0x06010DF3 RID: 69107 RVA: 0x0049F09D File Offset: 0x0049D29D
	public override void OnSelected(bool fireEvent)
	{
		this.OnClickItem(EToggleState.ETT_Checked);
	}

	// Token: 0x06010DF4 RID: 69108 RVA: 0x0049F0A6 File Offset: 0x0049D2A6
	public void SetToggleState(EToggleState state, bool isFireEvent = true)
	{
		base.GetExtendToggle(0).SetToggleState(state, isFireEvent, false, false);
	}

	// Token: 0x06010DF5 RID: 69109 RVA: 0x0049F0B9 File Offset: 0x0049D2B9
	private void OnClickItem(EToggleState toggleState)
	{
		if (this.Data == null)
		{
			return;
		}
		Action<MotorcycleDiyPresetData, int, UUIExtendToggle> onClickToggleBack = this.OnClickToggleBack;
		if (onClickToggleBack == null)
		{
			return;
		}
		onClickToggleBack(this.Data, this.ListIndex, base.GetExtendToggle(0));
	}

	// Token: 0x040084EF RID: 34031
	[Nullable(2)]
	private MotorcycleDiyPresetData Data;

	// Token: 0x040084F0 RID: 34032
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	public Action<MotorcycleDiyPresetData, int, UUIExtendToggle> OnClickToggleBack;

	// Token: 0x040084F1 RID: 34033
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private GenericLayout<MotorcycleDiyPresetIconItem, string> PresetLayout;

	// Token: 0x040084F2 RID: 34034
	private int ListIndex = -1;

	// Token: 0x020085AE RID: 34222
	[NullableContext(0)]
	private class EMotorDiyPresetItemComponent
	{
		// Token: 0x0402D3A8 RID: 185256
		public const int TogItem = 0;

		// Token: 0x0402D3A9 RID: 185257
		public const int TexIcon = 1;

		// Token: 0x0402D3AA RID: 185258
		public const int TxtName = 2;

		// Token: 0x0402D3AB RID: 185259
		public const int PresetLayout = 3;

		// Token: 0x0402D3AC RID: 185260
		public const int PresetItem = 4;

		// Token: 0x0402D3AD RID: 185261
		public const int ArtTxtCustomId = 5;
	}

	// Token: 0x020085AF RID: 34223
	[NullableContext(0)]
	private class EMotorDiyPresetIconComponent
	{
		// Token: 0x0402D3AE RID: 185262
		public const int TexIcon = 0;
	}
}
