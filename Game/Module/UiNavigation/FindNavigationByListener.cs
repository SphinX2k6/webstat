using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C8C RID: 19596
	public class FindNavigationByListener : FindActionBase
	{
		// Token: 0x06033146 RID: 209222 RVA: 0x00CCB20C File Offset: 0x00CC940C
		[NullableContext(1)]
		public override void FindNavigation(FindNavigationResult result)
		{
			TsUiNavigationBehaviorListener listener = this.Params[0] as TsUiNavigationBehaviorListener;
			this.PanelConfig.CommonFindNavigationByListener(result, listener, true);
		}
	}
}
