using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CD7 RID: 19671
	public enum EFindNavigationResult
	{
		// Token: 0x0401DBA7 RID: 121767
		None,
		// Token: 0x0401DBA8 RID: 121768
		CanFocus,
		// Token: 0x0401DBA9 RID: 121769
		CantFocus,
		// Token: 0x0401DBAA RID: 121770
		LoopOrLayoutDataInit,
		// Token: 0x0401DBAB RID: 121771
		LoopOrLayoutAnimation,
		// Token: 0x0401DBAC RID: 121772
		WaitRegisterToPanelConfig,
		// Token: 0x0401DBAD RID: 121773
		WaitDynamicListener,
		// Token: 0x0401DBAE RID: 121774
		DynamicScrollViewNotReady,
		// Token: 0x0401DBAF RID: 121775
		MultiTemplateScrollViewNotReady
	}
}
