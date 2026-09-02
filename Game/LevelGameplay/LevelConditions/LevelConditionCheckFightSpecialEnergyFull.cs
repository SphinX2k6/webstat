using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CFE RID: 27902
	public class LevelConditionCheckFightSpecialEnergyFull : LevelConditionBase
	{
		// Token: 0x06044430 RID: 279600 RVA: 0x011BB8C8 File Offset: 0x011B9AC8
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			int num = int.Parse(inConditionInfo.GetLimitParams("按钮类型") ?? "0");
			if (num == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TL;
				string message = "配置错误！条件的按钮类型不应该为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return Convert.ToInt32(eventArgs[0]) == num;
		}
	}
}
