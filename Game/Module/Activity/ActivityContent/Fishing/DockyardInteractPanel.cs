using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067AF RID: 26543
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardInteractPanel : UiPanelBase
	{
		// Token: 0x06042304 RID: 271108 RVA: 0x010FA784 File Offset: 0x010F8984
		public DockyardInteractPanel(DockyardInteractPanelModel panelModel)
		{
			this.PanelModel = panelModel;
			this.PanelModel.InitPanel(this);
		}

		// Token: 0x06042305 RID: 271109 RVA: 0x010FA810 File Offset: 0x010F8A10
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06042306 RID: 271110 RVA: 0x010FA89A File Offset: 0x010F8A9A
		private void InitOther()
		{
			this.AttachItem = base.GetItem(2);
		}

		// Token: 0x06042307 RID: 271111 RVA: 0x010FA8AC File Offset: 0x010F8AAC
		private UniTask InitLayout()
		{
			DockyardInteractPanel.<InitLayout>d__11 <InitLayout>d__;
			<InitLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLayout>d__.<>4__this = this;
			<InitLayout>d__.<>1__state = -1;
			<InitLayout>d__.<>t__builder.Start<DockyardInteractPanel.<InitLayout>d__11>(ref <InitLayout>d__);
			return <InitLayout>d__.<>t__builder.Task;
		}

		// Token: 0x06042308 RID: 271112 RVA: 0x010FA8F0 File Offset: 0x010F8AF0
		private UniTask InitInteractItemBlock(int itemId, IntArray dataList, float gridWidth)
		{
			DockyardInteractPanel.<InitInteractItemBlock>d__12 <InitInteractItemBlock>d__;
			<InitInteractItemBlock>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitInteractItemBlock>d__.<>4__this = this;
			<InitInteractItemBlock>d__.itemId = itemId;
			<InitInteractItemBlock>d__.dataList = dataList;
			<InitInteractItemBlock>d__.gridWidth = gridWidth;
			<InitInteractItemBlock>d__.<>1__state = -1;
			<InitInteractItemBlock>d__.<>t__builder.Start<DockyardInteractPanel.<InitInteractItemBlock>d__12>(ref <InitInteractItemBlock>d__);
			return <InitInteractItemBlock>d__.<>t__builder.Task;
		}

		// Token: 0x06042309 RID: 271113 RVA: 0x010FA94C File Offset: 0x010F8B4C
		private UniTask InitAllInteractItemBlock()
		{
			DockyardInteractPanel.<InitAllInteractItemBlock>d__13 <InitAllInteractItemBlock>d__;
			<InitAllInteractItemBlock>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitAllInteractItemBlock>d__.<>4__this = this;
			<InitAllInteractItemBlock>d__.<>1__state = -1;
			<InitAllInteractItemBlock>d__.<>t__builder.Start<DockyardInteractPanel.<InitAllInteractItemBlock>d__13>(ref <InitAllInteractItemBlock>d__);
			return <InitAllInteractItemBlock>d__.<>t__builder.Task;
		}

		// Token: 0x0604230A RID: 271114 RVA: 0x010FA990 File Offset: 0x010F8B90
		private void SetAllInteractItemBlockIncId()
		{
			Dictionary<int, DockyardItemBlockOriginalData> dataMapByInteract = ModelBase<FishingModel>.Instance.GetDataMapByInteract(this.PanelModel.ConfigId);
			if (dataMapByInteract != null)
			{
				foreach (DockyardItemBlockOriginalData dockyardItemBlockOriginalData in dataMapByInteract.Values)
				{
					DockyardInteractItemBlock interactItemBlock = this.GetInteractItemBlock(dockyardItemBlockOriginalData.ItemId, dockyardItemBlockOriginalData.PosY, dockyardItemBlockOriginalData.PosX);
					if (interactItemBlock != null)
					{
						interactItemBlock.SetItemData(dockyardItemBlockOriginalData);
					}
				}
			}
		}

		// Token: 0x0604230B RID: 271115 RVA: 0x010FAA18 File Offset: 0x010F8C18
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardInteractPanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardInteractPanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0604230C RID: 271116 RVA: 0x010FAA5B File Offset: 0x010F8C5B
		private DockyardInteractGrid InitItem()
		{
			return new DockyardInteractGrid(this.PanelModel);
		}

		// Token: 0x0604230D RID: 271117 RVA: 0x010FAA68 File Offset: 0x010F8C68
		private DockyardInteractGrid GetItemGridInLayout(int rowIndex, int colIndex)
		{
			IPanelPos interactPosByPos = this.PanelModel.GetInteractPosByPos(rowIndex, colIndex);
			if (interactPosByPos == null)
			{
				return null;
			}
			return this.Layout.GetLayoutItemByKey(interactPosByPos);
		}

		// Token: 0x0604230E RID: 271118 RVA: 0x010FAA94 File Offset: 0x010F8C94
		private unsafe DockyardInteractItemBlock GetInteractItemBlock(int itemId, int rowIndex, int colIndex)
		{
			foreach (DockyardInteractItemBlock dockyardInteractItemBlock in this.InteractItemBlockSet)
			{
				if (dockyardInteractItemBlock.ItemId == itemId && dockyardInteractItemBlock.StartPos.ColIndex == colIndex && dockyardInteractItemBlock.StartPos.RowIndex == rowIndex)
				{
					return dockyardInteractItemBlock;
				}
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Dockyard;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "查找不到对应的InteractItemBlock";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("ItemId", itemId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RowIndex", rowIndex);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("ColIndex", colIndex);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return null;
		}

		// Token: 0x0604230F RID: 271119 RVA: 0x010FAB8C File Offset: 0x010F8D8C
		private void ResetBackpackGridShowType(IPanelPosRange rangePos)
		{
			int num = (rangePos.RowStartIndex >= 0) ? rangePos.RowStartIndex : 0;
			int num2 = (rangePos.RowEndIndex < 3 && rangePos.RowEndIndex >= 0) ? rangePos.RowEndIndex : 2;
			int num3 = (rangePos.ColStartIndex >= 0) ? rangePos.ColStartIndex : 0;
			int num4 = (rangePos.ColEndIndex < 6 && rangePos.ColEndIndex >= 0) ? rangePos.ColEndIndex : 5;
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					DockyardInteractGrid itemGridInLayout = this.GetItemGridInLayout(i, j);
					if (itemGridInLayout != null)
					{
						itemGridInLayout.ResetPreviewBg();
					}
				}
			}
		}

		// Token: 0x06042310 RID: 271120 RVA: 0x010FAC28 File Offset: 0x010F8E28
		private void ChangeBackpackGridShowType(DockyardItemBlock itemBlock, IPanelPosRange rangePos)
		{
			this.InteractGridSet.Clear();
			int num = Math.Max(rangePos.RowStartIndex, 0);
			int num2 = Math.Min(rangePos.RowEndIndex, 2);
			int num3 = Math.Max(rangePos.ColStartIndex, 0);
			int num4 = Math.Min(rangePos.ColEndIndex, 5);
			int itemId = itemBlock.GetItemId();
			bool flag = itemBlock.IsPartOutOfRange(rangePos, 3, 6);
			bool flag2 = itemBlock.IsOutOfRange(rangePos, 3, 6);
			this.PanelModel.IsAllMatch = (!flag && !flag2);
			this.PanelModel.IsOverlapAnother = (!flag && !flag2);
			for (int i = num; i <= num2; i++)
			{
				for (int j = num3; j <= num4; j++)
				{
					if (itemBlock.IsValidGridPos(i, j))
					{
						DockyardInteractGrid itemGridInLayout = this.GetItemGridInLayout(i, j);
						if (itemGridInLayout != null)
						{
							this.InteractGridSet.Add(itemGridInLayout);
							if (itemGridInLayout.GetTargetItemId() != itemId)
							{
								this.PanelModel.IsAllMatch = false;
							}
							if (!itemGridInLayout.IsFinishInteract)
							{
								this.PanelModel.IsOverlapAnother = false;
							}
						}
					}
				}
			}
			if (this.PanelModel.IsAllMatch)
			{
				DockyardInteractItemBlock interactItemBlock = this.GetInteractItemBlock(itemId, rangePos.RowStartIndex, rangePos.ColStartIndex);
				if (interactItemBlock != null)
				{
					this.PanelModel.IsAllMatch = (interactItemBlock.RotateType == (int)itemBlock.GetData().Rotate);
					this.PanelModel.MatchPos.RowIndex = rangePos.RowStartIndex + interactItemBlock.ValidStartPos.RowIndex;
					this.PanelModel.MatchPos.ColIndex = rangePos.ColStartIndex + interactItemBlock.ValidStartPos.ColIndex;
				}
			}
			this.PanelModel.IsOverlapAnother &= this.PanelModel.IsAllMatch;
			foreach (DockyardInteractGrid dockyardInteractGrid in this.InteractGridSet)
			{
				dockyardInteractGrid.RefreshBgSprite(this.PanelModel.IsAllMatch);
			}
		}

		// Token: 0x06042311 RID: 271121 RVA: 0x010FAE2C File Offset: 0x010F902C
		private void TryHandleRotateFail()
		{
			if (this.PanelModel.IsOutOfRange)
			{
				this.PanelModel.InSelectItemBlock.ResetToAppropriatePos(3, 6, this.AttachItem);
				this.RefreshAllBackpackGridState(true);
			}
		}

		// Token: 0x06042312 RID: 271122 RVA: 0x010FAE5C File Offset: 0x010F905C
		private void RefreshBackpackGridState(DockyardItemBlock itemBlock)
		{
			IPanelPosRange leftTopPosRangeByPanel = itemBlock.GetLeftTopPosRangeByPanel(this.AttachItem);
			this.ChangeBackpackGridShowType(itemBlock, leftTopPosRangeByPanel);
		}

		// Token: 0x06042313 RID: 271123 RVA: 0x010FAE80 File Offset: 0x010F9080
		public void InitAppropriatePos(DockyardItemBlockOriginalData itemData)
		{
			List<List<int>> list = DockyardPanelUtil.RotateOriginalPosData(itemData.PosDoublyList, itemData.Rotate);
			this.AppropriatePos.RowStartIndex = itemData.PosY;
			this.AppropriatePos.RowEndIndex = itemData.PosY + list.Count - 1;
			this.AppropriatePos.ColStartIndex = itemData.PosX;
			this.AppropriatePos.ColEndIndex = itemData.PosX + list[0].Count - 1;
		}

		// Token: 0x06042314 RID: 271124 RVA: 0x010FAEFC File Offset: 0x010F90FC
		public void RefreshAllBackpackGridState(bool checkRangeChange = true)
		{
			IPanelPosRange leftTopPosRangeByPanel = this.PanelModel.InSelectItemBlock.GetLeftTopPosRangeByPanel(this.AttachItem);
			if (!this.PanelModel.InSelectItemBlock.IsRangeChange(this.LastLeftTopPos, leftTopPosRangeByPanel) && checkRangeChange)
			{
				DockyardPanelUtil.DeepCopyItemRangePos(this.LastLeftTopPos, leftTopPosRangeByPanel);
				return;
			}
			bool flag = this.PanelModel.InSelectItemBlock.IsOutOfRange(leftTopPosRangeByPanel, 3, 6);
			if (this.PanelModel.IsOutOfRange && flag)
			{
				DockyardPanelUtil.DeepCopyItemRangePos(this.LastLeftTopPos, leftTopPosRangeByPanel);
				return;
			}
			this.PanelModel.IsOutOfRange = flag;
			this.ResetBackpackGridShowType(this.LastLeftTopPos);
			this.ChangeBackpackGridShowType(this.PanelModel.InSelectItemBlock, leftTopPosRangeByPanel);
			DockyardPanelUtil.DeepCopyItemRangePos(this.LastLeftTopPos, leftTopPosRangeByPanel);
		}

		// Token: 0x06042315 RID: 271125 RVA: 0x010FAFB4 File Offset: 0x010F91B4
		public void HandleDragSuccess()
		{
			DockyardPanelUtil.DeepCopyItemRangePos(this.AppropriatePos, this.LastLeftTopPos);
			this.PanelModel.InSelectItemBlock.AdsorbToAppropriatePosByAttachItem(this.AppropriatePos.RowStartIndex, this.AppropriatePos.ColStartIndex, this.AttachItem);
			this.PanelModel.BackpackPanelModel.Panel.SetButtonsState(true);
		}

		// Token: 0x06042316 RID: 271126 RVA: 0x010FB014 File Offset: 0x010F9214
		public void HandleDragFail()
		{
			this.PanelModel.InSelectItemBlock.AdsorbToAppropriatePosByAttachItem(this.AppropriatePos.RowStartIndex, this.AppropriatePos.ColStartIndex, this.AttachItem);
			this.RefreshAllBackpackGridState(false);
			this.PanelModel.BackpackPanelModel.Panel.SetButtonsState(true);
			DockyardInteractBackpackPanelModel backpackPanelModel = this.PanelModel.BackpackPanelModel;
			if (backpackPanelModel == null)
			{
				return;
			}
			backpackPanelModel.RefreshPanel(false);
		}

		// Token: 0x06042317 RID: 271127 RVA: 0x010FB080 File Offset: 0x010F9280
		public void RotateClick()
		{
			this.PanelModel.InSelectItemBlock.RotateBlock();
			this.RefreshAllBackpackGridState(false);
			this.TryHandleRotateFail();
			DockyardInteractBackpackPanelModel backpackPanelModel = this.PanelModel.BackpackPanelModel;
			if (backpackPanelModel == null)
			{
				return;
			}
			backpackPanelModel.RefreshPanel(false);
		}

		// Token: 0x06042318 RID: 271128 RVA: 0x010FB0B8 File Offset: 0x010F92B8
		public void DisableInteractItemBlock(DockyardItemBlockOriginalData itemData, IPanelPos startPos)
		{
			DockyardInteractItemBlock interactItemBlock = this.GetInteractItemBlock(itemData.ItemId, startPos.RowIndex, startPos.ColIndex);
			if (interactItemBlock != null)
			{
				interactItemBlock.SetItemData(null);
			}
		}

		// Token: 0x06042319 RID: 271129 RVA: 0x010FB0E8 File Offset: 0x010F92E8
		public void EnableInteractItemBlock(DockyardItemBlockOriginalData itemData)
		{
			DockyardInteractItemBlock interactItemBlock = this.GetInteractItemBlock(itemData.ItemId, this.LastLeftTopPos.RowStartIndex, this.LastLeftTopPos.ColStartIndex);
			if (interactItemBlock != null)
			{
				interactItemBlock.SetItemData(itemData);
			}
		}

		// Token: 0x0604231A RID: 271130 RVA: 0x010FB122 File Offset: 0x010F9322
		public void HandleOverlapConfirm()
		{
			this.RefreshBackpackGridState(this.PanelModel.InSelectItemBlock);
			this.PanelModel.ChangeShowItemData();
		}

		// Token: 0x0604231B RID: 271131 RVA: 0x010FB140 File Offset: 0x010F9340
		public void HandleFinishConfirm()
		{
			this.RefreshBackpackGridState(this.PanelModel.InSelectItemBlock);
			this.PanelModel.ChangeShowItemData();
			DockyardInteractBackpackPanelModel backpackPanelModel = this.PanelModel.BackpackPanelModel;
			if (backpackPanelModel == null)
			{
				return;
			}
			backpackPanelModel.Panel.DestroySelectItemBlock();
		}

		// Token: 0x0604231C RID: 271132 RVA: 0x010FB178 File Offset: 0x010F9378
		public IPanelPos GetLeftTopPanelPos(int itemId)
		{
			if (this.GetInteractItemBlock(itemId, this.LastLeftTopPos.RowStartIndex, this.LastLeftTopPos.ColStartIndex) == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Dockyard;
				ELogAuthor author = ELogAuthor.XXJ;
				string message = "查找不到对应的InteractItemBlock";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ItemId", itemId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new PanelPos
				{
					RowIndex = -1,
					ColIndex = -1
				};
			}
			return new PanelPos
			{
				RowIndex = this.LastLeftTopPos.RowStartIndex,
				ColIndex = this.LastLeftTopPos.ColStartIndex
			};
		}

		// Token: 0x0604231D RID: 271133 RVA: 0x010FB20E File Offset: 0x010F940E
		public void ResetLastBackpackGridShowType()
		{
			this.ResetBackpackGridShowType(this.LastLeftTopPos);
		}

		// Token: 0x04024DF2 RID: 151026
		private readonly HashSet<DockyardInteractGrid> InteractGridSet = new HashSet<DockyardInteractGrid>();

		// Token: 0x04024DF3 RID: 151027
		private readonly HashSet<DockyardInteractItemBlock> InteractItemBlockSet = new HashSet<DockyardInteractItemBlock>();

		// Token: 0x04024DF4 RID: 151028
		protected GenericLayout<DockyardInteractGrid, IPanelPos> Layout;

		// Token: 0x04024DF5 RID: 151029
		public UUIItem AttachItem;

		// Token: 0x04024DF6 RID: 151030
		private readonly IPanelPosRange LastLeftTopPos = new PanelPosRange
		{
			RowStartIndex = -1,
			RowEndIndex = -1,
			ColStartIndex = -1,
			ColEndIndex = -1
		};

		// Token: 0x04024DF7 RID: 151031
		private readonly IPanelPosRange AppropriatePos = new PanelPosRange
		{
			RowStartIndex = -1,
			RowEndIndex = -1,
			ColStartIndex = -1,
			ColEndIndex = -1
		};

		// Token: 0x04024DF8 RID: 151032
		protected DockyardInteractPanelModel PanelModel;

		// Token: 0x0200C7D1 RID: 51153
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D820 RID: 251936
			public const int Layout = 0;

			// Token: 0x0403D821 RID: 251937
			public const int GridItem = 1;

			// Token: 0x0403D822 RID: 251938
			public const int AttachItem = 2;
		}
	}
}
