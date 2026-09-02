using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Data.Gameplay.InformationLib
{
	// Token: 0x02003EB3 RID: 16051
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Gameplay/InformationLib/SInfoGroup.SInfoGroup")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SInfoGroup : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06027DA5 RID: 163237 RVA: 0x009FC2BC File Offset: 0x009FA4BC
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInfoGroup._ScriptStructPtr != 0) ? SInfoGroup._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Data/Gameplay/InformationLib/SInfoGroup.SInfoGroup", ref SInfoGroup._ScriptStructPtr);
		}

		// Token: 0x17005F3C RID: 24380
		// (get) Token: 0x06027DA6 RID: 163238 RVA: 0x009FC2E0 File Offset: 0x009FA4E0
		// (set) Token: 0x06027DA7 RID: 163239 RVA: 0x009FC2F0 File Offset: 0x009FA4F0
		public unsafe long GroupID
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SInfoGroup.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SInfoGroup.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005F3D RID: 24381
		// (get) Token: 0x06027DA8 RID: 163240 RVA: 0x009FC304 File Offset: 0x009FA504
		// (set) Token: 0x06027DA9 RID: 163241 RVA: 0x009FC347 File Offset: 0x009FA547
		public TArray<long> InfoGroup
		{
			get
			{
				base.FastCheckIsValid();
				TArray<long> result;
				if ((result = this._InfoGroup) == null)
				{
					result = (this._InfoGroup = new TArray<long>(base.NativePtr + (IntPtr)SInfoGroup.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.InfoGroup.CopyAssign(value);
			}
		}

		// Token: 0x17005F3E RID: 24382
		// (get) Token: 0x06027DAA RID: 163242 RVA: 0x009FC355 File Offset: 0x009FA555
		// (set) Token: 0x06027DAB RID: 163243 RVA: 0x009FC369 File Offset: 0x009FA569
		public unsafe string Tips
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)SInfoGroup.__PropertyOffset_2)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)SInfoGroup.__PropertyOffset_2)), value);
			}
		}

		// Token: 0x06027DAC RID: 163244 RVA: 0x009FC37E File Offset: 0x009FA57E
		public SInfoGroup()
		{
		}

		// Token: 0x06027DAD RID: 163245 RVA: 0x009FC386 File Offset: 0x009FA586
		public SInfoGroup(long GroupID, TArray<long> InfoGroup, string Tips)
		{
			this.GroupID = GroupID;
			this.InfoGroup = InfoGroup;
			this.Tips = Tips;
		}

		// Token: 0x06027DAE RID: 163246 RVA: 0x009FC3A3 File Offset: 0x009FA5A3
		protected override IntPtr GetUStructPtr()
		{
			return SInfoGroup.StaticStruct();
		}

		// Token: 0x06027DAF RID: 163247 RVA: 0x009FC3AF File Offset: 0x009FA5AF
		[NullableContext(2)]
		public SInfoGroup(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06027DB0 RID: 163248 RVA: 0x009FC3B9 File Offset: 0x009FA5B9
		public SInfoGroup(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06027DB1 RID: 163249 RVA: 0x009FC3C4 File Offset: 0x009FA5C4
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInfoGroup(Pointer, false, true);
		}

		// Token: 0x06027DB2 RID: 163250 RVA: 0x009FC3CE File Offset: 0x009FA5CE
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInfoGroup(Pointer, MemoryOwner);
		}

		// Token: 0x04014EA2 RID: 85666
		public const string __ObjectPath = "/Game/Aki/Data/Gameplay/InformationLib/SInfoGroup.SInfoGroup";

		// Token: 0x04014EA3 RID: 85667
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04014EA4 RID: 85668
		internal static int __PropertyOffset_0;

		// Token: 0x04014EA5 RID: 85669
		internal static int __PropertyOffset_1;

		// Token: 0x04014EA6 RID: 85670
		[Nullable(2)]
		private TArray<long> _InfoGroup;

		// Token: 0x04014EA7 RID: 85671
		internal static int __PropertyOffset_2;
	}
}
