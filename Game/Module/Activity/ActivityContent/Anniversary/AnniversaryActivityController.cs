using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Anniversary
{
	// Token: 0x020069D0 RID: 27088
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class AnniversaryActivityController : ActivityControllerBase<AnniversaryActivityController>
	{
		// Token: 0x06043279 RID: 275065 RVA: 0x01140794 File Offset: 0x0113E994
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0604327A RID: 275066 RVA: 0x01140796 File Offset: 0x0113E996
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiView_AnniversaryCelebrationMain";
		}

		// Token: 0x0604327B RID: 275067 RVA: 0x0114079D File Offset: 0x0113E99D
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new AnniversaryActivitySubView();
		}

		// Token: 0x0604327C RID: 275068 RVA: 0x011407A4 File Offset: 0x0113E9A4
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			this.CheckOpenActivity(false);
			return new AnniversaryActivityData();
		}

		// Token: 0x0604327D RID: 275069 RVA: 0x011407BE File Offset: 0x0113E9BE
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0604327E RID: 275070 RVA: 0x011407C4 File Offset: 0x0113E9C4
		protected override void OnAddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDone));
			Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.OnActivityOpen, new Action<IReadOnlySet<int>>(this.OnActivityOpenEvent));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x0604327F RID: 275071 RVA: 0x01140828 File Offset: 0x0113EA28
		protected override void OnRemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.WorldDone));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnActivityOpen, new Action<IReadOnlySet<int>>(this.OnActivityOpenEvent));
			Singleton<EventSystem>.Instance.Remove(EEventName.RefreshCommonActivityRedDot, new Action<int>(this.OnRefreshCommonActivityRedDot));
		}

		// Token: 0x06043280 RID: 275072 RVA: 0x0114088C File Offset: 0x0113EA8C
		public void RequestThemePersonalScore(AnniversaryActivityData data)
		{
			List<int> rewardIds = data.GetPersonalCanReceiveRewardIds();
			if (rewardIds == null || rewardIds.Count == 0)
			{
				return;
			}
			ThemePersonalScoreRequest themePersonalScoreRequest = ThemePersonalScoreRequest.Create();
			foreach (int item in rewardIds)
			{
				themePersonalScoreRequest.Ids.Add(item);
			}
			Singleton<Net>.Instance.Call<ThemePersonalScoreResponse>(ERequestMessageId.ThemePersonalScoreRequest, themePersonalScoreRequest, delegate(ThemePersonalScoreResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.ThemePersonalScoreResponse, null, true, true);
					return;
				}
				data.UpdatePersonalRewardIds(rewardIds);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnAnniversaryActivityRewardUpdate);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
			}, 0);
		}

		// Token: 0x06043281 RID: 275073 RVA: 0x0114093C File Offset: 0x0113EB3C
		public void RequestThemeWorldScore(AnniversaryActivityData data)
		{
			List<int> rewardIds = data.GetWorldCanReceiveRewardIds();
			if (rewardIds == null || rewardIds.Count == 0)
			{
				return;
			}
			ThemeWorldScoreRequest themeWorldScoreRequest = ThemeWorldScoreRequest.Create();
			foreach (int item in rewardIds)
			{
				themeWorldScoreRequest.Ids.Add(item);
			}
			Singleton<Net>.Instance.Call<ThemeWorldScoreResponse>(ERequestMessageId.ThemeWorldScoreRequest, themeWorldScoreRequest, delegate(ThemeWorldScoreResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, EResponseMessageId.ThemeWorldScoreResponse, null, true, true);
					return;
				}
				data.UpdateWorldRewardIds(rewardIds);
				Singleton<EventSystem>.Instance.Emit(EEventName.OnAnniversaryActivityRewardUpdate);
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, data.Id);
			}, 0);
		}

		// Token: 0x06043282 RID: 275074 RVA: 0x011409EC File Offset: 0x0113EBEC
		private void WorldDone()
		{
			this.WorldDoneOnce = true;
			this.CheckOpenActivity(false);
		}

		// Token: 0x06043283 RID: 275075 RVA: 0x011409FC File Offset: 0x0113EBFC
		private void CacheSubActivityIds()
		{
			this.SubActivityIds.Clear();
			IReadOnlyList<AnniversaryEntrance> anniversaryEntranceAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceAll();
			if (anniversaryEntranceAll == null)
			{
				return;
			}
			foreach (AnniversaryEntrance anniversaryEntrance in anniversaryEntranceAll)
			{
				this.SubActivityIds.Add(anniversaryEntrance.ActivityId);
			}
		}

		// Token: 0x06043284 RID: 275076 RVA: 0x01140A6C File Offset: 0x0113EC6C
		private void OnActivityOpenEvent(IReadOnlySet<int> openActivities)
		{
			if (this.ActivityId == 0)
			{
				return;
			}
			if (this.SubActivityIds.Count == 0)
			{
				this.CacheSubActivityIds();
			}
			foreach (int item in openActivities)
			{
				if (this.SubActivityIds.Contains(item))
				{
					this.CheckOpenActivity(true);
					break;
				}
			}
		}

		// Token: 0x06043285 RID: 275077 RVA: 0x01140AE0 File Offset: 0x0113ECE0
		private void OnRefreshCommonActivityRedDot(int uid)
		{
			if (this.ActivityId == 0 || uid == this.ActivityId)
			{
				return;
			}
			AnniversaryActivityData anniversaryActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as AnniversaryActivityData;
			if (anniversaryActivityData == null || !anniversaryActivityData.IsRelativeActivityId(uid))
			{
				return;
			}
			TimerSystem.Instance.Delay(delegate(float _)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
			}, 20f, null, null, true, 1f);
		}

		// Token: 0x06043286 RID: 275078 RVA: 0x01140B46 File Offset: 0x0113ED46
		public void SetCheckedOpenActivity(bool value)
		{
			this.HadCheckedOpenActivity = value;
		}

		// Token: 0x06043287 RID: 275079 RVA: 0x01140B50 File Offset: 0x0113ED50
		public void CheckOpenActivity(bool isInstantly = false)
		{
			if (Singleton<PublicUtil>.Instance.GetIsSilentLogin())
			{
				return;
			}
			if (this.ActivityId == 0 || !this.WorldDoneOnce || ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				return;
			}
			if (this.HadCheckedOpenActivity)
			{
				return;
			}
			IReadOnlyList<AnniversaryEntrance> anniversaryEntranceAll = ConfigBase<AnniversaryActivityConfig>.Instance.GetAnniversaryEntranceAll();
			if (anniversaryEntranceAll == null)
			{
				return;
			}
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.AnniversaryActivityFirstClick) as ServerStorageSet;
			bool flag = false;
			foreach (AnniversaryEntrance anniversaryEntrance in anniversaryEntranceAll)
			{
				if (ModelBase<ActivityModel>.Instance.GetActivityById(anniversaryEntrance.ActivityId) != null && (serverStorageSet == null || !serverStorageSet.Has(anniversaryEntrance.ActivityId)))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
			this.HadCheckedOpenActivity = true;
			SplashScreenTask splashScreenTask = new SplashScreenTask(ESplashScreenSourceModuleType.AnniversaryActivity, ESplashScreenType.Config, delegate()
			{
				this.HadCheckedOpenActivity = false;
				TimerSystem.Instance.Delay(delegate(float _)
				{
					ControllerBase<ActivityController>.Instance.OpenActivityById(this.ActivityId, EActivityViewOpenType.Other, null, null);
				}, 100f, null, null, true, 1f);
			});
			ControllerBase<SplashScreenController>.Instance.PushSplashScreenTask(splashScreenTask, isInstantly);
		}

		// Token: 0x040256A9 RID: 153257
		private int ActivityId;

		// Token: 0x040256AA RID: 153258
		private bool WorldDoneOnce;

		// Token: 0x040256AB RID: 153259
		private readonly HashSet<int> SubActivityIds = new HashSet<int>();

		// Token: 0x040256AC RID: 153260
		private bool HadCheckedOpenActivity;
	}
}
