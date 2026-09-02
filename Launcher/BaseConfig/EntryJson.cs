using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004679 RID: 18041
	[NullableContext(2)]
	[Nullable(0)]
	public class EntryJson
	{
		// Token: 0x0602F061 RID: 192609 RVA: 0x00B24654 File Offset: 0x00B22854
		public EntryJson()
		{
		}

		// Token: 0x0602F062 RID: 192610 RVA: 0x00B2465C File Offset: 0x00B2285C
		[NullableContext(1)]
		public EntryJson(EntryJson defaultObject, [Nullable(2)] EntryJson overrideObj)
		{
			this.CdnUrl = ((overrideObj != null && overrideObj.CdnUrl != null) ? overrideObj.CdnUrl : ((defaultObject != null) ? defaultObject.CdnUrl : null));
			this.SpeedRatio = ((overrideObj != null && overrideObj.SpeedRatio != null) ? overrideObj.SpeedRatio : new float?(((defaultObject != null) ? defaultObject.SpeedRatio : null).GetValueOrDefault()));
			this.PriceRatio = ((overrideObj != null && overrideObj.PriceRatio != null) ? overrideObj.PriceRatio : new float?(((defaultObject != null) ? defaultObject.PriceRatio : null).GetValueOrDefault()));
			this.NoticeUrl = ((overrideObj != null && overrideObj.NoticeUrl != null) ? overrideObj.NoticeUrl : ((defaultObject != null) ? defaultObject.NoticeUrl : null));
			this.LoginServers = ((overrideObj != null && overrideObj.LoginServers != null) ? overrideObj.LoginServers : ((defaultObject != null) ? defaultObject.LoginServers : null));
			this.PrivateServers = ((overrideObj != null && overrideObj.PrivateServers != null) ? overrideObj.PrivateServers : ((defaultObject != null) ? defaultObject.PrivateServers : null));
			this.GmOpen = ((overrideObj != null && overrideObj.GmOpen != null) ? overrideObj.GmOpen : new bool?(((defaultObject != null) ? defaultObject.GmOpen : null).GetValueOrDefault()));
			this.RptOpen = ((overrideObj != null && overrideObj.RptOpen != null) ? overrideObj.RptOpen : new bool?(((defaultObject != null) ? defaultObject.RptOpen : null).GetValueOrDefault(true)));
			this.AsyncCheck = ((overrideObj != null && overrideObj.AsyncCheck != null) ? overrideObj.AsyncCheck : new bool?(((defaultObject != null) ? defaultObject.AsyncCheck : null).GetValueOrDefault()));
			this.NewHttpTimer = ((overrideObj != null && overrideObj.NewHttpTimer != null) ? overrideObj.NewHttpTimer : new bool?(((defaultObject != null) ? defaultObject.NewHttpTimer : null).GetValueOrDefault(true)));
			this.NewHttpApi = ((overrideObj != null && overrideObj.NewHttpApi != null) ? overrideObj.NewHttpApi : new bool?(((defaultObject != null) ? defaultObject.NewHttpApi : null).GetValueOrDefault(true)));
			this.GARUrl = ((overrideObj != null && overrideObj.GARUrl != null) ? overrideObj.GARUrl : (((defaultObject != null) ? defaultObject.GARUrl : null) ?? ""));
			this.TDCfg = ((overrideObj != null && overrideObj.TDCfg != null) ? overrideObj.TDCfg : ((defaultObject != null) ? defaultObject.TDCfg : null));
			this.KDCfg = ((overrideObj != null && overrideObj.KDCfg != null) ? overrideObj.KDCfg : ((defaultObject != null) ? defaultObject.KDCfg : null));
			this.ServerTimeUrl = ((overrideObj != null && overrideObj.ServerTimeUrl != null) ? overrideObj.ServerTimeUrl : (((defaultObject != null) ? defaultObject.ServerTimeUrl : null) ?? Array.Empty<string>()));
			this.LogReport = ((overrideObj != null && overrideObj.LogReport != null) ? overrideObj.LogReport : ((defaultObject != null) ? defaultObject.LogReport : null));
			this.IosAuditFirstDownloadTip = ((overrideObj != null && overrideObj.IosAuditFirstDownloadTip != null) ? overrideObj.IosAuditFirstDownloadTip : new bool?(((defaultObject != null) ? defaultObject.IosAuditFirstDownloadTip : null).GetValueOrDefault()));
			this.MixUri = ((overrideObj != null && overrideObj.MixUri != null) ? overrideObj.MixUri : (((defaultObject != null) ? defaultObject.MixUri : null) ?? ""));
			this.ResUri = ((overrideObj != null && overrideObj.ResUri != null) ? overrideObj.ResUri : (((defaultObject != null) ? defaultObject.ResUri : null) ?? ""));
			this.GachaUrl = ((overrideObj != null && overrideObj.GachaUrl != null) ? overrideObj.GachaUrl : ((defaultObject != null) ? defaultObject.GachaUrl : null));
			this.PackageUpdateUrl = ((overrideObj != null && overrideObj.PackageUpdateUrl != null) ? overrideObj.PackageUpdateUrl : ((defaultObject != null) ? defaultObject.PackageUpdateUrl : null));
			this.PackageUpdateDescUrl = ((overrideObj != null && overrideObj.PackageUpdateDescUrl != null) ? overrideObj.PackageUpdateDescUrl : ((defaultObject != null) ? defaultObject.PackageUpdateDescUrl : null));
			this.ParallelPackageDescUrl = ((overrideObj != null && overrideObj.ParallelPackageDescUrl != null) ? overrideObj.ParallelPackageDescUrl : ((defaultObject != null) ? defaultObject.ParallelPackageDescUrl : null));
			this.GrayBox = ((overrideObj != null && overrideObj.GrayBox != null) ? overrideObj.GrayBox : ((defaultObject != null) ? defaultObject.GrayBox : null));
			this.SDKEnvironment = ((overrideObj != null && overrideObj.SDKEnvironment != null) ? overrideObj.SDKEnvironment : ((defaultObject != null) ? defaultObject.SDKEnvironment : null));
			this.UdpDelay = ((overrideObj != null && overrideObj.UdpDelay != null) ? overrideObj.UdpDelay : ((defaultObject != null) ? defaultObject.UdpDelay : null));
			this.CdnEvalCfg = ((overrideObj != null && overrideObj.CdnEvalCfg != null) ? overrideObj.CdnEvalCfg : ((defaultObject != null) ? defaultObject.CdnEvalCfg : null));
		}

		// Token: 0x0401AC7D RID: 109693
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ICdnUrlData> CdnUrl;

		// Token: 0x0401AC7E RID: 109694
		public float? SpeedRatio;

		// Token: 0x0401AC7F RID: 109695
		public float? PriceRatio;

		// Token: 0x0401AC80 RID: 109696
		public string NoticeUrl;

		// Token: 0x0401AC81 RID: 109697
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public List<ILoginServersData> LoginServers;

		// Token: 0x0401AC82 RID: 109698
		public IPrivateServersData PrivateServers;

		// Token: 0x0401AC83 RID: 109699
		public bool? GmOpen;

		// Token: 0x0401AC84 RID: 109700
		public bool? RptOpen;

		// Token: 0x0401AC85 RID: 109701
		public bool? AsyncCheck;

		// Token: 0x0401AC86 RID: 109702
		public bool? NewHttpTimer;

		// Token: 0x0401AC87 RID: 109703
		public bool? NewHttpApi;

		// Token: 0x0401AC88 RID: 109704
		public string GARUrl;

		// Token: 0x0401AC89 RID: 109705
		public ITDConfig TDCfg;

		// Token: 0x0401AC8A RID: 109706
		public ITDConfig KDCfg;

		// Token: 0x0401AC8B RID: 109707
		[Nullable(1)]
		public string[] ServerTimeUrl;

		// Token: 0x0401AC8C RID: 109708
		public ILogReport LogReport;

		// Token: 0x0401AC8D RID: 109709
		public IUpdateUrl PackageUpdateUrl;

		// Token: 0x0401AC8E RID: 109710
		public IUpdateUrl PackageUpdateDescUrl;

		// Token: 0x0401AC8F RID: 109711
		public IUpdateUrl ParallelPackageDescUrl;

		// Token: 0x0401AC90 RID: 109712
		public bool? IosAuditFirstDownloadTip;

		// Token: 0x0401AC91 RID: 109713
		public string MixUri;

		// Token: 0x0401AC92 RID: 109714
		public string ResUri;

		// Token: 0x0401AC93 RID: 109715
		public IGachaUrl GachaUrl;

		// Token: 0x0401AC94 RID: 109716
		public IGrayBoxConfig GrayBox;

		// Token: 0x0401AC95 RID: 109717
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, IUdpRegion> UdpDelay;

		// Token: 0x0401AC96 RID: 109718
		public IEvalConfig CdnEvalCfg;

		// Token: 0x0401AC97 RID: 109719
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		public Dictionary<string, string> SDKEnvironment;
	}
}
