using System;
using Aki.Config;

// Token: 0x02003065 RID: 12389
public class CharacterShield
{
	// Token: 0x0601975B RID: 104283 RVA: 0x0075C348 File Offset: 0x0075A548
	public CharacterShield(int id, int templateId, float value)
	{
		this.Id = id;
		this.TemplateId = templateId;
		this.Value = value;
		this.HandleId = id;
		Shield? config = ConfigShieldById.GetConfig(templateId, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Battle;
			ELogAuthor author = ELogAuthor.ZFJ;
			string message = "护盾添加失败，护盾Id不存在";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", templateId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return;
		}
		this.Priority = config.Value.Priority;
		this.ShieldValue = value;
	}

	// Token: 0x0400C9BA RID: 51642
	public readonly int Priority;

	// Token: 0x0400C9BB RID: 51643
	public float ShieldValue;

	// Token: 0x0400C9BC RID: 51644
	public int HandleId;

	// Token: 0x0400C9BD RID: 51645
	public readonly int Id;

	// Token: 0x0400C9BE RID: 51646
	public readonly int TemplateId;

	// Token: 0x0400C9BF RID: 51647
	public readonly float Value;
}
