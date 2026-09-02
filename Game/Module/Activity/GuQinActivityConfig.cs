using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity
{
	// Token: 0x020061C6 RID: 25030
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class GuQinActivityConfig : ConfigBase<GuQinActivityConfig>
	{
		// Token: 0x0603F2AA RID: 258730 RVA: 0x01036D0C File Offset: 0x01034F0C
		public GuQinActivityParam GetGuQinActivityParamById(int id)
		{
			return ConfigGuQinActivityParamById.GetConfig(id, true).Value;
		}

		// Token: 0x0603F2AB RID: 258731 RVA: 0x01036D28 File Offset: 0x01034F28
		public GuQinActivityTask GetGuQinActivityTaskById(int id)
		{
			return ConfigGuQinActivityTaskById.GetConfig(id, true).Value;
		}
	}
}
