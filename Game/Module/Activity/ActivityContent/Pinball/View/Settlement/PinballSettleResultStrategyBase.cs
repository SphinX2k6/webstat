using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.KuroSimpleCombat.PB;
using CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Formation;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065BA RID: 26042
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballSettleResultStrategyBase : IPinballSettleResultStrategy
	{
		// Token: 0x17009EDA RID: 40666
		// (get) Token: 0x06041112 RID: 266514 RVA: 0x010B202B File Offset: 0x010B022B
		// (set) Token: 0x06041113 RID: 266515 RVA: 0x010B2033 File Offset: 0x010B0233
		public IPinballSettleResultViewContext Context { get; set; }

		// Token: 0x06041114 RID: 266516 RVA: 0x010B203C File Offset: 0x010B023C
		public virtual bool GetIsNeedRewardView()
		{
			return false;
		}

		// Token: 0x06041115 RID: 266517 RVA: 0x010B203F File Offset: 0x010B023F
		public virtual bool GetIsNeedProgressRewardView()
		{
			return false;
		}

		// Token: 0x06041116 RID: 266518 RVA: 0x010B2042 File Offset: 0x010B0242
		public virtual bool GetIsNeedFailTipsView()
		{
			return false;
		}

		// Token: 0x06041117 RID: 266519 RVA: 0x010B2045 File Offset: 0x010B0245
		public virtual bool GetIsNeedUnlockTipsView()
		{
			return false;
		}

		// Token: 0x06041118 RID: 266520 RVA: 0x010B2048 File Offset: 0x010B0248
		public virtual bool GetIsNeedDialogView()
		{
			return false;
		}

		// Token: 0x17009EDB RID: 40667
		// (get) Token: 0x06041119 RID: 266521 RVA: 0x010B204B File Offset: 0x010B024B
		public virtual bool HasCustomRefreshTitle
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17009EDC RID: 40668
		// (get) Token: 0x0604111A RID: 266522 RVA: 0x010B204E File Offset: 0x010B024E
		public virtual bool HasCustomRefreshFailTips
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17009EDD RID: 40669
		// (get) Token: 0x0604111B RID: 266523 RVA: 0x010B2051 File Offset: 0x010B0251
		public virtual bool HasCustomRefreshDialog
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0604111C RID: 266524 RVA: 0x010B2054 File Offset: 0x010B0254
		public virtual void RefreshTitle()
		{
		}

		// Token: 0x0604111D RID: 266525 RVA: 0x010B2056 File Offset: 0x010B0256
		public virtual void RefreshStarLayout()
		{
		}

		// Token: 0x0604111E RID: 266526 RVA: 0x010B2058 File Offset: 0x010B0258
		public virtual void RefreshRewards()
		{
		}

		// Token: 0x0604111F RID: 266527 RVA: 0x010B205A File Offset: 0x010B025A
		public virtual void RefreshButtons()
		{
		}

		// Token: 0x06041120 RID: 266528 RVA: 0x010B205C File Offset: 0x010B025C
		public virtual void RefreshProgressRewards()
		{
		}

		// Token: 0x06041121 RID: 266529 RVA: 0x010B205E File Offset: 0x010B025E
		public virtual void RefreshUnlockTips()
		{
		}

		// Token: 0x06041122 RID: 266530 RVA: 0x010B2060 File Offset: 0x010B0260
		public virtual void RefreshFailTips()
		{
		}

		// Token: 0x06041123 RID: 266531 RVA: 0x010B2062 File Offset: 0x010B0262
		public virtual void RefreshDialog()
		{
		}

		// Token: 0x06041124 RID: 266532 RVA: 0x010B2064 File Offset: 0x010B0264
		public virtual void OnClickBtnRestart(Action callback)
		{
		}

		// Token: 0x06041125 RID: 266533 RVA: 0x010B2066 File Offset: 0x010B0266
		public virtual void OnClickBtnNext(Action callback)
		{
		}

		// Token: 0x06041126 RID: 266534 RVA: 0x010B2068 File Offset: 0x010B0268
		public virtual void OnClickBtnBack(Action callback)
		{
		}

		// Token: 0x06041127 RID: 266535 RVA: 0x010B206C File Offset: 0x010B026C
		protected void RestartImmediate()
		{
			List<int> list = new List<int>();
			int levelId = this.Context.GetOpenParam().LevelId;
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
			if (pinballLevelConfigById.Value.TrailRoleLength == 0)
			{
				foreach (int item in this.Context.GetOpenParam().Roles.Keys)
				{
					list.Add(item);
				}
			}
			PinballBattleSubController.RequestEnterInst(levelId, list);
		}

		// Token: 0x06041128 RID: 266536 RVA: 0x010B2148 File Offset: 0x010B0348
		protected void OpenFormationView()
		{
			int levelId = this.Context.GetOpenParam().LevelId;
			PinballFormationViewData param = new PinballFormationViewData
			{
				LevelId = levelId,
				IfReturnToPinballMainView = new bool?(true)
			};
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballFormationView, param, null);
		}

		// Token: 0x06041129 RID: 266537 RVA: 0x010B2190 File Offset: 0x010B0390
		protected void OpenMainRootView()
		{
			PinballMainRootViewOpenParam openParam = new PinballMainRootViewOpenParam
			{
				ChildView = "PinballMainView",
				IsFromInstanceDungeon = new bool?(true)
			};
			ControllerBase<PinballController>.Instance.OpenMainRootView(openParam).Forget<bool>();
		}
	}
}
