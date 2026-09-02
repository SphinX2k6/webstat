using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020024E1 RID: 9441
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionAssembleAttrScrollItem : GridProxyAbstract<VisionAssembleAttrData>
{
	// Token: 0x0601254F RID: 75087 RVA: 0x00509DD4 File Offset: 0x00507FD4
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIItem)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIItem)),
			new ValueTuple<int, Type>(6, typeof(UUITexture)),
			new ValueTuple<int, Type>(7, typeof(UUIText)),
			new ValueTuple<int, Type>(8, typeof(UUIText)),
			new ValueTuple<int, Type>(9, typeof(UUIItem)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIItem))
		};
	}

	// Token: 0x06012550 RID: 75088 RVA: 0x00509EF7 File Offset: 0x005080F7
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012551 RID: 75089 RVA: 0x00509F0C File Offset: 0x0050810C
	public void PlaySequence(string name)
	{
		LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
		if (levelSequencePlayer != null)
		{
			levelSequencePlayer.StopCurrentSequence(false, false);
		}
		LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
		if (levelSequencePlayer2 == null)
		{
			return;
		}
		levelSequencePlayer2.PlayLevelSequenceByName(name, false, null, false);
	}

	// Token: 0x06012552 RID: 75090 RVA: 0x00509F48 File Offset: 0x00508148
	public void SetLeftItemAlpha(float alpha)
	{
		base.GetItem(0).SetAlpha(alpha);
	}

	// Token: 0x06012553 RID: 75091 RVA: 0x00509F57 File Offset: 0x00508157
	public void SetRightItemAlpha(float alpha)
	{
		base.GetItem(11).SetAlpha(alpha);
	}

	// Token: 0x06012554 RID: 75092 RVA: 0x00509F68 File Offset: 0x00508168
	private void RefreshBg(int gridIndex)
	{
		bool uiactive = gridIndex % 2 == 0;
		base.GetItem(1).SetUIActive(uiactive);
		base.GetItem(5).SetUIActive(uiactive);
	}

	// Token: 0x06012555 RID: 75093 RVA: 0x00509F98 File Offset: 0x00508198
	public override void Refresh(VisionAssembleAttrData data, bool isSelected, int gridIndex)
	{
		this.RefreshBg(gridIndex);
		bool compareMode = data.CompareMode;
		base.GetItem(0).SetUIActive(compareMode);
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.AttrId);
		if (compareMode)
		{
			base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(2), null, null);
			base.GetText(3).ShowTextNew(propertyIndexInfo.Value.Name);
			double propRatioValue = TipsDataTool.GetPropRatioValue((double)data.CompareValue, data.IfPercentage);
			string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.AttrId, propRatioValue, data.IfPercentage);
			base.GetText(4).SetText(formatAttributeValueString, true);
			bool flag = data.CompareValue == data.CurrentValue;
			bool flag2 = data.CompareValue < data.CurrentValue;
			base.GetItem(9).SetUIActive(flag2 && !flag);
			base.GetItem(10).SetUIActive(!flag2 && !flag);
		}
		else
		{
			base.GetItem(9).SetUIActive(false);
			base.GetItem(10).SetUIActive(false);
		}
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(6), null, null);
		base.GetText(7).ShowTextNew(propertyIndexInfo.Value.Name);
		double propRatioValue2 = TipsDataTool.GetPropRatioValue((double)data.CurrentValue, data.IfPercentage);
		string formatAttributeValueString2 = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.AttrId, propRatioValue2, data.IfPercentage);
		base.GetText(8).SetText(formatAttributeValueString2, true);
	}

	// Token: 0x04008EF9 RID: 36601
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x020087EF RID: 34799
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402DEC5 RID: 188101
		LeftItem,
		// Token: 0x0402DEC6 RID: 188102
		LeftSpriteBg,
		// Token: 0x0402DEC7 RID: 188103
		LeftTextureIcon,
		// Token: 0x0402DEC8 RID: 188104
		LeftAttributeText,
		// Token: 0x0402DEC9 RID: 188105
		LeftNumText,
		// Token: 0x0402DECA RID: 188106
		RightSpriteBg,
		// Token: 0x0402DECB RID: 188107
		RightTextureIcon,
		// Token: 0x0402DECC RID: 188108
		RightAttributeText,
		// Token: 0x0402DECD RID: 188109
		RightNumText,
		// Token: 0x0402DECE RID: 188110
		UpItem,
		// Token: 0x0402DECF RID: 188111
		DownItem,
		// Token: 0x0402DED0 RID: 188112
		RightItem
	}
}
