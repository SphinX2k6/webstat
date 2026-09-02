using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x02006882 RID: 26754
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DropCatchActivityController : ActivityControllerBase<DropCatchActivityController>
	{
		// Token: 0x06042AA1 RID: 273057 RVA: 0x0111CE3A File Offset: 0x0111B03A
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<DropCatchLevelRewardUpdateNotify>(ENotifyMessageId.DropCatchLevelRewardUpdateNotify, new Action<DropCatchLevelRewardUpdateNotify, Net.CallbackStatus>(this.OnDropCatchLevelRewardResponse));
		}

		// Token: 0x06042AA2 RID: 273058 RVA: 0x0111CE58 File Offset: 0x0111B058
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.DropCatchLevelRewardUpdateNotify);
		}

		// Token: 0x06042AA3 RID: 273059 RVA: 0x0111CE6A File Offset: 0x0111B06A
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x06042AA4 RID: 273060 RVA: 0x0111CE6C File Offset: 0x0111B06C
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_ActivityMainGoldCatch";
		}

		// Token: 0x06042AA5 RID: 273061 RVA: 0x0111CE73 File Offset: 0x0111B073
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new DropCatchSubView();
		}

		// Token: 0x06042AA6 RID: 273062 RVA: 0x0111CE7A File Offset: 0x0111B07A
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new DropCatchActivityData();
		}

		// Token: 0x06042AA7 RID: 273063 RVA: 0x0111CE8D File Offset: 0x0111B08D
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x06042AA8 RID: 273064 RVA: 0x0111CE90 File Offset: 0x0111B090
		private void OnDropCatchLevelRewardResponse(DropCatchLevelRewardUpdateNotify response, [Nullable(2)] Net.CallbackStatus status)
		{
			if (response == null || response.DropCatchLevelInfos == null)
			{
				return;
			}
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				return;
			}
			dropCatchActivityData.OnLevelRewardUpdateNotify(response.DropCatchLevelInfos);
			Singleton<EventSystem>.Instance.Emit(EEventName.DropCatchActivityRewardUpdate);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
		}

		// Token: 0x06042AA9 RID: 273065 RVA: 0x0111CEF8 File Offset: 0x0111B0F8
		public void RequestLevelReward(int configId)
		{
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				return;
			}
			DropCatchLevelRewardRequest dropCatchLevelRewardRequest = DropCatchLevelRewardRequest.Create();
			dropCatchLevelRewardRequest.DropCatchId = configId;
			DropCatchLevelData levelData = dropCatchActivityData.GetLevelData(configId);
			if (levelData == null)
			{
				return;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < levelData.RewardStates.Count; i++)
			{
				if (levelData.RewardStates[i] == EDropCatchLevelState.Unlock)
				{
					list.Add(i);
				}
			}
			dropCatchLevelRewardRequest.RewardIdxs.AddRange(list);
			Singleton<Net>.Instance.Call<DropCatchLevelRewardResponse>(ERequestMessageId.DropCatchLevelRewardRequest, dropCatchLevelRewardRequest, delegate(DropCatchLevelRewardResponse response, Net.CallbackStatus _)
			{
				if (response == null)
				{
					return;
				}
				if (response.Error != ErrorCode.Success)
				{
					ControllerBase<ErrorCodeController>.Instance.OpenErrorCodeTipView(response.Error, 29817, null, true, true);
				}
			}, 0);
		}

		// Token: 0x06042AAA RID: 273066 RVA: 0x0111CFAC File Offset: 0x0111B1AC
		public bool IsNewRoleClicked(int configId)
		{
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.DropCatchRoleClickDetail) as ServerStorageSet;
			return serverStorageSet == null || !serverStorageSet.Has(configId);
		}

		// Token: 0x06042AAB RID: 273067 RVA: 0x0111CFD0 File Offset: 0x0111B1D0
		public void SetNewRoleClicked(int roleId)
		{
			ServerStorageSet serverStorageSet = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.DropCatchRoleClickDetail) as ServerStorageSet;
			if (serverStorageSet == null || !serverStorageSet.Has(roleId))
			{
				if (serverStorageSet != null)
				{
					serverStorageSet.Add(roleId);
				}
				Singleton<EventSystem>.Instance.Emit(EEventName.DropCatchActivityRewardUpdate);
			}
		}

		// Token: 0x06042AAC RID: 273068 RVA: 0x0111D01C File Offset: 0x0111B21C
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			DropCatchActivityController.<OnOpenSubView>d__12 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.viewName = viewName;
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<DropCatchActivityController.<OnOpenSubView>d__12>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x06042AAD RID: 273069 RVA: 0x0111D060 File Offset: 0x0111B260
		public bool CheckLevelCompleted(int levelId)
		{
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应活动信息";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", this.ActivityId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			return dropCatchActivityData.CheckLevelCompleted(levelId);
		}

		// Token: 0x06042AAE RID: 273070 RVA: 0x0111D0C4 File Offset: 0x0111B2C4
		public bool CheckLevelUnlock(int levelId)
		{
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.DropCatch;
				ELogAuthor author = ELogAuthor.CB;
				string message = "找不到对应活动信息";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", this.ActivityId);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return false;
			}
			DropCatchLevelData levelData = dropCatchActivityData.GetLevelData(levelId);
			return levelData != null && levelData.IsUnlock;
		}

		// Token: 0x06042AAF RID: 273071 RVA: 0x0111D134 File Offset: 0x0111B334
		public void SetPreferredOpenLevel(int levelId)
		{
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				return;
			}
			dropCatchActivityData.SetPreferredOpenLevel(levelId);
		}

		// Token: 0x06042AB0 RID: 273072 RVA: 0x0111D164 File Offset: 0x0111B364
		public bool CheckIfActivityClose(bool isShowTips)
		{
			DropCatchActivityData dropCatchActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as DropCatchActivityData;
			if (dropCatchActivityData == null)
			{
				if (isShowTips)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_ErrCoinCatchNotOpen", Array.Empty<object>());
				}
				return true;
			}
			bool flag = dropCatchActivityData.CheckIfClose();
			if (flag && isShowTips)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("ErrorCode_ErrCoinCatchNotOpen", Array.Empty<object>());
			}
			return flag;
		}

		// Token: 0x040251C5 RID: 152005
		public int ActivityId;
	}
}
