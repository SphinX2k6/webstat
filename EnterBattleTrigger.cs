using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FE2 RID: 12258
[NullableContext(1)]
[Nullable(0)]
public class EnterBattleTrigger : Trigger
{
	// Token: 0x06018FBB RID: 102331 RVA: 0x00715CBA File Offset: 0x00713EBA
	[NullableContext(2)]
	public EnterBattleTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018FBC RID: 102332 RVA: 0x00715CCB File Offset: 0x00713ECB
	public override void OnInitParams(string[] triggerParams)
	{
		this.NotTryTriggerOnActive = (Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "0") == 1);
	}

	// Token: 0x06018FBD RID: 102333 RVA: 0x00715CEB File Offset: 0x00713EEB
	protected override void OnActive()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnEvent));
		if (!this.NotTryTriggerOnActive && ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			this.OnEvent(true);
		}
	}

	// Token: 0x06018FBE RID: 102334 RVA: 0x00715D24 File Offset: 0x00713F24
	protected override void OnInactive()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnEvent));
	}

	// Token: 0x06018FBF RID: 102335 RVA: 0x00715D42 File Offset: 0x00713F42
	private void OnEvent(bool isInBattleState)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		if (isInBattleState)
		{
			base.EvaluateAndExecute(new Dictionary<string, TFormulaValue>());
		}
	}

	// Token: 0x06018FC0 RID: 102336 RVA: 0x00715D68 File Offset: 0x00713F68
	public override string GetDebugTriggerType()
	{
		string str = this.NotTryTriggerOnActive ? "(添加时不尝试触发)" : "(添加时尝试触发)";
		return "小队进战时触发" + str;
	}

	// Token: 0x0400C32D RID: 49965
	private bool NotTryTriggerOnActive;
}
