using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.AutoAttach;
using UnrealEngine;

// Token: 0x020017A4 RID: 6052
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1,
	1
})]
public class NoCircleAttachView<[Nullable(2)] T, [Nullable(0)] TAttachItem> : AutoAttachBaseView<T, TAttachItem> where TAttachItem : AutoAttachItem<T>
{
	// Token: 0x0600AAC1 RID: 43713 RVA: 0x002D99B1 File Offset: 0x002D7BB1
	public NoCircleAttachView(AActor controllerActor, bool isNeedScrollCallback = false) : base(controllerActor, isNeedScrollCallback)
	{
	}

	// Token: 0x0600AAC2 RID: 43714 RVA: 0x002D99C6 File Offset: 0x002D7BC6
	public void SetIfNeedFakeItem(bool state)
	{
		this.NeedFakeShowItem = state;
	}

	// Token: 0x0600AAC3 RID: 43715 RVA: 0x002D99CF File Offset: 0x002D7BCF
	public void SetControllerItem(UUIItem controllerItem)
	{
		this.ControllerItem = controllerItem;
		this.ControllerWidth = controllerItem.GetWidth();
		this.ControllerHeight = controllerItem.GetHeight();
	}

	// Token: 0x0600AAC4 RID: 43716 RVA: 0x002D99F0 File Offset: 0x002D7BF0
	public override TAttachItem FindAutoAttachItem()
	{
		return this.FindNoCircleAttachItem();
	}

	// Token: 0x0600AAC5 RID: 43717 RVA: 0x002D99F8 File Offset: 0x002D7BF8
	private TAttachItem FindNoCircleAttachItem()
	{
		TAttachItem tattachItem = default(TAttachItem);
		float num = 10000000f;
		int count = this.Items.Count;
		for (int i = 0; i < count; i++)
		{
			float num2 = Math.Abs(this.Items[i].GetCurrentPosition());
			bool flag = this.Items[i].GetCurrentShowItemIndex() >= 0 && this.Items[i].GetCurrentShowItemIndex() < this.DataLength;
			if (num2 < num && flag)
			{
				tattachItem = this.Items[i];
				num = num2;
			}
		}
		if (tattachItem == null)
		{
			tattachItem = this.Items[0];
		}
		return tattachItem;
	}

	// Token: 0x0600AAC6 RID: 43718 RVA: 0x002D9AB4 File Offset: 0x002D7CB4
	public override float GetTrueBoundary()
	{
		if (this.ReCalculateBoundary == null)
		{
			float num = 0f;
			for (float num2 = 0f; num2 < 1f; num2 += 0.01f)
			{
				float curveValue = base.GetCurveValue(this.BoundaryCurve, num2);
				num += 0.01f * curveValue * this.MoveBoundary;
			}
			this.ReCalculateBoundary = new float?(num);
		}
		return this.ReCalculateBoundary.Value;
	}

	// Token: 0x0600AAC7 RID: 43719 RVA: 0x002D9B24 File Offset: 0x002D7D24
	protected override float RecalculateMoveOffset(float offset)
	{
		float num = this.CalculateOffset(offset);
		EAttachDirection? attachDirection = this.AttachDirection;
		EAttachDirection eattachDirection = EAttachDirection.Horizontal;
		if (attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null)
		{
			if (!this.CheckInHorizontalBounds(num))
			{
				return 0f;
			}
		}
		else if (!this.CheckInVerticalBounds(num))
		{
			return 0f;
		}
		return num;
	}

	// Token: 0x0600AAC8 RID: 43720 RVA: 0x002D9B78 File Offset: 0x002D7D78
	private float GetNearestMiddleItemToBoundaryOffset(float offset)
	{
		TAttachItem tattachItem = base.FindNearestMiddleItem();
		float currentPosition = tattachItem.GetCurrentPosition();
		float result;
		if (offset > 0f)
		{
			EAttachDirection? currentMoveDirection = base.GetCurrentMoveDirection();
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
			{
				result = (float)tattachItem.GetCurrentShowItemIndex() * (base.GetItemSize() + this.Gap) + currentPosition;
			}
			else
			{
				int num = this.DataLength - 1 - tattachItem.GetCurrentShowItemIndex();
				result = -1f * ((float)num * (base.GetItemSize() + this.Gap)) + currentPosition;
			}
		}
		else
		{
			EAttachDirection? currentMoveDirection = base.GetCurrentMoveDirection();
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
			{
				int num2 = this.DataLength - 1 - tattachItem.GetCurrentShowItemIndex();
				result = -1f * ((float)num2 * (base.GetItemSize() + this.Gap)) + currentPosition;
			}
			else
			{
				result = (float)tattachItem.GetCurrentShowItemIndex() * (base.GetItemSize() + this.Gap) + currentPosition;
			}
		}
		return result;
	}

	// Token: 0x0600AAC9 RID: 43721 RVA: 0x002D9C88 File Offset: 0x002D7E88
	private float CalculateOffset(float offset)
	{
		int showIndex = (offset > 0f) ? 0 : (this.DataLength - 1);
		EAttachDirection? attachDirection = this.AttachDirection;
		EAttachDirection eattachDirection = EAttachDirection.Horizontal;
		if (!(attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null))
		{
			showIndex = ((offset > 0f) ? (this.DataLength - 1) : 0);
		}
		TAttachItem showIndexItem = base.GetShowIndexItem(showIndex);
		if (showIndexItem != null)
		{
			float num = showIndexItem.GetCurrentPosition();
			if (-0.01f < num && num < 0.01f)
			{
				num = 0f;
			}
			float num2 = num + offset;
			attachDirection = this.AttachDirection;
			eattachDirection = EAttachDirection.Horizontal;
			if (!(attachDirection.GetValueOrDefault() == eattachDirection & attachDirection != null))
			{
				num2 = num - offset;
			}
			if (offset > 0f)
			{
				if (num2 < 0f)
				{
					return offset;
				}
			}
			else if (num2 > 0f)
			{
				return offset;
			}
			return this.CalculateDecreaseOffset(offset, num);
		}
		float nearestMiddleItemToBoundaryOffset = this.GetNearestMiddleItemToBoundaryOffset(offset);
		if (Math.Abs(nearestMiddleItemToBoundaryOffset) < Math.Abs(offset))
		{
			return nearestMiddleItemToBoundaryOffset;
		}
		return offset;
	}

	// Token: 0x0600AACA RID: 43722 RVA: 0x002D9D78 File Offset: 0x002D7F78
	private float CalculateDecreaseOffset(float offset, float currentZeroItemPosition)
	{
		float num = 0f;
		if (offset > 0f)
		{
			if (currentZeroItemPosition < 0f)
			{
				num = 0f - currentZeroItemPosition;
			}
		}
		else if (currentZeroItemPosition > 0f)
		{
			num = 0f - currentZeroItemPosition;
		}
		float num2 = 0f + num;
		float num3 = offset - num2;
		float num4 = this.CalculateDecreaseFactor(offset, currentZeroItemPosition);
		float num5 = num2 + num3 * num4;
		float num6 = currentZeroItemPosition + num5;
		if (offset > 0f)
		{
			if (num6 >= this.GetMoveDistance())
			{
				num2 = ((num > 0f) ? (num + this.GetMoveDistance()) : (this.GetMoveDistance() - currentZeroItemPosition));
			}
			else
			{
				num2 = num5;
			}
		}
		else if (num6 <= -1f * this.GetMoveDistance())
		{
			num2 = ((num < 0f) ? (num + -1f * this.GetMoveDistance()) : (-1f * (this.GetMoveDistance() + currentZeroItemPosition)));
		}
		else
		{
			num2 = num5;
		}
		return num2;
	}

	// Token: 0x0600AACB RID: 43723 RVA: 0x002D9E50 File Offset: 0x002D8050
	private float GetMoveDistance()
	{
		if (this.MoveDistance == null)
		{
			int num = 1;
			float num2 = 0f;
			int num3 = 0;
			while ((float)num3 < this.MoveBoundary)
			{
				float num4 = this.CalculateDecreaseFactor((float)num, (float)num3);
				num2 += (float)num * num4;
				num3 += num;
			}
			this.MoveDistance = new float?(num2);
		}
		return this.MoveDistance.Value;
	}

	// Token: 0x0600AACC RID: 43724 RVA: 0x002D9EB0 File Offset: 0x002D80B0
	private float CalculateDecreaseFactor(float offset, float currentZeroItemPosition)
	{
		if (this.GetTrueBoundary() <= 0f)
		{
			return 0f;
		}
		float num = Math.Abs(currentZeroItemPosition) / this.GetTrueBoundary();
		num = ((num > 1f) ? 1f : num);
		return base.GetCurveValue(this.BoundaryCurve, num);
	}

	// Token: 0x0600AACD RID: 43725 RVA: 0x002D9EFC File Offset: 0x002D80FC
	private bool CheckInHorizontalBounds(float offset)
	{
		TAttachItem tattachItem = default(TAttachItem);
		int count = this.Items.Count;
		for (int i = 0; i < count - 1; i++)
		{
			if (this.Items[i].GetCurrentShowItemIndex() == 0)
			{
				tattachItem = this.Items[i];
				break;
			}
		}
		if (tattachItem != null && offset > 0f)
		{
			float value = tattachItem.GetCurrentPosition() + offset;
			float value2 = Math.Abs(tattachItem.GetCurrentPosition()) + this.GetTrueBoundary();
			if (Math.Abs(value) > Math.Abs(value2))
			{
				return false;
			}
		}
		else if (offset < 0f)
		{
			for (int j = 0; j < count; j++)
			{
				if (this.Items[j].GetCurrentShowItemIndex() == this.DataLength - 1)
				{
					float num = this.Items[j].GetCurrentPosition() + offset;
					float num2 = 0f - this.Items[j].GetCurrentPosition() - this.GetTrueBoundary();
					if (num < num2)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0600AACE RID: 43726 RVA: 0x002DA028 File Offset: 0x002D8228
	private bool CheckInVerticalBounds(float offset)
	{
		TAttachItem tattachItem = default(TAttachItem);
		int count = this.Items.Count;
		for (int i = 0; i < count - 1; i++)
		{
			if (this.Items[i].GetCurrentShowItemIndex() == 0)
			{
				tattachItem = this.Items[i];
				break;
			}
		}
		if (offset > 0f)
		{
			for (int j = 0; j < count; j++)
			{
				if (this.Items[j].GetCurrentShowItemIndex() == this.DataLength - 1)
				{
					float num = this.Items[j].GetCurrentPosition() + offset;
					float num2 = 0f - this.Items[j].GetCurrentPosition() + this.GetTrueBoundary();
					if (num > num2)
					{
						return false;
					}
				}
			}
		}
		else if (tattachItem != null && offset < 0f)
		{
			float value = tattachItem.GetCurrentPosition() + offset;
			float value2 = tattachItem.GetCurrentPosition() + this.GetTrueBoundary();
			if (Math.Abs(value) > Math.Abs(value2))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x0600AACF RID: 43727 RVA: 0x002DA14C File Offset: 0x002D834C
	[NullableContext(2)]
	protected override TAttachItem FindNextDirectionItem(int direction)
	{
		int currentShowItemIndex = base.FindNearestMiddleItem().GetCurrentShowItemIndex();
		int showIndex;
		if (direction > 0)
		{
			if (currentShowItemIndex + direction < this.DataLength)
			{
				showIndex = currentShowItemIndex + direction;
			}
			else
			{
				showIndex = this.DataLength - 1;
			}
		}
		else if (currentShowItemIndex + direction > 0)
		{
			showIndex = currentShowItemIndex + direction;
		}
		else
		{
			showIndex = 0;
		}
		return base.GetShowIndexItem(showIndex);
	}

	// Token: 0x0600AAD0 RID: 43728 RVA: 0x002DA1A4 File Offset: 0x002D83A4
	protected override void ReloadItems(int showItemNum, T[] data, int attachTo = 0)
	{
		int num = (showItemNum > this.ShowItemNum || this.NeedFakeShowItem) ? (this.ShowItemNum + 1) : showItemNum;
		for (int i = showItemNum; i < this.AllItemList.Count; i++)
		{
			this.AllItemList[i].SetUiActive(false);
		}
		this.Items = new List<TAttachItem>();
		for (int j = 0; j < num; j++)
		{
			if (j >= this.AllItemList.Count)
			{
				AActor arg = Singleton<LguiUtil>.Instance.DuplicateActor(this.SourceActor as AUIBaseActor, this.ControllerItem);
				TAttachItem tattachItem = this.CreateItemFunction(arg, j, this.ShowItemNum);
				tattachItem.SetSourceView(this);
				this.Items.Add(tattachItem);
				this.AllItemList.Add(tattachItem);
			}
			else
			{
				this.Items.Add(this.AllItemList[j]);
			}
			this.Items[j].SetIfNeedShowFakeItem(this.NeedFakeShowItem);
			this.Items[j].SetItemIndex(j);
			this.Items[j].SetUiActive(true);
			this.Items[j].SetData(data);
			this.Items[j].InitItem();
		}
		base.RefreshItems();
		base.ForceUnSelectItems();
		base.AttachToIndex(attachTo, true);
	}

	// Token: 0x0600AAD1 RID: 43729 RVA: 0x002DA324 File Offset: 0x002D8524
	public override bool GetIfCircle()
	{
		return false;
	}

	// Token: 0x0600AAD2 RID: 43730 RVA: 0x002DA327 File Offset: 0x002D8527
	public void SetShowItemNum(int showItemNum)
	{
		this.ShowItemNum = showItemNum;
	}

	// Token: 0x04005135 RID: 20789
	private const float FLOATDURABLENUM = 0.01f;

	// Token: 0x04005136 RID: 20790
	private float? ReCalculateBoundary;

	// Token: 0x04005137 RID: 20791
	private float? MoveDistance;

	// Token: 0x04005138 RID: 20792
	private bool NeedFakeShowItem;

	// Token: 0x04005139 RID: 20793
	private readonly List<TAttachItem> AllItemList = new List<TAttachItem>();
}
