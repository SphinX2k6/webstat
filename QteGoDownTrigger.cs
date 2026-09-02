using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Utils;

// Token: 0x02002FD6 RID: 12246
[NullableContext(1)]
[Nullable(0)]
public class QteGoDownTrigger : Trigger
{
	// Token: 0x06018F6B RID: 102251 RVA: 0x007137A6 File Offset: 0x007119A6
	[NullableContext(2)]
	public QteGoDownTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F6C RID: 102252 RVA: 0x007137B7 File Offset: 0x007119B7
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
	}

	// Token: 0x06018F6D RID: 102253 RVA: 0x007137D4 File Offset: 0x007119D4
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

	// Token: 0x06018F6E RID: 102254 RVA: 0x00713848 File Offset: 0x00711A48
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

	// Token: 0x06018F6F RID: 102255 RVA: 0x007138BC File Offset: 0x00711ABC
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
				SceneTeamItem teamItem = ModelBase<SceneTeamModel>.Instance.GetTeamItem((long)goDownEntityId, new GetTeamItemOptions
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
			if (!(goDownEntityId == num2.GetValueOrDefault() & num2 != null))
			{
				return;
			}
		}
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		dictionary["GoBattleEntity"] = Singleton<EntitySystem>.Instance.Get(goBattleEntityId);
		dictionary["GoDownEntity"] = Singleton<EntitySystem>.Instance.Get(goDownEntityId);
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F70 RID: 102256 RVA: 0x007139A4 File Offset: 0x00711BA4
	public override string GetDebugTriggerType()
	{
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身QTE下场时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色QTE下场时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色QTE下场时触发";
		case ETriggerTargetType.Enemy:
			return "敌人QTE下场时触发,未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C30D RID: 49933
	protected ETriggerTargetType TargetType;
}
