using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F81 RID: 12161
[NullableContext(1)]
[Nullable(0)]
public class ConvertBuffToAnother : PeriodExecution
{
	// Token: 0x06018D34 RID: 101684 RVA: 0x00706902 File Offset: 0x00704B02
	public ConvertBuffToAnother(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D35 RID: 101685 RVA: 0x00706918 File Offset: 0x00704B18
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			this.SourceBuffIds = Array.Empty<long>();
			this.TargetBuffId = 0L;
			this.SaveSourceBuff = false;
			return;
		}
		if (!string.IsNullOrEmpty(extraEffectParameters_[0]))
		{
			string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
			this.SourceBuffIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.SourceBuffIds[i] = long.Parse(array[i]);
			}
		}
		else
		{
			this.SourceBuffIds = Array.Empty<long>();
		}
		this.TargetBuffId = ((extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1])) ? long.Parse(extraEffectParameters_[1]) : 0L);
		this.SaveSourceBuff = (extraEffectParameters_.Length > 2 && !string.IsNullOrEmpty(extraEffectParameters_[2]) && int.Parse(extraEffectParameters_[2]) == 1);
	}

	// Token: 0x06018D36 RID: 101686 RVA: 0x007069E4 File Offset: 0x00704BE4
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		if (ownerBuffComponent == null)
		{
			return null;
		}
		int num = 0;
		for (int i = 0; i < this.SourceBuffIds.Length; i++)
		{
			num += ownerBuffComponent.GetBuffTotalStackById(this.SourceBuffIds[i], false);
		}
		if (!this.SaveSourceBuff)
		{
			for (int j = 0; j < this.SourceBuffIds.Length; j++)
			{
				ownerBuffComponent.RemoveBuff(this.SourceBuffIds[j], -1, "Buff转换效果", null, null, null);
			}
		}
		if (num == 0)
		{
			return null;
		}
		if (this.TargetBuffId > 0L)
		{
			ownerBuffComponent.AddIterativeBuff(this.TargetBuffId, this.Buff, new int?(num), true, "Buff转换效果", null, null);
		}
		return null;
	}

	// Token: 0x0400C1B7 RID: 49591
	private long[] SourceBuffIds = Array.Empty<long>();

	// Token: 0x0400C1B8 RID: 49592
	private long TargetBuffId;

	// Token: 0x0400C1B9 RID: 49593
	private bool SaveSourceBuff;
}
