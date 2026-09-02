using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D30 RID: 19760
	public class NavigationGroupLeftNextComponent : NavigationGroupNextComponentBase
	{
		// Token: 0x06033509 RID: 210185 RVA: 0x00CD736B File Offset: 0x00CD556B
		public NavigationGroupLeftNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x0603350A RID: 210186 RVA: 0x00CD7374 File Offset: 0x00CD5574
		protected override ENavigationDirectionType GetDirection()
		{
			return ENavigationDirectionType.Left;
		}
	}
}
