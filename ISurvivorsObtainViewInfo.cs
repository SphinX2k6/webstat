using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002AE2 RID: 10978
[NullableContext(1)]
public interface ISurvivorsObtainViewInfo
{
	// Token: 0x17001C74 RID: 7284
	// (get) Token: 0x06015F4E RID: 89934
	string CaptionId { get; }

	// Token: 0x17001C75 RID: 7285
	// (get) Token: 0x06015F4F RID: 89935
	string TitleId { get; }

	// Token: 0x17001C76 RID: 7286
	// (get) Token: 0x06015F50 RID: 89936
	string ButtonId { get; }

	// Token: 0x17001C77 RID: 7287
	// (get) Token: 0x06015F51 RID: 89937
	ISurvivorsChooseData ChooseData { get; }

	// Token: 0x17001C78 RID: 7288
	// (get) Token: 0x06015F52 RID: 89938
	IList<GoodsDetail> GoodsList { get; }
}
