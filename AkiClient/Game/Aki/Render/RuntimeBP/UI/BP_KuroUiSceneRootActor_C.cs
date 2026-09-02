using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UI
{
	// Token: 0x02003A20 RID: 14880
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UI/BP_KuroUiSceneRootActor.BP_KuroUiSceneRootActor_C")]
	[UnrealStructLayout(1120, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1120)]
	public class BP_KuroUiSceneRootActor_C : AKuroUiSceneRootActor, IUnrealUObject, IUnrealObject, IMovieSceneTransformOrigin, IUnrealNativeInterface, IUnrealInterface
	{
		// Token: 0x0601E973 RID: 125299 RVA: 0x008F8B4C File Offset: 0x008F6D4C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_KuroUiSceneRootActor_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/UI/BP_KuroUiSceneRootActor.BP_KuroUiSceneRootActor_C");
			}
			return BP_KuroUiSceneRootActor_C._ClassPtr;
		}

		// Token: 0x0601E974 RID: 125300 RVA: 0x008F8B70 File Offset: 0x008F6D70
		int IMovieSceneTransformOrigin.InterfaceOffset()
		{
			return BP_KuroUiSceneRootActor_C.__InterfaceOffset_IMovieSceneTransformOrigin;
		}

		// Token: 0x0601E975 RID: 125301 RVA: 0x008F8B78 File Offset: 0x008F6D78
		public BP_KuroUiSceneRootActor_C() : this(BuiltinUtils.AllocNativeUObject(BP_KuroUiSceneRootActor_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601E976 RID: 125302 RVA: 0x008F8BA0 File Offset: 0x008F6DA0
		[NullableContext(1)]
		public BP_KuroUiSceneRootActor_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_KuroUiSceneRootActor_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002B6C RID: 11116
		// (get) Token: 0x0601E977 RID: 125303 RVA: 0x008F8BD3 File Offset: 0x008F6DD3
		// (set) Token: 0x0601E978 RID: 125304 RVA: 0x008F8BE7 File Offset: 0x008F6DE7
		[Nullable(2)]
		public unsafe UKuroCollectActorComponent KuroCollectActor
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UKuroCollectActorComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroUiSceneRootActor_C.__PropertyOffset_0);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroUiSceneRootActor_C.__PropertyOffset_0, value);
			}
		}

		// Token: 0x17002B6D RID: 11117
		// (get) Token: 0x0601E979 RID: 125305 RVA: 0x008F8BFC File Offset: 0x008F6DFC
		// (set) Token: 0x0601E97A RID: 125306 RVA: 0x008F8C10 File Offset: 0x008F6E10
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroUiSceneRootActor_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_KuroUiSceneRootActor_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002B6E RID: 11118
		// (get) Token: 0x0601E97B RID: 125307 RVA: 0x008F8C28 File Offset: 0x008F6E28
		// (set) Token: 0x0601E97C RID: 125308 RVA: 0x008F8C61 File Offset: 0x008F6E61
		[Nullable(1)]
		public TMap<string, AActor> RefActors_0
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<string, AActor> result;
				if ((result = this._RefActors_0) == null)
				{
					result = (this._RefActors_0 = new TMap<string, AActor>(base.NativePtr + (IntPtr)BP_KuroUiSceneRootActor_C.__PropertyOffset_2, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.RefActors_0.CopyAssign(value);
			}
		}

		// Token: 0x0601E97D RID: 125309 RVA: 0x008F8C70 File Offset: 0x008F6E70
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FTransform BP_GetTransformOrigin()
		{
			BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_FunctionParams* ptr = stackalloc BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0601E97E RID: 125310 RVA: 0x008F8CB8 File Offset: 0x008F6EB8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual FTransform BP_GetTransformOrigin_Implementation()
		{
			BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_FunctionParams* ptr = stackalloc BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_FunctionParams[(UIntPtr)159] + 15L / (long)sizeof(BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_KuroUiSceneRootActor_C.__BP_GetTransformOrigin_NativeFunctionPtr, (void*)ptr, 0);
			return ptr->__Result;
		}

		// Token: 0x0601E97F RID: 125311 RVA: 0x008F8D04 File Offset: 0x008F6F04
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetActorByKey(string Key, [Nullable(2)] ref AActor RetActor)
		{
			BP_KuroUiSceneRootActor_C.__GetActorByKey_FunctionParams* ptr = stackalloc BP_KuroUiSceneRootActor_C.__GetActorByKey_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_KuroUiSceneRootActor_C.__GetActorByKey_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_KuroUiSceneRootActor_C.__GetActorByKey_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->Key), Key);
			ref BP_KuroUiSceneRootActor_C.__GetActorByKey_FunctionParams ptr2 = ref *ptr;
			AActor aactor = RetActor;
			ptr2.RetActor = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_KuroUiSceneRootActor_C.__GetActorByKey_NativeFunctionPtr, (void*)ptr);
			RetActor = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->RetActor);
			UnrealReflectionUtils.DestroyStruct(BP_KuroUiSceneRootActor_C.__GetActorByKey_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0601E980 RID: 125312 RVA: 0x008F8D86 File Offset: 0x008F6F86
		protected BP_KuroUiSceneRootActor_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F13E RID: 61758
		internal static int __InterfaceOffset_IMovieSceneTransformOrigin;

		// Token: 0x0400F13F RID: 61759
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/UI/BP_KuroUiSceneRootActor.BP_KuroUiSceneRootActor_C";

		// Token: 0x0400F140 RID: 61760
		private static IntPtr _ClassPtr;

		// Token: 0x0400F141 RID: 61761
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F142 RID: 61762
		internal static int __PropertyOffset_0;

		// Token: 0x0400F143 RID: 61763
		internal static int __PropertyOffset_1;

		// Token: 0x0400F144 RID: 61764
		internal static int __PropertyOffset_2;

		// Token: 0x0400F145 RID: 61765
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, AActor> _RefActors_0;

		// Token: 0x0400F146 RID: 61766
		private static IntPtr __BP_GetTransformOrigin_NativeFunctionPtr;

		// Token: 0x0400F147 RID: 61767
		private static IntPtr __GetActorByKey_NativeFunctionPtr;

		// Token: 0x020097C4 RID: 38852
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 144)]
		protected ref struct __BP_GetTransformOrigin_FunctionParams
		{
			// Token: 0x04031DA9 RID: 204201
			[FieldOffset(0)]
			public FTransform __Result;
		}

		// Token: 0x020097C5 RID: 38853
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __GetActorByKey_FunctionParams
		{
			// Token: 0x04031DAA RID: 204202
			[FieldOffset(0)]
			public FString Key;

			// Token: 0x04031DAB RID: 204203
			[FieldOffset(16)]
			public IntPtr RetActor;
		}
	}
}
