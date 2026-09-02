using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002477 RID: 9335
[NullableContext(1)]
[Nullable(0)]
public class PhantomBattleInstance
{
	// Token: 0x06012143 RID: 74051 RVA: 0x004F7F9E File Offset: 0x004F619E
	public PhantomBattleInstance(PhantomItem data)
	{
		this.PhantomId = data.MonsterId;
		this.PhantomItem = new PhantomItem?(data);
		this.PhantomSkill = ConfigBase<PhantomBattleConfig>.Instance.GetPhantomSkillList(data.SkillId).ToList<PhantomSkill>();
	}

	// Token: 0x170016CD RID: 5837
	// (get) Token: 0x06012144 RID: 74052 RVA: 0x004F7FDB File Offset: 0x004F61DB
	// (set) Token: 0x06012145 RID: 74053 RVA: 0x004F7FE3 File Offset: 0x004F61E3
	public int PhantomId
	{
		get
		{
			return this.Id;
		}
		set
		{
			this.Id = value;
		}
	}

	// Token: 0x170016CE RID: 5838
	// (get) Token: 0x06012146 RID: 74054 RVA: 0x004F7FEC File Offset: 0x004F61EC
	// (set) Token: 0x06012147 RID: 74055 RVA: 0x004F7FF4 File Offset: 0x004F61F4
	public PhantomItem? PhantomItem
	{
		get
		{
			return this.Item;
		}
		set
		{
			this.Item = value;
		}
	}

	// Token: 0x170016CF RID: 5839
	// (get) Token: 0x06012148 RID: 74056 RVA: 0x004F7FFD File Offset: 0x004F61FD
	// (set) Token: 0x06012149 RID: 74057 RVA: 0x004F8005 File Offset: 0x004F6205
	[Nullable(2)]
	public List<PhantomSkill> PhantomSkill
	{
		[NullableContext(2)]
		get
		{
			return this.Skill;
		}
		[NullableContext(2)]
		set
		{
			this.Skill = value;
		}
	}

	// Token: 0x0601214A RID: 74058 RVA: 0x004F8010 File Offset: 0x004F6210
	public int? GetPhantomSkillId()
	{
		return new int?(this.Skill[0].Id);
	}

	// Token: 0x0601214B RID: 74059 RVA: 0x004F8038 File Offset: 0x004F6238
	public PhantomSkill? GetPhantomSkillInfoByLevel()
	{
		if (this.PhantomSkill.Count <= 0)
		{
			return null;
		}
		return new PhantomSkill?(this.PhantomSkill[0]);
	}

	// Token: 0x0601214C RID: 74060 RVA: 0x004F8070 File Offset: 0x004F6270
	public float[] GetModelZoom()
	{
		return this.PhantomItem.Value.Zoom();
	}

	// Token: 0x0601214D RID: 74061 RVA: 0x004F8094 File Offset: 0x004F6294
	public float[] GetModelLocation()
	{
		return this.PhantomItem.Value.Location();
	}

	// Token: 0x0601214E RID: 74062 RVA: 0x004F80B8 File Offset: 0x004F62B8
	public float[] GetModelRotator()
	{
		return this.PhantomItem.Value.Rotator();
	}

	// Token: 0x0601214F RID: 74063 RVA: 0x004F80DC File Offset: 0x004F62DC
	public string GetStandAnim()
	{
		return this.PhantomItem.Value.StandAnim;
	}

	// Token: 0x04008D45 RID: 36165
	private int Id;

	// Token: 0x04008D46 RID: 36166
	private PhantomItem? Item;

	// Token: 0x04008D47 RID: 36167
	[Nullable(2)]
	private List<PhantomSkill> Skill;
}
