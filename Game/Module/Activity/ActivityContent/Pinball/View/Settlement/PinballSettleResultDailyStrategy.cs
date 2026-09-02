using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Reward;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B8 RID: 26040
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballSettleResultDailyStrategy : PinballSettleResultStrategyBase
	{
		// Token: 0x06041100 RID: 266496 RVA: 0x010B1C60 File Offset: 0x010AFE60
		public override bool GetIsNeedRewardView()
		{
			return base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x06041101 RID: 266497 RVA: 0x010B1C72 File Offset: 0x010AFE72
		public override bool GetIsNeedDialogView()
		{
			return !base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x06041102 RID: 266498 RVA: 0x010B1C87 File Offset: 0x010AFE87
		public override bool GetIsNeedFailTipsView()
		{
			return !base.Context.GetOpenParam().IsWin;
		}

		// Token: 0x06041103 RID: 266499 RVA: 0x010B1C9C File Offset: 0x010AFE9C
		public override void RefreshRewards()
		{
			if (!base.Context.GetOpenParam().IsWin)
			{
				return;
			}
			int curDailyRewardDropId = ModelBase<PinballModel>.Instance.ActivityData.GetCurDailyRewardDropId();
			List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(curDailyRewardDropId);
			base.Context.ShowRewards(dropPackagePreviewItemList);
		}

		// Token: 0x06041104 RID: 266500 RVA: 0x010B1CE4 File Offset: 0x010AFEE4
		public override void RefreshButtons()
		{
			base.Context.BindRestartButton();
			base.Context.BindBackButton();
		}

		// Token: 0x06041105 RID: 266501 RVA: 0x010B1CFC File Offset: 0x010AFEFC
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

		// Token: 0x06041106 RID: 266502 RVA: 0x010B1D1F File Offset: 0x010AFF1F
		public override void OnClickBtnBack(Action callback)
		{
			if (base.Context.GetOpenParam().IsWin)
			{
				base.OpenMainRootView();
			}
			else
			{
				ControllerBase<PinballController>.Instance.OpenDailyLevelView(true).Forget<bool>();
			}
			callback();
		}
	}
}
