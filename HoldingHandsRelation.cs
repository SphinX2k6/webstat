using System;
using System.Runtime.CompilerServices;

// Token: 0x02001EC9 RID: 7881
[NullableContext(2)]
[Nullable(0)]
public class HoldingHandsRelation : NpcRelation
{
	// Token: 0x170011D8 RID: 4568
	// (get) Token: 0x0600E8FF RID: 59647 RVA: 0x003F153B File Offset: 0x003EF73B
	public override ENpcRelationType RelationType
	{
		get
		{
			return ENpcRelationType.HoldingHands;
		}
	}

	// Token: 0x0600E900 RID: 59648 RVA: 0x003F153E File Offset: 0x003EF73E
	public bool IsValid()
	{
		return this.Leader != null && this.Leader.Valid && this.Follower != null && this.Follower.Valid;
	}

	// Token: 0x04007041 RID: 28737
	public string Key;

	// Token: 0x04007042 RID: 28738
	public CharacterHoldingHandsComponent Leader;

	// Token: 0x04007043 RID: 28739
	public EHandType LeaderHandType = EHandType.Right;

	// Token: 0x04007044 RID: 28740
	public CharacterHoldingHandsComponent Follower;

	// Token: 0x04007045 RID: 28741
	public EHandType FollowerHandType;
}
