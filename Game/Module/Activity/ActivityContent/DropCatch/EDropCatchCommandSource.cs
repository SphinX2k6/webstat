using System;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068B3 RID: 26803
	[JsonConverter(typeof(EDropCatchCommandSourceJsonConverter))]
	[EnumExtensions]
	public enum EDropCatchCommandSource
	{
		// Token: 0x04025255 RID: 152149
		[EnumStringMember("Skill")]
		Skill
	}
}
