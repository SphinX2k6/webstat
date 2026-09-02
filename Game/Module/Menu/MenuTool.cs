using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x02005768 RID: 22376
	public class MenuTool
	{
		// Token: 0x06038EFC RID: 233212 RVA: 0x00E6C9C1 File Offset: 0x00E6ABC1
		[NullableContext(1)]
		public static IReadOnlyList<LanguageDefine> GetLanguageDefineData()
		{
			return Singleton<LanguageSystem>.Instance.GetAllLanguageDefines();
		}
	}
}
