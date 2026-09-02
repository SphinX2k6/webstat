using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter;
using UnrealEngine;

namespace CSharpScript.Game.Module.Audio
{
	// Token: 0x0200615B RID: 24923
	public interface IAudioCoolDownWithTagInfo : IAudioCoolDownInfo
	{
		// Token: 0x17009AE8 RID: 39656
		// (get) Token: 0x0603EFBE RID: 257982
		// (set) Token: 0x0603EFBF RID: 257983
		[Nullable(new byte[]
		{
			2,
			1
		})]
		TArray<SGameplayTagProbabilityCooldownInfo> TagProbability { [return: Nullable(new byte[]
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
