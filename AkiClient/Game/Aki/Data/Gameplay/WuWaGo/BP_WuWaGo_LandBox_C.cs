using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Gameplay.WuWaGo
{
	// Token: 0x02003E96 RID: 16022
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_LandBox.BP_WuWaGo_LandBox_C")]
	[UnrealStructLayout(1064, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1064)]
	public class BP_WuWaGo_LandBox_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06027B8A RID: 162698 RVA: 0x009F8E43 File Offset: 0x009F7043
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_WuWaGo_LandBox_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_LandBox.BP_WuWaGo_LandBox_C");
			}
			return BP_WuWaGo_LandBox_C._ClassPtr;
		}

		// Token: 0x06027B8B RID: 162699 RVA: 0x009F8E68 File Offset: 0x009F7068
		public BP_WuWaGo_LandBox_C() : this(BuiltinUtils.AllocNativeUObject(BP_WuWaGo_LandBox_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06027B8C RID: 162700 RVA: 0x009F8E90 File Offset: 0x009F7090
		[NullableContext(1)]
		public BP_WuWaGo_LandBox_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_WuWaGo_LandBox_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005E86 RID: 24198
		// (get) Token: 0x06027B8D RID: 162701 RVA: 0x009F8EC4 File Offset: 0x009F70C4
		// (set) Token: 0x06027B8E RID: 162702 RVA: 0x009F8EFD File Offset: 0x009F70FD
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_WuWaGo_LandBox_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_WuWaGo_LandBox_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005E87 RID: 24199
		// (get) Token: 0x06027B8F RID: 162703 RVA: 0x009F8F1E File Offset: 0x009F711E
		// (set) Token: 0x06027B90 RID: 162704 RVA: 0x009F8F32 File Offset: 0x009F7132
		public unsafe UStaticMeshComponent 模型
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_LandBox_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_LandBox_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17005E88 RID: 24200
		// (get) Token: 0x06027B91 RID: 162705 RVA: 0x009F8F47 File Offset: 0x009F7147
		// (set) Token: 0x06027B92 RID: 162706 RVA: 0x009F8F5B File Offset: 0x009F715B
		public unsafe UStaticMeshComponent Plane
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_LandBox_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_LandBox_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005E89 RID: 24201
		// (get) Token: 0x06027B93 RID: 162707 RVA: 0x009F8F70 File Offset: 0x009F7170
		// (set) Token: 0x06027B94 RID: 162708 RVA: 0x009F8F84 File Offset: 0x009F7184
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_LandBox_C.__PropertyOffset_3);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_WuWaGo_LandBox_C.__PropertyOffset_3, value);
			}
		}

		// Token: 0x06027B95 RID: 162709 RVA: 0x009F8F99 File Offset: 0x009F7199
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_WuWaGo_LandBox_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06027B96 RID: 162710 RVA: 0x009F8FAD File Offset: 0x009F71AD
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WuWaGo_LandBox_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06027B97 RID: 162711 RVA: 0x009F8FC4 File Offset: 0x009F71C4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_WuWaGo_LandBox(int EntryPoint)
		{
			BP_WuWaGo_LandBox_C.__ExecuteUbergraph_BP_WuWaGo_LandBox_FunctionParams* ptr = stackalloc BP_WuWaGo_LandBox_C.__ExecuteUbergraph_BP_WuWaGo_LandBox_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_WuWaGo_LandBox_C.__ExecuteUbergraph_BP_WuWaGo_LandBox_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_WuWaGo_LandBox_C.__ExecuteUbergraph_BP_WuWaGo_LandBox_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_WuWaGo_LandBox_C.__ExecuteUbergraph_BP_WuWaGo_LandBox_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06027B98 RID: 162712 RVA: 0x009F900B File Offset: 0x009F720B
		protected BP_WuWaGo_LandBox_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014D57 RID: 85335
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Data/Gameplay/WuWaGo/BP_WuWaGo_LandBox.BP_WuWaGo_LandBox_C";

		// Token: 0x04014D58 RID: 85336
		private static IntPtr _ClassPtr;

		// Token: 0x04014D59 RID: 85337
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014D5A RID: 85338
		internal static int __PropertyOffset_0;

		// Token: 0x04014D5B RID: 85339
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04014D5C RID: 85340
		internal static int __PropertyOffset_1;

		// Token: 0x04014D5D RID: 85341
		internal static int __PropertyOffset_2;

		// Token: 0x04014D5E RID: 85342
		internal static int __PropertyOffset_3;

		// Token: 0x04014D5F RID: 85343
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04014D60 RID: 85344
		private static IntPtr __ExecuteUbergraph_BP_WuWaGo_LandBox_NativeFunctionPtr;

		// Token: 0x0200A0DC RID: 41180
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_WuWaGo_LandBox_FunctionParams
		{
			// Token: 0x04032D96 RID: 208278
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
