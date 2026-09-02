using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D6F RID: 19823
	[NullableContext(1)]
	[Nullable(0)]
	public class StaticJoyStickComponentBase : HotKeyComponent
	{
		// Token: 0x060335D2 RID: 210386 RVA: 0x00CD8BF3 File Offset: 0x00CD6DF3
		public StaticJoyStickComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060335D3 RID: 210387 RVA: 0x00CD8C19 File Offset: 0x00CD6E19
		protected override void OnPress(HotKeyMap config)
		{
			this.SimulationPoint(config, true, this.Pivot);
		}

		// Token: 0x060335D4 RID: 210388 RVA: 0x00CD8C29 File Offset: 0x00CD6E29
		protected override void OnRelease(HotKeyMap config)
		{
			this.SimulationPoint(config, false, this.Pivot);
		}

		// Token: 0x060335D5 RID: 210389 RVA: 0x00CD8C39 File Offset: 0x00CD6E39
		protected void SimulationPoint(HotKeyMap config, bool isPress, Vector2D pivot)
		{
			if (isPress)
			{
				ControllerBase<UiNavigationNewController>.Instance.SimulationPointDown(config.BindButtonTag, config.Id, pivot);
				return;
			}
			ControllerBase<UiNavigationNewController>.Instance.SimulationPointUp(config.BindButtonTag, config.Id, pivot);
		}

		// Token: 0x060335D6 RID: 210390 RVA: 0x00CD8C74 File Offset: 0x00CD6E74
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (StringUtils.IsEmpty(bindButtonTag))
			{
				return;
			}
			TsUiNavigationBehaviorListener activeListenerByTag = viewHandle.GetActiveListenerByTag(bindButtonTag);
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, activeListenerByTag != null && activeListenerByTag.IsListenerActive(), false);
		}

		// Token: 0x0401DC7A RID: 121978
		protected const float ERROR_THRESHOLD = 0.01f;

		// Token: 0x0401DC7B RID: 121979
		protected Vector2D Pivot = Vector2D.Create(0.5, 0.5);
	}
}
