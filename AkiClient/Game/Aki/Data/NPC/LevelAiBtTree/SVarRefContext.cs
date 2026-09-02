using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.NPC.LevelAiBtTree
{
	// Token: 0x02003E61 RID: 15969
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/NPC/LevelAiBtTree/SVarRefContext.SVarRefContext")]
	[UnrealStructLayout(104, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 101)]
	public class SVarRefContext : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060276AD RID: 161453 RVA: 0x009F16A5 File Offset: 0x009EF8A5
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SVarRefContext._ScriptStructPtr != 0) ? SVarRefContext._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/NPC/LevelAiBtTree/SVarRefContext.SVarRefContext", ref SVarRefContext._ScriptStructPtr);
		}

		// Token: 0x17005CA5 RID: 23717
		// (get) Token: 0x060276AE RID: 161454 RVA: 0x009F16C9 File Offset: 0x009EF8C9
		// (set) Token: 0x060276AF RID: 161455 RVA: 0x009F16DD File Offset: 0x009EF8DD
		public unsafe string Type
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005CA6 RID: 23718
		// (get) Token: 0x060276B0 RID: 161456 RVA: 0x009F16F2 File Offset: 0x009EF8F2
		// (set) Token: 0x060276B1 RID: 161457 RVA: 0x009F1706 File Offset: 0x009EF906
		public unsafe string VarRefSource
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17005CA7 RID: 23719
		// (get) Token: 0x060276B2 RID: 161458 RVA: 0x009F171B File Offset: 0x009EF91B
		// (set) Token: 0x060276B3 RID: 161459 RVA: 0x009F172F File Offset: 0x009EF92F
		public unsafe string VarRefType
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x17005CA8 RID: 23720
		// (get) Token: 0x060276B4 RID: 161460 RVA: 0x009F1744 File Offset: 0x009EF944
		// (set) Token: 0x060276B5 RID: 161461 RVA: 0x009F1754 File Offset: 0x009EF954
		public unsafe int RefId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17005CA9 RID: 23721
		// (get) Token: 0x060276B6 RID: 161462 RVA: 0x009F1765 File Offset: 0x009EF965
		// (set) Token: 0x060276B7 RID: 161463 RVA: 0x009F1779 File Offset: 0x009EF979
		public unsafe string Key
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x17005CAA RID: 23722
		// (get) Token: 0x060276B8 RID: 161464 RVA: 0x009F178E File Offset: 0x009EF98E
		// (set) Token: 0x060276B9 RID: 161465 RVA: 0x009F17A2 File Offset: 0x009EF9A2
		public unsafe string StringValue
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_5)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SVarRefContext.__PropertyOffset_5)), value);
			}
		}

		// Token: 0x17005CAB RID: 23723
		// (get) Token: 0x060276BA RID: 161466 RVA: 0x009F17B7 File Offset: 0x009EF9B7
		// (set) Token: 0x060276BB RID: 161467 RVA: 0x009F17C7 File Offset: 0x009EF9C7
		public unsafe bool BoolValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_6) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_6) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005CAC RID: 23724
		// (get) Token: 0x060276BC RID: 161468 RVA: 0x009F17D8 File Offset: 0x009EF9D8
		// (set) Token: 0x060276BD RID: 161469 RVA: 0x009F17E8 File Offset: 0x009EF9E8
		public unsafe float FloatValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_7);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_7) = value;
			}
		}

		// Token: 0x17005CAD RID: 23725
		// (get) Token: 0x060276BE RID: 161470 RVA: 0x009F17F9 File Offset: 0x009EF9F9
		// (set) Token: 0x060276BF RID: 161471 RVA: 0x009F1809 File Offset: 0x009EFA09
		public unsafe int IntValue
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_8);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_8) = value;
			}
		}

		// Token: 0x17005CAE RID: 23726
		// (get) Token: 0x060276C0 RID: 161472 RVA: 0x009F181A File Offset: 0x009EFA1A
		// (set) Token: 0x060276C1 RID: 161473 RVA: 0x009F182A File Offset: 0x009EFA2A
		public unsafe bool IsClientVariable
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_9) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SVarRefContext.__PropertyOffset_9) = (value ? 1 : 0);
			}
		}

		// Token: 0x060276C2 RID: 161474 RVA: 0x009F183B File Offset: 0x009EFA3B
		public SVarRefContext()
		{
		}

		// Token: 0x060276C3 RID: 161475 RVA: 0x009F1844 File Offset: 0x009EFA44
		public SVarRefContext(string Type, string VarRefSource, string VarRefType, int RefId, string Key, string StringValue, bool BoolValue, float FloatValue, int IntValue, bool IsClientVariable)
		{
			this.Type = Type;
			this.VarRefSource = VarRefSource;
			this.VarRefType = VarRefType;
			this.RefId = RefId;
			this.Key = Key;
			this.StringValue = StringValue;
			this.BoolValue = BoolValue;
			this.FloatValue = FloatValue;
			this.IntValue = IntValue;
			this.IsClientVariable = IsClientVariable;
		}

		// Token: 0x060276C4 RID: 161476 RVA: 0x009F18A4 File Offset: 0x009EFAA4
		protected override IntPtr GetUStructPtr()
		{
			return SVarRefContext.StaticStruct();
		}

		// Token: 0x060276C5 RID: 161477 RVA: 0x009F18B0 File Offset: 0x009EFAB0
		[NullableContext(2)]
		public SVarRefContext(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060276C6 RID: 161478 RVA: 0x009F18BA File Offset: 0x009EFABA
		public SVarRefContext(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060276C7 RID: 161479 RVA: 0x009F18C5 File Offset: 0x009EFAC5
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SVarRefContext(Pointer, false, true);
		}

		// Token: 0x060276C8 RID: 161480 RVA: 0x009F18CF File Offset: 0x009EFACF
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SVarRefContext(Pointer, MemoryOwner);
		}

		// Token: 0x04014A53 RID: 84563
		public const string __ObjectPath = "/Game/Aki/Data/NPC/LevelAiBtTree/SVarRefContext.SVarRefContext";

		// Token: 0x04014A54 RID: 84564
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A55 RID: 84565
		internal static int __PropertyOffset_0;

		// Token: 0x04014A56 RID: 84566
		internal static int __PropertyOffset_1;

		// Token: 0x04014A57 RID: 84567
		internal static int __PropertyOffset_2;

		// Token: 0x04014A58 RID: 84568
		internal static int __PropertyOffset_3;

		// Token: 0x04014A59 RID: 84569
		internal static int __PropertyOffset_4;

		// Token: 0x04014A5A RID: 84570
		internal static int __PropertyOffset_5;

		// Token: 0x04014A5B RID: 84571
		internal static int __PropertyOffset_6;

		// Token: 0x04014A5C RID: 84572
		internal static int __PropertyOffset_7;

		// Token: 0x04014A5D RID: 84573
		internal static int __PropertyOffset_8;

		// Token: 0x04014A5E RID: 84574
		internal static int __PropertyOffset_9;
	}
}
