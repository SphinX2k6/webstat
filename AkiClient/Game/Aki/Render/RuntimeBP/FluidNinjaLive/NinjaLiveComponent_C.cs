using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core;
using AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.SimCache.BP;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive
{
	// Token: 0x02003CF4 RID: 15604
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C")]
	[UnrealStructLayout(3336, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 3336)]
	public class NinjaLiveComponent_C : UKuroBPActorComponent, IUnrealUObject, IUnrealObject, INinjaLiveInterface_C, IUnrealBlueprintInterface, IUnrealInterface
	{
		// Token: 0x0602549C RID: 152732 RVA: 0x009B657C File Offset: 0x009B477C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (NinjaLiveComponent_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C");
			}
			return NinjaLiveComponent_C._ClassPtr;
		}

		// Token: 0x0602549D RID: 152733 RVA: 0x009B65A0 File Offset: 0x009B47A0
		public NinjaLiveComponent_C() : this(BuiltinUtils.AllocNativeUObject(NinjaLiveComponent_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602549E RID: 152734 RVA: 0x009B65C8 File Offset: 0x009B47C8
		public NinjaLiveComponent_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(NinjaLiveComponent_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005096 RID: 20630
		// (get) Token: 0x0602549F RID: 152735 RVA: 0x009B65FC File Offset: 0x009B47FC
		// (set) Token: 0x060254A0 RID: 152736 RVA: 0x009B6635 File Offset: 0x009B4835
		public FPointerToUberGraphFrame UberGraphFrame
		{
			get
			{
				base.FastCheckIsValid();
				FPointerToUberGraphFrame result;
				if ((result = this._UberGraphFrame) == null)
				{
					result = (this._UberGraphFrame = new FPointerToUberGraphFrame(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FPointerToUberGraphFrame.StaticStruct(), base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005097 RID: 20631
		// (get) Token: 0x060254A1 RID: 152737 RVA: 0x009B6656 File Offset: 0x009B4856
		// (set) Token: 0x060254A2 RID: 152738 RVA: 0x009B6666 File Offset: 0x009B4866
		public unsafe bool ComponentActivatedByPawnProximity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005098 RID: 20632
		// (get) Token: 0x060254A3 RID: 152739 RVA: 0x009B6677 File Offset: 0x009B4877
		// (set) Token: 0x060254A4 RID: 152740 RVA: 0x009B6687 File Offset: 0x009B4887
		public unsafe bool DisableComponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005099 RID: 20633
		// (get) Token: 0x060254A5 RID: 152741 RVA: 0x009B6698 File Offset: 0x009B4898
		// (set) Token: 0x060254A6 RID: 152742 RVA: 0x009B66A8 File Offset: 0x009B48A8
		public unsafe bool BeginPlaySupressed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700509A RID: 20634
		// (get) Token: 0x060254A7 RID: 152743 RVA: 0x009B66B9 File Offset: 0x009B48B9
		// (set) Token: 0x060254A8 RID: 152744 RVA: 0x009B66C9 File Offset: 0x009B48C9
		public unsafe bool InitDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700509B RID: 20635
		// (get) Token: 0x060254A9 RID: 152745 RVA: 0x009B66DA File Offset: 0x009B48DA
		// (set) Token: 0x060254AA RID: 152746 RVA: 0x009B66EA File Offset: 0x009B48EA
		public unsafe bool MaterialInstacesDone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700509C RID: 20636
		// (get) Token: 0x060254AB RID: 152747 RVA: 0x009B66FB File Offset: 0x009B48FB
		// (set) Token: 0x060254AC RID: 152748 RVA: 0x009B670B File Offset: 0x009B490B
		public unsafe bool AutoConnectToMemoryPool_IF_Found
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700509D RID: 20637
		// (get) Token: 0x060254AD RID: 152749 RVA: 0x009B671C File Offset: 0x009B491C
		// (set) Token: 0x060254AE RID: 152750 RVA: 0x009B672C File Offset: 0x009B492C
		public unsafe bool MemPoolManagerDetected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_7) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_7) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700509E RID: 20638
		// (get) Token: 0x060254AF RID: 152751 RVA: 0x009B673D File Offset: 0x009B493D
		// (set) Token: 0x060254B0 RID: 152752 RVA: 0x009B674D File Offset: 0x009B494D
		public unsafe bool PoolManagerOverridesLocalSettings
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700509F RID: 20639
		// (get) Token: 0x060254B1 RID: 152753 RVA: 0x009B675E File Offset: 0x009B495E
		// (set) Token: 0x060254B2 RID: 152754 RVA: 0x009B676E File Offset: 0x009B496E
		public unsafe int ResolutionX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x170050A0 RID: 20640
		// (get) Token: 0x060254B3 RID: 152755 RVA: 0x009B677F File Offset: 0x009B497F
		// (set) Token: 0x060254B4 RID: 152756 RVA: 0x009B678F File Offset: 0x009B498F
		public unsafe int ResolutionY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x170050A1 RID: 20641
		// (get) Token: 0x060254B5 RID: 152757 RVA: 0x009B67A0 File Offset: 0x009B49A0
		// (set) Token: 0x060254B6 RID: 152758 RVA: 0x009B67B4 File Offset: 0x009B49B4
		public unsafe string PreferredTraceChannelName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_11)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_11)), value);
			}
		}

		// Token: 0x170050A2 RID: 20642
		// (get) Token: 0x060254B7 RID: 152759 RVA: 0x009B67C9 File Offset: 0x009B49C9
		// (set) Token: 0x060254B8 RID: 152760 RVA: 0x009B67DD File Offset: 0x009B49DD
		[Nullable(0)]
		public unsafe TEnumAsByte<ETraceTypeQuery> TraceChannel
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_12);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_12) = value;
			}
		}

		// Token: 0x170050A3 RID: 20643
		// (get) Token: 0x060254B9 RID: 152761 RVA: 0x009B67F2 File Offset: 0x009B49F2
		// (set) Token: 0x060254BA RID: 152762 RVA: 0x009B6806 File Offset: 0x009B4A06
		[Nullable(0)]
		public unsafe TEnumAsByte<ECollisionChannel> CollisionChannel
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_13);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x170050A4 RID: 20644
		// (get) Token: 0x060254BB RID: 152763 RVA: 0x009B681B File Offset: 0x009B4A1B
		// (set) Token: 0x060254BC RID: 152764 RVA: 0x009B682B File Offset: 0x009B4A2B
		public unsafe bool TraceChannelsSet
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_14) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_14) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050A5 RID: 20645
		// (get) Token: 0x060254BD RID: 152765 RVA: 0x009B683C File Offset: 0x009B4A3C
		// (set) Token: 0x060254BE RID: 152766 RVA: 0x009B6850 File Offset: 0x009B4A50
		[Nullable(0)]
		public unsafe TEnumAsByte<SimPrecision_Enum> SimPrecision
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_15);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x170050A6 RID: 20646
		// (get) Token: 0x060254BF RID: 152767 RVA: 0x009B6865 File Offset: 0x009B4A65
		// (set) Token: 0x060254C0 RID: 152768 RVA: 0x009B6875 File Offset: 0x009B4A75
		public unsafe bool UsePressureSolver1__DefaultIs2_
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050A7 RID: 20647
		// (get) Token: 0x060254C1 RID: 152769 RVA: 0x009B6886 File Offset: 0x009B4A86
		// (set) Token: 0x060254C2 RID: 152770 RVA: 0x009B6896 File Offset: 0x009B4A96
		public unsafe int PressureSolver1_MaxIterations
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_17);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_17) = value;
			}
		}

		// Token: 0x170050A8 RID: 20648
		// (get) Token: 0x060254C3 RID: 152771 RVA: 0x009B68A7 File Offset: 0x009B4AA7
		// (set) Token: 0x060254C4 RID: 152772 RVA: 0x009B68B7 File Offset: 0x009B4AB7
		public unsafe int PressureSolver2_MaxIterations
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x170050A9 RID: 20649
		// (get) Token: 0x060254C5 RID: 152773 RVA: 0x009B68C8 File Offset: 0x009B4AC8
		// (set) Token: 0x060254C6 RID: 152774 RVA: 0x009B68D8 File Offset: 0x009B4AD8
		public unsafe float PressureSolver2_KernelReduction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_19);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_19) = value;
			}
		}

		// Token: 0x170050AA RID: 20650
		// (get) Token: 0x060254C7 RID: 152775 RVA: 0x009B68E9 File Offset: 0x009B4AE9
		// (set) Token: 0x060254C8 RID: 152776 RVA: 0x009B68F9 File Offset: 0x009B4AF9
		public unsafe int MaxSamplingFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_20);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_20) = value;
			}
		}

		// Token: 0x170050AB RID: 20651
		// (get) Token: 0x060254C9 RID: 152777 RVA: 0x009B690A File Offset: 0x009B4B0A
		// (set) Token: 0x060254CA RID: 152778 RVA: 0x009B691A File Offset: 0x009B4B1A
		public unsafe int MinSamplingFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_21);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_21) = value;
			}
		}

		// Token: 0x170050AC RID: 20652
		// (get) Token: 0x060254CB RID: 152779 RVA: 0x009B692B File Offset: 0x009B4B2B
		// (set) Token: 0x060254CC RID: 152780 RVA: 0x009B693B File Offset: 0x009B4B3B
		public unsafe bool HalfResPressureAndDivergenceBuffers
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_22) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_22) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050AD RID: 20653
		// (get) Token: 0x060254CD RID: 152781 RVA: 0x009B694C File Offset: 0x009B4B4C
		// (set) Token: 0x060254CE RID: 152782 RVA: 0x009B695C File Offset: 0x009B4B5C
		public unsafe bool ShowDebugMessages_TraceChannels
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_23) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_23) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050AE RID: 20654
		// (get) Token: 0x060254CF RID: 152783 RVA: 0x009B696D File Offset: 0x009B4B6D
		// (set) Token: 0x060254D0 RID: 152784 RVA: 0x009B697D File Offset: 0x009B4B7D
		public unsafe bool ShowDebugMessages_MemoryManagement
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_24) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_24) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050AF RID: 20655
		// (get) Token: 0x060254D1 RID: 152785 RVA: 0x009B698E File Offset: 0x009B4B8E
		// (set) Token: 0x060254D2 RID: 152786 RVA: 0x009B699E File Offset: 0x009B4B9E
		public unsafe bool ShowDebugMessages_CollisionAndTracing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_25) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_25) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B0 RID: 20656
		// (get) Token: 0x060254D3 RID: 152787 RVA: 0x009B69AF File Offset: 0x009B4BAF
		// (set) Token: 0x060254D4 RID: 152788 RVA: 0x009B69BF File Offset: 0x009B4BBF
		public unsafe bool ShowDebugMessages_LODInitial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_26) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_26) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B1 RID: 20657
		// (get) Token: 0x060254D5 RID: 152789 RVA: 0x009B69D0 File Offset: 0x009B4BD0
		// (set) Token: 0x060254D6 RID: 152790 RVA: 0x009B69E0 File Offset: 0x009B4BE0
		public unsafe bool ShowDebugMessages_LODRuntime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_27) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_27) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B2 RID: 20658
		// (get) Token: 0x060254D7 RID: 152791 RVA: 0x009B69F1 File Offset: 0x009B4BF1
		// (set) Token: 0x060254D8 RID: 152792 RVA: 0x009B6A01 File Offset: 0x009B4C01
		public unsafe bool ShowDebugMessages_InterfaceControl
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_28) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_28) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B3 RID: 20659
		// (get) Token: 0x060254D9 RID: 152793 RVA: 0x009B6A12 File Offset: 0x009B4C12
		// (set) Token: 0x060254DA RID: 152794 RVA: 0x009B6A22 File Offset: 0x009B4C22
		public unsafe bool ShowDebugMessages_RenderTargetExport
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_29) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_29) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B4 RID: 20660
		// (get) Token: 0x060254DB RID: 152795 RVA: 0x009B6A33 File Offset: 0x009B4C33
		// (set) Token: 0x060254DC RID: 152796 RVA: 0x009B6A43 File Offset: 0x009B4C43
		public unsafe bool ShowWarning_NumberOfBonesToTrack
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_30) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_30) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B5 RID: 20661
		// (get) Token: 0x060254DD RID: 152797 RVA: 0x009B6A54 File Offset: 0x009B4C54
		// (set) Token: 0x060254DE RID: 152798 RVA: 0x009B6A64 File Offset: 0x009B4C64
		public unsafe bool VisualizeCustomTraceSource
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_31) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_31) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B6 RID: 20662
		// (get) Token: 0x060254DF RID: 152799 RVA: 0x009B6A75 File Offset: 0x009B4C75
		// (set) Token: 0x060254E0 RID: 152800 RVA: 0x009B6A85 File Offset: 0x009B4C85
		public unsafe bool SaveDebugMessagesToDefaultLog
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_32) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_32) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050B7 RID: 20663
		// (get) Token: 0x060254E1 RID: 152801 RVA: 0x009B6A96 File Offset: 0x009B4C96
		// (set) Token: 0x060254E2 RID: 152802 RVA: 0x009B6AA6 File Offset: 0x009B4CA6
		public unsafe float DebugMessagesLifetime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_33);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_33) = value;
			}
		}

		// Token: 0x170050B8 RID: 20664
		// (get) Token: 0x060254E3 RID: 152803 RVA: 0x009B6AB7 File Offset: 0x009B4CB7
		// (set) Token: 0x060254E4 RID: 152804 RVA: 0x009B6ACB File Offset: 0x009B4CCB
		[Nullable(2)]
		public unsafe UStaticMeshComponent TraceMeshComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UStaticMeshComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_34);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_34, value);
			}
		}

		// Token: 0x170050B9 RID: 20665
		// (get) Token: 0x060254E5 RID: 152805 RVA: 0x009B6AE0 File Offset: 0x009B4CE0
		// (set) Token: 0x060254E6 RID: 152806 RVA: 0x009B6AF0 File Offset: 0x009B4CF0
		public unsafe int SamplingFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_35);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_35) = value;
			}
		}

		// Token: 0x170050BA RID: 20666
		// (get) Token: 0x060254E7 RID: 152807 RVA: 0x009B6B01 File Offset: 0x009B4D01
		// (set) Token: 0x060254E8 RID: 152808 RVA: 0x009B6B11 File Offset: 0x009B4D11
		public unsafe float TickRateCustom
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_36);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_36) = value;
			}
		}

		// Token: 0x170050BB RID: 20667
		// (get) Token: 0x060254E9 RID: 152809 RVA: 0x009B6B22 File Offset: 0x009B4D22
		// (set) Token: 0x060254EA RID: 152810 RVA: 0x009B6B32 File Offset: 0x009B4D32
		public unsafe bool LOD1_ReduceSimQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_37) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_37) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050BC RID: 20668
		// (get) Token: 0x060254EB RID: 152811 RVA: 0x009B6B43 File Offset: 0x009B4D43
		// (set) Token: 0x060254EC RID: 152812 RVA: 0x009B6B53 File Offset: 0x009B4D53
		public unsafe bool LOD2_ReduceSamplingFPS
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_38) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_38) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050BD RID: 20669
		// (get) Token: 0x060254ED RID: 152813 RVA: 0x009B6B64 File Offset: 0x009B4D64
		// (set) Token: 0x060254EE RID: 152814 RVA: 0x009B6B74 File Offset: 0x009B4D74
		public unsafe float LOD_FarBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_39);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_39) = value;
			}
		}

		// Token: 0x170050BE RID: 20670
		// (get) Token: 0x060254EF RID: 152815 RVA: 0x009B6B85 File Offset: 0x009B4D85
		// (set) Token: 0x060254F0 RID: 152816 RVA: 0x009B6B95 File Offset: 0x009B4D95
		public unsafe float LOD_NearBound
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_40);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_40) = value;
			}
		}

		// Token: 0x170050BF RID: 20671
		// (get) Token: 0x060254F1 RID: 152817 RVA: 0x009B6BA6 File Offset: 0x009B4DA6
		// (set) Token: 0x060254F2 RID: 152818 RVA: 0x009B6BB6 File Offset: 0x009B4DB6
		public unsafe int LOD_Steps
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_41);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_41) = value;
			}
		}

		// Token: 0x170050C0 RID: 20672
		// (get) Token: 0x060254F3 RID: 152819 RVA: 0x009B6BC7 File Offset: 0x009B4DC7
		// (set) Token: 0x060254F4 RID: 152820 RVA: 0x009B6BD7 File Offset: 0x009B4DD7
		public unsafe float LOD_StepRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_42);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_42) = value;
			}
		}

		// Token: 0x170050C1 RID: 20673
		// (get) Token: 0x060254F5 RID: 152821 RVA: 0x009B6BE8 File Offset: 0x009B4DE8
		// (set) Token: 0x060254F6 RID: 152822 RVA: 0x009B6C21 File Offset: 0x009B4E21
		public TArray<float> LOD_StepsArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._LOD_StepsArray) == null)
				{
					result = (this._LOD_StepsArray = new TArray<float>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_43, this));
				}
				return result;
			}
			set
			{
				this.LOD_StepsArray.CopyAssign(value);
			}
		}

		// Token: 0x170050C2 RID: 20674
		// (get) Token: 0x060254F7 RID: 152823 RVA: 0x009B6C2F File Offset: 0x009B4E2F
		// (set) Token: 0x060254F8 RID: 152824 RVA: 0x009B6C3F File Offset: 0x009B4E3F
		public unsafe int SimPrecisionIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_44);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_44) = value;
			}
		}

		// Token: 0x170050C3 RID: 20675
		// (get) Token: 0x060254F9 RID: 152825 RVA: 0x009B6C50 File Offset: 0x009B4E50
		// (set) Token: 0x060254FA RID: 152826 RVA: 0x009B6C60 File Offset: 0x009B4E60
		public unsafe float MemConsumption
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_45);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_45) = value;
			}
		}

		// Token: 0x170050C4 RID: 20676
		// (get) Token: 0x060254FB RID: 152827 RVA: 0x009B6C71 File Offset: 0x009B4E71
		// (set) Token: 0x060254FC RID: 152828 RVA: 0x009B6C81 File Offset: 0x009B4E81
		public unsafe int MapLengthTmp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_46);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_46) = value;
			}
		}

		// Token: 0x170050C5 RID: 20677
		// (get) Token: 0x060254FD RID: 152829 RVA: 0x009B6C92 File Offset: 0x009B4E92
		// (set) Token: 0x060254FE RID: 152830 RVA: 0x009B6CA6 File Offset: 0x009B4EA6
		[Nullable(2)]
		public unsafe UMaterialInstance InactiveGrayMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstance>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_47);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_47, value);
			}
		}

		// Token: 0x170050C6 RID: 20678
		// (get) Token: 0x060254FF RID: 152831 RVA: 0x009B6CBC File Offset: 0x009B4EBC
		// (set) Token: 0x06025500 RID: 152832 RVA: 0x009B6CF5 File Offset: 0x009B4EF5
		public ComponentRePlayEvent ComponentRePlayEvent
		{
			get
			{
				base.FastCheckIsValid();
				ComponentRePlayEvent result;
				if ((result = this._ComponentRePlayEvent) == null)
				{
					result = (this._ComponentRePlayEvent = new ComponentRePlayEvent(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_48, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_48, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170050C7 RID: 20679
		// (get) Token: 0x06025501 RID: 152833 RVA: 0x009B6D18 File Offset: 0x009B4F18
		// (set) Token: 0x06025502 RID: 152834 RVA: 0x009B6D51 File Offset: 0x009B4F51
		public ComponentBroadcastMemConsumption ComponentBroadcastMemConsumption
		{
			get
			{
				base.FastCheckIsValid();
				ComponentBroadcastMemConsumption result;
				if ((result = this._ComponentBroadcastMemConsumption) == null)
				{
					result = (this._ComponentBroadcastMemConsumption = new ComponentBroadcastMemConsumption(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_49, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_49, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170050C8 RID: 20680
		// (get) Token: 0x06025503 RID: 152835 RVA: 0x009B6D72 File Offset: 0x009B4F72
		// (set) Token: 0x06025504 RID: 152836 RVA: 0x009B6D82 File Offset: 0x009B4F82
		public unsafe bool PawnInsideActivationBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_50) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_50) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050C9 RID: 20681
		// (get) Token: 0x06025505 RID: 152837 RVA: 0x009B6D93 File Offset: 0x009B4F93
		// (set) Token: 0x06025506 RID: 152838 RVA: 0x009B6DA7 File Offset: 0x009B4FA7
		[Nullable(2)]
		public unsafe UDataTable LoadedDataTable
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_51);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_51, value);
			}
		}

		// Token: 0x170050CA RID: 20682
		// (get) Token: 0x06025507 RID: 152839 RVA: 0x009B6DBC File Offset: 0x009B4FBC
		// (set) Token: 0x06025508 RID: 152840 RVA: 0x009B6DD0 File Offset: 0x009B4FD0
		public unsafe string LoadedDataTablePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_52)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_52)), value);
			}
		}

		// Token: 0x170050CB RID: 20683
		// (get) Token: 0x06025509 RID: 152841 RVA: 0x009B6DE8 File Offset: 0x009B4FE8
		// (set) Token: 0x0602550A RID: 152842 RVA: 0x009B6E21 File Offset: 0x009B5021
		public TMap<string, float> PresetMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, float> result;
				if ((result = this._PresetMap) == null)
				{
					result = (this._PresetMap = new TMap<string, float>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_53, this));
				}
				return result;
			}
			set
			{
				this.PresetMap.CopyAssign(value);
			}
		}

		// Token: 0x170050CC RID: 20684
		// (get) Token: 0x0602550B RID: 152843 RVA: 0x009B6E2F File Offset: 0x009B502F
		// (set) Token: 0x0602550C RID: 152844 RVA: 0x009B6E43 File Offset: 0x009B5043
		public unsafe string ActualPreset
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_54)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_54)), value);
			}
		}

		// Token: 0x170050CD RID: 20685
		// (get) Token: 0x0602550D RID: 152845 RVA: 0x009B6E58 File Offset: 0x009B5058
		// (set) Token: 0x0602550E RID: 152846 RVA: 0x009B6E6C File Offset: 0x009B506C
		[Nullable(2)]
		public unsafe UDataTable DefaultPreset
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UDataTable>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_55);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_55, value);
			}
		}

		// Token: 0x170050CE RID: 20686
		// (get) Token: 0x0602550F RID: 152847 RVA: 0x009B6E84 File Offset: 0x009B5084
		// (set) Token: 0x06025510 RID: 152848 RVA: 0x009B6EBD File Offset: 0x009B50BD
		public TArray<FName> PresetSearchPaths
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._PresetSearchPaths) == null)
				{
					result = (this._PresetSearchPaths = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_56, this));
				}
				return result;
			}
			set
			{
				this.PresetSearchPaths.CopyAssign(value);
			}
		}

		// Token: 0x170050CF RID: 20687
		// (get) Token: 0x06025511 RID: 152849 RVA: 0x009B6ECB File Offset: 0x009B50CB
		// (set) Token: 0x06025512 RID: 152850 RVA: 0x009B6EDF File Offset: 0x009B50DF
		public unsafe FName PresetNameFilterCriteria
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_57);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_57) = value;
			}
		}

		// Token: 0x170050D0 RID: 20688
		// (get) Token: 0x06025513 RID: 152851 RVA: 0x009B6EF4 File Offset: 0x009B50F4
		// (set) Token: 0x06025514 RID: 152852 RVA: 0x009B6F04 File Offset: 0x009B5104
		public unsafe bool TraceMeshInvisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_58) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_58) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050D1 RID: 20689
		// (get) Token: 0x06025515 RID: 152853 RVA: 0x009B6F15 File Offset: 0x009B5115
		// (set) Token: 0x06025516 RID: 152854 RVA: 0x009B6F25 File Offset: 0x009B5125
		public unsafe int OutputMaterialSelected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_59);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_59) = value;
			}
		}

		// Token: 0x170050D2 RID: 20690
		// (get) Token: 0x06025517 RID: 152855 RVA: 0x009B6F38 File Offset: 0x009B5138
		// (set) Token: 0x06025518 RID: 152856 RVA: 0x009B6F71 File Offset: 0x009B5171
		public TArray<UMaterialInterface> OutputMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._OutputMaterials) == null)
				{
					result = (this._OutputMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_60, this));
				}
				return result;
			}
			set
			{
				this.OutputMaterials.CopyAssign(value);
			}
		}

		// Token: 0x170050D3 RID: 20691
		// (get) Token: 0x06025519 RID: 152857 RVA: 0x009B6F7F File Offset: 0x009B517F
		// (set) Token: 0x0602551A RID: 152858 RVA: 0x009B6F8F File Offset: 0x009B518F
		public unsafe bool ForceAutoLoadPreset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_61) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_61) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050D4 RID: 20692
		// (get) Token: 0x0602551B RID: 152859 RVA: 0x009B6FA0 File Offset: 0x009B51A0
		// (set) Token: 0x0602551C RID: 152860 RVA: 0x009B6FD9 File Offset: 0x009B51D9
		public TArray<string> RenderTargetsList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._RenderTargetsList) == null)
				{
					result = (this._RenderTargetsList = new TArray<string>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_62, this));
				}
				return result;
			}
			set
			{
				this.RenderTargetsList.CopyAssign(value);
			}
		}

		// Token: 0x170050D5 RID: 20693
		// (get) Token: 0x0602551D RID: 152861 RVA: 0x009B6FE8 File Offset: 0x009B51E8
		// (set) Token: 0x0602551E RID: 152862 RVA: 0x009B7021 File Offset: 0x009B5221
		public TMap<string, UTextureRenderTarget2D> RenderTargetsMap
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, UTextureRenderTarget2D> result;
				if ((result = this._RenderTargetsMap) == null)
				{
					result = (this._RenderTargetsMap = new TMap<string, UTextureRenderTarget2D>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_63, this));
				}
				return result;
			}
			set
			{
				this.RenderTargetsMap.CopyAssign(value);
			}
		}

		// Token: 0x170050D6 RID: 20694
		// (get) Token: 0x0602551F RID: 152863 RVA: 0x009B702F File Offset: 0x009B522F
		// (set) Token: 0x06025520 RID: 152864 RVA: 0x009B7043 File Offset: 0x009B5243
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_Advection
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_64);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_64, value);
			}
		}

		// Token: 0x170050D7 RID: 20695
		// (get) Token: 0x06025521 RID: 152865 RVA: 0x009B7058 File Offset: 0x009B5258
		// (set) Token: 0x06025522 RID: 152866 RVA: 0x009B706C File Offset: 0x009B526C
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_Divergence
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_65);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_65, value);
			}
		}

		// Token: 0x170050D8 RID: 20696
		// (get) Token: 0x06025523 RID: 152867 RVA: 0x009B7081 File Offset: 0x009B5281
		// (set) Token: 0x06025524 RID: 152868 RVA: 0x009B7095 File Offset: 0x009B5295
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_PressureCycle1
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_66);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_66, value);
			}
		}

		// Token: 0x170050D9 RID: 20697
		// (get) Token: 0x06025525 RID: 152869 RVA: 0x009B70AA File Offset: 0x009B52AA
		// (set) Token: 0x06025526 RID: 152870 RVA: 0x009B70BE File Offset: 0x009B52BE
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_PressureCycle2
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_67);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_67, value);
			}
		}

		// Token: 0x170050DA RID: 20698
		// (get) Token: 0x06025527 RID: 152871 RVA: 0x009B70D3 File Offset: 0x009B52D3
		// (set) Token: 0x06025528 RID: 152872 RVA: 0x009B70E3 File Offset: 0x009B52E3
		public unsafe float VeloStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_68);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_68) = value;
			}
		}

		// Token: 0x170050DB RID: 20699
		// (get) Token: 0x06025529 RID: 152873 RVA: 0x009B70F4 File Offset: 0x009B52F4
		// (set) Token: 0x0602552A RID: 152874 RVA: 0x009B7104 File Offset: 0x009B5304
		public unsafe float VeloOffsetX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_69);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_69) = value;
			}
		}

		// Token: 0x170050DC RID: 20700
		// (get) Token: 0x0602552B RID: 152875 RVA: 0x009B7115 File Offset: 0x009B5315
		// (set) Token: 0x0602552C RID: 152876 RVA: 0x009B7125 File Offset: 0x009B5325
		public unsafe float VeloOffsetY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_70);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_70) = value;
			}
		}

		// Token: 0x170050DD RID: 20701
		// (get) Token: 0x0602552D RID: 152877 RVA: 0x009B7136 File Offset: 0x009B5336
		// (set) Token: 0x0602552E RID: 152878 RVA: 0x009B7146 File Offset: 0x009B5346
		public unsafe float VeloRotate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_71);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_71) = value;
			}
		}

		// Token: 0x170050DE RID: 20702
		// (get) Token: 0x0602552F RID: 152879 RVA: 0x009B7157 File Offset: 0x009B5357
		// (set) Token: 0x06025530 RID: 152880 RVA: 0x009B7167 File Offset: 0x009B5367
		public unsafe float VeloAmpNoise
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_72);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_72) = value;
			}
		}

		// Token: 0x170050DF RID: 20703
		// (get) Token: 0x06025531 RID: 152881 RVA: 0x009B7178 File Offset: 0x009B5378
		// (set) Token: 0x06025532 RID: 152882 RVA: 0x009B7188 File Offset: 0x009B5388
		public unsafe float VeloDirNoise
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_73);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_73) = value;
			}
		}

		// Token: 0x170050E0 RID: 20704
		// (get) Token: 0x06025533 RID: 152883 RVA: 0x009B7199 File Offset: 0x009B5399
		// (set) Token: 0x06025534 RID: 152884 RVA: 0x009B71A9 File Offset: 0x009B53A9
		public unsafe float Speed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_74);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_74) = value;
			}
		}

		// Token: 0x170050E1 RID: 20705
		// (get) Token: 0x06025535 RID: 152885 RVA: 0x009B71BA File Offset: 0x009B53BA
		// (set) Token: 0x06025536 RID: 152886 RVA: 0x009B71CE File Offset: 0x009B53CE
		public unsafe FName Apply1stOutMatToActorsWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_75);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_75) = value;
			}
		}

		// Token: 0x170050E2 RID: 20706
		// (get) Token: 0x06025537 RID: 152887 RVA: 0x009B71E3 File Offset: 0x009B53E3
		// (set) Token: 0x06025538 RID: 152888 RVA: 0x009B71F7 File Offset: 0x009B53F7
		public unsafe FName Apply1stOutMatToComponentsWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_76);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_76) = value;
			}
		}

		// Token: 0x170050E3 RID: 20707
		// (get) Token: 0x06025539 RID: 152889 RVA: 0x009B720C File Offset: 0x009B540C
		// (set) Token: 0x0602553A RID: 152890 RVA: 0x009B7220 File Offset: 0x009B5420
		public unsafe FName FeedTaggedActorNiagaraComponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_77);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_77) = value;
			}
		}

		// Token: 0x170050E4 RID: 20708
		// (get) Token: 0x0602553B RID: 152891 RVA: 0x009B7235 File Offset: 0x009B5435
		// (set) Token: 0x0602553C RID: 152892 RVA: 0x009B7245 File Offset: 0x009B5445
		public unsafe bool Make1stOutputAvailableFor2ndOutput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_78) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_78) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050E5 RID: 20709
		// (get) Token: 0x0602553D RID: 152893 RVA: 0x009B7256 File Offset: 0x009B5456
		// (set) Token: 0x0602553E RID: 152894 RVA: 0x009B7266 File Offset: 0x009B5466
		public unsafe bool Make1stOutputAvailableForNiagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_79) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_79) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050E6 RID: 20710
		// (get) Token: 0x0602553F RID: 152895 RVA: 0x009B7277 File Offset: 0x009B5477
		// (set) Token: 0x06025540 RID: 152896 RVA: 0x009B7287 File Offset: 0x009B5487
		public unsafe bool MakePressureAvailableForNiagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_80) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_80) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050E7 RID: 20711
		// (get) Token: 0x06025541 RID: 152897 RVA: 0x009B7298 File Offset: 0x009B5498
		// (set) Token: 0x06025542 RID: 152898 RVA: 0x009B72A8 File Offset: 0x009B54A8
		public unsafe int SecondaryOutputMaterialSelected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_81);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_81) = value;
			}
		}

		// Token: 0x170050E8 RID: 20712
		// (get) Token: 0x06025543 RID: 152899 RVA: 0x009B72BC File Offset: 0x009B54BC
		// (set) Token: 0x06025544 RID: 152900 RVA: 0x009B72F5 File Offset: 0x009B54F5
		public TArray<UMaterialInterface> SecondaryOutputMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._SecondaryOutputMaterials) == null)
				{
					result = (this._SecondaryOutputMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_82, this));
				}
				return result;
			}
			set
			{
				this.SecondaryOutputMaterials.CopyAssign(value);
			}
		}

		// Token: 0x170050E9 RID: 20713
		// (get) Token: 0x06025545 RID: 152901 RVA: 0x009B7303 File Offset: 0x009B5503
		// (set) Token: 0x06025546 RID: 152902 RVA: 0x009B7317 File Offset: 0x009B5517
		public unsafe FName Apply2ndOutMatToActorsWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_83);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_83) = value;
			}
		}

		// Token: 0x170050EA RID: 20714
		// (get) Token: 0x06025547 RID: 152903 RVA: 0x009B732C File Offset: 0x009B552C
		// (set) Token: 0x06025548 RID: 152904 RVA: 0x009B7340 File Offset: 0x009B5540
		public unsafe FName Apply2ndOutMatToComponentsWithTag
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_84);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_84) = value;
			}
		}

		// Token: 0x170050EB RID: 20715
		// (get) Token: 0x06025549 RID: 152905 RVA: 0x009B7355 File Offset: 0x009B5555
		// (set) Token: 0x0602554A RID: 152906 RVA: 0x009B7365 File Offset: 0x009B5565
		public unsafe bool UseRenderTargetAsInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_85) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_85) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050EC RID: 20716
		// (get) Token: 0x0602554B RID: 152907 RVA: 0x009B7376 File Offset: 0x009B5576
		// (set) Token: 0x0602554C RID: 152908 RVA: 0x009B738A File Offset: 0x009B558A
		[Nullable(2)]
		public unsafe UTextureRenderTarget InputRenderTarget
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_86);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_86, value);
			}
		}

		// Token: 0x170050ED RID: 20717
		// (get) Token: 0x0602554D RID: 152909 RVA: 0x009B739F File Offset: 0x009B559F
		// (set) Token: 0x0602554E RID: 152910 RVA: 0x009B73AF File Offset: 0x009B55AF
		public unsafe bool RGB_InputMaterial
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_87) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_87) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050EE RID: 20718
		// (get) Token: 0x0602554F RID: 152911 RVA: 0x009B73C0 File Offset: 0x009B55C0
		// (set) Token: 0x06025550 RID: 152912 RVA: 0x009B73D0 File Offset: 0x009B55D0
		public unsafe int InputMaterialSelected
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_88);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_88) = value;
			}
		}

		// Token: 0x170050EF RID: 20719
		// (get) Token: 0x06025551 RID: 152913 RVA: 0x009B73E4 File Offset: 0x009B55E4
		// (set) Token: 0x06025552 RID: 152914 RVA: 0x009B741D File Offset: 0x009B561D
		public TArray<UMaterialInterface> InputMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._InputMaterials) == null)
				{
					result = (this._InputMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_89, this));
				}
				return result;
			}
			set
			{
				this.InputMaterials.CopyAssign(value);
			}
		}

		// Token: 0x170050F0 RID: 20720
		// (get) Token: 0x06025553 RID: 152915 RVA: 0x009B742B File Offset: 0x009B562B
		// (set) Token: 0x06025554 RID: 152916 RVA: 0x009B743B File Offset: 0x009B563B
		public unsafe bool SimAreaClamp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_90) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_90) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050F1 RID: 20721
		// (get) Token: 0x06025555 RID: 152917 RVA: 0x009B744C File Offset: 0x009B564C
		// (set) Token: 0x06025556 RID: 152918 RVA: 0x009B745C File Offset: 0x009B565C
		public unsafe bool ShowMouseCursor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_91) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_91) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050F2 RID: 20722
		// (get) Token: 0x06025557 RID: 152919 RVA: 0x009B746D File Offset: 0x009B566D
		// (set) Token: 0x06025558 RID: 152920 RVA: 0x009B747D File Offset: 0x009B567D
		public unsafe float Divergence
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_92);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_92) = value;
			}
		}

		// Token: 0x170050F3 RID: 20723
		// (get) Token: 0x06025559 RID: 152921 RVA: 0x009B748E File Offset: 0x009B568E
		// (set) Token: 0x0602555A RID: 152922 RVA: 0x009B749E File Offset: 0x009B569E
		public unsafe float InputFeedback
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_93);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_93) = value;
			}
		}

		// Token: 0x170050F4 RID: 20724
		// (get) Token: 0x0602555B RID: 152923 RVA: 0x009B74AF File Offset: 0x009B56AF
		// (set) Token: 0x0602555C RID: 152924 RVA: 0x009B74BF File Offset: 0x009B56BF
		public unsafe float FlowFeedback
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_94);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_94) = value;
			}
		}

		// Token: 0x170050F5 RID: 20725
		// (get) Token: 0x0602555D RID: 152925 RVA: 0x009B74D0 File Offset: 0x009B56D0
		// (set) Token: 0x0602555E RID: 152926 RVA: 0x009B74E0 File Offset: 0x009B56E0
		public unsafe float VeloFromSimAreaMotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_95);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_95) = value;
			}
		}

		// Token: 0x170050F6 RID: 20726
		// (get) Token: 0x0602555F RID: 152927 RVA: 0x009B74F1 File Offset: 0x009B56F1
		// (set) Token: 0x06025560 RID: 152928 RVA: 0x009B7501 File Offset: 0x009B5701
		public unsafe float OffsetFromSimAreaMotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_96);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_96) = value;
			}
		}

		// Token: 0x170050F7 RID: 20727
		// (get) Token: 0x06025561 RID: 152929 RVA: 0x009B7512 File Offset: 0x009B5712
		// (set) Token: 0x06025562 RID: 152930 RVA: 0x009B7522 File Offset: 0x009B5722
		public unsafe float VeloFromBrushMotion
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_97);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_97) = value;
			}
		}

		// Token: 0x170050F8 RID: 20728
		// (get) Token: 0x06025563 RID: 152931 RVA: 0x009B7533 File Offset: 0x009B5733
		// (set) Token: 0x06025564 RID: 152932 RVA: 0x009B7543 File Offset: 0x009B5743
		public unsafe float BrushSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_98);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_98) = value;
			}
		}

		// Token: 0x170050F9 RID: 20729
		// (get) Token: 0x06025565 RID: 152933 RVA: 0x009B7554 File Offset: 0x009B5754
		// (set) Token: 0x06025566 RID: 152934 RVA: 0x009B7564 File Offset: 0x009B5764
		public unsafe float BrushStrength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_99);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_99) = value;
			}
		}

		// Token: 0x170050FA RID: 20730
		// (get) Token: 0x06025567 RID: 152935 RVA: 0x009B7575 File Offset: 0x009B5775
		// (set) Token: 0x06025568 RID: 152936 RVA: 0x009B7585 File Offset: 0x009B5785
		public unsafe float BrushStrengthTemp1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_100);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_100) = value;
			}
		}

		// Token: 0x170050FB RID: 20731
		// (get) Token: 0x06025569 RID: 152937 RVA: 0x009B7596 File Offset: 0x009B5796
		// (set) Token: 0x0602556A RID: 152938 RVA: 0x009B75A6 File Offset: 0x009B57A6
		public unsafe bool EraserMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_101) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_101) = (value ? 1 : 0);
			}
		}

		// Token: 0x170050FC RID: 20732
		// (get) Token: 0x0602556B RID: 152939 RVA: 0x009B75B7 File Offset: 0x009B57B7
		// (set) Token: 0x0602556C RID: 152940 RVA: 0x009B75C7 File Offset: 0x009B57C7
		public unsafe float BrushHardness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_102);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_102) = value;
			}
		}

		// Token: 0x170050FD RID: 20733
		// (get) Token: 0x0602556D RID: 152941 RVA: 0x009B75D8 File Offset: 0x009B57D8
		// (set) Token: 0x0602556E RID: 152942 RVA: 0x009B75EC File Offset: 0x009B57EC
		public unsafe string ParticleTemplate
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_103)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_103)), value);
			}
		}

		// Token: 0x170050FE RID: 20734
		// (get) Token: 0x0602556F RID: 152943 RVA: 0x009B7601 File Offset: 0x009B5801
		// (set) Token: 0x06025570 RID: 152944 RVA: 0x009B7615 File Offset: 0x009B5815
		public unsafe string DensityTemplate
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_104)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_104)), value);
			}
		}

		// Token: 0x170050FF RID: 20735
		// (get) Token: 0x06025571 RID: 152945 RVA: 0x009B762A File Offset: 0x009B582A
		// (set) Token: 0x06025572 RID: 152946 RVA: 0x009B763E File Offset: 0x009B583E
		public unsafe string VelocityTemplate
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_105)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_105)), value);
			}
		}

		// Token: 0x17005100 RID: 20736
		// (get) Token: 0x06025573 RID: 152947 RVA: 0x009B7653 File Offset: 0x009B5853
		// (set) Token: 0x06025574 RID: 152948 RVA: 0x009B7667 File Offset: 0x009B5867
		public unsafe string MetaData
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_106)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_106)), value);
			}
		}

		// Token: 0x17005101 RID: 20737
		// (get) Token: 0x06025575 RID: 152949 RVA: 0x009B767C File Offset: 0x009B587C
		// (set) Token: 0x06025576 RID: 152950 RVA: 0x009B768C File Offset: 0x009B588C
		public unsafe float BrushPuncture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_107);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_107) = value;
			}
		}

		// Token: 0x17005102 RID: 20738
		// (get) Token: 0x06025577 RID: 152951 RVA: 0x009B769D File Offset: 0x009B589D
		// (set) Token: 0x06025578 RID: 152952 RVA: 0x009B76B1 File Offset: 0x009B58B1
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_CollisionPainterDot
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_108);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_108, value);
			}
		}

		// Token: 0x17005103 RID: 20739
		// (get) Token: 0x06025579 RID: 152953 RVA: 0x009B76C6 File Offset: 0x009B58C6
		// (set) Token: 0x0602557A RID: 152954 RVA: 0x009B76DA File Offset: 0x009B58DA
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_CollisionPainterLine
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_109);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_109, value);
			}
		}

		// Token: 0x17005104 RID: 20740
		// (get) Token: 0x0602557B RID: 152955 RVA: 0x009B76EF File Offset: 0x009B58EF
		// (set) Token: 0x0602557C RID: 152956 RVA: 0x009B7703 File Offset: 0x009B5903
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_CollisionPainterOffset
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_110);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_110, value);
			}
		}

		// Token: 0x17005105 RID: 20741
		// (get) Token: 0x0602557D RID: 152957 RVA: 0x009B7718 File Offset: 0x009B5918
		// (set) Token: 0x0602557E RID: 152958 RVA: 0x009B772C File Offset: 0x009B592C
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_CompositeAndGradient
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_111);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_111, value);
			}
		}

		// Token: 0x17005106 RID: 20742
		// (get) Token: 0x0602557F RID: 152959 RVA: 0x009B7741 File Offset: 0x009B5941
		// (set) Token: 0x06025580 RID: 152960 RVA: 0x009B7755 File Offset: 0x009B5955
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_Output
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_112);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_112, value);
			}
		}

		// Token: 0x17005107 RID: 20743
		// (get) Token: 0x06025581 RID: 152961 RVA: 0x009B776A File Offset: 0x009B596A
		// (set) Token: 0x06025582 RID: 152962 RVA: 0x009B777E File Offset: 0x009B597E
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_SecondaryOutput
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_113);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_113, value);
			}
		}

		// Token: 0x17005108 RID: 20744
		// (get) Token: 0x06025583 RID: 152963 RVA: 0x009B7793 File Offset: 0x009B5993
		// (set) Token: 0x06025584 RID: 152964 RVA: 0x009B77A7 File Offset: 0x009B59A7
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic MI_Null
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_114);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_114, value);
			}
		}

		// Token: 0x17005109 RID: 20745
		// (get) Token: 0x06025585 RID: 152965 RVA: 0x009B77BC File Offset: 0x009B59BC
		// (set) Token: 0x06025586 RID: 152966 RVA: 0x009B77D0 File Offset: 0x009B59D0
		[Nullable(2)]
		public unsafe UMaterialInterface NullMaterial
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInterface>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_115);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_115, value);
			}
		}

		// Token: 0x1700510A RID: 20746
		// (get) Token: 0x06025587 RID: 152967 RVA: 0x009B77E5 File Offset: 0x009B59E5
		// (set) Token: 0x06025588 RID: 152968 RVA: 0x009B77F9 File Offset: 0x009B59F9
		public unsafe FName NullName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_116);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_116) = value;
			}
		}

		// Token: 0x1700510B RID: 20747
		// (get) Token: 0x06025589 RID: 152969 RVA: 0x009B780E File Offset: 0x009B5A0E
		// (set) Token: 0x0602558A RID: 152970 RVA: 0x009B7822 File Offset: 0x009B5A22
		public unsafe string NullString
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_117)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NinjaLiveComponent_C.__PropertyOffset_117)), value);
			}
		}

		// Token: 0x1700510C RID: 20748
		// (get) Token: 0x0602558B RID: 152971 RVA: 0x009B7837 File Offset: 0x009B5A37
		// (set) Token: 0x0602558C RID: 152972 RVA: 0x009B784B File Offset: 0x009B5A4B
		[Nullable(2)]
		public unsafe UTexture2D VelocityInput
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_118);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_118, value);
			}
		}

		// Token: 0x1700510D RID: 20749
		// (get) Token: 0x0602558D RID: 152973 RVA: 0x009B7860 File Offset: 0x009B5A60
		// (set) Token: 0x0602558E RID: 152974 RVA: 0x009B7874 File Offset: 0x009B5A74
		[Nullable(2)]
		public unsafe UTexture2D DensityInput
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_119);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_119, value);
			}
		}

		// Token: 0x1700510E RID: 20750
		// (get) Token: 0x0602558F RID: 152975 RVA: 0x009B7889 File Offset: 0x009B5A89
		// (set) Token: 0x06025590 RID: 152976 RVA: 0x009B7899 File Offset: 0x009B5A99
		public unsafe bool FlipRenderTargetsForMobile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_120) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_120) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700510F RID: 20751
		// (get) Token: 0x06025591 RID: 152977 RVA: 0x009B78AA File Offset: 0x009B5AAA
		// (set) Token: 0x06025592 RID: 152978 RVA: 0x009B78BA File Offset: 0x009B5ABA
		public unsafe bool SelfService_IF_PoolEmpty
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_121) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_121) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005110 RID: 20752
		// (get) Token: 0x06025593 RID: 152979 RVA: 0x009B78CB File Offset: 0x009B5ACB
		// (set) Token: 0x06025594 RID: 152980 RVA: 0x009B78DF File Offset: 0x009B5ADF
		[Nullable(2)]
		public unsafe UBoxComponent ActivationVolume
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_122);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_122, value);
			}
		}

		// Token: 0x17005111 RID: 20753
		// (get) Token: 0x06025595 RID: 152981 RVA: 0x009B78F4 File Offset: 0x009B5AF4
		// (set) Token: 0x06025596 RID: 152982 RVA: 0x009B7904 File Offset: 0x009B5B04
		public unsafe bool AutonomousMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_123) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_123) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005112 RID: 20754
		// (get) Token: 0x06025597 RID: 152983 RVA: 0x009B7915 File Offset: 0x009B5B15
		// (set) Token: 0x06025598 RID: 152984 RVA: 0x009B7925 File Offset: 0x009B5B25
		public unsafe bool AbsPathForVelocityTemplate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_124) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_124) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005113 RID: 20755
		// (get) Token: 0x06025599 RID: 152985 RVA: 0x009B7936 File Offset: 0x009B5B36
		// (set) Token: 0x0602559A RID: 152986 RVA: 0x009B7946 File Offset: 0x009B5B46
		public unsafe bool AbsPathForDensityTemplate
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_125) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_125) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005114 RID: 20756
		// (get) Token: 0x0602559B RID: 152987 RVA: 0x009B7958 File Offset: 0x009B5B58
		// (set) Token: 0x0602559C RID: 152988 RVA: 0x009B7991 File Offset: 0x009B5B91
		public TMap<int, UPrimitiveComponent> SkeletalMesh_TempArray_Pairs
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, UPrimitiveComponent> result;
				if ((result = this._SkeletalMesh_TempArray_Pairs) == null)
				{
					result = (this._SkeletalMesh_TempArray_Pairs = new TMap<int, UPrimitiveComponent>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_126, this));
				}
				return result;
			}
			set
			{
				this.SkeletalMesh_TempArray_Pairs.CopyAssign(value);
			}
		}

		// Token: 0x17005115 RID: 20757
		// (get) Token: 0x0602559D RID: 152989 RVA: 0x009B79A0 File Offset: 0x009B5BA0
		// (set) Token: 0x0602559E RID: 152990 RVA: 0x009B79D9 File Offset: 0x009B5BD9
		public TArray<UPrimitiveComponent> OverlappingComponents
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UPrimitiveComponent> result;
				if ((result = this._OverlappingComponents) == null)
				{
					result = (this._OverlappingComponents = new TArray<UPrimitiveComponent>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_127, this));
				}
				return result;
			}
			set
			{
				this.OverlappingComponents.CopyAssign(value);
			}
		}

		// Token: 0x17005116 RID: 20758
		// (get) Token: 0x0602559F RID: 152991 RVA: 0x009B79E8 File Offset: 0x009B5BE8
		// (set) Token: 0x060255A0 RID: 152992 RVA: 0x009B7A21 File Offset: 0x009B5C21
		public TArray<USkeletalMeshComponent> ContinuousInteractionSkeletalComponent
		{
			get
			{
				base.FastCheckIsValid();
				TArray<USkeletalMeshComponent> result;
				if ((result = this._ContinuousInteractionSkeletalComponent) == null)
				{
					result = (this._ContinuousInteractionSkeletalComponent = new TArray<USkeletalMeshComponent>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_128, this));
				}
				return result;
			}
			set
			{
				this.ContinuousInteractionSkeletalComponent.CopyAssign(value);
			}
		}

		// Token: 0x17005117 RID: 20759
		// (get) Token: 0x060255A1 RID: 152993 RVA: 0x009B7A30 File Offset: 0x009B5C30
		// (set) Token: 0x060255A2 RID: 152994 RVA: 0x009B7A69 File Offset: 0x009B5C69
		public TArray<bool> ListOfAvailableTempArrays
		{
			get
			{
				base.FastCheckIsValid();
				TArray<bool> result;
				if ((result = this._ListOfAvailableTempArrays) == null)
				{
					result = (this._ListOfAvailableTempArrays = new TArray<bool>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_129, this));
				}
				return result;
			}
			set
			{
				this.ListOfAvailableTempArrays.CopyAssign(value);
			}
		}

		// Token: 0x17005118 RID: 20760
		// (get) Token: 0x060255A3 RID: 152995 RVA: 0x009B7A77 File Offset: 0x009B5C77
		// (set) Token: 0x060255A4 RID: 152996 RVA: 0x009B7A8B File Offset: 0x009B5C8B
		[Nullable(2)]
		public unsafe UPrimitiveComponent OverlappingSkeletalMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrimitiveComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_130);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_130, value);
			}
		}

		// Token: 0x17005119 RID: 20761
		// (get) Token: 0x060255A5 RID: 152997 RVA: 0x009B7AA0 File Offset: 0x009B5CA0
		// (set) Token: 0x060255A6 RID: 152998 RVA: 0x009B7AB4 File Offset: 0x009B5CB4
		public unsafe FName OverlappingBone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_131);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_131) = value;
			}
		}

		// Token: 0x1700511A RID: 20762
		// (get) Token: 0x060255A7 RID: 152999 RVA: 0x009B7AC9 File Offset: 0x009B5CC9
		// (set) Token: 0x060255A8 RID: 153000 RVA: 0x009B7ADD File Offset: 0x009B5CDD
		public unsafe FVector Position1_3D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_132);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_132) = value;
			}
		}

		// Token: 0x1700511B RID: 20763
		// (get) Token: 0x060255A9 RID: 153001 RVA: 0x009B7AF2 File Offset: 0x009B5CF2
		// (set) Token: 0x060255AA RID: 153002 RVA: 0x009B7B06 File Offset: 0x009B5D06
		public unsafe FVector LastPosition1_3D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_133);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_133) = value;
			}
		}

		// Token: 0x1700511C RID: 20764
		// (get) Token: 0x060255AB RID: 153003 RVA: 0x009B7B1B File Offset: 0x009B5D1B
		// (set) Token: 0x060255AC RID: 153004 RVA: 0x009B7B2B File Offset: 0x009B5D2B
		public unsafe float TraceMeshSizeCoeff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_134);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_134) = value;
			}
		}

		// Token: 0x1700511D RID: 20765
		// (get) Token: 0x060255AD RID: 153005 RVA: 0x009B7B3C File Offset: 0x009B5D3C
		// (set) Token: 0x060255AE RID: 153006 RVA: 0x009B7B4C File Offset: 0x009B5D4C
		public unsafe float OverlappingMeshSizeCoeff
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_135);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_135) = value;
			}
		}

		// Token: 0x1700511E RID: 20766
		// (get) Token: 0x060255AF RID: 153007 RVA: 0x009B7B5D File Offset: 0x009B5D5D
		// (set) Token: 0x060255B0 RID: 153008 RVA: 0x009B7B71 File Offset: 0x009B5D71
		[Nullable(2)]
		public unsafe UPrimitiveComponent OverlappingComponent
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrimitiveComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_136);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_136, value);
			}
		}

		// Token: 0x1700511F RID: 20767
		// (get) Token: 0x060255B1 RID: 153009 RVA: 0x009B7B86 File Offset: 0x009B5D86
		// (set) Token: 0x060255B2 RID: 153010 RVA: 0x009B7B96 File Offset: 0x009B5D96
		public unsafe int TouchLookupIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_137);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_137) = value;
			}
		}

		// Token: 0x17005120 RID: 20768
		// (get) Token: 0x060255B3 RID: 153011 RVA: 0x009B7BA8 File Offset: 0x009B5DA8
		// (set) Token: 0x060255B4 RID: 153012 RVA: 0x009B7BE1 File Offset: 0x009B5DE1
		public TArray<FLinearColor> LastPosition3_2D
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FLinearColor> result;
				if ((result = this._LastPosition3_2D) == null)
				{
					result = (this._LastPosition3_2D = new TArray<FLinearColor>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_138, this));
				}
				return result;
			}
			set
			{
				this.LastPosition3_2D.CopyAssign(value);
			}
		}

		// Token: 0x17005121 RID: 20769
		// (get) Token: 0x060255B5 RID: 153013 RVA: 0x009B7BEF File Offset: 0x009B5DEF
		// (set) Token: 0x060255B6 RID: 153014 RVA: 0x009B7C03 File Offset: 0x009B5E03
		public unsafe FLinearColor LastPosition2_2D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_139);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_139) = value;
			}
		}

		// Token: 0x17005122 RID: 20770
		// (get) Token: 0x060255B7 RID: 153015 RVA: 0x009B7C18 File Offset: 0x009B5E18
		// (set) Token: 0x060255B8 RID: 153016 RVA: 0x009B7C28 File Offset: 0x009B5E28
		public unsafe bool MousePass
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_140) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_140) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005123 RID: 20771
		// (get) Token: 0x060255B9 RID: 153017 RVA: 0x009B7C39 File Offset: 0x009B5E39
		// (set) Token: 0x060255BA RID: 153018 RVA: 0x009B7C4D File Offset: 0x009B5E4D
		public unsafe FLinearColor Position2_2D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_141);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_141) = value;
			}
		}

		// Token: 0x17005124 RID: 20772
		// (get) Token: 0x060255BB RID: 153019 RVA: 0x009B7C64 File Offset: 0x009B5E64
		// (set) Token: 0x060255BC RID: 153020 RVA: 0x009B7C9D File Offset: 0x009B5E9D
		public TArray<FLinearColor> Position3_2D
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FLinearColor> result;
				if ((result = this._Position3_2D) == null)
				{
					result = (this._Position3_2D = new TArray<FLinearColor>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_142, this));
				}
				return result;
			}
			set
			{
				this.Position3_2D.CopyAssign(value);
			}
		}

		// Token: 0x17005125 RID: 20773
		// (get) Token: 0x060255BD RID: 153021 RVA: 0x009B7CAB File Offset: 0x009B5EAB
		// (set) Token: 0x060255BE RID: 153022 RVA: 0x009B7CBB File Offset: 0x009B5EBB
		public unsafe int PosDataType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_143);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_143) = value;
			}
		}

		// Token: 0x17005126 RID: 20774
		// (get) Token: 0x060255BF RID: 153023 RVA: 0x009B7CCC File Offset: 0x009B5ECC
		// (set) Token: 0x060255C0 RID: 153024 RVA: 0x009B7CDC File Offset: 0x009B5EDC
		public unsafe bool ShowVelocityDebugCone
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_144) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_144) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005127 RID: 20775
		// (get) Token: 0x060255C1 RID: 153025 RVA: 0x009B7CED File Offset: 0x009B5EED
		// (set) Token: 0x060255C2 RID: 153026 RVA: 0x009B7CFD File Offset: 0x009B5EFD
		public unsafe bool IgnoreInterfaceCommands
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_145) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_145) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005128 RID: 20776
		// (get) Token: 0x060255C3 RID: 153027 RVA: 0x009B7D0E File Offset: 0x009B5F0E
		// (set) Token: 0x060255C4 RID: 153028 RVA: 0x009B7D1E File Offset: 0x009B5F1E
		public unsafe bool DisableAndNotTickBlock
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_146) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_146) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005129 RID: 20777
		// (get) Token: 0x060255C5 RID: 153029 RVA: 0x009B7D2F File Offset: 0x009B5F2F
		// (set) Token: 0x060255C6 RID: 153030 RVA: 0x009B7D3F File Offset: 0x009B5F3F
		public unsafe float InputFeedbackInterface
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_147);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_147) = value;
			}
		}

		// Token: 0x1700512A RID: 20778
		// (get) Token: 0x060255C7 RID: 153031 RVA: 0x009B7D50 File Offset: 0x009B5F50
		// (set) Token: 0x060255C8 RID: 153032 RVA: 0x009B7D60 File Offset: 0x009B5F60
		public unsafe float BrushStrengthTemp2
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_148);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_148) = value;
			}
		}

		// Token: 0x1700512B RID: 20779
		// (get) Token: 0x060255C9 RID: 153033 RVA: 0x009B7D71 File Offset: 0x009B5F71
		// (set) Token: 0x060255CA RID: 153034 RVA: 0x009B7D81 File Offset: 0x009B5F81
		public unsafe bool TickBlocker
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_149) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_149) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700512C RID: 20780
		// (get) Token: 0x060255CB RID: 153035 RVA: 0x009B7D92 File Offset: 0x009B5F92
		// (set) Token: 0x060255CC RID: 153036 RVA: 0x009B7DA2 File Offset: 0x009B5FA2
		public unsafe int FluidSolver1Iterations
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_150);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_150) = value;
			}
		}

		// Token: 0x1700512D RID: 20781
		// (get) Token: 0x060255CD RID: 153037 RVA: 0x009B7DB4 File Offset: 0x009B5FB4
		// (set) Token: 0x060255CE RID: 153038 RVA: 0x009B7DED File Offset: 0x009B5FED
		public TArray<AActor> NinjaLIVETraceExclude
		{
			get
			{
				base.FastCheckIsValid();
				TArray<AActor> result;
				if ((result = this._NinjaLIVETraceExclude) == null)
				{
					result = (this._NinjaLIVETraceExclude = new TArray<AActor>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_151, this));
				}
				return result;
			}
			set
			{
				this.NinjaLIVETraceExclude.CopyAssign(value);
			}
		}

		// Token: 0x1700512E RID: 20782
		// (get) Token: 0x060255CF RID: 153039 RVA: 0x009B7DFB File Offset: 0x009B5FFB
		// (set) Token: 0x060255D0 RID: 153040 RVA: 0x009B7E0B File Offset: 0x009B600B
		public unsafe float DeltaSeconds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_152);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_152) = value;
			}
		}

		// Token: 0x1700512F RID: 20783
		// (get) Token: 0x060255D1 RID: 153041 RVA: 0x009B7E1C File Offset: 0x009B601C
		// (set) Token: 0x060255D2 RID: 153042 RVA: 0x009B7E2C File Offset: 0x009B602C
		public unsafe bool UseUnrealNativeEventTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_153) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_153) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005130 RID: 20784
		// (get) Token: 0x060255D3 RID: 153043 RVA: 0x009B7E3D File Offset: 0x009B603D
		// (set) Token: 0x060255D4 RID: 153044 RVA: 0x009B7E4D File Offset: 0x009B604D
		public unsafe bool SingleInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_154) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_154) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005131 RID: 20785
		// (get) Token: 0x060255D5 RID: 153045 RVA: 0x009B7E5E File Offset: 0x009B605E
		// (set) Token: 0x060255D6 RID: 153046 RVA: 0x009B7E6E File Offset: 0x009B606E
		public unsafe bool Touch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_155) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_155) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005132 RID: 20786
		// (get) Token: 0x060255D7 RID: 153047 RVA: 0x009B7E7F File Offset: 0x009B607F
		// (set) Token: 0x060255D8 RID: 153048 RVA: 0x009B7E8F File Offset: 0x009B608F
		public unsafe float LOD_CheckFrequency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_156);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_156) = value;
			}
		}

		// Token: 0x17005133 RID: 20787
		// (get) Token: 0x060255D9 RID: 153049 RVA: 0x009B7EA0 File Offset: 0x009B60A0
		// (set) Token: 0x060255DA RID: 153050 RVA: 0x009B7EB0 File Offset: 0x009B60B0
		public unsafe bool PauseSimWhenNotVisible
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_157) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_157) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005134 RID: 20788
		// (get) Token: 0x060255DB RID: 153051 RVA: 0x009B7EC1 File Offset: 0x009B60C1
		// (set) Token: 0x060255DC RID: 153052 RVA: 0x009B7ED1 File Offset: 0x009B60D1
		public unsafe float WaitBeforePause
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_158);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_158) = value;
			}
		}

		// Token: 0x17005135 RID: 20789
		// (get) Token: 0x060255DD RID: 153053 RVA: 0x009B7EE2 File Offset: 0x009B60E2
		// (set) Token: 0x060255DE RID: 153054 RVA: 0x009B7EF2 File Offset: 0x009B60F2
		public unsafe bool MousePressed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_159) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_159) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005136 RID: 20790
		// (get) Token: 0x060255DF RID: 153055 RVA: 0x009B7F03 File Offset: 0x009B6103
		// (set) Token: 0x060255E0 RID: 153056 RVA: 0x009B7F13 File Offset: 0x009B6113
		public unsafe bool ContinuousInteractionWithOwnerActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_160) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_160) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005137 RID: 20791
		// (get) Token: 0x060255E1 RID: 153057 RVA: 0x009B7F24 File Offset: 0x009B6124
		// (set) Token: 0x060255E2 RID: 153058 RVA: 0x009B7F38 File Offset: 0x009B6138
		public unsafe FLinearColor Position1_2D
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_161);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_161) = value;
			}
		}

		// Token: 0x17005138 RID: 20792
		// (get) Token: 0x060255E3 RID: 153059 RVA: 0x009B7F4D File Offset: 0x009B614D
		// (set) Token: 0x060255E4 RID: 153060 RVA: 0x009B7F5D File Offset: 0x009B615D
		public unsafe float TimeSinceLastClick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_162);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_162) = value;
			}
		}

		// Token: 0x17005139 RID: 20793
		// (get) Token: 0x060255E5 RID: 153061 RVA: 0x009B7F6E File Offset: 0x009B616E
		// (set) Token: 0x060255E6 RID: 153062 RVA: 0x009B7F7E File Offset: 0x009B617E
		public unsafe bool Position1_3D_Static
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_163) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_163) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700513A RID: 20794
		// (get) Token: 0x060255E7 RID: 153063 RVA: 0x009B7F8F File Offset: 0x009B618F
		// (set) Token: 0x060255E8 RID: 153064 RVA: 0x009B7F9F File Offset: 0x009B619F
		public unsafe float TimeSinceLastCollision
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_164);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_164) = value;
			}
		}

		// Token: 0x1700513B RID: 20795
		// (get) Token: 0x060255E9 RID: 153065 RVA: 0x009B7FB0 File Offset: 0x009B61B0
		// (set) Token: 0x060255EA RID: 153066 RVA: 0x009B7FC0 File Offset: 0x009B61C0
		public unsafe float TimeCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_165);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_165) = value;
			}
		}

		// Token: 0x1700513C RID: 20796
		// (get) Token: 0x060255EB RID: 153067 RVA: 0x009B7FD1 File Offset: 0x009B61D1
		// (set) Token: 0x060255EC RID: 153068 RVA: 0x009B7FE1 File Offset: 0x009B61E1
		public unsafe bool Overlap1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_166) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_166) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700513D RID: 20797
		// (get) Token: 0x060255ED RID: 153069 RVA: 0x009B7FF4 File Offset: 0x009B61F4
		// (set) Token: 0x060255EE RID: 153070 RVA: 0x009B802D File Offset: 0x009B622D
		public ComponentShutdownEvent ComponentShutdownEvent
		{
			get
			{
				base.FastCheckIsValid();
				ComponentShutdownEvent result;
				if ((result = this._ComponentShutdownEvent) == null)
				{
					result = (this._ComponentShutdownEvent = new ComponentShutdownEvent(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_167, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_167, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x1700513E RID: 20798
		// (get) Token: 0x060255EF RID: 153071 RVA: 0x009B8050 File Offset: 0x009B6250
		// (set) Token: 0x060255F0 RID: 153072 RVA: 0x009B8089 File Offset: 0x009B6289
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<EObjectTypeQuery>> ContinuousInteractionInclusiveObjType
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<EObjectTypeQuery>> result;
				if ((result = this._ContinuousInteractionInclusiveObjType) == null)
				{
					result = (this._ContinuousInteractionInclusiveObjType = new TArray<TEnumAsByte<EObjectTypeQuery>>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_168, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.ContinuousInteractionInclusiveObjType.CopyAssign(value);
			}
		}

		// Token: 0x1700513F RID: 20799
		// (get) Token: 0x060255F1 RID: 153073 RVA: 0x009B8098 File Offset: 0x009B6298
		// (set) Token: 0x060255F2 RID: 153074 RVA: 0x009B80D1 File Offset: 0x009B62D1
		public TArray<FName> ContinuousInteractionComponentNamesExact
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._ContinuousInteractionComponentNamesExact) == null)
				{
					result = (this._ContinuousInteractionComponentNamesExact = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_169, this));
				}
				return result;
			}
			set
			{
				this.ContinuousInteractionComponentNamesExact.CopyAssign(value);
			}
		}

		// Token: 0x17005140 RID: 20800
		// (get) Token: 0x060255F3 RID: 153075 RVA: 0x009B80E0 File Offset: 0x009B62E0
		// (set) Token: 0x060255F4 RID: 153076 RVA: 0x009B8119 File Offset: 0x009B6319
		public TArray<FName> ContinuousInteractionBoneNamesExact
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._ContinuousInteractionBoneNamesExact) == null)
				{
					result = (this._ContinuousInteractionBoneNamesExact = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_170, this));
				}
				return result;
			}
			set
			{
				this.ContinuousInteractionBoneNamesExact.CopyAssign(value);
			}
		}

		// Token: 0x17005141 RID: 20801
		// (get) Token: 0x060255F5 RID: 153077 RVA: 0x009B8127 File Offset: 0x009B6327
		// (set) Token: 0x060255F6 RID: 153078 RVA: 0x009B8137 File Offset: 0x009B6337
		public unsafe bool SingleTargetMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_171) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_171) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005142 RID: 20802
		// (get) Token: 0x060255F7 RID: 153079 RVA: 0x009B8148 File Offset: 0x009B6348
		// (set) Token: 0x060255F8 RID: 153080 RVA: 0x009B815C File Offset: 0x009B635C
		[Nullable(0)]
		public unsafe TEnumAsByte<SingleObjectType_Enum> SingleTargetType
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_172);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_172) = value;
			}
		}

		// Token: 0x17005143 RID: 20803
		// (get) Token: 0x060255F9 RID: 153081 RVA: 0x009B8171 File Offset: 0x009B6371
		// (set) Token: 0x060255FA RID: 153082 RVA: 0x009B8181 File Offset: 0x009B6381
		public unsafe int SingleTargetModeSkeletalMeshIndex
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_173);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_173) = value;
			}
		}

		// Token: 0x17005144 RID: 20804
		// (get) Token: 0x060255FB RID: 153083 RVA: 0x009B8192 File Offset: 0x009B6392
		// (set) Token: 0x060255FC RID: 153084 RVA: 0x009B81A2 File Offset: 0x009B63A2
		public unsafe bool SingleTargetMoveSetSimSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_174) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_174) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005145 RID: 20805
		// (get) Token: 0x060255FD RID: 153085 RVA: 0x009B81B3 File Offset: 0x009B63B3
		// (set) Token: 0x060255FE RID: 153086 RVA: 0x009B81C3 File Offset: 0x009B63C3
		public unsafe float SpeedInfluenceFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_175);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_175) = value;
			}
		}

		// Token: 0x17005146 RID: 20806
		// (get) Token: 0x060255FF RID: 153087 RVA: 0x009B81D4 File Offset: 0x009B63D4
		// (set) Token: 0x06025600 RID: 153088 RVA: 0x009B81E4 File Offset: 0x009B63E4
		public unsafe float ClampMaxVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_176);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_176) = value;
			}
		}

		// Token: 0x17005147 RID: 20807
		// (get) Token: 0x06025601 RID: 153089 RVA: 0x009B81F5 File Offset: 0x009B63F5
		// (set) Token: 0x06025602 RID: 153090 RVA: 0x009B8205 File Offset: 0x009B6405
		public unsafe bool CameraFacingTraceMesh
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_177) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_177) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005148 RID: 20808
		// (get) Token: 0x06025603 RID: 153091 RVA: 0x009B8216 File Offset: 0x009B6416
		// (set) Token: 0x06025604 RID: 153092 RVA: 0x009B8226 File Offset: 0x009B6426
		public unsafe bool OverlapBasedInteraction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_178) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_178) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005149 RID: 20809
		// (get) Token: 0x06025605 RID: 153093 RVA: 0x009B8237 File Offset: 0x009B6437
		// (set) Token: 0x06025606 RID: 153094 RVA: 0x009B824B File Offset: 0x009B644B
		[Nullable(0)]
		public unsafe TEnumAsByte<UserInput_Enum> UserInputBasedInteraction
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_179);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_179) = value;
			}
		}

		// Token: 0x1700514A RID: 20810
		// (get) Token: 0x06025607 RID: 153095 RVA: 0x009B8260 File Offset: 0x009B6460
		// (set) Token: 0x06025608 RID: 153096 RVA: 0x009B8270 File Offset: 0x009B6470
		public unsafe bool BrushScaledInverselyByTraceMeshSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_180) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_180) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700514B RID: 20811
		// (get) Token: 0x06025609 RID: 153097 RVA: 0x009B8281 File Offset: 0x009B6481
		// (set) Token: 0x0602560A RID: 153098 RVA: 0x009B8291 File Offset: 0x009B6491
		public unsafe bool BrushScaledByInteractingObjSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_181) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_181) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700514C RID: 20812
		// (get) Token: 0x0602560B RID: 153099 RVA: 0x009B82A2 File Offset: 0x009B64A2
		// (set) Token: 0x0602560C RID: 153100 RVA: 0x009B82B2 File Offset: 0x009B64B2
		public unsafe bool BrushScaledByInteractingSkeletalSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_182) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_182) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700514D RID: 20813
		// (get) Token: 0x0602560D RID: 153101 RVA: 0x009B82C3 File Offset: 0x009B64C3
		// (set) Token: 0x0602560E RID: 153102 RVA: 0x009B82D3 File Offset: 0x009B64D3
		public unsafe bool UseObjBoundsInsteadOfSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_183) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_183) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700514E RID: 20814
		// (get) Token: 0x0602560F RID: 153103 RVA: 0x009B82E4 File Offset: 0x009B64E4
		// (set) Token: 0x06025610 RID: 153104 RVA: 0x009B82F4 File Offset: 0x009B64F4
		public unsafe float GlobalBrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_184);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_184) = value;
			}
		}

		// Token: 0x1700514F RID: 20815
		// (get) Token: 0x06025611 RID: 153105 RVA: 0x009B8305 File Offset: 0x009B6505
		// (set) Token: 0x06025612 RID: 153106 RVA: 0x009B8315 File Offset: 0x009B6515
		public unsafe float UserInputBrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_185);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_185) = value;
			}
		}

		// Token: 0x17005150 RID: 20816
		// (get) Token: 0x06025613 RID: 153107 RVA: 0x009B8326 File Offset: 0x009B6526
		// (set) Token: 0x06025614 RID: 153108 RVA: 0x009B8336 File Offset: 0x009B6536
		public unsafe float PrimitiveObjBrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_186);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_186) = value;
			}
		}

		// Token: 0x17005151 RID: 20817
		// (get) Token: 0x06025615 RID: 153109 RVA: 0x009B8347 File Offset: 0x009B6547
		// (set) Token: 0x06025616 RID: 153110 RVA: 0x009B8357 File Offset: 0x009B6557
		public unsafe float SkeletalMeshBrushScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_187);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_187) = value;
			}
		}

		// Token: 0x17005152 RID: 20818
		// (get) Token: 0x06025617 RID: 153111 RVA: 0x009B8368 File Offset: 0x009B6568
		// (set) Token: 0x06025618 RID: 153112 RVA: 0x009B8378 File Offset: 0x009B6578
		public unsafe bool CameraFacing_LockY_Axis
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_188) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_188) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005153 RID: 20819
		// (get) Token: 0x06025619 RID: 153113 RVA: 0x009B8389 File Offset: 0x009B6589
		// (set) Token: 0x0602561A RID: 153114 RVA: 0x009B8399 File Offset: 0x009B6599
		public unsafe bool UseLegacyCameraFacing
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_189) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_189) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005154 RID: 20820
		// (get) Token: 0x0602561B RID: 153115 RVA: 0x009B83AA File Offset: 0x009B65AA
		// (set) Token: 0x0602561C RID: 153116 RVA: 0x009B83BA File Offset: 0x009B65BA
		public unsafe int TraceMeshTranslucentSortPrio
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_190);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_190) = value;
			}
		}

		// Token: 0x17005155 RID: 20821
		// (get) Token: 0x0602561D RID: 153117 RVA: 0x009B83CB File Offset: 0x009B65CB
		// (set) Token: 0x0602561E RID: 153118 RVA: 0x009B83DB File Offset: 0x009B65DB
		public unsafe int TraceMeshQueryCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_191);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_191) = value;
			}
		}

		// Token: 0x17005156 RID: 20822
		// (get) Token: 0x0602561F RID: 153119 RVA: 0x009B83EC File Offset: 0x009B65EC
		// (set) Token: 0x06025620 RID: 153120 RVA: 0x009B83FC File Offset: 0x009B65FC
		public unsafe float LimitUnrealNativeEventTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_192);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_192) = value;
			}
		}

		// Token: 0x17005157 RID: 20823
		// (get) Token: 0x06025621 RID: 153121 RVA: 0x009B840D File Offset: 0x009B660D
		// (set) Token: 0x06025622 RID: 153122 RVA: 0x009B841D File Offset: 0x009B661D
		public unsafe bool GlobalVeloTempCondition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_193) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_193) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005158 RID: 20824
		// (get) Token: 0x06025623 RID: 153123 RVA: 0x009B842E File Offset: 0x009B662E
		// (set) Token: 0x06025624 RID: 153124 RVA: 0x009B8442 File Offset: 0x009B6642
		public unsafe FVector TracePositionTemp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_194);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_194) = value;
			}
		}

		// Token: 0x17005159 RID: 20825
		// (get) Token: 0x06025625 RID: 153125 RVA: 0x009B8457 File Offset: 0x009B6657
		// (set) Token: 0x06025626 RID: 153126 RVA: 0x009B846B File Offset: 0x009B666B
		public unsafe FVector LastTracePositionTemp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_195);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_195) = value;
			}
		}

		// Token: 0x1700515A RID: 20826
		// (get) Token: 0x06025627 RID: 153127 RVA: 0x009B8480 File Offset: 0x009B6680
		// (set) Token: 0x06025628 RID: 153128 RVA: 0x009B8490 File Offset: 0x009B6690
		public unsafe float SimEdgeBouncyness
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_196);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_196) = value;
			}
		}

		// Token: 0x1700515B RID: 20827
		// (get) Token: 0x06025629 RID: 153129 RVA: 0x009B84A1 File Offset: 0x009B66A1
		// (set) Token: 0x0602562A RID: 153130 RVA: 0x009B84B1 File Offset: 0x009B66B1
		public unsafe float FadeDensityAtSimEdge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_197);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_197) = value;
			}
		}

		// Token: 0x1700515C RID: 20828
		// (get) Token: 0x0602562B RID: 153131 RVA: 0x009B84C2 File Offset: 0x009B66C2
		// (set) Token: 0x0602562C RID: 153132 RVA: 0x009B84D2 File Offset: 0x009B66D2
		public unsafe float EdgeMaskWidth
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_198);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_198) = value;
			}
		}

		// Token: 0x1700515D RID: 20829
		// (get) Token: 0x0602562D RID: 153133 RVA: 0x009B84E3 File Offset: 0x009B66E3
		// (set) Token: 0x0602562E RID: 153134 RVA: 0x009B84F3 File Offset: 0x009B66F3
		public unsafe float VeloDirNoiseSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_199);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_199) = value;
			}
		}

		// Token: 0x1700515E RID: 20830
		// (get) Token: 0x0602562F RID: 153135 RVA: 0x009B8504 File Offset: 0x009B6704
		// (set) Token: 0x06025630 RID: 153136 RVA: 0x009B8514 File Offset: 0x009B6714
		public unsafe float VeloDirNoiseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_200);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_200) = value;
			}
		}

		// Token: 0x1700515F RID: 20831
		// (get) Token: 0x06025631 RID: 153137 RVA: 0x009B8525 File Offset: 0x009B6725
		// (set) Token: 0x06025632 RID: 153138 RVA: 0x009B8535 File Offset: 0x009B6735
		public unsafe bool UseInputMaterials
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_201) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_201) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005160 RID: 20832
		// (get) Token: 0x06025633 RID: 153139 RVA: 0x009B8546 File Offset: 0x009B6746
		// (set) Token: 0x06025634 RID: 153140 RVA: 0x009B8556 File Offset: 0x009B6756
		public unsafe float DensityTxtScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_202);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_202) = value;
			}
		}

		// Token: 0x17005161 RID: 20833
		// (get) Token: 0x06025635 RID: 153141 RVA: 0x009B8567 File Offset: 0x009B6767
		// (set) Token: 0x06025636 RID: 153142 RVA: 0x009B8577 File Offset: 0x009B6777
		public unsafe float DensityTxtOffsetX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_203);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_203) = value;
			}
		}

		// Token: 0x17005162 RID: 20834
		// (get) Token: 0x06025637 RID: 153143 RVA: 0x009B8588 File Offset: 0x009B6788
		// (set) Token: 0x06025638 RID: 153144 RVA: 0x009B8598 File Offset: 0x009B6798
		public unsafe float DensityTxtOffsetY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_204);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_204) = value;
			}
		}

		// Token: 0x17005163 RID: 20835
		// (get) Token: 0x06025639 RID: 153145 RVA: 0x009B85A9 File Offset: 0x009B67A9
		// (set) Token: 0x0602563A RID: 153146 RVA: 0x009B85B9 File Offset: 0x009B67B9
		public unsafe float BrushNoise
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_205);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_205) = value;
			}
		}

		// Token: 0x17005164 RID: 20836
		// (get) Token: 0x0602563B RID: 153147 RVA: 0x009B85CA File Offset: 0x009B67CA
		// (set) Token: 0x0602563C RID: 153148 RVA: 0x009B85DA File Offset: 0x009B67DA
		public unsafe bool BrushNoiseInWorldSpace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_206) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_206) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005165 RID: 20837
		// (get) Token: 0x0602563D RID: 153149 RVA: 0x009B85EB File Offset: 0x009B67EB
		// (set) Token: 0x0602563E RID: 153150 RVA: 0x009B85FB File Offset: 0x009B67FB
		public unsafe float BrushDensityNoiseScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_207);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_207) = value;
			}
		}

		// Token: 0x17005166 RID: 20838
		// (get) Token: 0x0602563F RID: 153151 RVA: 0x009B860C File Offset: 0x009B680C
		// (set) Token: 0x06025640 RID: 153152 RVA: 0x009B861C File Offset: 0x009B681C
		public unsafe float BrushDensityNoiseFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_208);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_208) = value;
			}
		}

		// Token: 0x17005167 RID: 20839
		// (get) Token: 0x06025641 RID: 153153 RVA: 0x009B862D File Offset: 0x009B682D
		// (set) Token: 0x06025642 RID: 153154 RVA: 0x009B863D File Offset: 0x009B683D
		public unsafe float BrushVelocityNoiseScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_209);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_209) = value;
			}
		}

		// Token: 0x17005168 RID: 20840
		// (get) Token: 0x06025643 RID: 153155 RVA: 0x009B864E File Offset: 0x009B684E
		// (set) Token: 0x06025644 RID: 153156 RVA: 0x009B865E File Offset: 0x009B685E
		public unsafe float BrushVelocityNoiseFreq
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_210);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_210) = value;
			}
		}

		// Token: 0x17005169 RID: 20841
		// (get) Token: 0x06025645 RID: 153157 RVA: 0x009B866F File Offset: 0x009B686F
		// (set) Token: 0x06025646 RID: 153158 RVA: 0x009B8683 File Offset: 0x009B6883
		public unsafe FRotator TraceMeshInitialRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_211);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_211) = value;
			}
		}

		// Token: 0x1700516A RID: 20842
		// (get) Token: 0x06025647 RID: 153159 RVA: 0x009B8698 File Offset: 0x009B6898
		// (set) Token: 0x06025648 RID: 153160 RVA: 0x009B86A8 File Offset: 0x009B68A8
		public unsafe float VeloInputTile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_212);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_212) = value;
			}
		}

		// Token: 0x1700516B RID: 20843
		// (get) Token: 0x06025649 RID: 153161 RVA: 0x009B86B9 File Offset: 0x009B68B9
		// (set) Token: 0x0602564A RID: 153162 RVA: 0x009B86C9 File Offset: 0x009B68C9
		public unsafe float VeloInputOffsetSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_213);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_213) = value;
			}
		}

		// Token: 0x1700516C RID: 20844
		// (get) Token: 0x0602564B RID: 153163 RVA: 0x009B86DA File Offset: 0x009B68DA
		// (set) Token: 0x0602564C RID: 153164 RVA: 0x009B86EA File Offset: 0x009B68EA
		public unsafe float DensityTxtMult
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_214);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_214) = value;
			}
		}

		// Token: 0x1700516D RID: 20845
		// (get) Token: 0x0602564D RID: 153165 RVA: 0x009B86FB File Offset: 0x009B68FB
		// (set) Token: 0x0602564E RID: 153166 RVA: 0x009B870B File Offset: 0x009B690B
		public unsafe float DensityInputNoiseAmp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_215);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_215) = value;
			}
		}

		// Token: 0x1700516E RID: 20846
		// (get) Token: 0x0602564F RID: 153167 RVA: 0x009B871C File Offset: 0x009B691C
		// (set) Token: 0x06025650 RID: 153168 RVA: 0x009B872C File Offset: 0x009B692C
		public unsafe float DensityInputNoiseOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_216);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_216) = value;
			}
		}

		// Token: 0x1700516F RID: 20847
		// (get) Token: 0x06025651 RID: 153169 RVA: 0x009B873D File Offset: 0x009B693D
		// (set) Token: 0x06025652 RID: 153170 RVA: 0x009B874D File Offset: 0x009B694D
		public unsafe float DensityInputNoiseTile
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_217);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_217) = value;
			}
		}

		// Token: 0x17005170 RID: 20848
		// (get) Token: 0x06025653 RID: 153171 RVA: 0x009B875E File Offset: 0x009B695E
		// (set) Token: 0x06025654 RID: 153172 RVA: 0x009B8772 File Offset: 0x009B6972
		[Nullable(2)]
		public unsafe UMaterialParameterCollection SetInternalParamsToMaterialParamCollection
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialParameterCollection>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_218);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_218, value);
			}
		}

		// Token: 0x17005171 RID: 20849
		// (get) Token: 0x06025655 RID: 153173 RVA: 0x009B8787 File Offset: 0x009B6987
		// (set) Token: 0x06025656 RID: 153174 RVA: 0x009B8797 File Offset: 0x009B6997
		public unsafe bool DrawInternalRenderTargetToExternal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_219) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_219) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005172 RID: 20850
		// (get) Token: 0x06025657 RID: 153175 RVA: 0x009B87A8 File Offset: 0x009B69A8
		// (set) Token: 0x06025658 RID: 153176 RVA: 0x009B87E1 File Offset: 0x009B69E1
		[Nullable(new byte[]
		{
			1,
			0
		})]
		public TArray<TEnumAsByte<RenderTargetList>> InternalRenderTargetsToExport
		{
			[return: Nullable(new byte[]
			{
				1,
				0
			})]
			get
			{
				base.FastCheckIsValid();
				TArray<TEnumAsByte<RenderTargetList>> result;
				if ((result = this._InternalRenderTargetsToExport) == null)
				{
					result = (this._InternalRenderTargetsToExport = new TArray<TEnumAsByte<RenderTargetList>>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_220, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0
			})]
			set
			{
				this.InternalRenderTargetsToExport.CopyAssign(value);
			}
		}

		// Token: 0x17005173 RID: 20851
		// (get) Token: 0x06025659 RID: 153177 RVA: 0x009B87F0 File Offset: 0x009B69F0
		// (set) Token: 0x0602565A RID: 153178 RVA: 0x009B8829 File Offset: 0x009B6A29
		public TArray<UTextureRenderTarget2D> ExternalRenderTargets
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UTextureRenderTarget2D> result;
				if ((result = this._ExternalRenderTargets) == null)
				{
					result = (this._ExternalRenderTargets = new TArray<UTextureRenderTarget2D>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_221, this));
				}
				return result;
			}
			set
			{
				this.ExternalRenderTargets.CopyAssign(value);
			}
		}

		// Token: 0x17005174 RID: 20852
		// (get) Token: 0x0602565B RID: 153179 RVA: 0x009B8837 File Offset: 0x009B6A37
		// (set) Token: 0x0602565C RID: 153180 RVA: 0x009B884B File Offset: 0x009B6A4B
		[Nullable(2)]
		public unsafe UTexture CollisionMask
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_222);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_222, value);
			}
		}

		// Token: 0x17005175 RID: 20853
		// (get) Token: 0x0602565D RID: 153181 RVA: 0x009B8860 File Offset: 0x009B6A60
		// (set) Token: 0x0602565E RID: 153182 RVA: 0x009B8870 File Offset: 0x009B6A70
		public unsafe bool CollisionMaskIsNonDefault
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_223) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_223) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005176 RID: 20854
		// (get) Token: 0x0602565F RID: 153183 RVA: 0x009B8881 File Offset: 0x009B6A81
		// (set) Token: 0x06025660 RID: 153184 RVA: 0x009B8895 File Offset: 0x009B6A95
		[Nullable(2)]
		public unsafe ASceneCapture2D InputSceneCaptureCamera
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<ASceneCapture2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_224);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_224, value);
			}
		}

		// Token: 0x17005177 RID: 20855
		// (get) Token: 0x06025661 RID: 153185 RVA: 0x009B88AA File Offset: 0x009B6AAA
		// (set) Token: 0x06025662 RID: 153186 RVA: 0x009B88BE File Offset: 0x009B6ABE
		[Nullable(2)]
		public unsafe UMediaPlayer InputMediaPlayer
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaPlayer>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_225);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_225, value);
			}
		}

		// Token: 0x17005178 RID: 20856
		// (get) Token: 0x06025663 RID: 153187 RVA: 0x009B88D3 File Offset: 0x009B6AD3
		// (set) Token: 0x06025664 RID: 153188 RVA: 0x009B88E7 File Offset: 0x009B6AE7
		[Nullable(2)]
		public unsafe UMediaTexture MediaTexture
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMediaTexture>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_226);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_226, value);
			}
		}

		// Token: 0x17005179 RID: 20857
		// (get) Token: 0x06025665 RID: 153189 RVA: 0x009B88FC File Offset: 0x009B6AFC
		// (set) Token: 0x06025666 RID: 153190 RVA: 0x009B8910 File Offset: 0x009B6B10
		[Nullable(2)]
		public unsafe UFileMediaSource InputMediaSource
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UFileMediaSource>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_227);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_227, value);
			}
		}

		// Token: 0x1700517A RID: 20858
		// (get) Token: 0x06025667 RID: 153191 RVA: 0x009B8925 File Offset: 0x009B6B25
		// (set) Token: 0x06025668 RID: 153192 RVA: 0x009B8935 File Offset: 0x009B6B35
		public unsafe float InputMediaLoopLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_228);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_228) = value;
			}
		}

		// Token: 0x1700517B RID: 20859
		// (get) Token: 0x06025669 RID: 153193 RVA: 0x009B8946 File Offset: 0x009B6B46
		// (set) Token: 0x0602566A RID: 153194 RVA: 0x009B8956 File Offset: 0x009B6B56
		public unsafe bool RandomizeNoiseOffsets
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_229) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_229) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700517C RID: 20860
		// (get) Token: 0x0602566B RID: 153195 RVA: 0x009B8967 File Offset: 0x009B6B67
		// (set) Token: 0x0602566C RID: 153196 RVA: 0x009B8977 File Offset: 0x009B6B77
		public unsafe int OverlapCounter
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_230);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_230) = value;
			}
		}

		// Token: 0x1700517D RID: 20861
		// (get) Token: 0x0602566D RID: 153197 RVA: 0x009B8988 File Offset: 0x009B6B88
		// (set) Token: 0x0602566E RID: 153198 RVA: 0x009B8998 File Offset: 0x009B6B98
		public unsafe bool RandomizeDensityTextureOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_231) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_231) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700517E RID: 20862
		// (get) Token: 0x0602566F RID: 153199 RVA: 0x009B89A9 File Offset: 0x009B6BA9
		// (set) Token: 0x06025670 RID: 153200 RVA: 0x009B89BD File Offset: 0x009B6BBD
		[Nullable(2)]
		public unsafe UTexture2D OverwritePresetDensityInput
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_232);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_232, value);
			}
		}

		// Token: 0x1700517F RID: 20863
		// (get) Token: 0x06025671 RID: 153201 RVA: 0x009B89D2 File Offset: 0x009B6BD2
		// (set) Token: 0x06025672 RID: 153202 RVA: 0x009B89E6 File Offset: 0x009B6BE6
		[Nullable(2)]
		public unsafe UTexture2D OverwritePresetVelocityInput
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTexture2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_233);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_233, value);
			}
		}

		// Token: 0x17005180 RID: 20864
		// (get) Token: 0x06025673 RID: 153203 RVA: 0x009B89FB File Offset: 0x009B6BFB
		// (set) Token: 0x06025674 RID: 153204 RVA: 0x009B8A0B File Offset: 0x009B6C0B
		public unsafe float BrushRnd
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_234);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_234) = value;
			}
		}

		// Token: 0x17005181 RID: 20865
		// (get) Token: 0x06025675 RID: 153205 RVA: 0x009B8A1C File Offset: 0x009B6C1C
		// (set) Token: 0x06025676 RID: 153206 RVA: 0x009B8A2C File Offset: 0x009B6C2C
		public unsafe float SimSpeedAdjustmentLatency
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_235);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_235) = value;
			}
		}

		// Token: 0x17005182 RID: 20866
		// (get) Token: 0x06025677 RID: 153207 RVA: 0x009B8A3D File Offset: 0x009B6C3D
		// (set) Token: 0x06025678 RID: 153208 RVA: 0x009B8A4D File Offset: 0x009B6C4D
		public unsafe float SpeedTemp
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_236);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_236) = value;
			}
		}

		// Token: 0x17005183 RID: 20867
		// (get) Token: 0x06025679 RID: 153209 RVA: 0x009B8A5E File Offset: 0x009B6C5E
		// (set) Token: 0x0602567A RID: 153210 RVA: 0x009B8A6E File Offset: 0x009B6C6E
		public unsafe bool StopUsingPainterCanvasWhenIdle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_237) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_237) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005184 RID: 20868
		// (get) Token: 0x0602567B RID: 153211 RVA: 0x009B8A7F File Offset: 0x009B6C7F
		// (set) Token: 0x0602567C RID: 153212 RVA: 0x009B8A8F File Offset: 0x009B6C8F
		public unsafe int Experimental_PSolver2KernelIndexOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_238);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_238) = value;
			}
		}

		// Token: 0x17005185 RID: 20869
		// (get) Token: 0x0602567D RID: 153213 RVA: 0x009B8AA0 File Offset: 0x009B6CA0
		// (set) Token: 0x0602567E RID: 153214 RVA: 0x009B8AB0 File Offset: 0x009B6CB0
		public unsafe float Experimental_PressureFeedback
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_239);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_239) = value;
			}
		}

		// Token: 0x17005186 RID: 20870
		// (get) Token: 0x0602567F RID: 153215 RVA: 0x009B8AC1 File Offset: 0x009B6CC1
		// (set) Token: 0x06025680 RID: 153216 RVA: 0x009B8AD1 File Offset: 0x009B6CD1
		public unsafe bool TraceMeshIsAlsoInteractionVolume
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_240) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_240) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005187 RID: 20871
		// (get) Token: 0x06025681 RID: 153217 RVA: 0x009B8AE4 File Offset: 0x009B6CE4
		// (set) Token: 0x06025682 RID: 153218 RVA: 0x009B8B1D File Offset: 0x009B6D1D
		public TArray<FName> TempArray0
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray0) == null)
				{
					result = (this._TempArray0 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_241, this));
				}
				return result;
			}
			set
			{
				this.TempArray0.CopyAssign(value);
			}
		}

		// Token: 0x17005188 RID: 20872
		// (get) Token: 0x06025683 RID: 153219 RVA: 0x009B8B2C File Offset: 0x009B6D2C
		// (set) Token: 0x06025684 RID: 153220 RVA: 0x009B8B65 File Offset: 0x009B6D65
		public TArray<FName> TempArray1
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray1) == null)
				{
					result = (this._TempArray1 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_242, this));
				}
				return result;
			}
			set
			{
				this.TempArray1.CopyAssign(value);
			}
		}

		// Token: 0x17005189 RID: 20873
		// (get) Token: 0x06025685 RID: 153221 RVA: 0x009B8B74 File Offset: 0x009B6D74
		// (set) Token: 0x06025686 RID: 153222 RVA: 0x009B8BAD File Offset: 0x009B6DAD
		public TArray<FName> TempArray2
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray2) == null)
				{
					result = (this._TempArray2 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_243, this));
				}
				return result;
			}
			set
			{
				this.TempArray2.CopyAssign(value);
			}
		}

		// Token: 0x1700518A RID: 20874
		// (get) Token: 0x06025687 RID: 153223 RVA: 0x009B8BBC File Offset: 0x009B6DBC
		// (set) Token: 0x06025688 RID: 153224 RVA: 0x009B8BF5 File Offset: 0x009B6DF5
		public TArray<FName> TempArray3
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray3) == null)
				{
					result = (this._TempArray3 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_244, this));
				}
				return result;
			}
			set
			{
				this.TempArray3.CopyAssign(value);
			}
		}

		// Token: 0x1700518B RID: 20875
		// (get) Token: 0x06025689 RID: 153225 RVA: 0x009B8C04 File Offset: 0x009B6E04
		// (set) Token: 0x0602568A RID: 153226 RVA: 0x009B8C3D File Offset: 0x009B6E3D
		public TArray<FName> TempArray4
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray4) == null)
				{
					result = (this._TempArray4 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_245, this));
				}
				return result;
			}
			set
			{
				this.TempArray4.CopyAssign(value);
			}
		}

		// Token: 0x1700518C RID: 20876
		// (get) Token: 0x0602568B RID: 153227 RVA: 0x009B8C4C File Offset: 0x009B6E4C
		// (set) Token: 0x0602568C RID: 153228 RVA: 0x009B8C85 File Offset: 0x009B6E85
		public TArray<FName> TempArray5
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray5) == null)
				{
					result = (this._TempArray5 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_246, this));
				}
				return result;
			}
			set
			{
				this.TempArray5.CopyAssign(value);
			}
		}

		// Token: 0x1700518D RID: 20877
		// (get) Token: 0x0602568D RID: 153229 RVA: 0x009B8C94 File Offset: 0x009B6E94
		// (set) Token: 0x0602568E RID: 153230 RVA: 0x009B8CCD File Offset: 0x009B6ECD
		public TArray<FName> TempArray6
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray6) == null)
				{
					result = (this._TempArray6 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_247, this));
				}
				return result;
			}
			set
			{
				this.TempArray6.CopyAssign(value);
			}
		}

		// Token: 0x1700518E RID: 20878
		// (get) Token: 0x0602568F RID: 153231 RVA: 0x009B8CDC File Offset: 0x009B6EDC
		// (set) Token: 0x06025690 RID: 153232 RVA: 0x009B8D15 File Offset: 0x009B6F15
		public TArray<FName> TempArray7
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray7) == null)
				{
					result = (this._TempArray7 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_248, this));
				}
				return result;
			}
			set
			{
				this.TempArray7.CopyAssign(value);
			}
		}

		// Token: 0x1700518F RID: 20879
		// (get) Token: 0x06025691 RID: 153233 RVA: 0x009B8D24 File Offset: 0x009B6F24
		// (set) Token: 0x06025692 RID: 153234 RVA: 0x009B8D5D File Offset: 0x009B6F5D
		public TArray<FName> TempArray8
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray8) == null)
				{
					result = (this._TempArray8 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_249, this));
				}
				return result;
			}
			set
			{
				this.TempArray8.CopyAssign(value);
			}
		}

		// Token: 0x17005190 RID: 20880
		// (get) Token: 0x06025693 RID: 153235 RVA: 0x009B8D6C File Offset: 0x009B6F6C
		// (set) Token: 0x06025694 RID: 153236 RVA: 0x009B8DA5 File Offset: 0x009B6FA5
		public TArray<FName> TempArray9
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray9) == null)
				{
					result = (this._TempArray9 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_250, this));
				}
				return result;
			}
			set
			{
				this.TempArray9.CopyAssign(value);
			}
		}

		// Token: 0x17005191 RID: 20881
		// (get) Token: 0x06025695 RID: 153237 RVA: 0x009B8DB4 File Offset: 0x009B6FB4
		// (set) Token: 0x06025696 RID: 153238 RVA: 0x009B8DED File Offset: 0x009B6FED
		public TArray<FName> TempArray10
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray10) == null)
				{
					result = (this._TempArray10 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_251, this));
				}
				return result;
			}
			set
			{
				this.TempArray10.CopyAssign(value);
			}
		}

		// Token: 0x17005192 RID: 20882
		// (get) Token: 0x06025697 RID: 153239 RVA: 0x009B8DFC File Offset: 0x009B6FFC
		// (set) Token: 0x06025698 RID: 153240 RVA: 0x009B8E35 File Offset: 0x009B7035
		public TArray<FName> TempArray11
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray11) == null)
				{
					result = (this._TempArray11 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_252, this));
				}
				return result;
			}
			set
			{
				this.TempArray11.CopyAssign(value);
			}
		}

		// Token: 0x17005193 RID: 20883
		// (get) Token: 0x06025699 RID: 153241 RVA: 0x009B8E44 File Offset: 0x009B7044
		// (set) Token: 0x0602569A RID: 153242 RVA: 0x009B8E7D File Offset: 0x009B707D
		public TArray<FName> TempArray12
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray12) == null)
				{
					result = (this._TempArray12 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_253, this));
				}
				return result;
			}
			set
			{
				this.TempArray12.CopyAssign(value);
			}
		}

		// Token: 0x17005194 RID: 20884
		// (get) Token: 0x0602569B RID: 153243 RVA: 0x009B8E8C File Offset: 0x009B708C
		// (set) Token: 0x0602569C RID: 153244 RVA: 0x009B8EC5 File Offset: 0x009B70C5
		public TArray<FName> TempArray13
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray13) == null)
				{
					result = (this._TempArray13 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_254, this));
				}
				return result;
			}
			set
			{
				this.TempArray13.CopyAssign(value);
			}
		}

		// Token: 0x17005195 RID: 20885
		// (get) Token: 0x0602569D RID: 153245 RVA: 0x009B8ED4 File Offset: 0x009B70D4
		// (set) Token: 0x0602569E RID: 153246 RVA: 0x009B8F0D File Offset: 0x009B710D
		public TArray<FName> TempArray14
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray14) == null)
				{
					result = (this._TempArray14 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_255, this));
				}
				return result;
			}
			set
			{
				this.TempArray14.CopyAssign(value);
			}
		}

		// Token: 0x17005196 RID: 20886
		// (get) Token: 0x0602569F RID: 153247 RVA: 0x009B8F1C File Offset: 0x009B711C
		// (set) Token: 0x060256A0 RID: 153248 RVA: 0x009B8F55 File Offset: 0x009B7155
		public TArray<FName> TempArray15
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray15) == null)
				{
					result = (this._TempArray15 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_256, this));
				}
				return result;
			}
			set
			{
				this.TempArray15.CopyAssign(value);
			}
		}

		// Token: 0x17005197 RID: 20887
		// (get) Token: 0x060256A1 RID: 153249 RVA: 0x009B8F64 File Offset: 0x009B7164
		// (set) Token: 0x060256A2 RID: 153250 RVA: 0x009B8F9D File Offset: 0x009B719D
		public TArray<FName> TempArray16
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray16) == null)
				{
					result = (this._TempArray16 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_257, this));
				}
				return result;
			}
			set
			{
				this.TempArray16.CopyAssign(value);
			}
		}

		// Token: 0x17005198 RID: 20888
		// (get) Token: 0x060256A3 RID: 153251 RVA: 0x009B8FAC File Offset: 0x009B71AC
		// (set) Token: 0x060256A4 RID: 153252 RVA: 0x009B8FE5 File Offset: 0x009B71E5
		public TArray<FName> TempArray17
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray17) == null)
				{
					result = (this._TempArray17 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_258, this));
				}
				return result;
			}
			set
			{
				this.TempArray17.CopyAssign(value);
			}
		}

		// Token: 0x17005199 RID: 20889
		// (get) Token: 0x060256A5 RID: 153253 RVA: 0x009B8FF4 File Offset: 0x009B71F4
		// (set) Token: 0x060256A6 RID: 153254 RVA: 0x009B902D File Offset: 0x009B722D
		public TArray<FName> TempArray18
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray18) == null)
				{
					result = (this._TempArray18 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_259, this));
				}
				return result;
			}
			set
			{
				this.TempArray18.CopyAssign(value);
			}
		}

		// Token: 0x1700519A RID: 20890
		// (get) Token: 0x060256A7 RID: 153255 RVA: 0x009B903C File Offset: 0x009B723C
		// (set) Token: 0x060256A8 RID: 153256 RVA: 0x009B9075 File Offset: 0x009B7275
		public TArray<FName> TempArray19
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray19) == null)
				{
					result = (this._TempArray19 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_260, this));
				}
				return result;
			}
			set
			{
				this.TempArray19.CopyAssign(value);
			}
		}

		// Token: 0x1700519B RID: 20891
		// (get) Token: 0x060256A9 RID: 153257 RVA: 0x009B9084 File Offset: 0x009B7284
		// (set) Token: 0x060256AA RID: 153258 RVA: 0x009B90BD File Offset: 0x009B72BD
		public TArray<FName> TempArray20
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray20) == null)
				{
					result = (this._TempArray20 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_261, this));
				}
				return result;
			}
			set
			{
				this.TempArray20.CopyAssign(value);
			}
		}

		// Token: 0x1700519C RID: 20892
		// (get) Token: 0x060256AB RID: 153259 RVA: 0x009B90CB File Offset: 0x009B72CB
		// (set) Token: 0x060256AC RID: 153260 RVA: 0x009B90DB File Offset: 0x009B72DB
		public unsafe bool UseCustomTraceSource
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_262) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_262) = (value ? 1 : 0);
			}
		}

		// Token: 0x1700519D RID: 20893
		// (get) Token: 0x060256AD RID: 153261 RVA: 0x009B90EC File Offset: 0x009B72EC
		// (set) Token: 0x060256AE RID: 153262 RVA: 0x009B9100 File Offset: 0x009B7300
		public unsafe FVector CustomTraceSourcePosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_263);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_263) = value;
			}
		}

		// Token: 0x1700519E RID: 20894
		// (get) Token: 0x060256AF RID: 153263 RVA: 0x009B9118 File Offset: 0x009B7318
		// (set) Token: 0x060256B0 RID: 153264 RVA: 0x009B9151 File Offset: 0x009B7351
		public TArray<FName> TempArray21
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray21) == null)
				{
					result = (this._TempArray21 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_264, this));
				}
				return result;
			}
			set
			{
				this.TempArray21.CopyAssign(value);
			}
		}

		// Token: 0x1700519F RID: 20895
		// (get) Token: 0x060256B1 RID: 153265 RVA: 0x009B9160 File Offset: 0x009B7360
		// (set) Token: 0x060256B2 RID: 153266 RVA: 0x009B9199 File Offset: 0x009B7399
		public TArray<FName> TempArray22
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray22) == null)
				{
					result = (this._TempArray22 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_265, this));
				}
				return result;
			}
			set
			{
				this.TempArray22.CopyAssign(value);
			}
		}

		// Token: 0x170051A0 RID: 20896
		// (get) Token: 0x060256B3 RID: 153267 RVA: 0x009B91A8 File Offset: 0x009B73A8
		// (set) Token: 0x060256B4 RID: 153268 RVA: 0x009B91E1 File Offset: 0x009B73E1
		public TArray<FName> TempArray23
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray23) == null)
				{
					result = (this._TempArray23 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_266, this));
				}
				return result;
			}
			set
			{
				this.TempArray23.CopyAssign(value);
			}
		}

		// Token: 0x170051A1 RID: 20897
		// (get) Token: 0x060256B5 RID: 153269 RVA: 0x009B91F0 File Offset: 0x009B73F0
		// (set) Token: 0x060256B6 RID: 153270 RVA: 0x009B9229 File Offset: 0x009B7429
		public TArray<FName> TempArray24
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray24) == null)
				{
					result = (this._TempArray24 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_267, this));
				}
				return result;
			}
			set
			{
				this.TempArray24.CopyAssign(value);
			}
		}

		// Token: 0x170051A2 RID: 20898
		// (get) Token: 0x060256B7 RID: 153271 RVA: 0x009B9238 File Offset: 0x009B7438
		// (set) Token: 0x060256B8 RID: 153272 RVA: 0x009B9271 File Offset: 0x009B7471
		public TArray<FName> TempArray25
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray25) == null)
				{
					result = (this._TempArray25 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_268, this));
				}
				return result;
			}
			set
			{
				this.TempArray25.CopyAssign(value);
			}
		}

		// Token: 0x170051A3 RID: 20899
		// (get) Token: 0x060256B9 RID: 153273 RVA: 0x009B9280 File Offset: 0x009B7480
		// (set) Token: 0x060256BA RID: 153274 RVA: 0x009B92B9 File Offset: 0x009B74B9
		public TArray<FName> TempArray26
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray26) == null)
				{
					result = (this._TempArray26 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_269, this));
				}
				return result;
			}
			set
			{
				this.TempArray26.CopyAssign(value);
			}
		}

		// Token: 0x170051A4 RID: 20900
		// (get) Token: 0x060256BB RID: 153275 RVA: 0x009B92C8 File Offset: 0x009B74C8
		// (set) Token: 0x060256BC RID: 153276 RVA: 0x009B9301 File Offset: 0x009B7501
		public TArray<FName> TempArray27
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray27) == null)
				{
					result = (this._TempArray27 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_270, this));
				}
				return result;
			}
			set
			{
				this.TempArray27.CopyAssign(value);
			}
		}

		// Token: 0x170051A5 RID: 20901
		// (get) Token: 0x060256BD RID: 153277 RVA: 0x009B9310 File Offset: 0x009B7510
		// (set) Token: 0x060256BE RID: 153278 RVA: 0x009B9349 File Offset: 0x009B7549
		public TArray<FName> TempArray28
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray28) == null)
				{
					result = (this._TempArray28 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_271, this));
				}
				return result;
			}
			set
			{
				this.TempArray28.CopyAssign(value);
			}
		}

		// Token: 0x170051A6 RID: 20902
		// (get) Token: 0x060256BF RID: 153279 RVA: 0x009B9358 File Offset: 0x009B7558
		// (set) Token: 0x060256C0 RID: 153280 RVA: 0x009B9391 File Offset: 0x009B7591
		public TArray<FName> TempArray29
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray29) == null)
				{
					result = (this._TempArray29 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_272, this));
				}
				return result;
			}
			set
			{
				this.TempArray29.CopyAssign(value);
			}
		}

		// Token: 0x170051A7 RID: 20903
		// (get) Token: 0x060256C1 RID: 153281 RVA: 0x009B93A0 File Offset: 0x009B75A0
		// (set) Token: 0x060256C2 RID: 153282 RVA: 0x009B93D9 File Offset: 0x009B75D9
		public TArray<FName> TempArray30
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray30) == null)
				{
					result = (this._TempArray30 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_273, this));
				}
				return result;
			}
			set
			{
				this.TempArray30.CopyAssign(value);
			}
		}

		// Token: 0x170051A8 RID: 20904
		// (get) Token: 0x060256C3 RID: 153283 RVA: 0x009B93E8 File Offset: 0x009B75E8
		// (set) Token: 0x060256C4 RID: 153284 RVA: 0x009B9421 File Offset: 0x009B7621
		public TArray<FName> TempArray31
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray31) == null)
				{
					result = (this._TempArray31 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_274, this));
				}
				return result;
			}
			set
			{
				this.TempArray31.CopyAssign(value);
			}
		}

		// Token: 0x170051A9 RID: 20905
		// (get) Token: 0x060256C5 RID: 153285 RVA: 0x009B9430 File Offset: 0x009B7630
		// (set) Token: 0x060256C6 RID: 153286 RVA: 0x009B9469 File Offset: 0x009B7669
		public TArray<FName> TempArray32
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray32) == null)
				{
					result = (this._TempArray32 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_275, this));
				}
				return result;
			}
			set
			{
				this.TempArray32.CopyAssign(value);
			}
		}

		// Token: 0x170051AA RID: 20906
		// (get) Token: 0x060256C7 RID: 153287 RVA: 0x009B9478 File Offset: 0x009B7678
		// (set) Token: 0x060256C8 RID: 153288 RVA: 0x009B94B1 File Offset: 0x009B76B1
		public TArray<FName> TempArray33
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray33) == null)
				{
					result = (this._TempArray33 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_276, this));
				}
				return result;
			}
			set
			{
				this.TempArray33.CopyAssign(value);
			}
		}

		// Token: 0x170051AB RID: 20907
		// (get) Token: 0x060256C9 RID: 153289 RVA: 0x009B94C0 File Offset: 0x009B76C0
		// (set) Token: 0x060256CA RID: 153290 RVA: 0x009B94F9 File Offset: 0x009B76F9
		public TArray<FName> TempArray34
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray34) == null)
				{
					result = (this._TempArray34 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_277, this));
				}
				return result;
			}
			set
			{
				this.TempArray34.CopyAssign(value);
			}
		}

		// Token: 0x170051AC RID: 20908
		// (get) Token: 0x060256CB RID: 153291 RVA: 0x009B9508 File Offset: 0x009B7708
		// (set) Token: 0x060256CC RID: 153292 RVA: 0x009B9541 File Offset: 0x009B7741
		public TArray<FName> TempArray35
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray35) == null)
				{
					result = (this._TempArray35 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_278, this));
				}
				return result;
			}
			set
			{
				this.TempArray35.CopyAssign(value);
			}
		}

		// Token: 0x170051AD RID: 20909
		// (get) Token: 0x060256CD RID: 153293 RVA: 0x009B9550 File Offset: 0x009B7750
		// (set) Token: 0x060256CE RID: 153294 RVA: 0x009B9589 File Offset: 0x009B7789
		public TArray<FName> TempArray36
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray36) == null)
				{
					result = (this._TempArray36 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_279, this));
				}
				return result;
			}
			set
			{
				this.TempArray36.CopyAssign(value);
			}
		}

		// Token: 0x170051AE RID: 20910
		// (get) Token: 0x060256CF RID: 153295 RVA: 0x009B9598 File Offset: 0x009B7798
		// (set) Token: 0x060256D0 RID: 153296 RVA: 0x009B95D1 File Offset: 0x009B77D1
		public TArray<FName> TempArray37
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray37) == null)
				{
					result = (this._TempArray37 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_280, this));
				}
				return result;
			}
			set
			{
				this.TempArray37.CopyAssign(value);
			}
		}

		// Token: 0x170051AF RID: 20911
		// (get) Token: 0x060256D1 RID: 153297 RVA: 0x009B95E0 File Offset: 0x009B77E0
		// (set) Token: 0x060256D2 RID: 153298 RVA: 0x009B9619 File Offset: 0x009B7819
		public TArray<FName> TempArray38
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray38) == null)
				{
					result = (this._TempArray38 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_281, this));
				}
				return result;
			}
			set
			{
				this.TempArray38.CopyAssign(value);
			}
		}

		// Token: 0x170051B0 RID: 20912
		// (get) Token: 0x060256D3 RID: 153299 RVA: 0x009B9628 File Offset: 0x009B7828
		// (set) Token: 0x060256D4 RID: 153300 RVA: 0x009B9661 File Offset: 0x009B7861
		public TArray<FName> TempArray39
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FName> result;
				if ((result = this._TempArray39) == null)
				{
					result = (this._TempArray39 = new TArray<FName>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_282, this));
				}
				return result;
			}
			set
			{
				this.TempArray39.CopyAssign(value);
			}
		}

		// Token: 0x170051B1 RID: 20913
		// (get) Token: 0x060256D5 RID: 153301 RVA: 0x009B966F File Offset: 0x009B786F
		// (set) Token: 0x060256D6 RID: 153302 RVA: 0x009B967F File Offset: 0x009B787F
		public unsafe float DampenBrushBelowThisVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_283);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_283) = value;
			}
		}

		// Token: 0x170051B2 RID: 20914
		// (get) Token: 0x060256D7 RID: 153303 RVA: 0x009B9690 File Offset: 0x009B7890
		// (set) Token: 0x060256D8 RID: 153304 RVA: 0x009B96A0 File Offset: 0x009B78A0
		public unsafe bool DampenIgnoresStaticMeshes
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_284) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_284) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051B3 RID: 20915
		// (get) Token: 0x060256D9 RID: 153305 RVA: 0x009B96B1 File Offset: 0x009B78B1
		// (set) Token: 0x060256DA RID: 153306 RVA: 0x009B96C1 File Offset: 0x009B78C1
		public unsafe float DampenBrushFactor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_285);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_285) = value;
			}
		}

		// Token: 0x170051B4 RID: 20916
		// (get) Token: 0x060256DB RID: 153307 RVA: 0x009B96D2 File Offset: 0x009B78D2
		// (set) Token: 0x060256DC RID: 153308 RVA: 0x009B96E2 File Offset: 0x009B78E2
		public unsafe float BrushVelocityPow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_286);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_286) = value;
			}
		}

		// Token: 0x170051B5 RID: 20917
		// (get) Token: 0x060256DD RID: 153309 RVA: 0x009B96F3 File Offset: 0x009B78F3
		// (set) Token: 0x060256DE RID: 153310 RVA: 0x009B9703 File Offset: 0x009B7903
		public unsafe float SimAreaMotionEffectsBrushPuncture
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_287);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_287) = value;
			}
		}

		// Token: 0x170051B6 RID: 20918
		// (get) Token: 0x060256DF RID: 153311 RVA: 0x009B9714 File Offset: 0x009B7914
		// (set) Token: 0x060256E0 RID: 153312 RVA: 0x009B9724 File Offset: 0x009B7924
		public unsafe int LODlevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_288);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_288) = value;
			}
		}

		// Token: 0x170051B7 RID: 20919
		// (get) Token: 0x060256E1 RID: 153313 RVA: 0x009B9735 File Offset: 0x009B7935
		// (set) Token: 0x060256E2 RID: 153314 RVA: 0x009B9745 File Offset: 0x009B7945
		public unsafe bool AllowAbsoluteBlackDensity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_289) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_289) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051B8 RID: 20920
		// (get) Token: 0x060256E3 RID: 153315 RVA: 0x009B9756 File Offset: 0x009B7956
		// (set) Token: 0x060256E4 RID: 153316 RVA: 0x009B976A File Offset: 0x009B796A
		public unsafe FVector TraceMeshPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_290);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_290) = value;
			}
		}

		// Token: 0x170051B9 RID: 20921
		// (get) Token: 0x060256E5 RID: 153317 RVA: 0x009B977F File Offset: 0x009B797F
		// (set) Token: 0x060256E6 RID: 153318 RVA: 0x009B9793 File Offset: 0x009B7993
		public unsafe FVector TraceMeshLastPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_291);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_291) = value;
			}
		}

		// Token: 0x170051BA RID: 20922
		// (get) Token: 0x060256E7 RID: 153319 RVA: 0x009B97A8 File Offset: 0x009B79A8
		// (set) Token: 0x060256E8 RID: 153320 RVA: 0x009B97B8 File Offset: 0x009B79B8
		public unsafe float PressureEdgeMasking
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_292);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_292) = value;
			}
		}

		// Token: 0x170051BB RID: 20923
		// (get) Token: 0x060256E9 RID: 153321 RVA: 0x009B97CC File Offset: 0x009B79CC
		// (set) Token: 0x060256EA RID: 153322 RVA: 0x009B9805 File Offset: 0x009B7A05
		public TArray<UMaterialInterface> CoreSimMaterials
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UMaterialInterface> result;
				if ((result = this._CoreSimMaterials) == null)
				{
					result = (this._CoreSimMaterials = new TArray<UMaterialInterface>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_293, this));
				}
				return result;
			}
			set
			{
				this.CoreSimMaterials.CopyAssign(value);
			}
		}

		// Token: 0x170051BC RID: 20924
		// (get) Token: 0x060256EB RID: 153323 RVA: 0x009B9813 File Offset: 0x009B7A13
		// (set) Token: 0x060256EC RID: 153324 RVA: 0x009B9827 File Offset: 0x009B7A27
		public unsafe FVector TraceMeshDeltaPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_294);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_294) = value;
			}
		}

		// Token: 0x170051BD RID: 20925
		// (get) Token: 0x060256ED RID: 153325 RVA: 0x009B983C File Offset: 0x009B7A3C
		// (set) Token: 0x060256EE RID: 153326 RVA: 0x009B9850 File Offset: 0x009B7A50
		public unsafe FVector NullVector
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_295);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_295) = value;
			}
		}

		// Token: 0x170051BE RID: 20926
		// (get) Token: 0x060256EF RID: 153327 RVA: 0x009B9865 File Offset: 0x009B7A65
		// (set) Token: 0x060256F0 RID: 153328 RVA: 0x009B9879 File Offset: 0x009B7A79
		public unsafe FVector TraceMeshPosInitialLocal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_296);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_296) = value;
			}
		}

		// Token: 0x170051BF RID: 20927
		// (get) Token: 0x060256F1 RID: 153329 RVA: 0x009B988E File Offset: 0x009B7A8E
		// (set) Token: 0x060256F2 RID: 153330 RVA: 0x009B98A2 File Offset: 0x009B7AA2
		public unsafe FVector TraceMeshPosInitialFractionalPart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_297);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_297) = value;
			}
		}

		// Token: 0x170051C0 RID: 20928
		// (get) Token: 0x060256F3 RID: 153331 RVA: 0x009B98B7 File Offset: 0x009B7AB7
		// (set) Token: 0x060256F4 RID: 153332 RVA: 0x009B98CB File Offset: 0x009B7ACB
		public unsafe FVector TraceMeshPosInitialWorld
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_298);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_298) = value;
			}
		}

		// Token: 0x170051C1 RID: 20929
		// (get) Token: 0x060256F5 RID: 153333 RVA: 0x009B98E0 File Offset: 0x009B7AE0
		// (set) Token: 0x060256F6 RID: 153334 RVA: 0x009B98F0 File Offset: 0x009B7AF0
		public unsafe int QuantizerStepSize
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_299);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_299) = value;
			}
		}

		// Token: 0x170051C2 RID: 20930
		// (get) Token: 0x060256F7 RID: 153335 RVA: 0x009B9901 File Offset: 0x009B7B01
		// (set) Token: 0x060256F8 RID: 153336 RVA: 0x009B9915 File Offset: 0x009B7B15
		public unsafe FVector TraceMeshParentPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_300);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_300) = value;
			}
		}

		// Token: 0x170051C3 RID: 20931
		// (get) Token: 0x060256F9 RID: 153337 RVA: 0x009B992A File Offset: 0x009B7B2A
		// (set) Token: 0x060256FA RID: 153338 RVA: 0x009B993E File Offset: 0x009B7B3E
		public unsafe FVector TraceMeshParentLastPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_301);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_301) = value;
			}
		}

		// Token: 0x170051C4 RID: 20932
		// (get) Token: 0x060256FB RID: 153339 RVA: 0x009B9953 File Offset: 0x009B7B53
		// (set) Token: 0x060256FC RID: 153340 RVA: 0x009B9967 File Offset: 0x009B7B67
		[Nullable(0)]
		public unsafe TEnumAsByte<QuantizerMode> TraceMeshMovingInWorldSpace
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_302);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_302) = value;
			}
		}

		// Token: 0x170051C5 RID: 20933
		// (get) Token: 0x060256FD RID: 153341 RVA: 0x009B997C File Offset: 0x009B7B7C
		// (set) Token: 0x060256FE RID: 153342 RVA: 0x009B9990 File Offset: 0x009B7B90
		[Nullable(0)]
		public unsafe TEnumAsByte<QuantizerAxisIgnore> MovementNotQuantizedToStepsOnAxis
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_303);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_303) = value;
			}
		}

		// Token: 0x170051C6 RID: 20934
		// (get) Token: 0x060256FF RID: 153343 RVA: 0x009B99A5 File Offset: 0x009B7BA5
		// (set) Token: 0x06025700 RID: 153344 RVA: 0x009B99B5 File Offset: 0x009B7BB5
		public unsafe bool SecondaryMaterialsPresent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_304) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_304) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051C7 RID: 20935
		// (get) Token: 0x06025701 RID: 153345 RVA: 0x009B99C6 File Offset: 0x009B7BC6
		// (set) Token: 0x06025702 RID: 153346 RVA: 0x009B99DA File Offset: 0x009B7BDA
		[Nullable(0)]
		public unsafe TEnumAsByte<QuantizerAxisIgnore> MovementIsLockedOnThisAxis
		{
			[NullableContext(0)]
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_305);
			}
			[NullableContext(0)]
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_305) = value;
			}
		}

		// Token: 0x170051C8 RID: 20936
		// (get) Token: 0x06025703 RID: 153347 RVA: 0x009B99EF File Offset: 0x009B7BEF
		// (set) Token: 0x06025704 RID: 153348 RVA: 0x009B99FF File Offset: 0x009B7BFF
		public unsafe bool ForceTraceMeshToCustomVerticalPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_306) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_306) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051C9 RID: 20937
		// (get) Token: 0x06025705 RID: 153349 RVA: 0x009B9A10 File Offset: 0x009B7C10
		// (set) Token: 0x06025706 RID: 153350 RVA: 0x009B9A20 File Offset: 0x009B7C20
		public unsafe float ForceTraceMeshVerticalPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_307);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_307) = value;
			}
		}

		// Token: 0x170051CA RID: 20938
		// (get) Token: 0x06025707 RID: 153351 RVA: 0x009B9A31 File Offset: 0x009B7C31
		// (set) Token: 0x06025708 RID: 153352 RVA: 0x009B9A41 File Offset: 0x009B7C41
		public unsafe bool EnablePaintBufferOffsetInWorldSpace
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_308) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_308) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051CB RID: 20939
		// (get) Token: 0x06025709 RID: 153353 RVA: 0x009B9A52 File Offset: 0x009B7C52
		// (set) Token: 0x0602570A RID: 153354 RVA: 0x009B9A62 File Offset: 0x009B7C62
		public unsafe bool SimplePainterMode
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_309) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_309) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051CC RID: 20940
		// (get) Token: 0x0602570B RID: 153355 RVA: 0x009B9A73 File Offset: 0x009B7C73
		// (set) Token: 0x0602570C RID: 153356 RVA: 0x009B9A87 File Offset: 0x009B7C87
		[Nullable(2)]
		public unsafe UBoxComponent InteractionVolume
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UBoxComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_310);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_310, value);
			}
		}

		// Token: 0x170051CD RID: 20941
		// (get) Token: 0x0602570D RID: 153357 RVA: 0x009B9A9C File Offset: 0x009B7C9C
		// (set) Token: 0x0602570E RID: 153358 RVA: 0x009B9AAC File Offset: 0x009B7CAC
		public unsafe bool NiagaraSystemsPresent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_311) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_311) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051CE RID: 20942
		// (get) Token: 0x0602570F RID: 153359 RVA: 0x009B9AC0 File Offset: 0x009B7CC0
		// (set) Token: 0x06025710 RID: 153360 RVA: 0x009B9AF9 File Offset: 0x009B7CF9
		public TArray<UNiagaraComponent> NiagaraSystemsToDrive
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UNiagaraComponent> result;
				if ((result = this._NiagaraSystemsToDrive) == null)
				{
					result = (this._NiagaraSystemsToDrive = new TArray<UNiagaraComponent>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_312, this));
				}
				return result;
			}
			set
			{
				this.NiagaraSystemsToDrive.CopyAssign(value);
			}
		}

		// Token: 0x170051CF RID: 20943
		// (get) Token: 0x06025711 RID: 153361 RVA: 0x009B9B07 File Offset: 0x009B7D07
		// (set) Token: 0x06025712 RID: 153362 RVA: 0x009B9B17 File Offset: 0x009B7D17
		public unsafe float Exp_PressureFeedbackComponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_313);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_313) = value;
			}
		}

		// Token: 0x170051D0 RID: 20944
		// (get) Token: 0x06025713 RID: 153363 RVA: 0x009B9B28 File Offset: 0x009B7D28
		// (set) Token: 0x06025714 RID: 153364 RVA: 0x009B9B38 File Offset: 0x009B7D38
		public unsafe float Exp_DivergenceFeedbackComponent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_314);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_314) = value;
			}
		}

		// Token: 0x170051D1 RID: 20945
		// (get) Token: 0x06025715 RID: 153365 RVA: 0x009B9B49 File Offset: 0x009B7D49
		// (set) Token: 0x06025716 RID: 153366 RVA: 0x009B9B59 File Offset: 0x009B7D59
		public unsafe bool Force8bitSimplePainterBuffers
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_315) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_315) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051D2 RID: 20946
		// (get) Token: 0x06025717 RID: 153367 RVA: 0x009B9B6A File Offset: 0x009B7D6A
		// (set) Token: 0x06025718 RID: 153368 RVA: 0x009B9B7A File Offset: 0x009B7D7A
		public unsafe bool Force8bitOutputBuffer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_316) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_316) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051D3 RID: 20947
		// (get) Token: 0x06025719 RID: 153369 RVA: 0x009B9B8B File Offset: 0x009B7D8B
		// (set) Token: 0x0602571A RID: 153370 RVA: 0x009B9B9F File Offset: 0x009B7D9F
		[Nullable(2)]
		public unsafe UPrimitiveComponent SingleTarget
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrimitiveComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_317);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_317, value);
			}
		}

		// Token: 0x170051D4 RID: 20948
		// (get) Token: 0x0602571B RID: 153371 RVA: 0x009B9BB4 File Offset: 0x009B7DB4
		// (set) Token: 0x0602571C RID: 153372 RVA: 0x009B9BC4 File Offset: 0x009B7DC4
		public unsafe bool UE5EAFLAG
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_318) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_318) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051D5 RID: 20949
		// (get) Token: 0x0602571D RID: 153373 RVA: 0x009B9BD5 File Offset: 0x009B7DD5
		// (set) Token: 0x0602571E RID: 153374 RVA: 0x009B9BE5 File Offset: 0x009B7DE5
		public unsafe bool Force2xResolutionOutputBuffer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_319) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_319) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051D6 RID: 20950
		// (get) Token: 0x0602571F RID: 153375 RVA: 0x009B9BF6 File Offset: 0x009B7DF6
		// (set) Token: 0x06025720 RID: 153376 RVA: 0x009B9C06 File Offset: 0x009B7E06
		public unsafe bool ForceMaxSamplingFPS_ToNiagara
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_320) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_320) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051D7 RID: 20951
		// (get) Token: 0x06025721 RID: 153377 RVA: 0x009B9C17 File Offset: 0x009B7E17
		// (set) Token: 0x06025722 RID: 153378 RVA: 0x009B9C27 File Offset: 0x009B7E27
		public unsafe bool MaterialCollectionPresent
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_321) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_321) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051D8 RID: 20952
		// (get) Token: 0x06025723 RID: 153379 RVA: 0x009B9C38 File Offset: 0x009B7E38
		// (set) Token: 0x06025724 RID: 153380 RVA: 0x009B9C71 File Offset: 0x009B7E71
		public WorldSpaceOffset WorldSpaceOffset
		{
			get
			{
				base.FastCheckIsValid();
				WorldSpaceOffset result;
				if ((result = this._WorldSpaceOffset) == null)
				{
					result = (this._WorldSpaceOffset = new WorldSpaceOffset(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_322, this));
				}
				return result;
			}
			set
			{
				FMulticastScriptDelegate.NativeCopy(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_322, (value != null) ? value.NativePtr : ((IntPtr)0));
			}
		}

		// Token: 0x170051D9 RID: 20953
		// (get) Token: 0x06025725 RID: 153381 RVA: 0x009B9C92 File Offset: 0x009B7E92
		// (set) Token: 0x06025726 RID: 153382 RVA: 0x009B9CA2 File Offset: 0x009B7EA2
		public unsafe bool BrushPosityBySwimChangeSkeletalPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_323) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_323) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051DA RID: 20954
		// (get) Token: 0x06025727 RID: 153383 RVA: 0x009B9CB3 File Offset: 0x009B7EB3
		// (set) Token: 0x06025728 RID: 153384 RVA: 0x009B9CC7 File Offset: 0x009B7EC7
		[Nullable(2)]
		public unsafe UPrimitiveComponent boundTraceMesh
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UPrimitiveComponent>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_324);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_324, value);
			}
		}

		// Token: 0x170051DB RID: 20955
		// (get) Token: 0x06025729 RID: 153385 RVA: 0x009B9CDC File Offset: 0x009B7EDC
		// (set) Token: 0x0602572A RID: 153386 RVA: 0x009B9CF0 File Offset: 0x009B7EF0
		public unsafe FLinearColor tmpHitUV
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_325);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_325) = value;
			}
		}

		// Token: 0x170051DC RID: 20956
		// (get) Token: 0x0602572B RID: 153387 RVA: 0x009B9D05 File Offset: 0x009B7F05
		// (set) Token: 0x0602572C RID: 153388 RVA: 0x009B9D19 File Offset: 0x009B7F19
		public unsafe FVector tmpPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_326);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_326) = value;
			}
		}

		// Token: 0x170051DD RID: 20957
		// (get) Token: 0x0602572D RID: 153389 RVA: 0x009B9D2E File Offset: 0x009B7F2E
		// (set) Token: 0x0602572E RID: 153390 RVA: 0x009B9D3E File Offset: 0x009B7F3E
		public unsafe bool BatchRenderPoints
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_327) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_327) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051DE RID: 20958
		// (get) Token: 0x0602572F RID: 153391 RVA: 0x009B9D4F File Offset: 0x009B7F4F
		// (set) Token: 0x06025730 RID: 153392 RVA: 0x009B9D5F File Offset: 0x009B7F5F
		public unsafe int Object_Processor_Index
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_328);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_328) = value;
			}
		}

		// Token: 0x170051DF RID: 20959
		// (get) Token: 0x06025731 RID: 153393 RVA: 0x009B9D70 File Offset: 0x009B7F70
		// (set) Token: 0x06025732 RID: 153394 RVA: 0x009B9D84 File Offset: 0x009B7F84
		public unsafe FVector CameraLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_329);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_329) = value;
			}
		}

		// Token: 0x170051E0 RID: 20960
		// (get) Token: 0x06025733 RID: 153395 RVA: 0x009B9D99 File Offset: 0x009B7F99
		// (set) Token: 0x06025734 RID: 153396 RVA: 0x009B9DAD File Offset: 0x009B7FAD
		[Nullable(2)]
		public unsafe PD_NinjaSimCache_C SimCacheDA
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<PD_NinjaSimCache_C>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_330);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_330, value);
			}
		}

		// Token: 0x170051E1 RID: 20961
		// (get) Token: 0x06025735 RID: 153397 RVA: 0x009B9DC2 File Offset: 0x009B7FC2
		// (set) Token: 0x06025736 RID: 153398 RVA: 0x009B9DD6 File Offset: 0x009B7FD6
		[Nullable(2)]
		public unsafe UMaterialInstanceDynamic CopyMDI
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UMaterialInstanceDynamic>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_331);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_331, value);
			}
		}

		// Token: 0x170051E2 RID: 20962
		// (get) Token: 0x06025737 RID: 153399 RVA: 0x009B9DEB File Offset: 0x009B7FEB
		// (set) Token: 0x06025738 RID: 153400 RVA: 0x009B9DFB File Offset: 0x009B7FFB
		public unsafe bool bCached
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_332) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_332) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051E3 RID: 20963
		// (get) Token: 0x06025739 RID: 153401 RVA: 0x009B9E0C File Offset: 0x009B800C
		// (set) Token: 0x0602573A RID: 153402 RVA: 0x009B9E20 File Offset: 0x009B8020
		[Nullable(2)]
		public unsafe UTextureRenderTarget2D OverwriteDensityRT
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UTextureRenderTarget2D>(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_333);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + NinjaLiveComponent_C.__PropertyOffset_333, value);
			}
		}

		// Token: 0x170051E4 RID: 20964
		// (get) Token: 0x0602573B RID: 153403 RVA: 0x009B9E35 File Offset: 0x009B8035
		// (set) Token: 0x0602573C RID: 153404 RVA: 0x009B9E45 File Offset: 0x009B8045
		public unsafe int NowQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_334);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_334) = value;
			}
		}

		// Token: 0x170051E5 RID: 20965
		// (get) Token: 0x0602573D RID: 153405 RVA: 0x009B9E56 File Offset: 0x009B8056
		// (set) Token: 0x0602573E RID: 153406 RVA: 0x009B9E66 File Offset: 0x009B8066
		public unsafe bool bQualitySwitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_335) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_335) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051E6 RID: 20966
		// (get) Token: 0x0602573F RID: 153407 RVA: 0x009B9E77 File Offset: 0x009B8077
		// (set) Token: 0x06025740 RID: 153408 RVA: 0x009B9E87 File Offset: 0x009B8087
		public unsafe bool bBoundEventOnQuality
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_336) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_336) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051E7 RID: 20967
		// (get) Token: 0x06025741 RID: 153409 RVA: 0x009B9E98 File Offset: 0x009B8098
		// (set) Token: 0x06025742 RID: 153410 RVA: 0x009B9EAC File Offset: 0x009B80AC
		public unsafe FRotator TraceMeshRotation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_337);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_337) = value;
			}
		}

		// Token: 0x170051E8 RID: 20968
		// (get) Token: 0x06025743 RID: 153411 RVA: 0x009B9EC1 File Offset: 0x009B80C1
		// (set) Token: 0x06025744 RID: 153412 RVA: 0x009B9ED5 File Offset: 0x009B80D5
		public unsafe FVector TraceMeshScale
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_338);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_338) = value;
			}
		}

		// Token: 0x170051E9 RID: 20969
		// (get) Token: 0x06025745 RID: 153413 RVA: 0x009B9EEA File Offset: 0x009B80EA
		// (set) Token: 0x06025746 RID: 153414 RVA: 0x009B9EFE File Offset: 0x009B80FE
		public unsafe FVectorDouble TraceMeshLocation
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_339);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_339) = value;
			}
		}

		// Token: 0x170051EA RID: 20970
		// (get) Token: 0x06025747 RID: 153415 RVA: 0x009B9F13 File Offset: 0x009B8113
		// (set) Token: 0x06025748 RID: 153416 RVA: 0x009B9F23 File Offset: 0x009B8123
		public unsafe int RequiredQualityLevel
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_340);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_340) = value;
			}
		}

		// Token: 0x170051EB RID: 20971
		// (get) Token: 0x06025749 RID: 153417 RVA: 0x009B9F34 File Offset: 0x009B8134
		// (set) Token: 0x0602574A RID: 153418 RVA: 0x009B9F48 File Offset: 0x009B8148
		public unsafe FVector tmpCachedOffset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_341);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_341) = value;
			}
		}

		// Token: 0x170051EC RID: 20972
		// (get) Token: 0x0602574B RID: 153419 RVA: 0x009B9F5D File Offset: 0x009B815D
		// (set) Token: 0x0602574C RID: 153420 RVA: 0x009B9F6D File Offset: 0x009B816D
		public unsafe float tmpCachedOffsetX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_342);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_342) = value;
			}
		}

		// Token: 0x170051ED RID: 20973
		// (get) Token: 0x0602574D RID: 153421 RVA: 0x009B9F7E File Offset: 0x009B817E
		// (set) Token: 0x0602574E RID: 153422 RVA: 0x009B9F8E File Offset: 0x009B818E
		public unsafe float tmpCachedOffsetY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_343);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_343) = value;
			}
		}

		// Token: 0x170051EE RID: 20974
		// (get) Token: 0x0602574F RID: 153423 RVA: 0x009B9F9F File Offset: 0x009B819F
		// (set) Token: 0x06025750 RID: 153424 RVA: 0x009B9FAF File Offset: 0x009B81AF
		public unsafe float tmpCachedOffsetZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_344);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_344) = value;
			}
		}

		// Token: 0x170051EF RID: 20975
		// (get) Token: 0x06025751 RID: 153425 RVA: 0x009B9FC0 File Offset: 0x009B81C0
		// (set) Token: 0x06025752 RID: 153426 RVA: 0x009B9FD0 File Offset: 0x009B81D0
		public unsafe bool bNoMovement
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_345) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_345) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051F0 RID: 20976
		// (get) Token: 0x06025753 RID: 153427 RVA: 0x009B9FE1 File Offset: 0x009B81E1
		// (set) Token: 0x06025754 RID: 153428 RVA: 0x009B9FF1 File Offset: 0x009B81F1
		public unsafe bool bUseWeaponInteraction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_346) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_346) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051F1 RID: 20977
		// (get) Token: 0x06025755 RID: 153429 RVA: 0x009BA004 File Offset: 0x009B8204
		// (set) Token: 0x06025756 RID: 153430 RVA: 0x009BA03D File Offset: 0x009B823D
		public TMap<string, FVector> boneCachePos
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FVector> result;
				if ((result = this._boneCachePos) == null)
				{
					result = (this._boneCachePos = new TMap<string, FVector>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_347, this));
				}
				return result;
			}
			set
			{
				this.boneCachePos.CopyAssign(value);
			}
		}

		// Token: 0x170051F2 RID: 20978
		// (get) Token: 0x06025757 RID: 153431 RVA: 0x009BA04C File Offset: 0x009B824C
		// (set) Token: 0x06025758 RID: 153432 RVA: 0x009BA085 File Offset: 0x009B8285
		public TMap<string, FVector> boneVelocity
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, FVector> result;
				if ((result = this._boneVelocity) == null)
				{
					result = (this._boneVelocity = new TMap<string, FVector>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_348, this));
				}
				return result;
			}
			set
			{
				this.boneVelocity.CopyAssign(value);
			}
		}

		// Token: 0x170051F3 RID: 20979
		// (get) Token: 0x06025759 RID: 153433 RVA: 0x009BA093 File Offset: 0x009B8293
		// (set) Token: 0x0602575A RID: 153434 RVA: 0x009BA0A7 File Offset: 0x009B82A7
		public unsafe FVector tempBoneVelocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_349);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_349) = value;
			}
		}

		// Token: 0x170051F4 RID: 20980
		// (get) Token: 0x0602575B RID: 153435 RVA: 0x009BA0BC File Offset: 0x009B82BC
		// (set) Token: 0x0602575C RID: 153436 RVA: 0x009BA0CC File Offset: 0x009B82CC
		public unsafe bool bCalcVeloctiyWithoutPhysic
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_350) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_350) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051F5 RID: 20981
		// (get) Token: 0x0602575D RID: 153437 RVA: 0x009BA0DD File Offset: 0x009B82DD
		// (set) Token: 0x0602575E RID: 153438 RVA: 0x009BA0ED File Offset: 0x009B82ED
		public unsafe float CalcvelocityMulti
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_351);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_351) = value;
			}
		}

		// Token: 0x170051F6 RID: 20982
		// (get) Token: 0x0602575F RID: 153439 RVA: 0x009BA100 File Offset: 0x009B8300
		// (set) Token: 0x06025760 RID: 153440 RVA: 0x009BA139 File Offset: 0x009B8339
		public TMap<UPrimitiveComponent, FLinearColor> primitiveCachePos2D
		{
			get
			{
				base.FastCheckIsValid();
				TMap<UPrimitiveComponent, FLinearColor> result;
				if ((result = this._primitiveCachePos2D) == null)
				{
					result = (this._primitiveCachePos2D = new TMap<UPrimitiveComponent, FLinearColor>(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_352, this));
				}
				return result;
			}
			set
			{
				this.primitiveCachePos2D.CopyAssign(value);
			}
		}

		// Token: 0x170051F7 RID: 20983
		// (get) Token: 0x06025761 RID: 153441 RVA: 0x009BA147 File Offset: 0x009B8347
		// (set) Token: 0x06025762 RID: 153442 RVA: 0x009BA157 File Offset: 0x009B8357
		public unsafe bool bUseLinePaint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_353) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_353) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051F8 RID: 20984
		// (get) Token: 0x06025763 RID: 153443 RVA: 0x009BA168 File Offset: 0x009B8368
		// (set) Token: 0x06025764 RID: 153444 RVA: 0x009BA178 File Offset: 0x009B8378
		public unsafe bool bCommonFluid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_354) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_354) = (value ? 1 : 0);
			}
		}

		// Token: 0x170051F9 RID: 20985
		// (get) Token: 0x06025765 RID: 153445 RVA: 0x009BA189 File Offset: 0x009B8389
		// (set) Token: 0x06025766 RID: 153446 RVA: 0x009BA19D File Offset: 0x009B839D
		public unsafe FVector singleSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_355);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_355) = value;
			}
		}

		// Token: 0x170051FA RID: 20986
		// (get) Token: 0x06025767 RID: 153447 RVA: 0x009BA1B2 File Offset: 0x009B83B2
		// (set) Token: 0x06025768 RID: 153448 RVA: 0x009BA1C6 File Offset: 0x009B83C6
		public unsafe FVectorDouble lastSingelPosition
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_356);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NinjaLiveComponent_C.__PropertyOffset_356) = value;
			}
		}

		// Token: 0x06025769 RID: 153449 RVA: 0x009BA1DC File Offset: 0x009B83DC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SetLinePaintEnable(bool enable)
		{
			NinjaLiveComponent_C.__SetLinePaintEnable_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__SetLinePaintEnable_FunctionParams[(UIntPtr)23] + 15L / (long)sizeof(NinjaLiveComponent_C.__SetLinePaintEnable_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__SetLinePaintEnable_NativeFunctionPtr, (void*)ptr, 1);
			ptr->enable = enable;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__SetLinePaintEnable_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602576A RID: 153450 RVA: 0x009BA224 File Offset: 0x009B8424
		[NullableContext(2)]
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual FVector CalcBoneVelocity(UObject Skeletal)
		{
			NinjaLiveComponent_C.__CalcBoneVelocity_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__CalcBoneVelocity_FunctionParams[(UIntPtr)239] + 15L / (long)sizeof(NinjaLiveComponent_C.__CalcBoneVelocity_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__CalcBoneVelocity_NativeFunctionPtr, (void*)ptr, 1);
			ptr->Skeletal = ((Skeletal != null) ? Skeletal.NativePtr : IntPtr.Zero);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__CalcBoneVelocity_NativeFunctionPtr, (void*)ptr);
			return ptr->__Result;
		}

		// Token: 0x0602576B RID: 153451 RVA: 0x009BA282 File Offset: 0x009B8482
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void ApplySimCache()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__ApplySimCache_NativeFunctionPtr, null);
		}

		// Token: 0x0602576C RID: 153452 RVA: 0x009BA296 File Offset: 0x009B8496
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void 从表格读取覆盖贴图()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__从表格读取覆盖贴图_NativeFunctionPtr, null);
		}

		// Token: 0x0602576D RID: 153453 RVA: 0x009BA2AC File Offset: 0x009B84AC
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveTick(float DeltaSeconds)
		{
			NinjaLiveComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x0602576E RID: 153454 RVA: 0x009BA2F4 File Offset: 0x009B84F4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveTick_Implementation(float DeltaSeconds)
		{
			NinjaLiveComponent_C.__ReceiveTick_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__ReceiveTick_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveComponent_C.__ReceiveTick_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 1);
			ptr->DeltaSeconds = DeltaSeconds;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveComponent_C.__ReceiveTick_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602576F RID: 153455 RVA: 0x009BA33B File Offset: 0x009B853B
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void RePlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__RePlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025770 RID: 153456 RVA: 0x009BA350 File Offset: 0x009B8550
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LiveActivation(FName ParamName, float FadeTimeOfBrush, float FadeTimeOfCanvas)
		{
			NinjaLiveComponent_C.__LiveActivation_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__LiveActivation_FunctionParams[(UIntPtr)35] + 15L / (long)sizeof(NinjaLiveComponent_C.__LiveActivation_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__LiveActivation_NativeFunctionPtr, (void*)ptr, 1);
			ptr->ParamName = ParamName;
			ptr->FadeTimeOfBrush = FadeTimeOfBrush;
			ptr->FadeTimeOfCanvas = FadeTimeOfCanvas;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__LiveActivation_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025771 RID: 153457 RVA: 0x009BA3A4 File Offset: 0x009B85A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void LiveFluidParams(float BrushSize)
		{
			NinjaLiveComponent_C.__LiveFluidParams_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__LiveFluidParams_FunctionParams[(UIntPtr)19] + 15L / (long)sizeof(NinjaLiveComponent_C.__LiveFluidParams_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__LiveFluidParams_NativeFunctionPtr, (void*)ptr, 1);
			ptr->BrushSize = BrushSize;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__LiveFluidParams_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025772 RID: 153458 RVA: 0x009BA3EA File Offset: 0x009B85EA
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public override void ReceiveBeginPlay()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null);
		}

		// Token: 0x06025773 RID: 153459 RVA: 0x009BA3FE File Offset: 0x009B85FE
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected virtual void ReceiveBeginPlay_Implementation()
		{
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveComponent_C.__ReceiveBeginPlay_NativeFunctionPtr, null, 0);
		}

		// Token: 0x06025774 RID: 153460 RVA: 0x009BA413 File Offset: 0x009B8613
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void Shutdown()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__Shutdown_NativeFunctionPtr, null);
		}

		// Token: 0x06025775 RID: 153461 RVA: 0x009BA427 File Offset: 0x009B8627
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public virtual void UpdateQualitySwitch()
		{
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__UpdateQualitySwitch_NativeFunctionPtr, null);
		}

		// Token: 0x06025776 RID: 153462 RVA: 0x009BA43C File Offset: 0x009B863C
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe override void ReceiveEndPlay(EEndPlayReason EndPlayReason)
		{
			NinjaLiveComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLiveComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr);
		}

		// Token: 0x06025777 RID: 153463 RVA: 0x009BA488 File Offset: 0x009B8688
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		protected unsafe virtual void ReceiveEndPlay_Implementation(EEndPlayReason EndPlayReason)
		{
			NinjaLiveComponent_C.__ReceiveEndPlay_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__ReceiveEndPlay_FunctionParams[(UIntPtr)16] + 15L / (long)sizeof(NinjaLiveComponent_C.__ReceiveEndPlay_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EndPlayReason = EndPlayReason;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveComponent_C.__ReceiveEndPlay_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x06025778 RID: 153464 RVA: 0x009BA4D4 File Offset: 0x009B86D4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void SelChanged(string SelectedMenuItem, string SelectedActorName)
		{
			NinjaLiveComponent_C.__SelChanged_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__SelChanged_FunctionParams[(UIntPtr)47] + 15L / (long)sizeof(NinjaLiveComponent_C.__SelChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__SelChanged_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedMenuItem), SelectedMenuItem);
			FString.CopyFrom((void*)(&ptr->SelectedActorName), SelectedActorName);
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__SelChanged_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveComponent_C.__SelChanged_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x06025779 RID: 153465 RVA: 0x009BA540 File Offset: 0x009B8740
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PresetSelectionChanged(string SelectedPreset, bool ForceAutoLoadPreset)
		{
			NinjaLiveComponent_C.__PresetSelectionChanged_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__PresetSelectionChanged_FunctionParams[(UIntPtr)39] + 15L / (long)sizeof(NinjaLiveComponent_C.__PresetSelectionChanged_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__PresetSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedPreset), SelectedPreset);
			ptr->ForceAutoLoadPreset = ForceAutoLoadPreset;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__PresetSelectionChanged_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveComponent_C.__PresetSelectionChanged_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602577A RID: 153466 RVA: 0x009BA5A4 File Offset: 0x009B87A4
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe virtual void PresetSave(string SelectedProject, string SelectedPreset, bool OverWriteOrNot)
		{
			NinjaLiveComponent_C.__PresetSave_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__PresetSave_FunctionParams[(UIntPtr)55] + 15L / (long)sizeof(NinjaLiveComponent_C.__PresetSave_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__PresetSave_NativeFunctionPtr, (void*)ptr, 1);
			FString.CopyFrom((void*)(&ptr->SelectedProject), SelectedProject);
			FString.CopyFrom((void*)(&ptr->SelectedPreset), SelectedPreset);
			ptr->OverWriteOrNot = OverWriteOrNot;
			UnrealReflectionUtils.CallVirtualUFunction(base.NativePtr, NinjaLiveComponent_C.__PresetSave_NativeFunctionPtr, (void*)ptr);
			UnrealReflectionUtils.DestroyStruct(NinjaLiveComponent_C.__PresetSave_NativeFunctionPtr, (void*)ptr, 1);
		}

		// Token: 0x0602577B RID: 153467 RVA: 0x009BA618 File Offset: 0x009B8818
		[SkipLocalsInit]
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		public unsafe void ExecuteUbergraph_NinjaLiveComponent(int EntryPoint)
		{
			NinjaLiveComponent_C.__ExecuteUbergraph_NinjaLiveComponent_FunctionParams* ptr = stackalloc NinjaLiveComponent_C.__ExecuteUbergraph_NinjaLiveComponent_FunctionParams[(UIntPtr)18351] + 15L / (long)sizeof(NinjaLiveComponent_C.__ExecuteUbergraph_NinjaLiveComponent_FunctionParams) & -16L;
			UnrealReflectionUtils.InitializeStruct(NinjaLiveComponent_C.__ExecuteUbergraph_NinjaLiveComponent_NativeFunctionPtr, (void*)ptr, 1);
			ptr->EntryPoint = EntryPoint;
			UnrealReflectionUtils.CallUFunction(base.NativePtr, NinjaLiveComponent_C.__ExecuteUbergraph_NinjaLiveComponent_NativeFunctionPtr, (void*)ptr, 0);
		}

		// Token: 0x0602577C RID: 153468 RVA: 0x009BA662 File Offset: 0x009B8862
		protected NinjaLiveComponent_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013352 RID: 78674
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/FluidNinjaLive/NinjaLiveComponent.NinjaLiveComponent_C";

		// Token: 0x04013353 RID: 78675
		private static IntPtr _ClassPtr;

		// Token: 0x04013354 RID: 78676
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013355 RID: 78677
		public static IntPtr __WorldSpaceOffset__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013356 RID: 78678
		public static IntPtr __ComponentShutdownEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013357 RID: 78679
		public static IntPtr __ComponentBroadcastMemConsumption__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013358 RID: 78680
		public static IntPtr __ComponentRePlayEvent__DelegateSignature_NativeFunctionPtr;

		// Token: 0x04013359 RID: 78681
		internal static int __PropertyOffset_0;

		// Token: 0x0401335A RID: 78682
		[Nullable(2)]
		private FPointerToUberGraphFrame _UberGraphFrame;

		// Token: 0x0401335B RID: 78683
		internal static int __PropertyOffset_1;

		// Token: 0x0401335C RID: 78684
		internal static int __PropertyOffset_2;

		// Token: 0x0401335D RID: 78685
		internal static int __PropertyOffset_3;

		// Token: 0x0401335E RID: 78686
		internal static int __PropertyOffset_4;

		// Token: 0x0401335F RID: 78687
		internal static int __PropertyOffset_5;

		// Token: 0x04013360 RID: 78688
		internal static int __PropertyOffset_6;

		// Token: 0x04013361 RID: 78689
		internal static int __PropertyOffset_7;

		// Token: 0x04013362 RID: 78690
		internal static int __PropertyOffset_8;

		// Token: 0x04013363 RID: 78691
		internal static int __PropertyOffset_9;

		// Token: 0x04013364 RID: 78692
		internal static int __PropertyOffset_10;

		// Token: 0x04013365 RID: 78693
		internal static int __PropertyOffset_11;

		// Token: 0x04013366 RID: 78694
		internal static int __PropertyOffset_12;

		// Token: 0x04013367 RID: 78695
		internal static int __PropertyOffset_13;

		// Token: 0x04013368 RID: 78696
		internal static int __PropertyOffset_14;

		// Token: 0x04013369 RID: 78697
		internal static int __PropertyOffset_15;

		// Token: 0x0401336A RID: 78698
		internal static int __PropertyOffset_16;

		// Token: 0x0401336B RID: 78699
		internal static int __PropertyOffset_17;

		// Token: 0x0401336C RID: 78700
		internal static int __PropertyOffset_18;

		// Token: 0x0401336D RID: 78701
		internal static int __PropertyOffset_19;

		// Token: 0x0401336E RID: 78702
		internal static int __PropertyOffset_20;

		// Token: 0x0401336F RID: 78703
		internal static int __PropertyOffset_21;

		// Token: 0x04013370 RID: 78704
		internal static int __PropertyOffset_22;

		// Token: 0x04013371 RID: 78705
		internal static int __PropertyOffset_23;

		// Token: 0x04013372 RID: 78706
		internal static int __PropertyOffset_24;

		// Token: 0x04013373 RID: 78707
		internal static int __PropertyOffset_25;

		// Token: 0x04013374 RID: 78708
		internal static int __PropertyOffset_26;

		// Token: 0x04013375 RID: 78709
		internal static int __PropertyOffset_27;

		// Token: 0x04013376 RID: 78710
		internal static int __PropertyOffset_28;

		// Token: 0x04013377 RID: 78711
		internal static int __PropertyOffset_29;

		// Token: 0x04013378 RID: 78712
		internal static int __PropertyOffset_30;

		// Token: 0x04013379 RID: 78713
		internal static int __PropertyOffset_31;

		// Token: 0x0401337A RID: 78714
		internal static int __PropertyOffset_32;

		// Token: 0x0401337B RID: 78715
		internal static int __PropertyOffset_33;

		// Token: 0x0401337C RID: 78716
		internal static int __PropertyOffset_34;

		// Token: 0x0401337D RID: 78717
		internal static int __PropertyOffset_35;

		// Token: 0x0401337E RID: 78718
		internal static int __PropertyOffset_36;

		// Token: 0x0401337F RID: 78719
		internal static int __PropertyOffset_37;

		// Token: 0x04013380 RID: 78720
		internal static int __PropertyOffset_38;

		// Token: 0x04013381 RID: 78721
		internal static int __PropertyOffset_39;

		// Token: 0x04013382 RID: 78722
		internal static int __PropertyOffset_40;

		// Token: 0x04013383 RID: 78723
		internal static int __PropertyOffset_41;

		// Token: 0x04013384 RID: 78724
		internal static int __PropertyOffset_42;

		// Token: 0x04013385 RID: 78725
		internal static int __PropertyOffset_43;

		// Token: 0x04013386 RID: 78726
		[Nullable(2)]
		private TArray<float> _LOD_StepsArray;

		// Token: 0x04013387 RID: 78727
		internal static int __PropertyOffset_44;

		// Token: 0x04013388 RID: 78728
		internal static int __PropertyOffset_45;

		// Token: 0x04013389 RID: 78729
		internal static int __PropertyOffset_46;

		// Token: 0x0401338A RID: 78730
		internal static int __PropertyOffset_47;

		// Token: 0x0401338B RID: 78731
		internal static int __PropertyOffset_48;

		// Token: 0x0401338C RID: 78732
		[Nullable(2)]
		private ComponentRePlayEvent _ComponentRePlayEvent;

		// Token: 0x0401338D RID: 78733
		internal static int __PropertyOffset_49;

		// Token: 0x0401338E RID: 78734
		[Nullable(2)]
		private ComponentBroadcastMemConsumption _ComponentBroadcastMemConsumption;

		// Token: 0x0401338F RID: 78735
		internal static int __PropertyOffset_50;

		// Token: 0x04013390 RID: 78736
		internal static int __PropertyOffset_51;

		// Token: 0x04013391 RID: 78737
		internal static int __PropertyOffset_52;

		// Token: 0x04013392 RID: 78738
		internal static int __PropertyOffset_53;

		// Token: 0x04013393 RID: 78739
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, float> _PresetMap;

		// Token: 0x04013394 RID: 78740
		internal static int __PropertyOffset_54;

		// Token: 0x04013395 RID: 78741
		internal static int __PropertyOffset_55;

		// Token: 0x04013396 RID: 78742
		internal static int __PropertyOffset_56;

		// Token: 0x04013397 RID: 78743
		[Nullable(2)]
		private TArray<FName> _PresetSearchPaths;

		// Token: 0x04013398 RID: 78744
		internal static int __PropertyOffset_57;

		// Token: 0x04013399 RID: 78745
		internal static int __PropertyOffset_58;

		// Token: 0x0401339A RID: 78746
		internal static int __PropertyOffset_59;

		// Token: 0x0401339B RID: 78747
		internal static int __PropertyOffset_60;

		// Token: 0x0401339C RID: 78748
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _OutputMaterials;

		// Token: 0x0401339D RID: 78749
		internal static int __PropertyOffset_61;

		// Token: 0x0401339E RID: 78750
		internal static int __PropertyOffset_62;

		// Token: 0x0401339F RID: 78751
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _RenderTargetsList;

		// Token: 0x040133A0 RID: 78752
		internal static int __PropertyOffset_63;

		// Token: 0x040133A1 RID: 78753
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, UTextureRenderTarget2D> _RenderTargetsMap;

		// Token: 0x040133A2 RID: 78754
		internal static int __PropertyOffset_64;

		// Token: 0x040133A3 RID: 78755
		internal static int __PropertyOffset_65;

		// Token: 0x040133A4 RID: 78756
		internal static int __PropertyOffset_66;

		// Token: 0x040133A5 RID: 78757
		internal static int __PropertyOffset_67;

		// Token: 0x040133A6 RID: 78758
		internal static int __PropertyOffset_68;

		// Token: 0x040133A7 RID: 78759
		internal static int __PropertyOffset_69;

		// Token: 0x040133A8 RID: 78760
		internal static int __PropertyOffset_70;

		// Token: 0x040133A9 RID: 78761
		internal static int __PropertyOffset_71;

		// Token: 0x040133AA RID: 78762
		internal static int __PropertyOffset_72;

		// Token: 0x040133AB RID: 78763
		internal static int __PropertyOffset_73;

		// Token: 0x040133AC RID: 78764
		internal static int __PropertyOffset_74;

		// Token: 0x040133AD RID: 78765
		internal static int __PropertyOffset_75;

		// Token: 0x040133AE RID: 78766
		internal static int __PropertyOffset_76;

		// Token: 0x040133AF RID: 78767
		internal static int __PropertyOffset_77;

		// Token: 0x040133B0 RID: 78768
		internal static int __PropertyOffset_78;

		// Token: 0x040133B1 RID: 78769
		internal static int __PropertyOffset_79;

		// Token: 0x040133B2 RID: 78770
		internal static int __PropertyOffset_80;

		// Token: 0x040133B3 RID: 78771
		internal static int __PropertyOffset_81;

		// Token: 0x040133B4 RID: 78772
		internal static int __PropertyOffset_82;

		// Token: 0x040133B5 RID: 78773
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _SecondaryOutputMaterials;

		// Token: 0x040133B6 RID: 78774
		internal static int __PropertyOffset_83;

		// Token: 0x040133B7 RID: 78775
		internal static int __PropertyOffset_84;

		// Token: 0x040133B8 RID: 78776
		internal static int __PropertyOffset_85;

		// Token: 0x040133B9 RID: 78777
		internal static int __PropertyOffset_86;

		// Token: 0x040133BA RID: 78778
		internal static int __PropertyOffset_87;

		// Token: 0x040133BB RID: 78779
		internal static int __PropertyOffset_88;

		// Token: 0x040133BC RID: 78780
		internal static int __PropertyOffset_89;

		// Token: 0x040133BD RID: 78781
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _InputMaterials;

		// Token: 0x040133BE RID: 78782
		internal static int __PropertyOffset_90;

		// Token: 0x040133BF RID: 78783
		internal static int __PropertyOffset_91;

		// Token: 0x040133C0 RID: 78784
		internal static int __PropertyOffset_92;

		// Token: 0x040133C1 RID: 78785
		internal static int __PropertyOffset_93;

		// Token: 0x040133C2 RID: 78786
		internal static int __PropertyOffset_94;

		// Token: 0x040133C3 RID: 78787
		internal static int __PropertyOffset_95;

		// Token: 0x040133C4 RID: 78788
		internal static int __PropertyOffset_96;

		// Token: 0x040133C5 RID: 78789
		internal static int __PropertyOffset_97;

		// Token: 0x040133C6 RID: 78790
		internal static int __PropertyOffset_98;

		// Token: 0x040133C7 RID: 78791
		internal static int __PropertyOffset_99;

		// Token: 0x040133C8 RID: 78792
		internal static int __PropertyOffset_100;

		// Token: 0x040133C9 RID: 78793
		internal static int __PropertyOffset_101;

		// Token: 0x040133CA RID: 78794
		internal static int __PropertyOffset_102;

		// Token: 0x040133CB RID: 78795
		internal static int __PropertyOffset_103;

		// Token: 0x040133CC RID: 78796
		internal static int __PropertyOffset_104;

		// Token: 0x040133CD RID: 78797
		internal static int __PropertyOffset_105;

		// Token: 0x040133CE RID: 78798
		internal static int __PropertyOffset_106;

		// Token: 0x040133CF RID: 78799
		internal static int __PropertyOffset_107;

		// Token: 0x040133D0 RID: 78800
		internal static int __PropertyOffset_108;

		// Token: 0x040133D1 RID: 78801
		internal static int __PropertyOffset_109;

		// Token: 0x040133D2 RID: 78802
		internal static int __PropertyOffset_110;

		// Token: 0x040133D3 RID: 78803
		internal static int __PropertyOffset_111;

		// Token: 0x040133D4 RID: 78804
		internal static int __PropertyOffset_112;

		// Token: 0x040133D5 RID: 78805
		internal static int __PropertyOffset_113;

		// Token: 0x040133D6 RID: 78806
		internal static int __PropertyOffset_114;

		// Token: 0x040133D7 RID: 78807
		internal static int __PropertyOffset_115;

		// Token: 0x040133D8 RID: 78808
		internal static int __PropertyOffset_116;

		// Token: 0x040133D9 RID: 78809
		internal static int __PropertyOffset_117;

		// Token: 0x040133DA RID: 78810
		internal static int __PropertyOffset_118;

		// Token: 0x040133DB RID: 78811
		internal static int __PropertyOffset_119;

		// Token: 0x040133DC RID: 78812
		internal static int __PropertyOffset_120;

		// Token: 0x040133DD RID: 78813
		internal static int __PropertyOffset_121;

		// Token: 0x040133DE RID: 78814
		internal static int __PropertyOffset_122;

		// Token: 0x040133DF RID: 78815
		internal static int __PropertyOffset_123;

		// Token: 0x040133E0 RID: 78816
		internal static int __PropertyOffset_124;

		// Token: 0x040133E1 RID: 78817
		internal static int __PropertyOffset_125;

		// Token: 0x040133E2 RID: 78818
		internal static int __PropertyOffset_126;

		// Token: 0x040133E3 RID: 78819
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, UPrimitiveComponent> _SkeletalMesh_TempArray_Pairs;

		// Token: 0x040133E4 RID: 78820
		internal static int __PropertyOffset_127;

		// Token: 0x040133E5 RID: 78821
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UPrimitiveComponent> _OverlappingComponents;

		// Token: 0x040133E6 RID: 78822
		internal static int __PropertyOffset_128;

		// Token: 0x040133E7 RID: 78823
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<USkeletalMeshComponent> _ContinuousInteractionSkeletalComponent;

		// Token: 0x040133E8 RID: 78824
		internal static int __PropertyOffset_129;

		// Token: 0x040133E9 RID: 78825
		[Nullable(2)]
		private TArray<bool> _ListOfAvailableTempArrays;

		// Token: 0x040133EA RID: 78826
		internal static int __PropertyOffset_130;

		// Token: 0x040133EB RID: 78827
		internal static int __PropertyOffset_131;

		// Token: 0x040133EC RID: 78828
		internal static int __PropertyOffset_132;

		// Token: 0x040133ED RID: 78829
		internal static int __PropertyOffset_133;

		// Token: 0x040133EE RID: 78830
		internal static int __PropertyOffset_134;

		// Token: 0x040133EF RID: 78831
		internal static int __PropertyOffset_135;

		// Token: 0x040133F0 RID: 78832
		internal static int __PropertyOffset_136;

		// Token: 0x040133F1 RID: 78833
		internal static int __PropertyOffset_137;

		// Token: 0x040133F2 RID: 78834
		internal static int __PropertyOffset_138;

		// Token: 0x040133F3 RID: 78835
		[Nullable(2)]
		private TArray<FLinearColor> _LastPosition3_2D;

		// Token: 0x040133F4 RID: 78836
		internal static int __PropertyOffset_139;

		// Token: 0x040133F5 RID: 78837
		internal static int __PropertyOffset_140;

		// Token: 0x040133F6 RID: 78838
		internal static int __PropertyOffset_141;

		// Token: 0x040133F7 RID: 78839
		internal static int __PropertyOffset_142;

		// Token: 0x040133F8 RID: 78840
		[Nullable(2)]
		private TArray<FLinearColor> _Position3_2D;

		// Token: 0x040133F9 RID: 78841
		internal static int __PropertyOffset_143;

		// Token: 0x040133FA RID: 78842
		internal static int __PropertyOffset_144;

		// Token: 0x040133FB RID: 78843
		internal static int __PropertyOffset_145;

		// Token: 0x040133FC RID: 78844
		internal static int __PropertyOffset_146;

		// Token: 0x040133FD RID: 78845
		internal static int __PropertyOffset_147;

		// Token: 0x040133FE RID: 78846
		internal static int __PropertyOffset_148;

		// Token: 0x040133FF RID: 78847
		internal static int __PropertyOffset_149;

		// Token: 0x04013400 RID: 78848
		internal static int __PropertyOffset_150;

		// Token: 0x04013401 RID: 78849
		internal static int __PropertyOffset_151;

		// Token: 0x04013402 RID: 78850
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<AActor> _NinjaLIVETraceExclude;

		// Token: 0x04013403 RID: 78851
		internal static int __PropertyOffset_152;

		// Token: 0x04013404 RID: 78852
		internal static int __PropertyOffset_153;

		// Token: 0x04013405 RID: 78853
		internal static int __PropertyOffset_154;

		// Token: 0x04013406 RID: 78854
		internal static int __PropertyOffset_155;

		// Token: 0x04013407 RID: 78855
		internal static int __PropertyOffset_156;

		// Token: 0x04013408 RID: 78856
		internal static int __PropertyOffset_157;

		// Token: 0x04013409 RID: 78857
		internal static int __PropertyOffset_158;

		// Token: 0x0401340A RID: 78858
		internal static int __PropertyOffset_159;

		// Token: 0x0401340B RID: 78859
		internal static int __PropertyOffset_160;

		// Token: 0x0401340C RID: 78860
		internal static int __PropertyOffset_161;

		// Token: 0x0401340D RID: 78861
		internal static int __PropertyOffset_162;

		// Token: 0x0401340E RID: 78862
		internal static int __PropertyOffset_163;

		// Token: 0x0401340F RID: 78863
		internal static int __PropertyOffset_164;

		// Token: 0x04013410 RID: 78864
		internal static int __PropertyOffset_165;

		// Token: 0x04013411 RID: 78865
		internal static int __PropertyOffset_166;

		// Token: 0x04013412 RID: 78866
		internal static int __PropertyOffset_167;

		// Token: 0x04013413 RID: 78867
		[Nullable(2)]
		private ComponentShutdownEvent _ComponentShutdownEvent;

		// Token: 0x04013414 RID: 78868
		internal static int __PropertyOffset_168;

		// Token: 0x04013415 RID: 78869
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<EObjectTypeQuery>> _ContinuousInteractionInclusiveObjType;

		// Token: 0x04013416 RID: 78870
		internal static int __PropertyOffset_169;

		// Token: 0x04013417 RID: 78871
		[Nullable(2)]
		private TArray<FName> _ContinuousInteractionComponentNamesExact;

		// Token: 0x04013418 RID: 78872
		internal static int __PropertyOffset_170;

		// Token: 0x04013419 RID: 78873
		[Nullable(2)]
		private TArray<FName> _ContinuousInteractionBoneNamesExact;

		// Token: 0x0401341A RID: 78874
		internal static int __PropertyOffset_171;

		// Token: 0x0401341B RID: 78875
		internal static int __PropertyOffset_172;

		// Token: 0x0401341C RID: 78876
		internal static int __PropertyOffset_173;

		// Token: 0x0401341D RID: 78877
		internal static int __PropertyOffset_174;

		// Token: 0x0401341E RID: 78878
		internal static int __PropertyOffset_175;

		// Token: 0x0401341F RID: 78879
		internal static int __PropertyOffset_176;

		// Token: 0x04013420 RID: 78880
		internal static int __PropertyOffset_177;

		// Token: 0x04013421 RID: 78881
		internal static int __PropertyOffset_178;

		// Token: 0x04013422 RID: 78882
		internal static int __PropertyOffset_179;

		// Token: 0x04013423 RID: 78883
		internal static int __PropertyOffset_180;

		// Token: 0x04013424 RID: 78884
		internal static int __PropertyOffset_181;

		// Token: 0x04013425 RID: 78885
		internal static int __PropertyOffset_182;

		// Token: 0x04013426 RID: 78886
		internal static int __PropertyOffset_183;

		// Token: 0x04013427 RID: 78887
		internal static int __PropertyOffset_184;

		// Token: 0x04013428 RID: 78888
		internal static int __PropertyOffset_185;

		// Token: 0x04013429 RID: 78889
		internal static int __PropertyOffset_186;

		// Token: 0x0401342A RID: 78890
		internal static int __PropertyOffset_187;

		// Token: 0x0401342B RID: 78891
		internal static int __PropertyOffset_188;

		// Token: 0x0401342C RID: 78892
		internal static int __PropertyOffset_189;

		// Token: 0x0401342D RID: 78893
		internal static int __PropertyOffset_190;

		// Token: 0x0401342E RID: 78894
		internal static int __PropertyOffset_191;

		// Token: 0x0401342F RID: 78895
		internal static int __PropertyOffset_192;

		// Token: 0x04013430 RID: 78896
		internal static int __PropertyOffset_193;

		// Token: 0x04013431 RID: 78897
		internal static int __PropertyOffset_194;

		// Token: 0x04013432 RID: 78898
		internal static int __PropertyOffset_195;

		// Token: 0x04013433 RID: 78899
		internal static int __PropertyOffset_196;

		// Token: 0x04013434 RID: 78900
		internal static int __PropertyOffset_197;

		// Token: 0x04013435 RID: 78901
		internal static int __PropertyOffset_198;

		// Token: 0x04013436 RID: 78902
		internal static int __PropertyOffset_199;

		// Token: 0x04013437 RID: 78903
		internal static int __PropertyOffset_200;

		// Token: 0x04013438 RID: 78904
		internal static int __PropertyOffset_201;

		// Token: 0x04013439 RID: 78905
		internal static int __PropertyOffset_202;

		// Token: 0x0401343A RID: 78906
		internal static int __PropertyOffset_203;

		// Token: 0x0401343B RID: 78907
		internal static int __PropertyOffset_204;

		// Token: 0x0401343C RID: 78908
		internal static int __PropertyOffset_205;

		// Token: 0x0401343D RID: 78909
		internal static int __PropertyOffset_206;

		// Token: 0x0401343E RID: 78910
		internal static int __PropertyOffset_207;

		// Token: 0x0401343F RID: 78911
		internal static int __PropertyOffset_208;

		// Token: 0x04013440 RID: 78912
		internal static int __PropertyOffset_209;

		// Token: 0x04013441 RID: 78913
		internal static int __PropertyOffset_210;

		// Token: 0x04013442 RID: 78914
		internal static int __PropertyOffset_211;

		// Token: 0x04013443 RID: 78915
		internal static int __PropertyOffset_212;

		// Token: 0x04013444 RID: 78916
		internal static int __PropertyOffset_213;

		// Token: 0x04013445 RID: 78917
		internal static int __PropertyOffset_214;

		// Token: 0x04013446 RID: 78918
		internal static int __PropertyOffset_215;

		// Token: 0x04013447 RID: 78919
		internal static int __PropertyOffset_216;

		// Token: 0x04013448 RID: 78920
		internal static int __PropertyOffset_217;

		// Token: 0x04013449 RID: 78921
		internal static int __PropertyOffset_218;

		// Token: 0x0401344A RID: 78922
		internal static int __PropertyOffset_219;

		// Token: 0x0401344B RID: 78923
		internal static int __PropertyOffset_220;

		// Token: 0x0401344C RID: 78924
		[Nullable(new byte[]
		{
			2,
			0
		})]
		private TArray<TEnumAsByte<RenderTargetList>> _InternalRenderTargetsToExport;

		// Token: 0x0401344D RID: 78925
		internal static int __PropertyOffset_221;

		// Token: 0x0401344E RID: 78926
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UTextureRenderTarget2D> _ExternalRenderTargets;

		// Token: 0x0401344F RID: 78927
		internal static int __PropertyOffset_222;

		// Token: 0x04013450 RID: 78928
		internal static int __PropertyOffset_223;

		// Token: 0x04013451 RID: 78929
		internal static int __PropertyOffset_224;

		// Token: 0x04013452 RID: 78930
		internal static int __PropertyOffset_225;

		// Token: 0x04013453 RID: 78931
		internal static int __PropertyOffset_226;

		// Token: 0x04013454 RID: 78932
		internal static int __PropertyOffset_227;

		// Token: 0x04013455 RID: 78933
		internal static int __PropertyOffset_228;

		// Token: 0x04013456 RID: 78934
		internal static int __PropertyOffset_229;

		// Token: 0x04013457 RID: 78935
		internal static int __PropertyOffset_230;

		// Token: 0x04013458 RID: 78936
		internal static int __PropertyOffset_231;

		// Token: 0x04013459 RID: 78937
		internal static int __PropertyOffset_232;

		// Token: 0x0401345A RID: 78938
		internal static int __PropertyOffset_233;

		// Token: 0x0401345B RID: 78939
		internal static int __PropertyOffset_234;

		// Token: 0x0401345C RID: 78940
		internal static int __PropertyOffset_235;

		// Token: 0x0401345D RID: 78941
		internal static int __PropertyOffset_236;

		// Token: 0x0401345E RID: 78942
		internal static int __PropertyOffset_237;

		// Token: 0x0401345F RID: 78943
		internal static int __PropertyOffset_238;

		// Token: 0x04013460 RID: 78944
		internal static int __PropertyOffset_239;

		// Token: 0x04013461 RID: 78945
		internal static int __PropertyOffset_240;

		// Token: 0x04013462 RID: 78946
		internal static int __PropertyOffset_241;

		// Token: 0x04013463 RID: 78947
		[Nullable(2)]
		private TArray<FName> _TempArray0;

		// Token: 0x04013464 RID: 78948
		internal static int __PropertyOffset_242;

		// Token: 0x04013465 RID: 78949
		[Nullable(2)]
		private TArray<FName> _TempArray1;

		// Token: 0x04013466 RID: 78950
		internal static int __PropertyOffset_243;

		// Token: 0x04013467 RID: 78951
		[Nullable(2)]
		private TArray<FName> _TempArray2;

		// Token: 0x04013468 RID: 78952
		internal static int __PropertyOffset_244;

		// Token: 0x04013469 RID: 78953
		[Nullable(2)]
		private TArray<FName> _TempArray3;

		// Token: 0x0401346A RID: 78954
		internal static int __PropertyOffset_245;

		// Token: 0x0401346B RID: 78955
		[Nullable(2)]
		private TArray<FName> _TempArray4;

		// Token: 0x0401346C RID: 78956
		internal static int __PropertyOffset_246;

		// Token: 0x0401346D RID: 78957
		[Nullable(2)]
		private TArray<FName> _TempArray5;

		// Token: 0x0401346E RID: 78958
		internal static int __PropertyOffset_247;

		// Token: 0x0401346F RID: 78959
		[Nullable(2)]
		private TArray<FName> _TempArray6;

		// Token: 0x04013470 RID: 78960
		internal static int __PropertyOffset_248;

		// Token: 0x04013471 RID: 78961
		[Nullable(2)]
		private TArray<FName> _TempArray7;

		// Token: 0x04013472 RID: 78962
		internal static int __PropertyOffset_249;

		// Token: 0x04013473 RID: 78963
		[Nullable(2)]
		private TArray<FName> _TempArray8;

		// Token: 0x04013474 RID: 78964
		internal static int __PropertyOffset_250;

		// Token: 0x04013475 RID: 78965
		[Nullable(2)]
		private TArray<FName> _TempArray9;

		// Token: 0x04013476 RID: 78966
		internal static int __PropertyOffset_251;

		// Token: 0x04013477 RID: 78967
		[Nullable(2)]
		private TArray<FName> _TempArray10;

		// Token: 0x04013478 RID: 78968
		internal static int __PropertyOffset_252;

		// Token: 0x04013479 RID: 78969
		[Nullable(2)]
		private TArray<FName> _TempArray11;

		// Token: 0x0401347A RID: 78970
		internal static int __PropertyOffset_253;

		// Token: 0x0401347B RID: 78971
		[Nullable(2)]
		private TArray<FName> _TempArray12;

		// Token: 0x0401347C RID: 78972
		internal static int __PropertyOffset_254;

		// Token: 0x0401347D RID: 78973
		[Nullable(2)]
		private TArray<FName> _TempArray13;

		// Token: 0x0401347E RID: 78974
		internal static int __PropertyOffset_255;

		// Token: 0x0401347F RID: 78975
		[Nullable(2)]
		private TArray<FName> _TempArray14;

		// Token: 0x04013480 RID: 78976
		internal static int __PropertyOffset_256;

		// Token: 0x04013481 RID: 78977
		[Nullable(2)]
		private TArray<FName> _TempArray15;

		// Token: 0x04013482 RID: 78978
		internal static int __PropertyOffset_257;

		// Token: 0x04013483 RID: 78979
		[Nullable(2)]
		private TArray<FName> _TempArray16;

		// Token: 0x04013484 RID: 78980
		internal static int __PropertyOffset_258;

		// Token: 0x04013485 RID: 78981
		[Nullable(2)]
		private TArray<FName> _TempArray17;

		// Token: 0x04013486 RID: 78982
		internal static int __PropertyOffset_259;

		// Token: 0x04013487 RID: 78983
		[Nullable(2)]
		private TArray<FName> _TempArray18;

		// Token: 0x04013488 RID: 78984
		internal static int __PropertyOffset_260;

		// Token: 0x04013489 RID: 78985
		[Nullable(2)]
		private TArray<FName> _TempArray19;

		// Token: 0x0401348A RID: 78986
		internal static int __PropertyOffset_261;

		// Token: 0x0401348B RID: 78987
		[Nullable(2)]
		private TArray<FName> _TempArray20;

		// Token: 0x0401348C RID: 78988
		internal static int __PropertyOffset_262;

		// Token: 0x0401348D RID: 78989
		internal static int __PropertyOffset_263;

		// Token: 0x0401348E RID: 78990
		internal static int __PropertyOffset_264;

		// Token: 0x0401348F RID: 78991
		[Nullable(2)]
		private TArray<FName> _TempArray21;

		// Token: 0x04013490 RID: 78992
		internal static int __PropertyOffset_265;

		// Token: 0x04013491 RID: 78993
		[Nullable(2)]
		private TArray<FName> _TempArray22;

		// Token: 0x04013492 RID: 78994
		internal static int __PropertyOffset_266;

		// Token: 0x04013493 RID: 78995
		[Nullable(2)]
		private TArray<FName> _TempArray23;

		// Token: 0x04013494 RID: 78996
		internal static int __PropertyOffset_267;

		// Token: 0x04013495 RID: 78997
		[Nullable(2)]
		private TArray<FName> _TempArray24;

		// Token: 0x04013496 RID: 78998
		internal static int __PropertyOffset_268;

		// Token: 0x04013497 RID: 78999
		[Nullable(2)]
		private TArray<FName> _TempArray25;

		// Token: 0x04013498 RID: 79000
		internal static int __PropertyOffset_269;

		// Token: 0x04013499 RID: 79001
		[Nullable(2)]
		private TArray<FName> _TempArray26;

		// Token: 0x0401349A RID: 79002
		internal static int __PropertyOffset_270;

		// Token: 0x0401349B RID: 79003
		[Nullable(2)]
		private TArray<FName> _TempArray27;

		// Token: 0x0401349C RID: 79004
		internal static int __PropertyOffset_271;

		// Token: 0x0401349D RID: 79005
		[Nullable(2)]
		private TArray<FName> _TempArray28;

		// Token: 0x0401349E RID: 79006
		internal static int __PropertyOffset_272;

		// Token: 0x0401349F RID: 79007
		[Nullable(2)]
		private TArray<FName> _TempArray29;

		// Token: 0x040134A0 RID: 79008
		internal static int __PropertyOffset_273;

		// Token: 0x040134A1 RID: 79009
		[Nullable(2)]
		private TArray<FName> _TempArray30;

		// Token: 0x040134A2 RID: 79010
		internal static int __PropertyOffset_274;

		// Token: 0x040134A3 RID: 79011
		[Nullable(2)]
		private TArray<FName> _TempArray31;

		// Token: 0x040134A4 RID: 79012
		internal static int __PropertyOffset_275;

		// Token: 0x040134A5 RID: 79013
		[Nullable(2)]
		private TArray<FName> _TempArray32;

		// Token: 0x040134A6 RID: 79014
		internal static int __PropertyOffset_276;

		// Token: 0x040134A7 RID: 79015
		[Nullable(2)]
		private TArray<FName> _TempArray33;

		// Token: 0x040134A8 RID: 79016
		internal static int __PropertyOffset_277;

		// Token: 0x040134A9 RID: 79017
		[Nullable(2)]
		private TArray<FName> _TempArray34;

		// Token: 0x040134AA RID: 79018
		internal static int __PropertyOffset_278;

		// Token: 0x040134AB RID: 79019
		[Nullable(2)]
		private TArray<FName> _TempArray35;

		// Token: 0x040134AC RID: 79020
		internal static int __PropertyOffset_279;

		// Token: 0x040134AD RID: 79021
		[Nullable(2)]
		private TArray<FName> _TempArray36;

		// Token: 0x040134AE RID: 79022
		internal static int __PropertyOffset_280;

		// Token: 0x040134AF RID: 79023
		[Nullable(2)]
		private TArray<FName> _TempArray37;

		// Token: 0x040134B0 RID: 79024
		internal static int __PropertyOffset_281;

		// Token: 0x040134B1 RID: 79025
		[Nullable(2)]
		private TArray<FName> _TempArray38;

		// Token: 0x040134B2 RID: 79026
		internal static int __PropertyOffset_282;

		// Token: 0x040134B3 RID: 79027
		[Nullable(2)]
		private TArray<FName> _TempArray39;

		// Token: 0x040134B4 RID: 79028
		internal static int __PropertyOffset_283;

		// Token: 0x040134B5 RID: 79029
		internal static int __PropertyOffset_284;

		// Token: 0x040134B6 RID: 79030
		internal static int __PropertyOffset_285;

		// Token: 0x040134B7 RID: 79031
		internal static int __PropertyOffset_286;

		// Token: 0x040134B8 RID: 79032
		internal static int __PropertyOffset_287;

		// Token: 0x040134B9 RID: 79033
		internal static int __PropertyOffset_288;

		// Token: 0x040134BA RID: 79034
		internal static int __PropertyOffset_289;

		// Token: 0x040134BB RID: 79035
		internal static int __PropertyOffset_290;

		// Token: 0x040134BC RID: 79036
		internal static int __PropertyOffset_291;

		// Token: 0x040134BD RID: 79037
		internal static int __PropertyOffset_292;

		// Token: 0x040134BE RID: 79038
		internal static int __PropertyOffset_293;

		// Token: 0x040134BF RID: 79039
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UMaterialInterface> _CoreSimMaterials;

		// Token: 0x040134C0 RID: 79040
		internal static int __PropertyOffset_294;

		// Token: 0x040134C1 RID: 79041
		internal static int __PropertyOffset_295;

		// Token: 0x040134C2 RID: 79042
		internal static int __PropertyOffset_296;

		// Token: 0x040134C3 RID: 79043
		internal static int __PropertyOffset_297;

		// Token: 0x040134C4 RID: 79044
		internal static int __PropertyOffset_298;

		// Token: 0x040134C5 RID: 79045
		internal static int __PropertyOffset_299;

		// Token: 0x040134C6 RID: 79046
		internal static int __PropertyOffset_300;

		// Token: 0x040134C7 RID: 79047
		internal static int __PropertyOffset_301;

		// Token: 0x040134C8 RID: 79048
		internal static int __PropertyOffset_302;

		// Token: 0x040134C9 RID: 79049
		internal static int __PropertyOffset_303;

		// Token: 0x040134CA RID: 79050
		internal static int __PropertyOffset_304;

		// Token: 0x040134CB RID: 79051
		internal static int __PropertyOffset_305;

		// Token: 0x040134CC RID: 79052
		internal static int __PropertyOffset_306;

		// Token: 0x040134CD RID: 79053
		internal static int __PropertyOffset_307;

		// Token: 0x040134CE RID: 79054
		internal static int __PropertyOffset_308;

		// Token: 0x040134CF RID: 79055
		internal static int __PropertyOffset_309;

		// Token: 0x040134D0 RID: 79056
		internal static int __PropertyOffset_310;

		// Token: 0x040134D1 RID: 79057
		internal static int __PropertyOffset_311;

		// Token: 0x040134D2 RID: 79058
		internal static int __PropertyOffset_312;

		// Token: 0x040134D3 RID: 79059
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UNiagaraComponent> _NiagaraSystemsToDrive;

		// Token: 0x040134D4 RID: 79060
		internal static int __PropertyOffset_313;

		// Token: 0x040134D5 RID: 79061
		internal static int __PropertyOffset_314;

		// Token: 0x040134D6 RID: 79062
		internal static int __PropertyOffset_315;

		// Token: 0x040134D7 RID: 79063
		internal static int __PropertyOffset_316;

		// Token: 0x040134D8 RID: 79064
		internal static int __PropertyOffset_317;

		// Token: 0x040134D9 RID: 79065
		internal static int __PropertyOffset_318;

		// Token: 0x040134DA RID: 79066
		internal static int __PropertyOffset_319;

		// Token: 0x040134DB RID: 79067
		internal static int __PropertyOffset_320;

		// Token: 0x040134DC RID: 79068
		internal static int __PropertyOffset_321;

		// Token: 0x040134DD RID: 79069
		internal static int __PropertyOffset_322;

		// Token: 0x040134DE RID: 79070
		[Nullable(2)]
		private WorldSpaceOffset _WorldSpaceOffset;

		// Token: 0x040134DF RID: 79071
		internal static int __PropertyOffset_323;

		// Token: 0x040134E0 RID: 79072
		internal static int __PropertyOffset_324;

		// Token: 0x040134E1 RID: 79073
		internal static int __PropertyOffset_325;

		// Token: 0x040134E2 RID: 79074
		internal static int __PropertyOffset_326;

		// Token: 0x040134E3 RID: 79075
		internal static int __PropertyOffset_327;

		// Token: 0x040134E4 RID: 79076
		internal static int __PropertyOffset_328;

		// Token: 0x040134E5 RID: 79077
		internal static int __PropertyOffset_329;

		// Token: 0x040134E6 RID: 79078
		internal static int __PropertyOffset_330;

		// Token: 0x040134E7 RID: 79079
		internal static int __PropertyOffset_331;

		// Token: 0x040134E8 RID: 79080
		internal static int __PropertyOffset_332;

		// Token: 0x040134E9 RID: 79081
		internal static int __PropertyOffset_333;

		// Token: 0x040134EA RID: 79082
		internal static int __PropertyOffset_334;

		// Token: 0x040134EB RID: 79083
		internal static int __PropertyOffset_335;

		// Token: 0x040134EC RID: 79084
		internal static int __PropertyOffset_336;

		// Token: 0x040134ED RID: 79085
		internal static int __PropertyOffset_337;

		// Token: 0x040134EE RID: 79086
		internal static int __PropertyOffset_338;

		// Token: 0x040134EF RID: 79087
		internal static int __PropertyOffset_339;

		// Token: 0x040134F0 RID: 79088
		internal static int __PropertyOffset_340;

		// Token: 0x040134F1 RID: 79089
		internal static int __PropertyOffset_341;

		// Token: 0x040134F2 RID: 79090
		internal static int __PropertyOffset_342;

		// Token: 0x040134F3 RID: 79091
		internal static int __PropertyOffset_343;

		// Token: 0x040134F4 RID: 79092
		internal static int __PropertyOffset_344;

		// Token: 0x040134F5 RID: 79093
		internal static int __PropertyOffset_345;

		// Token: 0x040134F6 RID: 79094
		internal static int __PropertyOffset_346;

		// Token: 0x040134F7 RID: 79095
		internal static int __PropertyOffset_347;

		// Token: 0x040134F8 RID: 79096
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FVector> _boneCachePos;

		// Token: 0x040134F9 RID: 79097
		internal static int __PropertyOffset_348;

		// Token: 0x040134FA RID: 79098
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<string, FVector> _boneVelocity;

		// Token: 0x040134FB RID: 79099
		internal static int __PropertyOffset_349;

		// Token: 0x040134FC RID: 79100
		internal static int __PropertyOffset_350;

		// Token: 0x040134FD RID: 79101
		internal static int __PropertyOffset_351;

		// Token: 0x040134FE RID: 79102
		internal static int __PropertyOffset_352;

		// Token: 0x040134FF RID: 79103
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<UPrimitiveComponent, FLinearColor> _primitiveCachePos2D;

		// Token: 0x04013500 RID: 79104
		internal static int __PropertyOffset_353;

		// Token: 0x04013501 RID: 79105
		internal static int __PropertyOffset_354;

		// Token: 0x04013502 RID: 79106
		internal static int __PropertyOffset_355;

		// Token: 0x04013503 RID: 79107
		internal static int __PropertyOffset_356;

		// Token: 0x04013504 RID: 79108
		private static IntPtr __SetLinePaintEnable_NativeFunctionPtr;

		// Token: 0x04013505 RID: 79109
		private static IntPtr __CalcBoneVelocity_NativeFunctionPtr;

		// Token: 0x04013506 RID: 79110
		private static IntPtr __ApplySimCache_NativeFunctionPtr;

		// Token: 0x04013507 RID: 79111
		private static IntPtr __从表格读取覆盖贴图_NativeFunctionPtr;

		// Token: 0x04013508 RID: 79112
		private static IntPtr __ReceiveTick_NativeFunctionPtr;

		// Token: 0x04013509 RID: 79113
		private static IntPtr __RePlay_NativeFunctionPtr;

		// Token: 0x0401350A RID: 79114
		private static IntPtr __LiveActivation_NativeFunctionPtr;

		// Token: 0x0401350B RID: 79115
		private static IntPtr __LiveFluidParams_NativeFunctionPtr;

		// Token: 0x0401350C RID: 79116
		private static IntPtr __ReceiveBeginPlay_NativeFunctionPtr;

		// Token: 0x0401350D RID: 79117
		private static IntPtr __Shutdown_NativeFunctionPtr;

		// Token: 0x0401350E RID: 79118
		private static IntPtr __UpdateQualitySwitch_NativeFunctionPtr;

		// Token: 0x0401350F RID: 79119
		private static IntPtr __ReceiveEndPlay_NativeFunctionPtr;

		// Token: 0x04013510 RID: 79120
		private static IntPtr __SelChanged_NativeFunctionPtr;

		// Token: 0x04013511 RID: 79121
		private static IntPtr __PresetSelectionChanged_NativeFunctionPtr;

		// Token: 0x04013512 RID: 79122
		private static IntPtr __PresetSave_NativeFunctionPtr;

		// Token: 0x04013513 RID: 79123
		private static IntPtr __ExecuteUbergraph_NinjaLiveComponent_NativeFunctionPtr;

		// Token: 0x02009EF7 RID: 40695
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 8)]
		protected ref struct __SetLinePaintEnable_FunctionParams
		{
			// Token: 0x040329EE RID: 207342
			[FieldOffset(0)]
			public bool enable;
		}

		// Token: 0x02009EF8 RID: 40696
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 224)]
		protected ref struct __CalcBoneVelocity_FunctionParams
		{
			// Token: 0x040329EF RID: 207343
			[FieldOffset(0)]
			public IntPtr Skeletal;

			// Token: 0x040329F0 RID: 207344
			[FieldOffset(8)]
			public FVector __Result;
		}

		// Token: 0x02009EF9 RID: 40697
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected new ref struct __ReceiveTick_FunctionParams
		{
			// Token: 0x040329F1 RID: 207345
			[FieldOffset(0)]
			public float DeltaSeconds;
		}

		// Token: 0x02009EFA RID: 40698
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 20)]
		protected ref struct __LiveActivation_FunctionParams
		{
			// Token: 0x040329F2 RID: 207346
			[FieldOffset(0)]
			public FName ParamName;

			// Token: 0x040329F3 RID: 207347
			[FieldOffset(12)]
			public float FadeTimeOfBrush;

			// Token: 0x040329F4 RID: 207348
			[FieldOffset(16)]
			public float FadeTimeOfCanvas;
		}

		// Token: 0x02009EFB RID: 40699
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 4)]
		protected ref struct __LiveFluidParams_FunctionParams
		{
			// Token: 0x040329F5 RID: 207349
			[FieldOffset(0)]
			public float BrushSize;
		}

		// Token: 0x02009EFC RID: 40700
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 1)]
		protected new ref struct __ReceiveEndPlay_FunctionParams
		{
			// Token: 0x040329F6 RID: 207350
			[FieldOffset(0)]
			public TEnumAsByte<EEndPlayReason> EndPlayReason;
		}

		// Token: 0x02009EFD RID: 40701
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 32)]
		protected ref struct __SelChanged_FunctionParams
		{
			// Token: 0x040329F7 RID: 207351
			[FieldOffset(0)]
			public FString SelectedMenuItem;

			// Token: 0x040329F8 RID: 207352
			[FieldOffset(16)]
			public FString SelectedActorName;
		}

		// Token: 0x02009EFE RID: 40702
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 24)]
		protected ref struct __PresetSelectionChanged_FunctionParams
		{
			// Token: 0x040329F9 RID: 207353
			[FieldOffset(0)]
			public FString SelectedPreset;

			// Token: 0x040329FA RID: 207354
			[FieldOffset(16)]
			public bool ForceAutoLoadPreset;
		}

		// Token: 0x02009EFF RID: 40703
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 40)]
		protected ref struct __PresetSave_FunctionParams
		{
			// Token: 0x040329FB RID: 207355
			[FieldOffset(0)]
			public FString SelectedProject;

			// Token: 0x040329FC RID: 207356
			[FieldOffset(16)]
			public FString SelectedPreset;

			// Token: 0x040329FD RID: 207357
			[FieldOffset(32)]
			public bool OverWriteOrNot;
		}

		// Token: 0x02009F00 RID: 40704
		[NullableContext(0)]
		[CompilerFeatureRequired("RefStructs")]
		[StructLayout(LayoutKind.Explicit, Size = 18336)]
		protected ref struct __ExecuteUbergraph_NinjaLiveComponent_FunctionParams
		{
			// Token: 0x040329FE RID: 207358
			[FieldOffset(0)]
			public int EntryPoint;
		}
	}
}
