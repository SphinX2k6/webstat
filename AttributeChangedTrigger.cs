using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Utils;

// Token: 0x02002FC9 RID: 12233
[NullableContext(1)]
[Nullable(0)]
public class AttributeChangedTrigger : Trigger
{
	// Token: 0x06018F16 RID: 102166 RVA: 0x00711212 File Offset: 0x0070F412
	[NullableContext(2)]
	public AttributeChangedTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F17 RID: 102167 RVA: 0x00711223 File Offset: 0x0070F423
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.AttributeId = (EAttributeType)Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "0");
	}

	// Token: 0x06018F18 RID: 102168 RVA: 0x0071125C File Offset: 0x0070F45C
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			AbilityEvent.Instance.Add(target, EAbilityEventName.OnAttributeChange, (long)this.AttributeId, new Action<EAttributeType, Entity, float, float>(this.OnEvent));
		}
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
		{
			CharacterTriggerComponent ownerTriggerComp2 = base.OwnerTriggerComp;
			this.TriggerEventOnActive((ownerTriggerComp2 != null) ? ownerTriggerComp2.Entity : null);
			return;
		}
		case ETriggerTargetType.LocalFormation:
		case ETriggerTargetType.AllFormation:
		{
			bool onlyMyRole = this.TargetType == ETriggerTargetType.LocalFormation;
			foreach (EntityHandle entityHandle in ModelBase<SceneTeamModel>.Instance.GetTeamEntities(onlyMyRole))
			{
				this.TriggerEventOnActive(entityHandle.Entity);
			}
			break;
		}
		case ETriggerTargetType.Enemy:
			break;
		default:
			return;
		}
	}

	// Token: 0x06018F19 RID: 102169 RVA: 0x0071133C File Offset: 0x0070F53C
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			AbilityEvent.Instance.Remove(target, EAbilityEventName.OnAttributeChange, (long)this.AttributeId, new Action<EAttributeType, Entity, float, float>(this.OnEvent));
		}
	}

	// Token: 0x06018F1A RID: 102170 RVA: 0x0071138C File Offset: 0x0070F58C
	protected void OnEvent(EAttributeType _, Entity target, float newValue, float oldValue)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Target"] = target;
		dictionary["NewValue"] = newValue;
		dictionary["OldValue"] = oldValue;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F1B RID: 102171 RVA: 0x007113F0 File Offset: 0x0070F5F0
	[NullableContext(2)]
	private void TriggerEventOnActive(Entity entity)
	{
		BaseAttributeComponent baseAttributeComponent = (entity != null) ? entity.GetComponent<BaseAttributeComponent>() : null;
		if (baseAttributeComponent != null && entity != null)
		{
			float currentValue = baseAttributeComponent.GetCurrentValue(this.AttributeId);
			this.OnEvent(this.AttributeId, entity, currentValue, currentValue);
		}
	}

	// Token: 0x06018F1C RID: 102172 RVA: 0x0071142C File Offset: 0x0070F62C
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("自身属性 #");
			defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
			defaultInterpolatedStringHandler.AppendLiteral("变化时触发");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case ETriggerTargetType.LocalFormation:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("小队属性 #");
			defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
			defaultInterpolatedStringHandler.AppendLiteral("变化时触发");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case ETriggerTargetType.AllFormation:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(11, 1);
			defaultInterpolatedStringHandler.AppendLiteral("全队属性 #");
			defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
			defaultInterpolatedStringHandler.AppendLiteral("变化时触发");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		case ETriggerTargetType.Enemy:
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(17, 1);
			defaultInterpolatedStringHandler.AppendLiteral("敌人属性 #");
			defaultInterpolatedStringHandler.AppendFormatted<EAttributeType>(this.AttributeId);
			defaultInterpolatedStringHandler.AppendLiteral("变化时触发(暂未实现)");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C2F0 RID: 49904
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C2F1 RID: 49905
	protected EAttributeType AttributeId;
}
