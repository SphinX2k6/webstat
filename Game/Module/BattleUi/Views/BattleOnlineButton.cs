using System;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Module.InstanceDungeon;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FBE RID: 24510
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleOnlineButton : BattleEntranceButton
	{
		// Token: 0x0603DA18 RID: 252440 RVA: 0x00FB3D94 File Offset: 0x00FB1F94
		protected override void OnRegisterComponent()
		{
			base.OnRegisterComponent();
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(2, typeof(UUIItem)));
			this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(3, typeof(UUISprite)));
		}

		// Token: 0x0603DA19 RID: 252441 RVA: 0x00FB3DD2 File Offset: 0x00FB1FD2
		public override void Initialize(object param = null)
		{
			base.Initialize(param);
			if (param == null)
			{
				return;
			}
			this.OnlineIconComponent = base.GetSprite(3);
			this.AddEvents();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem.GetParentAsUIItem());
		}

		// Token: 0x0603DA1A RID: 252442 RVA: 0x00FB3E08 File Offset: 0x00FB2008
		protected override void OnShowBattleChildView()
		{
			base.OnShowBattleChildView();
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Matching)
			{
				base.GetItem(2).SetUIActive(true);
				if (this.LevelSequencePlayer.GetCurrentSequence() == "AutoLoop")
				{
					this.LevelSequencePlayer.ReplaySequenceByKey("AutoLoop");
				}
				else
				{
					this.LevelSequencePlayer.PlayLevelSequenceByName("AutoLoop", false, null, false);
				}
			}
			else
			{
				base.GetItem(2).SetUIActive(false);
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopCurrentSequence(false, false);
				}
			}
			this.RefreshButtonState();
		}

		// Token: 0x0603DA1B RID: 252443 RVA: 0x00FB3EA1 File Offset: 0x00FB20A1
		public override void Reset()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			this.RemoveEvents();
			base.Reset();
		}

		// Token: 0x0603DA1C RID: 252444 RVA: 0x00FB3EC8 File Offset: 0x00FB20C8
		protected void AddEvents()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Add(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
			Singleton<EventSystem>.Instance.Add(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationInfoChanged));
			Singleton<EventSystem>.Instance.Add(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
			Singleton<EventSystem>.Instance.Add(EEventName.OnlineDisableStateChange, new Action(this.OnlineDisableStateChange));
		}

		// Token: 0x0603DA1D RID: 252445 RVA: 0x00FB3F64 File Offset: 0x00FB2164
		protected void RemoveEvents()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingChange, new Action(this.OnMatchingChange));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMatchingBegin, new Action(this.OnMatchingBegin));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnUpdateSceneTeam, new Action(this.OnFormationInfoChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.ChangeModeFinish, new Action(this.OnChangeModeFinish));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnlineDisableStateChange, new Action(this.OnlineDisableStateChange));
		}

		// Token: 0x0603DA1E RID: 252446 RVA: 0x00FB3FFD File Offset: 0x00FB21FD
		private void OnMatchingChange()
		{
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() == EInstanceMatchState.Default)
			{
				base.GetItem(2).SetUIActive(false);
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer == null)
				{
					return;
				}
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
		}

		// Token: 0x0603DA1F RID: 252447 RVA: 0x00FB402C File Offset: 0x00FB222C
		private void OnMatchingBegin()
		{
			base.GetItem(2).SetUIActive(true);
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, false);
			}
			LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
			if (levelSequencePlayer2 == null)
			{
				return;
			}
			levelSequencePlayer2.PlayLevelSequenceByName("AutoLoop", false, null, false);
		}

		// Token: 0x0603DA20 RID: 252448 RVA: 0x00FB4079 File Offset: 0x00FB2279
		private void OnFormationInfoChanged()
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				this.RefreshButtonState();
			}
		}

		// Token: 0x0603DA21 RID: 252449 RVA: 0x00FB408D File Offset: 0x00FB228D
		private void OnChangeModeFinish()
		{
			this.RefreshButtonState();
		}

		// Token: 0x0603DA22 RID: 252450 RVA: 0x00FB4095 File Offset: 0x00FB2295
		private void OnlineDisableStateChange()
		{
			this.RefreshButtonState();
		}

		// Token: 0x0603DA23 RID: 252451 RVA: 0x00FB409D File Offset: 0x00FB229D
		public override void SetGamepadHide(bool isGamepad)
		{
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				base.SetGamepadHide(false);
				return;
			}
			base.SetGamepadHide(isGamepad);
		}

		// Token: 0x0603DA24 RID: 252452 RVA: 0x00FB40BC File Offset: 0x00FB22BC
		private void RefreshOnlineIcon()
		{
			string text;
			if (ModelBase<GameModeModel>.Instance.IsMulti)
			{
				int playerId = ModelBase<CreatureModel>.Instance.GetPlayerId();
				OnlineTeamData currentTeamListById = ModelBase<OnlineModel>.Instance.GetCurrentTeamListById(playerId);
				if (currentTeamListById == null)
				{
					return;
				}
				text = BattleOnlineButton.OnlinePlayerIconList[currentTeamListById.PlayerNumber - 1];
			}
			else
			{
				text = (ModelBase<OnlineModel>.Instance.IsOnlineDisabled() ? "OnlineLimitIcon" : "OnlineNoLimitIcon");
			}
			if (this.LastIconPathKey == text)
			{
				return;
			}
			this.LastIconPathKey = text;
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(text);
			if (!string.IsNullOrEmpty(resourcePath))
			{
				this.SetSpriteByPath(resourcePath, this.OnlineIconComponent, true, null, null);
			}
		}

		// Token: 0x0603DA25 RID: 252453 RVA: 0x00FB4160 File Offset: 0x00FB2360
		public void RefreshButtonState()
		{
			if (this.OnlineIconComponent == null)
			{
				return;
			}
			if (ControllerBase<GameModeController>.Instance.IsInInstance())
			{
				base.SetOtherHide(true);
				return;
			}
			bool isMulti = ModelBase<GameModeModel>.Instance.IsMulti;
			if (ModelBase<InstanceDungeonEntranceModel>.Instance.GetMatchingState() != EInstanceMatchState.Matching && !isMulti && Singleton<Info>.Instance.IsInGamepad())
			{
				base.SetOtherHide(true);
				return;
			}
			base.SetOtherHide(false);
			this.RefreshOnlineIcon();
		}

		// Token: 0x0402298E RID: 141710
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly string[] OnlinePlayerIconList = new string[]
		{
			"Online1PIcon",
			"Online2PIcon",
			"Online3PIcon"
		};

		// Token: 0x0402298F RID: 141711
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022990 RID: 141712
		private UUISprite OnlineIconComponent;

		// Token: 0x04022991 RID: 141713
		[Nullable(1)]
		private string LastIconPathKey = string.Empty;

		// Token: 0x0200C028 RID: 49192
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B27A RID: 242298
			Button,
			// Token: 0x0403B27B RID: 242299
			RedDotItem,
			// Token: 0x0403B27C RID: 242300
			AniItem,
			// Token: 0x0403B27D RID: 242301
			Icon
		}
	}
}
