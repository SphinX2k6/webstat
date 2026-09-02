using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Camera;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Level.Vehicle
{
	// Token: 0x02003E6C RID: 15980
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Level/Vehicle/SFloatThresholdAndCameraShake.SFloatThresholdAndCameraShake")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SFloatThresholdAndCameraShake : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060277CE RID: 161742 RVA: 0x009F2F64 File Offset: 0x009F1164
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFloatThresholdAndCameraShake._ScriptStructPtr != 0) ? SFloatThresholdAndCameraShake._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Level/Vehicle/SFloatThresholdAndCameraShake.SFloatThresholdAndCameraShake", ref SFloatThresholdAndCameraShake._ScriptStructPtr);
		}

		// Token: 0x17005D13 RID: 23827
		// (get) Token: 0x060277CF RID: 161743 RVA: 0x009F2F88 File Offset: 0x009F1188
		// (set) Token: 0x060277D0 RID: 161744 RVA: 0x009F2F98 File Offset: 0x009F1198
		public unsafe float Threshold
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatThresholdAndCameraShake.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFloatThresholdAndCameraShake.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005D14 RID: 23828
		// (get) Token: 0x060277D1 RID: 161745 RVA: 0x009F2FA9 File Offset: 0x009F11A9
		// (set) Token: 0x060277D2 RID: 161746 RVA: 0x009F2FBD File Offset: 0x009F11BD
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_CameraShakeAndForceFeedback_C> CameraShakeAndForceFeedback
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)SFloatThresholdAndCameraShake.__PropertyOffset_1);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)SFloatThresholdAndCameraShake.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x060277D3 RID: 161747 RVA: 0x009F2FD2 File Offset: 0x009F11D2
		public SFloatThresholdAndCameraShake()
		{
		}

		// Token: 0x060277D4 RID: 161748 RVA: 0x009F2FDA File Offset: 0x009F11DA
		public SFloatThresholdAndCameraShake(float Threshold, [Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<BP_CameraShakeAndForceFeedback_C> CameraShakeAndForceFeedback)
		{
			this.Threshold = Threshold;
			this.CameraShakeAndForceFeedback = CameraShakeAndForceFeedback;
		}

		// Token: 0x060277D5 RID: 161749 RVA: 0x009F2FF0 File Offset: 0x009F11F0
		protected override IntPtr GetUStructPtr()
		{
			return SFloatThresholdAndCameraShake.StaticStruct();
		}

		// Token: 0x060277D6 RID: 161750 RVA: 0x009F2FFC File Offset: 0x009F11FC
		[NullableContext(2)]
		public SFloatThresholdAndCameraShake(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060277D7 RID: 161751 RVA: 0x009F3006 File Offset: 0x009F1206
		public SFloatThresholdAndCameraShake(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060277D8 RID: 161752 RVA: 0x009F3011 File Offset: 0x009F1211
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFloatThresholdAndCameraShake(Pointer, false, true);
		}

		// Token: 0x060277D9 RID: 161753 RVA: 0x009F301B File Offset: 0x009F121B
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFloatThresholdAndCameraShake(Pointer, MemoryOwner);
		}

		// Token: 0x04014AF5 RID: 84725
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Level/Vehicle/SFloatThresholdAndCameraShake.SFloatThresholdAndCameraShake";

		// Token: 0x04014AF6 RID: 84726
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014AF7 RID: 84727
		internal static int __PropertyOffset_0;

		// Token: 0x04014AF8 RID: 84728
		internal static int __PropertyOffset_1;
	}
}
