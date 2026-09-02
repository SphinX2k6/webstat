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

namespace CSharpScript.Game.Module.PhantomArena.Battle.View.Choose
{
	// Token: 0x020055CD RID: 21965
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaChooseCardItem : GridProxyAbstract<PhantomCardData>, IPhantomCardProxy, IPhantomCardProxyBase
	{
		// Token: 0x06037F53 RID: 229203 RVA: 0x00E2CB1C File Offset: 0x00E2AD1C
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaChooseCardItem.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaChooseCardItem.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037F54 RID: 229204 RVA: 0x00E2CB5F File Offset: 0x00E2AD5F
		public override void Refresh(PhantomCardData data, bool isSelected, int gridIndex)
		{
			this.Card.Refresh(data);
			this.Card.SetToggleState(EToggleState.ETT_UnChecked, false);
			this.SetSelectStateWithoutSequence();
			this.SetChooseStateWithoutSequence();
		}

		// Token: 0x06037F55 RID: 229205 RVA: 0x00E2CB86 File Offset: 0x00E2AD86
		public void SetSelectStateWithoutSequence()
		{
			this.Card.SetSelectedStateWithoutSequence();
		}

		// Token: 0x06037F56 RID: 229206 RVA: 0x00E2CB93 File Offset: 0x00E2AD93
		public void SetSelectState(bool value)
		{
			this.Card.SetSelectedState(value);
		}

		// Token: 0x06037F57 RID: 229207 RVA: 0x00E2CBA1 File Offset: 0x00E2ADA1
		public void SetChooseStateWithoutSequence()
		{
			this.Card.GetComponent<CardCommonComponent>(ECardItemComponent.CardChooseComponent).SetComponentDisActiveWithoutSequence();
		}

		// Token: 0x06037F58 RID: 229208 RVA: 0x00E2CBB4 File Offset: 0x00E2ADB4
		public void SetChooseState(bool value)
		{
			this.Card.GetComponent<CardCommonComponent>(ECardItemComponent.CardChooseComponent).SetComponentActive(value);
		}

		// Token: 0x06037F59 RID: 229209 RVA: 0x00E2CBC8 File Offset: 0x00E2ADC8
		public void PointerClickCard(int id, EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				Action<PhantomCardData, bool> clickCallback = this.ClickCallback;
				if (clickCallback == null)
				{
					return;
				}
				clickCallback(this.Card.Data, true);
				return;
			}
			else
			{
				Action<PhantomCardData, bool> clickCallback2 = this.ClickCallback;
				if (clickCallback2 == null)
				{
					return;
				}
				clickCallback2(this.Card.Data, false);
				return;
			}
		}

		// Token: 0x06037F5A RID: 229210 RVA: 0x00E2CC07 File Offset: 0x00E2AE07
		public void PointerEnterCard(int id)
		{
		}

		// Token: 0x06037F5B RID: 229211 RVA: 0x00E2CC09 File Offset: 0x00E2AE09
		public void PointerDownCard(int id, ULGUIPointerEventData eventData)
		{
		}

		// Token: 0x06037F5C RID: 229212 RVA: 0x00E2CC0B File Offset: 0x00E2AE0B
		public override object GetKey(PhantomCardData data, int displayIndex)
		{
			return data.CardId;
		}

		// Token: 0x04020004 RID: 131076
		public PhantomArenaCard Card;

		// Token: 0x04020005 RID: 131077
		public Action<PhantomCardData, bool> ClickCallback;
	}
}
