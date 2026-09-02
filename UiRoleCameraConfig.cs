using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.UiRoleCamera.Struct;

// Token: 0x020028F4 RID: 10484
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class UiRoleCameraConfig : ConfigBase<UiRoleCameraConfig>
{
	// Token: 0x06014D3B RID: 85307 RVA: 0x005C4DB4 File Offset: 0x005C2FB4
	public SUiRoleCameraSetting? GetRoleCameraConfig(string rowName)
	{
		SUiRoleCameraSetting? result;
		DataTableUtil.TryGetDataTableRowStruct<SUiRoleCameraSetting>(EDataTable.UiRoleCameraSettings, rowName, out result);
		return result;
	}

	// Token: 0x06014D3C RID: 85308 RVA: 0x005C4DCD File Offset: 0x005C2FCD
	public SUiRoleCameraSetting? GetDefaultRoleCameraConfig()
	{
		return this.GetRoleCameraConfig("默认");
	}

	// Token: 0x06014D3D RID: 85309 RVA: 0x005C4DDC File Offset: 0x005C2FDC
	public SUiRoleCameraOffsetSetting? GetRoleCameraOffsetConfig(string roleBody)
	{
		SUiRoleCameraOffsetSetting? result;
		DataTableUtil.TryGetDataTableRowStruct<SUiRoleCameraOffsetSetting>(EDataTable.UiRoleCameraOffsetSettings, roleBody, out result);
		return result;
	}
}
