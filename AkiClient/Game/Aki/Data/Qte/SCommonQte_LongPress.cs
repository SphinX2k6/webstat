using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Qte
{
	// Token: 0x02003E4A RID: 15946
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Qte/SCommonQte_LongPress.SCommonQte_LongPress")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 193)]
	public class SCommonQte_LongPress : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027539 RID: 161081 RVA: 0x009EF348 File Offset: 0x009ED548
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCommonQte_LongPress._ScriptStructPtr != 0) ? SCommonQte_LongPress._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Qte/SCommonQte_LongPress.SCommonQte_LongPress", ref SCommonQte_LongPress._ScriptStructPtr);
		}

		// Token: 0x17005C3D RID: 23613
		// (get) Token: 0x0602753A RID: 161082 RVA: 0x009EF36C File Offset: 0x009ED56C
		// (set) Token: 0x0602753B RID: 161083 RVA: 0x009EF380 File Offset: 0x009ED580
		public unsafe TEnumAsByte<ECommonQteViewType_SingleButtonLongPress> ViewType
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C3E RID: 23614
		// (get) Token: 0x0602753C RID: 161084 RVA: 0x009EF398 File Offset: 0x009ED598
		// (set) Token: 0x0602753D RID: 161085 RVA: 0x009EF3DB File Offset: 0x009ED5DB
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
					result = (this._UIConfig = new SCommonQteButton(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCommonQteButton.StaticStruct(), base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17005C3F RID: 23615
		// (get) Token: 0x0602753E RID: 161086 RVA: 0x009EF3FC File Offset: 0x009ED5FC
		// (set) Token: 0x0602753F RID: 161087 RVA: 0x009EF410 File Offset: 0x009ED610
		public unsafe TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005C40 RID: 23616
		// (get) Token: 0x06027540 RID: 161088 RVA: 0x009EF425 File Offset: 0x009ED625
		// (set) Token: 0x06027541 RID: 161089 RVA: 0x009EF435 File Offset: 0x009ED635
		public unsafe float InitProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005C41 RID: 23617
		// (get) Token: 0x06027542 RID: 161090 RVA: 0x009EF446 File Offset: 0x009ED646
		// (set) Token: 0x06027543 RID: 161091 RVA: 0x009EF456 File Offset: 0x009ED656
		public unsafe float MaxProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005C42 RID: 23618
		// (get) Token: 0x06027544 RID: 161092 RVA: 0x009EF467 File Offset: 0x009ED667
		// (set) Token: 0x06027545 RID: 161093 RVA: 0x009EF477 File Offset: 0x009ED677
		public unsafe float TargetProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005C43 RID: 23619
		// (get) Token: 0x06027546 RID: 161094 RVA: 0x009EF488 File Offset: 0x009ED688
		// (set) Token: 0x06027547 RID: 161095 RVA: 0x009EF498 File Offset: 0x009ED698
		public unsafe float IncreaseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005C44 RID: 23620
		// (get) Token: 0x06027548 RID: 161096 RVA: 0x009EF4A9 File Offset: 0x009ED6A9
		// (set) Token: 0x06027549 RID: 161097 RVA: 0x009EF4B9 File Offset: 0x009ED6B9
		public unsafe float DecreaseSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005C45 RID: 23621
		// (get) Token: 0x0602754A RID: 161098 RVA: 0x009EF4CA File Offset: 0x009ED6CA
		// (set) Token: 0x0602754B RID: 161099 RVA: 0x009EF4DA File Offset: 0x009ED6DA
		public unsafe bool IsAttachToActor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_8) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_8) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C46 RID: 23622
		// (get) Token: 0x0602754C RID: 161100 RVA: 0x009EF4EB File Offset: 0x009ED6EB
		// (set) Token: 0x0602754D RID: 161101 RVA: 0x009EF4FF File Offset: 0x009ED6FF
		public unsafe SCommonQte_Attach AttachConfig
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_9);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_9) = value;
			}
		}

		// Token: 0x17005C47 RID: 23623
		// (get) Token: 0x0602754E RID: 161102 RVA: 0x009EF514 File Offset: 0x009ED714
		// (set) Token: 0x0602754F RID: 161103 RVA: 0x009EF524 File Offset: 0x009ED724
		public unsafe bool IsCheckOnRelease
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_10) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SCommonQte_LongPress.__PropertyOffset_10) = (value ? 1 : 0);
			}
		}

		// Token: 0x06027550 RID: 161104 RVA: 0x009EF535 File Offset: 0x009ED735
		public SCommonQte_LongPress()
		{
		}

		// Token: 0x06027551 RID: 161105 RVA: 0x009EF540 File Offset: 0x009ED740
		public SCommonQte_LongPress(TEnumAsByte<ECommonQteViewType_SingleButtonLongPress> ViewType, [Nullable(1)] SCommonQteButton UIConfig, TEnumAsByte<ECommonQteInteractiveTiming> InteractiveTiming, float InitProgress, float MaxProgress, float TargetProgress, float IncreaseSpeed, float DecreaseSpeed, bool IsAttachToActor, SCommonQte_Attach AttachConfig, bool IsCheckOnRelease)
		{
			this.ViewType = ViewType;
			this.UIConfig = UIConfig;
			this.InteractiveTiming = InteractiveTiming;
			this.InitProgress = InitProgress;
			this.MaxProgress = MaxProgress;
			this.TargetProgress = TargetProgress;
			this.IncreaseSpeed = IncreaseSpeed;
			this.DecreaseSpeed = DecreaseSpeed;
			this.IsAttachToActor = IsAttachToActor;
			this.AttachConfig = AttachConfig;
			this.IsCheckOnRelease = IsCheckOnRelease;
		}

		// Token: 0x06027552 RID: 161106 RVA: 0x009EF5A8 File Offset: 0x009ED7A8
		protected override IntPtr GetUStructPtr()
		{
			return SCommonQte_LongPress.StaticStruct();
		}

		// Token: 0x06027553 RID: 161107 RVA: 0x009EF5B4 File Offset: 0x009ED7B4
		[NullableContext(2)]
		public SCommonQte_LongPress(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027554 RID: 161108 RVA: 0x009EF5BE File Offset: 0x009ED7BE
		public SCommonQte_LongPress(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027555 RID: 161109 RVA: 0x009EF5C9 File Offset: 0x009ED7C9
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCommonQte_LongPress(Pointer, false, true);
		}

		// Token: 0x06027556 RID: 161110 RVA: 0x009EF5D3 File Offset: 0x009ED7D3
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCommonQte_LongPress(Pointer, MemoryOwner);
		}

		// Token: 0x0401496B RID: 84331
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Qte/SCommonQte_LongPress.SCommonQte_LongPress";

		// Token: 0x0401496C RID: 84332
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401496D RID: 84333
		internal static int __PropertyOffset_0;

		// Token: 0x0401496E RID: 84334
		internal static int __PropertyOffset_1;

		// Token: 0x0401496F RID: 84335
		[Nullable(2)]
		private SCommonQteButton _UIConfig;

		// Token: 0x04014970 RID: 84336
		internal static int __PropertyOffset_2;

		// Token: 0x04014971 RID: 84337
		internal static int __PropertyOffset_3;

		// Token: 0x04014972 RID: 84338
		internal static int __PropertyOffset_4;

		// Token: 0x04014973 RID: 84339
		internal static int __PropertyOffset_5;

		// Token: 0x04014974 RID: 84340
		internal static int __PropertyOffset_6;

		// Token: 0x04014975 RID: 84341
		internal static int __PropertyOffset_7;

		// Token: 0x04014976 RID: 84342
		internal static int __PropertyOffset_8;

		// Token: 0x04014977 RID: 84343
		internal static int __PropertyOffset_9;

		// Token: 0x04014978 RID: 84344
		internal static int __PropertyOffset_10;
	}
}
