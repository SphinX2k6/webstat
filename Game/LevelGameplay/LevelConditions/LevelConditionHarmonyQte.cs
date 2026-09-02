using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.NewWorld.Character.Common.Component.Abilities;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DA2 RID: 28066
	public class LevelConditionHarmonyQte : LevelConditionBase
	{
		// Token: 0x0604458C RID: 279948 RVA: 0x011C1E68 File Offset: 0x011C0068
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			if (eventArgs != null && eventArgs.Length == 0)
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
			int num;
			if (!int.TryParse(inConditionInfo.GetLimitParams("ElementType"), out num) || num == 0 || num >= 7)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(31, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的ElementType参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.HarmonyQte);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			Entity entity = (Entity)eventArgs[0];
			Entity entity2 = (Entity)eventArgs[1];
			RoleElementComponent component = entity.GetComponent<RoleElementComponent>();
			EElementType? eelementType = (component != null) ? new EElementType?(component.RoleElementType) : null;
			RoleElementComponent component2 = entity2.GetComponent<RoleElementComponent>();
			EElementType? eelementType2 = (component2 != null) ? new EElementType?(component2.RoleElementType) : null;
			int num2 = (int)(eelementType.Value * (EElementType)10 + (int)eelementType2.Value);
			int num3 = (int)(eelementType2.Value * (EElementType)10 + (int)eelementType.Value);
			return num2 == num || num3 == num;
		}
	}
}
