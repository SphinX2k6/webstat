using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02001744 RID: 5956
public class AdventureGuideViewOpenData
{
	// Token: 0x04004F0E RID: 20238
	public EUiTabViewName? OpenTabViewName;

	// Token: 0x04004F0F RID: 20239
	public int? OpenParam;

	// Token: 0x04004F10 RID: 20240
	[Nullable(1)]
	public int[] NewSoundDetectTracingIdList = new int[0];

	// Token: 0x04004F11 RID: 20241
	public bool SkipAdventureManualRequest;
}
