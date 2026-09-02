using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F46 RID: 12102
[NullableContext(1)]
[Nullable(0)]
public class SpecialEnergyModifier : BuffEffect
{
	// Token: 0x06018C3D RID: 101437 RVA: 0x00700117 File Offset: 0x006FE317
	public SpecialEnergyModifier(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018C3E RID: 101438 RVA: 0x00700128 File Offset: 0x006FE328
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ == null || extraEffectParameters_.Length == 0)
		{
			return;
		}
		string[] array = extraEffectParameters_[0].Split('#', StringSplitOptions.None);
		this.ModifyEnergy = new HashSet<int>();
		for (int i = 0; i < array.Length; i++)
		{
			this.ModifyEnergy.Add(int.Parse(array[i]));
		}
		this.Percent = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
	}

	// Token: 0x06018C3F RID: 101439 RVA: 0x00700199 File Offset: 0x006FE399
	public override void OnCreated()
	{
	}

	// Token: 0x06018C40 RID: 101440 RVA: 0x0070019B File Offset: 0x006FE39B
	public override void OnRemoved(bool bPremature)
	{
	}

	// Token: 0x06018C41 RID: 101441 RVA: 0x007001A0 File Offset: 0x006FE3A0
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length == 0)
		{
			return 0f;
		}
		int item = (int)parameters[0];
		if (this.ModifyEnergy == null || !this.ModifyEnergy.Contains(item))
		{
			return 0f;
		}
		float percent = this.Percent;
		IActiveBuff buff = base.Buff;
		return percent * (float)((buff != null) ? buff.StackCount : 1);
	}

	// Token: 0x06018C42 RID: 101442 RVA: 0x00700208 File Offset: 0x006FE408
	public override string GetDebugEffectString()
	{
		if (this.ModifyEnergy != null)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 2);
			defaultInterpolatedStringHandler.AppendLiteral("结算特殊能量获取系数加成:生效能量ID");
			defaultInterpolatedStringHandler.AppendFormatted(string.Join<int>(",", this.ModifyEnergy));
			defaultInterpolatedStringHandler.AppendLiteral(", 加成系数");
			defaultInterpolatedStringHandler.AppendFormatted<float>(this.Percent);
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		return "";
	}

	// Token: 0x06018C43 RID: 101443 RVA: 0x00700270 File Offset: 0x006FE470
	public static float ApplyEffects([Nullable(2)] Entity attacker, BaseBuffComponent buffComp, EAttributeType attrId, RequirementPayload requirements)
	{
		CharacterBuffComponent characterBuffComponent = (attacker != null) ? attacker.GetComponent<CharacterBuffComponent>() : null;
		ExtraEffectManager extraEffectManager = (characterBuffComponent != null) ? characterBuffComponent.BuffEffectManager : null;
		if (extraEffectManager == null)
		{
			return 0f;
		}
		float num = 0f;
		foreach (SpecialEnergyModifier specialEnergyModifier in extraEffectManager.FilterById<SpecialEnergyModifier>(EExtraEffectId.SpecialEnergyModifier, null))
		{
			if (specialEnergyModifier.Check(requirements, buffComp))
			{
				num += (float)(specialEnergyModifier.Execute(new object[]
				{
					(int)attrId
				}) ?? 0f);
			}
		}
		if (characterBuffComponent != null && characterBuffComponent.IsRoleBuffComponent())
		{
			RoleBuffComponent roleBuffComponent = characterBuffComponent as RoleBuffComponent;
			if (roleBuffComponent != null && roleBuffComponent.HasBuffAuthority())
			{
				PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
				if (((formationBuffComp != null) ? formationBuffComp.BuffEffectManager : null) != null)
				{
					foreach (SpecialEnergyModifier specialEnergyModifier2 in formationBuffComp.BuffEffectManager.FilterById<SpecialEnergyModifier>(EExtraEffectId.SpecialEnergyModifier, null))
					{
						if (specialEnergyModifier2.Check(requirements, buffComp))
						{
							num += (float)(specialEnergyModifier2.Execute(new object[]
							{
								(int)attrId
							}) ?? 0f);
						}
					}
				}
			}
		}
		return num;
	}

	// Token: 0x0400C0E4 RID: 49380
	[Nullable(2)]
	protected HashSet<int> ModifyEnergy;

	// Token: 0x0400C0E5 RID: 49381
	protected float Percent;
}
