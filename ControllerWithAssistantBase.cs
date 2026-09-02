using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001DD3 RID: 7635
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public abstract class ControllerWithAssistantBase<T> : ControllerBase<T> where T : class, new()
{
	// Token: 0x0600E205 RID: 57861 RVA: 0x003CE2A0 File Offset: 0x003CC4A0
	public override bool Init()
	{
		bool result = base.Init();
		this.OnRegisterNetEvent();
		this.OnAddEvents();
		return result;
	}

	// Token: 0x0600E206 RID: 57862 RVA: 0x003CE2B4 File Offset: 0x003CC4B4
	public override bool Clear()
	{
		this.OnUnRegisterNetEvent();
		this.OnRemoveEvents();
		return base.Clear();
	}

	// Token: 0x0600E207 RID: 57863 RVA: 0x003CE2C8 File Offset: 0x003CC4C8
	protected override bool OnInit()
	{
		this.InitAssistants();
		return true;
	}

	// Token: 0x0600E208 RID: 57864 RVA: 0x003CE2D1 File Offset: 0x003CC4D1
	protected override bool OnClear()
	{
		this.ClearAssistant();
		return base.OnClear();
	}

	// Token: 0x0600E209 RID: 57865 RVA: 0x003CE2DF File Offset: 0x003CC4DF
	protected virtual void OnRegisterNetEvent()
	{
		this.AssistantRegisterNetEvent();
	}

	// Token: 0x0600E20A RID: 57866 RVA: 0x003CE2E7 File Offset: 0x003CC4E7
	protected virtual void OnUnRegisterNetEvent()
	{
		this.AssistantUnRegisterNetEvent();
	}

	// Token: 0x0600E20B RID: 57867 RVA: 0x003CE2EF File Offset: 0x003CC4EF
	protected virtual void OnAddEvents()
	{
		this.AssistantAddEvents();
	}

	// Token: 0x0600E20C RID: 57868 RVA: 0x003CE2F7 File Offset: 0x003CC4F7
	protected virtual void OnRemoveEvents()
	{
		this.AssistantRemoveEvents();
	}

	// Token: 0x0600E20D RID: 57869 RVA: 0x003CE2FF File Offset: 0x003CC4FF
	private void InitAssistants()
	{
		this.Assistants = new Dictionary<int, ControllerAssistantBase>();
		this.RegisterAssistant();
	}

	// Token: 0x0600E20E RID: 57870 RVA: 0x003CE312 File Offset: 0x003CC512
	protected virtual void RegisterAssistant()
	{
	}

	// Token: 0x0600E20F RID: 57871 RVA: 0x003CE314 File Offset: 0x003CC514
	private void ClearAssistant()
	{
		if (this.Assistants != null)
		{
			foreach (ControllerAssistantBase controllerAssistantBase in this.Assistants.Values)
			{
				controllerAssistantBase.Destroy();
			}
			this.Assistants.Clear();
			this.Assistants = null;
		}
	}

	// Token: 0x0600E210 RID: 57872 RVA: 0x003CE384 File Offset: 0x003CC584
	private void AssistantRegisterNetEvent()
	{
		if (this.Assistants == null)
		{
			return;
		}
		foreach (ControllerAssistantBase controllerAssistantBase in this.Assistants.Values)
		{
			controllerAssistantBase.OnRegisterNetEvent();
		}
	}

	// Token: 0x0600E211 RID: 57873 RVA: 0x003CE3E4 File Offset: 0x003CC5E4
	private void AssistantUnRegisterNetEvent()
	{
		if (this.Assistants == null)
		{
			return;
		}
		foreach (ControllerAssistantBase controllerAssistantBase in this.Assistants.Values)
		{
			controllerAssistantBase.OnUnRegisterNetEvent();
		}
	}

	// Token: 0x0600E212 RID: 57874 RVA: 0x003CE444 File Offset: 0x003CC644
	private void AssistantAddEvents()
	{
		if (this.Assistants == null)
		{
			return;
		}
		foreach (ControllerAssistantBase controllerAssistantBase in this.Assistants.Values)
		{
			controllerAssistantBase.OnAddEvents();
		}
	}

	// Token: 0x0600E213 RID: 57875 RVA: 0x003CE4A4 File Offset: 0x003CC6A4
	private void AssistantRemoveEvents()
	{
		if (this.Assistants == null)
		{
			return;
		}
		foreach (ControllerAssistantBase controllerAssistantBase in this.Assistants.Values)
		{
			controllerAssistantBase.OnRemoveEvents();
		}
	}

	// Token: 0x0600E214 RID: 57876 RVA: 0x003CE504 File Offset: 0x003CC704
	[NullableContext(2)]
	public void AddAssistant(int assistantType, ControllerAssistantBase assistantObj)
	{
		if (assistantObj == null)
		{
			return;
		}
		assistantObj.Init();
		this.Assistants[assistantType] = assistantObj;
	}

	// Token: 0x04006C4D RID: 27725
	[Nullable(new byte[]
	{
		2,
		1
	})]
	protected Dictionary<int, ControllerAssistantBase> Assistants;
}
