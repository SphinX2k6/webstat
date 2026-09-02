using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004D9C RID: 19868
	[NullableContext(1)]
	[Nullable(0)]
	public class TrapDefenseTalentTreeRowData
	{
		// Token: 0x06033746 RID: 210758 RVA: 0x00CDEACF File Offset: 0x00CDCCCF
		public static TrapDefenseTalentTreeRowData Create(int row, List<TrapDefenseTalentTreeNodeData> nodeList)
		{
			return new TrapDefenseTalentTreeRowData
			{
				Row = row,
				NodeList = nodeList
			};
		}

		// Token: 0x0401DCF2 RID: 122098
		public int Row;

		// Token: 0x0401DCF3 RID: 122099
		public List<TrapDefenseTalentTreeNodeData> NodeList = new List<TrapDefenseTalentTreeNodeData>();
	}
}
