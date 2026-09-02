using System;
using System.Runtime.CompilerServices;

// Token: 0x02003272 RID: 12914
[NullableContext(1)]
[Nullable(0)]
public class EntityVehicleInfo
{
	// Token: 0x0601AFD7 RID: 110551 RVA: 0x00810451 File Offset: 0x0080E651
	public EntityVehicleInfo DeepCopy()
	{
		return new EntityVehicleInfo
		{
			EntityCreatureId = this.EntityCreatureId,
			VehicleCreatureId = this.VehicleCreatureId,
			Seat = this.Seat
		};
	}

	// Token: 0x0601AFD8 RID: 110552 RVA: 0x0081047C File Offset: 0x0080E67C
	public virtual bool Equals(EntityVehicleInfo info)
	{
		return this.EntityCreatureId == info.EntityCreatureId && this.VehicleCreatureId == info.VehicleCreatureId && this.Seat == info.Seat;
	}

	// Token: 0x0400DB34 RID: 56116
	public long EntityCreatureId;

	// Token: 0x0400DB35 RID: 56117
	public long VehicleCreatureId;

	// Token: 0x0400DB36 RID: 56118
	public int Seat = -1;

	// Token: 0x0400DB37 RID: 56119
	public ELeaveVehicleType ExitType;
}
