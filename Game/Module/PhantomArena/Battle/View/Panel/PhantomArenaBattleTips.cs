using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Panel
{
	// Token: 0x020055BA RID: 21946
	[NullableContext(1)]
	[Nullable(0)]
	public class PhantomArenaBattleTips : UiPanelBase
	{
		// Token: 0x06037E1D RID: 228893 RVA: 0x00E28B6F File Offset: 0x00E26D6F
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIItem))
			};
		}

		// Token: 0x06037E1E RID: 228894 RVA: 0x00E28BA8 File Offset: 0x00E26DA8
		protected UniTask InitCardItem()
		{
			PhantomArenaBattleTips.<InitCardItem>d__6 <InitCardItem>d__;
			<InitCardItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitCardItem>d__.<>4__this = this;
			<InitCardItem>d__.<>1__state = -1;
			<InitCardItem>d__.<>t__builder.Start<PhantomArenaBattleTips.<InitCardItem>d__6>(ref <InitCardItem>d__);
			return <InitCardItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E1F RID: 228895 RVA: 0x00E28BEC File Offset: 0x00E26DEC
		protected UniTask InitDetailsTipsItem()
		{
			PhantomArenaBattleTips.<InitDetailsTipsItem>d__7 <InitDetailsTipsItem>d__;
			<InitDetailsTipsItem>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<InitDetailsTipsItem>d__.<>4__this = this;
			<InitDetailsTipsItem>d__.<>1__state = -1;
			<InitDetailsTipsItem>d__.<>t__builder.Start<PhantomArenaBattleTips.<InitDetailsTipsItem>d__7>(ref <InitDetailsTipsItem>d__);
			return <InitDetailsTipsItem>d__.<>t__builder.Task;
		}

		// Token: 0x06037E20 RID: 228896 RVA: 0x00E28C30 File Offset: 0x00E26E30
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaBattleTips.<OnBeforeStartAsync>d__8 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaBattleTips.<OnBeforeStartAsync>d__8>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037E21 RID: 228897 RVA: 0x00E28C73 File Offset: 0x00E26E73
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Sequence.BindOnEndSequenceEvent(new Action<string>(this.SequenceEnd));
		}

		// Token: 0x06037E22 RID: 228898 RVA: 0x00E28C9D File Offset: 0x00E26E9D
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037E23 RID: 228899 RVA: 0x00E28CAA File Offset: 0x00E26EAA
		private void SequenceEnd(string sequenceName)
		{
			if (sequenceName == "Close")
			{
				this.SetActive(false);
			}
		}

		// Token: 0x06037E24 RID: 228900 RVA: 0x00E28CC0 File Offset: 0x00E26EC0
		public void RefreshTips(PhantomCardData cardData, bool isCardItemShow)
		{
			this.CardItem.SetUiActive(isCardItemShow);
			this.CardItem.Refresh(cardData);
			this.DetailsTipsItem.RefreshByCardData(cardData);
		}

		// Token: 0x06037E25 RID: 228901 RVA: 0x00E28CE8 File Offset: 0x00E26EE8
		public void SetTipsActive(bool isActive)
		{
			if (this.IsInActive == isActive)
			{
				return;
			}
			this.IsInActive = isActive;
			if (this.IsInActive)
			{
				this.SetActive(true);
				this.Sequence.StopPrevSequence(false, true);
				this.Sequence.PlaySequence("Start", false, null);
				return;
			}
			this.Sequence.StopPrevSequence(false, true);
			this.Sequence.PlaySequence("Close", false, null);
		}

		// Token: 0x06037E26 RID: 228902 RVA: 0x00E28D64 File Offset: 0x00E26F64
		public int GetCardId()
		{
			return this.CardItem.Data.CardId;
		}

		// Token: 0x06037E27 RID: 228903 RVA: 0x00E28D76 File Offset: 0x00E26F76
		public void RefreshContent()
		{
			this.DetailsTipsItem.RefreshByCardData(this.CardItem.Data);
		}

		// Token: 0x06037E28 RID: 228904 RVA: 0x00E28D90 File Offset: 0x00E26F90
		public override UUIItem[] GetGuideUiItemAndUiItemForShowEx(string[] configParams)
		{
			if (configParams == null || configParams.Length == 0)
			{
				return null;
			}
			string a = configParams[0];
			if (a == "CardEffect" || a == "CardAttr" || a == "CardFullInfo")
			{
				PhantomArenaBattleDetailsTips detailsTipsItem = this.DetailsTipsItem;
				if (detailsTipsItem == null)
				{
					return null;
				}
				return detailsTipsItem.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
			else
			{
				if (!(a == "DetailCard"))
				{
					return null;
				}
				PhantomArenaCard cardItem = this.CardItem;
				if (cardItem == null)
				{
					return null;
				}
				return cardItem.GetGuideUiItemAndUiItemForShowEx(configParams);
			}
		}

		// Token: 0x0401FFAE RID: 130990
		protected UiSequencePlayer Sequence;

		// Token: 0x0401FFAF RID: 130991
		protected PhantomArenaCard CardItem;

		// Token: 0x0401FFB0 RID: 130992
		protected PhantomArenaBattleDetailsTips DetailsTipsItem;

		// Token: 0x0401FFB1 RID: 130993
		public bool IsInActive;

		// Token: 0x0200B57B RID: 46459
		[NullableContext(0)]
		private class EComponentDefine
		{
			// Token: 0x04038295 RID: 230037
			public const int CardItem = 0;

			// Token: 0x04038296 RID: 230038
			public const int ContentItem = 1;
		}
	}
}
