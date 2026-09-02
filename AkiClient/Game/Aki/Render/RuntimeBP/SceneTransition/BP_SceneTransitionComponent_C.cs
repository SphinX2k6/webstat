using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SceneTransition
{
	// Token: 0x02003B2A RID: 15146
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SceneTransition/BP_SceneTransitionComponent.BP_SceneTransitionComponent_C")]
	[UnrealStructLayout(672, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 672)]
	public class BP_SceneTransitionComponent_C : UKuroSceneTransitionComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020A7A RID: 133754 RVA: 0x00932E6A File Offset: 0x0093106A
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SceneTransitionComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SceneTransition/BP_SceneTransitionComponent.BP_SceneTransitionComponent_C");
			}
			return BP_SceneTransitionComponent_C._ClassPtr;
		}

		// Token: 0x06020A7B RID: 133755 RVA: 0x00932E90 File Offset: 0x00931090
		public BP_SceneTransitionComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_SceneTransitionComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020A7C RID: 133756 RVA: 0x00932EB8 File Offset: 0x009310B8
		[NullableContext(1)]
		public BP_SceneTransitionComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SceneTransitionComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17003698 RID: 13976
		// (get) Token: 0x06020A7D RID: 133757 RVA: 0x00932EEC File Offset: 0x009310EC
		// (set) Token: 0x06020A7E RID: 133758 RVA: 0x00932F25 File Offset: 0x00931125
		[Nullable(1)]
		public FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SceneTransitionComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SceneTransitionComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17003699 RID: 13977
		// (get) Token: 0x06020A7F RID: 133759 RVA: 0x00932F46 File Offset: 0x00931146
		// (set) Token: 0x06020A80 RID: 133760 RVA: 0x00932F5A File Offset: 0x0093115A
		public unsafe UStaticMeshComponent MeshComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700369A RID: 13978
		// (get) Token: 0x06020A81 RID: 133761 RVA: 0x00932F6F File Offset: 0x0093116F
		// (set) Token: 0x06020A82 RID: 133762 RVA: 0x00932F83 File Offset: 0x00931183
		public unsafe UMaterialInterface ReplaceMaterial
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700369B RID: 13979
		// (get) Token: 0x06020A83 RID: 133763 RVA: 0x00932F98 File Offset: 0x00931198
		// (set) Token: 0x06020A84 RID: 133764 RVA: 0x00932FAC File Offset: 0x009311AC
		public unsafe UMaterialInterface ReplaceMaterialLOD
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x1700369C RID: 13980
		// (get) Token: 0x06020A85 RID: 133765 RVA: 0x00932FC1 File Offset: 0x009311C1
		// (set) Token: 0x06020A86 RID: 133766 RVA: 0x00932FD5 File Offset: 0x009311D5
		public unsafe UStaticMeshComponent RootMeshComp
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SceneTransitionComponent_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06020A87 RID: 133767 RVA: 0x00932FEC File Offset: 0x009311EC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void NeedDynMatForRoot(ref bool Out)
		{
			BP_SceneTransitionComponent_C.__NeedDynMatForRoot_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_C.__NeedDynMatForRoot_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(BP_SceneTransitionComponent_C.__NeedDynMatForRoot_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_C.__NeedDynMatForRoot_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Out = Out;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__NeedDynMatForRoot_NativeFunctionPtr, (void*)ptr);
			Out = ptr->Out;
		}

		// Token: 0x06020A88 RID: 133768 RVA: 0x0093303C File Offset: 0x0093123C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetMaterialParameters(float DeltaTime, float TransitionAge, float TransitionNormalizedProcess)
		{
			BP_SceneTransitionComponent_C.__SetMaterialParameters_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_C.__SetMaterialParameters_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneTransitionComponent_C.__SetMaterialParameters_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_C.__SetMaterialParameters_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			ptr->TransitionAge = TransitionAge;
			ptr->TransitionNormalizedProcess = TransitionNormalizedProcess;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__SetMaterialParameters_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A89 RID: 133769 RVA: 0x00933090 File Offset: 0x00931290
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void TickSceneTransition(float DeltaTime, float TransitionAge, float TransitionNormalizedProgress)
		{
			BP_SceneTransitionComponent_C.__TickSceneTransition_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_C.__TickSceneTransition_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneTransitionComponent_C.__TickSceneTransition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_C.__TickSceneTransition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			ptr->TransitionAge = TransitionAge;
			ptr->TransitionNormalizedProgress = TransitionNormalizedProgress;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__TickSceneTransition_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020A8A RID: 133770 RVA: 0x009330E4 File Offset: 0x009312E4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void TickSceneTransition_Implementation(float DeltaTime, float TransitionAge, float TransitionNormalizedProgress)
		{
			BP_SceneTransitionComponent_C.__TickSceneTransition_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_C.__TickSceneTransition_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_SceneTransitionComponent_C.__TickSceneTransition_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_C.__TickSceneTransition_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaTime = DeltaTime;
			ptr->TransitionAge = TransitionAge;
			ptr->TransitionNormalizedProgress = TransitionNormalizedProgress;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__TickSceneTransition_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A8B RID: 133771 RVA: 0x00933139 File Offset: 0x00931339
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnSceneTransitionStart()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__OnSceneTransitionStart_NativeFunctionPtr, null);
		}

		// Token: 0x06020A8C RID: 133772 RVA: 0x0093314D File Offset: 0x0093134D
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnSceneTransitionStart_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__OnSceneTransitionStart_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A8D RID: 133773 RVA: 0x00933162 File Offset: 0x00931362
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnSceneTransitionRegistered()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__OnSceneTransitionRegistered_NativeFunctionPtr, null);
		}

		// Token: 0x06020A8E RID: 133774 RVA: 0x00933176 File Offset: 0x00931376
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnSceneTransitionRegistered_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__OnSceneTransitionRegistered_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A8F RID: 133775 RVA: 0x0093318B File Offset: 0x0093138B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void OnSceneTransitionEnd()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__OnSceneTransitionEnd_NativeFunctionPtr, null);
		}

		// Token: 0x06020A90 RID: 133776 RVA: 0x0093319F File Offset: 0x0093139F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void OnSceneTransitionEnd_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__OnSceneTransitionEnd_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06020A91 RID: 133777 RVA: 0x009331B4 File Offset: 0x009313B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SceneTransitionComponent(int EntryPoint)
		{
			BP_SceneTransitionComponent_C.__ExecuteUbergraph_BP_SceneTransitionComponent_FunctionParams* ptr = stackalloc BP_SceneTransitionComponent_C.__ExecuteUbergraph_BP_SceneTransitionComponent_FunctionParams[(UIntPtr)375] + 15L / (long)sizeof(BP_SceneTransitionComponent_C.__ExecuteUbergraph_BP_SceneTransitionComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SceneTransitionComponent_C.__ExecuteUbergraph_BP_SceneTransitionComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SceneTransitionComponent_C.__ExecuteUbergraph_BP_SceneTransitionComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020A92 RID: 133778 RVA: 0x009331FE File Offset: 0x009313FE
		protected BP_SceneTransitionComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040105A2 RID: 66978
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SceneTransition/BP_SceneTransitionComponent.BP_SceneTransitionComponent_C";

		// Token: 0x040105A3 RID: 66979
		private static IntPtr _ClassPtr;

		// Token: 0x040105A4 RID: 66980
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040105A5 RID: 66981
		internal static int __PropertyOffset_0;

		// Token: 0x040105A6 RID: 66982
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040105A7 RID: 66983
		internal static int __PropertyOffset_1;

		// Token: 0x040105A8 RID: 66984
		internal static int __PropertyOffset_2;

		// Token: 0x040105A9 RID: 66985
		internal static int __PropertyOffset_3;

		// Token: 0x040105AA RID: 66986
		internal static int __PropertyOffset_4;

		// Token: 0x040105AB RID: 66987
		private static IntPtr __NeedDynMatForRoot_NativeFunctionPtr;

		// Token: 0x040105AC RID: 66988
		private static IntPtr __SetMaterialParameters_NativeFunctionPtr;

		// Token: 0x040105AD RID: 66989
		private static IntPtr __TickSceneTransition_NativeFunctionPtr;

		// Token: 0x040105AE RID: 66990
		private static IntPtr __OnSceneTransitionStart_NativeFunctionPtr;

		// Token: 0x040105AF RID: 66991
		private static IntPtr __OnSceneTransitionRegistered_NativeFunctionPtr;

		// Token: 0x040105B0 RID: 66992
		private static IntPtr __OnSceneTransitionEnd_NativeFunctionPtr;

		// Token: 0x040105B1 RID: 66993
		private static IntPtr __ExecuteUbergraph_BP_SceneTransitionComponent_NativeFunctionPtr;

		// Token: 0x02009A03 RID: 39427
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected ref struct __NeedDynMatForRoot_FunctionParams
		{
			// Token: 0x040320E0 RID: 205024
			[FieldOffset(0)]
			public bool Out;
		}

		// Token: 0x02009A04 RID: 39428
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __SetMaterialParameters_FunctionParams
		{
			// Token: 0x040320E1 RID: 205025
			[FieldOffset(0)]
			public float DeltaTime;

			// Token: 0x040320E2 RID: 205026
			[FieldOffset(4)]
			public float TransitionAge;

			// Token: 0x040320E3 RID: 205027
			[FieldOffset(8)]
			public float TransitionNormalizedProcess;
		}

		// Token: 0x02009A05 RID: 39429
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected new ref struct __TickSceneTransition_FunctionParams
		{
			// Token: 0x040320E4 RID: 205028
			[FieldOffset(0)]
			public float DeltaTime;

			// Token: 0x040320E5 RID: 205029
			[FieldOffset(4)]
			public float TransitionAge;

			// Token: 0x040320E6 RID: 205030
			[FieldOffset(8)]
			public float TransitionNormalizedProgress;
		}

		// Token: 0x02009A06 RID: 39430
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 360)]
		protected ref struct __ExecuteUbergraph_BP_SceneTransitionComponent_FunctionParams
		{
			// Token: 0x040320E7 RID: 205031
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
