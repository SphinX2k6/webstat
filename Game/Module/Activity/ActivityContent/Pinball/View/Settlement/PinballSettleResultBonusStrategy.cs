using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065B7 RID: 26039
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballSettleResultBonusStrategy : PinballSettleResultStrategyBase
	{
		// Token: 0x17009ED9 RID: 40665
		// (get) Token: 0x060410F8 RID: 266488 RVA: 0x010B1A8C File Offset: 0x010AFC8C
		public override bool HasCustomRefreshTitle
		{
			get
			{
				return true;
			}
		}

		// Token: 0x060410F9 RID: 266489 RVA: 0x010B1A8F File Offset: 0x010AFC8F
		public override bool GetIsNeedProgressRewardView()
		{
			return true;
		}

		// Token: 0x060410FA RID: 266490 RVA: 0x010B1A92 File Offset: 0x010AFC92
		public override void RefreshTitle()
		{
			base.Context.ShowSuccessTips("Pinball_BattleSettlement_Fail");
		}

		// Token: 0x060410FB RID: 266491 RVA: 0x010B1AA4 File Offset: 0x010AFCA4
		public override void RefreshProgressRewards()
		{
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
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			for (int i = 0; i < pinballLevelConfigById.Value.ScoreLevelRewardLength; i++)
			{
				DicIntInt? dicIntInt = pinballLevelConfigById.Value.ScoreLevelReward(i);
				if (dicIntInt != null)
				{
					list.Add(dicIntInt.Value.Key);
					list2.Add(dicIntInt.Value.Value);
				}
			}
			base.Context.ShowProgressRewardList(base.Context.GetOpenParam().Score, list.ToArray(), list2.ToArray());
		}

		// Token: 0x060410FC RID: 266492 RVA: 0x010B1BAF File Offset: 0x010AFDAF
		public override void RefreshButtons()
		{
			base.Context.BindRestartButton();
			base.Context.BindBackButton();
		}

		// Token: 0x060410FD RID: 266493 RVA: 0x010B1BC7 File Offset: 0x010AFDC7
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

		// Token: 0x060410FE RID: 266494 RVA: 0x010B1BEC File Offset: 0x010AFDEC
		public override void OnClickBtnBack(Action callback)
		{
			if (base.Context.GetOpenParam().Score >= ModelBase<PinballModel>.Instance.ActivityData.GetLevelMaxScore(base.Context.GetOpenParam().LevelId))
			{
				base.OpenMainRootView();
			}
			else
			{
				ControllerBase<PinballController>.Instance.OpenLevelView(base.Context.GetOpenParam().LevelId, true).Forget<bool>();
			}
			callback();
		}
	}
}
