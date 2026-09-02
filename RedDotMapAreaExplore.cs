using System;

// Token: 0x0200335B RID: 13147
public class RedDotMapAreaExplore : RedDotBase
{
	// Token: 0x0601B712 RID: 112402 RVA: 0x00837D45 File Offset: 0x00835F45
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionMap);
	}
}
