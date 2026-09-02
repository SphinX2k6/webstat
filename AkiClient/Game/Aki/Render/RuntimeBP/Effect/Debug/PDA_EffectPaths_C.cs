using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Render.RuntimeBP.Effect.Debug
{
	// Token: 0x02003D44 RID: 15684
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/Effect/Debug/PDA_EffectPaths.PDA_EffectPaths_C")]
	[UnrealStructLayout(96, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 96)]
	public class PDA_EffectPaths_C : UPrimaryDataAsset, IUnrealUObject, IUnrealObject
	{
		// Token: 0x06026104 RID: 155908 RVA: 0x009CCF5C File Offset: 0x009CB15C
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (PDA_EffectPaths_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Render/RuntimeBP/Effect/Debug/PDA_EffectPaths.PDA_EffectPaths_C");
			}
			return PDA_EffectPaths_C._ClassPtr;
		}

		// Token: 0x06026105 RID: 155909 RVA: 0x009CCF80 File Offset: 0x009CB180
		public PDA_EffectPaths_C() : this(BuiltinUtils.AllocNativeUObject(PDA_EffectPaths_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x06026106 RID: 155910 RVA: 0x009CCFA8 File Offset: 0x009CB1A8
		public PDA_EffectPaths_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(PDA_EffectPaths_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x1700554E RID: 21838
		// (get) Token: 0x06026107 RID: 155911 RVA: 0x009CCFDC File Offset: 0x009CB1DC
		// (set) Token: 0x06026108 RID: 155912 RVA: 0x009CD015 File Offset: 0x009CB215
		public TArray<string> BasePaths
		{
			get
			{
				base.FastCheckIsValid();
				TArray<string> result;
				if ((result = this._BasePaths) == null)
				{
					result = (this._BasePaths = new TArray<string>(base.NativePtr + (IntPtr)PDA_EffectPaths_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.BasePaths.CopyAssign(value);
			}
		}

		// Token: 0x06026109 RID: 155913 RVA: 0x009CD023 File Offset: 0x009CB223
		protected PDA_EffectPaths_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04013B54 RID: 80724
		public new const string __ObjectPath = "/Game/Aki/Render/RuntimeBP/Effect/Debug/PDA_EffectPaths.PDA_EffectPaths_C";

		// Token: 0x04013B55 RID: 80725
		private static IntPtr _ClassPtr;

		// Token: 0x04013B56 RID: 80726
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04013B57 RID: 80727
		internal static int __PropertyOffset_0;

		// Token: 0x04013B58 RID: 80728
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<string> _BasePaths;
	}
}
