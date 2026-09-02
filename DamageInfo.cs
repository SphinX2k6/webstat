using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001AB0 RID: 6832
[NullableContext(1)]
[Nullable(0)]
public class DamageInfo
{
	// Token: 0x04005DDA RID: 24026
	public float Damage;

	// Token: 0x04005DDB RID: 24027
	public int ElementId;

	// Token: 0x04005DDC RID: 24028
	public FVectorDouble? DamagePosition;

	// Token: 0x04005DDD RID: 24029
	public Vector BaseLocation = Vector.Create(0.0, 0.0, 0.0);

	// Token: 0x04005DDE RID: 24030
	public bool IsOwnPlayer;

	// Token: 0x04005DDF RID: 24031
	public bool IsCritical;

	// Token: 0x04005DE0 RID: 24032
	public bool IsCure;

	// Token: 0x04005DE1 RID: 24033
	public int DamageTextId;

	// Token: 0x04005DE2 RID: 24034
	public string DamageText = "";

	// Token: 0x04005DE3 RID: 24035
	public int DamageTextAreaId;

	// Token: 0x04005DE4 RID: 24036
	public int EntityId;

	// Token: 0x04005DE5 RID: 24037
	public bool EnableOptimization;

	// Token: 0x04005DE6 RID: 24038
	public bool Valid;
}
