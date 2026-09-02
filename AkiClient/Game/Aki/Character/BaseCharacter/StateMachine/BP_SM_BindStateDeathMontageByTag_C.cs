using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042B8 RID: 17080
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontageByTag.BP_SM_BindStateDeathMontageByTag_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 80)]
	public class BP_SM_BindStateDeathMontageByTag_C : UASMBindState, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D55D RID: 185693 RVA: 0x00ABD58E File Offset: 0x00ABB78E
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_BindStateDeathMontageByTag_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontageByTag.BP_SM_BindStateDeathMontageByTag_C");
			}
			return BP_SM_BindStateDeathMontageByTag_C._ClassPtr;
		}

		// Token: 0x0602D55E RID: 185694 RVA: 0x00ABD5B4 File Offset: 0x00ABB7B4
		public BP_SM_BindStateDeathMontageByTag_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDeathMontageByTag_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D55F RID: 185695 RVA: 0x00ABD5DC File Offset: 0x00ABB7DC
		public BP_SM_BindStateDeathMontageByTag_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_BindStateDeathMontageByTag_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007B9D RID: 31645
		// (get) Token: 0x0602D560 RID: 185696 RVA: 0x00ABD610 File Offset: 0x00ABB810
		// (set) Token: 0x0602D561 RID: 185697 RVA: 0x00ABD649 File Offset: 0x00ABB849
		public TArray<FGameplayTag> MontageTags
		{
			get
			{
				base.FastCheckIsValid();
				TArray<FGameplayTag> result;
				if ((result = this._MontageTags) == null)
				{
					result = (this._MontageTags = new TArray<FGameplayTag>(base.NativePtr + (IntPtr)BP_SM_BindStateDeathMontageByTag_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MontageTags.CopyAssign(value);
			}
		}

		// Token: 0x17007B9E RID: 31646
		// (get) Token: 0x0602D562 RID: 185698 RVA: 0x00ABD658 File Offset: 0x00ABB858
		// (set) Token: 0x0602D563 RID: 185699 RVA: 0x00ABD691 File Offset: 0x00ABB891
		public TArray<string> TagMontageNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._TagMontageNames) == null)
				{
					result = (this._TagMontageNames = new TArray<string>(base.NativePtr + (IntPtr)BP_SM_BindStateDeathMontageByTag_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				this.TagMontageNames.CopyAssign(value);
			}
		}

		// Token: 0x0602D564 RID: 185700 RVA: 0x00ABD69F File Offset: 0x00ABB89F
		protected BP_SM_BindStateDeathMontageByTag_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x040196BC RID: 104124
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_BindStateDeathMontageByTag.BP_SM_BindStateDeathMontageByTag_C";

		// Token: 0x040196BD RID: 104125
		private static IntPtr _ClassPtr;

		// Token: 0x040196BE RID: 104126
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x040196BF RID: 104127
		internal static int __PropertyOffset_0;

		// Token: 0x040196C0 RID: 104128
		[Nullable(2)]
		private TArray<FGameplayTag> _MontageTags;

		// Token: 0x040196C1 RID: 104129
		internal static int __PropertyOffset_1;

		// Token: 0x040196C2 RID: 104130
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _TagMontageNames;
	}
}
