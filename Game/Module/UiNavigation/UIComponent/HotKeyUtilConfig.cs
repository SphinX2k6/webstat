using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation.UIComponent
{
	// Token: 0x02004D82 RID: 19842
	public class HotKeyUtilConfig : IStaticVariableResetter
	{
		// Token: 0x170087D6 RID: 34774
		// (get) Token: 0x06033627 RID: 210471 RVA: 0x00CDA4C5 File Offset: 0x00CD86C5
		[Nullable(1)]
		public static Dictionary<EHotKeyCacheKey, Type> CacheKey2CompMap
		{
			[NullableContext(1)]
			get
			{
				return HotKeyUtilConfig._cacheKey2CompMap;
			}
		}

		// Token: 0x06033628 RID: 210472 RVA: 0x00CDA4CC File Offset: 0x00CD86CC
		static HotKeyUtilConfig()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(HotKeyUtilConfig.CreateStaticDefaultValue), new Action(HotKeyUtilConfig.ResetStaticDefaultValue));
		}

		// Token: 0x06033629 RID: 210473 RVA: 0x00CDA4EB File Offset: 0x00CD86EB
		public static void CreateStaticDefaultValue()
		{
			HotKeyUtilConfig._cacheKey2CompMap = new Dictionary<EHotKeyCacheKey, Type>
			{
				{
					EHotKeyCacheKey.RewardTakeDataCallback,
					typeof(RewardTakeComponent)
				}
			};
		}

		// Token: 0x0603362A RID: 210474 RVA: 0x00CDA508 File Offset: 0x00CD8708
		public static void ResetStaticDefaultValue()
		{
			HotKeyUtilConfig._cacheKey2CompMap = null;
		}

		// Token: 0x0401DC8A RID: 121994
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public static Dictionary<EHotKeyCacheKey, Type> _cacheKey2CompMap;
	}
}
