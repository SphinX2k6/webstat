using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063A6 RID: 25510
	[NullableContext(1)]
	[Nullable(0)]
	public class RoverlikeTalentTreeNodeRowData
	{
		// Token: 0x060400E9 RID: 262377 RVA: 0x0106B418 File Offset: 0x01069618
		public RoverlikeTalentTreeNodeRowData(int row, List<RoverlikeTalentNodeData> nodeList)
		{
			this.Row = row;
			this.NodeList = nodeList;
		}

		// Token: 0x04023F6A RID: 147306
		public int Row;

		// Token: 0x04023F6B RID: 147307
		public List<RoverlikeTalentNodeData> NodeList = new List<RoverlikeTalentNodeData>();
	}
}
