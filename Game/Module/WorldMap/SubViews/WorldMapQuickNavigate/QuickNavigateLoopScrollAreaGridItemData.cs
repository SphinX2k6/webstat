using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Map.MapDefine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.WorldMapQuickNavigate
{
	// Token: 0x02004B71 RID: 19313
	public class QuickNavigateLoopScrollAreaGridItemData
	{
		// Token: 0x0401D700 RID: 120576
		public int Index;

		// Token: 0x0401D701 RID: 120577
		[Nullable(2)]
		public IWorldMapNavigate AreaNavigateInfo;

		// Token: 0x0401D702 RID: 120578
		public bool IsSelected;

		// Token: 0x0401D703 RID: 120579
		public ERefreshNavigateType RefreshType;
	}
}
