using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007001 RID: 28673
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class LanguageKeyTransBase
	{
		// Token: 0x0604568E RID: 284302 RVA: 0x01225E9C File Offset: 0x0122409C
		public void InitPcKeysByConfig(PcKey config)
		{
			string otherPcKey = this.GetOtherPcKey(config);
			if (!StringUtils.IsBlank(otherPcKey))
			{
				this.NormalToOtherPcKeysMap[config.KeyName] = otherPcKey;
				this.OtherToNormalPcKeysMap[otherPcKey] = config.KeyName;
			}
		}

		// Token: 0x0604568F RID: 284303
		protected abstract string GetOtherPcKey(PcKey config);

		// Token: 0x06045690 RID: 284304
		public abstract string[] GetActionPcKeys(ActionMapping actionMappingConfig);

		// Token: 0x06045691 RID: 284305
		public abstract Dictionary<string, float> GetAxisPcKeys(AxisMapping axisMappingConfig);

		// Token: 0x06045692 RID: 284306
		public abstract Dictionary<string, string> GetCombinationActionPcKeys(CombinationAction combinationActionMappingConfig);

		// Token: 0x06045693 RID: 284307
		public abstract string GetPcKeyIconPath(PcKey config);

		// Token: 0x06045694 RID: 284308 RVA: 0x01225EE0 File Offset: 0x012240E0
		public string GetNormalToOtherPcKeysMap(string keyName)
		{
			string result;
			if (this.NormalToOtherPcKeysMap.TryGetValue(keyName, out result))
			{
				return result;
			}
			return keyName;
		}

		// Token: 0x06045695 RID: 284309 RVA: 0x01225F00 File Offset: 0x01224100
		public string GetOtherToNormalPcKeysMap(string keyName)
		{
			string result;
			if (this.OtherToNormalPcKeysMap.TryGetValue(keyName, out result))
			{
				return result;
			}
			return keyName;
		}

		// Token: 0x04026CCE RID: 158926
		private readonly Dictionary<string, string> NormalToOtherPcKeysMap = new Dictionary<string, string>();

		// Token: 0x04026CCF RID: 158927
		private readonly Dictionary<string, string> OtherToNormalPcKeysMap = new Dictionary<string, string>();
	}
}
