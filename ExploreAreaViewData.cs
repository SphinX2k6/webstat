using System;
using System.Runtime.CompilerServices;

// Token: 0x02001B84 RID: 7044
[NullableContext(1)]
[Nullable(0)]
public class ExploreAreaViewData
{
	// Token: 0x17001086 RID: 4230
	// (get) Token: 0x0600CCA6 RID: 52390 RVA: 0x003677B9 File Offset: 0x003659B9
	// (set) Token: 0x0600CCA7 RID: 52391 RVA: 0x003677C1 File Offset: 0x003659C1
	public int CountryId { get; private set; }

	// Token: 0x17001087 RID: 4231
	// (get) Token: 0x0600CCA8 RID: 52392 RVA: 0x003677CA File Offset: 0x003659CA
	// (set) Token: 0x0600CCA9 RID: 52393 RVA: 0x003677D2 File Offset: 0x003659D2
	public int AreaId { get; private set; }

	// Token: 0x17001088 RID: 4232
	// (get) Token: 0x0600CCAA RID: 52394 RVA: 0x003677DB File Offset: 0x003659DB
	// (set) Token: 0x0600CCAB RID: 52395 RVA: 0x003677E3 File Offset: 0x003659E3
	public string NameId { get; private set; } = "";

	// Token: 0x17001089 RID: 4233
	// (get) Token: 0x0600CCAC RID: 52396 RVA: 0x003677EC File Offset: 0x003659EC
	// (set) Token: 0x0600CCAD RID: 52397 RVA: 0x003677F4 File Offset: 0x003659F4
	public bool IsCountry { get; private set; }

	// Token: 0x1700108A RID: 4234
	// (get) Token: 0x0600CCAE RID: 52398 RVA: 0x003677FD File Offset: 0x003659FD
	// (set) Token: 0x0600CCAF RID: 52399 RVA: 0x00367805 File Offset: 0x00365A05
	public bool IsLock { get; private set; } = true;

	// Token: 0x1700108B RID: 4235
	// (get) Token: 0x0600CCB0 RID: 52400 RVA: 0x0036780E File Offset: 0x00365A0E
	// (set) Token: 0x0600CCB1 RID: 52401 RVA: 0x00367816 File Offset: 0x00365A16
	public float Progress { get; private set; }

	// Token: 0x0600CCB2 RID: 52402 RVA: 0x0036781F File Offset: 0x00365A1F
	public void RefreshCountry(int countryId, string nameId, bool isLock)
	{
		this.CountryId = countryId;
		this.AreaId = 0;
		this.NameId = nameId;
		this.IsLock = isLock;
		this.Progress = 0f;
		this.IsCountry = true;
	}

	// Token: 0x0600CCB3 RID: 52403 RVA: 0x0036784F File Offset: 0x00365A4F
	public void RefreshArea(int areaId, string nameId, float progress)
	{
		this.CountryId = 0;
		this.AreaId = areaId;
		this.NameId = nameId;
		this.IsLock = false;
		this.Progress = progress;
		this.IsCountry = false;
	}
}
