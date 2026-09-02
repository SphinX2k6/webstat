using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002596 RID: 9622
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PhonographConfig : ConfigBase<PhonographConfig>
{
	// Token: 0x06012BE8 RID: 76776 RVA: 0x0052BC83 File Offset: 0x00529E83
	public IReadOnlyList<PhonographMusic> GetMusicList()
	{
		return ConfigPhonographMusicAll.GetConfigList(true);
	}

	// Token: 0x06012BE9 RID: 76777 RVA: 0x0052BC8B File Offset: 0x00529E8B
	public PhonographMusic? GetMusicById(int id)
	{
		return ConfigPhonographMusicById.GetConfig(id, true);
	}

	// Token: 0x06012BEA RID: 76778 RVA: 0x0052BC94 File Offset: 0x00529E94
	public IReadOnlyList<PhonographAlbum> GetMusicAlbumList()
	{
		return ConfigPhonographAlbumAll.GetConfigList(true);
	}

	// Token: 0x06012BEB RID: 76779 RVA: 0x0052BC9C File Offset: 0x00529E9C
	public PhonographAlbum? GetMusicAlbumById(int id)
	{
		return ConfigPhonographAlbumById.GetConfig(id, true);
	}
}
