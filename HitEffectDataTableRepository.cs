using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

// Token: 0x0200311E RID: 12574
public class HitEffectDataTableRepository : BaseFightDataTableRepository
{
	// Token: 0x0601A067 RID: 106599 RVA: 0x0079F8A4 File Offset: 0x0079DAA4
	[NullableContext(1)]
	[return: Nullable(2)]
	public SHitEffect FindHitEffect(string rowName)
	{
		if (this.ExtraTables != null)
		{
			foreach (UDataTable table in this.ExtraTables)
			{
				SHitEffect dataTableRow = DataTableUtil.GetDataTableRow<SHitEffect>(table, rowName);
				if (dataTableRow != null)
				{
					return dataTableRow;
				}
			}
		}
		return DataTableUtil.GetDataTableRow<SHitEffect>(this.SelfTable, rowName);
	}
}
