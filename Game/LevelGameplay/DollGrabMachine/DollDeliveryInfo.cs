using System;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EC4 RID: 28356
	public class DollDeliveryInfo
	{
		// Token: 0x06044BAF RID: 281519 RVA: 0x011DE1CC File Offset: 0x011DC3CC
		public DollDeliveryInfo(int itemId, int lightIndex, bool isComplete, bool isLast)
		{
			this.ItemId = itemId;
			this.LightIndex = lightIndex;
			this.IsComplete = isComplete;
			this.IsLast = isLast;
		}

		// Token: 0x04026469 RID: 156777
		public int ItemId;

		// Token: 0x0402646A RID: 156778
		public int LightIndex;

		// Token: 0x0402646B RID: 156779
		public bool IsComplete;

		// Token: 0x0402646C RID: 156780
		public bool IsLast;
	}
}
