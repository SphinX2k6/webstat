using System;
using System.Runtime.CompilerServices;
using Aki.Protocol.Summon;
using AkiClient.Game.Aki.Character.Input.Enum;
using AkiClient.Game.Aki.Character.Input.Structures;
using AkiClient.Game.Aki.Character.Vision;
using CSharpScript.Game;

// Token: 0x0200309D RID: 12445
[NullableContext(2)]
[Nullable(0)]
public static class InputFunctionVisionSkill2
{
	// Token: 0x06019A4A RID: 105034 RVA: 0x007745C8 File Offset: 0x007727C8
	private static SInputCommand VisionSkill2Function(float time)
	{
		TsBaseCharacter baseCharacter = Global.BaseCharacter;
		if (baseCharacter == null)
		{
			return null;
		}
		CharacterActorComponent characterActorComponent = baseCharacter.CharacterActorComponent;
		Entity entity = (characterActorComponent != null) ? characterActorComponent.Entity : null;
		if (entity == null)
		{
			return null;
		}
		BaseTagComponent component = entity.GetComponent<BaseTagComponent>();
		if (component == null || !component.Valid)
		{
			return null;
		}
		if (!InputFunctionCommon.CanResponseInput(entity))
		{
			return null;
		}
		SInputCommand sinputCommand = InputFunctionCommon.CreateInputCommandFromDataTable(entity.Id, EInputAction.幻象2, EInputState.Press);
		if (sinputCommand != null)
		{
			return sinputCommand;
		}
		if (component.HasTag(GameplayTagDefine.EGameplayTagId["Rogue.Vision.Common.Demo测试_可变身操控"]))
		{
			if (InputFunctionCommon.HasEnoughEnergy(entity))
			{
				return InputFunctionCommon.CreateSkillCommand(entity, 200010);
			}
			return null;
		}
		else
		{
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["幻象.声骸角色.团子.团子声骸已装备"]) && !InputFunctionCommon.HasEnoughEnergy(entity))
			{
				return null;
			}
			if (component.HasTag(GameplayTagDefine.EGameplayTagId["系统.肉鸽.声骸BD.无妄者.解锁领域词条"]))
			{
				if (component.HasTag(GameplayTagDefine.EGameplayTagId["系统.肉鸽.声骸BD.无妄者.解锁领域词条.激活二段Q"]))
				{
					return InputFunctionCommon.CreateSkillCommand(entity, 23000201);
				}
				return InputFunctionCommon.CreateSkillCommand(entity, 230002);
			}
			else if (component.HasTag(GameplayTagDefine.EGameplayTagId["系统.肉鸽.3_4肉鸽.鳞人"]))
			{
				if (component.HasTag(GameplayTagDefine.EGameplayTagId["系统.肉鸽.3_4肉鸽.鳞人.允许变身"]))
				{
					return InputFunctionCommon.CreateSkillCommand(entity, 280001116);
				}
				return InputFunctionCommon.CreateSkillCommand(entity, 280001110);
			}
			else
			{
				CharacterVisionComponent component2 = entity.GetComponent<CharacterVisionComponent>();
				if (component2 == null)
				{
					return null;
				}
				int visionId = component2.GetVisionId(null);
				if (visionId == 0)
				{
					return null;
				}
				SVisionData visionData = PhantomUtil.GetVisionData(visionId);
				if (visionData == null)
				{
					return null;
				}
				EntityHandle summonedEntity = PhantomUtil.GetSummonedEntity(entity, ESummonType.ConcomitantVision, 1);
				if (summonedEntity == null || !summonedEntity.Valid)
				{
					return null;
				}
				if (summonedEntity.Entity.Active && visionData.类型 != EVisionType.驻场)
				{
					return null;
				}
				bool 空中能否释放 = visionData.空中能否释放;
				if (!空中能否释放 && component.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.位置状态.空中"]))
				{
					return null;
				}
				int entityVisionSkillId = PhantomUtil.GetEntityVisionSkillId(entity.Id, visionId);
				if (entityVisionSkillId == 0)
				{
					return null;
				}
				int visionLevel = component2.GetVisionLevel();
				ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "VisionLevel", visionLevel);
				ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "VisionID", visionId);
				ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "VisionAirSkill", (空中能否释放 > false) ? 1 : 0);
				ControllerBase<BlackboardController>.Instance.SetIntValueByEntity(entity.Id, "VisionLink", (component.HasAnyTag(new int[]
				{
					GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.普攻"],
					GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.技能"],
					GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.蓄力"],
					GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.核心"]
				}) > false) ? 1 : 0);
				return InputFunctionCommon.CreateSkillCommand(entity, entityVisionSkillId);
			}
		}
	}

	// Token: 0x06019A4B RID: 105035 RVA: 0x0077488C File Offset: 0x00772A8C
	public static SInputCommand VisionSkill2OnPress(float time)
	{
		return InputFunctionVisionSkill2.VisionSkill2Function(time);
	}

	// Token: 0x06019A4C RID: 105036 RVA: 0x00774894 File Offset: 0x00772A94
	public static SInputCommand VisionSkill2OnRelease(float time)
	{
		return null;
	}
}
