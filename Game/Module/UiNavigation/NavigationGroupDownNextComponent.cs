using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D2F RID: 19759
	public class NavigationGroupDownNextComponent : NavigationGroupNextComponentBase
	{
		// Token: 0x06033507 RID: 210183 RVA: 0x00CD735F File Offset: 0x00CD555F
		public NavigationGroupDownNextComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033508 RID: 210184 RVA: 0x00CD7368 File Offset: 0x00CD5568
		protected override ENavigationDirectionType GetDirection()
		{
			return ENavigationDirectionType.Down;
		}
	}
}
