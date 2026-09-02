using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using CSharpScript.Game.Module.Plot.FlowActions;

namespace CSharpScript.Game.Module.Plot.Flow
{
	// Token: 0x020053F7 RID: 21495
	[NullableContext(1)]
	[Nullable(0)]
	public class FlowAction
	{
		// Token: 0x06036DF0 RID: 224752 RVA: 0x00DE9C94 File Offset: 0x00DE7E94
		public void Init(EAction type, Func<FlowActionBase> actionFactory, bool isAutoFinished = false)
		{
			this.Type = type;
			this.ActionFactory = actionFactory;
			this.IsAutoFinish = isAutoFinished;
			this.ActionInstanceList = new Stack<FlowActionBase>();
			FlowActionBase element = this.CreateAction();
			this.ActionInstanceList.Push(element);
		}

		// Token: 0x06036DF1 RID: 224753 RVA: 0x00DE9CD4 File Offset: 0x00DE7ED4
		private FlowActionBase CreateAction()
		{
			FlowActionBase flowActionBase = this.ActionFactory();
			flowActionBase.Type = this.Type;
			return flowActionBase;
		}

		// Token: 0x06036DF2 RID: 224754 RVA: 0x00DE9CED File Offset: 0x00DE7EED
		public FlowActionBase GetAction()
		{
			FlowActionBase actionInner = this.GetActionInner();
			actionInner.Owner = this;
			return actionInner;
		}

		// Token: 0x06036DF3 RID: 224755 RVA: 0x00DE9CFC File Offset: 0x00DE7EFC
		private FlowActionBase GetActionInner()
		{
			if (this.IsAutoFinish)
			{
				return this.ActionInstanceList.Last<FlowActionBase>();
			}
			if (this.ActionInstanceList.Size <= 0)
			{
				return this.CreateAction();
			}
			return this.ActionInstanceList.Pop();
		}

		// Token: 0x06036DF4 RID: 224756 RVA: 0x00DE9D32 File Offset: 0x00DE7F32
		public void RecycleAction(FlowActionBase action)
		{
			action.Owner = null;
			if (this.IsAutoFinish)
			{
				return;
			}
			this.ActionInstanceList.Push(action);
		}

		// Token: 0x0401F96C RID: 129388
		public EAction Type;

		// Token: 0x0401F96D RID: 129389
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Func<FlowActionBase> ActionFactory;

		// Token: 0x0401F96E RID: 129390
		public bool IsAutoFinish;

		// Token: 0x0401F96F RID: 129391
		[Nullable(new byte[]
		{
			2,
			1
		})]
		public Stack<FlowActionBase> ActionInstanceList;
	}
}
