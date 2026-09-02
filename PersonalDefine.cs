using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200240A RID: 9226
public class PersonalDefine : IStaticVariableResetter
{
	// Token: 0x06011DCA RID: 73162 RVA: 0x004E9E17 File Offset: 0x004E8017
	static PersonalDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(PersonalDefine.CreateStaticDefaultValue), new Action(PersonalDefine.ResetStaticDefaultValue));
	}

	// Token: 0x06011DCB RID: 73163 RVA: 0x004E9E36 File Offset: 0x004E8036
	public static void CreateStaticDefaultValue()
	{
		PersonalDefine.playerTitleQualityToColor = new Dictionary<int, string>
		{
			{
				0,
				"FFF7A0FF"
			},
			{
				1,
				"D3DEFFFF"
			},
			{
				2,
				"B19370FF"
			}
		};
	}

	// Token: 0x06011DCC RID: 73164 RVA: 0x004E9E66 File Offset: 0x004E8066
	public static void ResetStaticDefaultValue()
	{
		PersonalDefine.playerTitleQualityToColor = null;
	}

	// Token: 0x04008B92 RID: 35730
	public const int MAX_SIGN_LENGTH = 40;

	// Token: 0x04008B93 RID: 35731
	public const int MAX_NAME_LENGTH = 12;

	// Token: 0x04008B94 RID: 35732
	[Nullable(1)]
	public const string STOP_AUDIO_EVENT_NAME = "stop_gacha_role_audio";

	// Token: 0x04008B95 RID: 35733
	[Nullable(1)]
	public static Dictionary<int, string> playerTitleQualityToColor;
}
