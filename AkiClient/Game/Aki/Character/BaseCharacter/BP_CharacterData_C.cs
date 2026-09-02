using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041C7 RID: 16839
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/BP_CharacterData.BP_CharacterData_C")]
	[UnrealStructLayout(160, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 160)]
	public class BP_CharacterData_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CC41 RID: 183361 RVA: 0x00AAEE9B File Offset: 0x00AAD09B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_CharacterData_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/BP_CharacterData.BP_CharacterData_C");
			}
			return BP_CharacterData_C._ClassPtr;
		}

		// Token: 0x0602CC42 RID: 183362 RVA: 0x00AAEEC0 File Offset: 0x00AAD0C0
		public BP_CharacterData_C() : this(BuiltinUtils.AllocNativeUObject(BP_CharacterData_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CC43 RID: 183363 RVA: 0x00AAEEE8 File Offset: 0x00AAD0E8
		[NullableContext(1)]
		public BP_CharacterData_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_CharacterData_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170078E7 RID: 30951
		// (get) Token: 0x0602CC44 RID: 183364 RVA: 0x00AAEF1C File Offset: 0x00AAD11C
		// (set) Token: 0x0602CC45 RID: 183365 RVA: 0x00AAEF55 File Offset: 0x00AAD155
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<ECharacterState>, FGameplayTagContainer> CharacterStateTags
		{
			[return: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			get
			{
				base.FastCheckIsValid();
				TMap<TEnumAsByte<ECharacterState>, FGameplayTagContainer> result;
				if ((result = this._CharacterStateTags) == null)
				{
					result = (this._CharacterStateTags = new TMap<TEnumAsByte<ECharacterState>, FGameplayTagContainer>(base.NativePtr + (IntPtr)BP_CharacterData_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[param: Nullable(new byte[]
			{
				1,
				0,
				1
			})]
			set
			{
				this.CharacterStateTags.CopyAssign(value);
			}
		}

		// Token: 0x0602CC46 RID: 183366 RVA: 0x00AAEF63 File Offset: 0x00AAD163
		protected BP_CharacterData_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018F1A RID: 102170
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/BP_CharacterData.BP_CharacterData_C";

		// Token: 0x04018F1B RID: 102171
		private static IntPtr _ClassPtr;

		// Token: 0x04018F1C RID: 102172
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018F1D RID: 102173
		internal static int __PropertyOffset_0;

		// Token: 0x04018F1E RID: 102174
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<ECharacterState>, FGameplayTagContainer> _CharacterStateTags;
	}
}
