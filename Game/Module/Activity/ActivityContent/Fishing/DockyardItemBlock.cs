using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B3 RID: 26547
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardItemBlock : UiPanelBase
	{
		// Token: 0x0604235D RID: 271197 RVA: 0x010FC100 File Offset: 0x010FA300
		public DockyardItemBlock(DockyardItemBlockData data)
		{
			this.Data = data;
		}

		// Token: 0x0604235E RID: 271198 RVA: 0x010FC1C4 File Offset: 0x010FA3C4
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as IDockyardGridInterface);
			int num = 5;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUITexture));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0604235F RID: 271199 RVA: 0x010FC2A4 File Offset: 0x010FA4A4
		private UniTask InitLayout()
		{
			DockyardItemBlock.<InitLayout>d__27 <InitLayout>d__;
			<InitLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLayout>d__.<>4__this = this;
			<InitLayout>d__.<>1__state = -1;
			<InitLayout>d__.<>t__builder.Start<DockyardItemBlock.<InitLayout>d__27>(ref <InitLayout>d__);
			return <InitLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06042360 RID: 271200 RVA: 0x010FC2E8 File Offset: 0x010FA4E8
		private void InitGridItem()
		{
			UUIItem item = base.GetItem(2);
			this.GridWidth = item.Width;
		}

		// Token: 0x06042361 RID: 271201 RVA: 0x010FC30C File Offset: 0x010FA50C
		private void InitLayoutWidth()
		{
			TWeakObjectPtr<UUIItem> rootUIComp = base.GetLayoutBase(1).RootUIComp;
			List<List<int>> posDoublyList = this.Data.Data.PosDoublyList;
			int count = posDoublyList[0].Count;
			int count2 = posDoublyList.Count;
			rootUIComp.Get().SetWidth((float)count * this.GridWidth);
			this.BlockWidth = this.GridWidth * (float)count;
			this.BlockHeight = this.GridWidth * (float)count2;
		}

		// Token: 0x06042362 RID: 271202 RVA: 0x010FC37C File Offset: 0x010FA57C
		private void InitSelectItemSize()
		{
			UUIItem item = base.GetItem(0);
			List<List<int>> validDoublyList = this.Data.Data.ValidDoublyList;
			int count = validDoublyList[0].Count;
			float count2 = (float)validDoublyList.Count;
			float num = (float)(count - 1) * this.GridWidth;
			float num2 = (count2 - (float)1) * this.GridWidth;
			item.SetWidth(item.Width + num);
			item.SetHeight(item.Height + num2);
			FVector2D anchorOffset = item.GetAnchorOffset();
			IPanelPos validStartPos = this.Data.Data.ValidStartPos;
			item.SetAnchorOffset(new FVector2D(anchorOffset.X + (float)validStartPos.ColIndex * this.GridWidth + num * 1f / 2f, anchorOffset.Y - (float)validStartPos.RowIndex * this.GridWidth - num2 * 1f / 2f));
		}

		// Token: 0x06042363 RID: 271203 RVA: 0x010FC450 File Offset: 0x010FA650
		private void InitRootItemPivot()
		{
			Vector2D originalPivot = this.Data.GetOriginalPivot();
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetPivot(originalPivot.ToUeVector2D(false));
		}

		// Token: 0x06042364 RID: 271204 RVA: 0x010FC480 File Offset: 0x010FA680
		private UniTask InitTexture(UUITexture texture)
		{
			DockyardItemBlock.<InitTexture>d__32 <InitTexture>d__;
			<InitTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTexture>d__.<>4__this = this;
			<InitTexture>d__.texture = texture;
			<InitTexture>d__.<>1__state = -1;
			<InitTexture>d__.<>t__builder.Start<DockyardItemBlock.<InitTexture>d__32>(ref <InitTexture>d__);
			return <InitTexture>d__.<>t__builder.Task;
		}

		// Token: 0x06042365 RID: 271205 RVA: 0x010FC4CC File Offset: 0x010FA6CC
		private void InitOther()
		{
			this.SequencePlayer = new UiSequencePlayer(this.RootItem);
			Transform itemWorldTrans = this.ItemWorldTrans;
			FTransform ftransform = this.ParentUiItem.K2_GetComponentToWorld();
			itemWorldTrans.FromUeTransform(ftransform);
			base.GetItem(0).SetUIActive(false);
			this.SetTextureMaterialActive(false);
		}

		// Token: 0x06042366 RID: 271206 RVA: 0x010FC518 File Offset: 0x010FA718
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardItemBlock.<OnBeforeStartAsync>d__34 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardItemBlock.<OnBeforeStartAsync>d__34>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042367 RID: 271207 RVA: 0x010FC55B File Offset: 0x010FA75B
		protected override void OnStart()
		{
			this.RefreshBlockRotate();
		}

		// Token: 0x06042368 RID: 271208 RVA: 0x010FC563 File Offset: 0x010FA763
		protected override void OnBeforeDestroy()
		{
			this.SequencePlayer.Clear();
		}

		// Token: 0x06042369 RID: 271209 RVA: 0x010FC570 File Offset: 0x010FA770
		private DockyardItemBlockGrid InitItem()
		{
			return new DockyardItemBlockGrid
			{
				OpenParam = this
			};
		}

		// Token: 0x0604236A RID: 271210 RVA: 0x010FC580 File Offset: 0x010FA780
		private void RecordLeftTopWorldPos()
		{
			this.Data.RefreshLeftTopPosInBackpack(this.TempAnchorOffset, this.BlockWidth, this.BlockHeight, this.GridWidth);
			Vector2D leftTopAnchorOffset = this.Data.LeftTopAnchorOffset;
			this.TempLeftTopWorldPos.Set(leftTopAnchorOffset.X, leftTopAnchorOffset.Y, 0.0);
			this.ItemWorldTrans.TransformPosition(this.TempLeftTopWorldPos, this.TempLeftTopWorldPos);
		}

		// Token: 0x0604236B RID: 271211 RVA: 0x010FC5F4 File Offset: 0x010FA7F4
		private void RefreshTempPanelData(UUIItem panel)
		{
			if (this.TempPanel != panel)
			{
				Transform tempAttachItemWorldTrans = this.TempAttachItemWorldTrans;
				FTransform ftransform = panel.K2_GetComponentToWorld();
				tempAttachItemWorldTrans.FromUeTransform(ftransform);
				FVector2D pivot = panel.GetPivot();
				this.TempSize.Set((double)panel.Width, (double)panel.Height);
				this.TempOffset.Set((double)pivot.X * this.TempSize.X, (double)(1f - pivot.Y) * this.TempSize.Y);
				this.TempPanel = panel;
			}
		}

		// Token: 0x0604236C RID: 271212 RVA: 0x010FC67C File Offset: 0x010FA87C
		private Vector2D GetPivotToTopLeftOffset()
		{
			Vector2D topLeftOffsetByRotate = this.Data.GetTopLeftOffsetByRotate();
			if (this.Data.IsInUpOrDown())
			{
				topLeftOffsetByRotate.X *= (double)this.BlockWidth;
				topLeftOffsetByRotate.Y *= (double)this.BlockHeight;
			}
			else
			{
				topLeftOffsetByRotate.X *= (double)this.BlockHeight;
				topLeftOffsetByRotate.Y *= (double)this.BlockWidth;
			}
			return topLeftOffsetByRotate;
		}

		// Token: 0x0604236D RID: 271213 RVA: 0x010FC6F8 File Offset: 0x010FA8F8
		public void OnPointerDown(ULGUIPointerEventData eventData)
		{
			bool flag = this.ParentModel.DragBegin(this.Data.Data.IncId);
			this.RecordLeftTopWorldPos();
			if (this.ParentModel.CanDrag(this.Data.Data.IncId))
			{
				FVector pointerPosition = eventData.pointerPosition;
				Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, this.LastDragPos);
				IDockyardGridInterface parentModel = this.ParentModel;
				if (parentModel != null)
				{
					parentModel.OnItemBlockClick(this.Data.Data.IncId);
				}
			}
			if (flag)
			{
				this.PlaySelectSequence("Grab");
			}
		}

		// Token: 0x0604236E RID: 271214 RVA: 0x010FC789 File Offset: 0x010FA989
		public void OnPointerUp(ULGUIPointerEventData eventData)
		{
			if (this.ParentModel.DragEnd(this.Data.Data.IncId))
			{
				this.PlaySelectSequence("Drop");
			}
		}

		// Token: 0x0604236F RID: 271215 RVA: 0x010FC7B3 File Offset: 0x010FA9B3
		public void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (this.ParentModel.DragBegin(this.Data.Data.IncId))
			{
				this.PlaySelectSequence("Grab");
			}
			this.RecordLeftTopWorldPos();
		}

		// Token: 0x06042370 RID: 271216 RVA: 0x010FC7E4 File Offset: 0x010FA9E4
		public void OnDrag(ULGUIPointerEventData eventData)
		{
			if (this.ParentModel.CanDrag(this.Data.Data.IncId))
			{
				FVector pointerPosition = eventData.pointerPosition;
				Vector2D vector2D = Vector2D.Create();
				Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiPosition(pointerPosition, vector2D);
				double num = vector2D.X - this.LastDragPos.X;
				double num2 = vector2D.Y - this.LastDragPos.Y;
				Vector2D vector2D2 = Vector2D.Create(vector2D.X, vector2D.Y).SubtractionEqual(this.LastDragPos);
				if (vector2D2.X == 0.0 && vector2D2.Y == 0.0)
				{
					return;
				}
				this.TempAnchorOffset.FromUeVector2D(this.RootItem.GetAnchorOffset());
				this.TempAnchorOffset.X += num;
				this.TempAnchorOffset.Y += num2;
				UUIItem rootItem = this.RootItem;
				if (rootItem != null)
				{
					rootItem.SetAnchorOffset(this.TempAnchorOffset.ToUeVector2D(false));
				}
				this.LastDragPos.DeepCopy(vector2D);
				this.RecordLeftTopWorldPos();
			}
		}

		// Token: 0x06042371 RID: 271217 RVA: 0x010FC903 File Offset: 0x010FAB03
		public void OnDragEnd(ULGUIPointerEventData eventData)
		{
			if (this.ParentModel.DragEnd(this.Data.Data.IncId))
			{
				this.PlaySelectSequence("Drop");
			}
		}

		// Token: 0x06042372 RID: 271218 RVA: 0x010FC930 File Offset: 0x010FAB30
		public void SetAnchorOffset(double offsetX, double offsetY)
		{
			this.TempAnchorOffset.Set(offsetX, offsetY);
			UUIItem rootItem = this.RootItem;
			if (rootItem != null)
			{
				rootItem.SetAnchorOffset(this.TempAnchorOffset.ToUeVector2D(false));
			}
			this.ResetAnchorOffset.DeepCopy(this.TempAnchorOffset);
			this.RecordLeftTopWorldPos();
		}

		// Token: 0x06042373 RID: 271219 RVA: 0x010FC980 File Offset: 0x010FAB80
		public void SetAnchorOffsetByEventDataPointerPosition(FVector pointerPosition)
		{
			Singleton<LguiUtil>.Instance.ConvertPointerPositionToLguiCenterPosition(pointerPosition, this.TempLguiCenterPos);
			this.TempPointerPosition.Set(this.TempLguiCenterPos.X, 0.0, this.TempLguiCenterPos.Y);
			UUIItem rootItem = this.RootItem;
			FVector fvector = this.TempPointerPosition.ToUeVectorOld();
			rootItem.SetUIWorldLocation(fvector);
			FVector2D anchorOffset = this.RootItem.GetAnchorOffset();
			this.TempAnchorOffset.Set((double)anchorOffset.X, (double)anchorOffset.Y);
			this.ResetAnchorOffset.DeepCopy(this.TempAnchorOffset);
			this.RecordLeftTopWorldPos();
		}

		// Token: 0x06042374 RID: 271220 RVA: 0x010FCA20 File Offset: 0x010FAC20
		public void InitAnchorOffset(float gridWidth, float gridHeight, int startRowIndex, int startColIndex)
		{
			Vector2D centerPosInBackpack = this.Data.GetCenterPosInBackpack(startRowIndex, startColIndex);
			this.SetAnchorOffset((double)gridWidth * centerPosInBackpack.X, (double)gridHeight * centerPosInBackpack.Y * -1.0);
		}

		// Token: 0x06042375 RID: 271221 RVA: 0x010FCA5E File Offset: 0x010FAC5E
		public void RotateBlock()
		{
			this.Data.RotateData();
			this.RefreshBlockRotate();
		}

		// Token: 0x06042376 RID: 271222 RVA: 0x010FCA74 File Offset: 0x010FAC74
		private void RefreshBlockRotate()
		{
			float rotateValue = this.Data.GetRotateValue();
			this.TempRotator.Yaw = rotateValue;
			UUIItem rootItem = this.RootItem;
			FRotator frotator = this.TempRotator.ToUeRotator();
			rootItem.SetUIRelativeRotation(frotator);
		}

		// Token: 0x06042377 RID: 271223 RVA: 0x010FCAB4 File Offset: 0x010FACB4
		private void RefreshGridDragActive(bool value)
		{
			foreach (DockyardItemBlockGrid dockyardItemBlockGrid in this.Layout.GetLayoutItemList())
			{
				dockyardItemBlockGrid.RefreshDragItemActive(value);
			}
		}

		// Token: 0x06042378 RID: 271224 RVA: 0x010FCB0C File Offset: 0x010FAD0C
		private void SetTextureMaterialActive(bool value)
		{
			if (value)
			{
				base.GetTexture(3).SetCustomMaterialScalarParameter(this.MaterialOffsetName, 0.012f);
				return;
			}
			base.GetTexture(3).SetCustomMaterialScalarParameter(this.MaterialOffsetName, -1f);
		}

		// Token: 0x06042379 RID: 271225 RVA: 0x010FCB40 File Offset: 0x010FAD40
		public void PlaySelectSequence(string sequenceName)
		{
			this.SequencePlayer.StopPrevSequence(false, true);
			this.SequencePlayer.PlaySequencePurely(sequenceName, false, false);
		}

		// Token: 0x0604237A RID: 271226 RVA: 0x010FCB5D File Offset: 0x010FAD5D
		public void SetItemBlockSelectState(bool value)
		{
			base.GetItem(0).SetUIActive(value);
			this.RefreshGridDragActive(value);
			this.SetTextureMaterialActive(value);
		}

		// Token: 0x0604237B RID: 271227 RVA: 0x010FCB7C File Offset: 0x010FAD7C
		public void SetUiParent(UUIItem parentItem)
		{
			if (this.ParentUiItem == parentItem)
			{
				return;
			}
			this.ParentUiItem = parentItem;
			this.GetOriginalItem().SetUIParent(parentItem, true);
			Transform itemWorldTrans = this.ItemWorldTrans;
			FTransform ftransform = parentItem.K2_GetComponentToWorld();
			itemWorldTrans.FromUeTransform(ftransform);
		}

		// Token: 0x0604237C RID: 271228 RVA: 0x010FCBBB File Offset: 0x010FADBB
		public IPanelPosRange GetLeftTopPosRangeByOffset(Vector2D leftTopOffset)
		{
			return this.Data.GetLeftTopPosRangeByLeftTopPos(leftTopOffset, this.GridWidth);
		}

		// Token: 0x0604237D RID: 271229 RVA: 0x010FCBCF File Offset: 0x010FADCF
		public bool IsValidGridPos(int rowIndex, int colIndex)
		{
			return this.Data.IsValidGridPos(rowIndex, colIndex);
		}

		// Token: 0x0604237E RID: 271230 RVA: 0x010FCBE0 File Offset: 0x010FADE0
		public void ResetToAppropriatePos(int panelRowCount, int panelColCount, UUIItem attachItem)
		{
			IPanelPosRange leftTopPosRangeByPanel = this.GetLeftTopPosRangeByPanel(attachItem);
			int targetRowIndex;
			if (leftTopPosRangeByPanel.RowEndIndex >= panelRowCount)
			{
				targetRowIndex = leftTopPosRangeByPanel.RowStartIndex - (leftTopPosRangeByPanel.RowEndIndex - panelRowCount);
			}
			else
			{
				targetRowIndex = ((leftTopPosRangeByPanel.RowStartIndex >= 0) ? leftTopPosRangeByPanel.RowStartIndex : 0);
			}
			int targetColIndex;
			if (leftTopPosRangeByPanel.ColEndIndex >= panelColCount)
			{
				targetColIndex = leftTopPosRangeByPanel.ColStartIndex - (leftTopPosRangeByPanel.ColEndIndex - panelColCount);
			}
			else
			{
				targetColIndex = ((leftTopPosRangeByPanel.ColStartIndex >= 0) ? leftTopPosRangeByPanel.ColStartIndex : 0);
			}
			this.AdsorbToAppropriatePosByAttachItem(targetRowIndex, targetColIndex, attachItem);
		}

		// Token: 0x0604237F RID: 271231 RVA: 0x010FCC60 File Offset: 0x010FAE60
		public void AdsorbToAppropriatePosByAttachItem(int targetRowIndex, int targetColIndex, UUIItem attachItem)
		{
			float num = this.GridWidth * (float)targetColIndex;
			float num2 = this.GridWidth * (float)targetRowIndex;
			Vector2D pivotToTopLeftOffset = this.GetPivotToTopLeftOffset();
			FVector2D pivot = attachItem.GetPivot();
			this.TempPivotWorldPos.Set((double)(num - pivot.X * attachItem.Width) - pivotToTopLeftOffset.X, (double)(-(double)num2 - (1f - pivot.Y) * attachItem.Height) - pivotToTopLeftOffset.Y, 0.0);
			Transform tempAttachItemWorldTrans = this.TempAttachItemWorldTrans;
			FTransform ftransform = attachItem.K2_GetComponentToWorld();
			tempAttachItemWorldTrans.FromUeTransform(ftransform);
			this.TempAttachItemWorldTrans.TransformPosition(this.TempPivotWorldPos, this.TempPivotWorldPos);
			UUIItem rootItem = this.RootItem;
			FVector fvector = this.TempPivotWorldPos.ToUeVectorOld();
			rootItem.SetUIWorldLocation(fvector);
			FVector2D anchorOffset = this.RootItem.GetAnchorOffset();
			this.TempAnchorOffset.Set((double)anchorOffset.X, (double)anchorOffset.Y);
			this.ResetAnchorOffset.DeepCopy(this.TempAnchorOffset);
		}

		// Token: 0x06042380 RID: 271232 RVA: 0x010FCD57 File Offset: 0x010FAF57
		public int GetUniqueId()
		{
			return this.Data.Data.IncId;
		}

		// Token: 0x06042381 RID: 271233 RVA: 0x010FCD69 File Offset: 0x010FAF69
		public int GetItemId()
		{
			return this.Data.Data.ItemId;
		}

		// Token: 0x06042382 RID: 271234 RVA: 0x010FCD7B File Offset: 0x010FAF7B
		public DockyardItemBlockData GetData()
		{
			return this.Data;
		}

		// Token: 0x06042383 RID: 271235 RVA: 0x010FCD83 File Offset: 0x010FAF83
		public void SetHierarchyIndex(int hierarchyIndex)
		{
			this.RootItem.SetHierarchyIndex(hierarchyIndex);
		}

		// Token: 0x06042384 RID: 271236 RVA: 0x010FCD94 File Offset: 0x010FAF94
		public bool IsRangeChange(IPanelPosRange lastLeftTopPos, IPanelPosRange leftTopPos)
		{
			return lastLeftTopPos.RowStartIndex != leftTopPos.RowStartIndex || lastLeftTopPos.RowEndIndex != leftTopPos.RowEndIndex || lastLeftTopPos.ColStartIndex != leftTopPos.ColStartIndex || lastLeftTopPos.ColEndIndex != leftTopPos.ColEndIndex;
		}

		// Token: 0x06042385 RID: 271237 RVA: 0x010FCDE4 File Offset: 0x010FAFE4
		public bool IsPartOutOfRange(IPanelPosRange pos, int panelRowCount, int panelColCount)
		{
			if (pos.RowStartIndex >= 0 && pos.RowEndIndex < panelRowCount && pos.ColStartIndex >= 0 && pos.ColEndIndex < panelColCount)
			{
				return false;
			}
			for (int i = pos.RowStartIndex; i <= pos.RowEndIndex; i++)
			{
				for (int j = pos.ColStartIndex; j <= pos.ColEndIndex; j++)
				{
					if ((i < 0 || i >= panelRowCount || j < 0 || j >= panelColCount) && this.IsValidGridPos(i, j))
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06042386 RID: 271238 RVA: 0x010FCE60 File Offset: 0x010FB060
		public bool IsOutOfRange(IPanelPosRange pos, int panelRowCount, int panelColCount)
		{
			if (pos.RowEndIndex < 0 || pos.RowStartIndex >= panelRowCount || pos.ColEndIndex < 0 || pos.ColStartIndex >= panelColCount)
			{
				return true;
			}
			for (int i = pos.RowStartIndex; i <= pos.RowEndIndex; i++)
			{
				for (int j = pos.ColStartIndex; j <= pos.ColEndIndex; j++)
				{
					if (i >= 0 && i < panelRowCount && j >= 0 && j < panelColCount && this.IsValidGridPos(i, j))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06042387 RID: 271239 RVA: 0x010FCEDC File Offset: 0x010FB0DC
		public bool IsItemBlockInPanel(UUIItem panel)
		{
			this.RefreshTempPanelData(panel);
			this.TempAttachItemWorldTrans.InverseTransformPosition(this.TempLeftTopWorldPos, this.TempAttachItemPos);
			this.TempAttachItemPos.X += this.TempOffset.X;
			this.TempAttachItemPos.Y -= this.TempOffset.Y;
			return this.TempAttachItemPos.X >= (double)(-(double)this.BlockWidth) && this.TempAttachItemPos.X <= this.TempSize.X && this.TempAttachItemPos.Y >= (double)(-(double)this.BlockHeight) && this.TempAttachItemPos.Y <= this.TempSize.Y;
		}

		// Token: 0x06042388 RID: 271240 RVA: 0x010FCFA0 File Offset: 0x010FB1A0
		public IPanelPosRange GetLeftTopPosRangeByPanel(UUIItem panel)
		{
			this.RecordLeftTopWorldPos();
			this.RefreshTempPanelData(panel);
			this.TempAttachItemWorldTrans.InverseTransformPosition(this.TempLeftTopWorldPos, this.TempAttachItemPos);
			this.TempLeftTopLocalPos.Set(this.TempAttachItemPos.X + this.TempOffset.X, this.TempAttachItemPos.Y - this.TempOffset.Y);
			return DockyardPanelUtil.CreateAndDeepCopyItemRangePos(this.GetLeftTopPosRangeByOffset(this.TempLeftTopLocalPos));
		}

		// Token: 0x06042389 RID: 271241 RVA: 0x010FD01C File Offset: 0x010FB21C
		public int GetValueByPanelPos(IPanelPos panelPos)
		{
			int rowIndex = panelPos.RowIndex;
			int colIndex = panelPos.ColIndex;
			return this.Data.Data.PosDoublyList[rowIndex][colIndex];
		}

		// Token: 0x0604238A RID: 271242 RVA: 0x010FD053 File Offset: 0x010FB253
		public void SetTextureMaskActive(bool value)
		{
			base.GetTexture(4).SetUIActive(value);
		}

		// Token: 0x0604238B RID: 271243 RVA: 0x010FD062 File Offset: 0x010FB262
		public void RefreshItemBlockData(DockyardItemBlockData itemData)
		{
			this.Data = itemData;
		}

		// Token: 0x04024E12 RID: 151058
		private const float MATERIAL_OFFSET_VALUE = 0.012f;

		// Token: 0x04024E13 RID: 151059
		protected GenericLayout<DockyardItemBlockGrid, IPanelPos> Layout;

		// Token: 0x04024E14 RID: 151060
		protected IDockyardGridInterface ParentModel;

		// Token: 0x04024E15 RID: 151061
		private Vector2D TempLguiCenterPos = Vector2D.Create();

		// Token: 0x04024E16 RID: 151062
		private Rotator TempRotator = Rotator.Create();

		// Token: 0x04024E17 RID: 151063
		private Vector2D LastDragPos = Vector2D.Create();

		// Token: 0x04024E18 RID: 151064
		private Vector2D TempAnchorOffset = Vector2D.Create();

		// Token: 0x04024E19 RID: 151065
		private Vector TempPointerPosition = Vector.Create();

		// Token: 0x04024E1A RID: 151066
		private Vector2D ResetAnchorOffset = Vector2D.Create();

		// Token: 0x04024E1B RID: 151067
		private Vector TempLeftTopWorldPos = Vector.Create();

		// Token: 0x04024E1C RID: 151068
		private Vector TempPivotWorldPos = Vector.Create();

		// Token: 0x04024E1D RID: 151069
		private Transform ItemWorldTrans = Transform.Create();

		// Token: 0x04024E1E RID: 151070
		private Transform TempAttachItemWorldTrans = Transform.Create();

		// Token: 0x04024E1F RID: 151071
		private Vector TempAttachItemPos = Vector.Create();

		// Token: 0x04024E20 RID: 151072
		private Vector2D TempOffset = Vector2D.Create();

		// Token: 0x04024E21 RID: 151073
		private Vector2D TempSize = Vector2D.Create();

		// Token: 0x04024E22 RID: 151074
		private Vector2D TempLeftTopLocalPos = Vector2D.Create();

		// Token: 0x04024E23 RID: 151075
		private UUIItem TempPanel;

		// Token: 0x04024E24 RID: 151076
		private FName MaterialOffsetName = new FName("Offset");

		// Token: 0x04024E25 RID: 151077
		private UiSequencePlayer SequencePlayer;

		// Token: 0x04024E26 RID: 151078
		private float GridWidth;

		// Token: 0x04024E27 RID: 151079
		public float BlockWidth;

		// Token: 0x04024E28 RID: 151080
		public float BlockHeight;

		// Token: 0x04024E29 RID: 151081
		protected DockyardItemBlockData Data;

		// Token: 0x0200C7DE RID: 51166
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D854 RID: 251988
			public const int SelectItem = 0;

			// Token: 0x0403D855 RID: 251989
			public const int Layout = 1;

			// Token: 0x0403D856 RID: 251990
			public const int GridItem = 2;

			// Token: 0x0403D857 RID: 251991
			public const int Texture = 3;

			// Token: 0x0403D858 RID: 251992
			public const int TextureMask = 4;
		}
	}
}
