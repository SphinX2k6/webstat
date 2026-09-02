using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200609B RID: 24731
	[NullableContext(2)]
	[Nullable(0)]
	public class LinkScoreItem : BaseScoreItem
	{
		// Token: 0x0603E6CE RID: 255694 RVA: 0x00FF2CF4 File Offset: 0x00FF0EF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E6CF RID: 255695 RVA: 0x00FF2D60 File Offset: 0x00FF0F60
		protected override UniTask OnCreateAsync()
		{
			LinkScoreItem.<OnCreateAsync>d__22 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<LinkScoreItem.<OnCreateAsync>d__22>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6D0 RID: 255696 RVA: 0x00FF2DA4 File Offset: 0x00FF0FA4
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.ScoreUiNiagara = base.GetUiNiagara(0);
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
			this.PointItem = base.GetItem(1);
			if (!ModelBase<WeeklyRogueModel>.Instance.CheckIsInWeeklyRogue())
			{
				this.InitScore(2);
				return;
			}
			bool flag = ModelBase<WeeklyRogueModel>.Instance.CurrentActivityId != 0;
			this.IsScoreEnable = flag;
			if (!flag)
			{
				Singleton<EventSystem>.Instance.Add(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
				return;
			}
			this.InitScore(ModelBase<WeeklyRogueModel>.Instance.CycleId);
			this.ShowScore();
		}

		// Token: 0x0603E6D1 RID: 255697 RVA: 0x00FF2E74 File Offset: 0x00FF1074
		private void InitScore(int groupId)
		{
			this.ScoreInitFlag = true;
			this.CurScoreLevelConfigList = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(groupId);
			this.UpdateMaxAndMinScore();
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int scoreId = num;
				int num3 = num2;
				if (num3 > 0)
				{
					this.OnBattleScoreChanged(scoreId, num3);
				}
			}
		}

		// Token: 0x0603E6D2 RID: 255698 RVA: 0x00FF2EFC File Offset: 0x00FF10FC
		private void OnCycleRefresh()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
			this.IsScoreEnable = true;
			int cycleId = ModelBase<WeeklyRogueModel>.Instance.CycleId;
			this.InitScore(cycleId);
			this.ShowScore();
		}

		// Token: 0x0603E6D3 RID: 255699 RVA: 0x00FF2F44 File Offset: 0x00FF1144
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			if (Singleton<EventSystem>.Instance.Has(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WeeklyRogueCycleRefresh, new Action(this.OnCycleRefresh));
			}
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E6D4 RID: 255700 RVA: 0x00FF2FA8 File Offset: 0x00FF11A8
		[NullableContext(1)]
		private UniTask LoadNiagara(string path)
		{
			LinkScoreItem.<LoadNiagara>d__27 <LoadNiagara>d__;
			<LoadNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadNiagara>d__.<>4__this = this;
			<LoadNiagara>d__.path = path;
			<LoadNiagara>d__.<>1__state = -1;
			<LoadNiagara>d__.<>t__builder.Start<LinkScoreItem.<LoadNiagara>d__27>(ref <LoadNiagara>d__);
			return <LoadNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6D5 RID: 255701 RVA: 0x00FF2FF4 File Offset: 0x00FF11F4
		protected override void OnBattleScoreChanged(int scoreId, int score)
		{
			if (!this.ScoreInitFlag)
			{
				return;
			}
			if (base.IsHideOrHiding)
			{
				this.ShowScore();
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

		// Token: 0x0603E6D6 RID: 255702 RVA: 0x00FF307C File Offset: 0x00FF127C
		private void UpdateScore(int score, BattleScoreLevelConf? scoreLevelConfig)
		{
			this.HasValidConfig = (scoreLevelConfig != null);
			this.SetTickEndScore(score);
			if (!base.IsShowOrShowing)
			{
				this.ShowScore();
				return;
			}
			if (score < this.MaxScore || this.IsShowFull)
			{
				if (score != this.MaxScore && this.IsShowFull)
				{
					this.IsShowFull = false;
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer != null)
					{
						levelSequencePlayer.StopSequenceByKey("Full", false, false);
					}
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 == null)
					{
						return;
					}
					levelSequencePlayer2.PlaySequencePurely("Restart", false, false, null, null, false);
				}
				return;
			}
			this.IsShowFull = true;
			LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
			if (levelSequencePlayer3 != null)
			{
				levelSequencePlayer3.StopSequenceByKey("Restart", false, false);
			}
			LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
			if (levelSequencePlayer4 == null)
			{
				return;
			}
			levelSequencePlayer4.PlaySequencePurely("Full", false, false, null, null, false);
		}

		// Token: 0x0603E6D7 RID: 255703 RVA: 0x00FF3154 File Offset: 0x00FF1354
		public override void OnTick(float delta)
		{
			if (this.HasValidConfig && this.TickScore != this.TickEndScore && base.GetActive())
			{
				this.SmoothTime = Math.Min(200f, this.SmoothTime + delta);
				float num = this.SmoothTime / 200f;
				this.TickScore = (int)((float)this.TickStartScore * (1f - num) + (float)this.TickEndScore * num);
				if (this.MaxScore > 0)
				{
					float num2 = (float)this.TickScore / (float)this.MaxScore;
					UUINiagara scoreUiNiagara = this.ScoreUiNiagara;
					if (scoreUiNiagara != null)
					{
						scoreUiNiagara.SetNiagaraVarFloat("Dissolve", num2);
					}
					UUIItem pointItem = this.PointItem;
					if (pointItem == null)
					{
						return;
					}
					FRotator frotator = new FRotator();
					frotator.Yaw = num2 * -360f;
					pointItem.SetUIRelativeRotation(frotator);
				}
			}
		}

		// Token: 0x0603E6D8 RID: 255704 RVA: 0x00FF3224 File Offset: 0x00FF1424
		private void SetTickEndScore(int score)
		{
			if (score > 0)
			{
				this.TickStartScore = this.TickScore;
				this.TickEndScore = score;
				this.SmoothTime = 0f;
				return;
			}
			this.TickStartScore = this.TickScore;
			this.TickEndScore = 0;
			this.SmoothTime = 200f;
		}

		// Token: 0x0603E6D9 RID: 255705 RVA: 0x00FF3274 File Offset: 0x00FF1474
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
			this.MaxScore = this.MaxScoreLevelConfig.Value.LowerUpperLimits(0);
			int maxScore = this.MaxScore;
		}

		// Token: 0x0603E6DA RID: 255706 RVA: 0x00FF3338 File Offset: 0x00FF1538
		public override bool IsValidScore(int scoreId)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, true);
			return scoreConfig != null && (scoreConfig.Value.Type == 4 || scoreConfig.Value.Type == 7);
		}

		// Token: 0x0603E6DB RID: 255707 RVA: 0x00FF3384 File Offset: 0x00FF1584
		public override void ShowScore()
		{
			base.ShowScore();
			base.Show(null);
			UUINiagara scoreUiNiagara = this.ScoreUiNiagara;
			if (scoreUiNiagara != null)
			{
				scoreUiNiagara.SetUIActive(true);
			}
			UUINiagara scoreUiNiagara2 = this.ScoreUiNiagara;
			if (scoreUiNiagara2 != null)
			{
				scoreUiNiagara2.ActivateSystem(true);
			}
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
			levelSequencePlayer2.PlaySequencePurely("Start", false, false, null, null, false);
		}

		// Token: 0x0603E6DC RID: 255708 RVA: 0x00FF33F8 File Offset: 0x00FF15F8
		public override void HideScore()
		{
			base.HideScore();
			UUINiagara scoreUiNiagara = this.ScoreUiNiagara;
			if (scoreUiNiagara != null)
			{
				scoreUiNiagara.SetUIActive(false);
			}
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
			levelSequencePlayer2.PlaySequenceAsync("Close", new CustomPromise<bool>(), false, false, null, false).ContinueWith(delegate()
			{
				if (!this.IsScoreEnable)
				{
					base.Hide(null);
				}
			}).Forget();
		}

		// Token: 0x04022FCD RID: 143309
		private const int LINK_SCORE_GROUP_ID = 2;

		// Token: 0x04022FCE RID: 143310
		[Nullable(1)]
		private const string SCORE_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_WhiteCat_Button_Panner.NS_Fx_LGUI_WhiteCat_Button_Panner";

		// Token: 0x04022FCF RID: 143311
		private const int MAX_SMOOTH_TIME = 200;

		// Token: 0x04022FD0 RID: 143312
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]LinkScoreItemTick", "", "");

		// Token: 0x04022FD1 RID: 143313
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022FD2 RID: 143314
		private UNiagaraSystem ScoreNiagara;

		// Token: 0x04022FD3 RID: 143315
		private UUINiagara ScoreUiNiagara;

		// Token: 0x04022FD4 RID: 143316
		private UUIItem PointItem;

		// Token: 0x04022FD5 RID: 143317
		private bool HasValidConfig;

		// Token: 0x04022FD6 RID: 143318
		private bool IsShowFull;

		// Token: 0x04022FD7 RID: 143319
		private int TickStartScore;

		// Token: 0x04022FD8 RID: 143320
		private int TickEndScore;

		// Token: 0x04022FD9 RID: 143321
		private int TickScore;

		// Token: 0x04022FDA RID: 143322
		private int MaxScore;

		// Token: 0x04022FDB RID: 143323
		private float SmoothTime;

		// Token: 0x04022FDC RID: 143324
		private IReadOnlyList<BattleScoreLevelConf> CurScoreLevelConfigList;

		// Token: 0x04022FDD RID: 143325
		private BattleScoreLevelConf? CurScoreLevelConfig;

		// Token: 0x04022FDE RID: 143326
		private BattleScoreLevelConf? MinScoreLevelConfig;

		// Token: 0x04022FDF RID: 143327
		private BattleScoreLevelConf? MaxScoreLevelConfig;

		// Token: 0x04022FE0 RID: 143328
		private bool ScoreInitFlag;

		// Token: 0x0200C195 RID: 49557
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B9C5 RID: 244165
			ScoreNiagara,
			// Token: 0x0403B9C6 RID: 244166
			PointItem
		}
	}
}
