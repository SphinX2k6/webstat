using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x0200168B RID: 5771
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WheelTowerSeasonScoreItem : GridProxyAbstract<IWheelTowerSeasonScoreData>
{
	// Token: 0x0600A10F RID: 41231 RVA: 0x002A40B0 File Offset: 0x002A22B0
	protected unsafe override void OnRegisterComponent()
	{
		int num = 3;
		List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
		CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
		Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
		int num2 = 0;
		*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
		num2++;
		*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
		this.ComponentRegisterInfos = list;
	}

	// Token: 0x0600A110 RID: 41232 RVA: 0x002A413C File Offset: 0x002A233C
	protected override void OnStart()
	{
		this.RewardItemGrid = new SmallItemGrid();
		this.RewardItemGrid.Initialize(base.GetItem(0).GetOwner());
		this.RewardItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
		this.RewardItemGrid.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
		{
			this.OnClickedGrid();
		});
	}

	// Token: 0x0600A111 RID: 41233 RVA: 0x002A41AC File Offset: 0x002A23AC
	[NullableContext(1)]
	public override void Refresh(IWheelTowerSeasonScoreData data, bool isSelected, int gridIndex)
	{
		this.DataInternal = data;
		UUIText text = base.GetText(2);
		if (text != null)
		{
			text.SetText(data.Score.ToString(), true);
		}
		List<TItem> dropPackagePreviewItemList = ConfigBase<RewardConfig>.Instance.GetDropPackagePreviewItemList(data.DropId);
		if (dropPackagePreviewItemList.Count <= 0)
		{
			return;
		}
		this.RewardItem = new TItem?(dropPackagePreviewItemList[0]);
		this.RefreshGrid();
		this.RefreshProgress();
	}

	// Token: 0x0600A112 RID: 41234 RVA: 0x002A421C File Offset: 0x002A241C
	private void RefreshProgress()
	{
		if (this.DataInternal == null)
		{
			return;
		}
		int num = this.DataInternal.Score - this.DataInternal.PrevScore;
		if (num <= 0)
		{
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount((this.DataInternal.CurScore >= this.DataInternal.Score) ? 1f : 0f);
			return;
		}
		else
		{
			float fillAmount = MathF.Min(MathF.Max((float)(this.DataInternal.CurScore - this.DataInternal.PrevScore), 0f) / (float)num, 1f);
			UUISprite sprite2 = base.GetSprite(1);
			if (sprite2 == null)
			{
				return;
			}
			sprite2.SetFillAmount(fillAmount);
			return;
		}
	}

	// Token: 0x0600A113 RID: 41235 RVA: 0x002A42C8 File Offset: 0x002A24C8
	private void RefreshGrid()
	{
		if (this.DataInternal == null || this.RewardItem == null || this.RewardItemGrid == null)
		{
			return;
		}
		bool lockBlackBigVisible = this.DataInternal.Score > this.DataInternal.CurScore;
		bool flag = this.DataInternal.Score <= this.DataInternal.CurScore;
		bool isReceived = this.DataInternal.IsReceived;
		this.RewardItemGrid.Apply<PropSmallItemGrid>(new PropSmallItemGrid
		{
			Data = this.DataInternal,
			ItemConfigId = new int?(this.RewardItem.Value.ItemData.ItemId),
			BottomText = this.RewardItem.Value.Count.ToString(),
			IsReceivableVisible = new bool?(flag && !isReceived),
			IsReceivedVisible = new bool?(isReceived),
			IsRedDotVisible = new bool?(flag && !isReceived)
		});
		this.RewardItemGrid.SetLockBlackBigVisible(lockBlackBigVisible);
	}

	// Token: 0x0600A114 RID: 41236 RVA: 0x002A43D0 File Offset: 0x002A25D0
	private void OnClickedGrid()
	{
		if (this.DataInternal == null || this.RewardItem == null)
		{
			return;
		}
		bool flag = this.DataInternal.Score > this.DataInternal.CurScore;
		bool flag2 = this.DataInternal.Score <= this.DataInternal.CurScore;
		bool isReceived = this.DataInternal.IsReceived;
		int motorPreviewId = this.DataInternal.MotorPreviewId;
		if (!isReceived && !flag)
		{
			if (flag2)
			{
				Action onClickToGet = this.OnClickToGet;
				if (onClickToGet == null)
				{
					return;
				}
				onClickToGet();
			}
			return;
		}
		if (motorPreviewId > 0)
		{
			ControllerBase<MotorcycleDiyController>.Instance.OpenMotorGeneralPreviewView(motorPreviewId);
			return;
		}
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItem.Value.ItemData.ItemId, true, null);
	}

	// Token: 0x04004AEC RID: 19180
	private IWheelTowerSeasonScoreData DataInternal;

	// Token: 0x04004AED RID: 19181
	private SmallItemGrid RewardItemGrid;

	// Token: 0x04004AEE RID: 19182
	private TItem? RewardItem;

	// Token: 0x04004AEF RID: 19183
	public Action OnClickToGet;
}
