using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Util;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.PhantomArena.Common.CardItem.Item
{
	// Token: 0x02005534 RID: 21812
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class CardElementCountItem : GridProxyAbstract<CardElementCount>
	{
		// Token: 0x060379FE RID: 227838 RVA: 0x00E1CEA8 File Offset: 0x00E1B0A8
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIItem)),
				new ValueTuple<int, Type>(1, typeof(UUIText)),
				new ValueTuple<int, Type>(2, typeof(UUIExtendToggle)),
				new ValueTuple<int, Type>(3, typeof(UUISprite)),
				new ValueTuple<int, Type>(4, typeof(UUISprite))
			};
		}

		// Token: 0x060379FF RID: 227839 RVA: 0x00E1CF30 File Offset: 0x00E1B130
		protected override UniTask OnBeforeStartAsync()
		{
			CardElementCountItem.<OnBeforeStartAsync>d__4 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<CardElementCountItem.<OnBeforeStartAsync>d__4>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x06037A00 RID: 227840 RVA: 0x00E1CF73 File Offset: 0x00E1B173
		protected override void OnStart()
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.OnStateChange.Add(new Action<EToggleState>(this.OnClickToggle));
		}

		// Token: 0x06037A01 RID: 227841 RVA: 0x00E1CF97 File Offset: 0x00E1B197
		public override void Refresh(CardElementCount data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			this.RefreshElement();
			this.RefreshCount();
		}

		// Token: 0x06037A02 RID: 227842 RVA: 0x00E1CFAC File Offset: 0x00E1B1AC
		private void RefreshElement()
		{
			int elementId = this.Data.ElementId;
			if (elementId == -1)
			{
				UUISprite sprite = base.GetSprite(4);
				if (sprite != null)
				{
					sprite.SetUIActive(true);
				}
				this.ItemElement.SetActive(false);
				return;
			}
			if (elementId != 0)
			{
				this.ItemElement.Refresh((ECardElement)this.Data.ElementId, false, 0);
				this.ItemElement.SetActive(this.Data.ElementId != 0);
				return;
			}
			UUISprite sprite2 = base.GetSprite(3);
			if (sprite2 != null)
			{
				sprite2.SetUIActive(true);
			}
			this.ItemElement.SetActive(false);
		}

		// Token: 0x06037A03 RID: 227843 RVA: 0x00E1D040 File Offset: 0x00E1B240
		private void RefreshCount()
		{
			string text = this.Data.Count.ToString();
			string text2 = this.Data.All.ToString();
			base.GetText(1).SetText(StringUtils.Format("{0}/{1}", new string[]
			{
				text,
				text2
			}), true);
		}

		// Token: 0x06037A04 RID: 227844 RVA: 0x00E1D094 File Offset: 0x00E1B294
		private void OnClickToggle(EToggleState state)
		{
			if (state == EToggleState.ETT_UnChecked)
			{
				return;
			}
			if (this.Data == null)
			{
				return;
			}
			Action<int> selectCallBack = this.SelectCallBack;
			if (selectCallBack != null)
			{
				selectCallBack(this.Data.ElementId);
			}
			IScrollViewDelegate<IGridProxy<CardElementCount>, CardElementCount> scrollViewDelegate = base.ScrollViewDelegate;
			if (scrollViewDelegate == null)
			{
				return;
			}
			scrollViewDelegate.SelectGridProxy(base.GridIndex, base.DisplayIndex, false);
		}

		// Token: 0x06037A05 RID: 227845 RVA: 0x00E1D0E7 File Offset: 0x00E1B2E7
		public override void OnSelected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_Checked, fireEvent, false, false);
		}

		// Token: 0x06037A06 RID: 227846 RVA: 0x00E1D0FF File Offset: 0x00E1B2FF
		public override void OnDeselected(bool fireEvent)
		{
			UUIExtendToggle extendToggle = base.GetExtendToggle(2);
			if (extendToggle == null)
			{
				return;
			}
			extendToggle.SetToggleState(EToggleState.ETT_UnChecked, fireEvent, false, false);
		}

		// Token: 0x06037A07 RID: 227847 RVA: 0x00E1D117 File Offset: 0x00E1B317
		public override object GetKey(CardElementCount data, int displayIndex)
		{
			return data.ElementId;
		}

		// Token: 0x0401FE39 RID: 130617
		private CardElementCount Data;

		// Token: 0x0401FE3A RID: 130618
		private CardElementItem ItemElement;

		// Token: 0x0401FE3B RID: 130619
		public Action<int> SelectCallBack;

		// Token: 0x0200B4CB RID: 46283
		[NullableContext(0)]
		private static class EComponents
		{
			// Token: 0x04037F85 RID: 229253
			public const int ItemElement = 0;

			// Token: 0x04037F86 RID: 229254
			public const int TextCount = 1;

			// Token: 0x04037F87 RID: 229255
			public const int Toggle = 2;

			// Token: 0x04037F88 RID: 229256
			public const int IconOther = 3;

			// Token: 0x04037F89 RID: 229257
			public const int IconAll = 4;
		}
	}
}
