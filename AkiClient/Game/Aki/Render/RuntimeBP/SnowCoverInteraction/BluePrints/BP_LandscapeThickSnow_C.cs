using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.SnowCoverInteraction.BluePrints
{
	// Token: 0x02003A50 RID: 14928
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_LandscapeThickSnow.BP_LandscapeThickSnow_C")]
	[UnrealStructLayout(1448, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1448)]
	public class BP_LandscapeThickSnow_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0601EEFB RID: 126715 RVA: 0x009029C0 File Offset: 0x00900BC0
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_LandscapeThickSnow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_LandscapeThickSnow.BP_LandscapeThickSnow_C");
			}
			return BP_LandscapeThickSnow_C._ClassPtr;
		}

		// Token: 0x0601EEFC RID: 126716 RVA: 0x009029E4 File Offset: 0x00900BE4
		public BP_LandscapeThickSnow_C() : this(BuiltinUtils.AllocNativeUObject(BP_LandscapeThickSnow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0601EEFD RID: 126717 RVA: 0x00902A0C File Offset: 0x00900C0C
		public BP_LandscapeThickSnow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_LandscapeThickSnow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17002D37 RID: 11575
		// (get) Token: 0x0601EEFE RID: 126718 RVA: 0x00902A40 File Offset: 0x00900C40
		// (set) Token: 0x0601EEFF RID: 126719 RVA: 0x00902A79 File Offset: 0x00900C79
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D38 RID: 11576
		// (get) Token: 0x0601EF00 RID: 126720 RVA: 0x00902A9A File Offset: 0x00900C9A
		// (set) Token: 0x0601EF01 RID: 126721 RVA: 0x00902AAE File Offset: 0x00900CAE
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_LandscapeThickSnow_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_LandscapeThickSnow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17002D39 RID: 11577
		// (get) Token: 0x0601EF02 RID: 126722 RVA: 0x00902AC3 File Offset: 0x00900CC3
		// (set) Token: 0x0601EF03 RID: 126723 RVA: 0x00902AD3 File Offset: 0x00900CD3
		public unsafe bool IsSetHeightArea
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17002D3A RID: 11578
		// (get) Token: 0x0601EF04 RID: 126724 RVA: 0x00902AE4 File Offset: 0x00900CE4
		// (set) Token: 0x0601EF05 RID: 126725 RVA: 0x00902AF4 File Offset: 0x00900CF4
		public unsafe float OriginWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17002D3B RID: 11579
		// (get) Token: 0x0601EF06 RID: 126726 RVA: 0x00902B05 File Offset: 0x00900D05
		// (set) Token: 0x0601EF07 RID: 126727 RVA: 0x00902B15 File Offset: 0x00900D15
		public unsafe float ThickSnowHeight
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17002D3C RID: 11580
		// (get) Token: 0x0601EF08 RID: 126728 RVA: 0x00902B26 File Offset: 0x00900D26
		// (set) Token: 0x0601EF09 RID: 126729 RVA: 0x00902B3A File Offset: 0x00900D3A
		public unsafe string WorldHeightName_
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17002D3D RID: 11581
		// (get) Token: 0x0601EF0A RID: 126730 RVA: 0x00902B4F File Offset: 0x00900D4F
		// (set) Token: 0x0601EF0B RID: 126731 RVA: 0x00902B63 File Offset: 0x00900D63
		public unsafe string EdgeWidthName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x17002D3E RID: 11582
		// (get) Token: 0x0601EF0C RID: 126732 RVA: 0x00902B78 File Offset: 0x00900D78
		// (set) Token: 0x0601EF0D RID: 126733 RVA: 0x00902BB1 File Offset: 0x00900DB1
		public TSet<string> PhysicMaterialSet
		{
			get
			{
				base.FastCheckIsValid();
				TSet<string> result;
				if ((result = this._PhysicMaterialSet) == null)
				{
					result = (this._PhysicMaterialSet = new TSet<string>(base.NativePtr + (IntPtr)BP_LandscapeThickSnow_C.__PropertyOffset_7, this));
				}
				return result;
			}
			set
			{
				this.PhysicMaterialSet.CopyAssign(value);
			}
		}

		// Token: 0x0601EF0E RID: 126734 RVA: 0x00902BBF File Offset: 0x00900DBF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LandscapeThickSnow_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0601EF0F RID: 126735 RVA: 0x00902BD3 File Offset: 0x00900DD3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LandscapeThickSnow_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0601EF10 RID: 126736 RVA: 0x00902BE8 File Offset: 0x00900DE8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_LandscapeThickSnow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LandscapeThickSnow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LandscapeThickSnow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LandscapeThickSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_LandscapeThickSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0601EF11 RID: 126737 RVA: 0x00902C30 File Offset: 0x00900E30
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_LandscapeThickSnow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_LandscapeThickSnow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_LandscapeThickSnow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LandscapeThickSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LandscapeThickSnow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF12 RID: 126738 RVA: 0x00902C78 File Offset: 0x00900E78
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_LandscapeThickSnow(int EntryPoint)
		{
			BP_LandscapeThickSnow_C.__ExecuteUbergraph_BP_LandscapeThickSnow_FunctionParams* ptr = stackalloc BP_LandscapeThickSnow_C.__ExecuteUbergraph_BP_LandscapeThickSnow_FunctionParams[(UIntPtr)407] + 15L / (long)sizeof(BP_LandscapeThickSnow_C.__ExecuteUbergraph_BP_LandscapeThickSnow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_LandscapeThickSnow_C.__ExecuteUbergraph_BP_LandscapeThickSnow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_LandscapeThickSnow_C.__ExecuteUbergraph_BP_LandscapeThickSnow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0601EF13 RID: 126739 RVA: 0x00902CC2 File Offset: 0x00900EC2
		protected BP_LandscapeThickSnow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0400F4B8 RID: 62648
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/SnowCoverInteraction/BluePrints/BP_LandscapeThickSnow.BP_LandscapeThickSnow_C";

		// Token: 0x0400F4B9 RID: 62649
		private static IntPtr _ClassPtr;

		// Token: 0x0400F4BA RID: 62650
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0400F4BB RID: 62651
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4BC RID: 62652
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0400F4BD RID: 62653
		internal static int __PropertyOffset_1;

		// Token: 0x0400F4BE RID: 62654
		internal static int __PropertyOffset_2;

		// Token: 0x0400F4BF RID: 62655
		internal static int __PropertyOffset_3;

		// Token: 0x0400F4C0 RID: 62656
		internal static int __PropertyOffset_4;

		// Token: 0x0400F4C1 RID: 62657
		internal static int __PropertyOffset_5;

		// Token: 0x0400F4C2 RID: 62658
		internal static int __PropertyOffset_6;

		// Token: 0x0400F4C3 RID: 62659
		internal static int __PropertyOffset_7;

		// Token: 0x0400F4C4 RID: 62660
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TSet<string> _PhysicMaterialSet;

		// Token: 0x0400F4C5 RID: 62661
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0400F4C6 RID: 62662
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x0400F4C7 RID: 62663
		private static IntPtr __ExecuteUbergraph_BP_LandscapeThickSnow_NativeFunctionPtr;

		// Token: 0x02009820 RID: 38944
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04031E3F RID: 204351
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009821 RID: 38945
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 392)]
		protected ref struct __ExecuteUbergraph_BP_LandscapeThickSnow_FunctionParams
		{
			// Token: 0x04031E40 RID: 204352
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
