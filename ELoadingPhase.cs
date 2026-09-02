using System;

// Token: 0x0200348F RID: 13455
public enum ELoadingPhase
{
	// Token: 0x0400E45C RID: 58460
	None,
	// Token: 0x0400E45D RID: 58461
	Finished,
	// Token: 0x0400E45E RID: 58462
	Start,
	// Token: 0x0400E45F RID: 58463
	OpenLoadingStart,
	// Token: 0x0400E460 RID: 58464
	OpenLoadingEnd,
	// Token: 0x0400E461 RID: 58465
	OpenLevelStart,
	// Token: 0x0400E462 RID: 58466
	OpenLevelEnd,
	// Token: 0x0400E463 RID: 58467
	PreloadStart,
	// Token: 0x0400E464 RID: 58468
	PreloadEnd,
	// Token: 0x0400E465 RID: 58469
	SetDataLayerAndLoadSubLevelStart,
	// Token: 0x0400E466 RID: 58470
	SetDataLayerAndLoadSubLevelEnd,
	// Token: 0x0400E467 RID: 58471
	CheckVoxelStreamingStart,
	// Token: 0x0400E468 RID: 58472
	CheckVoxelStreamingEnd,
	// Token: 0x0400E469 RID: 58473
	CheckStreamingStart,
	// Token: 0x0400E46A RID: 58474
	CheckStreamingEnd,
	// Token: 0x0400E46B RID: 58475
	CreateEntityStart,
	// Token: 0x0400E46C RID: 58476
	CreateEntityEnd,
	// Token: 0x0400E46D RID: 58477
	WorldDoneStart,
	// Token: 0x0400E46E RID: 58478
	WorldDoneEnd,
	// Token: 0x0400E46F RID: 58479
	CloseLoadingStart,
	// Token: 0x0400E470 RID: 58480
	CloseLoadingEnd
}
