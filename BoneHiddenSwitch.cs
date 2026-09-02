using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using UnrealEngine;

// Token: 0x02002FFB RID: 12283
[NullableContext(1)]
[Nullable(0)]
public class BoneHiddenSwitch : IDynamicConditionSwitch
{
	// Token: 0x06019080 RID: 102528 RVA: 0x0071AB64 File Offset: 0x00718D64
	public void Init(CharacterActorComponent actor, EntityAudioConfig config)
	{
		if (config.BoneHiddenSwitchLength != 4)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Audio;
			ELogAuthor author = ELogAuthor.LJM;
			string message = "[BoneHiddenSwitch] BoneHiddenSwitch配置无效";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ConfigId:", config.Id);
			instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		this.BoneName = config.BoneHiddenSwitch(0);
		this.SwitchGroup = config.BoneHiddenSwitch(1);
		this.HiddenSwitch = config.BoneHiddenSwitch(2);
		this.VisibleSwitch = config.BoneHiddenSwitch(3);
		this.LastHidden = actor.Actor.Mesh.IsBoneHiddenByName(FNameUtil.GetDynamicFName(this.BoneName) ?? FName.NAME_None);
		this.SetSwitch(this.LastHidden, actor);
	}

	// Token: 0x06019081 RID: 102529 RVA: 0x0071AC28 File Offset: 0x00718E28
	public void Do(CharacterActorComponent actor)
	{
		bool flag = actor.Actor.Mesh.IsBoneHiddenByName(FNameUtil.GetDynamicFName(this.BoneName) ?? FName.NAME_None);
		bool flag2 = flag != this.LastHidden;
		this.LastHidden = flag;
		if (flag2)
		{
			this.SetSwitch(this.LastHidden, actor);
		}
	}

	// Token: 0x06019082 RID: 102530 RVA: 0x0071AC8B File Offset: 0x00718E8B
	private void SetSwitch(bool isHiddenBone, CharacterActorComponent actor)
	{
	}

	// Token: 0x06019083 RID: 102531 RVA: 0x0071AC8D File Offset: 0x00718E8D
	public void Clear()
	{
	}

	// Token: 0x0400C3E8 RID: 50152
	private const int BONE_HIDDEN_SWITCH = 4;

	// Token: 0x0400C3E9 RID: 50153
	public string BoneName = "";

	// Token: 0x0400C3EA RID: 50154
	public string SwitchGroup = "";

	// Token: 0x0400C3EB RID: 50155
	public string HiddenSwitch = "";

	// Token: 0x0400C3EC RID: 50156
	public string VisibleSwitch = "";

	// Token: 0x0400C3ED RID: 50157
	public bool LastHidden;
}
