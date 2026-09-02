using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Pawn.Component
{
	// Token: 0x020048B4 RID: 18612
	[NullableContext(2)]
	[Nullable(0)]
	public class TimeScale
	{
		// Token: 0x06030843 RID: 198723 RVA: 0x00BE9708 File Offset: 0x00BE7908
		public TimeScale(double startTime, double endTime, int priority, float timeDilation, UCurveFloat timeCurveFloat, float duration, int id, ETimeScaleSourceType sourceType, ETimeScaleSourceGroup sourceTypeGroup, bool needAddSceneItemTag = false, bool immuneSelfCenter = false)
		{
		}

		// Token: 0x06030844 RID: 198724 RVA: 0x00BE9770 File Offset: 0x00BE7970
		private void ReadCurveTimeRange()
		{
			float num = 0f;
			float num2 = 0f;
			this.TimeCurveFloat.GetTimeRange(ref num, ref num2);
			this.CurveTimeRangeMinInternal = new double?((double)num);
			this.CurveTimeRangeMaxInternal = new double?((double)num2);
		}

		// Token: 0x170082B9 RID: 33465
		// (get) Token: 0x06030845 RID: 198725 RVA: 0x00BE97B2 File Offset: 0x00BE79B2
		public double CurveTimeRangeMin
		{
			get
			{
				if (this.CurveTimeRangeMinInternal == null)
				{
					this.ReadCurveTimeRange();
				}
				return this.CurveTimeRangeMinInternal.GetValueOrDefault(double.NegativeInfinity);
			}
		}

		// Token: 0x170082BA RID: 33466
		// (get) Token: 0x06030846 RID: 198726 RVA: 0x00BE97DB File Offset: 0x00BE79DB
		public double CurveTimeRangeMax
		{
			get
			{
				if (this.CurveTimeRangeMaxInternal == null)
				{
					this.ReadCurveTimeRange();
				}
				return this.CurveTimeRangeMaxInternal.GetValueOrDefault(double.PositiveInfinity);
			}
		}

		// Token: 0x06030847 RID: 198727 RVA: 0x00BE9804 File Offset: 0x00BE7A04
		private void ReadCurveValueRange()
		{
			float num = 0f;
			float num2 = 0f;
			this.TimeCurveFloat.GetValueRange(ref num, ref num2);
			this.CurveValueRangeMinInternal = new double?((double)num);
			this.CurveValueRangeMaxInternal = new double?((double)num2);
		}

		// Token: 0x170082BB RID: 33467
		// (get) Token: 0x06030848 RID: 198728 RVA: 0x00BE9846 File Offset: 0x00BE7A46
		private double CurveValueRangeMin
		{
			get
			{
				if (this.CurveValueRangeMinInternal == null)
				{
					this.ReadCurveValueRange();
				}
				return this.CurveValueRangeMinInternal.GetValueOrDefault(double.NegativeInfinity);
			}
		}

		// Token: 0x170082BC RID: 33468
		// (get) Token: 0x06030849 RID: 198729 RVA: 0x00BE986F File Offset: 0x00BE7A6F
		private double CurveValueRangeMax
		{
			get
			{
				if (this.CurveValueRangeMaxInternal == null)
				{
					this.ReadCurveValueRange();
				}
				return this.CurveValueRangeMaxInternal.GetValueOrDefault(double.PositiveInfinity);
			}
		}

		// Token: 0x0603084A RID: 198730 RVA: 0x00BE9898 File Offset: 0x00BE7A98
		public double GetCurrentTime()
		{
			if (!this.ImmuneSelfCenter)
			{
				return Singleton<Time>.Instance.WorldTimeSeconds;
			}
			return Singleton<Time>.Instance.PlayerWorldTimeSeconds;
		}

		// Token: 0x0603084B RID: 198731 RVA: 0x00BE98B8 File Offset: 0x00BE7AB8
		public float CalculateTimeScale()
		{
			if (this.TimeCurveFloat != null)
			{
				double curveTimeRangeMin = this.CurveTimeRangeMin;
				double curveTimeRangeMax = this.CurveTimeRangeMax;
				double value = (this.GetCurrentTime() - this.StartTime) / (double)this.Duration;
				double num = Singleton<MathUtils>.Instance.RangeClamp(value, 0.0, 1.0, curveTimeRangeMin, curveTimeRangeMax);
				float floatValue = this.TimeCurveFloat.GetFloatValue((float)num);
				double num2 = Singleton<MathUtils>.Instance.RangeClamp((double)floatValue, this.CurveValueRangeMin, this.CurveValueRangeMax, 0.0, 1.0);
				return (float)(1.0 - num2 * (double)(1f - this.TimeDilation));
			}
			return this.TimeDilation;
		}

		// Token: 0x0401BE1D RID: 114205
		public readonly double StartTime = startTime;

		// Token: 0x0401BE1E RID: 114206
		public readonly double EndTime = endTime;

		// Token: 0x0401BE1F RID: 114207
		public readonly int Priority = priority;

		// Token: 0x0401BE20 RID: 114208
		public readonly float TimeDilation = timeDilation;

		// Token: 0x0401BE21 RID: 114209
		public readonly UCurveFloat TimeCurveFloat = timeCurveFloat;

		// Token: 0x0401BE22 RID: 114210
		public readonly float Duration = duration;

		// Token: 0x0401BE23 RID: 114211
		public readonly int Id = id;

		// Token: 0x0401BE24 RID: 114212
		public readonly ETimeScaleSourceType SourceType = sourceType;

		// Token: 0x0401BE25 RID: 114213
		public readonly ETimeScaleSourceGroup SourceTypeGroup = sourceTypeGroup;

		// Token: 0x0401BE26 RID: 114214
		public readonly bool NeedAddSceneItemTag = needAddSceneItemTag;

		// Token: 0x0401BE27 RID: 114215
		public readonly bool ImmuneSelfCenter = immuneSelfCenter;

		// Token: 0x0401BE28 RID: 114216
		public bool MarkDelete;

		// Token: 0x0401BE29 RID: 114217
		private double? CurveTimeRangeMinInternal;

		// Token: 0x0401BE2A RID: 114218
		private double? CurveTimeRangeMaxInternal;

		// Token: 0x0401BE2B RID: 114219
		private double? CurveValueRangeMinInternal;

		// Token: 0x0401BE2C RID: 114220
		private double? CurveValueRangeMaxInternal;
	}
}
