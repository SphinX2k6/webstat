using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BCC RID: 23500
	[NullableContext(1)]
	[Nullable(0)]
	public class InstanceDungeonVictoryView : CommonResultView
	{
		// Token: 0x0603B806 RID: 243718 RVA: 0x00F15A3B File Offset: 0x00F13C3B
		public InstanceDungeonVictoryView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x1700978E RID: 38798
		// (get) Token: 0x0603B807 RID: 243719 RVA: 0x00F15A50 File Offset: 0x00F13C50
		private InstanceDungeon? InstanceConfig
		{
			get
			{
				if (this.InstanceId == 0)
				{
					return null;
				}
				return ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(this.InstanceId);
			}
		}

		// Token: 0x0603B808 RID: 243720 RVA: 0x00F15A80 File Offset: 0x00F13C80
		protected override void OnStart()
		{
			this.InstanceId = ModelBase<InstanceDungeonEntranceModel>.Instance.InstanceId;
			base.OnStart();
			if (Singleton<UiManager>.Instance.IsViewShow(EUiViewName.ReviveView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.ReviveView, null);
			}
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				this.UpdateOnlineTeamPlayer();
			}
		}

		// Token: 0x0603B809 RID: 243721 RVA: 0x00F15AD6 File Offset: 0x00F13CD6
		private List<CommonResultButtonData> CreateInstanceDungeonCommonButtonData()
		{
			List<CommonResultButtonData> list = new List<CommonResultButtonData>(2);
			list[0] = this.CreateFirstButtonData();
			list[1] = this.CreateSecondButtonData();
			return list;
		}

		// Token: 0x0603B80A RID: 243722 RVA: 0x00F15AF8 File Offset: 0x00F13CF8
		private CommonResultButtonData CreateFirstButtonData()
		{
			CommonResultButtonData commonResultButtonData = new CommonResultButtonData();
			commonResultButtonData.SetRefreshCallBack(delegate(CommonResultButton button)
			{
				button.SetBtnText("ButtonTextExit", Array.Empty<object>());
				int autoLeaveTime = this.InstanceConfig.Value.AutoLeaveTime;
				button.SetFloatTextWithTimer(autoLeaveTime, true, "InstanceDungeonLeftTimeToAutoLeave");
			});
			commonResultButtonData.SetClickCallBack(new Action(this.OnClickBtnLeave));
			return commonResultButtonData;
		}

		// Token: 0x0603B80B RID: 243723 RVA: 0x00F15B23 File Offset: 0x00F13D23
		private CommonResultButtonData CreateSecondButtonData()
		{
			CommonResultButtonData commonResultButtonData = new CommonResultButtonData();
			commonResultButtonData.SetRefreshCallBack(delegate(CommonResultButton button)
			{
				button.SetBtnText("ButtonTextRetry", Array.Empty<object>());
				if (ModelBase<GameModeModel>.Instance.IsMulti)
				{
					if (ModelBase<CreatureModel>.Instance.IsMyWorld())
					{
						button.SetBtnText("ContinueChallenge", Array.Empty<object>());
					}
					else
					{
						button.SetBtnText("SuggestContinueChallenge", Array.Empty<object>());
					}
				}
				this.UpdateButtonPowerTips(button);
			});
			commonResultButtonData.SetClickCallBack(new Action(this.OnClickBtnAgain));
			return commonResultButtonData;
		}

		// Token: 0x0603B80C RID: 243724 RVA: 0x00F15B50 File Offset: 0x00F13D50
		private void UpdateButtonPowerTips(CommonResultButton button)
		{
			int? instancePowerCost = ModelBase<InstanceDungeonEntranceModel>.Instance.GetInstancePowerCost(this.InstanceId);
			bool flag = !(instancePowerCost > 0);
			if (flag)
			{
				return;
			}
			int powerCount = ModelBase<PowerModel>.Instance.PowerCount;
			button.SetTipsItem(5, powerCount.ToString());
			int num = powerCount;
			int? num2 = instancePowerCost;
			if (num >= num2.GetValueOrDefault() & num2 != null)
			{
				button.SetTipsItemTextColor(InstanceDungeonVictoryView.ConditionTextColorWhite);
				return;
			}
			button.SetTipsItemTextColor(InstanceDungeonVictoryView.ConditionTextColorRed);
		}

		// Token: 0x0603B80D RID: 243725 RVA: 0x00F15BD4 File Offset: 0x00F13DD4
		protected override void OnAfterShow()
		{
			this.UpdateView();
		}

		// Token: 0x0603B80E RID: 243726 RVA: 0x00F15BDC File Offset: 0x00F13DDC
		protected override void OnBeforeDestroy()
		{
			ModelBase<ItemHintModel>.Instance.CleanItemRewardList();
			this.PlayerStateItemMap.Clear();
		}

		// Token: 0x0603B80F RID: 243727 RVA: 0x00F15BF3 File Offset: 0x00F13DF3
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add<int, EContinuingChallenge>(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept));
		}

		// Token: 0x0603B810 RID: 243728 RVA: 0x00F15C11 File Offset: 0x00F13E11
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove<int, EContinuingChallenge>(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept));
		}

		// Token: 0x0603B811 RID: 243729 RVA: 0x00F15C2F File Offset: 0x00F13E2F
		private void UpdateView()
		{
			this.UpdateRewardPreview();
		}

		// Token: 0x0603B812 RID: 243730 RVA: 0x00F15C38 File Offset: 0x00F13E38
		private void UpdateRewardPreview()
		{
			this.RewardItemList = ModelBase<InstanceDungeonEntranceModel>.Instance.SettleRewardItemList;
			this.RewardLayout.RebuildLayoutByDataNew<TItem>(this.RewardItemList, null);
		}

		// Token: 0x0603B813 RID: 243731 RVA: 0x00F15C70 File Offset: 0x00F13E70
		protected override void SetupButtonFormat()
		{
			List<CommonResultButtonData> dataList = this.CreateInstanceDungeonCommonButtonData();
			base.RefreshButtonList(dataList);
		}

		// Token: 0x0603B814 RID: 243732 RVA: 0x00F15C8B File Offset: 0x00F13E8B
		private void OnClickBtnLeave()
		{
			ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().ContinueWith(delegate(bool _)
			{
				if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
				{
					base.CloseMe(null);
				}
			});
		}

		// Token: 0x0603B815 RID: 243733 RVA: 0x00F15CAC File Offset: 0x00F13EAC
		private void OnClickBtnAgain()
		{
			if (!ModelBase<GameModeModel>.Instance.IsMulti)
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.RestartInstanceDungeon().ContinueWith(delegate(bool _)
				{
					if (Singleton<UiManager>.Instance.IsViewShow(this.ViewInfo.Name))
					{
						base.CloseMe(null);
					}
				});
				return;
			}
			if (!ModelBase<OnlineModel>.Instance.AllowInitiate)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CannotInvite", Array.Empty<object>());
				return;
			}
			bool flag = ModelBase<CreatureModel>.Instance.IsMyWorld();
			double nextInitiateLeftTime = ModelBase<OnlineModel>.Instance.NextInitiateLeftTime;
			if (nextInitiateLeftTime > 0.0)
			{
				if (flag)
				{
					ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NextInviteTime", new object[]
					{
						Singleton<TimeUtil>.Instance.GetCoolDown(nextInitiateLeftTime)
					});
					return;
				}
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NextSuggestTime", new object[]
				{
					Singleton<TimeUtil>.Instance.GetCoolDown(nextInitiateLeftTime)
				});
				return;
			}
			else
			{
				if (ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(ModelBase<PlayerInfoModel>.Instance.GetId().Value).GetValueOrDefault() == EContinuingChallenge.Pending)
				{
					ControllerBase<OnlineController>.Instance.ApplyRechallengeRequest(ApplyRechallengeReason.Settle);
					return;
				}
				if (flag)
				{
					ControllerBase<OnlineController>.Instance.InviteRechallengeRequest();
					return;
				}
				ControllerBase<OnlineController>.Instance.ApplyRechallengeRequest(ApplyRechallengeReason.Settle);
				return;
			}
		}

		// Token: 0x0603B816 RID: 243734 RVA: 0x00F15DBC File Offset: 0x00F13FBC
		private void UpdateOnlineTeamPlayer()
		{
			List<ScenePlayerData> allScenePlayers = ModelBase<CreatureModel>.Instance.GetAllScenePlayers();
			if (allScenePlayers.Count <= 1)
			{
				base.GetItem(5).SetUIActive(false);
				return;
			}
			base.GetItem(5).SetUIActive(true);
			UUISprite sprite = base.GetSprite(6);
			UUISprite sprite2 = base.GetSprite(7);
			sprite.SetUIActive(false);
			sprite2.SetUIActive(false);
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			foreach (ScenePlayerData scenePlayerData in allScenePlayers)
			{
				int playerId = scenePlayerData.GetPlayerId();
				int num = playerId;
				int? num2 = id;
				if (!(num == num2.GetValueOrDefault() & num2 != null))
				{
					EContinuingChallenge? continuingChallengeConfirmState = ModelBase<OnlineModel>.Instance.GetContinuingChallengeConfirmState(playerId);
					if (!sprite.bIsUIActive)
					{
						sprite.SetUIActive(true);
						this.SetTeamPlayerSprite(continuingChallengeConfirmState.Value, sprite);
						this.PlayerStateItemMap[playerId] = sprite;
					}
					else if (!sprite2.bIsUIActive)
					{
						sprite2.SetUIActive(true);
						this.SetTeamPlayerSprite(continuingChallengeConfirmState.Value, sprite2);
						this.PlayerStateItemMap[playerId] = sprite2;
					}
				}
			}
		}

		// Token: 0x0603B817 RID: 243735 RVA: 0x00F15EE8 File Offset: 0x00F140E8
		private void SetTeamPlayerSprite(EContinuingChallenge state, UUISprite playerSprite)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(OnlineDefine.onlineContinuingChallengeIcon[state]);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				this.SetSpriteByPath(resourcePath, playerSprite, false, null, null);
			}
		}

		// Token: 0x0603B818 RID: 243736 RVA: 0x00F15F28 File Offset: 0x00F14128
		private void OnlineTeamPlayerAccept(int playerId, EContinuingChallenge state)
		{
			UUISprite playerSprite;
			if (!this.PlayerStateItemMap.TryGetValue(playerId, out playerSprite))
			{
				return;
			}
			this.SetTeamPlayerSprite(state, playerSprite);
		}

		// Token: 0x04021836 RID: 137270
		private int InstanceId;

		// Token: 0x04021837 RID: 137271
		private readonly Dictionary<int, UUISprite> PlayerStateItemMap = new Dictionary<int, UUISprite>();

		// Token: 0x04021838 RID: 137272
		[Nullable(2)]
		private TItem[] RewardItemList;

		// Token: 0x04021839 RID: 137273
		private static readonly FColor ConditionTextColorRed = new FColor(246, 93, 88, byte.MaxValue);

		// Token: 0x0402183A RID: 137274
		private static readonly FColor ConditionTextColorWhite = new FColor(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
	}
}
