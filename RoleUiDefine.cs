using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020028E1 RID: 10465
public class RoleUiDefine : IStaticVariableResetter
{
	// Token: 0x06014C9C RID: 85148 RVA: 0x005C1F44 File Offset: 0x005C0144
	static RoleUiDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(RoleUiDefine.CreateStaticDefaultValue), new Action(RoleUiDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06014C9D RID: 85149 RVA: 0x005C1F64 File Offset: 0x005C0164
	public static void CreateStaticDefaultValue()
	{
		RoleUiDefine.roleSystemModeUiParam = new Dictionary<ERoleSystemMode, IRoleSystemUiParams>
		{
			{
				ERoleSystemMode.Trial,
				new RoleSystemUiParams
				{
					RoleListButton = true,
					RoleListButtonRedDot = false,
					RoleList = true,
					RoleListNeedTrial = true,
					RoleListRedDot = false,
					TabRedDot = false,
					TeachBtn = true,
					SwitchSkin = false,
					BackgroundMusicSwitch = false
				}
			},
			{
				ERoleSystemMode.Normal,
				new RoleSystemUiParams
				{
					RoleListButton = true,
					RoleListButtonRedDot = true,
					RoleList = true,
					RoleListNeedTrial = true,
					RoleListRedDot = true,
					TabRedDot = true,
					TeachBtn = true,
					SwitchSkin = true,
					BackgroundMusicSwitch = true
				}
			},
			{
				ERoleSystemMode.Preview,
				new RoleSystemUiParams
				{
					RoleListButton = true,
					RoleListButtonRedDot = false,
					RoleList = true,
					RoleListNeedTrial = false,
					RoleListRedDot = false,
					TabRedDot = false,
					TeachBtn = false,
					SwitchSkin = false,
					BackgroundMusicSwitch = false
				}
			},
			{
				ERoleSystemMode.RoleNewJoin,
				new RoleSystemUiParams
				{
					RoleListButton = false,
					RoleListButtonRedDot = false,
					RoleList = true,
					RoleListNeedTrial = false,
					RoleListRedDot = false,
					TabRedDot = false,
					TeachBtn = false,
					SwitchSkin = false,
					BackgroundMusicSwitch = false
				}
			},
			{
				ERoleSystemMode.SpecialTrial,
				new RoleSystemUiParams
				{
					RoleListButton = true,
					RoleListButtonRedDot = false,
					RoleList = true,
					RoleListNeedTrial = true,
					RoleListRedDot = false,
					TabRedDot = false,
					TeachBtn = true,
					SwitchSkin = false,
					BackgroundMusicSwitch = false
				}
			}
		};
	}

	// Token: 0x06014C9E RID: 85150 RVA: 0x005C20F2 File Offset: 0x005C02F2
	public static void ResetStaticDefaultValue()
	{
		RoleUiDefine.roleSystemModeUiParam = null;
	}

	// Token: 0x0400A012 RID: 40978
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<ERoleSystemMode, IRoleSystemUiParams> roleSystemModeUiParam;
}
