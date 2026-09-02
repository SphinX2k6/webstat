using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Fight.Struct
{
	// Token: 0x02003ED5 RID: 16085
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Fight/Struct/SLockOnPart.SLockOnPart")]
	[UnrealStructLayout(56, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 56)]
	public class SLockOnPart : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027FEF RID: 163823 RVA: 0x009FFF58 File Offset: 0x009FE158
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLockOnPart._ScriptStructPtr != 0) ? SLockOnPart._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Fight/Struct/SLockOnPart.SLockOnPart", ref SLockOnPart._ScriptStructPtr);
		}

		// Token: 0x17005FE8 RID: 24552
		// (get) Token: 0x06027FF0 RID: 163824 RVA: 0x009FFF7C File Offset: 0x009FE17C
		// (set) Token: 0x06027FF1 RID: 163825 RVA: 0x009FFF90 File Offset: 0x009FE190
		public unsafe string BoneName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnPart.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnPart.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17005FE9 RID: 24553
		// (get) Token: 0x06027FF2 RID: 163826 RVA: 0x009FFFA5 File Offset: 0x009FE1A5
		// (set) Token: 0x06027FF3 RID: 163827 RVA: 0x009FFFB5 File Offset: 0x009FE1B5
		public unsafe bool SoftLockValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnPart.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnPart.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FEA RID: 24554
		// (get) Token: 0x06027FF4 RID: 163828 RVA: 0x009FFFC6 File Offset: 0x009FE1C6
		// (set) Token: 0x06027FF5 RID: 163829 RVA: 0x009FFFD6 File Offset: 0x009FE1D6
		public unsafe bool HardLockValid
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLockOnPart.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLockOnPart.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005FEB RID: 24555
		// (get) Token: 0x06027FF6 RID: 163830 RVA: 0x009FFFE7 File Offset: 0x009FE1E7
		// (set) Token: 0x06027FF7 RID: 163831 RVA: 0x009FFFFB File Offset: 0x009FE1FB
		public unsafe string AimPartBoneName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnPart.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnPart.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005FEC RID: 24556
		// (get) Token: 0x06027FF8 RID: 163832 RVA: 0x00A00010 File Offset: 0x009FE210
		// (set) Token: 0x06027FF9 RID: 163833 RVA: 0x00A00024 File Offset: 0x009FE224
		public unsafe string EnablePartName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnPart.__PropertyOffset_4)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SLockOnPart.__PropertyOffset_4)), value);
			}
		}

		// Token: 0x06027FFA RID: 163834 RVA: 0x00A00039 File Offset: 0x009FE239
		public SLockOnPart()
		{
		}

		// Token: 0x06027FFB RID: 163835 RVA: 0x00A00041 File Offset: 0x009FE241
		public SLockOnPart(string BoneName, bool SoftLockValid, bool HardLockValid, string AimPartBoneName, string EnablePartName)
		{
			this.BoneName = BoneName;
			this.SoftLockValid = SoftLockValid;
			this.HardLockValid = HardLockValid;
			this.AimPartBoneName = AimPartBoneName;
			this.EnablePartName = EnablePartName;
		}

		// Token: 0x06027FFC RID: 163836 RVA: 0x00A0006E File Offset: 0x009FE26E
		protected override IntPtr GetUStructPtr()
		{
			return SLockOnPart.StaticStruct();
		}

		// Token: 0x06027FFD RID: 163837 RVA: 0x00A0007A File Offset: 0x009FE27A
		[NullableContext(2)]
		public SLockOnPart(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027FFE RID: 163838 RVA: 0x00A00084 File Offset: 0x009FE284
		public SLockOnPart(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027FFF RID: 163839 RVA: 0x00A0008F File Offset: 0x009FE28F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLockOnPart(Pointer, false, true);
		}

		// Token: 0x06028000 RID: 163840 RVA: 0x00A00099 File Offset: 0x009FE299
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLockOnPart(Pointer, MemoryOwner);
		}

		// Token: 0x04014FF9 RID: 86009
		public const string __ObjectPath = "/Game/Aki/Data/Fight/Struct/SLockOnPart.SLockOnPart";

		// Token: 0x04014FFA RID: 86010
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014FFB RID: 86011
		internal static int __PropertyOffset_0;

		// Token: 0x04014FFC RID: 86012
		internal static int __PropertyOffset_1;

		// Token: 0x04014FFD RID: 86013
		internal static int __PropertyOffset_2;

		// Token: 0x04014FFE RID: 86014
		internal static int __PropertyOffset_3;

		// Token: 0x04014FFF RID: 86015
		internal static int __PropertyOffset_4;
	}
}
