using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063CE RID: 25550
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoverlikeActionViewBase : UiViewBase
	{
		// Token: 0x06040267 RID: 262759 RVA: 0x0107091D File Offset: 0x0106EB1D
		protected RoverlikeActionViewBase(UiViewInfo viewInfo) : base(viewInfo)
		{
		}

		// Token: 0x06040268 RID: 262760 RVA: 0x01070926 File Offset: 0x0106EB26
		protected override void OnBeforeCreateImplementImplement()
		{
			RoverlikeActionStack actionStack = this.GetActionStack();
			if (actionStack == null)
			{
				return;
			}
			actionStack.Push(this);
		}

		// Token: 0x06040269 RID: 262761 RVA: 0x01070939 File Offset: 0x0106EB39
		protected override void OnBeforeDestroyImplement()
		{
			RoverlikeActionStack actionStack = this.GetActionStack();
			if (actionStack == null)
			{
				return;
			}
			actionStack.Pop(this);
		}

		// Token: 0x0604026A RID: 262762 RVA: 0x0107094C File Offset: 0x0106EB4C
		protected bool TryInteractAction(Action action)
		{
			RoverlikeActionStack actionStack = this.GetActionStack();
			return actionStack != null && actionStack.TryAction(this, action);
		}

		// Token: 0x0604026B RID: 262763 RVA: 0x0107096D File Offset: 0x0106EB6D
		[NullableContext(2)]
		private RoverlikeActionStack GetActionStack()
		{
			RoverlikeModel instance = ModelBase<RoverlikeModel>.Instance;
			if (instance == null)
			{
				return null;
			}
			return instance.ActionStack;
		}
	}
}
