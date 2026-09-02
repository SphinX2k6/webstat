using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.GenericPrompt
{
	// Token: 0x02005CA8 RID: 23720
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class GenericPromptModel : ModelBase<GenericPromptModel>
	{
		// Token: 0x0603BDF9 RID: 245241 RVA: 0x00F2C7FF File Offset: 0x00F2A9FF
		protected override bool OnInit()
		{
			Singleton<EventSystem>.Instance.Add(EEventName.OnFinishLoadingState, new Action(this.OnLoadingDone));
			return true;
		}

		// Token: 0x0603BDFA RID: 245242 RVA: 0x00F2C81E File Offset: 0x00F2AA1E
		protected override bool OnClear()
		{
			Singleton<EventSystem>.Instance.Remove(EEventName.OnFinishLoadingState, new Action(this.OnLoadingDone));
			this.WaitQueue.Clear();
			return true;
		}

		// Token: 0x0603BDFB RID: 245243 RVA: 0x00F2C848 File Offset: 0x00F2AA48
		private void OnLoadingDone()
		{
			int i = 0;
			int size = this.WaitQueue.Size;
			while (i < size)
			{
				this.ApplyPromptParamHub(this.WaitQueue.Pop());
				i++;
			}
			if (!this.WaitQueue.Empty)
			{
				Singleton<Log>.Instance.Error(ELogModule.GenericPrompt, ELogAuthor.XXJ, "播放队列飘字异常,存在从队列中取出又被放回队列的情况", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x0603BDFC RID: 245244 RVA: 0x00F2C8A7 File Offset: 0x00F2AAA7
		private bool NeedAddToWaitQueue()
		{
			return ModelBase<LoadingModel>.Instance.IsLoading || ModelBase<LoginModel>.Instance.HasLoginPromise();
		}

		// Token: 0x0603BDFD RID: 245245 RVA: 0x00F2C8C1 File Offset: 0x00F2AAC1
		public void ApplyPromptParamHub(IPromptParamHub promptParamHub)
		{
			if (this.NeedAddToWaitQueue())
			{
				this.WaitQueue.Push(promptParamHub);
				return;
			}
			Singleton<EventSystem>.Instance.Emit<IPromptParamHub>(EEventName.InsertFloatTips, promptParamHub);
		}

		// Token: 0x0603BDFE RID: 245246 RVA: 0x00F2C8EC File Offset: 0x00F2AAEC
		public void RemovePromptParamHubByKey(string promptKey)
		{
			int size = this.WaitQueue.Size;
			for (int i = 0; i < size; i++)
			{
				IPromptParamHub promptParamHub = this.WaitQueue.Get(i);
				if (promptParamHub != null && promptParamHub.PromptKey != null && promptParamHub.PromptKey == promptKey)
				{
					List<IPromptParamHub> list = new List<IPromptParamHub>();
					for (int j = 0; j < size; j++)
					{
						if (j != i)
						{
							list.Add(this.WaitQueue.Get(j));
						}
					}
					this.WaitQueue.Clear();
					foreach (IPromptParamHub element in list)
					{
						this.WaitQueue.Push(element);
					}
					return;
				}
			}
			Singleton<EventSystem>.Instance.Emit<string>(EEventName.RemoveFloatTips, promptKey);
		}

		// Token: 0x04021AA3 RID: 137891
		private readonly Queue<IPromptParamHub> WaitQueue = new Queue<IPromptParamHub>(4);
	}
}
