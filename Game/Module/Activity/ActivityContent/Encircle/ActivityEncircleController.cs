using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.ItemReward;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006855 RID: 26709
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ActivityEncircleController : ActivityControllerBase<ActivityEncircleController>
	{
		// Token: 0x06042946 RID: 272710 RVA: 0x01117413 File Offset: 0x01115613
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06042947 RID: 272711 RVA: 0x01117415 File Offset: 0x01115615
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<EncircleChallengeUpdateNotify>(ENotifyMessageId.EncircleChallengeUpdateNotify, new Action<EncircleChallengeUpdateNotify, Net.CallbackStatus>(this.OnEncircleChallengeUpdateNotify));
		}

		// Token: 0x06042948 RID: 272712 RVA: 0x01117433 File Offset: 0x01115633
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.EncircleChallengeUpdateNotify);
		}

		// Token: 0x06042949 RID: 272713 RVA: 0x01117445 File Offset: 0x01115645
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityEncircleMain";
		}

		// Token: 0x0604294A RID: 272714 RVA: 0x0111744C File Offset: 0x0111564C
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new ActivityEncircleSubView();
		}

		// Token: 0x0604294B RID: 272715 RVA: 0x01117453 File Offset: 0x01115653
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new ActivityEncircleData();
		}

		// Token: 0x0604294C RID: 272716 RVA: 0x01117468 File Offset: 0x01115668
		[NullableContext(2)]
		public ActivityEncircleData GetEncircleData()
		{
			List<ActivityBaseData> currentActivitiesByType = ModelBase<ActivityModel>.Instance.GetCurrentActivitiesByType(ActivityType.Encircle);
			ActivityEncircleData result = null;
			if (currentActivitiesByType.Count != 0)
			{
				result = (currentActivitiesByType[0] as ActivityEncircleData);
			}
			return result;
		}

		// Token: 0x0604294D RID: 272717 RVA: 0x0111749C File Offset: 0x0111569C
		public RewardData<IEncircleRewardInfo> BuildRewardData(List<RewardItemData> rewardItemDataList)
		{
			int currentChallengeId = Singleton<EncirclePlayLevelController>.Instance.GetCurrentChallengeId();
			ActivityEncircleData encircleData = this.GetEncircleData();
			return new RewardData<IEncircleRewardInfo>(new EncircleRewardInfo
			{
				IsSuccess = true,
				Score = new int?(Singleton<EncirclePlayLevelController>.Instance.GetTotalRound()),
				RecordScore = new int?((encircleData != null) ? encircleData.GetChallengeRecord(currentChallengeId) : 0),
				CommonItems = rewardItemDataList,
				Type = ERewardInfoType.Explore,
				ViewName = EUiViewName.EncircleResultView
			}, null);
		}

		// Token: 0x0604294E RID: 272718 RVA: 0x01117514 File Offset: 0x01115714
		public bool GetRedPointShow()
		{
			int activityId = this.ActivityId;
			IReadOnlyList<EncircleChallengeGroup> encircleGroups = ConfigBase<ActivityEncircleConfig>.Instance.GetEncircleGroups(activityId);
			if (encircleGroups == null)
			{
				return false;
			}
			ActivityEncircleData encircleData = this.GetEncircleData();
			if (encircleData == null)
			{
				return false;
			}
			foreach (EncircleChallengeGroup encircleChallengeGroup in encircleGroups)
			{
				if (encircleData.CheckGroupRedPointShow(encircleChallengeGroup.Id))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0604294F RID: 272719 RVA: 0x01117594 File Offset: 0x01115794
		public void SendCompleteRequest(EncircleChallengeCompleteRequest request, Action callback)
		{
			Singleton<Net>.Instance.Call<EncircleChallengeCompleteResponse>(ERequestMessageId.EncircleChallengeCompleteRequest, request, delegate(EncircleChallengeCompleteResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15438, null, true, true);
				}
				callback();
			}, 0);
		}

		// Token: 0x06042950 RID: 272720 RVA: 0x011175CC File Offset: 0x011157CC
		public static void SendEnterRequest(EncircleChallengeStartRequest request, Action callback)
		{
			Singleton<Net>.Instance.Call<EncircleChallengeStartResponse>(ERequestMessageId.EncircleChallengeStartRequest, request, delegate(EncircleChallengeStartResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.ErrorCode != Aki.Protocol.ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.ErrorCode, 15438, null, true, true);
				}
				callback();
			}, 0);
		}

		// Token: 0x06042951 RID: 272721 RVA: 0x01117603 File Offset: 0x01115803
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06042952 RID: 272722 RVA: 0x01117608 File Offset: 0x01115808
		private void OnEncircleChallengeUpdateNotify(EncircleChallengeUpdateNotify notify, [Nullable(2)] Net.CallbackStatus status)
		{
			foreach (EncircleChallengePb challengeInfo in notify.Challenges)
			{
				this.GetEncircleData().UpdateChallengeInfo(challengeInfo);
			}
		}

		// Token: 0x040250F1 RID: 151793
		public int ActivityId;
	}
}
