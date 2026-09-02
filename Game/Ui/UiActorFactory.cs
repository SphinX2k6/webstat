using System;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A3F RID: 19007
	[NullableContext(1)]
	[Nullable(0)]
	internal class UiActorFactory
	{
		// Token: 0x06031A83 RID: 203395 RVA: 0x00C5EE89 File Offset: 0x00C5D089
		private UiPoolActor Creator()
		{
			return new UiPoolActor(this.PathInternal)
			{
				EndTime = Singleton<Time>.Instance.Now + 30000.0
			};
		}

		// Token: 0x06031A84 RID: 203396 RVA: 0x00C5EEB0 File Offset: 0x00C5D0B0
		private void Clearer(UiPoolActor uiPoolActor)
		{
			uiPoolActor.Clear();
		}

		// Token: 0x06031A85 RID: 203397 RVA: 0x00C5EEB8 File Offset: 0x00C5D0B8
		public UiActorFactory(string path, [Nullable(2)] UUIItem poolRoot)
		{
			this.PathInternal = path;
			this.PoolRootInternal = poolRoot;
			Func<int> func;
			this.PoolCacheCount = (Singleton<UiActorPool>.Instance.PrepareConfigMap.TryGetValue(path, out func) ? func() : 0);
			if (poolRoot == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Pool, ELogAuthor.XXJ, "[UiActorFactory:constructor]初始化缓存池有问题,缓存池挂载根节点为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06031A86 RID: 203398 RVA: 0x00C5EF44 File Offset: 0x00C5D144
		public UniTask PreloadActor(Func<int> cacheCount)
		{
			UiActorFactory.<PreloadActor>d__8 <PreloadActor>d__;
			<PreloadActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadActor>d__.<>4__this = this;
			<PreloadActor>d__.cacheCount = cacheCount;
			<PreloadActor>d__.<>1__state = -1;
			<PreloadActor>d__.<>t__builder.Start<UiActorFactory.<PreloadActor>d__8>(ref <PreloadActor>d__);
			return <PreloadActor>d__.<>t__builder.Task;
		}

		// Token: 0x06031A87 RID: 203399 RVA: 0x00C5EF90 File Offset: 0x00C5D190
		public bool Release(UiPoolActor uiPoolActor)
		{
			if (uiPoolActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Pool, ELogAuthor.TL, "回收UiPoolActor对象不存在", default(ReadOnlySpan<ValueTuple<string, object>>));
				this.CancelGetAsync();
				return false;
			}
			this.Queue.Push(uiPoolActor);
			if (uiPoolActor.IsValid)
			{
				UUIItem uiItem = uiPoolActor.UiItem;
				if (uiItem != null)
				{
					uiItem.SetUIParent(this.PoolRootInternal, false);
				}
				uiPoolActor.EndTime = Singleton<Time>.Instance.Now + 30000.0;
			}
			else
			{
				uiPoolActor.EndTime = Singleton<Time>.Instance.Now;
			}
			return true;
		}

		// Token: 0x06031A88 RID: 203400 RVA: 0x00C5F020 File Offset: 0x00C5D220
		public int GarbageCollect(int allowGarbageCount)
		{
			if (this.Queue.Size <= this.PoolCacheCount)
			{
				return allowGarbageCount;
			}
			int num = 0;
			int num2 = 0;
			while (num2 < allowGarbageCount && !this.Queue.Empty)
			{
				UiPoolActor front = this.Queue.Front;
				if (front.EndTime > Singleton<Time>.Instance.Now)
				{
					break;
				}
				this.Queue.Pop();
				this.Clearer(front);
				num++;
				num2++;
			}
			return allowGarbageCount - num;
		}

		// Token: 0x06031A89 RID: 203401 RVA: 0x00C5F098 File Offset: 0x00C5D298
		public void Clear()
		{
			while (!this.Queue.Empty)
			{
				UiPoolActor uiPoolActor = this.Queue.Pop();
				this.Clearer(uiPoolActor);
			}
			this.Queue.Clear();
		}

		// Token: 0x06031A8A RID: 203402 RVA: 0x00C5F0D4 File Offset: 0x00C5D2D4
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<AActor> LoadActorAsync()
		{
			UiActorFactory.<LoadActorAsync>d__13 <LoadActorAsync>d__;
			<LoadActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadActorAsync>d__.<>4__this = this;
			<LoadActorAsync>d__.<>1__state = -1;
			<LoadActorAsync>d__.<>t__builder.Start<UiActorFactory.<LoadActorAsync>d__13>(ref <LoadActorAsync>d__);
			return <LoadActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A8B RID: 203403 RVA: 0x00C5F118 File Offset: 0x00C5D318
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UiPoolActor> GetAsync(string path, [Nullable(2)] UUIItem parent = null)
		{
			UiActorFactory.<GetAsync>d__14 <GetAsync>d__;
			<GetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiPoolActor>.Create();
			<GetAsync>d__.<>4__this = this;
			<GetAsync>d__.path = path;
			<GetAsync>d__.parent = parent;
			<GetAsync>d__.<>1__state = -1;
			<GetAsync>d__.<>t__builder.Start<UiActorFactory.<GetAsync>d__14>(ref <GetAsync>d__);
			return <GetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A8C RID: 203404 RVA: 0x00C5F16B File Offset: 0x00C5D36B
		public void CancelGetAsync()
		{
			Singleton<LguiResourceManager>.Instance.CancelLoadPrefab(this.AsyncHandleId);
			this.AsyncHandleId = Singleton<LguiResourceManager>.Instance.InvalidId;
		}

		// Token: 0x0401CE69 RID: 118377
		private readonly string PathInternal = "";

		// Token: 0x0401CE6A RID: 118378
		[Nullable(2)]
		private readonly UUIItem PoolRootInternal;

		// Token: 0x0401CE6B RID: 118379
		private int PoolCacheCount;

		// Token: 0x0401CE6C RID: 118380
		public bool IsKeepWhileCleaning;

		// Token: 0x0401CE6D RID: 118381
		private readonly Queue<UiPoolActor> Queue = new Queue<UiPoolActor>(15);

		// Token: 0x0401CE6E RID: 118382
		private int AsyncHandleId = Singleton<LguiResourceManager>.Instance.InvalidId;
	}
}
