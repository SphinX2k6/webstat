using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A8E RID: 27278
	public class TuningStandBubbleTypeInValidLink : TuningStandBubbleTypeBase
	{
		// Token: 0x06043768 RID: 276328 RVA: 0x0116188C File Offset: 0x0115FA8C
		public override bool TryStartBubble(bool canPlay)
		{
			if (this.PlayFlow == null)
			{
				return false;
			}
			if (Singleton<Time>.Instance.Now - 20.0 < this.PrevPlayTime)
			{
				return false;
			}
			this.PrevPlayTime = Singleton<Time>.Instance.Now;
			this.CurIndex = 0;
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025ADB RID: 154331
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.InvalidLink;

		// Token: 0x04025ADC RID: 154332
		private double PrevPlayTime;
	}
}
