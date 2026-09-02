using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A4B RID: 14923
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateLinearColorCurve.SEffectStateLinearColorCurve")]
	[UnrealStructLayout(1088, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1088)]
	public class SEffectStateLinearColorCurve : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EEC3 RID: 126659 RVA: 0x009024A6 File Offset: 0x009006A6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectStateLinearColorCurve._ScriptStructPtr != 0) ? SEffectStateLinearColorCurve._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateLinearColorCurve.SEffectStateLinearColorCurve", ref SEffectStateLinearColorCurve._ScriptStructPtr);
		}

		// Token: 0x17002D2F RID: 11567
		// (get) Token: 0x0601EEC4 RID: 126660 RVA: 0x009024CC File Offset: 0x009006CC
		// (set) Token: 0x0601EEC5 RID: 126661 RVA: 0x0090250F File Offset: 0x0090070F
		public FKuroCurveLinearColor PreLinearColorCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._PreLinearColorCurve) == null)
				{
					result = (this._PreLinearColorCurve = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)SEffectStateLinearColorCurve.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)SEffectStateLinearColorCurve.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17002D30 RID: 11568
		// (get) Token: 0x0601EEC6 RID: 126662 RVA: 0x00902530 File Offset: 0x00900730
		// (set) Token: 0x0601EEC7 RID: 126663 RVA: 0x00902573 File Offset: 0x00900773
		public FKuroCurveLinearColor LoopLinearColorCurve
		{
			get
			{
				base.FastCheckIsValid();
				FKuroCurveLinearColor result;
				if ((result = this._LoopLinearColorCurve) == null)
				{
					result = (this._LoopLinearColorCurve = new FKuroCurveLinearColor(base.NativePtr + (IntPtr)SEffectStateLinearColorCurve.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FKuroCurveLinearColor.StaticStruct(), base.NativePtr + (IntPtr)SEffectStateLinearColorCurve.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0601EEC8 RID: 126664 RVA: 0x00902594 File Offset: 0x00900794
		public SEffectStateLinearColorCurve()
		{
		}

		// Token: 0x0601EEC9 RID: 126665 RVA: 0x0090259C File Offset: 0x0090079C
		public SEffectStateLinearColorCurve(FKuroCurveLinearColor PreLinearColorCurve, FKuroCurveLinearColor LoopLinearColorCurve)
		{
			this.PreLinearColorCurve = PreLinearColorCurve;
			this.LoopLinearColorCurve = LoopLinearColorCurve;
		}

		// Token: 0x0601EECA RID: 126666 RVA: 0x009025B2 File Offset: 0x009007B2
		protected override IntPtr GetUStructPtr()
		{
			return SEffectStateLinearColorCurve.StaticStruct();
		}

		// Token: 0x0601EECB RID: 126667 RVA: 0x009025BE File Offset: 0x009007BE
		[NullableContext(2)]
		public SEffectStateLinearColorCurve(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EECC RID: 126668 RVA: 0x009025C8 File Offset: 0x009007C8
		public SEffectStateLinearColorCurve(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EECD RID: 126669 RVA: 0x009025D3 File Offset: 0x009007D3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectStateLinearColorCurve(Pointer, false, true);
		}

		// Token: 0x0601EECE RID: 126670 RVA: 0x009025DD File Offset: 0x009007DD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectStateLinearColorCurve(Pointer, MemoryOwner);
		}

		// Token: 0x0400F49E RID: 62622
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateLinearColorCurve.SEffectStateLinearColorCurve";

		// Token: 0x0400F49F RID: 62623
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F4A0 RID: 62624
		internal static int __PropertyOffset_0;

		// Token: 0x0400F4A1 RID: 62625
		[Nullable(2)]
		private FKuroCurveLinearColor _PreLinearColorCurve;

		// Token: 0x0400F4A2 RID: 62626
		internal static int __PropertyOffset_1;

		// Token: 0x0400F4A3 RID: 62627
		[Nullable(2)]
		private FKuroCurveLinearColor _LoopLinearColorCurve;
	}
}
