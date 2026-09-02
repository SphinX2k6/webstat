using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D70 RID: 19824
	public class StaticJoyStickLeftComponent : StaticJoyStickComponentBase
	{
		// Token: 0x060335D7 RID: 210391 RVA: 0x00CD8CAD File Offset: 0x00CD6EAD
		public StaticJoyStickLeftComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
			this.Pivot = Vector2D.Create(0.009999999776482582, 0.5);
		}
	}
}
