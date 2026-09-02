using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D7C RID: 23932
	public class FlagChallengeStrongholdPanel : UiPanelBase
	{
		// Token: 0x0603C451 RID: 246865 RVA: 0x00F4AE49 File Offset: 0x00F49049
		public FlagChallengeStrongholdPanel(int activityId, int strongholdId)
		{
			this.ActivityId = activityId;
			this.StrongholdId = strongholdId;
		}

		// Token: 0x0603C452 RID: 246866 RVA: 0x00F4AE60 File Offset: 0x00F49060
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUITexture)),
				new ValueTuple<int, Type>(3, typeof(UUISprite))
			};
		}

		// Token: 0x0603C453 RID: 246867 RVA: 0x00F4AED0 File Offset: 0x00F490D0
		protected override void OnStart()
		{
			FlagChallengeStrongholdData strongholdData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId).GetStrongholdData(this.StrongholdId);
			FlagStronghold strongholdConfig = strongholdData.StrongholdConfig;
			int monsterLevel = strongholdConfig.MonsterLevel;
			base.GetArtText(1).SetText(monsterLevel.ToString());
			base.SetTextureByPath(strongholdConfig.MonsterIconPath, base.GetTexture(2), null, null);
			base.GetSprite(3).SetUIActive(strongholdData.IsPass);
			switch (ModelBase<FlagChallengeModel>.Instance.GetLevelDiffType(this.ActivityId, monsterLevel, null))
			{
			case EFlagChallengeLevelDiffType.Easy:
				this.SetDiffIcon("T_EnemyFlagChallengeLevelGreenBg");
				return;
			case EFlagChallengeLevelDiffType.Normal:
				this.SetDiffIcon("T_EnemyFlagChallengeLevelYellowBg");
				return;
			case EFlagChallengeLevelDiffType.Hard:
				this.SetDiffIcon("T_EnemyFlagChallengeLevelRedBg");
				return;
			default:
				return;
			}
		}

		// Token: 0x0603C454 RID: 246868 RVA: 0x00F4AFA0 File Offset: 0x00F491A0
		[NullableContext(1)]
		private void SetDiffIcon(string resId)
		{
			string resourcePath = ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resId);
			base.SetTextureByPath(resourcePath, base.GetTexture(0), null, null);
		}

		// Token: 0x04021E37 RID: 138807
		private readonly int ActivityId;

		// Token: 0x04021E38 RID: 138808
		private readonly int StrongholdId;
	}
}
