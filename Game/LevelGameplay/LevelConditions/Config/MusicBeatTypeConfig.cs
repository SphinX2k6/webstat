using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions.Config
{
	// Token: 0x02006E08 RID: 28168
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class MusicBeatTypeConfig : ConfigBase<MusicBeatTypeConfig>
	{
		// Token: 0x06044670 RID: 280176 RVA: 0x011C4FBA File Offset: 0x011C31BA
		public MusicBeatType? GetMusicBeatTypeConfig(string beatType)
		{
			return ConfigMusicBeatTypeByBeatType.GetConfig(beatType, true);
		}
	}
}
