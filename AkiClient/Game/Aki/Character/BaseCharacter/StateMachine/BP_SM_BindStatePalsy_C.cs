using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042BE RID: 17086
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePalsy.BP_SM_BindStatePalsy_C")]
	[UnrealStructLayout(144, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 144)]
	public class BP_SM_BindStatePalsy_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D587 RID: 185735 RVA: 0x00ABDA53 File Offset: 0x00ABBC53
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStatePalsy_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePalsy.BP_SM_BindStatePalsy_C");
			}
			return BP_SM_BindStatePalsy_C._ClassPtr;
		}

		// Token: 0x0602D588 RID: 185736 RVA: 0x00ABDA78 File Offset: 0x00ABBC78
		public BP_SM_BindStatePalsy_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStatePalsy_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D589 RID: 185737 RVA: 0x00ABDAA0 File Offset: 0x00ABBCA0
		public BP_SM_BindStatePalsy_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStatePalsy_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BA6 RID: 31654
		// (get) Token: 0x0602D58A RID: 185738 RVA: 0x00ABDAD3 File Offset: 0x00ABBCD3
		// (set) Token: 0x0602D58B RID: 185739 RVA: 0x00ABDAE8 File Offset: 0x00ABBCE8
		public TSoftObjectPtr<CounterAttackEffectData> 弹反特效预设
		{
			get
			{
				return new TSoftObjectPtr<CounterAttackEffectData>(base.NativePtr + (IntPtr)BP_SM_BindStatePalsy_C.__PropertyOffset_0, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SM_BindStatePalsy_C.__PropertyOffset_0, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x17007BA7 RID: 31655
		// (get) Token: 0x0602D58C RID: 185740 RVA: 0x00ABDB0D File Offset: 0x00ABBD0D
		// (set) Token: 0x0602D58D RID: 185741 RVA: 0x00ABDB22 File Offset: 0x00ABBD22
		public TSoftObjectPtr<CounterAttackCameraData> 弹反摄像机预设
		{
			get
			{
				return new TSoftObjectPtr<CounterAttackCameraData>(base.NativePtr + (IntPtr)BP_SM_BindStatePalsy_C.__PropertyOffset_1, this);
			}
			set
			{
				FSoftObjectPtr.NativeCopy(base.NativePtr + (IntPtr)BP_SM_BindStatePalsy_C.__PropertyOffset_1, (value != null) ? value.NativePtr : IntPtr.Zero, 1);
			}
		}

		// Token: 0x0602D58E RID: 185742 RVA: 0x00ABDB47 File Offset: 0x00ABBD47
		protected BP_SM_BindStatePalsy_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196D9 RID: 104153
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStatePalsy.BP_SM_BindStatePalsy_C";

		// Token: 0x040196DA RID: 104154
		private static IntPtr _ClassPtr;

		// Token: 0x040196DB RID: 104155
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196DC RID: 104156
		internal static int __PropertyOffset_0;

		// Token: 0x040196DD RID: 104157
		internal static int __PropertyOffset_1;
	}
}
