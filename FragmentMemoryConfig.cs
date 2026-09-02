using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001C80 RID: 7296
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FragmentMemoryConfig : ConfigBase<FragmentMemoryConfig>
{
	// Token: 0x0600D52C RID: 54572 RVA: 0x0038E1BD File Offset: 0x0038C3BD
	public PhotoMemoryTopic? GetPhotoMemoryTopicById(int id)
	{
		return ConfigPhotoMemoryTopicById.GetConfig(id, true);
	}

	// Token: 0x0600D52D RID: 54573 RVA: 0x0038E1C6 File Offset: 0x0038C3C6
	public IReadOnlyList<PhotoMemoryTopic> GetAllPhotoMemoryTopic()
	{
		return ConfigPhotoMemoryTopicAll.GetConfigList(true);
	}

	// Token: 0x0600D52E RID: 54574 RVA: 0x0038E1CE File Offset: 0x0038C3CE
	public IReadOnlyList<PhotoMemoryCollect> GetPhotoMemoryCollectConfigListByTopicId(int topicId)
	{
		return ConfigPhotoMemoryCollectByTopicID.GetConfigList(topicId, true);
	}

	// Token: 0x0600D52F RID: 54575 RVA: 0x0038E1D7 File Offset: 0x0038C3D7
	public PhotoMemoryCollect? GetPhotoMemoryCollectById(int id)
	{
		return ConfigPhotoMemoryCollectById.GetConfig(id, true);
	}

	// Token: 0x0600D530 RID: 54576 RVA: 0x0038E1E0 File Offset: 0x0038C3E0
	public PhotoMemoryActivity? GetPhotoMemoryActivityById(int id)
	{
		return ConfigPhotoMemoryActivityById.GetConfig(id, true);
	}

	// Token: 0x0600D531 RID: 54577 RVA: 0x0038E1E9 File Offset: 0x0038C3E9
	public ClueEntrance? GetClueEntrance(int id)
	{
		return ConfigClueEntranceById.GetConfig(id, true);
	}

	// Token: 0x0600D532 RID: 54578 RVA: 0x0038E1F2 File Offset: 0x0038C3F2
	public IReadOnlyList<ClueContent> GetClueContent(int id)
	{
		return ConfigClueContentByGroupId.GetConfigList(id, true);
	}

	// Token: 0x0600D533 RID: 54579 RVA: 0x0038E1FB File Offset: 0x0038C3FB
	[NullableContext(1)]
	public string GetTopicNotOpenTexturePath()
	{
		return ConfigCommonParamById.GetStringConfig("FragmentMemoryNotOpenTexture");
	}

	// Token: 0x0600D534 RID: 54580 RVA: 0x0038E207 File Offset: 0x0038C407
	[NullableContext(1)]
	public string GetTopicNotOpenTextureLightPath()
	{
		return ConfigCommonParamById.GetStringConfig("FragmentMemoryNotOpenLightTexture");
	}

	// Token: 0x0600D535 RID: 54581 RVA: 0x0038E214 File Offset: 0x0038C414
	public int GetFragmentMemoryPreNeedItemId()
	{
		return ConfigCommonParamById.GetIntConfig("OpenFragmentNeedItem").Value;
	}
}
