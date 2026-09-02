using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Core.Fight;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.BrokenGlass
{
	// Token: 0x02003D9C RID: 15772
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow.BP_BrokenWindow_C")]
	[UnrealStructLayout(1424, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1418)]
	public class BP_BrokenWindow_C : AKuroBPActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060268FE RID: 157950 RVA: 0x009DBEF3 File Offset: 0x009DA0F3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_BrokenWindow_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow.BP_BrokenWindow_C");
			}
			return BP_BrokenWindow_C._ClassPtr;
		}

		// Token: 0x060268FF RID: 157951 RVA: 0x009DBF18 File Offset: 0x009DA118
		public BP_BrokenWindow_C() : this(BuiltinUtils.AllocNativeUObject(BP_BrokenWindow_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026900 RID: 157952 RVA: 0x009DBF40 File Offset: 0x009DA140
		public BP_BrokenWindow_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_BrokenWindow_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170057FD RID: 22525
		// (get) Token: 0x06026901 RID: 157953 RVA: 0x009DBF74 File Offset: 0x009DA174
		// (set) Token: 0x06026902 RID: 157954 RVA: 0x009DBFAD File Offset: 0x009DA1AD
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170057FE RID: 22526
		// (get) Token: 0x06026903 RID: 157955 RVA: 0x009DBFCE File Offset: 0x009DA1CE
		// (set) Token: 0x06026904 RID: 157956 RVA: 0x009DBFE2 File Offset: 0x009DA1E2
		[Nullable(2)]
		public unsafe UStaticMeshComponent Plane
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x170057FF RID: 22527
		// (get) Token: 0x06026905 RID: 157957 RVA: 0x009DBFF7 File Offset: 0x009DA1F7
		// (set) Token: 0x06026906 RID: 157958 RVA: 0x009DC00B File Offset: 0x009DA20B
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_BrokenWindow_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17005800 RID: 22528
		// (get) Token: 0x06026907 RID: 157959 RVA: 0x009DC020 File Offset: 0x009DA220
		// (set) Token: 0x06026908 RID: 157960 RVA: 0x009DC034 File Offset: 0x009DA234
		public unsafe FVector Size
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005801 RID: 22529
		// (get) Token: 0x06026909 RID: 157961 RVA: 0x009DC04C File Offset: 0x009DA24C
		// (set) Token: 0x0602690A RID: 157962 RVA: 0x009DC085 File Offset: 0x009DA285
		public TArray<FVector> UVList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FVector> result;
				if ((result = this._UVList) == null)
				{
					result = (this._UVList = new TArray<FVector>(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_4, this));
				}
				return result;
			}
			set
			{
				this.UVList.CopyAssign(value);
			}
		}

		// Token: 0x17005802 RID: 22530
		// (get) Token: 0x0602690B RID: 157963 RVA: 0x009DC093 File Offset: 0x009DA293
		// (set) Token: 0x0602690C RID: 157964 RVA: 0x009DC0A3 File Offset: 0x009DA2A3
		public unsafe int UVIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005803 RID: 22531
		// (get) Token: 0x0602690D RID: 157965 RVA: 0x009DC0B4 File Offset: 0x009DA2B4
		// (set) Token: 0x0602690E RID: 157966 RVA: 0x009DC0C4 File Offset: 0x009DA2C4
		public unsafe float HitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005804 RID: 22532
		// (get) Token: 0x0602690F RID: 157967 RVA: 0x009DC0D5 File Offset: 0x009DA2D5
		// (set) Token: 0x06026910 RID: 157968 RVA: 0x009DC0E5 File Offset: 0x009DA2E5
		public unsafe float TraceTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005805 RID: 22533
		// (get) Token: 0x06026911 RID: 157969 RVA: 0x009DC0F6 File Offset: 0x009DA2F6
		// (set) Token: 0x06026912 RID: 157970 RVA: 0x009DC10A File Offset: 0x009DA30A
		public unsafe FVector LastWeaponPoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005806 RID: 22534
		// (get) Token: 0x06026913 RID: 157971 RVA: 0x009DC11F File Offset: 0x009DA31F
		// (set) Token: 0x06026914 RID: 157972 RVA: 0x009DC12F File Offset: 0x009DA32F
		public unsafe float CrackPointState
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005807 RID: 22535
		// (get) Token: 0x06026915 RID: 157973 RVA: 0x009DC140 File Offset: 0x009DA340
		// (set) Token: 0x06026916 RID: 157974 RVA: 0x009DC179 File Offset: 0x009DA379
		public TArray<int> BitMask
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._BitMask) == null)
				{
					result = (this._BitMask = new TArray<int>(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_10, this));
				}
				return result;
			}
			set
			{
				this.BitMask.CopyAssign(value);
			}
		}

		// Token: 0x17005808 RID: 22536
		// (get) Token: 0x06026917 RID: 157975 RVA: 0x009DC187 File Offset: 0x009DA387
		// (set) Token: 0x06026918 RID: 157976 RVA: 0x009DC197 File Offset: 0x009DA397
		public unsafe int FinalStateMask
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005809 RID: 22537
		// (get) Token: 0x06026919 RID: 157977 RVA: 0x009DC1A8 File Offset: 0x009DA3A8
		// (set) Token: 0x0602691A RID: 157978 RVA: 0x009DC1B8 File Offset: 0x009DA3B8
		public unsafe float InteractRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700580A RID: 22538
		// (get) Token: 0x0602691B RID: 157979 RVA: 0x009DC1C9 File Offset: 0x009DA3C9
		// (set) Token: 0x0602691C RID: 157980 RVA: 0x009DC1D9 File Offset: 0x009DA3D9
		public unsafe bool Debug
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_13) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_13) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700580B RID: 22539
		// (get) Token: 0x0602691D RID: 157981 RVA: 0x009DC1EA File Offset: 0x009DA3EA
		// (set) Token: 0x0602691E RID: 157982 RVA: 0x009DC1FA File Offset: 0x009DA3FA
		public unsafe bool LastPointUseAble
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_BrokenWindow_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602691F RID: 157983 RVA: 0x009DC20B File Offset: 0x009DA40B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Reset()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_C.__Reset_NativeFunctionPtr, null);
		}

		// Token: 0x06026920 RID: 157984 RVA: 0x009DC220 File Offset: 0x009DA420
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_BrokenWindow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BrokenWindow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BrokenWindow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026921 RID: 157985 RVA: 0x009DC268 File Offset: 0x009DA468
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_BrokenWindow_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_BrokenWindow_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_BrokenWindow_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026922 RID: 157986 RVA: 0x009DC2B0 File Offset: 0x009DA4B0
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void OnWeaponInteraction(FVectorDouble OriginPoint, BP_SceneBattleInteract_C Config, int Id)
		{
			BP_BrokenWindow_C.__OnWeaponInteraction_FunctionParams* ptr = stackalloc BP_BrokenWindow_C.__OnWeaponInteraction_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(BP_BrokenWindow_C.__OnWeaponInteraction_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr, 1);
			ptr->OriginPoint = OriginPoint;
			ptr->Config = ((Config != null) ? Config.NativePtr : IntPtr.Zero);
			ptr->Id = Id;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_BrokenWindow_C.__OnWeaponInteraction_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06026923 RID: 157987 RVA: 0x009DC314 File Offset: 0x009DA514
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_BrokenWindow(int EntryPoint)
		{
			BP_BrokenWindow_C.__ExecuteUbergraph_BP_BrokenWindow_FunctionParams* ptr = stackalloc BP_BrokenWindow_C.__ExecuteUbergraph_BP_BrokenWindow_FunctionParams[(UIntPtr)831] + 15L / (long)sizeof(BP_BrokenWindow_C.__ExecuteUbergraph_BP_BrokenWindow_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_BrokenWindow_C.__ExecuteUbergraph_BP_BrokenWindow_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_BrokenWindow_C.__ExecuteUbergraph_BP_BrokenWindow_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06026924 RID: 157988 RVA: 0x009DC35E File Offset: 0x009DA55E
		protected BP_BrokenWindow_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040140DD RID: 82141
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/BrokenGlass/BP_BrokenWindow.BP_BrokenWindow_C";

		// Token: 0x040140DE RID: 82142
		private static IntPtr _ClassPtr;

		// Token: 0x040140DF RID: 82143
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040140E0 RID: 82144
		internal static int __PropertyOffset_0;

		// Token: 0x040140E1 RID: 82145
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x040140E2 RID: 82146
		internal static int __PropertyOffset_1;

		// Token: 0x040140E3 RID: 82147
		internal static int __PropertyOffset_2;

		// Token: 0x040140E4 RID: 82148
		internal static int __PropertyOffset_3;

		// Token: 0x040140E5 RID: 82149
		internal static int __PropertyOffset_4;

		// Token: 0x040140E6 RID: 82150
		[Nullable(2)]
		private TArray<FVector> _UVList;

		// Token: 0x040140E7 RID: 82151
		internal static int __PropertyOffset_5;

		// Token: 0x040140E8 RID: 82152
		internal static int __PropertyOffset_6;

		// Token: 0x040140E9 RID: 82153
		internal static int __PropertyOffset_7;

		// Token: 0x040140EA RID: 82154
		internal static int __PropertyOffset_8;

		// Token: 0x040140EB RID: 82155
		internal static int __PropertyOffset_9;

		// Token: 0x040140EC RID: 82156
		internal static int __PropertyOffset_10;

		// Token: 0x040140ED RID: 82157
		[Nullable(2)]
		private TArray<int> _BitMask;

		// Token: 0x040140EE RID: 82158
		internal static int __PropertyOffset_11;

		// Token: 0x040140EF RID: 82159
		internal static int __PropertyOffset_12;

		// Token: 0x040140F0 RID: 82160
		internal static int __PropertyOffset_13;

		// Token: 0x040140F1 RID: 82161
		internal static int __PropertyOffset_14;

		// Token: 0x040140F2 RID: 82162
		private static IntPtr __Reset_NativeFunctionPtr;

		// Token: 0x040140F3 RID: 82163
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x040140F4 RID: 82164
		private static IntPtr __OnWeaponInteraction_NativeFunctionPtr;

		// Token: 0x040140F5 RID: 82165
		private static IntPtr __ExecuteUbergraph_BP_BrokenWindow_NativeFunctionPtr;

		// Token: 0x0200A08E RID: 41102
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x04032D29 RID: 208169
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A08F RID: 41103
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __OnWeaponInteraction_FunctionParams
		{
			// Token: 0x04032D2A RID: 208170
			[FieldOffset(0)]
			public FVectorDouble OriginPoint;

			// Token: 0x04032D2B RID: 208171
			[FieldOffset(24)]
			public IntPtr Config;

			// Token: 0x04032D2C RID: 208172
			[FieldOffset(32)]
			public int Id;
		}

		// Token: 0x0200A090 RID: 41104
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 816)]
		protected ref struct __ExecuteUbergraph_BP_BrokenWindow_FunctionParams
		{
			// Token: 0x04032D2D RID: 208173
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
