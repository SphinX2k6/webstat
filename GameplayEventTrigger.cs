using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FD4 RID: 12244
[NullableContext(1)]
[Nullable(0)]
public class GameplayEventTrigger : Trigger
{
	// Token: 0x06018F5F RID: 102239 RVA: 0x00713426 File Offset: 0x00711626
	[NullableContext(2)]
	public GameplayEventTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F60 RID: 102240 RVA: 0x00713438 File Offset: 0x00711638
	public override void OnInitParams(string[] triggerParams)
	{
		string tagName = (triggerParams.Length != 0) ? triggerParams[0].Trim() : string.Empty;
		this.TagId = GameplayTagUtils.GetTagIdByName(tagName);
	}

	// Token: 0x06018F61 RID: 102241 RVA: 0x00713465 File Offset: 0x00711665
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object obj;
		if (ownerTriggerComp == null)
		{
			obj = null;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			obj = ((entity != null) ? entity.GetComponent<BaseAbilityComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.AddGameplayEventListener(this.TagId, new TGameplayEventCallback(this.OnEvent));
	}

	// Token: 0x06018F62 RID: 102242 RVA: 0x007134A1 File Offset: 0x007116A1
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object obj;
		if (ownerTriggerComp == null)
		{
			obj = null;
		}
		else
		{
			Entity entity = ownerTriggerComp.Entity;
			obj = ((entity != null) ? entity.GetComponent<BaseAbilityComponent>() : null);
		}
		object obj2 = obj;
		if (obj2 == null)
		{
			return;
		}
		obj2.RemoveGameplayEventListener(this.TagId, new TGameplayEventCallback(this.OnEvent));
	}

	// Token: 0x06018F63 RID: 102243 RVA: 0x007134E0 File Offset: 0x007116E0
	private void OnEvent(int _, FGameplayEventData payload)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		WorldEntity worldEntity;
		if (payload.Target == null)
		{
			worldEntity = null;
		}
		else
		{
			EntityHandle entityByActor = ActorUtils.GetEntityByActor(payload.Target, false);
			worldEntity = ((entityByActor != null) ? entityByActor.Entity : null);
		}
		WorldEntity value = worldEntity;
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["Target"] = value;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F64 RID: 102244 RVA: 0x00713543 File Offset: 0x00711743
	public override string GetDebugTriggerType()
	{
		return "GameplayEvent [" + GameplayTagUtils.GetNameByTagId(this.TagId) + "] 触发时触发";
	}

	// Token: 0x0400C30B RID: 49931
	protected int TagId;
}
