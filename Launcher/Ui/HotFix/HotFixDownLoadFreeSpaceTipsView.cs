using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.DiffPatch.Update;
using CSharpScript.Launcher.Update.ResourceDiffUpdate;
using UnrealEngine;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x02004500 RID: 17664
	public class HotFixDownLoadFreeSpaceTipsView : LaunchComponentsAction
	{
		// Token: 0x0602E8D7 RID: 190679 RVA: 0x00B07854 File Offset: 0x00B05A54
		protected override void OnStart()
		{
			base.AttachElement<HotFixBtnUiItem>(2).BindClickCallback(new Action(this.OnCancelBtnClick));
			base.AttachElement<HotFixBtnUiItem>(3).BindClickCallback(new Action(this.OnConfirmBtnClick));
			HotFixManager.SetLocalText(base.GetText(5), "Download_NoSpace", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(6), "Download_Retry", Array.Empty<string>());
			HotFixManager.SetLocalText(base.GetText(8), "Download_DownLoadBtnRetry", Array.Empty<string>());
		}

		// Token: 0x0602E8D8 RID: 190680 RVA: 0x00B078D4 File Offset: 0x00B05AD4
		private void OnCancelBtnClick()
		{
			base.SetActive(false);
			Singleton<LauncherLog>.Instance.Info("HotFixDownLoadFreeSpaceTipsView CancelBtn", default(ReadOnlySpan<ValueTuple<string, object>>));
			if (this.CanClearSpaceSize > 0L && Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				if (this.SetClearSubPackagePopActiveCallBack != null)
				{
					this.SetClearSubPackagePopActiveCallBack(true, delegate
					{
						base.SetActive(true);
					});
				}
				int canCleanUpSpace = (int)(this.CanClearSpaceSize / 1048576L);
				FLoginStruct loginData = HotFixManager.LoginData;
				new InitialMobileResCleanUpViewStateLog(canCleanUpSpace, ((loginData != null) ? loginData.Uid : null) ?? "", Singleton<ResourceDiffUpdaterManager>.Instance.TraceId.ToString(), 2, null).Report();
				return;
			}
			if (this.SetDownLoadActiveCallBack != null)
			{
				this.SetDownLoadActiveCallBack(true);
			}
		}

		// Token: 0x0602E8D9 RID: 190681 RVA: 0x00B07990 File Offset: 0x00B05B90
		private void OnConfirmBtnClick()
		{
			Singleton<LauncherLog>.Instance.Info("HotFixDownLoadFreeSpaceTipsView ConfirmBtn", default(ReadOnlySpan<ValueTuple<string, object>>));
			this.RefreshView();
			long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
			long needDownLoadByte = HotFixManager.NeedDownLoadByte;
			if (freeSpace > needDownLoadByte)
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
				base.SetActive(false);
				return;
			}
			this.RefreshView();
		}

		// Token: 0x0602E8DA RID: 190682 RVA: 0x00B079FC File Offset: 0x00B05BFC
		protected override void OnShow()
		{
			this.RefreshView();
			this.CanClearSpaceSize = HotFixManager.GetAllCanClearSpace();
			HotFixBtnUiItem element = base.GetElement<HotFixBtnUiItem>(2);
			base.GetButton(2).SetSelfInteractive(this.CanClearSpaceSize > 0L);
			if (this.CanClearSpaceSize > 0L && Singleton<ResourceDiffUpdaterManager>.Instance.IsGrayBoxHit())
			{
				element.SetText("HotFixSubPackageClearButton_Out", new string[]
				{
					HotFixManager.ByteConverter(this.CanClearSpaceSize)
				});
				int remainingSpace = (int)(this.CanClearSpaceSize / 1048576L);
				FLoginStruct loginData = HotFixManager.LoginData;
				new StorageAlertLog(remainingSpace, ((loginData != null) ? loginData.Uid : null) ?? "", null).Report();
				return;
			}
			element.SetText("HotFixSubPackageHaveNoSpaceClear", Array.Empty<string>());
		}

		// Token: 0x0602E8DB RID: 190683 RVA: 0x00B07AB4 File Offset: 0x00B05CB4
		private void RefreshView()
		{
			HotFixManager.SetLocalText(base.GetText(0), "DownLoadText_NeedSpace", new string[]
			{
				HotFixManager.ByteConverter(HotFixManager.NeedDownLoadByte)
			});
			long freeSpace = Singleton<VideoResUpdate>.Instance.GetFreeSpace();
			HotFixManager.SetLocalText(base.GetText(1), "DownLoadText_LeftSpace", new string[]
			{
				"<color=#c25757>" + HotFixManager.ByteConverter(freeSpace) + "</color>"
			});
		}

		// Token: 0x0401A726 RID: 108326
		private const long MB_SIZE = 1048576L;

		// Token: 0x0401A727 RID: 108327
		[Nullable(2)]
		public Action<bool> SetDownLoadActiveCallBack;

		// Token: 0x0401A728 RID: 108328
		[Nullable(2)]
		public Action<bool, Action> SetClearSubPackagePopActiveCallBack;

		// Token: 0x0401A729 RID: 108329
		private long CanClearSpaceSize;

		// Token: 0x0200A717 RID: 42775
		private static class EComponentDefine
		{
			// Token: 0x04033DA8 RID: 212392
			public const int NeedSpaceText = 0;

			// Token: 0x04033DA9 RID: 212393
			public const int LeftSpaceText = 1;

			// Token: 0x04033DAA RID: 212394
			public const int CancelBtn = 2;

			// Token: 0x04033DAB RID: 212395
			public const int ConfirmBtn = 3;

			// Token: 0x04033DAC RID: 212396
			public const int BackBtn = 4;

			// Token: 0x04033DAD RID: 212397
			public const int TitleText = 5;

			// Token: 0x04033DAE RID: 212398
			public const int DesText = 6;

			// Token: 0x04033DAF RID: 212399
			public const int CancelText = 7;

			// Token: 0x04033DB0 RID: 212400
			public const int ConfirmText = 8;
		}
	}
}
