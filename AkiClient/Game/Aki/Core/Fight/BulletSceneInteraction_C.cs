using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Render.RuntimeBP.Effect.WaterInteraction;
using AkiClient.Game.Aki.Render.RuntimeBP.Interaction;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F50 RID: 16208
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/BulletSceneInteraction.BulletSceneInteraction_C")]
	[UnrealStructLayout(320, 16, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 320)]
	public class BulletSceneInteraction_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06028857 RID: 165975 RVA: 0x00A0DD3B File Offset: 0x00A0BF3B
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BulletSceneInteraction_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Core/Fight/BulletSceneInteraction.BulletSceneInteraction_C");
			}
			return BulletSceneInteraction_C._ClassPtr;
		}

		// Token: 0x06028858 RID: 165976 RVA: 0x00A0DD60 File Offset: 0x00A0BF60
		public BulletSceneInteraction_C() : this(BuiltinUtils.AllocNativeUObject(BulletSceneInteraction_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06028859 RID: 165977 RVA: 0x00A0DD88 File Offset: 0x00A0BF88
		public BulletSceneInteraction_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BulletSceneInteraction_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x170062AE RID: 25262
		// (get) Token: 0x0602885A RID: 165978 RVA: 0x00A0DDBC File Offset: 0x00A0BFBC
		// (set) Token: 0x0602885B RID: 165979 RVA: 0x00A0DDF5 File Offset: 0x00A0BFF5
		public SKuroInteractionLimbsConfig WaterInteraction
		{
			get
			{
				base.FastCheckIsValid();
				SKuroInteractionLimbsConfig result;
				if ((result = this._WaterInteraction) == null)
				{
					result = (this._WaterInteraction = new SKuroInteractionLimbsConfig(base.NativePtr + (IntPtr)BulletSceneInteraction_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SKuroInteractionLimbsConfig.StaticStruct(), base.NativePtr + (IntPtr)BulletSceneInteraction_C.__PropertyOffset_0, value.NativePtr, 1, false);
			}
		}

		// Token: 0x170062AF RID: 25263
		// (get) Token: 0x0602885C RID: 165980 RVA: 0x00A0DE18 File Offset: 0x00A0C018
		// (set) Token: 0x0602885D RID: 165981 RVA: 0x00A0DE51 File Offset: 0x00A0C051
		public SWaterEffectObject WaterEffect
		{
			get
			{
				base.FastCheckIsValid();
				SWaterEffectObject result;
				if ((result = this._WaterEffect) == null)
				{
					result = (this._WaterEffect = new SWaterEffectObject(base.NativePtr + (IntPtr)BulletSceneInteraction_C.__PropertyOffset_1, this));
				}
				return result;
			}
			set
			{
				UnrealReflectionUtils.CopyNativeStruct(SWaterEffectObject.StaticStruct(), base.NativePtr + (IntPtr)BulletSceneInteraction_C.__PropertyOffset_1, value.NativePtr, 1, false);
			}
		}

		// Token: 0x0602885E RID: 165982 RVA: 0x00A0DE72 File Offset: 0x00A0C072
		protected BulletSceneInteraction_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04015534 RID: 87348
		public new const string __ObjectPath = "/Game/Aki/Core/Fight/BulletSceneInteraction.BulletSceneInteraction_C";

		// Token: 0x04015535 RID: 87349
		private static IntPtr _ClassPtr;

		// Token: 0x04015536 RID: 87350
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04015537 RID: 87351
		internal static int __PropertyOffset_0;

		// Token: 0x04015538 RID: 87352
		[Nullable(2)]
		private SKuroInteractionLimbsConfig _WaterInteraction;

		// Token: 0x04015539 RID: 87353
		internal static int __PropertyOffset_1;

		// Token: 0x0401553A RID: 87354
		[Nullable(2)]
		private SWaterEffectObject _WaterEffect;
	}
}
