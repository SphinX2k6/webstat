using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Common.MediumItemGrid
{
	// Token: 0x02005E51 RID: 24145
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class LoopScrollMediumItemGrid<[Nullable(2)] TData> : MediumItemGrid, IGridProxy<TData>
	{
		// Token: 0x17009943 RID: 39235
		// (get) Token: 0x0603CC19 RID: 248857 RVA: 0x00F6D6B2 File Offset: 0x00F6B8B2
		// (set) Token: 0x0603CC1A RID: 248858 RVA: 0x00F6D6BA File Offset: 0x00F6B8BA
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<TData>, TData> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x17009944 RID: 39236
		// (get) Token: 0x0603CC1B RID: 248859 RVA: 0x00F6D6C3 File Offset: 0x00F6B8C3
		// (set) Token: 0x0603CC1C RID: 248860 RVA: 0x00F6D6CB File Offset: 0x00F6B8CB
		public int GridIndex { get; set; }

		// Token: 0x17009945 RID: 39237
		// (get) Token: 0x0603CC1D RID: 248861 RVA: 0x00F6D6D4 File Offset: 0x00F6B8D4
		// (set) Token: 0x0603CC1E RID: 248862 RVA: 0x00F6D6DC File Offset: 0x00F6B8DC
		public int DisplayIndex { get; set; }

		// Token: 0x0603CC1F RID: 248863 RVA: 0x00F6D6E5 File Offset: 0x00F6B8E5
		public void Refresh(TData data, bool isSelected, int gridIndex)
		{
			this.OnRefresh(data, isSelected, gridIndex);
		}

		// Token: 0x0603CC20 RID: 248864
		protected abstract void OnRefresh(TData data, bool isSelected, int gridIndex);

		// Token: 0x0603CC21 RID: 248865 RVA: 0x00F6D6F0 File Offset: 0x00F6B8F0
		public void Clear()
		{
		}

		// Token: 0x0603CC22 RID: 248866 RVA: 0x00F6D6F2 File Offset: 0x00F6B8F2
		public virtual void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x0603CC23 RID: 248867 RVA: 0x00F6D6F4 File Offset: 0x00F6B8F4
		public virtual void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0603CC24 RID: 248868 RVA: 0x00F6D6F6 File Offset: 0x00F6B8F6
		public virtual void CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0603CC25 RID: 248869 RVA: 0x00F6D700 File Offset: 0x00F6B900
		public virtual UniTask CreateThenShowByActorAsync(AActor actor)
		{
			LoopScrollMediumItemGrid<TData>.<CreateThenShowByActorAsync>d__18 <CreateThenShowByActorAsync>d__;
			<CreateThenShowByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateThenShowByActorAsync>d__.<>4__this = this;
			<CreateThenShowByActorAsync>d__.actor = actor;
			<CreateThenShowByActorAsync>d__.<>1__state = -1;
			<CreateThenShowByActorAsync>d__.<>t__builder.Start<LoopScrollMediumItemGrid<TData>.<CreateThenShowByActorAsync>d__18>(ref <CreateThenShowByActorAsync>d__);
			return <CreateThenShowByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CC26 RID: 248870 RVA: 0x00F6D74C File Offset: 0x00F6B94C
		public virtual UniTask CreateByActorAsync(AActor actor)
		{
			LoopScrollMediumItemGrid<TData>.<CreateByActorAsync>d__19 <CreateByActorAsync>d__;
			<CreateByActorAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<CreateByActorAsync>d__.<>4__this = this;
			<CreateByActorAsync>d__.actor = actor;
			<CreateByActorAsync>d__.<>1__state = -1;
			<CreateByActorAsync>d__.<>t__builder.Start<LoopScrollMediumItemGrid<TData>.<CreateByActorAsync>d__19>(ref <CreateByActorAsync>d__);
			return <CreateByActorAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603CC27 RID: 248871 RVA: 0x00F6D797 File Offset: 0x00F6B997
		public virtual object GetKey(TData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
