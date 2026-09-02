using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004379 RID: 17273
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/BP_AudioVisualizer.BP_AudioVisualizer_C")]
	[UnrealStructLayout(1208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 1208)]
	public class BP_AudioVisualizer_C : AActor, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602DC29 RID: 187433 RVA: 0x00ACB4EC File Offset: 0x00AC96EC
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_AudioVisualizer_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Audio/BP_AudioVisualizer.BP_AudioVisualizer_C");
			}
			return BP_AudioVisualizer_C._ClassPtr;
		}

		// Token: 0x0602DC2A RID: 187434 RVA: 0x00ACB510 File Offset: 0x00AC9710
		public BP_AudioVisualizer_C() : this(BuiltinUtils.AllocNativeUObject(BP_AudioVisualizer_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602DC2B RID: 187435 RVA: 0x00ACB538 File Offset: 0x00AC9738
		[NullableContext(1)]
		public BP_AudioVisualizer_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_AudioVisualizer_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007D4B RID: 32075
		// (get) Token: 0x0602DC2C RID: 187436 RVA: 0x00ACB56C File Offset: 0x00AC976C
		// (set) Token: 0x0602DC2D RID: 187437 RVA: 0x00ACB5A5 File Offset: 0x00AC97A5
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
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D4C RID: 32076
		// (get) Token: 0x0602DC2E RID: 187438 RVA: 0x00ACB5C6 File Offset: 0x00AC97C6
		// (set) Token: 0x0602DC2F RID: 187439 RVA: 0x00ACB5DA File Offset: 0x00AC97DA
		public unsafe UAkComponent Ak
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_1);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_1, value);
			}
		}

		// Token: 0x17007D4D RID: 32077
		// (get) Token: 0x0602DC30 RID: 187440 RVA: 0x00ACB5EF File Offset: 0x00AC97EF
		// (set) Token: 0x0602DC31 RID: 187441 RVA: 0x00ACB603 File Offset: 0x00AC9803
		public unsafe USceneComponent DefaultSceneRoot
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<USceneComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_2);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D4E RID: 32078
		// (get) Token: 0x0602DC32 RID: 187442 RVA: 0x00ACB618 File Offset: 0x00AC9818
		// (set) Token: 0x0602DC33 RID: 187443 RVA: 0x00ACB628 File Offset: 0x00AC9828
		public unsafe float LeftRight_Amount_E70A81694434E6033ACF01BCCBB3EA40
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007D4F RID: 32079
		// (get) Token: 0x0602DC34 RID: 187444 RVA: 0x00ACB639 File Offset: 0x00AC9839
		// (set) Token: 0x0602DC35 RID: 187445 RVA: 0x00ACB649 File Offset: 0x00AC9849
		public unsafe float LeftRight_Speed_E70A81694434E6033ACF01BCCBB3EA40
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007D50 RID: 32080
		// (get) Token: 0x0602DC36 RID: 187446 RVA: 0x00ACB65A File Offset: 0x00AC985A
		// (set) Token: 0x0602DC37 RID: 187447 RVA: 0x00ACB66E File Offset: 0x00AC986E
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> LeftRight__Direction_E70A81694434E6033ACF01BCCBB3EA40
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_5);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007D51 RID: 32081
		// (get) Token: 0x0602DC38 RID: 187448 RVA: 0x00ACB683 File Offset: 0x00AC9883
		// (set) Token: 0x0602DC39 RID: 187449 RVA: 0x00ACB697 File Offset: 0x00AC9897
		public unsafe UTimelineComponent LeftRight
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_6);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_6, value);
			}
		}

		// Token: 0x17007D52 RID: 32082
		// (get) Token: 0x0602DC3A RID: 187450 RVA: 0x00ACB6AC File Offset: 0x00AC98AC
		// (set) Token: 0x0602DC3B RID: 187451 RVA: 0x00ACB6BC File Offset: 0x00AC98BC
		public unsafe float Timeline_1_Amount_E9903C6548E1132FB686C5B44E42F03F
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007D53 RID: 32083
		// (get) Token: 0x0602DC3C RID: 187452 RVA: 0x00ACB6CD File Offset: 0x00AC98CD
		// (set) Token: 0x0602DC3D RID: 187453 RVA: 0x00ACB6DD File Offset: 0x00AC98DD
		public unsafe float Timeline_1_Speed_E9903C6548E1132FB686C5B44E42F03F
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17007D54 RID: 32084
		// (get) Token: 0x0602DC3E RID: 187454 RVA: 0x00ACB6EE File Offset: 0x00AC98EE
		// (set) Token: 0x0602DC3F RID: 187455 RVA: 0x00ACB702 File Offset: 0x00AC9902
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_1__Direction_E9903C6548E1132FB686C5B44E42F03F
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_9);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17007D55 RID: 32085
		// (get) Token: 0x0602DC40 RID: 187456 RVA: 0x00ACB717 File Offset: 0x00AC9917
		// (set) Token: 0x0602DC41 RID: 187457 RVA: 0x00ACB72B File Offset: 0x00AC992B
		public unsafe UTimelineComponent Timeline_1
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17007D56 RID: 32086
		// (get) Token: 0x0602DC42 RID: 187458 RVA: 0x00ACB740 File Offset: 0x00AC9940
		// (set) Token: 0x0602DC43 RID: 187459 RVA: 0x00ACB750 File Offset: 0x00AC9950
		public unsafe float BassTimeline_Amount_56F891924BAD722F43E980B6AFE54B74
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17007D57 RID: 32087
		// (get) Token: 0x0602DC44 RID: 187460 RVA: 0x00ACB761 File Offset: 0x00AC9961
		// (set) Token: 0x0602DC45 RID: 187461 RVA: 0x00ACB771 File Offset: 0x00AC9971
		public unsafe float BassTimeline_Speed_56F891924BAD722F43E980B6AFE54B74
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_12);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x17007D58 RID: 32088
		// (get) Token: 0x0602DC46 RID: 187462 RVA: 0x00ACB782 File Offset: 0x00AC9982
		// (set) Token: 0x0602DC47 RID: 187463 RVA: 0x00ACB796 File Offset: 0x00AC9996
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> BassTimeline__Direction_56F891924BAD722F43E980B6AFE54B74
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17007D59 RID: 32089
		// (get) Token: 0x0602DC48 RID: 187464 RVA: 0x00ACB7AB File Offset: 0x00AC99AB
		// (set) Token: 0x0602DC49 RID: 187465 RVA: 0x00ACB7BF File Offset: 0x00AC99BF
		public unsafe UTimelineComponent BassTimeline
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_14);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_14, value);
			}
		}

		// Token: 0x17007D5A RID: 32090
		// (get) Token: 0x0602DC4A RID: 187466 RVA: 0x00ACB7D4 File Offset: 0x00AC99D4
		// (set) Token: 0x0602DC4B RID: 187467 RVA: 0x00ACB7E4 File Offset: 0x00AC99E4
		public unsafe float Timeline_0_Amount_84FB19EE41A244783A5C418B4069C9D8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17007D5B RID: 32091
		// (get) Token: 0x0602DC4C RID: 187468 RVA: 0x00ACB7F5 File Offset: 0x00AC99F5
		// (set) Token: 0x0602DC4D RID: 187469 RVA: 0x00ACB805 File Offset: 0x00AC9A05
		public unsafe float Timeline_0_Speed_84FB19EE41A244783A5C418B4069C9D8
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_16);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_16) = value;
			}
		}

		// Token: 0x17007D5C RID: 32092
		// (get) Token: 0x0602DC4E RID: 187470 RVA: 0x00ACB816 File Offset: 0x00AC9A16
		// (set) Token: 0x0602DC4F RID: 187471 RVA: 0x00ACB82A File Offset: 0x00AC9A2A
		[Nullable(0)]
		public unsafe TEnumAsByte<ETimelineDirection> Timeline_0__Direction_84FB19EE41A244783A5C418B4069C9D8
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_17);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x17007D5D RID: 32093
		// (get) Token: 0x0602DC50 RID: 187472 RVA: 0x00ACB83F File Offset: 0x00AC9A3F
		// (set) Token: 0x0602DC51 RID: 187473 RVA: 0x00ACB853 File Offset: 0x00AC9A53
		public unsafe UTimelineComponent Timeline_0
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTimelineComponent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_18);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_18, value);
			}
		}

		// Token: 0x17007D5E RID: 32094
		// (get) Token: 0x0602DC52 RID: 187474 RVA: 0x00ACB868 File Offset: 0x00AC9A68
		// (set) Token: 0x0602DC53 RID: 187475 RVA: 0x00ACB878 File Offset: 0x00AC9A78
		public unsafe int NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x17007D5F RID: 32095
		// (get) Token: 0x0602DC54 RID: 187476 RVA: 0x00ACB889 File Offset: 0x00AC9A89
		// (set) Token: 0x0602DC55 RID: 187477 RVA: 0x00ACB89D File Offset: 0x00AC9A9D
		public unsafe UAkAudioEvent Ak_Event
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_20);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_AudioVisualizer_C.__PropertyOffset_20, value);
			}
		}

		// Token: 0x17007D60 RID: 32096
		// (get) Token: 0x0602DC56 RID: 187478 RVA: 0x00ACB8B2 File Offset: 0x00AC9AB2
		// (set) Token: 0x0602DC57 RID: 187479 RVA: 0x00ACB8C2 File Offset: 0x00AC9AC2
		public unsafe float A01Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x17007D61 RID: 32097
		// (get) Token: 0x0602DC58 RID: 187480 RVA: 0x00ACB8D3 File Offset: 0x00AC9AD3
		// (set) Token: 0x0602DC59 RID: 187481 RVA: 0x00ACB8E3 File Offset: 0x00AC9AE3
		public unsafe float A02Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_22);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_22) = value;
			}
		}

		// Token: 0x17007D62 RID: 32098
		// (get) Token: 0x0602DC5A RID: 187482 RVA: 0x00ACB8F4 File Offset: 0x00AC9AF4
		// (set) Token: 0x0602DC5B RID: 187483 RVA: 0x00ACB904 File Offset: 0x00AC9B04
		public unsafe float A03Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_23);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_23) = value;
			}
		}

		// Token: 0x17007D63 RID: 32099
		// (get) Token: 0x0602DC5C RID: 187484 RVA: 0x00ACB915 File Offset: 0x00AC9B15
		// (set) Token: 0x0602DC5D RID: 187485 RVA: 0x00ACB925 File Offset: 0x00AC9B25
		public unsafe float A04Time
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_24);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_24) = value;
			}
		}

		// Token: 0x17007D64 RID: 32100
		// (get) Token: 0x0602DC5E RID: 187486 RVA: 0x00ACB936 File Offset: 0x00AC9B36
		// (set) Token: 0x0602DC5F RID: 187487 RVA: 0x00ACB946 File Offset: 0x00AC9B46
		public unsafe float A01Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_25);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_25) = value;
			}
		}

		// Token: 0x17007D65 RID: 32101
		// (get) Token: 0x0602DC60 RID: 187488 RVA: 0x00ACB957 File Offset: 0x00AC9B57
		// (set) Token: 0x0602DC61 RID: 187489 RVA: 0x00ACB967 File Offset: 0x00AC9B67
		public unsafe float A02Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_26);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_26) = value;
			}
		}

		// Token: 0x17007D66 RID: 32102
		// (get) Token: 0x0602DC62 RID: 187490 RVA: 0x00ACB978 File Offset: 0x00AC9B78
		// (set) Token: 0x0602DC63 RID: 187491 RVA: 0x00ACB988 File Offset: 0x00AC9B88
		public unsafe float A03Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_27);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_27) = value;
			}
		}

		// Token: 0x17007D67 RID: 32103
		// (get) Token: 0x0602DC64 RID: 187492 RVA: 0x00ACB999 File Offset: 0x00AC9B99
		// (set) Token: 0x0602DC65 RID: 187493 RVA: 0x00ACB9A9 File Offset: 0x00AC9BA9
		public unsafe float A04Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_28);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_28) = value;
			}
		}

		// Token: 0x17007D68 RID: 32104
		// (get) Token: 0x0602DC66 RID: 187494 RVA: 0x00ACB9BA File Offset: 0x00AC9BBA
		// (set) Token: 0x0602DC67 RID: 187495 RVA: 0x00ACB9CA File Offset: 0x00AC9BCA
		public unsafe bool UsingMax_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D69 RID: 32105
		// (get) Token: 0x0602DC68 RID: 187496 RVA: 0x00ACB9DB File Offset: 0x00AC9BDB
		// (set) Token: 0x0602DC69 RID: 187497 RVA: 0x00ACB9EB File Offset: 0x00AC9BEB
		public unsafe int PlayID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_30);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_AudioVisualizer_C.__PropertyOffset_30) = value;
			}
		}

		// Token: 0x0602DC6A RID: 187498 RVA: 0x00ACB9FC File Offset: 0x00AC9BFC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void StopAllEffects()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__StopAllEffects_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC6B RID: 187499 RVA: 0x00ACBA10 File Offset: 0x00AC9C10
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void NotifyMidi([Nullable(2)] UAkCallbackInfo CallbackInfo, EAkCallbackType CallbackType, string State)
		{
			BP_AudioVisualizer_C.__NotifyMidi_FunctionParams* ptr = stackalloc BP_AudioVisualizer_C.__NotifyMidi_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AudioVisualizer_C.__NotifyMidi_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioVisualizer_C.__NotifyMidi_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CallbackInfo = ((CallbackInfo != null) ? CallbackInfo.NativePtr : IntPtr.Zero);
			ptr->CallbackType = CallbackType;
			FString.CopyFrom((void*)(&ptr->State), State);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__NotifyMidi_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_AudioVisualizer_C.__NotifyMidi_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DC6C RID: 187500 RVA: 0x00ACBA8A File Offset: 0x00AC9C8A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BassTimeline__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__BassTimeline__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC6D RID: 187501 RVA: 0x00ACBA9E File Offset: 0x00AC9C9E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void BassTimeline__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__BassTimeline__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC6E RID: 187502 RVA: 0x00ACBAB2 File Offset: 0x00AC9CB2
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__Timeline_0__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC6F RID: 187503 RVA: 0x00ACBAC6 File Offset: 0x00AC9CC6
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_0__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__Timeline_0__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC70 RID: 187504 RVA: 0x00ACBADA File Offset: 0x00AC9CDA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_1__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__Timeline_1__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC71 RID: 187505 RVA: 0x00ACBAEE File Offset: 0x00AC9CEE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Timeline_1__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__Timeline_1__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC72 RID: 187506 RVA: 0x00ACBB02 File Offset: 0x00AC9D02
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LeftRight__FinishedFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__LeftRight__FinishedFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC73 RID: 187507 RVA: 0x00ACBB16 File Offset: 0x00AC9D16
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void LeftRight__UpdateFunc()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__LeftRight__UpdateFunc_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC74 RID: 187508 RVA: 0x00ACBB2A File Offset: 0x00AC9D2A
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC75 RID: 187509 RVA: 0x00ACBB3E File Offset: 0x00AC9D3E
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioVisualizer_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x0602DC76 RID: 187510 RVA: 0x00ACBB53 File Offset: 0x00AC9D53
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void C_4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__C_4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC77 RID: 187511 RVA: 0x00ACBB67 File Offset: 0x00AC9D67
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void D4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__D4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC78 RID: 187512 RVA: 0x00ACBB7B File Offset: 0x00AC9D7B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void D_4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__D_4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC79 RID: 187513 RVA: 0x00ACBB8F File Offset: 0x00AC9D8F
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void E4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__E4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC7A RID: 187514 RVA: 0x00ACBBA3 File Offset: 0x00AC9DA3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void F4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__F4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC7B RID: 187515 RVA: 0x00ACBBB7 File Offset: 0x00AC9DB7
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void F_4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__F_4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC7C RID: 187516 RVA: 0x00ACBBCB File Offset: 0x00AC9DCB
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void G4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__G4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC7D RID: 187517 RVA: 0x00ACBBDF File Offset: 0x00AC9DDF
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void G_4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__G_4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC7E RID: 187518 RVA: 0x00ACBBF3 File Offset: 0x00AC9DF3
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void F_4_Off()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__F_4_Off_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC7F RID: 187519 RVA: 0x00ACBC07 File Offset: 0x00AC9E07
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void C4_On()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__C4_On_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC80 RID: 187520 RVA: 0x00ACBC1C File Offset: 0x00AC9E1C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			BP_AudioVisualizer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AudioVisualizer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioVisualizer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioVisualizer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602DC81 RID: 187521 RVA: 0x00ACBC64 File Offset: 0x00AC9E64
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			BP_AudioVisualizer_C.__ReceiveTick_FunctionParams* ptr = stackalloc BP_AudioVisualizer_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(BP_AudioVisualizer_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioVisualizer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioVisualizer_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DC82 RID: 187522 RVA: 0x00ACBCAC File Offset: 0x00AC9EAC
		[NullableContext(1)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void MIDICall(EAkCallbackType CallbackType, [Nullable(2)] UAkCallbackInfo CallbackInfo, string State)
		{
			BP_AudioVisualizer_C.__MIDICall_FunctionParams* ptr = stackalloc BP_AudioVisualizer_C.__MIDICall_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(BP_AudioVisualizer_C.__MIDICall_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioVisualizer_C.__MIDICall_NativeFunctionPtr, (void*)ptr, 1);
			ptr->CallbackType = CallbackType;
			ptr->CallbackInfo = ((CallbackInfo != null) ? CallbackInfo.NativePtr : IntPtr.Zero);
			FString.CopyFrom((void*)(&ptr->State), State);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__MIDICall_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(BP_AudioVisualizer_C.__MIDICall_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602DC83 RID: 187523 RVA: 0x00ACBD26 File Offset: 0x00AC9F26
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Stop()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, BP_AudioVisualizer_C.__Stop_NativeFunctionPtr, null);
		}

		// Token: 0x0602DC84 RID: 187524 RVA: 0x00ACBD3C File Offset: 0x00AC9F3C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_BP_AudioVisualizer(int EntryPoint)
		{
			BP_AudioVisualizer_C.__ExecuteUbergraph_BP_AudioVisualizer_FunctionParams* ptr = stackalloc BP_AudioVisualizer_C.__ExecuteUbergraph_BP_AudioVisualizer_FunctionParams[(UIntPtr)199] + 15L / (long)sizeof(BP_AudioVisualizer_C.__ExecuteUbergraph_BP_AudioVisualizer_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(BP_AudioVisualizer_C.__ExecuteUbergraph_BP_AudioVisualizer_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, BP_AudioVisualizer_C.__ExecuteUbergraph_BP_AudioVisualizer_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602DC85 RID: 187525 RVA: 0x00ACBD86 File Offset: 0x00AC9F86
		protected BP_AudioVisualizer_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04019D35 RID: 105781
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Audio/BP_AudioVisualizer.BP_AudioVisualizer_C";

		// Token: 0x04019D36 RID: 105782
		private static IntPtr _ClassPtr;

		// Token: 0x04019D37 RID: 105783
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019D38 RID: 105784
		internal static int __PropertyOffset_0;

		// Token: 0x04019D39 RID: 105785
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x04019D3A RID: 105786
		internal static int __PropertyOffset_1;

		// Token: 0x04019D3B RID: 105787
		internal static int __PropertyOffset_2;

		// Token: 0x04019D3C RID: 105788
		internal static int __PropertyOffset_3;

		// Token: 0x04019D3D RID: 105789
		internal static int __PropertyOffset_4;

		// Token: 0x04019D3E RID: 105790
		internal static int __PropertyOffset_5;

		// Token: 0x04019D3F RID: 105791
		internal static int __PropertyOffset_6;

		// Token: 0x04019D40 RID: 105792
		internal static int __PropertyOffset_7;

		// Token: 0x04019D41 RID: 105793
		internal static int __PropertyOffset_8;

		// Token: 0x04019D42 RID: 105794
		internal static int __PropertyOffset_9;

		// Token: 0x04019D43 RID: 105795
		internal static int __PropertyOffset_10;

		// Token: 0x04019D44 RID: 105796
		internal static int __PropertyOffset_11;

		// Token: 0x04019D45 RID: 105797
		internal static int __PropertyOffset_12;

		// Token: 0x04019D46 RID: 105798
		internal static int __PropertyOffset_13;

		// Token: 0x04019D47 RID: 105799
		internal static int __PropertyOffset_14;

		// Token: 0x04019D48 RID: 105800
		internal static int __PropertyOffset_15;

		// Token: 0x04019D49 RID: 105801
		internal static int __PropertyOffset_16;

		// Token: 0x04019D4A RID: 105802
		internal static int __PropertyOffset_17;

		// Token: 0x04019D4B RID: 105803
		internal static int __PropertyOffset_18;

		// Token: 0x04019D4C RID: 105804
		internal static int __PropertyOffset_19;

		// Token: 0x04019D4D RID: 105805
		internal static int __PropertyOffset_20;

		// Token: 0x04019D4E RID: 105806
		internal static int __PropertyOffset_21;

		// Token: 0x04019D4F RID: 105807
		internal static int __PropertyOffset_22;

		// Token: 0x04019D50 RID: 105808
		internal static int __PropertyOffset_23;

		// Token: 0x04019D51 RID: 105809
		internal static int __PropertyOffset_24;

		// Token: 0x04019D52 RID: 105810
		internal static int __PropertyOffset_25;

		// Token: 0x04019D53 RID: 105811
		internal static int __PropertyOffset_26;

		// Token: 0x04019D54 RID: 105812
		internal static int __PropertyOffset_27;

		// Token: 0x04019D55 RID: 105813
		internal static int __PropertyOffset_28;

		// Token: 0x04019D56 RID: 105814
		internal static int __PropertyOffset_29;

		// Token: 0x04019D57 RID: 105815
		internal static int __PropertyOffset_30;

		// Token: 0x04019D58 RID: 105816
		private static IntPtr __StopAllEffects_NativeFunctionPtr;

		// Token: 0x04019D59 RID: 105817
		private static IntPtr __NotifyMidi_NativeFunctionPtr;

		// Token: 0x04019D5A RID: 105818
		private static IntPtr __BassTimeline__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04019D5B RID: 105819
		private static IntPtr __BassTimeline__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04019D5C RID: 105820
		private static IntPtr __Timeline_0__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04019D5D RID: 105821
		private static IntPtr __Timeline_0__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04019D5E RID: 105822
		private static IntPtr __Timeline_1__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04019D5F RID: 105823
		private static IntPtr __Timeline_1__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04019D60 RID: 105824
		private static IntPtr __LeftRight__FinishedFunc_NativeFunctionPtr;

		// Token: 0x04019D61 RID: 105825
		private static IntPtr __LeftRight__UpdateFunc_NativeFunctionPtr;

		// Token: 0x04019D62 RID: 105826
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x04019D63 RID: 105827
		private static IntPtr __C_4_On_NativeFunctionPtr;

		// Token: 0x04019D64 RID: 105828
		private static IntPtr __D4_On_NativeFunctionPtr;

		// Token: 0x04019D65 RID: 105829
		private static IntPtr __D_4_On_NativeFunctionPtr;

		// Token: 0x04019D66 RID: 105830
		private static IntPtr __E4_On_NativeFunctionPtr;

		// Token: 0x04019D67 RID: 105831
		private static IntPtr __F4_On_NativeFunctionPtr;

		// Token: 0x04019D68 RID: 105832
		private static IntPtr __F_4_On_NativeFunctionPtr;

		// Token: 0x04019D69 RID: 105833
		private static IntPtr __G4_On_NativeFunctionPtr;

		// Token: 0x04019D6A RID: 105834
		private static IntPtr __G_4_On_NativeFunctionPtr;

		// Token: 0x04019D6B RID: 105835
		private static IntPtr __F_4_Off_NativeFunctionPtr;

		// Token: 0x04019D6C RID: 105836
		private static IntPtr __C4_On_NativeFunctionPtr;

		// Token: 0x04019D6D RID: 105837
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04019D6E RID: 105838
		private static IntPtr __MIDICall_NativeFunctionPtr;

		// Token: 0x04019D6F RID: 105839
		private static IntPtr __Stop_NativeFunctionPtr;

		// Token: 0x04019D70 RID: 105840
		private static IntPtr __ExecuteUbergraph_BP_AudioVisualizer_NativeFunctionPtr;

		// Token: 0x0200A5A1 RID: 42401
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __NotifyMidi_FunctionParams
		{
			// Token: 0x040334FB RID: 210171
			[FieldOffset(0)]
			public IntPtr CallbackInfo;

			// Token: 0x040334FC RID: 210172
			[FieldOffset(8)]
			public EAkCallbackType CallbackType;

			// Token: 0x040334FD RID: 210173
			[FieldOffset(16)]
			public FString State;
		}

		// Token: 0x0200A5A2 RID: 42402
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040334FE RID: 210174
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x0200A5A3 RID: 42403
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __MIDICall_FunctionParams
		{
			// Token: 0x040334FF RID: 210175
			[FieldOffset(0)]
			public EAkCallbackType CallbackType;

			// Token: 0x04033500 RID: 210176
			[FieldOffset(8)]
			public IntPtr CallbackInfo;

			// Token: 0x04033501 RID: 210177
			[FieldOffset(16)]
			public FString State;
		}

		// Token: 0x0200A5A4 RID: 42404
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 184)]
		protected ref struct __ExecuteUbergraph_BP_AudioVisualizer_FunctionParams
		{
			// Token: 0x04033502 RID: 210178
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
