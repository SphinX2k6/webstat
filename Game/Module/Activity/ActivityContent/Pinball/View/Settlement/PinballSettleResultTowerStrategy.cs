using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065BB RID: 26043
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballSettleResultTowerStrategy : PinballSettleResultStrategyBase
	{
		// Token: 0x0604112B RID: 266539 RVA: 0x010B21D2 File Offset: 0x010B03D2
		public override bool GetIsNeedRewardView()
		{
			return base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x0604112C RID: 266540 RVA: 0x010B21E4 File Offset: 0x010B03E4
		public override bool GetIsNeedDialogView()
		{
			return !base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x0604112D RID: 266541 RVA: 0x010B21F9 File Offset: 0x010B03F9
		public override bool GetIsNeedFailTipsView()
		{
			return !base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x0604112E RID: 266542 RVA: 0x010B220E File Offset: 0x010B040E
		public override void RefreshStarLayout()
		{
			if (!base.Context.GetOpenParam().IsWin)
			{
				return;
			}
			base.Context.ShowStarLayout(base.Context.GetOpenParam().StarInfo);
		}

		// Token: 0x0604112F RID: 266543 RVA: 0x010B2240 File Offset: 0x010B0440
		public override void RefreshRewards()
		{
			if (!base.Context.GetOpenParam().IsWin)
			{
				return;
			}
			if (!base.Context.GetOpenParam().IsFirstPass)
			{
				base.Context.ShowRewardsGot();
				return;
			}
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(base.Context.GetOpenParam().LevelId);
			if (pinballLevelConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游关卡配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelId", base.Context.GetOpenParam().LevelId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(pinballLevelConfigById.Value.FirstClearDropId);
			base.Context.ShowRewards(dropPackagePreviewItemList);
		}

		// Token: 0x06041130 RID: 266544 RVA: 0x010B230C File Offset: 0x010B050C
		public override void RefreshButtons()
		{
			base.Context.BindRestartButton();
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(base.Context.GetOpenParam().LevelId);
			if (base.Context.GetOpenParam().IsWin && pinballLevelConfigById != null && pinballLevelConfigById.Value.NextLevelId > 0)
			{
				base.Context.BindNextButton();
				return;
			}
			base.Context.BindBackButton();
		}

		// Token: 0x06041131 RID: 266545 RVA: 0x010B2383 File Offset: 0x010B0583
		public override void OnClickBtnRestart(Action callback)
		{
			if (base.Context.GetNeedAdjustFormation())
			{
				base.OpenFormationView();
			}
			else
			{
				base.RestartImmediate();
			}
			callback();
		}

		// Token: 0x06041132 RID: 266546 RVA: 0x010B23A8 File Offset: 0x010B05A8
		public override void OnClickBtnNext(Action callback)
		{
			int levelId = base.Context.GetOpenParam().LevelId;
			PinballLevelConfig? pinballLevelConfigById = ConfigBase<PinballConfig>.Instance.GetPinballLevelConfigById(levelId);
			if (pinballLevelConfigById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.PinballBattle;
				ELogAuthor author = ELogAuthor.CB;
				string message = "星弹奇游关卡配置不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("LevelId", levelId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			ControllerBase<PinballController>.Instance.OpenTowerLevelView(pinballLevelConfigById.Value.NextLevelId, true).Forget<bool>();
			callback();
		}

		// Token: 0x06041133 RID: 266547 RVA: 0x010B2430 File Offset: 0x010B0630
		public override void OnClickBtnBack(Action callback)
		{
			ControllerBase<PinballController>.Instance.OpenTowerLevelView(base.Context.GetOpenParam().LevelId, true).Forget<bool>();
			callback();
		}
	}
}
