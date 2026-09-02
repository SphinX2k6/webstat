using System;
using System.Runtime.CompilerServices;

// Token: 0x0200346E RID: 13422
[NullableContext(1)]
[Nullable(0)]
public class LocationStruct
{
	// Token: 0x0601C489 RID: 115849 RVA: 0x00874A72 File Offset: 0x00872C72
	public LocationStruct(CharacterActorComponent actorComp)
	{
		this.ActorComp = actorComp;
	}

	// Token: 0x0400E38F RID: 58255
	public double DistSquared;

	// Token: 0x0400E390 RID: 58256
	public CharacterActorComponent ActorComp;
}
