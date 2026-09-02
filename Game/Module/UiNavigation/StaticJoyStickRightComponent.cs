using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D71 RID: 19825
	public class StaticJoyStickRightComponent : StaticJoyStickComponentBase
	{
		// Token: 0x060335D8 RID: 210392 RVA: 0x00CD8CD3 File Offset: 0x00CD6ED3
		public StaticJoyStickRightComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
			this.Pivot = Vector2D.Create(0.9900000095367432, 0.5);
		}
	}
}
