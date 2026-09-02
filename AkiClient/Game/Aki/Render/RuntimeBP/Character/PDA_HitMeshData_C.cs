using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character
{
	// Token: 0x02003D5B RID: 15707
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/PDA_HitMeshData.PDA_HitMeshData_C")]
	[UnrealStructLayout(160, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 148)]
	public class PDA_HitMeshData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060262E1 RID: 156385 RVA: 0x009D0243 File Offset: 0x009CE443
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_HitMeshData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Character/PDA_HitMeshData.PDA_HitMeshData_C");
			}
			return PDA_HitMeshData_C._ClassPtr;
		}

		// Token: 0x060262E2 RID: 156386 RVA: 0x009D0268 File Offset: 0x009CE468
		public PDA_HitMeshData_C() : this(BuiltinUtils.AllocNativeUObject(PDA_HitMeshData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060262E3 RID: 156387 RVA: 0x009D0290 File Offset: 0x009CE490
		[NullableContext(1)]
		public PDA_HitMeshData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_HitMeshData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170055E0 RID: 21984
		// (get) Token: 0x060262E4 RID: 156388 RVA: 0x009D02C3 File Offset: 0x009CE4C3
		// (set) Token: 0x060262E5 RID: 156389 RVA: 0x009D02D7 File Offset: 0x009CE4D7
		[Nullable(2)]
		public unsafe USkeletalMesh HitSkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PDA_HitMeshData_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PDA_HitMeshData_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170055E1 RID: 21985
		// (get) Token: 0x060262E6 RID: 156390 RVA: 0x009D02EC File Offset: 0x009CE4EC
		// (set) Token: 0x060262E7 RID: 156391 RVA: 0x009D0300 File Offset: 0x009CE500
		public unsafe FTransform HitSkeletalMeshTransform
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_HitMeshData_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_HitMeshData_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170055E2 RID: 21986
		// (get) Token: 0x060262E8 RID: 156392 RVA: 0x009D0315 File Offset: 0x009CE515
		// (set) Token: 0x060262E9 RID: 156393 RVA: 0x009D0325 File Offset: 0x009CE525
		public unsafe float LastTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PDA_HitMeshData_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PDA_HitMeshData_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x060262EA RID: 156394 RVA: 0x009D0336 File Offset: 0x009CE536
		protected PDA_HitMeshData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013C7B RID: 81019
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/PDA_HitMeshData.PDA_HitMeshData_C";

		// Token: 0x04013C7C RID: 81020
		private static IntPtr _ClassPtr;

		// Token: 0x04013C7D RID: 81021
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013C7E RID: 81022
		internal static int __PropertyOffset_0;

		// Token: 0x04013C7F RID: 81023
		internal static int __PropertyOffset_1;

		// Token: 0x04013C80 RID: 81024
		internal static int __PropertyOffset_2;
	}
}
