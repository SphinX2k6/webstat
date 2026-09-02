using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.FlagChallenge;
using CSharpScript.Game.Module.Plot;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F1E RID: 24350
	[NullableContext(2)]
	[Nullable(0)]
	public class FlagChallengeOccupiedSuccessView : UiViewBase
	{
		// Token: 0x0603D28D RID: 250509 RVA: 0x00F8A8BA File Offset: 0x00F88ABA
		[NullableContext(1)]
		public FlagChallengeOccupiedSuccessView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x17009A32 RID: 39474
		// (get) Token: 0x0603D28E RID: 250510 RVA: 0x00F8A8C3 File Offset: 0x00F88AC3
		public new FlagChallengeOccupiedSuccessViewParams OpenParam
		{
			get
			{
				return this.OpenParam as FlagChallengeOccupiedSuccessViewParams;
			}
		}

		// Token: 0x0603D28F RID: 250511 RVA: 0x00F8A8D0 File Offset: 0x00F88AD0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D290 RID: 250512 RVA: 0x00F8A95C File Offset: 0x00F88B5C
		protected override void OnStart()
		{
			int activityId = this.OpenParam.ActivityId;
			this.LevelText = base.GetArtText(0);
			if (this.LevelText != null)
			{
				(this.LevelText.GetOwner() as AUIBaseActor).OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
				int preCalculatedLevel = ModelBase<FlagChallengeBattleModel>.Instance.GetPreCalculatedLevel();
				this.LevelText.SetText(preCalculatedLevel.ToString());
			}
			int strongholdId = this.OpenParam.StrongholdId;
			FlagChallengeStrongholdData strongholdData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(activityId).GetStrongholdData(strongholdId);
			base.GetItem(2).SetUIActive(strongholdData.IsBossStronghold());
		}

		// Token: 0x0603D291 RID: 250513 RVA: 0x00F8A9FD File Offset: 0x00F88BFD
		protected override void OnBeforeShow()
		{
		}

		// Token: 0x0603D292 RID: 250514 RVA: 0x00F8A9FF File Offset: 0x00F88BFF
		protected override void OnAfterShow()
		{
			UUIArtText levelText = this.LevelText;
			AUIBaseActor auibaseActor = ((levelText != null) ? levelText.GetOwner() : null) as AUIBaseActor;
			if (auibaseActor != null)
			{
				auibaseActor.OnSequencePlayEvent.Unbind();
			}
			this.DelayClose();
		}

		// Token: 0x0603D293 RID: 250515 RVA: 0x00F8AA2E File Offset: 0x00F88C2E
		protected override void OnBeforeDestroy()
		{
			this.ClearDelayTimer();
			this.ClearRollingTimer();
		}

		// Token: 0x0603D294 RID: 250516 RVA: 0x00F8AA3C File Offset: 0x00F88C3C
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<PlotInfo>(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		}

		// Token: 0x0603D295 RID: 250517 RVA: 0x00F8AA5A File Offset: 0x00F88C5A
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.PlotNetworkStart, new Action<PlotInfo>(this.OnSequenceNetworkStart));
		}

		// Token: 0x0603D296 RID: 250518 RVA: 0x00F8AA78 File Offset: 0x00F88C78
		[NullableContext(1)]
		private void OnSequenceNetworkStart(PlotInfo plotInfo)
		{
			this.TryCloseMe();
		}

		// Token: 0x0603D297 RID: 250519 RVA: 0x00F8AA80 File Offset: 0x00F88C80
		private void TryCloseMe()
		{
			if (!base.IsHideOrHiding)
			{
				base.CloseMe(null);
			}
		}

		// Token: 0x0603D298 RID: 250520 RVA: 0x00F8AA91 File Offset: 0x00F88C91
		private void DelayClose()
		{
			this.ClearDelayTimer();
			this.DelayTimer = TimerSystem.GameplayTimeInstance.Delay(delegate(float _)
			{
				this.DelayTimer = null;
				this.TryCloseMe();
			}, 2000f, null, null, true, 1f);
		}

		// Token: 0x0603D299 RID: 250521 RVA: 0x00F8AAC2 File Offset: 0x00F88CC2
		private void ClearDelayTimer()
		{
			if (this.DelayTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.DelayTimer);
				this.DelayTimer = null;
			}
		}

		// Token: 0x0603D29A RID: 250522 RVA: 0x00F8AAE4 File Offset: 0x00F88CE4
		private void ClearRollingTimer()
		{
			if (this.RollingTimer != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.RollingTimer);
				this.RollingTimer = null;
			}
		}

		// Token: 0x0603D29B RID: 250523 RVA: 0x00F8AB06 File Offset: 0x00F88D06
		[NullableContext(1)]
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Level_Switch")
			{
				this.PlayLevelRolling();
			}
		}

		// Token: 0x0603D29C RID: 250524 RVA: 0x00F8AB1C File Offset: 0x00F88D1C
		private void PlayLevelRolling()
		{
			float elapsedTime = 0f;
			int startValue = ModelBase<FlagChallengeBattleModel>.Instance.GetPreCalculatedLevel();
			int targetValue = ModelBase<FlagChallengeBattleModel>.Instance.GetCalculatedLevel();
			this.RollingTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
			{
				elapsedTime += delta;
				if (elapsedTime >= 500f)
				{
					this.ClearRollingTimer();
					UUIArtText levelText = this.LevelText;
					if (levelText == null)
					{
						return;
					}
					levelText.SetText(targetValue.ToString());
					return;
				}
				else
				{
					float num = MathF.Min(elapsedTime / 500f, 1f);
					num = 1f - MathF.Pow(1f - num, 3f);
					float x = Singleton<MathUtils>.Instance.Lerp((float)startValue, (float)targetValue, num);
					UUIArtText levelText2 = this.LevelText;
					if (levelText2 == null)
					{
						return;
					}
					levelText2.SetText(MathF.Round(x).ToString(CultureInfo.InvariantCulture));
					return;
				}
			}, 20f, 1f, null, null, true);
		}

		// Token: 0x040224C4 RID: 140484
		private const float DELAY_CLOSE_TIME = 2000f;

		// Token: 0x040224C5 RID: 140485
		private const float ROLLING_DURATION = 500f;

		// Token: 0x040224C6 RID: 140486
		private UUIArtText LevelText;

		// Token: 0x040224C7 RID: 140487
		private TimerHandle DelayTimer;

		// Token: 0x040224C8 RID: 140488
		private TimerHandle RollingTimer;

		// Token: 0x0200BF25 RID: 48933
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403AD5C RID: 240988
			LevelText,
			// Token: 0x0403AD5D RID: 240989
			TitleText,
			// Token: 0x0403AD5E RID: 240990
			ClearTipsItem
		}
	}
}
