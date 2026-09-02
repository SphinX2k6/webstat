using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002332 RID: 9010
[NullableContext(1)]
public interface IOnlinePlayerData : IPlayerData
{
	// Token: 0x1700153C RID: 5436
	// (get) Token: 0x06011282 RID: 70274
	int HeadId { get; }

	// Token: 0x1700153D RID: 5437
	// (get) Token: 0x06011283 RID: 70275
	int Level { get; }

	// Token: 0x1700153E RID: 5438
	// (get) Token: 0x06011284 RID: 70276
	string Name { get; }

	// Token: 0x1700153F RID: 5439
	// (get) Token: 0x06011285 RID: 70277
	int PlayerTitleId { get; }

	// Token: 0x17001540 RID: 5440
	// (get) Token: 0x06011286 RID: 70278
	int PlayerTitleStarLevel { get; }

	// Token: 0x17001541 RID: 5441
	// (get) Token: 0x06011287 RID: 70279
	int Sex { get; }

	// Token: 0x17001542 RID: 5442
	// (get) Token: 0x06011288 RID: 70280
	PlayerDetails PlayerDetails { get; }

	// Token: 0x17001543 RID: 5443
	// (get) Token: 0x06011289 RID: 70281
	int CurUsingCardId { get; }

	// Token: 0x17001544 RID: 5444
	// (get) Token: 0x0601128A RID: 70282
	List<PersonalCardData> CardUnlockList { get; }

	// Token: 0x0601128B RID: 70283
	bool GetIfCanShowInHallList([Nullable(new byte[]
	{
		2,
		1
	})] Dictionary<string, bool> blockMap = null);

	// Token: 0x17001545 RID: 5445
	// (get) Token: 0x0601128C RID: 70284
	string ThirdPartyUserId { get; }
}
