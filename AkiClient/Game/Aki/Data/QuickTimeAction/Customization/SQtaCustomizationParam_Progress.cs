using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E2C RID: 15916
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_Progress.SQtaCustomizationParam_Progress")]
	[UnrealStructLayout(16, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SQtaCustomizationParam_Progress : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027396 RID: 160662 RVA: 0x009ECBB1 File Offset: 0x009EADB1
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCustomizationParam_Progress._ScriptStructPtr != 0) ? SQtaCustomizationParam_Progress._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_Progress.SQtaCustomizationParam_Progress", ref SQtaCustomizationParam_Progress._ScriptStructPtr);
		}

		// Token: 0x17005BAB RID: 23467
		// (get) Token: 0x06027397 RID: 160663 RVA: 0x009ECBD5 File Offset: 0x009EADD5
		// (set) Token: 0x06027398 RID: 160664 RVA: 0x009ECBE5 File Offset: 0x009EADE5
		public unsafe float InitProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BAC RID: 23468
		// (get) Token: 0x06027399 RID: 160665 RVA: 0x009ECBF6 File Offset: 0x009EADF6
		// (set) Token: 0x0602739A RID: 160666 RVA: 0x009ECC06 File Offset: 0x009EAE06
		public unsafe float MaxProgress
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BAD RID: 23469
		// (get) Token: 0x0602739B RID: 160667 RVA: 0x009ECC17 File Offset: 0x009EAE17
		// (set) Token: 0x0602739C RID: 160668 RVA: 0x009ECC27 File Offset: 0x009EAE27
		public unsafe float AutoSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005BAE RID: 23470
		// (get) Token: 0x0602739D RID: 160669 RVA: 0x009ECC38 File Offset: 0x009EAE38
		// (set) Token: 0x0602739E RID: 160670 RVA: 0x009ECC48 File Offset: 0x009EAE48
		public unsafe float AdditionSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_Progress.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602739F RID: 160671 RVA: 0x009ECC59 File Offset: 0x009EAE59
		public SQtaCustomizationParam_Progress()
		{
		}

		// Token: 0x060273A0 RID: 160672 RVA: 0x009ECC61 File Offset: 0x009EAE61
		public SQtaCustomizationParam_Progress(float InitProgress, float MaxProgress, float AutoSpeed, float AdditionSpeed)
		{
			this.InitProgress = InitProgress;
			this.MaxProgress = MaxProgress;
			this.AutoSpeed = AutoSpeed;
			this.AdditionSpeed = AdditionSpeed;
		}

		// Token: 0x060273A1 RID: 160673 RVA: 0x009ECC86 File Offset: 0x009EAE86
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCustomizationParam_Progress.StaticStruct();
		}

		// Token: 0x060273A2 RID: 160674 RVA: 0x009ECC92 File Offset: 0x009EAE92
		[NullableContext(2)]
		public SQtaCustomizationParam_Progress(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060273A3 RID: 160675 RVA: 0x009ECC9C File Offset: 0x009EAE9C
		public SQtaCustomizationParam_Progress(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060273A4 RID: 160676 RVA: 0x009ECCA7 File Offset: 0x009EAEA7
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCustomizationParam_Progress(Pointer, false, true);
		}

		// Token: 0x060273A5 RID: 160677 RVA: 0x009ECCB1 File Offset: 0x009EAEB1
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCustomizationParam_Progress(Pointer, MemoryOwner);
		}

		// Token: 0x04014824 RID: 84004
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_Progress.SQtaCustomizationParam_Progress";

		// Token: 0x04014825 RID: 84005
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014826 RID: 84006
		internal static int __PropertyOffset_0;

		// Token: 0x04014827 RID: 84007
		internal static int __PropertyOffset_1;

		// Token: 0x04014828 RID: 84008
		internal static int __PropertyOffset_2;

		// Token: 0x04014829 RID: 84009
		internal static int __PropertyOffset_3;
	}
}
