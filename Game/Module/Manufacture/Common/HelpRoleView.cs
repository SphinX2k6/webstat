using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Manufacture.Common
{
	// Token: 0x020059E8 RID: 23016
	public class HelpRoleView : UiNavigationView
	{
		// Token: 0x0603A4ED RID: 238829 RVA: 0x00EC83BC File Offset: 0x00EC65BC
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
			*span2[num] = new ValueTuple<int, Delegate>(2, new Action(this.OnConfirm));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603A4EE RID: 238830 RVA: 0x00EC84A4 File Offset: 0x00EC66A4
		protected override void OnBeforeDestroy()
		{
			if (this.RoleItemScrollView != null)
			{
				this.RoleItemScrollView.ClearGridProxies();
				this.RoleItemScrollView = null;
			}
		}

		// Token: 0x0603A4EF RID: 238831 RVA: 0x00EC84C0 File Offset: 0x00EC66C0
		protected override void OnStart()
		{
			this.RoleItemScrollView = new LoopScrollView<HelpRoleItem, ICommonRoleItemData>(base.GetLoopScrollViewComponent(0), base.GetItem(1).GetOwner() as AUIBaseActor, new Func<HelpRoleItem>(this.OnGridProxyCreate), false);
		}

		// Token: 0x0603A4F0 RID: 238832 RVA: 0x00EC84F2 File Offset: 0x00EC66F2
		[NullableContext(1)]
		private HelpRoleItem OnGridProxyCreate()
		{
			HelpRoleItem helpRoleItem = new HelpRoleItem();
			helpRoleItem.BindOnClickedCallback(new Action<int>(this.RefreshConfirm));
			return helpRoleItem;
		}

		// Token: 0x0603A4F1 RID: 238833 RVA: 0x00EC850B File Offset: 0x00EC670B
		public void HideView(bool isHide)
		{
			this.SetActive(!isHide);
		}

		// Token: 0x0603A4F2 RID: 238834 RVA: 0x00EC8518 File Offset: 0x00EC6718
		public void ShowView(int itemId)
		{
			this.SetActive(true);
			Singleton<EventSystem>.Instance.Emit<EViewType>(EEventName.SwitchViewType, EViewType.RoleViewType);
			this.ItemId = itemId;
			this.TmpId = Singleton<CommonManager>.Instance.GetCurrentRoleId().Value;
			this.RefreshHelpRoleScroll();
		}

		// Token: 0x0603A4F3 RID: 238835 RVA: 0x00EC8562 File Offset: 0x00EC6762
		private void RefreshHelpRoleScroll()
		{
			this.RoleItemDataList = Singleton<CommonManager>.Instance.GetHelpRoleItemDataList(this.ItemId);
			this.RoleItemScrollView.ReloadData(this.RoleItemDataList, false);
			this.SetSelectedRoleItem();
		}

		// Token: 0x0603A4F4 RID: 238836 RVA: 0x00EC8594 File Offset: 0x00EC6794
		private void SetSelectedRoleItem()
		{
			int num = 0;
			this.RoleItemScrollView.DeselectCurrentGridProxy(false);
			while (num < this.RoleItemDataList.Count && this.TmpId != this.RoleItemDataList[num].RoleId)
			{
				num++;
			}
			this.RoleItemScrollView.ScrollToGridIndex(num, true);
			this.RoleItemScrollView.SelectGridProxy(num, false);
		}

		// Token: 0x0603A4F5 RID: 238837 RVA: 0x00EC85F8 File Offset: 0x00EC67F8
		private void RefreshConfirm(int roleId)
		{
			this.TmpId = roleId;
			int num = 0;
			this.RoleItemScrollView.DeselectCurrentGridProxy(false);
			while (num < this.RoleItemDataList.Count && roleId != this.RoleItemDataList[num].RoleId)
			{
				num++;
			}
			if (!this.RoleItemScrollView.IsGridDisplaying(num))
			{
				return;
			}
			this.RoleItemScrollView.SelectGridProxy(num, false);
			this.RoleItemScrollView.RefreshGridProxy(num);
		}

		// Token: 0x0603A4F6 RID: 238838 RVA: 0x00EC866A File Offset: 0x00EC686A
		private void OnConfirm()
		{
			Singleton<CommonManager>.Instance.SetCurrentRoleId(this.TmpId);
			Singleton<EventSystem>.Instance.Emit(EEventName.CloseHelpRole);
		}

		// Token: 0x0402108E RID: 135310
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<HelpRoleItem, ICommonRoleItemData> RoleItemScrollView;

		// Token: 0x0402108F RID: 135311
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ICommonRoleItemData> RoleItemDataList;

		// Token: 0x04021090 RID: 135312
		private int ItemId;

		// Token: 0x04021091 RID: 135313
		private int TmpId;

		// Token: 0x0200B9B6 RID: 47542
		private class EHelpRoleDefine
		{
			// Token: 0x04039628 RID: 235048
			public const int HelpRoleLoopScroll = 0;

			// Token: 0x04039629 RID: 235049
			public const int HelpRoleItem = 1;

			// Token: 0x0403962A RID: 235050
			public const int ConfirmButton = 2;

			// Token: 0x0403962B RID: 235051
			public const int ConfirmText = 3;
		}
	}
}
