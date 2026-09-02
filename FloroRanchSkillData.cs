using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BCC RID: 7116
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchSkillData
{
	// Token: 0x0600CF0F RID: 53007 RVA: 0x00371720 File Offset: 0x0036F920
	public FloroRanchSkillData(FloroRanchSkill config)
	{
		this.Config = config;
	}

	// Token: 0x170010BD RID: 4285
	// (get) Token: 0x0600CF10 RID: 53008 RVA: 0x00371730 File Offset: 0x0036F930
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x170010BE RID: 4286
	// (get) Token: 0x0600CF11 RID: 53009 RVA: 0x0037174C File Offset: 0x0036F94C
	public string Name
	{
		get
		{
			return this.Config.Name;
		}
	}

	// Token: 0x0600CF12 RID: 53010 RVA: 0x00371768 File Offset: 0x0036F968
	public string GetRealName()
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.Config.Name, null);
	}

	// Token: 0x170010BF RID: 4287
	// (get) Token: 0x0600CF13 RID: 53011 RVA: 0x0037178C File Offset: 0x0036F98C
	public string Icon
	{
		get
		{
			return this.Config.Icon;
		}
	}

	// Token: 0x170010C0 RID: 4288
	// (get) Token: 0x0600CF14 RID: 53012 RVA: 0x003717A8 File Offset: 0x0036F9A8
	public string Desc
	{
		get
		{
			return this.Config.Desc;
		}
	}

	// Token: 0x170010C1 RID: 4289
	// (get) Token: 0x0600CF15 RID: 53013 RVA: 0x003717C4 File Offset: 0x0036F9C4
	public bool IsActiveSkill
	{
		get
		{
			return this.Config.Type == 0;
		}
	}

	// Token: 0x040062A5 RID: 25253
	private readonly FloroRanchSkill Config;
}
