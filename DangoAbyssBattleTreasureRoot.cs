using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x02001AD6 RID: 6870
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssBattleTreasureRoot : UiPanelBase
{
	// Token: 0x0600C5BA RID: 50618 RVA: 0x0034393E File Offset: 0x00341B3E
	public void InitItem(UUIItem rootItem, UUIItem templateItem)
	{
		this.CurrentCopyRootItem = rootItem;
		this.CurrentCopyTemplateItem = templateItem;
	}

	// Token: 0x0600C5BB RID: 50619 RVA: 0x00343950 File Offset: 0x00341B50
	public UniTask Init(Dictionary<int, int> rewardItemMap, float fullTime)
	{
		DangoAbyssBattleTreasureRoot.<Init>d__5 <Init>d__;
		<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<Init>d__.<>4__this = this;
		<Init>d__.rewardItemMap = rewardItemMap;
		<Init>d__.fullTime = fullTime;
		<Init>d__.<>1__state = -1;
		<Init>d__.<>t__builder.Start<DangoAbyssBattleTreasureRoot.<Init>d__5>(ref <Init>d__);
		return <Init>d__.<>t__builder.Task;
	}

	// Token: 0x0600C5BC RID: 50620 RVA: 0x003439A4 File Offset: 0x00341BA4
	public void RefreshRewardItem(float progress)
	{
		foreach (DangoAbyssBattleTreasureItem dangoAbyssBattleTreasureItem in this.DangoAbyssBattleTreasureItemList)
		{
			dangoAbyssBattleTreasureItem.RefreshByCurrentPercentage(progress);
		}
	}

	// Token: 0x04005EC0 RID: 24256
	[Nullable(2)]
	private UUIItem CurrentCopyRootItem;

	// Token: 0x04005EC1 RID: 24257
	[Nullable(2)]
	private UUIItem CurrentCopyTemplateItem;

	// Token: 0x04005EC2 RID: 24258
	private readonly List<UUIItem> RewardItemList = new List<UUIItem>();

	// Token: 0x04005EC3 RID: 24259
	private readonly List<DangoAbyssBattleTreasureItem> DangoAbyssBattleTreasureItemList = new List<DangoAbyssBattleTreasureItem>();
}
