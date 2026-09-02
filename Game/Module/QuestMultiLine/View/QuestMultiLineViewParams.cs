using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.QuestMultiLine.QuestMultiLineData;

namespace CSharpScript.Game.Module.QuestMultiLine.View
{
	// Token: 0x02005325 RID: 21285
	public class QuestMultiLineViewParams
	{
		// Token: 0x0401F3A2 RID: 127906
		[Nullable(1)]
		public List<QuestMultiLineTimePointData> TimePoints;

		// Token: 0x0401F3A3 RID: 127907
		public int ShowTimePointId;

		// Token: 0x0401F3A4 RID: 127908
		public bool PlayTimePointComponentAnim;
	}
}
