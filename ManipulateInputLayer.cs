using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Core.Common;
using CSharpScript.Game.Input;
using CSharpScript.Game.NewWorld.Character.Common.Component;

// Token: 0x020030A5 RID: 12453
[NullableContext(2)]
[Nullable(0)]
public class ManipulateInputLayer : InputLayer
{
	// Token: 0x06019A96 RID: 105110 RVA: 0x0077638C File Offset: 0x0077458C
	[NullableContext(1)]
	public void Init(EntityHandle entityHandle)
	{
		WorldEntity entity = entityHandle.Entity;
		this.TagComp = entity.GetComponent<RoleTagComponent>();
		this.SkillComp = entity.GetComponent<CharacterSkillComponent>();
		this.CreatureDataComp = entity.GetComponent<CreatureDataComponent>();
	}

	// Token: 0x06019A97 RID: 105111 RVA: 0x007763C4 File Offset: 0x007745C4
	public override void Clear()
	{
		this.TagComp = null;
		this.SkillComp = null;
		this.CreatureDataComp = null;
	}

	// Token: 0x06019A98 RID: 105112 RVA: 0x007763DB File Offset: 0x007745DB
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Manipulate;
	}

	// Token: 0x06019A99 RID: 105113 RVA: 0x007763E0 File Offset: 0x007745E0
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		ManipulateSkillConfigData manipulateSkillConfig = this.GetManipulateSkillConfig();
		byte b = action;
		switch (b)
		{
		case 4:
			if (manipulateSkillConfig.CastSkillId != 0 && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.新版控物.输入.控物投掷禁止"]))
			{
				this.SkillComp.BeginSkill(manipulateSkillConfig.CastSkillId, new SkillParam
				{
					Reason = "Manipulate InputLayer, Item Throw"
				});
			}
			return InputLayer.GetSwallowCommand();
		case 5:
			break;
		case 6:
			if (this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.技能通用标识.控物拼图旋转.可用"]))
			{
				this.SkillComp.BeginSkill(210009, new SkillParam
				{
					Reason = "Manipulate InputLayer, Item Rotate"
				});
				return InputLayer.GetSwallowCommand();
			}
			break;
		case 7:
			if (!Singleton<Info>.Instance.IsInTouch())
			{
				if (manipulateSkillConfig.CancelSkillId != 0 && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.新版控物.输入.控物放下禁止"]))
				{
					this.SkillComp.BeginSkill(manipulateSkillConfig.CancelSkillId, new SkillParam
					{
						Reason = "Manipulate InputLayer, Item Release"
					});
				}
				return InputLayer.GetSwallowCommand();
			}
			break;
		default:
			if (b == 14)
			{
				this.SkillComp.BeginSkill(240001, new SkillParam
				{
					Reason = "Manipulate InputLayer, Item Rotate"
				});
				return InputLayer.GetSwallowCommand();
			}
			break;
		}
		if (ManipulateInputLayer.actionsForbid.Contains(action) && this.IsManipulating())
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A9A RID: 105114 RVA: 0x00776550 File Offset: 0x00774750
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (action == 7 && Singleton<Info>.Instance.IsInTouch())
		{
			int cancelSkillId = this.GetManipulateSkillConfig().CancelSkillId;
			if (cancelSkillId != 0 && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["角色.Common.探索技能.新版控物.输入.控物放下禁止"]))
			{
				this.SkillComp.BeginSkill(cancelSkillId, new SkillParam
				{
					Reason = "Manipulate InputLayer, Item Release"
				});
			}
			return InputLayer.GetSwallowCommand();
		}
		if (this.IsManipulating())
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A9B RID: 105115 RVA: 0x007765CF File Offset: 0x007747CF
	public override SInputCommand HandleHold(EInputAction action, float time)
	{
		if (this.IsManipulating())
		{
			return InputLayer.GetSwallowCommand();
		}
		return null;
	}

	// Token: 0x06019A9C RID: 105116 RVA: 0x007765E0 File Offset: 0x007747E0
	[NullableContext(1)]
	private ManipulateSkillConfigData GetManipulateSkillConfig()
	{
		CreatureDataComponent creatureDataComp = this.CreatureDataComp;
		return ManipulateSkillConfig.GetSkillConfig((creatureDataComp != null) ? creatureDataComp.GetRoleId() : 0);
	}

	// Token: 0x06019A9D RID: 105117 RVA: 0x007765FC File Offset: 0x007747FC
	private bool IsManipulating()
	{
		return this.TagComp.HasAnyTag(new int[]
		{
			GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.控物.控物中"],
			GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.控物.控物选取"],
			GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.控物.进入投掷"]
		}) && !this.TagComp.HasTag(GameplayTagDefine.EGameplayTagId["行为状态.逻辑状态.控物.可释放技能"]);
	}

	// Token: 0x0400CC59 RID: 52313
	private const int MANIPULATE_ROTATE_SKILL = 210009;

	// Token: 0x0400CC5A RID: 52314
	private const int MANIPULATE_PARABOLA_SKILL = 240001;

	// Token: 0x0400CC5B RID: 52315
	[Nullable(1)]
	[StaticVariableRuleIgnore]
	private static readonly List<EInputAction> actionsForbid = new List<EInputAction>
	{
		EInputAction.攻击,
		EInputAction.幻象1,
		EInputAction.幻象2,
		EInputAction.技能1,
		EInputAction.瞄准,
		EInputAction.大招
	};

	// Token: 0x0400CC5C RID: 52316
	private RoleTagComponent TagComp;

	// Token: 0x0400CC5D RID: 52317
	private CharacterSkillComponent SkillComp;

	// Token: 0x0400CC5E RID: 52318
	private CreatureDataComponent CreatureDataComp;
}
