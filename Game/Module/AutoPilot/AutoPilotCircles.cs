using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006149 RID: 24905
	[NullableContext(1)]
	[Nullable(0)]
	public class AutoPilotCircles : AutoPilotDefine.IAutoPilotCircles
	{
		// Token: 0x17009AE0 RID: 39648
		// (get) Token: 0x0603EEBE RID: 257726 RVA: 0x010210FD File Offset: 0x0101F2FD
		// (set) Token: 0x0603EEBF RID: 257727 RVA: 0x01021105 File Offset: 0x0101F305
		public List<int> RoadBuildIdArray { get; set; } = new List<int>();

		// Token: 0x17009AE1 RID: 39649
		// (get) Token: 0x0603EEC0 RID: 257728 RVA: 0x0102110E File Offset: 0x0101F30E
		// (set) Token: 0x0603EEC1 RID: 257729 RVA: 0x01021116 File Offset: 0x0101F316
		public List<int> CircleIds { get; set; } = new List<int>();
	}
}
