using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.NewWorld.Common.Component;

namespace CSharpScript.Game.NewWorld.SceneItem.Common.Component
{
	// Token: 0x02004885 RID: 18565
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneItemDebugComponent : EntityComponent
	{
		// Token: 0x060304E4 RID: 197860 RVA: 0x00BC57A0 File Offset: 0x00BC39A0
		public string GetTagDebugStrings()
		{
			return base.Entity.GetComponent<LevelTagComponent>().GetTagDebugStrings();
		}

		// Token: 0x060304E5 RID: 197861 RVA: 0x00BC57B2 File Offset: 0x00BC39B2
		public override bool ClearComponent(EntityComponent componentTemplate)
		{
			if (!base.ClearComponent(componentTemplate))
			{
				return false;
			}
			SceneItemDebugComponent sceneItemDebugComponent = (SceneItemDebugComponent)componentTemplate;
			return true;
		}
	}
}
