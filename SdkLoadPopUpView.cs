using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002975 RID: 10613
[NullableContext(2)]
[Nullable(0)]
public class SdkLoadPopUpView : UiViewBase
{
	// Token: 0x0601516D RID: 86381 RVA: 0x005D5A7D File Offset: 0x005D3C7D
	[NullableContext(1)]
	public SdkLoadPopUpView(UiViewInfo viewInfo) : base(viewInfo)
	{
	}

	// Token: 0x0601516E RID: 86382 RVA: 0x005D5A86 File Offset: 0x005D3C86
	protected override void OnStart()
	{
		if (this.OpenParam != null)
		{
			this.Data = (this.OpenParam as SdkLoadPopUpViewData);
		}
		this.CheckCountDown();
	}

	// Token: 0x0601516F RID: 86383 RVA: 0x005D5AA7 File Offset: 0x005D3CA7
	private void CancelTimer()
	{
		if (this.TimerHandle != null)
		{
			TimerSystem.GameplayTimeInstance.Remove(this.TimerHandle);
			this.TimerHandle = null;
		}
	}

	// Token: 0x06015170 RID: 86384 RVA: 0x005D5ACC File Offset: 0x005D3CCC
	private void CheckCountDown()
	{
		SdkLoadPopUpViewData data = this.Data;
		int? num = (data != null) ? new int?(data.ForceCloseTime) : null;
		if (num != null)
		{
			int? num2 = num;
			int num3 = 0;
			if (num2.GetValueOrDefault() > num3 & num2 != null)
			{
				this.CurrentLeftTime = num.Value;
				this.CancelTimer();
				this.TimerHandle = TimerSystem.GameplayTimeInstance.Forever(delegate(float _)
				{
					this.CurrentLeftTime--;
					if (this.CurrentLeftTime < 0)
					{
						base.CloseMe(null);
						Log instance = Singleton<Log>.Instance;
						ELogModule module = ELogModule.KuroSdk;
						ELogAuthor author = ELogAuthor.YZY;
						string message = "SDK:读取中弹窗触发自动关闭";
						ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("reason", this.Data.OpenReason);
						instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
					}
				}, 1000f, 1f, null, null, true);
			}
		}
	}

	// Token: 0x06015171 RID: 86385 RVA: 0x005D5B56 File Offset: 0x005D3D56
	protected override void OnBeforeShow()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer("SdkLoading", true);
	}

	// Token: 0x06015172 RID: 86386 RVA: 0x005D5B68 File Offset: 0x005D3D68
	protected override void OnBeforeHide()
	{
		Singleton<UiLayer>.Instance.SetShowMaskLayer("SdkLoading", false);
		this.CancelTimer();
	}

	// Token: 0x0400A26E RID: 41582
	private const int TIMERGAP = 1000;

	// Token: 0x0400A26F RID: 41583
	private SdkLoadPopUpViewData Data;

	// Token: 0x0400A270 RID: 41584
	private TimerHandle TimerHandle;

	// Token: 0x0400A271 RID: 41585
	private int CurrentLeftTime;
}
