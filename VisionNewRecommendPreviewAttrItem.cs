using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200252A RID: 9514
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class VisionNewRecommendPreviewAttrItem : GridProxyAbstract<VisionAssembleAttrData>
{
	// Token: 0x06012834 RID: 75828 RVA: 0x00519A04 File Offset: 0x00517C04
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
			new ValueTuple<int, Type>(11, typeof(UUIItem)),
			new ValueTuple<int, Type>(12, typeof(UUISprite)),
			new ValueTuple<int, Type>(13, typeof(UUISprite))
		};
	}

	// Token: 0x06012835 RID: 75829 RVA: 0x00519B55 File Offset: 0x00517D55
	protected override void OnStart()
	{
		this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
	}

	// Token: 0x06012836 RID: 75830 RVA: 0x00519B68 File Offset: 0x00517D68
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

	// Token: 0x06012837 RID: 75831 RVA: 0x00519BA4 File Offset: 0x00517DA4
	public void SetLeftItemAlpha(float alpha)
	{
		base.GetItem(0).SetAlpha(alpha);
	}

	// Token: 0x06012838 RID: 75832 RVA: 0x00519BB3 File Offset: 0x00517DB3
	public void SetRightItemAlpha(float alpha)
	{
		base.GetItem(11).SetAlpha(alpha);
	}

	// Token: 0x06012839 RID: 75833 RVA: 0x00519BC4 File Offset: 0x00517DC4
	private void RefreshBg(int gridIndex)
	{
		bool uiactive = gridIndex % 2 == 0;
		base.GetItem(1).SetUIActive(uiactive);
		base.GetItem(5).SetUIActive(uiactive);
		UUISprite sprite = base.GetSprite(12);
		if (sprite != null)
		{
			VisionAssembleAttrData data = this.Data;
			sprite.SetUIActive(data != null && data.IsHighLight);
		}
		UUISprite sprite2 = base.GetSprite(13);
		if (sprite2 == null)
		{
			return;
		}
		VisionAssembleAttrData data2 = this.Data;
		sprite2.SetUIActive(data2 != null && data2.IsHighLight);
	}

	// Token: 0x0601283A RID: 75834 RVA: 0x00519C3C File Offset: 0x00517E3C
	public override void Refresh(VisionAssembleAttrData data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		this.RefreshBg(gridIndex);
		PropertyIndex? propertyIndexInfo = ConfigBase<PropertyIndexConfig>.Instance.GetPropertyIndexInfo(data.AttrId);
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(2), null, null);
		base.GetText(3).ShowTextNew(propertyIndexInfo.Value.Name);
		double propRatioValue = TipsDataTool.GetPropRatioValue((double)data.CompareValue, data.IfPercentage);
		string formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.AttrId, propRatioValue, data.IfPercentage);
		base.GetText(4).SetText(formatAttributeValueString.ToString(), true);
		bool flag = data.CompareValue == data.CurrentValue;
		bool flag2 = data.CompareValue < data.CurrentValue;
		base.GetItem(9).SetUIActive(flag2 && !flag);
		base.GetItem(10).SetUIActive(!flag2 && !flag);
		base.SetTextureByPath(propertyIndexInfo.Value.Icon, base.GetTexture(6), null, null);
		base.GetText(7).ShowTextNew(propertyIndexInfo.Value.Name);
		propRatioValue = TipsDataTool.GetPropRatioValue((double)data.CurrentValue, data.IfPercentage);
		formatAttributeValueString = ModelBase<AttributeModel>.Instance.GetFormatAttributeValueString(data.AttrId, propRatioValue, data.IfPercentage);
		base.GetText(8).SetText(formatAttributeValueString, true);
	}

	// Token: 0x04009052 RID: 36946
	[Nullable(2)]
	private VisionAssembleAttrData Data;

	// Token: 0x04009053 RID: 36947
	[Nullable(2)]
	private LevelSequencePlayer LevelSequencePlayer;

	// Token: 0x02008851 RID: 34897
	[NullableContext(0)]
	private enum EComponent
	{
		// Token: 0x0402E0A8 RID: 188584
		LeftItem,
		// Token: 0x0402E0A9 RID: 188585
		LeftSpriteBg,
		// Token: 0x0402E0AA RID: 188586
		LeftTextureIcon,
		// Token: 0x0402E0AB RID: 188587
		LeftAttributeText,
		// Token: 0x0402E0AC RID: 188588
		LeftNumText,
		// Token: 0x0402E0AD RID: 188589
		RightSpriteBg,
		// Token: 0x0402E0AE RID: 188590
		RightTextureIcon,
		// Token: 0x0402E0AF RID: 188591
		RightAttributeText,
		// Token: 0x0402E0B0 RID: 188592
		RightNumText,
		// Token: 0x0402E0B1 RID: 188593
		UpItem,
		// Token: 0x0402E0B2 RID: 188594
		DownItem,
		// Token: 0x0402E0B3 RID: 188595
		RightItem,
		// Token: 0x0402E0B4 RID: 188596
		LeftHighLightBg,
		// Token: 0x0402E0B5 RID: 188597
		RightHighLightBg
	}
}
