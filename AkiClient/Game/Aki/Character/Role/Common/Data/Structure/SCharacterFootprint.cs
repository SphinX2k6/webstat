using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x0200400A RID: 16394
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/SCharacterFootprint.SCharacterFootprint")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 72)]
	public class SCharacterFootprint : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602A963 RID: 174435 RVA: 0x00A5D593 File Offset: 0x00A5B793
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCharacterFootprint._ScriptStructPtr != 0) ? SCharacterFootprint._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/Common/Data/Structure/SCharacterFootprint.SCharacterFootprint", ref SCharacterFootprint._ScriptStructPtr);
		}

		// Token: 0x17006EE6 RID: 28390
		// (get) Token: 0x0602A964 RID: 174436 RVA: 0x00A5D5B7 File Offset: 0x00A5B7B7
		// (set) Token: 0x0602A965 RID: 174437 RVA: 0x00A5D5CB File Offset: 0x00A5B7CB
		public unsafe FGameplayTag Tag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006EE7 RID: 28391
		// (get) Token: 0x0602A966 RID: 174438 RVA: 0x00A5D5E0 File Offset: 0x00A5B7E0
		// (set) Token: 0x0602A967 RID: 174439 RVA: 0x00A5D5F0 File Offset: 0x00A5B7F0
		public unsafe int SortID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17006EE8 RID: 28392
		// (get) Token: 0x0602A968 RID: 174440 RVA: 0x00A5D601 File Offset: 0x00A5B801
		// (set) Token: 0x0602A969 RID: 174441 RVA: 0x00A5D611 File Offset: 0x00A5B811
		public unsafe int OverrideGlobalFootEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006EE9 RID: 28393
		// (get) Token: 0x0602A96A RID: 174442 RVA: 0x00A5D622 File Offset: 0x00A5B822
		// (set) Token: 0x0602A96B RID: 174443 RVA: 0x00A5D632 File Offset: 0x00A5B832
		public unsafe int OverrideOtherCharacterFootEffect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006EEA RID: 28394
		// (get) Token: 0x0602A96C RID: 174444 RVA: 0x00A5D643 File Offset: 0x00A5B843
		// (set) Token: 0x0602A96D RID: 174445 RVA: 0x00A5D662 File Offset: 0x00A5B862
		public TSoftObjectPtr<UEffectModelBase> Effect
		{
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCharacterFootprint.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602A96E RID: 174446 RVA: 0x00A5D687 File Offset: 0x00A5B887
		public SCharacterFootprint()
		{
		}

		// Token: 0x0602A96F RID: 174447 RVA: 0x00A5D68F File Offset: 0x00A5B88F
		public SCharacterFootprint(FGameplayTag Tag, int SortID, int OverrideGlobalFootEffect, int OverrideOtherCharacterFootEffect, TSoftObjectPtr<UEffectModelBase> Effect)
		{
			this.Tag = Tag;
			this.SortID = SortID;
			this.OverrideGlobalFootEffect = OverrideGlobalFootEffect;
			this.OverrideOtherCharacterFootEffect = OverrideOtherCharacterFootEffect;
			this.Effect = Effect;
		}

		// Token: 0x0602A970 RID: 174448 RVA: 0x00A5D6BC File Offset: 0x00A5B8BC
		protected override IntPtr GetUStructPtr()
		{
			return SCharacterFootprint.StaticStruct();
		}

		// Token: 0x0602A971 RID: 174449 RVA: 0x00A5D6C8 File Offset: 0x00A5B8C8
		[NullableContext(2)]
		public SCharacterFootprint(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A972 RID: 174450 RVA: 0x00A5D6D2 File Offset: 0x00A5B8D2
		public SCharacterFootprint(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A973 RID: 174451 RVA: 0x00A5D6DD File Offset: 0x00A5B8DD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCharacterFootprint(Pointer, false, true);
		}

		// Token: 0x0602A974 RID: 174452 RVA: 0x00A5D6E7 File Offset: 0x00A5B8E7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCharacterFootprint(Pointer, MemoryOwner);
		}

		// Token: 0x04017299 RID: 94873
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/SCharacterFootprint.SCharacterFootprint";

		// Token: 0x0401729A RID: 94874
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401729B RID: 94875
		internal static int __PropertyOffset_0;

		// Token: 0x0401729C RID: 94876
		internal static int __PropertyOffset_1;

		// Token: 0x0401729D RID: 94877
		internal static int __PropertyOffset_2;

		// Token: 0x0401729E RID: 94878
		internal static int __PropertyOffset_3;

		// Token: 0x0401729F RID: 94879
		internal static int __PropertyOffset_4;
	}
}
