using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200425F RID: 16991
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/SFloatPayload.SFloatPayload")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SFloatPayload : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602D05E RID: 184414 RVA: 0x00AB5A59 File Offset: 0x00AB3C59
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SFloatPayload._ScriptStructPtr != 0) ? SFloatPayload._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/BaseCharacter/SFloatPayload.SFloatPayload", ref SFloatPayload._ScriptStructPtr);
		}

		// Token: 0x17007A2A RID: 31274
		// (get) Token: 0x0602D05F RID: 184415 RVA: 0x00AB5A80 File Offset: 0x00AB3C80
		// (set) Token: 0x0602D060 RID: 184416 RVA: 0x00AB5AC3 File Offset: 0x00AB3CC3
		public TArray<float> FloatArray
		{
			get
			{
				base.FastCheckIsValid();
				TArray<float> result;
				if ((result = this._FloatArray) == null)
				{
					result = (this._FloatArray = new TArray<float>(base.NativePtr + (IntPtr)SFloatPayload.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.FloatArray.CopyAssign(value);
			}
		}

		// Token: 0x0602D061 RID: 184417 RVA: 0x00AB5AD1 File Offset: 0x00AB3CD1
		public SFloatPayload()
		{
		}

		// Token: 0x0602D062 RID: 184418 RVA: 0x00AB5AD9 File Offset: 0x00AB3CD9
		public SFloatPayload(TArray<float> FloatArray)
		{
			this.FloatArray = FloatArray;
		}

		// Token: 0x0602D063 RID: 184419 RVA: 0x00AB5AE8 File Offset: 0x00AB3CE8
		protected override IntPtr GetUStructPtr()
		{
			return SFloatPayload.StaticStruct();
		}

		// Token: 0x0602D064 RID: 184420 RVA: 0x00AB5AF4 File Offset: 0x00AB3CF4
		[NullableContext(2)]
		public SFloatPayload(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602D065 RID: 184421 RVA: 0x00AB5AFE File Offset: 0x00AB3CFE
		public SFloatPayload(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602D066 RID: 184422 RVA: 0x00AB5B09 File Offset: 0x00AB3D09
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SFloatPayload(Pointer, false, true);
		}

		// Token: 0x0602D067 RID: 184423 RVA: 0x00AB5B13 File Offset: 0x00AB3D13
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SFloatPayload(Pointer, MemoryOwner);
		}

		// Token: 0x04019404 RID: 103428
		public const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/SFloatPayload.SFloatPayload";

		// Token: 0x04019405 RID: 103429
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019406 RID: 103430
		internal static int __PropertyOffset_0;

		// Token: 0x04019407 RID: 103431
		[Nullable(2)]
		private TArray<float> _FloatArray;
	}
}
