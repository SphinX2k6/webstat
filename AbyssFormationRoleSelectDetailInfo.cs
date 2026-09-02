using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001ABF RID: 6847
[NullableContext(1)]
[Nullable(0)]
public class AbyssFormationRoleSelectDetailInfo
{
	// Token: 0x0600C49C RID: 50332 RVA: 0x0033E1CC File Offset: 0x0033C3CC
	public int GetRoleId()
	{
		return this.RoleId;
	}

	// Token: 0x0600C49D RID: 50333 RVA: 0x0033E1D4 File Offset: 0x0033C3D4
	public int GetDangoId()
	{
		return this.DangoId;
	}

	// Token: 0x0600C49E RID: 50334 RVA: 0x0033E1DC File Offset: 0x0033C3DC
	public int[] GetPluginItemList()
	{
		return this.PluginItemList;
	}

	// Token: 0x0600C49F RID: 50335 RVA: 0x0033E1E4 File Offset: 0x0033C3E4
	public void Phrase(AbyssOneRoleSelectInfo data)
	{
		this.RoleId = data.RoleId;
		this.DangoId = data.LittleRoleId;
		this.PluginItemList = data.PluginItemId.ToArray<int>();
	}

	// Token: 0x04005E4C RID: 24140
	private int RoleId;

	// Token: 0x04005E4D RID: 24141
	private int DangoId;

	// Token: 0x04005E4E RID: 24142
	private int[] PluginItemList = Array.Empty<int>();
}
