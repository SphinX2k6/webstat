using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020015BE RID: 5566
[NullableContext(1)]
[Nullable(0)]
public class Spring25Define : IStaticVariableResetter
{
	// Token: 0x06009D0D RID: 40205 RVA: 0x002921C2 File Offset: 0x002903C2
	static Spring25Define()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(Spring25Define.CreateStaticDefaultValue), new Action(Spring25Define.ResetStaticDefaultValue));
	}

	// Token: 0x06009D0E RID: 40206 RVA: 0x002921E4 File Offset: 0x002903E4
	public static void CreateStaticDefaultValue()
	{
		Spring25Define.Spring25DialogIndex = new Dictionary<string, int>
		{
			{
				"Bubble01",
				0
			},
			{
				"Bubble02",
				1
			},
			{
				"Bubble03",
				2
			},
			{
				"Bubble04",
				3
			},
			{
				"Bubble05",
				4
			},
			{
				"Bubble06",
				5
			},
			{
				"Bubble07",
				6
			},
			{
				"Bubble08",
				7
			}
		};
	}

	// Token: 0x06009D0F RID: 40207 RVA: 0x0029225B File Offset: 0x0029045B
	public static void ResetStaticDefaultValue()
	{
		Spring25Define.Spring25DialogIndex = null;
	}

	// Token: 0x04004811 RID: 18449
	public const int SANHUA_SKIN_ITEM_ID = 81011102;

	// Token: 0x04004812 RID: 18450
	public const int PROGRESS_BLINK_WAITING_TIME = 1000;

	// Token: 0x04004813 RID: 18451
	public const string PROGRESS_TEXT_ID_IN_SUBVIEW = "Springsystem_1";

	// Token: 0x04004814 RID: 18452
	public const string REWARD_TITLE_TEXT_ID_IN_SUBVIEW = "Springsystem_2";

	// Token: 0x04004815 RID: 18453
	public const string BUTTON_TEXT_ID_IN_SUBVIEW = "Springsystem_3";

	// Token: 0x04004816 RID: 18454
	public const string NO_LETTER_TIPS_TEXT_ID = "SpringMessage_1";

	// Token: 0x04004817 RID: 18455
	public const string REMAIN_CHANCE_NOT_ENOUGH = "SpringMessage_2";

	// Token: 0x04004818 RID: 18456
	public const string BUTTON_TEXT_ID_IN_DIALOG = "Springsystem_4";

	// Token: 0x04004819 RID: 18457
	public const string FUNCTION_AND_NUMBER_TEXT_ID = "Springsystem_5";

	// Token: 0x0400481A RID: 18458
	public const string ALL_CHARACTER_INVITED = "Springsystem_6";

	// Token: 0x0400481B RID: 18459
	public const int START_MALE_CHAT_CONFIG_ID = 99;

	// Token: 0x0400481C RID: 18460
	public const int START_FEMALE_CHAT_CONFIG_ID = 100;

	// Token: 0x0400481D RID: 18461
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public static Dictionary<string, int> Spring25DialogIndex;
}
