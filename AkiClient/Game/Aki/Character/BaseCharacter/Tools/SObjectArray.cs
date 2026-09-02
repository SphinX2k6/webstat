using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter.Tools
{
	// Token: 0x02004291 RID: 17041
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Tools/SObjectArray.SObjectArray")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SObjectArray : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D421 RID: 185377 RVA: 0x00ABB53C File Offset: 0x00AB973C
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SObjectArray._ScriptStructPtr != 0) ? SObjectArray._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/Tools/SObjectArray.SObjectArray", ref SObjectArray._ScriptStructPtr);
		}

		// Token: 0x17007B5B RID: 31579
		// (get) Token: 0x0602D422 RID: 185378 RVA: 0x00ABB560 File Offset: 0x00AB9760
		// (set) Token: 0x0602D423 RID: 185379 RVA: 0x00ABB5A3 File Offset: 0x00AB97A3
		public TArray<UObject> Array
		{
			get
			{
				base.FastCheckIsValid();
				TArray<UObject> result;
				if ((result = this._Array) == null)
				{
					result = (this._Array = new TArray<UObject>(base.NativePtr + (IntPtr)SObjectArray.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.Array.CopyAssign(value);
			}
		}

		// Token: 0x0602D424 RID: 185380 RVA: 0x00ABB5B1 File Offset: 0x00AB97B1
		public SObjectArray()
		{
		}

		// Token: 0x0602D425 RID: 185381 RVA: 0x00ABB5B9 File Offset: 0x00AB97B9
		public SObjectArray(TArray<UObject> Array)
		{
			this.Array = Array;
		}

		// Token: 0x0602D426 RID: 185382 RVA: 0x00ABB5C8 File Offset: 0x00AB97C8
		protected override IntPtr GetUStructPtr()
		{
			return SObjectArray.StaticStruct();
		}

		// Token: 0x0602D427 RID: 185383 RVA: 0x00ABB5D4 File Offset: 0x00AB97D4
		[NullableContext(2)]
		public SObjectArray(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D428 RID: 185384 RVA: 0x00ABB5DE File Offset: 0x00AB97DE
		public SObjectArray(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D429 RID: 185385 RVA: 0x00ABB5E9 File Offset: 0x00AB97E9
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SObjectArray(Pointer, false, true);
		}

		// Token: 0x0602D42A RID: 185386 RVA: 0x00ABB5F3 File Offset: 0x00AB97F3
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SObjectArray(Pointer, MemoryOwner);
		}

		// Token: 0x040195FC RID: 103932
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/Tools/SObjectArray.SObjectArray";

		// Token: 0x040195FD RID: 103933
		private static IntPtr _ScriptStructPtr;

		// Token: 0x040195FE RID: 103934
		internal static int __PropertyOffset_0;

		// Token: 0x040195FF RID: 103935
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<UObject> _Array;
	}
}
