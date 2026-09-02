using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.QuestSystem
{
	// Token: 0x02003F47 RID: 16199
	[UnrealObjectPath("/Game/Aki/Core/QuestSystem/BP_QuestTrackHUD1.BP_QuestTrackHUD1_C")]
	[UnrealStructLayout(1440, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1436)]
	public class BP_QuestTrackHUD1_C : AHUD, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028726 RID: 165670 RVA: 0x00A0B2B3 File Offset: 0x00A094B3
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QuestTrackHUD1_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/QuestSystem/BP_QuestTrackHUD1.BP_QuestTrackHUD1_C");
			}
			return BP_QuestTrackHUD1_C._ClassPtr;
		}

		// Token: 0x06028727 RID: 165671 RVA: 0x00A0B2D8 File Offset: 0x00A094D8
		public BP_QuestTrackHUD1_C() : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrackHUD1_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028728 RID: 165672 RVA: 0x00A0B300 File Offset: 0x00A09500
		[NullableContext(1)]
		public BP_QuestTrackHUD1_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrackHUD1_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006247 RID: 25159
		// (get) Token: 0x06028729 RID: 165673 RVA: 0x00A0B334 File Offset: 0x00A09534
		// (set) Token: 0x0602872A RID: 165674 RVA: 0x00A0B36D File Offset: 0x00A0956D
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006248 RID: 25160
		// (get) Token: 0x0602872B RID: 165675 RVA: 0x00A0B38E File Offset: 0x00A0958E
		// (set) Token: 0x0602872C RID: 165676 RVA: 0x00A0B3A2 File Offset: 0x00A095A2
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrackHUD1_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrackHUD1_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006249 RID: 25161
		// (get) Token: 0x0602872D RID: 165677 RVA: 0x00A0B3B7 File Offset: 0x00A095B7
		// (set) Token: 0x0602872E RID: 165678 RVA: 0x00A0B3CB File Offset: 0x00A095CB
		public unsafe FBox2D LimitedBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x1700624A RID: 25162
		// (get) Token: 0x0602872F RID: 165679 RVA: 0x00A0B3E0 File Offset: 0x00A095E0
		// (set) Token: 0x06028730 RID: 165680 RVA: 0x00A0B3F4 File Offset: 0x00A095F4
		public unsafe FVector2D LimitedScaler
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x1700624B RID: 25163
		// (get) Token: 0x06028731 RID: 165681 RVA: 0x00A0B409 File Offset: 0x00A09609
		// (set) Token: 0x06028732 RID: 165682 RVA: 0x00A0B41D File Offset: 0x00A0961D
		public unsafe FLinearColor CurrentColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x1700624C RID: 25164
		// (get) Token: 0x06028733 RID: 165683 RVA: 0x00A0B432 File Offset: 0x00A09632
		// (set) Token: 0x06028734 RID: 165684 RVA: 0x00A0B442 File Offset: 0x00A09642
		public unsafe float innerRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x1700624D RID: 25165
		// (get) Token: 0x06028735 RID: 165685 RVA: 0x00A0B453 File Offset: 0x00A09653
		// (set) Token: 0x06028736 RID: 165686 RVA: 0x00A0B463 File Offset: 0x00A09663
		public unsafe float ViewportSizeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x1700624E RID: 25166
		// (get) Token: 0x06028737 RID: 165687 RVA: 0x00A0B474 File Offset: 0x00A09674
		// (set) Token: 0x06028738 RID: 165688 RVA: 0x00A0B484 File Offset: 0x00A09684
		public unsafe float ViewportSizeY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700624F RID: 25167
		// (get) Token: 0x06028739 RID: 165689 RVA: 0x00A0B495 File Offset: 0x00A09695
		// (set) Token: 0x0602873A RID: 165690 RVA: 0x00A0B4A5 File Offset: 0x00A096A5
		public unsafe bool IsShow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006250 RID: 25168
		// (get) Token: 0x0602873B RID: 165691 RVA: 0x00A0B4B8 File Offset: 0x00A096B8
		// (set) Token: 0x0602873C RID: 165692 RVA: 0x00A0B4F1 File Offset: 0x00A096F1
		[Nullable(1)]
		public TMap<int, FVector> TrackPositions
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				TMap<int, FVector> result;
				if ((result = this._TrackPositions) == null)
				{
					result = (this._TrackPositions = new TMap<int, FVector>(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_9, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				this.TrackPositions.CopyAssign(value);
			}
		}

		// Token: 0x17006251 RID: 25169
		// (get) Token: 0x0602873D RID: 165693 RVA: 0x00A0B4FF File Offset: 0x00A096FF
		// (set) Token: 0x0602873E RID: 165694 RVA: 0x00A0B50F File Offset: 0x00A0970F
		public unsafe float DefaultScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD1_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x0602873F RID: 165695 RVA: 0x00A0B520 File Offset: 0x00A09720
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShowTracks(int X, int Y)
		{
			BP_QuestTrackHUD1_C.__ShowTracks_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__ShowTracks_FunctionParams[(UIntPtr)79] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__ShowTracks_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__ShowTracks_NativeFunctionPtr, (void*)ptr, 1);
			ptr->X = X;
			ptr->Y = Y;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ShowTracks_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028740 RID: 165696 RVA: 0x00A0B570 File Offset: 0x00A09770
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ShowTrack(int X, int Y, FVector TrackPos)
		{
			BP_QuestTrackHUD1_C.__ShowTrack_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__ShowTrack_FunctionParams[(UIntPtr)703] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__ShowTrack_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__ShowTrack_NativeFunctionPtr, (void*)ptr, 1);
			ptr->X = X;
			ptr->Y = Y;
			ptr->TrackPos = TrackPos;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ShowTrack_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028741 RID: 165697 RVA: 0x00A0B5C8 File Offset: 0x00A097C8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetTrackPos(bool valuie, FVector pos, int MarkId)
		{
			BP_QuestTrackHUD1_C.__SetTrackPos_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__SetTrackPos_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__SetTrackPos_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__SetTrackPos_NativeFunctionPtr, (void*)ptr, 1);
			ptr->valuie = valuie;
			ptr->pos = pos;
			ptr->MarkId = MarkId;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__SetTrackPos_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028742 RID: 165698 RVA: 0x00A0B61C File Offset: 0x00A0981C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void GetVectorAngle(FVector2D vector1, FVector2D vector2, ref float value)
		{
			BP_QuestTrackHUD1_C.__GetVectorAngle_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__GetVectorAngle_FunctionParams[(UIntPtr)75] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__GetVectorAngle_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__GetVectorAngle_NativeFunctionPtr, (void*)ptr, 1);
			ptr->vector1 = vector1;
			ptr->vector2 = vector2;
			ptr->value = value;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__GetVectorAngle_NativeFunctionPtr, (void*)ptr);
			value = ptr->value;
		}

		// Token: 0x06028743 RID: 165699 RVA: 0x00A0B67C File Offset: 0x00A0987C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReCalBounds(float inX, float inY)
		{
			BP_QuestTrackHUD1_C.__ReCalBounds_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__ReCalBounds_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__ReCalBounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__ReCalBounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inX = inX;
			ptr->inY = inY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ReCalBounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028744 RID: 165700 RVA: 0x00A0B6CC File Offset: 0x00A098CC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CaclBounds(float inX, float inY)
		{
			BP_QuestTrackHUD1_C.__CaclBounds_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__CaclBounds_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__CaclBounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__CaclBounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inX = inX;
			ptr->inY = inY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__CaclBounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028745 RID: 165701 RVA: 0x00A0B71C File Offset: 0x00A0991C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06028746 RID: 165702 RVA: 0x00A0B730 File Offset: 0x00A09930
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06028747 RID: 165703 RVA: 0x00A0B748 File Offset: 0x00A09948
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveDrawHUD(int SizeX, int SizeY)
		{
			BP_QuestTrackHUD1_C.__ReceiveDrawHUD_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__ReceiveDrawHUD_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__ReceiveDrawHUD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SizeX = SizeX;
			ptr->SizeY = SizeY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028748 RID: 165704 RVA: 0x00A0B798 File Offset: 0x00A09998
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveDrawHUD_Implementation(int SizeX, int SizeY)
		{
			BP_QuestTrackHUD1_C.__ReceiveDrawHUD_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__ReceiveDrawHUD_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__ReceiveDrawHUD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SizeX = SizeX;
			ptr->SizeY = SizeY;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028749 RID: 165705 RVA: 0x00A0B7E8 File Offset: 0x00A099E8
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QuestTrackHUD1(int EntryPoint)
		{
			BP_QuestTrackHUD1_C.__ExecuteUbergraph_BP_QuestTrackHUD1_FunctionParams* ptr = stackalloc BP_QuestTrackHUD1_C.__ExecuteUbergraph_BP_QuestTrackHUD1_FunctionParams[(UIntPtr)63] + 15L / (long)sizeof(BP_QuestTrackHUD1_C.__ExecuteUbergraph_BP_QuestTrackHUD1_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD1_C.__ExecuteUbergraph_BP_QuestTrackHUD1_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrackHUD1_C.__ExecuteUbergraph_BP_QuestTrackHUD1_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602874A RID: 165706 RVA: 0x00A0B82F File Offset: 0x00A09A2F
		protected BP_QuestTrackHUD1_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015475 RID: 87157
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/QuestSystem/BP_QuestTrackHUD1.BP_QuestTrackHUD1_C";

		// Token: 0x04015476 RID: 87158
		private static IntPtr _ClassPtr;

		// Token: 0x04015477 RID: 87159
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015478 RID: 87160
		internal static int __PropertyOffset_0;

		// Token: 0x04015479 RID: 87161
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401547A RID: 87162
		internal static int __PropertyOffset_1;

		// Token: 0x0401547B RID: 87163
		internal static int __PropertyOffset_2;

		// Token: 0x0401547C RID: 87164
		internal static int __PropertyOffset_3;

		// Token: 0x0401547D RID: 87165
		internal static int __PropertyOffset_4;

		// Token: 0x0401547E RID: 87166
		internal static int __PropertyOffset_5;

		// Token: 0x0401547F RID: 87167
		internal static int __PropertyOffset_6;

		// Token: 0x04015480 RID: 87168
		internal static int __PropertyOffset_7;

		// Token: 0x04015481 RID: 87169
		internal static int __PropertyOffset_8;

		// Token: 0x04015482 RID: 87170
		internal static int __PropertyOffset_9;

		// Token: 0x04015483 RID: 87171
		[Nullable(2)]
		private TMap<int, FVector> _TrackPositions;

		// Token: 0x04015484 RID: 87172
		internal static int __PropertyOffset_10;

		// Token: 0x04015485 RID: 87173
		private static IntPtr __ShowTracks_NativeFunctionPtr;

		// Token: 0x04015486 RID: 87174
		private static IntPtr __ShowTrack_NativeFunctionPtr;

		// Token: 0x04015487 RID: 87175
		private static IntPtr __SetTrackPos_NativeFunctionPtr;

		// Token: 0x04015488 RID: 87176
		private static IntPtr __GetVectorAngle_NativeFunctionPtr;

		// Token: 0x04015489 RID: 87177
		private static IntPtr __ReCalBounds_NativeFunctionPtr;

		// Token: 0x0401548A RID: 87178
		private static IntPtr __CaclBounds_NativeFunctionPtr;

		// Token: 0x0401548B RID: 87179
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401548C RID: 87180
		private static IntPtr __ReceiveDrawHUD_NativeFunctionPtr;

		// Token: 0x0401548D RID: 87181
		private static IntPtr __ExecuteUbergraph_BP_QuestTrackHUD1_NativeFunctionPtr;

		// Token: 0x0200A0F7 RID: 41207
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 64)]
		protected ref struct __ShowTracks_FunctionParams
		{
			// Token: 0x04032DD2 RID: 208338
			[FieldOffset(0)]
			public int X;

			// Token: 0x04032DD3 RID: 208339
			[FieldOffset(4)]
			public int Y;
		}

		// Token: 0x0200A0F8 RID: 41208
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 688)]
		protected ref struct __ShowTrack_FunctionParams
		{
			// Token: 0x04032DD4 RID: 208340
			[FieldOffset(0)]
			public int X;

			// Token: 0x04032DD5 RID: 208341
			[FieldOffset(4)]
			public int Y;

			// Token: 0x04032DD6 RID: 208342
			[FieldOffset(8)]
			public FVector TrackPos;
		}

		// Token: 0x0200A0F9 RID: 41209
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __SetTrackPos_FunctionParams
		{
			// Token: 0x04032DD7 RID: 208343
			[FieldOffset(0)]
			public bool valuie;

			// Token: 0x04032DD8 RID: 208344
			[FieldOffset(4)]
			public FVector pos;

			// Token: 0x04032DD9 RID: 208345
			[FieldOffset(16)]
			public int MarkId;
		}

		// Token: 0x0200A0FA RID: 41210
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 60)]
		protected ref struct __GetVectorAngle_FunctionParams
		{
			// Token: 0x04032DDA RID: 208346
			[FieldOffset(0)]
			public FVector2D vector1;

			// Token: 0x04032DDB RID: 208347
			[FieldOffset(8)]
			public FVector2D vector2;

			// Token: 0x04032DDC RID: 208348
			[FieldOffset(16)]
			public float value;
		}

		// Token: 0x0200A0FB RID: 41211
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ReCalBounds_FunctionParams
		{
			// Token: 0x04032DDD RID: 208349
			[FieldOffset(0)]
			public float inX;

			// Token: 0x04032DDE RID: 208350
			[FieldOffset(4)]
			public float inY;
		}

		// Token: 0x0200A0FC RID: 41212
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __CaclBounds_FunctionParams
		{
			// Token: 0x04032DDF RID: 208351
			[FieldOffset(0)]
			public float inX;

			// Token: 0x04032DE0 RID: 208352
			[FieldOffset(4)]
			public float inY;
		}

		// Token: 0x0200A0FD RID: 41213
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveDrawHUD_FunctionParams
		{
			// Token: 0x04032DE1 RID: 208353
			[FieldOffset(0)]
			public int SizeX;

			// Token: 0x04032DE2 RID: 208354
			[FieldOffset(4)]
			public int SizeY;
		}

		// Token: 0x0200A0FE RID: 41214
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 48)]
		protected ref struct __ExecuteUbergraph_BP_QuestTrackHUD1_FunctionParams
		{
			// Token: 0x04032DE3 RID: 208355
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
