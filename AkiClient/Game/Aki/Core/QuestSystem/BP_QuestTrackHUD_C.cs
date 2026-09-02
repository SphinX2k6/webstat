using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.QuestSystem
{
	// Token: 0x02003F48 RID: 16200
	[UnrealObjectPath("/Game/Aki/Core/QuestSystem/BP_QuestTrackHUD.BP_QuestTrackHUD_C")]
	[UnrealStructLayout(1392, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1385)]
	public class BP_QuestTrackHUD_C : AHUD, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602874B RID: 165707 RVA: 0x00A0B838 File Offset: 0x00A09A38
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_QuestTrackHUD_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/QuestSystem/BP_QuestTrackHUD.BP_QuestTrackHUD_C");
			}
			return BP_QuestTrackHUD_C._ClassPtr;
		}

		// Token: 0x0602874C RID: 165708 RVA: 0x00A0B85C File Offset: 0x00A09A5C
		public BP_QuestTrackHUD_C() : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrackHUD_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602874D RID: 165709 RVA: 0x00A0B884 File Offset: 0x00A09A84
		[NullableContext(1)]
		public BP_QuestTrackHUD_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_QuestTrackHUD_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17006252 RID: 25170
		// (get) Token: 0x0602874E RID: 165710 RVA: 0x00A0B8B8 File Offset: 0x00A09AB8
		// (set) Token: 0x0602874F RID: 165711 RVA: 0x00A0B8F1 File Offset: 0x00A09AF1
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17006253 RID: 25171
		// (get) Token: 0x06028750 RID: 165712 RVA: 0x00A0B912 File Offset: 0x00A09B12
		// (set) Token: 0x06028751 RID: 165713 RVA: 0x00A0B926 File Offset: 0x00A09B26
		[Nullable(2)]
		public unsafe USceneComponent DefaultSceneRoot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrackHUD_C.__PropertyOffset_1);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrackHUD_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17006254 RID: 25172
		// (get) Token: 0x06028752 RID: 165714 RVA: 0x00A0B93B File Offset: 0x00A09B3B
		// (set) Token: 0x06028753 RID: 165715 RVA: 0x00A0B94F File Offset: 0x00A09B4F
		public unsafe FBox2D LimitedBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17006255 RID: 25173
		// (get) Token: 0x06028754 RID: 165716 RVA: 0x00A0B964 File Offset: 0x00A09B64
		// (set) Token: 0x06028755 RID: 165717 RVA: 0x00A0B978 File Offset: 0x00A09B78
		public unsafe FVector2D LimitedScaler
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17006256 RID: 25174
		// (get) Token: 0x06028756 RID: 165718 RVA: 0x00A0B98D File Offset: 0x00A09B8D
		// (set) Token: 0x06028757 RID: 165719 RVA: 0x00A0B9A1 File Offset: 0x00A09BA1
		public unsafe FVector2D ScreenPositon
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17006257 RID: 25175
		// (get) Token: 0x06028758 RID: 165720 RVA: 0x00A0B9B6 File Offset: 0x00A09BB6
		// (set) Token: 0x06028759 RID: 165721 RVA: 0x00A0B9CA File Offset: 0x00A09BCA
		[Nullable(2)]
		public unsafe AActor QuestObject
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<AActor>(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrackHUD_C.__PropertyOffset_5);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_QuestTrackHUD_C.__PropertyOffset_5, value);
			}
		}

		// Token: 0x17006258 RID: 25176
		// (get) Token: 0x0602875A RID: 165722 RVA: 0x00A0B9DF File Offset: 0x00A09BDF
		// (set) Token: 0x0602875B RID: 165723 RVA: 0x00A0B9F3 File Offset: 0x00A09BF3
		public unsafe FLinearColor CurrentColor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17006259 RID: 25177
		// (get) Token: 0x0602875C RID: 165724 RVA: 0x00A0BA08 File Offset: 0x00A09C08
		// (set) Token: 0x0602875D RID: 165725 RVA: 0x00A0BA18 File Offset: 0x00A09C18
		public unsafe float innerRadius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x1700625A RID: 25178
		// (get) Token: 0x0602875E RID: 165726 RVA: 0x00A0BA29 File Offset: 0x00A09C29
		// (set) Token: 0x0602875F RID: 165727 RVA: 0x00A0BA39 File Offset: 0x00A09C39
		public unsafe float tempX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x1700625B RID: 25179
		// (get) Token: 0x06028760 RID: 165728 RVA: 0x00A0BA4A File Offset: 0x00A09C4A
		// (set) Token: 0x06028761 RID: 165729 RVA: 0x00A0BA5A File Offset: 0x00A09C5A
		public unsafe float tempY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x1700625C RID: 25180
		// (get) Token: 0x06028762 RID: 165730 RVA: 0x00A0BA6B File Offset: 0x00A09C6B
		// (set) Token: 0x06028763 RID: 165731 RVA: 0x00A0BA7B File Offset: 0x00A09C7B
		public unsafe float tempLX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x1700625D RID: 25181
		// (get) Token: 0x06028764 RID: 165732 RVA: 0x00A0BA8C File Offset: 0x00A09C8C
		// (set) Token: 0x06028765 RID: 165733 RVA: 0x00A0BA9C File Offset: 0x00A09C9C
		public unsafe float tempLY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x1700625E RID: 25182
		// (get) Token: 0x06028766 RID: 165734 RVA: 0x00A0BAAD File Offset: 0x00A09CAD
		// (set) Token: 0x06028767 RID: 165735 RVA: 0x00A0BABD File Offset: 0x00A09CBD
		public unsafe float tempLZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x1700625F RID: 25183
		// (get) Token: 0x06028768 RID: 165736 RVA: 0x00A0BACE File Offset: 0x00A09CCE
		// (set) Token: 0x06028769 RID: 165737 RVA: 0x00A0BADE File Offset: 0x00A09CDE
		public unsafe float ViewportSizeX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17006260 RID: 25184
		// (get) Token: 0x0602876A RID: 165738 RVA: 0x00A0BAEF File Offset: 0x00A09CEF
		// (set) Token: 0x0602876B RID: 165739 RVA: 0x00A0BAFF File Offset: 0x00A09CFF
		public unsafe float ViewportSizeY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17006261 RID: 25185
		// (get) Token: 0x0602876C RID: 165740 RVA: 0x00A0BB10 File Offset: 0x00A09D10
		// (set) Token: 0x0602876D RID: 165741 RVA: 0x00A0BB20 File Offset: 0x00A09D20
		public unsafe bool DisplayDistance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_15) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_QuestTrackHUD_C.__PropertyOffset_15) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602876E RID: 165742 RVA: 0x00A0BB34 File Offset: 0x00A09D34
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void ReCalBounds(float inX, float inY)
		{
			BP_QuestTrackHUD_C.__ReCalBounds_FunctionParams* ptr = stackalloc BP_QuestTrackHUD_C.__ReCalBounds_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrackHUD_C.__ReCalBounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD_C.__ReCalBounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inX = inX;
			ptr->inY = inY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD_C.__ReCalBounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602876F RID: 165743 RVA: 0x00A0BB84 File Offset: 0x00A09D84
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void CaclBounds(float inX, float inY)
		{
			BP_QuestTrackHUD_C.__CaclBounds_FunctionParams* ptr = stackalloc BP_QuestTrackHUD_C.__CaclBounds_FunctionParams[(UIntPtr)131] + 15L / (long)sizeof(BP_QuestTrackHUD_C.__CaclBounds_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD_C.__CaclBounds_NativeFunctionPtr, (void*)ptr, 1);
			ptr->inX = inX;
			ptr->inY = inY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD_C.__CaclBounds_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028770 RID: 165744 RVA: 0x00A0BBD4 File Offset: 0x00A09DD4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveDrawHUD(int SizeX, int SizeY)
		{
			BP_QuestTrackHUD_C.__ReceiveDrawHUD_FunctionParams* ptr = stackalloc BP_QuestTrackHUD_C.__ReceiveDrawHUD_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrackHUD_C.__ReceiveDrawHUD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SizeX = SizeX;
			ptr->SizeY = SizeY;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_QuestTrackHUD_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06028771 RID: 165745 RVA: 0x00A0BC24 File Offset: 0x00A09E24
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveDrawHUD_Implementation(int SizeX, int SizeY)
		{
			BP_QuestTrackHUD_C.__ReceiveDrawHUD_FunctionParams* ptr = stackalloc BP_QuestTrackHUD_C.__ReceiveDrawHUD_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(BP_QuestTrackHUD_C.__ReceiveDrawHUD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->SizeX = SizeX;
			ptr->SizeY = SizeY;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrackHUD_C.__ReceiveDrawHUD_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028772 RID: 165746 RVA: 0x00A0BC74 File Offset: 0x00A09E74
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_QuestTrackHUD(int EntryPoint)
		{
			BP_QuestTrackHUD_C.__ExecuteUbergraph_BP_QuestTrackHUD_FunctionParams* ptr = stackalloc BP_QuestTrackHUD_C.__ExecuteUbergraph_BP_QuestTrackHUD_FunctionParams[(UIntPtr)27] + 15L / (long)sizeof(BP_QuestTrackHUD_C.__ExecuteUbergraph_BP_QuestTrackHUD_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_QuestTrackHUD_C.__ExecuteUbergraph_BP_QuestTrackHUD_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_QuestTrackHUD_C.__ExecuteUbergraph_BP_QuestTrackHUD_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06028773 RID: 165747 RVA: 0x00A0BCBB File Offset: 0x00A09EBB
		protected BP_QuestTrackHUD_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401548E RID: 87182
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Core/QuestSystem/BP_QuestTrackHUD.BP_QuestTrackHUD_C";

		// Token: 0x0401548F RID: 87183
		private static IntPtr _ClassPtr;

		// Token: 0x04015490 RID: 87184
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015491 RID: 87185
		internal static int __PropertyOffset_0;

		// Token: 0x04015492 RID: 87186
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04015493 RID: 87187
		internal static int __PropertyOffset_1;

		// Token: 0x04015494 RID: 87188
		internal static int __PropertyOffset_2;

		// Token: 0x04015495 RID: 87189
		internal static int __PropertyOffset_3;

		// Token: 0x04015496 RID: 87190
		internal static int __PropertyOffset_4;

		// Token: 0x04015497 RID: 87191
		internal static int __PropertyOffset_5;

		// Token: 0x04015498 RID: 87192
		internal static int __PropertyOffset_6;

		// Token: 0x04015499 RID: 87193
		internal static int __PropertyOffset_7;

		// Token: 0x0401549A RID: 87194
		internal static int __PropertyOffset_8;

		// Token: 0x0401549B RID: 87195
		internal static int __PropertyOffset_9;

		// Token: 0x0401549C RID: 87196
		internal static int __PropertyOffset_10;

		// Token: 0x0401549D RID: 87197
		internal static int __PropertyOffset_11;

		// Token: 0x0401549E RID: 87198
		internal static int __PropertyOffset_12;

		// Token: 0x0401549F RID: 87199
		internal static int __PropertyOffset_13;

		// Token: 0x040154A0 RID: 87200
		internal static int __PropertyOffset_14;

		// Token: 0x040154A1 RID: 87201
		internal static int __PropertyOffset_15;

		// Token: 0x040154A2 RID: 87202
		private static IntPtr __ReCalBounds_NativeFunctionPtr;

		// Token: 0x040154A3 RID: 87203
		private static IntPtr __CaclBounds_NativeFunctionPtr;

		// Token: 0x040154A4 RID: 87204
		private static IntPtr __ReceiveDrawHUD_NativeFunctionPtr;

		// Token: 0x040154A5 RID: 87205
		private static IntPtr __ExecuteUbergraph_BP_QuestTrackHUD_NativeFunctionPtr;

		// Token: 0x0200A0FF RID: 41215
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __ReCalBounds_FunctionParams
		{
			// Token: 0x04032DE4 RID: 208356
			[FieldOffset(0)]
			public float inX;

			// Token: 0x04032DE5 RID: 208357
			[FieldOffset(4)]
			public float inY;
		}

		// Token: 0x0200A100 RID: 41216
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 116)]
		protected ref struct __CaclBounds_FunctionParams
		{
			// Token: 0x04032DE6 RID: 208358
			[FieldOffset(0)]
			public float inX;

			// Token: 0x04032DE7 RID: 208359
			[FieldOffset(4)]
			public float inY;
		}

		// Token: 0x0200A101 RID: 41217
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected new ref struct __ReceiveDrawHUD_FunctionParams
		{
			// Token: 0x04032DE8 RID: 208360
			[FieldOffset(0)]
			public int SizeX;

			// Token: 0x04032DE9 RID: 208361
			[FieldOffset(4)]
			public int SizeY;
		}

		// Token: 0x0200A102 RID: 41218
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 12)]
		protected ref struct __ExecuteUbergraph_BP_QuestTrackHUD_FunctionParams
		{
			// Token: 0x04032DEA RID: 208362
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
