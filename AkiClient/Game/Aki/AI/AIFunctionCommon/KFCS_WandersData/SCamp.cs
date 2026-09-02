using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.AI.AIFunctionCommon.KFCS_WandersData
{
	// Token: 0x02004393 RID: 17299
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SCamp.SCamp")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SCamp : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DDC6 RID: 187846 RVA: 0x00ACE722 File Offset: 0x00ACC922
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SCamp._ScriptStructPtr != 0) ? SCamp._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SCamp.SCamp", ref SCamp._ScriptStructPtr);
		}

		// Token: 0x17007DC6 RID: 32198
		// (get) Token: 0x0602DDC7 RID: 187847 RVA: 0x00ACE748 File Offset: 0x00ACC948
		// (set) Token: 0x0602DDC8 RID: 187848 RVA: 0x00ACE78B File Offset: 0x00ACC98B
		public TArray<int> Value
		{
			get
			{
				base.FastCheckIsValid();
				TArray<int> result;
				if ((result = this._Value) == null)
				{
					result = (this._Value = new TArray<int>(base.NativePtr + (IntPtr)SCamp.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Value.CopyAssign(value);
			}
		}

		// Token: 0x0602DDC9 RID: 187849 RVA: 0x00ACE799 File Offset: 0x00ACC999
		public SCamp()
		{
		}

		// Token: 0x0602DDCA RID: 187850 RVA: 0x00ACE7A1 File Offset: 0x00ACC9A1
		public SCamp(TArray<int> Value)
		{
			this.Value = Value;
		}

		// Token: 0x0602DDCB RID: 187851 RVA: 0x00ACE7B0 File Offset: 0x00ACC9B0
		protected override IntPtr GetUStructPtr()
		{
			return SCamp.StaticStruct();
		}

		// Token: 0x0602DDCC RID: 187852 RVA: 0x00ACE7BC File Offset: 0x00ACC9BC
		[NullableContext(2)]
		public SCamp(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DDCD RID: 187853 RVA: 0x00ACE7C6 File Offset: 0x00ACC9C6
		public SCamp(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DDCE RID: 187854 RVA: 0x00ACE7D1 File Offset: 0x00ACC9D1
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SCamp(Pointer, false, true);
		}

		// Token: 0x0602DDCF RID: 187855 RVA: 0x00ACE7DB File Offset: 0x00ACC9DB
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SCamp(Pointer, MemoryOwner);
		}

		// Token: 0x04019E97 RID: 106135
		public const string __ObjectPath = "/Game/Aki/AI/AIFunctionCommon/KFCS_WandersData/SCamp.SCamp";

		// Token: 0x04019E98 RID: 106136
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019E99 RID: 106137
		internal static int __PropertyOffset_0;

		// Token: 0x04019E9A RID: 106138
		[Nullable(2)]
		private TArray<int> _Value;
	}
}
