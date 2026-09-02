using System;
using System.Runtime.CompilerServices;

// Token: 0x020029A8 RID: 10664
public class ShipTowerBuffViewParams
{
	// Token: 0x0400A3F4 RID: 41972
	public int? BuffId;

	// Token: 0x0400A3F5 RID: 41973
	public int? StageId;

	// Token: 0x0400A3F6 RID: 41974
	public EShipTowerBuffOperationType? OperationType;

	// Token: 0x0400A3F7 RID: 41975
	[Nullable(2)]
	public ShipTowerTeamData TeamData;

	// Token: 0x0400A3F8 RID: 41976
	[Nullable(new byte[]
	{
		2,
		1,
		2
	})]
	public Action<ShipTowerBuffData, ShipTowerTeamData> OnUseBuff;
}
