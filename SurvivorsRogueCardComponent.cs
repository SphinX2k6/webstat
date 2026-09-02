using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Ui;

// Token: 0x02002ACD RID: 10957
public class SurvivorsRogueCardComponent : UiPanelBase
{
	// Token: 0x06015EA4 RID: 89764 RVA: 0x006168F6 File Offset: 0x00614AF6
	public void Refresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		this.OnRefresh(params_);
	}

	// Token: 0x06015EA5 RID: 89765 RVA: 0x006168FF File Offset: 0x00614AFF
	[NullableContext(1)]
	public string GetResourceId()
	{
		return this.OnGetResourceId() ?? "";
	}

	// Token: 0x06015EA6 RID: 89766 RVA: 0x00616910 File Offset: 0x00614B10
	public virtual ECardMountPos GetLayoutLevel()
	{
		return ECardMountPos.Center;
	}

	// Token: 0x06015EA7 RID: 89767 RVA: 0x00616914 File Offset: 0x00614B14
	protected virtual void OnRefresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "没有实现 OnRefresh";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentName", base.GetType().Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06015EA8 RID: 89768 RVA: 0x00616958 File Offset: 0x00614B58
	[NullableContext(2)]
	protected virtual string OnGetResourceId()
	{
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.SurvivorsRogue;
		ELogAuthor author = ELogAuthor.YYZ;
		string message = "没有实现 GetResourceId";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ComponentName", base.GetType().Name);
		instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		return null;
	}

	// Token: 0x06015EA9 RID: 89769 RVA: 0x0061699A File Offset: 0x00614B9A
	public override void SetActive(bool visibility)
	{
		base.SetActive(visibility);
		Action<SurvivorsRogueCardComponent, bool> onComponentVisibleChanged = this.OnComponentVisibleChanged;
		if (onComponentVisibleChanged == null)
		{
			return;
		}
		onComponentVisibleChanged(this, visibility);
	}

	// Token: 0x0400A864 RID: 43108
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public Action<SurvivorsRogueCardComponent, bool> OnComponentVisibleChanged;
}
