using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using AkiClient.Game.Aki.Character.Vision;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CD5 RID: 27861
	public class LevelConditionCheckClientUseVisionSkill : LevelConditionBase
	{
		// Token: 0x060443D6 RID: 279510 RVA: 0x011B8BF0 File Offset: 0x011B6DF0
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, AActor inTrigger, params object[] eventArgs)
		{
			if (inConditionInfo.LimitParamsLength == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TL;
				string message = "配置错误！条件的参数不应该为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			string limitParams = inConditionInfo.GetLimitParams("PhantomSkillId");
			if (limitParams == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.CheckClientUseVisionSkill);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			TsBaseCharacter baseCharacter = Global.BaseCharacter;
			if (baseCharacter == null)
			{
				return false;
			}
			Entity entityNoBlueprint = baseCharacter.GetEntityNoBlueprint();
			CharacterVisionComponent characterVisionComponent = (entityNoBlueprint != null) ? entityNoBlueprint.GetComponent<CharacterVisionComponent>() : null;
			if (characterVisionComponent == null)
			{
				return false;
			}
			Entity entityNoBlueprint2 = baseCharacter.GetEntityNoBlueprint();
			CharacterSkillComponent characterSkillComponent = (entityNoBlueprint2 != null) ? entityNoBlueprint2.GetComponent<CharacterSkillComponent>() : null;
			if (characterSkillComponent == null)
			{
				return false;
			}
			SVisionData visionData = characterVisionComponent.GetVisionData(int.Parse(limitParams));
			if (visionData == null)
			{
				return false;
			}
			global::Skill skill = characterSkillComponent.GetSkill(visionData.技能ID);
			return skill != null && skill.Active;
		}
	}
}
