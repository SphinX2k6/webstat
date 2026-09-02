using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x0200437C RID: 17276
	[HasGetTypeHash]
	[UnrealObjectPath("/Game/Aki/Audio/BP_SAudioCondition.BP_SAudioCondition")]
	[UnrealStructLayout(40, 8, UnrealReflectionPropertyTypeCode.UnrealScriptStructProxy, PropertiesSize = 40)]
	public class BP_SAudioCondition : UnrealUserDefinedStructProxy, IUnrealScriptStructProxy, IUnrealScriptStruct, IUnrealObject
	{
		// Token: 0x0602DC8E RID: 187534 RVA: 0x00ACBE6A File Offset: 0x00ACA06A
		public static UScriptStructStackOnlyPtr StaticStruct()
		{
			return (BP_SAudioCondition._ScriptStructPtr != 0) ? BP_SAudioCondition._ScriptStructPtr : UObjectGlobals.StaticLoadScriptStruct("/Game/Aki/Audio/BP_SAudioCondition.BP_SAudioCondition", ref BP_SAudioCondition._ScriptStructPtr);
		}

		// Token: 0x17007D6C RID: 32108
		// (get) Token: 0x0602DC8F RID: 187535 RVA: 0x00ACBE8E File Offset: 0x00ACA08E
		// (set) Token: 0x0602DC90 RID: 187536 RVA: 0x00ACBEA2 File Offset: 0x00ACA0A2
		public unsafe TEnumAsByte<BP_EAudioCondition> 条件标签
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SAudioCondition.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SAudioCondition.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007D6D RID: 32109
		// (get) Token: 0x0602DC91 RID: 187537 RVA: 0x00ACBEB7 File Offset: 0x00ACA0B7
		// (set) Token: 0x0602DC92 RID: 187538 RVA: 0x00ACBECB File Offset: 0x00ACA0CB
		[Nullable(1)]
		public unsafe string 条件字段
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SAudioCondition.__PropertyOffset_1)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SAudioCondition.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x17007D6E RID: 32110
		// (get) Token: 0x0602DC93 RID: 187539 RVA: 0x00ACBEE0 File Offset: 0x00ACA0E0
		// (set) Token: 0x0602DC94 RID: 187540 RVA: 0x00ACBEF4 File Offset: 0x00ACA0F4
		[Nullable(2)]
		public unsafe UAkAudioEvent 进入音效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SAudioCondition.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SAudioCondition.__PropertyOffset_2, value);
			}
		}

		// Token: 0x17007D6F RID: 32111
		// (get) Token: 0x0602DC95 RID: 187541 RVA: 0x00ACBF09 File Offset: 0x00ACA109
		// (set) Token: 0x0602DC96 RID: 187542 RVA: 0x00ACBF1D File Offset: 0x00ACA11D
		[Nullable(2)]
		public unsafe UAkAudioEvent 离开音效
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<UAkAudioEvent>(base.NativePtr / (IntPtr)sizeof(void*) + BP_SAudioCondition.__PropertyOffset_3);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_SAudioCondition.__PropertyOffset_3, value);
			}
		}

		// Token: 0x0602DC97 RID: 187543 RVA: 0x00ACBF32 File Offset: 0x00ACA132
		public BP_SAudioCondition()
		{
		}

		// Token: 0x0602DC98 RID: 187544 RVA: 0x00ACBF3A File Offset: 0x00ACA13A
		[NullableContext(1)]
		public BP_SAudioCondition([Nullable(0)] TEnumAsByte<BP_EAudioCondition> 条件标签, string 条件字段, UAkAudioEvent 进入音效, UAkAudioEvent 离开音效)
		{
			this.条件标签 = 条件标签;
			this.条件字段 = 条件字段;
			this.进入音效 = 进入音效;
			this.离开音效 = 离开音效;
		}

		// Token: 0x0602DC99 RID: 187545 RVA: 0x00ACBF5F File Offset: 0x00ACA15F
		protected override IntPtr GetUStructPtr()
		{
			return BP_SAudioCondition.StaticStruct();
		}

		// Token: 0x0602DC9A RID: 187546 RVA: 0x00ACBF6B File Offset: 0x00ACA16B
		[NullableContext(2)]
		public BP_SAudioCondition(IntPtr NativePtr, UnrealObject MemoryOwner) : base(NativePtr, MemoryOwner)
		{
		}

		// Token: 0x0602DC9B RID: 187547 RVA: 0x00ACBF75 File Offset: 0x00ACA175
		public BP_SAudioCondition(IntPtr NativePtr, bool bWithMoveAssign, bool bWithCopyAssignIfCannotMove) : base(NativePtr, bWithMoveAssign, bWithCopyAssignIfCannotMove)
		{
		}

		// Token: 0x0602DC9C RID: 187548 RVA: 0x00ACBF80 File Offset: 0x00ACA180
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateFromPointer(IntPtr Pointer)
		{
			return new BP_SAudioCondition(Pointer, false, true);
		}

		// Token: 0x0602DC9D RID: 187549 RVA: 0x00ACBF8A File Offset: 0x00ACA18A
		[NullableContext(1)]
		public static IUnrealScriptStructProxy CreateReferenceFromPointer(IntPtr Pointer, UnrealObject MemoryOwner)
		{
			return new BP_SAudioCondition(Pointer, MemoryOwner);
		}

		// Token: 0x04019D7B RID: 105851
		[Nullable(1)]
		public const string __ObjectPath = "/Game/Aki/Audio/BP_SAudioCondition.BP_SAudioCondition";

		// Token: 0x04019D7C RID: 105852
		private static IntPtr _ScriptStructPtr;

		// Token: 0x04019D7D RID: 105853
		internal static int __PropertyOffset_0;

		// Token: 0x04019D7E RID: 105854
		internal static int __PropertyOffset_1;

		// Token: 0x04019D7F RID: 105855
		internal static int __PropertyOffset_2;

		// Token: 0x04019D80 RID: 105856
		internal static int __PropertyOffset_3;
	}
}
