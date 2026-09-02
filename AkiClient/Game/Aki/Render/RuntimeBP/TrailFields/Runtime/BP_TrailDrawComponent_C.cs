using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.TrailFields.Runtime
{
	// Token: 0x02003A2A RID: 14890
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDrawComponent.BP_TrailDrawComponent_C")]
	[UnrealStructLayout(640, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 632)]
	public class BP_TrailDrawComponent_C : USceneComponent, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EA37 RID: 125495 RVA: 0x008FA3E8 File Offset: 0x008F85E8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_TrailDrawComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDrawComponent.BP_TrailDrawComponent_C");
			}
			return BP_TrailDrawComponent_C._ClassPtr;
		}

		// Token: 0x0601EA38 RID: 125496 RVA: 0x008FA40C File Offset: 0x008F860C
		public BP_TrailDrawComponent_C() : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EA39 RID: 125497 RVA: 0x008FA434 File Offset: 0x008F8634
		[NullableContext(1)]
		public BP_TrailDrawComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_TrailDrawComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002BA4 RID: 11172
		// (get) Token: 0x0601EA3A RID: 125498 RVA: 0x008FA468 File Offset: 0x008F8668
		// (set) Token: 0x0601EA3B RID: 125499 RVA: 0x008FA4A1 File Offset: 0x008F86A1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002BA5 RID: 11173
		// (get) Token: 0x0601EA3C RID: 125500 RVA: 0x008FA4C2 File Offset: 0x008F86C2
		// (set) Token: 0x0601EA3D RID: 125501 RVA: 0x008FA4D6 File Offset: 0x008F86D6
		public unsafe FVector2D Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17002BA6 RID: 11174
		// (get) Token: 0x0601EA3E RID: 125502 RVA: 0x008FA4EB File Offset: 0x008F86EB
		// (set) Token: 0x0601EA3F RID: 125503 RVA: 0x008FA4FF File Offset: 0x008F86FF
		public unsafe UTexture Texture
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17002BA7 RID: 11175
		// (get) Token: 0x0601EA40 RID: 125504 RVA: 0x008FA514 File Offset: 0x008F8714
		// (set) Token: 0x0601EA41 RID: 125505 RVA: 0x008FA528 File Offset: 0x008F8728
		public unsafe FVector2D Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002BA8 RID: 11176
		// (get) Token: 0x0601EA42 RID: 125506 RVA: 0x008FA53D File Offset: 0x008F873D
		// (set) Token: 0x0601EA43 RID: 125507 RVA: 0x008FA551 File Offset: 0x008F8751
		public unsafe BP_TrailsManager_C Manager
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_TrailsManager_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_TrailDrawComponent_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x17002BA9 RID: 11177
		// (get) Token: 0x0601EA44 RID: 125508 RVA: 0x008FA566 File Offset: 0x008F8766
		// (set) Token: 0x0601EA45 RID: 125509 RVA: 0x008FA576 File Offset: 0x008F8776
		public unsafe float Rotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17002BAA RID: 11178
		// (get) Token: 0x0601EA46 RID: 125510 RVA: 0x008FA587 File Offset: 0x008F8787
		// (set) Token: 0x0601EA47 RID: 125511 RVA: 0x008FA597 File Offset: 0x008F8797
		public unsafe float Depth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_TrailDrawComponent_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x0601EA48 RID: 125512 RVA: 0x008FA5A8 File Offset: 0x008F87A8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetManager(ref BP_TrailsManager_C Ret)
		{
			BP_TrailDrawComponent_C.__GetManager_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_C.__GetManager_FunctionParams[(UIntPtr)191] + 15L / (long)sizeof(BP_TrailDrawComponent_C.__GetManager_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_C.__GetManager_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_TrailDrawComponent_C.__GetManager_FunctionParams ptr2 = ref *ptr;
			BP_TrailsManager_C bp_TrailsManager_C = Ret;
			ptr2.Ret = ((bp_TrailsManager_C != null) ? bp_TrailsManager_C.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_C.__GetManager_NativeFunctionPtr, (void*)ptr);
			Ret = BuiltinUtils.GetOrCreateUObjectByNativePointer<BP_TrailsManager_C>(ptr->Ret);
		}

		// Token: 0x0601EA49 RID: 125513 RVA: 0x008FA610 File Offset: 0x008F8810
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetPlayerActor(ref AActor Ret)
		{
			BP_TrailDrawComponent_C.__GetPlayerActor_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_C.__GetPlayerActor_FunctionParams[(UIntPtr)31] + 15L / (long)sizeof(BP_TrailDrawComponent_C.__GetPlayerActor_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_C.__GetPlayerActor_NativeFunctionPtr, (void*)ptr, 1);
			ref BP_TrailDrawComponent_C.__GetPlayerActor_FunctionParams ptr2 = ref *ptr;
			AActor aactor = Ret;
			ptr2.Ret = ((aactor != null) ? aactor.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_C.__GetPlayerActor_NativeFunctionPtr, (void*)ptr);
			Ret = BuiltinUtils.GetOrCreateUObjectByNativePointer<AActor>(ptr->Ret);
		}

		// Token: 0x0601EA4A RID: 125514 RVA: 0x008FA674 File Offset: 0x008F8874
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void NeedDrawing()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_TrailDrawComponent_C.__NeedDrawing_NativeFunctionPtr, null);
		}

		// Token: 0x0601EA4B RID: 125515 RVA: 0x008FA688 File Offset: 0x008F8888
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_TrailDrawComponent(int EntryPoint)
		{
			BP_TrailDrawComponent_C.__ExecuteUbergraph_BP_TrailDrawComponent_FunctionParams* ptr = stackalloc BP_TrailDrawComponent_C.__ExecuteUbergraph_BP_TrailDrawComponent_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_TrailDrawComponent_C.__ExecuteUbergraph_BP_TrailDrawComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_TrailDrawComponent_C.__ExecuteUbergraph_BP_TrailDrawComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_TrailDrawComponent_C.__ExecuteUbergraph_BP_TrailDrawComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EA4C RID: 125516 RVA: 0x008FA6CF File Offset: 0x008F88CF
		protected BP_TrailDrawComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F1B9 RID: 61881
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/TrailFields/Runtime/BP_TrailDrawComponent.BP_TrailDrawComponent_C";

		// Token: 0x0400F1BA RID: 61882
		private static IntPtr _ClassPtr;

		// Token: 0x0400F1BB RID: 61883
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F1BC RID: 61884
		internal static int __PropertyOffset_0;

		// Token: 0x0400F1BD RID: 61885
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F1BE RID: 61886
		internal static int __PropertyOffset_1;

		// Token: 0x0400F1BF RID: 61887
		internal static int __PropertyOffset_2;

		// Token: 0x0400F1C0 RID: 61888
		internal static int __PropertyOffset_3;

		// Token: 0x0400F1C1 RID: 61889
		internal static int __PropertyOffset_4;

		// Token: 0x0400F1C2 RID: 61890
		internal static int __PropertyOffset_5;

		// Token: 0x0400F1C3 RID: 61891
		internal static int __PropertyOffset_6;

		// Token: 0x0400F1C4 RID: 61892
		private static IntPtr __GetManager_NativeFunctionPtr;

		// Token: 0x0400F1C5 RID: 61893
		private static IntPtr __GetPlayerActor_NativeFunctionPtr;

		// Token: 0x0400F1C6 RID: 61894
		private static IntPtr __NeedDrawing_NativeFunctionPtr;

		// Token: 0x0400F1C7 RID: 61895
		private static IntPtr __ExecuteUbergraph_BP_TrailDrawComponent_NativeFunctionPtr;

		// Token: 0x020097D8 RID: 38872
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 176)]
		protected ref struct __GetManager_FunctionParams
		{
			// Token: 0x04031DC5 RID: 204229
			[FieldOffset(0)]
			public IntPtr Ret;
		}

		// Token: 0x020097D9 RID: 38873
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 16)]
		protected ref struct __GetPlayerActor_FunctionParams
		{
			// Token: 0x04031DC6 RID: 204230
			[FieldOffset(0)]
			public IntPtr Ret;
		}

		// Token: 0x020097DA RID: 38874
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __ExecuteUbergraph_BP_TrailDrawComponent_FunctionParams
		{
			// Token: 0x04031DC7 RID: 204231
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
