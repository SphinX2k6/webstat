using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B9 RID: 17081
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontage.BP_SM_BindStateDeathMontage_C")]
	[UnrealStructLayout(72, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 72)]
	public class BP_SM_BindStateDeathMontage_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D565 RID: 185701 RVA: 0x00ABD6A8 File Offset: 0x00ABB8A8
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateDeathMontage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontage.BP_SM_BindStateDeathMontage_C");
			}
			return BP_SM_BindStateDeathMontage_C._ClassPtr;
		}

		// Token: 0x0602D566 RID: 185702 RVA: 0x00ABD6CC File Offset: 0x00ABB8CC
		public BP_SM_BindStateDeathMontage_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDeathMontage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D567 RID: 185703 RVA: 0x00ABD6F4 File Offset: 0x00ABB8F4
		[NullableContext(1)]
		public BP_SM_BindStateDeathMontage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDeathMontage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B9F RID: 31647
		// (get) Token: 0x0602D568 RID: 185704 RVA: 0x00ABD727 File Offset: 0x00ABB927
		// (set) Token: 0x0602D569 RID: 185705 RVA: 0x00ABD73B File Offset: 0x00ABB93B
		public unsafe TEnumAsByte<EMonsterDeathType> 死亡种类
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_BindStateDeathMontage_C.__PropertyOffset_0);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_BindStateDeathMontage_C.__PropertyOffset_0) = value;
			}
		}

		// Token: 0x17007BA0 RID: 31648
		// (get) Token: 0x0602D56A RID: 185706 RVA: 0x00ABD750 File Offset: 0x00ABB950
		// (set) Token: 0x0602D56B RID: 185707 RVA: 0x00ABD764 File Offset: 0x00ABB964
		[Nullable(1)]
		public unsafe string MontageName
		{
			[NullableContext(1)]
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateDeathMontage_C.__PropertyOffset_1)));
			}
			[NullableContext(1)]
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_BindStateDeathMontage_C.__PropertyOffset_1)), value);
			}
		}

		// Token: 0x0602D56C RID: 185708 RVA: 0x00ABD779 File Offset: 0x00ABB979
		protected BP_SM_BindStateDeathMontage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196C3 RID: 104131
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontage.BP_SM_BindStateDeathMontage_C";

		// Token: 0x040196C4 RID: 104132
		private static IntPtr _ClassPtr;

		// Token: 0x040196C5 RID: 104133
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196C6 RID: 104134
		internal static int __PropertyOffset_0;

		// Token: 0x040196C7 RID: 104135
		internal static int __PropertyOffset_1;
	}
}
