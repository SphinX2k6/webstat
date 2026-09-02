using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Camera
{
	// Token: 0x0200430A RID: 17162
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Camera/EPhotographCamera.EPhotographCamera")]
	public enum EPhotographCamera : byte
	{
		// Token: 0x040199CA RID: 104906
		None,
		// Token: 0x040199CB RID: 104907
		战斗拍照角色最大虚化仰视角,
		// Token: 0x040199CC RID: 104908
		战斗拍照角色开始虚化距离,
		// Token: 0x040199CD RID: 104909
		战斗拍照角色最大虚化距离,
		// Token: 0x040199CE RID: 104910
		战斗拍照角色虚化不透明度,
		// Token: 0x040199CF RID: 104911
		拍照界面npc开始虚化距离,
		// Token: 0x040199D0 RID: 104912
		拍照界面npc最大虚化距离,
		// Token: 0x040199D1 RID: 104913
		拍照界面npc虚化不透明度,
		// Token: 0x040199D2 RID: 104914
		角色开始虚化距离,
		// Token: 0x040199D3 RID: 104915
		角色最大虚化距离,
		// Token: 0x040199D4 RID: 104916
		角色开始虚化仰视角,
		// Token: 0x040199D5 RID: 104917
		角色最大虚化仰视角,
		// Token: 0x040199D6 RID: 104918
		角色虚化不透明度,
		// Token: 0x040199D7 RID: 104919
		角色开始虚化屏幕占比,
		// Token: 0x040199D8 RID: 104920
		角色最大虚化屏幕占比,
		// Token: 0x040199D9 RID: 104921
		战斗拍照角色开始虚化仰视角,
		// Token: 0x040199DA RID: 104922
		EPhotographCamera_MAX
	}
}
