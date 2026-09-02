using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020013F7 RID: 5111
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class MoonChasingMemoryConfig : ConfigBase<MoonChasingMemoryConfig>
{
	// Token: 0x06008DA5 RID: 36261 RVA: 0x002536B7 File Offset: 0x002518B7
	public IReadOnlyList<TrackMoonMemory> GetMemoryByClassify(int classify)
	{
		return ConfigTrackMoonMemoryByClassify.GetConfigList(classify, true) ?? new List<TrackMoonMemory>();
	}

	// Token: 0x06008DA6 RID: 36262 RVA: 0x002536C9 File Offset: 0x002518C9
	public TrackMoonMemory? GetMemoryById(int id)
	{
		return ConfigTrackMoonMemoryById.GetConfig(id, true);
	}

	// Token: 0x06008DA7 RID: 36263 RVA: 0x002536D2 File Offset: 0x002518D2
	public IReadOnlyList<TrackMoonMemory> GetAllMemoryInfo()
	{
		return ConfigTrackMoonMemoryAll.GetConfigList(true) ?? new List<TrackMoonMemory>();
	}
}
