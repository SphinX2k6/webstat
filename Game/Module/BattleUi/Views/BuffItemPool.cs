using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x02005FF9 RID: 24569
	[NullableContext(1)]
	[Nullable(0)]
	public class BuffItemPool
	{
		// Token: 0x0603DE09 RID: 253449 RVA: 0x00FC74FC File Offset: 0x00FC56FC
		public void Clear()
		{
			foreach (BuffItem buffItem in this.CommonBuffItemList)
			{
				buffItem.DestroyCompatible();
			}
			this.CommonBuffItemList.Clear();
			foreach (QuickHackBuffItem quickHackBuffItem in this.QuickHackBuffItemList)
			{
				quickHackBuffItem.DestroyCompatible();
			}
			this.QuickHackBuffItemList.Clear();
		}

		// Token: 0x0603DE0A RID: 253450 RVA: 0x00FC75A4 File Offset: 0x00FC57A4
		public BuffItemBase GetBuffItem(USceneComponent parentItem, GameplayCue? cueConfig)
		{
			if (cueConfig != null && cueConfig.Value.CueType == 37)
			{
				BuffItemBase buffItemBase = this.NewCustomStyleBuffItem(parentItem, cueConfig.Value);
				if (buffItemBase != null)
				{
					return buffItemBase;
				}
			}
			return this.NewCommonBuffItem(parentItem);
		}

		// Token: 0x0603DE0B RID: 253451 RVA: 0x00FC75E8 File Offset: 0x00FC57E8
		public void RecycleBuffItem(BuffItemBase buffItem)
		{
			BuffItem buffItem2 = buffItem as BuffItem;
			if (buffItem2 != null)
			{
				this.CommonBuffItemList.Add(buffItem2);
				return;
			}
			QuickHackBuffItem quickHackBuffItem = buffItem as QuickHackBuffItem;
			if (quickHackBuffItem != null)
			{
				this.QuickHackBuffItemList.Add(quickHackBuffItem);
			}
		}

		// Token: 0x0603DE0C RID: 253452 RVA: 0x00FC7624 File Offset: 0x00FC5824
		private BuffItem NewCommonBuffItem(USceneComponent parentItem)
		{
			if (this.CommonBuffItemList.Count > 0)
			{
				BuffItem result = this.CommonBuffItemList[this.CommonBuffItemList.Count - 1];
				this.CommonBuffItemList.RemoveAt(this.CommonBuffItemList.Count - 1);
				return result;
			}
			return new BuffItem(parentItem);
		}

		// Token: 0x0603DE0D RID: 253453 RVA: 0x00FC7676 File Offset: 0x00FC5876
		[return: Nullable(2)]
		private BuffItemBase NewCustomStyleBuffItem(USceneComponent parentItem, GameplayCue cueConfig)
		{
			if (cueConfig.ParametersLength > 0 && int.Parse(cueConfig.Parameters(0)) == 0)
			{
				return this.NewQuickHackBuffItem(parentItem);
			}
			return null;
		}

		// Token: 0x0603DE0E RID: 253454 RVA: 0x00FC769C File Offset: 0x00FC589C
		private QuickHackBuffItem NewQuickHackBuffItem(USceneComponent parentItem)
		{
			if (this.QuickHackBuffItemList.Count > 0)
			{
				QuickHackBuffItem result = this.QuickHackBuffItemList[this.QuickHackBuffItemList.Count - 1];
				this.QuickHackBuffItemList.RemoveAt(this.QuickHackBuffItemList.Count - 1);
				return result;
			}
			return new QuickHackBuffItem(parentItem);
		}

		// Token: 0x04022B52 RID: 142162
		private readonly List<BuffItem> CommonBuffItemList = new List<BuffItem>();

		// Token: 0x04022B53 RID: 142163
		private readonly List<QuickHackBuffItem> QuickHackBuffItemList = new List<QuickHackBuffItem>();
	}
}
