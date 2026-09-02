using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D33 RID: 19763
	public class NavigationGroupRightPrevComponent : NavigationGroupPrevComponentBase
	{
		// Token: 0x06033515 RID: 210197 RVA: 0x00CD7455 File Offset: 0x00CD5655
		public NavigationGroupRightPrevComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033516 RID: 210198 RVA: 0x00CD745E File Offset: 0x00CD565E
		protected override ENavigationDirectionType GetDirection()
		{
			return ENavigationDirectionType.Right;
		}
	}
}
