using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A49 RID: 14921
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateFloatCurve.SEffectStateFloatCurve")]
	[UnrealStructLayout(288, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 288)]
	public class SEffectStateFloatCurve : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EEA1 RID: 126625 RVA: 0x00902118 File Offset: 0x00900318
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectStateFloatCurve._ScriptStructPtr != 0) ? SEffectStateFloatCurve._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateFloatCurve.SEffectStateFloatCurve", ref SEffectStateFloatCurve._ScriptStructPtr);
		}

		// Token: 0x17002D26 RID: 11558
		// (get) Token: 0x0601EEA2 RID: 126626 RVA: 0x0090213C File Offset: 0x0090033C
		// (set) Token: 0x0601EEA3 RID: 126627 RVA: 0x0090217F File Offset: 0x0090037F
		public FKuroCurveFloat PreFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._PreFloatCurve) == null)
				{
					result = (this._PreFloatCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)SEffectStateFloatCurve.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)SEffectStateFloatCurve.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D27 RID: 11559
		// (get) Token: 0x0601EEA4 RID: 126628 RVA: 0x009021A0 File Offset: 0x009003A0
		// (set) Token: 0x0601EEA5 RID: 126629 RVA: 0x009021E3 File Offset: 0x009003E3
		public FKuroCurveFloat LoopFloatCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveFloat result;
				if ((result = this._LoopFloatCurve) == null)
				{
					result = (this._LoopFloatCurve = new FKuroCurveFloat(base.NativePtr + (IntPtr)SEffectStateFloatCurve.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveFloat.StaticStruct(), base.NativePtr + (IntPtr)SEffectStateFloatCurve.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0601EEA6 RID: 126630 RVA: 0x00902204 File Offset: 0x00900404
		public SEffectStateFloatCurve()
		{
		}

		// Token: 0x0601EEA7 RID: 126631 RVA: 0x0090220C File Offset: 0x0090040C
		public SEffectStateFloatCurve(FKuroCurveFloat PreFloatCurve, FKuroCurveFloat LoopFloatCurve)
		{
			this.PreFloatCurve = PreFloatCurve;
			this.LoopFloatCurve = LoopFloatCurve;
		}

		// Token: 0x0601EEA8 RID: 126632 RVA: 0x00902222 File Offset: 0x00900422
		protected override IntPtr GetUStructPtr()
		{
			return SEffectStateFloatCurve.StaticStruct();
		}

		// Token: 0x0601EEA9 RID: 126633 RVA: 0x0090222E File Offset: 0x0090042E
		[NullableContext(2)]
		public SEffectStateFloatCurve(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EEAA RID: 126634 RVA: 0x00902238 File Offset: 0x00900438
		public SEffectStateFloatCurve(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EEAB RID: 126635 RVA: 0x00902243 File Offset: 0x00900443
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectStateFloatCurve(Pointer, false, true);
		}

		// Token: 0x0601EEAC RID: 126636 RVA: 0x0090224D File Offset: 0x0090044D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectStateFloatCurve(Pointer, MemoryOwner);
		}

		// Token: 0x0400F48B RID: 62603
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateFloatCurve.SEffectStateFloatCurve";

		// Token: 0x0400F48C RID: 62604
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F48D RID: 62605
		internal static int __PropertyOffset_0;

		// Token: 0x0400F48E RID: 62606
		[Nullable(2)]
		private FKuroCurveFloat _PreFloatCurve;

		// Token: 0x0400F48F RID: 62607
		internal static int __PropertyOffset_1;

		// Token: 0x0400F490 RID: 62608
		[Nullable(2)]
		private FKuroCurveFloat _LoopFloatCurve;
	}
}
