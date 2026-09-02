using System;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006452 RID: 25682
	public class RoverlikeRogueLevelLineData : IRoverlikeRogueLevelLineData
	{
		// Token: 0x17009E1C RID: 40476
		// (get) Token: 0x06040741 RID: 264001 RVA: 0x01085366 File Offset: 0x01083566
		// (set) Token: 0x06040742 RID: 264002 RVA: 0x0108536E File Offset: 0x0108356E
		public ERoverlikeRoadLayerType LayerType { get; set; } = ERoverlikeRoadLayerType.Normal;

		// Token: 0x17009E1D RID: 40477
		// (get) Token: 0x06040743 RID: 264003 RVA: 0x01085377 File Offset: 0x01083577
		// (set) Token: 0x06040744 RID: 264004 RVA: 0x0108537F File Offset: 0x0108357F
		public bool IsCurrent { get; set; }

		// Token: 0x17009E1E RID: 40478
		// (get) Token: 0x06040745 RID: 264005 RVA: 0x01085388 File Offset: 0x01083588
		// (set) Token: 0x06040746 RID: 264006 RVA: 0x01085390 File Offset: 0x01083590
		public bool IsPassed { get; set; }

		// Token: 0x17009E1F RID: 40479
		// (get) Token: 0x06040747 RID: 264007 RVA: 0x01085399 File Offset: 0x01083599
		// (set) Token: 0x06040748 RID: 264008 RVA: 0x010853A1 File Offset: 0x010835A1
		public bool ShowCurrent { get; set; }
	}
}
