using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BD4 RID: 7124
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchTerrainData
{
	// Token: 0x0600CF5A RID: 53082 RVA: 0x00371CBF File Offset: 0x0036FEBF
	public FloroRanchTerrainData(FloroRanchTerrain config)
	{
		this.Config = config;
		this.TagData.SetTagId(this.Config.Tag);
	}

	// Token: 0x170010ED RID: 4333
	// (get) Token: 0x0600CF5B RID: 53083 RVA: 0x00371CF0 File Offset: 0x0036FEF0
	public string Name
	{
		get
		{
			return ConfigMultiTextLang.GetLocalTextNew(this.Config.Name, null);
		}
	}

	// Token: 0x170010EE RID: 4334
	// (get) Token: 0x0600CF5C RID: 53084 RVA: 0x00371D11 File Offset: 0x0036FF11
	public string Desc
	{
		get
		{
			return this.TagData.Desc;
		}
	}

	// Token: 0x170010EF RID: 4335
	// (get) Token: 0x0600CF5D RID: 53085 RVA: 0x00371D20 File Offset: 0x0036FF20
	public string Icon
	{
		get
		{
			return this.Config.Pic;
		}
	}

	// Token: 0x040062BF RID: 25279
	private readonly FloroRanchTerrain Config;

	// Token: 0x040062C0 RID: 25280
	public FloroRanchTagData TagData = new FloroRanchTagData();
}
