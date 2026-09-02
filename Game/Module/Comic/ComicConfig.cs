using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Comic
{
	// Token: 0x02005E86 RID: 24198
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ComicConfig : ConfigBase<ComicConfig>
	{
		// Token: 0x0603CDAB RID: 249259 RVA: 0x00F725C8 File Offset: 0x00F707C8
		public ComicDisplayConfig? GetComicDisplayConfig(int id)
		{
			return ConfigComicDisplayConfigById.GetConfig(id, true);
		}

		// Token: 0x0603CDAC RID: 249260 RVA: 0x00F725D1 File Offset: 0x00F707D1
		public ComicPrefabConfig? GetComicPrefabConfig(int id)
		{
			return ConfigComicPrefabConfigById.GetConfig(id, true);
		}
	}
}
