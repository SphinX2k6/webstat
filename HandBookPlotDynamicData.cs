using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.TDConfigMgr.Action;

// Token: 0x02001E5E RID: 7774
[NullableContext(2)]
[Nullable(0)]
public class HandBookPlotDynamicData
{
	// Token: 0x04006EE5 RID: 28389
	public PlotAudio? PlotAudio;

	// Token: 0x04006EE6 RID: 28390
	public string TalkOwnerName;

	// Token: 0x04006EE7 RID: 28391
	public string TalkText;

	// Token: 0x04006EE8 RID: 28392
	public ITalkOption TalkOption;

	// Token: 0x04006EE9 RID: 28393
	public int TalkItemId = -1;

	// Token: 0x04006EEA RID: 28394
	public int PlotId = -1;

	// Token: 0x04006EEB RID: 28395
	public bool? IsChoseOption = new bool?(false);

	// Token: 0x04006EEC RID: 28396
	public int? OptionIndex = new int?(0);

	// Token: 0x04006EED RID: 28397
	public bool? OptionTalker;

	// Token: 0x04006EEE RID: 28398
	public int MoveId;

	// Token: 0x04006EEF RID: 28399
	public string NodeText;

	// Token: 0x04006EF0 RID: 28400
	[Nullable(1)]
	public string BelongToNode = "";
}
