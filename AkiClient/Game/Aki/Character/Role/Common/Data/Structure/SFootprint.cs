using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Role.Common.Data.Structure
{
	// Token: 0x0200400B RID: 16395
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/Role/Common/Data/Structure/SFootprint.SFootprint")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 57)]
	public class SFootprint : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602A975 RID: 174453 RVA: 0x00A5D6F0 File Offset: 0x00A5B8F0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFootprint._ScriptStructPtr != 0) ? SFootprint._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Role/Common/Data/Structure/SFootprint.SFootprint", ref SFootprint._ScriptStructPtr);
		}

		// Token: 0x17006EEB RID: 28395
		// (get) Token: 0x0602A976 RID: 174454 RVA: 0x00A5D714 File Offset: 0x00A5B914
		// (set) Token: 0x0602A977 RID: 174455 RVA: 0x00A5D728 File Offset: 0x00A5B928
		public unsafe TEnumAsByte<EPhysicalSurface> SurfaceType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootprint.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootprint.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006EEC RID: 28396
		// (get) Token: 0x0602A978 RID: 174456 RVA: 0x00A5D73D File Offset: 0x00A5B93D
		// (set) Token: 0x0602A979 RID: 174457 RVA: 0x00A5D75C File Offset: 0x00A5B95C
		[Nullable(1)]
		public TSoftObjectPtr<UEffectModelBase> Effect
		{
			[NullableContext(1)]
			get
			{
				return new TSoftObjectPtr<UEffectModelBase>(base.NativePtr + (IntPtr)SFootprint.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			[NullableContext(1)]
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SFootprint.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17006EED RID: 28397
		// (get) Token: 0x0602A97A RID: 174458 RVA: 0x00A5D781 File Offset: 0x00A5B981
		// (set) Token: 0x0602A97B RID: 174459 RVA: 0x00A5D791 File Offset: 0x00A5B991
		public unsafe bool PriorToGlobal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootprint.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootprint.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602A97C RID: 174460 RVA: 0x00A5D7A2 File Offset: 0x00A5B9A2
		public SFootprint()
		{
		}

		// Token: 0x0602A97D RID: 174461 RVA: 0x00A5D7AA File Offset: 0x00A5B9AA
		public SFootprint(TEnumAsByte<EPhysicalSurface> SurfaceType, [Nullable(1)] TSoftObjectPtr<UEffectModelBase> Effect, bool PriorToGlobal)
		{
			this.SurfaceType = SurfaceType;
			this.Effect = Effect;
			this.PriorToGlobal = PriorToGlobal;
		}

		// Token: 0x0602A97E RID: 174462 RVA: 0x00A5D7C7 File Offset: 0x00A5B9C7
		protected override IntPtr GetUStructPtr()
		{
			return SFootprint.StaticStruct();
		}

		// Token: 0x0602A97F RID: 174463 RVA: 0x00A5D7D3 File Offset: 0x00A5B9D3
		[NullableContext(2)]
		public SFootprint(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602A980 RID: 174464 RVA: 0x00A5D7DD File Offset: 0x00A5B9DD
		public SFootprint(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602A981 RID: 174465 RVA: 0x00A5D7E8 File Offset: 0x00A5B9E8
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFootprint(Pointer, false, true);
		}

		// Token: 0x0602A982 RID: 174466 RVA: 0x00A5D7F2 File Offset: 0x00A5B9F2
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFootprint(Pointer, MemoryOwner);
		}

		// Token: 0x040172A0 RID: 94880
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Character/Role/Common/Data/Structure/SFootprint.SFootprint";

		// Token: 0x040172A1 RID: 94881
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040172A2 RID: 94882
		internal static int __PropertyOffset_0;

		// Token: 0x040172A3 RID: 94883
		internal static int __PropertyOffset_1;

		// Token: 0x040172A4 RID: 94884
		internal static int __PropertyOffset_2;
	}
}
