using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SoftMesh
{
	// Token: 0x02003B6F RID: 15215
	[NullableContext(2)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/S_SoftMeshPreset.S_SoftMeshPreset")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class S_SoftMeshPreset : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060217E1 RID: 137185 RVA: 0x0094AC28 File Offset: 0x00948E28
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (S_SoftMeshPreset._ScriptStructPtr != 0) ? S_SoftMeshPreset._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/S_SoftMeshPreset.S_SoftMeshPreset", ref S_SoftMeshPreset._ScriptStructPtr);
		}

		// Token: 0x17003B72 RID: 15218
		// (get) Token: 0x060217E2 RID: 137186 RVA: 0x0094AC4C File Offset: 0x00948E4C
		// (set) Token: 0x060217E3 RID: 137187 RVA: 0x0094AC60 File Offset: 0x00948E60
		public unsafe UHoudiniPointCache HPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + S_SoftMeshPreset.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_SoftMeshPreset.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003B73 RID: 15219
		// (get) Token: 0x060217E4 RID: 137188 RVA: 0x0094AC75 File Offset: 0x00948E75
		// (set) Token: 0x060217E5 RID: 137189 RVA: 0x0094AC85 File Offset: 0x00948E85
		public unsafe float TightNess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)S_SoftMeshPreset.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)S_SoftMeshPreset.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17003B74 RID: 15220
		// (get) Token: 0x060217E6 RID: 137190 RVA: 0x0094AC96 File Offset: 0x00948E96
		// (set) Token: 0x060217E7 RID: 137191 RVA: 0x0094ACAA File Offset: 0x00948EAA
		public unsafe UMaterialInstance InputMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + S_SoftMeshPreset.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + S_SoftMeshPreset.__PropertyOffset_2, value);
			}
		}

		// Token: 0x060217E8 RID: 137192 RVA: 0x0094ACBF File Offset: 0x00948EBF
		public S_SoftMeshPreset()
		{
		}

		// Token: 0x060217E9 RID: 137193 RVA: 0x0094ACC7 File Offset: 0x00948EC7
		[NullableContext(1)]
		public S_SoftMeshPreset(UHoudiniPointCache HPC, float TightNess, UMaterialInstance InputMat)
		{
			this.HPC = HPC;
			this.TightNess = TightNess;
			this.InputMat = InputMat;
		}

		// Token: 0x060217EA RID: 137194 RVA: 0x0094ACE4 File Offset: 0x00948EE4
		protected override IntPtr GetUStructPtr()
		{
			return S_SoftMeshPreset.StaticStruct();
		}

		// Token: 0x060217EB RID: 137195 RVA: 0x0094ACF0 File Offset: 0x00948EF0
		public S_SoftMeshPreset(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060217EC RID: 137196 RVA: 0x0094ACFA File Offset: 0x00948EFA
		public S_SoftMeshPreset(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060217ED RID: 137197 RVA: 0x0094AD05 File Offset: 0x00948F05
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new S_SoftMeshPreset(Pointer, false, true);
		}

		// Token: 0x060217EE RID: 137198 RVA: 0x0094AD0F File Offset: 0x00948F0F
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new S_SoftMeshPreset(Pointer, MemoryOwner);
		}

		// Token: 0x04010DDF RID: 69087
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SoftMesh/S_SoftMeshPreset.S_SoftMeshPreset";

		// Token: 0x04010DE0 RID: 69088
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04010DE1 RID: 69089
		internal static int __PropertyOffset_0;

		// Token: 0x04010DE2 RID: 69090
		internal static int __PropertyOffset_1;

		// Token: 0x04010DE3 RID: 69091
		internal static int __PropertyOffset_2;
	}
}
