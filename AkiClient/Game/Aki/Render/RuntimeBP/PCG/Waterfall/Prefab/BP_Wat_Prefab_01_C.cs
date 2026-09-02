using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.Waterfall.Prefab
{
	// Token: 0x02003B57 RID: 15191
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/Waterfall/Prefab/BP_Wat_Prefab_01.BP_Wat_Prefab_01_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1076)]
	public class BP_Wat_Prefab_01_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06021266 RID: 135782 RVA: 0x00941274 File Offset: 0x0093F474
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_Wat_Prefab_01_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/PCG/Waterfall/Prefab/BP_Wat_Prefab_01.BP_Wat_Prefab_01_C");
			}
			return BP_Wat_Prefab_01_C._ClassPtr;
		}

		// Token: 0x06021267 RID: 135783 RVA: 0x00941298 File Offset: 0x0093F498
		public BP_Wat_Prefab_01_C() : this(BuiltinUtils.AllocNativeUObject(BP_Wat_Prefab_01_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06021268 RID: 135784 RVA: 0x009412C0 File Offset: 0x0093F4C0
		[NullableContext(1)]
		public BP_Wat_Prefab_01_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_Wat_Prefab_01_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700396F RID: 14703
		// (get) Token: 0x06021269 RID: 135785 RVA: 0x009412F3 File Offset: 0x0093F4F3
		// (set) Token: 0x0602126A RID: 135786 RVA: 0x00941307 File Offset: 0x0093F507
		public unsafe UStaticMeshComponent SM_Wat_Seq_02
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17003970 RID: 14704
		// (get) Token: 0x0602126B RID: 135787 RVA: 0x0094131C File Offset: 0x0093F51C
		// (set) Token: 0x0602126C RID: 135788 RVA: 0x00941330 File Offset: 0x0093F530
		public unsafe UArrowComponent Arrow
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UArrowComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17003971 RID: 14705
		// (get) Token: 0x0602126D RID: 135789 RVA: 0x00941345 File Offset: 0x0093F545
		// (set) Token: 0x0602126E RID: 135790 RVA: 0x00941359 File Offset: 0x0093F559
		public unsafe UBillboardComponent Billboard
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBillboardComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17003972 RID: 14706
		// (get) Token: 0x0602126F RID: 135791 RVA: 0x0094136E File Offset: 0x0093F56E
		// (set) Token: 0x06021270 RID: 135792 RVA: 0x00941382 File Offset: 0x0093F582
		public unsafe UNiagaraComponent Niagara
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UNiagaraComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x17003973 RID: 14707
		// (get) Token: 0x06021271 RID: 135793 RVA: 0x00941397 File Offset: 0x0093F597
		// (set) Token: 0x06021272 RID: 135794 RVA: 0x009413AB File Offset: 0x0093F5AB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_Wat_Prefab_01_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17003974 RID: 14708
		// (get) Token: 0x06021273 RID: 135795 RVA: 0x009413C0 File Offset: 0x0093F5C0
		// (set) Token: 0x06021274 RID: 135796 RVA: 0x009413D0 File Offset: 0x0093F5D0
		public unsafe float 粒子范围
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Wat_Prefab_01_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Wat_Prefab_01_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17003975 RID: 14709
		// (get) Token: 0x06021275 RID: 135797 RVA: 0x009413E1 File Offset: 0x0093F5E1
		// (set) Token: 0x06021276 RID: 135798 RVA: 0x009413F1 File Offset: 0x0093F5F1
		public unsafe float 粒子寿命
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Wat_Prefab_01_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Wat_Prefab_01_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17003976 RID: 14710
		// (get) Token: 0x06021277 RID: 135799 RVA: 0x00941402 File Offset: 0x0093F602
		// (set) Token: 0x06021278 RID: 135800 RVA: 0x00941412 File Offset: 0x0093F612
		public unsafe float 粒子数量
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_Wat_Prefab_01_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_Wat_Prefab_01_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x06021279 RID: 135801 RVA: 0x00941423 File Offset: 0x0093F623
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_Wat_Prefab_01_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602127A RID: 135802 RVA: 0x00941437 File Offset: 0x0093F637
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_Wat_Prefab_01_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602127B RID: 135803 RVA: 0x0094144C File Offset: 0x0093F64C
		protected BP_Wat_Prefab_01_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04010A80 RID: 68224
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/PCG/Waterfall/Prefab/BP_Wat_Prefab_01.BP_Wat_Prefab_01_C";

		// Token: 0x04010A81 RID: 68225
		private static IntPtr _ClassPtr;

		// Token: 0x04010A82 RID: 68226
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04010A83 RID: 68227
		internal static int __PropertyOffset_0;

		// Token: 0x04010A84 RID: 68228
		internal static int __PropertyOffset_1;

		// Token: 0x04010A85 RID: 68229
		internal static int __PropertyOffset_2;

		// Token: 0x04010A86 RID: 68230
		internal static int __PropertyOffset_3;

		// Token: 0x04010A87 RID: 68231
		internal static int __PropertyOffset_4;

		// Token: 0x04010A88 RID: 68232
		internal static int __PropertyOffset_5;

		// Token: 0x04010A89 RID: 68233
		internal static int __PropertyOffset_6;

		// Token: 0x04010A8A RID: 68234
		internal static int __PropertyOffset_7;

		// Token: 0x04010A8B RID: 68235
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;
	}
}
