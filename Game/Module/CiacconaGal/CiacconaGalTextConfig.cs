using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.CiacconaGal
{
	// Token: 0x02005EB0 RID: 24240
	public class CiacconaGalTextConfig
	{
		// Token: 0x0603CECB RID: 249547 RVA: 0x00F7A13C File Offset: 0x00F7833C
		[NullableContext(1)]
		public static string GetTextId(int numberId)
		{
			CiacconaGalText? ciacconaGalText;
			return ((ConfigCiacconaGalTextById.GetConfig(numberId, true) != null) ? ciacconaGalText.GetValueOrDefault().TextId : null) ?? "";
		}
	}
}
