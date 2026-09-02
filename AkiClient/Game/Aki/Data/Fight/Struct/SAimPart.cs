using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003EC7 RID: 16071
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SAimPart.SAimPart")]
	[UnrealStructLayout(64, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 64)]
	public class SAimPart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027EC1 RID: 163521 RVA: 0x009FE110 File Offset: 0x009FC310
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAimPart._ScriptStructPtr != 0) ? SAimPart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SAimPart.SAimPart", ref SAimPart._ScriptStructPtr);
		}

		// Token: 0x17005F88 RID: 24456
		// (get) Token: 0x06027EC2 RID: 163522 RVA: 0x009FE134 File Offset: 0x009FC334
		// (set) Token: 0x06027EC3 RID: 163523 RVA: 0x009FE148 File Offset: 0x009FC348
		public unsafe string BoneName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAimPart.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAimPart.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005F89 RID: 24457
		// (get) Token: 0x06027EC4 RID: 163524 RVA: 0x009FE15D File Offset: 0x009FC35D
		// (set) Token: 0x06027EC5 RID: 163525 RVA: 0x009FE171 File Offset: 0x009FC371
		public unsafe FVector Offset
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005F8A RID: 24458
		// (get) Token: 0x06027EC6 RID: 163526 RVA: 0x009FE186 File Offset: 0x009FC386
		// (set) Token: 0x06027EC7 RID: 163527 RVA: 0x009FE196 File Offset: 0x009FC396
		public unsafe float RadiusIn
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x17005F8B RID: 24459
		// (get) Token: 0x06027EC8 RID: 163528 RVA: 0x009FE1A7 File Offset: 0x009FC3A7
		// (set) Token: 0x06027EC9 RID: 163529 RVA: 0x009FE1B7 File Offset: 0x009FC3B7
		public unsafe float RadiusOut
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005F8C RID: 24460
		// (get) Token: 0x06027ECA RID: 163530 RVA: 0x009FE1C8 File Offset: 0x009FC3C8
		// (set) Token: 0x06027ECB RID: 163531 RVA: 0x009FE1D8 File Offset: 0x009FC3D8
		public unsafe float RadiusOutOnStart
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x17005F8D RID: 24461
		// (get) Token: 0x06027ECC RID: 163532 RVA: 0x009FE1E9 File Offset: 0x009FC3E9
		// (set) Token: 0x06027ECD RID: 163533 RVA: 0x009FE1F9 File Offset: 0x009FC3F9
		public unsafe float MobileCorrect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005F8E RID: 24462
		// (get) Token: 0x06027ECE RID: 163534 RVA: 0x009FE20A File Offset: 0x009FC40A
		// (set) Token: 0x06027ECF RID: 163535 RVA: 0x009FE21A File Offset: 0x009FC41A
		public unsafe float GamePadCorrect
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAimPart.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005F8F RID: 24463
		// (get) Token: 0x06027ED0 RID: 163536 RVA: 0x009FE22B File Offset: 0x009FC42B
		// (set) Token: 0x06027ED1 RID: 163537 RVA: 0x009FE23F File Offset: 0x009FC43F
		public unsafe string 忽略的骨骼碰撞
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAimPart.__PropertyOffset_7)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAimPart.__PropertyOffset_7)), value);
			}
		}

		// Token: 0x06027ED2 RID: 163538 RVA: 0x009FE254 File Offset: 0x009FC454
		public SAimPart()
		{
		}

		// Token: 0x06027ED3 RID: 163539 RVA: 0x009FE25C File Offset: 0x009FC45C
		public SAimPart(string BoneName, FVector Offset, float RadiusIn, float RadiusOut, float RadiusOutOnStart, float MobileCorrect, float GamePadCorrect, string 忽略的骨骼碰撞)
		{
			this.BoneName = BoneName;
			this.Offset = Offset;
			this.RadiusIn = RadiusIn;
			this.RadiusOut = RadiusOut;
			this.RadiusOutOnStart = RadiusOutOnStart;
			this.MobileCorrect = MobileCorrect;
			this.GamePadCorrect = GamePadCorrect;
			this.忽略的骨骼碰撞 = 忽略的骨骼碰撞;
		}

		// Token: 0x06027ED4 RID: 163540 RVA: 0x009FE2AC File Offset: 0x009FC4AC
		protected override IntPtr GetUStructPtr()
		{
			return SAimPart.StaticStruct();
		}

		// Token: 0x06027ED5 RID: 163541 RVA: 0x009FE2B8 File Offset: 0x009FC4B8
		[NullableContext(2)]
		public SAimPart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027ED6 RID: 163542 RVA: 0x009FE2C2 File Offset: 0x009FC4C2
		public SAimPart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027ED7 RID: 163543 RVA: 0x009FE2CD File Offset: 0x009FC4CD
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAimPart(Pointer, false, true);
		}

		// Token: 0x06027ED8 RID: 163544 RVA: 0x009FE2D7 File Offset: 0x009FC4D7
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAimPart(Pointer, MemoryOwner);
		}

		// Token: 0x04014F5C RID: 85852
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SAimPart.SAimPart";

		// Token: 0x04014F5D RID: 85853
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014F5E RID: 85854
		internal static int __PropertyOffset_0;

		// Token: 0x04014F5F RID: 85855
		internal static int __PropertyOffset_1;

		// Token: 0x04014F60 RID: 85856
		internal static int __PropertyOffset_2;

		// Token: 0x04014F61 RID: 85857
		internal static int __PropertyOffset_3;

		// Token: 0x04014F62 RID: 85858
		internal static int __PropertyOffset_4;

		// Token: 0x04014F63 RID: 85859
		internal static int __PropertyOffset_5;

		// Token: 0x04014F64 RID: 85860
		internal static int __PropertyOffset_6;

		// Token: 0x04014F65 RID: 85861
		internal static int __PropertyOffset_7;
	}
}
