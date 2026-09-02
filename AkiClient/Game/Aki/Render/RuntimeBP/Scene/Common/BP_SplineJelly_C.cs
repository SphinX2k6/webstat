using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Scene.Common
{
	// Token: 0x02003ADF RID: 15071
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Scene/Common/BP_SplineJelly.BP_SplineJelly_C")]
	[UnrealStructLayout(1384, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1380)]
	public class BP_SplineJelly_C : AKuroEditorTickActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06020457 RID: 132183 RVA: 0x00927454 File Offset: 0x00925654
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SplineJelly_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_SplineJelly.BP_SplineJelly_C");
			}
			return BP_SplineJelly_C._ClassPtr;
		}

		// Token: 0x06020458 RID: 132184 RVA: 0x00927478 File Offset: 0x00925678
		public BP_SplineJelly_C() : this(BuiltinUtils.AllocNativeUObject(BP_SplineJelly_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06020459 RID: 132185 RVA: 0x009274A0 File Offset: 0x009256A0
		[NullableContext(1)]
		public BP_SplineJelly_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SplineJelly_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170034B9 RID: 13497
		// (get) Token: 0x0602045A RID: 132186 RVA: 0x009274D4 File Offset: 0x009256D4
		// (set) Token: 0x0602045B RID: 132187 RVA: 0x0092750D File Offset: 0x0092570D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170034BA RID: 13498
		// (get) Token: 0x0602045C RID: 132188 RVA: 0x0092752E File Offset: 0x0092572E
		// (set) Token: 0x0602045D RID: 132189 RVA: 0x00927542 File Offset: 0x00925742
		public unsafe USkeletalMeshComponent SkeletalMesh
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USkeletalMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineJelly_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineJelly_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170034BB RID: 13499
		// (get) Token: 0x0602045E RID: 132190 RVA: 0x00927557 File Offset: 0x00925757
		// (set) Token: 0x0602045F RID: 132191 RVA: 0x0092756B File Offset: 0x0092576B
		public unsafe USplineComponent Spline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USplineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineJelly_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SplineJelly_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170034BC RID: 13500
		// (get) Token: 0x06020460 RID: 132192 RVA: 0x00927580 File Offset: 0x00925780
		// (set) Token: 0x06020461 RID: 132193 RVA: 0x00927590 File Offset: 0x00925790
		public unsafe float MoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170034BD RID: 13501
		// (get) Token: 0x06020462 RID: 132194 RVA: 0x009275A1 File Offset: 0x009257A1
		// (set) Token: 0x06020463 RID: 132195 RVA: 0x009275B1 File Offset: 0x009257B1
		public unsafe float Rotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170034BE RID: 13502
		// (get) Token: 0x06020464 RID: 132196 RVA: 0x009275C2 File Offset: 0x009257C2
		// (set) Token: 0x06020465 RID: 132197 RVA: 0x009275D6 File Offset: 0x009257D6
		public unsafe FVectorDouble RelativeLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170034BF RID: 13503
		// (get) Token: 0x06020466 RID: 132198 RVA: 0x009275EB File Offset: 0x009257EB
		// (set) Token: 0x06020467 RID: 132199 RVA: 0x009275FB File Offset: 0x009257FB
		public unsafe float Progress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x170034C0 RID: 13504
		// (get) Token: 0x06020468 RID: 132200 RVA: 0x0092760C File Offset: 0x0092580C
		// (set) Token: 0x06020469 RID: 132201 RVA: 0x0092761C File Offset: 0x0092581C
		public unsafe float SplineLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x170034C1 RID: 13505
		// (get) Token: 0x0602046A RID: 132202 RVA: 0x0092762D File Offset: 0x0092582D
		// (set) Token: 0x0602046B RID: 132203 RVA: 0x0092763D File Offset: 0x0092583D
		public unsafe float Delta
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SplineJelly_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x0602046C RID: 132204 RVA: 0x0092764E File Offset: 0x0092584E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void UserConstructionScript()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineJelly_C.__UserConstructionScript_NativeFunctionPtr, null);
		}

		// Token: 0x0602046D RID: 132205 RVA: 0x00927662 File Offset: 0x00925862
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void UserConstructionScript_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineJelly_C.__UserConstructionScript_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602046E RID: 132206 RVA: 0x00927678 File Offset: 0x00925878
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_SplineJelly_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineJelly_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineJelly_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineJelly_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineJelly_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602046F RID: 132207 RVA: 0x009276C0 File Offset: 0x009258C0
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_SplineJelly_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_SplineJelly_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineJelly_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineJelly_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineJelly_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020470 RID: 132208 RVA: 0x00927708 File Offset: 0x00925908
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void EditorTick(float DeltaSeconds)
		{
			BP_SplineJelly_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplineJelly_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineJelly_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineJelly_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_SplineJelly_C.__EditorTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06020471 RID: 132209 RVA: 0x00927750 File Offset: 0x00925950
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void EditorTick_Implementation(float DeltaSeconds)
		{
			BP_SplineJelly_C.__EditorTick_FunctionParams* ptr = stackalloc BP_SplineJelly_C.__EditorTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_SplineJelly_C.__EditorTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineJelly_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineJelly_C.__EditorTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020472 RID: 132210 RVA: 0x00927798 File Offset: 0x00925998
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_SplineJelly(int EntryPoint)
		{
			BP_SplineJelly_C.__ExecuteUbergraph_BP_SplineJelly_FunctionParams* ptr = stackalloc BP_SplineJelly_C.__ExecuteUbergraph_BP_SplineJelly_FunctionParams[(UIntPtr)463] + 15L / (long)sizeof(BP_SplineJelly_C.__ExecuteUbergraph_BP_SplineJelly_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_SplineJelly_C.__ExecuteUbergraph_BP_SplineJelly_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_SplineJelly_C.__ExecuteUbergraph_BP_SplineJelly_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06020473 RID: 132211 RVA: 0x009277E2 File Offset: 0x009259E2
		protected BP_SplineJelly_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401019E RID: 65950
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Scene/Common/BP_SplineJelly.BP_SplineJelly_C";

		// Token: 0x0401019F RID: 65951
		private static IntPtr _ClassPtr;

		// Token: 0x040101A0 RID: 65952
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040101A1 RID: 65953
		internal static int __PropertyOffset_0;

		// Token: 0x040101A2 RID: 65954
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040101A3 RID: 65955
		internal static int __PropertyOffset_1;

		// Token: 0x040101A4 RID: 65956
		internal static int __PropertyOffset_2;

		// Token: 0x040101A5 RID: 65957
		internal static int __PropertyOffset_3;

		// Token: 0x040101A6 RID: 65958
		internal static int __PropertyOffset_4;

		// Token: 0x040101A7 RID: 65959
		internal static int __PropertyOffset_5;

		// Token: 0x040101A8 RID: 65960
		internal static int __PropertyOffset_6;

		// Token: 0x040101A9 RID: 65961
		internal static int __PropertyOffset_7;

		// Token: 0x040101AA RID: 65962
		internal static int __PropertyOffset_8;

		// Token: 0x040101AB RID: 65963
		private static IntPtr __UserConstructionScript_NativeFunctionPtr;

		// Token: 0x040101AC RID: 65964
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040101AD RID: 65965
		private static IntPtr __EditorTick_NativeFunctionPtr;

		// Token: 0x040101AE RID: 65966
		private static IntPtr __ExecuteUbergraph_BP_SplineJelly_NativeFunctionPtr;

		// Token: 0x02009989 RID: 39305
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x0403200F RID: 204815
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200998A RID: 39306
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __EditorTick_FunctionParams
		{
			// Token: 0x04032010 RID: 204816
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200998B RID: 39307
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 448)]
		protected ref struct __ExecuteUbergraph_BP_SplineJelly_FunctionParams
		{
			// Token: 0x04032011 RID: 204817
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
