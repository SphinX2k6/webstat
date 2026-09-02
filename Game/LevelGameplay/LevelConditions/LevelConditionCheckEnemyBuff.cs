using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006CE8 RID: 27880
	public class LevelConditionCheckEnemyBuff : LevelConditionBase
	{
		// Token: 0x06044401 RID: 279553 RVA: 0x011B9B14 File Offset: 0x011B7D14
		[NullableContext(1)]
		public unsafe override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs == null || eventArgs.Length == 0)
			{
				return false;
			}
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
			int num = int.Parse(inConditionInfo.GetLimitParams("BuffId"));
			if (num == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的BuffId参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.CheckEnemyBuff);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			IReadOnlyList<int> readOnlyList = eventArgs[0] as IReadOnlyList<int>;
			if (readOnlyList == null)
			{
				object obj = eventArgs[0];
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.LevelCondition;
				ELogAuthor author3 = ELogAuthor.TL;
				string message2 = "事件参数类型错误，期望 IReadOnlyList<int>";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ConditionId", inConditionInfo.Id);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("ArgType", (obj == null) ? "null" : (obj.GetType().FullName ?? "null"));
				instance3.Error(module3, author3, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
				return false;
			}
			foreach (int id in readOnlyList)
			{
				Entity entity = Singleton<EntitySystem>.Instance.Get(id);
				int? num2;
				if (entity == null)
				{
					num2 = null;
				}
				else
				{
					CharacterBuffComponent component = entity.GetComponent<CharacterBuffComponent>();
					num2 = ((component != null) ? new int?(component.GetBuffTotalStackById((long)num, false)) : null);
				}
				int? num3 = num2;
				if (num3.GetValueOrDefault() > 0)
				{
					return true;
				}
			}
			return false;
		}
	}
}
