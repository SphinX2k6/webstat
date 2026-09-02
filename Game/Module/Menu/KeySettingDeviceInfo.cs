using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200575C RID: 22364
	[NullableContext(1)]
	[Nullable(0)]
	public class KeySettingDeviceInfo : IKeySettingDeviceInfo
	{
		// Token: 0x17009171 RID: 37233
		// (get) Token: 0x06038EB6 RID: 233142 RVA: 0x00E6C7C9 File Offset: 0x00E6A9C9
		// (set) Token: 0x06038EB7 RID: 233143 RVA: 0x00E6C7D1 File Offset: 0x00E6A9D1
		public EKeySettingDeviceType DeviceType { get; set; }

		// Token: 0x17009172 RID: 37234
		// (get) Token: 0x06038EB8 RID: 233144 RVA: 0x00E6C7DA File Offset: 0x00E6A9DA
		// (set) Token: 0x06038EB9 RID: 233145 RVA: 0x00E6C7E2 File Offset: 0x00E6A9E2
		public string NameTextId { get; set; } = "";
	}
}
