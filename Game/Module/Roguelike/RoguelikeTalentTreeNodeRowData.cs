using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x02005101 RID: 20737
	[NullableContext(1)]
	[Nullable(0)]
	public class RoguelikeTalentTreeNodeRowData
	{
		// Token: 0x06035743 RID: 218947 RVA: 0x00D6ABB3 File Offset: 0x00D68DB3
		public RoguelikeTalentTreeNodeRowData(int row, List<RoguelikeTalentTreeNodeData> nodeList)
		{
			this.Row = row;
			this.NodeList = nodeList;
		}

		// Token: 0x0401EB43 RID: 125763
		public int Row;

		// Token: 0x0401EB44 RID: 125764
		public List<RoguelikeTalentTreeNodeData> NodeList = new List<RoguelikeTalentTreeNodeData>();
	}
}
