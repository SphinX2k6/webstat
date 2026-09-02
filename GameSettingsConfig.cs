using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02000E87 RID: 3719
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class GameSettingsConfig : ConfigBase<GameSettingsConfig>
{
	// Token: 0x06005ACF RID: 23247 RVA: 0x0016477D File Offset: 0x0016297D
	public IReadOnlyList<DeviceRenderFeature> GetDeviceRenderFeatureConfigListByDeviceId(int deviceId)
	{
		return ConfigDeviceRenderFeatureByDeviceId.GetConfigList(deviceId, true);
	}
}
