using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.SceneShader.PrismRefractionSky
{
	// Token: 0x02003B7B RID: 15227
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/SceneShader/PrismRefractionSky/BP_PrismRefractionSky.BP_PrismRefractionSky_C")]
	[UnrealStructLayout(1400, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1400)]
	public class BP_PrismRefractionSky_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021900 RID: 137472 RVA: 0x0094CB90 File Offset: 0x0094AD90
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_PrismRefractionSky_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/PrismRefractionSky/BP_PrismRefractionSky.BP_PrismRefractionSky_C");
			}
			return BP_PrismRefractionSky_C._ClassPtr;
		}

		// Token: 0x06021901 RID: 137473 RVA: 0x0094CBB4 File Offset: 0x0094ADB4
		public BP_PrismRefractionSky_C() : this(BuiltinUtils.AllocNativeUObject(BP_PrismRefractionSky_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021902 RID: 137474 RVA: 0x0094CBDC File Offset: 0x0094ADDC
		[NullableContext(1)]
		public BP_PrismRefractionSky_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_PrismRefractionSky_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003BCA RID: 15306
		// (get) Token: 0x06021903 RID: 137475 RVA: 0x0094CC0F File Offset: 0x0094AE0F
		// (set) Token: 0x06021904 RID: 137476 RVA: 0x0094CC23 File Offset: 0x0094AE23
		public unsafe UStaticMeshComponent SM_RefractionSkyBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003BCB RID: 15307
		// (get) Token: 0x06021905 RID: 137477 RVA: 0x0094CC38 File Offset: 0x0094AE38
		// (set) Token: 0x06021906 RID: 137478 RVA: 0x0094CC4C File Offset: 0x0094AE4C
		public unsafe UNiagaraComponent PrismRefractionPolygon
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003BCC RID: 15308
		// (get) Token: 0x06021907 RID: 137479 RVA: 0x0094CC61 File Offset: 0x0094AE61
		// (set) Token: 0x06021908 RID: 137480 RVA: 0x0094CC75 File Offset: 0x0094AE75
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003BCD RID: 15309
		// (get) Token: 0x06021909 RID: 137481 RVA: 0x0094CC8A File Offset: 0x0094AE8A
		// (set) Token: 0x0602190A RID: 137482 RVA: 0x0094CC9A File Offset: 0x0094AE9A
		public unsafe float StaticMeshScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17003BCE RID: 15310
		// (get) Token: 0x0602190B RID: 137483 RVA: 0x0094CCAB File Offset: 0x0094AEAB
		// (set) Token: 0x0602190C RID: 137484 RVA: 0x0094CCBB File Offset: 0x0094AEBB
		public unsafe float Sky_RotationSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17003BCF RID: 15311
		// (get) Token: 0x0602190D RID: 137485 RVA: 0x0094CCCC File Offset: 0x0094AECC
		// (set) Token: 0x0602190E RID: 137486 RVA: 0x0094CCE0 File Offset: 0x0094AEE0
		public unsafe UMaterialInstanceDynamic DMI_SkyBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_5);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17003BD0 RID: 15312
		// (get) Token: 0x0602190F RID: 137487 RVA: 0x0094CCF5 File Offset: 0x0094AEF5
		// (set) Token: 0x06021910 RID: 137488 RVA: 0x0094CD09 File Offset: 0x0094AF09
		public unsafe UMaterialInstance MI_SkyBox
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_PrismRefractionSky_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17003BD1 RID: 15313
		// (get) Token: 0x06021911 RID: 137489 RVA: 0x0094CD1E File Offset: 0x0094AF1E
		// (set) Token: 0x06021912 RID: 137490 RVA: 0x0094CD2E File Offset: 0x0094AF2E
		public unsafe int SpawnCount_Out
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17003BD2 RID: 15314
		// (get) Token: 0x06021913 RID: 137491 RVA: 0x0094CD3F File Offset: 0x0094AF3F
		// (set) Token: 0x06021914 RID: 137492 RVA: 0x0094CD4F File Offset: 0x0094AF4F
		public unsafe int SpawnCount_Internal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17003BD3 RID: 15315
		// (get) Token: 0x06021915 RID: 137493 RVA: 0x0094CD60 File Offset: 0x0094AF60
		// (set) Token: 0x06021916 RID: 137494 RVA: 0x0094CD70 File Offset: 0x0094AF70
		public unsafe float Scale_Out
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17003BD4 RID: 15316
		// (get) Token: 0x06021917 RID: 137495 RVA: 0x0094CD81 File Offset: 0x0094AF81
		// (set) Token: 0x06021918 RID: 137496 RVA: 0x0094CD91 File Offset: 0x0094AF91
		public unsafe float Scale_Internal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17003BD5 RID: 15317
		// (get) Token: 0x06021919 RID: 137497 RVA: 0x0094CDA2 File Offset: 0x0094AFA2
		// (set) Token: 0x0602191A RID: 137498 RVA: 0x0094CDB2 File Offset: 0x0094AFB2
		public unsafe bool _________________________________
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_11) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_11) = (value ? 1 : 0);
			}
		}

		// Token: 0x17003BD6 RID: 15318
		// (get) Token: 0x0602191B RID: 137499 RVA: 0x0094CDC3 File Offset: 0x0094AFC3
		// (set) Token: 0x0602191C RID: 137500 RVA: 0x0094CDD3 File Offset: 0x0094AFD3
		public unsafe float RotationRate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17003BD7 RID: 15319
		// (get) Token: 0x0602191D RID: 137501 RVA: 0x0094CDE4 File Offset: 0x0094AFE4
		// (set) Token: 0x0602191E RID: 137502 RVA: 0x0094CDF8 File Offset: 0x0094AFF8
		public unsafe FVectorDouble WorldLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_PrismRefractionSky_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x0602191F RID: 137503 RVA: 0x0094CE0D File Offset: 0x0094B00D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_PrismRefractionSky_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021920 RID: 137504 RVA: 0x0094CE21 File Offset: 0x0094B021
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_PrismRefractionSky_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021921 RID: 137505 RVA: 0x0094CE36 File Offset: 0x0094B036
		protected BP_PrismRefractionSky_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010E8F RID: 69263
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/SceneShader/PrismRefractionSky/BP_PrismRefractionSky.BP_PrismRefractionSky_C";

		// Token: 0x04010E90 RID: 69264
		private static IntPtr _ClassPtr;

		// Token: 0x04010E91 RID: 69265
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010E92 RID: 69266
		internal static int __PropertyOffset_0;

		// Token: 0x04010E93 RID: 69267
		internal static int __PropertyOffset_1;

		// Token: 0x04010E94 RID: 69268
		internal static int __PropertyOffset_2;

		// Token: 0x04010E95 RID: 69269
		internal static int __PropertyOffset_3;

		// Token: 0x04010E96 RID: 69270
		internal static int __PropertyOffset_4;

		// Token: 0x04010E97 RID: 69271
		internal static int __PropertyOffset_5;

		// Token: 0x04010E98 RID: 69272
		internal static int __PropertyOffset_6;

		// Token: 0x04010E99 RID: 69273
		internal static int __PropertyOffset_7;

		// Token: 0x04010E9A RID: 69274
		internal static int __PropertyOffset_8;

		// Token: 0x04010E9B RID: 69275
		internal static int __PropertyOffset_9;

		// Token: 0x04010E9C RID: 69276
		internal static int __PropertyOffset_10;

		// Token: 0x04010E9D RID: 69277
		internal static int __PropertyOffset_11;

		// Token: 0x04010E9E RID: 69278
		internal static int __PropertyOffset_12;

		// Token: 0x04010E9F RID: 69279
		internal static int __PropertyOffset_13;

		// Token: 0x04010EA0 RID: 69280
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
