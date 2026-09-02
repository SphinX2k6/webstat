using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game;
using CSharpScript.Game.Module.BattleUi;
using CSharpScript.Game.Ui;
using UnrealEngine;

// Token: 0x02001FCF RID: 8143
public class HudUnitPositionUtil
{
	// Token: 0x0600F5D8 RID: 62936 RVA: 0x0043538C File Offset: 0x0043358C
	[NullableContext(1)]
	public bool ProjectWorldToScreen(FVectorDouble worldLocation, Vector2D outScreenPosition)
	{
		if (!UGameplayStatics.D_ProjectWorldToScreen(Global.CharacterController, worldLocation, ref this.ScreenPositionRef, false))
		{
			return false;
		}
		outScreenPosition.Set((double)this.ScreenPositionRef.X, (double)this.ScreenPositionRef.Y);
		BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
		outScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset);
		outScreenPosition.Y = -outScreenPosition.Y;
		return true;
	}

	// Token: 0x0600F5D9 RID: 62937 RVA: 0x004353FB File Offset: 0x004335FB
	public void LogViewPortInfo()
	{
		UUIItem uiRootItem = Singleton<UiLayer>.Instance.UiRootItem;
		ModelBase<BattleUiModel>.Instance.UpdateViewPortSize();
	}

	// Token: 0x040076E1 RID: 30433
	private FVector2D ScreenPositionRef = new FVector2D();
}
