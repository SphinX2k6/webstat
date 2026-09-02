using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A40 RID: 19008
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class UiActorPool : Singleton<UiActorPool>
	{
		// Token: 0x06031A8D RID: 203405 RVA: 0x00C5F190 File Offset: 0x00C5D390
		private UiActorFactory TryGetFactory(string path)
		{
			UiActorFactory uiActorFactory;
			if (!this.FactoryMap.TryGetValue(path, out uiActorFactory))
			{
				uiActorFactory = new UiActorFactory(path, this.PoolRootActor);
				this.FactoryMap[path] = uiActorFactory;
			}
			return uiActorFactory;
		}

		// Token: 0x06031A8E RID: 203406 RVA: 0x00C5F1C8 File Offset: 0x00C5D3C8
		[return: Nullable(2)]
		private UiActorFactory GetFactory(string path)
		{
			UiActorFactory result;
			this.FactoryMap.TryGetValue(path, out result);
			return result;
		}

		// Token: 0x06031A8F RID: 203407 RVA: 0x00C5F1E8 File Offset: 0x00C5D3E8
		public UniTask Init()
		{
			UiActorPool.<Init>d__8 <Init>d__;
			<Init>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<UiActorPool.<Init>d__8>(ref <Init>d__);
			return <Init>d__.<>t__builder.Task;
		}

		// Token: 0x06031A90 RID: 203408 RVA: 0x00C5F22C File Offset: 0x00C5D42C
		private UniTask PreloadActor()
		{
			UiActorPool.<PreloadActor>d__9 <PreloadActor>d__;
			<PreloadActor>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<PreloadActor>d__.<>4__this = this;
			<PreloadActor>d__.<>1__state = -1;
			<PreloadActor>d__.<>t__builder.Start<UiActorPool.<PreloadActor>d__9>(ref <PreloadActor>d__);
			return <PreloadActor>d__.<>t__builder.Task;
		}

		// Token: 0x06031A91 RID: 203409 RVA: 0x00C5F270 File Offset: 0x00C5D470
		public void Tick(float deltaTime)
		{
			int num = 1;
			foreach (UiActorFactory uiActorFactory in this.FactoryMap.Values)
			{
				num = uiActorFactory.GarbageCollect(num);
				if (num <= 0)
				{
					break;
				}
			}
		}

		// Token: 0x06031A92 RID: 203410 RVA: 0x00C5F2D0 File Offset: 0x00C5D4D0
		public void ClearPool()
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, UiActorFactory> keyValuePair in this.FactoryMap)
			{
				if (!keyValuePair.Value.IsKeepWhileCleaning)
				{
					keyValuePair.Value.Clear();
					list.Add(keyValuePair.Key);
				}
			}
			foreach (string key in list)
			{
				this.FactoryMap.Remove(key);
			}
		}

		// Token: 0x06031A93 RID: 203411 RVA: 0x00C5F390 File Offset: 0x00C5D590
		public void SetKeepWhileCleaning(string path, bool isKeepWhileCleaning)
		{
			if (!this.IsOpenPool)
			{
				return;
			}
			this.TryGetFactory(path).IsKeepWhileCleaning = isKeepWhileCleaning;
		}

		// Token: 0x06031A94 RID: 203412 RVA: 0x00C5F3A8 File Offset: 0x00C5D5A8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UiPoolActor> GetAsync(string path, [Nullable(2)] UUIItem parent = null)
		{
			UiActorPool.<GetAsync>d__13 <GetAsync>d__;
			<GetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiPoolActor>.Create();
			<GetAsync>d__.<>4__this = this;
			<GetAsync>d__.path = path;
			<GetAsync>d__.parent = parent;
			<GetAsync>d__.<>1__state = -1;
			<GetAsync>d__.<>t__builder.Start<UiActorPool.<GetAsync>d__13>(ref <GetAsync>d__);
			return <GetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06031A95 RID: 203413 RVA: 0x00C5F3FC File Offset: 0x00C5D5FC
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<UiPoolActor> LoadUiPoolActor(string path, [Nullable(2)] UUIItem parent = null)
		{
			UiActorPool.<LoadUiPoolActor>d__14 <LoadUiPoolActor>d__;
			<LoadUiPoolActor>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiPoolActor>.Create();
			<LoadUiPoolActor>d__.path = path;
			<LoadUiPoolActor>d__.parent = parent;
			<LoadUiPoolActor>d__.<>1__state = -1;
			<LoadUiPoolActor>d__.<>t__builder.Start<UiActorPool.<LoadUiPoolActor>d__14>(ref <LoadUiPoolActor>d__);
			return <LoadUiPoolActor>d__.<>t__builder.Task;
		}

		// Token: 0x06031A96 RID: 203414 RVA: 0x00C5F448 File Offset: 0x00C5D648
		public void RecycleAsync([Nullable(2)] UiPoolActor uiPoolActor, string path)
		{
			UiActorFactory factory = this.GetFactory(path);
			if (factory == null)
			{
				if (((uiPoolActor != null) ? uiPoolActor.Actor : null) != null)
				{
					uiPoolActor.Clear();
				}
				return;
			}
			factory.Release(uiPoolActor);
		}

		// Token: 0x0401CE6F RID: 118383
		private const int TICK_GARBAGE_MAXCOUNT = 1;

		// Token: 0x0401CE70 RID: 118384
		private readonly Dictionary<string, UiActorFactory> FactoryMap = new Dictionary<string, UiActorFactory>();

		// Token: 0x0401CE71 RID: 118385
		private readonly Stat StatTick = Stat.Create("UiActorPool.Tick", "", "");

		// Token: 0x0401CE72 RID: 118386
		[Nullable(2)]
		private UUIItem PoolRootActor;

		// Token: 0x0401CE73 RID: 118387
		public Dictionary<string, Func<int>> PrepareConfigMap = new Dictionary<string, Func<int>>();

		// Token: 0x0401CE74 RID: 118388
		public bool IsOpenPool = true;
	}
}
