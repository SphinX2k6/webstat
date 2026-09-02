using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Core.Net
{
	// Token: 0x0200711F RID: 28959
	public class NetGameBudgetOnceTaskGroup : IGameBudgetOnceTaskGroup
	{
		// Token: 0x1700A5FA RID: 42490
		// (get) Token: 0x06046266 RID: 287334 RVA: 0x0126C760 File Offset: 0x0126A960
		public FName GroupId
		{
			get
			{
				return this.GroupIdInternal;
			}
		}

		// Token: 0x1700A5FB RID: 42491
		// (get) Token: 0x06046267 RID: 287335 RVA: 0x0126C768 File Offset: 0x0126A968
		public int Priority
		{
			get
			{
				return this.PriorityInternal;
			}
		}

		// Token: 0x06046268 RID: 287336 RVA: 0x0126C770 File Offset: 0x0126A970
		public bool IsEmpty()
		{
			Func<bool> isEmptyFuncInternal = this.IsEmptyFuncInternal;
			return isEmptyFuncInternal == null || isEmptyFuncInternal();
		}

		// Token: 0x06046269 RID: 287337 RVA: 0x0126C783 File Offset: 0x0126A983
		public void Consume()
		{
			Action consumeAction = this.ConsumeAction;
			if (consumeAction == null)
			{
				return;
			}
			consumeAction();
		}

		// Token: 0x0604626A RID: 287338 RVA: 0x0126C795 File Offset: 0x0126A995
		[NullableContext(1)]
		public NetGameBudgetOnceTaskGroup(FName groupId, int priority, Func<bool> isEmptyFunc, Action consumeAction)
		{
			this.GroupIdInternal = groupId;
			this.PriorityInternal = priority;
			this.IsEmptyFuncInternal = isEmptyFunc;
			this.ConsumeAction = consumeAction;
		}

		// Token: 0x0402756A RID: 161130
		private FName GroupIdInternal;

		// Token: 0x0402756B RID: 161131
		private int PriorityInternal;

		// Token: 0x0402756C RID: 161132
		[Nullable(2)]
		private Func<bool> IsEmptyFuncInternal;

		// Token: 0x0402756D RID: 161133
		[Nullable(2)]
		private Action ConsumeAction;
	}
}
