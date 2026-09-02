using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Waterfall.Prefab
{
	// Token: 0x02003B58 RID: 15192
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Waterfall/Prefab/BP_Wat_Prefab_02.BP_Wat_Prefab_02_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1076)]
	public class BP_Wat_Prefab_02_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602127C RID: 135804 RVA: 0x00941455 File Offset: 0x0093F655
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Wat_Prefab_02_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Waterfall/Prefab/BP_Wat_Prefab_02.BP_Wat_Prefab_02_C");
			}
			return BP_Wat_Prefab_02_C._ClassPtr;
		}

		// Token: 0x0602127D RID: 135805 RVA: 0x0094147C File Offset: 0x0093F67C
		public BP_Wat_Prefab_02_C() : this(BuiltinUtils.AllocNativeUObject(BP_Wat_Prefab_02_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602127E RID: 135806 RVA: 0x009414A4 File Offset: 0x0093F6A4
		[NullableContext(1)]
		public BP_Wat_Prefab_02_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Wat_Prefab_02_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003977 RID: 14711
		// (get) Token: 0x0602127F RID: 135807 RVA: 0x009414D7 File Offset: 0x0093F6D7
		// (set) Token: 0x06021280 RID: 135808 RVA: 0x009414EB File Offset: 0x0093F6EB
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003978 RID: 14712
		// (get) Token: 0x06021281 RID: 135809 RVA: 0x00941500 File Offset: 0x0093F700
		// (set) Token: 0x06021282 RID: 135810 RVA: 0x00941514 File Offset: 0x0093F714
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003979 RID: 14713
		// (get) Token: 0x06021283 RID: 135811 RVA: 0x00941529 File Offset: 0x0093F729
		// (set) Token: 0x06021284 RID: 135812 RVA: 0x0094153D File Offset: 0x0093F73D
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700397A RID: 14714
		// (get) Token: 0x06021285 RID: 135813 RVA: 0x00941552 File Offset: 0x0093F752
		// (set) Token: 0x06021286 RID: 135814 RVA: 0x00941566 File Offset: 0x0093F766
		public unsafe UStaticMeshComponent SM_Wat_Seq_01
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700397B RID: 14715
		// (get) Token: 0x06021287 RID: 135815 RVA: 0x0094157B File Offset: 0x0093F77B
		// (set) Token: 0x06021288 RID: 135816 RVA: 0x0094158F File Offset: 0x0093F78F
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_02_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x1700397C RID: 14716
		// (get) Token: 0x06021289 RID: 135817 RVA: 0x009415A4 File Offset: 0x0093F7A4
		// (set) Token: 0x0602128A RID: 135818 RVA: 0x009415B4 File Offset: 0x0093F7B4
		public unsafe float 粒子数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Wat_Prefab_02_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Wat_Prefab_02_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700397D RID: 14717
		// (get) Token: 0x0602128B RID: 135819 RVA: 0x009415C5 File Offset: 0x0093F7C5
		// (set) Token: 0x0602128C RID: 135820 RVA: 0x009415D5 File Offset: 0x0093F7D5
		public unsafe float 粒子范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Wat_Prefab_02_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Wat_Prefab_02_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700397E RID: 14718
		// (get) Token: 0x0602128D RID: 135821 RVA: 0x009415E6 File Offset: 0x0093F7E6
		// (set) Token: 0x0602128E RID: 135822 RVA: 0x009415F6 File Offset: 0x0093F7F6
		public unsafe float 粒子寿命
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Wat_Prefab_02_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Wat_Prefab_02_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602128F RID: 135823 RVA: 0x00941607 File Offset: 0x0093F807
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Wat_Prefab_02_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06021290 RID: 135824 RVA: 0x0094161B File Offset: 0x0093F81B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Wat_Prefab_02_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06021291 RID: 135825 RVA: 0x00941630 File Offset: 0x0093F830
		protected BP_Wat_Prefab_02_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A8C RID: 68236
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Waterfall/Prefab/BP_Wat_Prefab_02.BP_Wat_Prefab_02_C";

		// Token: 0x04010A8D RID: 68237
		private static IntPtr _ClassPtr;

		// Token: 0x04010A8E RID: 68238
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A8F RID: 68239
		internal static int __PropertyOffset_0;

		// Token: 0x04010A90 RID: 68240
		internal static int __PropertyOffset_1;

		// Token: 0x04010A91 RID: 68241
		internal static int __PropertyOffset_2;

		// Token: 0x04010A92 RID: 68242
		internal static int __PropertyOffset_3;

		// Token: 0x04010A93 RID: 68243
		internal static int __PropertyOffset_4;

		// Token: 0x04010A94 RID: 68244
		internal static int __PropertyOffset_5;

		// Token: 0x04010A95 RID: 68245
		internal static int __PropertyOffset_6;

		// Token: 0x04010A96 RID: 68246
		internal static int __PropertyOffset_7;

		// Token: 0x04010A97 RID: 68247
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
