using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004CEE RID: 19694
	[NullableContext(1)]
	[Nullable(0)]
	public class CommonFilterResetComponent : LongTimeToTriggerComponent
	{
		// Token: 0x060333D9 RID: 209881 RVA: 0x00CD4771 File Offset: 0x00CD2971
		public CommonFilterResetComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x060333DA RID: 209882 RVA: 0x00CD477A File Offset: 0x00CD297A
		protected override void ClickButton(string tag)
		{
			ControllerBase<UiNavigationNewController>.Instance.ClickButton(tag);
			this.ResetToFindListener();
		}

		// Token: 0x060333DB RID: 209883 RVA: 0x00CD4790 File Offset: 0x00CD2990
		protected void ResetToFindListener()
		{
			TsUiNavigationBehaviorListener currentNavigationFocusListener = ControllerBase<UiNavigationNewController>.Instance.GetCurrentNavigationFocusListener();
			if (currentNavigationFocusListener == null)
			{
				return;
			}
			if (!currentNavigationFocusListener.IsScrollOrLayoutActor())
			{
				return;
			}
			if (!CommonFilterResetComponent.ListenerGroupNameArray.Contains(currentNavigationFocusListener.GroupName))
			{
				return;
			}
			if (currentNavigationFocusListener.PanelConfig == null)
			{
				return;
			}
			FindNavigationByListener findNavigationByListener = new FindNavigationByListener();
			findNavigationByListener.PanelConfig = currentNavigationFocusListener.PanelConfig;
			findNavigationByListener.AddParam(new object[]
			{
				currentNavigationFocusListener
			});
			currentNavigationFocusListener.PanelConfig.SetFindNavigationAction(findNavigationByListener);
			ControllerBase<UiNavigationNewController>.Instance.MarkViewHandleRefreshNavigationDirty();
		}

		// Token: 0x0401DC2F RID: 121903
		[StaticVariableRuleIgnore]
		private static readonly string[] ListenerGroupNameArray = new string[]
		{
			"Group1",
			"Group2"
		};
	}
}
