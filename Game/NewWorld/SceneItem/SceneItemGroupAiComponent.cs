using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.NewWorld.SceneItem
{
	// Token: 0x020047FB RID: 18427
	public class SceneItemGroupAiComponent : EntityComponent
	{
		// Token: 0x0602FDFB RID: 196091 RVA: 0x00B895E5 File Offset: 0x00B877E5
		[NullableContext(1)]
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemGroupAiComponent sceneItemGroupAiComponent = (SceneItemGroupAiComponent)componentTemplate;
			return true;
		}
	}
}
