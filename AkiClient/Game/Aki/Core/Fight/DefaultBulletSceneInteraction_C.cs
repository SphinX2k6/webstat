using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F52 RID: 16210
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/DefaultBulletSceneInteraction.DefaultBulletSceneInteraction_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class DefaultBulletSceneInteraction_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x0602886B RID: 165995 RVA: 0x00A0DF56 File Offset: 0x00A0C156
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (DefaultBulletSceneInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/DefaultBulletSceneInteraction.DefaultBulletSceneInteraction_C");
			}
			return DefaultBulletSceneInteraction_C._ClassPtr;
		}

		// Token: 0x0602886C RID: 165996 RVA: 0x00A0DF7C File Offset: 0x00A0C17C
		public DefaultBulletSceneInteraction_C() : this(BuiltinUtils.AllocNativeUObject(DefaultBulletSceneInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x0602886D RID: 165997 RVA: 0x00A0DFA4 File Offset: 0x00A0C1A4
		public DefaultBulletSceneInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(DefaultBulletSceneInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170062B2 RID: 25266
		// (get) Token: 0x0602886E RID: 165998 RVA: 0x00A0DFD8 File Offset: 0x00A0C1D8
		// (set) Token: 0x0602886F RID: 165999 RVA: 0x00A0E011 File Offset: 0x00A0C211
		public TArray<ConditionBulletSceneInteraction> ConditionConfig
		{
			get
			{
				base.FastCheckIsValid();
				TArray<ConditionBulletSceneInteraction> result;
				if ((result = this._ConditionConfig) == null)
				{
					result = (this._ConditionConfig = new TArray<ConditionBulletSceneInteraction>(base.NativePtr + (IntPtr)DefaultBulletSceneInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.ConditionConfig.CopyAssign(value);
			}
		}

		// Token: 0x06028870 RID: 166000 RVA: 0x00A0E01F File Offset: 0x00A0C21F
		protected DefaultBulletSceneInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x0401553F RID: 87359
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/DefaultBulletSceneInteraction.DefaultBulletSceneInteraction_C";

		// Token: 0x04015540 RID: 87360
		private static IntPtr _ClassPtr;

		// Token: 0x04015541 RID: 87361
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015542 RID: 87362
		internal static int __PropertyOffset_0;

		// Token: 0x04015543 RID: 87363
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<ConditionBulletSceneInteraction> _ConditionConfig;
	}
}
