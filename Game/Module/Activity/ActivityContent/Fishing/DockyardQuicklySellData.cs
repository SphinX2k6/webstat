using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006795 RID: 26517
	public class DockyardQuicklySellData
	{
		// Token: 0x060421F4 RID: 270836 RVA: 0x010F7DF0 File Offset: 0x010F5FF0
		public DockyardQuicklySellData(int shapeId)
		{
			FishingGridItemShape fishingShapeConfig = ConfigBase<FishingConfig>.Instance.GetFishingShapeConfig(shapeId);
			for (int i = 0; i < fishingShapeConfig.FillStateLength; i++)
			{
				this.PosDataDoublyList.Add(new List<int>());
				foreach (int item in fishingShapeConfig.FillState(i).Value.GetArrayIntArray())
				{
					this.PosDataDoublyList[i].Add(item);
				}
			}
		}

		// Token: 0x04024D9E RID: 150942
		[Nullable(1)]
		public readonly List<List<int>> PosDataDoublyList = new List<List<int>>();
	}
}
