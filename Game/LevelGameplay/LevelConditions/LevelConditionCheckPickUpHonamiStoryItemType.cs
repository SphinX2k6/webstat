using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.HonamiStory;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D9D RID: 28061
	public class LevelConditionCheckPickUpHonamiStoryItemType : LevelConditionBase
	{
		// Token: 0x06044582 RID: 279938 RVA: 0x011C1A44 File Offset: 0x011BFC44
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ItemType");
			if (limitParams == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TZJ;
				string message = "条件：检查穗波物语拾取物品类型 需要配置目标类型作为参数";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("condition id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			int num;
			if (!int.TryParse(limitParams, out num))
			{
				return false;
			}
			HonamiStoryItemDataBase honamiStoryItemDataBase = eventArgs[0] as HonamiStoryItemDataBase;
			if (honamiStoryItemDataBase == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TZJ;
				string message2 = "条件：检查穗波物语拾取物品类型 事件参数类型错误";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("eventArg", ((honamiStoryItemDataBase != null) ? honamiStoryItemDataBase.GetType().ToString() : null) ?? "null");
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			return honamiStoryItemDataBase.GetItemType() == (EHonamiStoryItemType)num;
		}
	}
}
