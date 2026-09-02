using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042D9 RID: 17113
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskBeHitMontage.BP_SM_TaskBeHitMontage_C")]
	[UnrealStructLayout(152, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 152)]
	public class BP_SM_TaskBeHitMontage_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D654 RID: 185940 RVA: 0x00ABF078 File Offset: 0x00ABD278
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskBeHitMontage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskBeHitMontage.BP_SM_TaskBeHitMontage_C");
			}
			return BP_SM_TaskBeHitMontage_C._ClassPtr;
		}

		// Token: 0x0602D655 RID: 185941 RVA: 0x00ABF09C File Offset: 0x00ABD29C
		public BP_SM_TaskBeHitMontage_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskBeHitMontage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D656 RID: 185942 RVA: 0x00ABF0C4 File Offset: 0x00ABD2C4
		public BP_SM_TaskBeHitMontage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskBeHitMontage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BD5 RID: 31701
		// (get) Token: 0x0602D657 RID: 185943 RVA: 0x00ABF0F7 File Offset: 0x00ABD2F7
		// (set) Token: 0x0602D658 RID: 185944 RVA: 0x00ABF10B File Offset: 0x00ABD30B
		public unsafe string DefaultAnim
		{
			get
			{
				return FString.ToString((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_0)));
			}
			set
			{
				FString.CopyFrom((void*)(base.NativePtr + (byte*)((IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_0)), value);
			}
		}

		// Token: 0x17007BD6 RID: 31702
		// (get) Token: 0x0602D659 RID: 185945 RVA: 0x00ABF120 File Offset: 0x00ABD320
		// (set) Token: 0x0602D65A RID: 185946 RVA: 0x00ABF159 File Offset: 0x00ABD359
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		public TMap<TEnumAsByte<EHitAnim>, string> HitAnim
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
				TMap<TEnumAsByte<EHitAnim>, string> result;
				if ((result = this._HitAnim) == null)
				{
					result = (this._HitAnim = new TMap<TEnumAsByte<EHitAnim>, string>(base.NativePtr + (IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_1, this));
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
				this.HitAnim.CopyAssign(value);
			}
		}

		// Token: 0x17007BD7 RID: 31703
		// (get) Token: 0x0602D65B RID: 185947 RVA: 0x00ABF167 File Offset: 0x00ABD367
		// (set) Token: 0x0602D65C RID: 185948 RVA: 0x00ABF177 File Offset: 0x00ABD377
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BD8 RID: 31704
		// (get) Token: 0x0602D65D RID: 185949 RVA: 0x00ABF188 File Offset: 0x00ABD388
		// (set) Token: 0x0602D65E RID: 185950 RVA: 0x00ABF198 File Offset: 0x00ABD398
		public unsafe int BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskBeHitMontage_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x0602D65F RID: 185951 RVA: 0x00ABF1A9 File Offset: 0x00ABD3A9
		protected BP_SM_TaskBeHitMontage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401975E RID: 104286
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskBeHitMontage.BP_SM_TaskBeHitMontage_C";

		// Token: 0x0401975F RID: 104287
		private static IntPtr _ClassPtr;

		// Token: 0x04019760 RID: 104288
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04019761 RID: 104289
		internal static int __PropertyOffset_0;

		// Token: 0x04019762 RID: 104290
		internal static int __PropertyOffset_1;

		// Token: 0x04019763 RID: 104291
		[Nullable(new byte[]
		{
			2,
			0,
			1
		})]
		private TMap<TEnumAsByte<EHitAnim>, string> _HitAnim;

		// Token: 0x04019764 RID: 104292
		internal static int __PropertyOffset_2;

		// Token: 0x04019765 RID: 104293
		internal static int __PropertyOffset_3;
	}
}
