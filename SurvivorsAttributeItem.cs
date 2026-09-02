using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B03 RID: 11011
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsAttributeItem : GridProxyAbstract<ISurvivorsAttributeUiData>
{
	// Token: 0x0601602A RID: 90154 RVA: 0x0061B488 File Offset: 0x00619688
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUISprite)),
			new ValueTuple<int, Type>(4, typeof(UUISprite))
		};
	}

	// Token: 0x0601602B RID: 90155 RVA: 0x0061B510 File Offset: 0x00619710
	public override void Refresh(ISurvivorsAttributeUiData data, bool isSelected, int gridIndex)
	{
		SurvivorsProperty? propertyConfig = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(data.AttrId);
		this.SetTextByTextId(propertyConfig.Value.Name);
		this.SetIcon(propertyConfig.Value.Icon);
		this.SetValue(data.Value, propertyConfig.Value.IsPercent, data.IsAddition.GetValueOrDefault());
		this.SetRecommend(data.IsRecommend);
		this.SetBgVisible(gridIndex % 2 == 0);
	}

	// Token: 0x0601602C RID: 90156 RVA: 0x0061B59C File Offset: 0x0061979C
	public void SetIcon(string icon)
	{
		base.SetTextureByPath(icon, base.GetTexture(2), null, null);
	}

	// Token: 0x0601602D RID: 90157 RVA: 0x0061B5C1 File Offset: 0x006197C1
	public void SetRecommend(bool isRecommend)
	{
		UUISprite sprite = base.GetSprite(4);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(isRecommend);
	}

	// Token: 0x0601602E RID: 90158 RVA: 0x0061B5D8 File Offset: 0x006197D8
	public void SetValue(double value, bool isPercent = false, bool isAddition = false)
	{
		if (isPercent)
		{
			value *= 100.0;
		}
		string text = (Math.Abs(value - Math.Round(value)) < 1E-09) ? Math.Round(value).ToString() : value.ToString("F2");
		if (isPercent)
		{
			text += "%";
		}
		if (isAddition)
		{
			text = "+" + text;
		}
		UUIText text2 = base.GetText(1);
		if (text2 == null)
		{
			return;
		}
		text2.SetText(text, true);
	}

	// Token: 0x0601602F RID: 90159 RVA: 0x0061B65B File Offset: 0x0061985B
	public void SetTextByTextId(string textId)
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(textId);
	}

	// Token: 0x06016030 RID: 90160 RVA: 0x0061B66F File Offset: 0x0061986F
	public void SetBgVisible(bool visible)
	{
		UUISprite sprite = base.GetSprite(3);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(visible);
	}
}
