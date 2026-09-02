using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Prepare.Entrance
{
	// Token: 0x020054D3 RID: 21715
	[NullableContext(2)]
	[Nullable(0)]
	public class PhantomArenaGuideSubView : ActivitySubViewBase
	{
		// Token: 0x17008E98 RID: 36504
		// (get) Token: 0x06037504 RID: 226564 RVA: 0x00E0857C File Offset: 0x00E0677C
		protected new PhantomArenaGuideActivityData ActivityBaseData
		{
			get
			{
				return this.ActivityBaseData as PhantomArenaGuideActivityData;
			}
		}

		// Token: 0x06037505 RID: 226565 RVA: 0x00E0858C File Offset: 0x00E0678C
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(USpineSkeletonAnimationComponent)),
				new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUIText)),
				new ValueTuple<int, Type>(5, typeof(UUIButtonComponent))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(5, new Action(this.OnClickRewardBtn))
			};
		}

		// Token: 0x06037506 RID: 226566 RVA: 0x00E0864B File Offset: 0x00E0684B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRewardInfo));
		}

		// Token: 0x06037507 RID: 226567 RVA: 0x00E08669 File Offset: 0x00E06869
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshRewardInfo));
		}

		// Token: 0x06037508 RID: 226568 RVA: 0x00E08688 File Offset: 0x00E06888
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaGuideSubView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaGuideSubView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037509 RID: 226569 RVA: 0x00E086CC File Offset: 0x00E068CC
		protected override void OnBeforeShow()
		{
			string animationName = (ModelBase<PlayerInfoModel>.Instance.GetPlayerGender() == EPlayerGender.Female) ? "IdleF" : "IdleM";
			base.GetSpine(1).SetAnimation(0, animationName, true);
			bool exDataRedPointShowState = this.ActivityBaseData.GetExDataRedPointShowState();
			ActivitySubViewGeneralInfo infoComponent = this.InfoComponent;
			if (infoComponent == null)
			{
				return;
			}
			infoComponent.SetFunctionRedDotVisible(exDataRedPointShowState);
		}

		// Token: 0x0603750A RID: 226570 RVA: 0x00E08724 File Offset: 0x00E06924
		protected override void OnRefreshView()
		{
			int questId = this.ActivityBaseData.GetQuestId();
			string textId = ModelBase<QuestNewModel>.Instance.CheckQuestFinished(questId) ? "Activity_107200001_Challenge" : "Activity_107200001_Mission";
			this.InfoComponent.SetBtnText(textId, Array.Empty<object>());
			this.InfoComponent.RefreshFunction();
			this.RefreshRewardInfo();
		}

		// Token: 0x0603750B RID: 226571 RVA: 0x00E0877C File Offset: 0x00E0697C
		private void RefreshRewardInfo()
		{
			bool flag = this.ActivityBaseData.IsUnLock();
			int targetNum = this.ActivityBaseData.GetTargetNum();
			int finishedChallengeCount = ModelBase<PhantomArenaModel>.Instance.GetFinishedChallengeCount(this.ActivityBaseData.GetPhantomArenaActivityId());
			bool flag2 = finishedChallengeCount >= targetNum && !this.ActivityBaseData.GetIsReceiveReward();
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetUIActive(!flag);
			}
			UUIText text = base.GetText(4);
			if (text != null)
			{
				text.SetUIActive(flag && !flag2);
			}
			UUIButtonComponent button = base.GetButton(5);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(flag && flag2);
			}
			UUIText text2 = base.GetText(4);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int>(finishedChallengeCount);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int>(targetNum);
			text2.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
		}

		// Token: 0x0603750C RID: 226572 RVA: 0x00E0885B File Offset: 0x00E06A5B
		private void OnRefreshRewardInfo(int activityId)
		{
			if (this.ActivityBaseData.Id == activityId)
			{
				this.RefreshRewardInfo();
			}
		}

		// Token: 0x0603750D RID: 226573 RVA: 0x00E08874 File Offset: 0x00E06A74
		private void OnClickConfirm(ActivityBaseData data)
		{
			int questId = this.ActivityBaseData.GetQuestId();
			if (ModelBase<QuestNewModel>.Instance.CheckQuestFinished(questId))
			{
				PhantomArenaBattleController.OpenPhantomArenaMapEntrance(null, null);
				return;
			}
			Singleton<UiManager>.Instance.OpenView(EUiViewName.QuestView, questId, null);
		}

		// Token: 0x0603750E RID: 226574 RVA: 0x00E088C8 File Offset: 0x00E06AC8
		private void OnClickRewardBtn()
		{
			PhantomArenaGuideController.RequestReward(this.ActivityBaseData.Id);
		}

		// Token: 0x0401FC7D RID: 130173
		private ActivitySubViewGeneralInfo InfoComponent;

		// Token: 0x0200B43E RID: 46142
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04037C84 RID: 228484
			public const int InfoItem = 0;

			// Token: 0x04037C85 RID: 228485
			public const int ItemSpine = 1;

			// Token: 0x04037C86 RID: 228486
			public const int LayoutReward = 2;

			// Token: 0x04037C87 RID: 228487
			public const int SpriteLock = 3;

			// Token: 0x04037C88 RID: 228488
			public const int TextProgress = 4;

			// Token: 0x04037C89 RID: 228489
			public const int BtnReward = 5;
		}
	}
}
