using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A4C RID: 14924
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SStateBasedEffectFloatCurveSection.SStateBasedEffectFloatCurveSection")]
	[UnrealStructLayout(368, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 368)]
	public class SStateBasedEffectFloatCurveSection : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EECF RID: 126671 RVA: 0x009025E6 File Offset: 0x009007E6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SStateBasedEffectFloatCurveSection._ScriptStructPtr != 0) ? SStateBasedEffectFloatCurveSection._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SStateBasedEffectFloatCurveSection.SStateBasedEffectFloatCurveSection", ref SStateBasedEffectFloatCurveSection._ScriptStructPtr);
		}

		// Token: 0x17002D31 RID: 11569
		// (get) Token: 0x0601EED0 RID: 126672 RVA: 0x0090260C File Offset: 0x0090080C
		// (set) Token: 0x0601EED1 RID: 126673 RVA: 0x0090264F File Offset: 0x0090084F
		public SEffectStateFloatCurve DefaultCurveInfo
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateFloatCurve result;
				if ((result = this._DefaultCurveInfo) == null)
				{
					result = (this._DefaultCurveInfo = new SEffectStateFloatCurve(base.NativePtr + (IntPtr)SStateBasedEffectFloatCurveSection.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateFloatCurve.StaticStruct(), base.NativePtr + (IntPtr)SStateBasedEffectFloatCurveSection.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D32 RID: 11570
		// (get) Token: 0x0601EED2 RID: 126674 RVA: 0x00902670 File Offset: 0x00900870
		// (set) Token: 0x0601EED3 RID: 126675 RVA: 0x009026B3 File Offset: 0x009008B3
		public TMap<int, SEffectStateFloatCurve> OverrideSectionCurveInfo
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, SEffectStateFloatCurve> result;
				if ((result = this._OverrideSectionCurveInfo) == null)
				{
					result = (this._OverrideSectionCurveInfo = new TMap<int, SEffectStateFloatCurve>(base.NativePtr + (IntPtr)SStateBasedEffectFloatCurveSection.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.OverrideSectionCurveInfo.CopyAssign(value);
			}
		}

		// Token: 0x0601EED4 RID: 126676 RVA: 0x009026C1 File Offset: 0x009008C1
		public SStateBasedEffectFloatCurveSection()
		{
		}

		// Token: 0x0601EED5 RID: 126677 RVA: 0x009026C9 File Offset: 0x009008C9
		public SStateBasedEffectFloatCurveSection(SEffectStateFloatCurve DefaultCurveInfo, TMap<int, SEffectStateFloatCurve> OverrideSectionCurveInfo)
		{
			this.DefaultCurveInfo = DefaultCurveInfo;
			this.OverrideSectionCurveInfo = OverrideSectionCurveInfo;
		}

		// Token: 0x0601EED6 RID: 126678 RVA: 0x009026DF File Offset: 0x009008DF
		protected override IntPtr GetUStructPtr()
		{
			return SStateBasedEffectFloatCurveSection.StaticStruct();
		}

		// Token: 0x0601EED7 RID: 126679 RVA: 0x009026EB File Offset: 0x009008EB
		[NullableContext(2)]
		public SStateBasedEffectFloatCurveSection(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EED8 RID: 126680 RVA: 0x009026F5 File Offset: 0x009008F5
		public SStateBasedEffectFloatCurveSection(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EED9 RID: 126681 RVA: 0x00902700 File Offset: 0x00900900
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SStateBasedEffectFloatCurveSection(Pointer, false, true);
		}

		// Token: 0x0601EEDA RID: 126682 RVA: 0x0090270A File Offset: 0x0090090A
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SStateBasedEffectFloatCurveSection(Pointer, MemoryOwner);
		}

		// Token: 0x0400F4A4 RID: 62628
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/SStateBasedEffectFloatCurveSection.SStateBasedEffectFloatCurveSection";

		// Token: 0x0400F4A5 RID: 62629
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F4A6 RID: 62630
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4A7 RID: 62631
		[Nullable(2)]
		private SEffectStateFloatCurve _DefaultCurveInfo;

		// Token: 0x0400F4A8 RID: 62632
		internal static int __PropertyOffset_1;

		// Token: 0x0400F4A9 RID: 62633
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SEffectStateFloatCurve> _OverrideSectionCurveInfo;
	}
}
