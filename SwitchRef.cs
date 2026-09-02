using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000BF0 RID: 3056
[NullableContext(1)]
[Nullable(0)]
public class SwitchRef : IClear
{
	// Token: 0x06003291 RID: 12945 RVA: 0x0002365A File Offset: 0x0002185A
	public SwitchRef(string group, string stateInternal)
	{
		this.Group = group;
		this.StateInternal = stateInternal;
	}

	// Token: 0x170000CD RID: 205
	// (get) Token: 0x06003292 RID: 12946 RVA: 0x00023670 File Offset: 0x00021870
	// (set) Token: 0x06003293 RID: 12947 RVA: 0x00023678 File Offset: 0x00021878
	public string State
	{
		get
		{
			return this.StateInternal;
		}
		set
		{
			AActor actor = this.Actor;
			if (actor == null || !actor.IsValid())
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Audio;
				ELogAuthor author = ELogAuthor.MSY;
				string message = "[Core.SwitchRef] 绑定对象无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Group", this.Group);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return;
			}
			if (this.StateInternal != value)
			{
				this.StateInternal = value;
				Singleton<AudioSystem>.Instance.SetSwitch(this.Group, this.State, this.Actor);
			}
		}
	}

	// Token: 0x06003294 RID: 12948 RVA: 0x000236FA File Offset: 0x000218FA
	public void Bind(AActor actor)
	{
		this.Actor = actor;
		Singleton<AudioSystem>.Instance.SetSwitch(this.Group, this.State, this.Actor);
	}

	// Token: 0x06003295 RID: 12949 RVA: 0x0002371F File Offset: 0x0002191F
	public bool ClearObject()
	{
		this.Actor = null;
		return true;
	}

	// Token: 0x04000557 RID: 1367
	[Nullable(2)]
	private AActor Actor;

	// Token: 0x04000558 RID: 1368
	private readonly string Group;

	// Token: 0x04000559 RID: 1369
	private string StateInternal;
}
