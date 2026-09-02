using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.NPC.Common
{
	// Token: 0x020040EC RID: 16620
	[UnrealObjectPath("/Game/Aki/Character/NPC/Common/BPI_NpcEcological.BPI_NpcEcological_C")]
	public interface IBPI_NpcEcological_C : IUnrealBlueprintInterface, IUnrealInterface, IUnrealObject
	{
		// Token: 0x0602C0BD RID: 180413 RVA: 0x00A92FA8 File Offset: 0x00A911A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandlePlayerAttackEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandlePlayerAttackEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0BE RID: 180414 RVA: 0x00A92FBC File Offset: 0x00A911BC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandlePlayerAttack()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandlePlayerAttack_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0BF RID: 180415 RVA: 0x00A92FD0 File Offset: 0x00A911D0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandlePlayerImpactEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandlePlayerImpactEnd_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0C0 RID: 180416 RVA: 0x00A92FE4 File Offset: 0x00A911E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandlePlayerImpact()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandlePlayerImpact_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0C1 RID: 180417 RVA: 0x00A92FF8 File Offset: 0x00A911F8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandlePlayerExit()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandlePlayerExit_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0C2 RID: 180418 RVA: 0x00A9300C File Offset: 0x00A9120C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandlePlayerEnter()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandlePlayerEnter_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0C3 RID: 180419 RVA: 0x00A93020 File Offset: 0x00A91220
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandleQuestChanged()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandleQuestChanged_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0C4 RID: 180420 RVA: 0x00A93034 File Offset: 0x00A91234
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandleDayStateChanged()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandleDayStateChanged_NativeFunctionPtr, null);
		}

		// Token: 0x0602C0C5 RID: 180421 RVA: 0x00A93048 File Offset: 0x00A91248
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		void HandleWeatherChanged()
		{
			UnrealReflectionUtils.CallVirtualUFunction(this.NativePtr, IBPI_NpcEcological_C_ReflectionImplementationFields.__HandleWeatherChanged_NativeFunctionPtr, null);
		}

		// Token: 0x0401858B RID: 99723
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/NPC/Common/BPI_NpcEcological.BPI_NpcEcological_C";
	}
}
