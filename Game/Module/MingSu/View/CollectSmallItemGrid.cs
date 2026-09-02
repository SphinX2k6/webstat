using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Inventory;

namespace CSharpScript.Game.Module.MingSu.View
{
	// Token: 0x0200573B RID: 22331
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CollectSmallItemGrid : LoopScrollSmallItemGrid<IRewardItemData>
	{
		// Token: 0x06038D72 RID: 232818 RVA: 0x00E65CD8 File Offset: 0x00E63ED8
		protected override void OnRefresh(IRewardItemData data, bool isSelected, int gridIndex)
		{
			bool value = false;
			MingSuModel instance = ModelBase<MingSuModel>.Instance;
			int currentDragonPoolId = instance.GetCurrentDragonPoolId();
			int currentPreviewLevel = instance.CurrentPreviewLevel;
			int targetDragonPoolLevelById = instance.GetTargetDragonPoolLevelById(currentDragonPoolId);
			int targetDragonPoolMaxLevelById = instance.GetTargetDragonPoolMaxLevelById(currentDragonPoolId);
			if (currentPreviewLevel == targetDragonPoolLevelById + 1 || (currentPreviewLevel == targetDragonPoolLevelById && currentPreviewLevel == targetDragonPoolMaxLevelById))
			{
				if (instance.GetTargetDragonPoolActiveById(currentDragonPoolId) == 2)
				{
					value = true;
				}
			}
			else if (currentPreviewLevel <= targetDragonPoolLevelById)
			{
				value = true;
			}
			base.SetReceivedVisible(false);
			ItemConfig itemInfo = data.ItemInfo;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = data,
				ItemConfigId = new int?((itemInfo != null) ? itemInfo.Id : 0),
				BottomText = data.Count.ToString(),
				IsReceivedVisible = new bool?(value)
			};
			base.Apply<PropSmallItemGrid>(parameters);
		}
	}
}
