using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FFF RID: 28671
	[NullableContext(1)]
	[Nullable(0)]
	public class DefaultLanguageKeyTrans : LanguageKeyTransBase
	{
		// Token: 0x06045682 RID: 284290 RVA: 0x01225E1A File Offset: 0x0122401A
		protected override string GetOtherPcKey(PcKey config)
		{
			return config.KeyName;
		}

		// Token: 0x06045683 RID: 284291 RVA: 0x01225E23 File Offset: 0x01224023
		public override string[] GetActionPcKeys(ActionMapping actionMappingConfig)
		{
			return actionMappingConfig.PcKeys();
		}

		// Token: 0x06045684 RID: 284292 RVA: 0x01225E2C File Offset: 0x0122402C
		public override Dictionary<string, float> GetAxisPcKeys(AxisMapping axisMappingConfig)
		{
			return axisMappingConfig.PcKeys();
		}

		// Token: 0x06045685 RID: 284293 RVA: 0x01225E35 File Offset: 0x01224035
		public override Dictionary<string, string> GetCombinationActionPcKeys(CombinationAction combinationActionMappingConfig)
		{
			return combinationActionMappingConfig.PcKeys();
		}

		// Token: 0x06045686 RID: 284294 RVA: 0x01225E3E File Offset: 0x0122403E
		public override string GetPcKeyIconPath(PcKey config)
		{
			return config.KeyIconPath;
		}
	}
}
