using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow;
using CSharpScript.Utils;
using UnrealEngine;

// Token: 0x02002FCE RID: 12238
[NullableContext(1)]
[Nullable(0)]
public class SkillTrigger : Trigger
{
	// Token: 0x06018F39 RID: 102201 RVA: 0x00712062 File Offset: 0x00710262
	[NullableContext(2)]
	public SkillTrigger(ITriggerConfig c, int h, CharacterTriggerComponent o, [Nullable(1)] Dictionary<string, Func<TFormulaValue[], TFormulaValue>> f, TTriggerCallback cb, TTriggerChecker ck) : base(c, h, o, f, cb, ck)
	{
	}

	// Token: 0x06018F3A RID: 102202 RVA: 0x00712088 File Offset: 0x00710288
	public override void OnInitParams(string[] triggerParams)
	{
		this.TargetType = (ETriggerTargetType)Convert.ToInt32((triggerParams.Length != 0) ? triggerParams[0] : "0");
		this.SkillIds.Clear();
		if (triggerParams.Length > 1 && !string.IsNullOrEmpty(triggerParams[1]))
		{
			string[] array = triggerParams[1].Split('#', StringSplitOptions.None);
			this.AllSkill = false;
			for (int i = 0; i < array.Length; i++)
			{
				int num = Convert.ToInt32(array[i]);
				this.SkillIds.Add(num);
				if (num == -1)
				{
					this.AllSkill = true;
				}
			}
		}
		this.CheckEnd = (Convert.ToInt32((triggerParams.Length > 2) ? triggerParams[2] : "0") != 0);
	}

	// Token: 0x06018F3B RID: 102203 RVA: 0x00712128 File Offset: 0x00710328
	protected override void OnActive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target == null)
		{
			return;
		}
		if (this.CheckEnd)
		{
			if (!TriggerEventHelper.HasWithTarget(target, EEventName.OnSkillEnd, new Action<int, int>(this.OnSelfEvent)))
			{
				TriggerEventHelper.AddWithTarget(target, EEventName.OnSkillEnd, new Action<int, int>(this.OnSelfEvent));
				return;
			}
		}
		else
		{
			if (!TriggerEventHelper.HasWithTarget(target, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnSelfEventWithProxy)))
			{
				TriggerEventHelper.AddWithTarget(target, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnSelfEventWithProxy));
			}
			if (!Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharUseSkillRemote, new Action<int, int>(this.OnSelfEvent)))
			{
				Singleton<EventSystem>.Instance.AddWithTarget(target, EEventName.CharUseSkillRemote, new Action<int, int>(this.OnSelfEvent));
			}
		}
	}

	// Token: 0x06018F3C RID: 102204 RVA: 0x007121EC File Offset: 0x007103EC
	protected override void OnInactive()
	{
		CharacterTriggerComponent ownerTriggerComp = base.OwnerTriggerComp;
		object target = TriggerUtils.GetTarget((ownerTriggerComp != null) ? ownerTriggerComp.Entity : null, this.TargetType);
		if (target == null)
		{
			return;
		}
		if (this.CheckEnd)
		{
			if (TriggerEventHelper.HasWithTarget(target, EEventName.OnSkillEnd, new Action<int, int>(this.OnSelfEvent)))
			{
				TriggerEventHelper.RemoveWithTarget(target, EEventName.OnSkillEnd, new Action<int, int>(this.OnSelfEvent));
				return;
			}
		}
		else
		{
			if (TriggerEventHelper.HasWithTarget(target, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnSelfEventWithProxy)))
			{
				TriggerEventHelper.RemoveWithTarget(target, EEventName.CharUseSkill, new Action<int, int, bool>(this.OnSelfEventWithProxy));
			}
			if (Singleton<EventSystem>.Instance.HasWithTarget(target, EEventName.CharUseSkillRemote, new Action<int, int>(this.OnSelfEvent)))
			{
				Singleton<EventSystem>.Instance.RemoveWithTarget(target, EEventName.CharUseSkillRemote, new Action<int, int>(this.OnSelfEvent));
			}
		}
	}

	// Token: 0x06018F3D RID: 102205 RVA: 0x007122B0 File Offset: 0x007104B0
	protected void OnSelfEvent(int entityId, int skillId)
	{
		if (base.Checker != null && !base.Checker())
		{
			return;
		}
		if (!this.AllSkill)
		{
			bool flag = false;
			for (int i = 0; i < this.SkillIds.Count; i++)
			{
				if (this.SkillIds[i] == skillId)
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
		}
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity != null && FollowUtils.IsFollowShooterByEntity(entity))
		{
			entity = FollowUtils.ShouldForwardToFrontChar(entity);
		}
		BaseSkillComponent baseSkillComponent = (entity != null) ? entity.GetComponent<BaseSkillComponent>() : null;
		if (baseSkillComponent == null)
		{
			return;
		}
		SSkillInfo skillInfo = baseSkillComponent.GetSkillInfo(skillId);
		Skill skill = baseSkillComponent.GetSkill(skillId);
		string[] array;
		if (skill == null)
		{
			array = null;
		}
		else
		{
			ISkillBattleContext battleContext = skill.BattleContext;
			if (battleContext == null)
			{
				array = null;
			}
			else
			{
				List<string> battleFlags = battleContext.BattleFlags;
				array = ((battleFlags != null) ? battleFlags.ToArray() : null);
			}
		}
		string[] value = array ?? Array.Empty<string>();
		Dictionary<string, TFormulaValue> dictionary = new Dictionary<string, TFormulaValue>();
		string key = "SkillType";
		TEnumAsByte<ESkillGenre>? tenumAsByte = (skillInfo != null) ? new TEnumAsByte<ESkillGenre>?(skillInfo.SkillGenre) : null;
		dictionary[key] = (int)((tenumAsByte != null) ? tenumAsByte.GetValueOrDefault() : 0);
		dictionary["SkillTags"] = Array.Empty<string>();
		dictionary["SkillID"] = skillId;
		dictionary["BattleFlags"] = value;
		dictionary["Attacker"] = entity;
		base.EvaluateAndExecute(dictionary);
	}

	// Token: 0x06018F3E RID: 102206 RVA: 0x00712415 File Offset: 0x00710615
	protected void OnSelfEventWithProxy(int entityId, int skillId, bool isAutonomousProxy)
	{
		this.OnSelfEvent(entityId, skillId);
	}

	// Token: 0x06018F3F RID: 102207 RVA: 0x00712420 File Offset: 0x00710620
	public override string GetDebugTriggerType()
	{
		string str = string.Join<int>(",", this.SkillIds);
		switch (this.TargetType)
		{
		case ETriggerTargetType.Self:
			return "自身技能" + str + (this.CheckEnd ? "结束" : "开始") + "时触发";
		case ETriggerTargetType.LocalFormation:
			return "小队任意角色技能" + str + (this.CheckEnd ? "结束" : "开始") + "时触发";
		case ETriggerTargetType.AllFormation:
			return "全队任意角色技能" + str + (this.CheckEnd ? "结束" : "开始") + "时触发";
		case ETriggerTargetType.Enemy:
			return "敌人技能" + str + (this.CheckEnd ? "结束" : "开始") + "时触发,暂未实现";
		default:
			return base.GetDebugTriggerType();
		}
	}

	// Token: 0x0400C2FE RID: 49918
	protected ETriggerTargetType TargetType;

	// Token: 0x0400C2FF RID: 49919
	protected readonly List<int> SkillIds = new List<int>();

	// Token: 0x0400C300 RID: 49920
	protected bool AllSkill = true;

	// Token: 0x0400C301 RID: 49921
	protected bool CheckEnd;
}
