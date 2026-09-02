using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02002F39 RID: 12089
[NullableContext(1)]
[Nullable(0)]
public class ModifyToughReduce : BuffEffect
{
	// Token: 0x06018BEA RID: 101354 RVA: 0x006FDF6C File Offset: 0x006FC16C
	public ModifyToughReduce(int activeHandleId, int index, RequireAndLimits requireAndLimits, BaseBuffComponent ownerBuffComponent, [Nullable(2)] CharacterBuffComponent instigatorBuffComponent) : base(activeHandleId, index, requireAndLimits, ownerBuffComponent, instigatorBuffComponent)
	{
	}

	// Token: 0x06018BEB RID: 101355 RVA: 0x006FDF88 File Offset: 0x006FC188
	protected override void InitParameters(ExtraEffectParameters parameters)
	{
		string[] extraEffectParameters_ = parameters.ExtraEffectParameters_;
		if (extraEffectParameters_ != null && extraEffectParameters_.Length != 0)
		{
			this.ModifyRate = float.Parse(extraEffectParameters_[0]);
		}
	}

	// Token: 0x06018BEC RID: 101356 RVA: 0x006FDFB4 File Offset: 0x006FC1B4
	public override void OnCreated()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		foreach (BaseAttributeComponent baseAttributeComponent in (((baseBuffComponent != null) ? baseBuffComponent.GetTargetComponents<BaseAttributeComponent>(EComponent.BaseAttributeComponent, null) : null) ?? new List<BaseAttributeComponent>()))
		{
			if (baseAttributeComponent != null)
			{
				Entity entity = baseAttributeComponent.Entity;
				int value = baseAttributeComponent.AddModifier(EAttributeType.ToughReduce, new CharacterAttributeTypes.AttributeModifier
				{
					Type = ECalculationPolicyType.AdvancedMultiplyMagnitude1,
					Value1 = this.ModifyRate
				});
				this.EntityModifierMap[entity.Id] = value;
			}
		}
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
	}

	// Token: 0x06018BED RID: 101357 RVA: 0x006FE098 File Offset: 0x006FC298
	[return: Nullable(2)]
	public override object OnExecute(params object[] parameters)
	{
		return null;
	}

	// Token: 0x06018BEE RID: 101358 RVA: 0x006FE09C File Offset: 0x006FC29C
	public override void OnRemoved(bool bPremature)
	{
		foreach (KeyValuePair<int, int> keyValuePair in this.EntityModifierMap)
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			BaseAttributeComponent baseAttributeComponent;
			if (instance == null)
			{
				baseAttributeComponent = null;
			}
			else
			{
				EntityHandle handle = instance.GetHandle(keyValuePair.Key);
				if (handle == null)
				{
					baseAttributeComponent = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					baseAttributeComponent = ((entity != null) ? entity.CheckGetComponent<BaseAttributeComponent>() : null);
				}
			}
			BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
			if (baseAttributeComponent2 != null)
			{
				baseAttributeComponent2.RemoveModifier(EAttributeType.ToughReduce, keyValuePair.Value);
			}
		}
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		if (baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent())
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnChangeTeam));
		}
		this.EntityModifierMap.Clear();
	}

	// Token: 0x06018BEF RID: 101359 RVA: 0x006FE174 File Offset: 0x006FC374
	private void OnChangeTeam()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, int> keyValuePair in this.EntityModifierMap)
		{
			list.Add(keyValuePair.Key);
		}
		foreach (int num in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(list, true))
		{
			CharacterModel instance = ModelBase<CharacterModel>.Instance;
			BaseAttributeComponent baseAttributeComponent;
			if (instance == null)
			{
				baseAttributeComponent = null;
			}
			else
			{
				EntityHandle handle = instance.GetHandle(num);
				if (handle == null)
				{
					baseAttributeComponent = null;
				}
				else
				{
					WorldEntity entity = handle.Entity;
					baseAttributeComponent = ((entity != null) ? entity.CheckGetComponent<BaseAttributeComponent>() : null);
				}
			}
			BaseAttributeComponent baseAttributeComponent2 = baseAttributeComponent;
			if (baseAttributeComponent2 != null)
			{
				int value = baseAttributeComponent2.AddModifier(EAttributeType.ToughReduce, new CharacterAttributeTypes.AttributeModifier
				{
					Type = ECalculationPolicyType.AdvancedMultiplyMagnitude1,
					Value1 = this.ModifyRate
				});
				this.EntityModifierMap[num] = value;
			}
		}
		foreach (int num2 in BaseBuffComponent.GetNewOrRemoveTeamEntityIds(list, false))
		{
			CharacterModel instance2 = ModelBase<CharacterModel>.Instance;
			BaseAttributeComponent baseAttributeComponent3;
			if (instance2 == null)
			{
				baseAttributeComponent3 = null;
			}
			else
			{
				EntityHandle handle2 = instance2.GetHandle(num2);
				if (handle2 == null)
				{
					baseAttributeComponent3 = null;
				}
				else
				{
					WorldEntity entity2 = handle2.Entity;
					baseAttributeComponent3 = ((entity2 != null) ? entity2.CheckGetComponent<BaseAttributeComponent>() : null);
				}
			}
			BaseAttributeComponent baseAttributeComponent4 = baseAttributeComponent3;
			int handle3;
			if (baseAttributeComponent4 != null && this.EntityModifierMap.TryGetValue(num2, out handle3))
			{
				baseAttributeComponent4.RemoveModifier(EAttributeType.ToughReduce, handle3);
			}
			this.EntityModifierMap.Remove(num2);
		}
	}

	// Token: 0x06018BF0 RID: 101360 RVA: 0x006FE30C File Offset: 0x006FC50C
	public override string GetDebugEffectString()
	{
		Entity exactOwnerEntity = base.ExactOwnerEntity;
		BaseBuffComponent baseBuffComponent = (exactOwnerEntity != null) ? exactOwnerEntity.CheckGetComponent<BaseBuffComponent>() : null;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(9, 2);
		defaultInterpolatedStringHandler.AppendFormatted((baseBuffComponent != null && baseBuffComponent.IsTeamBuffComponent()) ? "编队buff" : "非编队buff");
		defaultInterpolatedStringHandler.AppendLiteral(",修改韧性扣减率");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.ModifyRate * 100f, "F1");
		defaultInterpolatedStringHandler.AppendLiteral("%");
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x0400C0B7 RID: 49335
	protected float ModifyRate;

	// Token: 0x0400C0B8 RID: 49336
	protected Dictionary<int, int> EntityModifierMap = new Dictionary<int, int>();
}
