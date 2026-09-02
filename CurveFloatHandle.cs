using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BF4 RID: 3060
[NullableContext(1)]
[Nullable(0)]
public class CurveFloatHandle
{
	// Token: 0x0600329D RID: 12957 RVA: 0x00023990 File Offset: 0x00021B90
	[NullableContext(2)]
	public CurveFloatHandle(UCurveFloat curveFloat = null)
	{
		if (curveFloat == null)
		{
			return;
		}
		this.IsEventCurve = curveFloat.bIsEventCurve;
		for (int i = 0; i < curveFloat.FloatCurve.Keys.Num(); i++)
		{
			FRichCurveKey value = curveFloat.FloatCurve.Keys.Get(i);
			this.FloatCurveKeys.Add(new RichCurveKeyHandle(new FRichCurveKey?(value)));
		}
		this.FloatCurveDefaultValue = curveFloat.FloatCurve.DefaultValue;
		this.FloatCurvePostInfinityExtrap = curveFloat.FloatCurve.PostInfinityExtrap;
		this.FloatCurvePreInfinityExtrap = curveFloat.FloatCurve.PreInfinityExtrap;
	}

	// Token: 0x0600329E RID: 12958 RVA: 0x00023A58 File Offset: 0x00021C58
	public void MapRangeClampedTimeAndValue(float oldTimeMin, float oldTimeMax, float newTimeMin, float newTimeMax, float oldValueMin, float oldValueMax, float newValueMin, float newValueMax)
	{
		float num = (newValueMax - newValueMin) / (oldValueMax - oldValueMin);
		float num2 = (newTimeMax - newTimeMin) / (oldTimeMax - oldTimeMin);
		float num3 = num / num2;
		foreach (RichCurveKeyHandle richCurveKeyHandle in this.FloatCurveKeys)
		{
			richCurveKeyHandle.Time = Singleton<MathUtils>.Instance.RangeClamp(richCurveKeyHandle.Time, oldTimeMin, oldTimeMax, newTimeMin, newTimeMax);
			richCurveKeyHandle.Value = Singleton<MathUtils>.Instance.RangeClamp(richCurveKeyHandle.Value, oldValueMin, oldValueMax, newValueMin, newValueMax);
			if (richCurveKeyHandle.Time == newTimeMin)
			{
				richCurveKeyHandle.ArriveTangent = 0f;
				richCurveKeyHandle.ArriveTangentWeight = 0f;
				if (richCurveKeyHandle.TangentWeightMode == ERichCurveTangentWeightMode.RCTWM_WeightedBoth)
				{
					richCurveKeyHandle.TangentWeightMode = ERichCurveTangentWeightMode.RCTWM_WeightedLeave;
				}
				else if (richCurveKeyHandle.TangentWeightMode == ERichCurveTangentWeightMode.RCTWM_WeightedArrive)
				{
					richCurveKeyHandle.TangentWeightMode = ERichCurveTangentWeightMode.RCTWM_WeightedNone;
				}
			}
			else
			{
				if (richCurveKeyHandle.TangentWeightMode != ERichCurveTangentWeightMode.RCTWM_WeightedNone && richCurveKeyHandle.TangentWeightMode != ERichCurveTangentWeightMode.RCTWM_WeightedLeave)
				{
					float num4 = (float)Math.Atan((double)richCurveKeyHandle.ArriveTangent);
					float value = (float)Math.Cos((double)num4) * richCurveKeyHandle.ArriveTangentWeight;
					float value2 = (float)Math.Sin((double)num4) * richCurveKeyHandle.ArriveTangentWeight;
					float num5 = Singleton<MathUtils>.Instance.Lerp(newTimeMin, newTimeMax, Singleton<MathUtils>.Instance.GetRangePct(oldTimeMin, oldTimeMax, value));
					float num6 = Singleton<MathUtils>.Instance.Lerp(newValueMin, newValueMax, Singleton<MathUtils>.Instance.GetRangePct(oldValueMin, oldValueMax, value2));
					richCurveKeyHandle.ArriveTangentWeight = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
				}
				richCurveKeyHandle.ArriveTangent *= num3;
			}
			if (richCurveKeyHandle.Time == newTimeMax)
			{
				richCurveKeyHandle.LeaveTangent = 0f;
				richCurveKeyHandle.LeaveTangentWeight = 0f;
				if (richCurveKeyHandle.TangentWeightMode == ERichCurveTangentWeightMode.RCTWM_WeightedBoth)
				{
					richCurveKeyHandle.TangentWeightMode = ERichCurveTangentWeightMode.RCTWM_WeightedArrive;
				}
				else if (richCurveKeyHandle.TangentWeightMode == ERichCurveTangentWeightMode.RCTWM_WeightedLeave)
				{
					richCurveKeyHandle.TangentWeightMode = ERichCurveTangentWeightMode.RCTWM_WeightedNone;
				}
			}
			else
			{
				if (richCurveKeyHandle.TangentWeightMode != ERichCurveTangentWeightMode.RCTWM_WeightedNone && richCurveKeyHandle.TangentWeightMode != ERichCurveTangentWeightMode.RCTWM_WeightedArrive)
				{
					float num7 = (float)Math.Atan((double)richCurveKeyHandle.LeaveTangent);
					float value3 = (float)Math.Cos((double)num7) * richCurveKeyHandle.LeaveTangentWeight;
					float value4 = (float)Math.Sin((double)num7) * richCurveKeyHandle.LeaveTangentWeight;
					float num8 = Singleton<MathUtils>.Instance.Lerp(newTimeMin, newTimeMax, Singleton<MathUtils>.Instance.GetRangePct(oldTimeMin, oldTimeMax, value3));
					float num9 = Singleton<MathUtils>.Instance.Lerp(newValueMin, newValueMax, Singleton<MathUtils>.Instance.GetRangePct(oldValueMin, oldValueMax, value4));
					richCurveKeyHandle.LeaveTangentWeight = (float)Math.Sqrt((double)(num8 * num8 + num9 * num9));
				}
				richCurveKeyHandle.LeaveTangent *= num3;
			}
		}
	}

	// Token: 0x0600329F RID: 12959 RVA: 0x00023CF0 File Offset: 0x00021EF0
	public void AddKey(RichCurveKeyHandle dataKey)
	{
		this.AddKeyInternal(dataKey);
	}

	// Token: 0x060032A0 RID: 12960 RVA: 0x00023CFC File Offset: 0x00021EFC
	public void AddKey(FRichCurveKey ueDataKey)
	{
		RichCurveKeyHandle dataKey = new RichCurveKeyHandle(new FRichCurveKey?(ueDataKey));
		this.AddKeyInternal(dataKey);
	}

	// Token: 0x060032A1 RID: 12961 RVA: 0x00023D1C File Offset: 0x00021F1C
	public void AddKey(float time, float? value, ERichCurveInterpMode? interpMode = null)
	{
		RichCurveKeyHandle richCurveKeyHandle = new RichCurveKeyHandle();
		richCurveKeyHandle.Time = time;
		richCurveKeyHandle.Value = value.GetValueOrDefault();
		if (interpMode != null)
		{
			richCurveKeyHandle.InterpMode = interpMode.Value;
		}
		this.AddKeyInternal(richCurveKeyHandle);
	}

	// Token: 0x060032A2 RID: 12962 RVA: 0x00023D60 File Offset: 0x00021F60
	private void AddKeyInternal(RichCurveKeyHandle dataKey)
	{
		int num = -1;
		for (int i = 0; i < this.FloatCurveKeys.Count; i++)
		{
			if (this.FloatCurveKeys[i].Time > dataKey.Time)
			{
				num = i;
				break;
			}
		}
		if (num == -1)
		{
			this.FloatCurveKeys.Add(dataKey);
			return;
		}
		this.FloatCurveKeys.Insert(num, dataKey);
	}

	// Token: 0x060032A3 RID: 12963 RVA: 0x00023DC0 File Offset: 0x00021FC0
	public UCurveFloat ToUeCurveFloat()
	{
		UCurveFloat ucurveFloat = new UCurveFloat();
		FRichCurve floatCurve = ucurveFloat.FloatCurve;
		ucurveFloat.bIsEventCurve = this.IsEventCurve;
		floatCurve.Keys.Empty(true);
		foreach (RichCurveKeyHandle richCurveKeyHandle in this.FloatCurveKeys)
		{
			floatCurve.Keys.Add(richCurveKeyHandle.ToUeRichCurveKey());
		}
		floatCurve.DefaultValue = this.FloatCurveDefaultValue;
		floatCurve.PostInfinityExtrap = this.FloatCurvePostInfinityExtrap;
		floatCurve.PreInfinityExtrap = this.FloatCurvePreInfinityExtrap;
		ucurveFloat.FloatCurve = floatCurve;
		return ucurveFloat;
	}

	// Token: 0x04000565 RID: 1381
	public bool IsEventCurve;

	// Token: 0x04000566 RID: 1382
	public List<RichCurveKeyHandle> FloatCurveKeys = new List<RichCurveKeyHandle>();

	// Token: 0x04000567 RID: 1383
	public float FloatCurveDefaultValue = float.MaxValue;

	// Token: 0x04000568 RID: 1384
	public ERichCurveExtrapolation FloatCurvePostInfinityExtrap = ERichCurveExtrapolation.RCCE_Constant;

	// Token: 0x04000569 RID: 1385
	public ERichCurveExtrapolation FloatCurvePreInfinityExtrap = ERichCurveExtrapolation.RCCE_Constant;
}
