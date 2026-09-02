using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.GamePlay.PathPoints
{
	// Token: 0x02003DCE RID: 15822
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/GamePlay/PathPoints/SAreaBound.SAreaBound")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SAreaBound : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026C11 RID: 158737 RVA: 0x009E141C File Offset: 0x009DF61C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SAreaBound._ScriptStructPtr != 0) ? SAreaBound._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/GamePlay/PathPoints/SAreaBound.SAreaBound", ref SAreaBound._ScriptStructPtr);
		}

		// Token: 0x170058E9 RID: 22761
		// (get) Token: 0x06026C12 RID: 158738 RVA: 0x009E1440 File Offset: 0x009DF640
		// (set) Token: 0x06026C13 RID: 158739 RVA: 0x009E1454 File Offset: 0x009DF654
		public unsafe string AreaName
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SAreaBound.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SAreaBound.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170058EA RID: 22762
		// (get) Token: 0x06026C14 RID: 158740 RVA: 0x009E1469 File Offset: 0x009DF669
		// (set) Token: 0x06026C15 RID: 158741 RVA: 0x009E1479 File Offset: 0x009DF679
		public unsafe float MinX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170058EB RID: 22763
		// (get) Token: 0x06026C16 RID: 158742 RVA: 0x009E148A File Offset: 0x009DF68A
		// (set) Token: 0x06026C17 RID: 158743 RVA: 0x009E149A File Offset: 0x009DF69A
		public unsafe float MinY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_2);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_2) = value;
			}
		}

		// Token: 0x170058EC RID: 22764
		// (get) Token: 0x06026C18 RID: 158744 RVA: 0x009E14AB File Offset: 0x009DF6AB
		// (set) Token: 0x06026C19 RID: 158745 RVA: 0x009E14BB File Offset: 0x009DF6BB
		public unsafe float MinZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x170058ED RID: 22765
		// (get) Token: 0x06026C1A RID: 158746 RVA: 0x009E14CC File Offset: 0x009DF6CC
		// (set) Token: 0x06026C1B RID: 158747 RVA: 0x009E14DC File Offset: 0x009DF6DC
		public unsafe float MaxX
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x170058EE RID: 22766
		// (get) Token: 0x06026C1C RID: 158748 RVA: 0x009E14ED File Offset: 0x009DF6ED
		// (set) Token: 0x06026C1D RID: 158749 RVA: 0x009E14FD File Offset: 0x009DF6FD
		public unsafe float MaxY
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_5);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_5) = value;
			}
		}

		// Token: 0x170058EF RID: 22767
		// (get) Token: 0x06026C1E RID: 158750 RVA: 0x009E150E File Offset: 0x009DF70E
		// (set) Token: 0x06026C1F RID: 158751 RVA: 0x009E151E File Offset: 0x009DF71E
		public unsafe float MaxZ
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_6);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SAreaBound.__PropertyOffset_6) = value;
			}
		}

		// Token: 0x06026C20 RID: 158752 RVA: 0x009E152F File Offset: 0x009DF72F
		public SAreaBound()
		{
		}

		// Token: 0x06026C21 RID: 158753 RVA: 0x009E1537 File Offset: 0x009DF737
		public SAreaBound(string AreaName, float MinX, float MinY, float MinZ, float MaxX, float MaxY, float MaxZ)
		{
			this.AreaName = AreaName;
			this.MinX = MinX;
			this.MinY = MinY;
			this.MinZ = MinZ;
			this.MaxX = MaxX;
			this.MaxY = MaxY;
			this.MaxZ = MaxZ;
		}

		// Token: 0x06026C22 RID: 158754 RVA: 0x009E1574 File Offset: 0x009DF774
		protected override IntPtr GetUStructPtr()
		{
			return SAreaBound.StaticStruct();
		}

		// Token: 0x06026C23 RID: 158755 RVA: 0x009E1580 File Offset: 0x009DF780
		[NullableContext(2)]
		public SAreaBound(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026C24 RID: 158756 RVA: 0x009E158A File Offset: 0x009DF78A
		public SAreaBound(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026C25 RID: 158757 RVA: 0x009E1595 File Offset: 0x009DF795
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SAreaBound(Pointer, false, true);
		}

		// Token: 0x06026C26 RID: 158758 RVA: 0x009E159F File Offset: 0x009DF79F
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SAreaBound(Pointer, MemoryOwner);
		}

		// Token: 0x04014362 RID: 82786
		public const string __ObjectPath = "/Game/Aki/GamePlay/PathPoints/SAreaBound.SAreaBound";

		// Token: 0x04014363 RID: 82787
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014364 RID: 82788
		internal static int __PropertyOffset_0;

		// Token: 0x04014365 RID: 82789
		internal static int __PropertyOffset_1;

		// Token: 0x04014366 RID: 82790
		internal static int __PropertyOffset_2;

		// Token: 0x04014367 RID: 82791
		internal static int __PropertyOffset_3;

		// Token: 0x04014368 RID: 82792
		internal static int __PropertyOffset_4;

		// Token: 0x04014369 RID: 82793
		internal static int __PropertyOffset_5;

		// Token: 0x0401436A RID: 82794
		internal static int __PropertyOffset_6;
	}
}
