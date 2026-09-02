using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FD8 RID: 12248
[NullableContext(1)]
[Nullable(0)]
public class BuffStackInstigatorTrigger : Trigger
{
	// Token: 0x06018F77 RID: 102263 RVA: 0x00713D34 File Offset: 0x00711F34
	[NullableContext(2)]
	public BuffStackInstigatorTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F78 RID: 102264 RVA: 0x00713D58 File Offset: 0x00711F58
	public override void OnInitParams(string[] triggerParams)
	{
		this.HasValidConfig = true;
		this.ListenBuffIds.Clear();
		ETriggerTargetType etriggerTargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		if (etriggerTargetType != ETriggerTargetType.Self && etriggerTargetType != ETriggerTargetType.LocalFormation && etriggerTargetType != ETriggerTargetType.AllFormation)
		{
			this.SetInvalidConfig(triggerParams);
			return;
		}
		this.TargetType = etriggerTargetType;
		string[] array = ((triggerParams.Length > 1) ? triggerParams[1] : string.Empty).Split('#', StringSplitOptions.None);
		if (array.Length == 0 || string.IsNullOrEmpty(array[0]))
		{
			this.SetInvalidConfig(triggerParams);
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			long num;
			if (!long.TryParse(array[i], out num) || num <= 0L)
			{
				this.SetInvalidConfig(triggerParams);
				return;
			}
			this.ListenBuffIds.Add(num);
		}
		if (this.ListenBuffIds.Count <= 0)
		{
			this.SetInvalidConfig(triggerParams);
		}
	}

	// Token: 0x06018F79 RID: 102265 RVA: 0x00713E20 File Offset: 0x00712020
	private unsafe void SetInvalidConfig(string[] triggerParams)
	{
		this.HasValidConfig = false;
		this.ListenBuffIds.Clear();
		CombatLog instance = Singleton<CombatLog>.Instance;
		CombatLog.EDebugModule flag = CombatLog.EDebugModule.PassiveSkill;
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		Entity entity = (ownerTriggerComp != null) ? ownerTriggerComp.Entity : null;
		string message = "BuffStackInstigatorTrigger参数错误";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("triggerName", this.GetDebugName());
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("params", triggerParams);
		instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06018F7A RID: 102266 RVA: 0x00713EA8 File Offset: 0x007120A8
	protected override void OnActive()
	{
		if (!this.HasValidConfig)
		{
			return;
		}
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds)
			{
				AbilityEvent.Instance.Add(target, EAbilityEventName.BuffStackInstigatorChanged, key, new Action<long, int, int, Entity, Entity>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F7B RID: 102267 RVA: 0x00713F38 File Offset: 0x00712138
	protected override void OnInactive()
	{
		if (!this.HasValidConfig)
		{
			return;
		}
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds)
			{
				AbilityEvent.Instance.Remove(target, EAbilityEventName.BuffStackInstigatorChanged, key, new Action<long, int, int, Entity, Entity>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F7C RID: 102268 RVA: 0x00713FC8 File Offset: 0x007121C8
	private void OnEvent(long buffId, int oldStack, int newStack, Entity victim, Entity attacker)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["BuffId"] = buffId;
		dictionary["OldStack"] = oldStack;
		dictionary["NewStack"] = newStack;
		dictionary["Victim"] = victim;
		dictionary["Attacker"] = attacker;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F7D RID: 102269 RVA: 0x00714050 File Offset: 0x00712250
	public override string GetDebugTriggerType()
	{
		string str = string.Join<long>("、", this.ListenBuffIds);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身来源buff" + str + "层数变化时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色来源buff" + str + "层数变化时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色来源buff" + str + "层数变化时触发";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C311 RID: 49937
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C312 RID: 49938
	protected readonly HashSet<long> ListenBuffIds = new HashSet<long>();

	// Token: 0x0400C313 RID: 49939
	protected bool HasValidConfig = true;
}
