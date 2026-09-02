using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Kurotato.Data;
using CSharpScript.Game.Module.Kurotato.View.KurotatoLevelSelect;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Kurotato.View.HandBook
{
	// Token: 0x02005AB9 RID: 23225
	[NullableContext(1)]
	[Nullable(0)]
	public class KurotatoHandBookView : UiViewBase
	{
		// Token: 0x0603AB9E RID: 240542 RVA: 0x00EE3588 File Offset: 0x00EE1788
		public KurotatoHandBookView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603AB9F RID: 240543 RVA: 0x00EE359C File Offset: 0x00EE179C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603ABA0 RID: 240544 RVA: 0x00EE3608 File Offset: 0x00EE1808
		protected override UniTask OnBeforeStartAsync()
		{
			KurotatoHandBookView.<OnBeforeStartAsync>d__6 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<KurotatoHandBookView.<OnBeforeStartAsync>d__6>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603ABA1 RID: 240545 RVA: 0x00EE364C File Offset: 0x00EE184C
		protected override void OnBeforeShow()
		{
			KurotatoLevelSelectViewData kurotatoLevelSelectViewData = this.OpenParam as KurotatoLevelSelectViewData;
			if (kurotatoLevelSelectViewData != null)
			{
				int? roleId = kurotatoLevelSelectViewData.RoleId;
				int num = 0;
				if (roleId.GetValueOrDefault() > num & roleId != null)
				{
					this.TabComponent.SelectToggleByIndex(1, false);
					goto IL_48;
				}
			}
			this.TabComponent.SelectToggleByIndex(0, false);
			IL_48:
			this.BindRedDot();
		}

		// Token: 0x0603ABA2 RID: 240546 RVA: 0x00EE36A7 File Offset: 0x00EE18A7
		protected override void OnBeforeHide()
		{
			this.ReadCurrentTabRedDot();
			this.UnBindRedDot();
		}

		// Token: 0x0603ABA3 RID: 240547 RVA: 0x00EE36B5 File Offset: 0x00EE18B5
		private void OnClickBtnBack()
		{
			base.CloseMe(null);
		}

		// Token: 0x0603ABA4 RID: 240548 RVA: 0x00EE36BE File Offset: 0x00EE18BE
		private void OnClickBtnHelp()
		{
			ControllerBase<HelpController>.Instance.OpenHelpById(575);
		}

		// Token: 0x0603ABA5 RID: 240549 RVA: 0x00EE36CF File Offset: 0x00EE18CF
		private CommonTabItem TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
		{
			return new KurotatoTabItem();
		}

		// Token: 0x0603ABA6 RID: 240550 RVA: 0x00EE36D8 File Offset: 0x00EE18D8
		private void ToggleCallBack(int index)
		{
			UiDynamicTab data = this.TabDataList[index];
			EUiTabViewName viewName = (EUiTabViewName)data.ChildViewName;
			CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(index);
			KurotatoHandBookTabViewData extraParams = new KurotatoHandBookTabViewData
			{
				OnCloseView = new Action(this.OnClickBtnBack),
				LevelSelectViewData = (this.OpenParam as KurotatoLevelSelectViewData)
			};
			this.TabViewComponent.ToggleCallBack(data, viewName, tabItemByIndex, extraParams, null);
		}

		// Token: 0x0603ABA7 RID: 240551 RVA: 0x00EE3750 File Offset: 0x00EE1950
		private CommonTabData GetCommonData(int index)
		{
			UiDynamicTab uiDynamicTab = this.TabDataList[index];
			return new CommonTabData(uiDynamicTab.Icon, new CommonTabTitleData(uiDynamicTab.TabName, Array.Empty<object>()), null);
		}

		// Token: 0x0603ABA8 RID: 240552 RVA: 0x00EE3788 File Offset: 0x00EE1988
		private void BindRedDot()
		{
			this.BindRedDotByName(EUiTabViewName.KurotatoHandBookRoleTabView, ERedDotName.RedDotKurotatoRole, true);
			this.BindRedDotByName(EUiTabViewName.KurotatoHandBookWeaponTabView, ERedDotName.RedDotKurotatoWeaponAndProp, true);
		}

		// Token: 0x0603ABA9 RID: 240553 RVA: 0x00EE37AC File Offset: 0x00EE19AC
		private void UnBindRedDot()
		{
			this.BindRedDotByName(EUiTabViewName.KurotatoHandBookRoleTabView, ERedDotName.RedDotKurotatoRole, false);
			this.BindRedDotByName(EUiTabViewName.KurotatoHandBookWeaponTabView, ERedDotName.RedDotKurotatoWeaponAndProp, false);
		}

		// Token: 0x0603ABAA RID: 240554 RVA: 0x00EE37D0 File Offset: 0x00EE19D0
		private void ReadCurrentTabRedDot()
		{
			int selectedIndex = this.TabComponent.GetSelectedIndex();
			if (selectedIndex < 0)
			{
				return;
			}
			EUiTabViewName left = (EUiTabViewName)this.TabDataList[selectedIndex].ChildViewName;
			KurotatoActivityData activityData = ControllerBase<KurotatoActivityController>.Instance.GetActivityData();
			if (left == EUiTabViewName.KurotatoHandBookRoleTabView)
			{
				activityData.ReadRoleRedDot();
				return;
			}
			if (left == EUiTabViewName.KurotatoHandBookWeaponTabView)
			{
				activityData.ReadKurotatoItemRedDot();
				activityData.ReadKurotatoWeaponRedDot();
			}
		}

		// Token: 0x0603ABAB RID: 240555 RVA: 0x00EE3840 File Offset: 0x00EE1A40
		private void BindRedDotByName(EUiTabViewName viewName, ERedDotName redDotName, bool bIsBind)
		{
			int num = this.TabDataList.FindIndex((UiDynamicTab config) => (EUiTabViewName)config.ChildViewName == viewName);
			if (num >= 0)
			{
				CommonTabItem tabItemByIndex = this.TabComponent.GetTabItemByIndex(num);
				if (tabItemByIndex == null)
				{
					return;
				}
				if (bIsBind)
				{
					tabItemByIndex.BindRedDot(redDotName, new int?(0));
					return;
				}
				tabItemByIndex.UnBindRedDot();
			}
		}

		// Token: 0x04021351 RID: 136017
		private List<UiDynamicTab> TabDataList = new List<UiDynamicTab>();

		// Token: 0x04021352 RID: 136018
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TabComponentWithCaptionItem<CommonTabItem> TabComponent;

		// Token: 0x04021353 RID: 136019
		[Nullable(2)]
		private TabViewComponent<UiDynamicTab> TabViewComponent;

		// Token: 0x0200BAC7 RID: 47815
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x04039A8C RID: 236172
			ItemCaption,
			// Token: 0x04039A8D RID: 236173
			ItemContent
		}
	}
}
