using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.GamePlay.StaticSceneInteraction
{
	// Token: 0x02003DC7 RID: 15815
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/GamePlay/StaticSceneInteraction/BP_GlobalGameplayPostProcess.BP_GlobalGameplayPostProcess_C")]
	[UnrealStructLayout(1040, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1040)]
	public class BP_GlobalGameplayPostProcess_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026B99 RID: 158617 RVA: 0x009E060F File Offset: 0x009DE80F
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_GlobalGameplayPostProcess_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/GamePlay/StaticSceneInteraction/BP_GlobalGameplayPostProcess.BP_GlobalGameplayPostProcess_C");
			}
			return BP_GlobalGameplayPostProcess_C._ClassPtr;
		}

		// Token: 0x06026B9A RID: 158618 RVA: 0x009E0634 File Offset: 0x009DE834
		public BP_GlobalGameplayPostProcess_C() : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGameplayPostProcess_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026B9B RID: 158619 RVA: 0x009E065C File Offset: 0x009DE85C
		[NullableContext(1)]
		public BP_GlobalGameplayPostProcess_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_GlobalGameplayPostProcess_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170058CA RID: 22730
		// (get) Token: 0x06026B9C RID: 158620 RVA: 0x009E068F File Offset: 0x009DE88F
		// (set) Token: 0x06026B9D RID: 158621 RVA: 0x009E06A3 File Offset: 0x009DE8A3
		public unsafe UKuroPostProcessComponent KuroPostProcess
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroPostProcessComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGameplayPostProcess_C.__PropertyOffset_0);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGameplayPostProcess_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x170058CB RID: 22731
		// (get) Token: 0x06026B9E RID: 158622 RVA: 0x009E06B8 File Offset: 0x009DE8B8
		// (set) Token: 0x06026B9F RID: 158623 RVA: 0x009E06CC File Offset: 0x009DE8CC
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGameplayPostProcess_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_GlobalGameplayPostProcess_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x06026BA0 RID: 158624 RVA: 0x009E06E4 File Offset: 0x009DE8E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void UpdateVignette(float Vignette_Intensity)
		{
			BP_GlobalGameplayPostProcess_C.__UpdateVignette_FunctionParams* ptr = stackalloc BP_GlobalGameplayPostProcess_C.__UpdateVignette_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_GlobalGameplayPostProcess_C.__UpdateVignette_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_GlobalGameplayPostProcess_C.__UpdateVignette_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Vignette_Intensity = Vignette_Intensity;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_GlobalGameplayPostProcess_C.__UpdateVignette_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026BA1 RID: 158625 RVA: 0x009E072A File Offset: 0x009DE92A
		protected BP_GlobalGameplayPostProcess_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014320 RID: 82720
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/GamePlay/StaticSceneInteraction/BP_GlobalGameplayPostProcess.BP_GlobalGameplayPostProcess_C";

		// Token: 0x04014321 RID: 82721
		private static IntPtr _ClassPtr;

		// Token: 0x04014322 RID: 82722
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014323 RID: 82723
		internal static int __PropertyOffset_0;

		// Token: 0x04014324 RID: 82724
		internal static int __PropertyOffset_1;

		// Token: 0x04014325 RID: 82725
		private static IntPtr __UpdateVignette_NativeFunctionPtr;

		// Token: 0x0200A0B2 RID: 41138
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __UpdateVignette_FunctionParams
		{
			// Token: 0x04032D62 RID: 208226
			[FieldOffset(0)]
			public float Vignette_Intensity;
		}
	}
}
