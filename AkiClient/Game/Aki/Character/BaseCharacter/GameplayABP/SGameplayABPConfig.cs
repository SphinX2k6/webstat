using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.GameplayABP
{
	// Token: 0x020042E6 RID: 17126
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/GameplayABP/SGameplayABPConfig.SGameplayABPConfig")]
	[UnrealStructLayout(28, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 28)]
	public class SGameplayABPConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D6CA RID: 186058 RVA: 0x00ABFB72 File Offset: 0x00ABDD72
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGameplayABPConfig._ScriptStructPtr != 0) ? SGameplayABPConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/GameplayABP/SGameplayABPConfig.SGameplayABPConfig", ref SGameplayABPConfig._ScriptStructPtr);
		}

		// Token: 0x17007BF8 RID: 31736
		// (get) Token: 0x0602D6CB RID: 186059 RVA: 0x00ABFB96 File Offset: 0x00ABDD96
		// (set) Token: 0x0602D6CC RID: 186060 RVA: 0x00ABFBAA File Offset: 0x00ABDDAA
		public unsafe TEnumAsByte<EGameplayABPType> Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayABPConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayABPConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BF9 RID: 31737
		// (get) Token: 0x0602D6CD RID: 186061 RVA: 0x00ABFBBF File Offset: 0x00ABDDBF
		// (set) Token: 0x0602D6CE RID: 186062 RVA: 0x00ABFBD3 File Offset: 0x00ABDDD3
		public unsafe FGameplayTag PreloadTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayABPConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayABPConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007BFA RID: 31738
		// (get) Token: 0x0602D6CF RID: 186063 RVA: 0x00ABFBE8 File Offset: 0x00ABDDE8
		// (set) Token: 0x0602D6D0 RID: 186064 RVA: 0x00ABFBFC File Offset: 0x00ABDDFC
		public unsafe FGameplayTag ActiveTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayABPConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayABPConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x0602D6D1 RID: 186065 RVA: 0x00ABFC11 File Offset: 0x00ABDE11
		public SGameplayABPConfig()
		{
		}

		// Token: 0x0602D6D2 RID: 186066 RVA: 0x00ABFC19 File Offset: 0x00ABDE19
		public SGameplayABPConfig(TEnumAsByte<EGameplayABPType> Type, FGameplayTag PreloadTag, FGameplayTag ActiveTag)
		{
			this.Type = Type;
			this.PreloadTag = PreloadTag;
			this.ActiveTag = ActiveTag;
		}

		// Token: 0x0602D6D3 RID: 186067 RVA: 0x00ABFC36 File Offset: 0x00ABDE36
		protected override IntPtr GetUStructPtr()
		{
			return SGameplayABPConfig.StaticStruct();
		}

		// Token: 0x0602D6D4 RID: 186068 RVA: 0x00ABFC42 File Offset: 0x00ABDE42
		[NullableContext(2)]
		public SGameplayABPConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D6D5 RID: 186069 RVA: 0x00ABFC4C File Offset: 0x00ABDE4C
		public SGameplayABPConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D6D6 RID: 186070 RVA: 0x00ABFC57 File Offset: 0x00ABDE57
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGameplayABPConfig(Pointer, false, true);
		}

		// Token: 0x0602D6D7 RID: 186071 RVA: 0x00ABFC61 File Offset: 0x00ABDE61
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGameplayABPConfig(Pointer, MemoryOwner);
		}

		// Token: 0x040197B2 RID: 104370
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/GameplayABP/SGameplayABPConfig.SGameplayABPConfig";

		// Token: 0x040197B3 RID: 104371
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040197B4 RID: 104372
		internal static int __PropertyOffset_0;

		// Token: 0x040197B5 RID: 104373
		internal static int __PropertyOffset_1;

		// Token: 0x040197B6 RID: 104374
		internal static int __PropertyOffset_2;
	}
}
