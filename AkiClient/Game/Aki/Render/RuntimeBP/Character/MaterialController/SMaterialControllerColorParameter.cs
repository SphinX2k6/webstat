using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D80 RID: 15744
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerColorParameter.SMaterialControllerColorParameter")]
	[UnrealStructLayout(1648, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 1648)]
	public class SMaterialControllerColorParameter : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x060266E6 RID: 157414 RVA: 0x009D7A11 File Offset: 0x009D5C11
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerColorParameter._ScriptStructPtr != 0) ? SMaterialControllerColorParameter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerColorParameter.SMaterialControllerColorParameter", ref SMaterialControllerColorParameter._ScriptStructPtr);
		}

		// Token: 0x1700575E RID: 22366
		// (get) Token: 0x060266E7 RID: 157415 RVA: 0x009D7A35 File Offset: 0x009D5C35
		// (set) Token: 0x060266E8 RID: 157416 RVA: 0x009D7A49 File Offset: 0x009D5C49
		public unsafe FName ParameterName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMaterialControllerColorParameter.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMaterialControllerColorParameter.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x1700575F RID: 22367
		// (get) Token: 0x060266E9 RID: 157417 RVA: 0x009D7A60 File Offset: 0x009D5C60
		// (set) Token: 0x060266EA RID: 157418 RVA: 0x009D7AA3 File Offset: 0x009D5CA3
		public SMaterialControllerColorGroup ParameterValue
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerColorGroup result;
				if ((result = this._ParameterValue) == null)
				{
					result = (this._ParameterValue = new SMaterialControllerColorGroup(base.NativePtr + (IntPtr)SMaterialControllerColorParameter.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerColorGroup.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerColorParameter.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x060266EB RID: 157419 RVA: 0x009D7AC4 File Offset: 0x009D5CC4
		public SMaterialControllerColorParameter()
		{
		}

		// Token: 0x060266EC RID: 157420 RVA: 0x009D7ACC File Offset: 0x009D5CCC
		public SMaterialControllerColorParameter(FName ParameterName, SMaterialControllerColorGroup ParameterValue)
		{
			this.ParameterName = ParameterName;
			this.ParameterValue = ParameterValue;
		}

		// Token: 0x060266ED RID: 157421 RVA: 0x009D7AE2 File Offset: 0x009D5CE2
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialControllerColorParameter.StaticStruct();
		}

		// Token: 0x060266EE RID: 157422 RVA: 0x009D7AEE File Offset: 0x009D5CEE
		[NullableContext(2)]
		public SMaterialControllerColorParameter(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x060266EF RID: 157423 RVA: 0x009D7AF8 File Offset: 0x009D5CF8
		public SMaterialControllerColorParameter(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x060266F0 RID: 157424 RVA: 0x009D7B03 File Offset: 0x009D5D03
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialControllerColorParameter(Pointer, false, true);
		}

		// Token: 0x060266F1 RID: 157425 RVA: 0x009D7B0D File Offset: 0x009D5D0D
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialControllerColorParameter(Pointer, MemoryOwner);
		}

		// Token: 0x04013F57 RID: 81751
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerColorParameter.SMaterialControllerColorParameter";

		// Token: 0x04013F58 RID: 81752
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013F59 RID: 81753
		internal static int __PropertyOffset_0;

		// Token: 0x04013F5A RID: 81754
		internal static int __PropertyOffset_1;

		// Token: 0x04013F5B RID: 81755
		[Nullable(2)]
		private SMaterialControllerColorGroup _ParameterValue;
	}
}
