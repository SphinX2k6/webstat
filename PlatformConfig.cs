using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x020025F0 RID: 9712
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class PlatformConfig : ConfigBase<PlatformConfig>
{
	// Token: 0x06013083 RID: 77955 RVA: 0x00546A9F File Offset: 0x00544C9F
	public DevicePlatform? GetDeviceConfigByProductIdAndVendorId(string productIdAndVendorId)
	{
		return ConfigDevicePlatformByPidAndVid.GetConfig(productIdAndVendorId, true);
	}
}
