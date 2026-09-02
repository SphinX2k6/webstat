using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200426D RID: 17005
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SMeshDitherDetectConfig.SMeshDitherDetectConfig")]
	[UnrealStructLayout(92, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 92)]
	public class SMeshDitherDetectConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D16D RID: 184685 RVA: 0x00AB713C File Offset: 0x00AB533C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMeshDitherDetectConfig._ScriptStructPtr != 0) ? SMeshDitherDetectConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SMeshDitherDetectConfig.SMeshDitherDetectConfig", ref SMeshDitherDetectConfig._ScriptStructPtr);
		}

		// Token: 0x17007A7B RID: 31355
		// (get) Token: 0x0602D16E RID: 184686 RVA: 0x00AB7160 File Offset: 0x00AB5360
		// (set) Token: 0x0602D16F RID: 184687 RVA: 0x00AB7170 File Offset: 0x00AB5370
		public unsafe int Priority
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMeshDitherDetectConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMeshDitherDetectConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007A7C RID: 31356
		// (get) Token: 0x0602D170 RID: 184688 RVA: 0x00AB7184 File Offset: 0x00AB5384
		// (set) Token: 0x0602D171 RID: 184689 RVA: 0x00AB71C7 File Offset: 0x00AB53C7
		public SMeshDitherDetectTraceConfig TraceConfig
		{
			get
			{
				base.FastCheckIsValid();
				SMeshDitherDetectTraceConfig result;
				if ((result = this._TraceConfig) == null)
				{
					result = (this._TraceConfig = new SMeshDitherDetectTraceConfig(base.NativePtr + (IntPtr)SMeshDitherDetectConfig.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMeshDitherDetectTraceConfig.StaticStruct(), base.NativePtr + (IntPtr)SMeshDitherDetectConfig.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007A7D RID: 31357
		// (get) Token: 0x0602D172 RID: 184690 RVA: 0x00AB71E8 File Offset: 0x00AB53E8
		// (set) Token: 0x0602D173 RID: 184691 RVA: 0x00AB722B File Offset: 0x00AB542B
		public SDitherDistanceConfig DitherConfig
		{
			get
			{
				base.FastCheckIsValid();
				SDitherDistanceConfig result;
				if ((result = this._DitherConfig) == null)
				{
					result = (this._DitherConfig = new SDitherDistanceConfig(base.NativePtr + (IntPtr)SMeshDitherDetectConfig.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SDitherDistanceConfig.StaticStruct(), base.NativePtr + (IntPtr)SMeshDitherDetectConfig.__PropertyOffset_2, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602D174 RID: 184692 RVA: 0x00AB724C File Offset: 0x00AB544C
		public SMeshDitherDetectConfig()
		{
		}

		// Token: 0x0602D175 RID: 184693 RVA: 0x00AB7254 File Offset: 0x00AB5454
		public SMeshDitherDetectConfig(int Priority, SMeshDitherDetectTraceConfig TraceConfig, SDitherDistanceConfig DitherConfig)
		{
			this.Priority = Priority;
			this.TraceConfig = TraceConfig;
			this.DitherConfig = DitherConfig;
		}

		// Token: 0x0602D176 RID: 184694 RVA: 0x00AB7271 File Offset: 0x00AB5471
		protected override IntPtr GetUStructPtr()
		{
			return SMeshDitherDetectConfig.StaticStruct();
		}

		// Token: 0x0602D177 RID: 184695 RVA: 0x00AB727D File Offset: 0x00AB547D
		[NullableContext(2)]
		public SMeshDitherDetectConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D178 RID: 184696 RVA: 0x00AB7287 File Offset: 0x00AB5487
		public SMeshDitherDetectConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D179 RID: 184697 RVA: 0x00AB7292 File Offset: 0x00AB5492
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMeshDitherDetectConfig(Pointer, false, true);
		}

		// Token: 0x0602D17A RID: 184698 RVA: 0x00AB729C File Offset: 0x00AB549C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMeshDitherDetectConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04019482 RID: 103554
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SMeshDitherDetectConfig.SMeshDitherDetectConfig";

		// Token: 0x04019483 RID: 103555
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019484 RID: 103556
		internal static int __PropertyOffset_0;

		// Token: 0x04019485 RID: 103557
		internal static int __PropertyOffset_1;

		// Token: 0x04019486 RID: 103558
		[Nullable(2)]
		private SMeshDitherDetectTraceConfig _TraceConfig;

		// Token: 0x04019487 RID: 103559
		internal static int __PropertyOffset_2;

		// Token: 0x04019488 RID: 103560
		[Nullable(2)]
		private SDitherDistanceConfig _DitherConfig;
	}
}
