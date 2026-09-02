using System;
using System.Runtime.CompilerServices;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace UnrealEngine
{
	// Token: 0x020043E8 RID: 17384
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/HoudiniNiagara/HoudiniEvent.HoudiniEvent")]
	[UnrealStructLayout(68, 4, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 68)]
	public class HoudiniEvent : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602E2A7 RID: 189095 RVA: 0x00ADB0F0 File Offset: 0x00AD92F0
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (HoudiniEvent._ScriptStructPtr != 0) ? HoudiniEvent._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/HoudiniNiagara/HoudiniEvent.HoudiniEvent", ref HoudiniEvent._ScriptStructPtr);
		}

		// Token: 0x17007F18 RID: 32536
		// (get) Token: 0x0602E2A8 RID: 189096 RVA: 0x00ADB114 File Offset: 0x00AD9314
		// (set) Token: 0x0602E2A9 RID: 189097 RVA: 0x00ADB128 File Offset: 0x00AD9328
		public unsafe FVector Position
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007F19 RID: 32537
		// (get) Token: 0x0602E2AA RID: 189098 RVA: 0x00ADB13D File Offset: 0x00AD933D
		// (set) Token: 0x0602E2AB RID: 189099 RVA: 0x00ADB151 File Offset: 0x00AD9351
		public unsafe FVector Velocity
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17007F1A RID: 32538
		// (get) Token: 0x0602E2AC RID: 189100 RVA: 0x00ADB166 File Offset: 0x00AD9366
		// (set) Token: 0x0602E2AD RID: 189101 RVA: 0x00ADB17A File Offset: 0x00AD937A
		public unsafe FVector Acceleration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17007F1B RID: 32539
		// (get) Token: 0x0602E2AE RID: 189102 RVA: 0x00ADB190 File Offset: 0x00AD9390
		// (set) Token: 0x0602E2AF RID: 189103 RVA: 0x00ADB1D3 File Offset: 0x00AD93D3
		public FNiagaraID RibbonID
		{
			get
			{
				base.FastCheckIsValid();
				FNiagaraID result;
				if ((result = this._RibbonID) == null)
				{
					result = (this._RibbonID = new FNiagaraID(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_3, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FNiagaraID.StaticStruct(), base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007F1C RID: 32540
		// (get) Token: 0x0602E2B0 RID: 189104 RVA: 0x00ADB1F4 File Offset: 0x00AD93F4
		// (set) Token: 0x0602E2B1 RID: 189105 RVA: 0x00ADB204 File Offset: 0x00AD9404
		public unsafe float NormalizedAge
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17007F1D RID: 32541
		// (get) Token: 0x0602E2B2 RID: 189106 RVA: 0x00ADB215 File Offset: 0x00AD9415
		// (set) Token: 0x0602E2B3 RID: 189107 RVA: 0x00ADB225 File Offset: 0x00AD9425
		public unsafe float RandomNormalizedFloat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17007F1E RID: 32542
		// (get) Token: 0x0602E2B4 RID: 189108 RVA: 0x00ADB236 File Offset: 0x00AD9436
		// (set) Token: 0x0602E2B5 RID: 189109 RVA: 0x00ADB24A File Offset: 0x00AD944A
		public unsafe FVector Normal
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17007F1F RID: 32543
		// (get) Token: 0x0602E2B6 RID: 189110 RVA: 0x00ADB25F File Offset: 0x00AD945F
		// (set) Token: 0x0602E2B7 RID: 189111 RVA: 0x00ADB26F File Offset: 0x00AD946F
		public unsafe float Impulse
		{
			get
			{
				return *(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)HoudiniEvent.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x0602E2B8 RID: 189112 RVA: 0x00ADB280 File Offset: 0x00AD9480
		public HoudiniEvent()
		{
		}

		// Token: 0x0602E2B9 RID: 189113 RVA: 0x00ADB288 File Offset: 0x00AD9488
		public HoudiniEvent(FVector Position, FVector Velocity, FVector Acceleration, FNiagaraID RibbonID, float NormalizedAge, float RandomNormalizedFloat, FVector Normal, float Impulse)
		{
			this.Position = Position;
			this.Velocity = Velocity;
			this.Acceleration = Acceleration;
			this.RibbonID = RibbonID;
			this.NormalizedAge = NormalizedAge;
			this.RandomNormalizedFloat = RandomNormalizedFloat;
			this.Normal = Normal;
			this.Impulse = Impulse;
		}

		// Token: 0x0602E2BA RID: 189114 RVA: 0x00ADB2D8 File Offset: 0x00AD94D8
		protected override IntPtr GetUStructPtr()
		{
			return HoudiniEvent.StaticStruct();
		}

		// Token: 0x0602E2BB RID: 189115 RVA: 0x00ADB2E4 File Offset: 0x00AD94E4
		[NullableContext(2)]
		public HoudiniEvent(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602E2BC RID: 189116 RVA: 0x00ADB2EE File Offset: 0x00AD94EE
		public HoudiniEvent(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602E2BD RID: 189117 RVA: 0x00ADB2F9 File Offset: 0x00AD94F9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new HoudiniEvent(Pointer, false, true);
		}

		// Token: 0x0602E2BE RID: 189118 RVA: 0x00ADB303 File Offset: 0x00AD9503
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new HoudiniEvent(Pointer, MemoryOwner);
		}

		// Token: 0x0401A1E9 RID: 106985
		public const string __ObjectPath = "/HoudiniNiagara/HoudiniEvent.HoudiniEvent";

		// Token: 0x0401A1EA RID: 106986
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401A1EB RID: 106987
		internal static int __PropertyOffset_0;

		// Token: 0x0401A1EC RID: 106988
		internal static int __PropertyOffset_1;

		// Token: 0x0401A1ED RID: 106989
		internal static int __PropertyOffset_2;

		// Token: 0x0401A1EE RID: 106990
		internal static int __PropertyOffset_3;

		// Token: 0x0401A1EF RID: 106991
		[Nullable(2)]
		private FNiagaraID _RibbonID;

		// Token: 0x0401A1F0 RID: 106992
		internal static int __PropertyOffset_4;

		// Token: 0x0401A1F1 RID: 106993
		internal static int __PropertyOffset_5;

		// Token: 0x0401A1F2 RID: 106994
		internal static int __PropertyOffset_6;

		// Token: 0x0401A1F3 RID: 106995
		internal static int __PropertyOffset_7;
	}
}
