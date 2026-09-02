using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.PlayerInput;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection.SelectServer
{
	// Token: 0x02004528 RID: 17704
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixNetworkDetectSelectView : LaunchComponentsAction
	{
		// Token: 0x0602EA2F RID: 191023 RVA: 0x00B0C16C File Offset: 0x00B0A36C
		protected override void OnStart()
		{
			base.GetButton(1).OnClickCallBack.Bind(new Action(this.OnBackBtnClick));
			HotFixManager.SetLocalText(base.GetText(2), "NetworkDetection_Select", Array.Empty<string>());
			base.AttachElement<HotFixButtonItem>(6).BindClickCallback(new Action(this.OnRightBtnClick));
			HotFixButtonItem hotFixButtonItem = base.AttachElement<HotFixButtonItem>(5);
			hotFixButtonItem.BindClickCallback(new Action(this.OnLeftBtnClick));
			hotFixButtonItem.SetLocalText("NetworkDetection_Cancel");
			UUILayoutBase layout = base.GetLayout(7);
			AUIBaseActor gridActor = base.GetItem(4).GetOwner() as AUIBaseActor;
			this.HotFixNetworkDetectSelectLayout = new HotFixLayout<HotFixNetworkDetectSelectItem, IHotFixNetworkDetectSelectData>(layout, () => new HotFixNetworkDetectSelectItem(), gridActor);
			Singleton<HotPatchInputManager>.Instance.RegisterInputAxis("手柄右摇杆垂直方向", new TInputAxis(this.InputAxis));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左摇杆上", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左摇杆下", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左边上键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左边下键", new TInputAction(this.InputAction));
			this.RegisteredInput = true;
		}

		// Token: 0x0602EA30 RID: 191024 RVA: 0x00B0C2BC File Offset: 0x00B0A4BC
		protected override void OnShow()
		{
			List<IHotFixNetworkDetectSelectData> loginServersLayoutItemData = Singleton<HotFixNetworkDetectionModel>.Instance.GetLoginServersLayoutItemData();
			Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData = Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData;
			int recommendedServerIndex = this.GetRecommendedServerIndex(loginServersLayoutItemData);
			this.CurrentSelectIndex = ((Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData != null) ? recommendedServerIndex : -1);
			this.HotFixNetworkDetectSelectLayout.RefreshByData(loginServersLayoutItemData);
			this.BindToggleGroupChanged();
			this.TryMoveToItem(loginServersLayoutItemData);
		}

		// Token: 0x0602EA31 RID: 191025 RVA: 0x00B0C320 File Offset: 0x00B0A520
		private void BindToggleGroupChanged()
		{
			IReadOnlyList<IHotFixLayoutItem> layoutItemList = this.HotFixNetworkDetectSelectLayout.GetLayoutItemList();
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				((HotFixNetworkDetectSelectItem)layoutItemList[i]).OnToggleStateChange = new Action(this.RefreshToggleGroupState);
			}
		}

		// Token: 0x0602EA32 RID: 191026 RVA: 0x00B0C368 File Offset: 0x00B0A568
		private void RefreshToggleGroupState()
		{
			IReadOnlyList<IHotFixLayoutItem> layoutItemList = this.HotFixNetworkDetectSelectLayout.GetLayoutItemList();
			for (int i = 0; i < layoutItemList.Count; i++)
			{
				((HotFixNetworkDetectSelectItem)layoutItemList[i]).RefreshToggleState();
			}
		}

		// Token: 0x0602EA33 RID: 191027 RVA: 0x00B0C3A4 File Offset: 0x00B0A5A4
		protected override void OnBeforeDestroy()
		{
			this.HotFixNetworkDetectSelectLayout.ClearChildren();
			if (this.RegisteredInput)
			{
				Singleton<HotPatchInputManager>.Instance.UnRegisterInputAxis("手柄右摇杆垂直方向", new TInputAxis(this.InputAxis));
				Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左摇杆上", new TInputAction(this.InputAction));
				Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左摇杆下", new TInputAction(this.InputAction));
				Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左边上键", new TInputAction(this.InputAction));
				Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左边下键", new TInputAction(this.InputAction));
				this.RegisteredInput = false;
			}
		}

		// Token: 0x0602EA34 RID: 191028 RVA: 0x00B0C455 File Offset: 0x00B0A655
		private void OnBackBtnClick()
		{
			this.CloseMe();
		}

		// Token: 0x0602EA35 RID: 191029 RVA: 0x00B0C45D File Offset: 0x00B0A65D
		private void OnLeftBtnClick()
		{
			this.CloseMe();
		}

		// Token: 0x0602EA36 RID: 191030 RVA: 0x00B0C468 File Offset: 0x00B0A668
		private void OnRightBtnClick()
		{
			ILoginServersData currentUiSelectSeverData = Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData;
			Singleton<HotFixNetworkDetectionModel>.Instance.CurrentSelectServerData = currentUiSelectSeverData;
			TOnSelectServerCallback onSelectServerCallBack = this.OnSelectServerCallBack;
			if (onSelectServerCallBack != null)
			{
				onSelectServerCallBack();
			}
			this.CloseMe();
		}

		// Token: 0x0602EA37 RID: 191031 RVA: 0x00B0C4A2 File Offset: 0x00B0A6A2
		private void CloseMe()
		{
			base.SetActive(false);
		}

		// Token: 0x0602EA38 RID: 191032 RVA: 0x00B0C4AC File Offset: 0x00B0A6AC
		private void TryMoveToItem(IReadOnlyList<IHotFixNetworkDetectSelectData> dataList)
		{
			int recommendedServerIndex = this.GetRecommendedServerIndex(dataList);
			UUIItem gridItemByIndex = this.HotFixNetworkDetectSelectLayout.GetGridItemByIndex(recommendedServerIndex);
			base.GetUiScrollViewWithScrollBar(3).ScrollTo(gridItemByIndex, false);
		}

		// Token: 0x0602EA39 RID: 191033 RVA: 0x00B0C4DC File Offset: 0x00B0A6DC
		private int GetRecommendedServerIndex(IReadOnlyList<IHotFixNetworkDetectSelectData> dataList)
		{
			int result = 0;
			int count = dataList.Count;
			for (int i = 0; i < count; i++)
			{
				if (Singleton<HotFixNetworkDetectionModel>.Instance.CurrentUiSelectSeverData == dataList[i].LoginServersData)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0602EA3A RID: 191034 RVA: 0x00B0C51C File Offset: 0x00B0A71C
		private void InputAxis(float value, string axisName)
		{
			if (value == 0f)
			{
				return;
			}
			if ("手柄右摇杆垂直方向" == axisName)
			{
				base.GetUiScrollViewWithScrollBar(3).SetVelocity(value * 800f);
			}
			if ("手柄左摇杆垂直方向" == axisName)
			{
				if (value < 0f)
				{
					this.FocusNext();
				}
				if (value > 0f)
				{
					this.FocusPrev();
				}
			}
		}

		// Token: 0x0602EA3B RID: 191035 RVA: 0x00B0C57C File Offset: 0x00B0A77C
		private void InputAction(bool bPress, string actionName)
		{
			if (!bPress)
			{
				return;
			}
			if ("手柄左边上键" == actionName || "手柄左摇杆上" == actionName)
			{
				this.FocusPrev();
			}
			if ("手柄左边下键" == actionName || "手柄左摇杆下" == actionName)
			{
				this.FocusNext();
			}
		}

		// Token: 0x0602EA3C RID: 191036 RVA: 0x00B0C5D0 File Offset: 0x00B0A7D0
		private void FocusPrev()
		{
			int val = 0;
			int num = this.CurrentSelectIndex - 1;
			this.CurrentSelectIndex = num;
			this.CurrentSelectIndex = Math.Max(val, num);
			this.HandleFocusScrollItem();
		}

		// Token: 0x0602EA3D RID: 191037 RVA: 0x00B0C600 File Offset: 0x00B0A800
		private void FocusNext()
		{
			int val = this.HotFixNetworkDetectSelectLayout.GetDataList().Count - 1;
			int num = this.CurrentSelectIndex + 1;
			this.CurrentSelectIndex = num;
			this.CurrentSelectIndex = Math.Min(val, num);
			this.HandleFocusScrollItem();
		}

		// Token: 0x0602EA3E RID: 191038 RVA: 0x00B0C644 File Offset: 0x00B0A844
		private void HandleFocusScrollItem()
		{
			HotFixNetworkDetectSelectItem hotFixNetworkDetectSelectItem = this.HotFixNetworkDetectSelectLayout.GetLayoutItemByIndex(this.CurrentSelectIndex) as HotFixNetworkDetectSelectItem;
			if (hotFixNetworkDetectSelectItem != null)
			{
				HotFixNetworkDetectionModel instance = Singleton<HotFixNetworkDetectionModel>.Instance;
				IHotFixNetworkDetectSelectData data = hotFixNetworkDetectSelectItem.Data;
				instance.CurrentUiSelectSeverData = ((data != null) ? data.LoginServersData : null);
				base.GetUiScrollViewWithScrollBar(3).ScrollToSelectableComponent(hotFixNetworkDetectSelectItem.GetToggle());
				this.RefreshToggleGroupState();
			}
		}

		// Token: 0x0401A7B7 RID: 108471
		private HotFixLayout<HotFixNetworkDetectSelectItem, IHotFixNetworkDetectSelectData> HotFixNetworkDetectSelectLayout;

		// Token: 0x0401A7B8 RID: 108472
		[Nullable(2)]
		public TOnSelectServerCallback OnSelectServerCallBack;

		// Token: 0x0401A7B9 RID: 108473
		private int CurrentSelectIndex = -1;

		// Token: 0x0401A7BA RID: 108474
		private bool RegisteredInput;

		// Token: 0x0200A743 RID: 42819
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04033EA3 RID: 212643
			public const int BtnMask = 0;

			// Token: 0x04033EA4 RID: 212644
			public const int BtnBack = 1;

			// Token: 0x04033EA5 RID: 212645
			public const int TxtTitle = 2;

			// Token: 0x04033EA6 RID: 212646
			public const int ScrollView = 3;

			// Token: 0x04033EA7 RID: 212647
			public const int ServerItem = 4;

			// Token: 0x04033EA8 RID: 212648
			public const int LeftBtn = 5;

			// Token: 0x04033EA9 RID: 212649
			public const int RightBtn = 6;

			// Token: 0x04033EAA RID: 212650
			public const int Content = 7;
		}
	}
}
