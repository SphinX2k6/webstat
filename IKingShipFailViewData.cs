using System;
using System.Runtime.CompilerServices;

// Token: 0x02002098 RID: 8344
[NullableContext(1)]
public interface IKingShipFailViewData
{
	// Token: 0x170012F1 RID: 4849
	// (get) Token: 0x0600FEAE RID: 65198
	// (set) Token: 0x0600FEAF RID: 65199
	int CardId { get; set; }

	// Token: 0x170012F2 RID: 4850
	// (get) Token: 0x0600FEB0 RID: 65200
	// (set) Token: 0x0600FEB1 RID: 65201
	Action OnCloseCallBack { get; set; }
}
