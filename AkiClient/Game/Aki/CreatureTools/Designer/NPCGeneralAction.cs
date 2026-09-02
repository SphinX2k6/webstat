using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F2D RID: 16173
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/NPCGeneralAction.NPCGeneralAction")]
	[UnrealStructLayout(112, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 106)]
	public class NPCGeneralAction : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060285E1 RID: 165345 RVA: 0x00A08AB4 File Offset: 0x00A06CB4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (NPCGeneralAction._ScriptStructPtr != 0) ? NPCGeneralAction._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/NPCGeneralAction.NPCGeneralAction", ref NPCGeneralAction._ScriptStructPtr);
		}

		// Token: 0x170061FF RID: 25087
		// (get) Token: 0x060285E2 RID: 165346 RVA: 0x00A08AD8 File Offset: 0x00A06CD8
		// (set) Token: 0x060285E3 RID: 165347 RVA: 0x00A08AE8 File Offset: 0x00A06CE8
		public unsafe int Id
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17006200 RID: 25088
		// (get) Token: 0x060285E4 RID: 165348 RVA: 0x00A08AF9 File Offset: 0x00A06CF9
		// (set) Token: 0x060285E5 RID: 165349 RVA: 0x00A08B0D File Offset: 0x00A06D0D
		public unsafe string ActionType
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)NPCGeneralAction.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)NPCGeneralAction.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17006201 RID: 25089
		// (get) Token: 0x060285E6 RID: 165350 RVA: 0x00A08B24 File Offset: 0x00A06D24
		// (set) Token: 0x060285E7 RID: 165351 RVA: 0x00A08B67 File Offset: 0x00A06D67
		public TMap<string, string> LimitParams
		{
			get
			{
				base.FastCheckIsValid();
				TMap<string, string> result;
				if ((result = this._LimitParams) == null)
				{
					result = (this._LimitParams = new TMap<string, string>(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.LimitParams.CopyAssign(value);
			}
		}

		// Token: 0x17006202 RID: 25090
		// (get) Token: 0x060285E8 RID: 165352 RVA: 0x00A08B75 File Offset: 0x00A06D75
		// (set) Token: 0x060285E9 RID: 165353 RVA: 0x00A08B85 File Offset: 0x00A06D85
		public unsafe bool IsClient
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_3) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_3) = (value ? 1 : 0);
			}
		}

		// Token: 0x17006203 RID: 25091
		// (get) Token: 0x060285EA RID: 165354 RVA: 0x00A08B96 File Offset: 0x00A06D96
		// (set) Token: 0x060285EB RID: 165355 RVA: 0x00A08BA6 File Offset: 0x00A06DA6
		public unsafe bool NeedTick
		{
			get
			{
				return *(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)NPCGeneralAction.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x060285EC RID: 165356 RVA: 0x00A08BB7 File Offset: 0x00A06DB7
		public NPCGeneralAction()
		{
		}

		// Token: 0x060285ED RID: 165357 RVA: 0x00A08BBF File Offset: 0x00A06DBF
		public NPCGeneralAction(int Id, string ActionType, TMap<string, string> LimitParams, bool IsClient, bool NeedTick)
		{
			this.Id = Id;
			this.ActionType = ActionType;
			this.LimitParams = LimitParams;
			this.IsClient = IsClient;
			this.NeedTick = NeedTick;
		}

		// Token: 0x060285EE RID: 165358 RVA: 0x00A08BEC File Offset: 0x00A06DEC
		protected override IntPtr GetUStructPtr()
		{
			return NPCGeneralAction.StaticStruct();
		}

		// Token: 0x060285EF RID: 165359 RVA: 0x00A08BF8 File Offset: 0x00A06DF8
		[NullableContext(2)]
		public NPCGeneralAction(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060285F0 RID: 165360 RVA: 0x00A08C02 File Offset: 0x00A06E02
		public NPCGeneralAction(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060285F1 RID: 165361 RVA: 0x00A08C0D File Offset: 0x00A06E0D
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new NPCGeneralAction(Pointer, false, true);
		}

		// Token: 0x060285F2 RID: 165362 RVA: 0x00A08C17 File Offset: 0x00A06E17
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new NPCGeneralAction(Pointer, MemoryOwner);
		}

		// Token: 0x040153B3 RID: 86963
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/NPCGeneralAction.NPCGeneralAction";

		// Token: 0x040153B4 RID: 86964
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040153B5 RID: 86965
		internal static int __PropertyOffset_0;

		// Token: 0x040153B6 RID: 86966
		internal static int __PropertyOffset_1;

		// Token: 0x040153B7 RID: 86967
		internal static int __PropertyOffset_2;

		// Token: 0x040153B8 RID: 86968
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private TMap<string, string> _LimitParams;

		// Token: 0x040153B9 RID: 86969
		internal static int __PropertyOffset_3;

		// Token: 0x040153BA RID: 86970
		internal static int __PropertyOffset_4;
	}
}
