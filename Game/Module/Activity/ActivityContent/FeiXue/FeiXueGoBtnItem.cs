using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.FeiXue
{
	// Token: 0x02006849 RID: 26697
	[NullableContext(2)]
	[Nullable(0)]
	public class FeiXueGoBtnItem : UiPanelBase
	{
		// Token: 0x0604289A RID: 272538 RVA: 0x01113FE0 File Offset: 0x011121E0
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIText)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite)),
				new ValueTuple<int, Type>(5, typeof(UUIItem))
			};
			this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
			{
				new ValueTuple<int, Delegate>(0, new Action(this.OnClickGoButton))
			};
		}

		// Token: 0x0604289B RID: 272539 RVA: 0x0111409F File Offset: 0x0111229F
		protected override void OnStart()
		{
			this.GoBtnInteraction = (base.GetButton(0).GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup);
		}

		// Token: 0x0604289C RID: 272540 RVA: 0x011140C7 File Offset: 0x011122C7
		protected override void OnBeforeDestroy()
		{
			this.TryDisableRefreshTimer();
		}

		// Token: 0x0604289D RID: 272541 RVA: 0x011140D0 File Offset: 0x011122D0
		[NullableContext(1)]
		public void RefreshBtnView(FeiXuePreheatTaskData data, ActivityFeiXuePreheatData activityData)
		{
			this.Data = data;
			this.ActivityData = activityData;
			bool isLock = data.IsLock;
			base.GetSprite(4).SetUIActive(isLock);
			base.GetSprite(3).SetUIActive(!isLock);
			this.GoBtnInteraction.SetInteractable(!isLock);
			if (isLock)
			{
				this.RefreshRemainTimeText(0f);
				this.TryEnableRefreshTimer();
			}
			else
			{
				this.TryDisableRefreshTimer();
				Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), data.QuestName, Array.Empty<object>());
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "FeiXueWarmup_1001", new <>z__ReadOnlyArray<object>(new object[]
			{
				this.ActivityData.GetClaimableOrFinishedTaskNum(),
				this.ActivityData.GetTotalTaskNum()
			}));
			base.GetItem(5).SetUIActive(this.ActivityData.IsFirstDoingTaskIsUnClick());
		}

		// Token: 0x0604289E RID: 272542 RVA: 0x011141B4 File Offset: 0x011123B4
		private void TryEnableRefreshTimer()
		{
			if (this.RefreshTimer != null)
			{
				return;
			}
			this.RefreshTimer = TimerSystem.GameplayTimeInstance.Forever(new TTimerAction(this.RefreshRemainTimeText), (float)Singleton<TimeUtil>.Instance.InverseMillisecond, 1f, null, null, true);
		}

		// Token: 0x0604289F RID: 272543 RVA: 0x011141EE File Offset: 0x011123EE
		private void TryDisableRefreshTimer()
		{
			if (this.RefreshTimer == null)
			{
				return;
			}
			TimerSystem.GameplayTimeInstance.Remove(this.RefreshTimer);
			this.RefreshTimer = null;
		}

		// Token: 0x060428A0 RID: 272544 RVA: 0x01114214 File Offset: 0x01112414
		public void RefreshRemainTimeText(float delta)
		{
			double num = Math.Max(0.0, (double)(this.Data.UnlockTime / (long)Singleton<TimeUtil>.Instance.InverseMillisecond) - Singleton<TimeUtil>.Instance.GetServerTime());
			if (num <= 0.0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.LZK;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(32, 2);
				defaultInterpolatedStringHandler.AppendLiteral("剩余时间显示失败，绯雪任务解锁时间戳小于当前时间戳，Id");
				defaultInterpolatedStringHandler.AppendFormatted<int>(this.Data.Config.Value.Id);
				defaultInterpolatedStringHandler.AppendLiteral("，时间戳");
				defaultInterpolatedStringHandler.AppendFormatted<long>(this.Data.UnlockTime);
				instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				this.TryDisableRefreshTimer();
				return;
			}
			string multiText = ConfigBase<TextConfig>.Instance.GetMultiText("FeiXueWarmup_1002", Array.Empty<string>());
			string countDownText = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat3(num).CountDownText;
			base.GetText(1).SetText(multiText + countDownText, true);
		}

		// Token: 0x060428A1 RID: 272545 RVA: 0x01114318 File Offset: 0x01112518
		private void OnClickGoButton()
		{
			if (this.Data == null)
			{
				return;
			}
			if (this.ActivityData.GetFirstDoingTaskIndex() == -1)
			{
				return;
			}
			this.ActivityData.CancelFirstDoingTaskRedDot();
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshActivityTab, this.ActivityData.Id);
			SkipTaskManager.Run(ESkipName.SkipToQuest, new object[]
			{
				this.Data.Config.Value.QuestId,
				"0"
			});
		}

		// Token: 0x04025093 RID: 151699
		private UUIInteractionGroup GoBtnInteraction;

		// Token: 0x04025094 RID: 151700
		private ActivityFeiXuePreheatData ActivityData;

		// Token: 0x04025095 RID: 151701
		private FeiXuePreheatTaskData Data;

		// Token: 0x04025096 RID: 151702
		private TimerHandle RefreshTimer;
	}
}
