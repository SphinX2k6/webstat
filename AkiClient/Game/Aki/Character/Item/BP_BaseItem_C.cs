using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.CreatureTools;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.Item
{
	// Token: 0x020041A4 RID: 16804
	[UnrealObjectPath("/Game/Aki/Character/Item/BP_BaseItem.BP_BaseItem_C")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1084)]
	public class BP_BaseItem_C : __TsBaseItem_InheritProxy, IUnrealUObject, IUnrealObject, IBPI_CreatureInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602C9CF RID: 182735 RVA: 0x00AA8008 File Offset: 0x00AA6208
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BaseItem_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/Item/BP_BaseItem.BP_BaseItem_C");
			}
			return BP_BaseItem_C._ClassPtr;
		}

		// Token: 0x0602C9D0 RID: 182736 RVA: 0x00AA802C File Offset: 0x00AA622C
		public BP_BaseItem_C() : this(BuiltinUtils.AllocNativeUObject(BP_BaseItem_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602C9D1 RID: 182737 RVA: 0x00AA8054 File Offset: 0x00AA6254
		[NullableContext(1)]
		public BP_BaseItem_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BaseItem_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700784C RID: 30796
		// (get) Token: 0x0602C9D2 RID: 182738 RVA: 0x00AA8088 File Offset: 0x00AA6288
		// (set) Token: 0x0602C9D3 RID: 182739 RVA: 0x00AA80C1 File Offset: 0x00AA62C1
		[Nullable(1)]
		public new FPointerToUberGraphFrame UberGraphFrame
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BaseItem_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BaseItem_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700784D RID: 30797
		// (get) Token: 0x0602C9D4 RID: 182740 RVA: 0x00AA80E2 File Offset: 0x00AA62E2
		// (set) Token: 0x0602C9D5 RID: 182741 RVA: 0x00AA80F6 File Offset: 0x00AA62F6
		[Nullable(2)]
		public unsafe UStaticMeshComponent StaticMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseItem_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseItem_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x1700784E RID: 30798
		// (get) Token: 0x0602C9D6 RID: 182742 RVA: 0x00AA810B File Offset: 0x00AA630B
		// (set) Token: 0x0602C9D7 RID: 182743 RVA: 0x00AA811F File Offset: 0x00AA631F
		[Nullable(2)]
		public unsafe USceneComponent Scene
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseItem_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BaseItem_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700784F RID: 30799
		// (get) Token: 0x0602C9D8 RID: 182744 RVA: 0x00AA8134 File Offset: 0x00AA6334
		// (set) Token: 0x0602C9D9 RID: 182745 RVA: 0x00AA8144 File Offset: 0x00AA6344
		public unsafe int EntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BaseItem_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BaseItem_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602C9DA RID: 182746 RVA: 0x00AA8158 File Offset: 0x00AA6358
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual int GetEntityId()
		{
			BP_BaseItem_C.__GetEntityId_FunctionParams* ptr = stackalloc BP_BaseItem_C.__GetEntityId_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseItem_C.__GetEntityId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseItem_C.__GetEntityId_NativeFunctionPtr, (void*)ptr, 1);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseItem_C.__GetEntityId_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602C9DB RID: 182747 RVA: 0x00AA81A0 File Offset: 0x00AA63A0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ApplyEntityId(int EntityId)
		{
			BP_BaseItem_C.__ApplyEntityId_FunctionParams* ptr = stackalloc BP_BaseItem_C.__ApplyEntityId_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseItem_C.__ApplyEntityId_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseItem_C.__ApplyEntityId_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntityId = EntityId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseItem_C.__ApplyEntityId_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602C9DC RID: 182748 RVA: 0x00AA81E6 File Offset: 0x00AA63E6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BaseItem_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602C9DD RID: 182749 RVA: 0x00AA81FA File Offset: 0x00AA63FA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected override void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseItem_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602C9DE RID: 182750 RVA: 0x00AA8210 File Offset: 0x00AA6410
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BaseItem(int EntryPoint)
		{
			BP_BaseItem_C.__ExecuteUbergraph_BP_BaseItem_FunctionParams* ptr = stackalloc BP_BaseItem_C.__ExecuteUbergraph_BP_BaseItem_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BaseItem_C.__ExecuteUbergraph_BP_BaseItem_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BaseItem_C.__ExecuteUbergraph_BP_BaseItem_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BaseItem_C.__ExecuteUbergraph_BP_BaseItem_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602C9DF RID: 182751 RVA: 0x00AA8257 File Offset: 0x00AA6457
		protected BP_BaseItem_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018D31 RID: 101681
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/Item/BP_BaseItem.BP_BaseItem_C";

		// Token: 0x04018D32 RID: 101682
		private static IntPtr _ClassPtr;

		// Token: 0x04018D33 RID: 101683
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018D34 RID: 101684
		internal static int __PropertyOffset_0;

		// Token: 0x04018D35 RID: 101685
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04018D36 RID: 101686
		internal static int __PropertyOffset_1;

		// Token: 0x04018D37 RID: 101687
		internal static int __PropertyOffset_2;

		// Token: 0x04018D38 RID: 101688
		internal static int __PropertyOffset_3;

		// Token: 0x04018D39 RID: 101689
		private static IntPtr __GetEntityId_NativeFunctionPtr;

		// Token: 0x04018D3A RID: 101690
		private static IntPtr __ApplyEntityId_NativeFunctionPtr;

		// Token: 0x04018D3B RID: 101691
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04018D3C RID: 101692
		private static IntPtr __ExecuteUbergraph_BP_BaseItem_NativeFunctionPtr;

		// Token: 0x0200A469 RID: 42089
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __GetEntityId_FunctionParams
		{
			// Token: 0x04033270 RID: 209520
			[FieldOffset(0)]
			public int __Result;
		}

		// Token: 0x0200A46A RID: 42090
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ApplyEntityId_FunctionParams
		{
			// Token: 0x04033271 RID: 209521
			[FieldOffset(0)]
			public int EntityId;
		}

		// Token: 0x0200A46B RID: 42091
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __ExecuteUbergraph_BP_BaseItem_FunctionParams
		{
			// Token: 0x04033272 RID: 209522
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
