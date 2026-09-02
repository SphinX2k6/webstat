using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x02002AE5 RID: 10981
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsRogueCommandBaseObtain : SurvivorsRogueCommandBase
{
	// Token: 0x17001C7F RID: 7295
	// (get) Token: 0x06015F5F RID: 89951 RVA: 0x00619061 File Offset: 0x00617261
	protected SurvivorsRogueGeneralObtainView ObtainViewProxy
	{
		get
		{
			return this.ViewProxy as SurvivorsRogueGeneralObtainView;
		}
	}

	// Token: 0x06015F60 RID: 89952 RVA: 0x0061906E File Offset: 0x0061726E
	public SurvivorsRogueCommandBaseObtain(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015F61 RID: 89953 RVA: 0x00619082 File Offset: 0x00617282
	protected override void OnStartExecute()
	{
		this.TryOpenViewOrRefresh();
	}

	// Token: 0x06015F62 RID: 89954 RVA: 0x0061908A File Offset: 0x0061728A
	protected override void Back2Fore()
	{
		if (this.ObtainViewProxy == null)
		{
			this.TryOpenViewOrRefresh();
		}
	}

	// Token: 0x06015F63 RID: 89955 RVA: 0x0061909A File Offset: 0x0061729A
	private void TryOpenViewOrRefresh()
	{
		if (!Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.SurvivorsRogueGeneralObtainView))
		{
			base.OpenView(EUiViewName.SurvivorsRogueGeneralObtainView, false);
			return;
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.SurvivorsRebindCommandView, this.IncId);
	}

	// Token: 0x06015F64 RID: 89956 RVA: 0x006190D0 File Offset: 0x006172D0
	protected override void OnFinish()
	{
		base.RequestCommand(this.SelectIds.ToArray(), null);
	}

	// Token: 0x06015F65 RID: 89957 RVA: 0x006190E4 File Offset: 0x006172E4
	[NullableContext(1)]
	protected ISurvivorsChooseData GetChooseData(SurvivorsOption info, ESurvivorsObtainMode? forceMode = null)
	{
		return new SurvivorsChooseData(forceMode ?? ((info.MaxSelectCount >= info.GoodsDetails.Count) ? ESurvivorsObtainMode.All : ESurvivorsObtainMode.SingleSelect));
	}

	// Token: 0x06015F66 RID: 89958 RVA: 0x00619121 File Offset: 0x00617321
	public virtual ISurvivorsObtainViewInfo GetViewInfo()
	{
		return null;
	}

	// Token: 0x0400A8BF RID: 43199
	[Nullable(1)]
	public List<int> SelectIds = new List<int>();
}
