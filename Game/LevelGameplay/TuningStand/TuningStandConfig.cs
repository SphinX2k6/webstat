using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.LevelGamePlay.TuningStand
{
	// Token: 0x02006A6C RID: 27244
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class TuningStandConfig : ConfigBase<TuningStandConfig>
	{
		// Token: 0x06043674 RID: 276084 RVA: 0x0115D0CC File Offset: 0x0115B2CC
		[return: Nullable(2)]
		public string GetEvent(string node)
		{
			if (this.CacheMap == null)
			{
				this.CacheMap = new Dictionary<string, string>();
				IReadOnlyList<TuningNode> configList = ConfigTuningNodeByAll.GetConfigList(true);
				if (configList != null)
				{
					foreach (TuningNode tuningNode in configList)
					{
						this.CacheMap[tuningNode.Desc] = tuningNode.AkEvent;
					}
				}
			}
			string result;
			if (!this.CacheMap.TryGetValue(node, out result))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelPlay;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "No TuningNode Config";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TuningNode", node);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			return result;
		}

		// Token: 0x04025A0E RID: 154126
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		protected Dictionary<string, string> CacheMap;
	}
}
