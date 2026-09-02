using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x02005375 RID: 21365
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PlotMontageConfig : ConfigBase<PlotMontageConfig>
	{
		// Token: 0x060367B0 RID: 223152 RVA: 0x00DBFE2C File Offset: 0x00DBE02C
		public MontageData? GetPlotMontageConfig(int id)
		{
			MontageData? config = ConfigMontageDataById.GetConfig(id, false);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "找不到剧情蒙太奇配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Montage ID", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x060367B1 RID: 223153 RVA: 0x00DBFE84 File Offset: 0x00DBE084
		public AbpMontageData? GetPlotAbpMontageConfig(int id)
		{
			AbpMontageData? config = ConfigAbpMontageDataById.GetConfig(id, false);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.ZWY;
				string message = "找不到剧情ABP蒙太奇配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Montage ID", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x060367B2 RID: 223154 RVA: 0x00DBFEDC File Offset: 0x00DBE0DC
		public OverlayAbpMontageData? GetOverlayAbpMontageConfig(int id)
		{
			OverlayAbpMontageData? config = ConfigOverlayAbpMontageDataById.GetConfig(id, false);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.CWZ;
				string message = "找不到剧情叠加ABP蒙太奇配置";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Montage ID", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}

		// Token: 0x060367B3 RID: 223155 RVA: 0x00DBFF34 File Offset: 0x00DBE134
		public AbpState? GetAbpStateConfig(string path)
		{
			AbpState? config = ConfigAbpStateByAbp.GetConfig(path, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Plot;
				ELogAuthor author = ELogAuthor.YJX;
				string message = "多状态ABP找不到状态定义";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ABP Path", path);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}
	}
}
