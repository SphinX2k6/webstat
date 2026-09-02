using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PhantomArena.Battle.Model;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem;
using CSharpScript.Game.Module.PhantomArena.Common.CardItem.Component;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Battle.Card
{
	// Token: 0x02005624 RID: 22052
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class PhantomArenaReplaceCard : GridProxyAbstract<PhantomCardData>, IPhantomCardProxy, IPhantomCardProxyBase
	{
		// Token: 0x06038337 RID: 230199 RVA: 0x00E3B528 File Offset: 0x00E39728
		protected override UniTask OnBeforeStartAsync()
		{
			PhantomArenaReplaceCard.<OnBeforeStartAsync>d__2 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<PhantomArenaReplaceCard.<OnBeforeStartAsync>d__2>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06038338 RID: 230200 RVA: 0x00E3B56B File Offset: 0x00E3976B
		public override void Refresh(PhantomCardData data, bool isSelected, int gridIndex)
		{
			this.Card.Refresh(data);
		}

		// Token: 0x06038339 RID: 230201 RVA: 0x00E3B579 File Offset: 0x00E39779
		private void ShowReplaceState()
		{
			CardReplaceComponent component = this.Card.GetComponent<CardReplaceComponent>(ECardItemComponent.CardReplaceComponent);
			if (component == null)
			{
				return;
			}
			component.SetActive(true);
		}

		// Token: 0x0603833A RID: 230202 RVA: 0x00E3B592 File Offset: 0x00E39792
		private void HideReplaceState()
		{
			CardReplaceComponent component = this.Card.GetComponent<CardReplaceComponent>(ECardItemComponent.CardReplaceComponent);
			if (component == null)
			{
				return;
			}
			component.SetActive(false);
		}

		// Token: 0x0603833B RID: 230203 RVA: 0x00E3B5AB File Offset: 0x00E397AB
		public void PointerClickCard(int id, EToggleState state)
		{
			if (state == EToggleState.ETT_Checked)
			{
				this.ShowReplaceState();
				Action<int, bool> clickCallback = this.ClickCallback;
				if (clickCallback == null)
				{
					return;
				}
				clickCallback(id, true);
				return;
			}
			else
			{
				this.HideReplaceState();
				Action<int, bool> clickCallback2 = this.ClickCallback;
				if (clickCallback2 == null)
				{
					return;
				}
				clickCallback2(id, false);
				return;
			}
		}

		// Token: 0x0603833C RID: 230204 RVA: 0x00E3B5E2 File Offset: 0x00E397E2
		public void SetSelectState(bool value)
		{
			this.Card.SetSelectedState(value);
		}

		// Token: 0x0603833D RID: 230205 RVA: 0x00E3B5F0 File Offset: 0x00E397F0
		public void PointerEnterCard(int id)
		{
		}

		// Token: 0x0603833E RID: 230206 RVA: 0x00E3B5F2 File Offset: 0x00E397F2
		public void PointerDownCard(int id, ULGUIPointerEventData eventData)
		{
		}

		// Token: 0x0603833F RID: 230207 RVA: 0x00E3B5F4 File Offset: 0x00E397F4
		public override object GetKey(PhantomCardData data, int displayIndex)
		{
			return data.CardId;
		}

		// Token: 0x0402019B RID: 131483
		public PhantomArenaCard Card;

		// Token: 0x0402019C RID: 131484
		public Action<int, bool> ClickCallback;
	}
}
