using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067AD RID: 26541
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractItemBlock : UiPanelBase
	{
		// Token: 0x060422F3 RID: 271091 RVA: 0x010FA0A8 File Offset: 0x010F82A8
		public DockyardInteractItemBlock(int itemId, IPanelPos startPos, int rotateType, float gridWidth)
		{
			this.ItemId = itemId;
			this.StartPos = startPos;
			this.RotateType = rotateType;
			this.GridWidth = gridWidth;
		}

		// Token: 0x060422F4 RID: 271092 RVA: 0x010FA118 File Offset: 0x010F8318
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as DockyardInteractPanelModel);
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIDraggableComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060422F5 RID: 271093 RVA: 0x010FA1B4 File Offset: 0x010F83B4
		private void InitDrag()
		{
			UUIDraggableComponent draggable = base.GetDraggable(2);
			draggable.OnPointerCancelCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			draggable.OnPointerUpCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnPointerUp));
			draggable.OnPointerBeginDragCallBack.Bind(new Action<ULGUIPointerEventData>(this.OnDragBegin));
		}

		// Token: 0x060422F6 RID: 271094 RVA: 0x010FA20C File Offset: 0x010F840C
		private void OnPointerUp(ULGUIPointerEventData eventData)
		{
			if (this.ItemData != null)
			{
				DockyardInteractPanelModel parentModel = this.ParentModel;
				if (parentModel == null)
				{
					return;
				}
				parentModel.DragClick(this.ItemData, this.StartPos);
			}
		}

		// Token: 0x060422F7 RID: 271095 RVA: 0x010FA232 File Offset: 0x010F8432
		private void OnDragBegin(ULGUIPointerEventData eventData)
		{
			if (this.ItemData != null)
			{
				DockyardInteractPanelModel parentModel = this.ParentModel;
				if (parentModel == null)
				{
					return;
				}
				parentModel.DragBegin(this.ItemData, this.StartPos);
			}
		}

		// Token: 0x060422F8 RID: 271096 RVA: 0x010FA258 File Offset: 0x010F8458
		private void InitValidData()
		{
			FishingItem? fishingItemConfig = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(this.ItemId);
			IntArray[] array = ConfigBase<FishingConfig>.Instance.GetFishingShapeConfig(fishingItemConfig.Value.Shap).FillState();
			this.ShapeLength.RowIndex = array.Length;
			this.ShapeLength.ColIndex = array[0].ArrayIntLength;
			int num = -1;
			int num2 = -1;
			int num3 = -1;
			int num4 = -1;
			for (int i = 0; i < array.Length; i++)
			{
				for (int j = 0; j < array[i].ArrayIntLength; j++)
				{
					if (array[i].ArrayInt(j) == 1)
					{
						num = ((num == -1) ? i : Math.Min(num, i));
						num2 = ((num2 == -1) ? i : Math.Max(num2, i));
						num3 = ((num3 == -1) ? j : Math.Min(num3, j));
						num4 = ((num4 == -1) ? j : Math.Max(num4, j));
					}
				}
			}
			this.ValidStartPos.ColIndex = num3;
			this.ValidStartPos.RowIndex = num;
			for (int k = 0; k < num2 - num + 1; k++)
			{
				this.ValidDoublyList.Add(new List<int>());
				for (int l = 0; l < num4 - num3 + 1; l++)
				{
					int item = array[k + num].ArrayInt(l + num3);
					this.ValidDoublyList[k].Add(item);
				}
			}
		}

		// Token: 0x060422F9 RID: 271097 RVA: 0x010FA3DC File Offset: 0x010F85DC
		private UniTask InitTexture()
		{
			DockyardInteractItemBlock.<InitTexture>d__16 <InitTexture>d__;
			<InitTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitTexture>d__.<>4__this = this;
			<InitTexture>d__.<>1__state = -1;
			<InitTexture>d__.<>t__builder.Start<DockyardInteractItemBlock.<InitTexture>d__16>(ref <InitTexture>d__);
			return <InitTexture>d__.<>t__builder.Task;
		}

		// Token: 0x060422FA RID: 271098 RVA: 0x010FA420 File Offset: 0x010F8620
		private void InitTargetId()
		{
			List<List<int>> list = DockyardPanelUtil.RotateOriginalPosData(this.ValidDoublyList, (FishingItemRotate)this.RotateType);
			for (int i = 0; i < list.Count; i++)
			{
				for (int j = 0; j < list[i].Count; j++)
				{
					if (list[i][j] == 1)
					{
						IPanelPos interactPosByPos = this.ParentModel.GetInteractPosByPos(i + this.StartPos.RowIndex, j + this.StartPos.ColIndex);
						this.ParentModel.GetInteractGridData(interactPosByPos).SetTargetId(this.ItemId);
					}
				}
			}
		}

		// Token: 0x060422FB RID: 271099 RVA: 0x010FA4B4 File Offset: 0x010F86B4
		private void RefreshFinish()
		{
			List<List<int>> list = new List<List<int>>();
			if (this.ItemData != null)
			{
				list = DockyardPanelUtil.RotateOriginalPosData(this.ItemData.ValidDoublyList, (FishingItemRotate)this.RotateType);
			}
			List<List<int>> list2 = DockyardPanelUtil.RotateOriginalPosData(this.ValidDoublyList, (FishingItemRotate)this.RotateType);
			for (int i = 0; i < list2.Count; i++)
			{
				for (int j = 0; j < list2[i].Count; j++)
				{
					IPanelPos interactPosByPos = this.ParentModel.GetInteractPosByPos(i + this.StartPos.RowIndex, j + this.StartPos.ColIndex);
					DockyardInteractGridData interactGridData = this.ParentModel.GetInteractGridData(interactPosByPos);
					if (list.Count > 0)
					{
						int num = list[i][j];
						interactGridData.IsFinish = (num == 1);
					}
					else
					{
						interactGridData.IsFinish = false;
					}
				}
			}
		}

		// Token: 0x060422FC RID: 271100 RVA: 0x010FA588 File Offset: 0x010F8788
		private void InitTextureTransform(UUITexture texture)
		{
			float width = (float)this.ValidDoublyList[0].Count * this.GridWidth;
			texture.SetWidth(width);
			float height = (float)this.ValidDoublyList.Count * this.GridWidth;
			texture.SetHeight(height);
			Vector2D vector2D = DockyardPanelUtil.CalculateOriginalPivot(this.ShapeLength.RowIndex, this.ShapeLength.ColIndex);
			if (texture != null)
			{
				texture.SetPivot(vector2D.ToUeVector2D(false));
			}
			int num = this.RotateType * -90;
			FRotator frotator = new FRotator(0f, (float)num, 0f);
			texture.SetUIRelativeRotation(frotator);
		}

		// Token: 0x060422FD RID: 271101 RVA: 0x010FA624 File Offset: 0x010F8824
		private void InitRootItemTransform()
		{
			float inX = (float)(this.ValidStartPos.ColIndex + this.StartPos.ColIndex) * this.GridWidth;
			float num = (float)(this.ValidStartPos.RowIndex + this.StartPos.RowIndex) * this.GridWidth;
			UUIItem rootItem = this.RootItem;
			if (rootItem == null)
			{
				return;
			}
			rootItem.SetAnchorOffset(new FVector2D(inX, -num));
		}

		// Token: 0x060422FE RID: 271102 RVA: 0x010FA689 File Offset: 0x010F8889
		private void InitOther()
		{
			this.ChangeTextureActive(false);
		}

		// Token: 0x060422FF RID: 271103 RVA: 0x010FA694 File Offset: 0x010F8894
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardInteractItemBlock.<OnBeforeStartAsync>d__22 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardInteractItemBlock.<OnBeforeStartAsync>d__22>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042300 RID: 271104 RVA: 0x010FA6D7 File Offset: 0x010F88D7
		private void ChangeTextureActive(bool realTextureActive)
		{
			UUITexture texture = base.GetTexture(1);
			if (texture != null)
			{
				texture.SetUIActive(realTextureActive);
			}
			UUITexture texture2 = base.GetTexture(0);
			if (texture2 == null)
			{
				return;
			}
			texture2.SetUIActive(!realTextureActive);
		}

		// Token: 0x06042301 RID: 271105 RVA: 0x010FA701 File Offset: 0x010F8901
		public void SetItemData(DockyardItemBlockOriginalData itemData)
		{
			this.ItemData = itemData;
			this.RefreshFinish();
			this.ChangeTextureActive(itemData != null);
		}

		// Token: 0x06042302 RID: 271106 RVA: 0x010FA71A File Offset: 0x010F891A
		public bool CheckIsTarget(int itemId, int rowIndex, int colIndex, int rotateType)
		{
			return this.ItemId == itemId && rowIndex == this.StartPos.RowIndex && colIndex == this.StartPos.ColIndex && rotateType == this.RotateType;
		}

		// Token: 0x04024DE6 RID: 151014
		private List<List<int>> ValidDoublyList = new List<List<int>>();

		// Token: 0x04024DE7 RID: 151015
		public readonly IPanelPos ValidStartPos = new PanelPos
		{
			RowIndex = -1,
			ColIndex = -1
		};

		// Token: 0x04024DE8 RID: 151016
		private DockyardInteractPanelModel ParentModel;

		// Token: 0x04024DE9 RID: 151017
		public DockyardItemBlockOriginalData ItemData;

		// Token: 0x04024DEA RID: 151018
		private readonly IPanelPos ShapeLength = new PanelPos
		{
			RowIndex = -1,
			ColIndex = -1
		};

		// Token: 0x04024DEB RID: 151019
		public int ItemId;

		// Token: 0x04024DEC RID: 151020
		public IPanelPos StartPos;

		// Token: 0x04024DED RID: 151021
		public readonly int RotateType;

		// Token: 0x04024DEE RID: 151022
		protected float GridWidth;

		// Token: 0x0200C7CE RID: 51150
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D815 RID: 251925
			public const int Texture = 0;

			// Token: 0x0403D816 RID: 251926
			public const int RealTexture = 1;

			// Token: 0x0403D817 RID: 251927
			public const int DraggableItem = 2;
		}
	}
}
