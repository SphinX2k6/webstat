using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Character.MaterialController
{
	// Token: 0x02003D82 RID: 15746
	[NullableContext(1)]
	[Nullable(0)]
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerFloatParameter.SMaterialControllerFloatParameter")]
	[UnrealStructLayout(448, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 448)]
	public class SMaterialControllerFloatParameter : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x06026700 RID: 157440 RVA: 0x009D7CC1 File Offset: 0x009D5EC1
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (SMaterialControllerFloatParameter._ScriptStructPtr != 0) ? SMaterialControllerFloatParameter._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerFloatParameter.SMaterialControllerFloatParameter", ref SMaterialControllerFloatParameter._ScriptStructPtr);
		}

		// Token: 0x17005763 RID: 22371
		// (get) Token: 0x06026701 RID: 157441 RVA: 0x009D7CE5 File Offset: 0x009D5EE5
		// (set) Token: 0x06026702 RID: 157442 RVA: 0x009D7CF9 File Offset: 0x009D5EF9
		public unsafe FName ParameterName
		{
			get
			{
				return *(base.NativePtr + (IntPtr)SMaterialControllerFloatParameter.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)SMaterialControllerFloatParameter.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17005764 RID: 22372
		// (get) Token: 0x06026703 RID: 157443 RVA: 0x009D7D10 File Offset: 0x009D5F10
		// (set) Token: 0x06026704 RID: 157444 RVA: 0x009D7D53 File Offset: 0x009D5F53
		public SMaterialControllerFloatGroup ParameterValue
		{
			get
			{
				base.FastCheckIsValid();
				SMaterialControllerFloatGroup result;
				if ((result = this._ParameterValue) == null)
				{
					result = (this._ParameterValue = new SMaterialControllerFloatGroup(base.NativePtr + (IntPtr)SMaterialControllerFloatParameter.__PropertyOffset_1, base.MemoryOwner ?? this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SMaterialControllerFloatGroup.StaticStruct(), base.NativePtr + (IntPtr)SMaterialControllerFloatParameter.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x06026705 RID: 157445 RVA: 0x009D7D74 File Offset: 0x009D5F74
		public SMaterialControllerFloatParameter()
		{
		}

		// Token: 0x06026706 RID: 157446 RVA: 0x009D7D7C File Offset: 0x009D5F7C
		public SMaterialControllerFloatParameter(FName ParameterName, SMaterialControllerFloatGroup ParameterValue)
		{
			this.ParameterName = ParameterName;
			this.ParameterValue = ParameterValue;
		}

		// Token: 0x06026707 RID: 157447 RVA: 0x009D7D92 File Offset: 0x009D5F92
		protected override IntPtr GetUStructPtr()
		{
			return SMaterialControllerFloatParameter.StaticStruct();
		}

		// Token: 0x06026708 RID: 157448 RVA: 0x009D7D9E File Offset: 0x009D5F9E
		[NullableContext(2)]
		public SMaterialControllerFloatParameter(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x06026709 RID: 157449 RVA: 0x009D7DA8 File Offset: 0x009D5FA8
		public SMaterialControllerFloatParameter(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602670A RID: 157450 RVA: 0x009D7DB3 File Offset: 0x009D5FB3
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new SMaterialControllerFloatParameter(Pointer, false, true);
		}

		// Token: 0x0602670B RID: 157451 RVA: 0x009D7DBD File Offset: 0x009D5FBD
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new SMaterialControllerFloatParameter(Pointer, MemoryOwner);
		}

		// Token: 0x04013F64 RID: 81764
		public const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Character/MaterialController/SMaterialControllerFloatParameter.SMaterialControllerFloatParameter";

		// Token: 0x04013F65 RID: 81765
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04013F66 RID: 81766
		internal static int __PropertyOffset_0;

		// Token: 0x04013F67 RID: 81767
		internal static int __PropertyOffset_1;

		// Token: 0x04013F68 RID: 81768
		[Nullable(2)]
		private SMaterialControllerFloatGroup _ParameterValue;
	}
}
