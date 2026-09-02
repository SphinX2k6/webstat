using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.Menu
{
	// Token: 0x0200575B RID: 22363
	[NullableContext(1)]
	public interface IKeySettingDeviceInfo
	{
		// Token: 0x1700916F RID: 37231
		// (get) Token: 0x06038EB2 RID: 233138
		// (set) Token: 0x06038EB3 RID: 233139
		EKeySettingDeviceType DeviceType { get; set; }

		// Token: 0x17009170 RID: 37232
		// (get) Token: 0x06038EB4 RID: 233140
		// (set) Token: 0x06038EB5 RID: 233141
		string NameTextId { get; set; }
	}
}
