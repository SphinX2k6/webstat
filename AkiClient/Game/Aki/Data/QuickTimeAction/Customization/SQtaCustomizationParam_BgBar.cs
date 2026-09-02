using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.QuickTimeAction.Customization
{
	// Token: 0x02003E2A RID: 15914
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_BgBar.SQtaCustomizationParam_BgBar")]
	[UnrealStructLayout(36, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 36)]
	public class SQtaCustomizationParam_BgBar : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602737A RID: 160634 RVA: 0x009EC99B File Offset: 0x009EAB9B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SQtaCustomizationParam_BgBar._ScriptStructPtr != 0) ? SQtaCustomizationParam_BgBar._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_BgBar.SQtaCustomizationParam_BgBar", ref SQtaCustomizationParam_BgBar._ScriptStructPtr);
		}

		// Token: 0x17005BA5 RID: 23461
		// (get) Token: 0x0602737B RID: 160635 RVA: 0x009EC9BF File Offset: 0x009EABBF
		// (set) Token: 0x0602737C RID: 160636 RVA: 0x009EC9CF File Offset: 0x009EABCF
		public unsafe float Angle
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_BgBar.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_BgBar.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005BA6 RID: 23462
		// (get) Token: 0x0602737D RID: 160637 RVA: 0x009EC9E0 File Offset: 0x009EABE0
		// (set) Token: 0x0602737E RID: 160638 RVA: 0x009EC9F4 File Offset: 0x009EABF4
		public unsafe FLinearColor Anchor
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SQtaCustomizationParam_BgBar.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SQtaCustomizationParam_BgBar.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005BA7 RID: 23463
		// (get) Token: 0x0602737F RID: 160639 RVA: 0x009ECA0C File Offset: 0x009EAC0C
		// (set) Token: 0x06027380 RID: 160640 RVA: 0x009ECA4F File Offset: 0x009EAC4F
		public SQtaCustomizationParam_Progress Progress
		{
			get
			{
				base.FastCheckIsValid();
				SQtaCustomizationParam_Progress result;
				if ((result = this._Progress) == null)
				{
					result = (this._Progress = new SQtaCustomizationParam_Progress(base.NativePtr + (IntPtr)SQtaCustomizationParam_BgBar.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SQtaCustomizationParam_Progress.StaticStruct(), base.NativePtr + (IntPtr)SQtaCustomizationParam_BgBar.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06027381 RID: 160641 RVA: 0x009ECA70 File Offset: 0x009EAC70
		public SQtaCustomizationParam_BgBar()
		{
		}

		// Token: 0x06027382 RID: 160642 RVA: 0x009ECA78 File Offset: 0x009EAC78
		public SQtaCustomizationParam_BgBar(float Angle, FLinearColor Anchor, SQtaCustomizationParam_Progress Progress)
		{
			this.Angle = Angle;
			this.Anchor = Anchor;
			this.Progress = Progress;
		}

		// Token: 0x06027383 RID: 160643 RVA: 0x009ECA95 File Offset: 0x009EAC95
		protected override IntPtr GetUStructPtr()
		{
			return SQtaCustomizationParam_BgBar.StaticStruct();
		}

		// Token: 0x06027384 RID: 160644 RVA: 0x009ECAA1 File Offset: 0x009EACA1
		[NullableContext(2)]
		public SQtaCustomizationParam_BgBar(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027385 RID: 160645 RVA: 0x009ECAAB File Offset: 0x009EACAB
		public SQtaCustomizationParam_BgBar(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027386 RID: 160646 RVA: 0x009ECAB6 File Offset: 0x009EACB6
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SQtaCustomizationParam_BgBar(Pointer, false, true);
		}

		// Token: 0x06027387 RID: 160647 RVA: 0x009ECAC0 File Offset: 0x009EACC0
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SQtaCustomizationParam_BgBar(Pointer, MemoryOwner);
		}

		// Token: 0x04014819 RID: 83993
		public const string __ObjectPath = "/Game/Aki/Data/QuickTimeAction/Customization/SQtaCustomizationParam_BgBar.SQtaCustomizationParam_BgBar";

		// Token: 0x0401481A RID: 83994
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401481B RID: 83995
		internal static int __PropertyOffset_0;

		// Token: 0x0401481C RID: 83996
		internal static int __PropertyOffset_1;

		// Token: 0x0401481D RID: 83997
		internal static int __PropertyOffset_2;

		// Token: 0x0401481E RID: 83998
		[Nullable(2)]
		private SQtaCustomizationParam_Progress _Progress;
	}
}
