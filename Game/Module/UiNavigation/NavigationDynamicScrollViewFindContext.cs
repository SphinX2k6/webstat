using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004C89 RID: 19593
	[NullableContext(1)]
	[Nullable(0)]
	public class NavigationDynamicScrollViewFindContext
	{
		// Token: 0x0401DB41 RID: 121665
		public Vector LastListenerPosition = Vector.Create();

		// Token: 0x0401DB42 RID: 121666
		public UINavigationWrapMode WrapMode;

		// Token: 0x0401DB43 RID: 121667
		public UINavigationPriorityMode PriorityMode = UINavigationPriorityMode.Direction;

		// Token: 0x0401DB44 RID: 121668
		public bool IsVertical;

		// Token: 0x0401DB45 RID: 121669
		public double NavigateTolerance;

		// Token: 0x0401DB46 RID: 121670
		public double NavigateToleranceReverse;

		// Token: 0x0401DB47 RID: 121671
		public UUIScrollViewWithScrollbarComponent ScrollView;

		// Token: 0x0401DB48 RID: 121672
		public NavigationGroup GroupConfig;

		// Token: 0x0401DB49 RID: 121673
		public bool NegativeDirection;

		// Token: 0x0401DB4A RID: 121674
		public bool Reversed;

		// Token: 0x0401DB4B RID: 121675
		[Nullable(2)]
		public TsUiNavigationBehaviorListener LastListener;

		// Token: 0x0401DB4C RID: 121676
		public EDynamicScrollViewFindNextType NextType;

		// Token: 0x0401DB4D RID: 121677
		public bool NeedWaitScroll;

		// Token: 0x0401DB4E RID: 121678
		public bool IsScrollToEdge;

		// Token: 0x0401DB4F RID: 121679
		public float VerticalScrollValue;

		// Token: 0x0401DB50 RID: 121680
		public float HorizontalScrollValue;
	}
}
