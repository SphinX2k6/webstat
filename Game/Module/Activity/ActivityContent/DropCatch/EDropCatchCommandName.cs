using System;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x02006890 RID: 26768
	[JsonConverter(typeof(EDropCatchCommandNameJsonConverter))]
	[EnumExtensions]
	public enum EDropCatchCommandName
	{
		// Token: 0x040251F0 RID: 152048
		[EnumStringMember("SpawnDropItem")]
		SpawnDropItem,
		// Token: 0x040251F1 RID: 152049
		[EnumStringMember("AddEnergy")]
		AddEnergy,
		// Token: 0x040251F2 RID: 152050
		[EnumStringMember("FullEnergy")]
		FullEnergy,
		// Token: 0x040251F3 RID: 152051
		[EnumStringMember("AddScore")]
		AddScore,
		// Token: 0x040251F4 RID: 152052
		[EnumStringMember("AddTime")]
		AddTime,
		// Token: 0x040251F5 RID: 152053
		[EnumStringMember("MoveRole")]
		MoveRole,
		// Token: 0x040251F6 RID: 152054
		[EnumStringMember("CrazyMode")]
		CrazyMode,
		// Token: 0x040251F7 RID: 152055
		[EnumStringMember("AddShield")]
		AddShield,
		// Token: 0x040251F8 RID: 152056
		[EnumStringMember("ConvertDropItem")]
		ConvertDropItem,
		// Token: 0x040251F9 RID: 152057
		[EnumStringMember("ModifyRoleSpeed")]
		ModifyRoleSpeed,
		// Token: 0x040251FA RID: 152058
		[EnumStringMember("ModifyDropPoolTimeInterval")]
		ModifyDropPoolTimeInterval,
		// Token: 0x040251FB RID: 152059
		[EnumStringMember("ModifyAddScoreRate")]
		ModifyAddScoreRate,
		// Token: 0x040251FC RID: 152060
		[EnumStringMember("ModifyEnergyGetRate")]
		ModifyEnergyGetRate,
		// Token: 0x040251FD RID: 152061
		[EnumStringMember("ShowLeftMsg")]
		ShowLeftMsg,
		// Token: 0x040251FE RID: 152062
		[EnumStringMember("ShowFloatEff")]
		ShowFloatEff,
		// Token: 0x040251FF RID: 152063
		[EnumStringMember("ChangeRoleColor")]
		ChangeRoleColor,
		// Token: 0x04025200 RID: 152064
		[EnumStringMember("PostAudioEvent")]
		PostAudioEvent,
		// Token: 0x04025201 RID: 152065
		[EnumStringMember("PlayFlow")]
		PlayFlow,
		// Token: 0x04025202 RID: 152066
		[EnumStringMember("SetInputEnabled")]
		SetInputEnabled
	}
}
