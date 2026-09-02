using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D2E RID: 19758
	public class NavigationGroupUpNextComponent : NavigationGroupNextComponentBase
	{
		// Token: 0x06033505 RID: 210181 RVA: 0x00CD7353 File Offset: 0x00CD5553
		public NavigationGroupUpNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033506 RID: 210182 RVA: 0x00CD735C File Offset: 0x00CD555C
		protected override ENavigationDirectionType GetDirection()
		{
			return ENavigationDirectionType.Up;
		}
	}
}
