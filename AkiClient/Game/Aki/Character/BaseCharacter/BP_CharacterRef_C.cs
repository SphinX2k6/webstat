using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using AkiClient.Game.Aki.Data.Fight.AssestStruct;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C8 RID: 16840
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_CharacterRef.BP_CharacterRef_C")]
	[UnrealStructLayout(208, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 208)]
	public class BP_CharacterRef_C : UObject, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CC47 RID: 183367 RVA: 0x00AAEF6C File Offset: 0x00AAD16C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterRef_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_CharacterRef.BP_CharacterRef_C");
			}
			return BP_CharacterRef_C._ClassPtr;
		}

		// Token: 0x0602CC48 RID: 183368 RVA: 0x00AAEF90 File Offset: 0x00AAD190
		public BP_CharacterRef_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterRef_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CC49 RID: 183369 RVA: 0x00AAEFB8 File Offset: 0x00AAD1B8
		public BP_CharacterRef_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterRef_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078E8 RID: 30952
		// (get) Token: 0x0602CC4A RID: 183370 RVA: 0x00AAEFEB File Offset: 0x00AAD1EB
		// (set) Token: 0x0602CC4B RID: 183371 RVA: 0x00AAEFFF File Offset: 0x00AAD1FF
		public unsafe SClimbInfo NewVar_0
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterRef_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterRef_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x170078E9 RID: 30953
		// (get) Token: 0x0602CC4C RID: 183372 RVA: 0x00AAF014 File Offset: 0x00AAD214
		// (set) Token: 0x0602CC4D RID: 183373 RVA: 0x00AAF028 File Offset: 0x00AAD228
		public unsafe SClimbState NewVar_1
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_CharacterRef_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_CharacterRef_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x170078EA RID: 30954
		// (get) Token: 0x0602CC4E RID: 183374 RVA: 0x00AAF03D File Offset: 0x00AAD23D
		// (set) Token: 0x0602CC4F RID: 183375 RVA: 0x00AAF051 File Offset: 0x00AAD251
		[Nullable(2)]
		public unsafe BP_SplineMoveConfig_C NewVar_2
		{
			[NullableContext(2)]
			get
			{
				return BuiltinUtils.ObjectPropertyGetter<BP_SplineMoveConfig_C>(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterRef_C.__PropertyOffset_2);
			}
			[NullableContext(2)]
			set
			{
				BuiltinUtils.ObjectPropertySetter(base.NativePtr / (IntPtr)sizeof(void*) + BP_CharacterRef_C.__PropertyOffset_2, value);
			}
		}

		// Token: 0x170078EB RID: 30955
		// (get) Token: 0x0602CC50 RID: 183376 RVA: 0x00AAF068 File Offset: 0x00AAD268
		// (set) Token: 0x0602CC51 RID: 183377 RVA: 0x00AAF0A1 File Offset: 0x00AAD2A1
		public SCameraModifier_Condition NewVar_3
		{
			get
			{
				base.FastCheckIsValid();
				SCameraModifier_Condition result;
				if ((result = this._NewVar_3) == null)
				{
					result = (this._NewVar_3 = new SCameraModifier_Condition(base.NativePtr + (IntPtr)BP_CharacterRef_C.__PropertyOffset_3, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SCameraModifier_Condition.StaticStruct(), base.NativePtr + (IntPtr)BP_CharacterRef_C.__PropertyOffset_3, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602CC52 RID: 183378 RVA: 0x00AAF0C2 File Offset: 0x00AAD2C2
		protected BP_CharacterRef_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F1F RID: 102175
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_CharacterRef.BP_CharacterRef_C";

		// Token: 0x04018F20 RID: 102176
		private static IntPtr _ClassPtr;

		// Token: 0x04018F21 RID: 102177
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F22 RID: 102178
		internal static int __PropertyOffset_0;

		// Token: 0x04018F23 RID: 102179
		internal static int __PropertyOffset_1;

		// Token: 0x04018F24 RID: 102180
		internal static int __PropertyOffset_2;

		// Token: 0x04018F25 RID: 102181
		internal static int __PropertyOffset_3;

		// Token: 0x04018F26 RID: 102182
		[Nullable(2)]
		private SCameraModifier_Condition _NewVar_3;
	}
}
