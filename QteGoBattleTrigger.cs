using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FD5 RID: 12245
[NullableContext(1)]
[Nullable(0)]
public class QteGoBattleTrigger : Trigger
{
	// Token: 0x06018F65 RID: 102245 RVA: 0x0071355F File Offset: 0x0071175F
	[NullableContext(2)]
	public QteGoBattleTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F66 RID: 102246 RVA: 0x00713570 File Offset: 0x00711770
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F67 RID: 102247 RVA: 0x0071358C File Offset: 0x0071178C
	protected override void OnActive()
	{
		if (!Singleton<EventSystem>.Instance.Has<int, int>(EEventName.CharExecuteQte, new Action<int, int>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.CharExecuteQte, new Action<int, int>(this.OnEvent));
		}
		if (!Singleton<EventSystem>.Instance.Has<int, int>(EEventName.CharExecuteMultiQte, new Action<int, int>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.CharExecuteMultiQte, new Action<int, int>(this.OnEvent));
		}
	}

	// Token: 0x06018F68 RID: 102248 RVA: 0x00713600 File Offset: 0x00711800
	protected override void OnInactive()
	{
		if (Singleton<EventSystem>.Instance.Has<int, int>(EEventName.CharExecuteQte, new Action<int, int>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.CharExecuteQte, new Action<int, int>(this.OnEvent));
		}
		if (Singleton<EventSystem>.Instance.Has<int, int>(EEventName.CharExecuteMultiQte, new Action<int, int>(this.OnEvent)))
		{
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.CharExecuteMultiQte, new Action<int, int>(this.OnEvent));
		}
	}

	// Token: 0x06018F69 RID: 102249 RVA: 0x00713674 File Offset: 0x00711874
	private void OnEvent(int goBattleEntityId, int goDownEntityId)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		ETriggerTargetType targetType = this.TargetType;
		if (targetType != ETriggerTargetType.Self)
		{
			if (targetType == ETriggerTargetType.LocalFormation)
			{
				SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)goBattleEntityId, new GetTeamItemOptions
				{
					ParamType = ETeamParamType.EntityId
				});
				if (teamItem == null || !teamItem.IsMyRole())
				{
					return;
				}
			}
		}
		else
		{
			CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
			int? num;
			if (ownerTriggerComp == null)
			{
				num = null;
			}
			else
			{
				Entity entity = ownerTriggerComp.Entity;
				num = ((entity != null) ? new int?(entity.Id) : null);
			}
			int? num2 = num;
			if (!(goBattleEntityId == num2.GetValueOrDefault() & num2 != null))
			{
				return;
			}
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["GoBattleEntity"] = Singleton<EntitySystem>.Instance.Get(goBattleEntityId);
		dictionary["GoDownEntity"] = Singleton<EntitySystem>.Instance.Get(goDownEntityId);
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F6A RID: 102250 RVA: 0x0071375C File Offset: 0x0071195C
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身QTE上场时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色QTE上场时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色QTE上场时触发";
		case ETriggerTargetType.Enemy:
			return "敌人角色QTE上场时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C30C RID: 49932
	protected ETriggerTargetType TargetType;
}
