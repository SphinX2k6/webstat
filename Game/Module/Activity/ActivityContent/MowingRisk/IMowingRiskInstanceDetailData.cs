using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk
{
	// Token: 0x02006686 RID: 26246
	[NullableContext(1)]
	public interface IMowingRiskInstanceDetailData
	{
		// Token: 0x17009FE9 RID: 40937
		// (get) Token: 0x060418E6 RID: 268518
		// (set) Token: 0x060418E7 RID: 268519
		string TitleTextId { get; set; }

		// Token: 0x17009FEA RID: 40938
		// (get) Token: 0x060418E8 RID: 268520
		// (set) Token: 0x060418E9 RID: 268521
		string ContentTextId { get; set; }

		// Token: 0x17009FEB RID: 40939
		// (get) Token: 0x060418EA RID: 268522
		// (set) Token: 0x060418EB RID: 268523
		IMowingRiskInstanceDetailAttributeItemData[] AttributeList { get; set; }

		// Token: 0x17009FEC RID: 40940
		// (get) Token: 0x060418EC RID: 268524
		// (set) Token: 0x060418ED RID: 268525
		IMowingRiskInstanceDetailLockItemData LockData { get; set; }
	}
}
