using System;

namespace CSharpScript.Game.Module.AdventureGuide
{
	// Token: 0x0200618E RID: 24974
	public interface IDetectingObj
	{
		// Token: 0x17009B0A RID: 39690
		// (get) Token: 0x0603F193 RID: 258451
		// (set) Token: 0x0603F194 RID: 258452
		int Id { get; set; }

		// Token: 0x17009B0B RID: 39691
		// (get) Token: 0x0603F195 RID: 258453
		// (set) Token: 0x0603F196 RID: 258454
		long RefreshTime { get; set; }

		// Token: 0x17009B0C RID: 39692
		// (get) Token: 0x0603F197 RID: 258455
		// (set) Token: 0x0603F198 RID: 258456
		int MapId { get; set; }

		// Token: 0x17009B0D RID: 39693
		// (get) Token: 0x0603F199 RID: 258457
		// (set) Token: 0x0603F19A RID: 258458
		float PositionX { get; set; }

		// Token: 0x17009B0E RID: 39694
		// (get) Token: 0x0603F19B RID: 258459
		// (set) Token: 0x0603F19C RID: 258460
		float PositionY { get; set; }

		// Token: 0x17009B0F RID: 39695
		// (get) Token: 0x0603F19D RID: 258461
		// (set) Token: 0x0603F19E RID: 258462
		float PositionZ { get; set; }
	}
}
