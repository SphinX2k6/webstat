using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BC4 RID: 7108
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRaceData
{
	// Token: 0x0600CED8 RID: 52952 RVA: 0x00371333 File Offset: 0x0036F533
	public FloroRanchRaceData(FloroRanchRace config)
	{
		this.Config = config;
	}

	// Token: 0x170010B4 RID: 4276
	// (get) Token: 0x0600CED9 RID: 52953 RVA: 0x00371344 File Offset: 0x0036F544
	public int Id
	{
		get
		{
			return this.Config.Id;
		}
	}

	// Token: 0x0600CEDA RID: 52954 RVA: 0x00371360 File Offset: 0x0036F560
	public string GetRaceName()
	{
		return this.Config.Name;
	}

	// Token: 0x170010B5 RID: 4277
	// (get) Token: 0x0600CEDB RID: 52955 RVA: 0x0037137C File Offset: 0x0036F57C
	public string Icon
	{
		get
		{
			return this.Config.Icon;
		}
	}

	// Token: 0x170010B6 RID: 4278
	// (get) Token: 0x0600CEDC RID: 52956 RVA: 0x00371398 File Offset: 0x0036F598
	public string SmallIcon
	{
		get
		{
			return this.Config.SmallIcon;
		}
	}

	// Token: 0x0600CEDD RID: 52957 RVA: 0x003713B4 File Offset: 0x0036F5B4
	public string GetDesc()
	{
		return this.Config.Description;
	}

	// Token: 0x170010B7 RID: 4279
	// (get) Token: 0x0600CEDE RID: 52958 RVA: 0x003713D0 File Offset: 0x0036F5D0
	public bool IsCommon
	{
		get
		{
			return this.Config.IsCommon;
		}
	}

	// Token: 0x04006298 RID: 25240
	private readonly FloroRanchRace Config;
}
