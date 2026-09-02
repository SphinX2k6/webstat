using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.RoleUi.RoleDevelop.Data;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.RoleUi.RoleDevelop.View
{
	// Token: 0x020050CA RID: 20682
	[NullableContext(1)]
	[Nullable(0)]
	public class RoleDevelopRootView : UiViewBase
	{
		// Token: 0x06035494 RID: 218260 RVA: 0x00D5DC05 File Offset: 0x00D5BE05
		public RoleDevelopRootView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x06035495 RID: 218261 RVA: 0x00D5DC48 File Offset: 0x00D5BE48
		protected unsafe override void OnRegisterComponent()
		{
			int num = 25;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(8, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(9, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(10, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(11, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(12, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(13, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(14, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(15, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(16, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(17, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(18, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(19, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(20, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(21, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(22, typeof(UUIExtendToggle));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(23, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(24, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(22, new Action<EToggleState>(this.OnClickToggleRoleMark));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(23, new Action(this.OnIntroductionBtnClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06035496 RID: 218262 RVA: 0x00D5E01C File Offset: 0x00D5C21C
		protected override UniTask OnBeforeStartAsync()
		{
			RoleDevelopRootView.<OnBeforeStartAsync>d__21 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<RoleDevelopRootView.<OnBeforeStartAsync>d__21>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06035497 RID: 218263 RVA: 0x00D5E060 File Offset: 0x00D5C260
		protected override void OnStart()
		{
			base.GetButton(23).RootUIComp.Get().SetUIActive(true);
			this.RefreshRoleGridLayout();
			this.RefreshHotRoleGridLayout();
			this.RefreshRoleDevelopCategoryLayout();
			Singleton<EventSystem>.Instance.Add(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
			Singleton<EventSystem>.Instance.Add<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			Singleton<EventSystem>.Instance.Add<int>(EEventName.ActiveRole, new Action<int>(this.OnActiveRole));
		}

		// Token: 0x06035498 RID: 218264 RVA: 0x00D5E0F0 File Offset: 0x00D5C2F0
		protected override void OnHandleLoadScene()
		{
			if (Singleton<UiSceneManager>.Instance.HasRoleSystemRoleActor())
			{
				return;
			}
			int value = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId().Value;
			this.ViewModel = new RoleViewViewModel(value, true, ERoleViewSource.Normal);
			this.ViewModel.HandleLoadScene(null);
		}

		// Token: 0x06035499 RID: 218265 RVA: 0x00D5E137 File Offset: 0x00D5C337
		protected override void OnHandleReleaseScene()
		{
			this.TryReleaseScene();
		}

		// Token: 0x0603549A RID: 218266 RVA: 0x00D5E13F File Offset: 0x00D5C33F
		private void TryReleaseScene()
		{
			if (this.ViewModel != null)
			{
				this.ViewModel.HandleReleaseScene();
			}
			this.ViewModel = null;
		}

		// Token: 0x0603549B RID: 218267 RVA: 0x00D5E15C File Offset: 0x00D5C35C
		protected override void OnBeforeDestroy()
		{
			this.TryReleaseScene();
			this.TryShowUiRoleModel();
			Singleton<EventSystem>.Instance.Remove(EEventName.RoleDevTargetRoleIdChange, new Action(this.OnRoleDevTargetRoleIdChange));
			Singleton<EventSystem>.Instance.Remove<int, int>(EEventName.OnCommonItemCountAnyChange, new Action<int, int>(this.OnCommonItemCountAnyChange));
			Singleton<EventSystem>.Instance.Remove<int>(EEventName.ActiveRole, new Action<int>(this.OnActiveRole));
		}

		// Token: 0x0603549C RID: 218268 RVA: 0x00D5E1CC File Offset: 0x00D5C3CC
		protected override void OnBeforeShow()
		{
			this.TryHideUiRoleModel();
			if (this.NeedRebuildDataOnShow)
			{
				this.RoleDevelopDataList = ModelBase<RoleDevelopModel>.Instance.GetNormalRoleDevelopData();
				this.RoleDataList = new List<RoleDataBase>();
				this.RefreshRoleGridLayout();
				this.RefreshHotRoleGridLayout();
			}
			this.NeedRebuildDataOnShow = false;
			if (this.RefreshOnShow)
			{
				this.RefreshTitleView();
				this.RefreshProjectView(false);
				this.RefreshCategoryHint();
				this.RoleLayout.RefreshWithoutDataSync();
				this.HotRoleLayout.RefreshWithoutDataSync();
			}
			this.RefreshOnShow = false;
		}

		// Token: 0x0603549D RID: 218269 RVA: 0x00D5E24D File Offset: 0x00D5C44D
		protected override void OnBeforeHide()
		{
			this.RefreshOnShow = true;
		}

		// Token: 0x0603549E RID: 218270 RVA: 0x00D5E258 File Offset: 0x00D5C458
		private void InitData()
		{
			this.RoleDevelopDataList = ModelBase<RoleDevelopModel>.Instance.GetNormalRoleDevelopData();
			List<RoleDevelopData> allHotRoleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetAllHotRoleDevelopData(false);
			RoleDevelopRootViewData roleDevelopRootViewData = this.OpenParam as RoleDevelopRootViewData;
			int? roleId = (roleDevelopRootViewData != null) ? roleDevelopRootViewData.RoleId : null;
			if (roleId != null && roleId.GetValueOrDefault() != 0)
			{
				this.CurSelectRoleDevelopData = (this.RoleDevelopDataList.Find((RoleDevelopData data) => data.GetId() == roleId.Value) ?? allHotRoleDevelopData.Find((RoleDevelopData data) => data.GetId() == roleId.Value));
			}
		}

		// Token: 0x0603549F RID: 218271 RVA: 0x00D5E2FA File Offset: 0x00D5C4FA
		private void InitSortEntrance()
		{
			this.FilterSortEntrance = new FilterSortEntrance<RoleDataBase>(base.GetItem(4), new TUpdateDataListFunction<RoleDataBase>(this.OnUpdateSortList));
		}

		// Token: 0x060354A0 RID: 218272 RVA: 0x00D5E31C File Offset: 0x00D5C51C
		private UniTask InitCaptainItem()
		{
			RoleDevelopRootView.<InitCaptainItem>d__31 <InitCaptainItem>d__;
			<InitCaptainItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCaptainItem>d__.<>4__this = this;
			<InitCaptainItem>d__.<>1__state = -1;
			<InitCaptainItem>d__.<>t__builder.Start<RoleDevelopRootView.<InitCaptainItem>d__31>(ref <InitCaptainItem>d__);
			return <InitCaptainItem>d__.<>t__builder.Task;
		}

		// Token: 0x060354A1 RID: 218273 RVA: 0x00D5E360 File Offset: 0x00D5C560
		private UniTask InitRoleDevelopTagItem()
		{
			RoleDevelopRootView.<InitRoleDevelopTagItem>d__32 <InitRoleDevelopTagItem>d__;
			<InitRoleDevelopTagItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleDevelopTagItem>d__.<>4__this = this;
			<InitRoleDevelopTagItem>d__.<>1__state = -1;
			<InitRoleDevelopTagItem>d__.<>t__builder.Start<RoleDevelopRootView.<InitRoleDevelopTagItem>d__32>(ref <InitRoleDevelopTagItem>d__);
			return <InitRoleDevelopTagItem>d__.<>t__builder.Task;
		}

		// Token: 0x060354A2 RID: 218274 RVA: 0x00D5E3A4 File Offset: 0x00D5C5A4
		private UniTask InitRoleElementItem()
		{
			RoleDevelopRootView.<InitRoleElementItem>d__33 <InitRoleElementItem>d__;
			<InitRoleElementItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleElementItem>d__.<>4__this = this;
			<InitRoleElementItem>d__.<>1__state = -1;
			<InitRoleElementItem>d__.<>t__builder.Start<RoleDevelopRootView.<InitRoleElementItem>d__33>(ref <InitRoleElementItem>d__);
			return <InitRoleElementItem>d__.<>t__builder.Task;
		}

		// Token: 0x060354A3 RID: 218275 RVA: 0x00D5E3E7 File Offset: 0x00D5C5E7
		private void InitRoleDevelopCategoryItem()
		{
			this.CategoryLayout = new GenericLayout<RoleDevelopCategoryItem, RoleDevelopCategoryData>(base.GetHorizontalLayout(11), new Func<RoleDevelopCategoryItem>(this.CreateRoleDevelopCategoryItem), null, false, true);
		}

		// Token: 0x060354A4 RID: 218276 RVA: 0x00D5E40C File Offset: 0x00D5C60C
		private UniTask InitRoleDevelopViewItem()
		{
			RoleDevelopRootView.<InitRoleDevelopViewItem>d__35 <InitRoleDevelopViewItem>d__;
			<InitRoleDevelopViewItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitRoleDevelopViewItem>d__.<>4__this = this;
			<InitRoleDevelopViewItem>d__.<>1__state = -1;
			<InitRoleDevelopViewItem>d__.<>t__builder.Start<RoleDevelopRootView.<InitRoleDevelopViewItem>d__35>(ref <InitRoleDevelopViewItem>d__);
			return <InitRoleDevelopViewItem>d__.<>t__builder.Task;
		}

		// Token: 0x060354A5 RID: 218277 RVA: 0x00D5E450 File Offset: 0x00D5C650
		private void RefreshCategoryHint()
		{
			List<RoleDevelopCategoryItem> layoutItemList = this.CategoryLayout.GetLayoutItemList();
			RoleDevelopProjectBaseData projectData = this.CurSelectRoleDevelopData.GetProjectData();
			foreach (RoleDevelopCategoryItem roleDevelopCategoryItem in layoutItemList)
			{
				ERoleDevelopCategoryType categoryType = roleDevelopCategoryItem.CategoryType;
				bool isShowUpgrade = projectData.IsShowUpgradeHint(categoryType);
				bool isShowFinish = projectData.IsShowFinishHint(categoryType);
				roleDevelopCategoryItem.RefreshHint(isShowUpgrade, isShowFinish);
			}
		}

		// Token: 0x060354A6 RID: 218278 RVA: 0x00D5E4CC File Offset: 0x00D5C6CC
		private void InitRoleGridLayout()
		{
			AActor owner = base.GetItem(3).GetOwner();
			this.HotRoleLayout = new GenericLayout<RoleDevelopHotRoleGridItem, RoleDevelopData>(base.GetGridLayout(1), new Func<RoleDevelopHotRoleGridItem>(this.CreateHotRoleGridItem), (AUIBaseActor)owner, false, true);
			this.RoleLayout = new GenericLayout<RoleDevelopGridItem, RoleDevelopData>(base.GetGridLayout(2), new Func<RoleDevelopGridItem>(this.CreateRoleGridItem), (AUIBaseActor)owner, false, true);
		}

		// Token: 0x060354A7 RID: 218279 RVA: 0x00D5E534 File Offset: 0x00D5C734
		private void TryShowUiRoleModel()
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			if (roleSystemRoleActor == null)
			{
				return;
			}
			UiModelBase model = roleSystemRoleActor.Model;
			Singleton<UiModelUtil>.Instance.StopFade(model);
			Singleton<UiModelUtil>.Instance.SetDitherEffect(model, 1f);
			Singleton<UiModelUtil>.Instance.SetVisible(model, true);
		}

		// Token: 0x060354A8 RID: 218280 RVA: 0x00D5E580 File Offset: 0x00D5C780
		private void TryHideUiRoleModel()
		{
			TsUiSceneRoleActor roleSystemRoleActor = Singleton<UiSceneManager>.Instance.GetRoleSystemRoleActor();
			if (roleSystemRoleActor == null)
			{
				return;
			}
			UiModelBase model = roleSystemRoleActor.Model;
			Singleton<UiModelUtil>.Instance.StopFade(model);
			Singleton<UiModelUtil>.Instance.SetDitherEffect(model, 0f);
			Singleton<UiModelUtil>.Instance.SetVisible(model, false);
		}

		// Token: 0x060354A9 RID: 218281 RVA: 0x00D5E5CC File Offset: 0x00D5C7CC
		private void RefreshRoleGridLayout()
		{
			List<RoleDevelopData> roleDevelopDataList = this.RoleDevelopDataList;
			if (this.RoleDataList.Count <= 0)
			{
				foreach (RoleDevelopData roleDevelopData in roleDevelopDataList)
				{
					int id = roleDevelopData.GetId();
					RoleInstance roleInstance = ModelBase<RoleModel>.Instance.GetRoleInstanceById(id);
					if (roleInstance == null)
					{
						roleInstance = new RoleInstance(id);
					}
					this.RoleDataList.Add(roleInstance);
				}
				this.FilterSortEntrance.UpdateData(EFilterSortGroupId.RoleDev, this.RoleDataList, Array.Empty<object>());
				return;
			}
			this.RoleLayout.RefreshByData(this.RoleDevelopDataList, new Action(this.OnRoleGridLayoutRefresh), true);
		}

		// Token: 0x060354AA RID: 218282 RVA: 0x00D5E688 File Offset: 0x00D5C888
		private void RefreshHotRoleGridLayout()
		{
			List<RoleDevelopData> allHotRoleDevelopData = ModelBase<RoleDevelopModel>.Instance.GetAllHotRoleDevelopData(true);
			if (allHotRoleDevelopData.Count <= 0)
			{
				this.HotRoleLayout.SetActive(false);
				return;
			}
			this.HotRoleLayout.SetActive(true);
			this.HotRoleLayout.RefreshByData(allHotRoleDevelopData, new Action(this.OnHotRoleGridLayoutRefresh), true);
		}

		// Token: 0x060354AB RID: 218283 RVA: 0x00D5E6DC File Offset: 0x00D5C8DC
		private void RefreshRoleDevelopCategoryLayout()
		{
			List<RoleDevelopCategoryData> data = new List<RoleDevelopCategoryData>(RoleDevelopDefine.roleDevelopCategoryConfig);
			RoleDevelopRootViewData roleDevelopRootViewData = this.OpenParam as RoleDevelopRootViewData;
			if (this.CurSelectCategoryType == null)
			{
				this.CurSelectCategoryType = new ERoleDevelopCategoryType?(((roleDevelopRootViewData != null) ? roleDevelopRootViewData.CategoryType : null).GetValueOrDefault(ERoleDevelopCategoryType.Role));
			}
			this.CategoryLayout.RefreshByData(data, delegate
			{
				this.CategoryLayout.SelectGridProxyByKey(this.CurSelectCategoryType.Value, true);
			}, false);
		}

		// Token: 0x060354AC RID: 218284 RVA: 0x00D5E750 File Offset: 0x00D5C950
		private void RefreshTitleView()
		{
			if (this.CurSelectRoleDevelopData == null)
			{
				return;
			}
			RoleDevelopRoleBaseData developRoleData = this.CurSelectRoleDevelopData.GetDevelopRoleData();
			base.GetText(6).SetText(developRoleData.GetName(), true);
			base.SetTextureByPath(developRoleData.GetRoleSmallIconPath(), base.GetTexture(5), null, null);
			this.ElementItem.Refresh(developRoleData.GetElementId(), false, 0);
			this.RoleDevelopTagItem.RefreshByData(this.CurSelectRoleDevelopData.GetHotRoleTag());
			this.RefreshMainProperty();
			this.RefreshRoleMarkToggle();
		}

		// Token: 0x060354AD RID: 218285 RVA: 0x00D5E7D8 File Offset: 0x00D5C9D8
		private void RefreshMainProperty()
		{
			UUIText text = base.GetText(9);
			if (this.CurSelectRoleDevelopData == null)
			{
				text.SetUIActive(false);
				return;
			}
			if (RoleDevelopUtil.IsAnyProspectRole(this.CurSelectRoleDevelopData.GetId()))
			{
				text.SetUIActive(false);
				return;
			}
			int keyProperty = this.CurSelectRoleDevelopData.GetDevelopRoleData().GetKeyProperty();
			if (keyProperty == 0)
			{
				text.SetUIActive(false);
				return;
			}
			RoleDevProject? roleDevProjectConfig = ConfigBase<RoleDevConfig>.Instance.GetRoleDevProjectConfig(this.CurSelectRoleDevelopData.GetId());
			PropertyIndex? propertyIndexConfigByIndex = ConfigBase<RoleDevConfig>.Instance.GetPropertyIndexConfigByIndex(keyProperty);
			text.SetUIActive(true);
			int[] propertyValueArray = roleDevProjectConfig.Value.GetPropertyValueArray();
			string text2;
			if (propertyValueArray[0] != 1)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<double>((double)propertyValueArray[1] / 100.0, "F1");
				defaultInterpolatedStringHandler.AppendLiteral("%");
				text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			else
			{
				text2 = propertyValueArray[1].ToString();
			}
			string str = text2;
			string text3 = ConfigMultiTextLang.GetLocalTextNew(propertyIndexConfigByIndex.Value.Name, null) + " " + str;
			text3 = StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RoleProject_TargetProperty", null), new string[]
			{
				text3
			});
			text.SetText(text3, true);
		}

		// Token: 0x060354AE RID: 218286 RVA: 0x00D5E908 File Offset: 0x00D5CB08
		private void RefreshProjectView(bool forceRefresh = false)
		{
			if (this.CurSelectRoleDevelopData == null || this.CurSelectCategoryType == null)
			{
				return;
			}
			foreach (KeyValuePair<ERoleDevelopCategoryType, UUIItem> keyValuePair in this.ProjectLayoutMap)
			{
				ERoleDevelopCategoryType eroleDevelopCategoryType;
				UUIItem uuiitem;
				keyValuePair.Deconstruct(out eroleDevelopCategoryType, out uuiitem);
				ERoleDevelopCategoryType eroleDevelopCategoryType2 = eroleDevelopCategoryType;
				uuiitem.SetUIActive(eroleDevelopCategoryType2 == this.CurSelectCategoryType.Value);
			}
			foreach (KeyValuePair<ERoleDevelopCategoryType, UUIItem> keyValuePair in this.ProjectScrollViewMap)
			{
				ERoleDevelopCategoryType eroleDevelopCategoryType;
				UUIItem uuiitem;
				keyValuePair.Deconstruct(out eroleDevelopCategoryType, out uuiitem);
				ERoleDevelopCategoryType eroleDevelopCategoryType3 = eroleDevelopCategoryType;
				uuiitem.SetUIActive(eroleDevelopCategoryType3 == this.CurSelectCategoryType.Value);
			}
			foreach (RoleDevelopProjectBasePanel roleDevelopProjectBasePanel in this.ProjectPanelMap.Values)
			{
				roleDevelopProjectBasePanel.RefreshView(this.CurSelectRoleDevelopData, forceRefresh);
			}
			bool uiactive = this.CurSelectCategoryType.Value == ERoleDevelopCategoryType.Phantom && RoleDevelopUtil.IsAnyProspectRole(this.CurSelectRoleDevelopData.GetId());
			base.GetItem(21).SetUIActive(uiactive);
		}

		// Token: 0x060354AF RID: 218287 RVA: 0x00D5EA6C File Offset: 0x00D5CC6C
		private void RefreshRoleMarkToggle()
		{
			int id = this.CurSelectRoleDevelopData.GetId();
			UUIExtendToggle extendToggle = base.GetExtendToggle(22);
			extendToggle.RootUIComp.Get().SetUIActive(true);
			EToggleState state = (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == id) ? EToggleState.ETT_Checked : EToggleState.ETT_UnChecked;
			extendToggle.SetToggleStateForce(state, false, false, false);
		}

		// Token: 0x060354B0 RID: 218288 RVA: 0x00D5EABC File Offset: 0x00D5CCBC
		private void OnHotRoleGridItemSelected(RoleDevelopData data)
		{
			this.RoleLayout.DeselectCurrentGridProxy();
			this.HotRoleLayout.DeselectCurrentGridProxy();
			this.HotRoleLayout.SelectGridProxyByKey(data.GetId(), false);
			this.CurSelectRoleDevelopData = data;
			this.IsSelectedFromHotRole = true;
			this.RefreshTitleView();
			this.RefreshProjectView(true);
			this.RefreshCategoryHint();
			this.UiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x060354B1 RID: 218289 RVA: 0x00D5EB34 File Offset: 0x00D5CD34
		private void OnRoleGridItemSelected(RoleDevelopData data)
		{
			this.RoleLayout.DeselectCurrentGridProxy();
			this.HotRoleLayout.DeselectCurrentGridProxy();
			this.RoleLayout.SelectGridProxyByKey(data.GetId(), false);
			this.CurSelectRoleDevelopData = data;
			this.IsSelectedFromHotRole = false;
			this.RefreshTitleView();
			this.RefreshProjectView(true);
			this.RefreshCategoryHint();
			this.UiViewSequence.PlayOrReplaySequenceByName("Switch", false, null);
		}

		// Token: 0x060354B2 RID: 218290 RVA: 0x00D5EBA9 File Offset: 0x00D5CDA9
		private void OnCloseButtonClick()
		{
			base.CloseMe(null);
		}

		// Token: 0x060354B3 RID: 218291 RVA: 0x00D5EBB2 File Offset: 0x00D5CDB2
		private RoleDevelopHotRoleGridItem CreateHotRoleGridItem()
		{
			RoleDevelopHotRoleGridItem roleDevelopHotRoleGridItem = new RoleDevelopHotRoleGridItem();
			roleDevelopHotRoleGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnHotRoleGridItemToggleChanged));
			roleDevelopHotRoleGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnHotRoleGridItemCanExecuteChange));
			return roleDevelopHotRoleGridItem;
		}

		// Token: 0x060354B4 RID: 218292 RVA: 0x00D5EBDD File Offset: 0x00D5CDDD
		private RoleDevelopGridItem CreateRoleGridItem()
		{
			RoleDevelopGridItem roleDevelopGridItem = new RoleDevelopGridItem();
			roleDevelopGridItem.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnRoleGridItemToggleChanged));
			roleDevelopGridItem.BindOnCanExecuteChange(new Func<object, bool, EToggleState, bool>(this.OnRoleGridItemCanExecuteChange));
			return roleDevelopGridItem;
		}

		// Token: 0x060354B5 RID: 218293 RVA: 0x00D5EC08 File Offset: 0x00D5CE08
		private void OnRoleGridItemToggleChanged(MediumItemGridExtendCallback callbackParameter)
		{
			this.OnRoleGridItemSelected((RoleDevelopData)callbackParameter.Data);
		}

		// Token: 0x060354B6 RID: 218294 RVA: 0x00D5EC1C File Offset: 0x00D5CE1C
		private bool OnRoleGridItemCanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			if (this.IsSelectedFromHotRole)
			{
				return true;
			}
			int id = ((RoleDevelopData)data).GetId();
			RoleDevelopData curSelectRoleDevelopData = this.CurSelectRoleDevelopData;
			int? num = (curSelectRoleDevelopData != null) ? new int?(curSelectRoleDevelopData.GetId()) : null;
			return !(id == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x060354B7 RID: 218295 RVA: 0x00D5EC72 File Offset: 0x00D5CE72
		private void OnHotRoleGridItemToggleChanged(MediumItemGridExtendCallback callbackParameter)
		{
			this.OnHotRoleGridItemSelected((RoleDevelopData)callbackParameter.Data);
		}

		// Token: 0x060354B8 RID: 218296 RVA: 0x00D5EC88 File Offset: 0x00D5CE88
		private bool OnHotRoleGridItemCanExecuteChange(object data, bool isForceSelected, EToggleState state)
		{
			if (!this.IsSelectedFromHotRole)
			{
				return true;
			}
			int id = ((RoleDevelopData)data).GetId();
			RoleDevelopData curSelectRoleDevelopData = this.CurSelectRoleDevelopData;
			int? num = (curSelectRoleDevelopData != null) ? new int?(curSelectRoleDevelopData.GetId()) : null;
			return !(id == num.GetValueOrDefault() & num != null);
		}

		// Token: 0x060354B9 RID: 218297 RVA: 0x00D5ECDE File Offset: 0x00D5CEDE
		private RoleDevelopCategoryItem CreateRoleDevelopCategoryItem()
		{
			RoleDevelopCategoryItem roleDevelopCategoryItem = new RoleDevelopCategoryItem();
			roleDevelopCategoryItem.SetToggleCallback(new Action<RoleDevelopCategoryData>(this.OnRoleDevelopCategoryItemToggle));
			roleDevelopCategoryItem.SetCanExecuteCallback(new Func<RoleDevelopCategoryData, bool>(this.OnRoleDevelopCategoryItemCanExecute));
			return roleDevelopCategoryItem;
		}

		// Token: 0x060354BA RID: 218298 RVA: 0x00D5ED0C File Offset: 0x00D5CF0C
		private void OnRoleDevelopCategoryItemToggle(RoleDevelopCategoryData data)
		{
			this.CategoryLayout.DeselectCurrentGridProxy();
			this.CategoryLayout.SelectGridProxyByKey(data.CategoryType, false);
			this.CurSelectCategoryType = new ERoleDevelopCategoryType?(data.CategoryType);
			this.RefreshProjectView(false);
			RoleDevelopProjectBasePanel roleDevelopProjectBasePanel;
			if (this.ProjectPanelMap.TryGetValue(this.CurSelectCategoryType.Value, out roleDevelopProjectBasePanel))
			{
				roleDevelopProjectBasePanel.PlaySequenceByName("Start", false);
			}
		}

		// Token: 0x060354BB RID: 218299 RVA: 0x00D5ED7C File Offset: 0x00D5CF7C
		private bool OnRoleDevelopCategoryItemCanExecute(RoleDevelopCategoryData data)
		{
			ERoleDevelopCategoryType? curSelectCategoryType = this.CurSelectCategoryType;
			ERoleDevelopCategoryType categoryType = data.CategoryType;
			return !(curSelectCategoryType.GetValueOrDefault() == categoryType & curSelectCategoryType != null);
		}

		// Token: 0x060354BC RID: 218300 RVA: 0x00D5EDAC File Offset: 0x00D5CFAC
		private void OnClickToggleRoleMark(EToggleState state)
		{
			int id = this.CurSelectRoleDevelopData.GetId();
			int roleId = (ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId == id) ? 0 : id;
			RoleDevelopProjectPhantomPanel roleDevelopProjectPhantomPanel = (RoleDevelopProjectPhantomPanel)this.ProjectPanelMap[ERoleDevelopCategoryType.Phantom];
			ControllerBase<RoleController>.Instance.RequestUpdateDevelopTarget(roleId, ERoleDevelopUpdateTargetSource.RoleDevelop, new int?(roleDevelopProjectPhantomPanel.SelectPlanId), roleDevelopProjectPhantomPanel.SelectFirstVisionMonsterId);
		}

		// Token: 0x060354BD RID: 218301 RVA: 0x00D5EE06 File Offset: 0x00D5D006
		private void OnCommonItemCountAnyChange(int configId, int count)
		{
			if (this.CurSelectCategoryType == null)
			{
				return;
			}
			this.ProjectPanelMap[this.CurSelectCategoryType.Value].OnCommonItemCountAnyChange(configId);
			this.RefreshCategoryHint();
		}

		// Token: 0x060354BE RID: 218302 RVA: 0x00D5EE38 File Offset: 0x00D5D038
		private void OnRoleDevTargetRoleIdChange()
		{
			this.RefreshRoleMarkToggle();
			this.RoleLayout.RefreshWithoutDataSync();
			this.HotRoleLayout.RefreshWithoutDataSync();
		}

		// Token: 0x060354BF RID: 218303 RVA: 0x00D5EE56 File Offset: 0x00D5D056
		private void OnActiveRole(int roleId)
		{
			this.NeedRebuildDataOnShow = true;
		}

		// Token: 0x060354C0 RID: 218304 RVA: 0x00D5EE60 File Offset: 0x00D5D060
		private void OnUpdateSortList(List<RoleDataBase> dataList, bool isOutSideChange, EFilterSortType operationType)
		{
			this.RoleDataList = dataList;
			Dictionary<int, int> orderMap = new Dictionary<int, int>();
			for (int i = 0; i < dataList.Count; i++)
			{
				orderMap[dataList[i].GetRoleId()] = i;
			}
			int targetRoleId = ModelBase<RoleDevelopModel>.Instance.DevTargetRoleId;
			this.RoleDevelopDataList.Sort(delegate(RoleDevelopData a, RoleDevelopData b)
			{
				int id = a.GetId();
				int id2 = b.GetId();
				if (targetRoleId > 0)
				{
					if (id == targetRoleId)
					{
						return -1;
					}
					if (id2 == targetRoleId)
					{
						return 1;
					}
				}
				int num = orderMap.ContainsKey(id) ? orderMap[id] : int.MaxValue;
				int num2 = orderMap.ContainsKey(id2) ? orderMap[id2] : int.MaxValue;
				return num - num2;
			});
			this.RoleLayout.RefreshByData(this.RoleDevelopDataList, new Action(this.OnRoleGridLayoutRefresh), true);
			base.GetScrollViewWithScrollbar(24).SetScrollProgress(0f);
		}

		// Token: 0x060354C1 RID: 218305 RVA: 0x00D5EF05 File Offset: 0x00D5D105
		private bool IsNormalRole(int roleId)
		{
			return !RoleDevelopUtil.IsAnyProspectRole(roleId);
		}

		// Token: 0x060354C2 RID: 218306 RVA: 0x00D5EF10 File Offset: 0x00D5D110
		private void OnRoleGridLayoutRefresh()
		{
			if (this.CurSelectRoleDevelopData == null)
			{
				this.CurSelectRoleDevelopData = this.RoleDevelopDataList[0];
			}
			int id = this.CurSelectRoleDevelopData.GetId();
			if (!this.IsNormalRole(id))
			{
				return;
			}
			this.RoleLayout.SelectGridProxyByKey(id, false);
			this.OnRoleGridItemSelected(this.CurSelectRoleDevelopData);
		}

		// Token: 0x060354C3 RID: 218307 RVA: 0x00D5EF6C File Offset: 0x00D5D16C
		private void OnHotRoleGridLayoutRefresh()
		{
			int id = this.CurSelectRoleDevelopData.GetId();
			if (this.IsNormalRole(id))
			{
				return;
			}
			this.HotRoleLayout.SelectGridProxyByKey(id, true);
			this.OnHotRoleGridItemSelected(this.CurSelectRoleDevelopData);
		}

		// Token: 0x060354C4 RID: 218308 RVA: 0x00D5EFB0 File Offset: 0x00D5D1B0
		private void OnIntroductionBtnClick()
		{
			int id = this.CurSelectRoleDevelopData.GetId();
			if (RoleDevelopUtil.IsAnyProspectRole(id))
			{
				ControllerBase<ChannelController>.Instance.OpenGameIntroduction();
				return;
			}
			ControllerBase<ChannelController>.Instance.OpenGameIntroductionByRoleId(id);
		}

		// Token: 0x0401EA6D RID: 125549
		private PopupCaptionItem CaptainItem;

		// Token: 0x0401EA6E RID: 125550
		private GenericLayout<RoleDevelopHotRoleGridItem, RoleDevelopData> HotRoleLayout;

		// Token: 0x0401EA6F RID: 125551
		private GenericLayout<RoleDevelopGridItem, RoleDevelopData> RoleLayout;

		// Token: 0x0401EA70 RID: 125552
		[Nullable(2)]
		private RoleDevelopData CurSelectRoleDevelopData;

		// Token: 0x0401EA71 RID: 125553
		private bool IsSelectedFromHotRole;

		// Token: 0x0401EA72 RID: 125554
		private RoleDevelopTagItem RoleDevelopTagItem;

		// Token: 0x0401EA73 RID: 125555
		private ERoleDevelopCategoryType? CurSelectCategoryType;

		// Token: 0x0401EA74 RID: 125556
		private GenericLayout<RoleDevelopCategoryItem, RoleDevelopCategoryData> CategoryLayout;

		// Token: 0x0401EA75 RID: 125557
		private CommonElementItem ElementItem;

		// Token: 0x0401EA76 RID: 125558
		private FilterSortEntrance<RoleDataBase> FilterSortEntrance;

		// Token: 0x0401EA77 RID: 125559
		private List<RoleDataBase> RoleDataList = new List<RoleDataBase>();

		// Token: 0x0401EA78 RID: 125560
		private List<RoleDevelopData> RoleDevelopDataList = new List<RoleDevelopData>();

		// Token: 0x0401EA79 RID: 125561
		private Dictionary<ERoleDevelopCategoryType, RoleDevelopProjectBasePanel> ProjectPanelMap = new Dictionary<ERoleDevelopCategoryType, RoleDevelopProjectBasePanel>();

		// Token: 0x0401EA7A RID: 125562
		private Dictionary<ERoleDevelopCategoryType, UUIItem> ProjectLayoutMap = new Dictionary<ERoleDevelopCategoryType, UUIItem>();

		// Token: 0x0401EA7B RID: 125563
		private Dictionary<ERoleDevelopCategoryType, UUIItem> ProjectScrollViewMap = new Dictionary<ERoleDevelopCategoryType, UUIItem>();

		// Token: 0x0401EA7C RID: 125564
		private bool RefreshOnShow;

		// Token: 0x0401EA7D RID: 125565
		private bool NeedRebuildDataOnShow;

		// Token: 0x0401EA7E RID: 125566
		[Nullable(2)]
		private RoleViewViewModel ViewModel;

		// Token: 0x0200B061 RID: 45153
		[NullableContext(0)]
		public static class EComponentType
		{
			// Token: 0x04036B9C RID: 224156
			public const int Caption = 0;

			// Token: 0x04036B9D RID: 224157
			public const int GridNewRole = 1;

			// Token: 0x04036B9E RID: 224158
			public const int GridOwnRole = 2;

			// Token: 0x04036B9F RID: 224159
			public const int RoleItem = 3;

			// Token: 0x04036BA0 RID: 224160
			public const int FilterSortItem = 4;

			// Token: 0x04036BA1 RID: 224161
			public const int TextureRole = 5;

			// Token: 0x04036BA2 RID: 224162
			public const int TxtRoleName = 6;

			// Token: 0x04036BA3 RID: 224163
			public const int Tag = 7;

			// Token: 0x04036BA4 RID: 224164
			public const int DevelopTag = 8;

			// Token: 0x04036BA5 RID: 224165
			public const int TxtProperty = 9;

			// Token: 0x04036BA6 RID: 224166
			public const int ElementIcon = 10;

			// Token: 0x04036BA7 RID: 224167
			public const int ToggleLayout = 11;

			// Token: 0x04036BA8 RID: 224168
			public const int DevelopToggle = 12;

			// Token: 0x04036BA9 RID: 224169
			public const int SubRoleViewLayout = 13;

			// Token: 0x04036BAA RID: 224170
			public const int SubRoleViewScrollView = 14;

			// Token: 0x04036BAB RID: 224171
			public const int SubSkillViewLayout = 15;

			// Token: 0x04036BAC RID: 224172
			public const int SubSkillViewScrollView = 16;

			// Token: 0x04036BAD RID: 224173
			public const int SubWeaponViewLayout = 17;

			// Token: 0x04036BAE RID: 224174
			public const int SubWeaponViewScrollView = 18;

			// Token: 0x04036BAF RID: 224175
			public const int SubPhantomViewLayout = 19;

			// Token: 0x04036BB0 RID: 224176
			public const int SubPhantomViewScrollView = 20;

			// Token: 0x04036BB1 RID: 224177
			public const int EmptyPanel = 21;

			// Token: 0x04036BB2 RID: 224178
			public const int ToggleRoleMark = 22;

			// Token: 0x04036BB3 RID: 224179
			public const int IntroductionBtn = 23;

			// Token: 0x04036BB4 RID: 224180
			public const int ScrollView = 24;
		}
	}
}
