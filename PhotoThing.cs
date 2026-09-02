using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

// Token: 0x020025A5 RID: 9637
[NullableContext(2)]
[Nullable(0)]
public class PhotoThing
{
	// Token: 0x06012C9C RID: 76956 RVA: 0x0052EC7B File Offset: 0x0052CE7B
	public PhotoThing(EntityPhotoBehaviorNode behaviorNode, [Nullable(new byte[]
	{
		2,
		1
	})] List<PhotoMission> missions, EMissionGetType? type)
	{
		this.BehaviorNode = behaviorNode;
		this.PhotoMissions = missions;
		this.Type = type;
	}

	// Token: 0x040092AC RID: 37548
	public EntityPhotoBehaviorNode BehaviorNode;

	// Token: 0x040092AD RID: 37549
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<PhotoMission> PhotoMissions;

	// Token: 0x040092AE RID: 37550
	public EMissionGetType? Type;
}
