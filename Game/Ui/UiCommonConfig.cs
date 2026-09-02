using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049D0 RID: 18896
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class UiCommonConfig : ConfigBase<UiCommonConfig>
	{
		// Token: 0x060316FE RID: 202494 RVA: 0x00C4C742 File Offset: 0x00C4A942
		public NpcSystemBackground? GetNpcSystemBackgroundByViewName(string viewName)
		{
			return ConfigNpcSystemBackgroundByViewName.GetConfig(viewName, true);
		}

		// Token: 0x060316FF RID: 202495 RVA: 0x00C4C74B File Offset: 0x00C4A94B
		public InteractBackGround? GetInteractBackgroundByViewName(string viewName)
		{
			return ConfigInteractBackGroundByViewName.GetConfig(viewName, true);
		}
	}
}
