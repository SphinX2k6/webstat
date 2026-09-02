using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x020049A9 RID: 18857
	[NullableContext(1)]
	[Nullable(0)]
	public class UiComponentsTween
	{
		// Token: 0x060313CA RID: 201674 RVA: 0x00C428CA File Offset: 0x00C40ACA
		public UiComponentsTween(UUIItem rootItem)
		{
			this.RootItem = rootItem;
		}

		// Token: 0x060313CB RID: 201675 RVA: 0x00C428DC File Offset: 0x00C40ADC
		private void PlayViewTween(bool reverse = false)
		{
			float time = this.UiComponentsTweenData.Time;
			float targetAlpha = this.UiComponentsTweenData.TargetAlpha;
			float startValue = reverse ? targetAlpha : 1f;
			float endValue = reverse ? 1f : targetAlpha;
			foreach (UUIItem uuiitem in this.UnSafeItemList)
			{
				uuiitem.PlayUIItemAlphaTween(startValue, endValue, time);
			}
			float targetSize = this.UiComponentsTweenData.TargetSize;
			float startValue2 = reverse ? targetSize : 1f;
			float endValue2 = reverse ? 1f : targetSize;
			foreach (UUIItem uuiitem2 in this.UnSafeItemList)
			{
				uuiitem2.PlayUIItemScaleTween(startValue2, endValue2, time);
			}
		}

		// Token: 0x060313CC RID: 201676 RVA: 0x00C429D0 File Offset: 0x00C40BD0
		protected void CollectUnSafeItem()
		{
			if (this.UnSafeItemList != null)
			{
				return;
			}
			this.UnSafeItemList = new List<UUIItem>();
			bool flag = false;
			TArray<UUIItem> attachUIChildren = this.RootItem.GetAttachUIChildren();
			int i = 0;
			int num = attachUIChildren.Num();
			while (i < num)
			{
				UUIItem uuiitem = attachUIChildren.Get(i);
				if (flag)
				{
					goto IL_61;
				}
				AActor owner = uuiitem.GetOwner();
				if (!(((owner != null) ? owner.GetComponentByClass(UUISafeZone.StaticClass()) : null) is UUIItem))
				{
					goto IL_61;
				}
				flag = true;
				IL_6E:
				i++;
				continue;
				IL_61:
				this.UnSafeItemList.Add(uuiitem);
				goto IL_6E;
			}
			if (!flag)
			{
				this.UnSafeItemList.Clear();
				this.UnSafeItemList.Add(this.RootItem);
			}
		}

		// Token: 0x060313CD RID: 201677 RVA: 0x00C42A72 File Offset: 0x00C40C72
		public void SetUiComponentsTweenData(UUIViewTweenParams tweenParams)
		{
			if (tweenParams == null)
			{
				return;
			}
			this.UiComponentsTweenData = new UiComponentsTweenData(tweenParams.GetTweenAlpha(), tweenParams.GetTweenSize(), tweenParams.GetTweenTime());
		}

		// Token: 0x060313CE RID: 201678 RVA: 0x00C42A95 File Offset: 0x00C40C95
		public void PlayStartTween()
		{
			this.CollectUnSafeItem();
			this.PlayViewTween(false);
		}

		// Token: 0x060313CF RID: 201679 RVA: 0x00C42AA4 File Offset: 0x00C40CA4
		public void PlayCloseTween()
		{
			this.PlayViewTween(true);
		}

		// Token: 0x060313D0 RID: 201680 RVA: 0x00C42AAD File Offset: 0x00C40CAD
		public void Destroy()
		{
			this.UiComponentsTweenData = null;
			this.RootItem = null;
			this.UnSafeItemList = null;
		}

		// Token: 0x0401C53B RID: 116027
		private UiComponentsTweenData UiComponentsTweenData;

		// Token: 0x0401C53C RID: 116028
		private UUIItem RootItem;

		// Token: 0x0401C53D RID: 116029
		private List<UUIItem> UnSafeItemList;
	}
}
