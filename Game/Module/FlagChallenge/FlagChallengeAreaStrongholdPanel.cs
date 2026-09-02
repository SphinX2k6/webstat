using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Battle;
using CSharpScript.Game.Module.WorldMap;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.FlagChallenge
{
	// Token: 0x02005D51 RID: 23889
	[NullableContext(1)]
	[Nullable(0)]
	public class FlagChallengeAreaStrongholdPanel : UiPanelBase
	{
		// Token: 0x0603C36B RID: 246635 RVA: 0x00F45DD6 File Offset: 0x00F43FD6
		public FlagChallengeAreaStrongholdPanel(int activityId)
		{
			this.ActivityId = activityId;
		}

		// Token: 0x0603C36C RID: 246636 RVA: 0x00F45DE8 File Offset: 0x00F43FE8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUITexture)),
				new ValueTuple<int, Type>(1, typeof(UUIArtText)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem)),
				new ValueTuple<int, Type>(4, typeof(UUIButtonComponent)),
				new ValueTuple<int, Type>(5, typeof(UUITexture)),
				new ValueTuple<int, Type>(6, typeof(UUIItem)),
				new ValueTuple<int, Type>(7, typeof(UUIItem)),
				new ValueTuple<int, Type>(8, typeof(UUIItem))
			};
		}

		// Token: 0x0603C36D RID: 246637 RVA: 0x00F45EC8 File Offset: 0x00F440C8
		protected override UniTask OnBeforeStartAsync()
		{
			FlagChallengeAreaStrongholdPanel.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<FlagChallengeAreaStrongholdPanel.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603C36E RID: 246638 RVA: 0x00F45F0C File Offset: 0x00F4410C
		public void RefreshView(int id)
		{
			this.Data = ModelBase<FlagChallengeModel>.Instance.GetStrongholdData(id);
			FlagStronghold strongholdConfig = this.Data.StrongholdConfig;
			UiResourceConfig instance = ConfigBase<UiResourceConfig>.Instance;
			base.SetTextureByPath(strongholdConfig.MonsterIconPath, base.GetTexture(5), null, null);
			base.GetArtText(1).SetText(strongholdConfig.MonsterLevel.ToString());
			string levelDiffBgRes = this.GetLevelDiffBgRes(strongholdConfig.MonsterLevel);
			base.SetTextureByPath(instance.GetResourcePath(levelDiffBgRes), base.GetTexture(0), null, null);
			this.DescriptionComponent.SetContentByTextId(strongholdConfig.MonsterDesc, Array.Empty<string>());
			base.GetSprite(2).SetUIActive(this.Data.IsPass);
			bool flag = this.Data.IsUnlocked();
			UUIButtonComponent button = base.GetButton(4);
			UUIItem item = base.GetItem(8);
			if (flag)
			{
				FlagChallengeData flagChallengeData = ModelBase<FlagChallengeModel>.Instance.GetFlagChallengeData(this.ActivityId);
				int challengeLevelId = this.Data.StrongholdConfig.ChallengeLevelId;
				bool flag2 = flagChallengeData.GetLevelData(challengeLevelId).IsCompleted();
				button.RootUIComp.Get().SetUIActive(!flag2);
				item.SetUIActive(flag2);
			}
			else
			{
				button.RootUIComp.Get().SetUIActive(false);
				item.SetUIActive(false);
			}
			base.GetItem(7).SetUIActive(!flag);
		}

		// Token: 0x0603C36F RID: 246639 RVA: 0x00F46078 File Offset: 0x00F44278
		private string GetLevelDiffBgRes(int targetLevel)
		{
			switch (ModelBase<FlagChallengeModel>.Instance.GetLevelDiffType(this.ActivityId, targetLevel, null))
			{
			case EFlagChallengeLevelDiffType.Easy:
				return "T_EnemyFlagChallengeLevelGreenBg";
			case EFlagChallengeLevelDiffType.Normal:
				return "T_EnemyFlagChallengeLevelYellowBg";
			case EFlagChallengeLevelDiffType.Hard:
				return "T_EnemyFlagChallengeLevelRedBg";
			default:
				return "T_EnemyFlagChallengeLevelGreenBg";
			}
		}

		// Token: 0x0603C370 RID: 246640 RVA: 0x00F460CC File Offset: 0x00F442CC
		private void OnClickButton(int _)
		{
			int challengeLevelId = this.Data.StrongholdConfig.ChallengeLevelId;
			FlagChallengeBattleModel instance = ModelBase<FlagChallengeBattleModel>.Instance;
			if (!instance.IsInFlagChallengeDungeon || instance.LevelId != challengeLevelId)
			{
				ControllerBase<FlagChallengeController>.Instance.OpenFlagChallengeSelectRoleView(this.ActivityId, challengeLevelId, this.Data.Id);
				return;
			}
			ControllerBase<WorldMapController>.Instance.TryTeleportByEntityId(this.Data.GetMarkId(), null);
			Singleton<UiManager>.Instance.CloseView(EUiViewName.FlagChallengeAreaDetailView, null);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FlagChallengePauseView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FlagChallengePauseView, null);
			}
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.FlagChallengeSettleView))
			{
				Singleton<UiManager>.Instance.CloseView(EUiViewName.FlagChallengeSettleView, null);
			}
		}

		// Token: 0x04021D1F RID: 138527
		[Nullable(2)]
		private FlagChallengeStrongholdData Data;

		// Token: 0x04021D20 RID: 138528
		private readonly int ActivityId;

		// Token: 0x04021D21 RID: 138529
		[Nullable(2)]
		private ActivityDescriptionTypeA DescriptionComponent;

		// Token: 0x04021D22 RID: 138530
		private ButtonItem FunctionButton;

		// Token: 0x04021D23 RID: 138531
		private FlagChallengeLockItem LockItem;

		// Token: 0x04021D24 RID: 138532
		private FlagChallengeCompleteItem CompleteItem;
	}
}
