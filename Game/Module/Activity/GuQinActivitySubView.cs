using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061D2 RID: 25042
	public class GuQinActivitySubView : ActivitySubViewBase
	{
		// Token: 0x17009B40 RID: 39744
		// (get) Token: 0x0603F303 RID: 258819 RVA: 0x01038A9F File Offset: 0x01036C9F
		[Nullable(1)]
		protected new GuQinActivityData ActivityBaseData
		{
			[NullableContext(1)]
			get
			{
				return (GuQinActivityData)this.ActivityBaseData;
			}
		}

		// Token: 0x0603F304 RID: 258820 RVA: 0x01038AAC File Offset: 0x01036CAC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603F305 RID: 258821 RVA: 0x01038B9C File Offset: 0x01036D9C
		protected override UniTask OnBeforeStartAsync()
		{
			GuQinActivitySubView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<GuQinActivitySubView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603F306 RID: 258822 RVA: 0x01038BE0 File Offset: 0x01036DE0
		protected override void OnRefreshView()
		{
			this.RefreshCondition();
			bool functionRedDotVisible = this.ActivityBaseData.HasRedDot() || this.ActivityBaseData.GetButtonRedPointShowState();
			ActivitySubViewGeneralInfo commonInfoPanel = this.CommonInfoPanel;
			if (commonInfoPanel != null)
			{
				commonInfoPanel.SetFunctionRedDotVisible(functionRedDotVisible);
			}
			UUIItem item = base.GetItem(4);
			if (item != null)
			{
				item.SetUIActive(this.ActivityBaseData.HasNewQuestRedDot());
			}
			bool uiactive = this.ActivityBaseData.IsUnLock();
			UUIItem item2 = base.GetItem(1);
			if (item2 != null)
			{
				item2.SetUIActive(uiactive);
			}
			ValueTuple<int, int> progress = this.ActivityBaseData.GetProgress();
			UUIText text = base.GetText(2);
			if (text != null)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(progress.Item1);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(progress.Item2);
				text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
			this.RefreshRecommendQuestTips();
		}

		// Token: 0x0603F307 RID: 258823 RVA: 0x01038CB8 File Offset: 0x01036EB8
		private void RefreshCondition()
		{
			ActivityFunctionalTypeA functional = this.CommonInfoPanel.GetFunctional();
			ActivityFunctionAreaParams parameters = new ActivityFunctionAreaParams
			{
				UnlockBtnTextId = "LongShanStage_Join01",
				UnlockBtnFunction = new Action(this.OnConfirmBtnClick)
			};
			functional.RefreshGeneralPerformance(parameters);
		}

		// Token: 0x0603F308 RID: 258824 RVA: 0x01038CF9 File Offset: 0x01036EF9
		private void OnConfirmBtnClick()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Farm_ConnectBan", Array.Empty<object>());
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.GuQinActivityMainView, this.ActivityBaseData, null);
		}

		// Token: 0x0603F309 RID: 258825 RVA: 0x01038D34 File Offset: 0x01036F34
		private void RefreshRecommendQuestTips()
		{
			bool flag = !this.ActivityBaseData.IsRecommendQuestFinished();
			this.RecommendQuestTipsSubPanel.SetUiActive(flag);
			if (flag)
			{
				string recommendQuestLabel = this.ActivityBaseData.GetGuQinActivityParamConfig().RecommendQuestLabel;
				this.RecommendQuestTipsSubPanel.SetTipsTxtByTextId(recommendQuestLabel, Array.Empty<string>());
			}
		}

		// Token: 0x0603F30A RID: 258826 RVA: 0x01038D84 File Offset: 0x01036F84
		private void OnRecommendBtnClick()
		{
			int? recommendQuestLinkId = this.ActivityBaseData.GetRecommendQuestLinkId();
			if (recommendQuestLinkId == null || ModelBase<QuestNewModel>.Instance.GetQuest(recommendQuestLinkId.Value) == null)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("GuQinActivity_QuestNotAcceptedTips", Array.Empty<object>());
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, recommendQuestLinkId, null);
		}

		// Token: 0x0603F30B RID: 258827 RVA: 0x01038DE3 File Offset: 0x01036FE3
		private void ExtraButtonFunction()
		{
			if (!this.ActivityBaseData.SaveFirstCheckRedDotState(EGuQinActivityCheckSaveFlag.PreOpen, 0))
			{
				this.OnRefreshView();
			}
		}

		// Token: 0x040237D6 RID: 145366
		[Nullable(2)]
		private ActivitySubViewGeneralInfo CommonInfoPanel;

		// Token: 0x040237D7 RID: 145367
		[Nullable(2)]
		private RecommendQuestTipsSubPanel RecommendQuestTipsSubPanel;

		// Token: 0x0200C311 RID: 49937
		private class EComponent
		{
			// Token: 0x0403C20A RID: 246282
			public const int UiItemComActivityInfo = 0;

			// Token: 0x0403C20B RID: 246283
			public const int PnlProgress = 1;

			// Token: 0x0403C20C RID: 246284
			public const int TextProgress = 2;

			// Token: 0x0403C20D RID: 246285
			public const int PreOpenTipsItem = 3;

			// Token: 0x0403C20E RID: 246286
			public const int PnlUnlockTips = 4;

			// Token: 0x0403C20F RID: 246287
			public const int TextUnlockTips = 5;
		}
	}
}
