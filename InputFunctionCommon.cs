using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Character.BaseCharacter;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Data.Fight.Struct;
using CSharpScript.Game;
using CSharpScript.Game.Input;
using UnrealEngine;

// Token: 0x02003091 RID: 12433
[NullableContext(1)]
[Nullable(0)]
public class InputFunctionCommon : IStaticVariableResetter
{
	// Token: 0x06019A17 RID: 104983 RVA: 0x0077303C File Offset: 0x0077123C
	static InputFunctionCommon()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(InputFunctionCommon.CreateStaticDefaultValue), new Action(InputFunctionCommon.ResetStaticDefaultValue));
	}

	// Token: 0x17002285 RID: 8837
	// (get) Token: 0x06019A18 RID: 104984 RVA: 0x0077305B File Offset: 0x0077125B
	private static Skill TempSkill
	{
		get
		{
			return InputFunctionCommon._tempSkill;
		}
	}

	// Token: 0x06019A19 RID: 104985 RVA: 0x00773064 File Offset: 0x00771264
	[return: Nullable(2)]
	public static SInputCommand CreateSkillCommand(Entity entity, int skillId)
	{
		if (skillId == 0)
		{
			return null;
		}
		BaseSkillComponent component = entity.GetComponent<BaseSkillComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		SSkillInfo skillInfo = component.GetSkillInfo(skillId);
		int priority = component.GetPriority(skillId);
		int skillIdWithGroupId = component.GetSkillIdWithGroupId(1);
		int activePriority = component.GetActivePriority(skillIdWithGroupId);
		if (priority > activePriority || component.IsMainSkillReadyEnd || (priority == activePriority && component.SkillAcceptInput) || (skillInfo != null && skillInfo.GroupId != 1))
		{
			return new SInputCommand(ECommandType.Skill, skillId, default(FGameplayTag));
		}
		return null;
	}

	// Token: 0x06019A1A RID: 104986 RVA: 0x007730F0 File Offset: 0x007712F0
	public static bool CanResponseInput(Entity entity)
	{
		BaseMoveComponent component = entity.GetComponent<BaseMoveComponent>();
		if (component == null || !component.CanResponseInput())
		{
			return false;
		}
		BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
		return (component2 == null || !component2.HasAnyTag(new int[]
		{
			GameplayTagDefine.EGameplayTagId["功能.功能制作.被击硬直时间"],
			GameplayTagDefine.EGameplayTagId["行为状态.位置状态.水中"],
			GameplayTagDefine.EGameplayTagId["行为状态.位置状态.攀爬"],
			GameplayTagDefine.EGameplayTagId["行为状态.动作状态.滑坡"],
			GameplayTagDefine.EGameplayTagId["行为状态.动作状态.受击.被抓取"],
			GameplayTagDefine.EGameplayTagId["角色.BaseRole.状态通用标识.输入硬直"]
		})) && (component2 == null || !component2.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中"]) || (component2 != null && component2.HasTag(GameplayTagDefine.EGameplayTagId["角色.BaseRole.技能通用标识.幻象变身中.可输入"])));
	}

	// Token: 0x06019A1B RID: 104987 RVA: 0x007731DC File Offset: 0x007713DC
	public static bool CanCharacterResponseInput()
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		Entity entity;
		if (baseCharacter == null)
		{
			entity = null;
		}
		else
		{
			CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
			entity = ((characterActorComponent != null) ? characterActorComponent.Entity : null);
		}
		Entity entity2 = entity;
		return entity2 != null && InputFunctionCommon.CanResponseInput(entity2);
	}

	// Token: 0x06019A1C RID: 104988 RVA: 0x00773218 File Offset: 0x00771418
	public static bool CanVehicleResponseInput(Entity entity)
	{
		VehicleMoveComponent component = entity.GetComponent<VehicleMoveComponent>();
		if (component == null || !component.CanResponseInput())
		{
			return false;
		}
		BaseTagComponent component2 = entity.GetComponent<BaseTagComponent>();
		return component2 == null || !component2.HasTag(GameplayTagDefine.EGameplayTagId["载具.行为状态.动作状态.冲刺"]);
	}

	// Token: 0x06019A1D RID: 104989 RVA: 0x00773264 File Offset: 0x00771464
	[NullableContext(2)]
	public static SInputCommand CreateInputCommandFromDataTable(int entityId, AkiClient.Game.Aki.Character.Input.Enum.EInputAction action, EInputState state)
	{
		Entity entity = Singleton<EntitySystem>.Instance.Get(entityId);
		if (entity == null)
		{
			return null;
		}
		BaseTagComponent component = Singleton<EntitySystem>.Instance.GetComponent<BaseTagComponent>(entityId);
		BaseSkillComponent component2 = Singleton<EntitySystem>.Instance.GetComponent<BaseSkillComponent>(entityId);
		if (component == null || component2 == null)
		{
			return null;
		}
		SInputCommandTransform[] inputCommandTransformData = ModelBase<InputModel>.Instance.GetInputCommandTransformData(action, state);
		if (inputCommandTransformData == null)
		{
			return null;
		}
		foreach (SInputCommandTransform sinputCommandTransform in inputCommandTransformData)
		{
			if (component.HasTag(sinputCommandTransform.Tag.TagId()))
			{
				bool flag = false;
				if (sinputCommandTransform.BehaviorConditionGroup.Num() == 0)
				{
					flag = true;
				}
				else if (SkillBehaviorCondition.SatisfyGroup(sinputCommandTransform.BehaviorConditionGroup, sinputCommandTransform.BehaviorConditionFormula, new BeginSkillBehaviorConditionParam
				{
					Entity = entity,
					SkillComponent = component2,
					Skill = InputFunctionCommon.TempSkill
				}))
				{
					flag = true;
				}
				if (flag)
				{
					if (sinputCommandTransform.Command.CommandType == ECommandType.Skill)
					{
						return InputFunctionCommon.CreateSkillCommand(entity, sinputCommandTransform.Command.IntValue);
					}
					return new SInputCommand(sinputCommandTransform.Command.CommandType, sinputCommandTransform.Command.IntValue, sinputCommandTransform.Command.TagValue);
				}
			}
		}
		return null;
	}

	// Token: 0x06019A1E RID: 104990 RVA: 0x00773398 File Offset: 0x00771598
	public static bool HasEnoughEnergy(Entity entity)
	{
		BaseAttributeComponent component = entity.GetComponent<BaseAttributeComponent>();
		return component.GetCurrentValue(EAttributeType.SpecialEnergy4) >= component.GetCurrentValue(EAttributeType.SpecialEnergy4Max);
	}

	// Token: 0x06019A1F RID: 104991 RVA: 0x007733C1 File Offset: 0x007715C1
	public static void CreateStaticDefaultValue()
	{
		InputFunctionCommon._tempSkill = new Skill();
	}

	// Token: 0x06019A20 RID: 104992 RVA: 0x007733CD File Offset: 0x007715CD
	public static void ResetStaticDefaultValue()
	{
		InputFunctionCommon._tempSkill = null;
	}

	// Token: 0x0400CC31 RID: 52273
	[Nullable(2)]
	private static Skill _tempSkill;
}
