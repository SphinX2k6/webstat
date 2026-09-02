using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D4F RID: 19791
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class ScrollBarComponentBase : HotKeyComponent
	{
		// Token: 0x06033578 RID: 210296 RVA: 0x00CD831A File Offset: 0x00CD651A
		protected ScrollBarComponentBase(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033579 RID: 210297 RVA: 0x00CD8324 File Offset: 0x00CD6524
		protected override void OnInputAxis(string axisName, float value)
		{
			if (Math.Abs(value) <= 0.1f)
			{
				if (this.TempValue != 0f)
				{
					this.TempValue = 0f;
					this.HandleScrollBarChange(0f);
				}
				return;
			}
			this.TempValue = value;
			this.HandleScrollBarChange(value);
		}

		// Token: 0x0603357A RID: 210298 RVA: 0x00CD8370 File Offset: 0x00CD6570
		protected override void OnRefreshSelfHotKeyState(UiNavigationViewHandle viewHandle)
		{
			string bindButtonTag = base.GetBindButtonTag();
			if (string.IsNullOrEmpty(bindButtonTag))
			{
				Singleton<Log>.Instance.Error(ELogModule.UiNavigationHotKey, ELogAuthor.XXJ, "ScrollBar需要配置tag", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			TsUiNavigationBehaviorListener currentListener = viewHandle.GetScrollbarData().GetCurrentListener();
			if (currentListener == null)
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			if (!currentListener.IsListenerActive())
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			TArray<string> tagArray = currentListener.TagArray;
			if (tagArray == null || !tagArray.Contains(bindButtonTag))
			{
				base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, false, false);
				return;
			}
			base.SetVisibleMode(HotKeyViewDefine.ELogicMode.ListenerActive, true, false);
		}

		// Token: 0x0603357B RID: 210299
		protected abstract void HandleScrollBarChange(float value);

		// Token: 0x0401DC63 RID: 121955
		private const float THRESHOLD = 0.1f;

		// Token: 0x0401DC64 RID: 121956
		private float TempValue;
	}
}
