using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BossPiling.View;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EE0 RID: 24288
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Controller(0)]
	public class BossPilingController : ActivityControllerBase<BossPilingController>
	{
		// Token: 0x0603D078 RID: 249976 RVA: 0x00F80A83 File Offset: 0x00F7EC83
		protected override void OnOpenView(ActivityBaseData data)
		{
		}

		// Token: 0x0603D079 RID: 249977 RVA: 0x00F80A85 File Offset: 0x00F7EC85
		protected override string OnGetActivityResource(ActivityBaseData data)
		{
			return "UiItem_BossPilingActivityMain";
		}

		// Token: 0x0603D07A RID: 249978 RVA: 0x00F80A8C File Offset: 0x00F7EC8C
		[NullableContext(0)]
		protected override UniTask<bool> OnOpenSubView(EUiViewName viewName, int activityId = 0)
		{
			BossPilingController.<OnOpenSubView>d__7 <OnOpenSubView>d__;
			<OnOpenSubView>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<OnOpenSubView>d__.<>1__state = -1;
			<OnOpenSubView>d__.<>t__builder.Start<BossPilingController.<OnOpenSubView>d__7>(ref <OnOpenSubView>d__);
			return <OnOpenSubView>d__.<>t__builder.Task;
		}

		// Token: 0x0603D07B RID: 249979 RVA: 0x00F80AC7 File Offset: 0x00F7ECC7
		protected override ActivitySubViewBase OnCreateSubPageComponent(ActivityBaseData data)
		{
			return new BossPilingSubView();
		}

		// Token: 0x0603D07C RID: 249980 RVA: 0x00F80ACE File Offset: 0x00F7ECCE
		protected override ActivityBaseData OnCreateActivityData(ActivityData data)
		{
			this.ActivityId = data.Id;
			return new BossPilingActivityData();
		}

		// Token: 0x0603D07D RID: 249981 RVA: 0x00F80AE1 File Offset: 0x00F7ECE1
		protected override bool OnGetIsOpeningActivityRelativeView()
		{
			return false;
		}

		// Token: 0x0603D07E RID: 249982 RVA: 0x00F80AE4 File Offset: 0x00F7ECE4
		[NullableContext(2)]
		public BossPilingActivityData GetActivityData()
		{
			BossPilingActivityData bossPilingActivityData = ModelBase<ActivityModel>.Instance.GetActivityById(this.ActivityId) as BossPilingActivityData;
			if (bossPilingActivityData == null)
			{
				return null;
			}
			return bossPilingActivityData;
		}

		// Token: 0x0603D07F RID: 249983 RVA: 0x00F80B10 File Offset: 0x00F7ED10
		protected override void OnRegisterNetEvent()
		{
			Singleton<Net>.Instance.Register<BossPilingLevelInfoUpdateNotify>(ENotifyMessageId.BossPilingLevelInfoUpdateNotify, new Action<BossPilingLevelInfoUpdateNotify, Net.CallbackStatus>(this.OnBossPilingLevelInfoUpdateNotify));
			Singleton<Net>.Instance.Register<BossPilingInstNotify>(ENotifyMessageId.BossPilingInstNotify, new Action<BossPilingInstNotify, Net.CallbackStatus>(this.OnBossPilingInstNotify));
			Singleton<Net>.Instance.Register<BossPilingBuffUpdateNotify>(ENotifyMessageId.BossPilingBuffUpdateNotify, new Action<BossPilingBuffUpdateNotify, Net.CallbackStatus>(this.OnBossPilingBuffUpdateNotify));
			Singleton<Net>.Instance.Register<BossPilingSettleNotify>(ENotifyMessageId.BossPilingSettleNotify, new Action<BossPilingSettleNotify, Net.CallbackStatus>(this.OnBossPilingSettleNotify));
			Singleton<Net>.Instance.Register<BossPilingTaskInfoUpdateNotify>(ENotifyMessageId.BossPilingTaskInfoUpdateNotify, new Action<BossPilingTaskInfoUpdateNotify, Net.CallbackStatus>(this.OnBossPilingTaskNotify));
		}

		// Token: 0x0603D080 RID: 249984 RVA: 0x00F80BAC File Offset: 0x00F7EDAC
		protected override void OnUnRegisterNetEvent()
		{
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossPilingLevelInfoUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossPilingInstNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossPilingBuffUpdateNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossPilingSettleNotify);
			Singleton<Net>.Instance.UnRegister(ENotifyMessageId.BossPilingTaskInfoUpdateNotify);
		}

		// Token: 0x0603D081 RID: 249985 RVA: 0x00F80C09 File Offset: 0x00F7EE09
		private void OnBossPilingLevelInfoUpdateNotify(BossPilingLevelInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<BossPilingModel>.Instance.GetActivityData().UpdateLevelData(message.BossPilingLevelInfo.ToArray<BossPilingLevelInfo>());
		}

		// Token: 0x0603D082 RID: 249986 RVA: 0x00F80C28 File Offset: 0x00F7EE28
		private void OnBossPilingInstNotify(BossPilingInstNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			if (this.GetActivityData() == null)
			{
				this.CacheLevelId = message.BossPilingLevelId;
				this.CacheBuffMap = new Dictionary<int, int>();
				foreach (int key in message.BossPilingBuffs.Keys)
				{
					int value = message.BossPilingBuffs[key];
					this.CacheBuffMap[key] = value;
				}
				return;
			}
			ModelBase<BossPilingModel>.Instance.InstBuffAcquireCount = 0;
			ModelBase<BossPilingModel>.Instance.GetActivityData().InitDungeon(message.BossPilingLevelId, message.BossPilingBuffs.ToDictionary<int, int>());
		}

		// Token: 0x0603D083 RID: 249987 RVA: 0x00F80CD8 File Offset: 0x00F7EED8
		private void OnBossPilingBuffUpdateNotify(BossPilingBuffUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			this.RefreshBuffView(message.BossPilingBuffs.ToDictionary<int, int>());
			ModelBase<BossPilingModel>.Instance.GetActivityData().UpdateDungeonBuff(message.BossPilingBuffs.ToDictionary<int, int>());
		}

		// Token: 0x0603D084 RID: 249988 RVA: 0x00F80D05 File Offset: 0x00F7EF05
		private void OnBossPilingSettleNotify(BossPilingSettleNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingSettleView, message, null);
		}

		// Token: 0x0603D085 RID: 249989 RVA: 0x00F80D18 File Offset: 0x00F7EF18
		private void OnBossPilingTaskNotify(BossPilingTaskInfoUpdateNotify message, [Nullable(2)] Net.CallbackStatus _)
		{
			ModelBase<BossPilingModel>.Instance.GetActivityData().UpdateTaskData(message.ConditionTasks.ToArray<ConditionTask>());
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBossPilingReward);
		}

		// Token: 0x0603D086 RID: 249990 RVA: 0x00F80D44 File Offset: 0x00F7EF44
		private void RefreshBuffView(Dictionary<int, int> buffInfo)
		{
			foreach (int num in buffInfo.Keys)
			{
				if (ConfigBase<BossPilingConfig>.Instance.GetBuffInfo(num).Value.Quality == 5)
				{
					ModelBase<BossPilingModel>.Instance.InstKeyBuffList.Add(num);
				}
			}
			if (ModelBase<BossPilingModel>.Instance.InstKeyBuffList.Count > 0 && !Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.BossPilingKeyBuffFloatView))
			{
				Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingKeyBuffFloatView, null, null);
			}
		}

		// Token: 0x0603D087 RID: 249991 RVA: 0x00F80DF4 File Offset: 0x00F7EFF4
		[NullableContext(0)]
		public UniTask<bool> RequestBossPilingReward(int levelId)
		{
			BossPilingController.<RequestBossPilingReward>d__20 <RequestBossPilingReward>d__;
			<RequestBossPilingReward>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestBossPilingReward>d__.levelId = levelId;
			<RequestBossPilingReward>d__.<>1__state = -1;
			<RequestBossPilingReward>d__.<>t__builder.Start<BossPilingController.<RequestBossPilingReward>d__20>(ref <RequestBossPilingReward>d__);
			return <RequestBossPilingReward>d__.<>t__builder.Task;
		}

		// Token: 0x0603D088 RID: 249992 RVA: 0x00F80E38 File Offset: 0x00F7F038
		public void RequestChallenge(int levelId, List<int> teamList, List<int> tagList, bool isBoss = false)
		{
			BossPilingLevels value2 = ConfigBase<BossPilingConfig>.Instance.GetLevelInfo(levelId).Value;
			int instanceId = isBoss ? value2.InstIds()[1] : value2.InstIds()[0];
			ModelBase<BossPilingModel>.Instance.GetActivityData().ClearDungeonInfo();
			BossPilingCtx bossPilingCtx = BossPilingCtx.Create();
			bossPilingCtx.BossPilingLevelId = levelId;
			List<int> list = new List<int>();
			for (int i = 0; i < tagList.Count; i++)
			{
				int num = tagList[i];
				if (num != 0 || teamList[i] != 0)
				{
					list.Add(num);
				}
			}
			bossPilingCtx.SkillBranchId.AddRange(list);
			ModelBase<InstanceDungeonModel>.Instance.InstanceEnterContentText.BossPilingCtx = bossPilingCtx;
			ControllerBase<InstanceDungeonController>.Instance.PrewarTeamFightRequest(instanceId, teamList, 0, 0, null, null).ContinueWith(delegate(bool value)
			{
				if (value)
				{
					this.CurTeamRole = teamList;
					this.CurTeamTag = tagList;
				}
			});
		}

		// Token: 0x0603D089 RID: 249993 RVA: 0x00F80F3C File Offset: 0x00F7F13C
		[NullableContext(0)]
		public UniTask<bool> RequestBossPilingSettle()
		{
			BossPilingController.<RequestBossPilingSettle>d__22 <RequestBossPilingSettle>d__;
			<RequestBossPilingSettle>d__.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<RequestBossPilingSettle>d__.<>1__state = -1;
			<RequestBossPilingSettle>d__.<>t__builder.Start<BossPilingController.<RequestBossPilingSettle>d__22>(ref <RequestBossPilingSettle>d__);
			return <RequestBossPilingSettle>d__.<>t__builder.Task;
		}

		// Token: 0x0603D08A RID: 249994 RVA: 0x00F80F78 File Offset: 0x00F7F178
		public void OpenPauseView()
		{
			InstanceDungeon? instanceDungeon = ModelBase<GameModeModel>.Instance.InstanceDungeon;
			if (instanceDungeon == null || !ModelBase<BossPilingModel>.Instance.CheckIsBossPiling())
			{
				return;
			}
			ValueTuple<int, bool> levelIdAndHalfByInstId = ModelBase<BossPilingModel>.Instance.GetLevelIdAndHalfByInstId(instanceDungeon.Value.Id);
			bool isFirst = levelIdAndHalfByInstId.Item2;
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.BossPilingExitConfirm);
			confirmBoxDataNew.IsEscViewTriggerCallBack = false;
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey(isFirst ? "BossPilingActivity_DungeonQuit05" : "BossPilingActivity_DungeonQuit06");
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				configTextByKey
			});
			confirmBoxDataNew.FunctionMap[1] = delegate()
			{
				if (isFirst)
				{
					Singleton<UiManager>.Instance.OpenView(EUiViewName.BossPilingMainView, null, null);
					return;
				}
				this.RequestBossPilingSettle();
			};
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				ControllerBase<InstanceDungeonController>.Instance.SingleInstReChallengeRequest();
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x040223E4 RID: 140260
		public int ActivityId;

		// Token: 0x040223E5 RID: 140261
		public int CacheLevelId;

		// Token: 0x040223E6 RID: 140262
		[Nullable(2)]
		public Dictionary<int, int> CacheBuffMap;

		// Token: 0x040223E7 RID: 140263
		public List<int> CurTeamRole = new List<int>();

		// Token: 0x040223E8 RID: 140264
		public List<int> CurTeamTag = new List<int>();
	}
}
