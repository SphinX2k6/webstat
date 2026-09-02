using System;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.Download;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044AB RID: 17579
	[NullableContext(1)]
	[Nullable(0)]
	public static class LauncherTextLib
	{
		// Token: 0x0602E576 RID: 189814 RVA: 0x00AE21D0 File Offset: 0x00AE03D0
		public static string DownloadSpeedFormat(long speedBps)
		{
			if (speedBps < 1024L)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(3, 1);
				defaultInterpolatedStringHandler.AppendFormatted<long>(speedBps);
				defaultInterpolatedStringHandler.AppendLiteral("B/s");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (speedBps < 1048576L)
			{
				return ((double)speedBps / 1024.0).ToString("F1") + "KB/s";
			}
			return ((double)speedBps / 1024.0 / 1024.0).ToString("F1") + "MB/s";
		}

		// Token: 0x0602E577 RID: 189815 RVA: 0x00AE2268 File Offset: 0x00AE0468
		public static string SpaceSizeFormat(long size)
		{
			if (size < 1024L)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 1);
				defaultInterpolatedStringHandler.AppendFormatted<long>(size);
				defaultInterpolatedStringHandler.AppendLiteral("B");
				return defaultInterpolatedStringHandler.ToStringAndClear();
			}
			if (size < 1048576L)
			{
				return ((double)size / 1024.0).ToString("F2") + "K";
			}
			if (size < 1073741824L)
			{
				return ((double)size / 1048576.0).ToString("F2") + "M";
			}
			return ((double)size / 1073741824.0).ToString("F2") + "G";
		}

		// Token: 0x0602E578 RID: 189816 RVA: 0x00AE2320 File Offset: 0x00AE0520
		public static string DownloadStateFormat(EDownloadState state)
		{
			switch (state)
			{
			case EDownloadState.None:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateNone");
			case EDownloadState.HttpError:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateHttpError");
			case EDownloadState.FileRenameError:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateFileRenameError");
			case EDownloadState.ValidateError:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateValidateError");
			case EDownloadState.OpenToWriteError:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateOpenToWriteError");
			case EDownloadState.NotEnoughSpace:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateNotEnoughSpace");
			case EDownloadState.DownloadCanceled:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateDownloadCanceled");
			case EDownloadState.Success:
				return Singleton<LauncherConfigLib>.Instance.GetHotPatchText("DownloadStateSuccess");
			default:
				return "";
			}
		}

		// Token: 0x0401A56D RID: 107885
		public const long BigIntKb = 1024L;

		// Token: 0x0401A56E RID: 107886
		public const long BigIntMb = 1048576L;

		// Token: 0x0401A56F RID: 107887
		public const long BigIntGb = 1073741824L;

		// Token: 0x0401A570 RID: 107888
		public const int NUMBER_KB = 1024;

		// Token: 0x0401A571 RID: 107889
		public const int NUMBER_MB = 1048576;

		// Token: 0x0401A572 RID: 107890
		public const int NUMBER_GB = 1073741824;
	}
}
