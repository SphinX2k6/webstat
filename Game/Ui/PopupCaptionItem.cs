using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.UiComponent.UiHomeButton;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049C8 RID: 18888
	[NullableContext(1)]
	[Nullable(0)]
	public class PopupCaptionItem : UiPanelBase
	{
		// Token: 0x06031696 RID: 202390 RVA: 0x00C4B6C5 File Offset: 0x00C498C5
		[NullableContext(2)]
		public PopupCaptionItem(UUIItem item = null)
		{
			if (item == null)
			{
				return;
			}
			base.CreateThenShowByActor(item.GetOwner(), null);
		}

		// Token: 0x06031697 RID: 202391 RVA: 0x00C4B6E0 File Offset: 0x00C498E0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnClickCloseBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnClickHelpBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06031698 RID: 202392 RVA: 0x00C4B86F File Offset: 0x00C49A6F
		protected override void OnStart()
		{
			this.CurrencyItemListComponent = new CommonCurrencyItemListComponent(base.GetItem(4));
		}

		// Token: 0x06031699 RID: 202393 RVA: 0x00C4B883 File Offset: 0x00C49A83
		private void OnClickCloseBtn()
		{
			if (this.OnClickCloseBtnCall != null)
			{
				this.OnClickCloseBtnCall();
			}
		}

		// Token: 0x0603169A RID: 202394 RVA: 0x00C4B898 File Offset: 0x00C49A98
		private void OnClickHelpBtn()
		{
			if (this.OnClickHelpBtnCall != null)
			{
				this.OnClickHelpBtnCall();
			}
		}

		// Token: 0x0603169B RID: 202395 RVA: 0x00C4B8B0 File Offset: 0x00C49AB0
		public void SetCloseBtnActive(bool state)
		{
			UUIItem uuiitem = base.GetButton(3).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(state);
			}
			this.SetHomeBtnShowState(state);
		}

		// Token: 0x0603169C RID: 202396 RVA: 0x00C4B8E4 File Offset: 0x00C49AE4
		public void SetHelpBtnActive(bool state)
		{
			UUIItem uuiitem = base.GetButton(2).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetUIActive(state);
		}

		// Token: 0x0603169D RID: 202397 RVA: 0x00C4B910 File Offset: 0x00C49B10
		public void SetCloseCallBack(Action call)
		{
			this.OnClickCloseBtnCall = call;
		}

		// Token: 0x0603169E RID: 202398 RVA: 0x00C4B919 File Offset: 0x00C49B19
		public void SetHelpCallBack(Action call)
		{
			this.OnClickHelpBtnCall = call;
		}

		// Token: 0x0603169F RID: 202399 RVA: 0x00C4B924 File Offset: 0x00C49B24
		public void SetCloseBtnRaycast(bool state)
		{
			UUIItem uuiitem = base.GetButton(3).RootUIComp.Get();
			if (uuiitem == null)
			{
				return;
			}
			uuiitem.SetRaycastTarget(state);
		}

		// Token: 0x060316A0 RID: 202400 RVA: 0x00C4B950 File Offset: 0x00C49B50
		public void SetCloseBtnShowState(bool state)
		{
			UUIItem uuiitem = base.GetButton(3).RootUIComp.Get();
			if (uuiitem != null)
			{
				uuiitem.SetUIActive(state);
			}
			this.SetHomeBtnShowState(state);
		}

		// Token: 0x060316A1 RID: 202401 RVA: 0x00C4B984 File Offset: 0x00C49B84
		public void SetHomeBtnShowState(bool state)
		{
			base.GetItem(6).SetUIActive(state);
		}

		// Token: 0x060316A2 RID: 202402 RVA: 0x00C4B993 File Offset: 0x00C49B93
		public void SetTitle(string title)
		{
			base.GetText(1).SetText(title, true);
		}

		// Token: 0x060316A3 RID: 202403 RVA: 0x00C4B9A3 File Offset: 0x00C49BA3
		public void SetTitleByTextIdAndArg(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(1), textId, args);
		}

		// Token: 0x060316A4 RID: 202404 RVA: 0x00C4B9B8 File Offset: 0x00C49BB8
		public void SetTitleByTextIdAndArgNew(string textId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, args);
		}

		// Token: 0x060316A5 RID: 202405 RVA: 0x00C4B9CD File Offset: 0x00C49BCD
		public void SetTitleByTitleData(CommonTabTitleData titleData)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), titleData.TextId, titleData.Args);
		}

		// Token: 0x060316A6 RID: 202406 RVA: 0x00C4B9EC File Offset: 0x00C49BEC
		public void SetTitleLocalText(string textId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(1), textId, Array.Empty<object>());
		}

		// Token: 0x060316A7 RID: 202407 RVA: 0x00C4BA08 File Offset: 0x00C49C08
		public UniTask SetTitleIconByResourceId(string resourceId)
		{
			PopupCaptionItem.<SetTitleIconByResourceId>d__23 <SetTitleIconByResourceId>d__;
			<SetTitleIconByResourceId>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetTitleIconByResourceId>d__.<>4__this = this;
			<SetTitleIconByResourceId>d__.resourceId = resourceId;
			<SetTitleIconByResourceId>d__.<>1__state = -1;
			<SetTitleIconByResourceId>d__.<>t__builder.Start<PopupCaptionItem.<SetTitleIconByResourceId>d__23>(ref <SetTitleIconByResourceId>d__);
			return <SetTitleIconByResourceId>d__.<>t__builder.Task;
		}

		// Token: 0x060316A8 RID: 202408 RVA: 0x00C4BA54 File Offset: 0x00C49C54
		public void SetTitleIcon(string iconPath)
		{
			this.SetSpriteByPath(iconPath, base.GetSprite(0), false, null, null);
		}

		// Token: 0x060316A9 RID: 202409 RVA: 0x00C4BA7A File Offset: 0x00C49C7A
		public void SetTitleTextActive(bool value)
		{
			base.GetText(1).SetUIActive(value);
		}

		// Token: 0x060316AA RID: 202410 RVA: 0x00C4BA89 File Offset: 0x00C49C89
		public void SetTitleIconVisible(bool bVisible)
		{
			base.GetSprite(0).SetUIActive(bVisible);
		}

		// Token: 0x060316AB RID: 202411 RVA: 0x00C4BA98 File Offset: 0x00C49C98
		public void SetCurrencyItemVisible(bool bVisible)
		{
			base.GetItem(4).SetUIActive(bVisible);
		}

		// Token: 0x060316AC RID: 202412 RVA: 0x00C4BAA8 File Offset: 0x00C49CA8
		public UniTask SetCurrencyItemList(int[] itemIdList)
		{
			PopupCaptionItem.<SetCurrencyItemList>d__28 <SetCurrencyItemList>d__;
			<SetCurrencyItemList>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<SetCurrencyItemList>d__.<>4__this = this;
			<SetCurrencyItemList>d__.itemIdList = itemIdList;
			<SetCurrencyItemList>d__.<>1__state = -1;
			<SetCurrencyItemList>d__.<>t__builder.Start<PopupCaptionItem.<SetCurrencyItemList>d__28>(ref <SetCurrencyItemList>d__);
			return <SetCurrencyItemList>d__.<>t__builder.Task;
		}

		// Token: 0x060316AD RID: 202413 RVA: 0x00C4BAF3 File Offset: 0x00C49CF3
		public void SetCurrencyItemResourceId(string resourceId)
		{
			CommonCurrencyItemListComponent currencyItemListComponent = this.CurrencyItemListComponent;
			if (currencyItemListComponent == null)
			{
				return;
			}
			currencyItemListComponent.SetResourceId(resourceId);
		}

		// Token: 0x060316AE RID: 202414 RVA: 0x00C4BB06 File Offset: 0x00C49D06
		[return: Nullable(new byte[]
		{
			2,
			1
		})]
		public List<CommonCurrencyItem> GetCurrencyItemList()
		{
			CommonCurrencyItemListComponent currencyItemListComponent = this.CurrencyItemListComponent;
			if (currencyItemListComponent == null)
			{
				return null;
			}
			return currencyItemListComponent.GetCurrencyItemList();
		}

		// Token: 0x060316AF RID: 202415 RVA: 0x00C4BB1C File Offset: 0x00C49D1C
		public void SetCurrencyItemBtnFunction(int itemId, Action<int> callBack)
		{
			CommonCurrencyItemListComponent currencyItemListComponent = this.CurrencyItemListComponent;
			List<CommonCurrencyItem> list = (currencyItemListComponent != null) ? currencyItemListComponent.GetCurrencyItemList() : null;
			if (list != null)
			{
				foreach (CommonCurrencyItem commonCurrencyItem in list)
				{
					if (commonCurrencyItem.ItemId == itemId)
					{
						commonCurrencyItem.SetButtonFunction(callBack);
						break;
					}
				}
			}
		}

		// Token: 0x060316B0 RID: 202416 RVA: 0x00C4BB8C File Offset: 0x00C49D8C
		public UniTask CreateToggleTab(Action<EToggleState> callback)
		{
			PopupCaptionItem.<CreateToggleTab>d__32 <CreateToggleTab>d__;
			<CreateToggleTab>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateToggleTab>d__.<>4__this = this;
			<CreateToggleTab>d__.callback = callback;
			<CreateToggleTab>d__.<>1__state = -1;
			<CreateToggleTab>d__.<>t__builder.Start<PopupCaptionItem.<CreateToggleTab>d__32>(ref <CreateToggleTab>d__);
			return <CreateToggleTab>d__.<>t__builder.Task;
		}

		// Token: 0x060316B1 RID: 202417 RVA: 0x00C4BBD7 File Offset: 0x00C49DD7
		public void SetToggleName(string name)
		{
			PopupCaptionToggleItem toggleItem = this.ToggleItem;
			if (toggleItem == null)
			{
				return;
			}
			toggleItem.SetNameText(name);
		}

		// Token: 0x060316B2 RID: 202418 RVA: 0x00C4BBEA File Offset: 0x00C49DEA
		public void SetToggleVisible(bool visible)
		{
			PopupCaptionToggleItem toggleItem = this.ToggleItem;
			if (toggleItem == null)
			{
				return;
			}
			toggleItem.SetUiActive(visible);
		}

		// Token: 0x060316B3 RID: 202419 RVA: 0x00C4BBFD File Offset: 0x00C49DFD
		public EToggleState GetToggleState()
		{
			if (this.ToggleItem == null)
			{
				return EToggleState.ETT_UnChecked;
			}
			return this.ToggleItem.GetToggleState();
		}

		// Token: 0x060316B4 RID: 202420 RVA: 0x00C4BC14 File Offset: 0x00C49E14
		public UUIItem GetCostContent()
		{
			return base.GetItem(4);
		}

		// Token: 0x060316B5 RID: 202421 RVA: 0x00C4BC20 File Offset: 0x00C49E20
		public UniTask CreateCaptionStateItem(Action callback)
		{
			PopupCaptionItem.<CreateCaptionStateItem>d__37 <CreateCaptionStateItem>d__;
			<CreateCaptionStateItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateCaptionStateItem>d__.<>4__this = this;
			<CreateCaptionStateItem>d__.callback = callback;
			<CreateCaptionStateItem>d__.<>1__state = -1;
			<CreateCaptionStateItem>d__.<>t__builder.Start<PopupCaptionItem.<CreateCaptionStateItem>d__37>(ref <CreateCaptionStateItem>d__);
			return <CreateCaptionStateItem>d__.<>t__builder.Task;
		}

		// Token: 0x060316B6 RID: 202422 RVA: 0x00C4BC6B File Offset: 0x00C49E6B
		public void SetCaptionStateTip(string localKey)
		{
			PopupCaptionStateItem captionStateItem = this.CaptionStateItem;
			if (captionStateItem == null)
			{
				return;
			}
			captionStateItem.SetTipsLocalText(localKey);
		}

		// Token: 0x060316B7 RID: 202423 RVA: 0x00C4BC7E File Offset: 0x00C49E7E
		public void SetCaptionStateActive(bool active)
		{
			PopupCaptionStateItem captionStateItem = this.CaptionStateItem;
			if (captionStateItem == null)
			{
				return;
			}
			captionStateItem.SetActive(active);
		}

		// Token: 0x060316B8 RID: 202424 RVA: 0x00C4BC91 File Offset: 0x00C49E91
		public void SetCaptionChangeColor(bool useChangeColor)
		{
			PopupCaptionStateItem captionStateItem = this.CaptionStateItem;
			if (captionStateItem == null)
			{
				return;
			}
			captionStateItem.SetCaptionChangeColor(useChangeColor);
		}

		// Token: 0x060316B9 RID: 202425 RVA: 0x00C4BCA4 File Offset: 0x00C49EA4
		public UUIItem GetToggleRootItem()
		{
			return base.GetItem(5);
		}

		// Token: 0x060316BA RID: 202426 RVA: 0x00C4BCAD File Offset: 0x00C49EAD
		[NullableContext(2)]
		public void CreateHomeBtn(EUiViewName viewName, string tag = null, bool snapSize = false)
		{
			ControllerBase<HomeBtnController>.Instance.CreateHomeBtnFromUiItem(base.GetItem(6), viewName, tag, snapSize);
		}

		// Token: 0x060316BB RID: 202427 RVA: 0x00C4BCC3 File Offset: 0x00C49EC3
		public UUIItem GetHomeBtnRootItem()
		{
			return base.GetItem(6);
		}

		// Token: 0x060316BC RID: 202428 RVA: 0x00C4BCCC File Offset: 0x00C49ECC
		[NullableContext(2)]
		public UUIItem GetTitleIconRootItem()
		{
			return base.GetItem(7);
		}

		// Token: 0x060316BD RID: 202429 RVA: 0x00C4BCD5 File Offset: 0x00C49ED5
		public UUIButtonComponent GetHelpBtn()
		{
			return base.GetButton(2);
		}

		// Token: 0x060316BE RID: 202430 RVA: 0x00C4BCDE File Offset: 0x00C49EDE
		public UUIButtonComponent GetCloseBtn()
		{
			return base.GetButton(3);
		}

		// Token: 0x0401C5FA RID: 116218
		private CommonCurrencyItemListComponent CurrencyItemListComponent;

		// Token: 0x0401C5FB RID: 116219
		private PopupCaptionToggleItem ToggleItem;

		// Token: 0x0401C5FC RID: 116220
		private PopupCaptionStateItem CaptionStateItem;

		// Token: 0x0401C5FD RID: 116221
		protected Action OnClickCloseBtnCall;

		// Token: 0x0401C5FE RID: 116222
		protected Action OnClickHelpBtnCall;

		// Token: 0x0200AA4E RID: 43598
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x04034B17 RID: 215831
			public const int TitleIcon = 0;

			// Token: 0x04034B18 RID: 215832
			public const int Title = 1;

			// Token: 0x04034B19 RID: 215833
			public const int HelpBtn = 2;

			// Token: 0x04034B1A RID: 215834
			public const int BackBtn = 3;

			// Token: 0x04034B1B RID: 215835
			public const int CostContent = 4;

			// Token: 0x04034B1C RID: 215836
			public const int ToggleRoot = 5;

			// Token: 0x04034B1D RID: 215837
			public const int HomeBtnRoot = 6;

			// Token: 0x04034B1E RID: 215838
			public const int TitleIconRoot = 7;
		}
	}
}
