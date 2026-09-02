using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02007003 RID: 28675
	[NullableContext(1)]
	[Nullable(0)]
	public class ThaiLanguageKeyTrans : LanguageKeyTransBase
	{
		// Token: 0x0604569F RID: 284319 RVA: 0x01226071 File Offset: 0x01224271
		protected override string GetOtherPcKey(PcKey config)
		{
			return config.ThaiKeyName;
		}

		// Token: 0x060456A0 RID: 284320 RVA: 0x0122607A File Offset: 0x0122427A
		public override string[] GetActionPcKeys(ActionMapping actionMappingConfig)
		{
			return actionMappingConfig.ThaiPcKeys();
		}

		// Token: 0x060456A1 RID: 284321 RVA: 0x01226083 File Offset: 0x01224283
		public override Dictionary<string, float> GetAxisPcKeys(AxisMapping axisMappingConfig)
		{
			return axisMappingConfig.ThaiPcKeys();
		}

		// Token: 0x060456A2 RID: 284322 RVA: 0x0122608C File Offset: 0x0122428C
		public override Dictionary<string, string> GetCombinationActionPcKeys(CombinationAction combinationActionMappingConfig)
		{
			return combinationActionMappingConfig.ThaiPcKeys();
		}

		// Token: 0x060456A3 RID: 284323 RVA: 0x01226095 File Offset: 0x01224295
		public override string GetPcKeyIconPath(PcKey config)
		{
			if (!StringUtils.IsBlank(config.ThaiKeyIconPath))
			{
				return config.ThaiKeyIconPath;
			}
			return config.KeyIconPath;
		}
	}
}
