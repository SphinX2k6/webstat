using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x0200001B RID: 27
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class Application : Singleton<Application>
{
	// Token: 0x06000049 RID: 73 RVA: 0x000039F0 File Offset: 0x00001BF0
	public void Initialize()
	{
		if (this.IsInit)
		{
			return;
		}
		this.IsInit = true;
		FOnApplicationLifeTime fonApplicationLifeTime = global::DelegateUtils.ToManualReleaseDelegate<FOnApplicationLifeTime>(new Action<int>(this.OnApplicationLifetimeDelegate));
		UKuroApplicationLibrary.AddApplicationLifetimeDelegate(fonApplicationLifeTime);
		FOnEditorPreEndPIE fonEditorPreEndPIE = global::DelegateUtils.ToManualReleaseDelegate<FOnEditorPreEndPIE>(new Action<bool>(this.OnEditorPreEndPIEDelegate));
		UKuroApplicationLibrary.AddEditorPreEndPIEDelegate(fonEditorPreEndPIE);
		FWindowActivation fwindowActivation = global::DelegateUtils.ToManualReleaseDelegate<FWindowActivation>(new Action<bool>(this.OnWindowActivationDelegate));
		UKuroApplicationLibrary.AddWindowActivationDelegate(fwindowActivation);
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00003A5C File Offset: 0x00001C5C
	private void OnApplicationLifetimeDelegate(int type)
	{
		if (!this.HandleMap.ContainsKey((EApplicationLifetimeDelegate)type))
		{
			return;
		}
		foreach (Action action in this.HandleMap[(EApplicationLifetimeDelegate)type])
		{
			action();
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00003AC4 File Offset: 0x00001CC4
	private void OnEditorPreEndPIEDelegate(bool bSimulateInEditor)
	{
		foreach (Action action in this.EditorHandleSet)
		{
			action();
		}
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00003B14 File Offset: 0x00001D14
	public void Destroy()
	{
		if (!this.IsInit)
		{
			return;
		}
		this.HandleMap.Clear();
		this.EditorHandleSet.Clear();
		this.WindowActivationHandleSet.Clear();
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<int>(this.OnApplicationLifetimeDelegate));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool>(this.OnEditorPreEndPIEDelegate));
		global::DelegateUtils.ReleaseManualReleaseDelegate(new Action<bool>(this.OnWindowActivationDelegate));
		UKuroApplicationLibrary.UnBind();
		this.IsInit = false;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00003B8C File Offset: 0x00001D8C
	private void OnWindowActivationDelegate(bool bIsActive)
	{
		bool? windowIsActive = this.WindowIsActive;
		if (!(bIsActive == windowIsActive.GetValueOrDefault() & windowIsActive != null))
		{
			this.WindowIsActive = new bool?(bIsActive);
			foreach (Action<bool> action in this.WindowActivationHandleSet)
			{
				action(bIsActive);
			}
		}
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00003C04 File Offset: 0x00001E04
	public void AddApplicationHandler(EApplicationLifetimeDelegate e, Action handler)
	{
		if (!this.HandleMap.ContainsKey(e))
		{
			this.HandleMap[e] = new HashSet<Action>();
		}
		this.HandleMap[e].Add(handler);
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00003C38 File Offset: 0x00001E38
	public void RemoveApplicationHandler(EApplicationLifetimeDelegate type, Action handler)
	{
		if (!this.HandleMap.ContainsKey(type))
		{
			return;
		}
		this.HandleMap[type].Remove(handler);
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00003C5C File Offset: 0x00001E5C
	public void AddEditorPreEndPIEHandler(Action handler)
	{
		this.EditorHandleSet.Add(handler);
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00003C6B File Offset: 0x00001E6B
	public void RemoveEditorPreEndPIEHandler(Action handler)
	{
		this.EditorHandleSet.Remove(handler);
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00003C7A File Offset: 0x00001E7A
	public void AddWindowActivationHandler(Action<bool> handler)
	{
		this.WindowActivationHandleSet.Add(handler);
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00003C89 File Offset: 0x00001E89
	public void RemoveWindowActivationHandler(Action<bool> handler)
	{
		this.WindowActivationHandleSet.Remove(handler);
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00003C98 File Offset: 0x00001E98
	public bool? GetWindowActivationState()
	{
		return this.WindowIsActive;
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00003CA0 File Offset: 0x00001EA0
	public bool IsPublicationApp()
	{
		return this.GmSimulatePublication || UKuroLauncherLibrary.GetAppInternalUseType() == "Publication";
	}

	// Token: 0x0400003E RID: 62
	private readonly Dictionary<EApplicationLifetimeDelegate, HashSet<Action>> HandleMap = new Dictionary<EApplicationLifetimeDelegate, HashSet<Action>>();

	// Token: 0x0400003F RID: 63
	private readonly HashSet<Action> EditorHandleSet = new HashSet<Action>();

	// Token: 0x04000040 RID: 64
	private readonly HashSet<Action<bool>> WindowActivationHandleSet = new HashSet<Action<bool>>();

	// Token: 0x04000041 RID: 65
	private bool IsInit;

	// Token: 0x04000042 RID: 66
	private bool? WindowIsActive;

	// Token: 0x04000043 RID: 67
	public bool GmSimulatePublication;
}
