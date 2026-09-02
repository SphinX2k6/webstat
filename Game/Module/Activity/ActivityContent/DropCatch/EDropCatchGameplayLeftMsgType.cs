using System;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068B6 RID: 26806
	[JsonConverter(typeof(EDropCatchGameplayLeftMsgTypeJsonConverter))]
	[EnumExtensions]
	public enum EDropCatchGameplayLeftMsgType
	{
		// Token: 0x0402525C RID: 152156
		[EnumStringMember("Gameplay")]
		Gameplay,
		// Token: 0x0402525D RID: 152157
		[EnumStringMember("DropItem")]
		DropItem
	}
}
