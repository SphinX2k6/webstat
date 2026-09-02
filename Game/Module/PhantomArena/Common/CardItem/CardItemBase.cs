using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem
{
	// Token: 0x0200552C RID: 21804
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class CardItemBase<[Nullable(2)] TItemData> : UiPanelBase
	{
		// Token: 0x060379D9 RID: 227801 RVA: 0x00E1C890 File Offset: 0x00E1AA90
		private void RegisterCardComponent()
		{
			this.OnRegisterCardComponent();
		}

		// Token: 0x060379DA RID: 227802 RVA: 0x00E1C898 File Offset: 0x00E1AA98
		protected virtual void OnRegisterCardComponent()
		{
		}

		// Token: 0x060379DB RID: 227803 RVA: 0x00E1C89C File Offset: 0x00E1AA9C
		protected override UniTask OnBeforeStartAsync()
		{
			CardItemBase<TItemData>.<OnBeforeStartAsync>d__5 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CardItemBase<TItemData>.<OnBeforeStartAsync>d__5>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x060379DC RID: 227804 RVA: 0x00E1C8E0 File Offset: 0x00E1AAE0
		[NullableContext(2)]
		private ICardComponentBase AddComponent(ECardItemComponent key)
		{
			ICardComponentBase cardComponentBase = this.GetComponent<ICardComponentBase>(key);
			if (cardComponentBase != null)
			{
				Singleton<Log>.Instance.Error(ELogModule.PhantomArena, ELogAuthor.LZK, "重复添加组件", default(ReadOnlySpan<ValueTuple<string, object>>));
				return cardComponentBase;
			}
			if (CardItemDefine.cardItemCreatorMap.ContainsKey(key))
			{
				cardComponentBase = CardItemDefine.cardItemCreatorMap[key]();
				this.ComponentsMap[key] = cardComponentBase;
			}
			return cardComponentBase;
		}

		// Token: 0x060379DD RID: 227805 RVA: 0x00E1C948 File Offset: 0x00E1AB48
		[return: Nullable(2)]
		public T GetComponent<T>(ECardItemComponent key) where T : class, ICardComponentBase
		{
			ICardComponentBase cardComponentBase;
			if (!this.ComponentsMap.TryGetValue(key, out cardComponentBase))
			{
				return default(T);
			}
			return cardComponentBase as T;
		}

		// Token: 0x060379DE RID: 227806
		public abstract void Refresh(TItemData data);

		// Token: 0x060379DF RID: 227807 RVA: 0x00E1C97A File Offset: 0x00E1AB7A
		protected virtual UniTask OnBeforeChildStartAsync()
		{
			return UniTask.CompletedTask;
		}

		// Token: 0x0401FE1D RID: 130589
		protected List<TCardComponentsRegisterInfoByItem> ComponentsRegisterInfoByItem = new List<TCardComponentsRegisterInfoByItem>();

		// Token: 0x0401FE1E RID: 130590
		protected List<TCardComponentsRegisterInfoByResourceId> ComponentsRegisterInfoByResourceId = new List<TCardComponentsRegisterInfoByResourceId>();

		// Token: 0x0401FE1F RID: 130591
		private readonly Dictionary<ECardItemComponent, ICardComponentBase> ComponentsMap = new Dictionary<ECardItemComponent, ICardComponentBase>();
	}
}
