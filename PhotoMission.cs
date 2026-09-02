using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.GeneralLogicTree.BehaviorNode.ChildQuestNode;

// Token: 0x020025A4 RID: 9636
[NullableContext(1)]
[Nullable(0)]
public class PhotoMission
{
	// Token: 0x06012C9B RID: 76955 RVA: 0x0052EC1C File Offset: 0x0052CE1C
	public PhotoMission([Nullable(2)] EntityPhotoBehaviorNode node, EEntityMissionType? type, bool bFinished, int? entityId, string desc, bool bOptional)
	{
		this.Node = node;
		this.ItsMissionType = type;
		this.IsFinished = bFinished;
		this.EntityId = entityId;
		this.Description = desc;
		this.IsOptional = bOptional;
		if (this.IsOptional)
		{
			this.IsOptionalFinished = new bool?(false);
		}
	}

	// Token: 0x040092A5 RID: 37541
	[Nullable(2)]
	public EntityPhotoBehaviorNode Node;

	// Token: 0x040092A6 RID: 37542
	public EEntityMissionType? ItsMissionType;

	// Token: 0x040092A7 RID: 37543
	public bool IsFinished;

	// Token: 0x040092A8 RID: 37544
	public int? EntityId;

	// Token: 0x040092A9 RID: 37545
	public string Description = "";

	// Token: 0x040092AA RID: 37546
	public bool IsOptional;

	// Token: 0x040092AB RID: 37547
	public bool? IsOptionalFinished;
}
