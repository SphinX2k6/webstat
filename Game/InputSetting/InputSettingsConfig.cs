using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.InputSetting
{
	// Token: 0x02006FF1 RID: 28657
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class InputSettingsConfig : ConfigBase<InputSettingsConfig>
	{
		// Token: 0x060455B5 RID: 284085 RVA: 0x0121EC3C File Offset: 0x0121CE3C
		public IReadOnlyList<ActionMapping> GetAllActionMappingConfig()
		{
			return ConfigActionMappingAll.GetConfigList(true);
		}

		// Token: 0x060455B6 RID: 284086 RVA: 0x0121EC44 File Offset: 0x0121CE44
		public IReadOnlyList<ActionMapping> GetActionMappingConfigByActionType(int actionType)
		{
			return ConfigActionMappingByActionType.GetConfigList(actionType, true);
		}

		// Token: 0x060455B7 RID: 284087 RVA: 0x0121EC4D File Offset: 0x0121CE4D
		[NullableContext(1)]
		public ActionMapping? GetActionMappingConfigByActionName(string actionName)
		{
			return ConfigActionMappingByActionName.GetConfig(actionName, true);
		}

		// Token: 0x060455B8 RID: 284088 RVA: 0x0121EC56 File Offset: 0x0121CE56
		public IReadOnlyList<AxisMapping> GetAllAxisMappingConfig()
		{
			return ConfigAxisMappingAll.GetConfigList(true);
		}

		// Token: 0x060455B9 RID: 284089 RVA: 0x0121EC5E File Offset: 0x0121CE5E
		public IReadOnlyList<AxisMapping> GetAxisMappingConfigByActionType(int axisType)
		{
			return ConfigAxisMappingByAxisType.GetConfigList(axisType, true);
		}

		// Token: 0x060455BA RID: 284090 RVA: 0x0121EC67 File Offset: 0x0121CE67
		[NullableContext(1)]
		public AxisMapping? GetAxisMappingConfigByAxisName(string axisName)
		{
			return ConfigAxisMappingByAxisName.GetConfig(axisName, true);
		}

		// Token: 0x060455BB RID: 284091 RVA: 0x0121EC70 File Offset: 0x0121CE70
		public IReadOnlyList<CombinationAction> GetAllCombinationActionConfig()
		{
			return ConfigCombinationActionAll.GetConfigList(true);
		}

		// Token: 0x060455BC RID: 284092 RVA: 0x0121EC78 File Offset: 0x0121CE78
		[NullableContext(1)]
		public CombinationAction? GetCombinationActionConfigByActionName(string actionName)
		{
			return ConfigCombinationActionByActionName.GetConfig(actionName, true);
		}

		// Token: 0x060455BD RID: 284093 RVA: 0x0121EC84 File Offset: 0x0121CE84
		[NullableContext(1)]
		public CombinationAction? GetCombinationActionConfigByActionNameInList(string actionName)
		{
			IReadOnlyList<CombinationAction> allCombinationActionConfig = this.GetAllCombinationActionConfig();
			if (allCombinationActionConfig != null)
			{
				foreach (CombinationAction value in allCombinationActionConfig)
				{
					if (value.ActionName == actionName)
					{
						return new CombinationAction?(value);
					}
				}
			}
			return null;
		}

		// Token: 0x060455BE RID: 284094 RVA: 0x0121ECF4 File Offset: 0x0121CEF4
		public IReadOnlyList<CombinationAction> GetCombinationActionConfigByActionType(int actionType)
		{
			return ConfigCombinationActionByActionType.GetConfigList(actionType, true);
		}

		// Token: 0x060455BF RID: 284095 RVA: 0x0121ECFD File Offset: 0x0121CEFD
		public IReadOnlyList<CombinationAxis> GetAllCombinationAxisConfig()
		{
			return ConfigCombinationAxisAll.GetConfigList(true);
		}

		// Token: 0x060455C0 RID: 284096 RVA: 0x0121ED05 File Offset: 0x0121CF05
		[NullableContext(1)]
		public CombinationAxis? GetCombinationAxisConfigByAxisName(string axisName)
		{
			return ConfigCombinationAxisByAxisName.GetConfig(axisName, true);
		}

		// Token: 0x060455C1 RID: 284097 RVA: 0x0121ED0E File Offset: 0x0121CF0E
		[NullableContext(1)]
		public PcKey? GetPcKeyConfig(string keyName)
		{
			return ConfigPcKeyByKeyName.GetConfig(keyName, true);
		}

		// Token: 0x060455C2 RID: 284098 RVA: 0x0121ED17 File Offset: 0x0121CF17
		public IReadOnlyList<PcKey> GetPcKeyConfigList()
		{
			return ConfigPcKeyAll.GetConfigList(true);
		}

		// Token: 0x060455C3 RID: 284099 RVA: 0x0121ED1F File Offset: 0x0121CF1F
		public PcKey? GetPcKeyConfigById(int configId)
		{
			return ConfigPcKeyById.GetConfig(configId, true);
		}

		// Token: 0x060455C4 RID: 284100 RVA: 0x0121ED28 File Offset: 0x0121CF28
		[NullableContext(1)]
		public GamepadKey? GetGamepadKeyConfig(string keyName)
		{
			return ConfigGamepadKeyByKeyName.GetConfig(keyName, true);
		}

		// Token: 0x060455C5 RID: 284101 RVA: 0x0121ED31 File Offset: 0x0121CF31
		public GamepadKey? GetGamepadKeyConfigById(int configId)
		{
			return ConfigGamepadKeyById.GetConfig(configId, true);
		}

		// Token: 0x060455C6 RID: 284102 RVA: 0x0121ED3A File Offset: 0x0121CF3A
		public PlatformIcon? GetPlatformIconConfig(int configId)
		{
			return ConfigPlatformIconById.GetConfig(configId, true);
		}
	}
}
