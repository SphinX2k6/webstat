using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D04 RID: 19716
	[NullableContext(2)]
	[Nullable(0)]
	public class HonamiStoryComponentBase : HotKeyComponent
	{
		// Token: 0x06033425 RID: 209957 RVA: 0x00CD5150 File Offset: 0x00CD3350
		public HonamiStoryComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x170087D2 RID: 34770
		// (get) Token: 0x06033426 RID: 209958 RVA: 0x00CD5159 File Offset: 0x00CD3359
		protected HonamiStoryGamepadLogicController Logic
		{
			get
			{
				return ModelBase<HonamiStoryModel>.Instance.GetGamepadLogic();
			}
		}
	}
}
