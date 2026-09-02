using System;
using System.Runtime.CompilerServices;

// Token: 0x02003273 RID: 12915
[NullableContext(1)]
[Nullable(0)]
public class ScenePlayerVehicleInfo : EntityVehicleInfo
{
	// Token: 0x0601AFDA RID: 110554 RVA: 0x008104B9 File Offset: 0x0080E6B9
	public new ScenePlayerVehicleInfo DeepCopy()
	{
		return new ScenePlayerVehicleInfo
		{
			PlayerId = this.PlayerId,
			EntityCreatureId = this.EntityCreatureId,
			VehicleCreatureId = this.VehicleCreatureId,
			Seat = this.Seat
		};
	}

	// Token: 0x0601AFDB RID: 110555 RVA: 0x008104F0 File Offset: 0x0080E6F0
	public override bool Equals(EntityVehicleInfo info)
	{
		ScenePlayerVehicleInfo scenePlayerVehicleInfo = info as ScenePlayerVehicleInfo;
		return scenePlayerVehicleInfo != null && this.PlayerId == scenePlayerVehicleInfo.PlayerId && base.Equals(info);
	}

	// Token: 0x0400DB38 RID: 56120
	public int PlayerId;
}
