using System;
using System.Collections.Generic;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x02005965 RID: 22885
	public class PanelBar : UiPanelBase
	{
		// Token: 0x17009467 RID: 37991
		// (get) Token: 0x06039FED RID: 237549 RVA: 0x00EAD34D File Offset: 0x00EAB54D
		protected bool IsActive
		{
			get
			{
				return (this.Direction > 0 && this.Current > 0) || (this.Direction < 0 && this.Current < 0);
			}
		}

		// Token: 0x06039FEE RID: 237550 RVA: 0x00EAD378 File Offset: 0x00EAB578
		protected override void OnRegisterComponent()
		{
			this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
			{
				new ValueTuple<int, Type>(0, typeof(UUIText)),
				new ValueTuple<int, Type>(1, typeof(UUISprite)),
				new ValueTuple<int, Type>(2, typeof(UUISprite)),
				new ValueTuple<int, Type>(3, typeof(UUIItem))
			};
		}

		// Token: 0x06039FEF RID: 237551 RVA: 0x00EAD3E8 File Offset: 0x00EAB5E8
		protected override void OnStart()
		{
			base.GetSprite(1).SetUIActive(false);
		}

		// Token: 0x06039FF0 RID: 237552 RVA: 0x00EAD3F7 File Offset: 0x00EAB5F7
		public void SetDirection(int direction)
		{
			this.Direction = direction;
		}

		// Token: 0x06039FF1 RID: 237553 RVA: 0x00EAD400 File Offset: 0x00EAB600
		public void SetLimit(int limit)
		{
			this.Limit = limit;
			base.GetText(0).SetText(limit.ToString(), true);
		}

		// Token: 0x06039FF2 RID: 237554 RVA: 0x00EAD420 File Offset: 0x00EAB620
		public void SetCurrentValue(int current)
		{
			UUISprite sprite = base.GetSprite(2);
			UUIItem item = base.GetItem(3);
			this.Current = current;
			bool isActive = this.IsActive;
			item.SetUIActive(isActive);
			sprite.SetUIActive(isActive);
			if (!isActive)
			{
				return;
			}
			float num = Singleton<MathUtils>.Instance.Clamp((float)current / (float)this.Limit, 0f, 1f);
			sprite.SetFillAmount(num);
			float anchorOffsetX = sprite.GetWidth() * num * (float)this.Direction;
			item.SetAnchorOffsetX(anchorOffsetX);
		}

		// Token: 0x06039FF3 RID: 237555 RVA: 0x00EAD4A0 File Offset: 0x00EAB6A0
		public void SetPreviewValue(int changeValue)
		{
			if (changeValue > 0)
			{
				return;
			}
			float num = this.IsActive ? ((float)this.Current / (float)this.Limit) : 0f;
			UUISprite sprite = base.GetSprite(2);
			UUISprite sprite2 = base.GetSprite(1);
			if (this.Direction > 0)
			{
				float num2 = (float)Singleton<MathUtils>.Instance.Clamp(this.Current + changeValue, 0, this.Limit) / (float)this.Limit;
				sprite.SetFillAmount(num2);
				sprite.SetUIActive(num2 > 0f);
				sprite2.SetFillAmount(num);
				sprite2.SetUIActive(num > 0f);
				return;
			}
			float num3 = (float)Singleton<MathUtils>.Instance.Clamp(this.Current + changeValue, this.Limit, 0) / (float)this.Limit;
			sprite.SetFillAmount(num);
			sprite.SetUIActive(num > 0f);
			sprite2.SetFillAmount(num3);
			sprite2.SetUIActive(num3 > 0f);
		}

		// Token: 0x06039FF4 RID: 237556 RVA: 0x00EAD588 File Offset: 0x00EAB788
		public void ClosePreviewValue()
		{
			base.GetSprite(1).SetUIActive(false);
			this.SetCurrentValue(this.Current);
		}

		// Token: 0x04020DFD RID: 134653
		protected int Direction = 1;

		// Token: 0x04020DFE RID: 134654
		protected int Limit;

		// Token: 0x04020DFF RID: 134655
		protected int Current;
	}
}
