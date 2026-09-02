using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Define;
using CSharpScript.Launcher.NetworkDetection;
using CSharpScript.Launcher.Platform.PlatformSdk;

namespace CSharpScript.Launcher.Ui.HotFix.NetWorkDetection
{
	// Token: 0x02004524 RID: 17700
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class HotFixNetworkDetectionModel : Singleton<HotFixNetworkDetectionModel>
	{
		// Token: 0x0602E9FE RID: 190974 RVA: 0x00B0B514 File Offset: 0x00B09714
		public List<ILoginServersData> GetLoginServersByClientRegion()
		{
			if (this.LoginServerData != null)
			{
				return this.LoginServerData;
			}
			List<ILoginServersData> loginServers = Singleton<BaseConfigController>.Instance.GetLoginServers();
			if (Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().BlockServerArea())
			{
				List<ILoginServersData> list = new List<ILoginServersData>();
				string sdkCountry = Singleton<PlatformSdkManagerNew>.Instance.GetPlatformSdk().GetSdkCountry();
				LauncherLog instance = Singleton<LauncherLog>.Instance;
				string message = "锁区";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("currentCountryCode", sdkCountry);
				instance.Info(message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				for (int i = 0; i < loginServers.Count; i++)
				{
					ILoginServersData loginServersData = loginServers[i];
					if (loginServersData.Region != null && loginServersData.Region.Length != 0)
					{
						LauncherServerLimitConfig serverLimitConfig = Singleton<LauncherConfigLib>.Instance.GetServerLimitConfig(loginServersData.Region);
						if (serverLimitConfig != null && sdkCountry != null && sdkCountry.Length > 0)
						{
							string[] array = (serverLimitConfig.CountryCodes ?? "").Split(',', StringSplitOptions.None);
							bool flag = false;
							for (int j = 0; j < array.Length; j++)
							{
								if (array[j].Trim() == sdkCountry)
								{
									flag = true;
									break;
								}
							}
							if (flag)
							{
								list.Add(loginServersData);
							}
						}
					}
				}
				if (list.Count == 0)
				{
					for (int k = 0; k < loginServers.Count; k++)
					{
						ILoginServersData loginServersData2 = loginServers[k];
						if (loginServersData2.Region == "SEA")
						{
							list.Add(loginServersData2);
							break;
						}
					}
				}
				this.LoginServerData = list;
				return this.LoginServerData;
			}
			List<ILoginServersData> list2 = new List<ILoginServersData>();
			for (int l = 0; l < loginServers.Count; l++)
			{
				list2.Add(loginServers[l]);
			}
			this.LoginServerData = list2;
			return this.LoginServerData;
		}

		// Token: 0x0602E9FF RID: 190975 RVA: 0x00B0B6CC File Offset: 0x00B098CC
		public List<IHotFixNetworkDetectSelectData> GetLoginServersLayoutItemData()
		{
			List<ILoginServersData> loginServersByClientRegion = this.GetLoginServersByClientRegion();
			List<IHotFixNetworkDetectSelectData> list = new List<IHotFixNetworkDetectSelectData>();
			for (int i = 0; i < loginServersByClientRegion.Count; i++)
			{
				ILoginServersData loginServersData = loginServersByClientRegion[i];
				HotFixNetworkDetectSelectData item = new HotFixNetworkDetectSelectData
				{
					LoginServersData = loginServersData
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0602EA00 RID: 190976 RVA: 0x00B0B718 File Offset: 0x00B09918
		public List<IHotFixNetworkDetectionLayoutItemData> GetNetworkDetectionLayoutItemData()
		{
			List<IHotFixNetworkDetectionLayoutItemData> list = new List<IHotFixNetworkDetectionLayoutItemData>();
			List<INetworkDetectionEntry> detectionDataList = LauncherNetworkDetectionModel.GetDetectionDataList();
			for (int i = 0; i < detectionDataList.Count; i++)
			{
				INetworkDetectionEntry entryData = detectionDataList[i];
				HotFixNetworkDetectionLayoutItemData item = new HotFixNetworkDetectionLayoutItemData
				{
					EntryData = entryData,
					Proceed = false
				};
				list.Add(item);
			}
			return list;
		}

		// Token: 0x0602EA01 RID: 190977 RVA: 0x00B0B768 File Offset: 0x00B09968
		public bool NeedInterruptDetectionDoubleCheckTips()
		{
			return (double)((float)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 0.001f) - this.LastDoubleCheckTime >= 5.0;
		}

		// Token: 0x0602EA02 RID: 190978 RVA: 0x00B0B7A0 File Offset: 0x00B099A0
		public void ConfirmInterruptDetection()
		{
			float num = (float)DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() * 0.001f;
			this.LastDoubleCheckTime = (double)num;
		}

		// Token: 0x0602EA03 RID: 190979 RVA: 0x00B0B7CA File Offset: 0x00B099CA
		public void ResetInterruptDetectionCheckTime()
		{
			this.LastDoubleCheckTime = 0.0;
		}

		// Token: 0x0602EA04 RID: 190980 RVA: 0x00B0B7DC File Offset: 0x00B099DC
		public string GetFinalErrorCodeString(IReadOnlyList<IHotFixNetworkDetectionLayoutItemData> datas)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < datas.Count; i++)
			{
				IHotFixNetworkDetectionLayoutItemData hotFixNetworkDetectionLayoutItemData = datas[i];
				if (hotFixNetworkDetectionLayoutItemData.ErrorCodeText != null && hotFixNetworkDetectionLayoutItemData.ErrorCodeText != "")
				{
					list.Add(hotFixNetworkDetectionLayoutItemData.ErrorCodeText);
				}
			}
			return string.Join("\n", list);
		}

		// Token: 0x0401A7A4 RID: 108452
		private const string SEASERVER = "SEA";

		// Token: 0x0401A7A5 RID: 108453
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<ILoginServersData> LoginServerData;

		// Token: 0x0401A7A6 RID: 108454
		[Nullable(2)]
		public ILoginServersData CurrentUiSelectSeverData;

		// Token: 0x0401A7A7 RID: 108455
		[Nullable(2)]
		public ILoginServersData CurrentSelectServerData;

		// Token: 0x0401A7A8 RID: 108456
		private double LastDoubleCheckTime;
	}
}
