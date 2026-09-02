using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Interaction.Enum
{
	// Token: 0x02003E8F RID: 16015
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Enum/Struct_InteractTrunkTypes.Struct_InteractTrunkTypes")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class Struct_InteractTrunkTypes : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027AA1 RID: 162465 RVA: 0x009F77B2 File Offset: 0x009F59B2
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_InteractTrunkTypes._ScriptStructPtr != 0) ? Struct_InteractTrunkTypes._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Interaction/Enum/Struct_InteractTrunkTypes.Struct_InteractTrunkTypes", ref Struct_InteractTrunkTypes._ScriptStructPtr);
		}

		// Token: 0x17005E2B RID: 24107
		// (get) Token: 0x06027AA2 RID: 162466 RVA: 0x009F77D6 File Offset: 0x009F59D6
		// (set) Token: 0x06027AA3 RID: 162467 RVA: 0x009F77EA File Offset: 0x009F59EA
		public unsafe UStaticMesh StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTrunkTypes.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTrunkTypes.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17005E2C RID: 24108
		// (get) Token: 0x06027AA4 RID: 162468 RVA: 0x009F77FF File Offset: 0x009F59FF
		// (set) Token: 0x06027AA5 RID: 162469 RVA: 0x009F780F File Offset: 0x009F5A0F
		public unsafe float TrunkMaterialIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)Struct_InteractTrunkTypes.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)Struct_InteractTrunkTypes.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005E2D RID: 24109
		// (get) Token: 0x06027AA6 RID: 162470 RVA: 0x009F7820 File Offset: 0x009F5A20
		// (set) Token: 0x06027AA7 RID: 162471 RVA: 0x009F7834 File Offset: 0x009F5A34
		public unsafe UTexture2D TreePosTexture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTrunkTypes.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_InteractTrunkTypes.__PropertyOffset_2, value);
			}
		}

		// Token: 0x06027AA8 RID: 162472 RVA: 0x009F7849 File Offset: 0x009F5A49
		public Struct_InteractTrunkTypes()
		{
		}

		// Token: 0x06027AA9 RID: 162473 RVA: 0x009F7851 File Offset: 0x009F5A51
		[NullableContext(1)]
		public Struct_InteractTrunkTypes(UStaticMesh StaticMesh, float TrunkMaterialIndex, UTexture2D TreePosTexture)
		{
			this.StaticMesh = StaticMesh;
			this.TrunkMaterialIndex = TrunkMaterialIndex;
			this.TreePosTexture = TreePosTexture;
		}

		// Token: 0x06027AAA RID: 162474 RVA: 0x009F786E File Offset: 0x009F5A6E
		protected override IntPtr GetUStructPtr()
		{
			return Struct_InteractTrunkTypes.StaticStruct();
		}

		// Token: 0x06027AAB RID: 162475 RVA: 0x009F787A File Offset: 0x009F5A7A
		public Struct_InteractTrunkTypes(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027AAC RID: 162476 RVA: 0x009F7884 File Offset: 0x009F5A84
		public Struct_InteractTrunkTypes(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027AAD RID: 162477 RVA: 0x009F788F File Offset: 0x009F5A8F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_InteractTrunkTypes(Pointer, false, true);
		}

		// Token: 0x06027AAE RID: 162478 RVA: 0x009F7899 File Offset: 0x009F5A99
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_InteractTrunkTypes(Pointer, MemoryOwner);
		}

		// Token: 0x04014CE0 RID: 85216
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Interaction/Enum/Struct_InteractTrunkTypes.Struct_InteractTrunkTypes";

		// Token: 0x04014CE1 RID: 85217
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014CE2 RID: 85218
		internal static int __PropertyOffset_0;

		// Token: 0x04014CE3 RID: 85219
		internal static int __PropertyOffset_1;

		// Token: 0x04014CE4 RID: 85220
		internal static int __PropertyOffset_2;
	}
}
