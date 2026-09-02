using System;

namespace CSharpScript.Game.Module.Kurotato
{
	// Token: 0x02005A67 RID: 23143
	public class KurotatoSaveData : IKurotatoSaveData
	{
		// Token: 0x17009583 RID: 38275
		// (get) Token: 0x0603A8CD RID: 239821 RVA: 0x00ED3267 File Offset: 0x00ED1467
		// (set) Token: 0x0603A8CE RID: 239822 RVA: 0x00ED326F File Offset: 0x00ED146F
		public long SaveTimestamp { get; set; }

		// Token: 0x17009584 RID: 38276
		// (get) Token: 0x0603A8CF RID: 239823 RVA: 0x00ED3278 File Offset: 0x00ED1478
		// (set) Token: 0x0603A8D0 RID: 239824 RVA: 0x00ED3280 File Offset: 0x00ED1480
		public int RoleLevel { get; set; }

		// Token: 0x17009585 RID: 38277
		// (get) Token: 0x0603A8D1 RID: 239825 RVA: 0x00ED3289 File Offset: 0x00ED1489
		// (set) Token: 0x0603A8D2 RID: 239826 RVA: 0x00ED3291 File Offset: 0x00ED1491
		public int WaveNum { get; set; }
	}
}
