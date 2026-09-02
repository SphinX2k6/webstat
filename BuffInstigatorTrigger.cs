using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Utils;

// Token: 0x02002FD7 RID: 12247
[NullableContext(1)]
[Nullable(0)]
public class BuffInstigatorTrigger : Trigger
{
	// Token: 0x06018F71 RID: 102257 RVA: 0x007139EE File Offset: 0x00711BEE
	[NullableContext(2)]
	public BuffInstigatorTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F72 RID: 102258 RVA: 0x00713A0C File Offset: 0x00711C0C
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.ListenBuffIds.Clear();
		string[] array = ((triggerParams.Length > 1) ? triggerParams[1] : string.Empty).Split('#', StringSplitOptions.None);
		for (int i = 0; i < array.Length; i++)
		{
			int num;
			if (int.TryParse(array[i], out num) && num > 0)
			{
				this.ListenBuffIds.Add((long)num);
			}
		}
		this.NotIncludeBornBuff = (((triggerParams.Length > 2) ? triggerParams[2] : "0") == "1");
		string[] array2 = ((triggerParams.Length > 3) ? triggerParams[3] : string.Empty).Split('#', StringSplitOptions.None);
		for (int j = 0; j < array2.Length; j++)
		{
			int num2;
			if (int.TryParse(array2[j], out num2) && num2 > 0)
			{
				foreach (long item in BuffController.GetBuffIdsByGroup(num2))
				{
					this.ListenBuffIds.Add(item);
				}
			}
		}
	}

	// Token: 0x06018F73 RID: 102259 RVA: 0x00713B10 File Offset: 0x00711D10
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds)
			{
				AbilityEvent.Instance.Add(target, EAbilityEventName.AddBuffToOthers, key, new Action<long, Entity, Entity, bool?>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F74 RID: 102260 RVA: 0x00713B98 File Offset: 0x00711D98
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			foreach (long key in this.ListenBuffIds)
			{
				AbilityEvent.Instance.Remove(target, EAbilityEventName.AddBuffToOthers, key, new Action<long, Entity, Entity, bool?>(this.OnEvent));
			}
		}
	}

	// Token: 0x06018F75 RID: 102261 RVA: 0x00713C20 File Offset: 0x00711E20
	private void OnEvent(long buffId, Entity victim, Entity attacker, bool? bornBuff)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		if (this.NotIncludeBornBuff && bornBuff.GetValueOrDefault())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["BuffId"] = buffId;
		dictionary["Victim"] = victim;
		dictionary["Attacker"] = attacker;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F76 RID: 102262 RVA: 0x00713C94 File Offset: 0x00711E94
	public override string GetDebugTriggerType()
	{
		string str = this.NotIncludeBornBuff ? "不包含出生buff" : "包含出生buff";
		string str2 = string.Join<long>("、", this.ListenBuffIds);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身施加buff" + str2 + "时触发 " + str;
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色施加buff" + str2 + "时触发 " + str;
		case ETriggerTargetType.AllFormation:
			return "全队任意角色施加buff" + str2 + "时触发 " + str;
		case ETriggerTargetType.Enemy:
			return "敌人施加buff" + str2 + "时触发,暂未实现 " + str;
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C30E RID: 49934
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C30F RID: 49935
	protected readonly HashSet<long> ListenBuffIds = new HashSet<long>();

	// Token: 0x0400C310 RID: 49936
	protected bool NotIncludeBornBuff;
}
