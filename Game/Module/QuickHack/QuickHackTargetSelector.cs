using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.BattleUi;
using UnrealEngine;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x020052F9 RID: 21241
	[NullableContext(1)]
	[Nullable(0)]
	public abstract class QuickHackTargetSelector
	{
		// Token: 0x06036397 RID: 222103 RVA: 0x00DAA083 File Offset: 0x00DA8283
		public virtual void Init(int selectRange, int selectScreenRadius)
		{
			this.SelectRange = selectRange;
			if (selectScreenRadius < 0)
			{
				this.ScreenRadiusSquared = int.MaxValue;
				return;
			}
			this.ScreenRadiusSquared = selectScreenRadius * selectScreenRadius;
		}

		// Token: 0x06036398 RID: 222104 RVA: 0x00DAA0A5 File Offset: 0x00DA82A5
		public virtual void Clear()
		{
		}

		// Token: 0x06036399 RID: 222105 RVA: 0x00DAA0A7 File Offset: 0x00DA82A7
		public virtual void OnExecuteExtraEffect(EQuickHackSkillExtraEffect type)
		{
		}

		// Token: 0x0603639A RID: 222106
		public abstract bool UpdateTargetInfo(float delta);

		// Token: 0x0603639B RID: 222107
		public abstract IQuickHackLockTargetInfo GetLockTargetInfo();

		// Token: 0x0603639C RID: 222108
		public abstract IQuickHackOnScreenTargetInfo GetOnScreenTargetInfo();

		// Token: 0x0603639D RID: 222109 RVA: 0x00DAA0AC File Offset: 0x00DA82AC
		protected bool ProjectWorldToScreen(FVectorDouble worldLocation, Vector2D outScreenPosition, float extend = 0.1f)
		{
			TsCharacterController characterController = Global.CharacterController;
			if (characterController == null)
			{
				return false;
			}
			if (!UGameplayStatics.D_ProjectWorldToScreen(characterController, worldLocation, ref this.RefScreenPosition, false))
			{
				return false;
			}
			FVector2D refScreenPosition = this.RefScreenPosition;
			outScreenPosition.Set((double)refScreenPosition.X, (double)refScreenPosition.Y);
			BattleUiModel instance = ModelBase<BattleUiModel>.Instance;
			Vector2D viewportSize = instance.ViewportSize;
			double num = viewportSize.X * (double)extend;
			double num2 = viewportSize.Y * (double)extend;
			if (outScreenPosition.X < -num || outScreenPosition.X > viewportSize.X + num || outScreenPosition.Y < -num2 || outScreenPosition.Y > viewportSize.Y + num2)
			{
				return false;
			}
			outScreenPosition.MultiplyEqual((double)instance.ScreenPositionScale).AdditionEqual(instance.ScreenPositionOffset);
			outScreenPosition.Y = -outScreenPosition.Y;
			return true;
		}

		// Token: 0x0401F2DD RID: 127709
		protected int SelectRange;

		// Token: 0x0401F2DE RID: 127710
		protected int ScreenRadiusSquared;

		// Token: 0x0401F2DF RID: 127711
		private FVector2D RefScreenPosition;
	}
}
