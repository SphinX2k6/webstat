using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Extension;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006D99 RID: 28057
	public class LevelConditionCheckUiItemShow : LevelConditionBase
	{
		// Token: 0x0604457A RID: 279930 RVA: 0x011C183C File Offset: 0x011BFA3C
		[NullableContext(1)]
		public override bool Check(Condition inConditionInfo, [Nullable(2)] AActor inTrigger, params object[] eventArgs)
		{
			string limitParams = inConditionInfo.GetLimitParams("ViewName");
			string limitParams2 = inConditionInfo.GetLimitParams("MarkName");
			if (limitParams == null || limitParams2 == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelCondition;
				ELogAuthor author = ELogAuthor.HYF;
				string message = "LevelConditionCheckUiItemShow: 配置错误，参数不能为空";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("inConditionInfo.Id", inConditionInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			UiViewBase viewByName = Singleton<UiManager>.Instance.GetViewByName((EUiViewName)limitParams);
			if (viewByName == null || !viewByName.IsShowOrShowing)
			{
				return false;
			}
			AActor rootActor = viewByName.GetRootActor();
			UUIGuideMarkComponent uuiguideMarkComponent = ((rootActor != null) ? rootActor.GetComponentByClass(UUIGuideMarkComponent.StaticClass()) : null) as UUIGuideMarkComponent;
			if (uuiguideMarkComponent == null)
			{
				Singleton<Log>.Instance.Info(ELogModule.Guide, ELogAuthor.HYF, "LevelConditionCheckUiItemShow: 没有挂载UIGuideMarkComponent组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return false;
			}
			TWeakObjectPtr<AActor>? valueOrNull = uuiguideMarkComponent.Children.GetValueOrNull(limitParams2);
			AUIBaseActor auibaseActor = (AUIBaseActor)((valueOrNull != null) ? valueOrNull.GetValueOrDefault() : null);
			if (auibaseActor == null)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.LevelCondition;
				ELogAuthor author2 = ELogAuthor.HYF;
				string message2 = "LevelConditionCheckUiItemShow: 没有找到对应的引导标记";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("MarkName", limitParams2);
				instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return false;
			}
			UUIItem uiitem = auibaseActor.GetUIItem();
			return uiitem != null && uiitem.IsUIActiveInHierarchy();
		}
	}
}
