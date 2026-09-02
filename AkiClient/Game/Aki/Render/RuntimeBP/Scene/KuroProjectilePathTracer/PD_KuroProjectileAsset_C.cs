using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.KuroProjectilePathTracer
{
	// Token: 0x02003AB6 RID: 15030
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/PD_KuroProjectileAsset.PD_KuroProjectileAsset_C")]
	[UnrealStructLayout(128, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 128)]
	public class PD_KuroProjectileAsset_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020120 RID: 131360 RVA: 0x00921634 File Offset: 0x0091F834
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PD_KuroProjectileAsset_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/PD_KuroProjectileAsset.PD_KuroProjectileAsset_C");
			}
			return PD_KuroProjectileAsset_C._ClassPtr;
		}

		// Token: 0x06020121 RID: 131361 RVA: 0x00921658 File Offset: 0x0091F858
		public PD_KuroProjectileAsset_C() : this(BuiltinUtils.AllocNativeUObject(PD_KuroProjectileAsset_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020122 RID: 131362 RVA: 0x00921680 File Offset: 0x0091F880
		[NullableContext(1)]
		public PD_KuroProjectileAsset_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PD_KuroProjectileAsset_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170033C9 RID: 13257
		// (get) Token: 0x06020123 RID: 131363 RVA: 0x009216B3 File Offset: 0x0091F8B3
		// (set) Token: 0x06020124 RID: 131364 RVA: 0x009216C7 File Offset: 0x0091F8C7
		public unsafe UStaticMesh DistanceRocordMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMesh>(base.NativePtr / (IntPtr)sizeof(void*) + PD_KuroProjectileAsset_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_KuroProjectileAsset_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170033CA RID: 13258
		// (get) Token: 0x06020125 RID: 131365 RVA: 0x009216DC File Offset: 0x0091F8DC
		// (set) Token: 0x06020126 RID: 131366 RVA: 0x009216EC File Offset: 0x0091F8EC
		public unsafe float DisplayDistancePerRecord
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170033CB RID: 13259
		// (get) Token: 0x06020127 RID: 131367 RVA: 0x009216FD File Offset: 0x0091F8FD
		// (set) Token: 0x06020128 RID: 131368 RVA: 0x0092170D File Offset: 0x0091F90D
		public unsafe int MaxPlaceCount
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170033CC RID: 13260
		// (get) Token: 0x06020129 RID: 131369 RVA: 0x0092171E File Offset: 0x0091F91E
		// (set) Token: 0x0602012A RID: 131370 RVA: 0x0092172E File Offset: 0x0091F92E
		public unsafe float RecordDeltaAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170033CD RID: 13261
		// (get) Token: 0x0602012B RID: 131371 RVA: 0x0092173F File Offset: 0x0091F93F
		// (set) Token: 0x0602012C RID: 131372 RVA: 0x0092174F File Offset: 0x0091F94F
		public unsafe float TargetDeltaAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170033CE RID: 13262
		// (get) Token: 0x0602012D RID: 131373 RVA: 0x00921760 File Offset: 0x0091F960
		// (set) Token: 0x0602012E RID: 131374 RVA: 0x00921770 File Offset: 0x0091F970
		public unsafe float TargetSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170033CF RID: 13263
		// (get) Token: 0x0602012F RID: 131375 RVA: 0x00921781 File Offset: 0x0091F981
		// (set) Token: 0x06020130 RID: 131376 RVA: 0x00921791 File Offset: 0x0091F991
		public unsafe float TargetThreshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170033D0 RID: 13264
		// (get) Token: 0x06020131 RID: 131377 RVA: 0x009217A2 File Offset: 0x0091F9A2
		// (set) Token: 0x06020132 RID: 131378 RVA: 0x009217B2 File Offset: 0x0091F9B2
		public unsafe float AnimationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170033D1 RID: 13265
		// (get) Token: 0x06020133 RID: 131379 RVA: 0x009217C3 File Offset: 0x0091F9C3
		// (set) Token: 0x06020134 RID: 131380 RVA: 0x009217D3 File Offset: 0x0091F9D3
		public unsafe float RecordSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)PD_KuroProjectileAsset_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x170033D2 RID: 13266
		// (get) Token: 0x06020135 RID: 131381 RVA: 0x009217E4 File Offset: 0x0091F9E4
		// (set) Token: 0x06020136 RID: 131382 RVA: 0x009217F8 File Offset: 0x0091F9F8
		public unsafe UMaterialInstance TargetDecalMat
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + PD_KuroProjectileAsset_C.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + PD_KuroProjectileAsset_C.__PropertyOffset_9, value);
			}
		}

		// Token: 0x06020137 RID: 131383 RVA: 0x0092180D File Offset: 0x0091FA0D
		protected PD_KuroProjectileAsset_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400FF9E RID: 65438
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/KuroProjectilePathTracer/PD_KuroProjectileAsset.PD_KuroProjectileAsset_C";

		// Token: 0x0400FF9F RID: 65439
		private static IntPtr _ClassPtr;

		// Token: 0x0400FFA0 RID: 65440
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400FFA1 RID: 65441
		internal static int __PropertyOffset_0;

		// Token: 0x0400FFA2 RID: 65442
		internal static int __PropertyOffset_1;

		// Token: 0x0400FFA3 RID: 65443
		internal static int __PropertyOffset_2;

		// Token: 0x0400FFA4 RID: 65444
		internal static int __PropertyOffset_3;

		// Token: 0x0400FFA5 RID: 65445
		internal static int __PropertyOffset_4;

		// Token: 0x0400FFA6 RID: 65446
		internal static int __PropertyOffset_5;

		// Token: 0x0400FFA7 RID: 65447
		internal static int __PropertyOffset_6;

		// Token: 0x0400FFA8 RID: 65448
		internal static int __PropertyOffset_7;

		// Token: 0x0400FFA9 RID: 65449
		internal static int __PropertyOffset_8;

		// Token: 0x0400FFAA RID: 65450
		internal static int __PropertyOffset_9;
	}
}
