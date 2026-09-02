using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.SkipInterface
{
	// Token: 0x02004F1F RID: 20255
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class SkipInterfaceConfig : ConfigBase<SkipInterfaceConfig>
	{
		// Token: 0x0603457C RID: 214396 RVA: 0x00D195B6 File Offset: 0x00D177B6
		public AccessPath? GetAccessPathConfig(int id)
		{
			return ConfigAccessPathById.GetConfig(id, true);
		}
	}
}
