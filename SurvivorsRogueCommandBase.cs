using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks.CompilerServices;

// Token: 0x02002AE0 RID: 10976
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandBase
{
	// Token: 0x17001C72 RID: 7282
	// (get) Token: 0x06015F38 RID: 89912 RVA: 0x00618D6C File Offset: 0x00616F6C
	public bool IsFinished
	{
		get
		{
			return this.CurrentStep >= this.StepSize;
		}
	}

	// Token: 0x17001C73 RID: 7283
	// (get) Token: 0x06015F39 RID: 89913 RVA: 0x00618D7F File Offset: 0x00616F7F
	public bool IsStarted
	{
		get
		{
			return this.CurrentStep >= 0;
		}
	}

	// Token: 0x06015F3A RID: 89914 RVA: 0x00618D8D File Offset: 0x00616F8D
	public SurvivorsRogueCommandBase(ESurvivorsRogueCommandType type)
	{
		this.Type = type;
	}

	// Token: 0x06015F3B RID: 89915 RVA: 0x00618DB4 File Offset: 0x00616FB4
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(10, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[Command] ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.IncId);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015F3C RID: 89916 RVA: 0x00618DEC File Offset: 0x00616FEC
	public void SetForegroundStatus(bool inForeground)
	{
		bool inForeground2 = this.InForeground;
		if (inForeground2 == inForeground)
		{
			return;
		}
		this.InForeground = inForeground;
		if (!this.IsStarted || this.IsFinished)
		{
			return;
		}
		bool inForeground3 = this.InForeground;
		if (inForeground2 != inForeground3)
		{
			if (inForeground3)
			{
				this.Back2Fore();
				return;
			}
			this.Fore2Back();
		}
	}

	// Token: 0x06015F3D RID: 89917 RVA: 0x00618E38 File Offset: 0x00617038
	public void Update(SurvivorsOpData data)
	{
		this.Data = data;
		this.IncId = this.Data.IncId;
		this.OnUpdate();
		ISurvivorsRogueCommandView viewProxy = this.ViewProxy;
		if (viewProxy == null)
		{
			return;
		}
		viewProxy.Refresh();
	}

	// Token: 0x06015F3E RID: 89918 RVA: 0x00618E68 File Offset: 0x00617068
	public void TryStartExecute()
	{
		if (this.IsStarted)
		{
			return;
		}
		if (!this.InForeground)
		{
			return;
		}
		this.CurrentStep = 0;
		this.OnStartExecute();
	}

	// Token: 0x06015F3F RID: 89919 RVA: 0x00618E89 File Offset: 0x00617089
	public void Execute()
	{
		if (this.IsFinished)
		{
			return;
		}
		if (!this.InForeground)
		{
			return;
		}
		this.CurrentStep++;
		if (this.IsFinished)
		{
			this.Finish();
			return;
		}
		this.OnExecute();
	}

	// Token: 0x06015F40 RID: 89920 RVA: 0x00618EC0 File Offset: 0x006170C0
	[NullableContext(2)]
	public void BindView(ISurvivorsRogueCommandView viewProxy)
	{
		this.ViewProxy = viewProxy;
		this.OnBindView();
	}

	// Token: 0x06015F41 RID: 89921 RVA: 0x00618ECF File Offset: 0x006170CF
	private void Finish()
	{
		this.OnFinish();
	}

	// Token: 0x06015F42 RID: 89922 RVA: 0x00618ED7 File Offset: 0x006170D7
	public void Delete()
	{
		this.OnDelete();
		if (this.CanCloseViewOnDelete())
		{
			ISurvivorsRogueCommandView viewProxy = this.ViewProxy;
			if (viewProxy != null)
			{
				viewProxy.CloseView();
			}
		}
		this.ViewProxy = null;
		this.AfterDelete = true;
	}

	// Token: 0x06015F43 RID: 89923 RVA: 0x00618F06 File Offset: 0x00617106
	public void RequestCommand(int[] executeIds, [Nullable(2)] Action<bool> callback = null)
	{
		if (!this.InForeground)
		{
			if (callback != null)
			{
				callback(false);
			}
			return;
		}
		ControllerBase<SurvivorsRogueController>.Instance.RequestCommandOperation(this.IncId, executeIds.ToList<int>(), callback);
	}

	// Token: 0x06015F44 RID: 89924 RVA: 0x00618F34 File Offset: 0x00617134
	protected void OpenView(EUiViewName viewName, bool isMultipleView)
	{
		SurvivorsRogueCommandBase.<>c__DisplayClass22_0 CS$<>8__locals1 = new SurvivorsRogueCommandBase.<>c__DisplayClass22_0();
		CS$<>8__locals1.viewName = viewName;
		CS$<>8__locals1.viewData = new SurvivorsRogueCommandViewData(this.IncId, isMultipleView);
		if (isMultipleView)
		{
			Singleton<UiManager>.Instance.OpenView(CS$<>8__locals1.viewName, CS$<>8__locals1.viewData, null);
			return;
		}
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(30, 1);
		defaultInterpolatedStringHandler.AppendLiteral("SurvivorsRogueCommandBase.Open");
		defaultInterpolatedStringHandler.AppendFormatted<EUiViewName>(CS$<>8__locals1.viewName);
		AsyncTask task = new AsyncTask(defaultInterpolatedStringHandler.ToStringAndClear(), delegate()
		{
			SurvivorsRogueCommandBase.<>c__DisplayClass22_0.<<OpenView>b__0>d <<OpenView>b__0>d;
			<<OpenView>b__0>d.<>t__builder = AsyncUniTaskMethodBuilder<bool>.Create();
			<<OpenView>b__0>d.<>4__this = CS$<>8__locals1;
			<<OpenView>b__0>d.<>1__state = -1;
			<<OpenView>b__0>d.<>t__builder.Start<SurvivorsRogueCommandBase.<>c__DisplayClass22_0.<<OpenView>b__0>d>(ref <<OpenView>b__0>d);
			return <<OpenView>b__0>d.<>t__builder.Task;
		}, null, null, null);
		Singleton<TaskSystem>.Instance.AddTask(task);
		Singleton<TaskSystem>.Instance.Run();
	}

	// Token: 0x06015F45 RID: 89925 RVA: 0x00618FD0 File Offset: 0x006171D0
	protected virtual void OnUpdate()
	{
	}

	// Token: 0x06015F46 RID: 89926 RVA: 0x00618FD2 File Offset: 0x006171D2
	protected virtual void Back2Fore()
	{
	}

	// Token: 0x06015F47 RID: 89927 RVA: 0x00618FD4 File Offset: 0x006171D4
	protected virtual void Fore2Back()
	{
	}

	// Token: 0x06015F48 RID: 89928 RVA: 0x00618FD6 File Offset: 0x006171D6
	protected virtual void OnStartExecute()
	{
	}

	// Token: 0x06015F49 RID: 89929 RVA: 0x00618FD8 File Offset: 0x006171D8
	protected virtual void OnExecute()
	{
	}

	// Token: 0x06015F4A RID: 89930 RVA: 0x00618FDA File Offset: 0x006171DA
	protected virtual void OnFinish()
	{
	}

	// Token: 0x06015F4B RID: 89931 RVA: 0x00618FDC File Offset: 0x006171DC
	protected virtual void OnDelete()
	{
	}

	// Token: 0x06015F4C RID: 89932 RVA: 0x00618FDE File Offset: 0x006171DE
	protected virtual void OnBindView()
	{
	}

	// Token: 0x06015F4D RID: 89933 RVA: 0x00618FE0 File Offset: 0x006171E0
	protected virtual bool CanCloseViewOnDelete()
	{
		return true;
	}

	// Token: 0x0400A8AF RID: 43183
	public int IncId = -1;

	// Token: 0x0400A8B0 RID: 43184
	protected int StepSize = 1;

	// Token: 0x0400A8B1 RID: 43185
	protected int CurrentStep = -1;

	// Token: 0x0400A8B2 RID: 43186
	[Nullable(2)]
	protected ISurvivorsRogueCommandView ViewProxy;

	// Token: 0x0400A8B3 RID: 43187
	public bool InForeground;

	// Token: 0x0400A8B4 RID: 43188
	public SurvivorsOpData Data;

	// Token: 0x0400A8B5 RID: 43189
	public bool AfterDelete;

	// Token: 0x0400A8B6 RID: 43190
	public readonly ESurvivorsRogueCommandType Type;
}
