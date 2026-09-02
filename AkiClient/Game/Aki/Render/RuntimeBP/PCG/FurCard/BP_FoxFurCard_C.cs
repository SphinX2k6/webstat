using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.FurCard
{
	// Token: 0x02003C32 RID: 15410
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/FurCard/BP_FoxFurCard.BP_FoxFurCard_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1056)]
	public class BP_FoxFurCard_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060234F8 RID: 144632 RVA: 0x0097E6FE File Offset: 0x0097C8FE
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FoxFurCard_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/FurCard/BP_FoxFurCard.BP_FoxFurCard_C");
			}
			return BP_FoxFurCard_C._ClassPtr;
		}

		// Token: 0x060234F9 RID: 144633 RVA: 0x0097E724 File Offset: 0x0097C924
		public BP_FoxFurCard_C() : this(BuiltinUtils.AllocNativeUObject(BP_FoxFurCard_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060234FA RID: 144634 RVA: 0x0097E74C File Offset: 0x0097C94C
		[NullableContext(1)]
		public BP_FoxFurCard_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FoxFurCard_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170045B1 RID: 17841
		// (get) Token: 0x060234FB RID: 144635 RVA: 0x0097E77F File Offset: 0x0097C97F
		// (set) Token: 0x060234FC RID: 144636 RVA: 0x0097E793 File Offset: 0x0097C993
		public unsafe UStaticMeshComponent SM_Fur
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170045B2 RID: 17842
		// (get) Token: 0x060234FD RID: 144637 RVA: 0x0097E7A8 File Offset: 0x0097C9A8
		// (set) Token: 0x060234FE RID: 144638 RVA: 0x0097E7BC File Offset: 0x0097C9BC
		public unsafe UStaticMeshComponent SM_Fur_02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170045B3 RID: 17843
		// (get) Token: 0x060234FF RID: 144639 RVA: 0x0097E7D1 File Offset: 0x0097C9D1
		// (set) Token: 0x06023500 RID: 144640 RVA: 0x0097E7E5 File Offset: 0x0097C9E5
		public unsafe UStaticMeshComponent SM_Gel_Pro_176AS
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170045B4 RID: 17844
		// (get) Token: 0x06023501 RID: 144641 RVA: 0x0097E7FA File Offset: 0x0097C9FA
		// (set) Token: 0x06023502 RID: 144642 RVA: 0x0097E80E File Offset: 0x0097CA0E
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FoxFurCard_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06023503 RID: 144643 RVA: 0x0097E823 File Offset: 0x0097CA23
		protected BP_FoxFurCard_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04011F67 RID: 73575
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/FurCard/BP_FoxFurCard.BP_FoxFurCard_C";

		// Token: 0x04011F68 RID: 73576
		private static IntPtr _ClassPtr;

		// Token: 0x04011F69 RID: 73577
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04011F6A RID: 73578
		internal static int __PropertyOffset_0;

		// Token: 0x04011F6B RID: 73579
		internal static int __PropertyOffset_1;

		// Token: 0x04011F6C RID: 73580
		internal static int __PropertyOffset_2;

		// Token: 0x04011F6D RID: 73581
		internal static int __PropertyOffset_3;
	}
}
