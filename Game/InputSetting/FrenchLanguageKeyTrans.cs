using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007000 RID: 28672
	[NullableContext(1)]
	[Nullable(0)]
	public class FrenchLanguageKeyTrans : LanguageKeyTransBase
	{
		// Token: 0x06045688 RID: 284296 RVA: 0x01225E4F File Offset: 0x0122404F
		protected override string GetOtherPcKey(PcKey config)
		{
			return config.FrenchKeyName;
		}

		// Token: 0x06045689 RID: 284297 RVA: 0x01225E58 File Offset: 0x01224058
		public override string[] GetActionPcKeys(ActionMapping actionMappingConfig)
		{
			return actionMappingConfig.FrancePcKeys();
		}

		// Token: 0x0604568A RID: 284298 RVA: 0x01225E61 File Offset: 0x01224061
		public override Dictionary<string, float> GetAxisPcKeys(AxisMapping axisMappingConfig)
		{
			return axisMappingConfig.FrancePcKeys();
		}

		// Token: 0x0604568B RID: 284299 RVA: 0x01225E6A File Offset: 0x0122406A
		public override Dictionary<string, string> GetCombinationActionPcKeys(CombinationAction combinationActionMappingConfig)
		{
			return combinationActionMappingConfig.FrancePcKeys();
		}

		// Token: 0x0604568C RID: 284300 RVA: 0x01225E73 File Offset: 0x01224073
		public override string GetPcKeyIconPath(PcKey config)
		{
			if (!StringUtils.IsBlank(config.FrenchKeyIconPath))
			{
				return config.FrenchKeyIconPath;
			}
			return config.KeyIconPath;
		}
	}
}
