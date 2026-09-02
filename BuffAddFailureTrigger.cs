using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FDC RID: 12252
[NullableContext(1)]
[Nullable(0)]
public class BuffAddFailureTrigger : Trigger
{
	// Token: 0x06018F91 RID: 102289 RVA: 0x00714D73 File Offset: 0x00712F73
	[NullableContext(2)]
	public BuffAddFailureTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F92 RID: 102290 RVA: 0x00714DA8 File Offset: 0x00712FA8
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.ListenBuffIds.Clear();
		string[] array = ((triggerParams.Length > 1) ? triggerParams[1] : string.Empty).Split('#', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			long item;
			if (long.TryParse(array[i], out item))
			{
				this.ListenBuffIds.Add(item);
			}
		}
		this.TriggerOncePerContext = (Convert.ToInt32((triggerParams.Length > 2) ? triggerParams[2] : "0") == 1);
	}

	// Token: 0x06018F93 RID: 102291 RVA: 0x00714E38 File Offset: 0x00713038
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds)
			{
				AbilityEvent.Instance.Add(target, EAbilityEventName.AddBuffFailure, key, new Action<long, Entity, Entity, int, long?>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F94 RID: 102292 RVA: 0x00714EC0 File Offset: 0x007130C0
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds)
			{
				AbilityEvent.Instance.Remove(target, EAbilityEventName.AddBuffFailure, key, new Action<long, Entity, Entity, int, long?>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F95 RID: 102293 RVA: 0x00714F48 File Offset: 0x00713148
	private void OnEvent(long buffId, Entity victim, Entity attacker, int stackCount, long? bulletContextId)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		if (this.TriggerOncePerContext)
		{
			long checkContext = bulletContextId.GetValueOrDefault();
			int num = this.ContextIds.FindIndex((long v) => v == checkContext);
			if (num == -1)
			{
				this.ContextIds.Add(checkContext);
				this.VictimIds.Add(victim.Id);
				if (this.ContextIds.Count > 15)
				{
					this.ContextIds.RemoveAt(0);
					this.VictimIds.RemoveAt(0);
				}
			}
			else if (this.VictimIds[num] != victim.Id)
			{
				return;
			}
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["BuffId"] = buffId;
		dictionary["Victim"] = victim;
		dictionary["Attacker"] = attacker;
		dictionary["StackCount"] = stackCount;
		string key = "Listener";
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		dictionary[key] = ((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null);
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F96 RID: 102294 RVA: 0x00715078 File Offset: 0x00713278
	public override string GetDebugTriggerType()
	{
		string str = string.Join<long>("、", this.ListenBuffIds);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身施加buff" + str + "失败时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色施加buff" + str + "失败时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色施加buff" + str + "失败时触发";
		case ETriggerTargetType.Enemy:
			return "敌人施加buff" + str + "失败时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C31F RID: 49951
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C320 RID: 49952
	protected readonly List<long> ListenBuffIds = new List<long>();

	// Token: 0x0400C321 RID: 49953
	protected readonly List<long> ContextIds = new List<long>();

	// Token: 0x0400C322 RID: 49954
	protected readonly List<int> VictimIds = new List<int>();

	// Token: 0x0400C323 RID: 49955
	protected const int ContextCapacity = 15;

	// Token: 0x0400C324 RID: 49956
	protected bool TriggerOncePerContext;
}
