using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.NPC.LevelAiBtTree
{
	// Token: 0x02003E60 RID: 15968
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/NPC/LevelAiBtTree/SLeisureActionContext.SLeisureActionContext")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 36)]
	public class SLeisureActionContext : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602769B RID: 161435 RVA: 0x009F156B File Offset: 0x009EF76B
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SLeisureActionContext._ScriptStructPtr != 0) ? SLeisureActionContext._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/NPC/LevelAiBtTree/SLeisureActionContext.SLeisureActionContext", ref SLeisureActionContext._ScriptStructPtr);
		}

		// Token: 0x17005CA0 RID: 23712
		// (get) Token: 0x0602769C RID: 161436 RVA: 0x009F158F File Offset: 0x009EF78F
		// (set) Token: 0x0602769D RID: 161437 RVA: 0x009F159F File Offset: 0x009EF79F
		public unsafe int Type
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005CA1 RID: 23713
		// (get) Token: 0x0602769E RID: 161438 RVA: 0x009F15B0 File Offset: 0x009EF7B0
		// (set) Token: 0x0602769F RID: 161439 RVA: 0x009F15C0 File Offset: 0x009EF7C0
		public unsafe int TargetEntityId
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x17005CA2 RID: 23714
		// (get) Token: 0x060276A0 RID: 161440 RVA: 0x009F15D1 File Offset: 0x009EF7D1
		// (set) Token: 0x060276A1 RID: 161441 RVA: 0x009F15E1 File Offset: 0x009EF7E1
		public unsafe bool UsedBySwitch
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17005CA3 RID: 23715
		// (get) Token: 0x060276A2 RID: 161442 RVA: 0x009F15F2 File Offset: 0x009EF7F2
		// (set) Token: 0x060276A3 RID: 161443 RVA: 0x009F1606 File Offset: 0x009EF806
		public unsafe string MontagePath
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SLeisureActionContext.__PropertyOffset_3)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SLeisureActionContext.__PropertyOffset_3)), value);
			}
		}

		// Token: 0x17005CA4 RID: 23716
		// (get) Token: 0x060276A4 RID: 161444 RVA: 0x009F161B File Offset: 0x009EF81B
		// (set) Token: 0x060276A5 RID: 161445 RVA: 0x009F162B File Offset: 0x009EF82B
		public unsafe int LoopDuration
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_4);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SLeisureActionContext.__PropertyOffset_4) = value;
			}
		}

		// Token: 0x060276A6 RID: 161446 RVA: 0x009F163C File Offset: 0x009EF83C
		public SLeisureActionContext()
		{
		}

		// Token: 0x060276A7 RID: 161447 RVA: 0x009F1644 File Offset: 0x009EF844
		public SLeisureActionContext(int Type, int TargetEntityId, bool UsedBySwitch, string MontagePath, int LoopDuration)
		{
			this.Type = Type;
			this.TargetEntityId = TargetEntityId;
			this.UsedBySwitch = UsedBySwitch;
			this.MontagePath = MontagePath;
			this.LoopDuration = LoopDuration;
		}

		// Token: 0x060276A8 RID: 161448 RVA: 0x009F1671 File Offset: 0x009EF871
		protected override IntPtr GetUStructPtr()
		{
			return SLeisureActionContext.StaticStruct();
		}

		// Token: 0x060276A9 RID: 161449 RVA: 0x009F167D File Offset: 0x009EF87D
		[NullableContext(2)]
		public SLeisureActionContext(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060276AA RID: 161450 RVA: 0x009F1687 File Offset: 0x009EF887
		public SLeisureActionContext(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060276AB RID: 161451 RVA: 0x009F1692 File Offset: 0x009EF892
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SLeisureActionContext(Pointer, false, true);
		}

		// Token: 0x060276AC RID: 161452 RVA: 0x009F169C File Offset: 0x009EF89C
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SLeisureActionContext(Pointer, MemoryOwner);
		}

		// Token: 0x04014A4C RID: 84556
		public const string __ObjectPath = "/Game/Aki/Data/NPC/LevelAiBtTree/SLeisureActionContext.SLeisureActionContext";

		// Token: 0x04014A4D RID: 84557
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014A4E RID: 84558
		internal static int __PropertyOffset_0;

		// Token: 0x04014A4F RID: 84559
		internal static int __PropertyOffset_1;

		// Token: 0x04014A50 RID: 84560
		internal static int __PropertyOffset_2;

		// Token: 0x04014A51 RID: 84561
		internal static int __PropertyOffset_3;

		// Token: 0x04014A52 RID: 84562
		internal static int __PropertyOffset_4;
	}
}
