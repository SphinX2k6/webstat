using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002A98 RID: 10904
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class SubPackageConfig : ConfigBase<SubPackageConfig>
{
	// Token: 0x06015D19 RID: 89369 RVA: 0x0060CFAC File Offset: 0x0060B1AC
	public DownLoadSubPackage? GetDownLoadSubPackageById(int id)
	{
		return ConfigDownLoadSubPackageById.GetConfig(id, true);
	}

	// Token: 0x06015D1A RID: 89370 RVA: 0x0060CFB5 File Offset: 0x0060B1B5
	public DownLoadVersion? GetDownLoadVersionByVersion(int version)
	{
		return ConfigDownLoadVersionByVersion.GetConfig(version, true);
	}

	// Token: 0x06015D1B RID: 89371 RVA: 0x0060CFBE File Offset: 0x0060B1BE
	public IReadOnlyList<DownLoadVersion> GetDownLoadVersionByType(int type)
	{
		return ConfigDownLoadVersionByType.GetConfigList(type, true);
	}

	// Token: 0x06015D1C RID: 89372 RVA: 0x0060CFC7 File Offset: 0x0060B1C7
	public IReadOnlyList<DownLoadSubPackage> GetDownLoadSubPackageList()
	{
		return ConfigDownLoadSubPackageAll.GetConfigList(true);
	}

	// Token: 0x06015D1D RID: 89373 RVA: 0x0060CFCF File Offset: 0x0060B1CF
	public IReadOnlyList<DownLoadSubPackage> GetDownLoadSubPackageListByVersion(int versionId)
	{
		return ConfigDownLoadSubPackageByVersion.GetConfigList(versionId, true);
	}

	// Token: 0x06015D1E RID: 89374 RVA: 0x0060CFD8 File Offset: 0x0060B1D8
	public IReadOnlyList<VideoData> GetVideoDataByBranch(int branch)
	{
		return ConfigVideoDataByBelongBranch.GetConfigList(branch, true);
	}
}
