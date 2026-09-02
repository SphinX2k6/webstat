using System;
using Aki.TDConfigMgr.Action;

namespace CSharpScript.Game.Module.Plot.Avg
{
	// Token: 0x02005448 RID: 21576
	public class AvgTalkerEnterActionContext
	{
		// Token: 0x17008E12 RID: 36370
		// (get) Token: 0x06036FEE RID: 225262 RVA: 0x00DF601B File Offset: 0x00DF421B
		// (set) Token: 0x06036FEF RID: 225263 RVA: 0x00DF6023 File Offset: 0x00DF4223
		public int CharacterId { get; set; }

		// Token: 0x17008E13 RID: 36371
		// (get) Token: 0x06036FF0 RID: 225264 RVA: 0x00DF602C File Offset: 0x00DF422C
		// (set) Token: 0x06036FF1 RID: 225265 RVA: 0x00DF6034 File Offset: 0x00DF4234
		public EAvgRolePosition Position { get; set; }

		// Token: 0x17008E14 RID: 36372
		// (get) Token: 0x06036FF2 RID: 225266 RVA: 0x00DF603D File Offset: 0x00DF423D
		// (set) Token: 0x06036FF3 RID: 225267 RVA: 0x00DF6045 File Offset: 0x00DF4245
		public EAvgRoleAnimationType AnimationType { get; set; }

		// Token: 0x17008E15 RID: 36373
		// (get) Token: 0x06036FF4 RID: 225268 RVA: 0x00DF604E File Offset: 0x00DF424E
		// (set) Token: 0x06036FF5 RID: 225269 RVA: 0x00DF6056 File Offset: 0x00DF4256
		public bool IsLoop { get; set; }
	}
}
