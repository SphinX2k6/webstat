using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.NetworkDetection;
using CSharpScript.Launcher.Platform;
using CSharpScript.Launcher.Update;
using CSharpScript.Launcher.Util;
using CSharpScript.Typing;
using UnrealEngine;

namespace CSharpScript.Launcher.LogUpload
{
	// Token: 0x020045E7 RID: 17895
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherLogUpload : Singleton<LauncherLogUpload>
	{
		// Token: 0x0602ED8B RID: 191883 RVA: 0x00B18290 File Offset: 0x00B16490
		public void Init()
		{
			if (AppUtil.IsPioneerApp())
			{
				UKuroStaticLibrary.ResetHttpMaxFlushTimeSeconds();
				this.EnableAutoSend = true;
			}
			UKuroTencentCOSLibrary.EnableAuthorization(false);
			EntryJson cdnReturnConfigInfo = Singleton<BaseConfigController>.Instance.GetCdnReturnConfigInfo();
			ILogReport logReport = (cdnReturnConfigInfo != null) ? cdnReturnConfigInfo.LogReport : null;
			if (logReport != null)
			{
				UKuroTencentCOSLibrary.SetSendLogConfig("", "", logReport.name, logReport.region);
			}
			else
			{
				Singleton<LauncherLog>.Instance.Error("CDN下发数据未配置腾讯云对象存储相关配置！", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			UKuroTencentCOSLibrary.SetAdmissibleValue(5);
			FOnPrepareSendDelegate fonPrepareSendDelegate = global::DelegateUtils.ToManualReleaseDelegate<FOnPrepareSendDelegate>(new <>A{00000003}<TArray<string>>(this.PreSendFiles));
			FOnPostSended fonPostSended = global::DelegateUtils.ToManualReleaseDelegate<FOnPostSended>(new <>A{00000003}<TArray<string>>(this.PostSended));
			UKuroTencentCOSLibrary.SetHandleFunc(fonPrepareSendDelegate, fonPostSended);
			if (this.EnableAutoSend)
			{
				if (Singleton<Platform>.Instance.IsPcOrGamepadPlatform())
				{
					UKuroTencentCOSLibrary.EnableAutoSendWhenExit();
				}
				if (Singleton<Platform>.Instance.IsMobilePlatform() && UKuroLauncherLibrary.GetNetworkConnectionType() == 4)
				{
					FOnProgress fonProgress = global::DelegateUtils.ToManualReleaseDelegate<FOnProgress>(new Action<ESendState, float>(this.OnAutoSendProgres));
					UKuroTencentCOSLibrary.SendLogToTencentCOS(fonProgress);
				}
			}
		}

		// Token: 0x0602ED8C RID: 191884 RVA: 0x00B1837F File Offset: 0x00B1657F
		public void SetParams(ILogUploadParams params_)
		{
			this.LogUploadParams = params_;
		}

		// Token: 0x0602ED8D RID: 191885 RVA: 0x00B18388 File Offset: 0x00B16588
		private void OnAutoSendProgres(ESendState State, float Rate)
		{
			if (State == ESendState.ESS_Done || State == ESendState.ESS_Fail)
			{
				UKuroTencentCOSLibrary.SetIsAutoSend(false);
			}
		}

		// Token: 0x0602ED8E RID: 191886 RVA: 0x00B18398 File Offset: 0x00B16598
		public void PostSended(in TArray<string> SendedFiles)
		{
			if (this.SendedLogs == null)
			{
				this.SendedLogs = new ILocalSendedSave
				{
					Paths = new List<string>()
				};
			}
			string logFilename = KuroLoggingLibrary.GetLogFilename();
			int num = SendedFiles.Num();
			for (int i = 0; i < num; i++)
			{
				string text = SendedFiles.Get(i);
				if (!text.EndsWith(logFilename) && !this.SendedLogs.Paths.Contains(text))
				{
					this.SendedLogs.Paths.Add(text);
				}
			}
			UKuroStaticLibrary.SaveStringToFile(LauncherJson.Stringify<ILocalSendedSave>(this.SendedLogs, null), UKuroLauncherLibrary.GameSavedDir() + "Logs/Sendedlogs.json", false);
		}

		// Token: 0x0602ED8F RID: 191887 RVA: 0x00B18438 File Offset: 0x00B16638
		public void PreSendFiles(in TArray<string> FileNames)
		{
			TArray<string> tarray = new TArray<string>();
			List<string> list = new List<string>();
			int num = FileNames.Num();
			for (int i = 0; i < num; i++)
			{
				string text = FileNames.Get(i);
				if (!this.IsDir(text))
				{
					string[] array = text.Split('/', StringSplitOptions.None);
					string text2 = array[array.Length - 1].ToLower();
					string[] array2 = text2.Split('.', StringSplitOptions.None);
					string a = null;
					if (array2.Length > 1)
					{
						a = array2[array2.Length - 1];
					}
					if (text2.StartsWith("client") && !text2.StartsWith("client_") && !(a != "log"))
					{
						if (text2.StartsWith("client-"))
						{
							list.Add(text);
						}
						else
						{
							tarray.Add(text);
						}
					}
				}
			}
			string text3 = UKuroLauncherLibrary.GameSavedDir() + "Logs/Sendedlogs.json";
			if (UKuroStaticLibrary.FileExists(text3))
			{
				string text4 = null;
				UKuroStaticLibrary.LoadFileToString(ref text4, text3);
				this.SendedLogs = LauncherJson.Parse<ILocalSendedSave>(text4, null);
				if (this.SendedLogs != null)
				{
					HashSet<string> hashSet = new HashSet<string>(list);
					List<string> paths = this.SendedLogs.Paths;
					this.SendedLogs.Paths = new List<string>();
					foreach (string item in paths)
					{
						if (hashSet.Contains(item))
						{
							this.SendedLogs.Paths.Add(item);
						}
					}
				}
			}
			if (list.Count > 20)
			{
				list.Sort();
				list.RemoveRange(0, list.Count - 20);
			}
			if (this.SendedLogs != null)
			{
				HashSet<string> hashSet2 = new HashSet<string>(this.SendedLogs.Paths);
				List<string> list2 = new List<string>();
				foreach (string item2 in list)
				{
					if (!hashSet2.Contains(item2))
					{
						list2.Add(item2);
					}
				}
				list = list2;
			}
			if (list.Count > 0)
			{
				Match match = Regex.Match(list[0], "\\d{4}.\\d{1,2}.\\d{1,2}-\\d{1,2}.\\d{1,2}.\\d{1,2}");
				if (match.Success && match.Groups.Count > 0)
				{
					this.StartTime = match.Groups[0].Value;
				}
			}
			foreach (string value in list)
			{
				tarray.Add(value);
			}
			string sendZipName = this.GetSendZipName();
			UKuroTencentCOSLibrary.SetFilesToSend(tarray);
			UKuroTencentCOSLibrary.SetSendLogZipName(sendZipName);
			UKuroTencentCOSLibrary.SetCloudPath(this.GetFullPath(sendZipName));
		}

		// Token: 0x0602ED90 RID: 191888 RVA: 0x00B18700 File Offset: 0x00B16900
		private bool IsDir(string path)
		{
			return UKuroStaticLibrary.DirectoryExists(path);
		}

		// Token: 0x0602ED91 RID: 191889 RVA: 0x00B18708 File Offset: 0x00B16908
		private string GetSendZipPlatformName()
		{
			string text = KuroApplication.IniPlatformName();
			if (text != null)
			{
				switch (text.Length)
				{
				case 3:
				{
					char c = text[0];
					if (c <= 'M')
					{
						if (c != 'I')
						{
							if (c != 'M')
							{
								goto IL_138;
							}
							if (!(text == "Mac"))
							{
								goto IL_138;
							}
							return text;
						}
						else
						{
							if (!(text == "IOS"))
							{
								goto IL_138;
							}
							return text;
						}
					}
					else if (c != 'P')
					{
						if (c != 'X')
						{
							goto IL_138;
						}
						if (!(text == "XSX"))
						{
							goto IL_138;
						}
					}
					else
					{
						if (!(text == "PS5"))
						{
							goto IL_138;
						}
						return text;
					}
					break;
				}
				case 4:
				case 8:
				case 9:
				case 10:
					goto IL_138;
				case 5:
					if (!(text == "Linux"))
					{
						goto IL_138;
					}
					return text;
				case 6:
					if (!(text == "WinGDK"))
					{
						goto IL_138;
					}
					break;
				case 7:
				{
					char c = text[0];
					if (c != 'A')
					{
						if (c != 'W')
						{
							if (c != 'X')
							{
								goto IL_138;
							}
							if (!(text == "XboxOne"))
							{
								goto IL_138;
							}
						}
						else
						{
							if (!(text == "Windows"))
							{
								goto IL_138;
							}
							return text;
						}
					}
					else
					{
						if (!(text == "Android"))
						{
							goto IL_138;
						}
						return text;
					}
					break;
				}
				case 11:
					if (!(text == "OpenHarmony"))
					{
						goto IL_138;
					}
					return text;
				default:
					goto IL_138;
				}
				return "Xbox";
			}
			IL_138:
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "未识别的平台, 默认归类到Default分类下";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("平台名", text);
			instance.Error(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return "Default";
		}

		// Token: 0x0602ED92 RID: 191890 RVA: 0x00B18878 File Offset: 0x00B16A78
		private string GetSendZipName()
		{
			this.UpdateUserId();
			string text = "";
			if (this.StartTime != "")
			{
				text = this.StartTime + "-";
			}
			DateTime now = DateTime.Now;
			int year = now.Year;
			int month = now.Month;
			int day = now.Day;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 6);
			defaultInterpolatedStringHandler.AppendFormatted<int>(year);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(month);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(day);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted<int>(now.Hour);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(now.Minute);
			defaultInterpolatedStringHandler.AppendLiteral(".");
			defaultInterpolatedStringHandler.AppendFormatted<int>(now.Second);
			string text2 = defaultInterpolatedStringHandler.ToStringAndClear();
			if (this.UserId == "")
			{
				return text + text2 + ".zip";
			}
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(5, 3);
			defaultInterpolatedStringHandler.AppendFormatted(this.UserId);
			defaultInterpolatedStringHandler.AppendLiteral("-");
			defaultInterpolatedStringHandler.AppendFormatted(text);
			defaultInterpolatedStringHandler.AppendFormatted(text2);
			defaultInterpolatedStringHandler.AppendLiteral(".zip");
			return defaultInterpolatedStringHandler.ToStringAndClear();
		}

		// Token: 0x0602ED93 RID: 191891 RVA: 0x00B189CC File Offset: 0x00B16BCC
		private string GetFullPath(string zipName)
		{
			DateTime now = DateTime.Now;
			string text = now.Year.ToString();
			string text2 = now.Month.ToString();
			string text3 = now.Day.ToString();
			return string.Concat(new string[]
			{
				"/",
				text,
				"/",
				text2,
				"/",
				text3,
				"/",
				this.GetSendZipPlatformName(),
				"/",
				zipName
			});
		}

		// Token: 0x0602ED94 RID: 191892 RVA: 0x00B18A60 File Offset: 0x00B16C60
		public void SendLog(FOnProgress OnProgress)
		{
			UKuroTencentCOSLibrary.SendLogToTencentCOS(OnProgress);
		}

		// Token: 0x0602ED95 RID: 191893 RVA: 0x00B18A6C File Offset: 0x00B16C6C
		private void UpdateUserId()
		{
			string str = "";
			if (this.LogUploadParams.Net.IsServerConnected())
			{
				int? num;
				str = (((this.LogUploadParams.PlayerInfoModel.GetId() != null) ? num.GetValueOrDefault().ToString() : null) ?? "");
			}
			else
			{
				int? num2 = this.LogUploadParams.LocalStorage.GetRecentlyLoginUid();
				if (num2 != null)
				{
					str = num2.ToString();
				}
			}
			string str2 = "0";
			if (this.LogUploadParams.KuroSdkController.CanUseSdk())
			{
				ILoginModel loginModel = this.LogUploadParams.LoginModel;
				str2 = (((loginModel != null) ? loginModel.GetSdkLoginConfigUid() : null) ?? "0");
			}
			this.UserId = str2 + "-" + str;
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "获取日志上传UID";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("UID", this.UserId);
			instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}

		// Token: 0x0401AA82 RID: 109186
		private bool EnableAutoSend;

		// Token: 0x0401AA83 RID: 109187
		private const int AdmissibleSize = 5;

		// Token: 0x0401AA84 RID: 109188
		[Nullable(2)]
		private ILogUploadParams LogUploadParams;

		// Token: 0x0401AA85 RID: 109189
		private string StartTime = "";

		// Token: 0x0401AA86 RID: 109190
		private const int MaxUploadBackUpLogNum = 20;

		// Token: 0x0401AA87 RID: 109191
		private string UserId = "";

		// Token: 0x0401AA88 RID: 109192
		private const string SendedLogPath = "Logs/Sendedlogs.json";

		// Token: 0x0401AA89 RID: 109193
		[Nullable(2)]
		private ILocalSendedSave SendedLogs;
	}
}
