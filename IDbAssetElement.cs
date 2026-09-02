using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020032B0 RID: 12976
[NullableContext(1)]
public interface IDbAssetElement
{
	// Token: 0x17002506 RID: 9478
	// (get) Token: 0x0601B31E RID: 111390
	// (set) Token: 0x0601B31F RID: 111391
	List<string> ActorClass { get; set; }

	// Token: 0x17002507 RID: 9479
	// (get) Token: 0x0601B320 RID: 111392
	// (set) Token: 0x0601B321 RID: 111393
	List<string> Animations { get; set; }

	// Token: 0x17002508 RID: 9480
	// (get) Token: 0x0601B322 RID: 111394
	// (set) Token: 0x0601B323 RID: 111395
	List<string> Effects { get; set; }

	// Token: 0x17002509 RID: 9481
	// (get) Token: 0x0601B324 RID: 111396
	// (set) Token: 0x0601B325 RID: 111397
	List<string> Audios { get; set; }

	// Token: 0x1700250A RID: 9482
	// (get) Token: 0x0601B326 RID: 111398
	// (set) Token: 0x0601B327 RID: 111399
	List<string> Meshes { get; set; }

	// Token: 0x1700250B RID: 9483
	// (get) Token: 0x0601B328 RID: 111400
	// (set) Token: 0x0601B329 RID: 111401
	List<string> Materials { get; set; }

	// Token: 0x1700250C RID: 9484
	// (get) Token: 0x0601B32A RID: 111402
	// (set) Token: 0x0601B32B RID: 111403
	List<string> AnimationBlueprints { get; set; }

	// Token: 0x1700250D RID: 9485
	// (get) Token: 0x0601B32C RID: 111404
	// (set) Token: 0x0601B32D RID: 111405
	List<string> Others { get; set; }
}
