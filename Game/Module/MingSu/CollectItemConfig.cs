using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.MingSu
{
	// Token: 0x0200572D RID: 22317
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class CollectItemConfig : ConfigBase<CollectItemConfig>
	{
		// Token: 0x06038CCB RID: 232651 RVA: 0x00E6390E File Offset: 0x00E61B0E
		public IReadOnlyList<DragonPool> GetAllDragonPoolConfigList()
		{
			return ConfigDragonPoolAll.GetConfigList(true);
		}

		// Token: 0x06038CCC RID: 232652 RVA: 0x00E63916 File Offset: 0x00E61B16
		public DragonPool? GetDragonPoolConfigById(int id)
		{
			return ConfigDragonPoolById.GetConfig(id, true);
		}

		// Token: 0x06038CCD RID: 232653 RVA: 0x00E6391F File Offset: 0x00E61B1F
		public DragonPool? GetDragonPoolConfigByCoreId(int coreId)
		{
			return ConfigDragonPoolByCoreId.GetConfig(coreId, true);
		}

		// Token: 0x06038CCE RID: 232654 RVA: 0x00E63928 File Offset: 0x00E61B28
		public MingSuPlot? GetMingSuPlotConfigById(int id)
		{
			return ConfigMingSuPlotById.GetConfig(id, true);
		}

		// Token: 0x06038CCF RID: 232655 RVA: 0x00E63934 File Offset: 0x00E61B34
		public List<int> GetIsDragonPoolCompositeRewardIdList()
		{
			IReadOnlyList<CompositeRewardDisplay> configList = ConfigCompositeRewardDisplayAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.MingSuTi, ELogAuthor.BB, "CompositeRewardDisplay表无配置", default(ReadOnlySpan<ValueTuple<string, object>>));
				return null;
			}
			List<int> list = new List<int>();
			for (int i = 0; i < configList.Count; i++)
			{
				CompositeRewardDisplay compositeRewardDisplay = configList[i];
				if (compositeRewardDisplay.IsDragonPool)
				{
					list.Add(compositeRewardDisplay.Id);
				}
			}
			return list;
		}

		// Token: 0x06038CD0 RID: 232656 RVA: 0x00E639A0 File Offset: 0x00E61BA0
		public DarkCoastDelivery? GetDarkCoastDeliveryById(int id)
		{
			DarkCoastDelivery? config = ConfigDarkCoastDeliveryById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.MingSuTi;
				ELogAuthor author = ELogAuthor.BB;
				string message = "DarkCoastDelivery表无当前id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id.ToString());
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return config;
		}
	}
}
