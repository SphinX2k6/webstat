using System;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using AkiClient.Game.Aki.UI.Module.Loading.View;

// Token: 0x020020E2 RID: 8418
[NullableContext(2)]
[Nullable(0)]
public class BackToGameData
{
	// Token: 0x04007B48 RID: 31560
	public EBackToGameType BackToGameType;

	// Token: 0x04007B49 RID: 31561
	public float Progress;

	// Token: 0x04007B4A RID: 31562
	[JsonIgnore]
	public WBP_UILoading_C LoadingWidget;

	// Token: 0x04007B4B RID: 31563
	public string LoadingTexturePath;

	// Token: 0x04007B4C RID: 31564
	public string LoadingTitle;

	// Token: 0x04007B4D RID: 31565
	public string LoadingTips;

	// Token: 0x04007B4E RID: 31566
	public BackToGameLoginData BackToGameLoginData;
}
