using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using CSharpScript.Game.Effect;
using UnrealEngine;

// Token: 0x02002FA3 RID: 12195
public class GamePlayCueEffectNiagara : GameplayCueEffect
{
	// Token: 0x06018DF1 RID: 101873 RVA: 0x0070AF24 File Offset: 0x00709124
	protected unsafe override void OnSetMagnitude(float value)
	{
		EffectParameterNiagara effectParameterNiagara = new EffectParameterNiagara();
		EffectParameterNiagara effectParameterNiagara2 = effectParameterNiagara;
		int num = 1;
		List<ValueTuple<FName, float>> list = new List<ValueTuple<FName, float>>(num);
		CollectionsMarshal.SetCount<ValueTuple<FName, float>>(list, num);
		Span<ValueTuple<FName, float>> span = CollectionsMarshal.AsSpan<ValueTuple<FName, float>>(list);
		int index = 0;
		*span[index] = new ValueTuple<FName, float>(FNameUtil.GetDynamicFName("VisualCount").Value, base.ToRange(value));
		effectParameterNiagara2.UserParameterFloat = list;
		Singleton<EffectSystem>.Instance.SetEffectParameterNiagara(this.EffectViewHandle, effectParameterNiagara);
	}
}
