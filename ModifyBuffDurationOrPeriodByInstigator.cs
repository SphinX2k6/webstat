using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F3C RID: 12092
[NullableContext(1)]
[Nullable(0)]
public class ModifyBuffDurationOrPeriodByInstigator : BuffEffect
{
	// Token: 0x06018BFE RID: 101374 RVA: 0x006FE9C4 File Offset: 0x006FCBC4
	public ModifyBuffDurationOrPeriodByInstigator(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BFF RID: 101375 RVA: 0x006FE9E0 File Offset: 0x006FCBE0
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.DurationRate = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
		this.PeriodRate = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters2, this.Level, 0f);
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
			this.InvolvedBuffIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.InvolvedBuffIds[i] = long.Parse(array[i].Trim());
			}
		}
	}

	// Token: 0x06018C00 RID: 101376 RVA: 0x006FEA70 File Offset: 0x006FCC70
	public override void OnCreated()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent != null && (this.DurationRate != 0f || this.PeriodRate != 0f))
		{
			foreach (long targetBuffId in this.InvolvedBuffIds)
			{
				ownerBuffComponent.AddBuffTimeModifier(targetBuffId, this.ActiveHandleId, this.PeriodRate, this.DurationRate, true);
			}
		}
	}

	// Token: 0x06018C01 RID: 101377 RVA: 0x006FEAD4 File Offset: 0x006FCCD4
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018C02 RID: 101378 RVA: 0x006FEAD8 File Offset: 0x006FCCD8
	public override void OnRemoved(bool bPremature)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent != null)
		{
			foreach (long targetBuffId in this.InvolvedBuffIds)
			{
				ownerBuffComponent.RemoveBuffTimeModifier(targetBuffId, this.ActiveHandleId, true);
			}
		}
	}

	// Token: 0x06018C03 RID: 101379 RVA: 0x006FEB18 File Offset: 0x006FCD18
	public override string GetDebugEffectString()
	{
		string str = "修改由该持有者施加的buff" + string.Join<long>(",", this.InvolvedBuffIds);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(6, 2);
		defaultInterpolatedStringHandler.AppendLiteral(" 持续时间");
		defaultInterpolatedStringHandler.AppendFormatted((this.DurationRate >= 0f) ? "+" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>((double)this.DurationRate * 0.01, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("%");
		string str2 = str + defaultInterpolatedStringHandler.ToStringAndClear();
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(4, 2);
		defaultInterpolatedStringHandler.AppendLiteral(" 周期");
		defaultInterpolatedStringHandler.AppendFormatted((this.DurationRate >= 0f) ? "+" : "");
		defaultInterpolatedStringHandler.AppendFormatted<double>((double)this.PeriodRate * 0.01, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return str2 + defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0BE RID: 49342
	protected long[] InvolvedBuffIds = Array.Empty<long>();

	// Token: 0x0400C0BF RID: 49343
	protected float DurationRate;

	// Token: 0x0400C0C0 RID: 49344
	protected float PeriodRate;
}
