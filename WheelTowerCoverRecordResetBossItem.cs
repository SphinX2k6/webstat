using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001630 RID: 5680
public class WheelTowerCoverRecordResetBossItem : UiPanelBase
{
	// Token: 0x0600A00F RID: 40975 RVA: 0x0029D938 File Offset: 0x0029BB38
	protected unsafe override void OnRegisterComponent()
	{
		int num = 5;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A010 RID: 40976 RVA: 0x0029DA04 File Offset: 0x0029BC04
	[NullableContext(1)]
	public void Refresh(IWheelTowerCoverRecordData oldData, IWheelTowerCoverRecordData newData)
	{
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), "WheelTowerEndlessFinishedNum", new <>z__ReadOnlySingleElementList<object>(oldData.BossRound.ToString()));
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(3), "WheelTowerEndlessFinishedNum", new <>z__ReadOnlySingleElementList<object>(newData.BossRound.ToString()));
		UUIText text = base.GetText(2);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (text != null)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(oldData.BossWave);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(oldData.NeedChallengeBossWaveNum);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}
		UUIText text2 = base.GetText(4);
		if (text2 == null)
		{
			return;
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(newData.BossWave);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(newData.NeedChallengeBossWaveNum);
		text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
	}
}
