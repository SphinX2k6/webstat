using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041D4 RID: 16852
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBullet.DAC_BatchCreateBullet_C")]
	[UnrealStructLayout(136, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 129)]
	public class DAC_BatchCreateBullet_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602CD2B RID: 183595 RVA: 0x00AB0A83 File Offset: 0x00AAEC83
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DAC_BatchCreateBullet_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBullet.DAC_BatchCreateBullet_C");
			}
			return DAC_BatchCreateBullet_C._ClassPtr;
		}

		// Token: 0x0602CD2C RID: 183596 RVA: 0x00AB0AA8 File Offset: 0x00AAECA8
		public DAC_BatchCreateBullet_C() : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBullet_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602CD2D RID: 183597 RVA: 0x00AB0AD0 File Offset: 0x00AAECD0
		[NullableContext(1)]
		public DAC_BatchCreateBullet_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DAC_BatchCreateBullet_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700793A RID: 31034
		// (get) Token: 0x0602CD2E RID: 183598 RVA: 0x00AB0B04 File Offset: 0x00AAED04
		// (set) Token: 0x0602CD2F RID: 183599 RVA: 0x00AB0B3D File Offset: 0x00AAED3D
		[Nullable(1)]
		public SSkillBehaviorBatchBullet Base
		{
			[NullableContext(1)]
			get
			{
				base.FastCheckIsValid();
				SSkillBehaviorBatchBullet result;
				if ((result = this._Base) == null)
				{
					result = (this._Base = new SSkillBehaviorBatchBullet(base.NativePtr + (IntPtr)DAC_BatchCreateBullet_C.__PropertyOffset_0, this));
				}
				return result;
			}
			[NullableContext(1)]
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SSkillBehaviorBatchBullet.StaticStruct(), base.NativePtr + (IntPtr)DAC_BatchCreateBullet_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x1700793B RID: 31035
		// (get) Token: 0x0602CD30 RID: 183600 RVA: 0x00AB0B5E File Offset: 0x00AAED5E
		// (set) Token: 0x0602CD31 RID: 183601 RVA: 0x00AB0B72 File Offset: 0x00AAED72
		public unsafe TEnumAsByte<EBatchBulletPosition> BeginPos
		{
			get
			{
				return *(base.NativePtr + (IntPtr)DAC_BatchCreateBullet_C.__PropertyOffset_1);
			}
			set
			{
				*(base.NativePtr + (IntPtr)DAC_BatchCreateBullet_C.__PropertyOffset_1) = value;
			}
		}

		// Token: 0x0602CD32 RID: 183602 RVA: 0x00AB0B87 File Offset: 0x00AAED87
		protected DAC_BatchCreateBullet_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04018FC1 RID: 102337
		[Nullable(1)]
		public new const string __ObjectPath = "/Game/Aki/Character/BaseCharacter/DAC_BatchCreateBullet.DAC_BatchCreateBullet_C";

		// Token: 0x04018FC2 RID: 102338
		private static IntPtr _ClassPtr;

		// Token: 0x04018FC3 RID: 102339
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04018FC4 RID: 102340
		internal static int __PropertyOffset_0;

		// Token: 0x04018FC5 RID: 102341
		[Nullable(2)]
		private SSkillBehaviorBatchBullet _Base;

		// Token: 0x04018FC6 RID: 102342
		internal static int __PropertyOffset_1;
	}
}
