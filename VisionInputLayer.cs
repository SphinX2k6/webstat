using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.Input.Structures;
using CSharpScript.Game.Input;

// Token: 0x020030AB RID: 12459
[NullableContext(2)]
[Nullable(0)]
public class VisionInputLayer : InputLayer
{
	// Token: 0x06019AC4 RID: 105156 RVA: 0x00776FC4 File Offset: 0x007751C4
	[NullableContext(1)]
	public void Init(EntityHandle entityHandle)
	{
		WorldEntity entity = entityHandle.Entity;
		this.VisionComp = ((entity != null) ? entity.GetComponent<CharacterVisionComponent>() : null);
		WorldEntity entity2 = entityHandle.Entity;
		this.AbilityComp = ((entity2 != null) ? entity2.GetComponent<CharacterAbilityComponent>() : null);
	}

	// Token: 0x06019AC5 RID: 105157 RVA: 0x00776FF6 File Offset: 0x007751F6
	public override void Clear()
	{
		this.VisionComp = null;
		this.AbilityComp = null;
	}

	// Token: 0x06019AC6 RID: 105158 RVA: 0x00777006 File Offset: 0x00775206
	public override EInputLayer GetLayerType()
	{
		return EInputLayer.Vision;
	}

	// Token: 0x06019AC7 RID: 105159 RVA: 0x0077700C File Offset: 0x0077520C
	public override SInputCommand HandlePress(EInputAction action, float time)
	{
		byte b = action;
		if (b != 4)
		{
			if (b == 9)
			{
				this.AbilityComp.SendGameplayEventToActor(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["幻象.Common.输入.声骸技能按下"]).Value, null);
				if (this.VisionComp.HandlePress(action, time))
				{
					return InputLayer.GetSwallowCommand();
				}
			}
		}
		else
		{
			this.AbilityComp.SendGameplayEventToActor(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["幻象.Common.输入.声骸技能攻击按下"]).Value, null);
			if (this.VisionComp.HandlePress(action, time))
			{
				return InputLayer.GetSwallowCommand();
			}
		}
		return null;
	}

	// Token: 0x06019AC8 RID: 105160 RVA: 0x007770B4 File Offset: 0x007752B4
	public override SInputCommand HandleRelease(EInputAction action, float time)
	{
		if (action == 9)
		{
			this.AbilityComp.SendGameplayEventToActor(GameplayTagUtils.GetGameplayTagById(GameplayTagDefine.EGameplayTagId["幻象.Common.输入.声骸技能抬起"]).Value, null);
		}
		return null;
	}

	// Token: 0x0400CC65 RID: 52325
	private CharacterVisionComponent VisionComp;

	// Token: 0x0400CC66 RID: 52326
	private CharacterAbilityComponent AbilityComp;
}
