using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D2D RID: 19757
	public class NavigationGroupNextComponent : NavigationGroupNextComponentBase
	{
		// Token: 0x06033503 RID: 210179 RVA: 0x00CD7347 File Offset: 0x00CD5547
		public NavigationGroupNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033504 RID: 210180 RVA: 0x00CD7350 File Offset: 0x00CD5550
		protected override ENavigationDirectionType GetDirection()
		{
			return ENavigationDirectionType.Right;
		}
	}
}
