using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FE3 RID: 12259
[NullableContext(1)]
[Nullable(0)]
public class LeaveBattleTrigger : Trigger
{
	// Token: 0x06018FC1 RID: 102337 RVA: 0x00715D95 File Offset: 0x00713F95
	[NullableContext(2)]
	public LeaveBattleTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018FC2 RID: 102338 RVA: 0x00715DA6 File Offset: 0x00713FA6
	public override void OnInitParams(string[] triggerParams)
	{
		this.NotTryTriggerOnActive = (Convert.ToInt32((triggerParams.Length > 1) ? triggerParams[1] : "0") == 1);
	}

	// Token: 0x06018FC3 RID: 102339 RVA: 0x00715DC6 File Offset: 0x00713FC6
	protected override void OnActive()
	{
		Singleton<EventSystem>.Instance.Add<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnEvent));
		if (!this.NotTryTriggerOnActive && !ControllerBase<FormationDataController>.Instance.GlobalIsInFight)
		{
			this.OnEvent(false);
		}
	}

	// Token: 0x06018FC4 RID: 102340 RVA: 0x00715DFF File Offset: 0x00713FFF
	protected override void OnInactive()
	{
		Singleton<EventSystem>.Instance.Remove<bool>(EEventName.OnBattleStateChanged, new Action<bool>(this.OnEvent));
	}

	// Token: 0x06018FC5 RID: 102341 RVA: 0x00715E1D File Offset: 0x0071401D
	private void OnEvent(bool isInBattleState)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		if (!isInBattleState)
		{
			base.EvaluateAndExecute(new Dictionary<string, TFormulaValue>());
		}
	}

	// Token: 0x06018FC6 RID: 102342 RVA: 0x00715E44 File Offset: 0x00714044
	public override string GetDebugTriggerType()
	{
		string str = this.NotTryTriggerOnActive ? "(添加时不尝试触发)" : "(添加时尝试触发)";
		return "小队脱战时触发" + str;
	}

	// Token: 0x0400C32E RID: 49966
	private bool NotTryTriggerOnActive;
}
