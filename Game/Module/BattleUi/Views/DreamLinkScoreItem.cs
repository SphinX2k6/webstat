using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006099 RID: 24729
	[NullableContext(2)]
	[Nullable(0)]
	public class DreamLinkScoreItem : BaseScoreItem
	{
		// Token: 0x0603E6B3 RID: 255667 RVA: 0x00FF1FC4 File Offset: 0x00FF01C4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUINiagara));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E6B4 RID: 255668 RVA: 0x00FF20D4 File Offset: 0x00FF02D4
		protected override UniTask OnCreateAsync()
		{
			DreamLinkScoreItem.<OnCreateAsync>d__29 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<DreamLinkScoreItem.<OnCreateAsync>d__29>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6B5 RID: 255669 RVA: 0x00FF2118 File Offset: 0x00FF0318
		protected unsafe override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.ScoreNiagara = base.GetUiNiagara(6);
			UUINiagara scoreNiagara = this.ScoreNiagara;
			if (scoreNiagara != null)
			{
				scoreNiagara.SetUIActive(false);
			}
			int num = 3;
			List<UUISprite> list = new List<UUISprite>(num);
			CollectionsMarshal.SetCount<UUISprite>(list, num);
			Span<UUISprite> span = CollectionsMarshal.AsSpan<UUISprite>(list);
			int num2 = 0;
			*span[num2] = base.GetSprite(2);
			num2++;
			*span[num2] = base.GetSprite(1);
			num2++;
			*span[num2] = base.GetSprite(0);
			this.ScoreBarList = list;
			this.ResetScoreGroup();
			UUISprite sprite = base.GetSprite(3);
			if (sprite != null)
			{
				sprite.SetUIActive(false);
			}
			this.ProgressText = base.GetText(5);
			UUIText progressText = this.ProgressText;
			if (progressText != null)
			{
				progressText.SetText("0%", true);
			}
			this.PointItem = base.GetItem(4);
			this.CurScoreLevelConfigList = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(4);
			this.UpdateMaxAndMinScore();
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
			{
				keyValuePair.Deconstruct(out num2, out num);
				int scoreId = num2;
				int num3 = num;
				if (num3 > 0)
				{
					this.OnBattleScoreChanged(scoreId, num3);
				}
			}
		}

		// Token: 0x0603E6B6 RID: 255670 RVA: 0x00FF2270 File Offset: 0x00FF0470
		protected override void OnBeforeDestroy()
		{
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			this.LevelSequencePlayer = null;
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E6B7 RID: 255671 RVA: 0x00FF2290 File Offset: 0x00FF0490
		[NullableContext(1)]
		private UniTask LoadNiagara(string path, DreamLinkScoreItem.EScoreNiagaraType niagaraType)
		{
			DreamLinkScoreItem.<LoadNiagara>d__32 <LoadNiagara>d__;
			<LoadNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadNiagara>d__.<>4__this = this;
			<LoadNiagara>d__.path = path;
			<LoadNiagara>d__.niagaraType = niagaraType;
			<LoadNiagara>d__.<>1__state = -1;
			<LoadNiagara>d__.<>t__builder.Start<DreamLinkScoreItem.<LoadNiagara>d__32>(ref <LoadNiagara>d__);
			return <LoadNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6B8 RID: 255672 RVA: 0x00FF22E4 File Offset: 0x00FF04E4
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
				this.CurScoreLevelConfig = null;
				if (this.CurScoreLevelConfigList != null)
				{
					foreach (BattleScoreLevelConf value in this.CurScoreLevelConfigList)
					{
						if (score >= value.LowerUpperLimits(0) && score < value.LowerUpperLimits(1))
						{
							this.CurScoreLevelConfig = new BattleScoreLevelConf?(value);
							break;
						}
					}
				}
			}
			this.UpdateScore(score, this.CurScoreLevelConfig);
		}

		// Token: 0x0603E6B9 RID: 255673 RVA: 0x00FF23CC File Offset: 0x00FF05CC
		private void UpdateScore(int score, BattleScoreLevelConf? scoreLevelConfig)
		{
			this.HasValidConfig = (scoreLevelConfig != null);
			this.SetTickEndScore(score);
			if (this.MaxScore > 0)
			{
				int value = (int)Math.Floor((double)((float)score / (float)this.MaxScore * 100f));
				UUIText progressText = this.ProgressText;
				if (progressText == null)
				{
					return;
				}
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value);
				defaultInterpolatedStringHandler.AppendLiteral("%");
				progressText.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			}
		}

		// Token: 0x0603E6BA RID: 255674 RVA: 0x00FF2444 File Offset: 0x00FF0644
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
					int curScoreGroup = this.CurScoreGroup;
					if (this.ScoreBarList != null)
					{
						for (int i = 0; i < this.ScoreBarList.Count; i++)
						{
							UUISprite uuisprite = this.ScoreBarList[i];
							if (i >= this.CurScoreGroup && this.TickScore >= this.ScoreGroup[i])
							{
								if (this.TickScore < this.ScoreGroup[i + 1])
								{
									this.CurScoreGroup = i;
									uuisprite.SetFillAmount(num2);
								}
								else
								{
									if (this.TickScore == this.ScoreGroup[this.MaxScoreGroup])
									{
										this.CurScoreGroup = this.MaxScoreGroup;
									}
									uuisprite.SetFillAmount(this.ScoreProgressGroup[i + 1]);
								}
							}
						}
					}
					if (curScoreGroup < this.CurScoreGroup)
					{
						if (this.CurScoreGroup < this.MaxScoreGroup)
						{
							UUINiagara scoreNiagara = this.ScoreNiagara;
							if (scoreNiagara != null)
							{
								scoreNiagara.SetNiagaraSystem(this.ScoreLevelUpNiagara);
							}
						}
						else
						{
							UUINiagara scoreNiagara2 = this.ScoreNiagara;
							if (scoreNiagara2 != null)
							{
								scoreNiagara2.SetNiagaraSystem(this.ScoreFullNiagara);
							}
						}
						UUINiagara scoreNiagara3 = this.ScoreNiagara;
						if (scoreNiagara3 != null)
						{
							scoreNiagara3.SetUIActive(true);
						}
						UUINiagara scoreNiagara4 = this.ScoreNiagara;
						if (scoreNiagara4 != null)
						{
							scoreNiagara4.ActivateSystem(true);
						}
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

		// Token: 0x0603E6BB RID: 255675 RVA: 0x00FF2628 File Offset: 0x00FF0828
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
			this.ResetScoreGroup();
		}

		// Token: 0x0603E6BC RID: 255676 RVA: 0x00FF267C File Offset: 0x00FF087C
		private void ResetScoreGroup()
		{
			this.CurScoreGroup = 0;
			if (this.ScoreBarList != null)
			{
				foreach (UUISprite uuisprite in this.ScoreBarList)
				{
					uuisprite.SetFillAmount(0f);
				}
			}
		}

		// Token: 0x0603E6BD RID: 255677 RVA: 0x00FF26E0 File Offset: 0x00FF08E0
		private void UpdateMaxAndMinScore()
		{
			this.MinScoreLevelConfig = null;
			this.MaxScoreLevelConfig = null;
			this.ScoreGroup = new List<int>();
			this.ScoreProgressGroup = new List<float>();
			if (this.CurScoreLevelConfigList == null || this.CurScoreLevelConfigList.Count == 0)
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
				this.ScoreGroup.Add(value.LowerUpperLimits(0));
			}
			this.MaxScoreGroup = this.ScoreGroup.Count - 1;
			this.MaxScore = this.MaxScoreLevelConfig.Value.LowerUpperLimits(1);
			if (this.MaxScore > 0)
			{
				foreach (int num3 in this.ScoreGroup)
				{
					this.ScoreProgressGroup.Add((float)num3 / (float)this.MaxScore);
				}
			}
		}

		// Token: 0x0603E6BE RID: 255678 RVA: 0x00FF2840 File Offset: 0x00FF0A40
		public override bool IsValidScore(int scoreId)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, true);
			return scoreConfig != null && scoreConfig.Value.Type == 5;
		}

		// Token: 0x0603E6BF RID: 255679 RVA: 0x00FF2878 File Offset: 0x00FF0A78
		public override void ShowScore()
		{
			base.ShowScore();
			base.Show(null);
		}

		// Token: 0x0603E6C0 RID: 255680 RVA: 0x00FF2887 File Offset: 0x00FF0A87
		public override void HideScore()
		{
			base.HideScore();
			base.Hide(null);
		}

		// Token: 0x04022FAF RID: 143279
		private const int DREAM_LINK_SCORE_GROUP_ID = 4;

		// Token: 0x04022FB0 RID: 143280
		[Nullable(1)]
		private const string SCORE_LEVEL_UP_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_RouGeIcon_Brust_Weak.NS_Fx_LGUI_RouGeIcon_Brust_Weak";

		// Token: 0x04022FB1 RID: 143281
		[Nullable(1)]
		private const string SCORE_FULL_NIAGARA_PATH = "/Game/Aki/Effect/UI/Niagaras/RouGe/NS_Fx_LGUI_RouGeIcon_Brust.NS_Fx_LGUI_RouGeIcon_Brust";

		// Token: 0x04022FB2 RID: 143282
		private const int MAX_SMOOTH_TIME = 200;

		// Token: 0x04022FB3 RID: 143283
		[Nullable(1)]
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]DreamLinkScoreItemTick", "", "");

		// Token: 0x04022FB4 RID: 143284
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022FB5 RID: 143285
		private UNiagaraSystem ScoreFullNiagara;

		// Token: 0x04022FB6 RID: 143286
		private UNiagaraSystem ScoreLevelUpNiagara;

		// Token: 0x04022FB7 RID: 143287
		private UUINiagara ScoreNiagara;

		// Token: 0x04022FB8 RID: 143288
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<UUISprite> ScoreBarList;

		// Token: 0x04022FB9 RID: 143289
		private UUIItem PointItem;

		// Token: 0x04022FBA RID: 143290
		private UUIText ProgressText;

		// Token: 0x04022FBB RID: 143291
		private bool HasValidConfig;

		// Token: 0x04022FBC RID: 143292
		private int TickStartScore;

		// Token: 0x04022FBD RID: 143293
		private int TickEndScore;

		// Token: 0x04022FBE RID: 143294
		private int TickScore;

		// Token: 0x04022FBF RID: 143295
		private int MaxScore;

		// Token: 0x04022FC0 RID: 143296
		private float SmoothTime;

		// Token: 0x04022FC1 RID: 143297
		private int CurScoreGroup;

		// Token: 0x04022FC2 RID: 143298
		private IReadOnlyList<BattleScoreLevelConf> CurScoreLevelConfigList;

		// Token: 0x04022FC3 RID: 143299
		private BattleScoreLevelConf? CurScoreLevelConfig;

		// Token: 0x04022FC4 RID: 143300
		private BattleScoreLevelConf? MinScoreLevelConfig;

		// Token: 0x04022FC5 RID: 143301
		private BattleScoreLevelConf? MaxScoreLevelConfig;

		// Token: 0x04022FC6 RID: 143302
		private List<int> ScoreGroup;

		// Token: 0x04022FC7 RID: 143303
		private List<float> ScoreProgressGroup;

		// Token: 0x04022FC8 RID: 143304
		private int MaxScoreGroup;

		// Token: 0x0200C18F RID: 49551
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B9AB RID: 244139
			ScoreBarA,
			// Token: 0x0403B9AC RID: 244140
			ScoreBarB,
			// Token: 0x0403B9AD RID: 244141
			ScoreBarC,
			// Token: 0x0403B9AE RID: 244142
			ScoreBarD,
			// Token: 0x0403B9AF RID: 244143
			PointItem,
			// Token: 0x0403B9B0 RID: 244144
			ProgressText,
			// Token: 0x0403B9B1 RID: 244145
			ScoreNiagara
		}

		// Token: 0x0200C190 RID: 49552
		[NullableContext(0)]
		private enum EScoreNiagaraType
		{
			// Token: 0x0403B9B3 RID: 244147
			LevelUp,
			// Token: 0x0403B9B4 RID: 244148
			Full
		}
	}
}
