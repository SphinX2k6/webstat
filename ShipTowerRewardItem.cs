using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

// Token: 0x020029D1 RID: 10705
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ShipTowerRewardItem : GridProxyAbstract<ShipTowerRewardItemData>
{
	// Token: 0x06015571 RID: 87409 RVA: 0x005E9F18 File Offset: 0x005E8118
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIText)),
			new ValueTuple<int, Type>(3, typeof(UUIHorizontalLayout)),
			new ValueTuple<int, Type>(4, typeof(UUIItem)),
			new ValueTuple<int, Type>(5, typeof(UUISprite)),
			new ValueTuple<int, Type>(6, typeof(UUISprite))
		};
	}

	// Token: 0x06015572 RID: 87410 RVA: 0x005E9FCC File Offset: 0x005E81CC
	protected override UniTask OnBeforeStartAsync()
	{
		ShipTowerRewardItem.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
		<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
		<OnBeforeStartAsync>d__.<>4__this = this;
		<OnBeforeStartAsync>d__.<>1__state = -1;
		<OnBeforeStartAsync>d__.<>t__builder.Start<ShipTowerRewardItem.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
		return <OnBeforeStartAsync>d__.<>t__builder.Task;
	}

	// Token: 0x06015573 RID: 87411 RVA: 0x005EA010 File Offset: 0x005E8210
	public override void Refresh(ShipTowerRewardItemData data, bool isSelected, int gridIndex)
	{
		this.ItemData = data;
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.ShowTextNew(this.ItemData.TitleKey);
		}
		UUIButtonComponent button = base.GetButton(1);
		if (button != null)
		{
			UUIItem uuiitem = button.RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(this.ItemData.IsReceive);
			}
		}
		UUIText text2 = base.GetText(2);
		if (text2 != null)
		{
			text2.SetUIActive(this.ItemData.IsProgress);
		}
		UUISprite sprite = base.GetSprite(5);
		if (sprite != null)
		{
			sprite.SetUIActive(this.ItemData.IsCompleted);
		}
		UUISprite sprite2 = base.GetSprite(6);
		if (sprite2 != null)
		{
			sprite2.SetUIActive(this.ItemData.IsCompleted);
		}
		ButtonItem btnReceive = this.BtnReceive;
		if (btnReceive != null)
		{
			btnReceive.SetRedDotVisible(this.ItemData.IsReceive);
		}
		GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
		if (rewardLayout == null)
		{
			return;
		}
		rewardLayout.RefreshByData(this.ItemData.RewardList, null, false);
	}

	// Token: 0x06015574 RID: 87412 RVA: 0x005EA101 File Offset: 0x005E8301
	private void OnClickBtnReceive()
	{
		Action<ShipTowerRewardItemData> clickCallBack = this.ClickCallBack;
		if (clickCallBack == null)
		{
			return;
		}
		clickCallBack(this.ItemData);
	}

	// Token: 0x0400A465 RID: 42085
	private ShipTowerRewardItemData ItemData;

	// Token: 0x0400A466 RID: 42086
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

	// Token: 0x0400A467 RID: 42087
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<ShipTowerRewardItemData> ClickCallBack;

	// Token: 0x0400A468 RID: 42088
	[Nullable(2)]
	public ButtonItem BtnReceive;

	// Token: 0x02008D36 RID: 36150
	[NullableContext(0)]
	private static class EChildType
	{
		// Token: 0x0402F7DD RID: 194525
		public const int TextName = 0;

		// Token: 0x0402F7DE RID: 194526
		public const int BtnReceive = 1;

		// Token: 0x0402F7DF RID: 194527
		public const int TextProgress = 2;

		// Token: 0x0402F7E0 RID: 194528
		public const int HLayoutReward = 3;

		// Token: 0x0402F7E1 RID: 194529
		public const int ItemLock = 4;

		// Token: 0x0402F7E2 RID: 194530
		public const int SpriteMask = 5;

		// Token: 0x0402F7E3 RID: 194531
		public const int SpriteCompleted = 6;
	}
}
