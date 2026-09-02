using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.RhythmGame
{
	// Token: 0x02003EA0 RID: 16032
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameFreeFlyCameraConfig.RhythmGameFreeFlyCameraConfig")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class RhythmGameFreeFlyCameraConfig : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027C79 RID: 162937 RVA: 0x009FA5A6 File Offset: 0x009F87A6
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (RhythmGameFreeFlyCameraConfig._ScriptStructPtr != 0) ? RhythmGameFreeFlyCameraConfig._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameFreeFlyCameraConfig.RhythmGameFreeFlyCameraConfig", ref RhythmGameFreeFlyCameraConfig._ScriptStructPtr);
		}

		// Token: 0x17005EE6 RID: 24294
		// (get) Token: 0x06027C7A RID: 162938 RVA: 0x009FA5CA File Offset: 0x009F87CA
		// (set) Token: 0x06027C7B RID: 162939 RVA: 0x009FA5DE File Offset: 0x009F87DE
		public unsafe FVectorDouble TargetLoc
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005EE7 RID: 24295
		// (get) Token: 0x06027C7C RID: 162940 RVA: 0x009FA5F3 File Offset: 0x009F87F3
		// (set) Token: 0x06027C7D RID: 162941 RVA: 0x009FA607 File Offset: 0x009F8807
		public unsafe FRotator TargetRot
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005EE8 RID: 24296
		// (get) Token: 0x06027C7E RID: 162942 RVA: 0x009FA61C File Offset: 0x009F881C
		// (set) Token: 0x06027C7F RID: 162943 RVA: 0x009FA62C File Offset: 0x009F882C
		public unsafe float Radius
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005EE9 RID: 24297
		// (get) Token: 0x06027C80 RID: 162944 RVA: 0x009FA63D File Offset: 0x009F883D
		// (set) Token: 0x06027C81 RID: 162945 RVA: 0x009FA64D File Offset: 0x009F884D
		public unsafe float ChangeInterval
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005EEA RID: 24298
		// (get) Token: 0x06027C82 RID: 162946 RVA: 0x009FA65E File Offset: 0x009F885E
		// (set) Token: 0x06027C83 RID: 162947 RVA: 0x009FA66E File Offset: 0x009F886E
		public unsafe float InterpDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005EEB RID: 24299
		// (get) Token: 0x06027C84 RID: 162948 RVA: 0x009FA67F File Offset: 0x009F887F
		// (set) Token: 0x06027C85 RID: 162949 RVA: 0x009FA68F File Offset: 0x009F888F
		public unsafe float EnterTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005EEC RID: 24300
		// (get) Token: 0x06027C86 RID: 162950 RVA: 0x009FA6A0 File Offset: 0x009F88A0
		// (set) Token: 0x06027C87 RID: 162951 RVA: 0x009FA6B0 File Offset: 0x009F88B0
		public unsafe float ExitTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)RhythmGameFreeFlyCameraConfig.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06027C88 RID: 162952 RVA: 0x009FA6C1 File Offset: 0x009F88C1
		public RhythmGameFreeFlyCameraConfig()
		{
		}

		// Token: 0x06027C89 RID: 162953 RVA: 0x009FA6C9 File Offset: 0x009F88C9
		public RhythmGameFreeFlyCameraConfig(FVectorDouble TargetLoc, FRotator TargetRot, float Radius, float ChangeInterval, float InterpDuration, float EnterTime, float ExitTime)
		{
			this.TargetLoc = TargetLoc;
			this.TargetRot = TargetRot;
			this.Radius = Radius;
			this.ChangeInterval = ChangeInterval;
			this.InterpDuration = InterpDuration;
			this.EnterTime = EnterTime;
			this.ExitTime = ExitTime;
		}

		// Token: 0x06027C8A RID: 162954 RVA: 0x009FA706 File Offset: 0x009F8906
		protected override IntPtr GetUStructPtr()
		{
			return RhythmGameFreeFlyCameraConfig.StaticStruct();
		}

		// Token: 0x06027C8B RID: 162955 RVA: 0x009FA712 File Offset: 0x009F8912
		[NullableContext(2)]
		public RhythmGameFreeFlyCameraConfig(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027C8C RID: 162956 RVA: 0x009FA71C File Offset: 0x009F891C
		public RhythmGameFreeFlyCameraConfig(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027C8D RID: 162957 RVA: 0x009FA727 File Offset: 0x009F8927
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new RhythmGameFreeFlyCameraConfig(Pointer, false, true);
		}

		// Token: 0x06027C8E RID: 162958 RVA: 0x009FA731 File Offset: 0x009F8931
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new RhythmGameFreeFlyCameraConfig(Pointer, MemoryOwner);
		}

		// Token: 0x04014DF6 RID: 85494
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/RhythmGame/RhythmGameFreeFlyCameraConfig.RhythmGameFreeFlyCameraConfig";

		// Token: 0x04014DF7 RID: 85495
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014DF8 RID: 85496
		internal static int __PropertyOffset_0;

		// Token: 0x04014DF9 RID: 85497
		internal static int __PropertyOffset_1;

		// Token: 0x04014DFA RID: 85498
		internal static int __PropertyOffset_2;

		// Token: 0x04014DFB RID: 85499
		internal static int __PropertyOffset_3;

		// Token: 0x04014DFC RID: 85500
		internal static int __PropertyOffset_4;

		// Token: 0x04014DFD RID: 85501
		internal static int __PropertyOffset_5;

		// Token: 0x04014DFE RID: 85502
		internal static int __PropertyOffset_6;
	}
}
