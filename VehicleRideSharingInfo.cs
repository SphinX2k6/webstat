using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02003274 RID: 12916
public class VehicleRideSharingInfo
{
	// Token: 0x0601AFDD RID: 110557 RVA: 0x00810528 File Offset: 0x0080E728
	[NullableContext(1)]
	public VehicleRideSharingInfo(VehiclePassengerUpdateNotify data)
	{
		this.PlayerId = data.PlayerId;
		this.RoleId = data.RoleId;
		this.RoleCreatureId = data.EntityId;
		this.Seat = data.SeatId;
	}

	// Token: 0x0400DB39 RID: 56121
	public int PlayerId;

	// Token: 0x0400DB3A RID: 56122
	public int RoleId;

	// Token: 0x0400DB3B RID: 56123
	public long RoleCreatureId;

	// Token: 0x0400DB3C RID: 56124
	public int Seat = -1;
}
