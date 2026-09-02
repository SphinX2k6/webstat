using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using CSharpScript.Utils;

// Token: 0x02003122 RID: 12578
[NullableContext(2)]
[Nullable(0)]
public class CharacterSkillTriggerComponent : EntityComponent
{
	// Token: 0x0601A0B0 RID: 106672 RVA: 0x007A11D6 File Offset: 0x0079F3D6
	protected override bool OnInit()
	{
		this.SkillComp = base.Entity.CheckGetComponent<BaseSkillComponent>();
		this.TriggerComp = base.Entity.CheckGetComponent<CharacterTriggerComponent>();
		return true;
	}

	// Token: 0x0601A0B1 RID: 106673 RVA: 0x007A11FB File Offset: 0x0079F3FB
	protected override bool OnStart()
	{
		return true;
	}

	// Token: 0x0601A0B2 RID: 106674 RVA: 0x007A1200 File Offset: 0x0079F400
	protected override void OnActivate()
	{
		foreach (int skillId in this.SkillComp.GetAllSkillId(EFightDataTableSourceType.All))
		{
			SSkillInfo skillInfo = this.SkillComp.GetSkillInfo(skillId);
			this.AddSkillTrigger(skillId, skillInfo);
		}
	}

	// Token: 0x0601A0B3 RID: 106675 RVA: 0x007A1264 File Offset: 0x0079F464
	protected override bool OnEnd()
	{
		return true;
	}

	// Token: 0x0601A0B4 RID: 106676 RVA: 0x007A1268 File Offset: 0x0079F468
	private unsafe void AddSkillTrigger(int skillId, SSkillInfo info)
	{
		if (info == null)
		{
			return;
		}
		for (int i = 0; i < info.SkillTriggers.Num(); i++)
		{
			SSkillTrigger skillTrigger = info.SkillTriggers.Get(i);
			ETriggerEvent etriggerEvent;
			if (!Enum.TryParse<ETriggerEvent>(skillTrigger.TriggerType, out etriggerEvent))
			{
				CombatLog instance = Singleton<CombatLog>.Instance;
				CombatLog.EDebugModule flag = CombatLog.EDebugModule.Skill;
				Entity entity = base.Entity;
				string message = "技能触发器类型不合法";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("技能Id", skillId);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("触发器类型", skillTrigger.TriggerType);
				instance.Error(flag, entity, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			}
			else
			{
				List<string> list = new List<string>();
				if (skillTrigger.TriggerPreset != null)
				{
					for (int j = 0; j < skillTrigger.TriggerPreset.Num(); j++)
					{
						list.Add(skillTrigger.TriggerPreset.Get(j));
					}
				}
				if (etriggerEvent == ETriggerEvent.GlobalDamageTrigger)
				{
					CombatLog instance2 = Singleton<CombatLog>.Instance;
					CombatLog.EDebugModule flag2 = CombatLog.EDebugModule.Skill;
					Entity entity2 = base.Entity;
					string message2 = "禁止白名单之外的技能使用全局伤害监听";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("skillId", skillId);
					instance2.Error(flag2, entity2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					int handle = this.TriggerComp.AddTrigger(new TriggerConfigData
					{
						Type = skillTrigger.TriggerType,
						Preset = list.ToArray(),
						Params = (string.IsNullOrEmpty(skillTrigger.TriggerParams) ? "{}" : skillTrigger.TriggerParams),
						Formula = (string.IsNullOrEmpty(skillTrigger.TriggerFormula) ? "TRUE" : skillTrigger.TriggerFormula),
						ExecuteType = EExecuteType.Default
					}, delegate([Nullable(new byte[]
					{
						2,
						1
					})] Dictionary<string, TFormulaValue> parameters, [Nullable(new byte[]
					{
						2,
						1
					})] Dictionary<string, TFormulaValue> extraParams)
					{
						string triggerTarget = skillTrigger.TriggerTarget;
						Entity target = null;
						TFormulaValue tformulaValue;
						if (!string.IsNullOrEmpty(triggerTarget) && extraParams != null && extraParams.TryGetValue(triggerTarget, out tformulaValue) && !tformulaValue.TryGetEntity(out target))
						{
							Singleton<CombatLog>.Instance.Error(CombatLog.EDebugModule.Skill, this.Entity, "技能触发器配的技能目标不正确或不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
							return;
						}
						string triggerTargetSocket = skillTrigger.TriggerTargetSocket;
						string socketName = null;
						TFormulaValue tformulaValue2;
						string text;
						if (!string.IsNullOrEmpty(triggerTargetSocket) && extraParams != null && extraParams.TryGetValue(triggerTargetSocket, out tformulaValue2) && tformulaValue2.TryGetString(out text))
						{
							socketName = text;
						}
						this.SkillComp.BeginSkill(skillId, new SkillParam
						{
							Reason = "技能触发器触发",
							Target = target,
							SocketName = socketName
						});
					}, null);
					this.TriggerComp.SetTriggerActive(handle, true);
				}
			}
		}
	}

	// Token: 0x0601A0B5 RID: 106677 RVA: 0x007A149C File Offset: 0x0079F69C
	[NullableContext(1)]
	public void AddSkillTriggerDebug(int skillId, SSkillInfo info)
	{
		this.AddSkillTrigger(skillId, info);
	}

	// Token: 0x0601A0B6 RID: 106678 RVA: 0x007A14A8 File Offset: 0x0079F6A8
	[NullableContext(1)]
	public override bool ClearComponent(EntityComponent componentTemplate)
	{
		if (!base.ClearComponent(componentTemplate))
		{
			return false;
		}
		CharacterSkillTriggerComponent characterSkillTriggerComponent = (CharacterSkillTriggerComponent)componentTemplate;
		if (base.CanResetComponentProperty("SkillComp"))
		{
			if (characterSkillTriggerComponent.SkillComp == null)
			{
				this.SkillComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<BaseSkillComponent>(this.SkillComp), "SkillComp"))
			{
				return false;
			}
		}
		if (base.CanResetComponentProperty("TriggerComp"))
		{
			if (characterSkillTriggerComponent.TriggerComp == null)
			{
				this.TriggerComp = null;
			}
			else if (!base.CheckClearObject(EntityComponentSystem.ClearObject<CharacterTriggerComponent>(this.TriggerComp), "TriggerComp"))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0400D0DD RID: 53469
	private BaseSkillComponent SkillComp;

	// Token: 0x0400D0DE RID: 53470
	private CharacterTriggerComponent TriggerComp;
}
