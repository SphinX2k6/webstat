using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.View
{
	// Token: 0x02006F15 RID: 28437
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DollCollectSmallItemGrid : LoopScrollSmallItemGrid<IDollRewardItemData>
	{
		// Token: 0x06044E13 RID: 282131 RVA: 0x011ECDB0 File Offset: 0x011EAFB0
		protected override void OnRefresh(IDollRewardItemData data, bool isSelected, int gridIndex)
		{
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?(data.ItemInfo.Id),
				BottomText = data.Count.ToString(),
				IsReceivedVisible = new bool?(false)
			};
			base.Apply<PropSmallItemGrid>(parameters);
			base.SetUseFixedAsync(true);
		}
	}
}
