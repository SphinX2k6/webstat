using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A1B RID: 18971
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ImmersiveMouseConfig : ConfigBase<ImmersiveMouseConfig>
	{
		// Token: 0x06031915 RID: 203029 RVA: 0x00C5A76D File Offset: 0x00C5896D
		public IReadOnlyList<ImmersiveMouse> GetAllImmersiveMouseViewConfig()
		{
			return ConfigImmersiveMouseAll.GetConfigList(true);
		}

		// Token: 0x06031916 RID: 203030 RVA: 0x00C5A778 File Offset: 0x00C58978
		public ImmersiveMouse GetImmersiveMouseViewConfigByViewName(EUiViewName viewName)
		{
			return ConfigImmersiveMouseByViewName.GetConfig(viewName, true).Value;
		}
	}
}
