using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200615D RID: 24925
	public class AudioCoolDownWithTagInfo : AudioCoolDownInfo, IAudioCoolDownWithTagInfo, IAudioCoolDownInfo
	{
		// Token: 0x17009AEB RID: 39659
		// (get) Token: 0x0603EFC5 RID: 257989 RVA: 0x01024E50 File Offset: 0x01023050
		// (set) Token: 0x0603EFC6 RID: 257990 RVA: 0x01024E58 File Offset: 0x01023058
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public TArray<SGameplayTagProbabilityCooldownInfo> TagProbability { [return: Nullable(new byte[]
		{
			2,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1
		})] set; }
	}
}
