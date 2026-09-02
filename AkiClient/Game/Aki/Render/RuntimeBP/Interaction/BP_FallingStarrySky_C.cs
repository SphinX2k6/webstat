using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Interaction
{
	// Token: 0x02003C7E RID: 15486
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Interaction/BP_FallingStarrySky.BP_FallingStarrySky_C")]
	[UnrealStructLayout(1080, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1080)]
	public class BP_FallingStarrySky_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06024003 RID: 147459 RVA: 0x00991EE1 File Offset: 0x009900E1
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_FallingStarrySky_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Interaction/BP_FallingStarrySky.BP_FallingStarrySky_C");
			}
			return BP_FallingStarrySky_C._ClassPtr;
		}

		// Token: 0x06024004 RID: 147460 RVA: 0x00991F08 File Offset: 0x00990108
		public BP_FallingStarrySky_C() : this(BuiltinUtils.AllocNativeUObject(BP_FallingStarrySky_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06024005 RID: 147461 RVA: 0x00991F30 File Offset: 0x00990130
		[NullableContext(1)]
		public BP_FallingStarrySky_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_FallingStarrySky_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17004977 RID: 18807
		// (get) Token: 0x06024006 RID: 147462 RVA: 0x00991F64 File Offset: 0x00990164
		// (set) Token: 0x06024007 RID: 147463 RVA: 0x00991F9D File Offset: 0x0099019D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_FallingStarrySky_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_FallingStarrySky_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17004978 RID: 18808
		// (get) Token: 0x06024008 RID: 147464 RVA: 0x00991FBE File Offset: 0x009901BE
		// (set) Token: 0x06024009 RID: 147465 RVA: 0x00991FD2 File Offset: 0x009901D2
		public unsafe UDecalComponent Decal
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDecalComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FallingStarrySky_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FallingStarrySky_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17004979 RID: 18809
		// (get) Token: 0x0602400A RID: 147466 RVA: 0x00991FE7 File Offset: 0x009901E7
		// (set) Token: 0x0602400B RID: 147467 RVA: 0x00991FFB File Offset: 0x009901FB
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FallingStarrySky_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FallingStarrySky_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x1700497A RID: 18810
		// (get) Token: 0x0602400C RID: 147468 RVA: 0x00992010 File Offset: 0x00990210
		// (set) Token: 0x0602400D RID: 147469 RVA: 0x00992024 File Offset: 0x00990224
		public unsafe FName PositionName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_FallingStarrySky_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_FallingStarrySky_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700497B RID: 18811
		// (get) Token: 0x0602400E RID: 147470 RVA: 0x00992039 File Offset: 0x00990239
		// (set) Token: 0x0602400F RID: 147471 RVA: 0x0099204D File Offset: 0x0099024D
		public unsafe UMaterialInstance DecalMaterialInstance
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + BP_FallingStarrySky_C.__PropertyOffset_4);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_FallingStarrySky_C.__PropertyOffset_4, value);
			}
		}

		// Token: 0x06024010 RID: 147472 RVA: 0x00992062 File Offset: 0x00990262
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FallingStarrySky_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x06024011 RID: 147473 RVA: 0x00992076 File Offset: 0x00990276
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FallingStarrySky_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024012 RID: 147474 RVA: 0x0099208B File Offset: 0x0099028B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_FallingStarrySky_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06024013 RID: 147475 RVA: 0x0099209F File Offset: 0x0099029F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FallingStarrySky_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06024014 RID: 147476 RVA: 0x009920B4 File Offset: 0x009902B4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_FallingStarrySky(int EntryPoint)
		{
			BP_FallingStarrySky_C.__ExecuteUbergraph_BP_FallingStarrySky_FunctionParams* ptr = stackalloc BP_FallingStarrySky_C.__ExecuteUbergraph_BP_FallingStarrySky_FunctionParams[(UIntPtr)135] + 15L / (long)sizeof(BP_FallingStarrySky_C.__ExecuteUbergraph_BP_FallingStarrySky_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_FallingStarrySky_C.__ExecuteUbergraph_BP_FallingStarrySky_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_FallingStarrySky_C.__ExecuteUbergraph_BP_FallingStarrySky_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06024015 RID: 147477 RVA: 0x009920FE File Offset: 0x009902FE
		protected BP_FallingStarrySky_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401265D RID: 75357
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Interaction/BP_FallingStarrySky.BP_FallingStarrySky_C";

		// Token: 0x0401265E RID: 75358
		private static IntPtr _ClassPtr;

		// Token: 0x0401265F RID: 75359
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04012660 RID: 75360
		internal static int __PropertyOffset_0;

		// Token: 0x04012661 RID: 75361
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04012662 RID: 75362
		internal static int __PropertyOffset_1;

		// Token: 0x04012663 RID: 75363
		internal static int __PropertyOffset_2;

		// Token: 0x04012664 RID: 75364
		internal static int __PropertyOffset_3;

		// Token: 0x04012665 RID: 75365
		internal static int __PropertyOffset_4;

		// Token: 0x04012666 RID: 75366
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x04012667 RID: 75367
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04012668 RID: 75368
		private static IntPtr __ExecuteUbergraph_BP_FallingStarrySky_NativeFunctionPtr;

		// Token: 0x02009D75 RID: 40309
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 120)]
		protected ref struct __ExecuteUbergraph_BP_FallingStarrySky_FunctionParams
		{
			// Token: 0x0403276A RID: 206698
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
