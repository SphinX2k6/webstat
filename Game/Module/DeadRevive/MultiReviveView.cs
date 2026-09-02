using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.DeadRevive
{
	// Token: 0x02005DC7 RID: 24007
	[NullableContext(1)]
	[Nullable(0)]
	public class MultiReviveView : UiTickViewBase
	{
		// Token: 0x0603C6F8 RID: 247544 RVA: 0x00F5846C File Offset: 0x00F5666C
		public MultiReviveView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603C6F9 RID: 247545 RVA: 0x00F584A0 File Offset: 0x00F566A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 12;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 4;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickQuitBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickAgainBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(7, new Action(this.OnClickReviveBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(9, new Action(this.OnClickReviveAtLocationBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603C6FA RID: 247546 RVA: 0x00F58700 File Offset: 0x00F56900
		protected override void OnAddEventListener()
		{
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				Singleton<EventSystem>.Instance.Add<int, EContinuingChallenge>(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept));
				Singleton<EventSystem>.Instance.Add<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
			}
		}

		// Token: 0x0603C6FB RID: 247547 RVA: 0x00F58754 File Offset: 0x00F56954
		protected override void OnRemoveEventListener()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.PlayerChallengeStateChange, new Action<int, EContinuingChallenge>(this.OnlineTeamPlayerAccept));
			}
			if (Singleton<EventSystem>.Instance.Has(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.OnTeamLivingStateChange, new Action<bool, ETeamGroupType, ETeamLivingState, ETeamLivingState>(this.OnTeamLivingStateChange));
			}
		}

		// Token: 0x0603C6FC RID: 247548 RVA: 0x00F587D4 File Offset: 0x00F569D4
		protected override void OnBeforeShow()
		{
			bool flag = ControllerBase<GameModeController>.Instance.IsInInstance();
			base.GetButton(1).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(2).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(7).RootUIComp.Get().SetUIActive(!flag);
			if (flag)
			{
				this.UpdateOnlineTeamPlayer();
				this.UpdateOnlineText();
				return;
			}
			base.GetItem(3).SetUIActive(false);
			this.InitRevive();
		}

		// Token: 0x0603C6FD RID: 247549 RVA: 0x00F58860 File Offset: 0x00F56A60
		protected override void OnBeforeDestroy()
		{
			this.ResetData();
		}

		// Token: 0x0603C6FE RID: 247550 RVA: 0x00F58868 File Offset: 0x00F56A68
		private void ResetData()
		{
			this.ReviveNumber = -1;
			this.AutoReviveTime = 0;
			this.AutoReviveText = null;
			this.ReviveAtLocationName = "";
			this.ReviveAtLocationCd = "";
			if (this.AutoReviveTimer != null)
			{
				this.AutoReviveTimer.Remove();
				this.AutoReviveTimer = null;
			}
			if (this.PlayerStateItemMap != null)
			{
				this.PlayerStateItemMap.Clear();
			}
		}

		// Token: 0x0603C6FF RID: 247551 RVA: 0x00F588D0 File Offset: 0x00F56AD0
		private void InitRevive()
		{
			Revive? reviveConfig = ModelBase<DeadReviveModel>.Instance.ReviveConfig;
			if (reviveConfig != null)
			{
				this.ReviveNumber = reviveConfig.Value.ReviveTimes;
			}
			if (this.AutoReviveTimer == null)
			{
				this.AutoReviveTime = 60;
				this.AutoReviveText = base.GetText(8);
				Singleton<LguiUtil>.Instance.SetLocalText(this.AutoReviveText, "ReviveItemTips", new <>z__ReadOnlySingleElementList<object>(this.AutoReviveTime));
				this.AutoReviveTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					if (this.AutoReviveTime <= 0)
					{
						ControllerBase<ConfirmBoxController>.Instance.CloseConfirmBoxView();
						this.OnClickReviveBtn();
						if (this.AutoReviveTimer != null)
						{
							this.AutoReviveTimer.Remove();
							this.AutoReviveTimer = null;
						}
						return;
					}
					this.AutoReviveTime--;
					Singleton<LguiUtil>.Instance.SetLocalText(this.AutoReviveText, "ReviveItemTips", new <>z__ReadOnlySingleElementList<object>(this.AutoReviveTime));
				}, 1000f, 1f, null, null, true);
			}
			int num = -1;
			Revive? reviveConfig2 = ModelBase<DeadReviveModel>.Instance.ReviveConfig;
			if (reviveConfig2 != null)
			{
				num = reviveConfig2.Value.UseItemId;
			}
			int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(num, 0);
			if (itemCountByConfigId <= 0)
			{
				return;
			}
			base.GetButton(9).RootUIComp.Get().SetUIActive(true);
			UUITexture texture = base.GetTexture(10);
			UUIText text = base.GetText(11);
			BuffItemModel instance = ModelBase<BuffItemModel>.Instance;
			base.SetItemIcon(texture, num, null, null);
			this.ReviveAtLocationName = ConfigBase<ItemConfig>.Instance.GetItemName(num);
			int buffItemTotalCdTime = ConfigBase<BuffItemConfig>.Instance.GetBuffItemTotalCdTime(num);
			if ((double)buffItemTotalCdTime < Singleton<TimeUtil>.Instance.Minute)
			{
				this.ReviveAtLocationCd = buffItemTotalCdTime.ToString() + ConfigBase<TextConfig>.Instance.GetTextById("Second");
			}
			else
			{
				this.ReviveAtLocationCd = Math.Floor((double)buffItemTotalCdTime / Singleton<TimeUtil>.Instance.Minute).ToString() + ConfigBase<TextConfig>.Instance.GetTextById("MinuteText");
				double num2 = (double)buffItemTotalCdTime % Singleton<TimeUtil>.Instance.Minute;
				if (num2 > 0.0)
				{
					this.ReviveAtLocationCd = this.ReviveAtLocationCd + num2.ToString() + ConfigBase<TextConfig>.Instance.GetTextById("Second");
				}
			}
			if (instance.GetBuffItemRemainCdTime(num) > 0.0)
			{
				Singleton<LguiUtil>.Instance.SetLocalText(text, "ReviveItemCd", Array.Empty<object>());
				(base.GetButton(9).GetOwner().GetComponentByClass(UUIInteractionGroup.StaticClass()) as UUIInteractionGroup).SetInteractable(false);
				return;
			}
			text.SetText(itemCountByConfigId.ToString(), true);
		}

		// Token: 0x0603C700 RID: 247552 RVA: 0x00F58B1C File Offset: 0x00F56D1C
		private void OnClickReviveBtn()
		{
			if (this.ReviveNumber == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("CannotRevive", Array.Empty<object>());
				return;
			}
			this.RequestRevive(false);
		}

		// Token: 0x0603C701 RID: 247553 RVA: 0x00F58B44 File Offset: 0x00F56D44
		private void OnClickReviveAtLocationBtn()
		{
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.UsingItemRevive);
			confirmBoxDataNew.SetTextArgs(new string[]
			{
				this.ReviveAtLocationName,
				this.ReviveAtLocationCd
			});
			confirmBoxDataNew.FunctionMap[2] = delegate()
			{
				this.RequestRevive(true);
			};
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C702 RID: 247554 RVA: 0x00F58B9C File Offset: 0x00F56D9C
		private void RequestRevive(bool useItem)
		{
			ControllerBase<DeadReviveController>.Instance.ReviveRequest(useItem, delegate(bool result)
			{
				if (result)
				{
					this.ResetData();
				}
			}, null);
		}

		// Token: 0x0603C703 RID: 247555 RVA: 0x00F58BCC File Offset: 0x00F56DCC
		private void UpdateOnlineTeamPlayer()
		{
			UUIText text = base.GetText(0);
			UUIItem item = base.GetItem(3);
			List<ScenePlayerData> allScenePlayers = ModelBase<CreatureModel>.Instance.GetAllScenePlayers();
			bool flag = true;
			foreach (ScenePlayerData scenePlayerData in allScenePlayers)
			{
				if (ModelBase<SceneTeamModel>.Instance.GetGroupLivingState(scenePlayerData.GetPlayerId(), ETeamGroupType.Battle) == ETeamLivingState.Alive)
				{
					flag = false;
					break;
				}
			}
			if (allScenePlayers.Count <= 1 || !flag)
			{
				text.SetUIActive(true);
				item.SetUIActive(false);
				return;
			}
			text.SetUIActive(false);
			item.SetUIActive(true);
			UUISprite sprite = base.GetSprite(4);
			UUISprite sprite2 = base.GetSprite(5);
			sprite.SetUIActive(false);
			sprite2.SetUIActive(false);
			int? id = ModelBase<PlayerInfoModel>.Instance.GetId();
			foreach (ScenePlayerData scenePlayerData2 in allScenePlayers)
			{
				int playerId = scenePlayerData2.GetPlayerId();
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

		// Token: 0x0603C704 RID: 247556 RVA: 0x00F58D6C File Offset: 0x00F56F6C
		private void UpdateOnlineText()
		{
			if (ModelBase<CreatureModel>.Instance.IsMyWorld())
			{
				Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "ChallengeAgain", Array.Empty<object>());
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(6), "SuggestChallengeAgain", Array.Empty<object>());
		}

		// Token: 0x0603C705 RID: 247557 RVA: 0x00F58DBC File Offset: 0x00F56FBC
		private void SetTeamPlayerSprite(EContinuingChallenge state, UUISprite playerSprite)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(OnlineDefine.onlineContinuingChallengeIcon[state]);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				this.SetSpriteByPath(resourcePath, playerSprite, false, null, null);
			}
		}

		// Token: 0x0603C706 RID: 247558 RVA: 0x00F58DFC File Offset: 0x00F56FFC
		private void OnClickQuitBtn()
		{
			if (ModelBase<SceneTeamModel>.Instance.IsAllDid())
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
				return;
			}
			ConfirmBoxDataNew confirmBoxDataNew = new ConfirmBoxDataNew(EConfirmBoxConfigId.OnlineQuitInstance);
			Action value = delegate()
			{
				ControllerBase<InstanceDungeonEntranceController>.Instance.LeaveInstanceDungeon().Forget<bool>();
			};
			confirmBoxDataNew.FunctionMap[2] = value;
			ControllerBase<ConfirmBoxController>.Instance.ShowConfirmBoxNew(confirmBoxDataNew);
		}

		// Token: 0x0603C707 RID: 247559 RVA: 0x00F58E68 File Offset: 0x00F57068
		private void OnClickAgainBtn()
		{
			if (!ModelBase<SceneTeamModel>.Instance.IsAllDid())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsById("NeedAllDeadToChallengeAgain", Array.Empty<object>());
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
					ControllerBase<OnlineController>.Instance.ApplyRechallengeRequest(ApplyRechallengeReason.Dead);
					return;
				}
				if (flag)
				{
					ControllerBase<OnlineController>.Instance.InviteRechallengeRequest();
					return;
				}
				ControllerBase<OnlineController>.Instance.ApplyRechallengeRequest(ApplyRechallengeReason.Dead);
				return;
			}
		}

		// Token: 0x0603C708 RID: 247560 RVA: 0x00F58F70 File Offset: 0x00F57170
		private void OnlineTeamPlayerAccept(int playerId, EContinuingChallenge state)
		{
			UUISprite uuisprite;
			this.PlayerStateItemMap.TryGetValue(playerId, out uuisprite);
			if (uuisprite == null)
			{
				return;
			}
			this.SetTeamPlayerSprite(state, uuisprite);
		}

		// Token: 0x0603C709 RID: 247561 RVA: 0x00F58F98 File Offset: 0x00F57198
		private void OnTeamLivingStateChange(bool b, ETeamGroupType eTeamGroupType, ETeamLivingState arg3, ETeamLivingState arg4)
		{
			this.UpdateOnlineTeamPlayer();
		}

		// Token: 0x04021FAA RID: 139178
		private const int TIME_SECOND = 1000;

		// Token: 0x04021FAB RID: 139179
		private const int AUTO_REVIVE_TIME = 60;

		// Token: 0x04021FAC RID: 139180
		private readonly Dictionary<int, UUISprite> PlayerStateItemMap = new Dictionary<int, UUISprite>();

		// Token: 0x04021FAD RID: 139181
		private string ReviveAtLocationName = "";

		// Token: 0x04021FAE RID: 139182
		private string ReviveAtLocationCd = "";

		// Token: 0x04021FAF RID: 139183
		private int ReviveNumber = -1;

		// Token: 0x04021FB0 RID: 139184
		private int AutoReviveTime;

		// Token: 0x04021FB1 RID: 139185
		[Nullable(2)]
		private TimerHandle AutoReviveTimer;

		// Token: 0x04021FB2 RID: 139186
		[Nullable(2)]
		private UUIText AutoReviveText;

		// Token: 0x0200BE15 RID: 48661
		[NullableContext(0)]
		private class EOnlineInstanceDungeonDeathPanel
		{
			// Token: 0x0403A857 RID: 239703
			public const int TextTips = 0;

			// Token: 0x0403A858 RID: 239704
			public const int QuitButton = 1;

			// Token: 0x0403A859 RID: 239705
			public const int AgainButton = 2;

			// Token: 0x0403A85A RID: 239706
			public const int TeamPlayerStateItem = 3;

			// Token: 0x0403A85B RID: 239707
			public const int TeamPlayer1Sprite = 4;

			// Token: 0x0403A85C RID: 239708
			public const int TeamPlayer2Sprite = 5;

			// Token: 0x0403A85D RID: 239709
			public const int TextAgain = 6;

			// Token: 0x0403A85E RID: 239710
			public const int ReviveBtn = 7;

			// Token: 0x0403A85F RID: 239711
			public const int AutoReviveText = 8;

			// Token: 0x0403A860 RID: 239712
			public const int ReviveAtLocationBtn = 9;

			// Token: 0x0403A861 RID: 239713
			public const int ReviveAtLocationTexture = 10;

			// Token: 0x0403A862 RID: 239714
			public const int ReviveAtLocationText = 11;
		}
	}
}
