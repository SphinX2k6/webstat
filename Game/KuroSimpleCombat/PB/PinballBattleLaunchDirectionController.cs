using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.KuroSimpleCombat.PB
{
	// Token: 0x02006FC1 RID: 28609
	[NullableContext(1)]
	[Nullable(0)]
	public class PinballBattleLaunchDirectionController
	{
		// Token: 0x060452A8 RID: 283304 RVA: 0x0120D5AA File Offset: 0x0120B7AA
		public void Init(PinballBattleLaunchDirectionItem directionItem)
		{
			this.DirectionItem = directionItem;
			this.DirectionActor = directionItem.GetRootActor();
		}

		// Token: 0x060452A9 RID: 283305 RVA: 0x0120D5BF File Offset: 0x0120B7BF
		public void Destroy()
		{
			this.DirectionItem = null;
			this.DirectionActor = null;
		}

		// Token: 0x060452AA RID: 283306 RVA: 0x0120D5D0 File Offset: 0x0120B7D0
		[NullableContext(2)]
		public void Update(AKSC_Shape2D_Entity_Bar leftBar, AKSC_Shape2D_Entity_Bar rightBar)
		{
			AKSC_Shape2D_Entity_Bar aksc_Shape2D_Entity_Bar = null;
			if (leftBar != null && leftBar.IsShowLaunchDirection)
			{
				aksc_Shape2D_Entity_Bar = leftBar;
			}
			else if (rightBar != null && rightBar.IsShowLaunchDirection)
			{
				aksc_Shape2D_Entity_Bar = rightBar;
			}
			if (aksc_Shape2D_Entity_Bar == null)
			{
				this.ShowLaunchDirection(false, null, 0f);
				return;
			}
			this.ShowLaunchDirection(true, new FVector?(aksc_Shape2D_Entity_Bar.LaunchStartPoint), aksc_Shape2D_Entity_Bar.LaunchRotation);
		}

		// Token: 0x060452AB RID: 283307 RVA: 0x0120D62C File Offset: 0x0120B82C
		private void ShowLaunchDirection(bool isShow, FVector? location = null, float rotation = 0f)
		{
			if (isShow && location != null)
			{
				this.Rotation.Yaw = rotation;
				AActor directionActor = this.DirectionActor;
				if (directionActor != null)
				{
					FVector value = location.Value;
					directionActor.D_K2_SetActorLocationAndRotation(value, this.Rotation.ToUeRotator(), false, ref WorldGlobal.SweepHitResult, true);
				}
			}
			if (this.IsShowLaunchDirection == isShow)
			{
				return;
			}
			this.IsShowLaunchDirection = isShow;
			if (isShow)
			{
				PinballBattleLaunchDirectionItem directionItem = this.DirectionItem;
				if (directionItem == null)
				{
					return;
				}
				directionItem.Show(null);
				return;
			}
			else
			{
				PinballBattleLaunchDirectionItem directionItem2 = this.DirectionItem;
				if (directionItem2 == null)
				{
					return;
				}
				directionItem2.Hide(null);
				return;
			}
		}

		// Token: 0x0402696F RID: 158063
		[Nullable(2)]
		private PinballBattleLaunchDirectionItem DirectionItem;

		// Token: 0x04026970 RID: 158064
		[Nullable(2)]
		private AActor DirectionActor;

		// Token: 0x04026971 RID: 158065
		private bool IsShowLaunchDirection;

		// Token: 0x04026972 RID: 158066
		private readonly Rotator Rotation = Rotator.Create(0f, 0f, 0f);

		// Token: 0x04026973 RID: 158067
		[StaticVariableRuleIgnore]
		private static readonly Stat UpdateStat = Stat.Create("PinballBattleLaunchDirectionController.Update", "", "");
	}
}
