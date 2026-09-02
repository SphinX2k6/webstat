using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.GameplayABP
{
	// Token: 0x020042E5 RID: 17125
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/GameplayABP/SGameplayABPAssetConfig.SGameplayABPAssetConfig")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SGameplayABPAssetConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D6BE RID: 186046 RVA: 0x00ABFA8F File Offset: 0x00ABDC8F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGameplayABPAssetConfig._ScriptStructPtr != 0) ? SGameplayABPAssetConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/GameplayABP/SGameplayABPAssetConfig.SGameplayABPAssetConfig", ref SGameplayABPAssetConfig._ScriptStructPtr);
		}

		// Token: 0x17007BF6 RID: 31734
		// (get) Token: 0x0602D6BF RID: 186047 RVA: 0x00ABFAB3 File Offset: 0x00ABDCB3
		// (set) Token: 0x0602D6C0 RID: 186048 RVA: 0x00ABFAC7 File Offset: 0x00ABDCC7
		public unsafe TEnumAsByte<EGameplayABPType> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayABPAssetConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayABPAssetConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BF7 RID: 31735
		// (get) Token: 0x0602D6C1 RID: 186049 RVA: 0x00ABFADC File Offset: 0x00ABDCDC
		// (set) Token: 0x0602D6C2 RID: 186050 RVA: 0x00ABFAFB File Offset: 0x00ABDCFB
		[Nullable(1)]
		public TSoftClassPtr<UKuroAnimInstance> AnimInstance
		{
			[NullableContext(1)]
			get
			{
				return new TSoftClassPtr<UKuroAnimInstance>(base.NativePtr + (IntPtr)SGameplayABPAssetConfig.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SGameplayABPAssetConfig.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602D6C3 RID: 186051 RVA: 0x00ABFB20 File Offset: 0x00ABDD20
		public SGameplayABPAssetConfig()
		{
		}

		// Token: 0x0602D6C4 RID: 186052 RVA: 0x00ABFB28 File Offset: 0x00ABDD28
		public SGameplayABPAssetConfig(TEnumAsByte<EGameplayABPType> Type, [Nullable(1)] TSoftClassPtr<UKuroAnimInstance> AnimInstance)
		{
			this.Type = Type;
			this.AnimInstance = AnimInstance;
		}

		// Token: 0x0602D6C5 RID: 186053 RVA: 0x00ABFB3E File Offset: 0x00ABDD3E
		protected override IntPtr GetUStructPtr()
		{
			return SGameplayABPAssetConfig.StaticStruct();
		}

		// Token: 0x0602D6C6 RID: 186054 RVA: 0x00ABFB4A File Offset: 0x00ABDD4A
		[NullableContext(2)]
		public SGameplayABPAssetConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D6C7 RID: 186055 RVA: 0x00ABFB54 File Offset: 0x00ABDD54
		public SGameplayABPAssetConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D6C8 RID: 186056 RVA: 0x00ABFB5F File Offset: 0x00ABDD5F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGameplayABPAssetConfig(Pointer, false, true);
		}

		// Token: 0x0602D6C9 RID: 186057 RVA: 0x00ABFB69 File Offset: 0x00ABDD69
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGameplayABPAssetConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040197AE RID: 104366
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/GameplayABP/SGameplayABPAssetConfig.SGameplayABPAssetConfig";

		// Token: 0x040197AF RID: 104367
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040197B0 RID: 104368
		internal static int __PropertyOffset_0;

		// Token: 0x040197B1 RID: 104369
		internal static int __PropertyOffset_1;
	}
}
