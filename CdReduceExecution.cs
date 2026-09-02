using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F73 RID: 12147
[NullableContext(1)]
[Nullable(0)]
public class CdReduceExecution : PeriodExecution
{
	// Token: 0x06018CFF RID: 101631 RVA: 0x007041D0 File Offset: 0x007023D0
	public CdReduceExecution(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D00 RID: 101632 RVA: 0x007041DC File Offset: 0x007023DC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			this.SkillIds = Array.Empty<long>();
			this.CdResetType = ESkillCdReduceType.SpecifiedSkillId;
			this.DecreaseRatio = parameters.ExtraEffectGrowParameters1;
			this.DecreaseMagnitude = parameters.ExtraEffectGrowParameters2;
			return;
		}
		if (!string.IsNullOrEmpty(extraEffectParameters_[0]))
		{
			string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
			this.SkillIds = new long[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				this.SkillIds[i] = long.Parse(array[i]);
			}
		}
		else
		{
			this.SkillIds = Array.Empty<long>();
		}
		string s = (extraEffectParameters_.Length > 1 && !string.IsNullOrEmpty(extraEffectParameters_[1])) ? extraEffectParameters_[1] : 0.ToString();
		this.CdResetType = (ESkillCdReduceType)int.Parse(s);
		this.DecreaseRatio = parameters.ExtraEffectGrowParameters1;
		this.DecreaseMagnitude = parameters.ExtraEffectGrowParameters2;
	}

	// Token: 0x06018D01 RID: 101633 RVA: 0x007042B8 File Offset: 0x007024B8
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		BaseBuffComponent component = base.ExactOwnerEntity.GetComponent<BaseBuffComponent>();
		List<CharacterSkillCdComponent> list = ((component != null) ? component.GetTargetComponents<CharacterSkillCdComponent>(EComponent.CharacterSkillCdComponent, null) : null) ?? new List<CharacterSkillCdComponent>();
		float num = AbilityUtils.GetLevelValue<float>(this.DecreaseRatio, this.Level, 0f) * 0.0001f;
		float levelValue = AbilityUtils.GetLevelValue<float>(this.DecreaseMagnitude, this.Level, 0f);
		foreach (CharacterSkillCdComponent characterSkillCdComponent in list)
		{
			if (characterSkillCdComponent != null)
			{
				ESkillCdReduceType cdResetType = this.CdResetType;
				if (cdResetType != ESkillCdReduceType.SpecifiedSkillId)
				{
					if (cdResetType == ESkillCdReduceType.SpecifiedSkillGenre)
					{
						characterSkillCdComponent.ModifyCdTimeBySkillGenres(Array.ConvertAll<long, int>(this.SkillIds ?? Array.Empty<long>(), (long id) => (int)id), -levelValue, -num);
					}
				}
				else
				{
					characterSkillCdComponent.ModifyCdTime(this.SkillIds ?? Array.Empty<long>(), -levelValue, -num);
				}
			}
		}
		return null;
	}

	// Token: 0x0400C17D RID: 49533
	[Nullable(2)]
	private long[] SkillIds;

	// Token: 0x0400C17E RID: 49534
	private ESkillCdReduceType CdResetType;

	// Token: 0x0400C17F RID: 49535
	[Nullable(2)]
	private float[] DecreaseRatio;

	// Token: 0x0400C180 RID: 49536
	[Nullable(2)]
	private float[] DecreaseMagnitude;
}
