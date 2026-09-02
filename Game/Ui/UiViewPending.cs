using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049BB RID: 18875
	[NullableContext(1)]
	[Nullable(0)]
	public class UiViewPending
	{
		// Token: 0x060315BA RID: 202170 RVA: 0x00C48CE7 File Offset: 0x00C46EE7
		public UiViewPending(UiViewBase view, EViewPendingType pendingType, [Nullable(2)] UiViewBase nextView = null)
		{
			this.View = view;
			this.PendingType = pendingType;
			this.NextView = nextView;
			this.ExecutePromise = new CustomPromise<bool>();
		}

		// Token: 0x060315BB RID: 202171 RVA: 0x00C48D16 File Offset: 0x00C46F16
		public bool Equal(UiViewPending other)
		{
			return this.View.ViewInfo.Name == other.View.ViewInfo.Name && this.PendingType == other.PendingType;
		}

		// Token: 0x060315BC RID: 202172 RVA: 0x00C48D50 File Offset: 0x00C46F50
		public bool IsPairWith(UiViewPending other)
		{
			return !(this.View.ViewInfo.Name != other.View.ViewInfo.Name) && (this.PendingType == EViewPendingType.Open && (other.PendingType == EViewPendingType.Close || other.PendingType == EViewPendingType.CloseSilently));
		}

		// Token: 0x0401C5A8 RID: 116136
		public UiViewBase View;

		// Token: 0x0401C5A9 RID: 116137
		[Nullable(2)]
		public UiViewBase NextView;

		// Token: 0x0401C5AA RID: 116138
		public readonly EViewPendingType PendingType = EViewPendingType.Open;

		// Token: 0x0401C5AB RID: 116139
		public CustomPromise<bool> ExecutePromise;
	}
}
