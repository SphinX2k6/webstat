using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Ui
{
	// Token: 0x02004A5C RID: 19036
	[NullableContext(1)]
	[Nullable(0)]
	public class UiTextAdapterProxy
	{
		// Token: 0x1700848B RID: 33931
		// (get) Token: 0x06031B86 RID: 203654 RVA: 0x00C64045 File Offset: 0x00C62245
		// (set) Token: 0x06031B87 RID: 203655 RVA: 0x00C6404D File Offset: 0x00C6224D
		public UUIText BindText { get; private set; }

		// Token: 0x06031B88 RID: 203656 RVA: 0x00C64056 File Offset: 0x00C62256
		public UiTextAdapterProxy(UUIText bindText)
		{
			this.BindText = bindText;
		}

		// Token: 0x06031B89 RID: 203657 RVA: 0x00C6406C File Offset: 0x00C6226C
		public void Init()
		{
			this.TextItem = (this.BindText.GetOwner() as AUIBaseActor).GetUIItem().GetParentAsUIItem();
			this.TextSizeControlByOther = (this.TextItem.GetOwner().GetComponentByClass(UUISizeControlByOther.StaticClass()) as UUISizeControlByOther);
			this.DefaultFontSize = this.BindText.GetSize();
			this.DefaultToggleItemHeight = (int)this.TextItem.GetHeight();
			this.CurrentViewportSize = this.GetViewportSize();
			this.StartTick();
		}

		// Token: 0x06031B8A RID: 203658 RVA: 0x00C640F4 File Offset: 0x00C622F4
		private FIntPoint GetViewportSize()
		{
			APlayerController playerController = Global.PlayerController;
			int x = 0;
			int y = 0;
			if (playerController != null)
			{
				playerController.GetViewportSize(ref x, ref y);
			}
			return new FIntPoint
			{
				X = x,
				Y = y
			};
		}

		// Token: 0x06031B8B RID: 203659 RVA: 0x00C64131 File Offset: 0x00C62331
		public void SetLocalText(string textStringId, params object[] args)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(this.BindText, textStringId, args);
			this.CheckAndRefresh();
		}

		// Token: 0x06031B8C RID: 203660 RVA: 0x00C6414B File Offset: 0x00C6234B
		public void SetText(string inText)
		{
			this.BindText.SetText(inText, true);
			this.CheckAndRefresh();
		}

		// Token: 0x06031B8D RID: 203661 RVA: 0x00C64160 File Offset: 0x00C62360
		private void CheckAndRefresh()
		{
			if (this.DelayRefreshTextHeightTimer == null)
			{
				this.DelayRefreshTextHeightTimer = TimerSystem.Instance.Delay(delegate(float _)
				{
					this.RefreshTextHeight();
					this.DelayRefreshTextHeightTimer = null;
				}, 100f, null, null, true, 1f);
			}
		}

		// Token: 0x06031B8E RID: 203662 RVA: 0x00C64193 File Offset: 0x00C62393
		public void StartTick()
		{
			this.StopTick();
			this.Ticker = Singleton<TickSystem>.Instance.Add(new Action<float>(this.OnTick), "UiTextSizeFitter." + this.BindText.GetName(), ETickingGroup.TG_PrePhysics, false, 0, false);
		}

		// Token: 0x06031B8F RID: 203663 RVA: 0x00C641D0 File Offset: 0x00C623D0
		public void StopTick()
		{
			if (this.Ticker != null)
			{
				Singleton<TickSystem>.Instance.Remove(this.Ticker.Id);
				this.Ticker = null;
			}
		}

		// Token: 0x06031B90 RID: 203664 RVA: 0x00C641F7 File Offset: 0x00C623F7
		public void Clear()
		{
			this.StopTick();
			if (this.DelayRefreshTextHeightTimer != null && TimerSystem.Instance.Has(this.DelayRefreshTextHeightTimer))
			{
				TimerSystem.Instance.Remove(this.DelayRefreshTextHeightTimer);
				this.DelayRefreshTextHeightTimer = null;
			}
		}

		// Token: 0x06031B91 RID: 203665 RVA: 0x00C64234 File Offset: 0x00C62434
		private void OnTick(float delta)
		{
			FIntPoint viewportSize = this.GetViewportSize();
			if (this.CurrentViewportSize.X != viewportSize.X || this.CurrentViewportSize.Y != viewportSize.Y)
			{
				this.CurrentViewportSize = viewportSize;
				this.RefreshTextHeight();
			}
		}

		// Token: 0x06031B92 RID: 203666 RVA: 0x00C6427C File Offset: 0x00C6247C
		private void RefreshTextHeight()
		{
			if (this.BindText == null || this.TextItem == null)
			{
				return;
			}
			this.BindText.GetRealSize();
			bool flag = this.BindText.GetRenderLineNum() < 2;
			if (this.IsSingleRow == flag)
			{
				return;
			}
			this.IsSingleRow = flag;
			if (this.IsSingleRow)
			{
				UUISizeControlByOther textSizeControlByOther = this.TextSizeControlByOther;
				if (textSizeControlByOther != null)
				{
					textSizeControlByOther.SetControlHeight(false);
				}
				this.BindText.SetFontSize(this.DefaultFontSize);
				this.BindText.GetRealSize();
				if (this.BindText.GetRenderLineNum() >= 2)
				{
					this.BindText.SetFontSize(38f);
				}
				UUIItem textItem = this.TextItem;
				if (textItem == null)
				{
					return;
				}
				textItem.SetHeight((float)this.DefaultToggleItemHeight);
				return;
			}
			else
			{
				this.BindText.SetFontSize(38f);
				UUISizeControlByOther textSizeControlByOther2 = this.TextSizeControlByOther;
				if (textSizeControlByOther2 != null)
				{
					textSizeControlByOther2.SetControlHeight(true);
				}
				this.BindText.SetFontSize(38f);
				this.BindText.GetRealSize();
				if (this.BindText.GetRenderLineNum() < 2)
				{
					UUISizeControlByOther textSizeControlByOther3 = this.TextSizeControlByOther;
					if (textSizeControlByOther3 != null)
					{
						textSizeControlByOther3.SetControlHeight(false);
					}
					this.IsSingleRow = true;
					return;
				}
				UUISizeControlByOther textSizeControlByOther4 = this.TextSizeControlByOther;
				if (textSizeControlByOther4 == null)
				{
					return;
				}
				textSizeControlByOther4.SetControlHeight(true);
				return;
			}
		}

		// Token: 0x0401CEB9 RID: 118457
		private const int FONT_SIZE = 38;

		// Token: 0x0401CEBA RID: 118458
		private const int DELAY_REFRESH_TIME = 100;

		// Token: 0x0401CEBB RID: 118459
		private float DefaultFontSize;

		// Token: 0x0401CEBC RID: 118460
		public int DefaultToggleItemHeight;

		// Token: 0x0401CEBD RID: 118461
		[Nullable(2)]
		private UUISizeControlByOther TextSizeControlByOther;

		// Token: 0x0401CEBE RID: 118462
		[Nullable(2)]
		private Ticker Ticker;

		// Token: 0x0401CEBF RID: 118463
		private FIntPoint CurrentViewportSize;

		// Token: 0x0401CEC0 RID: 118464
		private bool IsSingleRow = true;

		// Token: 0x0401CEC1 RID: 118465
		[Nullable(2)]
		private TimerHandle DelayRefreshTextHeightTimer;

		// Token: 0x0401CEC2 RID: 118466
		[Nullable(2)]
		private UUIItem TextItem;
	}
}
