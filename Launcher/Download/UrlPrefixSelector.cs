using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.BaseConfig;
using CSharpScript.Launcher.Util;
using UnrealEngine;

namespace CSharpScript.Launcher.Download
{
	// Token: 0x0200461C RID: 17948
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UrlPrefixSelector : Singleton<UrlPrefixSelector>
	{
		// Token: 0x0602EE81 RID: 192129 RVA: 0x00B1BDA0 File Offset: 0x00B19FA0
		public void Init()
		{
			if (this.PrimaryUrlList != null)
			{
				return;
			}
			this.InitInternal(this.ManagePrimary(), (Singleton<BaseConfigController>.Instance.GetSpeedRatio() != null) ? Singleton<BaseConfigController>.Instance.GetSpeedRatio().Value : 0.8f, (Singleton<BaseConfigController>.Instance.GetPriceRatio() != null) ? Singleton<BaseConfigController>.Instance.GetPriceRatio().Value : 0.2f);
		}

		// Token: 0x0602EE82 RID: 192130 RVA: 0x00B1BE1C File Offset: 0x00B1A01C
		private Dictionary<string, int> ManagePrimary()
		{
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			List<ICdnUrlData> cdnUrl = Singleton<BaseConfigController>.Instance.GetCdnUrl();
			if (cdnUrl != null)
			{
				for (int i = 0; i < cdnUrl.Count; i++)
				{
					ICdnUrlData cdnUrlData = cdnUrl[i];
					string url = cdnUrlData.url;
					string weight = cdnUrlData.weight;
					dictionary[url] = int.Parse(weight);
				}
			}
			return dictionary;
		}

		// Token: 0x0602EE83 RID: 192131 RVA: 0x00B1BE74 File Offset: 0x00B1A074
		public unsafe void SetUrl(string primaryUrl, float speedRatio, float priceRatio)
		{
			LauncherLog instance = Singleton<LauncherLog>.Instance;
			string message = "设置远程前缀参数";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("primary", primaryUrl);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("speedRatio", speedRatio);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("priceRatio", priceRatio);
			instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			HotPatchLog hotPatchLog = new HotPatchLog();
			hotPatchLog.s_step_id = "set_remote_prefix";
			HotPatchLog hotPatchLog2 = hotPatchLog;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(2, 3);
			defaultInterpolatedStringHandler.AppendFormatted(primaryUrl);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<float>(speedRatio);
			defaultInterpolatedStringHandler.AppendLiteral("|");
			defaultInterpolatedStringHandler.AppendFormatted<float>(priceRatio);
			hotPatchLog2.s_step_result = defaultInterpolatedStringHandler.ToStringAndClear();
			Singleton<HotPatchLogReport>.Instance.Report(hotPatchLog);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			if (!string.IsNullOrEmpty(primaryUrl))
			{
				string text = primaryUrl.Trim();
				if (text != "")
				{
					string[] array = text.Split(';', StringSplitOptions.None);
					for (int i = 0; i < array.Length; i++)
					{
						string[] array2 = array[i].Split(',', StringSplitOptions.None);
						if (array2.Length >= 2)
						{
							dictionary[array2[0].Trim()] = int.Parse(array2[1].Trim());
						}
					}
				}
			}
			this.InitInternal(dictionary, speedRatio, priceRatio);
		}

		// Token: 0x0602EE84 RID: 192132 RVA: 0x00B1BFD4 File Offset: 0x00B1A1D4
		private void InitInternal(Dictionary<string, int> primaryUrlMap, float speedRatio, float priceRatio)
		{
			if (primaryUrlMap.Count > 0)
			{
				List<UrlPrefixInfo> list = new List<UrlPrefixInfo>();
				int num = 0;
				float evalTime = this.GetEvalTime();
				foreach (KeyValuePair<string, int> keyValuePair in primaryUrlMap)
				{
					string key = keyValuePair.Key;
					int value = keyValuePair.Value;
					list.Add(new UrlPrefixInfo
					{
						Address = key,
						Price = value,
						OriginOrder = num++,
						EvalPoint = 0,
						IsEvaluated = false,
						RemainDownloadTime = evalTime,
						DownloadedSize = 0L,
						Speed = 0
					});
				}
				this.ShuffleOrSortByOrigin(list);
				this.PrimaryUrlList = list;
			}
			if (primaryUrlMap.Count == 0)
			{
				this.PrimaryUrlList = new List<UrlPrefixInfo>();
			}
			this.SpeedRatio = ((speedRatio != 0f) ? speedRatio : 0.8f);
			this.PriceRatio = ((priceRatio != 0f) ? priceRatio : 0.2f);
		}

		// Token: 0x0602EE85 RID: 192133 RVA: 0x00B1C0EC File Offset: 0x00B1A2EC
		public void Reset()
		{
			if (this.PrimaryUrlList == null)
			{
				return;
			}
			float evalTime = this.GetEvalTime();
			for (int i = 0; i < this.PrimaryUrlList.Count; i++)
			{
				UrlPrefixInfo urlPrefixInfo = this.PrimaryUrlList[i];
				urlPrefixInfo.DownloadedSize = 0L;
				urlPrefixInfo.Speed = 0;
				urlPrefixInfo.RemainDownloadTime = evalTime;
				urlPrefixInfo.EvalPoint = 0;
				urlPrefixInfo.IsEvaluated = false;
			}
			if (this.PrimaryUrlList.Count > 1)
			{
				this.ShuffleOrSortByOrigin(this.PrimaryUrlList);
			}
		}

		// Token: 0x0602EE86 RID: 192134 RVA: 0x00B1C168 File Offset: 0x00B1A368
		public unsafe void Evaluated()
		{
			if (this.PrimaryUrlList == null)
			{
				return;
			}
			if (this.PrimaryUrlList.Count > 1)
			{
				this.PrimaryUrlList.Sort((UrlPrefixInfo a, UrlPrefixInfo b) => b.EvalPoint - a.EvalPoint);
			}
			if (this.PrimaryUrlList != null && this.PrimaryUrlList.Count > 0)
			{
				for (int i = 0; i < this.PrimaryUrlList.Count; i++)
				{
					UrlPrefixInfo urlPrefixInfo = this.PrimaryUrlList[i];
					LauncherLog instance = Singleton<LauncherLog>.Instance;
					string message = "整体完成评估";
					<>y__InlineArray4<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray4<ValueTuple<string, object>>);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("prefix", urlPrefixInfo.Address);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("size", urlPrefixInfo.DownloadedSize);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("price", urlPrefixInfo.Price);
					*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 3) = new ValueTuple<string, object>("point", urlPrefixInfo.EvalPoint);
					instance.Info(message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray4<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 4));
				}
			}
		}

		// Token: 0x0602EE87 RID: 192135 RVA: 0x00B1C29D File Offset: 0x00B1A49D
		public List<UrlPrefixInfo> GetPrimaryPrefixList()
		{
			if (this.PrimaryUrlList == null)
			{
				return new List<UrlPrefixInfo>();
			}
			this.ShuffleOrSortByOrigin(this.PrimaryUrlList);
			return this.PrimaryUrlList;
		}

		// Token: 0x0602EE88 RID: 192136 RVA: 0x00B1C2C0 File Offset: 0x00B1A4C0
		public List<string> GetAllPrefixList(bool bSorted = false)
		{
			if (this.PrimaryUrlList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Preload, ELogAuthor.LRX, "未初始化UrlPrefixSelector就调用了GetAllPrefixList", default(ReadOnlySpan<ValueTuple<string, object>>));
				return new List<string>();
			}
			if (bSorted && this.PrimaryUrlList.Count > 1)
			{
				this.PrimaryUrlList.Sort((UrlPrefixInfo a, UrlPrefixInfo b) => b.EvalPoint - a.EvalPoint);
			}
			List<string> list = new List<string>();
			for (int i = 0; i < this.PrimaryUrlList.Count; i++)
			{
				list.Add(this.PrimaryUrlList[i].Address);
			}
			if (!bSorted && this.IsEvalShuffle())
			{
				ProcedureUtil.randomArray<string>(list);
			}
			return list;
		}

		// Token: 0x0602EE89 RID: 192137 RVA: 0x00B1C377 File Offset: 0x00B1A577
		public float CalculateUrlPoint(int price, float downloadSpeed)
		{
			return downloadSpeed * this.SpeedRatio - (float)price * this.PriceRatio;
		}

		// Token: 0x0602EE8A RID: 192138 RVA: 0x00B1C38C File Offset: 0x00B1A58C
		[NullableContext(2)]
		private IEvalNetworkConfig GetEvalNetworkConfig()
		{
			IEvalConfig cdnEvalCfg = Singleton<BaseConfigController>.Instance.GetCdnEvalCfg();
			if (cdnEvalCfg == null)
			{
				return null;
			}
			if (UKuroLauncherLibrary.GetNetworkConnectionType() != 3)
			{
				return cdnEvalCfg.Broadband;
			}
			return cdnEvalCfg.Cellular;
		}

		// Token: 0x0602EE8B RID: 192139 RVA: 0x00B1C3C0 File Offset: 0x00B1A5C0
		public bool IsEvalShuffle()
		{
			IEvalNetworkConfig evalNetworkConfig = this.GetEvalNetworkConfig();
			return ((evalNetworkConfig != null) ? evalNetworkConfig.Shuffle : null).GetValueOrDefault(true);
		}

		// Token: 0x0602EE8C RID: 192140 RVA: 0x00B1C3F0 File Offset: 0x00B1A5F0
		public float GetEvalTime()
		{
			IEvalNetworkConfig evalNetworkConfig = this.GetEvalNetworkConfig();
			float? num = (evalNetworkConfig != null) ? evalNetworkConfig.EvalTime : null;
			if (num == null || num.Value <= 0f)
			{
				return 5f;
			}
			return num.Value;
		}

		// Token: 0x0602EE8D RID: 192141 RVA: 0x00B1C43C File Offset: 0x00B1A63C
		public float GetSkipEvalSizeMb()
		{
			IEvalNetworkConfig evalNetworkConfig = this.GetEvalNetworkConfig();
			float? num = (evalNetworkConfig != null) ? evalNetworkConfig.SkipSize : null;
			if (num == null || num.Value <= 0f)
			{
				return 0f;
			}
			return num.Value;
		}

		// Token: 0x0602EE8E RID: 192142 RVA: 0x00B1C488 File Offset: 0x00B1A688
		private void ShuffleOrSortByOrigin(List<UrlPrefixInfo> list)
		{
			if (this.IsEvalShuffle())
			{
				ProcedureUtil.randomArray<UrlPrefixInfo>(list);
				return;
			}
			if (list.Count > 1)
			{
				list.Sort((UrlPrefixInfo a, UrlPrefixInfo b) => a.OriginOrder - b.OriginOrder);
			}
		}

		// Token: 0x0401AAF9 RID: 109305
		private const float INLINE_SPEED_RATIO = 0.8f;

		// Token: 0x0401AAFA RID: 109306
		private const float INLINE_PRICE_RATIO = 0.2f;

		// Token: 0x0401AAFB RID: 109307
		private const float TEST_TIME = 5f;

		// Token: 0x0401AAFC RID: 109308
		private const long BigIntZero = 0L;

		// Token: 0x0401AAFD RID: 109309
		private const long BigIntKb = 1024L;

		// Token: 0x0401AAFE RID: 109310
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private List<UrlPrefixInfo> PrimaryUrlList;

		// Token: 0x0401AAFF RID: 109311
		private float SpeedRatio;

		// Token: 0x0401AB00 RID: 109312
		private float PriceRatio;
	}
}
