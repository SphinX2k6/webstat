using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C1 RID: 16833
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BPI_CharacterAnimation.BPI_CharacterAnimation_C")]
	public interface IBPI_CharacterAnimation_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602CB96 RID: 183190 RVA: 0x00AAD103 File Offset: 0x00AAB303
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void BPI_Jumped()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_CharacterAnimation_C_ReflectionImplementationFields.__BPI_Jumped_NativeFunctionPtr, null);
		}

		// Token: 0x04018EB2 RID: 102066
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BPI_CharacterAnimation.BPI_CharacterAnimation_C";
	}
}
