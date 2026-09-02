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
	// Token: 0x020067B9 RID: 26553
	[NullableContext(1)]
	[Nullable(0)]
	public class DockyardItemListPanel : UiPanelBase
	{
		// Token: 0x060423C9 RID: 271305 RVA: 0x010FE2C8 File Offset: 0x010FC4C8
		protected unsafe override void OnRegisterComponent()
		{
			this.PanelModel = (this.OpenParam as DockyardItemListPanelModel);
			this.PanelModel.RegisterPanel(this);
			int num = 10;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060423CA RID: 271306 RVA: 0x010FE458 File Offset: 0x010FC658
		private UniTask InitLoopScroll()
		{
			DockyardItemListPanel.<InitLoopScroll>d__10 <InitLoopScroll>d__;
			<InitLoopScroll>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitLoopScroll>d__.<>4__this = this;
			<InitLoopScroll>d__.<>1__state = -1;
			<InitLoopScroll>d__.<>t__builder.Start<DockyardItemListPanel.<InitLoopScroll>d__10>(ref <InitLoopScroll>d__);
			return <InitLoopScroll>d__.<>t__builder.Task;
		}

		// Token: 0x060423CB RID: 271307 RVA: 0x010FE49C File Offset: 0x010FC69C
		protected void InitTitle()
		{
			UUIText text = base.GetText(4);
			bool flag = !StringUtils.IsBlank(this.PanelModel.ComponentData.TitleText);
			text.SetUIActive(flag);
			if (flag)
			{
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, this.PanelModel.ComponentData.TitleText, Array.Empty<object>());
			}
		}

		// Token: 0x060423CC RID: 271308 RVA: 0x010FE4F4 File Offset: 0x010FC6F4
		protected void SetCountText()
		{
			UUIText text = base.GetText(1);
			Func<string> getCountText = this.PanelModel.ComponentData.GetCountText;
			string text2 = (getCountText != null) ? getCountText() : null;
			bool flag = text2 != null && !StringUtils.IsBlank(text2);
			text.SetUIActive(flag);
			if (flag)
			{
				text.SetText(text2, true);
			}
		}

		// Token: 0x060423CD RID: 271309 RVA: 0x010FE548 File Offset: 0x010FC748
		protected void InitHelpItem()
		{
			UUIExtendButtonComponent uuiextendButtonComponent = base.GetButton(6) as UUIExtendButtonComponent;
			bool flag = this.PanelModel.ComponentData.HelpBtnId != 0;
			uuiextendButtonComponent.RootUIComp.Get().SetUIActive(flag);
			if (flag)
			{
				uuiextendButtonComponent.HelpGroupId = this.PanelModel.ComponentData.HelpBtnId;
			}
		}

		// Token: 0x060423CE RID: 271310 RVA: 0x010FE5A4 File Offset: 0x010FC7A4
		protected void InitTimeItem()
		{
			UUIItem item = base.GetItem(8);
			bool flag = !StringUtils.IsBlank(this.PanelModel.ComponentData.TimeText);
			item.SetUIActive(flag);
			if (flag)
			{
				UUIText text = base.GetText(9);
				Singleton<LguiUtil>.Instance.SetLocalTextNew(text, "Fishing_CageTime", new <>z__ReadOnlySingleElementList<object>(this.PanelModel.ComponentData.TimeText));
			}
		}

		// Token: 0x060423CF RID: 271311 RVA: 0x010FE608 File Offset: 0x010FC808
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardItemListPanel.<OnBeforeStartAsync>d__15 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardItemListPanel.<OnBeforeStartAsync>d__15>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060423D0 RID: 271312 RVA: 0x010FE64C File Offset: 0x010FC84C
		protected override void OnStart()
		{
			this.DragTipsItem = base.GetItem(7);
			this.DragTipsActive = this.DragTipsItem.bIsUIActive;
			this.SetDragTipsActive(false);
			Transform dragTipsWorldTrans = this.DragTipsWorldTrans;
			FTransform ftransform = this.DragTipsItem.K2_GetComponentToWorld();
			dragTipsWorldTrans.FromUeTransform(ftransform);
			FVector2D pivot = this.DragTipsItem.GetPivot();
			this.ViewportItemRange = new ItemRange
			{
				Left = -pivot.X * this.DragTipsItem.Width,
				Right = (1f - pivot.X) * this.DragTipsItem.Width,
				Top = (1f - pivot.Y) * this.DragTipsItem.Height,
				Bottom = -pivot.Y * this.DragTipsItem.Height
			};
		}

		// Token: 0x060423D1 RID: 271313 RVA: 0x010FE71C File Offset: 0x010FC91C
		protected override UniTask OnBeforeShowAsyncImplement()
		{
			DockyardItemListPanel.<OnBeforeShowAsyncImplement>d__17 <OnBeforeShowAsyncImplement>d__;
			<OnBeforeShowAsyncImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplement>d__.<>t__builder.Start<DockyardItemListPanel.<OnBeforeShowAsyncImplement>d__17>(ref <OnBeforeShowAsyncImplement>d__);
			return <OnBeforeShowAsyncImplement>d__.<>t__builder.Task;
		}

		// Token: 0x060423D2 RID: 271314 RVA: 0x010FE75F File Offset: 0x010FC95F
		protected override void OnBeforeDestroy()
		{
			this.TipsSequence.Clear();
		}

		// Token: 0x060423D3 RID: 271315 RVA: 0x010FE76C File Offset: 0x010FC96C
		private DockyardItemListItem InitGridItem()
		{
			return new DockyardItemListItem
			{
				OpenParam = this.PanelModel
			};
		}

		// Token: 0x060423D4 RID: 271316 RVA: 0x010FE780 File Offset: 0x010FC980
		public UniTask RefreshListItem()
		{
			DockyardItemListPanel.<RefreshListItem>d__20 <RefreshListItem>d__;
			<RefreshListItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshListItem>d__.<>4__this = this;
			<RefreshListItem>d__.<>1__state = -1;
			<RefreshListItem>d__.<>t__builder.Start<DockyardItemListPanel.<RefreshListItem>d__20>(ref <RefreshListItem>d__);
			return <RefreshListItem>d__.<>t__builder.Task;
		}

		// Token: 0x060423D5 RID: 271317 RVA: 0x010FE7C4 File Offset: 0x010FC9C4
		public bool CheckInViewport()
		{
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, true);
			this.TempVector.Set((double)pointerEventData.worldPoint.X, 0.0, (double)pointerEventData.worldPoint.Z);
			Transform dragTipsWorldTrans = this.DragTipsWorldTrans;
			FTransform ftransform = this.DragTipsItem.K2_GetComponentToWorld();
			dragTipsWorldTrans.FromUeTransform(ftransform);
			this.DragTipsWorldTrans.InverseTransformPosition(this.TempVector, this.TempVector);
			return this.TempVector.X >= (double)this.ViewportItemRange.Left && this.TempVector.X <= (double)this.ViewportItemRange.Right && this.TempVector.Y >= (double)this.ViewportItemRange.Bottom && this.TempVector.Y <= (double)this.ViewportItemRange.Top;
		}

		// Token: 0x060423D6 RID: 271318 RVA: 0x010FE8A4 File Offset: 0x010FCAA4
		private UniTask PlayShowSequence()
		{
			DockyardItemListPanel.<PlayShowSequence>d__22 <PlayShowSequence>d__;
			<PlayShowSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayShowSequence>d__.<>4__this = this;
			<PlayShowSequence>d__.<>1__state = -1;
			<PlayShowSequence>d__.<>t__builder.Start<DockyardItemListPanel.<PlayShowSequence>d__22>(ref <PlayShowSequence>d__);
			return <PlayShowSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060423D7 RID: 271319 RVA: 0x010FE8E8 File Offset: 0x010FCAE8
		private UniTask PlayHideSequence()
		{
			DockyardItemListPanel.<PlayHideSequence>d__23 <PlayHideSequence>d__;
			<PlayHideSequence>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PlayHideSequence>d__.<>4__this = this;
			<PlayHideSequence>d__.<>1__state = -1;
			<PlayHideSequence>d__.<>t__builder.Start<DockyardItemListPanel.<PlayHideSequence>d__23>(ref <PlayHideSequence>d__);
			return <PlayHideSequence>d__.<>t__builder.Task;
		}

		// Token: 0x060423D8 RID: 271320 RVA: 0x010FE92C File Offset: 0x010FCB2C
		public void SetDragTipsActive(bool isActive)
		{
			if (this.DragTipsActive == isActive)
			{
				return;
			}
			this.DragTipsActive = isActive;
			if (isActive)
			{
				this.PlayShowSequence();
			}
			else
			{
				this.PlayHideSequence();
			}
			List<DockyardItemBlockOriginalData> showItemList = this.PanelModel.ShowItemList;
			UUIItem item = base.GetItem(0);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(showItemList.Count == 0 && !isActive);
		}

		// Token: 0x060423D9 RID: 271321 RVA: 0x010FE98C File Offset: 0x010FCB8C
		public void RefreshListItemStateByIncId(int incId)
		{
			int num = this.PanelModel.ShowItemList.FindIndex((DockyardItemBlockOriginalData item) => item.IncId == incId);
			if (num >= 0)
			{
				DockyardItemListItem dockyardItemListItem = this.LoopScroll.UnsafeGetGridProxy(num, false);
				if (dockyardItemListItem == null)
				{
					return;
				}
				dockyardItemListItem.RefreshToggleState();
			}
		}

		// Token: 0x060423DA RID: 271322 RVA: 0x010FE9E0 File Offset: 0x010FCBE0
		public void RefreshListItemRedDot(int itemId)
		{
			for (int i = 0; i < this.PanelModel.ShowItemList.Count; i++)
			{
				if (this.PanelModel.ShowItemList[i].ItemId == itemId && i >= this.LoopScroll.StartGridIndex && i <= this.LoopScroll.EndGridIndex)
				{
					DockyardItemListItem dockyardItemListItem = this.LoopScroll.UnsafeGetGridProxy(i, false);
					if (dockyardItemListItem != null)
					{
						dockyardItemListItem.RefreshRedDot();
					}
				}
			}
		}

		// Token: 0x060423DB RID: 271323 RVA: 0x010FEA58 File Offset: 0x010FCC58
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (this.PanelModel.ShowItemList.Count <= 0)
			{
				return null;
			}
			UUIItem gridByDisplayIndex = this.LoopScroll.GetGridByDisplayIndex(0);
			if (gridByDisplayIndex == null)
			{
				return null;
			}
			return new UUIItem[]
			{
				gridByDisplayIndex,
				gridByDisplayIndex
			};
		}

		// Token: 0x04024E46 RID: 151110
		private LoopScrollView<DockyardItemListItem, DockyardItemBlockOriginalData> LoopScroll;

		// Token: 0x04024E47 RID: 151111
		public DockyardItemListPanelModel PanelModel;

		// Token: 0x04024E48 RID: 151112
		private readonly Transform DragTipsWorldTrans = Transform.Create();

		// Token: 0x04024E49 RID: 151113
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x04024E4A RID: 151114
		private IItemRange ViewportItemRange;

		// Token: 0x04024E4B RID: 151115
		private UUIItem DragTipsItem;

		// Token: 0x04024E4C RID: 151116
		private bool DragTipsActive;

		// Token: 0x04024E4D RID: 151117
		private UiSequencePlayer TipsSequence;

		// Token: 0x0200C7EB RID: 51179
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D88D RID: 252045
			public const int EmptyItem = 0;

			// Token: 0x0403D88E RID: 252046
			public const int Count = 1;

			// Token: 0x0403D88F RID: 252047
			public const int ListItem = 2;

			// Token: 0x0403D890 RID: 252048
			public const int GridItem = 3;

			// Token: 0x0403D891 RID: 252049
			public const int Title = 4;

			// Token: 0x0403D892 RID: 252050
			public const int TitleSprite = 5;

			// Token: 0x0403D893 RID: 252051
			public const int HelpBtn = 6;

			// Token: 0x0403D894 RID: 252052
			public const int DragTips = 7;

			// Token: 0x0403D895 RID: 252053
			public const int TimeItem = 8;

			// Token: 0x0403D896 RID: 252054
			public const int TimeTips = 9;
		}
	}
}
