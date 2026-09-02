using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Reward;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B9 RID: 26041
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballSettleResultNormalStrategy : PinballSettleResultStrategyBase
	{
		// Token: 0x06041108 RID: 266504 RVA: 0x010B1D59 File Offset: 0x010AFF59
		public override bool GetIsNeedRewardView()
		{
			return base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x06041109 RID: 266505 RVA: 0x010B1D6B File Offset: 0x010AFF6B
		public override bool GetIsNeedDialogView()
		{
			return !base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x0604110A RID: 266506 RVA: 0x010B1D80 File Offset: 0x010AFF80
		public override bool GetIsNeedFailTipsView()
		{
			return !base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x0604110B RID: 266507 RVA: 0x010B1D95 File Offset: 0x010AFF95
		public override void RefreshStarLayout()
		{
			if (!base.Context.GetOpenParam().IsWin)
			{
				return;
			}
			base.Context.ShowStarLayout(base.Context.GetOpenParam().StarInfo);
		}

		// Token: 0x0604110C RID: 266508 RVA: 0x010B1DC8 File Offset: 0x010AFFC8
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

		// Token: 0x0604110D RID: 266509 RVA: 0x010B1E94 File Offset: 0x010B0094
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

		// Token: 0x0604110E RID: 266510 RVA: 0x010B1F0B File Offset: 0x010B010B
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

		// Token: 0x0604110F RID: 266511 RVA: 0x010B1F30 File Offset: 0x010B0130
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
			if (pinballLevelConfigById.Value.NextLevelId == 0)
			{
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.PinballBattle;
				ELogAuthor author2 = ELogAuthor.CB;
				string message2 = "星弹奇游关卡配置不存在下一关";
				ValueTuple<string, object> valueTuple2 = new ValueTuple<string, object>("LevelId", levelId);
				instance2.Error(module2, author2, message2, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple2));
				return;
			}
			ControllerBase<PinballController>.Instance.OpenLevelView(pinballLevelConfigById.Value.NextLevelId, true).Forget<bool>();
			callback();
		}

		// Token: 0x06041110 RID: 266512 RVA: 0x010B1FFB File Offset: 0x010B01FB
		public override void OnClickBtnBack(Action callback)
		{
			ControllerBase<PinballController>.Instance.OpenLevelView(base.Context.GetOpenParam().LevelId, true).Forget<bool>();
			callback();
		}
	}
}
