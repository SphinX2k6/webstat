using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WorldMap.RegionalTerminal.Data;

// Token: 0x02002D6D RID: 11629
[NullableContext(1)]
[Nullable(0)]
public class RegionalTerminalGroupData
{
	// Token: 0x17001EF5 RID: 7925
	// (get) Token: 0x06017798 RID: 96152 RVA: 0x00681B4F File Offset: 0x0067FD4F
	// (set) Token: 0x06017799 RID: 96153 RVA: 0x00681B57 File Offset: 0x0067FD57
	public int GroupId { get; set; }

	// Token: 0x17001EF6 RID: 7926
	// (get) Token: 0x0601779A RID: 96154 RVA: 0x00681B60 File Offset: 0x0067FD60
	// (set) Token: 0x0601779B RID: 96155 RVA: 0x00681B68 File Offset: 0x0067FD68
	public int SortId { get; set; }

	// Token: 0x17001EF7 RID: 7927
	// (get) Token: 0x0601779C RID: 96156 RVA: 0x00681B71 File Offset: 0x0067FD71
	// (set) Token: 0x0601779D RID: 96157 RVA: 0x00681B79 File Offset: 0x0067FD79
	public List<RegionalTerminalGameplayData> GameplayDataList { get; set; } = new List<RegionalTerminalGameplayData>();

	// Token: 0x0601779E RID: 96158 RVA: 0x00681B84 File Offset: 0x0067FD84
	public bool IsAvailableShow()
	{
		using (List<RegionalTerminalGameplayData>.Enumerator enumerator = this.GameplayDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetShowState())
				{
					return true;
				}
			}
		}
		return false;
	}
}
