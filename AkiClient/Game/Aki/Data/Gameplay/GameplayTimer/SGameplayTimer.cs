using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.GameplayTimer
{
	// Token: 0x02003EB4 RID: 16052
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/GameplayTimer/SGameplayTimer.SGameplayTimer")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SGameplayTimer : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027DB3 RID: 163251 RVA: 0x009FC3D7 File Offset: 0x009FA5D7
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SGameplayTimer._ScriptStructPtr != 0) ? SGameplayTimer._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/GameplayTimer/SGameplayTimer.SGameplayTimer", ref SGameplayTimer._ScriptStructPtr);
		}

		// Token: 0x17005F3F RID: 24383
		// (get) Token: 0x06027DB4 RID: 163252 RVA: 0x009FC3FB File Offset: 0x009FA5FB
		// (set) Token: 0x06027DB5 RID: 163253 RVA: 0x009FC40B File Offset: 0x009FA60B
		public unsafe int ID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F40 RID: 24384
		// (get) Token: 0x06027DB6 RID: 163254 RVA: 0x009FC41C File Offset: 0x009FA61C
		// (set) Token: 0x06027DB7 RID: 163255 RVA: 0x009FC42C File Offset: 0x009FA62C
		public unsafe int TimeLength
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F41 RID: 24385
		// (get) Token: 0x06027DB8 RID: 163256 RVA: 0x009FC43D File Offset: 0x009FA63D
		// (set) Token: 0x06027DB9 RID: 163257 RVA: 0x009FC44D File Offset: 0x009FA64D
		public unsafe int TimerFormat
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F42 RID: 24386
		// (get) Token: 0x06027DBA RID: 163258 RVA: 0x009FC45E File Offset: 0x009FA65E
		// (set) Token: 0x06027DBB RID: 163259 RVA: 0x009FC472 File Offset: 0x009FA672
		public unsafe string UIRes
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SGameplayTimer.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SGameplayTimer.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005F43 RID: 24387
		// (get) Token: 0x06027DBC RID: 163260 RVA: 0x009FC487 File Offset: 0x009FA687
		// (set) Token: 0x06027DBD RID: 163261 RVA: 0x009FC497 File Offset: 0x009FA697
		public unsafe int StarEventGroup
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005F44 RID: 24388
		// (get) Token: 0x06027DBE RID: 163262 RVA: 0x009FC4A8 File Offset: 0x009FA6A8
		// (set) Token: 0x06027DBF RID: 163263 RVA: 0x009FC4B8 File Offset: 0x009FA6B8
		public unsafe int EndEventGroup
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005F45 RID: 24389
		// (get) Token: 0x06027DC0 RID: 163264 RVA: 0x009FC4C9 File Offset: 0x009FA6C9
		// (set) Token: 0x06027DC1 RID: 163265 RVA: 0x009FC4DD File Offset: 0x009FA6DD
		public unsafe string EndTips
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SGameplayTimer.__PropertyOffset_6)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SGameplayTimer.__PropertyOffset_6)), value);
			}
		}

		// Token: 0x17005F46 RID: 24390
		// (get) Token: 0x06027DC2 RID: 163266 RVA: 0x009FC4F2 File Offset: 0x009FA6F2
		// (set) Token: 0x06027DC3 RID: 163267 RVA: 0x009FC502 File Offset: 0x009FA702
		public unsafe int ValidRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005F47 RID: 24391
		// (get) Token: 0x06027DC4 RID: 163268 RVA: 0x009FC513 File Offset: 0x009FA713
		// (set) Token: 0x06027DC5 RID: 163269 RVA: 0x009FC523 File Offset: 0x009FA723
		public unsafe int CentralPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SGameplayTimer.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005F48 RID: 24392
		// (get) Token: 0x06027DC6 RID: 163270 RVA: 0x009FC534 File Offset: 0x009FA734
		// (set) Token: 0x06027DC7 RID: 163271 RVA: 0x009FC548 File Offset: 0x009FA748
		public unsafe string RangeTips
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SGameplayTimer.__PropertyOffset_9)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SGameplayTimer.__PropertyOffset_9)), value);
			}
		}

		// Token: 0x06027DC8 RID: 163272 RVA: 0x009FC55D File Offset: 0x009FA75D
		public SGameplayTimer()
		{
		}

		// Token: 0x06027DC9 RID: 163273 RVA: 0x009FC568 File Offset: 0x009FA768
		public SGameplayTimer(int ID, int TimeLength, int TimerFormat, string UIRes, int StarEventGroup, int EndEventGroup, string EndTips, int ValidRange, int CentralPos, string RangeTips)
		{
			this.ID = ID;
			this.TimeLength = TimeLength;
			this.TimerFormat = TimerFormat;
			this.UIRes = UIRes;
			this.StarEventGroup = StarEventGroup;
			this.EndEventGroup = EndEventGroup;
			this.EndTips = EndTips;
			this.ValidRange = ValidRange;
			this.CentralPos = CentralPos;
			this.RangeTips = RangeTips;
		}

		// Token: 0x06027DCA RID: 163274 RVA: 0x009FC5C8 File Offset: 0x009FA7C8
		protected override IntPtr GetUStructPtr()
		{
			return SGameplayTimer.StaticStruct();
		}

		// Token: 0x06027DCB RID: 163275 RVA: 0x009FC5D4 File Offset: 0x009FA7D4
		[NullableContext(2)]
		public SGameplayTimer(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027DCC RID: 163276 RVA: 0x009FC5DE File Offset: 0x009FA7DE
		public SGameplayTimer(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027DCD RID: 163277 RVA: 0x009FC5E9 File Offset: 0x009FA7E9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SGameplayTimer(Pointer, false, true);
		}

		// Token: 0x06027DCE RID: 163278 RVA: 0x009FC5F3 File Offset: 0x009FA7F3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SGameplayTimer(Pointer, MemoryOwner);
		}

		// Token: 0x04014EA8 RID: 85672
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/GameplayTimer/SGameplayTimer.SGameplayTimer";

		// Token: 0x04014EA9 RID: 85673
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EAA RID: 85674
		internal static int __PropertyOffset_0;

		// Token: 0x04014EAB RID: 85675
		internal static int __PropertyOffset_1;

		// Token: 0x04014EAC RID: 85676
		internal static int __PropertyOffset_2;

		// Token: 0x04014EAD RID: 85677
		internal static int __PropertyOffset_3;

		// Token: 0x04014EAE RID: 85678
		internal static int __PropertyOffset_4;

		// Token: 0x04014EAF RID: 85679
		internal static int __PropertyOffset_5;

		// Token: 0x04014EB0 RID: 85680
		internal static int __PropertyOffset_6;

		// Token: 0x04014EB1 RID: 85681
		internal static int __PropertyOffset_7;

		// Token: 0x04014EB2 RID: 85682
		internal static int __PropertyOffset_8;

		// Token: 0x04014EB3 RID: 85683
		internal static int __PropertyOffset_9;
	}
}
