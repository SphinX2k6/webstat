using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.RoleUi;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CC4 RID: 27844
	public class LevelConditionCheckBattleRoleWeaponType : LevelConditionBase
	{
		// Token: 0x06044398 RID: 279448 RVA: 0x011B7318 File Offset: 0x011B5518
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
			string limitParams = inConditionInfo.GetLimitParams("WeaponType");
			if (limitParams == null)
			{
				return false;
			}
			int num = int.Parse(limitParams);
			int? battleTeamFirstRoleId = ModelBase<RoleModel>.Instance.GetBattleTeamFirstRoleId();
			return battleTeamFirstRoleId != null && ConfigBase<RoleConfig>.Instance.GetRoleConfig(battleTeamFirstRoleId.Value).Value.WeaponType == num;
		}
	}
}
