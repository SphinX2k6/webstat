using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.BattleUi.Views;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Battle
{
	// Token: 0x02005F39 RID: 24377
	[NullableContext(1)]
	[Nullable(0)]
	public class MoraleMonsterLevelItem : StateExtraItemBase
	{
		// Token: 0x0603D3E8 RID: 250856 RVA: 0x00F93358 File Offset: 0x00F91558
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

		// Token: 0x0603D3E9 RID: 250857 RVA: 0x00F933E4 File Offset: 0x00F915E4
		protected override UniTask OnCreateAsync()
		{
			MoraleMonsterLevelItem.<OnCreateAsync>d__14 <OnCreateAsync>d__;
			<OnCreateAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnCreateAsync>d__.<>4__this = this;
			<OnCreateAsync>d__.<>1__state = -1;
			<OnCreateAsync>d__.<>t__builder.Start<MoraleMonsterLevelItem.<OnCreateAsync>d__14>(ref <OnCreateAsync>d__);
			return <OnCreateAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603D3EA RID: 250858 RVA: 0x00F93428 File Offset: 0x00F91628
		protected override void OnStart()
		{
			base.OnStart();
			this.LevelDiffTexture = base.GetTexture(1);
			this.LightTexture = base.GetTexture(2);
			this.LevelSequencePlayer = new LevelSequencePlayer(this.RootItem);
			Singleton<EventSystem>.Instance.Add(EEventName.OnMoraleSumLevelChanged, new Action<int, int, int, int>(this.OnMoraleSumLevelChanged));
		}

		// Token: 0x0603D3EB RID: 250859 RVA: 0x00F93484 File Offset: 0x00F91684
		protected override void OnBeforeDestroy()
		{
			Dictionary<EMoraleLevelDiffType, UTexture> levelDiffTextureMap = this.LevelDiffTextureMap;
			if (levelDiffTextureMap != null)
			{
				levelDiffTextureMap.Clear();
			}
			LevelSequencePlayer levelSequencePlayer = this.LevelSequencePlayer;
			if (levelSequencePlayer != null)
			{
				levelSequencePlayer.Clear();
			}
			Singleton<EventSystem>.Instance.Remove(EEventName.OnMoraleSumLevelChanged, new Action<int, int, int, int>(this.OnMoraleSumLevelChanged));
			base.OnBeforeDestroy();
		}

		// Token: 0x0603D3EC RID: 250860 RVA: 0x00F934D5 File Offset: 0x00F916D5
		private void OnMoraleSumLevelChanged(int oldLevel, int newLevel, int oldTempLevel, int newTempLevel)
		{
			this.SetMoraleLevelDiff(this.MoraleLevel);
		}

		// Token: 0x0603D3ED RID: 250861 RVA: 0x00F934E4 File Offset: 0x00F916E4
		protected override void OnInitExtraParams(ExtraItemParams param)
		{
			int moraleLevel = ((MoraleLevelItemParams)param).MoraleLevel;
			this.SetMoraleLevel(moraleLevel);
		}

		// Token: 0x0603D3EE RID: 250862 RVA: 0x00F93504 File Offset: 0x00F91704
		private void SetMoraleLevel(int moraleLevel)
		{
			this.MoraleLevel = moraleLevel;
			UUIArtText artText = base.GetArtText(0);
			if (artText != null)
			{
				artText.SetText(moraleLevel.ToString());
			}
			this.SetMoraleLevelDiff(moraleLevel);
		}

		// Token: 0x0603D3EF RID: 250863 RVA: 0x00F93530 File Offset: 0x00F91730
		private void SetMoraleLevelDiff(int moraleLevel)
		{
			EMoraleLevelDiffType moraleLevelDiffType = ModelBase<MoraleBattleModel>.Instance.GetMoraleLevelDiffType(moraleLevel, null);
			EMoraleLevelDiffType emoraleLevelDiffType = moraleLevelDiffType;
			EMoraleLevelDiffType? moraleLevelDiffType2 = this.MoraleLevelDiffType;
			if (emoraleLevelDiffType == moraleLevelDiffType2.GetValueOrDefault() & moraleLevelDiffType2 != null)
			{
				return;
			}
			this.MoraleLevelDiffType = new EMoraleLevelDiffType?(moraleLevelDiffType);
			UTexture texture;
			if (this.LevelDiffTextureMap != null && this.LevelDiffTextureMap.TryGetValue(moraleLevelDiffType, out texture))
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
			switch (moraleLevelDiffType)
			{
			case EMoraleLevelDiffType.Easy:
			{
				UUITexture lightTexture = this.LightTexture;
				if (lightTexture != null)
				{
					lightTexture.SetColor(FColor.FromHex("#000000cc"));
				}
				LevelSequencePlayer levelSequencePlayer2 = this.LevelSequencePlayer;
				if (levelSequencePlayer2 == null)
				{
					return;
				}
				levelSequencePlayer2.PlaySequencePurely("Start01", false, false, null, null, false);
				return;
			}
			case EMoraleLevelDiffType.Normal:
			{
				UUITexture lightTexture2 = this.LightTexture;
				if (lightTexture2 != null)
				{
					lightTexture2.SetColor(FColor.FromHex("#ff9517cc"));
				}
				LevelSequencePlayer levelSequencePlayer3 = this.LevelSequencePlayer;
				if (levelSequencePlayer3 == null)
				{
					return;
				}
				levelSequencePlayer3.PlaySequencePurely("Start03", false, false, null, null, false);
				return;
			}
			case EMoraleLevelDiffType.Hard:
			{
				UUITexture lightTexture3 = this.LightTexture;
				if (lightTexture3 != null)
				{
					lightTexture3.SetColor(FColor.FromHex("#ff1e18cc"));
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

		// Token: 0x0603D3F0 RID: 250864 RVA: 0x00F93688 File Offset: 0x00F91888
		private UniTask LoadLevelDiffSprite(string path, EMoraleLevelDiffType index)
		{
			MoraleMonsterLevelItem.<LoadLevelDiffSprite>d__21 <LoadLevelDiffSprite>d__;
			<LoadLevelDiffSprite>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<LoadLevelDiffSprite>d__.<>4__this = this;
			<LoadLevelDiffSprite>d__.path = path;
			<LoadLevelDiffSprite>d__.index = index;
			<LoadLevelDiffSprite>d__.<>1__state = -1;
			<LoadLevelDiffSprite>d__.<>t__builder.Start<MoraleMonsterLevelItem.<LoadLevelDiffSprite>d__21>(ref <LoadLevelDiffSprite>d__);
			return <LoadLevelDiffSprite>d__.<>t__builder.Task;
		}

		// Token: 0x04022592 RID: 140690
		private const string LEVEL_DIFF_SPRITE_EASY = "/Game/Aki/UI/UIResources/UiFight/Image/Flag/T_EmenyMoraleLevelGray.T_EmenyMoraleLevelGray";

		// Token: 0x04022593 RID: 140691
		private const string LEVEL_DIFF_SPRITE_NORMAL = "/Game/Aki/UI/UIResources/UiFight/Image/Flag/T_EmenyMoraleLevelYellow.T_EmenyMoraleLevelYellow";

		// Token: 0x04022594 RID: 140692
		private const string LEVEL_DIFF_SPRITE_HARD = "/Game/Aki/UI/UIResources/UiFight/Image/Flag/T_EmenyMoraleLevelRed.T_EmenyMoraleLevelRed";

		// Token: 0x04022595 RID: 140693
		private const string LEVEL_DIFF_COLOR_EASY = "#000000cc";

		// Token: 0x04022596 RID: 140694
		private const string LEVEL_DIFF_COLOR_NORMAL = "#ff9517cc";

		// Token: 0x04022597 RID: 140695
		private const string LEVEL_DIFF_COLOR_HARD = "#ff1e18cc";

		// Token: 0x04022598 RID: 140696
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Dictionary<EMoraleLevelDiffType, UTexture> LevelDiffTextureMap;

		// Token: 0x04022599 RID: 140697
		[Nullable(2)]
		private UUITexture LevelDiffTexture;

		// Token: 0x0402259A RID: 140698
		[Nullable(2)]
		private UUITexture LightTexture;

		// Token: 0x0402259B RID: 140699
		private int MoraleLevel = 1;

		// Token: 0x0402259C RID: 140700
		private EMoraleLevelDiffType? MoraleLevelDiffType;

		// Token: 0x0402259D RID: 140701
		[Nullable(2)]
		private LevelSequencePlayer LevelSequencePlayer;

		// Token: 0x0200BF5D RID: 48989
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403AE73 RID: 241267
			LevelText,
			// Token: 0x0403AE74 RID: 241268
			LevelDiffTexture,
			// Token: 0x0403AE75 RID: 241269
			LightTexture
		}
	}
}
