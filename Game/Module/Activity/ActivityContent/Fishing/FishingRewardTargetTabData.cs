using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006783 RID: 26499
	[NullableContext(2)]
	[Nullable(0)]
	public class FishingRewardTargetTabData
	{
		// Token: 0x04024D3D RID: 150845
		public string NameTextId;

		// Token: 0x04024D3E RID: 150846
		public int Index = -1;

		// Token: 0x04024D3F RID: 150847
		public Action<int> ClickedCallback;

		// Token: 0x04024D40 RID: 150848
		public Func<int, bool> RefreshRedDot;
	}
}
