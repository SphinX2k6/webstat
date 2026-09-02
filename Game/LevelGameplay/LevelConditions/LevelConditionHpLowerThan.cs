using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006DA1 RID: 28065
	public class LevelConditionHpLowerThan : LevelConditionBase
	{
		// Token: 0x0604458A RID: 279946 RVA: 0x011C1D08 File Offset: 0x011BFF08
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
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
			float num;
			if (!float.TryParse(inConditionInfo.GetLimitParams("Hp"), out num) || num == 0f)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(22, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的Hp参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.HpLowerThan);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance2.Error(module2, author2, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			EntityHandle getCurrentEntity = ModelBase<SceneTeamModel>.Instance.GetCurrentEntity;
			if (getCurrentEntity == null)
			{
				return false;
			}
			BaseAttributeComponent component = getCurrentEntity.Entity.GetComponent<BaseAttributeComponent>();
			float? num2 = (component != null) ? new float?(component.GetCurrentValue(EAttributeType.Life)) : null;
			BaseAttributeComponent component2 = getCurrentEntity.Entity.GetComponent<BaseAttributeComponent>();
			float? num3 = (component2 != null) ? new float?(component2.GetCurrentValue(EAttributeType.LifeMax)) : null;
			return num2 != null && num3 != null && num2.Value / num3.Value < num / 10000f;
		}
	}
}
