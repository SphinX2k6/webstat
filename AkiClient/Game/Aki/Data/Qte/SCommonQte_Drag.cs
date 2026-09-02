using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E48 RID: 15944
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_Drag.SCommonQte_Drag")]
	[UnrealStructLayout(216, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 216)]
	public class SCommonQte_Drag : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060274F3 RID: 161011 RVA: 0x009EECD0 File Offset: 0x009ECED0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_Drag._ScriptStructPtr != 0) ? SCommonQte_Drag._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_Drag.SCommonQte_Drag", ref SCommonQte_Drag._ScriptStructPtr);
		}

		// Token: 0x17005C22 RID: 23586
		// (get) Token: 0x060274F4 RID: 161012 RVA: 0x009EECF4 File Offset: 0x009ECEF4
		// (set) Token: 0x060274F5 RID: 161013 RVA: 0x009EED08 File Offset: 0x009ECF08
		public unsafe TEnumAsByte<ECommonQteViewType_Drag> ViewType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C23 RID: 23587
		// (get) Token: 0x060274F6 RID: 161014 RVA: 0x009EED1D File Offset: 0x009ECF1D
		// (set) Token: 0x060274F7 RID: 161015 RVA: 0x009EED31 File Offset: 0x009ECF31
		public unsafe TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005C24 RID: 23588
		// (get) Token: 0x060274F8 RID: 161016 RVA: 0x009EED46 File Offset: 0x009ECF46
		// (set) Token: 0x060274F9 RID: 161017 RVA: 0x009EED56 File Offset: 0x009ECF56
		public unsafe int Direction
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C25 RID: 23589
		// (get) Token: 0x060274FA RID: 161018 RVA: 0x009EED67 File Offset: 0x009ECF67
		// (set) Token: 0x060274FB RID: 161019 RVA: 0x009EED77 File Offset: 0x009ECF77
		public unsafe float SlideLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005C26 RID: 23590
		// (get) Token: 0x060274FC RID: 161020 RVA: 0x009EED88 File Offset: 0x009ECF88
		// (set) Token: 0x060274FD RID: 161021 RVA: 0x009EED98 File Offset: 0x009ECF98
		public unsafe float ToleranceAngle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005C27 RID: 23591
		// (get) Token: 0x060274FE RID: 161022 RVA: 0x009EEDA9 File Offset: 0x009ECFA9
		// (set) Token: 0x060274FF RID: 161023 RVA: 0x009EEDB9 File Offset: 0x009ECFB9
		public unsafe float CompassSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005C28 RID: 23592
		// (get) Token: 0x06027500 RID: 161024 RVA: 0x009EEDCA File Offset: 0x009ECFCA
		// (set) Token: 0x06027501 RID: 161025 RVA: 0x009EEDDA File Offset: 0x009ECFDA
		public unsafe float DragBounds
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005C29 RID: 23593
		// (get) Token: 0x06027502 RID: 161026 RVA: 0x009EEDEB File Offset: 0x009ECFEB
		// (set) Token: 0x06027503 RID: 161027 RVA: 0x009EEDFB File Offset: 0x009ECFFB
		public unsafe float DragLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005C2A RID: 23594
		// (get) Token: 0x06027504 RID: 161028 RVA: 0x009EEE0C File Offset: 0x009ED00C
		// (set) Token: 0x06027505 RID: 161029 RVA: 0x009EEE1C File Offset: 0x009ED01C
		public unsafe float LerpSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005C2B RID: 23595
		// (get) Token: 0x06027506 RID: 161030 RVA: 0x009EEE30 File Offset: 0x009ED030
		// (set) Token: 0x06027507 RID: 161031 RVA: 0x009EEE73 File Offset: 0x009ED073
		[Nullable(1)]
		public SCommonQteButton UIConfig
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SCommonQteButton result;
				if ((result = this._UIConfig) == null)
				{
					result = (this._UIConfig = new SCommonQteButton(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_9, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQteButton.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_9, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C2C RID: 23596
		// (get) Token: 0x06027508 RID: 161032 RVA: 0x009EEE94 File Offset: 0x009ED094
		// (set) Token: 0x06027509 RID: 161033 RVA: 0x009EEEA4 File Offset: 0x009ED0A4
		public unsafe bool IsAttachToActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C2D RID: 23597
		// (get) Token: 0x0602750A RID: 161034 RVA: 0x009EEEB5 File Offset: 0x009ED0B5
		// (set) Token: 0x0602750B RID: 161035 RVA: 0x009EEEC9 File Offset: 0x009ED0C9
		public unsafe SCommonQte_Attach AttachConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_11);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_11) = value;
			}
		}

		// Token: 0x17005C2E RID: 23598
		// (get) Token: 0x0602750C RID: 161036 RVA: 0x009EEEDE File Offset: 0x009ED0DE
		// (set) Token: 0x0602750D RID: 161037 RVA: 0x009EEEEE File Offset: 0x009ED0EE
		public unsafe bool CheckByRealTimeInput
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_12) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_12) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C2F RID: 23599
		// (get) Token: 0x0602750E RID: 161038 RVA: 0x009EEEFF File Offset: 0x009ED0FF
		// (set) Token: 0x0602750F RID: 161039 RVA: 0x009EEF0F File Offset: 0x009ED10F
		public unsafe float LeftSlideLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_13);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_13) = value;
			}
		}

		// Token: 0x17005C30 RID: 23600
		// (get) Token: 0x06027510 RID: 161040 RVA: 0x009EEF20 File Offset: 0x009ED120
		// (set) Token: 0x06027511 RID: 161041 RVA: 0x009EEF30 File Offset: 0x009ED130
		public unsafe float RightSlideLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_14);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_14) = value;
			}
		}

		// Token: 0x17005C31 RID: 23601
		// (get) Token: 0x06027512 RID: 161042 RVA: 0x009EEF41 File Offset: 0x009ED141
		// (set) Token: 0x06027513 RID: 161043 RVA: 0x009EEF51 File Offset: 0x009ED151
		public unsafe float SlideAngleTolerance
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_15);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_15) = value;
			}
		}

		// Token: 0x17005C32 RID: 23602
		// (get) Token: 0x06027514 RID: 161044 RVA: 0x009EEF62 File Offset: 0x009ED162
		// (set) Token: 0x06027515 RID: 161045 RVA: 0x009EEF72 File Offset: 0x009ED172
		public unsafe bool IsLeftSuccess
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_16) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_16) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C33 RID: 23603
		// (get) Token: 0x06027516 RID: 161046 RVA: 0x009EEF83 File Offset: 0x009ED183
		// (set) Token: 0x06027517 RID: 161047 RVA: 0x009EEF93 File Offset: 0x009ED193
		public unsafe bool BackwardWhenFail
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_17) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_17) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C34 RID: 23604
		// (get) Token: 0x06027518 RID: 161048 RVA: 0x009EEFA4 File Offset: 0x009ED1A4
		// (set) Token: 0x06027519 RID: 161049 RVA: 0x009EEFB4 File Offset: 0x009ED1B4
		public unsafe float RewardSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_18);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_Drag.__PropertyOffset_18) = value;
			}
		}

		// Token: 0x0602751A RID: 161050 RVA: 0x009EEFC5 File Offset: 0x009ED1C5
		public SCommonQte_Drag()
		{
		}

		// Token: 0x0602751B RID: 161051 RVA: 0x009EEFD0 File Offset: 0x009ED1D0
		public SCommonQte_Drag(TEnumAsByte<ECommonQteViewType_Drag> ViewType, TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming, int Direction, float SlideLength, float ToleranceAngle, float CompassSpeed, float DragBounds, float DragLength, float LerpSpeed, [Nullable(1)] SCommonQteButton UIConfig, bool IsAttachToActor, SCommonQte_Attach AttachConfig, bool CheckByRealTimeInput, float LeftSlideLength, float RightSlideLength, float SlideAngleTolerance, bool IsLeftSuccess, bool BackwardWhenFail, float RewardSpeed)
		{
			this.ViewType = ViewType;
			this.InteractiveTiming = InteractiveTiming;
			this.Direction = Direction;
			this.SlideLength = SlideLength;
			this.ToleranceAngle = ToleranceAngle;
			this.CompassSpeed = CompassSpeed;
			this.DragBounds = DragBounds;
			this.DragLength = DragLength;
			this.LerpSpeed = LerpSpeed;
			this.UIConfig = UIConfig;
			this.IsAttachToActor = IsAttachToActor;
			this.AttachConfig = AttachConfig;
			this.CheckByRealTimeInput = CheckByRealTimeInput;
			this.LeftSlideLength = LeftSlideLength;
			this.RightSlideLength = RightSlideLength;
			this.SlideAngleTolerance = SlideAngleTolerance;
			this.IsLeftSuccess = IsLeftSuccess;
			this.BackwardWhenFail = BackwardWhenFail;
			this.RewardSpeed = RewardSpeed;
		}

		// Token: 0x0602751C RID: 161052 RVA: 0x009EF078 File Offset: 0x009ED278
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_Drag.StaticStruct();
		}

		// Token: 0x0602751D RID: 161053 RVA: 0x009EF084 File Offset: 0x009ED284
		[NullableContext(2)]
		public SCommonQte_Drag(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602751E RID: 161054 RVA: 0x009EF08E File Offset: 0x009ED28E
		public SCommonQte_Drag(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602751F RID: 161055 RVA: 0x009EF099 File Offset: 0x009ED299
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_Drag(Pointer, false, true);
		}

		// Token: 0x06027520 RID: 161056 RVA: 0x009EF0A3 File Offset: 0x009ED2A3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_Drag(Pointer, MemoryOwner);
		}

		// Token: 0x0401494A RID: 84298
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_Drag.SCommonQte_Drag";

		// Token: 0x0401494B RID: 84299
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401494C RID: 84300
		internal static int __PropertyOffset_0;

		// Token: 0x0401494D RID: 84301
		internal static int __PropertyOffset_1;

		// Token: 0x0401494E RID: 84302
		internal static int __PropertyOffset_2;

		// Token: 0x0401494F RID: 84303
		internal static int __PropertyOffset_3;

		// Token: 0x04014950 RID: 84304
		internal static int __PropertyOffset_4;

		// Token: 0x04014951 RID: 84305
		internal static int __PropertyOffset_5;

		// Token: 0x04014952 RID: 84306
		internal static int __PropertyOffset_6;

		// Token: 0x04014953 RID: 84307
		internal static int __PropertyOffset_7;

		// Token: 0x04014954 RID: 84308
		internal static int __PropertyOffset_8;

		// Token: 0x04014955 RID: 84309
		internal static int __PropertyOffset_9;

		// Token: 0x04014956 RID: 84310
		[Nullable(2)]
		private SCommonQteButton _UIConfig;

		// Token: 0x04014957 RID: 84311
		internal static int __PropertyOffset_10;

		// Token: 0x04014958 RID: 84312
		internal static int __PropertyOffset_11;

		// Token: 0x04014959 RID: 84313
		internal static int __PropertyOffset_12;

		// Token: 0x0401495A RID: 84314
		internal static int __PropertyOffset_13;

		// Token: 0x0401495B RID: 84315
		internal static int __PropertyOffset_14;

		// Token: 0x0401495C RID: 84316
		internal static int __PropertyOffset_15;

		// Token: 0x0401495D RID: 84317
		internal static int __PropertyOffset_16;

		// Token: 0x0401495E RID: 84318
		internal static int __PropertyOffset_17;

		// Token: 0x0401495F RID: 84319
		internal static int __PropertyOffset_18;
	}
}
