using System;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Interface;
using UnrealEngine.Service;
using UnrealEngine.Utils;

namespace AkiClient.Game.Aki.Data.Level.Swing
{
	// Token: 0x02003E70 RID: 15984
	[NullableContext(1)]
	[Nullable(0)]
	[UnrealObjectPath("/Game/Aki/Data/Level/Swing/BP_RoleSwingConfig.BP_RoleSwingConfig_C")]
	[UnrealStructLayout(176, 8, UnrealReflectionPropertyTypeCode.UnrealObject, PropertiesSize = 176)]
	public class BP_RoleSwingConfig_C : BP_BaseSwingConfig_C, IUnrealUObject, IUnrealObject
	{
		// Token: 0x060277FC RID: 161788 RVA: 0x009F3362 File Offset: 0x009F1562
		public new static UClassStackOnlyPtr StaticClass()
		{
			if (BP_RoleSwingConfig_C._ClassPtr == IntPtr.Zero)
			{
				UObjectGlobals.StaticLoadClass(null, "/Game/Aki/Data/Level/Swing/BP_RoleSwingConfig.BP_RoleSwingConfig_C");
			}
			return BP_RoleSwingConfig_C._ClassPtr;
		}

		// Token: 0x060277FD RID: 161789 RVA: 0x009F3388 File Offset: 0x009F1588
		public BP_RoleSwingConfig_C() : this(BuiltinUtils.AllocNativeUObject(BP_RoleSwingConfig_C.StaticClass(), null, default(FName), EObjectFlags.RF_NoFlags))
		{
		}

		// Token: 0x060277FE RID: 161790 RVA: 0x009F33B0 File Offset: 0x009F15B0
		public BP_RoleSwingConfig_C(UnrealUObject Outer, [Nullable(2)] string Name = null, EObjectFlags ObjectFlags = EObjectFlags.RF_NoFlags) : this(BuiltinUtils.AllocNativeUObject(BP_RoleSwingConfig_C.StaticClass(), Outer, (Name != null) ? new FName(Name) : default(FName), ObjectFlags))
		{
		}

		// Token: 0x17005D20 RID: 23840
		// (get) Token: 0x060277FF RID: 161791 RVA: 0x009F33E4 File Offset: 0x009F15E4
		// (set) Token: 0x06027800 RID: 161792 RVA: 0x009F341D File Offset: 0x009F161D
		public TArray<SRoleSwingConfig> SwingAnimation
		{
			get
			{
				base.FastCheckIsValid();
				TArray<SRoleSwingConfig> result;
				if ((result = this._SwingAnimation) == null)
				{
					result = (this._SwingAnimation = new TArray<SRoleSwingConfig>(base.NativePtr + (IntPtr)BP_RoleSwingConfig_C.__PropertyOffset_0, this));
				}
				return result;
			}
			set
			{
				this.SwingAnimation.CopyAssign(value);
			}
		}

		// Token: 0x06027801 RID: 161793 RVA: 0x009F342B File Offset: 0x009F162B
		protected BP_RoleSwingConfig_C(IntPtr NativeObjectPtr) : base(NativeObjectPtr)
		{
		}

		// Token: 0x04014B0D RID: 84749
		public new const string __ObjectPath = "/Game/Aki/Data/Level/Swing/BP_RoleSwingConfig.BP_RoleSwingConfig_C";

		// Token: 0x04014B0E RID: 84750
		private static IntPtr _ClassPtr;

		// Token: 0x04014B0F RID: 84751
		private static IntPtr _ClassDefaultObjectPtr;

		// Token: 0x04014B10 RID: 84752
		internal new static int __PropertyOffset_0;

		// Token: 0x04014B11 RID: 84753
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private TArray<SRoleSwingConfig> _SwingAnimation;
	}
}
