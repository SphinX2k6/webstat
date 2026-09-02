using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x0200233A RID: 9018
[NullableContext(2)]
[Nullable(0)]
public class OtherScenePlayerData
{
	// Token: 0x06011336 RID: 70454 RVA: 0x004B8DEE File Offset: 0x004B6FEE
	public OtherScenePlayerData(int playerId, int mapId, Aki.Protocol.Vector location, int areaId)
	{
		this.PlayerId = playerId;
		this.MapId = mapId;
		this.Location = global::Vector.Create(location);
		this.Area = areaId;
	}

	// Token: 0x06011337 RID: 70455 RVA: 0x004B8E18 File Offset: 0x004B7018
	public void SetLocation(global::Vector location)
	{
		global::Vector location2 = this.Location;
		if (location2 == null)
		{
			return;
		}
		location2.Set((location != null) ? location.X : 0.0, (location != null) ? location.Y : 0.0, (location != null) ? location.Z : 0.0);
	}

	// Token: 0x04008737 RID: 34615
	public int PlayerId;

	// Token: 0x04008738 RID: 34616
	public int MapId;

	// Token: 0x04008739 RID: 34617
	public int Area;

	// Token: 0x0400873A RID: 34618
	public global::Vector Location;
}
