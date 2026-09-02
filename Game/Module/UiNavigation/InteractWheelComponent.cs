using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.UiNavigation
{
	// Token: 0x02004D13 RID: 19731
	public class InteractWheelComponent : HotKeyComponent
	{
		// Token: 0x06033497 RID: 210071 RVA: 0x00CD6363 File Offset: 0x00CD4563
		public InteractWheelComponent(int hotKeyMapIndex) : base(hotKeyMapIndex)
		{
		}

		// Token: 0x06033498 RID: 210072 RVA: 0x00CD636C File Offset: 0x00CD456C
		[NullableContext(1)]
		protected override void OnInputAxis(string axisName, float value)
		{
			float num = -value;
			if (this.ZoomValue * num < 0f)
			{
				this.ZoomValue = 0f;
			}
			this.ZoomValue += num;
			float num2 = (float)((num > 0f) ? 1 : -1) * (float)Math.Floor((double)Math.Abs(this.ZoomValue / 1f));
			this.ZoomValue -= 1f * num2;
			bool flag = value != 0f;
			if (this.IsPress == flag)
			{
				return;
			}
			this.IsPress = flag;
			if (value > 0f)
			{
				ControllerBase<UiNavigationNewController>.Instance.FindTarget(ELGUINavigationDirection.Prev);
				return;
			}
			if (value < 0f)
			{
				ControllerBase<UiNavigationNewController>.Instance.FindTarget(ELGUINavigationDirection.Next);
			}
		}

		// Token: 0x06033499 RID: 210073 RVA: 0x00CD6423 File Offset: 0x00CD4623
		protected override void OnRefreshMode()
		{
			this.CurComponent.SetNeedRefreshKeyName(false);
			base.OnRefreshMode();
		}

		// Token: 0x0603349A RID: 210074 RVA: 0x00CD6438 File Offset: 0x00CD4638
		public bool UpdateIndex(int totalNum)
		{
			int indexInternal = this.IndexInternal;
			this.UpdateIndexInternal(totalNum);
			return this.IndexInternal != indexInternal;
		}

		// Token: 0x0603349B RID: 210075 RVA: 0x00CD6460 File Offset: 0x00CD4660
		private void UpdateIndexInternal(int totalNum)
		{
			if (totalNum != 0)
			{
				this.TotalNumInternal = totalNum;
			}
			if (this.TotalNumInternal == 0)
			{
				return;
			}
			if (this.IndexInternal < 0 || this.IndexInternal >= this.TotalNumInternal)
			{
				if (!this.AllowLoop)
				{
					this.IndexInternal = Math.Max(0, Math.Min(this.IndexInternal, this.TotalNumInternal - 1));
					return;
				}
				this.IndexInternal %= this.TotalNumInternal;
				if (this.IndexInternal < 0)
				{
					this.IndexInternal = this.TotalNumInternal + this.IndexInternal;
				}
			}
		}

		// Token: 0x0401DC47 RID: 121927
		private const int ZOOM_THRESHOLD = 1;

		// Token: 0x0401DC48 RID: 121928
		private int TotalNumInternal;

		// Token: 0x0401DC49 RID: 121929
		private int IndexInternal;

		// Token: 0x0401DC4A RID: 121930
		private float ZoomValue;

		// Token: 0x0401DC4B RID: 121931
		protected new bool IsPress;

		// Token: 0x0401DC4C RID: 121932
		private readonly bool AllowLoop;
	}
}
