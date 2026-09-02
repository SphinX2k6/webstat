using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200183B RID: 6203
[NullableContext(1)]
[Nullable(0)]
public class ChatDefine : IStaticVariableResetter
{
	// Token: 0x0600B129 RID: 45353 RVA: 0x002F515C File Offset: 0x002F335C
	static ChatDefine()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(ChatDefine.CreateStaticDefaultValue), new Action(ChatDefine.ResetStaticDefaultValue));
	}

	// Token: 0x0600B12A RID: 45354 RVA: 0x002F517B File Offset: 0x002F337B
	public static void CreateStaticDefaultValue()
	{
		ChatDefine.playerMarkNameColor = FColor.FromHex("81540E");
		ChatDefine.playerRealNameColor = FColor.FromHex("#000000FF");
	}

	// Token: 0x0600B12B RID: 45355 RVA: 0x002F519B File Offset: 0x002F339B
	public static void ResetStaticDefaultValue()
	{
		ChatDefine.playerMarkNameColor = default(FColor);
		ChatDefine.playerRealNameColor = default(FColor);
	}

	// Token: 0x04005404 RID: 21508
	public const int CHAT_CONTENT_QUEUE_SIZE = 10;

	// Token: 0x04005405 RID: 21509
	public const string CHAT_CONTENT_RESOURCE_ID = "UiItem_ChatLeft_Prefab";

	// Token: 0x04005406 RID: 21510
	public const string OWN_CHAT_CONTENT_RESOURCE_ID = "UiItem_ChatRight_Prefab";

	// Token: 0x04005407 RID: 21511
	public const string TEAM_CONTENT_RESOURCE_ID = "UiItem_Zudui";

	// Token: 0x04005408 RID: 21512
	public const int CHAT_SCROLL_DELAY = 200;

	// Token: 0x04005409 RID: 21513
	public const int FIRST_CHAT_SCROLL_DELAY = 500;

	// Token: 0x0400540A RID: 21514
	public const int REFRESH_PLAYER_INFO_TIME_DOWN = 10000;

	// Token: 0x0400540B RID: 21515
	public const int CHAT_PANEL_DELAY = 500;

	// Token: 0x0400540C RID: 21516
	public static FColor playerMarkNameColor;

	// Token: 0x0400540D RID: 21517
	public static FColor playerRealNameColor;

	// Token: 0x0400540E RID: 21518
	public const int READ_HISTORY_COUNT = 10;

	// Token: 0x0400540F RID: 21519
	public const int DELAY_PRIVATE_CHAT_DATA_REQUEST_TIME = 60000;
}
