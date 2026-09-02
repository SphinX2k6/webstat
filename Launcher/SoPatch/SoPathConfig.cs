using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace CSharpScript.Launcher.SoPatch
{
	// Token: 0x02004534 RID: 17716
	[NullableContext(1)]
	[Nullable(0)]
	public class SoPathConfig
	{
		// Token: 0x0602EA5B RID: 191067 RVA: 0x00B0CD74 File Offset: 0x00B0AF74
		private SoPathConfig(SoVersion soVer)
		{
			this.SoVer = soVer;
		}

		// Token: 0x17008054 RID: 32852
		// (get) Token: 0x0602EA5C RID: 191068 RVA: 0x00B0CD83 File Offset: 0x00B0AF83
		public int CurVerNum
		{
			get
			{
				return this.SoVer.CurVer;
			}
		}

		// Token: 0x17008055 RID: 32853
		// (get) Token: 0x0602EA5D RID: 191069 RVA: 0x00B0CD90 File Offset: 0x00B0AF90
		public bool IsValid
		{
			get
			{
				return this.SoVer.CurVer >= 0;
			}
		}

		// Token: 0x17008056 RID: 32854
		// (get) Token: 0x0602EA5E RID: 191070 RVA: 0x00B0CDA3 File Offset: 0x00B0AFA3
		public int UpdateTime
		{
			get
			{
				return this.SoVer.UpdateTime;
			}
		}

		// Token: 0x0602EA5F RID: 191071 RVA: 0x00B0CDB0 File Offset: 0x00B0AFB0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public ValueTuple<int, string, Dictionary<int, SoEnableInfo>> GetLatestAvailableVer(long deviceValue, string osVer, string manufacturer, string model)
		{
			Dictionary<int, SoEnableInfo> dictionary = new Dictionary<int, SoEnableInfo>(this.SoVer.CurVer);
			for (int i = this.SoVer.CurVer; i > 0; i--)
			{
				VersionInfo versionInfo;
				if (this.SoVer.Versions.TryGetValue(i, out versionInfo) && versionInfo.PatchInfo != null)
				{
					SoEnableInfo soEnableInfo = new SoEnableInfo();
					soEnableInfo.IsPublished = versionInfo.IsPublished;
					dictionary.Add(i, soEnableInfo);
					if (versionInfo.IsPublished)
					{
						bool flag = true;
						if (versionInfo.Filters != null && versionInfo.Filters.Count > 0)
						{
							for (int j = 0; j < versionInfo.Filters.Count; j++)
							{
								MobileFilter mobileFilter = versionInfo.Filters[j];
								if ((!string.IsNullOrEmpty(mobileFilter.OSVersion) && mobileFilter.OSVersion.Length > 0) || (!string.IsNullOrEmpty(mobileFilter.Manufacturer) && mobileFilter.Manufacturer.Length > 0) || (!string.IsNullOrEmpty(mobileFilter.Model) && mobileFilter.Model.Length > 0))
								{
									CheckConditions checkConditions = new CheckConditions();
									int num = 0;
									SoPatchDefine.CheckCondition(mobileFilter.OSVersion, osVer, checkConditions, num++);
									SoPatchDefine.CheckCondition(mobileFilter.Manufacturer, manufacturer, checkConditions, num++);
									SoPatchDefine.CheckCondition(mobileFilter.Model, model, checkConditions, num++);
									if (checkConditions.Meet())
									{
										flag = false;
										break;
									}
								}
							}
							soEnableInfo.IsFilterMeet = new bool?(!flag);
							if (!flag)
							{
								goto IL_21F;
							}
						}
						if (versionInfo.Gray != null)
						{
							int num2 = (int)(deviceValue % (long)versionInfo.Gray.Divisor);
							flag = (num2 >= versionInfo.Gray.Down && num2 <= versionInfo.Gray.Up);
							soEnableInfo.Gray = new float?((float)(versionInfo.Gray.Up - versionInfo.Gray.Down + 1) * 1f / (float)versionInfo.Gray.Divisor);
							soEnableInfo.IsGrayHit = new bool?(flag);
							if (!flag)
							{
								goto IL_21F;
							}
						}
						return new ValueTuple<int, string, Dictionary<int, SoEnableInfo>>(i, versionInfo.PatchInfo.Md5, dictionary);
					}
				}
				IL_21F:;
			}
			return new ValueTuple<int, string, Dictionary<int, SoEnableInfo>>(-1, "", dictionary);
		}

		// Token: 0x0602EA60 RID: 191072 RVA: 0x00B0CFF4 File Offset: 0x00B0B1F4
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public ValueTuple<int, string> FindVerNum(string verStr, long deviceValue, string osVer, string manufacturer, string model)
		{
			if (verStr == null || verStr.Length <= 0)
			{
				return new ValueTuple<int, string>(-1, "");
			}
			foreach (KeyValuePair<int, VersionInfo> keyValuePair in this.SoVer.Versions)
			{
				int key = keyValuePair.Key;
				VersionInfo value = keyValuePair.Value;
				if (value != null && value.PatchInfo != null && !(value.PatchInfo.Md5 != verStr))
				{
					if (!value.IsPublished)
					{
						return new ValueTuple<int, string>(-1, "");
					}
					bool flag = true;
					if (value.Filters != null && value.Filters.Count > 0)
					{
						for (int i = 0; i < value.Filters.Count; i++)
						{
							MobileFilter mobileFilter = value.Filters[i];
							if ((!string.IsNullOrEmpty(mobileFilter.OSVersion) && mobileFilter.OSVersion.Length > 0) || (!string.IsNullOrEmpty(mobileFilter.Manufacturer) && mobileFilter.Manufacturer.Length > 0) || (!string.IsNullOrEmpty(mobileFilter.Model) && mobileFilter.Model.Length > 0))
							{
								CheckConditions checkConditions = new CheckConditions();
								int num = 0;
								SoPatchDefine.CheckCondition(mobileFilter.OSVersion, osVer, checkConditions, num++);
								SoPatchDefine.CheckCondition(mobileFilter.Manufacturer, manufacturer, checkConditions, num++);
								SoPatchDefine.CheckCondition(mobileFilter.Model, model, checkConditions, num++);
								if (checkConditions.Meet())
								{
									flag = false;
									break;
								}
							}
						}
						if (!flag)
						{
							return new ValueTuple<int, string>(-1, "");
						}
					}
					if (value.Gray != null)
					{
						int num2 = (int)(deviceValue % (long)value.Gray.Divisor);
						if (num2 < value.Gray.Down || num2 > value.Gray.Up)
						{
							return new ValueTuple<int, string>(-1, "");
						}
					}
					return new ValueTuple<int, string>(key, value.PatchInfo.DestHash);
				}
			}
			return new ValueTuple<int, string>(-1, "");
		}

		// Token: 0x0602EA61 RID: 191073 RVA: 0x00B0D24C File Offset: 0x00B0B44C
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public ValueTuple<int, string, string> GetFileInfo(int ver)
		{
			if (ver <= 0)
			{
				return new ValueTuple<int, string, string>(-1, "", "");
			}
			VersionInfo versionInfo;
			if (!this.SoVer.Versions.TryGetValue(ver, out versionInfo) || versionInfo.PatchInfo == null)
			{
				return new ValueTuple<int, string, string>(-1, "", "");
			}
			return new ValueTuple<int, string, string>(versionInfo.PatchInfo.Size, versionInfo.PatchInfo.Name, versionInfo.PatchInfo.Hash);
		}

		// Token: 0x0602EA62 RID: 191074 RVA: 0x00B0D2C4 File Offset: 0x00B0B4C4
		public static SoPathConfig Parse(string appParallel, string jsonStr)
		{
			SoVersion soVersion = new SoVersion();
			if (appParallel == null || appParallel.Trim().Length <= 0)
			{
				return new SoPathConfig(soVersion);
			}
			SoPathConfig result;
			using (JsonDocument jsonDocument = JsonDocument.Parse(jsonStr, default(JsonDocumentOptions)))
			{
				JsonElement rootElement = jsonDocument.RootElement;
				int updateTime = -1;
				JsonElement jsonElement;
				int num;
				if (rootElement.TryGetProperty("UpdateTime", out jsonElement) && jsonElement.ValueKind == JsonValueKind.Number && jsonElement.TryGetInt32(out num))
				{
					updateTime = num;
				}
				soVersion.UpdateTime = updateTime;
				JsonElement jsonElement2;
				JsonElement jsonElement3;
				if (!rootElement.TryGetProperty("Infos", out jsonElement2) || !jsonElement2.TryGetProperty(appParallel, out jsonElement3))
				{
					result = new SoPathConfig(soVersion);
				}
				else
				{
					int curVer = -1;
					JsonElement jsonElement4;
					int num2;
					if (jsonElement3.TryGetProperty("CurVer", out jsonElement4) && jsonElement4.ValueKind == JsonValueKind.Number && jsonElement4.TryGetInt32(out num2))
					{
						curVer = num2;
					}
					soVersion.CurVer = curVer;
					JsonElement jsonElement5;
					if (jsonElement3.TryGetProperty("Versions", out jsonElement5) && jsonElement5.ValueKind == JsonValueKind.Object)
					{
						foreach (JsonProperty jsonProperty in jsonElement5.EnumerateObject())
						{
							string name = jsonProperty.Name;
							JsonElement value = jsonProperty.Value;
							VersionInfo versionInfo = new VersionInfo();
							JsonElement jsonElement6;
							int verNum;
							if (value.TryGetProperty("VerNum", out jsonElement6) && jsonElement6.ValueKind == JsonValueKind.Number && jsonElement6.TryGetInt32(out verNum))
							{
								versionInfo.VerNum = verNum;
							}
							else
							{
								versionInfo.VerNum = -1;
							}
							JsonElement jsonElement7;
							if (value.TryGetProperty("IsPublished", out jsonElement7))
							{
								versionInfo.IsPublished = (jsonElement7.ValueKind == JsonValueKind.True);
							}
							JsonElement jsonElement8;
							if (value.TryGetProperty("Filters", out jsonElement8) && jsonElement8.ValueKind == JsonValueKind.Array)
							{
								foreach (JsonElement jsonElement9 in jsonElement8.EnumerateArray())
								{
									MobileFilter mobileFilter = new MobileFilter();
									JsonElement jsonElement10;
									mobileFilter.OSVersion = ((jsonElement9.TryGetProperty("OSVersion", out jsonElement10) && jsonElement10.ValueKind == JsonValueKind.String) ? (jsonElement10.GetString() ?? "") : "");
									JsonElement jsonElement11;
									mobileFilter.Manufacturer = ((jsonElement9.TryGetProperty("Manufacturer", out jsonElement11) && jsonElement11.ValueKind == JsonValueKind.String) ? (jsonElement11.GetString() ?? "") : "");
									JsonElement jsonElement12;
									mobileFilter.Model = ((jsonElement9.TryGetProperty("Model", out jsonElement12) && jsonElement12.ValueKind == JsonValueKind.String) ? (jsonElement12.GetString() ?? "") : "");
									versionInfo.Filters.Add(mobileFilter);
								}
							}
							JsonElement jsonElement13;
							if (value.TryGetProperty("Gray", out jsonElement13) && jsonElement13.ValueKind == JsonValueKind.Object)
							{
								JsonElement jsonElement14;
								int num3;
								JsonElement jsonElement15;
								int num4;
								JsonElement jsonElement16;
								int num5;
								versionInfo.Gray = new GrayInfo
								{
									Divisor = ((jsonElement13.TryGetProperty("Divisor", out jsonElement14) && jsonElement14.ValueKind == JsonValueKind.Number && jsonElement14.TryGetInt32(out num3)) ? num3 : 1),
									Down = ((jsonElement13.TryGetProperty("Down", out jsonElement15) && jsonElement15.ValueKind == JsonValueKind.Number && jsonElement15.TryGetInt32(out num4)) ? num4 : 0),
									Up = ((jsonElement13.TryGetProperty("Up", out jsonElement16) && jsonElement16.ValueKind == JsonValueKind.Number && jsonElement16.TryGetInt32(out num5)) ? num5 : 0)
								};
							}
							JsonElement jsonElement17;
							if (value.TryGetProperty("PatchInfo", out jsonElement17) && jsonElement17.ValueKind == JsonValueKind.Object)
							{
								JsonElement jsonElement18;
								JsonElement jsonElement19;
								int num6;
								JsonElement jsonElement20;
								JsonElement jsonElement21;
								JsonElement jsonElement22;
								versionInfo.PatchInfo = new SoPatchFileInfo
								{
									Name = ((jsonElement17.TryGetProperty("Name", out jsonElement18) && jsonElement18.ValueKind == JsonValueKind.String) ? (jsonElement18.GetString() ?? "") : ""),
									Size = ((jsonElement17.TryGetProperty("Size", out jsonElement19) && jsonElement19.ValueKind == JsonValueKind.Number && jsonElement19.TryGetInt32(out num6)) ? num6 : 0),
									Hash = ((jsonElement17.TryGetProperty("Hash", out jsonElement20) && jsonElement20.ValueKind == JsonValueKind.String) ? (jsonElement20.GetString() ?? "") : ""),
									Md5 = ((jsonElement17.TryGetProperty("Md5", out jsonElement21) && jsonElement21.ValueKind == JsonValueKind.String) ? (jsonElement21.GetString() ?? "") : ""),
									DestHash = ((jsonElement17.TryGetProperty("DestHash", out jsonElement22) && jsonElement22.ValueKind == JsonValueKind.String) ? (jsonElement22.GetString() ?? "") : "")
								};
							}
							int key = int.Parse(name);
							soVersion.Versions[key] = versionInfo;
						}
					}
					result = new SoPathConfig(soVersion);
				}
			}
			return result;
		}

		// Token: 0x0401A7DC RID: 108508
		private readonly SoVersion SoVer;
	}
}
