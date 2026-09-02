using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch.Gameplay.Views
{
	// Token: 0x02006916 RID: 26902
	[NullableContext(1)]
	[Nullable(0)]
	internal class DropCatchGameplayPanelViewPool<[Nullable(0)] T> where T : DropCatchGameplayPoolPanelBase
	{
		// Token: 0x06042D0B RID: 273675 RVA: 0x011268CE File Offset: 0x01124ACE
		public void Init([Nullable(new byte[]
		{
			1,
			0,
			1
		})] Func<UniTask<T>> createFn)
		{
			this.CreateFn = createFn;
		}

		// Token: 0x06042D0C RID: 273676 RVA: 0x011268D8 File Offset: 0x01124AD8
		[return: Nullable(new byte[]
		{
			0,
			1
		})]
		public UniTask<T> GetAsync()
		{
			DropCatchGameplayPanelViewPool<T>.<GetAsync>d__4 <GetAsync>d__;
			<GetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<T>.Create();
			<GetAsync>d__.<>4__this = this;
			<GetAsync>d__.<>1__state = -1;
			<GetAsync>d__.<>t__builder.Start<DropCatchGameplayPanelViewPool<T>.<GetAsync>d__4>(ref <GetAsync>d__);
			return <GetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06042D0D RID: 273677 RVA: 0x0112691B File Offset: 0x01124B1B
		public void Recycle(T view)
		{
			if (!this.Active.Contains(view))
			{
				return;
			}
			this.Active.Remove(view);
			view.Hide(null);
			this.Pool.Add(view);
		}

		// Token: 0x06042D0E RID: 273678 RVA: 0x01126954 File Offset: 0x01124B54
		public void RecycleAll()
		{
			foreach (T t in this.Active)
			{
				t.Hide(null);
				this.Pool.Add(t);
			}
			this.Active.Clear();
		}

		// Token: 0x06042D0F RID: 273679 RVA: 0x011269C4 File Offset: 0x01124BC4
		public void DestroyAll()
		{
			foreach (T t in this.Active)
			{
				t.Destroy(null);
			}
			this.Active.Clear();
			foreach (T t2 in this.Pool)
			{
				t2.Destroy(null);
			}
			this.Pool.Clear();
		}

		// Token: 0x040253D2 RID: 152530
		private readonly List<T> Pool = new List<T>();

		// Token: 0x040253D3 RID: 152531
		private readonly HashSet<T> Active = new HashSet<T>();

		// Token: 0x040253D4 RID: 152532
		[Nullable(new byte[]
		{
			1,
			0,
			1
		})]
		private Func<UniTask<T>> CreateFn;
	}
}
