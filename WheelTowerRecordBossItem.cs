using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001655 RID: 5717
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerRecordBossItem : GridProxyAbstract<IBossItemData>
{
	// Token: 0x0600A069 RID: 41065 RVA: 0x0029FBA8 File Offset: 0x0029DDA8
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

	// Token: 0x0600A06A RID: 41066 RVA: 0x0029FCB8 File Offset: 0x0029DEB8
	public override void Refresh(IBossItemData data, bool isSelected, int gridIndex)
	{
		IBossInfo bossInfo = data.BossInfo;
		NewTowerWave? waveConfigById = ConfigBase<WheelTowerConfig>.Instance.GetWaveConfigById(bossInfo.WaveConfigId);
		if (waveConfigById == null)
		{
			return;
		}
		base.SetTextureByPath(waveConfigById.Value.Icon, base.GetTexture(0), null, null);
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
		double? num;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelTower_Record_Progress", new <>z__ReadOnlyArray<object>(new object[]
		{
			bossInfo.HpPercentage.ToString(),
			((bossInfo.LoseHpPercentage != null) ? num.GetValueOrDefault().ToString() : null) ?? "0"
		}));
		UUISprite sprite2 = base.GetSprite(4);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(bossInfo.HpPercentage <= 0.0);
		}
		bool endlessMode = ModelBase<WheelTowerModel>.Instance.EndlessMode;
		UUIItem item = base.GetItem(5);
		if (item != null)
		{
			item.SetUIActive(endlessMode && bossInfo.Round > 0);
		}
		UUIText text2 = base.GetText(6);
		if (text2 == null)
		{
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
		defaultInterpolatedStringHandler.AppendLiteral("R");
		defaultInterpolatedStringHandler.AppendFormatted<int>(bossInfo.Round);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}
}
