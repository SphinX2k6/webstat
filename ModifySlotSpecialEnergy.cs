using System;
using System.Reflection;
using System.Runtime.CompilerServices;

// Token: 0x02002F87 RID: 12167
[NullableContext(1)]
[Nullable(0)]
public class ModifySlotSpecialEnergy : PeriodExecution
{
	// Token: 0x06018D46 RID: 101702 RVA: 0x0070723E File Offset: 0x0070543E
	public ModifySlotSpecialEnergy(RequireAndLimits requireAndLimits) : base(requireAndLimits)
	{
	}

	// Token: 0x06018D47 RID: 101703 RVA: 0x00707254 File Offset: 0x00705454
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null)
		{
			this.NumberParams = Array.Empty<int>();
			return;
		}
		this.NumberParams = new int[extraEffectParameters_.Length];
		for (int i = 0; i < extraEffectParameters_.Length; i++)
		{
			this.NumberParams[i] = int.Parse(extraEffectParameters_[i]);
		}
	}

	// Token: 0x06018D48 RID: 101704 RVA: 0x007072A4 File Offset: 0x007054A4
	[return: Nullable(2)]
	public override object OnExecute(params object[] args)
	{
		if (base.OwnerEntity != null)
		{
			int num = (this.NumberParams.Length != 0) ? this.NumberParams[0] : -1;
			if (num <= -1 || num >= 1)
			{
				return null;
			}
			CharacterSpecialSkillComponent component = base.OwnerEntity.GetComponent<CharacterSpecialSkillComponent>();
			SpecialSkillBase specialSkillBase = (component != null) ? component.SpecialSkill : null;
			if (specialSkillBase != null)
			{
				MethodInfo method = specialSkillBase.GetType().GetMethod("ModifySlotSpecialEnergy", new Type[]
				{
					typeof(int[])
				});
				if (method != null)
				{
					method.Invoke(specialSkillBase, new object[]
					{
						this.NumberParams
					});
				}
			}
		}
		return null;
	}

	// Token: 0x06018D49 RID: 101705 RVA: 0x00707334 File Offset: 0x00705534
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(15, 2);
		defaultInterpolatedStringHandler.AppendLiteral("buff");
		defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
		defaultInterpolatedStringHandler.AppendLiteral(" 修改槽位型特殊能量 ");
		defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(",", this.NumberParams));
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C1C5 RID: 49605
	private int[] NumberParams = Array.Empty<int>();
}
