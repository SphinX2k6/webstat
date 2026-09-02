using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005537 RID: 21815
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CollectGridCardItem : GridProxyAbstract<CollectGridCardData>
	{
		// Token: 0x06037A11 RID: 227857 RVA: 0x00E1D3BA File Offset: 0x00E1B5BA
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06037A12 RID: 227858 RVA: 0x00E1D3F4 File Offset: 0x00E1B5F4
		public override void Refresh(CollectGridCardData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			if (this.CardItem == null)
			{
				this.CardItem = new CollectCardItem();
				int activityId = ConfigBase<PhantomArenaConfig>.Instance.GetPhantomBattleCardConfig(data.CardId).ActivityId;
				this.CardItem.IsNewPhantomArenaActivity = ModelBase<PhantomArenaModel>.Instance.IsNewPhantomArenaActivity(activityId);
				this.CardItem.CallbackOnClick = this.CallbackOnClick;
				this.CardItem.CreateThenShowByActorAsync(base.GetItem(1).GetOwner(), data, false).Forget();
				return;
			}
			this.CardItem.Refresh(data);
		}

		// Token: 0x06037A13 RID: 227859 RVA: 0x00E1D486 File Offset: 0x00E1B686
		public override void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06037A14 RID: 227860 RVA: 0x00E1D488 File Offset: 0x00E1B688
		public override void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06037A15 RID: 227861 RVA: 0x00E1D48A File Offset: 0x00E1B68A
		public override object GetKey(CollectGridCardData data, int displayIndex)
		{
			return data.CardId;
		}

		// Token: 0x0401FE3C RID: 130620
		protected CollectGridCardData Data;

		// Token: 0x0401FE3D RID: 130621
		private CollectCardItem CardItem;

		// Token: 0x0401FE3E RID: 130622
		public Action<int> CallbackOnClick;

		// Token: 0x0200B4CF RID: 46287
		[NullableContext(0)]
		private static class EGirdComponent
		{
			// Token: 0x04037F92 RID: 229266
			public const int PanelBg = 0;

			// Token: 0x04037F93 RID: 229267
			public const int ItemCard = 1;
		}
	}
}
