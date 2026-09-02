using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D86 RID: 15750
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerTextureParameter.SMaterialControllerTextureParameter")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class SMaterialControllerTextureParameter : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026728 RID: 157480 RVA: 0x009D8078 File Offset: 0x009D6278
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerTextureParameter._ScriptStructPtr != 0) ? SMaterialControllerTextureParameter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerTextureParameter.SMaterialControllerTextureParameter", ref SMaterialControllerTextureParameter._ScriptStructPtr);
		}

		// Token: 0x17005768 RID: 22376
		// (get) Token: 0x06026729 RID: 157481 RVA: 0x009D809C File Offset: 0x009D629C
		// (set) Token: 0x0602672A RID: 157482 RVA: 0x009D80B0 File Offset: 0x009D62B0
		public unsafe FName ParameterName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMaterialControllerTextureParameter.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMaterialControllerTextureParameter.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005769 RID: 22377
		// (get) Token: 0x0602672B RID: 157483 RVA: 0x009D80C8 File Offset: 0x009D62C8
		// (set) Token: 0x0602672C RID: 157484 RVA: 0x009D810B File Offset: 0x009D630B
		public SMaterialControllerTextureGroup ParameterValue
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerTextureGroup result;
				if ((result = this._ParameterValue) == null)
				{
					result = (this._ParameterValue = new SMaterialControllerTextureGroup(base.NativePtr + (IntPtr)SMaterialControllerTextureParameter.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerTextureGroup.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerTextureParameter.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602672D RID: 157485 RVA: 0x009D812C File Offset: 0x009D632C
		public SMaterialControllerTextureParameter()
		{
		}

		// Token: 0x0602672E RID: 157486 RVA: 0x009D8134 File Offset: 0x009D6334
		public SMaterialControllerTextureParameter(FName ParameterName, SMaterialControllerTextureGroup ParameterValue)
		{
			this.ParameterName = ParameterName;
			this.ParameterValue = ParameterValue;
		}

		// Token: 0x0602672F RID: 157487 RVA: 0x009D814A File Offset: 0x009D634A
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialControllerTextureParameter.StaticStruct();
		}

		// Token: 0x06026730 RID: 157488 RVA: 0x009D8156 File Offset: 0x009D6356
		[NullableContext(2)]
		public SMaterialControllerTextureParameter(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026731 RID: 157489 RVA: 0x009D8160 File Offset: 0x009D6360
		public SMaterialControllerTextureParameter(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x06026732 RID: 157490 RVA: 0x009D816B File Offset: 0x009D636B
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialControllerTextureParameter(Pointer, false, true);
		}

		// Token: 0x06026733 RID: 157491 RVA: 0x009D8175 File Offset: 0x009D6375
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialControllerTextureParameter(Pointer, MemoryOwner);
		}

		// Token: 0x04013F79 RID: 81785
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerTextureParameter.SMaterialControllerTextureParameter";

		// Token: 0x04013F7A RID: 81786
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013F7B RID: 81787
		internal static int __PropertyOffset_0;

		// Token: 0x04013F7C RID: 81788
		internal static int __PropertyOffset_1;

		// Token: 0x04013F7D RID: 81789
		[Nullable(2)]
		private SMaterialControllerTextureGroup _ParameterValue;
	}
}
