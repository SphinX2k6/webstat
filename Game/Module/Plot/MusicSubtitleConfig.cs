using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200534E RID: 21326
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class MusicSubtitleConfig : ConfigBase<MusicSubtitleConfig>
	{
		// Token: 0x0603665B RID: 222811 RVA: 0x00DB700C File Offset: 0x00DB520C
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603665C RID: 222812 RVA: 0x00DB700F File Offset: 0x00DB520F
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x0603665D RID: 222813 RVA: 0x00DB7012 File Offset: 0x00DB5212
		[return: Nullable(2)]
		public IReadOnlyList<MusicSubTitle> GetMusicSubtitle(string id)
		{
			return ConfigMusicSubTitleBySubtitleGroupTag.GetConfigList(id, true);
		}
	}
}
