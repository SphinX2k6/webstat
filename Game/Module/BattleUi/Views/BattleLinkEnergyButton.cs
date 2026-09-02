using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Camera;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FBD RID: 24509
	[NullableContext(2)]
	[Nullable(0)]
	public class BattleLinkEnergyButton : FormationExtraButton
	{
		// Token: 0x0603D9FF RID: 252415 RVA: 0x00FB2D80 File Offset: 0x00FB0F80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(8, typeof(UUIItem)));
				this.ComponentRegisterInfos.Add(new ValueTuple<int, Type>(9, typeof(UUIItem)));
			}
		}

		// Token: 0x0603DA00 RID: 252416 RVA: 0x00FB2EF4 File Offset: 0x00FB10F4
		protected override UniTask OnCreateAsync()
		{
			BattleLinkEnergyButton.<OnCreateAsync>d__37 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<BattleLinkEnergyButton.<OnCreateAsync>d__37>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DA01 RID: 252417 RVA: 0x00FB2F38 File Offset: 0x00FB1138
		protected override UniTask OnBeforeStartAsync()
		{
			BattleLinkEnergyButton.<OnBeforeStartAsync>d__38 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattleLinkEnergyButton.<OnBeforeStartAsync>d__38>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603DA02 RID: 252418 RVA: 0x00FB2F7C File Offset: 0x00FB117C
		protected override void OnStart()
		{
			base.OnStart();
			this.LinkButton = base.GetButton(0);
			this.PointItem = base.GetItem(2);
			this.ScoreUiNiagara = base.GetUiNiagara(1);
			if (this.ScoreNiagara != null)
			{
				UUINiagara scoreUiNiagara = this.ScoreUiNiagara;
				if (scoreUiNiagara != null)
				{
					scoreUiNiagara.SetUIActive(false);
				}
				UUINiagara scoreUiNiagara2 = this.ScoreUiNiagara;
				if (scoreUiNiagara2 != null)
				{
					scoreUiNiagara2.SetNiagaraSystem(this.ScoreNiagara);
				}
			}
			this.ForbidItem = base.GetItem(3);
			this.LockItem = base.GetItem(4);
			this.Icon = base.GetTexture(5);
			this.IconBg = base.GetTexture(6);
			this.ReadyUiNiagara = base.GetUiNiagara(7);
			if (this.ReadyNiagara != null)
			{
				UUINiagara readyUiNiagara = this.ReadyUiNiagara;
				if (readyUiNiagara != null)
				{
					readyUiNiagara.SetUIActive(false);
				}
				UUINiagara readyUiNiagara2 = this.ReadyUiNiagara;
				if (readyUiNiagara2 != null)
				{
					readyUiNiagara2.SetNiagaraSystem(this.ReadyNiagara);
				}
			}
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				CombineKeyItem keyItemPc = this.KeyItemPc;
				if (keyItemPc != null)
				{
					keyItemPc.RefreshAction("Link大招");
				}
				CombineKeyItem keyItemGp = this.KeyItemGp;
				if (keyItemGp != null)
				{
					keyItemGp.RefreshAction("Link大招");
				}
				if (Singleton<Info>.Instance.IsInKeyBoard())
				{
					CombineKeyItem keyItemPc2 = this.KeyItemPc;
					if (keyItemPc2 != null)
					{
						keyItemPc2.SetUiActive(true);
					}
				}
				else if (Singleton<Info>.Instance.IsInGamepad())
				{
					CombineKeyItem keyItemGp2 = this.KeyItemGp;
					if (keyItemGp2 != null)
					{
						keyItemGp2.SetUiActive(true);
					}
				}
			}
			UUIButtonComponent linkButton = this.LinkButton;
			if (linkButton != null)
			{
				linkButton.SetActive(true, false);
			}
			UUIButtonComponent linkButton2 = this.LinkButton;
			if (linkButton2 != null)
			{
				linkButton2.OnPointDownCallBack.Bind(new Action(this.OnPressLinkButton));
			}
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.UpdateLinkConfig();
			this.RefreshLinkButton(ModelBase<BattleLinkModel>.Instance.GetNewLinkStatus());
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleScoreChanged, new Action<int, int>(this.OnBattleScoreChanged));
			Singleton<EventSystem>.Instance.Add<ENewLinkStatus>(EEventName.OnNewLinkStatusChanged, new Action<ENewLinkStatus>(this.OnNewLinkStatusChanged));
			Singleton<EventSystem>.Instance.Add<EInputControllerType, EInputControllerType>(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			ControllerBase<InputDistributeController>.Instance.BindAction("Link大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputLinkAction));
		}

		// Token: 0x0603DA03 RID: 252419 RVA: 0x00FB319C File Offset: 0x00FB139C
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleScoreChanged, new Action<int, int>(this.OnBattleScoreChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.OnNewLinkStatusChanged, new Action<ENewLinkStatus>(this.OnNewLinkStatusChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.InputControllerChange, new Action<EInputControllerType, EInputControllerType>(this.OnInputControllerChange));
			ControllerBase<InputDistributeController>.Instance.UnBindAction("Link大招", new TInputHandle<InputDistributeDefine.EActionType>(this.OnInputLinkAction));
			if (Singleton<Info>.Instance.IsInTouch())
			{
				UUIButtonComponent linkButton = this.LinkButton;
				if (linkButton != null)
				{
					linkButton.OnPointDownCallBack.Unbind();
				}
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603DA04 RID: 252420 RVA: 0x00FB3258 File Offset: 0x00FB1458
		[NullableContext(1)]
		private UniTask LoadNiagara(string path)
		{
			BattleLinkEnergyButton.<LoadNiagara>d__41 <LoadNiagara>d__;
			<LoadNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadNiagara>d__.<>4__this = this;
			<LoadNiagara>d__.path = path;
			<LoadNiagara>d__.<>1__state = -1;
			<LoadNiagara>d__.<>t__builder.Start<BattleLinkEnergyButton.<LoadNiagara>d__41>(ref <LoadNiagara>d__);
			return <LoadNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x0603DA05 RID: 252421 RVA: 0x00FB32A3 File Offset: 0x00FB14A3
		[NullableContext(1)]
		private void OnInputLinkAction(string actionName, InputDistributeDefine.EActionType actionType, InputIdentification inputIdentification)
		{
			if (!base.IsUiActiveInHierarchy())
			{
				return;
			}
			if (actionType == InputDistributeDefine.EActionType.Press)
			{
				this.LinkAction();
			}
		}

		// Token: 0x0603DA06 RID: 252422 RVA: 0x00FB32B7 File Offset: 0x00FB14B7
		private void OnPressLinkButton()
		{
			this.LinkAction();
		}

		// Token: 0x0603DA07 RID: 252423 RVA: 0x00FB32C0 File Offset: 0x00FB14C0
		private void LinkAction()
		{
			if (ControllerBase<CameraController>.Instance.IsSequenceCameraInCinematic("MainCamera"))
			{
				return;
			}
			if (!Singleton<Info>.Instance.IsBuildShipping && ModelBase<BattleLinkModel>.Instance.IsNewLinkGmTest())
			{
				ControllerBase<BattleLinkController>.Instance.NewLinkBurstTest().Forget();
				return;
			}
			if (!this.CheckAliveRoles())
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("Link_CannotCast_Tips", Array.Empty<object>());
				return;
			}
			if (ModelBase<BattleLinkModel>.Instance.GetNewLinkStatus() == ENewLinkStatus.Ready)
			{
				if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - this.BurstTriggerCd < 1000L)
				{
					return;
				}
				this.BurstTriggerCd = DateTimeOffset.Now.ToUnixTimeMilliseconds();
				ControllerBase<BattleLinkController>.Instance.RequestNewLinkBurst();
			}
		}

		// Token: 0x0603DA08 RID: 252424 RVA: 0x00FB336C File Offset: 0x00FB156C
		private void OnBattleScoreChanged(int scoreId, int score)
		{
			if (!this.IsValidScore(scoreId))
			{
				return;
			}
			if (score < this.MinScoreLevelConfig.Value.LowerUpperLimits(0))
			{
				this.CurScoreLevelConfig = null;
			}
			else if (score >= this.MaxScoreLevelConfig.Value.LowerUpperLimits(1))
			{
				this.CurScoreLevelConfig = this.MaxScoreLevelConfig;
			}
			else
			{
				this.CurScoreLevelConfig = this.MinScoreLevelConfig;
			}
			this.UpdateScore(score, this.CurScoreLevelConfig);
		}

		// Token: 0x0603DA09 RID: 252425 RVA: 0x00FB33E6 File Offset: 0x00FB15E6
		private void OnNewLinkStatusChanged(ENewLinkStatus state)
		{
			this.UpdateLinkConfig();
			this.RefreshLinkButton(state);
			if (ModelBase<BattleLinkModel>.Instance.IsNewLinkGmTest())
			{
				this.SetVisible(true);
			}
		}

		// Token: 0x0603DA0A RID: 252426 RVA: 0x00FB3408 File Offset: 0x00FB1608
		private void OnInputControllerChange(EInputControllerType last, EInputControllerType now)
		{
			if (Singleton<Info>.Instance.IsInKeyBoard())
			{
				CombineKeyItem keyItemPc = this.KeyItemPc;
				if (keyItemPc != null)
				{
					keyItemPc.SetUiActive(true);
				}
				CombineKeyItem keyItemGp = this.KeyItemGp;
				if (keyItemGp == null)
				{
					return;
				}
				keyItemGp.SetUiActive(false);
				return;
			}
			else if (Singleton<Info>.Instance.IsInGamepad())
			{
				CombineKeyItem keyItemPc2 = this.KeyItemPc;
				if (keyItemPc2 != null)
				{
					keyItemPc2.SetUiActive(false);
				}
				CombineKeyItem keyItemGp2 = this.KeyItemGp;
				if (keyItemGp2 == null)
				{
					return;
				}
				keyItemGp2.SetUiActive(true);
				return;
			}
			else
			{
				CombineKeyItem keyItemPc3 = this.KeyItemPc;
				if (keyItemPc3 != null)
				{
					keyItemPc3.SetUiActive(false);
				}
				CombineKeyItem keyItemGp3 = this.KeyItemGp;
				if (keyItemGp3 == null)
				{
					return;
				}
				keyItemGp3.SetUiActive(false);
				return;
			}
		}

		// Token: 0x0603DA0B RID: 252427 RVA: 0x00FB3498 File Offset: 0x00FB1698
		private void UpdateLinkConfig()
		{
			LinkData? linkConfig = ModelBase<BattleLinkModel>.Instance.GetLinkConfig();
			if (linkConfig == null)
			{
				this.NewLinkId = 0;
				this.ScoreId = 0;
				return;
			}
			LinkData valueOrDefault = linkConfig.GetValueOrDefault();
			if (valueOrDefault.Id == this.NewLinkId)
			{
				return;
			}
			this.NewLinkId = valueOrDefault.Id;
			this.ScoreId = valueOrDefault.BattleScoreId;
			BattleScoreConf? battleScoreConfig = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreConfig(valueOrDefault.BattleScoreId);
			if (battleScoreConfig != null)
			{
				BattleScoreConf valueOrDefault2 = battleScoreConfig.GetValueOrDefault();
				this.CurScoreLevelConfigList = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(valueOrDefault2.LevelGroupId);
				this.UpdateMaxAndMinScore();
				foreach (KeyValuePair<int, int> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
				{
					int num;
					int num2;
					keyValuePair.Deconstruct(out num, out num2);
					int num3 = num;
					int score = num2;
					if (num3 == valueOrDefault.BattleScoreId)
					{
						this.OnBattleScoreChanged(num3, score);
						break;
					}
				}
			}
		}

		// Token: 0x0603DA0C RID: 252428 RVA: 0x00FB35AC File Offset: 0x00FB17AC
		private void UpdateScore(int score, BattleScoreLevelConf? scoreLevelConfig)
		{
			this.Score = score;
			this.HasValidConfig = (scoreLevelConfig != null);
			this.SetTickEndScore(score);
			if ((float)score >= this.MaxScore && !this.IsShowFull)
			{
				this.IsShowFull = true;
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopSequenceByKey("Restart", false, false);
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 != null)
				{
					levelSequencePlayer2.PlaySequencePurely("Full", false, false, null, null, false);
				}
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Full);
				return;
			}
			if ((float)score != this.MaxScore && this.IsShowFull)
			{
				this.IsShowFull = false;
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 != null)
				{
					levelSequencePlayer3.StopSequenceByKey("Full", false, false);
				}
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 != null)
				{
					levelSequencePlayer4.PlaySequencePurely("Restart", false, false, null, null, false);
				}
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Normal);
			}
		}

		// Token: 0x0603DA0D RID: 252429 RVA: 0x00FB368C File Offset: 0x00FB188C
		public override void Tick(float delta)
		{
			if (this.HasValidConfig && this.TickScore != this.TickEndScore && base.GetActive())
			{
				this.SmoothTime = Math.Min(200f, this.SmoothTime + delta * 1000f);
				float num = this.SmoothTime / 200f;
				this.TickScore = this.TickStartScore * (1f - num) + this.TickEndScore * num;
				if (this.MaxScore > 0f)
				{
					float num2 = this.TickScore / this.MaxScore;
					UUINiagara scoreUiNiagara = this.ScoreUiNiagara;
					if (scoreUiNiagara != null)
					{
						scoreUiNiagara.SetNiagaraVarFloat("Dissolve", num2);
					}
					UUIItem pointItem = this.PointItem;
					if (pointItem != null)
					{
						FRotator frotator = new FRotator();
						frotator.Yaw = num2 * -360f;
						pointItem.SetUIRelativeRotation(frotator);
					}
					UUIItem pointItem2 = this.PointItem;
					if (pointItem2 == null)
					{
						return;
					}
					pointItem2.SetUIActive(num2 > 0f && num2 < 1f);
				}
			}
		}

		// Token: 0x0603DA0E RID: 252430 RVA: 0x00FB3788 File Offset: 0x00FB1988
		private void SetTickEndScore(int score)
		{
			if (score > 0)
			{
				this.TickStartScore = this.TickScore;
				this.TickEndScore = (float)score;
				this.SmoothTime = 0f;
				return;
			}
			this.TickStartScore = this.TickScore;
			this.TickEndScore = 0f;
			this.SmoothTime = 200f;
		}

		// Token: 0x0603DA0F RID: 252431 RVA: 0x00FB37DC File Offset: 0x00FB19DC
		private void UpdateMaxAndMinScore()
		{
			this.MinScoreLevelConfig = null;
			this.MaxScoreLevelConfig = null;
			if (this.CurScoreLevelConfigList == null)
			{
				return;
			}
			int num = int.MaxValue;
			int num2 = 0;
			foreach (BattleScoreLevelConf value in this.CurScoreLevelConfigList)
			{
				int level = value.Level;
				if (num > level)
				{
					num = level;
					this.MinScoreLevelConfig = new BattleScoreLevelConf?(value);
				}
				if (num2 < level)
				{
					num2 = level;
					this.MaxScoreLevelConfig = new BattleScoreLevelConf?(value);
				}
			}
			this.MaxScore = (float)this.MaxScoreLevelConfig.Value.LowerUpperLimits(0);
			float maxScore = this.MaxScore;
		}

		// Token: 0x0603DA10 RID: 252432 RVA: 0x00FB38A8 File Offset: 0x00FB1AA8
		public bool IsValidScore(int scoreId)
		{
			return scoreId == this.ScoreId && ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, true) != null;
		}

		// Token: 0x0603DA11 RID: 252433 RVA: 0x00FB38DC File Offset: 0x00FB1ADC
		public bool CheckAliveRoles()
		{
			LinkData? linkConfig = ModelBase<BattleLinkModel>.Instance.GetLinkConfig();
			if (linkConfig != null && linkConfig.Value.IsEnableOneRoleBurst != 0)
			{
				return true;
			}
			int num = 0;
			using (List<SceneTeamItem>.Enumerator enumerator = ModelBase<SceneTeamModel>.Instance.GetTeamItems(false).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (!enumerator.Current.IsDead())
					{
						num++;
					}
				}
			}
			return num > 1;
		}

		// Token: 0x0603DA12 RID: 252434 RVA: 0x00FB3964 File Offset: 0x00FB1B64
		public void RefreshLinkButton(ENewLinkStatus state)
		{
			if (state == ENewLinkStatus.None)
			{
				this.SetVisible(false);
				return;
			}
			this.SetVisible(true);
			if (!this.CheckAliveRoles())
			{
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Forbid);
				return;
			}
			switch (state)
			{
			case ENewLinkStatus.Lock:
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Lock);
				return;
			case ENewLinkStatus.Active:
				if ((float)this.Score != this.MaxScore)
				{
					this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Normal);
					return;
				}
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Full);
				return;
			case ENewLinkStatus.Ready:
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Full);
				return;
			case ENewLinkStatus.Burst:
				this.SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState.Burst);
				return;
			default:
				return;
			}
		}

		// Token: 0x0603DA13 RID: 252435 RVA: 0x00FB39E4 File Offset: 0x00FB1BE4
		public void SetLinkButtonState(BattleLinkEnergyButton.ELinkButtonState state)
		{
			switch (state)
			{
			case BattleLinkEnergyButton.ELinkButtonState.Normal:
			{
				UUIItem pointItem = this.PointItem;
				if (pointItem != null)
				{
					pointItem.SetUIActive(true);
				}
				UUINiagara scoreUiNiagara = this.ScoreUiNiagara;
				if (scoreUiNiagara != null)
				{
					scoreUiNiagara.SetUIActive(true);
				}
				UUINiagara readyUiNiagara = this.ReadyUiNiagara;
				if (readyUiNiagara != null)
				{
					readyUiNiagara.SetUIActive(false);
				}
				UUIItem forbidItem = this.ForbidItem;
				if (forbidItem != null)
				{
					forbidItem.SetUIActive(false);
				}
				UUIItem lockItem = this.LockItem;
				if (lockItem != null)
				{
					lockItem.SetUIActive(false);
				}
				UUINiagara scoreUiNiagara2 = this.ScoreUiNiagara;
				if (scoreUiNiagara2 != null)
				{
					scoreUiNiagara2.SetAlpha(1f);
				}
				UUIItem pointItem2 = this.PointItem;
				if (pointItem2 != null)
				{
					pointItem2.SetAlpha(1f);
				}
				UUITexture icon = this.Icon;
				if (icon != null)
				{
					icon.SetAlpha(1f);
				}
				UUITexture iconBg = this.IconBg;
				if (iconBg == null)
				{
					return;
				}
				iconBg.SetColor(FColor.White);
				return;
			}
			case BattleLinkEnergyButton.ELinkButtonState.Full:
			{
				UUIItem pointItem3 = this.PointItem;
				if (pointItem3 != null)
				{
					pointItem3.SetUIActive(true);
				}
				UUINiagara scoreUiNiagara3 = this.ScoreUiNiagara;
				if (scoreUiNiagara3 != null)
				{
					scoreUiNiagara3.SetUIActive(true);
				}
				UUINiagara readyUiNiagara2 = this.ReadyUiNiagara;
				if (readyUiNiagara2 != null)
				{
					readyUiNiagara2.SetUIActive(true);
				}
				UUIItem forbidItem2 = this.ForbidItem;
				if (forbidItem2 != null)
				{
					forbidItem2.SetUIActive(false);
				}
				UUIItem lockItem2 = this.LockItem;
				if (lockItem2 != null)
				{
					lockItem2.SetUIActive(false);
				}
				UUINiagara scoreUiNiagara4 = this.ScoreUiNiagara;
				if (scoreUiNiagara4 != null)
				{
					scoreUiNiagara4.SetAlpha(1f);
				}
				UUITexture icon2 = this.Icon;
				if (icon2 != null)
				{
					icon2.SetAlpha(1f);
				}
				UUITexture iconBg2 = this.IconBg;
				if (iconBg2 == null)
				{
					return;
				}
				iconBg2.SetColor(FColor.White);
				return;
			}
			case BattleLinkEnergyButton.ELinkButtonState.Burst:
			{
				UUIItem pointItem4 = this.PointItem;
				if (pointItem4 != null)
				{
					pointItem4.SetUIActive(true);
				}
				UUINiagara scoreUiNiagara5 = this.ScoreUiNiagara;
				if (scoreUiNiagara5 != null)
				{
					scoreUiNiagara5.SetUIActive(true);
				}
				UUINiagara readyUiNiagara3 = this.ReadyUiNiagara;
				if (readyUiNiagara3 != null)
				{
					readyUiNiagara3.SetUIActive(false);
				}
				UUIItem forbidItem3 = this.ForbidItem;
				if (forbidItem3 != null)
				{
					forbidItem3.SetUIActive(false);
				}
				UUIItem lockItem3 = this.LockItem;
				if (lockItem3 != null)
				{
					lockItem3.SetUIActive(false);
				}
				UUINiagara scoreUiNiagara6 = this.ScoreUiNiagara;
				if (scoreUiNiagara6 != null)
				{
					scoreUiNiagara6.SetAlpha(1f);
				}
				UUITexture icon3 = this.Icon;
				if (icon3 != null)
				{
					icon3.SetAlpha(1f);
				}
				UUITexture iconBg3 = this.IconBg;
				if (iconBg3 == null)
				{
					return;
				}
				iconBg3.SetColor(FColor.White);
				return;
			}
			case BattleLinkEnergyButton.ELinkButtonState.Forbid:
			{
				UUIItem pointItem5 = this.PointItem;
				if (pointItem5 != null)
				{
					pointItem5.SetUIActive(true);
				}
				UUINiagara scoreUiNiagara7 = this.ScoreUiNiagara;
				if (scoreUiNiagara7 != null)
				{
					scoreUiNiagara7.SetUIActive(true);
				}
				UUINiagara readyUiNiagara4 = this.ReadyUiNiagara;
				if (readyUiNiagara4 != null)
				{
					readyUiNiagara4.SetUIActive(false);
				}
				UUIItem forbidItem4 = this.ForbidItem;
				if (forbidItem4 != null)
				{
					forbidItem4.SetUIActive(true);
				}
				UUIItem lockItem4 = this.LockItem;
				if (lockItem4 != null)
				{
					lockItem4.SetUIActive(false);
				}
				UUINiagara scoreUiNiagara8 = this.ScoreUiNiagara;
				if (scoreUiNiagara8 != null)
				{
					scoreUiNiagara8.SetAlpha(0.5f);
				}
				UUIItem pointItem6 = this.PointItem;
				if (pointItem6 != null)
				{
					pointItem6.SetAlpha(0.5f);
				}
				UUITexture icon4 = this.Icon;
				if (icon4 != null)
				{
					icon4.SetAlpha(0.3f);
				}
				UUITexture iconBg4 = this.IconBg;
				if (iconBg4 == null)
				{
					return;
				}
				iconBg4.SetColor(FColor.Transparent);
				return;
			}
			case BattleLinkEnergyButton.ELinkButtonState.Lock:
			{
				UUIItem pointItem7 = this.PointItem;
				if (pointItem7 != null)
				{
					pointItem7.SetUIActive(false);
				}
				UUINiagara scoreUiNiagara9 = this.ScoreUiNiagara;
				if (scoreUiNiagara9 != null)
				{
					scoreUiNiagara9.SetUIActive(false);
				}
				UUINiagara readyUiNiagara5 = this.ReadyUiNiagara;
				if (readyUiNiagara5 != null)
				{
					readyUiNiagara5.SetUIActive(false);
				}
				UUIItem forbidItem5 = this.ForbidItem;
				if (forbidItem5 != null)
				{
					forbidItem5.SetUIActive(false);
				}
				UUIItem lockItem5 = this.LockItem;
				if (lockItem5 != null)
				{
					lockItem5.SetUIActive(true);
				}
				UUITexture icon5 = this.Icon;
				if (icon5 != null)
				{
					icon5.SetAlpha(0.3f);
				}
				UUITexture iconBg5 = this.IconBg;
				if (iconBg5 == null)
				{
					return;
				}
				iconBg5.SetColor(FColor.Transparent);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603DA14 RID: 252436 RVA: 0x00FB3D2D File Offset: 0x00FB1F2D
		protected override void OnShowBattleChildView()
		{
		}

		// Token: 0x0603DA15 RID: 252437 RVA: 0x00FB3D30 File Offset: 0x00FB1F30
		public string GetResourceId()
		{
			BattleLinkModel instance = ModelBase<BattleLinkModel>.Instance;
			if (instance.CheckInNewBattleLink())
			{
				return "UiItem_RogueScoreE";
			}
			if (!instance.CheckInSpecialBattleLink())
			{
				return null;
			}
			string specialLinkEnergyButton = instance.GetSpecialLinkEnergyButton();
			if (!string.IsNullOrEmpty(specialLinkEnergyButton))
			{
				return specialLinkEnergyButton;
			}
			return "UiItem_FightLinkBurst";
		}

		// Token: 0x0402296D RID: 141677
		[Nullable(1)]
		private const string SCORE_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_WhiteCat_Button_Panner.NS_Fx_LGUI_WhiteCat_Button_Panner";

		// Token: 0x0402296E RID: 141678
		[Nullable(1)]
		private const string READY_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/Common/NS_Fx_LGUI_Fight_Link.NS_Fx_LGUI_Fight_Link";

		// Token: 0x0402296F RID: 141679
		private const int MAX_SMOOTH_TIME = 200;

		// Token: 0x04022970 RID: 141680
		private const int LINK_BURST_TRIGGER_INTERVAL = 1000;

		// Token: 0x04022971 RID: 141681
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]BattleLinkEnergyButtonTick", "", "");

		// Token: 0x04022972 RID: 141682
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022973 RID: 141683
		private UUIButtonComponent LinkButton;

		// Token: 0x04022974 RID: 141684
		private UNiagaraSystem ScoreNiagara;

		// Token: 0x04022975 RID: 141685
		private UUINiagara ScoreUiNiagara;

		// Token: 0x04022976 RID: 141686
		private UNiagaraSystem ReadyNiagara;

		// Token: 0x04022977 RID: 141687
		private UUINiagara ReadyUiNiagara;

		// Token: 0x04022978 RID: 141688
		private UUIItem PointItem;

		// Token: 0x04022979 RID: 141689
		private UUIItem ForbidItem;

		// Token: 0x0402297A RID: 141690
		private UUIItem LockItem;

		// Token: 0x0402297B RID: 141691
		private UUITexture Icon;

		// Token: 0x0402297C RID: 141692
		private UUITexture IconBg;

		// Token: 0x0402297D RID: 141693
		private CombineKeyItem KeyItemPc;

		// Token: 0x0402297E RID: 141694
		private CombineKeyItem KeyItemGp;

		// Token: 0x0402297F RID: 141695
		private bool HasValidConfig;

		// Token: 0x04022980 RID: 141696
		private bool IsShowFull;

		// Token: 0x04022981 RID: 141697
		private float TickStartScore;

		// Token: 0x04022982 RID: 141698
		private float TickEndScore;

		// Token: 0x04022983 RID: 141699
		private float TickScore;

		// Token: 0x04022984 RID: 141700
		private float MaxScore;

		// Token: 0x04022985 RID: 141701
		private float SmoothTime;

		// Token: 0x04022986 RID: 141702
		private IReadOnlyList<BattleScoreLevelConf> CurScoreLevelConfigList;

		// Token: 0x04022987 RID: 141703
		private BattleScoreLevelConf? CurScoreLevelConfig;

		// Token: 0x04022988 RID: 141704
		private BattleScoreLevelConf? MinScoreLevelConfig;

		// Token: 0x04022989 RID: 141705
		private BattleScoreLevelConf? MaxScoreLevelConfig;

		// Token: 0x0402298A RID: 141706
		private int NewLinkId;

		// Token: 0x0402298B RID: 141707
		private int ScoreId;

		// Token: 0x0402298C RID: 141708
		private int Score;

		// Token: 0x0402298D RID: 141709
		private long BurstTriggerCd;

		// Token: 0x0200C021 RID: 49185
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B258 RID: 242264
			LinkButton,
			// Token: 0x0403B259 RID: 242265
			ScoreNiagara,
			// Token: 0x0403B25A RID: 242266
			PointItem,
			// Token: 0x0403B25B RID: 242267
			ForbidItem,
			// Token: 0x0403B25C RID: 242268
			LockItem,
			// Token: 0x0403B25D RID: 242269
			Icon,
			// Token: 0x0403B25E RID: 242270
			IconBg,
			// Token: 0x0403B25F RID: 242271
			ReadyNiagara
		}

		// Token: 0x0200C022 RID: 49186
		[NullableContext(0)]
		private enum EDesktopChildType
		{
			// Token: 0x0403B261 RID: 242273
			KeyItemPc = 8,
			// Token: 0x0403B262 RID: 242274
			KeyItemGp
		}

		// Token: 0x0200C023 RID: 49187
		[NullableContext(0)]
		public enum ELinkButtonState
		{
			// Token: 0x0403B264 RID: 242276
			Normal,
			// Token: 0x0403B265 RID: 242277
			Full,
			// Token: 0x0403B266 RID: 242278
			Burst,
			// Token: 0x0403B267 RID: 242279
			Forbid,
			// Token: 0x0403B268 RID: 242280
			Lock
		}
	}
}
