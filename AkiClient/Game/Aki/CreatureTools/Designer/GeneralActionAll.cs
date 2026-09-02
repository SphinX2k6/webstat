using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.CreatureTools.Designer
{
	// Token: 0x02003F2A RID: 16170
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/CreatureTools/Designer/GeneralActionAll.GeneralActionAll")]
	[UnrealStructLayout(48, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 48)]
	public class GeneralActionAll : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060285A3 RID: 165283 RVA: 0x00A08591 File Offset: 0x00A06791
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (GeneralActionAll._ScriptStructPtr != 0) ? GeneralActionAll._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/CreatureTools/Designer/GeneralActionAll.GeneralActionAll", ref GeneralActionAll._ScriptStructPtr);
		}

		// Token: 0x170061EC RID: 25068
		// (get) Token: 0x060285A4 RID: 165284 RVA: 0x00A085B5 File Offset: 0x00A067B5
		// (set) Token: 0x060285A5 RID: 165285 RVA: 0x00A085C9 File Offset: 0x00A067C9
		public unsafe string DefineMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionAll.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionAll.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x170061ED RID: 25069
		// (get) Token: 0x060285A6 RID: 165286 RVA: 0x00A085DE File Offset: 0x00A067DE
		// (set) Token: 0x060285A7 RID: 165287 RVA: 0x00A085F2 File Offset: 0x00A067F2
		public unsafe string DataMd5
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionAll.__PropertyOffset_1)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)GeneralActionAll.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x170061EE RID: 25070
		// (get) Token: 0x060285A8 RID: 165288 RVA: 0x00A08608 File Offset: 0x00A06808
		// (set) Token: 0x060285A9 RID: 165289 RVA: 0x00A0864B File Offset: 0x00A0684B
		public TArray<NPCGeneralAction> Data
		{
			get
			{
				base.FastCheckIsValid();
				TArray<NPCGeneralAction> result;
				if ((result = this._Data) == null)
				{
					result = (this._Data = new TArray<NPCGeneralAction>(base.NativePtr + (IntPtr)GeneralActionAll.__PropertyOffset_2, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Data.CopyAssign(value);
			}
		}

		// Token: 0x060285AA RID: 165290 RVA: 0x00A08659 File Offset: 0x00A06859
		public GeneralActionAll()
		{
		}

		// Token: 0x060285AB RID: 165291 RVA: 0x00A08661 File Offset: 0x00A06861
		public GeneralActionAll(string DefineMd5, string DataMd5, TArray<NPCGeneralAction> Data)
		{
			this.DefineMd5 = DefineMd5;
			this.DataMd5 = DataMd5;
			this.Data = Data;
		}

		// Token: 0x060285AC RID: 165292 RVA: 0x00A0867E File Offset: 0x00A0687E
		protected override IntPtr GetUStructPtr()
		{
			return GeneralActionAll.StaticStruct();
		}

		// Token: 0x060285AD RID: 165293 RVA: 0x00A0868A File Offset: 0x00A0688A
		[NullableContext(2)]
		public GeneralActionAll(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060285AE RID: 165294 RVA: 0x00A08694 File Offset: 0x00A06894
		public GeneralActionAll(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060285AF RID: 165295 RVA: 0x00A0869F File Offset: 0x00A0689F
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new GeneralActionAll(Pointer, false, true);
		}

		// Token: 0x060285B0 RID: 165296 RVA: 0x00A086A9 File Offset: 0x00A068A9
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new GeneralActionAll(Pointer, MemoryOwner);
		}

		// Token: 0x04015398 RID: 86936
		public const string __ObjectPath = "/Game/Aki/CreatureTools/Designer/GeneralActionAll.GeneralActionAll";

		// Token: 0x04015399 RID: 86937
		private static IntPtr _ScriptStructPtr;

		// Token: 0x0401539A RID: 86938
		internal static int __PropertyOffset_0;

		// Token: 0x0401539B RID: 86939
		internal static int __PropertyOffset_1;

		// Token: 0x0401539C RID: 86940
		internal static int __PropertyOffset_2;

		// Token: 0x0401539D RID: 86941
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<NPCGeneralAction> _Data;
	}
}
