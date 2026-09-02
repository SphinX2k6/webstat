using System;
using System.Runtime.CompilerServices;

// Token: 0x020027DB RID: 10203
[NullableContext(1)]
[Nullable(0)]
public abstract class RoleDisplayModelBase
{
	// Token: 0x1700199B RID: 6555
	// (get) Token: 0x0601428F RID: 82575 RVA: 0x005A06DD File Offset: 0x0059E8DD
	public int Id
	{
		get
		{
			return this.IdInternal;
		}
	}

	// Token: 0x1700199C RID: 6556
	// (get) Token: 0x06014290 RID: 82576 RVA: 0x005A06E5 File Offset: 0x0059E8E5
	public string Name
	{
		get
		{
			return this.NameInternal;
		}
	}

	// Token: 0x1700199D RID: 6557
	// (get) Token: 0x06014291 RID: 82577 RVA: 0x005A06ED File Offset: 0x0059E8ED
	public int SkinId
	{
		get
		{
			return this.SkinIdInternal;
		}
	}

	// Token: 0x1700199E RID: 6558
	// (get) Token: 0x06014292 RID: 82578 RVA: 0x005A06F5 File Offset: 0x0059E8F5
	public int ElementId
	{
		get
		{
			return this.ElementIdInternal;
		}
	}

	// Token: 0x1700199F RID: 6559
	// (get) Token: 0x06014293 RID: 82579 RVA: 0x005A06FD File Offset: 0x0059E8FD
	public int Level
	{
		get
		{
			return this.LevelInternal;
		}
	}

	// Token: 0x170019A0 RID: 6560
	// (get) Token: 0x06014294 RID: 82580 RVA: 0x005A0705 File Offset: 0x0059E905
	public bool IsInTeam
	{
		get
		{
			return this.IsInTeamInternal;
		}
	}

	// Token: 0x170019A1 RID: 6561
	// (get) Token: 0x06014295 RID: 82581 RVA: 0x005A070D File Offset: 0x0059E90D
	public bool IsTrial
	{
		get
		{
			return this.IsTrialInternal;
		}
	}

	// Token: 0x170019A2 RID: 6562
	// (get) Token: 0x06014296 RID: 82582 RVA: 0x005A0715 File Offset: 0x0059E915
	public bool IsNew
	{
		get
		{
			return this.IsNewInternal;
		}
	}

	// Token: 0x170019A3 RID: 6563
	// (get) Token: 0x06014297 RID: 82583 RVA: 0x005A071D File Offset: 0x0059E91D
	public ERoleTypeTag TypeTag
	{
		get
		{
			return this.TypeTagInternal;
		}
	}

	// Token: 0x170019A4 RID: 6564
	// (get) Token: 0x06014298 RID: 82584
	public abstract ERoleDisplaySourceType SourceType { get; }

	// Token: 0x170019A5 RID: 6565
	// (get) Token: 0x06014299 RID: 82585
	[Nullable(2)]
	public abstract RoleDataBase OriginRoleData { [NullableContext(2)] get; }

	// Token: 0x0601429A RID: 82586 RVA: 0x005A0728 File Offset: 0x0059E928
	protected void InitBase(RoleDisplayModelBaseInitParams param)
	{
		this.IdInternal = param.Id;
		this.NameInternal = param.Name;
		this.SkinIdInternal = param.SkinId;
		this.ElementIdInternal = param.ElementId;
		this.LevelInternal = param.Level;
		this.IsInTeamInternal = param.IsInTeam;
		this.IsTrialInternal = param.IsTrial;
		this.IsNewInternal = param.IsNew;
		this.TypeTagInternal = param.TypeTag;
	}

	// Token: 0x04009CF7 RID: 40183
	private int IdInternal;

	// Token: 0x04009CF8 RID: 40184
	private string NameInternal;

	// Token: 0x04009CF9 RID: 40185
	private int SkinIdInternal;

	// Token: 0x04009CFA RID: 40186
	private int ElementIdInternal;

	// Token: 0x04009CFB RID: 40187
	private int LevelInternal;

	// Token: 0x04009CFC RID: 40188
	private bool IsInTeamInternal;

	// Token: 0x04009CFD RID: 40189
	private bool IsTrialInternal;

	// Token: 0x04009CFE RID: 40190
	private bool IsNewInternal;

	// Token: 0x04009CFF RID: 40191
	private ERoleTypeTag TypeTagInternal;
}
