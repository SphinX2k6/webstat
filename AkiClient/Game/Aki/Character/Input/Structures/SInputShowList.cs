using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;

namespace AkiClient.Game.Aki.Character.Input.Structures
{
	// Token: 0x020041AA RID: 16810
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/Input/Structures/SInputShowList.SInputShowList")]
	[UnrealStructLayout(16, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 16)]
	public class SInputShowList : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602CA1D RID: 182813 RVA: 0x00AA87C4 File Offset: 0x00AA69C4
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SInputShowList._ScriptStructPtr != 0) ? SInputShowList._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Character/Input/Structures/SInputShowList.SInputShowList", ref SInputShowList._ScriptStructPtr);
		}

		// Token: 0x1700785C RID: 30812
		// (get) Token: 0x0602CA1E RID: 182814 RVA: 0x00AA87E8 File Offset: 0x00AA69E8
		// (set) Token: 0x0602CA1F RID: 182815 RVA: 0x00AA882B File Offset: 0x00AA6A2B
		public TArray<SInputShow> InputShowList
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SInputShow> result;
				if ((result = this._InputShowList) == null)
				{
					result = (this._InputShowList = new TArray<SInputShow>(base.NativePtr + (IntPtr)SInputShowList.__PropertyOffset_0, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				this.InputShowList.CopyAssign(value);
			}
		}

		// Token: 0x0602CA20 RID: 182816 RVA: 0x00AA8839 File Offset: 0x00AA6A39
		public SInputShowList()
		{
		}

		// Token: 0x0602CA21 RID: 182817 RVA: 0x00AA8841 File Offset: 0x00AA6A41
		public SInputShowList(TArray<SInputShow> InputShowList)
		{
			this.InputShowList = InputShowList;
		}

		// Token: 0x0602CA22 RID: 182818 RVA: 0x00AA8850 File Offset: 0x00AA6A50
		protected override IntPtr GetUStructPtr()
		{
			return SInputShowList.StaticStruct();
		}

		// Token: 0x0602CA23 RID: 182819 RVA: 0x00AA885C File Offset: 0x00AA6A5C
		[NullableContext(2)]
		public SInputShowList(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602CA24 RID: 182820 RVA: 0x00AA8866 File Offset: 0x00AA6A66
		public SInputShowList(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602CA25 RID: 182821 RVA: 0x00AA8871 File Offset: 0x00AA6A71
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SInputShowList(Pointer, false, true);
		}

		// Token: 0x0602CA26 RID: 182822 RVA: 0x00AA887B File Offset: 0x00AA6A7B
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SInputShowList(Pointer, MemoryOwner);
		}

		// Token: 0x04018D5B RID: 101723
		public const string __ObjectPath = "/Game/Aki/Character/Input/Structures/SInputShowList.SInputShowList";

		// Token: 0x04018D5C RID: 101724
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04018D5D RID: 101725
		internal static int __PropertyOffset_0;

		// Token: 0x04018D5E RID: 101726
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SInputShow> _InputShowList;
	}
}
