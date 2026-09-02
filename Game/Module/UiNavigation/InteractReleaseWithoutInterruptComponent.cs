using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D12 RID: 19730
	public class InteractReleaseWithoutInterruptComponent : InteractReleaseComponent
	{
		// Token: 0x06033495 RID: 210069 RVA: 0x00CD6358 File Offset: 0x00CD4558
		public InteractReleaseWithoutInterruptComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033496 RID: 210070 RVA: 0x00CD6361 File Offset: 0x00CD4561
		[NullableContext(1)]
		protected override void HandleLogicAfterRefresh(UiNavigationViewHandle viewHandle)
		{
		}
	}
}
