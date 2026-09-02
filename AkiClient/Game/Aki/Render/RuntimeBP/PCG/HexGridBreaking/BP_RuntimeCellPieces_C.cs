using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.HexGridBreaking
{
	// Token: 0x02003C11 RID: 15377
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_RuntimeCellPieces.BP_RuntimeCellPieces_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_RuntimeCellPieces_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06022F82 RID: 143234 RVA: 0x00974A97 File Offset: 0x00972C97
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RuntimeCellPieces_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_RuntimeCellPieces.BP_RuntimeCellPieces_C");
			}
			return BP_RuntimeCellPieces_C._ClassPtr;
		}

		// Token: 0x06022F83 RID: 143235 RVA: 0x00974ABC File Offset: 0x00972CBC
		public BP_RuntimeCellPieces_C() : this(BuiltinUtils.AllocNativeUObject(BP_RuntimeCellPieces_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06022F84 RID: 143236 RVA: 0x00974AE4 File Offset: 0x00972CE4
		[NullableContext(1)]
		public BP_RuntimeCellPieces_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RuntimeCellPieces_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170043B7 RID: 17335
		// (get) Token: 0x06022F85 RID: 143237 RVA: 0x00974B17 File Offset: 0x00972D17
		// (set) Token: 0x06022F86 RID: 143238 RVA: 0x00974B2B File Offset: 0x00972D2B
		public unsafe UStaticMeshComponent StaticMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RuntimeCellPieces_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RuntimeCellPieces_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170043B8 RID: 17336
		// (get) Token: 0x06022F87 RID: 143239 RVA: 0x00974B40 File Offset: 0x00972D40
		// (set) Token: 0x06022F88 RID: 143240 RVA: 0x00974B54 File Offset: 0x00972D54
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_RuntimeCellPieces_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_RuntimeCellPieces_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06022F89 RID: 143241 RVA: 0x00974B69 File Offset: 0x00972D69
		protected BP_RuntimeCellPieces_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011C3E RID: 72766
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/HexGridBreaking/BP_RuntimeCellPieces.BP_RuntimeCellPieces_C";

		// Token: 0x04011C3F RID: 72767
		private static IntPtr _ClassPtr;

		// Token: 0x04011C40 RID: 72768
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011C41 RID: 72769
		internal static int __PropertyOffset_0;

		// Token: 0x04011C42 RID: 72770
		internal static int __PropertyOffset_1;
	}
}
