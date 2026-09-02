using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.PathLine
{
	// Token: 0x02003E53 RID: 15955
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/PathLine/DTS_PathLine.DTS_PathLine")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class DTS_PathLine : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027602 RID: 161282 RVA: 0x009F0718 File Offset: 0x009EE918
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (DTS_PathLine._ScriptStructPtr != 0) ? DTS_PathLine._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/PathLine/DTS_PathLine.DTS_PathLine", ref DTS_PathLine._ScriptStructPtr);
		}

		// Token: 0x17005C77 RID: 23671
		// (get) Token: 0x06027603 RID: 161283 RVA: 0x009F073C File Offset: 0x009EE93C
		// (set) Token: 0x06027604 RID: 161284 RVA: 0x009F0750 File Offset: 0x009EE950
		[Nullable(new byte[]
		{
			0,
			1
		})]
		public unsafe TSubclassOf<BP_BasePathLine_C> splinepath
		{
			[return: Nullable(new byte[]
			{
				0,
				1
			})]
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_0);
			}
			[param: Nullable(new byte[]
			{
				0,
				1
			})]
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005C78 RID: 23672
		// (get) Token: 0x06027605 RID: 161285 RVA: 0x009F0765 File Offset: 0x009EE965
		// (set) Token: 0x06027606 RID: 161286 RVA: 0x009F0775 File Offset: 0x009EE975
		public unsafe bool AutoMove
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C79 RID: 23673
		// (get) Token: 0x06027607 RID: 161287 RVA: 0x009F0786 File Offset: 0x009EE986
		// (set) Token: 0x06027608 RID: 161288 RVA: 0x009F0796 File Offset: 0x009EE996
		public unsafe bool NeedFollow
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C7A RID: 23674
		// (get) Token: 0x06027609 RID: 161289 RVA: 0x009F07A7 File Offset: 0x009EE9A7
		// (set) Token: 0x0602760A RID: 161290 RVA: 0x009F07B7 File Offset: 0x009EE9B7
		public unsafe bool Back
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C7B RID: 23675
		// (get) Token: 0x0602760B RID: 161291 RVA: 0x009F07C8 File Offset: 0x009EE9C8
		// (set) Token: 0x0602760C RID: 161292 RVA: 0x009F07D8 File Offset: 0x009EE9D8
		public unsafe bool WaitForPlayer
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005C7C RID: 23676
		// (get) Token: 0x0602760D RID: 161293 RVA: 0x009F07E9 File Offset: 0x009EE9E9
		// (set) Token: 0x0602760E RID: 161294 RVA: 0x009F07F9 File Offset: 0x009EE9F9
		public unsafe float MoveSpeed
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x17005C7D RID: 23677
		// (get) Token: 0x0602760F RID: 161295 RVA: 0x009F080A File Offset: 0x009EEA0A
		// (set) Token: 0x06027610 RID: 161296 RVA: 0x009F081A File Offset: 0x009EEA1A
		public unsafe int CurrentSlinePoint
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x17005C7E RID: 23678
		// (get) Token: 0x06027611 RID: 161297 RVA: 0x009F082B File Offset: 0x009EEA2B
		// (set) Token: 0x06027612 RID: 161298 RVA: 0x009F083B File Offset: 0x009EEA3B
		public unsafe float ActivateRange
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DTS_PathLine.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005C7F RID: 23679
		// (get) Token: 0x06027613 RID: 161299 RVA: 0x009F084C File Offset: 0x009EEA4C
		// (set) Token: 0x06027614 RID: 161300 RVA: 0x009F0860 File Offset: 0x009EEA60
		public unsafe string 备注
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)DTS_PathLine.__PropertyOffset_8)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)DTS_PathLine.__PropertyOffset_8)), value);
			}
		}

		// Token: 0x06027615 RID: 161301 RVA: 0x009F0875 File Offset: 0x009EEA75
		public DTS_PathLine()
		{
		}

		// Token: 0x06027616 RID: 161302 RVA: 0x009F0880 File Offset: 0x009EEA80
		public DTS_PathLine([Nullable(new byte[]
		{
			0,
			1
		})] TSubclassOf<BP_BasePathLine_C> splinepath, bool AutoMove, bool NeedFollow, bool Back, bool WaitForPlayer, float MoveSpeed, int CurrentSlinePoint, float ActivateRange, string 备注)
		{
			this.splinepath = splinepath;
			this.AutoMove = AutoMove;
			this.NeedFollow = NeedFollow;
			this.Back = Back;
			this.WaitForPlayer = WaitForPlayer;
			this.MoveSpeed = MoveSpeed;
			this.CurrentSlinePoint = CurrentSlinePoint;
			this.ActivateRange = ActivateRange;
			this.备注 = 备注;
		}

		// Token: 0x06027617 RID: 161303 RVA: 0x009F08D8 File Offset: 0x009EEAD8
		protected override IntPtr GetUStructPtr()
		{
			return DTS_PathLine.StaticStruct();
		}

		// Token: 0x06027618 RID: 161304 RVA: 0x009F08E4 File Offset: 0x009EEAE4
		[NullableContext(2)]
		public DTS_PathLine(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027619 RID: 161305 RVA: 0x009F08EE File Offset: 0x009EEAEE
		public DTS_PathLine(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602761A RID: 161306 RVA: 0x009F08F9 File Offset: 0x009EEAF9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new DTS_PathLine(Pointer, false, true);
		}

		// Token: 0x0602761B RID: 161307 RVA: 0x009F0903 File Offset: 0x009EEB03
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new DTS_PathLine(Pointer, MemoryOwner);
		}

		// Token: 0x040149DE RID: 84446
		public const string __ObjectPath = "/Game/Aki/Data/PathLine/DTS_PathLine.DTS_PathLine";

		// Token: 0x040149DF RID: 84447
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040149E0 RID: 84448
		internal static int __PropertyOffset_0;

		// Token: 0x040149E1 RID: 84449
		internal static int __PropertyOffset_1;

		// Token: 0x040149E2 RID: 84450
		internal static int __PropertyOffset_2;

		// Token: 0x040149E3 RID: 84451
		internal static int __PropertyOffset_3;

		// Token: 0x040149E4 RID: 84452
		internal static int __PropertyOffset_4;

		// Token: 0x040149E5 RID: 84453
		internal static int __PropertyOffset_5;

		// Token: 0x040149E6 RID: 84454
		internal static int __PropertyOffset_6;

		// Token: 0x040149E7 RID: 84455
		internal static int __PropertyOffset_7;

		// Token: 0x040149E8 RID: 84456
		internal static int __PropertyOffset_8;
	}
}
