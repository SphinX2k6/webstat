using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006687 RID: 26247
	[NullableContext(1)]
	[Nullable(0)]
	public class MowingRiskInstanceDetailData : IMowingRiskInstanceDetailData
	{
		// Token: 0x17009FED RID: 40941
		// (get) Token: 0x060418EE RID: 268526 RVA: 0x010D0E81 File Offset: 0x010CF081
		// (set) Token: 0x060418EF RID: 268527 RVA: 0x010D0E89 File Offset: 0x010CF089
		public string TitleTextId { get; set; }

		// Token: 0x17009FEE RID: 40942
		// (get) Token: 0x060418F0 RID: 268528 RVA: 0x010D0E92 File Offset: 0x010CF092
		// (set) Token: 0x060418F1 RID: 268529 RVA: 0x010D0E9A File Offset: 0x010CF09A
		public string ContentTextId { get; set; }

		// Token: 0x17009FEF RID: 40943
		// (get) Token: 0x060418F2 RID: 268530 RVA: 0x010D0EA3 File Offset: 0x010CF0A3
		// (set) Token: 0x060418F3 RID: 268531 RVA: 0x010D0EAB File Offset: 0x010CF0AB
		public IMowingRiskInstanceDetailAttributeItemData[] AttributeList { get; set; }

		// Token: 0x17009FF0 RID: 40944
		// (get) Token: 0x060418F4 RID: 268532 RVA: 0x010D0EB4 File Offset: 0x010CF0B4
		// (set) Token: 0x060418F5 RID: 268533 RVA: 0x010D0EBC File Offset: 0x010CF0BC
		public IMowingRiskInstanceDetailLockItemData LockData { get; set; }
	}
}
