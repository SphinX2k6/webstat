using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Menu;

namespace CSharpScript.Game.Module.KeySetting
{
	// Token: 0x02005AFB RID: 23291
	[NullableContext(1)]
	[Nullable(0)]
	public static class KeySettingDefine
	{
		// Token: 0x0603AE65 RID: 241253 RVA: 0x00EEFE24 File Offset: 0x00EEE024
		// Note: this type is marked as 'beforefieldinit'.
		static KeySettingDefine()
		{
			Dictionary<EKeySettingDeviceType, IKeySettingDeviceInfo> dictionary = new Dictionary<EKeySettingDeviceType, IKeySettingDeviceInfo>();
			dictionary[EKeySettingDeviceType.None] = new KeySettingDeviceInfoClass
			{
				DeviceType = EKeySettingDeviceType.None,
				NameTextId = ""
			};
			dictionary[EKeySettingDeviceType.Keyboard] = new KeySettingDeviceInfoClass
			{
				DeviceType = EKeySettingDeviceType.Keyboard,
				NameTextId = "Text_KeyBoard_Text"
			};
			dictionary[EKeySettingDeviceType.Gamepad] = new KeySettingDeviceInfoClass
			{
				DeviceType = EKeySettingDeviceType.Gamepad,
				NameTextId = "Text_Handle_Text"
			};
			KeySettingDefine.keySettingDeviceInfoRecord = dictionary;
		}

		// Token: 0x0402143C RID: 136252
		[StaticVariableRuleIgnore]
		public static readonly EKeySettingExclusiveType[] menuKeySettingExclusiveTypeList = new EKeySettingExclusiveType[]
		{
			EKeySettingExclusiveType.None,
			EKeySettingExclusiveType.Motor
		};

		// Token: 0x0402143D RID: 136253
		[StaticVariableRuleIgnore]
		public static readonly Dictionary<EKeySettingDeviceType, IKeySettingDeviceInfo> keySettingDeviceInfoRecord;
	}
}
