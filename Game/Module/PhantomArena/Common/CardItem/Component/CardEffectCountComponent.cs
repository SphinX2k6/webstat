using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component
{
	// Token: 0x0200554D RID: 21837
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardEffectCountComponent : CardComponentBase<ICardEffectCountComponentData>
	{
		// Token: 0x06037A8A RID: 227978 RVA: 0x00E1E3E8 File Offset: 0x00E1C5E8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUILayoutBase)),
				new ValueTuple<int, Type>(2, typeof(UUIItem))
			};
		}

		// Token: 0x06037A8B RID: 227979 RVA: 0x00E1E444 File Offset: 0x00E1C644
		protected override void OnStart()
		{
			this.Sequence = new UiSequencePlayer(this.RootItem);
			this.Layout = new GenericLayout<EffectCountItem, IEffectCountItemData>(base.GetLayoutBase(1), new Func<EffectCountItem>(this.InitEffectCountItem), base.GetItem(2).GetOwner() as AUIBaseActor, false, true);
		}

		// Token: 0x06037A8C RID: 227980 RVA: 0x00E1E493 File Offset: 0x00E1C693
		protected override void OnBeforeDestroy()
		{
			this.Sequence.Clear();
		}

		// Token: 0x06037A8D RID: 227981 RVA: 0x00E1E4A0 File Offset: 0x00E1C6A0
		private EffectCountItem InitEffectCountItem()
		{
			return new EffectCountItem();
		}

		// Token: 0x06037A8E RID: 227982 RVA: 0x00E1E4A8 File Offset: 0x00E1C6A8
		private void RefreshEffectCount()
		{
			base.GetText(0).SetText(this.Data.EffectCount.ToString() + "/" + this.Data.EffectCountMax.ToString(), true);
		}

		// Token: 0x06037A8F RID: 227983 RVA: 0x00E1E4F4 File Offset: 0x00E1C6F4
		private UniTask ShowFullEffect()
		{
			CardEffectCountComponent.<ShowFullEffect>d__8 <ShowFullEffect>d__;
			<ShowFullEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowFullEffect>d__.<>4__this = this;
			<ShowFullEffect>d__.<>1__state = -1;
			<ShowFullEffect>d__.<>t__builder.Start<CardEffectCountComponent.<ShowFullEffect>d__8>(ref <ShowFullEffect>d__);
			return <ShowFullEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037A90 RID: 227984 RVA: 0x00E1E538 File Offset: 0x00E1C738
		private UniTask ShowAddEffect(int lastEffectCount, int newEffectCount)
		{
			CardEffectCountComponent.<ShowAddEffect>d__9 <ShowAddEffect>d__;
			<ShowAddEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowAddEffect>d__.<>4__this = this;
			<ShowAddEffect>d__.lastEffectCount = lastEffectCount;
			<ShowAddEffect>d__.newEffectCount = newEffectCount;
			<ShowAddEffect>d__.<>1__state = -1;
			<ShowAddEffect>d__.<>t__builder.Start<CardEffectCountComponent.<ShowAddEffect>d__9>(ref <ShowAddEffect>d__);
			return <ShowAddEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037A91 RID: 227985 RVA: 0x00E1E58C File Offset: 0x00E1C78C
		private UniTask ShowResetEffect()
		{
			CardEffectCountComponent.<ShowResetEffect>d__10 <ShowResetEffect>d__;
			<ShowResetEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<ShowResetEffect>d__.<>4__this = this;
			<ShowResetEffect>d__.<>1__state = -1;
			<ShowResetEffect>d__.<>t__builder.Start<CardEffectCountComponent.<ShowResetEffect>d__10>(ref <ShowResetEffect>d__);
			return <ShowResetEffect>d__.<>t__builder.Task;
		}

		// Token: 0x06037A92 RID: 227986 RVA: 0x00E1E5D0 File Offset: 0x00E1C7D0
		private void RefreshEffectCountItemList()
		{
			List<IEffectCountItemData> list = new List<IEffectCountItemData>();
			for (int i = 0; i < this.Data.EffectCountMax; i++)
			{
				EffectCountItemData item = new EffectCountItemData
				{
					IsActive = (i < this.Data.EffectCount)
				};
				list.Add(item);
			}
			this.Layout.RefreshByData(list, null, false);
		}

		// Token: 0x06037A93 RID: 227987 RVA: 0x00E1E628 File Offset: 0x00E1C828
		public override void Refresh(ICardEffectCountComponentData data)
		{
			if (!data.InFight)
			{
				this.SetActive(false);
				return;
			}
			this.SetActive(true);
			ICardEffectCountComponentData data2 = this.Data;
			bool flag = data2 != null && data2.InFight;
			if (data.InFight != flag)
			{
				this.Data = data;
				this.RefreshEffectCount();
				this.RefreshEffectCountItemList();
			}
		}

		// Token: 0x06037A94 RID: 227988 RVA: 0x00E1E67C File Offset: 0x00E1C87C
		public UniTask RefreshEffect(ICardEffectCountComponentData data)
		{
			CardEffectCountComponent.<RefreshEffect>d__13 <RefreshEffect>d__;
			<RefreshEffect>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<RefreshEffect>d__.<>4__this = this;
			<RefreshEffect>d__.data = data;
			<RefreshEffect>d__.<>1__state = -1;
			<RefreshEffect>d__.<>t__builder.Start<CardEffectCountComponent.<RefreshEffect>d__13>(ref <RefreshEffect>d__);
			return <RefreshEffect>d__.<>t__builder.Task;
		}

		// Token: 0x0401FE60 RID: 130656
		protected ICardEffectCountComponentData Data;

		// Token: 0x0401FE61 RID: 130657
		protected GenericLayout<EffectCountItem, IEffectCountItemData> Layout;

		// Token: 0x0401FE62 RID: 130658
		protected UiSequencePlayer Sequence;

		// Token: 0x0200B4D5 RID: 46293
		[NullableContext(0)]
		private static class EComponentDefine
		{
			// Token: 0x04037FA3 RID: 229283
			public const int EffectText = 0;

			// Token: 0x04037FA4 RID: 229284
			public const int EffectCountLayout = 1;

			// Token: 0x04037FA5 RID: 229285
			public const int EffectCountItem = 2;
		}
	}
}
