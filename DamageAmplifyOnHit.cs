using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F65 RID: 12133
[NullableContext(1)]
[Nullable(0)]
public class DamageAmplifyOnHit : BuffEffect, IStaticVariableResetter
{
	// Token: 0x06018CBA RID: 101562 RVA: 0x00702E44 File Offset: 0x00701044
	static DamageAmplifyOnHit()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(DamageAmplifyOnHit.CreateStaticDefaultValue), new Action(DamageAmplifyOnHit.ResetStaticDefaultValue));
	}

	// Token: 0x06018CBB RID: 101563 RVA: 0x00702E63 File Offset: 0x00701063
	public DamageAmplifyOnHit(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CBC RID: 101564 RVA: 0x00702E72 File Offset: 0x00701072
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		this.Value = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
	}

	// Token: 0x06018CBD RID: 101565 RVA: 0x00702E90 File Offset: 0x00701090
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		float value = this.Value;
		IActiveBuff buff = base.Buff;
		return value * (float)((buff != null) ? buff.StackCount : 1);
	}

	// Token: 0x06018CBE RID: 101566 RVA: 0x00702EB4 File Offset: 0x007010B4
	public static float ApplyEffects(RequirementPayload requirements, SnapshotPayload snapshots)
	{
		BaseBuffComponent ownerBuffComponent = snapshots.Attacker.OwnerBuffComponent;
		CharacterBuffComponent ownerBuffComponent2 = snapshots.Target.OwnerBuffComponent;
		float num = 0f;
		foreach (DamageAmplifyOnHit damageAmplifyOnHit in ownerBuffComponent.BuffEffectManager.FilterById<DamageAmplifyOnHit>(EExtraEffectId.DamageAmplifyOnHit, null))
		{
			if (damageAmplifyOnHit.Check(requirements, ownerBuffComponent2))
			{
				object obj = damageAmplifyOnHit.Execute(Array.Empty<object>());
				if (obj is float)
				{
					float num2 = (float)obj;
					num += num2;
				}
			}
		}
		return num;
	}

	// Token: 0x06018CBF RID: 101567 RVA: 0x00702F50 File Offset: 0x00701150
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("持有者攻击时伤害加深 ");
		float value = this.Value;
		IActiveBuff buff = base.Buff;
		defaultInterpolatedStringHandler.AppendFormatted<float>(value * (float)((buff != null) ? buff.StackCount : 1) * 0.0001f * 100f);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06018CC0 RID: 101568 RVA: 0x00702FB3 File Offset: 0x007011B3
	public static void CreateStaticDefaultValue()
	{
		DamageAmplifyOnHit.TempModifiedResult = 0f;
	}

	// Token: 0x06018CC1 RID: 101569 RVA: 0x00702FBF File Offset: 0x007011BF
	public static void ResetStaticDefaultValue()
	{
		DamageAmplifyOnHit.TempModifiedResult = 0f;
	}

	// Token: 0x0400C162 RID: 49506
	public float Value;

	// Token: 0x0400C163 RID: 49507
	public static float TempModifiedResult;
}
