using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using CSharpScript.Game.Module.FlagChallenge;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F1C RID: 24348
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeMonsterLevelItem : StateExtraItemBase
	{
		// Token: 0x0603D282 RID: 250498 RVA: 0x00F8A4E4 File Offset: 0x00F886E4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIArtText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603D283 RID: 250499 RVA: 0x00F8A570 File Offset: 0x00F88770
		protected override UniTask OnCreateAsync()
		{
			FlagChallengeMonsterLevelItem.<OnCreateAsync>d__14 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<FlagChallengeMonsterLevelItem.<OnCreateAsync>d__14>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D284 RID: 250500 RVA: 0x00F8A5B4 File Offset: 0x00F887B4
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelDiffTexture = base.GetTexture(1);
			this.LightTexture = base.GetTexture(2);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			Singleton<EventSystem>.Instance.Add(EEventName.OnFlagChallengeTotalLevelChanged, new Action<int, int, int, int>(this.OnFlagChallengeTotalLevelChanged));
		}

		// Token: 0x0603D285 RID: 250501 RVA: 0x00F8A610 File Offset: 0x00F88810
		protected override void OnBeforeDestroy()
		{
			Dictionary<EFlagChallengeLevelDiffType, UTexture> levelDiffTextureMap = this.LevelDiffTextureMap;
			if (levelDiffTextureMap != null)
			{
				levelDiffTextureMap.Clear();
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFlagChallengeTotalLevelChanged, new Action<int, int, int, int>(this.OnFlagChallengeTotalLevelChanged));
			base.OnBeforeDestroy();
		}

		// Token: 0x0603D286 RID: 250502 RVA: 0x00F8A661 File Offset: 0x00F88861
		private void OnFlagChallengeTotalLevelChanged(int oldLevel, int newLevel, int oldTempLevel, int newTempLevel)
		{
			this.SetFlagChallengeLevelDiff(this.FlagChallengeLevel);
		}

		// Token: 0x0603D287 RID: 250503 RVA: 0x00F8A670 File Offset: 0x00F88870
		protected override void OnInitExtraParams(ExtraItemParams paramsObj)
		{
			FlagChallengeLevelItemParams flagChallengeLevelItemParams = paramsObj as FlagChallengeLevelItemParams;
			if (flagChallengeLevelItemParams == null)
			{
				throw new InvalidCastException();
			}
			int flagChallengeLevel = flagChallengeLevelItemParams.FlagChallengeLevel;
			this.SetFlagChallengeLevel(flagChallengeLevel);
		}

		// Token: 0x0603D288 RID: 250504 RVA: 0x00F8A69C File Offset: 0x00F8889C
		private void SetFlagChallengeLevel(int mosnterLevelId)
		{
			int level = ConfigBase<FlagChallengeConfig>.Instance.GetMonsterLevelConfigById(mosnterLevelId).Value.Level;
			this.FlagChallengeLevel = level;
			UUIArtText artText = base.GetArtText(0);
			if (artText != null)
			{
				artText.SetText(level.ToString());
			}
			this.SetFlagChallengeLevelDiff(level);
		}

		// Token: 0x0603D289 RID: 250505 RVA: 0x00F8A6EC File Offset: 0x00F888EC
		private void SetFlagChallengeLevelDiff(int flagChallengeLevel)
		{
			int activityId = ModelBase<FlagChallengeBattleModel>.Instance.ActivityId;
			EFlagChallengeLevelDiffType levelDiffType = ModelBase<FlagChallengeModel>.Instance.GetLevelDiffType(activityId, flagChallengeLevel, null);
			EFlagChallengeLevelDiffType eflagChallengeLevelDiffType = levelDiffType;
			EFlagChallengeLevelDiffType? flagChallengeLevelDiffType = this.FlagChallengeLevelDiffType;
			if (eflagChallengeLevelDiffType == flagChallengeLevelDiffType.GetValueOrDefault() & flagChallengeLevelDiffType != null)
			{
				return;
			}
			this.FlagChallengeLevelDiffType = new EFlagChallengeLevelDiffType?(levelDiffType);
			UTexture texture;
			if (this.LevelDiffTextureMap != null && this.LevelDiffTextureMap.TryGetValue(levelDiffType, out texture))
			{
				UUITexture levelDiffTexture = this.LevelDiffTexture;
				if (levelDiffTexture != null)
				{
					levelDiffTexture.SetTexture(texture);
				}
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.StopCurrentSequence(false, true);
			}
			switch (levelDiffType)
			{
			case EFlagChallengeLevelDiffType.Easy:
			{
				UUITexture lightTexture = this.LightTexture;
				if (lightTexture != null)
				{
					lightTexture.SetColor(FColor.FromHex("#8AD797"));
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlaySequencePurely("Start01", false, false, null, null, false);
				return;
			}
			case EFlagChallengeLevelDiffType.Normal:
			{
				UUITexture lightTexture2 = this.LightTexture;
				if (lightTexture2 != null)
				{
					lightTexture2.SetColor(FColor.FromHex("#FF9517"));
				}
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 == null)
				{
					return;
				}
				levelSequencePlayer3.PlaySequencePurely("Start03", false, false, null, null, false);
				return;
			}
			case EFlagChallengeLevelDiffType.Hard:
			{
				UUITexture lightTexture3 = this.LightTexture;
				if (lightTexture3 != null)
				{
					lightTexture3.SetColor(FColor.FromHex("#FF1E18"));
				}
				LevelSequencePlayer levelSequencePlayer4 = this.LevelSequencePlayer;
				if (levelSequencePlayer4 == null)
				{
					return;
				}
				levelSequencePlayer4.PlaySequencePurely("Start02", false, false, null, null, false);
				return;
			}
			default:
				return;
			}
		}

		// Token: 0x0603D28A RID: 250506 RVA: 0x00F8A850 File Offset: 0x00F88A50
		private UniTask LoadLevelDiffSprite(string path, EFlagChallengeLevelDiffType index)
		{
			FlagChallengeMonsterLevelItem.<LoadLevelDiffSprite>d__21 <LoadLevelDiffSprite>d__;
			<LoadLevelDiffSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLevelDiffSprite>d__.<>4__this = this;
			<LoadLevelDiffSprite>d__.path = path;
			<LoadLevelDiffSprite>d__.index = index;
			<LoadLevelDiffSprite>d__.<>1__state = -1;
			<LoadLevelDiffSprite>d__.<>t__builder.Start<FlagChallengeMonsterLevelItem.<LoadLevelDiffSprite>d__21>(ref <LoadLevelDiffSprite>d__);
			return <LoadLevelDiffSprite>d__.<>t__builder.Task;
		}

		// Token: 0x040224B6 RID: 140470
		private const string LEVEL_DIFF_SPRITE_EASY = "/Game/Aki/UI/UIResources/UiFight/Image/Activity/Activity32/Morale/T_EmenyMoraleLevelGreen.T_EmenyMoraleLevelGreen";

		// Token: 0x040224B7 RID: 140471
		private const string LEVEL_DIFF_SPRITE_NORMAL = "/Game/Aki/UI/UIResources/UiFight/Image/Activity/Activity32/Morale/T_EmenyMoraleLevelYellow.T_EmenyMoraleLevelYellow";

		// Token: 0x040224B8 RID: 140472
		private const string LEVEL_DIFF_SPRITE_HARD = "/Game/Aki/UI/UIResources/UiFight/Image/Activity/Activity32/Morale/T_EmenyMoraleLevelRed.T_EmenyMoraleLevelRed";

		// Token: 0x040224B9 RID: 140473
		private const string LEVEL_DIFF_COLOR_EASY = "#8AD797";

		// Token: 0x040224BA RID: 140474
		private const string LEVEL_DIFF_COLOR_NORMAL = "#FF9517";

		// Token: 0x040224BB RID: 140475
		private const string LEVEL_DIFF_COLOR_HARD = "#FF1E18";

		// Token: 0x040224BC RID: 140476
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EFlagChallengeLevelDiffType, UTexture> LevelDiffTextureMap;

		// Token: 0x040224BD RID: 140477
		[Nullable(2)]
		private UUITexture LevelDiffTexture;

		// Token: 0x040224BE RID: 140478
		[Nullable(2)]
		private UUITexture LightTexture;

		// Token: 0x040224BF RID: 140479
		private int FlagChallengeLevel = 1;

		// Token: 0x040224C0 RID: 140480
		private EFlagChallengeLevelDiffType? FlagChallengeLevelDiffType;

		// Token: 0x040224C1 RID: 140481
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BF21 RID: 48929
		[NullableContext(0)]
		private enum EComponentType
		{
			// Token: 0x0403AD4A RID: 240970
			LevelText,
			// Token: 0x0403AD4B RID: 240971
			LevelDiffTexture,
			// Token: 0x0403AD4C RID: 240972
			LightTexture
		}
	}
}
