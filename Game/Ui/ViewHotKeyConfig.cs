using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A2D RID: 18989
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ViewHotKeyConfig : ConfigBase<ViewHotKeyConfig>
	{
		// Token: 0x060319F6 RID: 203254 RVA: 0x00C5D051 File Offset: 0x00C5B251
		public IReadOnlyList<OpenAndCloseViewHotKey> GetAllOpenAndCloseViewHotKeyConfig()
		{
			return ConfigOpenAndCloseViewHotKeyAll.GetConfigList(true);
		}
	}
}
