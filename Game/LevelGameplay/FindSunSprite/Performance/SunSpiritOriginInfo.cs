using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.FindSunSprite.Performance
{
	// Token: 0x02006EB4 RID: 28340
	[NullableContext(1)]
	[Nullable(0)]
	public class SunSpiritOriginInfo : ISunSpiritOriginInfo
	{
		// Token: 0x1700A3D6 RID: 41942
		// (get) Token: 0x06044B4B RID: 281419 RVA: 0x011DC7D5 File Offset: 0x011DA9D5
		// (set) Token: 0x06044B4C RID: 281420 RVA: 0x011DC7DD File Offset: 0x011DA9DD
		public EntityHandle EntityHandle { get; set; }

		// Token: 0x1700A3D7 RID: 41943
		// (get) Token: 0x06044B4D RID: 281421 RVA: 0x011DC7E6 File Offset: 0x011DA9E6
		// (set) Token: 0x06044B4E RID: 281422 RVA: 0x011DC7EE File Offset: 0x011DA9EE
		public Transform Transform { get; set; }

		// Token: 0x1700A3D8 RID: 41944
		// (get) Token: 0x06044B4F RID: 281423 RVA: 0x011DC7F7 File Offset: 0x011DA9F7
		// (set) Token: 0x06044B50 RID: 281424 RVA: 0x011DC7FF File Offset: 0x011DA9FF
		public int DisableMoveHandle { get; set; }

		// Token: 0x1700A3D9 RID: 41945
		// (get) Token: 0x06044B51 RID: 281425 RVA: 0x011DC808 File Offset: 0x011DAA08
		// (set) Token: 0x06044B52 RID: 281426 RVA: 0x011DC810 File Offset: 0x011DAA10
		public int DisableMoveTickHandle { get; set; }
	}
}
