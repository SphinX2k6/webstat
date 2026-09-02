using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001691 RID: 5777
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerSettlementBossItem : GridProxyAbstract<IBossItemData>
{
	// Token: 0x0600A123 RID: 41251 RVA: 0x002A4AC0 File Offset: 0x002A2CC0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 7;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A124 RID: 41252 RVA: 0x002A4BD0 File Offset: 0x002A2DD0
	public override void Refresh(IBossItemData data, bool isSelected, int gridIndex)
	{
		IBossInfo bossInfo = data.BossInfo;
		bool valueOrDefault = data.ShowBossRound.GetValueOrDefault();
		NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossInfo.WaveConfigId);
		if (waveConfigById == null)
		{
			return;
		}
		base.SetTextureByPath(waveConfigById.Value.Icon, base.GetTexture(0), null, null);
		UUITexture texture = base.GetTexture(0);
		if (texture != null)
		{
			UUIItem uuiitem = texture;
			bool bUseChangeColor = bossInfo.HpPercentage <= 0.0;
			FColor? fcolor = new FColor?(texture.changeColor);
			uuiitem.SetChangeColor(bUseChangeColor, fcolor);
		}
		UUIText text = base.GetText(1);
		if (text != null)
		{
			text.ShowTextNew(waveConfigById.Value.Name);
		}
		UUISprite sprite = base.GetSprite(2);
		if (sprite != null)
		{
			sprite.SetFillAmount((float)bossInfo.HpPercentage / 100f);
		}
		UUIText text2 = base.GetText(3);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (text2 != null)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
			defaultInterpolatedStringHandler.AppendFormatted<double>(bossInfo.HpPercentage);
			defaultInterpolatedStringHandler.AppendLiteral("%");
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUISprite sprite2 = base.GetSprite(4);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(bossInfo.HpPercentage <= 0.0);
		}
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(valueOrDefault && bossInfo.Round > 0);
		}
		UUIText text3 = base.GetText(6);
		if (text3 == null)
		{
			return;
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("R");
		defaultInterpolatedStringHandler.AppendFormatted<int>(bossInfo.Round);
		text3.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}
}
