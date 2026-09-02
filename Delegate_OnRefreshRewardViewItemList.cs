using System;
using System.Collections.Generic;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x02000694 RID: 1684
// (Invoke) Token: 0x06001C03 RID: 7171
[EventRule(EEventName.OnRefreshRewardViewItemList)]
internal delegate void Delegate_OnRefreshRewardViewItemList(IReadOnlyList<RewardItemData> itemList);
