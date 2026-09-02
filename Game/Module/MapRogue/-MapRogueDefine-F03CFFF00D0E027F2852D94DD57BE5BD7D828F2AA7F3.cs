using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005902 RID: 22786
	internal static class <MapRogueDefine>F03CFFF00D0E027F2852D94DD57BE5BD7D828F2AA7F3E47833B077C3F5047A3BC__EMapRogueSpineAnimExtension
	{
		// Token: 0x06039D2D RID: 236845 RVA: 0x00EA4B38 File Offset: 0x00EA2D38
		[NullableContext(1)]
		public static string ToAnimString(this EMapRogueSpineAnim anim)
		{
			switch (anim)
			{
			case EMapRogueSpineAnim.Idle:
				return "Idle";
			case EMapRogueSpineAnim.Move:
				return "Run";
			case EMapRogueSpineAnim.Cheer:
				return "Cheer";
			case EMapRogueSpineAnim.Fight:
				return "Fight";
			default:
				return "Idle";
			}
		}
	}
}
