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
	// Token: 0x02006098 RID: 24728
	[NullableContext(1)]
	[Nullable(0)]
	public class BossPilingScoreItem : BaseScoreItem
	{
		// Token: 0x0603E693 RID: 255635 RVA: 0x00FF12B8 File Offset: 0x00FEF4B8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E694 RID: 255636 RVA: 0x00FF1384 File Offset: 0x00FEF584
		protected override UniTask OnCreateAsync()
		{
			BossPilingScoreItem.<OnCreateAsync>d__19 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<BossPilingScoreItem.<OnCreateAsync>d__19>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603E695 RID: 255637 RVA: 0x00FF13C8 File Offset: 0x00FEF5C8
		private UniTask LoadResource(string path, int index, [Nullable(new byte[]
		{
			1,
			2
		})] ULGUISpriteData_BaseObject[] spriteDataList)
		{
			CustomPromise promise = new CustomPromise();
			Singleton<ResourceSystem>.Instance.LoadAsync<ULGUISpriteData_BaseObject>(path, delegate([Nullable(2)] ULGUISpriteData_BaseObject res, string _)
			{
				spriteDataList[index] = res;
				promise.SetResult();
			}, 103, "js_undefined");
			return promise.Promise;
		}

		// Token: 0x0603E696 RID: 255638 RVA: 0x00FF1420 File Offset: 0x00FEF620
		protected override void OnStart()
		{
			base.OnStart();
			this.BarSprite = base.GetSprite(0);
			this.BarBgSprite = base.GetSprite(1);
			this.BarWhite = base.GetTexture(2);
			this.IconSprite = base.GetSprite(3);
			this.ValueText = base.GetText(4);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			this.RootActor.OnSequencePlayEvent.Bind(new Action<string, string>(this.OnPlaySequenceEvent));
			this.SetPercent(0f);
			this.InstScoreMachine.SetUpdateCallback(new Action<float, BattleScoreLevelConf?>(this.OnUpdateScore), new Action(this.PlayUpAnim));
			this.InitScore();
		}

		// Token: 0x0603E697 RID: 255639 RVA: 0x00FF14D5 File Offset: 0x00FEF6D5
		protected override void OnBeforeDestroy()
		{
			this.LevelSequencePlayer.Clear();
			this.LevelSequencePlayer = null;
			this.RemoveEvent();
			this.RemoveTimer();
			base.OnBeforeDestroy();
		}

		// Token: 0x0603E698 RID: 255640 RVA: 0x00FF14FC File Offset: 0x00FEF6FC
		protected override UniTask OnShowAsyncImplementImplement()
		{
			BossPilingScoreItem.<OnShowAsyncImplementImplement>d__23 <OnShowAsyncImplementImplement>d__;
			<OnShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnShowAsyncImplementImplement>d__.<>4__this = this;
			<OnShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnShowAsyncImplementImplement>d__.<>t__builder.Start<BossPilingScoreItem.<OnShowAsyncImplementImplement>d__23>(ref <OnShowAsyncImplementImplement>d__);
			return <OnShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603E699 RID: 255641 RVA: 0x00FF1540 File Offset: 0x00FEF740
		protected override UniTask OnHideAsyncImplementImplement()
		{
			BossPilingScoreItem.<OnHideAsyncImplementImplement>d__24 <OnHideAsyncImplementImplement>d__;
			<OnHideAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnHideAsyncImplementImplement>d__.<>4__this = this;
			<OnHideAsyncImplementImplement>d__.<>1__state = -1;
			<OnHideAsyncImplementImplement>d__.<>t__builder.Start<BossPilingScoreItem.<OnHideAsyncImplementImplement>d__24>(ref <OnHideAsyncImplementImplement>d__);
			return <OnHideAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x0603E69A RID: 255642 RVA: 0x00FF1584 File Offset: 0x00FEF784
		[NullableContext(0)]
		private ValueTuple<int, int> GetValidScoreId()
		{
			foreach (KeyValuePair<int, int> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreMap())
			{
				int num;
				int num2;
				keyValuePair.Deconstruct(out num, out num2);
				int num3 = num;
				int num4 = num2;
				if (num4 > 0 && this.IsValidScore(num3))
				{
					return new ValueTuple<int, int>(num3, num4);
				}
			}
			foreach (KeyValuePair<int, bool> keyValuePair2 in ModelBase<BattleScoreModel>.Instance.GetScoreEnableMap())
			{
				int num2;
				bool flag;
				keyValuePair2.Deconstruct(out num2, out flag);
				int num5 = num2;
				if (flag && this.IsValidScore(num5))
				{
					return new ValueTuple<int, int>(num5, 0);
				}
			}
			return new ValueTuple<int, int>(0, 0);
		}

		// Token: 0x0603E69B RID: 255643 RVA: 0x00FF166C File Offset: 0x00FEF86C
		private void InitScore()
		{
			ValueTuple<int, int> validScoreId = this.GetValidScoreId();
			int item = validScoreId.Item1;
			int item2 = validScoreId.Item2;
			if (item != 0)
			{
				this.OnBattleScoreChanged(item, item2);
			}
			if (item == 0)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.ValueText, "BossPilingActivity_Dungeon20", new <>z__ReadOnlySingleElementList<object>("0"));
				return;
			}
			if (ModelBase<GameModeModel>.Instance.Loading)
			{
				this.ShowScoreOnWorldDone();
				return;
			}
			this.ShowScore();
			this.OnTick(0f);
		}

		// Token: 0x0603E69C RID: 255644 RVA: 0x00FF16DE File Offset: 0x00FEF8DE
		private void RemoveTimer()
		{
			if (this.TimeoutHd != null)
			{
				TimerSystem.GameplayTimeInstance.Remove(this.TimeoutHd);
				this.TimeoutHd = null;
			}
		}

		// Token: 0x0603E69D RID: 255645 RVA: 0x00FF1700 File Offset: 0x00FEF900
		private void ShowScoreOnWorldDone()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			this.TimeoutHd = TimerSystem.Instance.Delay(delegate(float _)
			{
				this.RemoveTimer();
				this.OnWorldDoneAndCloseLoading();
			}, 5000f, null, null, true, 1f);
		}

		// Token: 0x0603E69E RID: 255646 RVA: 0x00FF1752 File Offset: 0x00FEF952
		private void OnWorldDoneAndCloseLoading()
		{
			this.RemoveEvent();
			this.RemoveTimer();
			if (this.GetValidScoreId().Item1 != 0 && !this.RootItem.IsUIActiveSelf())
			{
				this.ShowScore();
				this.OnTick(0f);
			}
		}

		// Token: 0x0603E69F RID: 255647 RVA: 0x00FF178B File Offset: 0x00FEF98B
		private void RemoveEvent()
		{
			if (Singleton<EventSystem>.Instance.Has(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading)))
			{
				Singleton<EventSystem>.Instance.Remove(EEventName.WorldDoneAndCloseLoading, new Action(this.OnWorldDoneAndCloseLoading));
			}
		}

		// Token: 0x0603E6A0 RID: 255648 RVA: 0x00FF17C6 File Offset: 0x00FEF9C6
		protected override void OnBattleScoreChanged(int scoreId, int score)
		{
			if (base.IsHideOrHiding)
			{
				this.ShowScore();
			}
			this.UpdateScoreConfig(scoreId, (float)score);
			if (this.NextScoreLevelConfig != null)
			{
				this.UpdateScoreValue((float)score, this.NextScoreLevelConfig);
				base.SetUiActive(true);
			}
		}

		// Token: 0x0603E6A1 RID: 255649 RVA: 0x00FF1804 File Offset: 0x00FEFA04
		private void UpdateScoreValue(float score, BattleScoreLevelConf? scoreLevelConfig)
		{
			this.InstScoreMachine.UpdateTargetScore(score, scoreLevelConfig);
			if (this.IsMaxScore(score))
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(this.ValueText, "BossPilingActivity_Dungeon20", new <>z__ReadOnlySingleElementList<object>(score));
				return;
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.ValueText, "BossPilingActivity_Dungeon19", new <>z__ReadOnlyArray<object>(new object[]
			{
				score,
				this.GetNextPhaseScore(scoreLevelConfig)
			}));
		}

		// Token: 0x0603E6A2 RID: 255650 RVA: 0x00FF1880 File Offset: 0x00FEFA80
		private bool IsMaxScore(float score)
		{
			return score >= this.ScoreMaxValue;
		}

		// Token: 0x0603E6A3 RID: 255651 RVA: 0x00FF1890 File Offset: 0x00FEFA90
		private float GetNextPhaseScore(BattleScoreLevelConf? lvCfg)
		{
			if (lvCfg != null && lvCfg.Value.Level > 0 && lvCfg.Value.Level - 1 < this.ScorePhaseValues.Count)
			{
				return this.ScorePhaseValues[lvCfg.Value.Level - 1];
			}
			return 0f;
		}

		// Token: 0x0603E6A4 RID: 255652 RVA: 0x00FF18F8 File Offset: 0x00FEFAF8
		private void OnUpdateScore(float value, BattleScoreLevelConf? scoreCfg)
		{
			if (this.CurScoreValue == value)
			{
				return;
			}
			this.CurScoreValue = value;
			int? num = (this.LastScoreLevelConfig != null) ? new int?(this.LastScoreLevelConfig.GetValueOrDefault().Id) : null;
			int? num2 = (scoreCfg != null) ? new int?(scoreCfg.GetValueOrDefault().Id) : null;
			if (!(num.GetValueOrDefault() == num2.GetValueOrDefault() & num != null == (num2 != null)) && scoreCfg != null && this.LastScoreLevelConfig != null)
			{
				LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
				if (levelSequencePlayer != null)
				{
					levelSequencePlayer.PlayLevelSequenceByName("GradeChange", false, null, false);
				}
				if (scoreCfg.Value.Level == this.ScoreMaxLevel)
				{
					this.IsPlayingMaxLevel = true;
					LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
					if (levelSequencePlayer2 != null)
					{
						levelSequencePlayer2.PlayLevelSequenceByName("SS_In", false, null, false);
					}
				}
				else if (this.IsPlayingMaxLevel)
				{
					this.IsPlayingMaxLevel = false;
					LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
					if (levelSequencePlayer3 != null)
					{
						levelSequencePlayer3.PlayLevelSequenceByName("SS_Out", false, null, false);
					}
				}
				this.LastScoreLevelConfig = scoreCfg;
			}
			if (this.IsMaxScore(value))
			{
				this.SetPercent(1f);
				return;
			}
			if (scoreCfg != null)
			{
				int num3 = scoreCfg.Value.LowerUpperLimits(0);
				int num4 = scoreCfg.Value.LowerUpperLimits(1);
				float num5;
				if (num4 == num3)
				{
					num5 = 1f;
				}
				else
				{
					num5 = (value - (float)num3) / (float)(num4 - num3);
					num5 = Math.Min(num5, 1f);
				}
				this.SetPercent(num5);
			}
		}

		// Token: 0x0603E6A5 RID: 255653 RVA: 0x00FF1AC0 File Offset: 0x00FEFCC0
		private void SetLevelSprite(int level)
		{
			ULGUISpriteData_BaseObject ulguispriteData_BaseObject = this.BarSpriteDataList[level - 1];
			if (ulguispriteData_BaseObject != null && ulguispriteData_BaseObject.IsValid())
			{
				this.IconSprite.SetSprite(ulguispriteData_BaseObject, true);
			}
		}

		// Token: 0x0603E6A6 RID: 255654 RVA: 0x00FF1AF0 File Offset: 0x00FEFCF0
		private void OnPlaySequenceEvent(string sequenceName, string eventName)
		{
			if (eventName == "Sequence_Grade_Change" && this.NextScoreLevelConfig != null)
			{
				this.SetLevelSprite(this.NextScoreLevelConfig.Value.Level);
			}
		}

		// Token: 0x0603E6A7 RID: 255655 RVA: 0x00FF1B30 File Offset: 0x00FEFD30
		private void PlayUpAnim()
		{
		}

		// Token: 0x0603E6A8 RID: 255656 RVA: 0x00FF1B34 File Offset: 0x00FEFD34
		private void SetPercent(float percent)
		{
			this.BarSprite.SetFillAmount(percent);
			this.BarBgSprite.SetFillAmount(percent);
			this.P1Color.A = Singleton<MathUtils>.Instance.Lerp(0.25f, -0.75f, percent);
			this.BarWhite.SetCustomMaterialVectorParameter(BossPilingScoreItem.P1Name, this.P1Color);
			float num = (percent > 0.5f) ? 0.5f : 0f;
			if (num != this.LastMaskValue)
			{
				this.BarWhite.SetCustomMaterialScalarParameter(BossPilingScoreItem.P2Name, num);
				this.LastMaskValue = num;
			}
		}

		// Token: 0x0603E6A9 RID: 255657 RVA: 0x00FF1BC5 File Offset: 0x00FEFDC5
		public override void OnTick(float delta)
		{
			this.InstScoreMachine.Tick(delta);
		}

		// Token: 0x0603E6AA RID: 255658 RVA: 0x00FF1BD4 File Offset: 0x00FEFDD4
		public override bool IsValidScore(int scoreId)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, false);
			return scoreConfig != null && scoreConfig.Value.Type == 10;
		}

		// Token: 0x0603E6AB RID: 255659 RVA: 0x00FF1C0D File Offset: 0x00FEFE0D
		public override void ShowScore()
		{
			base.ShowScore();
			this.SetLevelSprite(1);
			this.SetPercent(0f);
			base.Show(null);
		}

		// Token: 0x0603E6AC RID: 255660 RVA: 0x00FF1C2E File Offset: 0x00FEFE2E
		public override void HideScore()
		{
			base.HideScore();
			this.ResetScore();
			RogueScoreMachine instScoreMachine = this.InstScoreMachine;
			if (instScoreMachine != null)
			{
				instScoreMachine.ResetScore();
			}
			base.Hide(null);
		}

		// Token: 0x0603E6AD RID: 255661 RVA: 0x00FF1C54 File Offset: 0x00FEFE54
		public override void OnShowFirstTime()
		{
			if (this.IsScoreEnable && this.CurScoreValue > 0f)
			{
				this.ShowScore();
			}
		}

		// Token: 0x0603E6AE RID: 255662 RVA: 0x00FF1C74 File Offset: 0x00FEFE74
		private void UpdateScoreConfig(int scoreId, float score)
		{
			BattleScoreConf? scoreConfig = ModelBase<BattleScoreModel>.Instance.GetScoreConfig(scoreId, false);
			if (scoreConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Battle;
				ELogAuthor author = ELogAuthor.HWR;
				string message = "BossPilingScoreItem 没有找到分数配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("scoreId", scoreId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			int levelGroupId = scoreConfig.Value.LevelGroupId;
			if (this.CurScoreGroupId != levelGroupId)
			{
				this.CurScoreGroupId = levelGroupId;
				IReadOnlyList<BattleScoreLevelConf> battleScoreActionConfigByGroupId = ConfigBase<BattleScoreConfig>.Instance.GetBattleScoreActionConfigByGroupId(levelGroupId);
				if (battleScoreActionConfigByGroupId == null || battleScoreActionConfigByGroupId.Count == 0)
				{
					return;
				}
				this.ScoreLevelConfigList = battleScoreActionConfigByGroupId;
				BattleScoreLevelConf? scoreLevelConfigMax = null;
				this.ScorePhaseValues.Clear();
				foreach (BattleScoreLevelConf value in battleScoreActionConfigByGroupId)
				{
					this.ScorePhaseValues.Add((float)value.LowerUpperLimits(1));
					if (scoreLevelConfigMax == null || scoreLevelConfigMax.Value.LowerUpperLimits(0) < value.LowerUpperLimits(0))
					{
						scoreLevelConfigMax = new BattleScoreLevelConf?(value);
					}
				}
				this.ScorePhaseValues.Sort((float a, float b) => a.CompareTo(b));
				this.ScoreLevelConfigMax = scoreLevelConfigMax;
				if (scoreLevelConfigMax != null)
				{
					this.ScoreMaxValue = (float)scoreLevelConfigMax.Value.LowerUpperLimits(0);
					this.ScoreMaxLevel = scoreLevelConfigMax.Value.Level;
				}
			}
			if (this.ScoreLevelConfigList != null && this.ScoreLevelConfigList.Count > 0)
			{
				foreach (BattleScoreLevelConf value2 in this.ScoreLevelConfigList)
				{
					if (score >= (float)value2.LowerUpperLimits(0) && score < (float)value2.LowerUpperLimits(1))
					{
						this.NextScoreLevelConfig = new BattleScoreLevelConf?(value2);
						break;
					}
				}
				if (this.ScoreLevelConfigMax != null && score >= (float)this.ScoreLevelConfigMax.Value.LowerUpperLimits(1))
				{
					this.NextScoreLevelConfig = this.ScoreLevelConfigMax;
				}
			}
		}

		// Token: 0x0603E6AF RID: 255663 RVA: 0x00FF1EB4 File Offset: 0x00FF00B4
		private void ResetScore()
		{
			this.CurScoreValue = -1f;
			this.CurScoreGroupId = -1;
			this.NextScoreLevelConfig = null;
			this.LastScoreLevelConfig = null;
		}

		// Token: 0x04022F97 RID: 143255
		[StaticVariableRuleIgnore]
		private static readonly string[] scoreSpritePathList = new string[]
		{
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/BossPiling/Game/SP_BossPilingGameScoreBGrey.SP_BossPilingGameScoreBGrey",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/BossPiling/Game/SP_BossPilingGameScoreB.SP_BossPilingGameScoreB",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/BossPiling/Game/SP_BossPilingGameScoreA.SP_BossPilingGameScoreA",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/BossPiling/Game/SP_BossPilingGameScoreS.SP_BossPilingGameScoreS",
			"/Game/Aki/UI/UIResources/UiActivity/Atlas/Activity33/BossPiling/Game/SP_BossPilingGameScoreSS.SP_BossPilingGameScoreSS"
		};

		// Token: 0x04022F98 RID: 143256
		private float CurScoreValue = -1f;

		// Token: 0x04022F99 RID: 143257
		private int CurScoreGroupId = -1;

		// Token: 0x04022F9A RID: 143258
		private BattleScoreLevelConf? LastScoreLevelConfig;

		// Token: 0x04022F9B RID: 143259
		private BattleScoreLevelConf? NextScoreLevelConfig;

		// Token: 0x04022F9C RID: 143260
		private readonly List<float> ScorePhaseValues = new List<float>();

		// Token: 0x04022F9D RID: 143261
		private float ScoreMaxValue;

		// Token: 0x04022F9E RID: 143262
		private int ScoreMaxLevel;

		// Token: 0x04022F9F RID: 143263
		private RogueScoreMachine InstScoreMachine = new RogueScoreMachine();

		// Token: 0x04022FA0 RID: 143264
		private UUISprite BarSprite;

		// Token: 0x04022FA1 RID: 143265
		private UUISprite BarBgSprite;

		// Token: 0x04022FA2 RID: 143266
		private UUITexture BarWhite;

		// Token: 0x04022FA3 RID: 143267
		private UUISprite IconSprite;

		// Token: 0x04022FA4 RID: 143268
		private UUIText ValueText;

		// Token: 0x04022FA5 RID: 143269
		[Nullable(new byte[]
		{
			1,
			2
		})]
		private readonly ULGUISpriteData_BaseObject[] BarSpriteDataList = new ULGUISpriteData_BaseObject[BossPilingScoreItem.scoreSpritePathList.Length];

		// Token: 0x04022FA6 RID: 143270
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x04022FA7 RID: 143271
		private bool IsPlayingMaxLevel;

		// Token: 0x04022FA8 RID: 143272
		[Nullable(2)]
		private TimerHandle TimeoutHd;

		// Token: 0x04022FA9 RID: 143273
		private static readonly FName P1Name = new FName("MainTexRotate");

		// Token: 0x04022FAA RID: 143274
		private static readonly FName P2Name = new FName("MaskAngle");

		// Token: 0x04022FAB RID: 143275
		private FLinearColor P1Color = new FLinearColor(0.5f, 0.5f, 0.5f, 1f);

		// Token: 0x04022FAC RID: 143276
		private float LastMaskValue = -1f;

		// Token: 0x04022FAD RID: 143277
		[Nullable(2)]
		private IReadOnlyList<BattleScoreLevelConf> ScoreLevelConfigList;

		// Token: 0x04022FAE RID: 143278
		private BattleScoreLevelConf? ScoreLevelConfigMax;

		// Token: 0x0200C189 RID: 49545
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B994 RID: 244116
			SprProgress,
			// Token: 0x0403B995 RID: 244117
			SprProgressLight,
			// Token: 0x0403B996 RID: 244118
			TextureWhite,
			// Token: 0x0403B997 RID: 244119
			SprScoreIcon,
			// Token: 0x0403B998 RID: 244120
			ValueText
		}
	}
}
