using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049F1 RID: 18929
	[NullableContext(1)]
	[Nullable(0)]
	public class InputDistributeDelay
	{
		// Token: 0x06031824 RID: 202788 RVA: 0x00C568AE File Offset: 0x00C54AAE
		public InputDistributeDelay()
		{
			this.InputPressTimeStampQueue = new Queue<double>(4);
			this.InputReleaseTimeStampQueue = new Queue<double>(4);
		}

		// Token: 0x06031825 RID: 202789 RVA: 0x00C568CE File Offset: 0x00C54ACE
		public void StartDelay(float delayTime, bool bPress)
		{
			if (bPress)
			{
				this.InputPressTimeStampQueue.Push(Singleton<Time>.Instance.Now + (double)delayTime);
				return;
			}
			this.InputReleaseTimeStampQueue.Push(Singleton<Time>.Instance.Now + (double)delayTime);
		}

		// Token: 0x06031826 RID: 202790 RVA: 0x00C56904 File Offset: 0x00C54B04
		public bool IsInputActive(bool bPress)
		{
			Queue<double> queue;
			if (bPress)
			{
				queue = this.InputPressTimeStampQueue;
			}
			else
			{
				queue = this.InputReleaseTimeStampQueue;
			}
			double now = Singleton<Time>.Instance.Now;
			while (queue.Size > 0)
			{
				if (now < queue.Front)
				{
					queue.Pop();
					return true;
				}
				queue.Pop();
			}
			return false;
		}

		// Token: 0x06031827 RID: 202791 RVA: 0x00C56956 File Offset: 0x00C54B56
		public bool CheckCondition(string actionName, bool bPress)
		{
			return actionName == "通用交互" && !Singleton<UiManager>.Instance.IsViewCreating(EUiViewName.InteractionHintView) && !Singleton<UiManager>.Instance.IsViewDestroying(EUiViewName.InteractionHintView);
		}

		// Token: 0x0401CCB4 RID: 117940
		[StaticVariableRuleIgnore]
		public static readonly string[] delayInput = new string[]
		{
			"通用交互"
		};

		// Token: 0x0401CCB5 RID: 117941
		private readonly Queue<double> InputPressTimeStampQueue;

		// Token: 0x0401CCB6 RID: 117942
		private readonly Queue<double> InputReleaseTimeStampQueue;
	}
}
