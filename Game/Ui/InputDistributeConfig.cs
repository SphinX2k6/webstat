using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049EE RID: 18926
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class InputDistributeConfig : ConfigBase<InputDistributeConfig>
	{
		// Token: 0x060317EA RID: 202730 RVA: 0x00C55BC0 File Offset: 0x00C53DC0
		public bool IsViewAllowFightInput(EUiViewName viewName)
		{
			UiShow? config = ConfigUiShowByViewName.GetConfig(viewName, true);
			return config != null && config.Value.IsAllowFightInput;
		}
	}
}
