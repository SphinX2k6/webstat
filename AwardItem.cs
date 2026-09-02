using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001280 RID: 4736
public class AwardItem : UiPanelBase
{
	// Token: 0x06007EC4 RID: 32452 RVA: 0x002189A4 File Offset: 0x00216BA4
	protected unsafe override void OnRegisterComponent()
	{
		int num = 6;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(4, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x06007EC5 RID: 32453 RVA: 0x00218A94 File Offset: 0x00216C94
	[NullableContext(1)]
	public void Refresh(TimePointRewardData data, IntPair rewardItem)
	{
		ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(rewardItem.Item1);
		if (itemConfigData == null)
		{
			return;
		}
		string text = itemConfigData.Icon;
		if (itemConfigData.ItemDataType == InventoryDefine.EItemDataType.PlayerHeadItem)
		{
			PlayerHeadRe? playerHeadRe;
			text = (((ConfigPlayerHeadReById.GetConfig(rewardItem.Item1, true) != null) ? playerHeadRe.GetValueOrDefault().RoleHeadIconCircle : null) ?? text);
		}
		base.SetTextureByPath(text, base.GetTexture(2), null, null);
		base.GetText(3).SetText(rewardItem.Item2.ToString(), true);
	}

	// Token: 0x06007EC6 RID: 32454 RVA: 0x00218B30 File Offset: 0x00216D30
	[NullableContext(1)]
	public void RefreshState(TimePointRewardData data)
	{
		bool uiactive = data.RewardState == ETimePointRewardState.Lock;
		bool uiactive2 = data.RewardState == ETimePointRewardState.UnlockAndUnClaimed;
		bool uiactive3 = data.RewardState == ETimePointRewardState.UnlockAndClaimed;
		base.GetSprite(0).SetUIActive(uiactive);
		base.GetSprite(1).SetUIActive(uiactive2);
		base.GetSprite(4).SetUIActive(uiactive3);
		base.GetSprite(5).SetUIActive(uiactive3);
	}

	// Token: 0x02007602 RID: 30210
	private class EComponents
	{
		// Token: 0x04028AF8 RID: 166648
		public const int DefaultBgSprite = 0;

		// Token: 0x04028AF9 RID: 166649
		public const int SelectBgSprite = 1;

		// Token: 0x04028AFA RID: 166650
		public const int IconTexture = 2;

		// Token: 0x04028AFB RID: 166651
		public const int CountText = 3;

		// Token: 0x04028AFC RID: 166652
		public const int MaskSprite = 4;

		// Token: 0x04028AFD RID: 166653
		public const int ReceivedBgSprite = 5;
	}
}
