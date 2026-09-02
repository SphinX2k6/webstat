using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FDE RID: 12254
[NullableContext(1)]
[Nullable(0)]
public class ShowTargetTrigger : Trigger
{
	// Token: 0x06018F9D RID: 102301 RVA: 0x0071528E File Offset: 0x0071348E
	[NullableContext(2)]
	public ShowTargetTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F9E RID: 102302 RVA: 0x0071529F File Offset: 0x0071349F
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F9F RID: 102303 RVA: 0x007152BC File Offset: 0x007134BC
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && !Singleton<EventSystem>.Instance.HasWithTarget<int, string, bool>(target, EEventName.CharSetShowTarget, new Action<int, string, bool>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int, string, bool>(target, EEventName.CharSetShowTarget, new Action<int, string, bool>(this.OnEvent));
		}
	}

	// Token: 0x06018FA0 RID: 102304 RVA: 0x00715320 File Offset: 0x00713520
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null && Singleton<EventSystem>.Instance.HasWithTarget<int, string, bool>(target, EEventName.CharSetShowTarget, new Action<int, string, bool>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, string, bool>(target, EEventName.CharSetShowTarget, new Action<int, string, bool>(this.OnEvent));
		}
	}

	// Token: 0x06018FA1 RID: 102305 RVA: 0x00715384 File Offset: 0x00713584
	private void OnEvent(int targetId, string targetSocket, bool isHardLock)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["ShowTarget"] = Singleton<EntitySystem>.Instance.Get(targetId);
		dictionary["TargetSocket"] = targetSocket;
		dictionary["IsHardLock"] = isHardLock;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018FA2 RID: 102306 RVA: 0x007153F0 File Offset: 0x007135F0
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身索敌时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色索敌时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色索敌时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色触发，暂时不支持";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C326 RID: 49958
	protected ETriggerTargetType TargetType;
}
