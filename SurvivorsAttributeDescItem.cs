using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B33 RID: 11059
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class SurvivorsAttributeDescItem : GridProxyAbstract<ISurvivorsAttributeUiData>
{
	// Token: 0x06016106 RID: 90374 RVA: 0x0061F6F8 File Offset: 0x0061D8F8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIText)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUITexture)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUIItem))
		};
	}

	// Token: 0x06016107 RID: 90375 RVA: 0x0061F7AC File Offset: 0x0061D9AC
	public override void Refresh(ISurvivorsAttributeUiData data, bool isSelected, int gridIndex)
	{
		SurvivorsProperty value = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(data.AttrId).Value;
		this.SetTextByTextId(value.Name);
		this.SetIcon(value.Icon);
		this.SetValue(data.Value, value.IsPercent);
		this.SetBgVisible(gridIndex % 2 == 0);
	}

	// Token: 0x06016108 RID: 90376 RVA: 0x0061F80C File Offset: 0x0061DA0C
	public void SetIcon(string icon)
	{
		base.SetTextureByPath(icon, base.GetTexture(4), null, null);
	}

	// Token: 0x06016109 RID: 90377 RVA: 0x0061F834 File Offset: 0x0061DA34
	public void SetValue(double value, bool isPercent = false)
	{
		UUIText text = base.GetText(1);
		if (text != null)
		{
			if (isPercent)
			{
				text.SetText(Math.Round(value * 100.0, 2).ToString() + "%", true);
				return;
			}
			text.SetText(Math.Round(value, 6).ToString() ?? "", true);
		}
	}

	// Token: 0x0601610A RID: 90378 RVA: 0x0061F899 File Offset: 0x0061DA99
	public void SetTextByTextId(string textId)
	{
		UUIText text = base.GetText(0);
		if (text == null)
		{
			return;
		}
		text.ShowTextNew(textId);
	}

	// Token: 0x0601610B RID: 90379 RVA: 0x0061F8AD File Offset: 0x0061DAAD
	public void SetBgVisible(bool visible)
	{
		UUISprite sprite = base.GetSprite(5);
		if (sprite == null)
		{
			return;
		}
		sprite.SetUIActive(visible);
	}
}
