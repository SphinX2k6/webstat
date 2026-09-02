using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BC5 RID: 7109
[NullableContext(1)]
[Nullable(0)]
public class FloroRanchRandomEventData
{
	// Token: 0x0600CEDF RID: 52959 RVA: 0x003713EB File Offset: 0x0036F5EB
	public FloroRanchRandomEventData(FloroRanchEvent config)
	{
		this.Config = config;
	}

	// Token: 0x0600CEE0 RID: 52960 RVA: 0x003713FC File Offset: 0x0036F5FC
	public int GetId()
	{
		return this.Config.Id;
	}

	// Token: 0x0600CEE1 RID: 52961 RVA: 0x00371418 File Offset: 0x0036F618
	public string GetEventTitle()
	{
		return this.Config.Title;
	}

	// Token: 0x0600CEE2 RID: 52962 RVA: 0x00371434 File Offset: 0x0036F634
	public string GetEventDesc()
	{
		return this.Config.Desc;
	}

	// Token: 0x04006299 RID: 25241
	private readonly FloroRanchEvent Config;
}
