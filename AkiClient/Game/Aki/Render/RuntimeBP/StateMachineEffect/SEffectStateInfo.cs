using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Render.RuntimeBP.StateMachineEffect
{
	// Token: 0x02003A4A RID: 14922
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateInfo.SEffectStateInfo")]
	[UnrealStructLayout(336, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 336)]
	public class SEffectStateInfo : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0601EEAD RID: 126637 RVA: 0x00902256 File Offset: 0x00900456
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SEffectStateInfo._ScriptStructPtr != 0) ? SEffectStateInfo._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateInfo.SEffectStateInfo", ref SEffectStateInfo._ScriptStructPtr);
		}

		// Token: 0x17002D28 RID: 11560
		// (get) Token: 0x0601EEAE RID: 126638 RVA: 0x0090227A File Offset: 0x0090047A
		// (set) Token: 0x0601EEAF RID: 126639 RVA: 0x0090228A File Offset: 0x0090048A
		public unsafe float StateTransitionTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17002D29 RID: 11561
		// (get) Token: 0x0601EEB0 RID: 126640 RVA: 0x0090229B File Offset: 0x0090049B
		// (set) Token: 0x0601EEB1 RID: 126641 RVA: 0x009022AB File Offset: 0x009004AB
		public unsafe float PreLoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17002D2A RID: 11562
		// (get) Token: 0x0601EEB2 RID: 126642 RVA: 0x009022BC File Offset: 0x009004BC
		// (set) Token: 0x0601EEB3 RID: 126643 RVA: 0x009022CC File Offset: 0x009004CC
		public unsafe float LoopTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17002D2B RID: 11563
		// (get) Token: 0x0601EEB4 RID: 126644 RVA: 0x009022E0 File Offset: 0x009004E0
		// (set) Token: 0x0601EEB5 RID: 126645 RVA: 0x00902323 File Offset: 0x00900523
		public TMap<FName, SEffectStateFloatCurve> FloatInfos
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SEffectStateFloatCurve> result;
				if ((result = this._FloatInfos) == null)
				{
					result = (this._FloatInfos = new TMap<FName, SEffectStateFloatCurve>(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatInfos.CopyAssign(value);
			}
		}

		// Token: 0x17002D2C RID: 11564
		// (get) Token: 0x0601EEB6 RID: 126646 RVA: 0x00902334 File Offset: 0x00900534
		// (set) Token: 0x0601EEB7 RID: 126647 RVA: 0x00902377 File Offset: 0x00900577
		public TMap<FName, SEffectStateLinearColorCurve> LinearColorInfos
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SEffectStateLinearColorCurve> result;
				if ((result = this._LinearColorInfos) == null)
				{
					result = (this._LinearColorInfos = new TMap<FName, SEffectStateLinearColorCurve>(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_4, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.LinearColorInfos.CopyAssign(value);
			}
		}

		// Token: 0x17002D2D RID: 11565
		// (get) Token: 0x0601EEB8 RID: 126648 RVA: 0x00902388 File Offset: 0x00900588
		// (set) Token: 0x0601EEB9 RID: 126649 RVA: 0x009023CB File Offset: 0x009005CB
		public TMap<FName, SStateBasedEffectFloatCurveSection> StaticMeshFloatInfo
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SStateBasedEffectFloatCurveSection> result;
				if ((result = this._StaticMeshFloatInfo) == null)
				{
					result = (this._StaticMeshFloatInfo = new TMap<FName, SStateBasedEffectFloatCurveSection>(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_5, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.StaticMeshFloatInfo.CopyAssign(value);
			}
		}

		// Token: 0x17002D2E RID: 11566
		// (get) Token: 0x0601EEBA RID: 126650 RVA: 0x009023DC File Offset: 0x009005DC
		// (set) Token: 0x0601EEBB RID: 126651 RVA: 0x0090241F File Offset: 0x0090061F
		public TMap<FName, SStateBasedEffectLinearColorCurveSection> StaticMeshLinearColorInfo
		{
			get
			{
				base.FastCheckIsValid();
				TMap<FName, SStateBasedEffectLinearColorCurveSection> result;
				if ((result = this._StaticMeshLinearColorInfo) == null)
				{
					result = (this._StaticMeshLinearColorInfo = new TMap<FName, SStateBasedEffectLinearColorCurveSection>(base.NativePtr + (IntPtr)SEffectStateInfo.__PropertyOffset_6, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.StaticMeshLinearColorInfo.CopyAssign(value);
			}
		}

		// Token: 0x0601EEBC RID: 126652 RVA: 0x0090242D File Offset: 0x0090062D
		public SEffectStateInfo()
		{
		}

		// Token: 0x0601EEBD RID: 126653 RVA: 0x00902435 File Offset: 0x00900635
		public SEffectStateInfo(float StateTransitionTime, float PreLoopTime, float LoopTime, TMap<FName, SEffectStateFloatCurve> FloatInfos, TMap<FName, SEffectStateLinearColorCurve> LinearColorInfos, TMap<FName, SStateBasedEffectFloatCurveSection> StaticMeshFloatInfo, TMap<FName, SStateBasedEffectLinearColorCurveSection> StaticMeshLinearColorInfo)
		{
			this.StateTransitionTime = StateTransitionTime;
			this.PreLoopTime = PreLoopTime;
			this.LoopTime = LoopTime;
			this.FloatInfos = FloatInfos;
			this.LinearColorInfos = LinearColorInfos;
			this.StaticMeshFloatInfo = StaticMeshFloatInfo;
			this.StaticMeshLinearColorInfo = StaticMeshLinearColorInfo;
		}

		// Token: 0x0601EEBE RID: 126654 RVA: 0x00902472 File Offset: 0x00900672
		protected override IntPtr GetUStructPtr()
		{
			return SEffectStateInfo.StaticStruct();
		}

		// Token: 0x0601EEBF RID: 126655 RVA: 0x0090247E File Offset: 0x0090067E
		[NullableContext(2)]
		public SEffectStateInfo(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0601EEC0 RID: 126656 RVA: 0x00902488 File Offset: 0x00900688
		public SEffectStateInfo(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0601EEC1 RID: 126657 RVA: 0x00902493 File Offset: 0x00900693
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SEffectStateInfo(Pointer, false, true);
		}

		// Token: 0x0601EEC2 RID: 126658 RVA: 0x0090249D File Offset: 0x0090069D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SEffectStateInfo(Pointer, MemoryOwner);
		}

		// Token: 0x0400F491 RID: 62609
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/StateMachineEffect/SEffectStateInfo.SEffectStateInfo";

		// Token: 0x0400F492 RID: 62610
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0400F493 RID: 62611
		internal static int __PropertyOffset_0;

		// Token: 0x0400F494 RID: 62612
		internal static int __PropertyOffset_1;

		// Token: 0x0400F495 RID: 62613
		internal static int __PropertyOffset_2;

		// Token: 0x0400F496 RID: 62614
		internal static int __PropertyOffset_3;

		// Token: 0x0400F497 RID: 62615
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SEffectStateFloatCurve> _FloatInfos;

		// Token: 0x0400F498 RID: 62616
		internal static int __PropertyOffset_4;

		// Token: 0x0400F499 RID: 62617
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SEffectStateLinearColorCurve> _LinearColorInfos;

		// Token: 0x0400F49A RID: 62618
		internal static int __PropertyOffset_5;

		// Token: 0x0400F49B RID: 62619
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SStateBasedEffectFloatCurveSection> _StaticMeshFloatInfo;

		// Token: 0x0400F49C RID: 62620
		internal static int __PropertyOffset_6;

		// Token: 0x0400F49D RID: 62621
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TMap<FName, SStateBasedEffectLinearColorCurveSection> _StaticMeshLinearColorInfo;
	}
}
