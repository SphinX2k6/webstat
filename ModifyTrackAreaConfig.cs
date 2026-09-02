using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Quest;

// Token: 0x02001DED RID: 7661
[NullableContext(1)]
[Nullable(0)]
public class ModifyTrackAreaConfig
{
	// Token: 0x0600E22E RID: 57902 RVA: 0x003CE81D File Offset: 0x003CCA1D
	public ModifyTrackAreaConfig(int sourceOfAdd, ITrackAreaText trackConfig)
	{
	}

	// Token: 0x170011B0 RID: 4528
	// (get) Token: 0x0600E22F RID: 57903 RVA: 0x003CE833 File Offset: 0x003CCA33
	public string ModifyTrackAreaText
	{
		get
		{
			return Singleton<PublicUtil>.Instance.GetConfigTextByKey(this.TrackConfig.Tid);
		}
	}

	// Token: 0x04006CBE RID: 27838
	public int SourceOfAdd = sourceOfAdd;

	// Token: 0x04006CBF RID: 27839
	public ITrackAreaText TrackConfig = trackConfig;
}
