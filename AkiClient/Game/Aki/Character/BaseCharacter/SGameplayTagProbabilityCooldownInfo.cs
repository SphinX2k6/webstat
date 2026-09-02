using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004263 RID: 16995
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SGameplayTagProbabilityCooldownInfo.SGameplayTagProbabilityCooldownInfo")]
	[UnrealStructLayout(20, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 20)]
	public class SGameplayTagProbabilityCooldownInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D09B RID: 184475 RVA: 0x00AB5F30 File Offset: 0x00AB4130
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGameplayTagProbabilityCooldownInfo._ScriptStructPtr != 0) ? SGameplayTagProbabilityCooldownInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SGameplayTagProbabilityCooldownInfo.SGameplayTagProbabilityCooldownInfo", ref SGameplayTagProbabilityCooldownInfo._ScriptStructPtr);
		}

		// Token: 0x17007A39 RID: 31289
		// (get) Token: 0x0602D09C RID: 184476 RVA: 0x00AB5F54 File Offset: 0x00AB4154
		// (set) Token: 0x0602D09D RID: 184477 RVA: 0x00AB5F68 File Offset: 0x00AB4168
		public unsafe FGameplayTag GameplayTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTagProbabilityCooldownInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTagProbabilityCooldownInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A3A RID: 31290
		// (get) Token: 0x0602D09E RID: 184478 RVA: 0x00AB5F7D File Offset: 0x00AB417D
		// (set) Token: 0x0602D09F RID: 184479 RVA: 0x00AB5F8D File Offset: 0x00AB418D
		public unsafe float Probability
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTagProbabilityCooldownInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTagProbabilityCooldownInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007A3B RID: 31291
		// (get) Token: 0x0602D0A0 RID: 184480 RVA: 0x00AB5F9E File Offset: 0x00AB419E
		// (set) Token: 0x0602D0A1 RID: 184481 RVA: 0x00AB5FAE File Offset: 0x00AB41AE
		public unsafe int CooldownTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTagProbabilityCooldownInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTagProbabilityCooldownInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D0A2 RID: 184482 RVA: 0x00AB5FBF File Offset: 0x00AB41BF
		public SGameplayTagProbabilityCooldownInfo()
		{
		}

		// Token: 0x0602D0A3 RID: 184483 RVA: 0x00AB5FC7 File Offset: 0x00AB41C7
		public SGameplayTagProbabilityCooldownInfo(FGameplayTag GameplayTag, float Probability, int CooldownTime)
		{
			this.GameplayTag = GameplayTag;
			this.Probability = Probability;
			this.CooldownTime = CooldownTime;
		}

		// Token: 0x0602D0A4 RID: 184484 RVA: 0x00AB5FE4 File Offset: 0x00AB41E4
		protected override IntPtr GetUStructPtr()
		{
			return SGameplayTagProbabilityCooldownInfo.StaticStruct();
		}

		// Token: 0x0602D0A5 RID: 184485 RVA: 0x00AB5FF0 File Offset: 0x00AB41F0
		[NullableContext(2)]
		public SGameplayTagProbabilityCooldownInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D0A6 RID: 184486 RVA: 0x00AB5FFA File Offset: 0x00AB41FA
		public SGameplayTagProbabilityCooldownInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D0A7 RID: 184487 RVA: 0x00AB6005 File Offset: 0x00AB4205
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGameplayTagProbabilityCooldownInfo(Pointer, false, true);
		}

		// Token: 0x0602D0A8 RID: 184488 RVA: 0x00AB600F File Offset: 0x00AB420F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGameplayTagProbabilityCooldownInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0401941F RID: 103455
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SGameplayTagProbabilityCooldownInfo.SGameplayTagProbabilityCooldownInfo";

		// Token: 0x04019420 RID: 103456
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019421 RID: 103457
		internal static int __PropertyOffset_0;

		// Token: 0x04019422 RID: 103458
		internal static int __PropertyOffset_1;

		// Token: 0x04019423 RID: 103459
		internal static int __PropertyOffset_2;
	}
}
