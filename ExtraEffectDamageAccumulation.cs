using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x02002F1B RID: 12059
[NullableContext(1)]
[Nullable(0)]
public class ExtraEffectDamageAccumulation : BuffEffect, IStaticVariableResetter
{
	// Token: 0x06018B39 RID: 101177 RVA: 0x006F955F File Offset: 0x006F775F
	static ExtraEffectDamageAccumulation()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ExtraEffectDamageAccumulation.CreateStaticDefaultValue), new Action(ExtraEffectDamageAccumulation.ResetStaticDefaultValue));
	}

	// Token: 0x17002184 RID: 8580
	// (get) Token: 0x06018B3A RID: 101178 RVA: 0x006F957E File Offset: 0x006F777E
	private static Dictionary<int, float> AccumulationMap
	{
		get
		{
			return ExtraEffectDamageAccumulation._accumulationMap;
		}
	}

	// Token: 0x06018B3B RID: 101179 RVA: 0x006F9585 File Offset: 0x006F7785
	public ExtraEffectDamageAccumulation(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018B3C RID: 101180 RVA: 0x006F95A0 File Offset: 0x006F77A0
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		this.AccumulationType = (EAccumulationType)int.Parse(extraEffectParameters_[0]);
		this.GoalType = (EPassiveEffectGoalType)int.Parse(extraEffectParameters_[1]);
		string[] array = extraEffectParameters_[2].Split('#', StringSplitOptions.None);
		this.Ids = new long[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			this.Ids[i] = long.Parse(array[i]);
		}
		string[] array2 = ((extraEffectParameters_.Length > 3) ? (extraEffectParameters_[3] ?? "") : "").Split('#', StringSplitOptions.None);
		for (int j = 0; j < array2.Length; j++)
		{
			if (!string.IsNullOrEmpty(array2[j]))
			{
				this.Triggers |= 1 << int.Parse(array2[j]);
			}
		}
		string[] array3 = ((extraEffectParameters_.Length > 4) ? (extraEffectParameters_[4] ?? "") : "").Split('#', StringSplitOptions.None);
		int num = array3.Length;
		if (num != 1)
		{
			if (num != 2)
			{
				return;
			}
			if (!string.IsNullOrEmpty(array3[0]))
			{
				this.AttributeId = new EAttributeType?((EAttributeType)int.Parse(array3[0]));
			}
			if (!string.IsNullOrEmpty(array3[1]))
			{
				this.Lower = float.Parse(array3[1]);
			}
		}
		else if (!string.IsNullOrEmpty(array3[0]))
		{
			this.Lower = float.Parse(array3[0]);
			return;
		}
	}

	// Token: 0x06018B3D RID: 101181 RVA: 0x006F96E8 File Offset: 0x006F78E8
	public override void OnCreated()
	{
		this.PreTriggerEffect(ExtraEffectDamageAccumulation.ETriggerType.Accumulated);
	}

	// Token: 0x06018B3E RID: 101182 RVA: 0x006F96F1 File Offset: 0x006F78F1
	public override void OnRemoved(bool bPremature)
	{
		if (bPremature)
		{
			this.PreTriggerEffect(ExtraEffectDamageAccumulation.ETriggerType.Premature);
			return;
		}
		this.PreTriggerEffect(ExtraEffectDamageAccumulation.ETriggerType.Expired);
	}

	// Token: 0x06018B3F RID: 101183 RVA: 0x006F9705 File Offset: 0x006F7905
	public override void OnStackDecreased(int newCount, int oldCount, bool bPremature)
	{
		if (newCount < oldCount)
		{
			this.PreTriggerEffect(ExtraEffectDamageAccumulation.ETriggerType.Reduced);
		}
	}

	// Token: 0x06018B40 RID: 101184 RVA: 0x006F9714 File Offset: 0x006F7914
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		if (parameters.Length >= 2)
		{
			object obj = parameters[0];
			if (obj is EAccumulationType)
			{
				EAccumulationType eaccumulationType = (EAccumulationType)obj;
				DamageResult damageResult = parameters[1] as DamageResult;
				if (damageResult != null)
				{
					if (eaccumulationType != this.AccumulationType)
					{
						return null;
					}
					if (damageResult.Damage >= 0f)
					{
						return null;
					}
					this.Accumulation += -damageResult.Damage;
					this.PreTriggerEffect(ExtraEffectDamageAccumulation.ETriggerType.Accumulated);
					return null;
				}
			}
		}
		return null;
	}

	// Token: 0x06018B41 RID: 101185 RVA: 0x006F9780 File Offset: 0x006F7980
	public static void ApplyEffects(DamageResult damageResult, RequirementPayload requirements, BaseDamageComponent attacker, BaseDamageComponent victim)
	{
		BaseBuffComponent[] array = new BaseBuffComponent[]
		{
			victim.OwnerBuffComponent,
			attacker.OwnerBuffComponent
		};
		for (int i = 0; i < array.Length; i++)
		{
			BaseBuffComponent baseBuffComponent = array[i];
			if (baseBuffComponent != null)
			{
				if (baseBuffComponent.IsRoleBuffComponent())
				{
					RoleBuffComponent roleBuffComponent = baseBuffComponent as RoleBuffComponent;
					if (roleBuffComponent != null && roleBuffComponent.HasBuffAuthority())
					{
						PlayerBuffComponent formationBuffComp = roleBuffComponent.GetFormationBuffComp();
						BaseBuffComponent baseBuffComponent2 = array[1 - i];
						if (((formationBuffComp != null) ? formationBuffComp.BuffEffectManager : null) != null && baseBuffComponent2 != null)
						{
							foreach (ExtraEffectDamageAccumulation extraEffectDamageAccumulation in formationBuffComp.BuffEffectManager.FilterById<ExtraEffectDamageAccumulation>(EExtraEffectId.DamageAccumulation, null))
							{
								if (extraEffectDamageAccumulation.Check(requirements, baseBuffComponent2))
								{
									extraEffectDamageAccumulation.Execute(new object[]
									{
										(EAccumulationType)i,
										damageResult
									});
								}
							}
						}
					}
				}
				BaseBuffComponent baseBuffComponent3 = array[1 - i];
				if (baseBuffComponent.BuffEffectManager != null && baseBuffComponent3 != null)
				{
					foreach (ExtraEffectDamageAccumulation extraEffectDamageAccumulation2 in baseBuffComponent.BuffEffectManager.FilterById<ExtraEffectDamageAccumulation>(EExtraEffectId.DamageAccumulation, null))
					{
						if (extraEffectDamageAccumulation2.Check(requirements, baseBuffComponent3))
						{
							extraEffectDamageAccumulation2.Execute(new object[]
							{
								(EAccumulationType)i,
								damageResult
							});
						}
					}
				}
			}
		}
	}

	// Token: 0x06018B42 RID: 101186 RVA: 0x006F98F8 File Offset: 0x006F7AF8
	public static float GetAccumulation(int bulletEntityId)
	{
		float valueOrDefault = ExtraEffectDamageAccumulation.AccumulationMap.GetValueOrDefault(bulletEntityId, 0f);
		ExtraEffectDamageAccumulation.AccumulationMap.Remove(bulletEntityId);
		return valueOrDefault;
	}

	// Token: 0x06018B43 RID: 101187 RVA: 0x006F9916 File Offset: 0x006F7B16
	private bool CheckTriggeredType(ExtraEffectDamageAccumulation.ETriggerType triggerType)
	{
		return (this.Triggers & 1 << (int)triggerType) != 0;
	}

	// Token: 0x06018B44 RID: 101188 RVA: 0x006F9928 File Offset: 0x006F7B28
	private void PreTriggerEffect(ExtraEffectDamageAccumulation.ETriggerType triggerType)
	{
		if (!this.CheckTriggeredType(triggerType))
		{
			return;
		}
		if (triggerType == ExtraEffectDamageAccumulation.ETriggerType.Accumulated)
		{
			float num2;
			if (this.AttributeId != null)
			{
				float num = this.Lower * 0.0001f;
				BaseAttributeComponent component = base.OwnerEntity.GetComponent<BaseAttributeComponent>();
				num2 = ((component != null) ? component.GetBaseValue(this.AttributeId.Value) : 0f) * num;
			}
			else
			{
				num2 = this.Lower;
			}
			if (num2 < this.Accumulation)
			{
				this.TriggerEffect();
				return;
			}
		}
		else
		{
			this.TriggerEffect();
		}
	}

	// Token: 0x06018B45 RID: 101189 RVA: 0x006F99A4 File Offset: 0x006F7BA4
	private void TriggerEffect()
	{
		EPassiveEffectGoalType goalType = this.GoalType;
		if (goalType != EPassiveEffectGoalType.Buff)
		{
			if (goalType == EPassiveEffectGoalType.Bullet)
			{
				this.ExecuteAddBullets();
			}
		}
		else
		{
			this.ExecuteAddBuffs();
		}
		this.Accumulation = 0f;
	}

	// Token: 0x06018B46 RID: 101190 RVA: 0x006F99D8 File Offset: 0x006F7BD8
	private void ExecuteAddBuffs()
	{
		IActiveBuff buffByHandle = this.OwnerBuffComponent.GetBuffByHandle(this.ActiveHandleId);
		if (buffByHandle != null && buffByHandle.IsValid())
		{
			Entity entity = this.OwnerBuffComponent.GetEntity();
			BaseBuffComponent baseBuffComponent = (entity != null) ? entity.CheckGetComponent<BaseBuffComponent>() : null;
			for (int i = 0; i < this.Ids.Length; i++)
			{
				if (baseBuffComponent != null)
				{
					BaseBuffComponent baseBuffComponent2 = baseBuffComponent;
					long buffId = this.Ids[i];
					IActiveBuff preBuff = buffByHandle;
					int? stackCount = null;
					bool isIterable = true;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 2);
					defaultInterpolatedStringHandler.AppendLiteral("因为其它buff额外效果而移除（前置buff Id=");
					defaultInterpolatedStringHandler.AppendFormatted<long>(this.BuffId);
					defaultInterpolatedStringHandler.AppendLiteral(", handle=");
					defaultInterpolatedStringHandler.AppendFormatted<int>(this.ActiveHandleId);
					defaultInterpolatedStringHandler.AppendLiteral("）");
					baseBuffComponent2.AddIterativeBuff(buffId, preBuff, stackCount, isIterable, defaultInterpolatedStringHandler.ToStringAndClear(), null, null);
				}
			}
		}
	}

	// Token: 0x06018B47 RID: 101191 RVA: 0x006F9AAC File Offset: 0x006F7CAC
	private void ExecuteAddBullets()
	{
		CharacterActorComponent component = base.OwnerEntity.GetComponent<CharacterActorComponent>();
		FTransformDouble? initialTransform = (component != null) ? new FTransformDouble?(component.ActorTransform) : null;
		EntityHandle instigatorEntity = base.InstigatorEntity;
		WorldEntity worldEntity = (instigatorEntity != null) ? instigatorEntity.Entity : null;
		if (initialTransform == null || worldEntity == null)
		{
			return;
		}
		long? messageId = base.Buff.MessageId;
		for (int i = 0; i < this.Ids.Length; i++)
		{
			for (int j = 0; j < 1; j++)
			{
				BulletEntity bulletEntity = ControllerBase<BulletController>.Instance.CreateBulletCustomTarget(worldEntity, this.Ids[i].ToString(), initialTransform, new BulletController.BulletCreateParams(), messageId, global::EBulletCreateSource.Others);
				if (bulletEntity != null)
				{
					ExtraEffectDamageAccumulation.AccumulationMap[bulletEntity.Id] = this.Accumulation;
				}
			}
		}
	}

	// Token: 0x06018B48 RID: 101192 RVA: 0x006F9B73 File Offset: 0x006F7D73
	public static void CreateStaticDefaultValue()
	{
		ExtraEffectDamageAccumulation._accumulationMap = new Dictionary<int, float>();
	}

	// Token: 0x06018B49 RID: 101193 RVA: 0x006F9B7F File Offset: 0x006F7D7F
	public static void ResetStaticDefaultValue()
	{
		ExtraEffectDamageAccumulation._accumulationMap = null;
	}

	// Token: 0x0400C05A RID: 49242
	private float Accumulation;

	// Token: 0x0400C05B RID: 49243
	[Nullable(2)]
	private static Dictionary<int, float> _accumulationMap;

	// Token: 0x0400C05C RID: 49244
	private EAccumulationType AccumulationType;

	// Token: 0x0400C05D RID: 49245
	private EPassiveEffectGoalType GoalType;

	// Token: 0x0400C05E RID: 49246
	private long[] Ids = Array.Empty<long>();

	// Token: 0x0400C05F RID: 49247
	private int Triggers;

	// Token: 0x0400C060 RID: 49248
	private float Lower;

	// Token: 0x0400C061 RID: 49249
	private EAttributeType? AttributeId;

	// Token: 0x0200932A RID: 37674
	[NullableContext(0)]
	public enum ETriggerType
	{
		// Token: 0x04031004 RID: 200708
		Accumulated,
		// Token: 0x04031005 RID: 200709
		Expired,
		// Token: 0x04031006 RID: 200710
		Premature,
		// Token: 0x04031007 RID: 200711
		Reduced
	}
}
