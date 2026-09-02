using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DB0 RID: 28080
	public class LevelConditionMotorMovieModeStateChange : LevelConditionBase
	{
		// Token: 0x060445A9 RID: 279977 RVA: 0x011C2790 File Offset: 0x011C0990
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("State");
			if (limitParams == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TZJ;
				string message = "条件：检查摩托车状态 需要配置状态作为参数";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("condition id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int num = int.Parse(limitParams);
			return (((bool)eventArgs[0] > false) ? 1 : 0) == num;
		}
	}
}
