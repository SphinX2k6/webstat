using System;
using System.Collections.Generic;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Battle;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02006097 RID: 24727
	public class BaseScoreItem : BattleChildView
	{
		// Token: 0x0603E687 RID: 255623 RVA: 0x00FF1158 File Offset: 0x00FEF358
		protected override void OnStart()
		{
			foreach (KeyValuePair<int, bool> keyValuePair in ModelBase<BattleScoreModel>.Instance.GetScoreEnableMap())
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int scoreId = num;
				if (flag && this.IsValidScore(scoreId))
				{
					this.IsScoreEnable = true;
					break;
				}
			}
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.BattleScoreChanged, new Action<int, int>(this.BattleScoreChanged));
			Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.BattleScoreEnableChanged, new Action<int, bool>(this.BattleScoreEnableChanged));
		}

		// Token: 0x0603E688 RID: 255624 RVA: 0x00FF1200 File Offset: 0x00FEF400
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleScoreChanged, new Action<int, int>(this.BattleScoreChanged));
			Singleton<EventSystem>.Instance.Remove(EEventName.BattleScoreEnableChanged, new Action<int, bool>(this.BattleScoreEnableChanged));
		}

		// Token: 0x0603E689 RID: 255625 RVA: 0x00FF123A File Offset: 0x00FEF43A
		public virtual void OnShowFirstTime()
		{
			if (this.IsScoreEnable)
			{
				this.ShowScore();
			}
		}

		// Token: 0x0603E68A RID: 255626 RVA: 0x00FF124A File Offset: 0x00FEF44A
		public virtual void OnTick(float delta)
		{
		}

		// Token: 0x0603E68B RID: 255627 RVA: 0x00FF124C File Offset: 0x00FEF44C
		public virtual bool IsValidScore(int scoreId)
		{
			return false;
		}

		// Token: 0x0603E68C RID: 255628 RVA: 0x00FF124F File Offset: 0x00FEF44F
		private void BattleScoreChanged(int scoreId, int score)
		{
			if (!this.IsValidScore(scoreId))
			{
				return;
			}
			this.OnBattleScoreChanged(scoreId, score);
		}

		// Token: 0x0603E68D RID: 255629 RVA: 0x00FF1263 File Offset: 0x00FEF463
		private void BattleScoreEnableChanged(int scoreId, bool enable)
		{
			if (!this.IsValidScore(scoreId))
			{
				return;
			}
			this.OnBattleScoreEnableChanged(scoreId, enable);
		}

		// Token: 0x0603E68E RID: 255630 RVA: 0x00FF1277 File Offset: 0x00FEF477
		protected virtual void OnBattleScoreChanged(int scoreId, int score)
		{
		}

		// Token: 0x0603E68F RID: 255631 RVA: 0x00FF1279 File Offset: 0x00FEF479
		protected virtual void OnBattleScoreEnableChanged(int scoreId, bool enable)
		{
			if (this.IsScoreEnable == enable)
			{
				return;
			}
			this.IsScoreEnable = enable;
			if (enable)
			{
				this.ShowScore();
				return;
			}
			this.HideScore();
		}

		// Token: 0x0603E690 RID: 255632 RVA: 0x00FF129C File Offset: 0x00FEF49C
		public virtual void ShowScore()
		{
			this.IsScoreEnable = true;
		}

		// Token: 0x0603E691 RID: 255633 RVA: 0x00FF12A5 File Offset: 0x00FEF4A5
		public virtual void HideScore()
		{
			this.IsScoreEnable = false;
		}

		// Token: 0x04022F96 RID: 143254
		public bool IsScoreEnable;
	}
}
