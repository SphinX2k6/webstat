using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F74 RID: 12148
[NullableContext(1)]
[Nullable(0)]
public class ExtendBuffDurationExecution : PeriodExecution
{
	// Token: 0x06018D02 RID: 101634 RVA: 0x007043D8 File Offset: 0x007025D8
	public ExtendBuffDurationExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D03 RID: 101635 RVA: 0x007043EC File Offset: 0x007025EC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			return;
		}
		if (extraEffectParameters_.Length != 0 && !string.IsNullOrEmpty(extraEffectParameters_[0]))
		{
			this.TargetType = (EExecutionTargetType)int.Parse(extraEffectParameters_[0]);
		}
		if (extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1]))
		{
			string[] array = extraEffectParameters_[1].Split('#', StringSplitOptions.None);
			this.BuffIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.BuffIds[i] = long.Parse(array[i]);
			}
		}
		else
		{
			this.BuffIds = Array.Empty<long>();
		}
		if (extraEffectParameters_.Length > 2 && !string.IsNullOrEmpty(extraEffectParameters_[2]))
		{
			string[] array2 = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
			this.DurationLimit = new float[array2.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				this.DurationLimit[j] = float.Parse(array2[j]);
			}
		}
		else
		{
			this.DurationLimit = null;
		}
		this.ExtendRatio = parameters.ExtraEffectGrowParameters1;
		this.ExtendMagnitude = parameters.ExtraEffectGrowParameters2;
	}

	// Token: 0x06018D04 RID: 101636 RVA: 0x007044E4 File Offset: 0x007026E4
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		IBuffComponent effectTarget = base.GetEffectTarget();
		if (effectTarget == null || !effectTarget.HasBuffAuthority())
		{
			return null;
		}
		float num = AbilityUtils.GetLevelValue<float>(this.ExtendRatio, this.Level, 0f) * 0.0001f;
		float num2 = AbilityUtils.GetLevelValue<float>(this.ExtendMagnitude, this.Level, 0f) * (float)Singleton<TimeUtil>.Instance.Millisecond;
		foreach (long buffId in this.BuffIds)
		{
			ActiveBuffInternal buffById = effectTarget.GetBuffById(buffId);
			if (buffById != null)
			{
				float remainDuration = buffById.GetRemainDuration();
				if (remainDuration > 0f)
				{
					float num3 = Math.Max(remainDuration * (1f + num) + num2, 0.0001f);
					if (this.DurationLimit != null && this.DurationLimit.Length != 0 && this.DurationLimit[0] > 0f)
					{
						num3 = Math.Max(num3, this.DurationLimit[0] * (float)Singleton<TimeUtil>.Instance.Millisecond);
					}
					if (this.DurationLimit != null && this.DurationLimit.Length > 1 && this.DurationLimit[1] > 0f)
					{
						num3 = Math.Min(num3, this.DurationLimit[1] * (float)Singleton<TimeUtil>.Instance.Millisecond);
					}
					buffById.SetDuration(new float?(num3));
				}
			}
		}
		return null;
	}

	// Token: 0x0400C181 RID: 49537
	private long[] BuffIds = Array.Empty<long>();

	// Token: 0x0400C182 RID: 49538
	[Nullable(2)]
	private float[] ExtendRatio;

	// Token: 0x0400C183 RID: 49539
	[Nullable(2)]
	private float[] ExtendMagnitude;

	// Token: 0x0400C184 RID: 49540
	[Nullable(2)]
	private float[] DurationLimit;
}
