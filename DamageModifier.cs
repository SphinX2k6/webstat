using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002F1F RID: 12063
[NullableContext(1)]
[Nullable(0)]
public class DamageModifier : ModifierCalculator, IStaticVariableResetter
{
	// Token: 0x06018B57 RID: 101207 RVA: 0x006FA0AC File Offset: 0x006F82AC
	static DamageModifier()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(DamageModifier.CreateStaticDefaultValue), new Action(DamageModifier.ResetStaticDefaultValue));
	}

	// Token: 0x06018B58 RID: 101208 RVA: 0x006FA0CB File Offset: 0x006F82CB
	public DamageModifier(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B59 RID: 101209 RVA: 0x006FA0DA File Offset: 0x006F82DA
	protected override bool CheckAuthority()
	{
		IBuffComponent ownerBuffComponent = this.OwnerBuffComponent;
		return ownerBuffComponent != null && ownerBuffComponent.HasBuffAuthority();
	}

	// Token: 0x06018B5A RID: 101210 RVA: 0x006FA0F0 File Offset: 0x006F82F0
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.ModifyTough = (extraEffectParameters_.Length > 3 && !string.IsNullOrEmpty(extraEffectParameters_[3]));
		if (!this.ModifyTough)
		{
			return;
		}
		this.CalculationPolicy = (ESnapCalculateType)int.Parse(extraEffectParameters_[3]);
		this.StackParam = new long[1];
		this.RefParam1 = ((extraEffectParameters_.Length > 4) ? float.Parse(extraEffectParameters_[4]) : 0f);
		if (extraEffectParameters_.Length > 5 && !string.IsNullOrEmpty(extraEffectParameters_[5]))
		{
			string[] array = extraEffectParameters_[5].Split('#', StringSplitOptions.None);
			this.RefAttrId = (EAttributeType)int.Parse(array[0]);
			this.RefTargetType = (ESnapAttributeSourceType)int.Parse(array[1]);
			this.RefValueType = (EAttributeRefType)int.Parse(array[2]);
			this.RefParam2 = float.Parse(array[3]);
			this.ExecuteCountLimit = ((array.Length > 4) ? int.Parse(array[4]) : 0);
			this.ExecuteCount = 0;
		}
		if (extraEffectParameters_.Length > 6 && !string.IsNullOrEmpty(extraEffectParameters_[6]))
		{
			string[] array2 = extraEffectParameters_[6].Split('#', StringSplitOptions.None);
			this.UpperBound = (((array2.Length > 2) ? int.Parse(array2[2]) : 0) == 1);
		}
	}

	// Token: 0x06018B5B RID: 101211 RVA: 0x006FA204 File Offset: 0x006F8404
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length >= 2)
		{
			SnapshotPayload snapshotPayload = parameters[0] as SnapshotPayload;
			if (snapshotPayload != null)
			{
				object obj = parameters[1];
				if (obj is float)
				{
					float num = (float)obj;
					if (!this.ModifyTough || (this.ExecuteCount >= this.ExecuteCountLimit && this.ExecuteCountLimit > 0))
					{
						return -1f;
					}
					float num2 = base.CalculateValue(snapshotPayload);
					if (!this.UpperBound)
					{
						this.ExecuteCount++;
						return num2;
					}
					if (num2 < num)
					{
						this.ExecuteCount++;
						return num2;
					}
					return num;
				}
			}
		}
		return -1f;
	}

	// Token: 0x06018B5C RID: 101212 RVA: 0x006FA2B4 File Offset: 0x006F84B4
	[return: Nullable(2)]
	private static DamageModifier GetLatestModifier([Nullable(2)] BaseBuffComponent victim, BaseBuffComponent attacker, RequirementPayload requirements)
	{
		if (victim == null || victim.BuffEffectManager == null)
		{
			return null;
		}
		DamageModifier result = null;
		foreach (DamageModifier damageModifier in victim.BuffEffectManager.FilterById<DamageModifier>(EExtraEffectId.DamageModify, null))
		{
			if (damageModifier.Check(requirements, attacker))
			{
				result = damageModifier;
			}
		}
		return result;
	}

	// Token: 0x06018B5D RID: 101213 RVA: 0x006FA320 File Offset: 0x006F8520
	[NullableContext(2)]
	private static DamageModifier CompareLatestModifier(DamageModifier modifier1, DamageModifier modifier2)
	{
		if (modifier1 == null || modifier1.Buff == null)
		{
			return modifier2;
		}
		if (modifier2 == null || modifier2.Buff == null)
		{
			return modifier1;
		}
		if (modifier1.Buff.CreateTimestamp <= modifier2.Buff.CreateTimestamp)
		{
			return modifier2;
		}
		return modifier1;
	}

	// Token: 0x06018B5E RID: 101214 RVA: 0x006FA358 File Offset: 0x006F8558
	public static float ApplyEffects(RequirementPayload requirements, SnapshotPayload snapshots, float toughResult)
	{
		CharacterBuffComponent ownerBuffComponent = snapshots.Attacker.OwnerBuffComponent;
		DamageModifier latestModifier = DamageModifier.GetLatestModifier(snapshots.Target.OwnerBuffComponent, ownerBuffComponent, requirements);
		WorldEntity playerEntity = ControllerBase<FormationDataController>.Instance.GetPlayerEntity(ModelBase<CreatureModel>.Instance.GetPlayerId());
		DamageModifier latestModifier2 = DamageModifier.GetLatestModifier((playerEntity != null) ? playerEntity.GetComponent<PlayerBuffComponent>() : null, ownerBuffComponent, requirements);
		DamageModifier damageModifier = DamageModifier.CompareLatestModifier(latestModifier, latestModifier2);
		if (damageModifier == null)
		{
			return toughResult;
		}
		float num = (float)(damageModifier.Execute(new object[]
		{
			snapshots,
			toughResult
		}) ?? 0f);
		if (num < 0f)
		{
			return toughResult;
		}
		return num;
	}

	// Token: 0x06018B5F RID: 101215 RVA: 0x006FA3EF File Offset: 0x006F85EF
	public static void CreateStaticDefaultValue()
	{
		DamageModifier.TempModifiedResult = 0f;
	}

	// Token: 0x06018B60 RID: 101216 RVA: 0x006FA3FB File Offset: 0x006F85FB
	public static void ResetStaticDefaultValue()
	{
		DamageModifier.TempModifiedResult = 0f;
	}

	// Token: 0x0400C069 RID: 49257
	public float Value;

	// Token: 0x0400C06A RID: 49258
	public static float TempModifiedResult;

	// Token: 0x0400C06B RID: 49259
	public bool ModifyTough;

	// Token: 0x0400C06C RID: 49260
	public bool UpperBound;

	// Token: 0x0400C06D RID: 49261
	private int ExecuteCount;

	// Token: 0x0400C06E RID: 49262
	private int ExecuteCountLimit;
}
