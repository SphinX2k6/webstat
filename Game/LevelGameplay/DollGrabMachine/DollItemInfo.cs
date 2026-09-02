using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common.DollMachine;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine
{
	// Token: 0x02006EC2 RID: 28354
	[NullableContext(1)]
	[Nullable(0)]
	public class DollItemInfo
	{
		// Token: 0x06044BA8 RID: 281512 RVA: 0x011DE104 File Offset: 0x011DC304
		public bool IsCollectComplete()
		{
			return this.ShowedItemIds.Count == this.PartDollIdList.Count + 1;
		}

		// Token: 0x06044BA9 RID: 281513 RVA: 0x011DE120 File Offset: 0x011DC320
		public int GetShowedItemCount()
		{
			return this.ShowedItemIds.Count;
		}

		// Token: 0x06044BAA RID: 281514 RVA: 0x011DE12D File Offset: 0x011DC32D
		public int GetTotalItemCount()
		{
			return this.PartDollIdList.Count + 1;
		}

		// Token: 0x06044BAB RID: 281515 RVA: 0x011DE13C File Offset: 0x011DC33C
		public bool HasShowedItem(int itemId)
		{
			return this.ShowedItemIds.Contains(itemId);
		}

		// Token: 0x06044BAC RID: 281516 RVA: 0x011DE14C File Offset: 0x011DC34C
		public int GetIndexByItemId(int itemId)
		{
			if (itemId == this.MainItemId)
			{
				return 0;
			}
			int num = this.PartDollIdList.IndexOf(itemId);
			if (num >= 0)
			{
				return num + 1;
			}
			return -1;
		}

		// Token: 0x0402645F RID: 156767
		[Nullable(2)]
		public BP_DollShowCaseActor_C DollShowCaseActor;

		// Token: 0x04026460 RID: 156768
		public string DollIdleAnimPath = string.Empty;

		// Token: 0x04026461 RID: 156769
		public HashSet<int> ShowedItemIds = new HashSet<int>();

		// Token: 0x04026462 RID: 156770
		[Nullable(2)]
		public DollViewCameraInfo ViewCameraInfo;

		// Token: 0x04026463 RID: 156771
		public int MainItemId;

		// Token: 0x04026464 RID: 156772
		public List<int> PartDollIdList = new List<int>();

		// Token: 0x04026465 RID: 156773
		public Dictionary<int, UMaterialInterface[]> OriginalMaterialMap = new Dictionary<int, UMaterialInterface[]>();

		// Token: 0x04026466 RID: 156774
		public HashSet<int> BindingItemIdSet = new HashSet<int>();
	}
}
