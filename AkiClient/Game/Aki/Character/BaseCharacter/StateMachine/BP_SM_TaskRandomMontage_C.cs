using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042E0 RID: 17120
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskRandomMontage.BP_SM_TaskRandomMontage_C")]
	[UnrealStructLayout(80, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 73)]
	public class BP_SM_TaskRandomMontage_C : UASMTask, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602D69C RID: 186012 RVA: 0x00ABF74B File Offset: 0x00ABD94B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_SM_TaskRandomMontage_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskRandomMontage.BP_SM_TaskRandomMontage_C");
			}
			return BP_SM_TaskRandomMontage_C._ClassPtr;
		}

		// Token: 0x0602D69D RID: 186013 RVA: 0x00ABF770 File Offset: 0x00ABD970
		public BP_SM_TaskRandomMontage_C() : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskRandomMontage_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602D69E RID: 186014 RVA: 0x00ABF798 File Offset: 0x00ABD998
		public BP_SM_TaskRandomMontage_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_SM_TaskRandomMontage_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17007BEB RID: 31723
		// (get) Token: 0x0602D69F RID: 186015 RVA: 0x00ABF7CC File Offset: 0x00ABD9CC
		// (set) Token: 0x0602D6A0 RID: 186016 RVA: 0x00ABF805 File Offset: 0x00ABDA05
		public TArray<string> MontageNames
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._MontageNames) == null)
				{
					result = (this._MontageNames = new TArray<string>(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.MontageNames.CopyAssign(value);
			}
		}

		// Token: 0x17007BEC RID: 31724
		// (get) Token: 0x0602D6A1 RID: 186017 RVA: 0x00ABF813 File Offset: 0x00ABDA13
		// (set) Token: 0x0602D6A2 RID: 186018 RVA: 0x00ABF823 File Offset: 0x00ABDA23
		public unsafe bool 加载期间隐藏模型
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_1) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_1) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BED RID: 31725
		// (get) Token: 0x0602D6A3 RID: 186019 RVA: 0x00ABF834 File Offset: 0x00ABDA34
		// (set) Token: 0x0602D6A4 RID: 186020 RVA: 0x00ABF844 File Offset: 0x00ABDA44
		public unsafe bool 允许打断
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_2) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_2) = (value ? 1 : 0);
			}
		}

		// Token: 0x17007BEE RID: 31726
		// (get) Token: 0x0602D6A5 RID: 186021 RVA: 0x00ABF855 File Offset: 0x00ABDA55
		// (set) Token: 0x0602D6A6 RID: 186022 RVA: 0x00ABF865 File Offset: 0x00ABDA65
		public unsafe int BlendInTime
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_3);
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_3) = value;
			}
		}

		// Token: 0x17007BEF RID: 31727
		// (get) Token: 0x0602D6A7 RID: 186023 RVA: 0x00ABF876 File Offset: 0x00ABDA76
		// (set) Token: 0x0602D6A8 RID: 186024 RVA: 0x00ABF886 File Offset: 0x00ABDA86
		public unsafe bool 客户端随机
		{
			get
			{
				return *(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_4) != 0;
			}
			set
			{
				*(base.NativePtr + (IntPtr)BP_SM_TaskRandomMontage_C.__PropertyOffset_4) = (value ? 1 : 0);
			}
		}

		// Token: 0x0602D6A9 RID: 186025 RVA: 0x00ABF897 File Offset: 0x00ABDA97
		protected BP_SM_TaskRandomMontage_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401978A RID: 104330
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/StateMachine/BP_SM_TaskRandomMontage.BP_SM_TaskRandomMontage_C";

		// Token: 0x0401978B RID: 104331
		private static IntPtr _ClassPtr;

		// Token: 0x0401978C RID: 104332
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x0401978D RID: 104333
		internal static int __PropertyOffset_0;

		// Token: 0x0401978E RID: 104334
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _MontageNames;

		// Token: 0x0401978F RID: 104335
		internal static int __PropertyOffset_1;

		// Token: 0x04019790 RID: 104336
		internal static int __PropertyOffset_2;

		// Token: 0x04019791 RID: 104337
		internal static int __PropertyOffset_3;

		// Token: 0x04019792 RID: 104338
		internal static int __PropertyOffset_4;
	}
}
