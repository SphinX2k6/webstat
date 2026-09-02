using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.LevelGamePlay.TuningStand.Bubble
{
	// Token: 0x02006A90 RID: 27280
	public class TuningStandBubbleTypeLinkMiss : TuningStandBubbleTypeBase
	{
		// Token: 0x0604376C RID: 276332 RVA: 0x01161932 File Offset: 0x0115FB32
		public override bool TryStartBubble(bool canPlay)
		{
			if (this.PlayFlow == null)
			{
				return false;
			}
			this.CurIndex = 0;
			base.UpdateBubble();
			return true;
		}

		// Token: 0x04025ADF RID: 154335
		protected new ETuningStandBubbleTriggerType BubbleType = ETuningStandBubbleTriggerType.LinkMiss;
	}
}
