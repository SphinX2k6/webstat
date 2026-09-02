using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Menu;

namespace CSharpScript.Game.Module.KeySetting
{
	// Token: 0x02005AFC RID: 23292
	[NullableContext(1)]
	[Nullable(0)]
	public class KeySettingDeviceInfoClass : IKeySettingDeviceInfo
	{
		// Token: 0x17009601 RID: 38401
		// (get) Token: 0x0603AE66 RID: 241254 RVA: 0x00EEFEA4 File Offset: 0x00EEE0A4
		// (set) Token: 0x0603AE67 RID: 241255 RVA: 0x00EEFEAC File Offset: 0x00EEE0AC
		public EKeySettingDeviceType DeviceType { get; set; }

		// Token: 0x17009602 RID: 38402
		// (get) Token: 0x0603AE68 RID: 241256 RVA: 0x00EEFEB5 File Offset: 0x00EEE0B5
		// (set) Token: 0x0603AE69 RID: 241257 RVA: 0x00EEFEBD File Offset: 0x00EEE0BD
		public string NameTextId { get; set; } = "";
	}
}
