using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Card;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Discard
{
	// Token: 0x020055C8 RID: 21960
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaDiscardCardItem : GridProxyAbstract<PhantomCardData>, IPhantomCardProxy, IPhantomCardProxyBase
	{
		// Token: 0x06037F0D RID: 229133 RVA: 0x00E2C048 File Offset: 0x00E2A248
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaDiscardCardItem.<OnBeforeStartAsync>d__3 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaDiscardCardItem.<OnBeforeStartAsync>d__3>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037F0E RID: 229134 RVA: 0x00E2C08C File Offset: 0x00E2A28C
		public override void Refresh(PhantomCardData data, bool isSelected, int gridIndex)
		{
			this.Card.Refresh(data);
			EToggleState state = (data.UseCost == 0) ? EToggleState.ETT_UnDetermined : EToggleState.ETT_UnChecked;
			this.Card.SetToggleState(state, false);
			this.SetSelectStateWithoutSequence();
			this.SetChooseStateWithoutSequence();
		}

		// Token: 0x06037F0F RID: 229135 RVA: 0x00E2C0CC File Offset: 0x00E2A2CC
		public void PointerClickCard(int id, EToggleState state)
		{
			if (this.Card.Data.IsField)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1187", Array.Empty<object>());
				return;
			}
			if (this.Card.Data.UseCost == 0)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("PhantomBattle_1186", Array.Empty<object>());
				return;
			}
			Action<PhantomCardData, bool> clickCallback = this.ClickCallback;
			if (clickCallback == null)
			{
				return;
			}
			clickCallback(this.Card.Data, !this.IsChoose);
		}

		// Token: 0x06037F10 RID: 229136 RVA: 0x00E2C14B File Offset: 0x00E2A34B
		public void SetSelectStateWithoutSequence()
		{
			this.Card.SetSelectedStateWithoutSequence();
		}

		// Token: 0x06037F11 RID: 229137 RVA: 0x00E2C158 File Offset: 0x00E2A358
		public void SetSelectState(bool value)
		{
			this.Card.SetSelectedState(value);
		}

		// Token: 0x06037F12 RID: 229138 RVA: 0x00E2C166 File Offset: 0x00E2A366
		public void SetChooseStateWithoutSequence()
		{
			this.Card.GetComponent<CardCommonComponent>(ECardItemComponent.CardChooseComponent).SetComponentDisActiveWithoutSequence();
			this.IsChoose = false;
		}

		// Token: 0x06037F13 RID: 229139 RVA: 0x00E2C180 File Offset: 0x00E2A380
		public void SetChooseState(bool value)
		{
			this.Card.GetComponent<CardCommonComponent>(ECardItemComponent.CardChooseComponent).SetComponentActive(value);
			this.IsChoose = value;
		}

		// Token: 0x06037F14 RID: 229140 RVA: 0x00E2C19B File Offset: 0x00E2A39B
		public void PointerEnterCard(int id)
		{
		}

		// Token: 0x06037F15 RID: 229141 RVA: 0x00E2C19D File Offset: 0x00E2A39D
		public void PointerDownCard(int id, ULGUIPointerEventData eventData)
		{
		}

		// Token: 0x06037F16 RID: 229142 RVA: 0x00E2C19F File Offset: 0x00E2A39F
		public override object GetKey(PhantomCardData data, int displayIndex)
		{
			return data.CardId;
		}

		// Token: 0x0401FFF4 RID: 131060
		public PhantomArenaCard Card;

		// Token: 0x0401FFF5 RID: 131061
		public Action<PhantomCardData, bool> ClickCallback;

		// Token: 0x0401FFF6 RID: 131062
		protected bool IsChoose;
	}
}
