using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.Battle;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200609C RID: 24732
	[NullableContext(1)]
	[Nullable(0)]
	public class RogueScoreItem : BaseScoreItem
	{
		// Token: 0x0603E6E0 RID: 255712 RVA: 0x00FF34A0 File Offset: 0x00FF16A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUINiagara));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			this.IsMobile = Singleton<Info>.Instance.IsInTouch();
		}

		// Token: 0x0603E6E1 RID: 255713 RVA: 0x00FF3604 File Offset: 0x00FF1804
		protected override UniTask OnCreateAsync()
		{
			RogueScoreItem.<OnCreateAsync>d__49 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<RogueScoreItem.<OnCreateAsync>d__49>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6E2 RID: 255714 RVA: 0x00FF3648 File Offset: 0x00FF1848
		private UniTask LoadTexture(string path, int index, [Nullable(new byte[]
		{
			1,
			2
		})] UTexture[] textureDataList)
		{
			RogueScoreItem.<LoadTexture>d__50 <LoadTexture>d__;
			<LoadTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadTexture>d__.path = path;
			<LoadTexture>d__.index = index;
			<LoadTexture>d__.textureDataList = textureDataList;
			<LoadTexture>d__.<>1__state = -1;
			<LoadTexture>d__.<>t__builder.Start<RogueScoreItem.<LoadTexture>d__50>(ref <LoadTexture>d__);
			return <LoadTexture>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6E3 RID: 255715 RVA: 0x00FF369C File Offset: 0x00FF189C
		private UniTask LoadNiagara(string path, int index, [Nullable(new byte[]
		{
			1,
			2
		})] UNiagaraSystem[] niagaraList)
		{
			RogueScoreItem.<LoadNiagara>d__51 <LoadNiagara>d__;
			<LoadNiagara>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadNiagara>d__.path = path;
			<LoadNiagara>d__.index = index;
			<LoadNiagara>d__.niagaraList = niagaraList;
			<LoadNiagara>d__.<>1__state = -1;
			<LoadNiagara>d__.<>t__builder.Start<RogueScoreItem.<LoadNiagara>d__51>(ref <LoadNiagara>d__);
			return <LoadNiagara>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6E4 RID: 255716 RVA: 0x00FF36F0 File Offset: 0x00FF18F0
		private UniTask LoadShader(string path)
		{
			RogueScoreItem.<LoadShader>d__52 <LoadShader>d__;
			<LoadShader>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadShader>d__.<>4__this = this;
			<LoadShader>d__.path = path;
			<LoadShader>d__.<>1__state = -1;
			<LoadShader>d__.<>t__builder.Start<RogueScoreItem.<LoadShader>d__52>(ref <LoadShader>d__);
			return <LoadShader>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6E5 RID: 255717 RVA: 0x00FF373C File Offset: 0x00FF193C
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.ScoreTexture = base.GetTexture(0);
			this.ScoreTextureTransitionComp = (this.ScoreTexture.GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent);
			this.ScoreBgTexture = base.GetTexture(1);
			this.ScoreBgTextureTransitionComp = (this.ScoreBgTexture.GetOwner().GetComponentByClass(UUITextureTransitionComponent.StaticClass()) as UUITextureTransitionComponent);
			this.ScoreNiagara = base.GetUiNiagara(2);
			for (int i = 3; i <= 8; i++)
			{
				UUIItem item = base.GetItem(i);
				this.NodeList.Add(item);
			}
			this.SetPercent(0f);
			this.RogueScoreMachine.SetUpdateCallback(new Action<float, BattleScoreLevelConf?>(this.OnUpdateScore), new Action(this.PlayUpAnim));
			foreach (KeyValuePair<int, bool> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreEnableMap())
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int scoreId = num;
				if (flag)
				{
					this.UpdateScoreOffset(scoreId);
				}
			}
			foreach (KeyValuePair<int, int> keyValuePair2 in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
			{
				int num;
				int num2;
				keyValuePair2.Deconstruct(out num, out num2);
				int scoreId2 = num;
				int num3 = num2;
				if (num3 > 0 && this.IsValidScore(scoreId2))
				{
					this.OnBattleScoreChanged(scoreId2, num3);
				}
			}
		}

		// Token: 0x0603E6E6 RID: 255718 RVA: 0x00FF38E4 File Offset: 0x00FF1AE4
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E6E7 RID: 255719 RVA: 0x00FF3900 File Offset: 0x00FF1B00
		protected override UniTask OnShowAsyncImplement()
		{
			RogueScoreItem.<OnShowAsyncImplement>d__55 <OnShowAsyncImplement>d__;
			<OnShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplement>d__.<>4__this = this;
			<OnShowAsyncImplement>d__.<>1__state = -1;
			<OnShowAsyncImplement>d__.<>t__builder.Start<RogueScoreItem.<OnShowAsyncImplement>d__55>(ref <OnShowAsyncImplement>d__);
			return <OnShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603E6E8 RID: 255720 RVA: 0x00FF3943 File Offset: 0x00FF1B43
		protected override void OnBattleScoreChanged(int scoreId, int score)
		{
			if (base.IsHideOrHiding)
			{
				this.ShowScore();
			}
			this.UpdateScoreConfig(scoreId, score);
			this.UpdateScore(score, this.CurScoreLevelConfig);
			if (this.CurScoreLevelConfig != null)
			{
				base.SetUiActive(true);
			}
		}

		// Token: 0x0603E6E9 RID: 255721 RVA: 0x00FF397C File Offset: 0x00FF1B7C
		public void UpdateScore(int score, BattleScoreLevelConf? scoreLevelConfig)
		{
			this.RogueScoreMachine.UpdateTargetScore((float)score, scoreLevelConfig);
		}

		// Token: 0x0603E6EA RID: 255722 RVA: 0x00FF398C File Offset: 0x00FF1B8C
		private void OnUpdateScore(float curScore, BattleScoreLevelConf? curScoreLevelConfig)
		{
			if (this.CurScore == curScore)
			{
				return;
			}
			this.CurScore = curScore;
			int? num = (this.UiScoreLevelConfig != null) ? new int?(this.UiScoreLevelConfig.GetValueOrDefault().Id) : null;
			int? num2 = (curScoreLevelConfig != null) ? new int?(curScoreLevelConfig.GetValueOrDefault().Id) : null;
			if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)))
			{
				int num3 = (this.UiScoreLevelConfig != null) ? this.UiScoreLevelConfig.GetValueOrDefault().Level : 0;
				bool flag = this.UiScoreLevelConfig != null;
				this.UiScoreLevelConfig = curScoreLevelConfig;
				if (this.UiScoreLevelConfig != null)
				{
					BattleScoreLevelConf value = this.UiScoreLevelConfig.Value;
					this.SetScoreLevelUi(value.Level);
					this.PlayAudio(value.Level, value.Level > num3);
					if (flag)
					{
						this.PlayChangeAnim(value.Level);
					}
				}
				else
				{
					base.SetUiActive(false);
					this.PlayAudio(0, false);
				}
			}
			if (this.UiScoreLevelConfig != null)
			{
				BattleScoreLevelConf value2 = this.UiScoreLevelConfig.Value;
				int num4 = value2.LowerUpperLimits(0);
				int num5 = value2.LowerUpperLimits(1);
				float num6;
				if (num5 == num4)
				{
					num6 = 1f;
				}
				else
				{
					num6 = (curScore - (float)num4) / (float)(num5 - num4);
					num6 = Math.Min(num6, 1f);
				}
				this.SetPercent(num6);
			}
		}

		// Token: 0x0603E6EB RID: 255723 RVA: 0x00FF3B1D File Offset: 0x00FF1D1D
		private void SetScoreLevelUi(int level)
		{
			this.SetScoreTexture(level);
			this.SetScoreBgTexture(level);
			this.SetScoreNiagara(level);
			this.SetNode(level);
		}

		// Token: 0x0603E6EC RID: 255724 RVA: 0x00FF3B3C File Offset: 0x00FF1D3C
		private void SetScoreTexture(int level)
		{
			UTexture utexture = this.ScoreTextureDataList[level - 1];
			this.ScoreTexture.SetTexture(utexture);
			UUITextureTransitionComponent scoreTextureTransitionComp = this.ScoreTextureTransitionComp;
			if (scoreTextureTransitionComp != null)
			{
				scoreTextureTransitionComp.SetAllStateTexture(utexture);
			}
			this.ScoreTexture.SetSizeFromTexture();
		}

		// Token: 0x0603E6ED RID: 255725 RVA: 0x00FF3B80 File Offset: 0x00FF1D80
		private void SetScoreBgTexture(int level)
		{
			UTexture utexture = this.ScoreBgTextureDataList[level - 1];
			this.ScoreBgTexture.SetTexture(utexture);
			UUITextureTransitionComponent scoreBgTextureTransitionComp = this.ScoreBgTextureTransitionComp;
			if (scoreBgTextureTransitionComp != null)
			{
				scoreBgTextureTransitionComp.SetAllStateTexture(utexture);
			}
			this.ScoreBgTexture.SetSizeFromTexture();
			this.ScoreBgTexture.SetCustomMaterialVectorParameter(RogueScoreItem.fillColor, RogueScoreItem.fillColorList[level - 1]);
			this.ScoreBgTexture.SetCustomMaterialVectorParameter(RogueScoreItem.flowColorA, RogueScoreItem.flowColorListA[level - 1]);
			this.ScoreBgTexture.SetCustomMaterialVectorParameter(RogueScoreItem.flowColorB, RogueScoreItem.flowColorListB[level - 1]);
		}

		// Token: 0x0603E6EE RID: 255726 RVA: 0x00FF3C18 File Offset: 0x00FF1E18
		private void SetScoreNiagara(int level)
		{
			int num = RogueScoreItem.scoreNiagaraIndexList[level - 1];
			if (this.CurScoreNiagaraIndex == num)
			{
				return;
			}
			this.CurScoreNiagaraIndex = num;
			UNiagaraSystem niagaraSystem = this.ScoreNiagaraList[num];
			this.ScoreNiagara.SetNiagaraSystem(niagaraSystem);
			this.ScoreNiagara.ActivateSystem(true);
		}

		// Token: 0x0603E6EF RID: 255727 RVA: 0x00FF3C64 File Offset: 0x00FF1E64
		private void SetNode(int level)
		{
			int num = level - 1;
			if (this.CurNodeIndex == num)
			{
				return;
			}
			if (this.CurNodeIndex >= 0)
			{
				this.NodeList[this.CurNodeIndex].SetUIActive(false);
			}
			if (num >= 0)
			{
				this.NodeList[num].SetUIActive(true);
			}
			this.CurNodeIndex = num;
		}

		// Token: 0x0603E6F0 RID: 255728 RVA: 0x00FF3CBC File Offset: 0x00FF1EBC
		private void PlayAudio(int level, bool isLevelUp)
		{
			ModelBase<BattleScoreModel>.Instance.RougeScoreMusicState.State = RogueScoreItem.musicStateList[level];
			if (isLevelUp)
			{
				Singleton<AudioSystem>.Instance.PostEvent("play_ui_rogue_combo");
				return;
			}
			Singleton<AudioSystem>.Instance.PostEvent("play_ui_rogue_combo_down");
		}

		// Token: 0x0603E6F1 RID: 255729 RVA: 0x00FF3CF8 File Offset: 0x00FF1EF8
		private void PlayChangeAnim(int level)
		{
			if (this.IsPlayingStartAnim)
			{
				return;
			}
			this.LevelSequencePlayer.PlaySequencePurely(RogueScoreItem.sequenceNameList[level - 1], false, false, null, null, false);
		}

		// Token: 0x0603E6F2 RID: 255730 RVA: 0x00FF3D2F File Offset: 0x00FF1F2F
		private void SetPercent(float percent)
		{
			this.ScoreBgTexture.SetCustomMaterialScalarParameter(RogueScoreItem.filledAmount, percent);
		}

		// Token: 0x0603E6F3 RID: 255731 RVA: 0x00FF3D42 File Offset: 0x00FF1F42
		private void PlayUpAnim()
		{
			this.IsPlayingUpAnim = true;
			this.UpAnimStartTime = Singleton<Time>.Instance.Now;
			this.UpEffectCountdown = 100f;
			this.PlayUpEffect(1f);
		}

		// Token: 0x0603E6F4 RID: 255732 RVA: 0x00FF3D71 File Offset: 0x00FF1F71
		private void PlayUpEffect(float param)
		{
			if (this.GlobalShaderCollection != null)
			{
				UKismetMaterialLibrary.SetScalarParameterValue(GlobalData.GameInstance.GetWorld(), this.GlobalShaderCollection, RogueScoreItem.rgbSplitProgress, param);
			}
		}

		// Token: 0x0603E6F5 RID: 255733 RVA: 0x00FF3D98 File Offset: 0x00FF1F98
		public override void OnTick(float delta)
		{
			if (base.GetActive())
			{
				this.RogueScoreMachine.Tick(delta);
				if (this.IsPlayingUpAnim)
				{
					double num = Singleton<Time>.Instance.Now - this.UpAnimStartTime;
					if (num >= 600.0)
					{
						num = 600.0;
						this.IsPlayingUpAnim = false;
					}
					double num2;
					if (num < 0.0)
					{
						num2 = num / 0.0;
					}
					else
					{
						num2 = (600.0 - num) / 600.0;
					}
					float currentValue = this.UpAnimCurve.GetCurrentValue((float)num2);
					this.ScoreBgTexture.SetCustomMaterialScalarParameter(RogueScoreItem.globalInt, 0.1f + currentValue * 0.9f);
				}
				if (this.UpEffectCountdown > 0f)
				{
					this.UpEffectCountdown -= delta;
					if (this.UpEffectCountdown <= 0f)
					{
						this.PlayUpEffect(0f);
						return;
					}
					float currentValue2 = this.UpAnimCurve.GetCurrentValue(this.UpEffectCountdown / 100f);
					this.PlayUpEffect(currentValue2);
				}
			}
		}

		// Token: 0x0603E6F6 RID: 255734 RVA: 0x00FF3EA4 File Offset: 0x00FF20A4
		public override bool IsValidScore(int scoreId)
		{
			BattleScoreModel instance = ModelBase<BattleScoreModel>.Instance;
			BattleScoreConf? battleScoreConf = (instance != null) ? instance.GetScoreConfig(scoreId, false) : null;
			if (battleScoreConf == null)
			{
				return false;
			}
			int type = battleScoreConf.Value.Type;
			return type == 1 || type == 2 || type == 3 || type == 6;
		}

		// Token: 0x0603E6F7 RID: 255735 RVA: 0x00FF3EFB File Offset: 0x00FF20FB
		public override void ShowScore()
		{
			base.ShowScore();
			this.SetScoreLevelUi(1);
			this.SetPercent(0f);
			base.Show(null);
			UUINiagara scoreNiagara = this.ScoreNiagara;
			if (scoreNiagara == null)
			{
				return;
			}
			scoreNiagara.SetUIActive(true);
		}

		// Token: 0x0603E6F8 RID: 255736 RVA: 0x00FF3F30 File Offset: 0x00FF2130
		public override void HideScore()
		{
			base.HideScore();
			UUINiagara scoreNiagara = this.ScoreNiagara;
			if (scoreNiagara != null)
			{
				scoreNiagara.SetUIActive(false);
			}
			this.ResetScore();
			RogueScoreMachine rogueScoreMachine = this.RogueScoreMachine;
			if (rogueScoreMachine != null)
			{
				rogueScoreMachine.ResetScore();
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer == null)
			{
				return;
			}
			levelSequencePlayer.PlaySequenceAsync("Close", new CustomPromise<bool>(), false, false, null, false).ContinueWith(delegate()
			{
				if (!base.IsDestroyOrDestroying && !this.IsScoreEnable)
				{
					base.Hide(null);
				}
			}).Forget();
		}

		// Token: 0x0603E6F9 RID: 255737 RVA: 0x00FF3FA8 File Offset: 0x00FF21A8
		public override void OnShowFirstTime()
		{
			if (this.IsScoreEnable && this.CurScore > 0f)
			{
				this.ShowScore();
			}
		}

		// Token: 0x0603E6FA RID: 255738 RVA: 0x00FF3FC8 File Offset: 0x00FF21C8
		private void UpdateScoreConfig(int scoreId, int score)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, false);
			if (scoreConfig == null)
			{
				return;
			}
			int levelGroupId = scoreConfig.Value.LevelGroupId;
			if (this.CurScoreLevelId != levelGroupId)
			{
				this.CurScoreLevelId = levelGroupId;
				this.CurScoreLevelConfigList = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(levelGroupId);
				this.UpdateMaxAndMinScore();
			}
			if (this.CurScoreLevelConfigList == null || this.CurScoreLevelConfigList.Count == 0)
			{
				return;
			}
			if (score < this.MinScoreLevelConfig.Value.LowerUpperLimits(0))
			{
				this.CurScoreLevelConfig = null;
				return;
			}
			if (score >= this.MaxScoreLevelConfig.Value.LowerUpperLimits(1))
			{
				this.CurScoreLevelConfig = this.MaxScoreLevelConfig;
				return;
			}
			this.CurScoreLevelConfig = null;
			foreach (BattleScoreLevelConf value in this.CurScoreLevelConfigList)
			{
				if (value.LowerUpperLimitsLength >= 2 && score >= value.LowerUpperLimits(0) && score < value.LowerUpperLimits(1))
				{
					this.CurScoreLevelConfig = new BattleScoreLevelConf?(value);
					break;
				}
			}
		}

		// Token: 0x0603E6FB RID: 255739 RVA: 0x00FF40FC File Offset: 0x00FF22FC
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
		}

		// Token: 0x0603E6FC RID: 255740 RVA: 0x00FF419C File Offset: 0x00FF239C
		private void UpdateScoreOffset(int scoreId)
		{
			BattleScoreModel instance = ModelBase<BattleScoreModel>.Instance;
			BattleScoreConf? battleScoreConf = (instance != null) ? instance.GetScoreConfig(scoreId, false) : null;
			int? num = (battleScoreConf != null) ? new int?(battleScoreConf.GetValueOrDefault().Type) : null;
			if (num == null)
			{
				BattleScoreConf? battleScoreConfig = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreConfig(scoreId);
				num = ((battleScoreConfig != null) ? new int?(battleScoreConfig.GetValueOrDefault().Type) : null);
			}
			if (num == null)
			{
				return;
			}
			FVector2D anchorOffset = new FVector2D();
			if (num.Value == 6)
			{
				IReadOnlyList<int> intArrayConfig = ConfigCommonParamById.GetIntArrayConfig("ScoreOffsetLevelPlayReport");
				if (intArrayConfig != null && intArrayConfig.Count >= 4)
				{
					if (this.IsMobile)
					{
						anchorOffset.Set((float)intArrayConfig[2], (float)intArrayConfig[3]);
					}
					else
					{
						anchorOffset.Set((float)intArrayConfig[0], (float)intArrayConfig[1]);
					}
				}
			}
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffset(anchorOffset);
		}

		// Token: 0x0603E6FD RID: 255741 RVA: 0x00FF42B3 File Offset: 0x00FF24B3
		private void ResetScore()
		{
			this.CurScore = 0f;
			this.UiScoreLevelConfig = null;
			this.CurScoreLevelConfig = null;
			this.CurScoreLevelId = 0;
		}

		// Token: 0x04022FE1 RID: 143329
		private const int UP_ANIM_TIME = 600;

		// Token: 0x04022FE2 RID: 143330
		private const int HALF_UP_ANIM_TIME = 0;

		// Token: 0x04022FE3 RID: 143331
		private const int UP_EFFECT_TIME = 100;

		// Token: 0x04022FE4 RID: 143332
		private const string SHADER_PATH = "/Game/Aki/Render/Shaders/UI/MPC_RGBSplitGlitch_FightScore.MPC_RGBSplitGlitch_FightScore";

		// Token: 0x04022FE5 RID: 143333
		[StaticVariableRuleIgnore]
		private static readonly Stat TickStatsObject = Stat.Create("[BattleView]RogueScoreItem", "", "");

		// Token: 0x04022FE6 RID: 143334
		private static readonly FName filledAmount = new FName("FilledAmount");

		// Token: 0x04022FE7 RID: 143335
		private static readonly FName fillColor = new FName("FillColor");

		// Token: 0x04022FE8 RID: 143336
		private static readonly FName flowColorA = new FName("FlowColorA");

		// Token: 0x04022FE9 RID: 143337
		private static readonly FName flowColorB = new FName("FlowColorB");

		// Token: 0x04022FEA RID: 143338
		private static readonly FName globalInt = new FName("GlobalInt");

		// Token: 0x04022FEB RID: 143339
		private static readonly FName rgbSplitProgress = new FName("RGBSplit_Progress");

		// Token: 0x04022FEC RID: 143340
		[StaticVariableRuleIgnore]
		private static readonly string[] scoreTexturePathList = new string[]
		{
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreD.T_FightScoreD",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreC.T_FightScoreC",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreB.T_FightScoreB",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreA.T_FightScoreA",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreS.T_FightScoreS",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreSS.T_FightScoreSS"
		};

		// Token: 0x04022FED RID: 143341
		[StaticVariableRuleIgnore]
		private static readonly string[] scoreBgTexturePathList = new string[]
		{
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreBgD.T_FightScoreBgD",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreBgC.T_FightScoreBgC",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreBgB.T_FightScoreBgB",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreBgA.T_FightScoreBgA",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreBgS.T_FightScoreBgS",
			"/Game/Aki/UI/UIResources/UiFight/Image/T_FightScoreBgSS.T_FightScoreBgSS"
		};

		// Token: 0x04022FEE RID: 143342
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor[] fillColorList = new FLinearColor[]
		{
			new FLinearColor(0.0118f, 0.2588f, 1f, 0.5255f),
			new FLinearColor(0.0118f, 0.2588f, 1f, 0.5255f),
			new FLinearColor(1f, 0.2588f, 0.5961f, 0.5255f),
			new FLinearColor(1f, 0.2588f, 0.5961f, 0.5255f),
			new FLinearColor(1f, 0.5725f, 0.1098f, 0.651f),
			new FLinearColor(1f, 0.5725f, 0.1098f, 0.651f)
		};

		// Token: 0x04022FEF RID: 143343
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor[] flowColorListA = new FLinearColor[]
		{
			new FLinearColor(0.451f, 0.5922f, 0.949f, 1f),
			new FLinearColor(0.451f, 0.5922f, 0.949f, 1f),
			new FLinearColor(1f, 0.2824f, 0.7098f, 1f),
			new FLinearColor(1f, 0.2824f, 0.7098f, 1f),
			new FLinearColor(1f, 0.8588f, 0.7451f, 1f),
			new FLinearColor(1f, 0.8588f, 0.7451f, 1f)
		};

		// Token: 0x04022FF0 RID: 143344
		[StaticVariableRuleIgnore]
		private static readonly FLinearColor[] flowColorListB = new FLinearColor[]
		{
			new FLinearColor(0.5686f, 0.6196f, 0.702f, 0.0941f),
			new FLinearColor(0.5686f, 0.6196f, 0.702f, 0.0941f),
			new FLinearColor(0.7255f, 0.5451f, 0.5451f, 0.0941f),
			new FLinearColor(0.7255f, 0.5451f, 0.5451f, 0.0941f),
			new FLinearColor(0.7255f, 0.6471f, 0.1882f, 0.0941f),
			new FLinearColor(0.7255f, 0.6471f, 0.1882f, 0.0941f)
		};

		// Token: 0x04022FF1 RID: 143345
		[StaticVariableRuleIgnore]
		private static readonly string[] scoreNiagaraPathList = new string[]
		{
			"/Game/Aki/Effect/UI/Niagaras/RouGe/PingFen/NS_Fx_LGUI_Rouge_CD.NS_Fx_LGUI_Rouge_CD",
			"/Game/Aki/Effect/UI/Niagaras/RouGe/PingFen/NS_Fx_LGUI_Rouge_AB.NS_Fx_LGUI_Rouge_AB",
			"/Game/Aki/Effect/UI/Niagaras/RouGe/PingFen/NS_Fx_LGUI_Rouge_S.NS_Fx_LGUI_Rouge_S",
			"/Game/Aki/Effect/UI/Niagaras/RouGe/PingFen/NS_Fx_LGUI_Rouge_S02.NS_Fx_LGUI_Rouge_S02"
		};

		// Token: 0x04022FF2 RID: 143346
		[StaticVariableRuleIgnore]
		private static readonly int[] scoreNiagaraIndexList = new int[]
		{
			0,
			0,
			1,
			1,
			2,
			3
		};

		// Token: 0x04022FF3 RID: 143347
		[StaticVariableRuleIgnore]
		private static readonly string[] sequenceNameList = new string[]
		{
			"StartD",
			"StartC",
			"StartB",
			"StartA",
			"StartS",
			"StartSS"
		};

		// Token: 0x04022FF4 RID: 143348
		[StaticVariableRuleIgnore]
		private static readonly string[] musicStateList = new string[]
		{
			"none",
			"d",
			"c",
			"b",
			"a",
			"s",
			"ss"
		};

		// Token: 0x04022FF5 RID: 143349
		private float CurScore;

		// Token: 0x04022FF6 RID: 143350
		private int CurScoreLevelId;

		// Token: 0x04022FF7 RID: 143351
		private BattleScoreLevelConf? CurScoreLevelConfig;

		// Token: 0x04022FF8 RID: 143352
		[Nullable(2)]
		private IReadOnlyList<BattleScoreLevelConf> CurScoreLevelConfigList;

		// Token: 0x04022FF9 RID: 143353
		private BattleScoreLevelConf? UiScoreLevelConfig;

		// Token: 0x04022FFA RID: 143354
		private BattleScoreLevelConf? MinScoreLevelConfig;

		// Token: 0x04022FFB RID: 143355
		private BattleScoreLevelConf? MaxScoreLevelConfig;

		// Token: 0x04022FFC RID: 143356
		private readonly RogueScoreMachine RogueScoreMachine = new RogueScoreMachine();

		// Token: 0x04022FFD RID: 143357
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022FFE RID: 143358
		[Nullable(2)]
		private UUITexture ScoreTexture;

		// Token: 0x04022FFF RID: 143359
		[Nullable(2)]
		private UUITextureTransitionComponent ScoreTextureTransitionComp;

		// Token: 0x04023000 RID: 143360
		[Nullable(2)]
		private UUITexture ScoreBgTexture;

		// Token: 0x04023001 RID: 143361
		[Nullable(2)]
		private UUITextureTransitionComponent ScoreBgTextureTransitionComp;

		// Token: 0x04023002 RID: 143362
		[Nullable(2)]
		private UUINiagara ScoreNiagara;

		// Token: 0x04023003 RID: 143363
		private int CurScoreNiagaraIndex = -1;

		// Token: 0x04023004 RID: 143364
		private readonly List<UUIItem> NodeList = new List<UUIItem>();

		// Token: 0x04023005 RID: 143365
		private int CurNodeIndex = -1;

		// Token: 0x04023006 RID: 143366
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private UTexture[] ScoreTextureDataList = Array.Empty<UTexture>();

		// Token: 0x04023007 RID: 143367
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private UTexture[] ScoreBgTextureDataList = Array.Empty<UTexture>();

		// Token: 0x04023008 RID: 143368
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private UNiagaraSystem[] ScoreNiagaraList = Array.Empty<UNiagaraSystem>();

		// Token: 0x04023009 RID: 143369
		private bool IsPlayingStartAnim;

		// Token: 0x0402300A RID: 143370
		private bool IsPlayingUpAnim;

		// Token: 0x0402300B RID: 143371
		private readonly SquaredCurve UpAnimCurve = CurveUtils.DefaultPara;

		// Token: 0x0402300C RID: 143372
		private double UpAnimStartTime;

		// Token: 0x0402300D RID: 143373
		[Nullable(2)]
		private UMaterialParameterCollection GlobalShaderCollection;

		// Token: 0x0402300E RID: 143374
		private float UpEffectCountdown = -1f;

		// Token: 0x0402300F RID: 143375
		private bool IsMobile;

		// Token: 0x0200C199 RID: 49561
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B9D3 RID: 244179
			ScoreTexture,
			// Token: 0x0403B9D4 RID: 244180
			ScoreBgTexture,
			// Token: 0x0403B9D5 RID: 244181
			ScoreNiagara,
			// Token: 0x0403B9D6 RID: 244182
			NodeD,
			// Token: 0x0403B9D7 RID: 244183
			NodeC,
			// Token: 0x0403B9D8 RID: 244184
			NodeB,
			// Token: 0x0403B9D9 RID: 244185
			NodeA,
			// Token: 0x0403B9DA RID: 244186
			NodeS,
			// Token: 0x0403B9DB RID: 244187
			NodeSS
		}
	}
}
