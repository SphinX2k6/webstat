using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02002D6A RID: 11626
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WorldLevelModel : ModelBase<WorldLevelModel>
{
	// Token: 0x17001EF1 RID: 7921
	// (get) Token: 0x0601778E RID: 96142 RVA: 0x00681AB9 File Offset: 0x0067FCB9
	public string WorldLevelMultilingualText
	{
		get
		{
			return ConfigBase<TextConfig>.Instance.GetTextById("WorldLevel") ?? "";
		}
	}

	// Token: 0x17001EF2 RID: 7922
	// (get) Token: 0x0601778F RID: 96143 RVA: 0x00681AD3 File Offset: 0x0067FCD3
	// (set) Token: 0x06017790 RID: 96144 RVA: 0x00681ADB File Offset: 0x0067FCDB
	public int CurWorldLevel
	{
		get
		{
			return this.CurWorldLevelInner;
		}
		set
		{
			if (this.CurWorldLevelInner != value)
			{
				this.CurWorldLevelInner = value;
				Singleton<EventSystem>.Instance.Emit(EEventName.CurWorldLevelChange);
			}
		}
	}

	// Token: 0x17001EF3 RID: 7923
	// (get) Token: 0x06017791 RID: 96145 RVA: 0x00681AFD File Offset: 0x0067FCFD
	// (set) Token: 0x06017792 RID: 96146 RVA: 0x00681B05 File Offset: 0x0067FD05
	public int OriginWorldLevel
	{
		get
		{
			return this.OriginWorldLevelInner;
		}
		set
		{
			bool flag = value > this.OriginWorldLevelInner;
			this.OriginWorldLevelInner = value;
			if (flag)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OriginWorldLevelUp);
			}
		}
	}

	// Token: 0x17001EF4 RID: 7924
	// (get) Token: 0x06017793 RID: 96147 RVA: 0x00681B29 File Offset: 0x0067FD29
	// (set) Token: 0x06017794 RID: 96148 RVA: 0x00681B31 File Offset: 0x0067FD31
	public int Sex
	{
		get
		{
			return this.SexInner;
		}
		set
		{
			this.SexInner = value;
		}
	}

	// Token: 0x06017795 RID: 96149 RVA: 0x00681B3A File Offset: 0x0067FD3A
	protected override bool OnInit()
	{
		this.LastChangeWorldLevelTimeStamp = 0;
		return true;
	}

	// Token: 0x06017796 RID: 96150 RVA: 0x00681B44 File Offset: 0x0067FD44
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0400B3FA RID: 46074
	private int OriginWorldLevelInner;

	// Token: 0x0400B3FB RID: 46075
	private int CurWorldLevelInner;

	// Token: 0x0400B3FC RID: 46076
	public int LastChangeWorldLevelTimeStamp;

	// Token: 0x0400B3FD RID: 46077
	private int SexInner;

	// Token: 0x0400B3FE RID: 46078
	public int WorldLevelChangeTarget;

	// Token: 0x0400B3FF RID: 46079
	public bool TsFightState;
}
