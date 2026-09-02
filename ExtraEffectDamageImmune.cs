using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;

// Token: 0x02002F1E RID: 12062
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectDamageImmune : BuffEffect
{
	// Token: 0x06018B53 RID: 101203 RVA: 0x006F9F8E File Offset: 0x006F818E
	public ExtraEffectDamageImmune(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B54 RID: 101204 RVA: 0x006F9FAC File Offset: 0x006F81AC
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		for (int i = 0; i < extraEffectParameters_.Length; i++)
		{
			EElementType eelementType = (EElementType)int.Parse(extraEffectParameters_[i]);
			this.ImmuneElements[(int)eelementType] = true;
		}
	}

	// Token: 0x06018B55 RID: 101205 RVA: 0x006F9FE0 File Offset: 0x006F81E0
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length != 0)
		{
			TDamageParam tdamageParam = parameters[0] as TDamageParam;
			if (tdamageParam != null)
			{
				return this.ImmuneElements[(int)tdamageParam.Element];
			}
		}
		return false;
	}

	// Token: 0x06018B56 RID: 101206 RVA: 0x006FA018 File Offset: 0x006F8218
	public static bool ApplyEffects(RequirementPayload requirements, TDamageParam inputParam, SnapshotPayload snapshots)
	{
		CharacterBuffComponent ownerBuffComponent = snapshots.Attacker.OwnerBuffComponent;
		foreach (ExtraEffectDamageImmune extraEffectDamageImmune in snapshots.Target.OwnerBuffComponent.BuffEffectManager.FilterById<ExtraEffectDamageImmune>(EExtraEffectId.DamageImmune, null))
		{
			if (extraEffectDamageImmune.Check(requirements, ownerBuffComponent) == ((bool?)extraEffectDamageImmune.Execute(new object[]
			{
				inputParam
			})).GetValueOrDefault())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0400C068 RID: 49256
	private bool[] ImmuneElements = new bool[7];
}
