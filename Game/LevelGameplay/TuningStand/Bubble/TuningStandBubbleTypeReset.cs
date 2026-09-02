using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A92 RID: 27282
	public class TuningStandBubbleTypeReset : TuningStandBubbleTypeBase
	{
		// Token: 0x06043770 RID: 276336 RVA: 0x01161984 File Offset: 0x0115FB84
		public override bool TryStartBubble(bool canPlay)
		{
			if (!canPlay)
			{
				this.HasPlayedOnce = true;
				return false;
			}
			if (this.PlayFlow == null || this.HasPlayedOnce)
			{
				return false;
			}
			this.HasPlayedOnce = true;
			this.CurIndex = 0;
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025AE1 RID: 154337
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.Reset;

		// Token: 0x04025AE2 RID: 154338
		protected bool HasPlayedOnce;
	}
}
