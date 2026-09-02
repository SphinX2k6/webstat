using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005929 RID: 22825
	[NullableContext(1)]
	[Nullable(0)]
	public class MapUiActorFactory
	{
		// Token: 0x06039EBB RID: 237243 RVA: 0x00EA987B File Offset: 0x00EA7A7B
		public MapUiActorFactory(string path, UUIItem poolRoot)
		{
			this.PathInternal = path;
			this.PoolRootInternal = poolRoot;
		}

		// Token: 0x06039EBC RID: 237244 RVA: 0x00EA98B4 File Offset: 0x00EA7AB4
		public void Clear()
		{
			this.CancelLoad();
			foreach (UiPoolActor uiPoolActor in this.List)
			{
				uiPoolActor.Clear();
			}
			this.List.Clear();
		}

		// Token: 0x06039EBD RID: 237245 RVA: 0x00EA9918 File Offset: 0x00EA7B18
		public void CancelLoad()
		{
			foreach (int id in this.ResourceIdSet)
			{
				Singleton<ResourceSystem>.Instance.CancelAsyncLoad(id);
			}
			this.ResourceIdSet.Clear();
		}

		// Token: 0x06039EBE RID: 237246 RVA: 0x00EA997C File Offset: 0x00EA7B7C
		public bool Release(UiPoolActor uiPoolActor)
		{
			if (uiPoolActor == null)
			{
				return false;
			}
			if (uiPoolActor.IsValid)
			{
				UUIItem uiItem = uiPoolActor.UiItem;
				if (uiItem != null)
				{
					uiItem.SetUIActive(false);
				}
				UUIItem uiItem2 = uiPoolActor.UiItem;
				if (uiItem2 != null)
				{
					uiItem2.SetUIParent(this.PoolRootInternal, false);
				}
				this.List.Add(uiPoolActor);
				return true;
			}
			return false;
		}

		// Token: 0x06039EBF RID: 237247 RVA: 0x00EA99D0 File Offset: 0x00EA7BD0
		public int GarbageCollect(int allowGarbageCount)
		{
			if (this.List.Count <= 0)
			{
				return 0;
			}
			int num = 0;
			int num2 = 0;
			while (num2 < allowGarbageCount && this.List.Count != 0)
			{
				UiPoolActor uiPoolActor = this.List[this.List.Count - 1];
				this.List.RemoveAt(this.List.Count - 1);
				uiPoolActor.Clear();
				num++;
				num2++;
			}
			return num;
		}

		// Token: 0x06039EC0 RID: 237248 RVA: 0x00EA9A44 File Offset: 0x00EA7C44
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		private UniTask<AActor> LoadActorAsync()
		{
			MapUiActorFactory.<LoadActorAsync>d__10 <LoadActorAsync>d__;
			<LoadActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<AActor>.Create();
			<LoadActorAsync>d__.<>4__this = this;
			<LoadActorAsync>d__.<>1__state = -1;
			<LoadActorAsync>d__.<>t__builder.Start<MapUiActorFactory.<LoadActorAsync>d__10>(ref <LoadActorAsync>d__);
			return <LoadActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06039EC1 RID: 237249 RVA: 0x00EA9A88 File Offset: 0x00EA7C88
		[return: Nullable(new byte[]
		{
			0,
			2
		})]
		public UniTask<UiPoolActor> GetAsync(string path, [Nullable(2)] UUIItem parent = null)
		{
			MapUiActorFactory.<GetAsync>d__11 <GetAsync>d__;
			<GetAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder<UiPoolActor>.Create();
			<GetAsync>d__.<>4__this = this;
			<GetAsync>d__.path = path;
			<GetAsync>d__.parent = parent;
			<GetAsync>d__.<>1__state = -1;
			<GetAsync>d__.<>t__builder.Start<MapUiActorFactory.<GetAsync>d__11>(ref <GetAsync>d__);
			return <GetAsync>d__.<>t__builder.Task;
		}

		// Token: 0x04020D02 RID: 134402
		private readonly string PathInternal = "";

		// Token: 0x04020D03 RID: 134403
		private readonly UUIItem PoolRootInternal;

		// Token: 0x04020D04 RID: 134404
		private readonly List<UiPoolActor> List = new List<UiPoolActor>();

		// Token: 0x04020D05 RID: 134405
		private readonly HashSet<int> ResourceIdSet = new HashSet<int>();

		// Token: 0x04020D06 RID: 134406
		private const int ACTOR_MAX_CACHE_COUNT = 0;
	}
}
