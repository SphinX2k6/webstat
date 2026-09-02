using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Cook.View
{
	// Token: 0x02005E22 RID: 24098
	public class CookRoleView : UiViewBase
	{
		// Token: 0x0603CA16 RID: 248342 RVA: 0x00F65977 File Offset: 0x00F63B77
		[NullableContext(1)]
		public CookRoleView(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x0603CA17 RID: 248343 RVA: 0x00F65980 File Offset: 0x00F63B80
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(delegate()
			{
				this.OnConfirm();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603CA18 RID: 248344 RVA: 0x00F65A68 File Offset: 0x00F63C68
		protected override void OnBeforeDestroy()
		{
			if (this.RoleItemScrollView != null)
			{
				this.RoleItemScrollView.ClearGridProxies();
				this.RoleItemScrollView = null;
			}
		}

		// Token: 0x0603CA19 RID: 248345 RVA: 0x00F65A84 File Offset: 0x00F63C84
		protected override void OnStart()
		{
			this.RoleItemScrollView = new LoopScrollView<CookRoleItem, ICookRoleItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<CookRoleItem>(this.OnGridProxyCreate), false);
			Singleton<LguiUtil>.Instance.SetLocalText(base.GetText(3), "CookSelectRoleButtonText", Array.Empty<object>());
			this.ShowView((this.OpenParam as int?).Value);
		}

		// Token: 0x0603CA1A RID: 248346 RVA: 0x00F65AFA File Offset: 0x00F63CFA
		protected override void OnBeforeShow()
		{
			IUiPopFrameInterface childPopView = this.ChildPopView;
			if (childPopView == null)
			{
				return;
			}
			CommonPopViewBase popItem = childPopView.PopItem;
			if (popItem == null)
			{
				return;
			}
			popItem.SetTexBgVisible(false);
		}

		// Token: 0x0603CA1B RID: 248347 RVA: 0x00F65B17 File Offset: 0x00F63D17
		[NullableContext(1)]
		private CookRoleItem OnGridProxyCreate()
		{
			CookRoleItem cookRoleItem = new CookRoleItem();
			cookRoleItem.BindOnClickedCallback(new Action<int>(this.RefreshConfirm));
			return cookRoleItem;
		}

		// Token: 0x0603CA1C RID: 248348 RVA: 0x00F65B30 File Offset: 0x00F63D30
		public void HideView(bool isHide)
		{
			this.SetActive(!isHide);
		}

		// Token: 0x0603CA1D RID: 248349 RVA: 0x00F65B3C File Offset: 0x00F63D3C
		public void ShowView(int itemId)
		{
			this.SetActive(true);
			ModelBase<CookModel>.Instance.CurrentCookViewType = ECookDataType.CookRole;
			this.ItemId = itemId;
			this.TmpId = ModelBase<CookModel>.Instance.CurrentCookRoleId.Value;
			this.RefreshCookRoleScroll();
		}

		// Token: 0x0603CA1E RID: 248350 RVA: 0x00F65B80 File Offset: 0x00F63D80
		private void RefreshCookRoleScroll()
		{
			this.RoleItemDataList = ModelBase<CookModel>.Instance.GetCookRoleItemDataList(this.ItemId);
			this.RoleItemScrollView.ReloadData(this.RoleItemDataList, false);
			this.SetSelectedPhantomItem();
		}

		// Token: 0x0603CA1F RID: 248351 RVA: 0x00F65BB0 File Offset: 0x00F63DB0
		private void SetSelectedPhantomItem()
		{
			int num = 0;
			this.RoleItemScrollView.DeselectCurrentGridProxy(false);
			if (this.RoleItemDataList.Count == 0)
			{
				return;
			}
			while (num < this.RoleItemDataList.Count && this.TmpId != this.RoleItemDataList[num].RoleId)
			{
				num++;
			}
			this.RoleItemScrollView.ScrollToGridIndex(num, true);
			this.RoleItemScrollView.SelectGridProxy(num, false);
		}

		// Token: 0x0603CA20 RID: 248352 RVA: 0x00F65C20 File Offset: 0x00F63E20
		private void RefreshConfirm(int roleId)
		{
			this.TmpId = roleId;
			int num = 0;
			this.RoleItemScrollView.DeselectCurrentGridProxy(false);
			if (this.RoleItemDataList.Count == 0)
			{
				return;
			}
			while (num < this.RoleItemDataList.Count && roleId != this.RoleItemDataList[num].RoleId)
			{
				num++;
			}
			this.RoleItemScrollView.SelectGridProxy(num, false);
			this.RoleItemScrollView.RefreshGridProxy(num);
		}

		// Token: 0x0603CA21 RID: 248353 RVA: 0x00F65C8F File Offset: 0x00F63E8F
		private void OnConfirm()
		{
			ModelBase<CookModel>.Instance.CurrentCookRoleId = new int?(this.TmpId);
			base.CloseMe(null);
			Singleton<EventSystem>.Instance.Emit(EEventName.CloseCookRole);
		}

		// Token: 0x04022104 RID: 139524
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<CookRoleItem, ICookRoleItemData> RoleItemScrollView;

		// Token: 0x04022105 RID: 139525
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICookRoleItemData> RoleItemDataList;

		// Token: 0x04022106 RID: 139526
		private int ItemId;

		// Token: 0x04022107 RID: 139527
		private int TmpId;

		// Token: 0x0200BE56 RID: 48726
		public enum ECookRoleDefine
		{
			// Token: 0x0403A99C RID: 240028
			CookRoleLoopScroll,
			// Token: 0x0403A99D RID: 240029
			CookRoleItem,
			// Token: 0x0403A99E RID: 240030
			ConfirmButton,
			// Token: 0x0403A99F RID: 240031
			TxtConfirm
		}
	}
}
