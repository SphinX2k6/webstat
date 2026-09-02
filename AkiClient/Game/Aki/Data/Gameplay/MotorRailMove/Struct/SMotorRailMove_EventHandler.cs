using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.MotorRailMove.Struct
{
	// Token: 0x02003EAE RID: 16046
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_EventHandler.SMotorRailMove_EventHandler")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 80)]
	public class SMotorRailMove_EventHandler : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027D8D RID: 163213 RVA: 0x009FC072 File Offset: 0x009FA272
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMotorRailMove_EventHandler._ScriptStructPtr != 0) ? SMotorRailMove_EventHandler._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_EventHandler.SMotorRailMove_EventHandler", ref SMotorRailMove_EventHandler._ScriptStructPtr);
		}

		// Token: 0x17005F3B RID: 24379
		// (get) Token: 0x06027D8E RID: 163214 RVA: 0x009FC098 File Offset: 0x009FA298
		// (set) Token: 0x06027D8F RID: 163215 RVA: 0x009FC0DB File Offset: 0x009FA2DB
		public TMap<int, bool> ModifyCues
		{
			get
			{
				base.FastCheckIsValid();
				TMap<int, bool> result;
				if ((result = this._ModifyCues) == null)
				{
					result = (this._ModifyCues = new TMap<int, bool>(base.NativePtr + (IntPtr)SMotorRailMove_EventHandler.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.ModifyCues.CopyAssign(value);
			}
		}

		// Token: 0x06027D90 RID: 163216 RVA: 0x009FC0E9 File Offset: 0x009FA2E9
		public SMotorRailMove_EventHandler()
		{
		}

		// Token: 0x06027D91 RID: 163217 RVA: 0x009FC0F1 File Offset: 0x009FA2F1
		public SMotorRailMove_EventHandler(TMap<int, bool> ModifyCues)
		{
			this.ModifyCues = ModifyCues;
		}

		// Token: 0x06027D92 RID: 163218 RVA: 0x009FC100 File Offset: 0x009FA300
		protected override IntPtr GetUStructPtr()
		{
			return SMotorRailMove_EventHandler.StaticStruct();
		}

		// Token: 0x06027D93 RID: 163219 RVA: 0x009FC10C File Offset: 0x009FA30C
		[NullableContext(2)]
		public SMotorRailMove_EventHandler(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027D94 RID: 163220 RVA: 0x009FC116 File Offset: 0x009FA316
		public SMotorRailMove_EventHandler(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027D95 RID: 163221 RVA: 0x009FC121 File Offset: 0x009FA321
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMotorRailMove_EventHandler(Pointer, false, true);
		}

		// Token: 0x06027D96 RID: 163222 RVA: 0x009FC12B File Offset: 0x009FA32B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMotorRailMove_EventHandler(Pointer, MemoryOwner);
		}

		// Token: 0x04014E8A RID: 85642
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/MotorRailMove/Struct/SMotorRailMove_EventHandler.SMotorRailMove_EventHandler";

		// Token: 0x04014E8B RID: 85643
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014E8C RID: 85644
		internal static int __PropertyOffset_0;

		// Token: 0x04014E8D RID: 85645
		[Nullable(2)]
		private TMap<int, bool> _ModifyCues;
	}
}
