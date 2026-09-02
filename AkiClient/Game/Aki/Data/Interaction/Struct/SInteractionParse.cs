using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Interaction.Struct
{
	// Token: 0x02003E89 RID: 16009
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Data/Interaction/Struct/SInteractionParse.SInteractionParse")]
	[UnrealStructLayout(24, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 24)]
	public class SInteractionParse : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027A8E RID: 162446 RVA: 0x009F75B4 File Offset: 0x009F57B4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInteractionParse._ScriptStructPtr != 0) ? SInteractionParse._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Interaction/Struct/SInteractionParse.SInteractionParse", ref SInteractionParse._ScriptStructPtr);
		}

		// Token: 0x17005E29 RID: 24105
		// (get) Token: 0x06027A8F RID: 162447 RVA: 0x009F75D8 File Offset: 0x009F57D8
		// (set) Token: 0x06027A90 RID: 162448 RVA: 0x009F75E8 File Offset: 0x009F57E8
		public unsafe int Value
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInteractionParse.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInteractionParse.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005E2A RID: 24106
		// (get) Token: 0x06027A91 RID: 162449 RVA: 0x009F75F9 File Offset: 0x009F57F9
		// (set) Token: 0x06027A92 RID: 162450 RVA: 0x009F760D File Offset: 0x009F580D
		public unsafe string Desc
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInteractionParse.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInteractionParse.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x06027A93 RID: 162451 RVA: 0x009F7622 File Offset: 0x009F5822
		public SInteractionParse()
		{
		}

		// Token: 0x06027A94 RID: 162452 RVA: 0x009F762A File Offset: 0x009F582A
		public SInteractionParse(int Value, string Desc)
		{
			this.Value = Value;
			this.Desc = Desc;
		}

		// Token: 0x06027A95 RID: 162453 RVA: 0x009F7640 File Offset: 0x009F5840
		protected override IntPtr GetUStructPtr()
		{
			return SInteractionParse.StaticStruct();
		}

		// Token: 0x06027A96 RID: 162454 RVA: 0x009F764C File Offset: 0x009F584C
		[NullableContext(2)]
		public SInteractionParse(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027A97 RID: 162455 RVA: 0x009F7656 File Offset: 0x009F5856
		public SInteractionParse(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027A98 RID: 162456 RVA: 0x009F7661 File Offset: 0x009F5861
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInteractionParse(Pointer, false, true);
		}

		// Token: 0x06027A99 RID: 162457 RVA: 0x009F766B File Offset: 0x009F586B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInteractionParse(Pointer, MemoryOwner);
		}

		// Token: 0x04014CC0 RID: 85184
		public const string __ObjectPath = "/Game/Aki/Data/Interaction/Struct/SInteractionParse.SInteractionParse";

		// Token: 0x04014CC1 RID: 85185
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014CC2 RID: 85186
		internal static int __PropertyOffset_0;

		// Token: 0x04014CC3 RID: 85187
		internal static int __PropertyOffset_1;
	}
}
