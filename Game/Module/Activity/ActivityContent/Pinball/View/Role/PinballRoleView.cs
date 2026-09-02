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

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Role
{
	// Token: 0x020065DD RID: 26077
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballRoleView : UiViewBase
	{
		// Token: 0x0604124F RID: 266831 RVA: 0x010B636F File Offset: 0x010B456F
		public PinballRoleView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06041250 RID: 266832 RVA: 0x010B63A0 File Offset: 0x010B45A0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 9;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUILoopScrollViewComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 3;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(3, new Action(this.OnRoleSelectButtonClick));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action<EToggleState>(delegate(EToggleState _)
			{
				this.OnWeaponTabToggleClick();
			}));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(5, new Action<EToggleState>(delegate(EToggleState _)
			{
				this.OnAttributeTabToggleClick();
			}));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06041251 RID: 266833 RVA: 0x010B6574 File Offset: 0x010B4774
		protected override UniTask OnBeforeStartAsync()
		{
			PinballRoleView.<OnBeforeStartAsync>d__12 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PinballRoleView.<OnBeforeStartAsync>d__12>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06041252 RID: 266834 RVA: 0x010B65B8 File Offset: 0x010B47B8
		protected override void OnBeforeShow()
		{
			if (this.SelectedTabIndex == EPinballRoleTabIndex.None)
			{
				this.SelectTab(EPinballRoleTabIndex.RoleAttribute);
			}
			else
			{
				UiTabViewBase currentTabView = this.TabViewComponent.GetCurrentTabView();
				if (currentTabView != null)
				{
					((IPinballRoleTabViewRefresh)currentTabView).RefreshView();
				}
			}
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(ModelBase<PinballModel>.Instance.GetWeaponRedDot(this.Proxy.GetActivityData().Id, this.Proxy.GetSelectedRoleId()));
		}

		// Token: 0x06041253 RID: 266835 RVA: 0x010B6628 File Offset: 0x010B4828
		protected override UniTask OnBeforeShowAsyncImplementImplement()
		{
			PinballRoleView.<OnBeforeShowAsyncImplementImplement>d__14 <OnBeforeShowAsyncImplementImplement>d__;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeShowAsyncImplementImplement>d__.<>4__this = this;
			<OnBeforeShowAsyncImplementImplement>d__.<>1__state = -1;
			<OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Start<PinballRoleView.<OnBeforeShowAsyncImplementImplement>d__14>(ref <OnBeforeShowAsyncImplementImplement>d__);
			return <OnBeforeShowAsyncImplementImplement>d__.<>t__builder.Task;
		}

		// Token: 0x06041254 RID: 266836 RVA: 0x010B666B File Offset: 0x010B486B
		protected override void OnAddEventListener()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnPinballRoleLevelUp, new Action<int, int, int>(this.OnPinballRoleLevelUp));
		}

		// Token: 0x06041255 RID: 266837 RVA: 0x010B6689 File Offset: 0x010B4889
		protected override void OnRemoveEventListener()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnPinballRoleLevelUp, new Action<int, int, int>(this.OnPinballRoleLevelUp));
		}

		// Token: 0x06041256 RID: 266838 RVA: 0x010B66A8 File Offset: 0x010B48A8
		private void BuildRoleHeadItemDataList()
		{
			if (this.Proxy == null)
			{
				return;
			}
			this.RoleHeadItemDataList.Clear();
			int selectedRoleId = this.Proxy.GetSelectedRoleId();
			foreach (PinballRoleDataBase pinballRoleDataBase in this.Proxy.GetRoleDataList())
			{
				PinballRoleHeadItemData item = new PinballRoleHeadItemData
				{
					RoleConfig = pinballRoleDataBase.GetConfig(),
					IsSelected = (pinballRoleDataBase.GetId() == selectedRoleId),
					IsLocked = pinballRoleDataBase.IsLocked(),
					IsTrail = false,
					NeedRedDot = true
				};
				this.RoleHeadItemDataList.Add(item);
			}
		}

		// Token: 0x06041257 RID: 266839 RVA: 0x010B6760 File Offset: 0x010B4960
		private void SelectDefaultRoleWhenNoSelected()
		{
			if (this.Proxy == null || this.RoleHeadItemDataList.Count == 0 || this.Proxy.GetSelectedRoleId() != 0)
			{
				return;
			}
			IPinballRoleViewOpenParam openParam = this.GetOpenParam();
			int selectedRole = ((openParam != null) ? openParam.RoleId : null) ?? this.RoleHeadItemDataList[0].RoleConfig.Id;
			this.SetSelectedRole(selectedRole);
		}

		// Token: 0x06041258 RID: 266840 RVA: 0x010B67E0 File Offset: 0x010B49E0
		private void SetSelectedRole(int roleId)
		{
			this.CancelSelectedRole();
			this.Proxy.SetSelectedRoleDataById(roleId);
			this.RoleHeadItemDataList[this.Proxy.GetSelectedRoleIndex()].IsSelected = true;
			PinballController instance = ControllerBase<PinballController>.Instance;
			if (instance != null)
			{
				instance.CheckToSetRoleRedDotAsRead(this.Proxy.GetActivityData().Id, roleId);
			}
			UUIItem item = base.GetItem(8);
			if (item == null)
			{
				return;
			}
			item.SetUIActive(ModelBase<PinballModel>.Instance.GetWeaponRedDot(this.Proxy.GetActivityData().Id, roleId));
		}

		// Token: 0x06041259 RID: 266841 RVA: 0x010B686C File Offset: 0x010B4A6C
		private void CancelSelectedRole()
		{
			if (this.Proxy == null || this.Proxy.GetSelectedRoleIndex() < 0 || this.Proxy.GetSelectedRoleIndex() >= this.RoleHeadItemDataList.Count)
			{
				return;
			}
			this.RoleHeadItemDataList[this.Proxy.GetSelectedRoleIndex()].IsSelected = false;
		}

		// Token: 0x0604125A RID: 266842 RVA: 0x010B68C4 File Offset: 0x010B4AC4
		private void SelectRole(int roleId)
		{
			if (this.Proxy == null)
			{
				return;
			}
			int selectedRoleIndex = this.Proxy.GetSelectedRoleIndex();
			this.SetSelectedRole(roleId);
			this.RoleHeadItemLoopScrollView.RefreshGridProxy(selectedRoleIndex);
			this.RoleHeadItemLoopScrollView.RefreshGridProxy(this.Proxy.GetSelectedRoleIndex());
			this.RoleSpineItem.RefreshRole(this.Proxy.GetSelectedRoleId(), "Idle_Fight", true);
			UiTabViewBase currentTabView = this.TabViewComponent.GetCurrentTabView();
			if (currentTabView != null)
			{
				((IPinballRoleTabViewRoleChange)currentTabView).RefreshByRoleChange();
			}
		}

		// Token: 0x0604125B RID: 266843 RVA: 0x010B6948 File Offset: 0x010B4B48
		private void SelectTab(EPinballRoleTabIndex tabIndex)
		{
			if (tabIndex == this.SelectedTabIndex)
			{
				return;
			}
			EPinballRoleTabIndex selectedTabIndex = this.SelectedTabIndex;
			this.SelectedTabIndex = tabIndex;
			if (selectedTabIndex != EPinballRoleTabIndex.None)
			{
				this.TabToggleList[(int)selectedTabIndex].SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.TabToggleList[(int)tabIndex].SetToggleState(EToggleState.ETT_Checked, false, false, false);
			this.TabViewComponent.ToggleCallBack(this.Proxy.GetSelectedRoleIndex(), this.TabViewNameList[(int)tabIndex], null, this.Proxy, null);
		}

		// Token: 0x0604125C RID: 266844 RVA: 0x010B69CF File Offset: 0x010B4BCF
		[NullableContext(2)]
		private IPinballRoleViewOpenParam GetOpenParam()
		{
			return this.OpenParam as IPinballRoleViewOpenParam;
		}

		// Token: 0x0604125D RID: 266845 RVA: 0x010B69DC File Offset: 0x010B4BDC
		private void OnRoleSelectButtonClick()
		{
			if (this.Proxy == null)
			{
				return;
			}
			PinballRoleSelectViewOpenData pinballRoleSelectViewOpenData = new PinballRoleSelectViewOpenData();
			pinballRoleSelectViewOpenData.ActivityData = this.Proxy.GetActivityData();
			pinballRoleSelectViewOpenData.SelectedRoleId = this.Proxy.GetSelectedRoleId();
			pinballRoleSelectViewOpenData.RoleDataList = this.Proxy.GetRoleDataList();
			IPinballRoleViewOpenParam openParam = this.GetOpenParam();
			pinballRoleSelectViewOpenData.FormationRoleIds = ((openParam != null) ? openParam.FormationRoleIds : null);
			pinballRoleSelectViewOpenData.OnSelectConfirm = new Action<int>(this.OnRoleSelectConfirm);
			PinballRoleSelectViewOpenData param = pinballRoleSelectViewOpenData;
			Singleton<UiManager>.Instance.OpenView(EUiViewName.PinballRoleSelectView, param, null);
		}

		// Token: 0x0604125E RID: 266846 RVA: 0x010B6A66 File Offset: 0x010B4C66
		private void OnRoleSelectConfirm(int roleId)
		{
			this.SetSelectedRole(roleId);
		}

		// Token: 0x0604125F RID: 266847 RVA: 0x010B6A6F File Offset: 0x010B4C6F
		private PinballRoleHeadItem CreateRoleHeadItem()
		{
			return new PinballRoleHeadItem
			{
				OnSelectCallBack = new Action<IPinballRoleHeadItemData>(this.OnRoleHeadItemSelect)
			};
		}

		// Token: 0x06041260 RID: 266848 RVA: 0x010B6A88 File Offset: 0x010B4C88
		private void OnRoleHeadItemSelect(IPinballRoleHeadItemData data)
		{
			this.SelectRole(data.RoleConfig.Id);
		}

		// Token: 0x06041261 RID: 266849 RVA: 0x010B6AA9 File Offset: 0x010B4CA9
		private void OnWeaponTabToggleClick()
		{
			this.SelectTab(EPinballRoleTabIndex.Weapon);
		}

		// Token: 0x06041262 RID: 266850 RVA: 0x010B6AB2 File Offset: 0x010B4CB2
		private void OnAttributeTabToggleClick()
		{
			this.SelectTab(EPinballRoleTabIndex.RoleAttribute);
		}

		// Token: 0x06041263 RID: 266851 RVA: 0x010B6ABC File Offset: 0x010B4CBC
		private void OnPinballRoleLevelUp(int activityId, int roleId, int addLevel)
		{
			if (roleId != this.Proxy.GetSelectedRoleId())
			{
				return;
			}
			UiBehaviorLevelSequence uiViewSequence = this.UiViewSequence;
			if (uiViewSequence == null)
			{
				return;
			}
			uiViewSequence.PlayOrReplaySequenceByName("LevelUp", false, null);
		}

		// Token: 0x06041264 RID: 266852 RVA: 0x010B6AF7 File Offset: 0x010B4CF7
		private void OnCloseBtnClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x040247BC RID: 149436
		[Nullable(2)]
		protected PinballRoleViewProxy Proxy;

		// Token: 0x040247BD RID: 149437
		private EPinballRoleTabIndex SelectedTabIndex = EPinballRoleTabIndex.None;

		// Token: 0x040247BE RID: 149438
		private readonly List<IPinballRoleHeadItemData> RoleHeadItemDataList = new List<IPinballRoleHeadItemData>();

		// Token: 0x040247BF RID: 149439
		[Nullable(2)]
		protected PinballRoleSpineItem RoleSpineItem;

		// Token: 0x040247C0 RID: 149440
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private LoopScrollView<PinballRoleHeadItem, IPinballRoleHeadItemData> RoleHeadItemLoopScrollView;

		// Token: 0x040247C1 RID: 149441
		[Nullable(2)]
		private PopupCaptionItem CaptionItem;

		// Token: 0x040247C2 RID: 149442
		[Nullable(2)]
		protected TabViewComponent<int> TabViewComponent;

		// Token: 0x040247C3 RID: 149443
		private readonly List<UUIExtendToggle> TabToggleList = new List<UUIExtendToggle>();

		// Token: 0x040247C4 RID: 149444
		private readonly List<EUiTabViewName> TabViewNameList = new List<EUiTabViewName>();

		// Token: 0x0200C5E2 RID: 50658
		[NullableContext(0)]
		private enum EComponent
		{
			// Token: 0x0403CE83 RID: 249475
			CaptionItem,
			// Token: 0x0403CE84 RID: 249476
			RoleHeadLoopScrollView,
			// Token: 0x0403CE85 RID: 249477
			RoleHeadItem,
			// Token: 0x0403CE86 RID: 249478
			RoleSelectButton,
			// Token: 0x0403CE87 RID: 249479
			WeaponTabToggle,
			// Token: 0x0403CE88 RID: 249480
			AttributeTabToggle,
			// Token: 0x0403CE89 RID: 249481
			RoleSpineItem,
			// Token: 0x0403CE8A RID: 249482
			ContentRootItem,
			// Token: 0x0403CE8B RID: 249483
			RedDotWeapon
		}
	}
}
