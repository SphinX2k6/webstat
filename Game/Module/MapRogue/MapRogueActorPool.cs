using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200592A RID: 22826
	[NullableContext(1)]
	[Nullable(0)]
	public class MapRogueActorPool
	{
		// Token: 0x06039EC2 RID: 237250 RVA: 0x00EA9ADC File Offset: 0x00EA7CDC
		public void Init()
		{
			this.PoolRootActor = Singleton<UiLayer>.Instance.GetLayerRootUiItem(ELayerType.Pool);
			if (this.PoolRootActor == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Pool, ELogAuthor.YYZ, "[MapRogueActorPool] 初始缓存池有问题,挂载根节点为空", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
		}

		// Token: 0x06039EC3 RID: 237251 RVA: 0x00EA9B24 File Offset: 0x00EA7D24
		public void Tick(float deltaTime)
		{
			this.PeriodDeltaTime += deltaTime;
			if (this.PeriodDeltaTime < 100f)
			{
				return;
			}
			this.PeriodDeltaTime = 0f;
			int num = 0;
			foreach (MapUiActorFactory mapUiActorFactory in this.FactoryMap.Values)
			{
				num += mapUiActorFactory.GarbageCollect(10);
				if (num >= 10)
				{
					break;
				}
			}
		}

		// Token: 0x06039EC4 RID: 237252 RVA: 0x00EA9BB0 File Offset: 0x00EA7DB0
		public void Clear()
		{
			foreach (MapUiActorFactory mapUiActorFactory in this.FactoryMap.Values)
			{
				mapUiActorFactory.Clear();
			}
			this.PoolRootActor = null;
			this.FactoryMap.Clear();
		}

		// Token: 0x06039EC5 RID: 237253 RVA: 0x00EA9C18 File Offset: 0x00EA7E18
		public void CancelLoad()
		{
			foreach (MapUiActorFactory mapUiActorFactory in this.FactoryMap.Values)
			{
				mapUiActorFactory.CancelLoad();
			}
		}

		// Token: 0x06039EC6 RID: 237254 RVA: 0x00EA9C70 File Offset: 0x00EA7E70
		private MapUiActorFactory TryGetFactory(string path)
		{
			MapUiActorFactory mapUiActorFactory;
			if (!this.FactoryMap.TryGetValue(path, out mapUiActorFactory))
			{
				mapUiActorFactory = new MapUiActorFactory(path, this.PoolRootActor);
				this.FactoryMap[path] = mapUiActorFactory;
			}
			return mapUiActorFactory;
		}

		// Token: 0x06039EC7 RID: 237255 RVA: 0x00EA9CA8 File Offset: 0x00EA7EA8
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UiPoolActor> GetAsync(string path, [Nullable(2)] UUIItem parent = null)
		{
			return this.TryGetFactory(path).GetAsync(path, parent);
		}

		// Token: 0x06039EC8 RID: 237256 RVA: 0x00EA9CB8 File Offset: 0x00EA7EB8
		public void RecycleAsync(UiPoolActor uiPoolActor, string path)
		{
			this.TryGetFactory(path).Release(uiPoolActor);
		}

		// Token: 0x04020D07 RID: 134407
		private readonly Dictionary<string, MapUiActorFactory> FactoryMap = new Dictionary<string, MapUiActorFactory>();

		// Token: 0x04020D08 RID: 134408
		[Nullable(2)]
		private UUIItem PoolRootActor;

		// Token: 0x04020D09 RID: 134409
		private float PeriodDeltaTime;

		// Token: 0x04020D0A RID: 134410
		private const int TICK_GARBAGE_MAXCOUNT = 10;

		// Token: 0x04020D0B RID: 134411
		public const int PROCESSING_INTERVAL = 100;
	}
}
