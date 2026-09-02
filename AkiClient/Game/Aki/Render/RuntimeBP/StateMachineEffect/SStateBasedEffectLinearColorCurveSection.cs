using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A4D RID: 14925
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SStateBasedEffectLinearColorCurveSection.SStateBasedEffectLinearColorCurveSection")]
	[UnrealStructLayout(1168, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1168)]
	public class SStateBasedEffectLinearColorCurveSection : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EEDB RID: 126683 RVA: 0x00902713 File Offset: 0x00900913
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SStateBasedEffectLinearColorCurveSection._ScriptStructPtr != 0) ? SStateBasedEffectLinearColorCurveSection._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SStateBasedEffectLinearColorCurveSection.SStateBasedEffectLinearColorCurveSection", ref SStateBasedEffectLinearColorCurveSection._ScriptStructPtr);
		}

		// Token: 0x17002D33 RID: 11571
		// (get) Token: 0x0601EEDC RID: 126684 RVA: 0x00902738 File Offset: 0x00900938
		// (set) Token: 0x0601EEDD RID: 126685 RVA: 0x0090277B File Offset: 0x0090097B
		public SEffectStateLinearColorCurve DefaultCurveInfo
		{
			get
			{
				base.FastCheckIsValid();
				SEffectStateLinearColorCurve result;
				if ((result = this._DefaultCurveInfo) == null)
				{
					result = (this._DefaultCurveInfo = new SEffectStateLinearColorCurve(base.NativePtr + (IntPtr)SStateBasedEffectLinearColorCurveSection.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SEffectStateLinearColorCurve.StaticStruct(), base.NativePtr + (IntPtr)SStateBasedEffectLinearColorCurveSection.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D34 RID: 11572
		// (get) Token: 0x0601EEDE RID: 126686 RVA: 0x0090279C File Offset: 0x0090099C
		// (set) Token: 0x0601EEDF RID: 126687 RVA: 0x009027DF File Offset: 0x009009DF
		public TMap<int, SEffectStateLinearColorCurve> OverrideSectionCurveInfo
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, SEffectStateLinearColorCurve> result;
				if ((result = this._OverrideSectionCurveInfo) == null)
				{
					result = (this._OverrideSectionCurveInfo = new TMap<int, SEffectStateLinearColorCurve>(base.NativePtr + (IntPtr)SStateBasedEffectLinearColorCurveSection.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.OverrideSectionCurveInfo.CopyAssign(value);
			}
		}

		// Token: 0x0601EEE0 RID: 126688 RVA: 0x009027ED File Offset: 0x009009ED
		public SStateBasedEffectLinearColorCurveSection()
		{
		}

		// Token: 0x0601EEE1 RID: 126689 RVA: 0x009027F5 File Offset: 0x009009F5
		public SStateBasedEffectLinearColorCurveSection(SEffectStateLinearColorCurve DefaultCurveInfo, TMap<int, SEffectStateLinearColorCurve> OverrideSectionCurveInfo)
		{
			this.DefaultCurveInfo = DefaultCurveInfo;
			this.OverrideSectionCurveInfo = OverrideSectionCurveInfo;
		}

		// Token: 0x0601EEE2 RID: 126690 RVA: 0x0090280B File Offset: 0x00900A0B
		protected override IntPtr GetUStructPtr()
		{
			return SStateBasedEffectLinearColorCurveSection.StaticStruct();
		}

		// Token: 0x0601EEE3 RID: 126691 RVA: 0x00902817 File Offset: 0x00900A17
		[NullableContext(2)]
		public SStateBasedEffectLinearColorCurveSection(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EEE4 RID: 126692 RVA: 0x00902821 File Offset: 0x00900A21
		public SStateBasedEffectLinearColorCurveSection(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EEE5 RID: 126693 RVA: 0x0090282C File Offset: 0x00900A2C
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SStateBasedEffectLinearColorCurveSection(Pointer, false, true);
		}

		// Token: 0x0601EEE6 RID: 126694 RVA: 0x00902836 File Offset: 0x00900A36
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SStateBasedEffectLinearColorCurveSection(Pointer, MemoryOwner);
		}

		// Token: 0x0400F4AA RID: 62634
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/SStateBasedEffectLinearColorCurveSection.SStateBasedEffectLinearColorCurveSection";

		// Token: 0x0400F4AB RID: 62635
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F4AC RID: 62636
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4AD RID: 62637
		[Nullable(2)]
		private SEffectStateLinearColorCurve _DefaultCurveInfo;

		// Token: 0x0400F4AE RID: 62638
		internal static int __PropertyOffset_1;

		// Token: 0x0400F4AF RID: 62639
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<int, SEffectStateLinearColorCurve> _OverrideSectionCurveInfo;
	}
}
