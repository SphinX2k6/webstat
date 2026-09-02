using System;
using CSharpScript.Game.Render.Effect.ScreenEffectSystem;

// Token: 0x02002F9F RID: 12191
public class GameplayCueCameraEffect : GameplayCueBase
{
	// Token: 0x06018DC7 RID: 101831 RVA: 0x00709DBC File Offset: 0x00707FBC
	protected override void OnCreate()
	{
		if (!string.IsNullOrEmpty(this.CueConfig.Path) && this.EntityHandle.Entity.GetComponent<CharacterActorComponent>().IsAutonomousProxy && CharacterUtils.CanCharacterMonsterOrSummonedDisplayEffect(this.EntityHandle))
		{
			if (this.HandleId != 0)
			{
				ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.HandleId);
			}
			this.HandleId = ModelBase<ScreenEffectModel>.Instance.PlayScreenEffect(this.CueConfig.Path, null, null);
		}
	}

	// Token: 0x06018DC8 RID: 101832 RVA: 0x00709E34 File Offset: 0x00708034
	protected override void OnDestroy()
	{
		if (this.HandleId != 0)
		{
			ModelBase<ScreenEffectModel>.Instance.EndScreenEffect(this.HandleId);
			this.HandleId = 0;
		}
	}

	// Token: 0x06018DC9 RID: 101833 RVA: 0x00709E55 File Offset: 0x00708055
	public override void OnEnable()
	{
		this.OnCreate();
	}

	// Token: 0x06018DCA RID: 101834 RVA: 0x00709E5D File Offset: 0x0070805D
	public override void OnDisable()
	{
		this.OnDestroy();
	}

	// Token: 0x0400C228 RID: 49704
	private int HandleId;
}
