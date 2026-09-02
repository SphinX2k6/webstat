using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200609D RID: 24733
	[NullableContext(1)]
	[Nullable(0)]
	public class ShipTowerScoreItem : BaseScoreItem
	{
		// Token: 0x0603E701 RID: 255745 RVA: 0x00FF4780 File Offset: 0x00FF2980
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603E702 RID: 255746 RVA: 0x00FF488C File Offset: 0x00FF2A8C
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.LevelSequencePlayer.BindSequenceCloseEvent(new TSequenceEndEvent(this.OnSequenceClose), false);
			this.PointItem = base.GetItem(4);
			this.PointRotator = new FRotator(0f, 0f, 0f);
			this.ProgressText = base.GetText(2);
			this.ProgressText.SetText("0%", true);
			UUISprite sprite = base.GetSprite(0);
			if (sprite != null)
			{
				sprite.SetFillAmount(0f);
			}
			if (ModelBase<ShipTowerModel>.Instance.CurSeasonCfg == null)
			{
				return;
			}
			int num = 2304;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "ShipTower评分组ID";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("scoreGroupId", num);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			this.CurScoreLevelConfigList = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(num);
			this.UpdateMaxAndMinScore();
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
			{
				int num2;
				int num3;
				keyValuePair.Deconstruct(out num2, out num3);
				int scoreId = num2;
				int num4 = num3;
				if (num4 > 0)
				{
					this.OnBattleScoreChanged(scoreId, num4);
				}
			}
		}

		// Token: 0x0603E703 RID: 255747 RVA: 0x00FF49E4 File Offset: 0x00FF2BE4
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			this.RemoveScoreTextTimer();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E704 RID: 255748 RVA: 0x00FF4A0C File Offset: 0x00FF2C0C
		protected override void OnBattleScoreChanged(int scoreId, int score)
		{
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

		// Token: 0x0603E705 RID: 255749 RVA: 0x00FF4A8C File Offset: 0x00FF2C8C
		private void UpdateScore(int score, BattleScoreLevelConf? scoreLevelConfig)
		{
			this.HasValidConfig = (scoreLevelConfig != null);
			this.SetTickEndScore(score);
			if (!base.IsShowOrShowing)
			{
				this.ShowScore();
			}
			if (this.MaxScore > 0)
			{
				int num = (int)Math.Floor((double)((float)score / (float)this.MaxScore * 100f));
				this.ProgressText.SetText(num.ToString() + "%", true);
			}
		}

		// Token: 0x0603E706 RID: 255750 RVA: 0x00FF4AFC File Offset: 0x00FF2CFC
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
			if (this.MaxScore <= 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.LRC;
				string message = "ShipTower评分最大值不合法";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("MaxScore", this.MaxScore);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
		}

		// Token: 0x0603E707 RID: 255751 RVA: 0x00FF4BF4 File Offset: 0x00FF2DF4
		public override void OnTick(float delta)
		{
			if (this.HasValidConfig && this.TickScore != this.TickEndScore && base.GetActive() && Singleton<Time>.Instance.TimeDilation != 0f)
			{
				this.SmoothTime = Math.Min(this.MaxSmoothTime, this.SmoothTime + delta);
				float num = this.SmoothTime / this.MaxSmoothTime;
				this.TickScore = this.TickStartScore * (1f - num) + this.TickEndScore * num;
				if (this.MaxScore > 0)
				{
					float num2 = this.TickScore / (float)this.MaxScore;
					UUISprite sprite = base.GetSprite(0);
					if (sprite != null)
					{
						sprite.SetFillAmount(num2);
					}
					this.PointRotator.Yaw = num2 * -360f;
					UUIItem pointItem = this.PointItem;
					if (pointItem == null)
					{
						return;
					}
					pointItem.SetUIRelativeRotation(this.PointRotator);
				}
			}
		}

		// Token: 0x0603E708 RID: 255752 RVA: 0x00FF4CD4 File Offset: 0x00FF2ED4
		private float GetMaxSmoothTime()
		{
			PropSmallItemGrid propSmallItemGrid = ModelBase<ShipTowerModel>.Instance.GetInTheBattleBuffInfo().ItemInfo as PropSmallItemGrid;
			int valueOrDefault = ((propSmallItemGrid != null) ? propSmallItemGrid.ItemConfigId : null).GetValueOrDefault();
			if (valueOrDefault != 0)
			{
				SlashBuffToItem? buffCfgByItemId = ConfigBase<ShipTowerConfig>.Instance.GetBuffCfgByItemId(valueOrDefault);
				int? num = (buffCfgByItemId != null) ? new int?(buffCfgByItemId.GetValueOrDefault().BuffTime) : null;
				bool flag;
				if (num != null)
				{
					int valueOrDefault2 = num.GetValueOrDefault();
					if (valueOrDefault2 > 0 || valueOrDefault2 == -1)
					{
						flag = true;
						goto IL_8C;
					}
				}
				flag = false;
				IL_8C:
				if (flag)
				{
					return (float)buffCfgByItemId.Value.BuffTime;
				}
			}
			return (float)((this.CurScoreLevelConfig != null) ? this.CurScoreLevelConfig.GetValueOrDefault().BuffTime : 0);
		}

		// Token: 0x0603E709 RID: 255753 RVA: 0x00FF4DA4 File Offset: 0x00FF2FA4
		private void ScoreTextSmoothToZero()
		{
			this.RemoveScoreTextTimer();
			this.ScoreTextHandle = TimerSystem.FlowTimeInstance.Forever(delegate(float _)
			{
				int num = (int)Math.Floor((double)((1f - this.SmoothTime / this.MaxSmoothTime) * 100f));
				this.ProgressText.SetText(num.ToString() + "%", true);
				if (num <= 0)
				{
					this.RemoveScoreTextTimer();
				}
			}, 200f, 1f, null, null, true);
		}

		// Token: 0x0603E70A RID: 255754 RVA: 0x00FF4DD5 File Offset: 0x00FF2FD5
		private void RemoveScoreTextTimer()
		{
			if (this.ScoreTextHandle != null)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.StopSequenceByKey("Back", true, true);
				}
				TimerSystem.FlowTimeInstance.Remove(this.ScoreTextHandle);
				this.ScoreTextHandle = null;
			}
		}

		// Token: 0x0603E70B RID: 255755 RVA: 0x00FF4E10 File Offset: 0x00FF3010
		private void SetTickEndScore(int score)
		{
			if (score <= 0)
			{
				this.RemoveScoreTextTimer();
				this.TickStartScore = this.TickScore;
				this.TickEndScore = 0f;
				this.SmoothTime = 200f;
				this.MaxSmoothTime = 200f;
				this.PlayLevelSequence("Start2");
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.LRC;
				string message = "焚潮结束";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("score", score);
				instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				Singleton<EventSystem>.Instance.Emit<string>(EEventName.ShipTowerBattleTip, "ShipTower_BurningTide_End");
				return;
			}
			this.TickStartScore = this.TickScore;
			this.TickEndScore = (float)score;
			this.SmoothTime = 0f;
			if (score < this.MaxScore)
			{
				this.MaxSmoothTime = 200f;
				return;
			}
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.Battle;
			ELogAuthor author2 = ELogAuthor.LRC;
			string message2 = "焚潮开始";
			ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("score", score);
			instance2.Info(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.ShipTowerBattleTip, "ShipTower_BurningTide_Start");
			float maxSmoothTime = this.GetMaxSmoothTime();
			if (maxSmoothTime > 0f)
			{
				this.PlayLevelSequence("Start");
				this.MaxSmoothTime = maxSmoothTime;
				this.TickEndScore = 0f;
				this.ScoreTextSmoothToZero();
				return;
			}
			this.PlayLevelSequence("Immortal");
			this.MaxSmoothTime = 200f;
		}

		// Token: 0x0603E70C RID: 255756 RVA: 0x00FF4F68 File Offset: 0x00FF3168
		public override bool IsValidScore(int scoreId)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, true);
			return scoreConfig != null && scoreConfig.Value.Type == 9;
		}

		// Token: 0x0603E70D RID: 255757 RVA: 0x00FF4FAC File Offset: 0x00FF31AC
		private void PlayLevelSequence(string sequenceName)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.LRC;
			string message = "播放序列";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("sequenceName", sequenceName);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
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
			levelSequencePlayer2.PlaySequencePurely(sequenceName, false, false, null, null, false);
		}

		// Token: 0x0603E70E RID: 255758 RVA: 0x00FF5014 File Offset: 0x00FF3214
		private void OnSequenceClose(string sequenceName)
		{
			if (sequenceName == "Start")
			{
				if (this.TickEndScore <= 0f)
				{
					LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
					if (levelSequencePlayer == null)
					{
						return;
					}
					levelSequencePlayer.PlayLevelSequenceByName("Back", false, new float?(1000f / this.MaxSmoothTime), false);
					return;
				}
			}
			else if (sequenceName == "Start2")
			{
				this.PlayLevelSequence("Loop1");
			}
		}

		// Token: 0x0603E70F RID: 255759 RVA: 0x00FF507C File Offset: 0x00FF327C
		private void OnButtonClick()
		{
			ShipTowerScoreItemViewParams param = new ShipTowerScoreItemViewParams
			{
				CurScore = (int)this.TickScore,
				MaxScore = this.MaxScore
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.ShipTowerLevelInfoView, param, null);
		}

		// Token: 0x0603E710 RID: 255760 RVA: 0x00FF50B9 File Offset: 0x00FF32B9
		public override void ShowScore()
		{
			base.ShowScore();
			base.Show(null);
			this.PlayLevelSequence("Start2");
		}

		// Token: 0x0603E711 RID: 255761 RVA: 0x00FF50D3 File Offset: 0x00FF32D3
		public override void HideScore()
		{
			base.HideScore();
			base.Hide(null);
		}

		// Token: 0x04023010 RID: 143376
		private const int MAX_SMOOTH_TIME = 200;

		// Token: 0x04023011 RID: 143377
		private const int SHIP_TOWER_SCORE_GROUP_ID = 2304;

		// Token: 0x04023012 RID: 143378
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]ShipTowerScoreItemTick", "", "");

		// Token: 0x04023013 RID: 143379
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04023014 RID: 143380
		private UUIText ProgressText;

		// Token: 0x04023015 RID: 143381
		[Nullable(2)]
		private IReadOnlyList<BattleScoreLevelConf> CurScoreLevelConfigList;

		// Token: 0x04023016 RID: 143382
		private BattleScoreLevelConf? CurScoreLevelConfig;

		// Token: 0x04023017 RID: 143383
		private BattleScoreLevelConf? MinScoreLevelConfig;

		// Token: 0x04023018 RID: 143384
		private BattleScoreLevelConf? MaxScoreLevelConfig;

		// Token: 0x04023019 RID: 143385
		private bool HasValidConfig;

		// Token: 0x0402301A RID: 143386
		private float TickStartScore;

		// Token: 0x0402301B RID: 143387
		private float TickEndScore;

		// Token: 0x0402301C RID: 143388
		private float TickScore;

		// Token: 0x0402301D RID: 143389
		private int MaxScore;

		// Token: 0x0402301E RID: 143390
		private float SmoothTime;

		// Token: 0x0402301F RID: 143391
		[Nullable(2)]
		private UUIItem PointItem;

		// Token: 0x04023020 RID: 143392
		private FRotator PointRotator;

		// Token: 0x04023021 RID: 143393
		private float MaxSmoothTime;

		// Token: 0x04023022 RID: 143394
		[Nullable(2)]
		private TimerHandle ScoreTextHandle;

		// Token: 0x0200C1A2 RID: 49570
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403B9FE RID: 244222
			ProgressSprite,
			// Token: 0x0403B9FF RID: 244223
			BuffIconTexture,
			// Token: 0x0403BA00 RID: 244224
			ProgressText,
			// Token: 0x0403BA01 RID: 244225
			Button,
			// Token: 0x0403BA02 RID: 244226
			PointItem
		}
	}
}
