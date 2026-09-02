using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common;

// Token: 0x02001A74 RID: 6772
public class CommonTipsData : CommonTipsBaseData
{
	// Token: 0x04005ABF RID: 23231
	public int CurrentStar;

	// Token: 0x04005AC0 RID: 23232
	public int MaxStar;

	// Token: 0x04005AC1 RID: 23233
	[Nullable(1)]
	public List<CSharpScript.Game.Module.Common.AttributeData> AttributeList = new List<CSharpScript.Game.Module.Common.AttributeData>();
}
