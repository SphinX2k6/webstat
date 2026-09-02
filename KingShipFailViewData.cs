using System;
using System.Runtime.CompilerServices;

// Token: 0x02002099 RID: 8345
[NullableContext(1)]
[Nullable(0)]
public class KingShipFailViewData : IKingShipFailViewData
{
	// Token: 0x170012F3 RID: 4851
	// (get) Token: 0x0600FEB2 RID: 65202 RVA: 0x0045E5FC File Offset: 0x0045C7FC
	// (set) Token: 0x0600FEB3 RID: 65203 RVA: 0x0045E604 File Offset: 0x0045C804
	public int CardId { get; set; }

	// Token: 0x170012F4 RID: 4852
	// (get) Token: 0x0600FEB4 RID: 65204 RVA: 0x0045E60D File Offset: 0x0045C80D
	// (set) Token: 0x0600FEB5 RID: 65205 RVA: 0x0045E615 File Offset: 0x0045C815
	public Action OnCloseCallBack { get; set; }
}
