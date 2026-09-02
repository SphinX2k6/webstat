using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x020063DE RID: 25566
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class RoverlikeMultiUseGridProxyAbstract<[Nullable(2)] TData> : UiPanelBase, IGridProxy<TData>, ISyncGridProxy<TData>, ISyncGridProxy
	{
		// Token: 0x17009DBF RID: 40383
		// (get) Token: 0x0604032F RID: 262959 RVA: 0x010742FC File Offset: 0x010724FC
		// (set) Token: 0x06040330 RID: 262960 RVA: 0x01074304 File Offset: 0x01072504
		public int GridIndex { get; set; }

		// Token: 0x17009DC0 RID: 40384
		// (get) Token: 0x06040331 RID: 262961 RVA: 0x0107430D File Offset: 0x0107250D
		// (set) Token: 0x06040332 RID: 262962 RVA: 0x01074315 File Offset: 0x01072515
		public int DisplayIndex { get; set; }

		// Token: 0x17009DC1 RID: 40385
		// (get) Token: 0x06040333 RID: 262963 RVA: 0x0107431E File Offset: 0x0107251E
		// (set) Token: 0x06040334 RID: 262964 RVA: 0x01074326 File Offset: 0x01072526
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		IScrollViewDelegate<IGridProxy<TData>, TData> IGridProxy<!0>.ScrollViewDelegate
		{
			[return: Nullable(new byte[]
			{
				2,
				1,
				1,
				1
			})]
			get
			{
				return this.ScrollViewDelegate;
			}
			[param: Nullable(new byte[]
			{
				2,
				1,
				1,
				1
			})]
			set
			{
				this.ScrollViewDelegate = (value as ScrollViewDelegate<IGridProxy<TData>, TData>);
			}
		}

		// Token: 0x06040335 RID: 262965 RVA: 0x01074334 File Offset: 0x01072534
		public virtual void Refresh(TData data, bool isSelected, int gridIndex)
		{
		}

		// Token: 0x06040336 RID: 262966 RVA: 0x01074336 File Offset: 0x01072536
		public virtual void Refresh(TData data)
		{
			this.Refresh(data, false, this.GridIndex);
		}

		// Token: 0x06040337 RID: 262967 RVA: 0x01074348 File Offset: 0x01072548
		void ISyncGridProxy.Refresh(object data)
		{
			if (data is TData)
			{
				TData data2 = (TData)((object)data);
				this.Refresh(data2);
			}
		}

		// Token: 0x06040338 RID: 262968 RVA: 0x0107436B File Offset: 0x0107256B
		public virtual void Clear()
		{
		}

		// Token: 0x06040339 RID: 262969 RVA: 0x0107436D File Offset: 0x0107256D
		public virtual void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x0604033A RID: 262970 RVA: 0x0107436F File Offset: 0x0107256F
		public virtual void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x0604033B RID: 262971 RVA: 0x01074371 File Offset: 0x01072571
		public void CreateByActor(AActor actor)
		{
			base.CreateByActor(actor, null);
		}

		// Token: 0x0604033C RID: 262972 RVA: 0x0107437B File Offset: 0x0107257B
		public virtual void CreateThenShowByActor(AActor actor)
		{
			base.CreateThenShowByActor(actor, null);
		}

		// Token: 0x0604033D RID: 262973 RVA: 0x01074385 File Offset: 0x01072585
		public virtual object GetKey(TData data, int displayIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x04024017 RID: 147479
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public ScrollViewDelegate<IGridProxy<TData>, TData> ScrollViewDelegate;
	}
}
