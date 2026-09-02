using System;
using System.Runtime.CompilerServices;

// Token: 0x02002F66 RID: 12134
[NullableContext(1)]
[Nullable(0)]
public class DamageAmplifyOnBeHit : BuffEffect, IStaticVariableResetter
{
	// Token: 0x06018CC2 RID: 101570 RVA: 0x00702FCB File Offset: 0x007011CB
	static DamageAmplifyOnBeHit()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(DamageAmplifyOnBeHit.CreateStaticDefaultValue), new Action(DamageAmplifyOnBeHit.ResetStaticDefaultValue));
	}

	// Token: 0x06018CC3 RID: 101571 RVA: 0x00702FEA File Offset: 0x007011EA
	public DamageAmplifyOnBeHit(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018CC4 RID: 101572 RVA: 0x00702FF9 File Offset: 0x007011F9
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		this.Value = AbilityUtils.GetLevelValue<float>(parameters.ExtraEffectGrowParameters1, this.Level, 0f);
	}

	// Token: 0x06018CC5 RID: 101573 RVA: 0x00703017 File Offset: 0x00701217
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		float value = this.Value;
		IActiveBuff buff = base.Buff;
		return value * (float)((buff != null) ? buff.StackCount : 1);
	}

	// Token: 0x06018CC6 RID: 101574 RVA: 0x00703038 File Offset: 0x00701238
	public static float ApplyEffects(RequirementPayload requirements, SnapshotPayload snapshots)
	{
		CharacterBuffComponent ownerBuffComponent = snapshots.Attacker.OwnerBuffComponent;
		BaseBuffComponent ownerBuffComponent2 = snapshots.Target.OwnerBuffComponent;
		float num = 0f;
		foreach (DamageAmplifyOnBeHit damageAmplifyOnBeHit in ownerBuffComponent2.BuffEffectManager.FilterById<DamageAmplifyOnBeHit>(EExtraEffectId.DamageAmplifyOnBeHit, null))
		{
			if (damageAmplifyOnBeHit.Check(requirements, ownerBuffComponent))
			{
				object obj = damageAmplifyOnBeHit.Execute(Array.Empty<object>());
				if (obj is float)
				{
					float num2 = (float)obj;
					num += num2;
				}
			}
		}
		return num;
	}

	// Token: 0x06018CC7 RID: 101575 RVA: 0x007030D4 File Offset: 0x007012D4
	public override string GetDebugEffectString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(12, 1);
		defaultInterpolatedStringHandler.AppendLiteral("持有者受击时伤害加深 ");
		float value = this.Value;
		IActiveBuff buff = base.Buff;
		defaultInterpolatedStringHandler.AppendFormatted<float>(value * (float)((buff != null) ? buff.StackCount : 1) * 0.0001f * 100f);
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06018CC8 RID: 101576 RVA: 0x00703137 File Offset: 0x00701337
	public static void CreateStaticDefaultValue()
	{
		DamageAmplifyOnBeHit.TempModifiedResult = 0f;
	}

	// Token: 0x06018CC9 RID: 101577 RVA: 0x00703143 File Offset: 0x00701343
	public static void ResetStaticDefaultValue()
	{
		DamageAmplifyOnBeHit.TempModifiedResult = 0f;
	}

	// Token: 0x0400C164 RID: 49508
	public float Value;

	// Token: 0x0400C165 RID: 49509
	public static float TempModifiedResult;
}
