using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.PlayerInput;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004501 RID: 17665
	[NullableContext(1)]
	[Nullable(0)]
	public class HotFixDownLoadView : LaunchComponentsAction
	{
		// Token: 0x0602E8DE RID: 190686 RVA: 0x00B07B30 File Offset: 0x00B05D30
		protected override void OnStart()
		{
			HotFixBtnUiItem hotFixBtnUiItem = base.AttachElement<HotFixBtnUiItem>(8);
			hotFixBtnUiItem.BindClickCallback(delegate
			{
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "HotFixDownLoadView ClickBtnCallback";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("this.SelectTabIndex", this.SelectTabIndex);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				HotFixManager.ResDownLoadType = (EResUpdateType)this.SelectTabIndex;
				long resSize = Singleton<ResourceDiffUpdaterManager>.Instance.GetResSize((EResUpdateType)this.SelectTabIndex);
				HotFixManager.NeedDownLoadByte = resSize;
				if (Singleton<VideoResUpdate>.Instance.GetFreeSpace() >= resSize)
				{
					Action downLoadViewChoseDoneCallBack = HotFixManager.DownLoadViewChoseDoneCallBack;
					if (downLoadViewChoseDoneCallBack != null)
					{
						downLoadViewChoseDoneCallBack();
					}
					Action freeSpaceCheckDoneCallBack = HotFixManager.FreeSpaceCheckDoneCallBack;
					if (freeSpaceCheckDoneCallBack != null)
					{
						freeSpaceCheckDoneCallBack();
					}
				}
				else
				{
					this.SetFreeSpaceTipsPopActive(true);
				}
				base.SetActive(false);
			});
			hotFixBtnUiItem.SetText("Download_DownLoadBtnText", Array.Empty<string>());
			base.AttachElement<HotFixBtnUiItem>(9).BindClickCallback(delegate
			{
				if (this.SetClearSubPackagePopActiveCallBack != null)
				{
					this.SetClearSubPackagePopActiveCallBack(true, delegate
					{
						base.SetActive(true);
					});
				}
				int canCleanUpSpace = (int)(HotFixManager.GetAllCanClearSpace() / 1048576L);
				FLoginStruct loginData = HotFixManager.LoginData;
				new InitialMobileResCleanUpViewStateLog(canCleanUpSpace, ((loginData != null) ? loginData.Uid : null) ?? "", Singleton<ResourceDiffUpdaterManager>.Instance.TraceId.ToString(), 1, null).Report();
				base.SetActive(false);
			});
			UUILayoutBase layout = base.GetLayout(1);
			AUIBaseActor gridActor = base.GetItem(0).GetOwner() as AUIBaseActor;
			this.HotFixTabLayout = new HotFixLayout<HotFixDownLoadTabItem, IHotFixDownLoadTabItemData>(layout, () => new HotFixDownLoadTabItem
			{
				OnClickExtendToggleCallBack = new Action<int, UUIExtendToggle>(this.OnClickToggle)
			}, gridActor);
			HotFixManager.SetLocalText(base.GetText(11), "PrefabTextItem_1851234659_Text", Array.Empty<string>());
		}

		// Token: 0x0602E8DF RID: 190687 RVA: 0x00B07BC8 File Offset: 0x00B05DC8
		protected override void OnHide()
		{
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAxis("手柄右摇杆垂直方向", new TInputAxis(this.InputAxis));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左摇杆上", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左摇杆下", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左边上键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.UnRegisterInputAction("手柄左边下键", new TInputAction(this.InputAction));
		}

		// Token: 0x0602E8E0 RID: 190688 RVA: 0x00B07C5C File Offset: 0x00B05E5C
		protected override void OnShow()
		{
			List<IHotFixDownLoadTabItemData> list = new List<IHotFixDownLoadTabItemData>();
			for (int i = 1; i <= 2; i++)
			{
				HotFixDownLoadTabItemData item = new HotFixDownLoadTabItemData
				{
					TabId = i
				};
				list.Add(item);
			}
			this.HotFixTabLayout.RefreshByData(list);
			((HotFixDownLoadTabItem)this.HotFixTabLayout.GetLayoutItemByIndex(0)).Select();
			long allCanClearSpace = HotFixManager.GetAllCanClearSpace();
			base.GetButton(9).SetSelfInteractive(allCanClearSpace > 0L);
			HotFixBtnUiItem element = base.GetElement<HotFixBtnUiItem>(9);
			if (allCanClearSpace > 0L)
			{
				element.SetText("HotFixSubPackageClearButton_Out", new string[]
				{
					HotFixManager.ByteConverter(allCanClearSpace)
				});
			}
			else
			{
				element.SetText("HotFixSubPackageHaveNoSpaceClear", Array.Empty<string>());
			}
			Singleton<HotPatchInputManager>.Instance.RegisterInputAxis("手柄右摇杆垂直方向", new TInputAxis(this.InputAxis));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左摇杆上", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左摇杆下", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左边上键", new TInputAction(this.InputAction));
			Singleton<HotPatchInputManager>.Instance.RegisterInputAction("手柄左边下键", new TInputAction(this.InputAction));
		}

		// Token: 0x0602E8E1 RID: 190689 RVA: 0x00B07D8C File Offset: 0x00B05F8C
		private void OnClickToggle(int tabIndex, UUIExtendToggle toggle)
		{
			UUIExtendToggle currentSelectToggle = this.CurrentSelectToggle;
			if (currentSelectToggle != null)
			{
				currentSelectToggle.SetToggleState(EToggleState.ETT_UnChecked, false, false, false);
			}
			this.CurrentSelectToggle = toggle;
			this.RefreshTabContent(tabIndex);
		}

		// Token: 0x0602E8E2 RID: 190690 RVA: 0x00B07DB4 File Offset: 0x00B05FB4
		private void RefreshTabContent(int tabIndex)
		{
			this.SelectTabIndex = tabIndex;
			LauncherDownLoadConfig downLoadTabConfig = Singleton<LauncherConfigLib>.Instance.GetDownLoadTabConfig(tabIndex.ToString());
			HotFixManager.SetLocalText(base.GetText(2), downLoadTabConfig.ContentTitle, Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(3), downLoadTabConfig.Content, Array.Empty<string>());
			long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
			if (freeSpace > Singleton<ResourceDiffUpdaterManager>.Instance.GetResSize((EResUpdateType)this.SelectTabIndex))
			{
				HotFixManager.SetLocalText(base.GetText(4), "DownLoadText_LeftSpace", new string[]
				{
					"<color=#36cd33>" + HotFixManager.ByteConverter(freeSpace) + "</color>"
				});
				return;
			}
			HotFixManager.SetLocalText(base.GetText(4), "DownLoadText_LeftSpace", new string[]
			{
				"<color=#c25757>" + HotFixManager.ByteConverter(freeSpace) + "</color>"
			});
		}

		// Token: 0x0602E8E3 RID: 190691 RVA: 0x00B07E88 File Offset: 0x00B06088
		public void SetFreeSpaceTipsPopActive(bool value)
		{
			Action<bool> setFreeSpaceTipsPopActiveCallBack = this.SetFreeSpaceTipsPopActiveCallBack;
			if (setFreeSpaceTipsPopActiveCallBack != null)
			{
				setFreeSpaceTipsPopActiveCallBack(value);
			}
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "SetHotFixDownLoadFreeSpaceTipsViewActive";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("value", value);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0602E8E4 RID: 190692 RVA: 0x00B07ECF File Offset: 0x00B060CF
		private void InputAxis(float value, string axisName)
		{
			if (value == 0f)
			{
				return;
			}
			if ("手柄右摇杆垂直方向" == axisName)
			{
				base.GetUiScrollViewWithScrollBar(12).SetVelocity(value * 800f);
			}
		}

		// Token: 0x0602E8E5 RID: 190693 RVA: 0x00B07EFC File Offset: 0x00B060FC
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

		// Token: 0x0602E8E6 RID: 190694 RVA: 0x00B07F4D File Offset: 0x00B0614D
		private void FocusPrev()
		{
			this.SelectTabIndexToggle(Math.Max(0, this.SelectTabIndex - 1 - 1));
		}

		// Token: 0x0602E8E7 RID: 190695 RVA: 0x00B07F65 File Offset: 0x00B06165
		private void FocusNext()
		{
			this.SelectTabIndexToggle(Math.Min(1, this.SelectTabIndex - 1 + 1));
		}

		// Token: 0x0602E8E8 RID: 190696 RVA: 0x00B07F7D File Offset: 0x00B0617D
		private void SelectTabIndexToggle(int index)
		{
			((HotFixDownLoadTabItem)this.HotFixTabLayout.GetLayoutItemByIndex(index)).Select();
		}

		// Token: 0x0401A72A RID: 108330
		private const long MB_SIZE = 1048576L;

		// Token: 0x0401A72B RID: 108331
		private int SelectTabIndex = -1;

		// Token: 0x0401A72C RID: 108332
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private HotFixLayout<HotFixDownLoadTabItem, IHotFixDownLoadTabItemData> HotFixTabLayout;

		// Token: 0x0401A72D RID: 108333
		[Nullable(2)]
		private UUIExtendToggle CurrentSelectToggle;

		// Token: 0x0401A72E RID: 108334
		[Nullable(2)]
		public Action<bool> SetFreeSpaceTipsPopActiveCallBack;

		// Token: 0x0401A72F RID: 108335
		[Nullable(2)]
		public Action<bool, Action> SetClearSubPackagePopActiveCallBack;

		// Token: 0x0200A718 RID: 42776
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x04033DB1 RID: 212401
			public const int LayoutItem = 0;

			// Token: 0x04033DB2 RID: 212402
			public const int TabLayout = 1;

			// Token: 0x04033DB3 RID: 212403
			public const int TitleText = 2;

			// Token: 0x04033DB4 RID: 212404
			public const int DesText = 3;

			// Token: 0x04033DB5 RID: 212405
			public const int MemoryText = 4;

			// Token: 0x04033DB6 RID: 212406
			public const int DownLoadBar = 5;

			// Token: 0x04033DB7 RID: 212407
			public const int DownLoadBarTexture = 6;

			// Token: 0x04033DB8 RID: 212408
			public const int SpeedText = 7;

			// Token: 0x04033DB9 RID: 212409
			public const int RightBtnItem = 8;

			// Token: 0x04033DBA RID: 212410
			public const int LeftBtnItem = 9;

			// Token: 0x04033DBB RID: 212411
			public const int MainTitleText = 11;

			// Token: 0x04033DBC RID: 212412
			public const int ScrollView = 12;
		}
	}
}
