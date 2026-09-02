using System;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068AE RID: 26798
	[JsonConverter(typeof(EDropCatchModifierTypeJsonConverter))]
	[EnumExtensions]
	public enum EDropCatchModifierType
	{
		// Token: 0x04025247 RID: 152135
		[EnumStringMember("Override")]
		Override,
		// Token: 0x04025248 RID: 152136
		[EnumStringMember("Rate")]
		Rate,
		// Token: 0x04025249 RID: 152137
		[EnumStringMember("Offset")]
		Offset
	}
}
