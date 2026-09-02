using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x0200657B RID: 25979
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class ActivityPreWarmController : ActivityControllerBase<ActivityPreWarmController>
	{
		// Token: 0x06040E25 RID: 265765 RVA: 0x010A4F18 File Offset: 0x010A3118
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x06040E26 RID: 265766 RVA: 0x010A4F36 File Offset: 0x010A3136
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove<int, QuestState, EQuestStatusUpdateReason>(EEventName.OnQuestStateChange, new Action<int, QuestState, EQuestStatusUpdateReason>(this.OnQuestStateChange));
		}

		// Token: 0x06040E27 RID: 265767 RVA: 0x010A4F54 File Offset: 0x010A3154
		private void OnQuestStateChange(int questId, QuestState state, EQuestStatusUpdateReason reason)
		{
			if (!ModelBase<ActivityPreWarmModel>.Instance.IsHasQuest(questId))
			{
				return;
			}
			if (this.Data == null)
			{
				return;
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.ActivityViewRefreshCurrent, this.Data.Id);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.Data.Id);
		}

		// Token: 0x06040E28 RID: 265768 RVA: 0x010A4FAE File Offset: 0x010A31AE
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06040E29 RID: 265769 RVA: 0x010A4FB0 File Offset: 0x010A31B0
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			ActivityPreWarmModel instance = ModelBase<ActivityPreWarmModel>.Instance;
			int? num = (instance != null) ? instance.GetProgressId() : null;
			if (num == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.ActivityPreWarm, ELogAuthor.CB, "找不到当前正在进行的id", default(ReadOnlySpan<ValueTuple<string, object>>));
				return UniTask.FromResult<bool>(false);
			}
			IActivityPreWarmParam activityPreWarmParam = new IActivityPreWarmParam();
			activityPreWarmParam.Id = num.Value;
			activityPreWarmParam.IsParsing = true;
			ActivityPreWarmData data = this.Data;
			activityPreWarmParam.ActivityId = ((data != null) ? new int?(data.Id) : null);
			IActivityPreWarmParam param = activityPreWarmParam;
			Singleton<UiManager>.Instance.OpenView(viewName, param, null);
			Singleton<Log>.Instance.Info(ELogModule.ActivityPreWarm, ELogAuthor.CB, "打开预热活动界面（解析）", default(ReadOnlySpan<ValueTuple<string, object>>));
			return UniTask.FromResult<bool>(true);
		}

		// Token: 0x06040E2A RID: 265770 RVA: 0x010A5077 File Offset: 0x010A3277
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_PreheatActivityMain";
		}

		// Token: 0x06040E2B RID: 265771 RVA: 0x010A507E File Offset: 0x010A327E
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivitySubViewPreWarm();
		}

		// Token: 0x06040E2C RID: 265772 RVA: 0x010A5085 File Offset: 0x010A3285
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.Data = new ActivityPreWarmData();
			return this.Data;
		}

		// Token: 0x06040E2D RID: 265773 RVA: 0x010A5098 File Offset: 0x010A3298
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x040246B5 RID: 149173
		[Nullable(2)]
		public ActivityPreWarmData Data;
	}
}
