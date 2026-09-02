using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CC2 RID: 27842
	public class LevelConditionCheckBattleRole : LevelConditionBase
	{
		// Token: 0x06044394 RID: 279444 RVA: 0x011B702C File Offset: 0x011B522C
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
			string limitParams = inConditionInfo.GetLimitParams("RoleId");
			if (limitParams == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的RoleId参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.CheckBattleRole);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			int num = int.Parse(limitParams);
			int? battleTeamFirstRoleId = ModelBase<RoleModel>.Instance.GetBattleTeamFirstRoleId();
			string limitParams2 = inConditionInfo.GetLimitParams("Slot");
			int? num2;
			int num3;
			if (limitParams2 == null)
			{
				num2 = battleTeamFirstRoleId;
				num3 = num;
				return num2.GetValueOrDefault() == num3 & num2 != null;
			}
			int num4 = 0;
			bool flag = int.TryParse(limitParams2, out num4);
			if (num4 <= 0 || num4 > 4 || !flag)
			{
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelCondition;
				ELogAuthor author3 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(24, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的Slot参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.CheckBattleRole);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance3.Error(module3, author3, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			SceneTeamItem getCurrentTeamItem = ModelBase<SceneTeamModel>.Instance.GetCurrentTeamItem;
			if (getCurrentTeamItem == null)
			{
				return false;
			}
			List<SceneTeamItem> teamItems = ModelBase<SceneTeamModel>.Instance.GetTeamItems(true);
			int num5 = -1;
			for (int i = 0; i < teamItems.Count; i++)
			{
				if (teamItems[i] == getCurrentTeamItem)
				{
					num5 = i + 1;
					break;
				}
			}
			num2 = battleTeamFirstRoleId;
			num3 = num;
			return (num2.GetValueOrDefault() == num3 & num2 != null) && num4 == num5;
		}
	}
}
