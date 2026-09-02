using System;

// Token: 0x020031AD RID: 12717
public class NpcSeatInfo
{
	// Token: 0x0601A5F0 RID: 108016 RVA: 0x007C5D53 File Offset: 0x007C3F53
	public NpcSeatInfo(int npcEntityId, int seat)
	{
		this.NpcEntityId = npcEntityId;
		this.Seat = seat;
	}

	// Token: 0x0400D4CA RID: 54474
	public readonly int NpcEntityId;

	// Token: 0x0400D4CB RID: 54475
	public readonly int Seat = -1;

	// Token: 0x0400D4CC RID: 54476
	public ENpcVehicleRideState RideState = ENpcVehicleRideState.MoveToVehicle;

	// Token: 0x0400D4CD RID: 54477
	public int? TargetSplinePbDataId;
}
