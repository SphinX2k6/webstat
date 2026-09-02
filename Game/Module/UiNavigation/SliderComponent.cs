using System;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D5F RID: 19807
	public class SliderComponent : HotKeyComponent
	{
		// Token: 0x060335AB RID: 210347 RVA: 0x00CD8926 File Offset: 0x00CD6B26
		public SliderComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335AC RID: 210348 RVA: 0x00CD892F File Offset: 0x00CD6B2F
		protected virtual void SetValue(float value)
		{
			ControllerBase<UiNavigationNewController>.Instance.SliderComponentSetValue(base.GetBindButtonTag(), value);
		}

		// Token: 0x0401DC6C RID: 121964
		private const float INTERVAL = 0.05f;

		// Token: 0x0401DC6D RID: 121965
		private const float DEAD_AREA = 0.4f;
	}
}
