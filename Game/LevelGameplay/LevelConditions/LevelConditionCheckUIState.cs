using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D66 RID: 28006
	public class LevelConditionCheckUIState : LevelConditionBase
	{
		// Token: 0x06044512 RID: 279826 RVA: 0x011C0328 File Offset: 0x011BE528
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("UIName");
			string limitParams2 = inConditionInfo.GetLimitParams("UIState");
			int num;
			if (limitParams == null || limitParams2 == null || !int.TryParse(limitParams2, out num))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.TL;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(20, 2);
				defaultInterpolatedStringHandler.AppendLiteral("配置错误！条件");
				defaultInterpolatedStringHandler.AppendFormatted<int>(inConditionInfo.Id);
				defaultInterpolatedStringHandler.AppendLiteral("的参数不符合条件类型");
				defaultInterpolatedStringHandler.AppendFormatted<ELevelGeneralCondition>(ELevelGeneralCondition.CheckUIState);
				defaultInterpolatedStringHandler.AppendLiteral("的定义");
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			if (num != 0)
			{
				return Singleton<UiManager>.Instance.IsViewShow((EUiViewName)limitParams);
			}
			return !Singleton<UiManager>.Instance.IsViewShow((EUiViewName)limitParams);
		}
	}
}
