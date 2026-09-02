using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x02004383 RID: 17283
	[NullableContext(2)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Audio/SFootstepAudioEventParam.SFootstepAudioEventParam")]
	[UnrealStructLayout(200, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 200)]
	public class SFootstepAudioEventParam : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DCE0 RID: 187616 RVA: 0x00ACC7C6 File Offset: 0x00ACA9C6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFootstepAudioEventParam._ScriptStructPtr != 0) ? SFootstepAudioEventParam._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Audio/SFootstepAudioEventParam.SFootstepAudioEventParam", ref SFootstepAudioEventParam._ScriptStructPtr);
		}

		// Token: 0x17007D84 RID: 32132
		// (get) Token: 0x0602DCE1 RID: 187617 RVA: 0x00ACC7EC File Offset: 0x00ACA9EC
		// (set) Token: 0x0602DCE2 RID: 187618 RVA: 0x00ACC82F File Offset: 0x00ACAA2F
		[Nullable(1)]
		public FHitResult 碰撞信息
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				FHitResult result;
				if ((result = this._碰撞信息) == null)
				{
					result = (this._碰撞信息 = new FHitResult(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(FHitResult.StaticStruct(), base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x17007D85 RID: 32133
		// (get) Token: 0x0602DCE3 RID: 187619 RVA: 0x00ACC850 File Offset: 0x00ACAA50
		// (set) Token: 0x0602DCE4 RID: 187620 RVA: 0x00ACC860 File Offset: 0x00ACAA60
		public unsafe bool 状态_地面_Walk
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D86 RID: 32134
		// (get) Token: 0x0602DCE5 RID: 187621 RVA: 0x00ACC871 File Offset: 0x00ACAA71
		// (set) Token: 0x0602DCE6 RID: 187622 RVA: 0x00ACC881 File Offset: 0x00ACAA81
		public unsafe bool 状态_地面_Run
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D87 RID: 32135
		// (get) Token: 0x0602DCE7 RID: 187623 RVA: 0x00ACC892 File Offset: 0x00ACAA92
		// (set) Token: 0x0602DCE8 RID: 187624 RVA: 0x00ACC8A2 File Offset: 0x00ACAAA2
		public unsafe bool 状态_地面_Sprint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D88 RID: 32136
		// (get) Token: 0x0602DCE9 RID: 187625 RVA: 0x00ACC8B3 File Offset: 0x00ACAAB3
		// (set) Token: 0x0602DCEA RID: 187626 RVA: 0x00ACC8C3 File Offset: 0x00ACAAC3
		public unsafe bool 状态_跑停_WalkStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D89 RID: 32137
		// (get) Token: 0x0602DCEB RID: 187627 RVA: 0x00ACC8D4 File Offset: 0x00ACAAD4
		// (set) Token: 0x0602DCEC RID: 187628 RVA: 0x00ACC8E4 File Offset: 0x00ACAAE4
		public unsafe bool 状态_跑停_RunStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_5) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_5) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D8A RID: 32138
		// (get) Token: 0x0602DCED RID: 187629 RVA: 0x00ACC8F5 File Offset: 0x00ACAAF5
		// (set) Token: 0x0602DCEE RID: 187630 RVA: 0x00ACC905 File Offset: 0x00ACAB05
		public unsafe bool 状态_跑停_SprintStop
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007D8B RID: 32139
		// (get) Token: 0x0602DCEF RID: 187631 RVA: 0x00ACC916 File Offset: 0x00ACAB16
		// (set) Token: 0x0602DCF0 RID: 187632 RVA: 0x00ACC92A File Offset: 0x00ACAB2A
		public unsafe FVector 缓存角色位置
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SFootstepAudioEventParam.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17007D8C RID: 32140
		// (get) Token: 0x0602DCF1 RID: 187633 RVA: 0x00ACC93F File Offset: 0x00ACAB3F
		// (set) Token: 0x0602DCF2 RID: 187634 RVA: 0x00ACC953 File Offset: 0x00ACAB53
		public unsafe UAkAudioEvent WalkAkAudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_8);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_8, value);
			}
		}

		// Token: 0x17007D8D RID: 32141
		// (get) Token: 0x0602DCF3 RID: 187635 RVA: 0x00ACC968 File Offset: 0x00ACAB68
		// (set) Token: 0x0602DCF4 RID: 187636 RVA: 0x00ACC97C File Offset: 0x00ACAB7C
		public unsafe UAkAudioEvent RunAkAudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_9);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_9, value);
			}
		}

		// Token: 0x17007D8E RID: 32142
		// (get) Token: 0x0602DCF5 RID: 187637 RVA: 0x00ACC991 File Offset: 0x00ACAB91
		// (set) Token: 0x0602DCF6 RID: 187638 RVA: 0x00ACC9A5 File Offset: 0x00ACABA5
		public unsafe UAkAudioEvent SprintAkAudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_10);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_10, value);
			}
		}

		// Token: 0x17007D8F RID: 32143
		// (get) Token: 0x0602DCF7 RID: 187639 RVA: 0x00ACC9BA File Offset: 0x00ACABBA
		// (set) Token: 0x0602DCF8 RID: 187640 RVA: 0x00ACC9CE File Offset: 0x00ACABCE
		public unsafe UAkAudioEvent FallbackAkAudioEvent
		{
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_11);
			}
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + SFootstepAudioEventParam.__PropertyOffset_11, value);
			}
		}

		// Token: 0x0602DCF9 RID: 187641 RVA: 0x00ACC9E3 File Offset: 0x00ACABE3
		public SFootstepAudioEventParam()
		{
		}

		// Token: 0x0602DCFA RID: 187642 RVA: 0x00ACC9EC File Offset: 0x00ACABEC
		[NullableContext(1)]
		public SFootstepAudioEventParam(FHitResult 碰撞信息, bool 状态_地面_Walk, bool 状态_地面_Run, bool 状态_地面_Sprint, bool 状态_跑停_WalkStop, bool 状态_跑停_RunStop, bool 状态_跑停_SprintStop, FVector 缓存角色位置, UAkAudioEvent WalkAkAudioEvent, UAkAudioEvent RunAkAudioEvent, UAkAudioEvent SprintAkAudioEvent, UAkAudioEvent FallbackAkAudioEvent)
		{
			this.碰撞信息 = 碰撞信息;
			this.状态_地面_Walk = 状态_地面_Walk;
			this.状态_地面_Run = 状态_地面_Run;
			this.状态_地面_Sprint = 状态_地面_Sprint;
			this.状态_跑停_WalkStop = 状态_跑停_WalkStop;
			this.状态_跑停_RunStop = 状态_跑停_RunStop;
			this.状态_跑停_SprintStop = 状态_跑停_SprintStop;
			this.缓存角色位置 = 缓存角色位置;
			this.WalkAkAudioEvent = WalkAkAudioEvent;
			this.RunAkAudioEvent = RunAkAudioEvent;
			this.SprintAkAudioEvent = SprintAkAudioEvent;
			this.FallbackAkAudioEvent = FallbackAkAudioEvent;
		}

		// Token: 0x0602DCFB RID: 187643 RVA: 0x00ACCA5C File Offset: 0x00ACAC5C
		protected override IntPtr GetUStructPtr()
		{
			return SFootstepAudioEventParam.StaticStruct();
		}

		// Token: 0x0602DCFC RID: 187644 RVA: 0x00ACCA68 File Offset: 0x00ACAC68
		public SFootstepAudioEventParam(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DCFD RID: 187645 RVA: 0x00ACCA72 File Offset: 0x00ACAC72
		public SFootstepAudioEventParam(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DCFE RID: 187646 RVA: 0x00ACCA7D File Offset: 0x00ACAC7D
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFootstepAudioEventParam(Pointer, false, true);
		}

		// Token: 0x0602DCFF RID: 187647 RVA: 0x00ACCA87 File Offset: 0x00ACAC87
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFootstepAudioEventParam(Pointer, MemoryOwner);
		}

		// Token: 0x04019DC9 RID: 105929
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Audio/SFootstepAudioEventParam.SFootstepAudioEventParam";

		// Token: 0x04019DCA RID: 105930
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019DCB RID: 105931
		internal static int __PropertyOffset_0;

		// Token: 0x04019DCC RID: 105932
		private FHitResult _碰撞信息;

		// Token: 0x04019DCD RID: 105933
		internal static int __PropertyOffset_1;

		// Token: 0x04019DCE RID: 105934
		internal static int __PropertyOffset_2;

		// Token: 0x04019DCF RID: 105935
		internal static int __PropertyOffset_3;

		// Token: 0x04019DD0 RID: 105936
		internal static int __PropertyOffset_4;

		// Token: 0x04019DD1 RID: 105937
		internal static int __PropertyOffset_5;

		// Token: 0x04019DD2 RID: 105938
		internal static int __PropertyOffset_6;

		// Token: 0x04019DD3 RID: 105939
		internal static int __PropertyOffset_7;

		// Token: 0x04019DD4 RID: 105940
		internal static int __PropertyOffset_8;

		// Token: 0x04019DD5 RID: 105941
		internal static int __PropertyOffset_9;

		// Token: 0x04019DD6 RID: 105942
		internal static int __PropertyOffset_10;

		// Token: 0x04019DD7 RID: 105943
		internal static int __PropertyOffset_11;
	}
}
