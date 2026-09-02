using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x0200553B RID: 21819
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CommonGridCardItem<[Nullable(2)] TItemData> : CommonBaseCardItem<TItemData>, IGridProxy<TItemData>
	{
		// Token: 0x17008F33 RID: 36659
		// (get) Token: 0x06037A26 RID: 227878 RVA: 0x00E1D8CF File Offset: 0x00E1BACF
		// (set) Token: 0x06037A27 RID: 227879 RVA: 0x00E1D8D7 File Offset: 0x00E1BAD7
		public IScrollViewDelegate<IGridProxy<TItemData>, TItemData> ScrollViewDelegate { get; set; }

		// Token: 0x17008F34 RID: 36660
		// (get) Token: 0x06037A28 RID: 227880 RVA: 0x00E1D8E0 File Offset: 0x00E1BAE0
		// (set) Token: 0x06037A29 RID: 227881 RVA: 0x00E1D8E8 File Offset: 0x00E1BAE8
		public int GridIndex { get; set; }

		// Token: 0x17008F35 RID: 36661
		// (get) Token: 0x06037A2A RID: 227882 RVA: 0x00E1D8F1 File Offset: 0x00E1BAF1
		// (set) Token: 0x06037A2B RID: 227883 RVA: 0x00E1D8F9 File Offset: 0x00E1BAF9
		public int DisplayIndex { get; set; }

		// Token: 0x06037A2C RID: 227884 RVA: 0x00E1D902 File Offset: 0x00E1BB02
		public override void Refresh(TItemData data)
		{
		}

		// Token: 0x06037A2D RID: 227885 RVA: 0x00E1D904 File Offset: 0x00E1BB04
		public virtual void Refresh(TItemData data, bool isSelected, int gridIndex)
		{
		}

		// Token: 0x06037A2E RID: 227886 RVA: 0x00E1D906 File Offset: 0x00E1BB06
		public virtual UniTask RefreshAsync(TItemData data, bool isSelected, int gridIndex)
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x06037A2F RID: 227887 RVA: 0x00E1D90D File Offset: 0x00E1BB0D
		public void Clear()
		{
		}

		// Token: 0x06037A30 RID: 227888 RVA: 0x00E1D90F File Offset: 0x00E1BB0F
		public virtual void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06037A31 RID: 227889 RVA: 0x00E1D911 File Offset: 0x00E1BB11
		public virtual void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06037A32 RID: 227890 RVA: 0x00E1D913 File Offset: 0x00E1BB13
		public virtual object GetKey(TItemData data, int gridIndex)
		{
			return this.GridIndex;
		}
	}
}
