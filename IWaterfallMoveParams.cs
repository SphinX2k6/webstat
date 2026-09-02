using System;
using System.Runtime.CompilerServices;

// Token: 0x0200328D RID: 12941
[NullableContext(1)]
public interface IWaterfallMoveParams
{
	// Token: 0x170024DB RID: 9435
	// (get) Token: 0x0601B171 RID: 110961
	// (set) Token: 0x0601B172 RID: 110962
	int SplineId { get; set; }

	// Token: 0x170024DC RID: 9436
	// (get) Token: 0x0601B173 RID: 110963
	// (set) Token: 0x0601B174 RID: 110964
	Vector Direct { get; set; }

	// Token: 0x170024DD RID: 9437
	// (get) Token: 0x0601B175 RID: 110965
	// (set) Token: 0x0601B176 RID: 110966
	[Nullable(2)]
	Vector ChangeGravity { [NullableContext(2)] get; [NullableContext(2)] set; }
}
