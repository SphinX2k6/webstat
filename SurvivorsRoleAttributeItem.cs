using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02002B3F RID: 11071
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class SurvivorsRoleAttributeItem : GridProxyAbstract<ISurvivorsAttributeUiData>
{
	// Token: 0x06016151 RID: 90449 RVA: 0x0062084F File Offset: 0x0061EA4F
	public override void Refresh(ISurvivorsAttributeUiData data, bool isSelected, int gridIndex)
	{
		this.Update(data);
	}

	// Token: 0x06016152 RID: 90450 RVA: 0x00620858 File Offset: 0x0061EA58
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIExtendToggle)),
			new ValueTuple<int, Type>(1, typeof(UUISprite)),
			new ValueTuple<int, Type>(2, typeof(UUITexture)),
			new ValueTuple<int, Type>(3, typeof(UUIText)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIItem)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIText))
		};
	}

	// Token: 0x06016153 RID: 90451 RVA: 0x00620936 File Offset: 0x0061EB36
	protected override void OnStart()
	{
		UUIText text = base.GetText(5);
		if (text != null)
		{
			text.SetUIActive(false);
		}
		UUIItem item = base.GetItem(6);
		if (item != null)
		{
			item.SetUIActive(false);
		}
		UUIItem item2 = base.GetItem(7);
		if (item2 == null)
		{
			return;
		}
		item2.SetUIActive(false);
	}

	// Token: 0x06016154 RID: 90452 RVA: 0x00620970 File Offset: 0x0061EB70
	public void Update(ISurvivorsAttributeUiData data)
	{
		base.GetSprite(1).useChangeColor = (base.GridIndex % 2 == 1);
		SurvivorsProperty value = ConfigBase<SurvivorsRogueConfig>.Instance.GetPropertyConfig(data.AttrId).Value;
		base.SetTextureByPath(value.Icon, base.GetTexture(2), null, null);
		base.GetText(3).ShowTextNew(value.Name);
		this.SetValue(data.Value, value.IsPercent);
	}

	// Token: 0x06016155 RID: 90453 RVA: 0x006209F4 File Offset: 0x0061EBF4
	public void SetValue(double value, bool isPercent = false)
	{
		UUIText text = base.GetText(4);
		if (isPercent)
		{
			text.SetText(Math.Round(value * 100.0, 2).ToString() + "%", true);
			return;
		}
		text.SetText(value.ToString(), true);
	}
}
