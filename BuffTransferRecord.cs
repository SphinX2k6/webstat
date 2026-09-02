using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002F17 RID: 12055
[NullableContext(1)]
[Nullable(0)]
public class BuffTransferRecord
{
	// Token: 0x0400C042 RID: 49218
	public long BulletMessageId;

	// Token: 0x0400C043 RID: 49219
	public long RecordSkillMessageId;

	// Token: 0x0400C044 RID: 49220
	public long TargetSkillMessageId;

	// Token: 0x0400C045 RID: 49221
	public HashSet<int> TransferEntity = new HashSet<int>();

	// Token: 0x0400C046 RID: 49222
	public int[] BuffStack = Array.Empty<int>();

	// Token: 0x0400C047 RID: 49223
	public bool IsAbnormalDamage;

	// Token: 0x0400C048 RID: 49224
	public int VictimEntityId;
}
