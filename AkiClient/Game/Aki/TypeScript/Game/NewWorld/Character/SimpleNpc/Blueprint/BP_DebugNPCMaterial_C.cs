using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.TypeScript.Game.NewWorld.Character.SimpleNpc.Blueprint
{
	// Token: 0x020039BA RID: 14778
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_DebugNPCMaterial.BP_DebugNPCMaterial_C")]
	[UnrealStructLayout(1056, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1056)]
	public class BP_DebugNPCMaterial_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601DDAA RID: 122282 RVA: 0x008E4834 File Offset: 0x008E2A34
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_DebugNPCMaterial_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_DebugNPCMaterial.BP_DebugNPCMaterial_C");
			}
			return BP_DebugNPCMaterial_C._ClassPtr;
		}

		// Token: 0x0601DDAB RID: 122283 RVA: 0x008E4858 File Offset: 0x008E2A58
		public BP_DebugNPCMaterial_C() : this(BuiltinUtils.AllocNativeUObject(BP_DebugNPCMaterial_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601DDAC RID: 122284 RVA: 0x008E4880 File Offset: 0x008E2A80
		[NullableContext(1)]
		public BP_DebugNPCMaterial_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_DebugNPCMaterial_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002781 RID: 10113
		// (get) Token: 0x0601DDAD RID: 122285 RVA: 0x008E48B3 File Offset: 0x008E2AB3
		// (set) Token: 0x0601DDAE RID: 122286 RVA: 0x008E48C7 File Offset: 0x008E2AC7
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002782 RID: 10114
		// (get) Token: 0x0601DDAF RID: 122287 RVA: 0x008E48DC File Offset: 0x008E2ADC
		// (set) Token: 0x0601DDB0 RID: 122288 RVA: 0x008E48F0 File Offset: 0x008E2AF0
		public unsafe AActor NPC
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002783 RID: 10115
		// (get) Token: 0x0601DDB1 RID: 122289 RVA: 0x008E4905 File Offset: 0x008E2B05
		// (set) Token: 0x0601DDB2 RID: 122290 RVA: 0x008E4919 File Offset: 0x008E2B19
		public unsafe PD_HolographicEffect_C Data
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_HolographicEffect_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002784 RID: 10116
		// (get) Token: 0x0601DDB3 RID: 122291 RVA: 0x008E492E File Offset: 0x008E2B2E
		// (set) Token: 0x0601DDB4 RID: 122292 RVA: 0x008E4942 File Offset: 0x008E2B42
		public unsafe BP_NPCMaterialController_C HolographicComponent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_NPCMaterialController_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_DebugNPCMaterial_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0601DDB5 RID: 122293 RVA: 0x008E4957 File Offset: 0x008E2B57
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Remove()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugNPCMaterial_C.__Remove_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDB6 RID: 122294 RVA: 0x008E496B File Offset: 0x008E2B6B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Add()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_DebugNPCMaterial_C.__Add_NativeFunctionPtr, null);
		}

		// Token: 0x0601DDB7 RID: 122295 RVA: 0x008E497F File Offset: 0x008E2B7F
		protected BP_DebugNPCMaterial_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400E9DE RID: 59870
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/TypeScript/Game/NewWorld/Character/SimpleNpc/Blueprint/BP_DebugNPCMaterial.BP_DebugNPCMaterial_C";

		// Token: 0x0400E9DF RID: 59871
		private static IntPtr _ClassPtr;

		// Token: 0x0400E9E0 RID: 59872
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400E9E1 RID: 59873
		internal static int __PropertyOffset_0;

		// Token: 0x0400E9E2 RID: 59874
		internal static int __PropertyOffset_1;

		// Token: 0x0400E9E3 RID: 59875
		internal static int __PropertyOffset_2;

		// Token: 0x0400E9E4 RID: 59876
		internal static int __PropertyOffset_3;

		// Token: 0x0400E9E5 RID: 59877
		private static IntPtr __Remove_NativeFunctionPtr;

		// Token: 0x0400E9E6 RID: 59878
		private static IntPtr __Add_NativeFunctionPtr;
	}
}
