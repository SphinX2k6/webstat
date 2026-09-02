using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Parkour
{
	// Token: 0x02006B33 RID: 27443
	public class ParkourPointInfo
	{
		// Token: 0x06043D05 RID: 277765 RVA: 0x01186980 File Offset: 0x01184B80
		[NullableContext(1)]
		public ParkourPointInfo(TsParkourCheckPoint point)
		{
			this.Point = point;
			this.IsRecycled = false;
		}

		// Token: 0x04025EE5 RID: 155365
		[Nullable(2)]
		public TsParkourCheckPoint Point;

		// Token: 0x04025EE6 RID: 155366
		public bool IsRecycled;
	}
}
