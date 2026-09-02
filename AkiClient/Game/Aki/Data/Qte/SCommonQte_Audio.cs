using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E45 RID: 15941
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_Audio.SCommonQte_Audio")]
	[UnrealStructLayout(448, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 444)]
	public class SCommonQte_Audio : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602748F RID: 160911 RVA: 0x009EE270 File Offset: 0x009EC470
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_Audio._ScriptStructPtr != 0) ? SCommonQte_Audio._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_Audio.SCommonQte_Audio", ref SCommonQte_Audio._ScriptStructPtr);
		}

		// Token: 0x17005BFC RID: 23548
		// (get) Token: 0x06027490 RID: 160912 RVA: 0x009EE294 File Offset: 0x009EC494
		// (set) Token: 0x06027491 RID: 160913 RVA: 0x009EE2B3 File Offset: 0x009EC4B3
		public TSoftObjectPtr<UAkAudioEvent> AudioEventStart
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_0, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005BFD RID: 23549
		// (get) Token: 0x06027492 RID: 160914 RVA: 0x009EE2D8 File Offset: 0x009EC4D8
		// (set) Token: 0x06027493 RID: 160915 RVA: 0x009EE2F7 File Offset: 0x009EC4F7
		public TSoftObjectPtr<UAkAudioEvent> AudioEventSuccess
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_1, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005BFE RID: 23550
		// (get) Token: 0x06027494 RID: 160916 RVA: 0x009EE31C File Offset: 0x009EC51C
		// (set) Token: 0x06027495 RID: 160917 RVA: 0x009EE33B File Offset: 0x009EC53B
		public TSoftObjectPtr<UAkAudioEvent> AudioEventFail
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_2, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_2, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005BFF RID: 23551
		// (get) Token: 0x06027496 RID: 160918 RVA: 0x009EE360 File Offset: 0x009EC560
		// (set) Token: 0x06027497 RID: 160919 RVA: 0x009EE37F File Offset: 0x009EC57F
		public TSoftObjectPtr<UAkAudioEvent> AudioEventPendingSuccess
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_3, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_3, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C00 RID: 23552
		// (get) Token: 0x06027498 RID: 160920 RVA: 0x009EE3A4 File Offset: 0x009EC5A4
		// (set) Token: 0x06027499 RID: 160921 RVA: 0x009EE3C3 File Offset: 0x009EC5C3
		public TSoftObjectPtr<UAkAudioEvent> AudioEventResponse
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_4, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_4, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C01 RID: 23553
		// (get) Token: 0x0602749A RID: 160922 RVA: 0x009EE3E8 File Offset: 0x009EC5E8
		// (set) Token: 0x0602749B RID: 160923 RVA: 0x009EE407 File Offset: 0x009EC607
		public TSoftObjectPtr<UAkAudioEvent> AudioEventProgress
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_5, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_5, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C02 RID: 23554
		// (get) Token: 0x0602749C RID: 160924 RVA: 0x009EE42C File Offset: 0x009EC62C
		// (set) Token: 0x0602749D RID: 160925 RVA: 0x009EE44B File Offset: 0x009EC64B
		public TSoftObjectPtr<UAkAudioEvent> AudioEventRegress
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_6, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_6, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C03 RID: 23555
		// (get) Token: 0x0602749E RID: 160926 RVA: 0x009EE470 File Offset: 0x009EC670
		// (set) Token: 0x0602749F RID: 160927 RVA: 0x009EE48F File Offset: 0x009EC68F
		public TSoftObjectPtr<UAkAudioEvent> AudioEventResponseEnd
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_7, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_7, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C04 RID: 23556
		// (get) Token: 0x060274A0 RID: 160928 RVA: 0x009EE4B4 File Offset: 0x009EC6B4
		// (set) Token: 0x060274A1 RID: 160929 RVA: 0x009EE4D3 File Offset: 0x009EC6D3
		public TSoftObjectPtr<UAkAudioEvent> AudioEventReset
		{
			get
			{
				return new TSoftObjectPtr<UAkAudioEvent>(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_8, base.MemoryOwner ?? this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_8, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17005C05 RID: 23557
		// (get) Token: 0x060274A2 RID: 160930 RVA: 0x009EE4F8 File Offset: 0x009EC6F8
		// (set) Token: 0x060274A3 RID: 160931 RVA: 0x009EE508 File Offset: 0x009EC708
		public unsafe float AudioEventProgressFadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005C06 RID: 23558
		// (get) Token: 0x060274A4 RID: 160932 RVA: 0x009EE519 File Offset: 0x009EC719
		// (set) Token: 0x060274A5 RID: 160933 RVA: 0x009EE529 File Offset: 0x009EC729
		public unsafe float AudioEventRegressFadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_10);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_10) = value;
			}
		}

		// Token: 0x17005C07 RID: 23559
		// (get) Token: 0x060274A6 RID: 160934 RVA: 0x009EE53A File Offset: 0x009EC73A
		// (set) Token: 0x060274A7 RID: 160935 RVA: 0x009EE54A File Offset: 0x009EC74A
		public unsafe float AudioEventResponseFadeOutTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Audio.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x060274A8 RID: 160936 RVA: 0x009EE55B File Offset: 0x009EC75B
		public SCommonQte_Audio()
		{
		}

		// Token: 0x060274A9 RID: 160937 RVA: 0x009EE564 File Offset: 0x009EC764
		public SCommonQte_Audio(TSoftObjectPtr<UAkAudioEvent> AudioEventStart, TSoftObjectPtr<UAkAudioEvent> AudioEventSuccess, TSoftObjectPtr<UAkAudioEvent> AudioEventFail, TSoftObjectPtr<UAkAudioEvent> AudioEventPendingSuccess, TSoftObjectPtr<UAkAudioEvent> AudioEventResponse, TSoftObjectPtr<UAkAudioEvent> AudioEventProgress, TSoftObjectPtr<UAkAudioEvent> AudioEventRegress, TSoftObjectPtr<UAkAudioEvent> AudioEventResponseEnd, TSoftObjectPtr<UAkAudioEvent> AudioEventReset, float AudioEventProgressFadeOutTime, float AudioEventRegressFadeOutTime, float AudioEventResponseFadeOutTime)
		{
			this.AudioEventStart = AudioEventStart;
			this.AudioEventSuccess = AudioEventSuccess;
			this.AudioEventFail = AudioEventFail;
			this.AudioEventPendingSuccess = AudioEventPendingSuccess;
			this.AudioEventResponse = AudioEventResponse;
			this.AudioEventProgress = AudioEventProgress;
			this.AudioEventRegress = AudioEventRegress;
			this.AudioEventResponseEnd = AudioEventResponseEnd;
			this.AudioEventReset = AudioEventReset;
			this.AudioEventProgressFadeOutTime = AudioEventProgressFadeOutTime;
			this.AudioEventRegressFadeOutTime = AudioEventRegressFadeOutTime;
			this.AudioEventResponseFadeOutTime = AudioEventResponseFadeOutTime;
		}

		// Token: 0x060274AA RID: 160938 RVA: 0x009EE5D4 File Offset: 0x009EC7D4
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_Audio.StaticStruct();
		}

		// Token: 0x060274AB RID: 160939 RVA: 0x009EE5E0 File Offset: 0x009EC7E0
		[NullableContext(2)]
		public SCommonQte_Audio(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060274AC RID: 160940 RVA: 0x009EE5EA File Offset: 0x009EC7EA
		public SCommonQte_Audio(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060274AD RID: 160941 RVA: 0x009EE5F5 File Offset: 0x009EC7F5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_Audio(Pointer, false, true);
		}

		// Token: 0x060274AE RID: 160942 RVA: 0x009EE5FF File Offset: 0x009EC7FF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_Audio(Pointer, MemoryOwner);
		}

		// Token: 0x04014918 RID: 84248
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_Audio.SCommonQte_Audio";

		// Token: 0x04014919 RID: 84249
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401491A RID: 84250
		internal static int __PropertyOffset_0;

		// Token: 0x0401491B RID: 84251
		internal static int __PropertyOffset_1;

		// Token: 0x0401491C RID: 84252
		internal static int __PropertyOffset_2;

		// Token: 0x0401491D RID: 84253
		internal static int __PropertyOffset_3;

		// Token: 0x0401491E RID: 84254
		internal static int __PropertyOffset_4;

		// Token: 0x0401491F RID: 84255
		internal static int __PropertyOffset_5;

		// Token: 0x04014920 RID: 84256
		internal static int __PropertyOffset_6;

		// Token: 0x04014921 RID: 84257
		internal static int __PropertyOffset_7;

		// Token: 0x04014922 RID: 84258
		internal static int __PropertyOffset_8;

		// Token: 0x04014923 RID: 84259
		internal static int __PropertyOffset_9;

		// Token: 0x04014924 RID: 84260
		internal static int __PropertyOffset_10;

		// Token: 0x04014925 RID: 84261
		internal static int __PropertyOffset_11;
	}
}
