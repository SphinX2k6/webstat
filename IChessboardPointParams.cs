using System;
using System.Runtime.CompilerServices;

// Token: 0x02001288 RID: 4744
[NullableContext(1)]
public interface IChessboardPointParams
{
	// Token: 0x17000AB8 RID: 2744
	// (get) Token: 0x06007F04 RID: 32516
	// (set) Token: 0x06007F05 RID: 32517
	int Id { get; set; }

	// Token: 0x17000AB9 RID: 2745
	// (get) Token: 0x06007F06 RID: 32518
	// (set) Token: 0x06007F07 RID: 32519
	Vector Location { get; set; }

	// Token: 0x17000ABA RID: 2746
	// (get) Token: 0x06007F08 RID: 32520
	// (set) Token: 0x06007F09 RID: 32521
	Rotator Rotation { get; set; }

	// Token: 0x17000ABB RID: 2747
	// (get) Token: 0x06007F0A RID: 32522
	// (set) Token: 0x06007F0B RID: 32523
	[Nullable(2)]
	Rotator BackwardRotation { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17000ABC RID: 2748
	// (get) Token: 0x06007F0C RID: 32524
	// (set) Token: 0x06007F0D RID: 32525
	int SortIndex { get; set; }
}
