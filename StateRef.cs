using System;
using System.Runtime.CompilerServices;

// Token: 0x02000BEF RID: 3055
[NullableContext(1)]
[Nullable(0)]
public class StateRef : IClear
{
	// Token: 0x0600328D RID: 12941 RVA: 0x0002360B File Offset: 0x0002180B
	public StateRef(string group, string initState)
	{
		this.Group = group;
		this._State = initState;
	}

	// Token: 0x170000CC RID: 204
	// (get) Token: 0x0600328E RID: 12942 RVA: 0x00023621 File Offset: 0x00021821
	// (set) Token: 0x0600328F RID: 12943 RVA: 0x00023629 File Offset: 0x00021829
	public string State
	{
		get
		{
			return this._State;
		}
		set
		{
			if (this._State != value)
			{
				this._State = value;
				Singleton<AudioSystem>.Instance.SetState(this.Group, this._State, true);
			}
		}
	}

	// Token: 0x06003290 RID: 12944 RVA: 0x00023657 File Offset: 0x00021857
	public bool ClearObject()
	{
		return true;
	}

	// Token: 0x04000555 RID: 1365
	private string Group;

	// Token: 0x04000556 RID: 1366
	private string _State;
}
