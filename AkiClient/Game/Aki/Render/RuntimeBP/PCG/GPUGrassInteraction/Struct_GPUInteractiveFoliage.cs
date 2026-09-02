using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.GPUGrassInteraction
{
	// Token: 0x02003C16 RID: 15382
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/Struct_GPUInteractiveFoliage.Struct_GPUInteractiveFoliage")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class Struct_GPUInteractiveFoliage : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602303B RID: 143419 RVA: 0x0097624F File Offset: 0x0097444F
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (Struct_GPUInteractiveFoliage._ScriptStructPtr != 0) ? Struct_GPUInteractiveFoliage._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/Struct_GPUInteractiveFoliage.Struct_GPUInteractiveFoliage", ref Struct_GPUInteractiveFoliage._ScriptStructPtr);
		}

		// Token: 0x170043F6 RID: 17398
		// (get) Token: 0x0602303C RID: 143420 RVA: 0x00976273 File Offset: 0x00974473
		// (set) Token: 0x0602303D RID: 143421 RVA: 0x00976287 File Offset: 0x00974487
		[Nullable(2)]
		public unsafe UStaticMesh Static_Mesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GPUInteractiveFoliage.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GPUInteractiveFoliage.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170043F7 RID: 17399
		// (get) Token: 0x0602303E RID: 143422 RVA: 0x0097629C File Offset: 0x0097449C
		// (set) Token: 0x0602303F RID: 143423 RVA: 0x009762B0 File Offset: 0x009744B0
		[Nullable(2)]
		public unsafe UHoudiniPointCache Houdini_Point_Cache
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UHoudiniPointCache>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GPUInteractiveFoliage.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GPUInteractiveFoliage.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170043F8 RID: 17400
		// (get) Token: 0x06023040 RID: 143424 RVA: 0x009762C8 File Offset: 0x009744C8
		// (set) Token: 0x06023041 RID: 143425 RVA: 0x0097630B File Offset: 0x0097450B
		public TArray<UMaterialInterface> Interaction_Material
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Interaction_Material) == null)
				{
					result = (this._Interaction_Material = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_GPUInteractiveFoliage.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Interaction_Material.CopyAssign(value);
			}
		}

		// Token: 0x170043F9 RID: 17401
		// (get) Token: 0x06023042 RID: 143426 RVA: 0x0097631C File Offset: 0x0097451C
		// (set) Token: 0x06023043 RID: 143427 RVA: 0x0097635F File Offset: 0x0097455F
		public TArray<UMaterialInterface> Normal_Material
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._Normal_Material) == null)
				{
					result = (this._Normal_Material = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)Struct_GPUInteractiveFoliage.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Normal_Material.CopyAssign(value);
			}
		}

		// Token: 0x170043FA RID: 17402
		// (get) Token: 0x06023044 RID: 143428 RVA: 0x0097636D File Offset: 0x0097456D
		// (set) Token: 0x06023045 RID: 143429 RVA: 0x00976381 File Offset: 0x00974581
		[Nullable(2)]
		public unsafe BP_GPUFoliageInteraction_C Data_Asset
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_GPUFoliageInteraction_C>(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GPUInteractiveFoliage.__PropertyOffset_4);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + Struct_GPUInteractiveFoliage.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06023046 RID: 143430 RVA: 0x00976396 File Offset: 0x00974596
		public Struct_GPUInteractiveFoliage()
		{
		}

		// Token: 0x06023047 RID: 143431 RVA: 0x0097639E File Offset: 0x0097459E
		public Struct_GPUInteractiveFoliage(UStaticMesh Static_Mesh, UHoudiniPointCache Houdini_Point_Cache, TArray<UMaterialInterface> Interaction_Material, TArray<UMaterialInterface> Normal_Material, BP_GPUFoliageInteraction_C Data_Asset)
		{
			this.Static_Mesh = Static_Mesh;
			this.Houdini_Point_Cache = Houdini_Point_Cache;
			this.Interaction_Material = Interaction_Material;
			this.Normal_Material = Normal_Material;
			this.Data_Asset = Data_Asset;
		}

		// Token: 0x06023048 RID: 143432 RVA: 0x009763CB File Offset: 0x009745CB
		protected override IntPtr GetUStructPtr()
		{
			return Struct_GPUInteractiveFoliage.StaticStruct();
		}

		// Token: 0x06023049 RID: 143433 RVA: 0x009763D7 File Offset: 0x009745D7
		[NullableContext(2)]
		public Struct_GPUInteractiveFoliage(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602304A RID: 143434 RVA: 0x009763E1 File Offset: 0x009745E1
		public Struct_GPUInteractiveFoliage(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602304B RID: 143435 RVA: 0x009763EC File Offset: 0x009745EC
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new Struct_GPUInteractiveFoliage(Pointer, false, true);
		}

		// Token: 0x0602304C RID: 143436 RVA: 0x009763F6 File Offset: 0x009745F6
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new Struct_GPUInteractiveFoliage(Pointer, MemoryOwner);
		}

		// Token: 0x04011CB7 RID: 72887
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/GPUGrassInteraction/Struct_GPUInteractiveFoliage.Struct_GPUInteractiveFoliage";

		// Token: 0x04011CB8 RID: 72888
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04011CB9 RID: 72889
		internal static int __PropertyOffset_0;

		// Token: 0x04011CBA RID: 72890
		internal static int __PropertyOffset_1;

		// Token: 0x04011CBB RID: 72891
		internal static int __PropertyOffset_2;

		// Token: 0x04011CBC RID: 72892
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Interaction_Material;

		// Token: 0x04011CBD RID: 72893
		internal static int __PropertyOffset_3;

		// Token: 0x04011CBE RID: 72894
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _Normal_Material;

		// Token: 0x04011CBF RID: 72895
		internal static int __PropertyOffset_4;
	}
}
