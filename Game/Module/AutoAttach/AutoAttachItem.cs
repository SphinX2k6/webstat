using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.AutoAttach
{
	// Token: 0x02006158 RID: 24920
	public abstract class AutoAttachItem<[Nullable(2)] T> : UiPanelBase
	{
		// Token: 0x0603EF90 RID: 257936 RVA: 0x01024464 File Offset: 0x01022664
		[NullableContext(2)]
		public AutoAttachItem(AActor uiItem = null)
		{
			if (uiItem != null)
			{
				base.CreateThenShowByActor(uiItem, null);
			}
		}

		// Token: 0x0603EF91 RID: 257937 RVA: 0x01024477 File Offset: 0x01022677
		[NullableContext(1)]
		public void SetData(T[] dataArray)
		{
			this.AllData = dataArray;
		}

		// Token: 0x0603EF92 RID: 257938 RVA: 0x01024480 File Offset: 0x01022680
		public void SetIfNeedShowFakeItem(bool state)
		{
			this.IfNeedShowFakeItem = state;
		}

		// Token: 0x0603EF93 RID: 257939 RVA: 0x01024489 File Offset: 0x01022689
		[NullableContext(1)]
		public void SetSourceView(IAutoAttachBaseView<T> view)
		{
			this.SourceView = view;
			this.CurrentMoveDirection = this.SourceView.GetCurrentMoveDirection();
		}

		// Token: 0x0603EF94 RID: 257940 RVA: 0x010244A3 File Offset: 0x010226A3
		public void SetItemIndex(int index)
		{
			this.CreateIndex = index;
		}

		// Token: 0x0603EF95 RID: 257941 RVA: 0x010244AC File Offset: 0x010226AC
		public int GetItemIndex()
		{
			return this.CreateIndex;
		}

		// Token: 0x0603EF96 RID: 257942 RVA: 0x010244B4 File Offset: 0x010226B4
		public void InitItem()
		{
			this.TryInitSelectToggle();
			this.DataLength = this.SourceView.GetDataLength();
			if (this.CreateIndex < this.DataLength)
			{
				this.CurrentShowItemIndex = this.CreateIndex;
			}
			else
			{
				this.CurrentShowItemIndex = this.CreateIndex - this.SourceView.GetShowItemNum();
			}
			this.InitPosition();
		}

		// Token: 0x0603EF97 RID: 257943 RVA: 0x01024514 File Offset: 0x01022714
		private void InitPosition()
		{
			this.ResetPosition();
			if (this.SourceView != null)
			{
				int num = (int)Math.Floor((double)this.SourceView.GetShowItemNum() / 2.0);
				float itemSize = this.SourceView.GetItemSize();
				float gap = this.SourceView.GetGap();
				float offset;
				if (this.SourceView.GetIfCircle())
				{
					offset = (float)(this.CreateIndex - num) * (itemSize + gap);
				}
				else
				{
					EAttachDirection? currentMoveDirection = this.CurrentMoveDirection;
					EAttachDirection eattachDirection = EAttachDirection.Horizontal;
					if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
					{
						offset = (float)(this.CreateIndex - num) * (itemSize + gap);
					}
					else
					{
						offset = (float)(num - this.CreateIndex) * (itemSize + gap);
					}
				}
				this.MoveItem(offset);
			}
		}

		// Token: 0x0603EF98 RID: 257944 RVA: 0x010245CF File Offset: 0x010227CF
		private void ResetPosition()
		{
			this.RootItem.SetAnchorOffsetX(0f);
			this.RootItem.SetAnchorOffsetY(0f);
		}

		// Token: 0x0603EF99 RID: 257945 RVA: 0x010245F4 File Offset: 0x010227F4
		public void MoveItem(float offset)
		{
			int currentShowItemIndex = this.CurrentShowItemIndex;
			ValueTuple<float, int> moveOffsetFinalPositionAndShowIndex = this.GetMoveOffsetFinalPositionAndShowIndex(offset);
			this.CurrentShowItemIndex = moveOffsetFinalPositionAndShowIndex.Item2;
			EAttachDirection? currentMoveDirection = this.CurrentMoveDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
			{
				this.RootItem.SetAnchorOffsetX(moveOffsetFinalPositionAndShowIndex.Item1);
			}
			else
			{
				this.RootItem.SetAnchorOffsetY(moveOffsetFinalPositionAndShowIndex.Item1);
			}
			if (!this.SourceView.GetIfCircle() && !this.IfShowOverSizeItem)
			{
				bool uiactive = (this.CurrentShowItemIndex >= 0 && this.CurrentShowItemIndex < this.DataLength) || this.IfNeedShowFakeItem;
				this.RootItem.SetUIActive(uiactive);
			}
			if (currentShowItemIndex != this.CurrentShowItemIndex)
			{
				this.RefreshItem();
			}
			this.RefreshSelectToggleState();
			this.OnMoveItem();
		}

		// Token: 0x0603EF9A RID: 257946 RVA: 0x010246B8 File Offset: 0x010228B8
		public float GetCurrentMovePercentage()
		{
			float viewSize = this.SourceView.GetViewSize();
			return (this.GetCurrentPosition() + viewSize / 2f) / viewSize;
		}

		// Token: 0x0603EF9B RID: 257947 RVA: 0x010246E4 File Offset: 0x010228E4
		private ValueTuple<float, int> GetMoveOffsetFinalPositionAndShowIndex(float offset)
		{
			float checkPosition = this.GetCurrentPosition() + offset;
			if (this.SourceView.GetIfCircle())
			{
				return this.GetCircleMoveOffsetPositionAndShowIndex(checkPosition);
			}
			return this.GetNoCircleMoveOffsetPositionAndShowIndex(checkPosition);
		}

		// Token: 0x0603EF9C RID: 257948 RVA: 0x01024718 File Offset: 0x01022918
		private ValueTuple<float, int> GetCircleMoveOffsetPositionAndShowIndex(float checkPosition)
		{
			float num = checkPosition;
			int i = this.CurrentShowItemIndex;
			float itemSize = this.SourceView.GetItemSize();
			float gap = this.SourceView.GetGap();
			int showItemNum = this.SourceView.GetShowItemNum();
			if (!this.CheckIfInSizeOneBorder(num))
			{
				while (!this.CheckIfInSizeOneBorder(num))
				{
					num -= (itemSize + gap) * (float)Math.Ceiling((double)showItemNum + 1.0);
					i -= showItemNum + 1;
				}
				while (i < 0)
				{
					i = this.DataLength + i;
				}
			}
			else if (!this.CheckIfInSizeTwoBorder(num))
			{
				while (!this.CheckIfInSizeTwoBorder(num))
				{
					num += (itemSize + gap) * (float)Math.Ceiling((double)showItemNum + 1.0);
					i += showItemNum + 1;
				}
				while (i >= this.DataLength)
				{
					i -= this.DataLength;
				}
			}
			return new ValueTuple<float, int>(num, i);
		}

		// Token: 0x0603EF9D RID: 257949 RVA: 0x010247EC File Offset: 0x010229EC
		private ValueTuple<float, int> GetNoCircleMoveOffsetPositionAndShowIndex(float checkPosition)
		{
			float num = checkPosition;
			int num2 = this.CurrentShowItemIndex;
			float itemSize = this.SourceView.GetItemSize();
			float gap = this.SourceView.GetGap();
			int showItemNum = this.SourceView.GetShowItemNum();
			if (!this.CheckIfInSizeOneBorder(num))
			{
				while (!this.CheckIfInSizeOneBorder(num))
				{
					num -= (itemSize + gap) * (float)Math.Ceiling((double)showItemNum + 1.0);
					EAttachDirection? currentMoveDirection = this.CurrentMoveDirection;
					EAttachDirection eattachDirection = EAttachDirection.Horizontal;
					if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
					{
						num2 -= showItemNum + 1;
					}
					else
					{
						num2 += showItemNum + 1;
					}
				}
			}
			else if (!this.CheckIfInSizeTwoBorder(num))
			{
				while (!this.CheckIfInSizeTwoBorder(num))
				{
					num += (itemSize + gap) * (float)Math.Ceiling((double)showItemNum + 1.0);
					EAttachDirection? currentMoveDirection = this.CurrentMoveDirection;
					EAttachDirection eattachDirection = EAttachDirection.Horizontal;
					if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
					{
						num2 += showItemNum + 1;
					}
					else
					{
						num2 -= showItemNum + 1;
					}
				}
			}
			return new ValueTuple<float, int>(num, num2);
		}

		// Token: 0x0603EF9E RID: 257950 RVA: 0x010248EC File Offset: 0x01022AEC
		public int GetCurrentShowItemIndex()
		{
			return this.CurrentShowItemIndex;
		}

		// Token: 0x0603EF9F RID: 257951 RVA: 0x010248F4 File Offset: 0x01022AF4
		protected bool GetCurrentSelectedState()
		{
			return this.SourceView.GetCurrentSelectIndex() == this.GetCurrentShowItemIndex();
		}

		// Token: 0x0603EFA0 RID: 257952 RVA: 0x01024909 File Offset: 0x01022B09
		public bool GetSelectedState()
		{
			return this.SelectState;
		}

		// Token: 0x0603EFA1 RID: 257953 RVA: 0x01024911 File Offset: 0x01022B11
		public void Select()
		{
			if (!this.SelectState)
			{
				this.SelectState = true;
				this.RefreshSelectToggleState();
				this.OnSelect();
			}
		}

		// Token: 0x0603EFA2 RID: 257954 RVA: 0x0102492E File Offset: 0x01022B2E
		public void OnControllerDragStart()
		{
			this.DragState = true;
		}

		// Token: 0x0603EFA3 RID: 257955 RVA: 0x01024937 File Offset: 0x01022B37
		public void OnControllerDragEnd()
		{
			this.DragState = false;
		}

		// Token: 0x0603EFA4 RID: 257956 RVA: 0x01024940 File Offset: 0x01022B40
		public void ForceUnSelectItem()
		{
			this.SelectState = false;
			this.RefreshSelectToggleState();
			this.OnUnSelect();
		}

		// Token: 0x0603EFA5 RID: 257957 RVA: 0x01024955 File Offset: 0x01022B55
		[NullableContext(2)]
		protected virtual UUIExtendToggle GetSelectToggle()
		{
			return null;
		}

		// Token: 0x0603EFA6 RID: 257958 RVA: 0x01024958 File Offset: 0x01022B58
		protected virtual void OnSelectToggleClick()
		{
		}

		// Token: 0x0603EFA7 RID: 257959 RVA: 0x0102495A File Offset: 0x01022B5A
		private void TryInitSelectToggle()
		{
			if (this.SelectToggleInited)
			{
				return;
			}
			this.SelectToggleInited = true;
			this.SelectToggle = this.GetSelectToggle();
			UUIExtendToggle selectToggle = this.SelectToggle;
			if (selectToggle == null)
			{
				return;
			}
			selectToggle.OnStateChange.Add(new Action<EToggleState>(this.OnSelectToggleStateChange));
		}

		// Token: 0x0603EFA8 RID: 257960 RVA: 0x01024999 File Offset: 0x01022B99
		private void OnSelectToggleStateChange(EToggleState state)
		{
			this.RefreshSelectToggleState();
			this.OnSelectToggleClick();
		}

		// Token: 0x0603EFA9 RID: 257961 RVA: 0x010249A7 File Offset: 0x01022BA7
		private void RefreshSelectToggleState()
		{
			UUIExtendToggle selectToggle = this.SelectToggle;
			if (selectToggle == null)
			{
				return;
			}
			selectToggle.SetToggleStateForce(this.SelectState ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked, false, false, false);
		}

		// Token: 0x0603EFAA RID: 257962 RVA: 0x010249C8 File Offset: 0x01022BC8
		protected override void OnBeforeDestroyImplement()
		{
			base.OnBeforeDestroyImplement();
			UUIExtendToggle selectToggle = this.SelectToggle;
			if (selectToggle != null)
			{
				selectToggle.OnStateChange.Remove(new Action<EToggleState>(this.OnSelectToggleStateChange));
			}
			this.SelectToggle = null;
		}

		// Token: 0x0603EFAB RID: 257963 RVA: 0x010249FC File Offset: 0x01022BFC
		public float GetCurrentPosition()
		{
			EAttachDirection? currentMoveDirection = this.CurrentMoveDirection;
			EAttachDirection eattachDirection = EAttachDirection.Horizontal;
			if (currentMoveDirection.GetValueOrDefault() == eattachDirection & currentMoveDirection != null)
			{
				return this.RootItem.GetAnchorOffsetX();
			}
			return this.RootItem.GetAnchorOffsetY();
		}

		// Token: 0x0603EFAC RID: 257964 RVA: 0x01024A40 File Offset: 0x01022C40
		public void RefreshItem()
		{
			T data = default(T);
			bool flag = false;
			if (this.AllData != null && this.CurrentShowItemIndex >= 0 && this.CurrentShowItemIndex < this.AllData.Length)
			{
				data = this.AllData[this.CurrentShowItemIndex];
				flag = true;
			}
			if (!this.IfShowOverSizeItem && !flag)
			{
				if (this.IfNeedShowFakeItem)
				{
					this.OnRefreshItem(default(T));
				}
				return;
			}
			this.OnRefreshItem(data);
		}

		// Token: 0x0603EFAD RID: 257965
		[NullableContext(1)]
		protected abstract void OnRefreshItem(T data);

		// Token: 0x0603EFAE RID: 257966
		public abstract void OnSelect();

		// Token: 0x0603EFAF RID: 257967
		protected abstract void OnUnSelect();

		// Token: 0x0603EFB0 RID: 257968
		protected abstract void OnMoveItem();

		// Token: 0x0603EFB1 RID: 257969 RVA: 0x01024AB8 File Offset: 0x01022CB8
		private bool CheckIfInSizeOneBorder(float prePosition)
		{
			float itemSize = this.SourceView.GetItemSize();
			float gap = this.SourceView.GetGap();
			int showItemNum = this.SourceView.GetShowItemNum();
			float num = (itemSize + gap) * (float)Math.Ceiling((double)(showItemNum + 1) / 2.0) + this.SourceView.GetTrueBoundary();
			return prePosition <= num;
		}

		// Token: 0x0603EFB2 RID: 257970 RVA: 0x01024B14 File Offset: 0x01022D14
		private bool CheckIfInSizeTwoBorder(float prePosition)
		{
			float itemSize = this.SourceView.GetItemSize();
			float gap = this.SourceView.GetGap();
			int showItemNum = this.SourceView.GetShowItemNum();
			float num = -(itemSize + gap) * (float)Math.Ceiling((double)showItemNum / 2.0) - this.SourceView.GetTrueBoundary();
			return prePosition >= num;
		}

		// Token: 0x04023563 RID: 144739
		protected int CurrentShowItemIndex;

		// Token: 0x04023564 RID: 144740
		private int CreateIndex;

		// Token: 0x04023565 RID: 144741
		private int DataLength;

		// Token: 0x04023566 RID: 144742
		protected bool SelectState;

		// Token: 0x04023567 RID: 144743
		private readonly bool IfShowOverSizeItem;

		// Token: 0x04023568 RID: 144744
		private bool IfNeedShowFakeItem;

		// Token: 0x04023569 RID: 144745
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected IAutoAttachBaseView<T> SourceView;

		// Token: 0x0402356A RID: 144746
		protected EAttachDirection? CurrentMoveDirection;

		// Token: 0x0402356B RID: 144747
		[Nullable(new byte[]
		{
			2,
			1
		})]
		protected T[] AllData;

		// Token: 0x0402356C RID: 144748
		protected bool DragState;

		// Token: 0x0402356D RID: 144749
		[Nullable(2)]
		private UUIExtendToggle SelectToggle;

		// Token: 0x0402356E RID: 144750
		private bool SelectToggleInited;
	}
}
