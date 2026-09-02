using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FDF RID: 12255
[NullableContext(1)]
[Nullable(0)]
public class ClearShowTargetTrigger : Trigger
{
	// Token: 0x06018FA3 RID: 102307 RVA: 0x0071543A File Offset: 0x0071363A
	[NullableContext(2)]
	public ClearShowTargetTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018FA4 RID: 102308 RVA: 0x0071544B File Offset: 0x0071364B
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018FA5 RID: 102309 RVA: 0x00715468 File Offset: 0x00713668
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			Singleton<EventSystem>.Instance.AddWithTarget<int, string, bool>(target, EEventName.CharEndShowTarget, new Action<int, string, bool>(this.OnEvent));
		}
	}

	// Token: 0x06018FA6 RID: 102310 RVA: 0x007154B0 File Offset: 0x007136B0
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target != null)
		{
			Singleton<EventSystem>.Instance.RemoveWithTarget<int, string, bool>(target, EEventName.CharEndShowTarget, new Action<int, string, bool>(this.OnEvent));
		}
	}

	// Token: 0x06018FA7 RID: 102311 RVA: 0x007154F8 File Offset: 0x007136F8
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

	// Token: 0x0400C327 RID: 49959
	protected ETriggerTargetType TargetType;
}
