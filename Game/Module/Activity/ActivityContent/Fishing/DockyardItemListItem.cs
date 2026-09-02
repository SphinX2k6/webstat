using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067B8 RID: 26552
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class DockyardItemListItem : GridProxyAbstract<DockyardItemBlockOriginalData>
	{
		// Token: 0x060423B1 RID: 271281 RVA: 0x010FDAB4 File Offset: 0x010FBCB4
		protected unsafe override void OnRegisterComponent()
		{
			this.ParentModel = (this.OpenParam as DockyardItemListPanelModel);
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x060423B2 RID: 271282 RVA: 0x010FDC18 File Offset: 0x010FBE18
		private void InitDrag()
		{
			this.ExtendToggle = base.GetExtendToggle(0);
			if (!this.NeedInteract)
			{
				this.ExtendToggle.SetSelfInteractive(false);
				this.ExtendToggle.SetCanClickWhenDisable(false);
				return;
			}
			this.ExtendToggle.OnPointDownCallBack.Bind(new Action<EToggleState>(this.OnPointerDown));
			this.ExtendToggle.CanExecuteChange.Bind(new Func<bool>(this.CanExecuteChange));
			this.ExtendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnPointerClick));
			this.ExtendToggle.OnPointerBeginDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnDragBegin));
			this.ExtendToggle.OnPointerDragCallBack.Bind(new Func<ULGUIPointerEventData, bool>(this.OnDrag));
		}

		// Token: 0x060423B3 RID: 271283 RVA: 0x010FDCE0 File Offset: 0x010FBEE0
		private UniTask InitListLayout(int tag, UUIItem layoutItem)
		{
			DockyardItemListItem.<InitListLayout>d__14 <InitListLayout>d__;
			<InitListLayout>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitListLayout>d__.<>4__this = this;
			<InitListLayout>d__.tag = tag;
			<InitListLayout>d__.layoutItem = layoutItem;
			<InitListLayout>d__.<>1__state = -1;
			<InitListLayout>d__.<>t__builder.Start<DockyardItemListItem.<InitListLayout>d__14>(ref <InitListLayout>d__);
			return <InitListLayout>d__.<>t__builder.Task;
		}

		// Token: 0x060423B4 RID: 271284 RVA: 0x010FDD34 File Offset: 0x010FBF34
		private void RefreshDelegateItem(int itemId)
		{
			bool uiactive = ModelBase<FishingQuestModel>.Instance.IsUnDeliverableByItemId(itemId);
			base.GetItem(8).SetUIActive(uiactive);
		}

		// Token: 0x060423B5 RID: 271285 RVA: 0x010FDD5C File Offset: 0x010FBF5C
		private void SetToggleState(bool isActive)
		{
			EToggleState state = isActive ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			base.GetExtendToggle(0).SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x060423B6 RID: 271286 RVA: 0x010FDD84 File Offset: 0x010FBF84
		protected override UniTask OnBeforeStartAsync()
		{
			DockyardItemListItem.<OnBeforeStartAsync>d__17 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<DockyardItemListItem.<OnBeforeStartAsync>d__17>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060423B7 RID: 271287 RVA: 0x010FDDC7 File Offset: 0x010FBFC7
		protected override void OnStart()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.FishingBackpackDeliverableRefresh, new Action(this.RefreshCurrentDelegateItem));
		}

		// Token: 0x060423B8 RID: 271288 RVA: 0x010FDDE5 File Offset: 0x010FBFE5
		protected override void OnBeforeDestroy()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.FishingBackpackDeliverableRefresh, new Action(this.RefreshCurrentDelegateItem));
		}

		// Token: 0x060423B9 RID: 271289 RVA: 0x010FDE04 File Offset: 0x010FC004
		private void HideListLayout()
		{
			foreach (ListLayout listLayout in this.ListLayoutMap.Values)
			{
				listLayout.GetRootItem().SetUIActive(false);
			}
		}

		// Token: 0x060423BA RID: 271290 RVA: 0x010FDE60 File Offset: 0x010FC060
		private UniTask RefreshTexture(int itemId)
		{
			DockyardItemListItem.<RefreshTexture>d__21 <RefreshTexture>d__;
			<RefreshTexture>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshTexture>d__.<>4__this = this;
			<RefreshTexture>d__.itemId = itemId;
			<RefreshTexture>d__.<>1__state = -1;
			<RefreshTexture>d__.<>t__builder.Start<DockyardItemListItem.<RefreshTexture>d__21>(ref <RefreshTexture>d__);
			return <RefreshTexture>d__.<>t__builder.Task;
		}

		// Token: 0x060423BB RID: 271291 RVA: 0x010FDEAC File Offset: 0x010FC0AC
		private void ShowListLayout(List<List<int>> dataDoublyList, int qualityId)
		{
			int count = dataDoublyList[0].Count;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Dockyard;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "列表格子显示长度";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("tag", count);
			instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			int key = Math.Max(count, 3);
			ListLayout listLayout = this.ListLayoutMap[key];
			this.TempLayout = listLayout.GetRootItem();
			this.TempLayout.SetUIActive(true);
			listLayout.RefreshAsync(dataDoublyList, qualityId);
		}

		// Token: 0x060423BC RID: 271292 RVA: 0x010FDF2C File Offset: 0x010FC12C
		private void RefreshCup(int cup, int itemId)
		{
			bool flag = ConfigBase<FishingConfig>.Instance.GetFishingItemConfig(itemId).Value.Type == 1;
			UUITexture texture = base.GetTexture(1);
			string texturePathByCup = DockyardPanelUtil.GetTexturePathByCup(cup);
			bool flag2 = !StringUtils.IsBlank(texturePathByCup) && flag;
			texture.SetUIActive(flag2);
			if (flag2)
			{
				base.SetTextureByPath(texturePathByCup, texture, null, null);
			}
		}

		// Token: 0x060423BD RID: 271293 RVA: 0x010FDF94 File Offset: 0x010FC194
		private void RefreshPrice(int price)
		{
			base.GetText(2).SetText(price.ToString(), true);
		}

		// Token: 0x060423BE RID: 271294 RVA: 0x010FDFAA File Offset: 0x010FC1AA
		private void OnPointerClick(EToggleState state)
		{
			DockyardItemListPanelModel parentModel = this.ParentModel;
			if (parentModel == null)
			{
				return;
			}
			parentModel.DragClick(this.ItemData);
		}

		// Token: 0x060423BF RID: 271295 RVA: 0x010FDFC4 File Offset: 0x010FC1C4
		private void OnPointerDown(EToggleState state)
		{
			ULGUIPointerEventData pointerEventData = Singleton<LguiEventSystemManager>.Instance.GetPointerEventData(0, false);
			if (pointerEventData != null)
			{
				this.MoveDistance = 0.0;
				Vector lastPosition = this.LastPosition;
				FVector pointerPosition = pointerEventData.pointerPosition;
				FVectorDouble fvectorDouble = pointerPosition;
				lastPosition.DeepCopy(fvectorDouble);
				this.IsCanDrag = true;
			}
		}

		// Token: 0x060423C0 RID: 271296 RVA: 0x010FE013 File Offset: 0x010FC213
		private bool CanExecuteChange()
		{
			return this.ParentModel == null || this.ParentModel.InSelectedBlockId != this.ItemData.IncId;
		}

		// Token: 0x060423C1 RID: 271297 RVA: 0x010FE03C File Offset: 0x010FC23C
		private bool OnDragBegin(ULGUIPointerEventData eventData)
		{
			Vector currentPosition = this.CurrentPosition;
			FVector pointerPosition = eventData.pointerPosition;
			FVectorDouble fvectorDouble = pointerPosition;
			currentPosition.DeepCopy(fvectorDouble);
			double angleByVector2D = Singleton<MathUtils>.Instance.GetAngleByVector2D(this.CurrentPosition.SubtractionEqual(this.LastPosition));
			if (Math.Abs(angleByVector2D) < 45.0 || Math.Abs(angleByVector2D) > 135.0)
			{
				return false;
			}
			this.IsCanDrag = false;
			return true;
		}

		// Token: 0x060423C2 RID: 271298 RVA: 0x010FE0AD File Offset: 0x010FC2AD
		private void RefreshCurrentDelegateItem()
		{
			if (this.ItemData != null)
			{
				this.RefreshDelegateItem(this.ItemData.ItemId);
			}
		}

		// Token: 0x060423C3 RID: 271299 RVA: 0x010FE0C8 File Offset: 0x010FC2C8
		private bool OnDrag(ULGUIPointerEventData eventData)
		{
			if (!this.IsCanDrag)
			{
				return true;
			}
			Vector currentPosition = this.CurrentPosition;
			FVector pointerPosition = eventData.pointerPosition;
			FVectorDouble fvectorDouble = pointerPosition;
			currentPosition.DeepCopy(fvectorDouble);
			double num = this.CurrentPosition.X - this.LastPosition.X;
			this.MoveDistance += num;
			this.LastPosition.DeepCopy(this.CurrentPosition);
			if (Math.Abs(this.MoveDistance) > 50.0)
			{
				DockyardItemListPanelModel parentModel = this.ParentModel;
				if (parentModel != null)
				{
					parentModel.DragBegin(this.ItemData);
				}
				this.IsCanDrag = false;
			}
			return true;
		}

		// Token: 0x060423C4 RID: 271300 RVA: 0x010FE168 File Offset: 0x010FC368
		public override void Refresh(DockyardItemBlockOriginalData data, bool isSelected, int gridIndex)
		{
			this.HideListLayout();
			this.ItemData = data;
			this.RefreshRedDot();
			this.RefreshPrice(data.Price);
			this.RefreshCup(data.Cup, data.ItemId);
			this.ShowListLayout(data.ValidDoublyList, data.Quality);
			this.RefreshTexture(data.ItemId);
			this.RefreshDelegateItem(data.ItemId);
			this.RefreshToggleState();
		}

		// Token: 0x060423C5 RID: 271301 RVA: 0x010FE1D8 File Offset: 0x010FC3D8
		public void RefreshRedDot()
		{
			bool flag = ModelBase<DockyardModel>.Instance.CheckListItemReadFlag(this.ItemData.ItemId);
			base.GetItem(3).SetUIActive(!flag);
		}

		// Token: 0x060423C6 RID: 271302 RVA: 0x010FE20C File Offset: 0x010FC40C
		public void RefreshToggleState()
		{
			if (this.ParentModel != null)
			{
				bool toggleState = this.ParentModel.InSelectedBlockId == this.ItemData.IncId;
				this.SetToggleState(toggleState);
				return;
			}
			this.SetToggleState(false);
		}

		// Token: 0x060423C7 RID: 271303 RVA: 0x010FE249 File Offset: 0x010FC449
		public override object GetKey(DockyardItemBlockOriginalData data, int displayIndex)
		{
			return this.ItemData;
		}

		// Token: 0x04024E3B RID: 151099
		private const int MOVE_DISTANCE = 50;

		// Token: 0x04024E3C RID: 151100
		protected DockyardItemBlockOriginalData ItemData;

		// Token: 0x04024E3D RID: 151101
		protected DockyardItemListPanelModel ParentModel;

		// Token: 0x04024E3E RID: 151102
		protected Dictionary<int, ListLayout> ListLayoutMap = new Dictionary<int, ListLayout>();

		// Token: 0x04024E3F RID: 151103
		private UUIItem TempLayout;

		// Token: 0x04024E40 RID: 151104
		private double MoveDistance;

		// Token: 0x04024E41 RID: 151105
		private readonly Vector LastPosition = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04024E42 RID: 151106
		private readonly Vector CurrentPosition = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x04024E43 RID: 151107
		private bool IsCanDrag;

		// Token: 0x04024E44 RID: 151108
		private UUIExtendToggle ExtendToggle;

		// Token: 0x04024E45 RID: 151109
		public bool NeedInteract = true;

		// Token: 0x0200C7E7 RID: 51175
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x0403D873 RID: 252019
			public const int DraggableItem = 0;

			// Token: 0x0403D874 RID: 252020
			public const int CupIcon = 1;

			// Token: 0x0403D875 RID: 252021
			public const int TxtPrice = 2;

			// Token: 0x0403D876 RID: 252022
			public const int NewItem = 3;

			// Token: 0x0403D877 RID: 252023
			public const int FirstLayoutItem = 4;

			// Token: 0x0403D878 RID: 252024
			public const int SecondLayoutItem = 5;

			// Token: 0x0403D879 RID: 252025
			public const int ThirdLayoutItem = 6;

			// Token: 0x0403D87A RID: 252026
			public const int Texture = 7;

			// Token: 0x0403D87B RID: 252027
			public const int DelegateItem = 8;
		}
	}
}
